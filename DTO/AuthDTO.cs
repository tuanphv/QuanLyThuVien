namespace DTO
{
    public class AuthDTO
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string VaiTro { get; set; }
        public int? MaDocGia { get; set; }
        public int? MaNhanVien { get; set; }
        public string HoTen { get; set; }

        public AuthDTO()
        {
            TenDangNhap = string.Empty;
            MatKhau = string.Empty;
            VaiTro = string.Empty;
            MaDocGia = null;
            MaNhanVien = null;
            HoTen = string.Empty;
        }

        public AuthDTO(string tenDangNhap, string matKhau, string vaiTro, int? maDocGia, int? maNhanVien, string hoTen)
        {
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            VaiTro = vaiTro;
            MaDocGia = maDocGia;
            MaNhanVien = maNhanVien;
            HoTen = hoTen;
        }
    }
}