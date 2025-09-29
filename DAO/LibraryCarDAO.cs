using DTO;

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
                    MaThe = row["MaThe"] == DBNull.Value ? 0 : Convert.ToInt32(row["MaDocGia"]),
                    MaDocGia = row["MaDocGia"] == DBNull.Value ? 0 : Convert.ToInt32(row["MaDocGia"]),
                    NgayCap = row["NgayCap"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["NgayCap"]),
                    NgayHetHan = row["NgayHetHan"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["NgayHetHan"]),
                    TrangThai = row["TrangThai"]?.ToString() ?? string.Empty,
                    QRCode = row["QRCode"]?.ToString() ?? string.Empty
                });
            }
            return list;
        }
    }
}
