using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace DAO
{
    public class NguoiDungDAO
    {
        // 1. L?y t?t c? ng??i dùng
        public static BindingList<NguoiDungDTO> GetAll()
        {
            BindingList<NguoiDungDTO> list = new BindingList<NguoiDungDTO>();
            string query = @"
                SELECT 
                    nd.ID, 
                    nd.MaNguoiDung, 
                    nd.TenNguoiDung, 
                    nd.NgaySinh, 
                    nd.ChucVu,
                    nd.TenDangNhap, 
                    nd.MatKhau, 
                    nd.IDNhomNguoiDung,
                    nnd.TenNhomNguoiDung
                FROM NGUOIDUNG nd
                LEFT JOIN NHOMNGUOIDUNG nnd ON nd.IDNhomNguoiDung = nnd.ID
                ORDER BY nd.ID
            ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                NguoiDungDTO nguoiDung = new NguoiDungDTO(
                    Convert.ToInt32(item["ID"]),
                    item["MaNguoiDung"].ToString() ?? string.Empty,
                    item["TenNguoiDung"].ToString() ?? string.Empty,
                    item["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(item["NgaySinh"]) : (DateTime?)null,
                    item["ChucVu"]?.ToString() ?? string.Empty,
                    item["TenDangNhap"].ToString() ?? string.Empty,
                    item["MatKhau"].ToString() ?? string.Empty,
                    Convert.ToInt32(item["IDNhomNguoiDung"]),
                    item["TenNhomNguoiDung"]?.ToString() ?? string.Empty
                );
                list.Add(nguoiDung);
            }
            return list;
        }

        // 2. T?o mã m?i
        public static string TaoMaMoi()
        {
            string query = "SELECT MaNguoiDung FROM NGUOIDUNG ORDER BY ID DESC LIMIT 1";
            object result = DataProvider.Instance.ExecuteScalar(query);

            if (result == null || result == DBNull.Value)
            {
                return "ND0001";
            }

            string maCuoi = result.ToString(); // Ví d?: "ND0005"
            string phanSo = maCuoi.Substring(2);
            int so = int.Parse(phanSo);
            so++;

            return "ND" + so.ToString("D4");
        }

        // 3. Thêm m?i ng??i dùng
        public static string Add(NguoiDungDTO nguoiDung)
        {
            string maMoi = TaoMaMoi();

            string query = @"
                INSERT INTO NGUOIDUNG (MaNguoiDung, TenNguoiDung, NgaySinh, ChucVu, 
                    TenDangNhap, MatKhau, IDNhomNguoiDung)
                VALUES (@MaNguoiDung, @TenNguoiDung, @NgaySinh, @ChucVu, 
                    @TenDangNhap, @MatKhau, @IDNhomNguoiDung);
            ";

            int result = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@MaNguoiDung", maMoi),
                new MySqlParameter("@TenNguoiDung", nguoiDung.TenNguoiDung),
                new MySqlParameter("@NgaySinh", nguoiDung.NgaySinh ?? (object)DBNull.Value),
                new MySqlParameter("@ChucVu", nguoiDung.ChucVu ?? (object)DBNull.Value),
                new MySqlParameter("@TenDangNhap", nguoiDung.TenDangNhap),
                new MySqlParameter("@MatKhau", nguoiDung.MatKhau),
                new MySqlParameter("@IDNhomNguoiDung", nguoiDung.IDNhomNguoiDung)
            );

            return result > 0 ? maMoi : string.Empty;
        }

        // 4. C?p nh?t ng??i dùng
        public static bool Update(NguoiDungDTO nguoiDung)
        {
            string query = @"
                UPDATE NGUOIDUNG
                SET TenNguoiDung = @TenNguoiDung,
                    NgaySinh = @NgaySinh,
                    ChucVu = @ChucVu,
                    TenDangNhap = @TenDangNhap,
                    MatKhau = @MatKhau,
                    IDNhomNguoiDung = @IDNhomNguoiDung
                WHERE MaNguoiDung = @MaNguoiDung
            ";

            int count = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@TenNguoiDung", nguoiDung.TenNguoiDung),
                new MySqlParameter("@NgaySinh", nguoiDung.NgaySinh ?? (object)DBNull.Value),
                new MySqlParameter("@ChucVu", nguoiDung.ChucVu ?? (object)DBNull.Value),
                new MySqlParameter("@TenDangNhap", nguoiDung.TenDangNhap),
                new MySqlParameter("@MatKhau", nguoiDung.MatKhau),
                new MySqlParameter("@IDNhomNguoiDung", nguoiDung.IDNhomNguoiDung),
                new MySqlParameter("@MaNguoiDung", nguoiDung.MaNguoiDung)
            );

            return count > 0;
        }

        // 5. Xóa ng??i dùng
        public static bool Delete(string maNguoiDung)
        {
            string query = "DELETE FROM NGUOIDUNG WHERE MaNguoiDung = @MaNguoiDung";
            int count = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@MaNguoiDung", maNguoiDung)
            );
            return count > 0;
        }

        // 6. Ki?m tra tên ??ng nh?p ?ã t?n t?i
        public static bool IsTenDangNhapExist(string tenDangNhap, string maNguoiDung = "")
        {
            string query = @"
                SELECT COUNT(*)
                FROM NGUOIDUNG
                WHERE TenDangNhap = @tenDangNhap
                AND (@ma = '' OR MaNguoiDung <> @ma)
            ";
            int count = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query,
                new MySqlParameter("@tenDangNhap", tenDangNhap),
                new MySqlParameter("@ma", maNguoiDung)
            ));
            return count > 0;
        }

        // 7. Ki?m tra ng??i dùng có ?ang ???c s? d?ng không (có liên k?t v?i ??c gi?)
        public static bool IsInUse(string maNguoiDung)
        {
            string queryGetId = "SELECT ID FROM NGUOIDUNG WHERE MaNguoiDung = @MaNguoiDung";
            object? result = DataProvider.Instance.ExecuteScalar(queryGetId, 
                new MySqlParameter("@MaNguoiDung", maNguoiDung));

            if (result == null || result == DBNull.Value)
            {
                return false;
            }

            int idNguoiDung = Convert.ToInt32(result);

            string queryCheckUse = "SELECT COUNT(*) FROM DOCGIA WHERE IDNguoiDung = @IDNguoiDung";
            int count = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(queryCheckUse,
                new MySqlParameter("@IDNguoiDung", idNguoiDung)
            ));

            return count > 0;
        }

        // 8. ??ng nh?p
        public static NguoiDungDTO? Login(string tenDangNhap, string matKhau)
        {
            string query = @"
                SELECT 
                    nd.ID, 
                    nd.MaNguoiDung, 
                    nd.TenNguoiDung, 
                    nd.NgaySinh, 
                    nd.ChucVu,
                    nd.TenDangNhap, 
                    nd.MatKhau, 
                    nd.IDNhomNguoiDung,
                    nnd.TenNhomNguoiDung
                FROM NGUOIDUNG nd
                LEFT JOIN NHOMNGUOIDUNG nnd ON nd.IDNhomNguoiDung = nnd.ID
                WHERE nd.TenDangNhap = @TenDangNhap AND nd.MatKhau = @MatKhau
            ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query,
                new MySqlParameter("@TenDangNhap", tenDangNhap),
                new MySqlParameter("@MatKhau", matKhau)
            );

            if (data.Rows.Count > 0)
            {
                DataRow item = data.Rows[0];
                return new NguoiDungDTO(
                    Convert.ToInt32(item["ID"]),
                    item["MaNguoiDung"].ToString() ?? string.Empty,
                    item["TenNguoiDung"].ToString() ?? string.Empty,
                    item["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(item["NgaySinh"]) : (DateTime?)null,
                    item["ChucVu"]?.ToString() ?? string.Empty,
                    item["TenDangNhap"].ToString() ?? string.Empty,
                    item["MatKhau"].ToString() ?? string.Empty,
                    Convert.ToInt32(item["IDNhomNguoiDung"]),
                    item["TenNhomNguoiDung"]?.ToString() ?? string.Empty
                );
            }

            return null;
        }
    }
}
