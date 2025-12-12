using System;

namespace DTO
{
    public class PhieuThuDTO
    {
        public int ID { get; set; }
        public string MaPhieuThu { get; set; } = string.Empty;
        public int IDDocGia { get; set; }
        public string TenDocGia { get; set; } = string.Empty;
        public int SoTienThu { get; set; }
        public DateTime NgayLapPhieu { get; set; }

        public PhieuThuDTO()
        {
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

    // DTO đơn giản dùng cho ComboBox lọc
    public class DocGiaSimpleDTO
    {
        public int ID { get; set; }
        public string HoTen { get; set; } = string.Empty;
    }
}