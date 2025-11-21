using DTO;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAO
{
    public class TuaSachDAO
    {
        public static BindingList<TuaSachDTO> GetAll()
        {
            BindingList<TuaSachDTO> list = new BindingList<TuaSachDTO>();
            string query = @"
                SELECT
                    TS.*,
                    GROUP_CONCAT(DISTINCT TL.TenTheLoai SEPARATOR ', ') AS TheLoai,
                    GROUP_CONCAT(DISTINCT TG.TenTacGia SEPARATOR ', ') AS TacGia
                FROM TuaSach AS TS
                LEFT JOIN
                    CT_TheLoai AS CT_TL ON TS.ID = CT_TL.IDTuaSach
                LEFT JOIN
                    TheLoai AS TL ON CT_TL.IDTheLoai = TL.ID
                LEFT JOIN 
                    CT_TacGia AS CT_TG ON TS.ID = CT_TG.IDTuaSach
                LEFT JOIN
                    TacGia AS TG ON CT_TG.IDTacGia = TG.ID
                WHERE TS.DaAn = 0
                GROUP BY TS.ID
            ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                TuaSachDTO tuaSach = new TuaSachDTO(
                    Convert.ToInt32(item["ID"]),
                    item["MaTuaSach"].ToString() ?? string.Empty,
                    item["TenTuaSach"].ToString() ?? string.Empty,
                    item["AnhBia"] != DBNull.Value ? (byte[])item["AnhBia"] : null,
                    item["TheLoai"].ToString() ?? string.Empty,
                    item["TacGia"].ToString() ?? string.Empty
                    );
                list.Add(tuaSach);
            }
            return list;
        }

        public static string AddBookTitle(TuaSachDTO tuaSach)
        {
            // Thêm Tựa sách và lấy ID + mã vừa tạo
            string insertQuery = @"
                INSERT INTO TuaSach (TenTuaSach, AnhBia)
                VALUES (@TenTuaSach, @AnhBia);

                SELECT ID, MaTuaSach FROM TuaSach WHERE ID = LAST_INSERT_ID();
            ";

            DataTable result = DataProvider.Instance.ExecuteQuery(insertQuery,
                new MySqlParameter("@TenTuaSach", tuaSach.TenTuaSach),
                new MySqlParameter("@AnhBia", tuaSach.AnhBia ?? (object)DBNull.Value)
            );

            if (result.Rows.Count == 0)
                return string.Empty;

            int idTuaSach = Convert.ToInt32(result.Rows[0]["ID"]);
            string maTuaSachMoi = result.Rows[0]["MaTuaSach"].ToString() ?? string.Empty;

            // Thêm Thể loại (nếu có)
            if (!string.IsNullOrWhiteSpace(tuaSach.TheLoai))
            {
                foreach (string theLoai in tuaSach.TheLoai.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries))
                {
                    InsertBookTitleGenre(theLoai, idTuaSach);
                }
            }

            // Thêm Tác giả (nếu có)
            if (!string.IsNullOrWhiteSpace(tuaSach.TacGia))
            {
                foreach (string tacGia in tuaSach.TacGia.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries))
                {
                    InsertBookTitleAuthor(tacGia, idTuaSach);
                }
            }

            return maTuaSachMoi;
        }


        private static bool InsertBookTitleGenre(string genre, int idTuaSach)
        {
            string queryGetGenreID = "SELECT ID FROM TheLoai WHERE TenTheLoai = @TenTheLoai";
            object? genreResult = DataProvider.Instance.ExecuteScalar(queryGetGenreID,
                new MySqlParameter("@TenTheLoai", genre)
            );
            if (genreResult == null) return false;

            int idTheLoai = Convert.ToInt32(genreResult);

            string queryInsert = @"
                INSERT INTO CT_TheLoai (IDTuaSach, IDTheLoai)
                VALUES (@IDTuaSach, @IDTheLoai)
            ";
            int count = DataProvider.Instance.ExecuteNonQuery(queryInsert,
                new MySqlParameter("@IDTuaSach", idTuaSach),
                new MySqlParameter("@IDTheLoai", idTheLoai)
            );

            return count > 0;
        }


        private static bool InsertBookTitleAuthor(string author, int idTuaSach)
        {
            string queryGetAuthorID = "SELECT ID FROM TacGia WHERE TenTacGia = @TenTacGia";
            object? authorResult = DataProvider.Instance.ExecuteScalar(queryGetAuthorID,
                new MySqlParameter("@TenTacGia", author)
            );
            if (authorResult == null) return false;

            int idTacGia = Convert.ToInt32(authorResult);

            string queryInsert = @"
                INSERT INTO CT_TacGia (IDTuaSach, IDTacGia)
                VALUES (@IDTuaSach, @IDTacGia)
            ";
            int count = DataProvider.Instance.ExecuteNonQuery(queryInsert,
                new MySqlParameter("@IDTuaSach", idTuaSach),
                new MySqlParameter("@IDTacGia", idTacGia)
            );

            return count > 0;
        }


        public static bool IsNameExist(string name, string ma = "")
        {
            string query = @"
                SELECT COUNT(*)
                FROM TUASACH AS TS
                WHERE LOWER(TenTuaSach) = LOWER(@ten)
                AND (@ma = '' OR TS.MaTuaSach <> @ma)
            ";
            int count = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query,
                new MySqlParameter("@ten", name),
                new MySqlParameter("@ma", ma)
            ));
            return count > 0;
        }

        public static bool UpdateBookTitle(TuaSachDTO tuaSach)
        {
            string query = @"
                UPDATE TuaSach
                SET TenTuaSach = @TenTuaSach,
                    AnhBia = @AnhBia
                WHERE MaTuaSach = @ID
            ";
            int count = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@TenTuaSach", tuaSach.TenTuaSach),
                new MySqlParameter("@AnhBia", tuaSach.AnhBia ?? (object)DBNull.Value),
                new MySqlParameter("@ID", tuaSach.MaTuaSach)
            );

            return count > 0;
        }

        public static bool DeleteBookTitle(int id)
        {
            string query = @"
                UPDATE TuaSach
                SET DaAn = 1 
                WHERE ID = @ID
            ";
            int count = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@ID", id)
            );
            return count > 0;
        }

        //Trí thêm hàm lấy tựa sách theo mã thể loại
        public static List<TuaSachDTO> GetByMaTheLoai(string maTheLoai)
        {
            List<TuaSachDTO> list = new List<TuaSachDTO>();

            // Câu truy vấn: Join qua bảng trung gian CT_TheLoai và TheLoai để lọc theo MaTheLoai
            // Vẫn giữ các LEFT JOIN khác để lấy đầy đủ tên Tác giả hiển thị lên Grid
            string query = @"
                            SELECT 
                                TS.*,
                                GROUP_CONCAT(DISTINCT TL.TenTheLoai SEPARATOR ', ') AS TheLoai,
                                GROUP_CONCAT(DISTINCT TG.TenTacGia SEPARATOR ', ') AS TacGia
                            FROM TuaSach AS TS
                            JOIN 
                                CT_TheLoai AS CT_TL_Filter ON TS.ID = CT_TL_Filter.IDTuaSach
                            JOIN 
                                TheLoai AS TL_Filter ON CT_TL_Filter.IDTheLoai = TL_Filter.ID
                            LEFT JOIN
                                CT_TheLoai AS CT_TL ON TS.ID = CT_TL.IDTuaSach
                            LEFT JOIN
                                TheLoai AS TL ON CT_TL.IDTheLoai = TL.ID
                            LEFT JOIN 
                                CT_TacGia AS CT_TG ON TS.ID = CT_TG.IDTuaSach
                            LEFT JOIN
                                TacGia AS TG ON CT_TG.IDTacGia = TG.ID
                            WHERE TL_Filter.MaTheLoai = @MaTheLoai 
                              AND TS.DaAn = 0
                            GROUP BY TS.ID
                        ";
            // Thực thi truy vấn với tham số @MaTheLoai
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new MySqlParameter("@MaTheLoai", maTheLoai));

            // Chuyển đổi dữ liệu từ DataTable sang List<TuaSachDTO>
            foreach (DataRow item in data.Rows)
            {
                TuaSachDTO tuaSach = new TuaSachDTO(
                    Convert.ToInt32(item["ID"]),
                    item["MaTuaSach"].ToString() ?? string.Empty,
                    item["TenTuaSach"].ToString() ?? string.Empty,
                    item["AnhBia"] != DBNull.Value ? (byte[])item["AnhBia"] : null,
                    item["TheLoai"].ToString() ?? string.Empty,
                    item["TacGia"].ToString() ?? string.Empty
                );
                list.Add(tuaSach);
            }

            return list;
        }

        // Trí thêm hàm lấy tựa sách theo mã tác giả
        public static List<TuaSachDTO> GetByMaTacGia(string maTacGia)
        {
            List<TuaSachDTO> list = new List<TuaSachDTO>();

            // SQL: Lọc theo Tác giả (Filter), nhưng vẫn lấy kèm thông tin Thể loại để hiển thị
            string query = @"
                            SELECT 
                                TS.*,
                                GROUP_CONCAT(DISTINCT TL.TenTheLoai SEPARATOR ', ') AS TheLoai,
                                GROUP_CONCAT(DISTINCT TG.TenTacGia SEPARATOR ', ') AS TacGia
                            FROM TuaSach AS TS
                            -- JOIN đoạn này để LỌC theo mã tác giả được chọn
                            JOIN 
                                CT_TacGia AS CT_TG_Filter ON TS.ID = CT_TG_Filter.IDTuaSach
                            JOIN 
                                TacGia AS TG_Filter ON CT_TG_Filter.IDTacGia = TG_Filter.ID
        
                            -- LEFT JOIN đoạn này để LẤY DỮ LIỆU hiển thị (Thể loại, Tác giả khác nếu có)
                            LEFT JOIN
                                CT_TheLoai AS CT_TL ON TS.ID = CT_TL.IDTuaSach
                            LEFT JOIN
                                TheLoai AS TL ON CT_TL.IDTheLoai = TL.ID
                            LEFT JOIN 
                                CT_TacGia AS CT_TG ON TS.ID = CT_TG.IDTuaSach
                            LEFT JOIN
                                TacGia AS TG ON CT_TG.IDTacGia = TG.ID
            
                            WHERE TG_Filter.MaTacGia = @MaTacGia 
                              AND TS.DaAn = 0
                            GROUP BY TS.ID
                        ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new MySqlParameter("@MaTacGia", maTacGia));

            foreach (DataRow item in data.Rows)
            {
                TuaSachDTO tuaSach = new TuaSachDTO(
                    Convert.ToInt32(item["ID"]),
                    item["MaTuaSach"].ToString() ?? string.Empty,
                    item["TenTuaSach"].ToString() ?? string.Empty,
                    item["AnhBia"] != DBNull.Value ? (byte[])item["AnhBia"] : null,
                    item["TheLoai"].ToString() ?? string.Empty, // Đã lấy được tên thể loại ở đây
                    item["TacGia"].ToString() ?? string.Empty
                );
                list.Add(tuaSach);
            }

            return list;
        }
    }
}
