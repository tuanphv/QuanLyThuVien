using System;

namespace DTO
{
    public class PhieuMuonDTO
    {
        public int ID { get; set; }
        public string MaPhieuMuon { get; set; } = string.Empty;
        public string MaDocGia { get; set; } = string.Empty;
        public string HoTenDocGia { get; set; } = string.Empty;
        public DateTime NgayMuon { get; set; }
        public DateTime NgayTraDuKien { get; set; }
        public DateTime? NgayTraThucTe { get; set; }
        public int TongSach { get; set; }
        public int SoSachChuaTra { get; set; }

        public string TinhTrang
        {
            get
            {
                if (SoSachChuaTra > 0 && DateTime.Today.Date > NgayTraDuKien.Date)
                {
                    return "Quá hạn";
                }
                if (SoSachChuaTra > 0)
                {
                    return "Đang mượn";
                }
                return "Đã trả";
            }
        }

        public string GhiChu => TongSach > 0
            ? $"Còn {SoSachChuaTra}/{TongSach} sách"
            : string.Empty;
    }

    public class ChiTietPhieuMuonDTO
    {
        public int IDPhieuMuon { get; set; }
        public int IDCuonSach { get; set; }
        public string MaCuonSach { get; set; } = string.Empty;
        public string TenSach { get; set; } = string.Empty;
        public DateTime? NgayTraThucTe { get; set; }
        public DateTime NgayTraDuKien { get; set; }
    }

    public class ThamSoMuonTraDTO
    {
        public int SoSachMuonToiDa { get; set; }
        public int SoNgayMuonToiDa { get; set; }
        public int DonGiaPhatMoiNgay { get; set; }
        public int TuoiToiThieu { get; set; }
        public int TuoiToiDa { get; set; }
    }

    public class DocGiaMuonInfoDTO
    {
        public int ID { get; set; }
        public string MaDocGia { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public DateTime NgaySinh { get; set; }
        public DateTime NgayHetHan { get; set; }
        public int TongNoHienTai { get; set; }
    }
}
