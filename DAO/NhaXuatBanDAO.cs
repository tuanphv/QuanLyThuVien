using DTO;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;

namespace DAO
{
    public class NhaXuatBanDAO
    {
        // 1. Lấy tất cả
        public static BindingList<NhaXuatBanDTO> GetAll()
        {
            BindingList<NhaXuatBanDTO> list = new BindingList<NhaXuatBanDTO>();
            string query = "SELECT ID, TenNXB, DiaChi FROM NHAXUATBAN";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                NhaXuatBanDTO nxb = new NhaXuatBanDTO(
                    Convert.ToInt32(item["ID"]),
                    item["TenNXB"].ToString() ?? string.Empty,
                    item["DiaChi"] == DBNull.Value ? null : item["DiaChi"].ToString()
                );
                list.Add(nxb);
            }
            return list;
        }

        // 2. Thêm mới (Trả về ID mới)
        public static int Add(NhaXuatBanDTO nxb)
        {
            string query = @"
                INSERT INTO NHAXUATBAN (TenNXB, DiaChi)
                VALUES (@TenNXB, @DiaChi);
                SELECT LAST_INSERT_ID();
            ";
            object? result = DataProvider.Instance.ExecuteScalar(query,
                new MySqlParameter("@TenNXB", nxb.TenNXB),
                new MySqlParameter("@DiaChi", nxb.DiaChi ?? (object)DBNull.Value)
            );
            return Convert.ToInt32(result);
        }

        // 3. Cập nhật
        public static bool Update(NhaXuatBanDTO nxb)
        {
            string query = @"
                UPDATE NHAXUATBAN
                SET TenNXB = @TenNXB,
                    DiaChi = @DiaChi
                WHERE ID = @ID
            ";
            int count = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@TenNXB", nxb.TenNXB),
                new MySqlParameter("@DiaChi", nxb.DiaChi ?? (object)DBNull.Value),
                new MySqlParameter("@ID", nxb.ID)
            );
            return count > 0;
        }

        // 4. Xóa (Hard Delete)
        public static bool Delete(int id)
        {
            string query = "DELETE FROM NHAXUATBAN WHERE ID = @ID";
            int count = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@ID", id));
            return count > 0;
        }

        // 5. Kiểm tra trùng tên
        public static bool IsNameExist(string name, int id = 0)
        {
            string query = @"
                SELECT COUNT(*)
                FROM NHAXUATBAN
                WHERE LOWER(TenNXB) = LOWER(@ten)
                AND (@id = 0 OR ID <> @id)
            ";
            int count = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query,
                new MySqlParameter("@ten", name),
                new MySqlParameter("@id", id)
            ));
            return count > 0;
        }

        // 6. Kiểm tra NXB có đang được sử dụng trong bảng SACH không
        public static bool IsInUse(int id)
        {
            string queryCheckUse = "SELECT COUNT(*) FROM SACH WHERE IDNhaXuatBan = @ID";
            int count = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(queryCheckUse,
                new MySqlParameter("@ID", id)
            ));
            return count > 0;
        }
    }
}