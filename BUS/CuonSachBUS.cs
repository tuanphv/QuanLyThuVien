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
    }

}