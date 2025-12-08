using Dapper;
using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DAO
{
    public class MuonTraDAO
    {
        private static MySqlConnection OpenConnection()
        {
            return DataProvider.Instance.GetOpenConnection();
        }

        public static ThamSoMuonTraDTO LayThamSoMuonTra()
        {
            const string query = @"SELECT SoSachMuonToiDa, SoNgayMuonToiDa, DonGiaPhatMoiNgay, TuoiToiThieu, TuoiToiDa FROM THAMSO LIMIT 1";
            using var connection = OpenConnection();
            var thamSo = connection.QueryFirstOrDefault<ThamSoMuonTraDTO>(query);

            if (thamSo == null)
                throw new Exception("Chưa cấu hình bảng THAMSO.");

            return thamSo;
        }

        public static DocGiaMuonInfoDTO? LayThongTinDocGia(string maDocGia)
        {
            const string query = @"SELECT ID, MaDocGia, HoTen, NgaySinh, NgayHetHan, TongNoHienTai FROM DOCGIA WHERE MaDocGia = @MaDocGia";
            using var connection = OpenConnection();
            return connection.QueryFirstOrDefault<DocGiaMuonInfoDTO>(query, new { MaDocGia = maDocGia });
        }

        public static int? LayIDCuonSach(string maCuonSach)
        {
            const string query = "SELECT ID FROM CUONSACH WHERE MaCuonSach = @Ma";
            using var connection = OpenConnection();
            return connection.QuerySingleOrDefault<int?>(query, new { Ma = maCuonSach });
        }

        public static bool CuonSachSanSang(int idCuonSach)
        {
            const string query = "SELECT TinhTrang FROM CUONSACH WHERE ID = @ID";
            using var connection = OpenConnection();
            int? tinhTrang = connection.QuerySingleOrDefault<int?>(query, new { ID = idCuonSach });
            return tinhTrang == 1;
        }

        public static int DemSoSachDangMuon(int idDocGia)
        {
            const string query = @"SELECT COUNT(*) FROM CT_PHIEUMUON cp
                             INNER JOIN PHIEUMUON p ON cp.IDPhieuMuon = p.ID
                             WHERE p.IDDocGia = @IDDocGia AND cp.NgayTraThucTe IS NULL";
            using var connection = OpenConnection();
            return connection.ExecuteScalar<int>(query, new { IDDocGia = idDocGia });
        }

        private static string TaoMaPhieuMuonMoi(MySqlConnection connection, MySqlTransaction transaction)
        {
            const string query = "SELECT MaPhieuMuon FROM PHIEUMUON ORDER BY ID DESC LIMIT 1";
            string? maCuoi = connection.QueryFirstOrDefault<string>(query, transaction: transaction);

            if (string.IsNullOrEmpty(maCuoi))
            {
                return "PM000001";
            }

            string phanSo = maCuoi.Substring(2);
            int so = int.Parse(phanSo) + 1;
            return "PM" + so.ToString("D6");
        }

        private static string TaoMaPhieuTraMoi(MySqlConnection connection, MySqlTransaction transaction)
        {
            const string query = "SELECT MaPhieuTra FROM PHIEUTRA ORDER BY ID DESC LIMIT 1";
            string? maCuoi = connection.QueryFirstOrDefault<string>(query, transaction: transaction);

            if (string.IsNullOrEmpty(maCuoi))
            {
                return "PT000001";
            }

            string phanSo = maCuoi.Substring(2);
            int so = int.Parse(phanSo) + 1;
            return "PT" + so.ToString("D6");
        }

        public static PhieuMuonDTO TaoPhieuMuonVaChiTiet(DocGiaMuonInfoDTO docGia, List<int> danhSachCuon,
            DateTime ngayMuon, DateTime ngayTraDuKien)
        {
            PhieuMuonDTO phieu = new();

            bool success = DataProvider.Instance.ExecuteTransaction((connection, transaction) =>
            {
                string maMoi = TaoMaPhieuMuonMoi(connection, transaction);
                const string queryInsert = @"INSERT INTO PHIEUMUON (MaPhieuMuon, IDDocGia, NgayMuon, NgayTraDuKien)
                                        VALUES (@MaPhieuMuon, @IDDocGia, @NgayMuon, @NgayTraDuKien);
                                        SELECT LAST_INSERT_ID();";

                long idResult = connection.ExecuteScalar<long>(queryInsert, new
                {
                    MaPhieuMuon = maMoi,
                    IDDocGia = docGia.ID,
                    NgayMuon = ngayMuon,
                    NgayTraDuKien = ngayTraDuKien
                }, transaction);

                if (idResult == 0)
                {
                    return false;
                }

                int idPhieu = Convert.ToInt32(idResult);
                foreach (int idCuon in danhSachCuon)
                {
                    const string queryCT = @"INSERT INTO CT_PHIEUMUON (IDPhieuMuon, IDCuonSach)
                                        VALUES (@IDPhieuMuon, @IDCuonSach);";
                    connection.Execute(queryCT, new { IDPhieuMuon = idPhieu, IDCuonSach = idCuon }, transaction);

                    const string queryUpdateCuon = "UPDATE CUONSACH SET TinhTrang = 0 WHERE ID = @IDCuon";
                    connection.Execute(queryUpdateCuon, new { IDCuon = idCuon }, transaction);
                }

                phieu = new PhieuMuonDTO
                {
                    ID = idPhieu,
                    MaPhieuMuon = maMoi,
                    MaDocGia = docGia.MaDocGia,
                    HoTenDocGia = docGia.HoTen,
                    NgayMuon = ngayMuon,
                    NgayTraDuKien = ngayTraDuKien,
                    TongSach = danhSachCuon.Count,
                    SoSachChuaTra = danhSachCuon.Count
                };
                return true;
            });

            if (!success)
                throw new Exception("Không thể tạo phiếu mượn.");

            return phieu;
        }

        public static BindingList<PhieuMuonDTO> LayTatCaPhieuMuon()
        {
            BindingList<PhieuMuonDTO> list = new BindingList<PhieuMuonDTO>();
            const string query = @"SELECT pm.ID, pm.MaPhieuMuon, dg.MaDocGia, dg.HoTen AS HoTenDocGia, pm.NgayMuon, pm.NgayTraDuKien,
                                    COUNT(cp.IDCuonSach) AS TongSach,
                                    SUM(CASE WHEN cp.NgayTraThucTe IS NULL THEN 1 ELSE 0 END) AS SoSachChuaTra,
                                    MAX(cp.NgayTraThucTe) AS NgayTraThucTe
                             FROM PHIEUMUON pm
                             INNER JOIN DOCGIA dg ON pm.IDDocGia = dg.ID
                             LEFT JOIN CT_PHIEUMUON cp ON cp.IDPhieuMuon = pm.ID
                             GROUP BY pm.ID, pm.MaPhieuMuon, dg.MaDocGia, dg.HoTen, pm.NgayMuon, pm.NgayTraDuKien
                             ORDER BY pm.NgayMuon DESC";
            using var connection = OpenConnection();
            var phieuMuonList = connection.Query<PhieuMuonDTO>(query).ToList();
            return new BindingList<PhieuMuonDTO>(phieuMuonList);
        }

        public static PhieuMuonDTO? LayPhieuMuonTheoID(int idPhieuMuon)
        {
            const string query = @"SELECT pm.ID, pm.MaPhieuMuon, dg.MaDocGia, dg.HoTen AS HoTenDocGia, pm.NgayMuon, pm.NgayTraDuKien,
                                    COUNT(cp.IDCuonSach) AS TongSach,
                                    SUM(CASE WHEN cp.NgayTraThucTe IS NULL THEN 1 ELSE 0 END) AS SoSachChuaTra,
                                    MAX(cp.NgayTraThucTe) AS NgayTraThucTe
                             FROM PHIEUMUON pm
                             INNER JOIN DOCGIA dg ON pm.IDDocGia = dg.ID
                             LEFT JOIN CT_PHIEUMUON cp ON cp.IDPhieuMuon = pm.ID
                             WHERE pm.ID = @ID
                             GROUP BY pm.ID, pm.MaPhieuMuon, dg.MaDocGia, dg.HoTen, pm.NgayMuon, pm.NgayTraDuKien";
            using var connection = OpenConnection();
            return connection.QueryFirstOrDefault<PhieuMuonDTO>(query, new { ID = idPhieuMuon });
        }

        public static PhieuMuonDTO? LayPhieuMuonTheoMa(string maPhieuMuon)
        {
            const string query = @"SELECT pm.ID, pm.MaPhieuMuon, dg.MaDocGia, dg.HoTen AS HoTenDocGia, pm.NgayMuon, pm.NgayTraDuKien,
                                    COUNT(cp.IDCuonSach) AS TongSach,
                                    SUM(CASE WHEN cp.NgayTraThucTe IS NULL THEN 1 ELSE 0 END) AS SoSachChuaTra,
                                    MAX(cp.NgayTraThucTe) AS NgayTraThucTe
                             FROM PHIEUMUON pm
                             INNER JOIN DOCGIA dg ON pm.IDDocGia = dg.ID
                             LEFT JOIN CT_PHIEUMUON cp ON cp.IDPhieuMuon = pm.ID
                             WHERE pm.MaPhieuMuon = @MaPhieu
                             GROUP BY pm.ID, pm.MaPhieuMuon, dg.MaDocGia, dg.HoTen, pm.NgayMuon, pm.NgayTraDuKien";

            using var connection = OpenConnection();
            return connection.QueryFirstOrDefault<PhieuMuonDTO>(query, new { MaPhieu = maPhieuMuon });
        }

        public static BindingList<ChiTietPhieuMuonDTO> LayChiTietPhieuMuon(int idPhieuMuon)
        {
            const string query = @"SELECT cp.IDPhieuMuon, cp.IDCuonSach, cs.MaCuonSach, ts.TenTuaSach AS TenSach, cp.NgayTraThucTe, pm.NgayTraDuKien,
                                    cp.TinhTrangMuon, cp.TinhTrangTra
                             FROM CT_PHIEUMUON cp
                             INNER JOIN CUONSACH cs ON cp.IDCuonSach = cs.ID
                             INNER JOIN SACH s ON cs.IDSach = s.ID
                             INNER JOIN TUASACH ts ON s.IDTuaSach = ts.ID
                             INNER JOIN PHIEUMUON pm ON pm.ID = cp.IDPhieuMuon
                             WHERE cp.IDPhieuMuon = @ID";
            using var connection = OpenConnection();
            var list = connection.Query<ChiTietPhieuMuonDTO>(query, new { ID = idPhieuMuon }).ToList();
            return new BindingList<ChiTietPhieuMuonDTO>(list);
        }

        public static bool CapNhatTinhTrangCuonSach(int idPhieuMuon, int idCuonSach, string tinhTrangMuon, string? tinhTrangTra, bool daTra)
        {
            string chiTietCuon = string.IsNullOrWhiteSpace(tinhTrangTra) ? tinhTrangMuon : tinhTrangTra;

            return DataProvider.Instance.ExecuteTransaction((connection, transaction) =>
            {
                const string updateChiTiet = @"UPDATE CT_PHIEUMUON
                                              SET TinhTrangMuon = @TinhTrangMuon,
                                                  TinhTrangTra = @TinhTrangTra,
                                                  NgayTraThucTe = CASE WHEN @DaTra = 1 THEN IFNULL(NgayTraThucTe, CURRENT_DATE()) ELSE NgayTraThucTe END
                                              WHERE IDPhieuMuon = @IDPhieuMuon AND IDCuonSach = @IDCuonSach";

                connection.Execute(updateChiTiet, new
                {
                    TinhTrangMuon = tinhTrangMuon,
                    TinhTrangTra = (object?)tinhTrangTra ?? DBNull.Value,
                    DaTra = daTra ? 1 : 0,
                    IDPhieuMuon = idPhieuMuon,
                    IDCuonSach = idCuonSach
                }, transaction);

                const string updateCuon = @"UPDATE CUONSACH
                                         SET ChiTietTinhTrang = @ChiTietTinhTrang,
                                             TinhTrang = CASE WHEN @DaTra = 1 THEN 1 ELSE TinhTrang END
                                         WHERE ID = @IDCuon";

                connection.Execute(updateCuon, new
                {
                    ChiTietTinhTrang = (object?)chiTietCuon ?? DBNull.Value,
                    DaTra = daTra ? 1 : 0,
                    IDCuon = idCuonSach
                }, transaction);

                const string queryDemChuaTra = "SELECT COUNT(*) FROM CT_PHIEUMUON WHERE IDPhieuMuon = @ID AND NgayTraThucTe IS NULL";
                int soSachChuaTra = connection.ExecuteScalar<int>(queryDemChuaTra, new { ID = idPhieuMuon }, transaction);

                const string updateTrangThaiPhieu = "UPDATE PHIEUMUON SET TrangThai = CASE WHEN @ConSach = 0 THEN 0 ELSE 1 END WHERE ID = @ID";
                connection.Execute(updateTrangThaiPhieu, new { ConSach = soSachChuaTra, ID = idPhieuMuon }, transaction);
                return true;
            });
        }

        public static bool GiaHanPhieuMuon(int idPhieuMuon, DateTime hanTraMoi)
        {
            const string query = "UPDATE PHIEUMUON SET NgayTraDuKien = @HanTraMoi WHERE ID = @ID";
            using var connection = OpenConnection();
            int count = connection.Execute(query, new { HanTraMoi = hanTraMoi, ID = idPhieuMuon });
            return count > 0;
        }

        public static bool XoaPhieuMuon(int idPhieuMuon)
        {
            return DataProvider.Instance.ExecuteTransaction((connection, transaction) =>
            {
                const string queryCheck = @"SELECT COUNT(*) FROM CT_PHIEUMUON WHERE IDPhieuMuon = @ID AND NgayTraThucTe IS NOT NULL";
                int coLichSuTra = connection.ExecuteScalar<int>(queryCheck, new { ID = idPhieuMuon }, transaction);
                if (coLichSuTra > 0)
                {
                    throw new Exception("Phiếu đã có lịch sử trả, không thể xóa.");
                }

                const string queryCuon = "SELECT IDCuonSach FROM CT_PHIEUMUON WHERE IDPhieuMuon = @ID";
                List<int> cuonSach = connection.Query<int>(queryCuon, new { ID = idPhieuMuon }, transaction).ToList();

                const string deleteCT = "DELETE FROM CT_PHIEUMUON WHERE IDPhieuMuon = @ID";
                connection.Execute(deleteCT, new { ID = idPhieuMuon }, transaction);

                foreach (int idCuon in cuonSach)
                {
                    const string updateCuon = "UPDATE CUONSACH SET TinhTrang = 1 WHERE ID = @ID";
                    connection.Execute(updateCuon, new { ID = idCuon }, transaction);
                }

                const string deletePhieu = "DELETE FROM PHIEUMUON WHERE ID = @ID";
                connection.Execute(deletePhieu, new { ID = idPhieuMuon }, transaction);

                return true;
            });
        }

        public static bool TraPhieuMuon(int idPhieuMuon, DateTime ngayTra, int donGiaPhatMoiNgay, out int tongTienPhat, out int idPhieuTra)
        {
            int tongTienPhatLocal = 0;
            int idPhieuTraLocal = 0;

            bool success = DataProvider.Instance.ExecuteTransaction((connection, transaction) =>
            {
                const string queryNgayTraDuKien = "SELECT NgayTraDuKien FROM PHIEUMUON WHERE ID = @ID";
                DateTime? ngayTraDuKien = connection.QueryFirstOrDefault<DateTime?>(queryNgayTraDuKien, new { ID = idPhieuMuon }, transaction);
                if (ngayTraDuKien == null)
                {
                    return false;
                }

                const string querySelectCT = @"SELECT IDCuonSach FROM CT_PHIEUMUON
                                           WHERE IDPhieuMuon = @ID AND NgayTraThucTe IS NULL";
                List<int> cuonChuaTra = connection.Query<int>(querySelectCT, new { ID = idPhieuMuon }, transaction).ToList();

                if (cuonChuaTra.Count == 0)
                {
                    return false;
                }

                int soNgayTre = Math.Max(0, (ngayTra.Date - ngayTraDuKien.Value.Date).Days);
                int tienPhatMoiCuon = soNgayTre * donGiaPhatMoiNgay;
                tongTienPhatLocal = tienPhatMoiCuon * cuonChuaTra.Count;

                string maPhieuTra = TaoMaPhieuTraMoi(connection, transaction);
                const string insertPhieuTra = @"INSERT INTO PHIEUTRA (MaPhieuTra, IDPhieuMuon, NgayTra, TongTienPhat)
                                              VALUES (@MaPhieuTra, @IDPhieuMuon, @NgayTra, @TongTienPhat);
                                              SELECT LAST_INSERT_ID();";

                long phieuTraId = connection.ExecuteScalar<long>(insertPhieuTra, new
                {
                    MaPhieuTra = maPhieuTra,
                    IDPhieuMuon = idPhieuMuon,
                    NgayTra = ngayTra,
                    TongTienPhat = tongTienPhatLocal
                }, transaction);

                if (phieuTraId <= 0)
                {
                    return false;
                }

                idPhieuTraLocal = Convert.ToInt32(phieuTraId);

                const string insertChiTietTra = @"INSERT INTO CT_PHIEUTRA (IDPhieuTra, IDCuonSach, SoNgayTre, TienPhat)
                                                 VALUES (@IDPhieuTra, @IDCuonSach, @SoNgayTre, @TienPhat)";

                foreach (int idCuon in cuonChuaTra)
                {
                    connection.Execute(insertChiTietTra, new
                    {
                        IDPhieuTra = idPhieuTraLocal,
                        IDCuonSach = idCuon,
                        SoNgayTre = soNgayTre,
                        TienPhat = tienPhatMoiCuon
                    }, transaction);
                }

                const string queryUpdateCT = @"UPDATE CT_PHIEUMUON
                                          SET NgayTraThucTe = @NgayTra, SoNgayTre = @SoNgayTre, TienPhat = @TienPhat
                                          WHERE IDPhieuMuon = @ID AND NgayTraThucTe IS NULL";
                connection.Execute(queryUpdateCT, new
                {
                    NgayTra = ngayTra,
                    SoNgayTre = soNgayTre,
                    TienPhat = tienPhatMoiCuon,
                    ID = idPhieuMuon
                }, transaction);

                foreach (int idCuon in cuonChuaTra)
                {
                    const string queryUpdateCuon = "UPDATE CUONSACH SET TinhTrang = 1 WHERE ID = @ID";
                    connection.Execute(queryUpdateCuon, new { ID = idCuon }, transaction);
                }

                const string queryConLai = "SELECT COUNT(*) FROM CT_PHIEUMUON WHERE IDPhieuMuon = @ID AND NgayTraThucTe IS NULL";
                int soSachChuaTra = connection.ExecuteScalar<int>(queryConLai, new { ID = idPhieuMuon }, transaction);

                const string updateTrangThai = "UPDATE PHIEUMUON SET TrangThai = CASE WHEN @ConLai = 0 THEN 0 ELSE 1 END WHERE ID = @ID";
                connection.Execute(updateTrangThai, new { ConLai = soSachChuaTra, ID = idPhieuMuon }, transaction);

                return true;
            });

            tongTienPhat = tongTienPhatLocal;
            idPhieuTra = idPhieuTraLocal;
            return success;
        }

        public static PhieuTraDTO? LayPhieuTraTheoID(int idPhieuTra)
        {
            const string query = @"SELECT pt.ID, pt.MaPhieuTra, pt.IDPhieuMuon, pm.MaPhieuMuon, dg.MaDocGia, dg.HoTen AS HoTenDocGia,
                                    pt.NgayTra, IFNULL(pt.TongTienPhat, 0) AS TongTienPhat,
                                    COUNT(ct.IDCuonSach) AS TongSachTra
                             FROM PHIEUTRA pt
                             INNER JOIN PHIEUMUON pm ON pt.IDPhieuMuon = pm.ID
                             INNER JOIN DOCGIA dg ON pm.IDDocGia = dg.ID
                             LEFT JOIN CT_PHIEUTRA ct ON ct.IDPhieuTra = pt.ID
                             WHERE pt.ID = @ID
                             GROUP BY pt.ID, pt.MaPhieuTra, pt.IDPhieuMuon, pm.MaPhieuMuon, dg.MaDocGia, dg.HoTen, pt.NgayTra, pt.TongTienPhat";

            using var connection = OpenConnection();
            return connection.QueryFirstOrDefault<PhieuTraDTO>(query, new { ID = idPhieuTra });
        }

        public static BindingList<PhieuTraDTO> LayTatCaPhieuTra()
        {
            const string query = @"SELECT pt.ID, pt.MaPhieuTra, pt.IDPhieuMuon, pm.MaPhieuMuon, dg.MaDocGia, dg.HoTen AS HoTenDocGia,
                                    pt.NgayTra,
                                    COUNT(ct.IDCuonSach) AS TongSachTra,
                                    IFNULL(pt.TongTienPhat, 0) AS TongTienPhat
                             FROM PHIEUTRA pt
                             INNER JOIN PHIEUMUON pm ON pt.IDPhieuMuon = pm.ID
                             INNER JOIN DOCGIA dg ON pm.IDDocGia = dg.ID
                             LEFT JOIN CT_PHIEUTRA ct ON ct.IDPhieuTra = pt.ID
                             GROUP BY pt.ID, pt.MaPhieuTra, pt.IDPhieuMuon, pm.MaPhieuMuon, dg.MaDocGia, dg.HoTen, pt.NgayTra, pt.TongTienPhat
                             ORDER BY pt.NgayTra DESC, pt.ID DESC";

            using var connection = OpenConnection();
            var list = connection.Query<PhieuTraDTO>(query).ToList();
            return new BindingList<PhieuTraDTO>(list);
        }

        public static BindingList<ChiTietPhieuTraDTO> LayChiTietPhieuTra(int idPhieuTra)
        {
            const string query = @"SELECT ct.IDCuonSach, cs.MaCuonSach, ts.TenTuaSach AS TenSach, pm.NgayTraDuKien,
                                    pt.NgayTra AS NgayTraThucTe,
                                    IFNULL(ct.SoNgayTre, 0) AS SoNgayTre, IFNULL(ct.TienPhat, 0) AS TienPhat
                             FROM CT_PHIEUTRA ct
                             INNER JOIN CUONSACH cs ON ct.IDCuonSach = cs.ID
                             INNER JOIN SACH s ON cs.IDSach = s.ID
                             INNER JOIN TUASACH ts ON s.IDTuaSach = ts.ID
                             INNER JOIN PHIEUTRA pt ON pt.ID = ct.IDPhieuTra
                             INNER JOIN PHIEUMUON pm ON pm.ID = pt.IDPhieuMuon
                             WHERE ct.IDPhieuTra = @ID";

            using var connection = OpenConnection();
            var list = connection.Query<ChiTietPhieuTraDTO>(query, new { ID = idPhieuTra }).ToList();

            return new BindingList<ChiTietPhieuTraDTO>(list);
        }

        public static bool XoaPhieuTra(int idPhieuTra)
        {
            return DataProvider.Instance.ExecuteTransaction((connection, transaction) =>
            {
                const string querySelect = @"SELECT pt.IDPhieuMuon, ct.IDCuonSach
                                             FROM CT_PHIEUTRA ct
                                             INNER JOIN PHIEUTRA pt ON ct.IDPhieuTra = pt.ID
                                             WHERE ct.IDPhieuTra = @ID";

                var cuonDaTra = connection.Query<(int IDPhieuMuon, int IDCuonSach)>(querySelect, new { ID = idPhieuTra }, transaction).ToList();

                if (cuonDaTra.Count == 0)
                    throw new Exception("Phiếu trả không tồn tại hoặc không có sách để xóa.");

                int idPhieuMuon = cuonDaTra.First().IDPhieuMuon;
                List<int> danhSachCuon = cuonDaTra.Select(c => c.IDCuonSach).ToList();

                const string queryUpdateCT = @"UPDATE CT_PHIEUMUON
                                          SET NgayTraThucTe = NULL, SoNgayTre = NULL, TienPhat = NULL
                                          WHERE IDPhieuMuon = @IDPhieuMuon AND IDCuonSach IN @CuonSach";
                connection.Execute(queryUpdateCT, new { IDPhieuMuon = idPhieuMuon, CuonSach = danhSachCuon }, transaction);

                const string queryUpdateCuon = "UPDATE CUONSACH SET TinhTrang = 0 WHERE ID IN @CuonSach";
                connection.Execute(queryUpdateCuon, new { CuonSach = danhSachCuon }, transaction);

                const string deleteChiTiet = "DELETE FROM CT_PHIEUTRA WHERE IDPhieuTra = @ID";
                connection.Execute(deleteChiTiet, new { ID = idPhieuTra }, transaction);

                const string deletePhieu = "DELETE FROM PHIEUTRA WHERE ID = @ID";
                connection.Execute(deletePhieu, new { ID = idPhieuTra }, transaction);

                const string queryConLai = "SELECT COUNT(*) FROM CT_PHIEUMUON WHERE IDPhieuMuon = @ID AND NgayTraThucTe IS NULL";
                int soSachChuaTra = connection.ExecuteScalar<int>(queryConLai, new { ID = idPhieuMuon }, transaction);
                const string updateTrangThai = "UPDATE PHIEUMUON SET TrangThai = CASE WHEN @ConLai = 0 THEN 0 ELSE 1 END WHERE ID = @ID";
                connection.Execute(updateTrangThai, new { ConLai = soSachChuaTra, ID = idPhieuMuon }, transaction);

                return true;
            });
        }
    }
}
