using DTO;
using MySql.Data.MySqlClient;
using System;
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
            // Lấy tất cả cột, bao gồm NamSinh
            string query = "SELECT * FROM TACGIA";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                TacGiaDTO tacGia = new TacGiaDTO(
                    Convert.ToInt32(item["ID"]),
                    item["MATACGIA"].ToString() ?? string.Empty,
                    item["TenTacGia"].ToString() ?? string.Empty,
                    item["NamSinh"] != DBNull.Value ? Convert.ToInt32(item["NamSinh"]) : 0
                );
                list.Add(tacGia);
            }
            return list;
        }

        //
        public static string TaoMaMoi()
        {
            string query = "SELECT MATACGIA FROM TACGIA ORDER BY ID DESC LIMIT 1";
            object result = DataProvider.Instance.ExecuteScalar(query);

            if (result == null || result == DBNull.Value)
            {
                return "TG0001";
            }

            string maCuoi = result.ToString(); // Ví dụ: "TG0005"
            string phanSo = maCuoi.Substring(2); // Bỏ "TG"
            int so = int.Parse(phanSo);
            so++;

            return "TG" + so.ToString("D4");
        }

        // 2. Thêm mới 
        public static string Add(TacGiaDTO tacGia)
        {            
            string maMoi = TaoMaMoi();
                        
            string query = @"
                INSERT INTO TACGIA (MATACGIA, TenTacGia, NamSinh)
                VALUES (@Ma, @Ten, @Nam);
            ";

            int result = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@Ma", maMoi),
                new MySqlParameter("@Ten", tacGia.TenTacGia),
                new MySqlParameter("@Nam", tacGia.NamSinh)
            );

            return result > 0 ? maMoi : string.Empty;
        }

        // 3. Cập nhật 
        public static bool Update(TacGiaDTO tacGia)
        {
            string query = @"
                UPDATE TACGIA
                SET TenTacGia = @Ten, 
                    NamSinh = @Nam
                WHERE MATACGIA = @Ma
            ";
            int count = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@Ten", tacGia.TenTacGia),
                new MySqlParameter("@Nam", tacGia.NamSinh), 
                new MySqlParameter("@Ma", tacGia.MaTacGia)
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
        public static bool IsNameExist(string name,int namSinh, string ma = "")
        {
            string query = @"
                SELECT COUNT(*)
                FROM TACGIA
                WHERE LOWER(TenTacGia) = LOWER(@ten)
                AND NamSinh = @namSinh
                AND (@ma = '' OR MATACGIA <> @ma)
            ";
            int count = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query,
                new MySqlParameter("@ten", name),
                new MySqlParameter("@namSinh", namSinh),
                new MySqlParameter("@ma", ma)
            ));
            return count > 0;
        }

        // 6. Kiểm tra ràng buộc khóa ngoại
        public static bool IsInUse(string maTacGia)
        {
            string queryGetId = "SELECT ID FROM TACGIA WHERE MATACGIA = @MaTacGia";
            object? result = DataProvider.Instance.ExecuteScalar(queryGetId, new MySqlParameter("@MaTacGia", maTacGia));

            if (result == null || result == DBNull.Value) return false;

            int idTacGia = Convert.ToInt32(result);

            string queryCheckUse = "SELECT COUNT(*) FROM CT_TACGIA WHERE IDTacGia = @IDTacGia";
            int count = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(queryCheckUse,
                new MySqlParameter("@IDTacGia", idTacGia)
            ));

            return count > 0;
        }
    }
}