namespace DTO
{
    /// <summary>
    /// Quy định xử phạt cho từng tình trạng sách.
    /// </summary>
    public class ThamSoPhatDTO
    {
        public int ID { get; set; }
        public string MaQuyDinh { get; set; } = string.Empty;
        public string LoaiTinhTrang { get; set; } = string.Empty;
        public string? MucDo { get; set; }
        public int TienPhat { get; set; }
        public string? GhiChu { get; set; }

        public string TenHienThi => string.IsNullOrWhiteSpace(MucDo)
            ? LoaiTinhTrang
            : $"{LoaiTinhTrang} - {MucDo}";
    }
}
