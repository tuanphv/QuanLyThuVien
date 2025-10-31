using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TuaSachDTO
    {
        public int Id { get; set; } = 0;
        public string MaTuaSach { get; set; } = string.Empty;
        public string TenTuaSach { get; set; } = string.Empty;
        public byte[]? AnhBia { get; set; } = null;
        public string TheLoai { get; set; } = string.Empty;
        public string TacGia { get; set; } = string.Empty;

        public TuaSachDTO(int id, string maTuaSach, string tenTuaSach, byte[]? anh, string theLoai, string tacGia)
        {
            Id = id;
            MaTuaSach = maTuaSach;
            TenTuaSach = tenTuaSach;
            AnhBia = anh;
            TheLoai = theLoai;
            TacGia = tacGia;
        }
    }
}
