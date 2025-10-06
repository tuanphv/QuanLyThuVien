using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using LibraryManagement.DTO;

namespace LibraryManagement.DAO
{
    public class BookDAO
    {
        private readonly string connectionString = "Data Source=.;Initial Catalog=QLTV;Integrated Security=True";

        public List<BookDTO> GetAllBooks()
        {
            List<BookDTO> books = new List<BookDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Sach";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    BookDTO book = new BookDTO
                    {
                        MaSach = (int)reader["MaSach"],
                        TieuDe = reader["TieuDe"].ToString(),
                        ISBN = reader["ISBN"].ToString(),
                        NamXuatBan = (int)reader["NamXuatBan"],
                        GiaSach = (decimal)reader["GiaSach"],
                        SoLuongTong = (int)reader["SoLuongTong"],
                        SoLuongCon = (int)reader["SoLuongCon"],
                        MaNXB = (int)reader["MaNXB"],
                        MaTheLoai = (int)reader["MaTheLoai"]
                    };
                    books.Add(book);
                }
            }
            return books;
        }

        public bool InsertBook(BookDTO book)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Sach (TieuDe, ISBN, NamXuatBan, GiaSach, SoLuongTong, SoLuongCon, MaNXB, MaTheLoai)
                                 VALUES (@TieuDe, @ISBN, @NamXuatBan, @GiaSach, @SoLuongTong, @SoLuongCon, @MaNXB, @MaTheLoai)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TieuDe", book.TieuDe);
                cmd.Parameters.AddWithValue("@ISBN", book.ISBN);
                cmd.Parameters.AddWithValue("@NamXuatBan", book.NamXuatBan);
                cmd.Parameters.AddWithValue("@GiaSach", book.GiaSach);
                cmd.Parameters.AddWithValue("@SoLuongTong", book.SoLuongTong);
                cmd.Parameters.AddWithValue("@SoLuongCon", book.SoLuongCon);
                cmd.Parameters.AddWithValue("@MaNXB", book.MaNXB);
                cmd.Parameters.AddWithValue("@MaTheLoai", book.MaTheLoai);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateBook(BookDTO book)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"UPDATE Sach SET 
                                TieuDe=@TieuDe, ISBN=@ISBN, NamXuatBan=@NamXuatBan, GiaSach=@GiaSach,
                                SoLuongTong=@SoLuongTong, SoLuongCon=@SoLuongCon, 
                                MaNXB=@MaNXB, MaTheLoai=@MaTheLoai
                                WHERE MaSach=@MaSach";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSach", book.MaSach);
                cmd.Parameters.AddWithValue("@TieuDe", book.TieuDe);
                cmd.Parameters.AddWithValue("@ISBN", book.ISBN);
                cmd.Parameters.AddWithValue("@NamXuatBan", book.NamXuatBan);
                cmd.Parameters.AddWithValue("@GiaSach", book.GiaSach);
                cmd.Parameters.AddWithValue("@SoLuongTong", book.SoLuongTong);
                cmd.Parameters.AddWithValue("@SoLuongCon", book.SoLuongCon);
                cmd.Parameters.AddWithValue("@MaNXB", book.MaNXB);
                cmd.Parameters.AddWithValue("@MaTheLoai", book.MaTheLoai);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteBook(int maSach)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Sach WHERE MaSach=@MaSach";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSach", maSach);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
