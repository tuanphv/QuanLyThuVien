using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class NhomNguoiDungDAO
    {
        public static BindingList<NhomNguoiDungDTO> GetAllNhomNguoiDung()
        {
            BindingList<NhomNguoiDungDTO> list = new BindingList<NhomNguoiDungDTO>();
            string query = @"
                SELECT NND.*, COUNT(ND.ID) AS TongSoNguoi 
                FROM NhomNguoiDung AS NND
                JOIN NguoiDung AS ND ON ND.IDNhomNguoiDung = NND.ID
                GROUP BY NND.ID
            ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                list.Add(new NhomNguoiDungDTO
                {
                    ID = Convert.ToInt32(row["ID"]),
                    MaNhom = row["MaNhomNguoiDung"].ToString(),
                    TenNhom = row["TenNhomNguoiDung"].ToString(),
                    TongSoNguoi = Convert.ToInt32(row["TongSoNguoi"])
                });
            }
            return list;
        }
    }
}
