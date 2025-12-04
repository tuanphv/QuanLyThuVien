namespace DTO
{
    public class CT_PhieuNhapDTO
    {
        public int IDPhieuNhap { get; set; }
        public int IDSach { get; set; }
        public string MaSach { get; set; } = string.Empty;
        public string TenTuaSach { get; set; } = string.Empty;
        public int SoLuongNhap { get; set; }
        public int DonGiaNhap { get; set; }
        public int ThanhTien { get; set; }

        public CT_PhieuNhapDTO() { }

        public CT_PhieuNhapDTO(int idPhieuNhap, int idSach, string maSach, string tenTuaSach, int soLuongNhap, int donGiaNhap, int thanhTien)
        {
            IDPhieuNhap = idPhieuNhap;
            IDSach = idSach;
            MaSach = maSach;
            TenTuaSach = tenTuaSach;
            SoLuongNhap = soLuongNhap;
            DonGiaNhap = donGiaNhap;
            ThanhTien = thanhTien;
        }
    }
}
