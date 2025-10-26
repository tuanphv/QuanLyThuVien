using DTO;
using MySql.Data.MySqlClient;

using System.ComponentModel;
namespace DAO
{
    public class ReaderDAO
    {
        public static BindingList<ReaderDTO> GetAllReaders()
        {
            BindingList<ReaderDTO> list = new BindingList<ReaderDTO>();
            string query = "SELECT * FROM DocGia";
            System.Data.DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (System.Data.DataRow row in dt.Rows)
            {
                list.Add(new ReaderDTO
                {
                    MaDocGia = Convert.ToInt32(row["MaDocGia"]),
                    HoTen = row["HoTen"]?.ToString() ?? String.Empty,
                    NgaySinh = row["NgaySinh"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["NgaySinh"]),
                    GioiTinh = row["GioiTinh"]?.ToString() ?? String.Empty,
                    DiaChi = row["DiaChi"]?.ToString() ?? String.Empty,
                    Email = row["Email"]?.ToString() ?? String.Empty,
                    SoDienThoai = row["SoDienThoai"]?.ToString() ?? String.Empty,
                    NgayDangKy = row["NgayDangKy"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(row["NgayDangKy"])
                });
            }
            return list;
        }

        public static int AddReader(ReaderDTO reader)
        {
            string query = "INSERT INTO DocGia (HoTen, NgaySinh, GioiTinh, DiaChi, Email, SoDienThoai, NgayDangKy) " +
                           "VALUES (@HoTen, @NgaySinh, @GioiTinh, @DiaChi, @Email, @SoDienThoai, @NgayDangKy); " +
                           "SELECT LAST_INSERT_ID();";

            object result = DataProvider.Instance.ExecuteScalar(query,
                new MySqlParameter("@HoTen", reader.HoTen),
                new MySqlParameter("@NgaySinh", reader.NgaySinh),
                new MySqlParameter("@GioiTinh", reader.GioiTinh),
                new MySqlParameter("@DiaChi", reader.DiaChi),
                new MySqlParameter("@Email", reader.Email),
                new MySqlParameter("@SoDienThoai", reader.SoDienThoai),
                new MySqlParameter("@NgayDangKy", reader.NgayDangKy));

            return Convert.ToInt32(result);
        }

        public static bool UpdateReader(ReaderDTO reader)
        {
            string query = "UPDATE DocGia SET HoTen = @HoTen, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, " +
                           "DiaChi = @DiaChi, Email = @Email, SoDienThoai = @SoDienThoai, NgayDangKy = @NgayDangKy " +
                           "WHERE MaDocGia = @MaDocGia";
            int result = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@HoTen", reader.HoTen),
                new MySqlParameter("@NgaySinh", reader.NgaySinh),
                new MySqlParameter("@GioiTinh", reader.GioiTinh),
                new MySqlParameter("@DiaChi", reader.DiaChi),
                new MySqlParameter("@Email", reader.Email),
                new MySqlParameter("@SoDienThoai", reader.SoDienThoai),
                new MySqlParameter("@NgayDangKy", reader.NgayDangKy),
                new MySqlParameter("@MaDocGia", reader.MaDocGia));
            return result > 0;
        }

        public static bool DeleteReader(int maDocGia)
        {
            string query = "DELETE FROM DocGia WHERE MaDocGia = @MaDocGia";
            int result = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@MaDocGia", maDocGia));
            return result > 0;
        }
    }
}
