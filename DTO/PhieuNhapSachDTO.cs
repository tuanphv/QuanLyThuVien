using System;

namespace DTO
{
    public class PhieuNhapSachDTO
    {
        public int ID { get; set; }
        public string MaPhieuNhap { get; set; } = string.Empty;
        public int IDNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; } = string.Empty;
        public DateTime NgayNhap { get; set; }
        public int TongTien { get; set; }

        public PhieuNhapSachDTO() { }

        public PhieuNhapSachDTO(int id, string maPhieuNhap, int idNhaCungCap, string tenNhaCungCap, DateTime ngayNhap, int tongTien)
        {
            ID = id;
            MaPhieuNhap = maPhieuNhap;
            IDNhaCungCap = idNhaCungCap;
            TenNhaCungCap = tenNhaCungCap;
            NgayNhap = ngayNhap;
            TongTien = tongTien;
        }
    }
}
