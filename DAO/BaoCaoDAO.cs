using DTO;
using MySql.Data.MySqlClient;
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

        /// <summary>
        /// L?y danh sách ??c gi? quá h?n (ch?a tr? sách)
        /// </summary>
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
                    WHERE cp.NgayTraThucTe IS NULL 
                      AND p.NgayTraDuKien < CURDATE()
                    GROUP BY p.ID
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

        /// <summary>
        /// L?y Top N sách m??n nhi?u nh?t (có chi ti?t)
        /// </summary>
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

        /// <summary>
        /// L?y Top N ??c gi? tích c?c (có chi ti?t)
        /// </summary>
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
    }
}
