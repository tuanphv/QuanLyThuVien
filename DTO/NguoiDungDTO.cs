using System;

namespace DTO
{
    public class NguoiDungDTO
    {
        public int ID { get; set; }
        public string MaNguoiDung { get; set; }
        public string TenNguoiDung { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string ChucVu { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public int IDNhomNguoiDung { get; set; }
        public string TenNhomNguoiDung { get; set; }


        public NguoiDungDTO()
        {
            ID = 0;
            MaNguoiDung = string.Empty;
            TenNguoiDung = string.Empty;
            NgaySinh = null;
            ChucVu = string.Empty;
            TenDangNhap = string.Empty;
            MatKhau = string.Empty;
            IDNhomNguoiDung = 0;
            TenNhomNguoiDung = string.Empty;
        }

        public NguoiDungDTO(int id, string maNguoiDung, string tenNguoiDung, 
            DateTime? ngaySinh, string chucVu, string tenDangNhap, 
            string matKhau, int idNhomNguoiDung, string tenNhomNguoiDung = "")
        {
            ID = id;
            MaNguoiDung = maNguoiDung;
            TenNguoiDung = tenNguoiDung;
            NgaySinh = ngaySinh;
            ChucVu = chucVu;
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            IDNhomNguoiDung = idNhomNguoiDung;
            TenNhomNguoiDung = tenNhomNguoiDung;
        }

 
        public NguoiDungDTO(string tenNguoiDung, DateTime? ngaySinh, 
            string chucVu, string tenDangNhap, string matKhau, 
            int idNhomNguoiDung, string maNguoiDung = "")
        {
            MaNguoiDung = maNguoiDung;
            TenNguoiDung = tenNguoiDung;
            NgaySinh = ngaySinh;
            ChucVu = chucVu;
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            IDNhomNguoiDung = idNhomNguoiDung;
        }
    }
}
