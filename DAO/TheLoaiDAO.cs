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
        public static string Add(TheLoaiDTO theLoai)
        {
            string query = @"
                INSERT INTO THELOAI (TenTheLoai)
                VALUES (@TenTheLoai);

                SELECT MaTheLoai 
                FROM THELOAI 
                WHERE ID = LAST_INSERT_ID();
            ";
            string? maTheLoaiMoi = DataProvider.Instance.ExecuteScalar(query,
                new MySqlParameter("@TenTheLoai", theLoai.TenTheLoai)
            )?.ToString();

            return maTheLoaiMoi ?? string.Empty;
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
    }
}