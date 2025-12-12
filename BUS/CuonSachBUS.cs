using DAO;
using DTO;
using System.ComponentModel;

namespace BUS
{
    public class CuonSachBUS
    {
        // Lấy danh sách cuốn sách thuộc về 1 lô sách (Dùng cho form Quản lý Sách)
        public static BindingList<CuonSachDTO> GetByIDSach(int idSach)
        {
            return CuonSachDAO.GetByIDSach(idSach);
        }

        // Cập nhật tình trạng sách (Dùng khi kiểm kê hoặc sửa lỗi trong kho)
        // idTinhTrangMoi chính là ID trong bảng THAMSOPHAT (VD: 2 là Bẩn, 7 là Mất)
        public static bool CapNhatTinhTrang(int idCuonSach, int idTinhTrangMoi)
        {
            // Gọi DAL thực thi Procedure SP_ThemTinhTrang
            // Procedure này sẽ tự động xóa lỗi cũ nếu xung đột (Logic thông minh của DB)
            return CuonSachDAO.CallSP_ThemTinhTrang(idCuonSach, idTinhTrangMoi);
        }

        public static string KiemTraMaCuonSach(int idSach, int maDau, int maCuoi)
        {
            for (int i = maDau; i <= maCuoi; i++)
            {
                string maCuonSach = $"S{ idSach.ToString().PadLeft(4, '0') }-{ i.ToString().PadLeft(4, '0') }";
                if (CuonSachDAO.TonTaiMaCuonSach(maCuonSach))
                {
                    return maCuonSach; // Tồn tại mã cuốn sách trùng
                }
            }
            return string.Empty; // Không có mã cuốn sách trùng
        }

        public static bool ThemCuonSach(CuonSachDTO dto)
        {
            return CuonSachDAO.AddCuonSach(dto);
        }

        public static int GetLastBookCopyCode(int idSach)
        {
            return CuonSachDAO.GetLastBookCopyCode(idSach);
        }
    }
}