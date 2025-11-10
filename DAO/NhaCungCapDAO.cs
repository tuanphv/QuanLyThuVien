using DTO;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;

namespace DAO
{
    public class NhaCungCapDAO
    {
        // 1. Lấy tất cả
        public static BindingList<NhaCungCapDTO> GetAll()
        {
            BindingList<NhaCungCapDTO> list = new BindingList<NhaCungCapDTO>();
            string query = "SELECT ID, TenNCC, DiaChi FROM NHACUNGCAP";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                NhaCungCapDTO ncc = new NhaCungCapDTO(
                    Convert.ToInt32(item["ID"]),
                    item["TenNCC"].ToString() ?? string.Empty,
                    item["DiaChi"] == DBNull.Value ? null : item["DiaChi"].ToString()
                );
                list.Add(ncc);
            }
            return list;
        }

        // 2. Thêm mới (Trả về ID mới)
        public static int Add(NhaCungCapDTO ncc)
        {
            string query = @"
                INSERT INTO NHACUNGCAP (TenNCC, DiaChi)
                VALUES (@TenNCC, @DiaChi);
                SELECT LAST_INSERT_ID();
            ";
            object? result = DataProvider.Instance.ExecuteScalar(query,
                new MySqlParameter("@TenNCC", ncc.TenNCC),
                new MySqlParameter("@DiaChi", ncc.DiaChi ?? (object)DBNull.Value)
            );
            return Convert.ToInt32(result);
        }

        // 3. Cập nhật
        public static bool Update(NhaCungCapDTO ncc)
        {
            string query = @"
                UPDATE NHACUNGCAP
                SET TenNCC = @TenNCC,
                    DiaChi = @DiaChi
                WHERE ID = @ID
            ";
            int count = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@TenNCC", ncc.TenNCC),
                new MySqlParameter("@DiaChi", ncc.DiaChi ?? (object)DBNull.Value),
                new MySqlParameter("@ID", ncc.ID)
            );
            return count > 0;
        }

        // 4. Xóa (Hard Delete)
        public static bool Delete(int id)
        {
            string query = "DELETE FROM NHACUNGCAP WHERE ID = @ID";
            int count = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@ID", id));
            return count > 0;
        }

        // 5. Kiểm tra trùng tên
        public static bool IsNameExist(string name, int id = 0)
        {
            string query = @"
                SELECT COUNT(*)
                FROM NHACUNGCAP
                WHERE LOWER(TenNCC) = LOWER(@ten)
                AND (@id = 0 OR ID <> @id)
            ";
            int count = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query,
                new MySqlParameter("@ten", name),
                new MySqlParameter("@id", id)
            ));
            return count > 0;
        }

        // 6. Kiểm tra NCC có đang được sử dụng trong PHIEUNHAPSACH không
        public static bool IsInUse(int id)
        {
            // Bảng PHIEUNHAPSACH có khóa ngoại đến NHACUNGCAP
            string queryCheckUse = "SELECT COUNT(*) FROM PHIEUNHAPSACH WHERE IDNhaCungCap = @ID";
            int count = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(queryCheckUse,
                new MySqlParameter("@ID", id)
            ));
            return count > 0;
        }
    }
}