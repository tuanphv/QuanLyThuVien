namespace DTO
{
    public class CuonSachDTO
    {
        public int ID { get; set; }
        public string MaCuonSach { get; set; } = string.Empty;
        public int IDSach { get; set; }

        // 0: Đang mượn, 1: Sẵn sàng, 2: Hỏng/Mất
        public int TrangThai { get; set; }


        // Property hiển thị text cho người dùng dễ hiểu
        public string TenTrangThai
        {
            get
            {
                if (TrangThai == 0) return "Đang mượn";
                if (TrangThai == 1) return "Sẵn sàng";
                if (TrangThai == 2) return "Hỏng/Mất";
                return "Không khả dụng";
            }
        }

        public CuonSachDTO() { }

        public CuonSachDTO(int id, string maCuonSach, int idSach, int trangThai)
        {
            ID = id;
            MaCuonSach = maCuonSach;
            IDSach = idSach;
            TrangThai = trangThai;
        }
    }
}