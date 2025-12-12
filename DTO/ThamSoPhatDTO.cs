namespace DTO
{
    public class ThamSoPhatDTO
    {
        public int ID { get; set; }
        public string MaQuyDinh { get; set; } = string.Empty;
        public string TenQuyDinh { get; set; } = string.Empty;
        public int MucPhatPhanTram { get; set; }
        public string? GhiChu { get; set; }

        // Trường mới để phân nhóm logic (Quan trọng)
        public string? NhomTinhTrang { get; set; }

        public bool CoLaDuyNhat { get; set; }
        public bool CoLaMacDinh { get; set; }
        public bool CoLaHuHong { get; set; }

        public string TenHienThi => MucPhatPhanTram > 0
            ? $"{TenQuyDinh} (Phạt {MucPhatPhanTram}%)"
            : TenQuyDinh;

        // Giữ lại property cũ để tương thích (nếu code cũ có dùng)
        public string LoaiTinhTrang => TenQuyDinh;
        public int MucPhat => MucPhatPhanTram;
    }
}