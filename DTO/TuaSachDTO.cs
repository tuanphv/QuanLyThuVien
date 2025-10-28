using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TuaSachDTO
    {
        public int Id { get; set; }
        public string MaTuaSach { get; set; }
        public string TenTuaSach { get; set; }
        public byte[]? AnhBia { get; set; }
        public int DaAn { get; set; }
        public TuaSachDTO()
        {
            Id = 0;
            MaTuaSach = string.Empty;
            TenTuaSach = string.Empty;
            AnhBia = null;
            DaAn = 0;
        }
        public TuaSachDTO(int id, string maTuaSach, string tenTuaSach, byte[]? anh, int daAn)
        {
            Id = id;
            MaTuaSach = maTuaSach;
            TenTuaSach = tenTuaSach;
            AnhBia = anh;
            DaAn = daAn;
        }
    }
}
