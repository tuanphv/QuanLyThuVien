using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using DTO;

namespace DAO
{
    public class TheLoaiDAO
    {     
        private static TheLoaiDAO instance;

        public static TheLoaiDAO Instance
        {
            get { if (instance == null) instance = new TheLoaiDAO(); return instance; }
            private set { instance = value; }
        }

        private TheLoaiDAO() { }
        public List<TheLoaiDTO> GetAllTheLoai()
        {
            List<TheLoaiDTO> listTheLoai = new List<TheLoaiDTO>();

            // Câu lệnh SQL
            string query = "SELECT ID, MaTheLoai, TenTheLoai FROM THELOAI";

            // Dùng DataProvider để thực thi
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            // Duyệt qua từng dòng trong DataTable
            foreach (DataRow row in data.Rows)
            {
                // Tạo đối tượng DTO từ dữ liệu đọc được
                TheLoaiDTO theLoai = new TheLoaiDTO
                {
                    ID = (int)row["ID"],
                    MaTheLoai = row["MaTheLoai"].ToString(),
                    TenTheLoai = row["TenTheLoai"].ToString()
                };
                listTheLoai.Add(theLoai);
            }

            return listTheLoai;
        }

        // 3. Phương thức THÊM thể loại mới
        // Lưu ý: ID và MaTheLoai đã được CSDL tự động tạo (trigger)
        public bool InsertTheLoai(string tenTheLoai)
        {
            // Câu lệnh SQL với tham số @TenTheLoai
            string query = "INSERT INTO THELOAI (TenTheLoai) VALUES (@TenTheLoai)";

            // Tạo mảng MySqlParameter
            MySqlParameter[] parameters = new MySqlParameter[1];
            parameters[0] = new MySqlParameter("@TenTheLoai", MySqlDbType.VarChar) { Value = tenTheLoai };

            // Gọi DataProvider.ExecuteNonQuery để thực thi
            // (Giả sử DataProvider của bạn có phương thức ExecuteNonQuery nhận tham số)
            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);

            // Trả về true nếu có 1 dòng bị ảnh hưởng (thêm thành công)
            return result > 0;
        }

        // 4. Phương thức CẬP NHẬT thể loại
        public bool UpdateTheLoai(int id, string tenTheLoai)
        {
            string query = "UPDATE THELOAI SET TenTheLoai = @TenTheLoai WHERE ID = @ID";

            MySqlParameter[] parameters = new MySqlParameter[2];
            parameters[0] = new MySqlParameter("@TenTheLoai", MySqlDbType.VarChar) { Value = tenTheLoai };
            parameters[1] = new MySqlParameter("@ID", MySqlDbType.Int32) { Value = id };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);

            return result > 0;
        }

        // 5. Phương thức XÓA thể loại
        public bool DeleteTheLoai(int id)
        {
            // Cân nhắc: Nên làm "ẩn" (đặt cờ DaAn = 1) thay vì xóa vĩnh viễn
            // Nhưng theo CSDL của bạn, bảng THELOAI không có cột DaAn nên ta sẽ XÓA
            string query = "DELETE FROM THELOAI WHERE ID = @ID";

            MySqlParameter[] parameters = new MySqlParameter[1];
            parameters[0] = new MySqlParameter("@ID", MySqlDbType.Int32) { Value = id };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);

            return result > 0;
        }

        // (Tùy chọn) 6. Phương thức TÌM KIẾM (nếu form của bạn có chức năng tìm kiếm)
        public List<TheLoaiDTO> SearchTheLoai(string keyword)
        {
            List<TheLoaiDTO> listTheLoai = new List<TheLoaiDTO>();

            // Tìm kiếm theo cả Mã và Tên
            string query = "SELECT ID, MaTheLoai, TenTheLoai FROM THELOAI WHERE TenTheLoai LIKE @keyword OR MaTheLoai LIKE @keyword";

            MySqlParameter[] parameters = new MySqlParameter[1];
            // Thêm dấu % để tìm kiếm tương đối
            parameters[0] = new MySqlParameter("@keyword", MySqlDbType.VarChar) { Value = "%" + keyword + "%" };

            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);

            foreach (DataRow row in data.Rows)
            {
                TheLoaiDTO theLoai = new TheLoaiDTO
                {
                    ID = (int)row["ID"],
                    MaTheLoai = row["MaTheLoai"].ToString(),
                    TenTheLoai = row["TenTheLoai"].ToString()
                };
                listTheLoai.Add(theLoai);
            }

            return listTheLoai;
        }
    }
}