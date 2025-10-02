using DTO;
using MySql.Data.MySqlClient;

namespace DAO
{
    public class LibraryCarDAO
    {
        public static List<LibraryCardDTO> GetAllLibraryCards()
        {
            List<LibraryCardDTO> list = new List<LibraryCardDTO>();
            string query = "SELECT * FROM TheThuVien";
            System.Data.DataTable dt = DataProvider.Instance.ExecuteQuery(query);

            foreach (System.Data.DataRow row in dt.Rows)
            {
                list.Add(new LibraryCardDTO
                {
                    MaThe = row["MaThe"] == DBNull.Value ? 0 : Convert.ToInt32(row["MaThe"]),
                    MaDocGia = row["MaDocGia"] == DBNull.Value ? 0 : Convert.ToInt32(row["MaDocGia"]),
                    NgayCap = row["NgayCap"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["NgayCap"]),
                    NgayHetHan = row["NgayHetHan"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["NgayHetHan"]),
                    TrangThai = row["TrangThai"]?.ToString() ?? string.Empty,
                    QRCode = row["QRCode"]?.ToString() ?? string.Empty
                });
            }
            return list;
        }

        public static bool AddLibraryCard(LibraryCardDTO card)
        {
            string query = "INSERT INTO TheThuVien (MaDocGia, NgayCap, NgayHetHan, TrangThai) " +
                           "VALUES (@MaDocGia, @NgayCap, @NgayHetHan, @TrangThai)";
            int result = DataProvider.Instance.ExecuteNonQuery(query, 
                new MySqlParameter("@MaDocGia", card.MaDocGia),
                new MySqlParameter("@NgayCap", card.NgayCap),
                new MySqlParameter("@NgayHetHan", card.NgayHetHan),
                new MySqlParameter("@TrangThai", card.TrangThai));

            int newID = Convert.ToInt32(DataProvider.Instance.ExecuteScalar("SELECT LAST_INSERT_ID()"));
            string qr = $"QR{newID:000}_" + Guid.NewGuid().ToString();
            DataProvider.Instance.ExecuteNonQuery("UPDATE TheThuVien SET QRCode = @QRCode WHERE MaThe = @MaThe",
                new MySqlParameter("@QRCode", qr),
                new MySqlParameter("@MaThe", newID));
            return result > 0;
        }

        public static bool UpdateLibraryCard(LibraryCardDTO card)
        {
            string query = "UPDATE TheThuVien SET MaDocGia = @MaDocGia, NgayCap = @NgayCap, " +
                           "NgayHetHan = @NgayHetHan, TrangThai = @TrangThai " +
                           "WHERE MaThe = @MaThe";
            int result = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@MaDocGia", card.MaDocGia),
                new MySqlParameter("@NgayCap", card.NgayCap),
                new MySqlParameter("@NgayHetHan", card.NgayHetHan),
                new MySqlParameter("@TrangThai", card.TrangThai),
                new MySqlParameter("@MaThe", card.MaThe));
            return result > 0;
        }

        public static bool DeleteLibraryCard(int cardId)
        {
            string query = "DELETE FROM TheThuVien WHERE MaThe = @MaThe";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new MySqlParameter("@MaThe", cardId));
            return result > 0;
        }
    }
}
