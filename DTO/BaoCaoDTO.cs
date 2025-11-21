namespace DTO
{

    public class BaoCaoMuonTheoKhoangDTO
    {
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public int TongLuotMuon { get; set; }
        public int TongSachMuon { get; set; }

        public BaoCaoMuonTheoKhoangDTO() { }

        public BaoCaoMuonTheoKhoangDTO(DateTime tuNgay, DateTime denNgay, int tongLuotMuon, int tongSachMuon)
        {
            TuNgay = tuNgay;
            DenNgay = denNgay;
            TongLuotMuon = tongLuotMuon;
            TongSachMuon = tongSachMuon;
        }
    }

    public class BaoCaoQuaHanDTO
    {
        public string MaDocGia { get; set; }
        public string HoTen { get; set; }
        public string MaPhieuMuon { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime NgayTraDuKien { get; set; }
        public int SoNgayQuaHan { get; set; }
        public int TienPhat { get; set; }

        public BaoCaoQuaHanDTO() { }

        public BaoCaoQuaHanDTO(string maDocGia, string hoTen, string maPhieuMuon, 
            DateTime ngayMuon, DateTime ngayTraDuKien, int soNgayQuaHan, int tienPhat)
        {
            MaDocGia = maDocGia;
            HoTen = hoTen;
            MaPhieuMuon = maPhieuMuon;
            NgayMuon = ngayMuon;
            NgayTraDuKien = ngayTraDuKien;
            SoNgayQuaHan = soNgayQuaHan;
            TienPhat = tienPhat;
        }
    }

    public class BaoCaoTopSachDTO
    {
        public int STT { get; set; }
        public string MaTuaSach { get; set; }
        public string TenTuaSach { get; set; }
        public string TheLoai { get; set; }
        public int SoLuotMuon { get; set; }
        public int SoLuongHienCo { get; set; }

        public BaoCaoTopSachDTO() { }

        public BaoCaoTopSachDTO(int stt, string maTuaSach, string tenTuaSach, 
            string theLoai, int soLuotMuon, int soLuongHienCo)
        {
            STT = stt;
            MaTuaSach = maTuaSach;
            TenTuaSach = tenTuaSach;
            TheLoai = theLoai;
            SoLuotMuon = soLuotMuon;
            SoLuongHienCo = soLuongHienCo;
        }
    }

    public class BaoCaoTopDocGiaDTO
    {
        public int STT { get; set; }
        public string MaDocGia { get; set; }
        public string HoTen { get; set; }
        public int SoLuotMuon { get; set; }
        public int TongNo { get; set; }
        public DateTime NgayLapThe { get; set; }

        public BaoCaoTopDocGiaDTO() { }

        public BaoCaoTopDocGiaDTO(int stt, string maDocGia, string hoTen, 
            int soLuotMuon, int tongNo, DateTime ngayLapThe)
        {
            STT = stt;
            MaDocGia = maDocGia;
            HoTen = hoTen;
            SoLuotMuon = soLuotMuon;
            TongNo = tongNo;
            NgayLapThe = ngayLapThe;
        }
    }
}
