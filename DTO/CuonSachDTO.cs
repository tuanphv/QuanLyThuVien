namespace DTO
{
    public class CuonSachDTO
    {
        public int ID { get; set; }
        public string MaCuonSach { get; set; } = string.Empty;
        public int IDSach { get; set; }

        // 0: Đang mượn, 1: Sẵn sàng, 2: Hỏng/Mất
        public int TinhTrang { get; set; }

        public string? ChiTietTinhTrang { get; set; }

        // Property hiển thị text cho người dùng dễ hiểu
        public string TenTinhTrang
        {
            get
            {
                if (TinhTrang == 0) return "Đang mượn";
                if (TinhTrang == 1) return "Sẵn sàng";
                if (TinhTrang == 2) return "Hỏng/Mất";
                return "Không khả dụng";
            }
        }

        public CuonSachDTO() { }

        public CuonSachDTO(int id, string maCuonSach, int idSach, int tinhTrang, string? chiTietTinhTrang)
        {
            ID = id;
            MaCuonSach = maCuonSach;
            IDSach = idSach;
            TinhTrang = tinhTrang;
            ChiTietTinhTrang = chiTietTinhTrang;
        }
    }
}