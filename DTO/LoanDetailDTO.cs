namespace DTO
{
    public class LoanDetailDTO
    {
        public int MaPhieuMuon { get; set; }
        public int MaSach { get; set; }
        public int SoLuong { get; set; }

        public LoanDetailDTO() { }

        public LoanDetailDTO(int maPhieuMuon, int maSach, int soLuong)
        {
            MaPhieuMuon = maPhieuMuon;
            MaSach = maSach;
            SoLuong = soLuong;
        }
    }
}
