using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    HoTen = row["HoTen"].ToString() ?? String.Empty,
                    NgaySinh = Convert.ToDateTime(row["NgaySinh"]),
                    GioiTinh = row["GioiTinh"].ToString() ?? String.Empty,
                    DiaChi = row["DiaChi"].ToString() ?? String.Empty,
                    SoDienThoai = row["SoDienThoai"].ToString() ?? String.Empty,
                    ChucVu = row["ChucVu"].ToString() ?? String.Empty,
                    NgayVaoLam = row["NgayVaoLam"].ToString() ?? String.Empty
                });
            }

            return list;
        }
    }
}
