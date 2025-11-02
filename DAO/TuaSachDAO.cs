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
            string query = @"
                INSERT INTO TuaSach (TenTuaSach, AnhBia)
                VALUES (@TenTuaSach, @AnhBia);

                SELECT MaTuaSach 
                FROM TuaSach 
                WHERE ID = LAST_INSERT_ID();
            ";
            string? maTuaSachMoi = DataProvider.Instance.ExecuteScalar(query,
                new MySqlParameter("@TenTuaSach", tuaSach.TenTuaSach),
                new MySqlParameter("@AnhBia", tuaSach.AnhBia ?? (object)DBNull.Value)
            )?.ToString();

            return maTuaSachMoi ?? String.Empty;
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
    }
}
