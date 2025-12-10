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

    // DTO m?i cho báo cáo n? quá h?n theo ??c gi?
    public class BaoCaoNoDocGiaDTO
    {
        public string MaDocGia { get; set; }
        public string HoTen { get; set; }
        public int NoHienTai { get; set; }  // S? ti?n ph?t ?ã ghi nh?n
        public int SoSachQuaHan { get; set; }  // S? b?n sao sách quá h?n ch?a tr?
        public int TongNoUocTinh { get; set; }  // N? hi?n t?i + ti?n ph?t d? ki?n

        public BaoCaoNoDocGiaDTO() { }

        public BaoCaoNoDocGiaDTO(string maDocGia, string hoTen, int noHienTai, 
            int soSachQuaHan, int tongNoUocTinh)
        {
            MaDocGia = maDocGia;
            HoTen = hoTen;
            NoHienTai = noHienTai;
            SoSachQuaHan = soSachQuaHan;
            TongNoUocTinh = tongNoUocTinh;
        }
    }

    // DTO cho chi ti?t sách quá h?n c?a m?t ??c gi?
    public class ChiTietSachQuaHanDTO
    {
        public string MaCuonSach { get; set; }
        public string TenSach { get; set; }
        public string MaPhieuMuon { get; set; }
        public DateTime NgayTraDuKien { get; set; }
        public int SoNgayQuaHan { get; set; }
        public int TienPhatUocTinh { get; set; }

        public ChiTietSachQuaHanDTO() { }

        public ChiTietSachQuaHanDTO(string maCuonSach, string tenSach, string maPhieuMuon,
            DateTime ngayTraDuKien, int soNgayQuaHan, int tienPhatUocTinh)
        {
            MaCuonSach = maCuonSach;
            TenSach = tenSach;
            MaPhieuMuon = maPhieuMuon;
            NgayTraDuKien = ngayTraDuKien;
            SoNgayQuaHan = soNgayQuaHan;
            TienPhatUocTinh = tienPhatUocTinh;
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

    /// <summary>
    /// DTO cho th?ng kê tình tr?ng sách (t?ng h?p theo t?a sách)
    /// </summary>
    public class ThongKeSachDTO
    {
        public int IDTuaSach { get; set; }
        public string TenSach { get; set; }
        public int TongSoLuong { get; set; }
        public int DangMuon { get; set; }
        public int ConLai { get; set; }
        public double TyLeMuon { get; set; }

        public ThongKeSachDTO() { }

        public ThongKeSachDTO(int idTuaSach, string tenSach, int tongSoLuong, 
            int dangMuon, int conLai, double tyLeMuon)
        {
            IDTuaSach = idTuaSach;
            TenSach = tenSach;
            TongSoLuong = tongSoLuong;
            DangMuon = dangMuon;
            ConLai = conLai;
            TyLeMuon = tyLeMuon;
        }
    }

    /// <summary>
    /// DTO cho th?ng kê m??n/tr? theo ngày
    /// </summary>
    public class ThongKeMuonTraTheoNgayDTO
    {
        public DateTime Ngay { get; set; }
        public int SoPhieuMuon { get; set; }
        public int TongSachMuon { get; set; }
        public int SoPhieuDaTra { get; set; }
        public int SoPhieuChuaTra { get; set; }

        public ThongKeMuonTraTheoNgayDTO() { }

        public ThongKeMuonTraTheoNgayDTO(DateTime ngay, int soPhieuMuon, 
            int tongSachMuon, int soPhieuDaTra, int soPhieuChuaTra)
        {
            Ngay = ngay;
            SoPhieuMuon = soPhieuMuon;
            TongSachMuon = tongSachMuon;
            SoPhieuDaTra = soPhieuDaTra;
            SoPhieuChuaTra = soPhieuChuaTra;
        }
    }
}
