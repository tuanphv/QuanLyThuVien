using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ReaderDTO
    {
        public int MaDocGia { get; set; }
        public string TenDangNhap { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime NgayDangKy { get; set; }

        public ReaderDTO()
        {
            MaDocGia = 0;
            TenDangNhap = string.Empty;
            HoTen = string.Empty;
            NgaySinh = DateTime.MinValue;
            GioiTinh = string.Empty;
            DiaChi = string.Empty;
            Email = string.Empty;
            SoDienThoai = string.Empty;
            NgayDangKy = DateTime.MinValue;
        }

        public ReaderDTO(int maDocGia, string tenDangNhap, string hoTen, DateTime ngaySinh, string gioiTinh, string diaChi, string email, string soDienThoai, DateTime ngayDangKy)
        {
            MaDocGia = maDocGia;
            TenDangNhap = tenDangNhap;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            DiaChi = diaChi;
            Email = email;
            SoDienThoai = soDienThoai;
            NgayDangKy = ngayDangKy;
        }
    }
}
