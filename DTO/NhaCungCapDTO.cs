using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaCungCapDTO
    {
        public int ID { get; set; }
        public string TenNCC { get; set; }
        public string? DiaChi { get; set; } // DiaChi có thể NULL

        // Constructor để DAO (GetAll) sử dụng
        public NhaCungCapDTO(int id, string tenNCC, string? diaChi)
        {
            ID = id;
            TenNCC = tenNCC;
            DiaChi = diaChi;
        }

        // Constructor để BUS (Add/Update) sử dụng
        public NhaCungCapDTO(string tenNCC, string? diaChi, int id = 0)
        {
            ID = id;
            TenNCC = tenNCC;
            DiaChi = diaChi;
        }
    }
}
