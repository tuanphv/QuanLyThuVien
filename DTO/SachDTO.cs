namespace DTO
{
    public class SachDTO
    {
        public int ID { get; set; }
        public string MaSach { get; set; }

        public int IDTuaSach { get; set; }
        public string TenTuaSach { get; set; } // Thêm để hiển thị tên thay vì số

        public int SoLuongTong { get; set; }
        public int SoLuongConLai { get; set; }
        public int DonGia { get; set; }
        public int NamXB { get; set; }

        public int IDNhaXuatBan { get; set; }
        public string TenNXB { get; set; } // Thêm để hiển thị tên thay vì số

        public string TinhTrangHang { get; set; } 

        public SachDTO(int id, string maSach, int idTuaSach, string tenTuaSach, int slTong, int slCon, int donGia, int namXB, int idNXB, string tenNXB)
        {
            ID = id;
            MaSach = maSach;
            IDTuaSach = idTuaSach;
            TenTuaSach = tenTuaSach;
            SoLuongTong = slTong;
            SoLuongConLai = slCon;
            DonGia = donGia;
            NamXB = namXB;
            IDNhaXuatBan = idNXB;
            TenNXB = tenNXB;
            TinhTrangHang = slCon > 0 ? "Còn hàng" : "Hết hàng";
        }

        // Constructor rỗng cho việc thêm mới
        public SachDTO() { }
    }
}
