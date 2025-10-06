namespace LibraryManagement.DTO
{
    public class BookDTO
    {
        public int MaSach { get; set; }
        public string TieuDe { get; set; }
        public string ISBN { get; set; }
        public int NamXuatBan { get; set; }
        public decimal GiaSach { get; set; }
        public int SoLuongTong { get; set; }
        public int SoLuongCon { get; set; }
        public int MaNXB { get; set; }
        public int MaTheLoai { get; set; }

        public BookDTO() { }

        public BookDTO(int maSach, string tieuDe, string isbn, int namXuatBan,
                       decimal giaSach, int soLuongTong, int soLuongCon,
                       int maNXB, int maTheLoai)
        {
            MaSach = maSach;
            TieuDe = tieuDe;
            ISBN = isbn;
            NamXuatBan = namXuatBan;
            GiaSach = giaSach;
            SoLuongTong = soLuongTong;
            SoLuongCon = soLuongCon;
            MaNXB = maNXB;
            MaTheLoai = maTheLoai;
        }
    }
}
