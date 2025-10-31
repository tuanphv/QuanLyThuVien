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
        public string MaTheLoai { get; set; } = string.Empty;
        public string TenTheLoai { get; set; } = string.Empty;
       
        public TheLoaiDTO() { }

        public TheLoaiDTO(int id, string maTheLoai, string tenTheLoai)
        {
            this.ID = id;
            this.MaTheLoai = maTheLoai;
            this.TenTheLoai = tenTheLoai;
        }
    }
}