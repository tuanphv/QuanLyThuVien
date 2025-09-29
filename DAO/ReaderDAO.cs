using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                (
                    Convert.ToInt32(row["MaDocGia"]),
                    string.Empty, // TenDangNhap không còn trong bảng DocGia
                    row["HoTen"]?.ToString() ?? String.Empty,
                    row["NgaySinh"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["NgaySinh"]),
                    row["GioiTinh"]?.ToString() ?? String.Empty,
                    row["DiaChi"]?.ToString() ?? String.Empty,
                    row["Email"]?.ToString() ?? String.Empty,
                    row["SoDienThoai"]?.ToString() ?? String.Empty,
                    row["NgayDangKy"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(row["NgayDangKy"])
                ));
            }
            return list;
        }
    }
}
