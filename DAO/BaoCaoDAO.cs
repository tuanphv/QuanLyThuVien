// Ensure this file matches your DAO/BaoCaoDAO.cs to guarantee correct fetching
using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAO
{
    public class BaoCaoDAO
    {
        public static BaoCaoMuonTheoKhoangDTO GetBaoCaoTheoKhoang(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                string sql = @"
                    SELECT 
                        COUNT(DISTINCT cp.IDPhieuMuon) as TongLuotMuon,
                        COUNT(cp.IDCuonSach) as TongSachMuon
                    FROM CT_PHIEUMUON cp
                    INNER JOIN PHIEUMUON p ON cp.IDPhieuMuon = p.ID
                    WHERE p.NgayMuon BETWEEN @TuNgay AND @DenNgay";

                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@TuNgay", tuNgay.Date),
                    new MySqlParameter("@DenNgay", denNgay.Date.AddDays(1).AddSeconds(-1))
                };

                DataTable dt = DataProvider.Instance.ExecuteQuery(sql, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    return new BaoCaoMuonTheoKhoangDTO(
                        tuNgay,
                        denNgay,
                        row["TongLuotMuon"] != DBNull.Value ? Convert.ToInt32(row["TongLuotMuon"]) : 0,
                        row["TongSachMuon"] != DBNull.Value ? Convert.ToInt32(row["TongSachMuon"]) : 0
                    );
                }

                return new BaoCaoMuonTheoKhoangDTO(tuNgay, denNgay, 0, 0);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy báo cáo theo khoảng: {ex.Message}", ex);
            }
        }

        public static List<BaoCaoQuaHanDTO> GetBaoCaoQuaHan()
        {
            var list = new List<BaoCaoQuaHanDTO>();

            try
            {
                string sql = @"
                    SELECT 
                        dg.MaDocGia,
                        dg.HoTen,
                        p.MaPhieuMuon,
                        p.NgayMuon,
                        p.NgayTraDuKien,
                        DATEDIFF(CURDATE(), p.NgayTraDuKien) as SoNgayQuaHan,
                        SUM(DATEDIFF(CURDATE(), p.NgayTraDuKien) * (SELECT DonGiaPhatMoiNgay FROM THAMSO LIMIT 1)) as TienPhat
                    FROM CT_PHIEUMUON cp
                    INNER JOIN PHIEUMUON p ON cp.IDPhieuMuon = p.ID
                    INNER JOIN DOCGIA dg ON p.IDDocGia = dg.ID
                    LEFT JOIN PHIEUTRA pt ON p.ID = pt.IDPhieuMuon
                    WHERE pt.ID IS NULL 
                      AND p.NgayTraDuKien < CURDATE()
                      -- AND p.TrangThai = 1 -- Removed check for TrangThai=1 to be safe, rely on dates and no return
                    GROUP BY p.ID, dg.MaDocGia, dg.HoTen, p.MaPhieuMuon, p.NgayMuon, p.NgayTraDuKien
                    ORDER BY SoNgayQuaHan DESC";

                DataTable dt = DataProvider.Instance.ExecuteQuery(sql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        var item = new BaoCaoQuaHanDTO(
                            row["MaDocGia"]?.ToString() ?? "",
                            row["HoTen"]?.ToString() ?? "",
                            row["MaPhieuMuon"]?.ToString() ?? "",
                            row["NgayMuon"] != DBNull.Value ? Convert.ToDateTime(row["NgayMuon"]) : DateTime.MinValue,
                            row["NgayTraDuKien"] != DBNull.Value ? Convert.ToDateTime(row["NgayTraDuKien"]) : DateTime.MinValue,
                            row["SoNgayQuaHan"] != DBNull.Value ? Convert.ToInt32(row["SoNgayQuaHan"]) : 0,
                            row["TienPhat"] != DBNull.Value ? Convert.ToInt32(row["TienPhat"]) : 0
                        );
                        list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy báo cáo quá hạn: {ex.Message}", ex);
            }

            return list;
        }

        // ... (TopSach, TopDocGia methods - kept as is) ...
        public static List<BaoCaoTopSachDTO> GetTopSachMuonNhieu(int top = 10)
        {
            var list = new List<BaoCaoTopSachDTO>();

            try
            {
                string sql = @"
                    SELECT 
                        ts.MaTuaSach,
                        ts.TenTuaSach,
                        GROUP_CONCAT(DISTINCT tl.TenTheLoai SEPARATOR ', ') as TheLoai,
                        COUNT(cp.IDPhieuMuon) as SoLuotMuon,
                        SUM(s.SoLuongConLai) as SoLuongHienCo
                    FROM CT_PHIEUMUON cp
                    INNER JOIN CUONSACH cs ON cp.IDCuonSach = cs.ID
                    INNER JOIN SACH s ON cs.IDSach = s.ID
                    INNER JOIN TUASACH ts ON s.IDTuaSach = ts.ID
                    LEFT JOIN CT_THELOAI ctl ON ts.ID = ctl.IDTuaSach
                    LEFT JOIN THELOAI tl ON ctl.IDTheLoai = tl.ID
                    GROUP BY ts.ID, ts.MaTuaSach, ts.TenTuaSach
                    ORDER BY SoLuotMuon DESC
                    LIMIT @Top";

                var param = new MySqlParameter("@Top", top);
                DataTable dt = DataProvider.Instance.ExecuteQuery(sql, param);

                if (dt != null && dt.Rows.Count > 0)
                {
                    int stt = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        var item = new BaoCaoTopSachDTO(
                            stt++,
                            row["MaTuaSach"]?.ToString() ?? "",
                            row["TenTuaSach"]?.ToString() ?? "",
                            row["TheLoai"]?.ToString() ?? "N/A",
                            row["SoLuotMuon"] != DBNull.Value ? Convert.ToInt32(row["SoLuotMuon"]) : 0,
                            row["SoLuongHienCo"] != DBNull.Value ? Convert.ToInt32(row["SoLuongHienCo"]) : 0
                        );
                        list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy top sách: {ex.Message}", ex);
            }

            return list;
        }

        public static List<BaoCaoTopDocGiaDTO> GetTopDocGiaTichCuc(int top = 10)
        {
            var list = new List<BaoCaoTopDocGiaDTO>();

            try
            {
                string sql = @"
                    SELECT 
                        dg.MaDocGia,
                        dg.HoTen,
                        COUNT(cp.IDPhieuMuon) as SoLuotMuon,
                        dg.TongNoHienTai,
                        dg.NgayLapThe
                    FROM CT_PHIEUMUON cp
                    INNER JOIN PHIEUMUON p ON cp.IDPhieuMuon = p.ID
                    INNER JOIN DOCGIA dg ON p.IDDocGia = dg.ID
                    GROUP BY dg.ID, dg.MaDocGia, dg.HoTen, dg.TongNoHienTai, dg.NgayLapThe
                    ORDER BY SoLuotMuon DESC
                    LIMIT @Top";

                var param = new MySqlParameter("@Top", top);
                DataTable dt = DataProvider.Instance.ExecuteQuery(sql, param);

                if (dt != null && dt.Rows.Count > 0)
                {
                    int stt = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        var item = new BaoCaoTopDocGiaDTO(
                            stt++,
                            row["MaDocGia"]?.ToString() ?? "",
                            row["HoTen"]?.ToString() ?? "",
                            row["SoLuotMuon"] != DBNull.Value ? Convert.ToInt32(row["SoLuotMuon"]) : 0,
                            row["TongNoHienTai"] != DBNull.Value ? Convert.ToInt32(row["TongNoHienTai"]) : 0,
                            row["NgayLapThe"] != DBNull.Value ? Convert.ToDateTime(row["NgayLapThe"]) : DateTime.MinValue
                        );
                        list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy top độc giả: {ex.Message}", ex);
            }

            return list;
        }

        public static List<BaoCaoNoDocGiaDTO> GetBaoCaoNoDocGia()
        {
            var list = new List<BaoCaoNoDocGiaDTO>();

            try
            {
                // BƯỚC 1: Lấy đơn giá phạt hiện tại từ DB (Tránh lỗi nếu subquery trong SQL không lấy được)
                decimal donGiaPhat = 0;
                try
                {
                    DataTable dtThamSo = DataProvider.Instance.ExecuteQuery("SELECT DonGiaPhatMoiNgay FROM THAMSO LIMIT 1");
                    if (dtThamSo != null && dtThamSo.Rows.Count > 0)
                    {
                        donGiaPhat = Convert.ToDecimal(dtThamSo.Rows[0]["DonGiaPhatMoiNgay"]);
                    }
                }
                catch { donGiaPhat = 1000; } // Giá trị mặc định nếu lỗi

                // BƯỚC 2: Truy vấn SQL với logic tách biệt
                // - Subquery 'TienPhatDuKien': Tính riêng tiền phạt cho các sách đang mượn quá hạn
                // - DOCGIA: Lấy TongNoHienTai (Nợ cũ)
                // - Cộng 2 cái lại: IFNULL(Nợ cũ, 0) + IFNULL(Nợ mới, 0)

                string sql = @"
            SELECT 
                dg.MaDocGia,
                dg.HoTen,
                
                -- 1. Nợ thực tế (Đã chốt)
                IFNULL(dg.TongNoHienTai, 0) as NoThucTe,

                -- 2. Số sách đang quá hạn
                IFNULL(TempPhat.SoLuongSachQuaHan, 0) as SoSachQuaHan,

                -- 3. Nợ dự kiến (Đang chạy)
                IFNULL(TempPhat.TienPhatDuKien, 0) as TienPhatDuKien

            FROM DOCGIA dg
            LEFT JOIN (
                -- Subquery: Chỉ tính toán trên những cuốn sách chưa trả và đã quá hạn
                SELECT 
                    p.IDDocGia,
                    COUNT(*) as SoLuongSachQuaHan,
                    SUM(DATEDIFF(CURDATE(), p.NgayTraDuKien) * @DonGiaPhat) as TienPhatDuKien
                FROM CT_PHIEUMUON cp
                JOIN PHIEUMUON p ON cp.IDPhieuMuon = p.ID
                WHERE cp.NgayTraThucTe IS NULL          -- Chưa trả
                  AND p.NgayTraDuKien < CURDATE()       -- Đã quá hạn
                GROUP BY p.IDDocGia
            ) TempPhat ON dg.ID = TempPhat.IDDocGia
            
            -- Chỉ lấy những người có nợ (cũ hoặc mới)
            WHERE IFNULL(dg.TongNoHienTai, 0) > 0 OR IFNULL(TempPhat.TienPhatDuKien, 0) > 0
            
            ORDER BY (IFNULL(dg.TongNoHienTai, 0) + IFNULL(TempPhat.TienPhatDuKien, 0)) DESC";

                var parameter = new MySqlParameter("@DonGiaPhat", donGiaPhat);
                DataTable dt = DataProvider.Instance.ExecuteQuery(sql, new MySqlParameter[] { parameter });

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        // Lấy dữ liệu thô
                        decimal noThucTe = row["NoThucTe"] != DBNull.Value ? Convert.ToDecimal(row["NoThucTe"]) : 0;
                        decimal noDuKien = row["TienPhatDuKien"] != DBNull.Value ? Convert.ToDecimal(row["TienPhatDuKien"]) : 0;
                        int soSach = row["SoSachQuaHan"] != DBNull.Value ? Convert.ToInt32(row["SoSachQuaHan"]) : 0;

                        // TÍNH TỔNG: Cộng dồn 2 khoản nợ lại
                        // Đây là con số quan trọng nhất
                        decimal tongNoUocTinh = noThucTe + noDuKien;

                        var item = new BaoCaoNoDocGiaDTO(
                            row["MaDocGia"]?.ToString() ?? "",
                            row["HoTen"]?.ToString() ?? "",
                            (int)noThucTe,      // Cột 3: Nợ hiện tại (trong DB)
                            soSach,             // Cột 4: Số sách quá hạn
                            (int)tongNoUocTinh  // Cột 5: Tổng nợ ước tính (Nợ hiện tại + Phạt dự kiến)
                        );
                        list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy báo cáo nợ: {ex.Message}", ex);
            }

            return list;
        }

        public static List<ChiTietSachQuaHanDTO> GetChiTietSachQuaHan(string maDocGia)
        {
            var list = new List<ChiTietSachQuaHanDTO>();

            try
            {
                string sql = @"
                    SELECT 
                        cs.MaCuonSach,
                        ts.TenTuaSach as TenSach,
                        p.MaPhieuMuon,
                        p.NgayTraDuKien,
                        DATEDIFF(CURDATE(), p.NgayTraDuKien) as SoNgayQuaHan,
                        (DATEDIFF(CURDATE(), p.NgayTraDuKien) * (SELECT DonGiaPhatMoiNgay FROM THAMSO LIMIT 1)) as TienPhatUocTinh
                    FROM CT_PHIEUMUON cp
                    INNER JOIN CUONSACH cs ON cp.IDCuonSach = cs.ID
                    INNER JOIN SACH s ON cs.IDSach = s.ID
                    INNER JOIN TUASACH ts ON s.IDTuaSach = ts.ID
                    INNER JOIN PHIEUMUON p ON cp.IDPhieuMuon = p.ID
                    INNER JOIN DOCGIA dg ON p.IDDocGia = dg.ID
                    LEFT JOIN PHIEUTRA pt ON p.ID = pt.IDPhieuMuon
                    WHERE dg.MaDocGia = @MaDocGia
                      AND pt.ID IS NULL 
                      AND p.NgayTraDuKien < CURDATE()
                    ORDER BY p.NgayTraDuKien ASC";

                var param = new MySqlParameter("@MaDocGia", maDocGia);
                DataTable dt = DataProvider.Instance.ExecuteQuery(sql, param);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        var item = new ChiTietSachQuaHanDTO(
                            row["MaCuonSach"]?.ToString() ?? "",
                            row["TenSach"]?.ToString() ?? "",
                            row["MaPhieuMuon"]?.ToString() ?? "",
                            row["NgayTraDuKien"] != DBNull.Value ? Convert.ToDateTime(row["NgayTraDuKien"]) : DateTime.MinValue,
                            row["SoNgayQuaHan"] != DBNull.Value ? Convert.ToInt32(row["SoNgayQuaHan"]) : 0,
                            row["TienPhatUocTinh"] != DBNull.Value ? Convert.ToInt32(row["TienPhatUocTinh"]) : 0
                        );
                        list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy chi tiết sách quá hạn: {ex.Message}", ex);
            }

            return list;
        }

        public static List<BaoCaoTopSachDTO> GetTopSachMuonNhieuTheoKhoang(int top, DateTime? tuNgay, DateTime? denNgay)
        {
            var list = new List<BaoCaoTopSachDTO>();

            try
            {
                string whereClause = "";
                List<MySqlParameter> parameters = new List<MySqlParameter>();

                if (tuNgay.HasValue && denNgay.HasValue)
                {
                    whereClause = "WHERE p.NgayMuon BETWEEN @TuNgay AND @DenNgay";
                    parameters.Add(new MySqlParameter("@TuNgay", tuNgay.Value.Date));
                    parameters.Add(new MySqlParameter("@DenNgay", denNgay.Value.Date.AddDays(1).AddSeconds(-1)));
                }

                parameters.Add(new MySqlParameter("@Top", top));

                string sql = $@"
                    SELECT 
                        ts.MaTuaSach,
                        ts.TenTuaSach,
                        GROUP_CONCAT(DISTINCT tl.TenTheLoai SEPARATOR ', ') as TheLoai,
                        COUNT(cp.IDPhieuMuon) as SoLuotMuon,
                        SUM(s.SoLuongConLai) as SoLuongHienCo
                    FROM CT_PHIEUMUON cp
                    INNER JOIN PHIEUMUON p ON cp.IDPhieuMuon = p.ID
                    INNER JOIN CUONSACH cs ON cp.IDCuonSach = cs.ID
                    INNER JOIN SACH s ON cs.IDSach = s.ID
                    INNER JOIN TUASACH ts ON s.IDTuaSach = ts.ID
                    LEFT JOIN CT_THELOAI ctl ON ts.ID = ctl.IDTuaSach
                    LEFT JOIN THELOAI tl ON ctl.IDTheLoai = tl.ID
                    {whereClause}
                    GROUP BY ts.ID, ts.MaTuaSach, ts.TenTuaSach
                    ORDER BY SoLuotMuon DESC
                    LIMIT @Top";

                DataTable dt = DataProvider.Instance.ExecuteQuery(sql, parameters.ToArray());

                if (dt != null && dt.Rows.Count > 0)
                {
                    int stt = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        var item = new BaoCaoTopSachDTO(
                            stt++,
                            row["MaTuaSach"]?.ToString() ?? "",
                            row["TenTuaSach"]?.ToString() ?? "",
                            row["TheLoai"]?.ToString() ?? "N/A",
                            row["SoLuotMuon"] != DBNull.Value ? Convert.ToInt32(row["SoLuotMuon"]) : 0,
                            row["SoLuongHienCo"] != DBNull.Value ? Convert.ToInt32(row["SoLuongHienCo"]) : 0
                        );
                        list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy top sách theo khoảng: {ex.Message}", ex);
            }

            return list;
        }

        public static List<BaoCaoTopDocGiaDTO> GetTopDocGiaTichCucTheoKhoang(int top, DateTime? tuNgay, DateTime? denNgay)
        {
            var list = new List<BaoCaoTopDocGiaDTO>();

            try
            {
                string whereClause = "";
                List<MySqlParameter> parameters = new List<MySqlParameter>();

                if (tuNgay.HasValue && denNgay.HasValue)
                {
                    whereClause = "WHERE p.NgayMuon BETWEEN @TuNgay AND @DenNgay";
                    parameters.Add(new MySqlParameter("@TuNgay", tuNgay.Value.Date));
                    parameters.Add(new MySqlParameter("@DenNgay", denNgay.Value.Date.AddDays(1).AddSeconds(-1)));
                }

                parameters.Add(new MySqlParameter("@Top", top));

                string sql = $@"
                    SELECT 
                        dg.MaDocGia,
                        dg.HoTen,
                        COUNT(cp.IDPhieuMuon) as SoLuotMuon,
                        dg.TongNoHienTai,
                        dg.NgayLapThe
                    FROM CT_PHIEUMUON cp
                    INNER JOIN PHIEUMUON p ON cp.IDPhieuMuon = p.ID
                    INNER JOIN DOCGIA dg ON p.IDDocGia = dg.ID
                    {whereClause}
                    GROUP BY dg.ID, dg.MaDocGia, dg.HoTen, dg.TongNoHienTai, dg.NgayLapThe
                    ORDER BY SoLuotMuon DESC
                    LIMIT @Top";

                DataTable dt = DataProvider.Instance.ExecuteQuery(sql, parameters.ToArray());

                if (dt != null && dt.Rows.Count > 0)
                {
                    int stt = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        var item = new BaoCaoTopDocGiaDTO(
                            stt++,
                            row["MaDocGia"]?.ToString() ?? "",
                            row["HoTen"]?.ToString() ?? "",
                            row["SoLuotMuon"] != DBNull.Value ? Convert.ToInt32(row["SoLuotMuon"]) : 0,
                            row["TongNoHienTai"] != DBNull.Value ? Convert.ToInt32(row["TongNoHienTai"]) : 0,
                            row["NgayLapThe"] != DBNull.Value ? Convert.ToDateTime(row["NgayLapThe"]) : DateTime.MinValue
                        );
                        list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy top độc giả theo khoảng: {ex.Message}", ex);
            }

            return list;
        }

        public static List<ThongKeSachDTO> GetThongKeSach()
        {
            var list = new List<ThongKeSachDTO>();

            try
            {
                string sql = @"
                    SELECT 
                        ts.ID,
                        ts.TenTuaSach,
                        SUM(s.SoLuongTong) as TongSoLuong,
                        SUM(s.SoLuongTong - s.SoLuongConLai) as DangMuon,
                        SUM(s.SoLuongConLai) as ConLai,
                        CASE 
                            WHEN SUM(s.SoLuongTong) > 0 
                            THEN ROUND((SUM(s.SoLuongTong - s.SoLuongConLai) * 100.0) / SUM(s.SoLuongTong), 1)
                            ELSE 0 
                        END as TyLeMuon
                    FROM SACH s
                    INNER JOIN TUASACH ts ON s.IDTuaSach = ts.ID
                    WHERE s.DaAn = 0 AND ts.DaAn = 0
                    GROUP BY ts.ID, ts.TenTuaSach
                    ORDER BY DangMuon DESC, TongSoLuong DESC";

                DataTable dt = DataProvider.Instance.ExecuteQuery(sql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        var item = new ThongKeSachDTO(
                            row["ID"] != DBNull.Value ? Convert.ToInt32(row["ID"]) : 0,
                            row["TenTuaSach"]?.ToString() ?? "",
                            row["TongSoLuong"] != DBNull.Value ? Convert.ToInt32(row["TongSoLuong"]) : 0,
                            row["DangMuon"] != DBNull.Value ? Convert.ToInt32(row["DangMuon"]) : 0,
                            row["ConLai"] != DBNull.Value ? Convert.ToInt32(row["ConLai"]) : 0,
                            row["TyLeMuon"] != DBNull.Value ? Convert.ToDouble(row["TyLeMuon"]) : 0
                        );
                        list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thống kê sách: {ex.Message}", ex);
            }

            return list;
        }

        public static List<ThongKeMuonTraTheoNgayDTO> GetThongKeMuonTraTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            var list = new List<ThongKeMuonTraTheoNgayDTO>();

            try
            {
                string sql = @"
                    SELECT
                        DATE(PM.NgayMuon) AS NgayMuon,
                        COUNT(DISTINCT PM.ID) AS SoLuongPhieuMuon,
                        COUNT(CTPM.IDCuonSach) AS TongSachMuon,
                        SUM(CASE WHEN CTPM.NgayTraThucTe IS NOT NULL THEN 1 ELSE 0 END) AS SachDaTra,
                        SUM(CASE WHEN CTPM.NgayTraThucTe IS NULL THEN 1 ELSE 0 END) AS SachChuaTra
                    FROM
                        PHIEUMUON PM
                    JOIN
                        CT_PHIEUMUON CTPM ON PM.ID = CTPM.IDPhieuMuon
                    WHERE PM.NgayMuon BETWEEN @TuNgay AND @DenNgay
                    GROUP BY
                        DATE(PM.NgayMuon)
                    ORDER BY
                        NgayMuon DESC;";

                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@TuNgay", tuNgay.Date),
                    new MySqlParameter("@DenNgay", denNgay.Date.AddDays(1).AddSeconds(-1))
                };

                DataTable dt = DataProvider.Instance.ExecuteQuery(sql, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        var item = new ThongKeMuonTraTheoNgayDTO(
                            row["NgayMuon"] != DBNull.Value ? Convert.ToDateTime(row["NgayMuon"]) : DateTime.MinValue,
                            row["SoLuongPhieuMuon"] != DBNull.Value ? Convert.ToInt32(row["SoLuongPhieuMuon"]) : 0,
                            row["TongSachMuon"] != DBNull.Value ? Convert.ToInt32(row["TongSachMuon"]) : 0,
                            row["SachDaTra"] != DBNull.Value ? Convert.ToInt32(row["SachDaTra"]) : 0,
                            row["SachChuaTra"] != DBNull.Value ? Convert.ToInt32(row["SachChuaTra"]) : 0
                        );
                        list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thống kê mượn/trả theo ngày: {ex.Message}", ex);
            }

            return list;
        }
    }
}