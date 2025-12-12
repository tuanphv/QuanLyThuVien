using DAO;
using DTO;
using System.ComponentModel;

namespace BUS
{
    public class CuonSachBUS
    {
        // Lấy danh sách cuốn sách thuộc về 1 lô sách
        public static BindingList<CuonSachDTO> GetByIDSach(int idSach)
        {
            return CuonSachDAO.GetByIDSach(idSach);
        }

        public static bool CapNhatTinhTrang(int idCuonSach, int tinhTrangMoi)
        {
            // Có thể thêm logic: Nếu sách đang mượn (0) thì không cho chuyển sang Hỏng (2) trực tiếp mà phải Trả trước.
            // Nhưng với quyền Admin, ta cứ cho phép cập nhật.
            return CuonSachDAO.UpdateTinhTrang(idCuonSach, tinhTrangMoi);
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