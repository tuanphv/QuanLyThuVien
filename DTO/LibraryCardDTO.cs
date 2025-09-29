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

        public LibraryCardDTO() { }

        public LibraryCardDTO(int maThe, int maDocGia, DateTime ngayCap, DateTime ngayHetHan, string trangThai, string qrCode)
        {
            MaThe = maThe;
            MaDocGia = maDocGia;
            NgayCap = ngayCap;
            NgayHetHan = ngayHetHan;
            TrangThai = trangThai;
            QRCode = qrCode;
        }

    }
}
