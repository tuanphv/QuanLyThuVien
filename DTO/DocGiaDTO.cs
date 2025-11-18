using System;

namespace DTO
{
    public class DocGiaDTO
    {
        public int ID { get; set; }
        public string MaDocGia { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayLapThe { get; set; }
        public DateTime NgayHetHan { get; set; }
        public int TongNoHienTai { get; set; }
        public int? IDNguoiDung { get; set; }
        public string TenDangNhap { get; set; } 

  
        public DocGiaDTO()
        {
            ID = 0;
            MaDocGia = string.Empty;
            HoTen = string.Empty;
            NgaySinh = DateTime.Now;
            DiaChi = string.Empty;
            NgayLapThe = DateTime.Now;
            NgayHetHan = DateTime.Now;
            TongNoHienTai = 0;
            IDNguoiDung = null;
            TenDangNhap = string.Empty;
        }

 
        public DocGiaDTO(int id, string maDocGia, string hoTen, DateTime ngaySinh,
            string diaChi, DateTime ngayLapThe, DateTime ngayHetHan, 
            int tongNoHienTai, int? idNguoiDung = null, string tenDangNhap = "")
        {
            ID = id;
            MaDocGia = maDocGia;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            NgayLapThe = ngayLapThe;
            NgayHetHan = ngayHetHan;
            TongNoHienTai = tongNoHienTai;
            IDNguoiDung = idNguoiDung;
            TenDangNhap = tenDangNhap;
        }


        public DocGiaDTO(string hoTen, DateTime ngaySinh, string diaChi,
            DateTime ngayLapThe, DateTime ngayHetHan, int? idNguoiDung = null,
            string maDocGia = "")
        {
            MaDocGia = maDocGia;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            NgayLapThe = ngayLapThe;
            NgayHetHan = ngayHetHan;
            TongNoHienTai = 0;
            IDNguoiDung = idNguoiDung;
        }
    }
}
