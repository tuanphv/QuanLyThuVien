using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TacGiaDTO
    {
        public int ID { get; set; }
        public string MaTacGia { get; set; }
        public string TenTacGia { get; set; }

        public TacGiaDTO()
        {
            ID = 0;
            MaTacGia = string.Empty;
            TenTacGia = string.Empty;
        }
        // Constructor để GetAll() trong DAO sử dụng
        public TacGiaDTO(int id, string maTacGia, string tenTacGia)
        {
            ID = id;
            MaTacGia = maTacGia;
            TenTacGia = tenTacGia;
        }

        // Constructor để BUS sử dụng khi Thêm/Sửa
        public TacGiaDTO(string tenTacGia, string maTacGia = "")
        {
            TenTacGia = tenTacGia;
            MaTacGia = maTacGia;
        }
    }
}
