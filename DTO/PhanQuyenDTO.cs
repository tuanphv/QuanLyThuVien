namespace DTO
{
    public class PhanQuyenDTO
    {
        public int IDChucNang { get; set; }
        public string TenChucNang { get; set; }
        public bool CoQuyenTruyCap { get; set; }
        public bool CoQuyenThem { get; set; }
        public bool CoQuyenSua { get; set; }
        public bool CoQuyenXoa { get; set; }

        public PhanQuyenDTO()
        {
            IDChucNang = 0;
            TenChucNang = string.Empty;
            CoQuyenTruyCap = false;
            CoQuyenThem = false;
            CoQuyenSua = false;
            CoQuyenXoa = false;
        }

        public PhanQuyenDTO(
            int idChucNang, string tenChucNang,
            bool coQuyenTruyCap, bool coQuyenThem,
            bool coQuyenSua, bool coQuyenXoa)
        {
            IDChucNang = idChucNang;
            TenChucNang = tenChucNang;
            CoQuyenTruyCap = coQuyenTruyCap;
            CoQuyenThem = coQuyenThem;
            CoQuyenSua = coQuyenSua;
            CoQuyenXoa = coQuyenXoa;
        }
    }
}
