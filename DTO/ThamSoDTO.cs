namespace DTO
{
    public class ThamSoDTO
    {
        // Các quy định trong bảng THAMSO
        public int TuoiToiThieu { get; set; }
        public int TuoiToiDa { get; set; }
        public int ThoiHanThe { get; set; }
        public int KhoangCachXuatBan { get; set; } 
        public int SoSachMuonToiDa { get; set; }
        public int SoNgayMuonToiDa { get; set; }
        public int DonGiaPhatMoiNgay { get; set; }

        public ThamSoDTO(int tuoiMin, int tuoiMax, int thoiHan, int khoangCachXB, int soSachMax, int ngayMax, int tienPhat)
        {
            TuoiToiThieu = tuoiMin;
            TuoiToiDa = tuoiMax;
            ThoiHanThe = thoiHan;
            KhoangCachXuatBan = khoangCachXB;
            SoSachMuonToiDa = soSachMax;
            SoNgayMuonToiDa = ngayMax;
            DonGiaPhatMoiNgay = tienPhat;
        }
    }
}
