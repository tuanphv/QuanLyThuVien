using DTO;
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
                    JOIN DocGia dg ON dg.ID = IDDocGia";
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
                string sql = @"
                    INSERT INTO PHIEUTHU (IDDocGia, SoTienThu, NgayLap)
                    VALUES (@IDDocGia, @SoTienThu, @NgayLapPhieu);

                    SELECT ID, MaPhieuThu FROM PhieuThu WHERE ID = LAST_INSERT_ID()";
                var parameters = new MySql.Data.MySqlClient.MySqlParameter[]
                {
                    new MySql.Data.MySqlClient.MySqlParameter("@IDDocGia", phieuThu.IDDocGia),
                    new MySql.Data.MySqlClient.MySqlParameter("@SoTienThu", phieuThu.SoTienThu),
                    new MySql.Data.MySqlClient.MySqlParameter("@NgayLapPhieu", phieuThu.NgayLapPhieu)
                };
                DataTable result = DataProvider.Instance.ExecuteQuery(sql, parameters);

                return result.Rows[0]["MaPhieuThu"].ToString() ?? string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm phiếu thu: {ex.Message}", ex);
            }
        }

        public static List<(int ID, string HoTen)> GetAllDocGiaCoPhieuThu()
        {
            List<(int ID, string HoTen)> list = new List<(int ID, string HoTen)>();
            try
            {
                string sql = @"
                    SELECT DISTINCT dg.ID, dg.HoTen
                    FROM DocGia dg
                    JOIN PhieuThu pt ON dg.ID = pt.IDDocGia";
                DataTable dt = DataProvider.Instance.ExecuteQuery(sql);
                foreach (DataRow row in dt.Rows)
                {
                    int id = Convert.ToInt32(row["ID"]);
                    string hoTen = row["HoTen"].ToString() ?? string.Empty;
                    list.Add((id, hoTen));
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
                string sql = "DELETE FROM PhieuThu WHERE ID = @IDPhieuThu";
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
