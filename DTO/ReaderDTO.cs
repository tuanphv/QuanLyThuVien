using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /// <summary>
    /// DTO for Reader (DocGia)<br/>
    /// - MaDocGia: int        <br/>
    /// - HoTen: string        <br/>
    /// - NgaySinh: DateTime   <br/>
    /// - GioiTinh: string     <br/>
    /// - DiaChi: string       <br/>
    /// - Email: string        <br/>
    /// - SoDienThoai: string  <br/>
    /// - NgayDangKy: DateTime
    /// </summary>
    public class ReaderDTO
    {
        public int MaDocGia { get; set; }
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
            HoTen = string.Empty;
            NgaySinh = DateTime.MinValue;
            GioiTinh = string.Empty;
            DiaChi = string.Empty;
            Email = string.Empty;
            SoDienThoai = string.Empty;
            NgayDangKy = DateTime.MinValue;
        }

        public ReaderDTO(int maDocGia, string hoTen, DateTime ngaySinh, string gioiTinh, string diaChi, string email, string soDienThoai, DateTime ngayDangKy)
        {
            MaDocGia = maDocGia;
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
