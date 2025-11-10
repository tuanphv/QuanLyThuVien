using DTO;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;

namespace DAO
{
    public class TacGiaDAO
    {
        // 1. Lấy tất cả
        public static BindingList<TacGiaDTO> GetAll()
        {
            BindingList<TacGiaDTO> list = new BindingList<TacGiaDTO>();
            // Lưu ý: Cột mã trong SQL là MATACGIA
            string query = "SELECT ID, MATACGIA, TenTacGia FROM TACGIA";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                TacGiaDTO tacGia = new TacGiaDTO(
                    Convert.ToInt32(item["ID"]),
                    item["MATACGIA"].ToString() ?? string.Empty,
                    item["TenTacGia"].ToString() ?? string.Empty
                );
                list.Add(tacGia);
            }
            return list;
        }

        // 2. Thêm mới (Trả về MaTacGia mới)
        public static string Add(TacGiaDTO tacGia)
        {
            string query = @"
                INSERT INTO TACGIA (TenTacGia)
                VALUES (@TenTacGia);

                SELECT MATACGIA 
                FROM TACGIA 
                WHERE ID = LAST_INSERT_ID();
            ";
            string? maTacGiaMoi = DataProvider.Instance.ExecuteScalar(query,
                new MySqlParameter("@TenTacGia", tacGia.TenTacGia)
            )?.ToString();

            return maTacGiaMoi ?? string.Empty;
        }

        // 3. Cập nhật
        public static bool Update(TacGiaDTO tacGia)
        {
            string query = @"
                UPDATE TACGIA
                SET TenTacGia = @TenTacGia
                WHERE MATACGIA = @MaTacGia
            ";
            int count = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@TenTacGia", tacGia.TenTacGia),
                new MySqlParameter("@MaTacGia", tacGia.MaTacGia)
            );

            return count > 0;
        }

        // 4. Xóa 
        public static bool Delete(string maTacGia)
        {
            string query = @"
                DELETE FROM TACGIA
                WHERE MATACGIA = @MaTacGia
            ";
            int count = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@MaTacGia", maTacGia)
            );
            return count > 0;
        }

        // 5. Kiểm tra trùng tên
        public static bool IsNameExist(string name, string ma = "")
        {
            string query = @"
                SELECT COUNT(*)
                FROM TACGIA
                WHERE LOWER(TenTacGia) = LOWER(@ten)
                AND (@ma = '' OR MATACGIA <> @ma)
            ";
            int count = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query,
                new MySqlParameter("@ten", name),
                new MySqlParameter("@ma", ma)
            ));
            return count > 0;
        }

        // 6. Kiểm tra xem Tác giả có đang được sử dụng trong CT_TACGIA không
        public static bool IsInUse(string maTacGia)
        {
            string queryGetId = "SELECT ID FROM TACGIA WHERE MATACGIA = @MaTacGia";
            object? result = DataProvider.Instance.ExecuteScalar(queryGetId, new MySqlParameter("@MaTacGia", maTacGia));

            if (result == null || result == DBNull.Value)
            {
                return false;
            }

            int idTacGia = Convert.ToInt32(result);

            string queryCheckUse = "SELECT COUNT(*) FROM CT_TACGIA WHERE IDTacGia = @IDTacGia";
            int count = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(queryCheckUse,
                new MySqlParameter("@IDTacGia", idTacGia)
            ));

            return count > 0;
        }
    }
}