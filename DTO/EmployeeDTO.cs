namespace DTO
{
    public class EmployeeDTO
    {
        public int MaNhanVien { get; set; }
        public string HoTen { get; set; }

        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string ChucVu { get; set; }
        public string NgayVaoLam { get; set; }

        public EmployeeDTO()
        {
            MaNhanVien = 0;
            HoTen = string.Empty;
            NgaySinh = DateTime.MinValue;
            GioiTinh = string.Empty;
            DiaChi = string.Empty;
            SoDienThoai = string.Empty;
            ChucVu = string.Empty;
            NgayVaoLam = string.Empty;
        }

        public EmployeeDTO(int maNhanVien, string hoTen, DateTime ngaySinh, string gioiTinh, string diaChi, string soDienThoai, string chucVu, string ngayVaoLam)
        {
            MaNhanVien = maNhanVien;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
            ChucVu = chucVu;
            NgayVaoLam = ngayVaoLam;
        }
    }
}
