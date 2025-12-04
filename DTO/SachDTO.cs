namespace DTO
{
    public class SachDTO
    {
        public int ID { get; set; }
        public string MaSach { get; set; } = string.Empty;
        public int IDTuaSach { get; set; }
        public string TenTuaSach { get; set; } = string.Empty;
        public int SoLuongTong { get; set; }
        public int SoLuongConLai { get; set; }
        public int DonGia { get; set; }
        public int NamXB { get; set; }
        public int IDNhaXuatBan { get; set; }
        public string TenNhaXuatBan { get; set; } = string.Empty;

        public SachDTO() { }

        public SachDTO(int id, string maSach, int idTuaSach, string tenTuaSach, int soLuongTong, int soLuongConLai, int donGia, int namXB, int idNhaXuatBan, string tenNhaXuatBan)
        {
            ID = id;
            MaSach = maSach;
            IDTuaSach = idTuaSach;
            TenTuaSach = tenTuaSach;
            SoLuongTong = soLuongTong;
            SoLuongConLai = soLuongConLai;
            DonGia = donGia;
            NamXB = namXB;
            IDNhaXuatBan = idNhaXuatBan;
            TenNhaXuatBan = tenNhaXuatBan;
        }
    }

    public class LoSach
    {
        public int ID { get; set; }
        public int IDTuaSach { get; set; }
        public string NXB { get; set; }
        public int NamXB { get; set; }
        public decimal DonGia { get; set; }
    }

    public class CuonSach
    {
        public int ID { get; set; }
        public int IDLoSach { get; set; }
        public string TinhTrang { get; set; } // "SanSang", "DangMuon", "Hong"
    }
}
