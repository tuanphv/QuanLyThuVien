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
        public int NamSinh { get; set; } 

        public TacGiaDTO()
        {
            ID = 0;
            MaTacGia = string.Empty;
            TenTacGia = string.Empty;
            NamSinh = 0; 
        }

        // Constructor đầy đủ để GetAll() trong DAO sử dụng
        public TacGiaDTO(int id, string maTacGia, string tenTacGia, int namSinh)
        {
            ID = id;
            MaTacGia = maTacGia;
            TenTacGia = tenTacGia;
            NamSinh = namSinh;
        }

        // Constructor rút gọn để BUS sử dụng khi Thêm/Sửa
        public TacGiaDTO(string tenTacGia, int namSinh, string maTacGia = "")
        {
            TenTacGia = tenTacGia;
            NamSinh = namSinh;
            MaTacGia = maTacGia;
        }
    }
}