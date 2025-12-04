namespace DTO
{
    public class CuonSachDTO
    {
        public int ID { get; set; }
        public string MaCuonSach { get; set; }
        public int IDSach { get; set; }
        public int TinhTrang { get; set; } // 0: Đang mượn, 1: Sẵn sàng, 2: Ẩn

        // Property hiển thị text cho người dùng dễ hiểu
        public string TenTinhTrang
        {
            get
            {
                if (TinhTrang == 0) return "Đang mượn";
                if (TinhTrang == 1) return "Sẵn sàng";
                return "Không khả dụng";
            }
        }

        public CuonSachDTO(int id, string maCuonSach, int idSach, int tinhTrang)
        {
            ID = id;
            MaCuonSach = maCuonSach;
            IDSach = idSach;
            TinhTrang = tinhTrang;
        }
    }
}