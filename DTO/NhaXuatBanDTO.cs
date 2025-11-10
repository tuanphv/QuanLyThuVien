using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaXuatBanDTO
    {
        public int ID { get; set; }
        public string TenNXB { get; set; }
        public string? DiaChi { get; set; } // DiaChi có thể NULL

        // Constructor để DAO (GetAll) sử dụng
        public NhaXuatBanDTO(int id, string tenNXB, string? diaChi)
        {
            ID = id;
            TenNXB = tenNXB;
            DiaChi = diaChi;
        }

        // Constructor để BUS (Add/Update) sử dụng
        public NhaXuatBanDTO(string tenNXB, string? diaChi, int id = 0)
        {
            ID = id;
            TenNXB = tenNXB;
            DiaChi = diaChi;
        }
    }
}