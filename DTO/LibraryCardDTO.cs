namespace DTO
{
    public class LibraryCardDTO
    {
        public int MaThe { get; set; }
        public int MaDocGia { get; set; }
        public DateTime NgayCap { get; set; }
        public DateTime NgayHetHan { get; set; }
        public string TrangThai { get; set; }
        public string QRCode { get; set; }

        public LibraryCardDTO() {
            MaThe = 0;
            MaDocGia = 0;
            NgayCap = DateTime.Now;
            NgayHetHan = DateTime.Now.AddYears(1);
            TrangThai = string.Empty;
            QRCode = string.Empty;
        }

        public LibraryCardDTO(int maThe, int maDocGia, DateTime ngayCap, DateTime ngayHetHan, string trangThai, string qr)
        {
            MaThe = maThe;
            MaDocGia = maDocGia;
            NgayCap = ngayCap;
            NgayHetHan = ngayHetHan;
            TrangThai = trangThai;
            QRCode = qr;
        }
    }
}
