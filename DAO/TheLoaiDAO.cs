using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace DAO
{
    public class TheLoaiDAO
    {
        // 1. Lấy tất cả
        public static BindingList<TheLoaiDTO> GetAll()
        {
            BindingList<TheLoaiDTO> list = new BindingList<TheLoaiDTO>();
            string query = "SELECT ID, MaTheLoai, TenTheLoai FROM THELOAI";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                TheLoaiDTO theLoai = new TheLoaiDTO(
                    Convert.ToInt32(item["ID"]),
                    item["MaTheLoai"].ToString() ?? string.Empty,
                    item["TenTheLoai"].ToString() ?? string.Empty
                );
                list.Add(theLoai);
            }
            return list;
        }

        // 2. Thêm mới 
        public static string TaoMaMoi()
        {
            // Lấy mã thể loại cuối cùng (sắp xếp giảm dần để lấy cái lớn nhất)
            string query = "SELECT MaTheLoai FROM THELOAI ORDER BY ID DESC LIMIT 1";
            object result = DataProvider.Instance.ExecuteScalar(query);

            // Nếu bảng chưa có dữ liệu thì trả về mã đầu tiên
            if (result == null || result == DBNull.Value)
            {
                return "TL0001";
            }

            string maCuoi = result.ToString(); // Ví dụ: "TL0005"

            // Xử lý tách số: Bỏ 2 ký tự đầu "TL", lấy phần số còn lại
            string phanSo = maCuoi.Substring(2);
            int so = int.Parse(phanSo);

            // Tăng lên 1
            so++;

            // Ghép lại thành mã mới: "TL" + số (định dạng 4 chữ số)
            return "TL" + so.ToString("D4");
        }
        public static string Add(TheLoaiDTO theLoai)
        {
            // Bước 1: Tạo mã mới trước
            string maMoi = TaoMaMoi();

            // Bước 2: Insert cả Mã và Tên vào Database
            string query = @"
                INSERT INTO THELOAI (MaTheLoai, TenTheLoai)
                VALUES (@MaTheLoai, @TenTheLoai);
            ";

            int result = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@MaTheLoai", maMoi),
                new MySqlParameter("@TenTheLoai", theLoai.TenTheLoai)
            );

            // Nếu insert thành công (result > 0) thì trả về mã mới, ngược lại trả về rỗng
            return result > 0 ? maMoi : string.Empty;
        }

        // 3. Cập nhật
        public static bool Update(TheLoaiDTO theLoai)
        {
            string query = @"
                UPDATE THELOAI
                SET TenTheLoai = @TenTheLoai
                WHERE MaTheLoai = @MaTheLoai
            ";
            int count = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@TenTheLoai", theLoai.TenTheLoai),
                new MySqlParameter("@MaTheLoai", theLoai.MaTheLoai)
            );

            return count > 0;
        }

        // 4. Xóa 
        public static bool Delete(string maTheLoai)
        {
            string query = @"
                DELETE FROM THELOAI
                WHERE MaTheLoai = @MaTheLoai
            ";
            int count = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@MaTheLoai", maTheLoai)
            );
            return count > 0;
        }

        // 5. Kiểm tra trùng tên 
        public static bool IsNameExist(string name, string ma = "")
        {
            string query = @"
                SELECT COUNT(*)
                FROM THELOAI
                WHERE LOWER(TenTheLoai) = LOWER(@ten)
                AND (@ma = '' OR MaTheLoai <> @ma)
            ";
            int count = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query,
                new MySqlParameter("@ten", name),
                new MySqlParameter("@ma", ma)
            ));
            return count > 0;
        }

        // 6. Kiểm tra xem thể loại có đang được sử dụng trong CT_THELOAI không
        public static bool IsInUse(string maTheLoai)
        {
            // Lấy ID của thể loại từ MaTheLoai
            string queryGetId = "SELECT ID FROM THELOAI WHERE MaTheLoai = @MaTheLoai";
            object? result = DataProvider.Instance.ExecuteScalar(queryGetId, new MySqlParameter("@MaTheLoai", maTheLoai));

            if (result == null || result == DBNull.Value)
            {
                // Không tìm thấy thể loại (lỗi lạ, nhưng cứ coi như là không dùng)
                return false;
            }

            int idTheLoai = Convert.ToInt32(result);

            // Đếm xem ID này xuất hiện bao nhiêu lần trong bảng CT_THELOAI
            string queryCheckUse = "SELECT COUNT(*) FROM CT_THELOAI WHERE IDTheLoai = @IDTheLoai";
            int count = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(queryCheckUse,
                new MySqlParameter("@IDTheLoai", idTheLoai)
            ));

            return count > 0;
        }
    }
}