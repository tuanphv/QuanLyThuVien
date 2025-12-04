using DAO;
using DTO;
using System.ComponentModel;

namespace BUS
{
    public class SachBUS
    {
        public static BindingList<SachDTO> GetAll()
        {
            return SachDAO.GetAll();
        }

        public static bool Add(SachDTO sach)
        {
            // 1. Kiểm tra quy định Năm Xuất Bản
            if (!ThamSoBUS.KiemTraNamXuatBan(sach.NamXB))
            {
                ThamSoDTO qd = ThamSoBUS.GetQuyDinh();
                throw new Exception($"Chỉ nhận sách xuất bản trong vòng {qd.KhoangCachXuatBan} năm trở lại đây.");
            }

            // 2. Kiểm tra giá tiền
            if (sach.DonGia <= 0) throw new Exception("Đơn giá phải lớn hơn 0.");
            if (sach.SoLuongTong <= 0) throw new Exception("Số lượng nhập phải lớn hơn 0.");

            return SachDAO.Add(sach);
        }

        public static bool Update(SachDTO sach)
        {
            if (!ThamSoBUS.KiemTraNamXuatBan(sach.NamXB))
            {
                ThamSoDTO qd = ThamSoBUS.GetQuyDinh();
                throw new Exception($"Năm xuất bản không hợp lệ (Quá {qd.KhoangCachXuatBan} năm).");
            }
            return SachDAO.Update(sach);
        }

        public static bool Delete(int id)
        {
            // 1. Kiểm tra nghiệp vụ: Có cuốn nào đang được độc giả mượn không?
            if (CuonSachDAO.IsBatchBeingBorrowed(id))
            {
                throw new Exception("Không thể xóa lô sách này!\nLý do: Đang có độc giả mượn sách thuộc lô này.");
            }

            // 2. Nếu an toàn (tất cả đều đang ở trong kho), cho phép xóa (Soft Delete)
            return SachDAO.Delete(id);
        }
    }
}