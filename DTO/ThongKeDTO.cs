namespace DTO
{
    public class ThongKeDTO
    {
        public int TongSach { get; set; }
        public int SachDangMuon { get; set; }
        public int TongDocGia { get; set; }
        public int TongNo { get; set; }
    }

    public class SachMuonNhieuDTO
    {
        public string TenSach { get; set; }
        public int SoLuotMuon { get; set; }

        public SachMuonNhieuDTO(string tenSach, int soLuotMuon)
        {
            TenSach = tenSach;
            SoLuotMuon = soLuotMuon;
        }
    }

    public class DocGiaTichCucDTO
    {
        public string HoTen { get; set; }
        public int SoLuotMuon { get; set; }

        public DocGiaTichCucDTO(string hoTen, int soLuotMuon)
        {
            HoTen = hoTen;
            SoLuotMuon = soLuotMuon;
        }
    }

    public class ThongKeMuonTheoThangDTO
    {
        public int Thang { get; set; }
        public int SoLuotMuon { get; set; }

        public ThongKeMuonTheoThangDTO(int thang, int soLuotMuon)
        {
            Thang = thang;
            SoLuotMuon = soLuotMuon;
        }
    }

    public class ThongKeMuonTheoQuyDTO
    {
        public int Quy { get; set; }
        public int SoLuotMuon { get; set; }

        public ThongKeMuonTheoQuyDTO(int quy, int soLuotMuon)
        {
            Quy = quy;
            SoLuotMuon = soLuotMuon;
        }
    }
}
