using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAO
{
    public class PhieuThuDAO
    {
        public static List<PhieuThuDTO> GetAllPhieuThu()
        {
            var list = new List<PhieuThuDTO>();
            try
            {
                string sql = @"SELECT pt.ID, MaPhieuThu, IDDocGia, dg.HoTen AS TenDocGia, SoTienThu, NgayLap 
                               FROM PHIEUTHU pt
                               JOIN DOCGIA dg ON dg.ID = IDDocGia
                               ORDER BY NgayLap DESC";
                var dt = DataProvider.Instance.ExecuteQuery(sql);
                foreach (DataRow row in dt.Rows)
                {
                    var phieuThu = new PhieuThuDTO
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        MaPhieuThu = row["MaPhieuThu"].ToString() ?? string.Empty,
                        IDDocGia = Convert.ToInt32(row["IDDocGia"]),
                        TenDocGia = row["TenDocGia"].ToString() ?? string.Empty,
                        SoTienThu = Convert.ToInt32(row["SoTienThu"]),
                        NgayLapPhieu = Convert.ToDateTime(row["NgayLap"])
                    };
                    list.Add(phieuThu);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách phiếu thu: {ex.Message}", ex);
            }
            return list;
        }

        public static string AddPhieuThu(PhieuThuDTO phieuThu)
        {
            try
            {
                string sql = @"INSERT INTO PHIEUTHU (IDDocGia, SoTienThu, NgayLap)
                               VALUES (@IDDocGia, @SoTienThu, @NgayLapPhieu);
                               SELECT MaPhieuThu FROM PHIEUTHU WHERE ID = LAST_INSERT_ID()";

                var parameters = new MySql.Data.MySqlClient.MySqlParameter[]
                {
                    new MySql.Data.MySqlClient.MySqlParameter("@IDDocGia", phieuThu.IDDocGia),
                    new MySql.Data.MySqlClient.MySqlParameter("@SoTienThu", phieuThu.SoTienThu),
                    new MySql.Data.MySqlClient.MySqlParameter("@NgayLapPhieu", phieuThu.NgayLapPhieu)
                };

                object result = DataProvider.Instance.ExecuteScalar(sql, parameters);
                return result?.ToString() ?? string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm phiếu thu: {ex.Message}", ex);
            }
        }

        // Trả về List<DocGiaSimpleDTO> để dễ binding và cast
        public static List<DocGiaSimpleDTO> GetAllDocGiaCoPhieuThu()
        {
            var list = new List<DocGiaSimpleDTO>();
            try
            {
                string sql = @"SELECT DISTINCT dg.ID, dg.HoTen
                               FROM DOCGIA dg
                               JOIN PHIEUTHU pt ON dg.ID = pt.IDDocGia
                               ORDER BY dg.HoTen";
                DataTable dt = DataProvider.Instance.ExecuteQuery(sql);
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new DocGiaSimpleDTO
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        HoTen = row["HoTen"].ToString() ?? string.Empty
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách độc giả có phiếu thu: {ex.Message}", ex);
            }
            return list;
        }

        public static bool DeletePhieuThu(int idPhieuThu)
        {
            try
            {
                string sql = "DELETE FROM PHIEUTHU WHERE ID = @IDPhieuThu";
                var parameters = new MySql.Data.MySqlClient.MySqlParameter[]
                {
                    new MySql.Data.MySqlClient.MySqlParameter("@IDPhieuThu", idPhieuThu)
                };
                int rowsAffected = DataProvider.Instance.ExecuteNonQuery(sql, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa phiếu thu: {ex.Message}", ex);
            }
        }
    }
}