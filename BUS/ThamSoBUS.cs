using DAO;
using DTO;

namespace BUS
{
    public class ThamSoBUS
    {
        // Lấy toàn bộ tham số
        public static ThamSoDTO GetQuyDinh()
        {
            return ThamSoDAO.GetThamSo();
        }

        // Kiểm tra năm xuất bản có hợp lệ không
        public static bool KiemTraNamXuatBan(int namXB)
        {
            ThamSoDTO quyDinh = GetQuyDinh();
            if (quyDinh == null) return true; // Nếu chưa có quy định thì cho qua

            int namHienTai = DateTime.Now.Year;

            // Quy định: Chỉ nhận sách xuất bản trong vòng X năm trở lại đây
            // Ví dụ: KhoangCachXuatBan = 8, Năm nay 2025 -> Chỉ nhận sách >= 2017
            if ((namHienTai - namXB) > quyDinh.KhoangCachXuatBan)
            {
                return false;
            }
            return true;
        }
    }
}