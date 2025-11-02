using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhomNguoiDungDTO
    {
        public int ID { get; set; }
        public string MaNhom { get; set; }
        public string TenNhom { get; set; }
        public int TongSoNguoi { get; set; }
        
        public NhomNguoiDungDTO() { }

        public NhomNguoiDungDTO(int id, string maNhom, string tenNhom, int tongSoNguoi)
        {
            ID = id;
            MaNhom = maNhom;
            TenNhom = tenNhom;
            TongSoNguoi = tongSoNguoi;
        }
    }
}
