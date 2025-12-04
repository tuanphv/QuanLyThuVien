using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuThuDTO
    {
        public int ID { get; set; }
        public string MaPhieuThu { get; set; } = string.Empty;
        public int IDDocGia { get; set; }
        public string TenDocGia { get; set; }
        public int SoTienThu { get; set; }
        public DateTime NgayLapPhieu { get; set; }

        public PhieuThuDTO()
        {
            ID = 0;
            MaPhieuThu = string.Empty;
            IDDocGia = 0;
            TenDocGia = string.Empty;
            SoTienThu = 0;
            NgayLapPhieu = DateTime.Now;
        }

        public PhieuThuDTO(int id, string maPhieuThu, int idDocGia, string tenDocGia, int soTienThu, DateTime ngayLapPhieu)
        {
            ID = id;
            MaPhieuThu = maPhieuThu;
            IDDocGia = idDocGia;
            TenDocGia = tenDocGia;
            SoTienThu = soTienThu;
            NgayLapPhieu = ngayLapPhieu;
        }
    }
}
