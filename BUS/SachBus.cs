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

        public static int Add(SachDTO sach)
        {
            // Kiểm tra quy định Năm Xuất Bản
            if (!ThamSoBUS.KiemTraNamXuatBan(sach.NamXB))
            {
                ThamSoDTO qd = ThamSoBUS.GetQuyDinh();
                throw new Exception($"Chỉ nhận sách xuất bản trong vòng {qd.KhoangCachXuatBan} năm trở lại đây.");
            }

            int idSachNew = SachDAO.Add(sach);
            if (idSachNew == -1) throw new Exception("Thêm sách thất bại.");
            return idSachNew;
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

        public static SachDTO? FindByTuaSachAndNXBAndNamXB(int idTuaSach, int idNhaXuatBan, int namXB)
        {
            return SachDAO.FindByTuaSachAndNXBAndNamXB(idTuaSach, idNhaXuatBan, namXB);
        }
    }
}
