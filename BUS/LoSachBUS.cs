// File: SachBUS.cs
using DAO;
using DTO;

namespace QuanLyThuVien.BUS
{
    public class LoSachBUS
    {
        private LoSachDAO loSachDAO = new LoSachDAO();
        private ThamSoDAO thamSoDAO = new ThamSoDAO();

        // 1. Kiểm tra Quy định & Thêm lô sách
        public string ThemLoSach_BUS(int idTuaSach, string nxb, int namXB, decimal donGia)
        {
            // Lấy tham số quy định
            int khoangCachNam = thamSoDAO.LayKhoangCachXuatBan();
            int namHienTai = DateTime.Now.Year;

            // Kiểm tra quy định: Năm XB không được quá cũ so với quy định
            if ((namHienTai - namXB) > khoangCachNam)
            {
                return $"Lỗi: Chỉ nhận sách xuất bản trong vòng {khoangCachNam} năm.";
            }

            if (donGia <= 0) return "Lỗi: Đơn giá phải lớn hơn 0.";

            // Nếu hợp lệ thì gọi DAO
            bool ketQua = loSachDAO.ThemLoSach(idTuaSach, nxb, namXB, donGia);
            return ketQua ? "Thêm lô sách thành công." : "Thêm thất bại.";
        }

        // 2. Logic Tồn kho: Tính số lượng còn lại
        public int TinhSoLuongConLai(int idLoSach)
        {
            // LayCuonSachSanSang returns List<TuaSachDTO>, not List<CuonSach>
            List<TuaSachDTO> dsSanSang = loSachDAO.LayCuonSachSanSang(idLoSach);
            return dsSanSang.Count;
        }

        // 3. Logic Trạng thái: Admin cập nhật tình trạng cuốn sách
        // (Ví dụ: Chuyển từ "Sẵn sàng" sang "Hỏng" hoặc "Mất")
        public string CapNhatTrangThaiCuonSach_Admin(int idCuonSach, string trangThaiMoi)
        {
            // Logic kiểm tra: Admin không được sửa sách đang được mượn thành Sẵn sàng trực tiếp 
            // mà phải thông qua quy trình Trả sách (tùy nghiệp vụ, ở đây demo đơn giản)

            bool result = loSachDAO.CapNhatTrangThaiCuon(idCuonSach, trangThaiMoi);
            return result ? "Cập nhật trạng thái thành công." : "Lỗi cập nhật.";
        }

        // Gọi xuống DAO để lấy chi tiết hiển thị
        public LoSach LayThongTinLoSach(int id) => (LoSach)loSachDAO.LayChiTietLoSach(id);
        public bool SuaThongTinLoSach(int id, string nxb, decimal gia) => loSachDAO.SuaThongTinLoSach(id, nxb, gia);
    }
}