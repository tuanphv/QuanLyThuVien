using DTO;
using System.Data;

namespace DAO
{
    public class EmployeeDAO
    {
        public static List<EmployeeDTO> GetAllEmployees()
        {
            List<EmployeeDTO> list = new List<EmployeeDTO>();

            string query = "SELECT * FROM NhanVien";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new EmployeeDTO
                {
                    MaNhanVien = Convert.ToInt32(row["MaNhanVien"]),
                    HoTen = row["HoTen"]?.ToString() ?? String.Empty,
                    NgaySinh = row["NgaySinh"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["NgaySinh"]),
                    GioiTinh = row["GioiTinh"]?.ToString() ?? String.Empty,
                    DiaChi = row["DiaChi"]?.ToString() ?? String.Empty,
                    SoDienThoai = row["SoDienThoai"]?.ToString() ?? String.Empty,
                    ChucVu = String.Empty, // ChucVu đã bị comment trong database schema
                    NgayVaoLam = row["NgayVaoLam"] == DBNull.Value ? String.Empty : Convert.ToDateTime(row["NgayVaoLam"]).ToString("dd/MM/yyyy")
                });
            }

            return list;
        }
    }
}
