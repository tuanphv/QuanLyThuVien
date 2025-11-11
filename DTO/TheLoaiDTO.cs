using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TheLoaiDTO
    {
        public int ID { get; set; }
        public string MaTheLoai { get; set; }
        public string TenTheLoai { get; set; }

        // Constructor để GetAll() trong DAO sử dụng
        public TheLoaiDTO()
        {
            ID = 0;
            MaTheLoai = string.Empty;
            TenTheLoai = string.Empty;
        }
        public TheLoaiDTO(int id, string maTheLoai, string tenTheLoai)
        {
            ID = id;
            MaTheLoai = maTheLoai;
            TenTheLoai = tenTheLoai;
        }

        // Constructor để BUS sử dụng khi Thêm/Sửa
        public TheLoaiDTO(string tenTheLoai, string maTheLoai = "")
        {
            TenTheLoai = tenTheLoai;
            MaTheLoai = maTheLoai;
        }
    }
}