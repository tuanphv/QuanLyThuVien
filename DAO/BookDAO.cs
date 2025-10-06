using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAO
{
    public class BookDAO
    {
        // Lấy tất cả sách
        public List<BookDTO> GetAllBooks()
        {
            List<BookDTO> list = new List<BookDTO>();
            string query = "SELECT * FROM Sach";

            DataTable dt = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new BookDTO
                {
                    MaSach = Convert.ToInt32(row["MaSach"]),
                    TieuDe = row["TieuDe"].ToString() ?? "",
                    ISBN = row["ISBN"].ToString() ?? "",
                    NamXuatBan = Convert.ToInt32(row["NamXuatBan"]),
                    GiaSach = Convert.ToDecimal(row["GiaSach"]),
                    SoLuongTong = Convert.ToInt32(row["SoLuongTong"]),
                    SoLuongCon = Convert.ToInt32(row["SoLuongCon"]),
                    MaNXB = Convert.ToInt32(row["MaNXB"]),
                    MaTheLoai = Convert.ToInt32(row["MaTheLoai"])
                });
            }

            return list;
        }

        // Thêm sách mới
        public bool AddBook(BookDTO book)
        {
            try
            {
                string query = @"
                    INSERT INTO Sach (TieuDe, ISBN, NamXuatBan, GiaSach, SoLuongTong, SoLuongCon, MaNXB, MaTheLoai)
                    VALUES (@TieuDe, @ISBN, @NamXuatBan, @GiaSach, @SoLuongTong, @SoLuongCon, @MaNXB, @MaTheLoai)";

                int result = DataProvider.Instance.ExecuteNonQuery(query,
                    new MySqlParameter("@TieuDe", book.TieuDe),
                    new MySqlParameter("@ISBN", book.ISBN),
                    new MySqlParameter("@NamXuatBan", book.NamXuatBan),
                    new MySqlParameter("@GiaSach", book.GiaSach),
                    new MySqlParameter("@SoLuongTong", book.SoLuongTong),
                    new MySqlParameter("@SoLuongCon", book.SoLuongCon),
                    new MySqlParameter("@MaNXB", book.MaNXB),
                    new MySqlParameter("@MaTheLoai", book.MaTheLoai)
                );

                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm sách: " + ex.Message);
                return false;
            }
        }

        // Cập nhật thông tin sách
        public bool UpdateBook(BookDTO book)
        {
            try
            {
                string query = @"
                    UPDATE Sach SET
                        TieuDe = @TieuDe,
                        ISBN = @ISBN,
                        NamXuatBan = @NamXuatBan,
                        GiaSach = @GiaSach,
                        SoLuongTong = @SoLuongTong,
                        SoLuongCon = @SoLuongCon,
                        MaNXB = @MaNXB,
                        MaTheLoai = @MaTheLoai
                    WHERE MaSach = @MaSach";

                int result = DataProvider.Instance.ExecuteNonQuery(query,
                    new MySqlParameter("@MaSach", book.MaSach),
                    new MySqlParameter("@TieuDe", book.TieuDe),
                    new MySqlParameter("@ISBN", book.ISBN),
                    new MySqlParameter("@NamXuatBan", book.NamXuatBan),
                    new MySqlParameter("@GiaSach", book.GiaSach),
                    new MySqlParameter("@SoLuongTong", book.SoLuongTong),
                    new MySqlParameter("@SoLuongCon", book.SoLuongCon),
                    new MySqlParameter("@MaNXB", book.MaNXB),
                    new MySqlParameter("@MaTheLoai", book.MaTheLoai)
                );

                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi cập nhật sách: " + ex.Message);
                return false;
            }
        }

        // Xóa sách
        public bool DeleteBook(int maSach)
        {
            try
            {
                string query = "DELETE FROM Sach WHERE MaSach = @MaSach";
                int result = DataProvider.Instance.ExecuteNonQuery(query,
                    new MySqlParameter("@MaSach", maSach));
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xóa sách: " + ex.Message);
                return false;
            }
        }
    }
}
