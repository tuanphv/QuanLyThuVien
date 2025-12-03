using DTO;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;

namespace DAO
{
    public class SachDAO
    {
        // 1. Lấy toàn bộ sách
        public static BindingList<SachDTO> GetAll()
        {
            BindingList<SachDTO> list = new BindingList<SachDTO>();

            string query = @"
                SELECT 
                    MaSach,
                    TieuDe,
                    ISBN,
                    NamXuatBan,
                    GiaSach,
                    SoLuongTong,
                    SoLuongCon,
                    MaNXB,
                    MaTheLoai
                FROM SACH
                ORDER BY MaSach
            ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                SachDTO sach = new SachDTO(
                    Convert.ToInt32(item["MaSach"]),
                    item["TieuDe"]?.ToString() ?? string.Empty,
                    item["ISBN"]?.ToString() ?? string.Empty,
                    Convert.ToInt32(item["NamXuatBan"]),
                    Convert.ToDecimal(item["GiaSach"]),
                    Convert.ToInt32(item["SoLuongTong"]),
                    Convert.ToInt32(item["SoLuongCon"]),
                    Convert.ToInt32(item["MaNXB"]),
                    Convert.ToInt32(item["MaTheLoai"])
                );

                list.Add(sach);
            }

            return list;
        }

        // 2. Tạo mã sách mới (dạng S0001)
        public static string TaoMaMoi()
        {
            string query = "SELECT MaSach FROM SACH ORDER BY MaSach DESC LIMIT 1";

            object result = DataProvider.Instance.ExecuteScalar(query);

            if (result == null || result == DBNull.Value)
            {
                return "S0001";
            }

            string maCuoi = result.ToString();   // ví dụ: S0005
            string phanSo = maCuoi.Substring(1);
            int soMoi = int.Parse(phanSo) + 1;

            return "S" + soMoi.ToString("D4");  // S0006
        }

        // 3. Thêm sách
        public static string Add(SachDTO sach)
        {
            string query = @"
                INSERT INTO SACH
                (MaSach, TieuDe, ISBN, NamXuatBan, GiaSach, SoLuongTong, SoLuongCon, MaNXB, MaTheLoai)
                VALUES
                (@MaSach, @TieuDe, @ISBN, @NamXuatBan, @GiaSach, @SoLuongTong, @SoLuongCon, @MaNXB, @MaTheLoai)
            ";

            string maMoi = TaoMaMoi();

            int result = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@MaSach", maMoi),
                new MySqlParameter("@TieuDe", sach.TieuDe),
                new MySqlParameter("@ISBN", sach.ISBN),
                new MySqlParameter("@NamXuatBan", sach.NamXuatBan),
                new MySqlParameter("@GiaSach", sach.GiaSach),
                new MySqlParameter("@SoLuongTong", sach.SoLuongTong),
                new MySqlParameter("@SoLuongCon", sach.SoLuongCon),
                new MySqlParameter("@MaNXB", sach.MaNXB),
                new MySqlParameter("@MaTheLoai", sach.MaTheLoai)
            );

            return result > 0 ? maMoi : string.Empty;
        }

        // 4. Cập nhật sách
        public static bool Update(SachDTO sach)
        {
            string query = @"
                UPDATE SACH
                SET 
                    TieuDe = @TieuDe,
                    ISBN = @ISBN,
                    NamXuatBan = @NamXuatBan,
                    GiaSach = @GiaSach,
                    SoLuongTong = @SoLuongTong,
                    SoLuongCon = @SoLuongCon,
                    MaNXB = @MaNXB,
                    MaTheLoai = @MaTheLoai
                WHERE MaSach = @MaSach
            ";

            int count = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@TieuDe", sach.TieuDe),
                new MySqlParameter("@ISBN", sach.ISBN),
                new MySqlParameter("@NamXuatBan", sach.NamXuatBan),
                new MySqlParameter("@GiaSach", sach.GiaSach),
                new MySqlParameter("@SoLuongTong", sach.SoLuongTong),
                new MySqlParameter("@SoLuongCon", sach.SoLuongCon),
                new MySqlParameter("@MaNXB", sach.MaNXB),
                new MySqlParameter("@MaTheLoai", sach.MaTheLoai),
                new MySqlParameter("@MaSach", sach.MaSach)
            );

            return count > 0;
        }

        // 5. Xóa sách
        public static bool Delete(int maSach)
        {
            string query = "DELETE FROM SACH WHERE MaSach = @MaSach";

            int count = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@MaSach", maSach)
            );

            return count > 0;
        }

        // 6. Kiểm tra ISBN có tồn tại
        public static bool IsISBNExists(string isbn)
        {
            string query = "SELECT COUNT(*) FROM SACH WHERE ISBN = @ISBN";

            int count = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query,
                new MySqlParameter("@ISBN", isbn)
            ));

            return count > 0;
        }

        // 7. Kiểm tra ISBN có thuộc về sách khác không
        public static bool IsISBNBelongsToSach(string isbn, int maSach)
        {
            string query = @"
                SELECT COUNT(*)
                FROM SACH
                WHERE ISBN = @ISBN AND MaSach != @MaSach
            ";

            int count = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query,
                new MySqlParameter("@ISBN", isbn),
                new MySqlParameter("@MaSach", maSach)
            ));

            return count == 0;
        }

        // 8. Kiểm tra sách có đang được dùng không
        public static bool IsInUse(int maSach)
        {
            string query = @"
                SELECT COUNT(*) FROM CHITIETMUON WHERE MaSach = @MaSach
                UNION ALL
                SELECT COUNT(*) FROM CHITIETNHAPSACH WHERE MaSach = @MaSach
            ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query,
                new MySqlParameter("@MaSach", maSach)
            );

            foreach (DataRow row in data.Rows)
            {
                if (Convert.ToInt32(row[0]) > 0)
                    return true;
            }

            return false;
        }

        // 9. Tìm kiếm theo tiêu đề
        public static BindingList<SachDTO> SearchByTieuDe(string tieuDe)
        {
            BindingList<SachDTO> list = new BindingList<SachDTO>();

            string query = @"
                SELECT *
                FROM SACH
                WHERE TieuDe LIKE CONCAT(@TieuDe, '%')
            ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query,
                new MySqlParameter("@TieuDe", tieuDe)
            );

            foreach (DataRow item in data.Rows)
            {
                SachDTO sach = new SachDTO(
                    Convert.ToInt32(item["MaSach"]),
                    item["TieuDe"]?.ToString() ?? string.Empty,
                    item["ISBN"]?.ToString() ?? string.Empty,
                    Convert.ToInt32(item["NamXuatBan"]),
                    Convert.ToDecimal(item["GiaSach"]),
                    Convert.ToInt32(item["SoLuongTong"]),
                    Convert.ToInt32(item["SoLuongCon"]),
                    Convert.ToInt32(item["MaNXB"]),
                    Convert.ToInt32(item["MaTheLoai"])
                );

                list.Add(sach);
            }

            return list;
        }
    }
}
