using DTO;
using MySql.Data.MySqlClient;
using System.Data;

namespace DAO
{
    public class ThongKeDAO
    {
        /// <summary>
        /// L?y th?ng kê t?ng quan
        /// </summary>
        public static ThongKeDTO GetThongKeTongQuan()
        {
            var thongKe = new ThongKeDTO();

            try
            {
                // T?ng s? sách (cu?n sách v?t lý)
                string sqlTongSach = "SELECT COUNT(*) FROM CUONSACH";
                var resultTongSach = DataProvider.Instance.ExecuteScalar(sqlTongSach);
                thongKe.TongSach = resultTongSach != null && resultTongSach != DBNull.Value 
                    ? Convert.ToInt32(resultTongSach) : 0;

                // S? sách ?ang m??n (TinhTrang = 0)
                string sqlSachDangMuon = @"
                    SELECT COUNT(*) 
                    FROM CUONSACH 
                    WHERE TinhTrang = 0";
                var resultSachDangMuon = DataProvider.Instance.ExecuteScalar(sqlSachDangMuon);
                thongKe.SachDangMuon = resultSachDangMuon != null && resultSachDangMuon != DBNull.Value 
                    ? Convert.ToInt32(resultSachDangMuon) : 0;

                // T?ng s? ??c gi?
                string sqlTongDocGia = "SELECT COUNT(*) FROM DOCGIA";
                var resultTongDocGia = DataProvider.Instance.ExecuteScalar(sqlTongDocGia);
                thongKe.TongDocGia = resultTongDocGia != null && resultTongDocGia != DBNull.Value 
                    ? Convert.ToInt32(resultTongDocGia) : 0;

                // T?ng n?
                string sqlTongNo = "SELECT COALESCE(SUM(TongNoHienTai), 0) FROM DOCGIA";
                var resultTongNo = DataProvider.Instance.ExecuteScalar(sqlTongNo);
                thongKe.TongNo = resultTongNo != null && resultTongNo != DBNull.Value 
                    ? Convert.ToInt32(resultTongNo) : 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"L?i khi l?y th?ng kê t?ng quan: {ex.Message}", ex);
            }

            return thongKe;
        }

        /// <summary>
        /// L?y top 5 sách m??n nhi?u nh?t
        /// </summary>
        public static List<SachMuonNhieuDTO> GetTop5SachMuonNhieu()
        {
            var list = new List<SachMuonNhieuDTO>();

            try
            {
                string sql = @"
                    SELECT ts.TenTuaSach, COUNT(cp.IDPhieuMuon) as SoLuotMuon
                    FROM CT_PHIEUMUON cp
                    INNER JOIN CUONSACH cs ON cp.IDCuonSach = cs.ID
                    INNER JOIN SACH s ON cs.IDSach = s.ID
                    INNER JOIN TUASACH ts ON s.IDTuaSach = ts.ID
                    GROUP BY ts.ID, ts.TenTuaSach
                    ORDER BY SoLuotMuon DESC
                    LIMIT 5";

                DataTable dt = DataProvider.Instance.ExecuteQuery(sql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        var item = new SachMuonNhieuDTO(
                            row["TenTuaSach"]?.ToString() ?? "N/A",
                            row["SoLuotMuon"] != DBNull.Value ? Convert.ToInt32(row["SoLuotMuon"]) : 0
                        );
                        list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"L?i khi l?y top sách m??n nhi?u: {ex.Message}", ex);
            }

            return list;
        }

        /// <summary>
        /// L?y top 3 ??c gi? tích c?c (m??n nhi?u nh?t)
        /// </summary>
        public static List<DocGiaTichCucDTO> GetTop3DocGiaTichCuc()
        {
            var list = new List<DocGiaTichCucDTO>();

            try
            {
                string sql = @"
                    SELECT dg.HoTen, COUNT(cp.IDPhieuMuon) as SoLuotMuon
                    FROM CT_PHIEUMUON cp
                    INNER JOIN PHIEUMUON p ON cp.IDPhieuMuon = p.ID
                    INNER JOIN DOCGIA dg ON p.IDDocGia = dg.ID
                    GROUP BY dg.ID, dg.HoTen
                    ORDER BY SoLuotMuon DESC
                    LIMIT 3";

                DataTable dt = DataProvider.Instance.ExecuteQuery(sql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        var item = new DocGiaTichCucDTO(
                            row["HoTen"]?.ToString() ?? "N/A",
                            row["SoLuotMuon"] != DBNull.Value ? Convert.ToInt32(row["SoLuotMuon"]) : 0
                        );
                        list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"L?i khi l?y top ??c gi? tích c?c: {ex.Message}", ex);
            }

            return list;
        }

        /// <summary>
        /// Th?ng kê s? l??t m??n theo tháng trong n?m hi?n t?i
        /// </summary>
        public static List<ThongKeMuonTheoThangDTO> GetThongKeTheoThang(int? nam = null)
        {
            var list = new List<ThongKeMuonTheoThangDTO>();
            int namThongKe = nam ?? DateTime.Now.Year;

            try
            {
                string sql = @"
                    SELECT MONTH(p.NgayMuon) as Thang, COUNT(cp.IDPhieuMuon) as SoLuotMuon
                    FROM CT_PHIEUMUON cp
                    INNER JOIN PHIEUMUON p ON cp.IDPhieuMuon = p.ID
                    WHERE YEAR(p.NgayMuon) = @Nam
                    GROUP BY MONTH(p.NgayMuon)
                    ORDER BY Thang";

                var param = new MySqlParameter("@Nam", namThongKe);
                DataTable dt = DataProvider.Instance.ExecuteQuery(sql, param);

                // Kh?i t?o 12 tháng v?i giá tr? 0
                for (int i = 1; i <= 12; i++)
                {
                    list.Add(new ThongKeMuonTheoThangDTO(i, 0));
                }

                // C?p nh?t giá tr? th?c t? database
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["Thang"] != DBNull.Value && row["SoLuotMuon"] != DBNull.Value)
                        {
                            int thang = Convert.ToInt32(row["Thang"]);
                            int soLuot = Convert.ToInt32(row["SoLuotMuon"]);
                            
                            if (thang >= 1 && thang <= 12)
                            {
                                list[thang - 1].SoLuotMuon = soLuot;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"L?i khi l?y th?ng kê theo tháng: {ex.Message}", ex);
            }

            return list;
        }

        /// <summary>
        /// Th?ng kê s? l??t m??n theo quý trong n?m hi?n t?i
        /// </summary>
        public static List<ThongKeMuonTheoQuyDTO> GetThongKeTheoQuy(int? nam = null)
        {
            var list = new List<ThongKeMuonTheoQuyDTO>();
            int namThongKe = nam ?? DateTime.Now.Year;

            try
            {
                string sql = @"
                    SELECT QUARTER(p.NgayMuon) as Quy, COUNT(cp.IDPhieuMuon) as SoLuotMuon
                    FROM CT_PHIEUMUON cp
                    INNER JOIN PHIEUMUON p ON cp.IDPhieuMuon = p.ID
                    WHERE YEAR(p.NgayMuon) = @Nam
                    GROUP BY QUARTER(p.NgayMuon)
                    ORDER BY Quy";

                var param = new MySqlParameter("@Nam", namThongKe);
                DataTable dt = DataProvider.Instance.ExecuteQuery(sql, param);

                // Kh?i t?o 4 quý v?i giá tr? 0
                for (int i = 1; i <= 4; i++)
                {
                    list.Add(new ThongKeMuonTheoQuyDTO(i, 0));
                }

                // C?p nh?t giá tr? th?c t? database
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["Quy"] != DBNull.Value && row["SoLuotMuon"] != DBNull.Value)
                        {
                            int quy = Convert.ToInt32(row["Quy"]);
                            int soLuot = Convert.ToInt32(row["SoLuotMuon"]);
                            
                            if (quy >= 1 && quy <= 4)
                            {
                                list[quy - 1].SoLuotMuon = soLuot;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"L?i khi l?y th?ng kê theo quý: {ex.Message}", ex);
            }

            return list;
        }

        /// <summary>
        /// Th?ng kê s? l??t m??n theo kho?ng th?i gian
        /// </summary>
        public static int GetThongKeTheoKhoang(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                string sql = @"
                    SELECT COUNT(cp.IDPhieuMuon) 
                    FROM CT_PHIEUMUON cp
                    INNER JOIN PHIEUMUON p ON cp.IDPhieuMuon = p.ID
                    WHERE p.NgayMuon BETWEEN @TuNgay AND @DenNgay";

                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@TuNgay", tuNgay.Date),
                    new MySqlParameter("@DenNgay", denNgay.Date.AddDays(1).AddSeconds(-1))
                };

                var result = DataProvider.Instance.ExecuteScalar(sql, parameters);
                return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"L?i khi l?y th?ng kê theo kho?ng: {ex.Message}", ex);
            }
        }
    }
}
