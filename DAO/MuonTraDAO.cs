using Dapper;
using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace DAO
{
    public class MuonTraDAO
    {
        // Hàm này lấy kết nối ĐÃ MỞ từ DataProvider
        private static MySqlConnection GetOpenConnection()
        {
            return DataProvider.Instance.GetOpenConnection();
        }

        public static ThamSoMuonTraDTO LayThamSoMuonTra()
        {
            const string query = @"SELECT SoSachMuonToiDa, SoNgayMuonToiDa, DonGiaPhatMoiNgay, TuoiToiThieu, TuoiToiDa FROM THAMSO LIMIT 1";
            using var connection = GetOpenConnection();
            var thamSo = connection.QueryFirstOrDefault<ThamSoMuonTraDTO>(query);
            if (thamSo == null) throw new Exception("Chưa cấu hình bảng THAMSO.");
            return thamSo;
        }

        public static DocGiaMuonInfoDTO? LayThongTinDocGia(string maDocGia)
        {
            const string query = @"SELECT ID, MaDocGia, HoTen, NgaySinh, NgayHetHan, TongNoHienTai FROM DOCGIA WHERE MaDocGia = @MaDocGia";
            using var connection = GetOpenConnection();
            return connection.QueryFirstOrDefault<DocGiaMuonInfoDTO>(query, new { MaDocGia = maDocGia });
        }

        public static List<SachMuonLuaChonDTO> TimCuonSachSanSang(string keyword)
        {
            string query = @"SELECT cs.ID AS IDCuonSach, cs.MaCuonSach, ts.TenTuaSach AS TenSach,
                                    IFNULL(GROUP_CONCAT(DISTINCT tg.TenTacGia SEPARATOR ', '), 'Đang cập nhật') AS TacGia,
                                    nxb.TenNXB AS NhaXuatBan,
                                    IFNULL(GROUP_CONCAT(DISTINCT tsp.TenTinhTrang SEPARATOR ', '), 'Mới nguyên') AS TinhTrangHienTai
                             FROM CUONSACH cs
                             INNER JOIN SACH s ON cs.IDSach = s.ID AND s.DaAn = 0
                             INNER JOIN TUASACH ts ON s.IDTuaSach = ts.ID AND ts.DaAn = 0
                             INNER JOIN NHAXUATBAN nxb ON s.IDNhaXuatBan = nxb.ID
                             LEFT JOIN CT_TACGIA cttg ON cttg.IDTuaSach = ts.ID
                             LEFT JOIN TACGIA tg ON tg.ID = cttg.IDTacGia
                             LEFT JOIN CUONSACH_TINHTRANG cst ON cst.IDCuonSach = cs.ID
                             LEFT JOIN THAMSOPHAT tsp ON tsp.ID = cst.IDThamSoPhat
                             WHERE cs.TrangThai = 1 AND cs.DaAn = 0 ";

            var parameters = new DynamicParameters();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query += " AND (ts.TenTuaSach LIKE @Keyword OR cs.MaCuonSach LIKE @Keyword)";
                parameters.Add("Keyword", $"%{keyword}%");
            }

            query += " GROUP BY cs.ID, cs.MaCuonSach, ts.TenTuaSach, nxb.TenNXB ORDER BY ts.TenTuaSach LIMIT 50";

            using var connection = GetOpenConnection();
            return connection.Query<SachMuonLuaChonDTO>(query, parameters).ToList();
        }

        public static int DemSoSachDangMuon(int idDocGia)
        {
            const string query = @"SELECT COUNT(*) FROM CT_PHIEUMUON cp
                                   INNER JOIN PHIEUMUON p ON cp.IDPhieuMuon = p.ID
                                   WHERE p.IDDocGia = @IDDocGia AND cp.NgayTraThucTe IS NULL";
            using var connection = GetOpenConnection();
            return connection.ExecuteScalar<int>(query, new { IDDocGia = idDocGia });
        }

        // ========================================================================
        // 1. TẠO PHIẾU MƯỢN (ĐÃ SỬA LỖI)
        // ========================================================================
        public static int TaoPhieuMuon(PhieuMuonDTO phieu, List<SachMuonLuaChonDTO> danhSachCuon)
        {
            using var connection = GetOpenConnection(); // Kết nối đã mở sẵn
                                                        // KHÔNG GỌI connection.Open() Ở ĐÂY NỮA

            using var transaction = connection.BeginTransaction();

            try
            {
                string maMoi = TaoMaPhieuMuonMoi(connection, transaction);

                const string insertPhieu = @"INSERT INTO PHIEUMUON (MaPhieuMuon, IDDocGia, NgayMuon, NgayTraDuKien)
                                             VALUES (@MaPhieu, (SELECT ID FROM DOCGIA WHERE MaDocGia = @MaDG), @NgayMuon, @HanTra);
                                             SELECT LAST_INSERT_ID();";

                int idPhieu = connection.ExecuteScalar<int>(insertPhieu, new
                {
                    MaPhieu = maMoi,
                    MaDG = phieu.MaDocGia,
                    NgayMuon = phieu.NgayMuon,
                    HanTra = phieu.NgayTraDuKien
                }, transaction);

                foreach (var sach in danhSachCuon)
                {
                    // p_DanhSachLoiMoi là chuỗi ID lỗi, VD: "2,4,5"
                    connection.Execute("SP_ThemSachVaoPhieuMuon", new
                    {
                        p_IDPhieuMuon = idPhieu,
                        p_IDCuonSach = sach.IDCuonSach,
                        p_DanhSachLoiMoi = sach.DanhSachLoiMoi
                    }, transaction, commandType: CommandType.StoredProcedure);
                }

                transaction.Commit();
                return idPhieu;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        // ========================================================================
        // 2. TẠO PHIẾU TRẢ (ĐÃ SỬA LỖI)
        // ========================================================================
        public static int TaoPhieuTra(int idPhieuMuon, List<ChiTietPhieuMuonDTO> danhSachTra)
        {
            using var connection = GetOpenConnection(); // Kết nối đã mở sẵn
                                                        // KHÔNG GỌI connection.Open() Ở ĐÂY NỮA

            using var transaction = connection.BeginTransaction();

            try
            {
                string maMoi = TaoMaPhieuTraMoi(connection, transaction);

                const string insertPhieu = @"INSERT INTO PHIEUTRA (MaPhieuTra, IDPhieuMuon, NgayTra, TongTienPhat)
                                             VALUES (@MaPhieu, @IDPM, NOW(), 0);
                                             SELECT LAST_INSERT_ID();";

                int idPhieuTra = connection.ExecuteScalar<int>(insertPhieu, new { MaPhieu = maMoi, IDPM = idPhieuMuon }, transaction);

                foreach (var item in danhSachTra)
                {
                    // A. Insert CT_PHIEUTRA (Trigger hồi phục kho chạy tại đây)
                    const string insertCT = @"INSERT INTO CT_PHIEUTRA (IDPhieuTra, IDCuonSach, TienPhat) 
                                              VALUES (@IDPT, @IDCuon, 0);"; // TienPhat sẽ do Trigger update
                    connection.Execute(insertCT, new { IDPT = idPhieuTra, IDCuon = item.IDCuonSach }, transaction);

                    // B. Insert Tình Trạng Trả (Xử lý chuỗi ID: "2,4,5")
                    if (!string.IsNullOrEmpty(item.DanhSachIdLoiTra))
                    {
                        var ids = item.DanhSachIdLoiTra.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        const string insertTinhTrang = @"INSERT INTO CT_PHIEUTRA_TINHTRANG (IDPhieuTra, IDCuonSach, IDThamSoPhat)
                                                         VALUES (@IDPT, @IDCuon, @IDThamSo);";
                        foreach (var idStr in ids)
                        {
                            if (int.TryParse(idStr, out int idLoi))
                            {
                                connection.Execute(insertTinhTrang, new { IDPT = idPhieuTra, IDCuon = item.IDCuonSach, IDThamSo = idLoi }, transaction);
                            }
                        }
                    }
                    else
                    {
                        // Mặc định trả về Mới nếu không chọn gì
                        var idMoi = connection.ExecuteScalar<int>("SELECT ID FROM THAMSOPHAT WHERE CoLaMacDinh = 1 LIMIT 1", transaction: transaction);
                        connection.Execute("INSERT INTO CT_PHIEUTRA_TINHTRANG (IDPhieuTra, IDCuonSach, IDThamSoPhat) VALUES (@IDPT, @IDCuon, @IDMoi)",
                            new { IDPT = idPhieuTra, IDCuon = item.IDCuonSach, IDMoi = idMoi }, transaction);
                    }
                }

                transaction.Commit();
                return idPhieuTra;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        // ========================================================================
        // 3. QUERY DỮ LIỆU
        // ========================================================================

        public static List<PhieuMuonDTO> LayDSPhieuMuon()
        {
            const string query = @"SELECT pm.ID, pm.MaPhieuMuon, dg.MaDocGia, dg.HoTen AS HoTenDocGia, pm.NgayMuon, pm.NgayTraDuKien,
                                          COUNT(cp.IDCuonSach) AS TongSach,
                                          SUM(CASE WHEN cp.NgayTraThucTe IS NULL THEN 1 ELSE 0 END) AS SoSachChuaTra,
                                          pm.TongPhat
                                   FROM PHIEUMUON pm
                                   INNER JOIN DOCGIA dg ON pm.IDDocGia = dg.ID
                                   LEFT JOIN CT_PHIEUMUON cp ON cp.IDPhieuMuon = pm.ID
                                   GROUP BY pm.ID ORDER BY pm.NgayMuon DESC";
            using var connection = GetOpenConnection();
            return connection.Query<PhieuMuonDTO>(query).ToList();
        }

        public static List<ChiTietPhieuMuonDTO> LayChiTietMuon(int idPhieuMuon)
        {
            // Join SACH để lấy DonGia tính phạt
            const string query = @"SELECT cp.IDPhieuMuon, cp.IDCuonSach, cs.MaCuonSach, ts.TenTuaSach AS TenSach, 
                                          s.DonGia, -- Giá sách
                                          pm.NgayMuon, cp.NgayTraThucTe, pm.NgayTraDuKien,
                                          
                                          -- Lấy chuỗi tình trạng lúc mượn
                                          (SELECT GROUP_CONCAT(tsp.TenTinhTrang SEPARATOR ', ') 
                                           FROM CT_PHIEUMUON_TINHTRANG ctt 
                                           JOIN THAMSOPHAT tsp ON ctt.IDThamSoPhat = tsp.ID 
                                           WHERE ctt.IDPhieuMuon = cp.IDPhieuMuon AND ctt.IDCuonSach = cp.IDCuonSach) AS TinhTrangMuon,
                                          
                                          -- Lấy danh sách ID lỗi mượn để so sánh
                                          (SELECT GROUP_CONCAT(ctt.IDThamSoPhat) 
                                           FROM CT_PHIEUMUON_TINHTRANG ctt 
                                           WHERE ctt.IDPhieuMuon = cp.IDPhieuMuon AND ctt.IDCuonSach = cp.IDCuonSach) AS DanhSachIdLoiMuon

                                   FROM CT_PHIEUMUON cp
                                   INNER JOIN CUONSACH cs ON cp.IDCuonSach = cs.ID
                                   INNER JOIN SACH s ON cs.IDSach = s.ID
                                   INNER JOIN TUASACH ts ON s.IDTuaSach = ts.ID
                                   INNER JOIN PHIEUMUON pm ON pm.ID = cp.IDPhieuMuon
                                   WHERE cp.IDPhieuMuon = @ID";
            using var connection = GetOpenConnection();
            return connection.Query<ChiTietPhieuMuonDTO>(query, new { ID = idPhieuMuon }).ToList();
        }

        public static PhieuMuonDTO? LayPhieuMuon(string? maPhieu, int? idPhieu)
        {
            string query = @"SELECT pm.ID, pm.MaPhieuMuon, dg.MaDocGia, dg.HoTen AS HoTenDocGia, pm.NgayMuon, pm.NgayTraDuKien,
                                    COUNT(cp.IDCuonSach) AS TongSach,
                                    SUM(CASE WHEN cp.NgayTraThucTe IS NULL THEN 1 ELSE 0 END) AS SoSachChuaTra,
                                    pm.TongPhat
                             FROM PHIEUMUON pm
                             INNER JOIN DOCGIA dg ON pm.IDDocGia = dg.ID
                             LEFT JOIN CT_PHIEUMUON cp ON cp.IDPhieuMuon = pm.ID
                             WHERE 1=1 ";

            if (idPhieu.HasValue) query += " AND pm.ID = @ID ";
            if (!string.IsNullOrEmpty(maPhieu)) query += " AND pm.MaPhieuMuon = @Ma ";

            query += " GROUP BY pm.ID";

            using var connection = GetOpenConnection();
            return connection.QueryFirstOrDefault<PhieuMuonDTO>(query, new { ID = idPhieu, Ma = maPhieu });
        }

        public static List<PhieuTraDTO> LayDSPhieuTra()
        {
            const string query = @"SELECT pt.ID, pt.MaPhieuTra, pm.MaPhieuMuon, dg.HoTen AS HoTenDocGia, 
                                          pt.NgayTra, pt.TongTienPhat,
                                          COUNT(ct.IDCuonSach) AS TongSachTra
                                   FROM PHIEUTRA pt
                                   JOIN PHIEUMUON pm ON pt.IDPhieuMuon = pm.ID
                                   JOIN DOCGIA dg ON pm.IDDocGia = dg.ID
                                   LEFT JOIN CT_PHIEUTRA ct ON ct.IDPhieuTra = pt.ID
                                   GROUP BY pt.ID ORDER BY pt.NgayTra DESC";
            using var connection = GetOpenConnection();
            return connection.Query<PhieuTraDTO>(query).ToList();
        }

        public static List<ChiTietPhieuTraDTO> LayChiTietTra(int idPhieuTra)
        {
            const string query = @"SELECT ct.IDCuonSach, cs.MaCuonSach, ts.TenTuaSach AS TenSach, 
                                          pm.NgayMuon, pm.NgayTraDuKien, pt.NgayTra AS NgayTraThucTe,
                                          ct.TienPhat, 
                                          
                                          (SELECT GROUP_CONCAT(tsp.TenTinhTrang SEPARATOR ', ') 
                                           FROM CT_PHIEUTRA_TINHTRANG ctt 
                                           JOIN THAMSOPHAT tsp ON ctt.IDThamSoPhat = tsp.ID 
                                           WHERE ctt.IDPhieuTra = ct.IDPhieuTra AND ctt.IDCuonSach = ct.IDCuonSach) AS TinhTrangTra

                                   FROM CT_PHIEUTRA ct
                                   JOIN PHIEUTRA pt ON ct.IDPhieuTra = pt.ID
                                   JOIN PHIEUMUON pm ON pt.IDPhieuMuon = pm.ID
                                   JOIN CUONSACH cs ON ct.IDCuonSach = cs.ID
                                   JOIN SACH s ON cs.IDSach = s.ID
                                   JOIN TUASACH ts ON s.IDTuaSach = ts.ID
                                   WHERE ct.IDPhieuTra = @ID";
            using var connection = GetOpenConnection();
            return connection.Query<ChiTietPhieuTraDTO>(query, new { ID = idPhieuTra }).ToList();
        }

        public static PhieuTraDTO? LayPhieuTra(int id)
        {
            const string query = @"SELECT pt.*, pm.MaPhieuMuon, dg.HoTen AS HoTenDocGia, dg.MaDocGia 
                                   FROM PHIEUTRA pt
                                   JOIN PHIEUMUON pm ON pt.IDPhieuMuon = pm.ID
                                   JOIN DOCGIA dg ON pm.IDDocGia = dg.ID
                                   WHERE pt.ID = @ID";
            using var connection = GetOpenConnection();
            return connection.QueryFirstOrDefault<PhieuTraDTO>(query, new { ID = id });
        }

        public static bool GiaHanPhieuMuon(int idPhieuMuon, DateTime hanTraMoi)
        {
            const string query = "UPDATE PHIEUMUON SET NgayTraDuKien = @HanTraMoi WHERE ID = @ID";
            using var connection = GetOpenConnection();
            int count = connection.Execute(query, new { HanTraMoi = hanTraMoi, ID = idPhieuMuon });
            return count > 0;
        }

        // ========================================================================
        // 4. HÀM HỖ TRỢ SINH MÃ (Private, dùng chung Connection của Transaction)
        // ========================================================================
        private static string TaoMaPhieuMuonMoi(MySqlConnection conn, MySqlTransaction tran)
        {
            string lastMa = conn.QueryFirstOrDefault<string>("SELECT MaPhieuMuon FROM PHIEUMUON ORDER BY ID DESC LIMIT 1", transaction: tran);
            if (string.IsNullOrEmpty(lastMa)) return "PM000001";
            int next = int.Parse(lastMa.Substring(2)) + 1;
            return "PM" + next.ToString("D6");
        }

        private static string TaoMaPhieuTraMoi(MySqlConnection conn, MySqlTransaction tran)
        {
            string lastMa = conn.QueryFirstOrDefault<string>("SELECT MaPhieuTra FROM PHIEUTRA ORDER BY ID DESC LIMIT 1", transaction: tran);
            if (string.IsNullOrEmpty(lastMa)) return "PT000001";
            int next = int.Parse(lastMa.Substring(2)) + 1;
            return "PT" + next.ToString("D6");
        }

        // --- XÓA PHIẾU MƯỢN (Xử lý toàn vẹn) ---
        public static bool XoaPhieuMuon(int id)
        {
            using var connection = GetOpenConnection();
            using var transaction = connection.BeginTransaction();
            try
            {
                // 1. Lấy danh sách sách trong phiếu này
                var listCuon = connection.Query<int>("SELECT IDCuonSach FROM CT_PHIEUMUON WHERE IDPhieuMuon = @ID", new { ID = id }, transaction).ToList();

                // 2. Xóa các ràng buộc tình trạng mượn
                connection.Execute("DELETE FROM CT_PHIEUMUON_TINHTRANG WHERE IDPhieuMuon = @ID", new { ID = id }, transaction);

                // 3. Xóa chi tiết phiếu mượn
                connection.Execute("DELETE FROM CT_PHIEUMUON WHERE IDPhieuMuon = @ID", new { ID = id }, transaction);

                // 4. Cập nhật lại sách: Tăng tồn kho và set trạng thái Sẵn sàng (1)
                foreach (var idCuon in listCuon)
                {
                    // Lấy ID sách gốc (lô sách) để tăng tồn kho
                    int idSach = connection.ExecuteScalar<int>("SELECT IDSach FROM CUONSACH WHERE ID = @ID", new { ID = idCuon }, transaction);
                    connection.Execute("UPDATE SACH SET SoLuongConLai = SoLuongConLai + 1 WHERE ID = @ID", new { ID = idSach }, transaction);

                    // Set cuốn sách về Sẵn sàng (Trừ khi nó đã bị Hỏng/Mất từ trước khi mượn - nhưng logic mượn chỉ cho mượn sách sẵn sàng nên set về 1 là an toàn)
                    connection.Execute("UPDATE CUONSACH SET TrangThai = 1 WHERE ID = @ID", new { ID = idCuon }, transaction);

                    // Reset tình trạng sách về "Mới" hoặc tình trạng mặc định nếu cần (Tùy chọn)
                    // Ở đây ta giữ nguyên tình trạng cũ của sách trong CUONSACH_TINHTRANG vì xóa phiếu mượn coi như chưa từng mượn
                }

                // 5. Xóa phiếu mượn
                int rows = connection.Execute("DELETE FROM PHIEUMUON WHERE ID = @ID", new { ID = id }, transaction);

                transaction.Commit();
                return rows > 0;
            }
            catch { transaction.Rollback(); throw; }
        }

        // --- XÓA PHIẾU TRẢ (Hồi phục trạng thái đang mượn) ---
        public static bool XoaPhieuTra(int id)
        {
            using var connection = GetOpenConnection();
            using var transaction = connection.BeginTransaction();
            try
            {
                int idPhieuMuon = connection.ExecuteScalar<int>("SELECT IDPhieuMuon FROM PHIEUTRA WHERE ID = @ID", new { ID = id }, transaction);
                decimal tongPhatPhieuTra = connection.ExecuteScalar<decimal>("SELECT TongTienPhat FROM PHIEUTRA WHERE ID = @ID", new { ID = id }, transaction);
                int idDocGia = connection.ExecuteScalar<int>("SELECT IDDocGia FROM PHIEUMUON WHERE ID = @ID", new { ID = idPhieuMuon }, transaction);

                var listCuonTra = connection.Query<int>("SELECT IDCuonSach FROM CT_PHIEUTRA WHERE IDPhieuTra = @ID", new { ID = id }, transaction).ToList();

                connection.Execute("DELETE FROM CT_PHIEUTRA_TINHTRANG WHERE IDPhieuTra = @ID", new { ID = id }, transaction);
                connection.Execute("DELETE FROM CT_PHIEUTRA WHERE IDPhieuTra = @ID", new { ID = id }, transaction);

                foreach (var idCuon in listCuonTra)
                {
                    // Lỗi xảy ra ở đây: Bảng CT_PHIEUMUON không có cột TienPhat ở database mới
                    // Ta chỉ cần set NgayTraThucTe về NULL
                    connection.Execute(@"UPDATE CT_PHIEUMUON SET NgayTraThucTe = NULL WHERE IDPhieuMuon = @IDPM AND IDCuonSach = @IDCS",
                                         new { IDPM = idPhieuMuon, IDCS = idCuon }, transaction);

                    connection.Execute("UPDATE CUONSACH SET TrangThai = 0 WHERE ID = @ID", new { ID = idCuon }, transaction);

                    int idSach = connection.ExecuteScalar<int>("SELECT IDSach FROM CUONSACH WHERE ID = @ID", new { ID = idCuon }, transaction);
                    connection.Execute("UPDATE SACH SET SoLuongConLai = SoLuongConLai - 1 WHERE ID = @ID", new { ID = idSach }, transaction);
                }

                if (tongPhatPhieuTra > 0)
                {
                    connection.Execute("UPDATE DOCGIA SET TongNoHienTai = TongNoHienTai - @Tien WHERE ID = @ID", new { Tien = tongPhatPhieuTra, ID = idDocGia }, transaction);
                    connection.Execute("UPDATE PHIEUMUON SET TongPhat = TongPhat - @Tien WHERE ID = @ID", new { Tien = tongPhatPhieuTra, ID = idPhieuMuon }, transaction);
                }

                connection.Execute("UPDATE PHIEUMUON SET TrangThai = 1 WHERE ID = @ID", new { ID = idPhieuMuon }, transaction);
                int rows = connection.Execute("DELETE FROM PHIEUTRA WHERE ID = @ID", new { ID = id }, transaction);

                transaction.Commit();
                return rows > 0;
            }
            catch { transaction.Rollback(); throw; }
        }
    }
}