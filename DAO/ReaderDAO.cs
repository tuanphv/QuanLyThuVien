using DTO;

namespace DAO
{
    public class ReaderDAO
    {
        public static List<ReaderDTO> GetAllReaders()
        {
            List<ReaderDTO> list = new List<ReaderDTO>();
            string query = "SELECT * FROM DocGia";
            System.Data.DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (System.Data.DataRow row in dt.Rows)
            {
                list.Add(new ReaderDTO
                {
                    MaDocGia = Convert.ToInt32(row["MaDocGia"]),
                    HoTen = row["HoTen"]?.ToString() ?? String.Empty,
                    NgaySinh = row["NgaySinh"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["NgaySinh"]),
                    GioiTinh = row["GioiTinh"]?.ToString() ?? String.Empty,
                    DiaChi = row["DiaChi"]?.ToString() ?? String.Empty,
                    Email = row["Email"]?.ToString() ?? String.Empty,
                    SoDienThoai = row["SoDienThoai"]?.ToString() ?? String.Empty,
                    NgayDangKy = row["NgayDangKy"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(row["NgayDangKy"])
                });
            }
            return list;
        }
    }
}
