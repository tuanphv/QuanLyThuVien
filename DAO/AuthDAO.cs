using DTO;
using MySql.Data.MySqlClient;
using System.Data;

namespace DAO
{
    public class AuthDAO
    {
        public static AuthDTO? ValidateLogin(string tenDangNhap, string matKhau)
        {
            string query = @"
                SELECT dn.TenDangNhap, dn.MatKhau, dn.VaiTro, dn.MaDocGia, dn.MaNhanVien,
                       CASE 
                           WHEN dn.VaiTro = 'NhanVien' THEN nv.HoTen
                           WHEN dn.VaiTro = 'DocGia' THEN dg.HoTen
                           ELSE ''
                       END as HoTen
                FROM DangNhap dn
                LEFT JOIN NhanVien nv ON dn.MaNhanVien = nv.MaNhanVien
                LEFT JOIN DocGia dg ON dn.MaDocGia = dg.MaDocGia
                WHERE dn.TenDangNhap = @TenDangNhap AND dn.MatKhau = @MatKhau";

            MySqlParameter[] parameters = {
                new MySqlParameter("@TenDangNhap", tenDangNhap),
                new MySqlParameter("@MatKhau", matKhau)
            };

            DataTable dt = DataProvider.Instance.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new AuthDTO
                {
                    TenDangNhap = row["TenDangNhap"]?.ToString() ?? string.Empty,
                    MatKhau = row["MatKhau"]?.ToString() ?? string.Empty,
                    VaiTro = row["VaiTro"]?.ToString() ?? string.Empty,
                    MaDocGia = row["MaDocGia"] == DBNull.Value ? null : Convert.ToInt32(row["MaDocGia"]),
                    MaNhanVien = row["MaNhanVien"] == DBNull.Value ? null : Convert.ToInt32(row["MaNhanVien"]),
                    HoTen = row["HoTen"]?.ToString() ?? string.Empty
                };
            }

            return null;
        }

        public static bool CheckUserExists(string tenDangNhap)
        {
            string query = "SELECT COUNT(*) FROM DangNhap WHERE TenDangNhap = @TenDangNhap";
            MySqlParameter[] parameters = {
                new MySqlParameter("@TenDangNhap", tenDangNhap)
            };

            object result = DataProvider.Instance.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result) > 0;
        }

        public static bool ChangePassword(string tenDangNhap, string matKhauMoi)
        {
            string query = "UPDATE DangNhap SET MatKhau = @MatKhauMoi WHERE TenDangNhap = @TenDangNhap";
            MySqlParameter[] parameters = {
                new MySqlParameter("@MatKhauMoi", matKhauMoi),
                new MySqlParameter("@TenDangNhap", tenDangNhap)
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
    }
}