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
                    INSERT INTO PHIEUTHU (IDDocGia, SoTienThu, NgayLapPhieu)
                    VALUES (@IDDocGia, @SoTienThu, @NgayLapPhieu);

                    SELECT ID, MaPhieuThu FROM PhieuThu WHERE ID = LAST_INSERT_ID()";
                var parameters = new MySql.Data.MySqlClient.MySqlParameter[]
                {
                    new MySql.Data.MySqlClient.MySqlParameter("@IDDocGia", phieuThu.IDDocGia),
                    new MySql.Data.MySqlClient.MySqlParameter("@IDDocGia", phieuThu.TenDocGia),
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
    }
}
