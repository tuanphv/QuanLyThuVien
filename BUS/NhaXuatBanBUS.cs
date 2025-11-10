using DAO;
using DTO;
using System.ComponentModel;

namespace BUS
{
    public class NhaXuatBanBUS
    {
        public static BindingList<NhaXuatBanDTO> GetAll()
        {
            return NhaXuatBanDAO.GetAll();
        }

        public static int Add(NhaXuatBanDTO nxb)
        {
            if (string.IsNullOrWhiteSpace(nxb.TenNXB))
            {
                throw new Exception("Tên nhà xuất bản không được để trống.");
            }
            if (NhaXuatBanDAO.IsNameExist(nxb.TenNXB))
            {
                throw new Exception("Nhà xuất bản với tên này đã tồn tại.");
            }
            return NhaXuatBanDAO.Add(nxb);
        }

        public static bool Update(NhaXuatBanDTO nxb)
        {
            if (string.IsNullOrWhiteSpace(nxb.TenNXB))
            {
                throw new Exception("Tên nhà xuất bản không được để trống.");
            }
            if (NhaXuatBanDAO.IsNameExist(nxb.TenNXB, nxb.ID))
            {
                throw new Exception("Nhà xuất bản với tên này đã tồn tại.");
            }
            return NhaXuatBanDAO.Update(nxb);
        }

        public static bool Delete(int id)
        {
            if (NhaXuatBanDAO.IsInUse(id))
            {
                throw new Exception("Không thể xóa nhà xuất bản này.\nNhà xuất bản đang được liên kết với các sách hiện có.");
            }
            return NhaXuatBanDAO.Delete(id);
        }
    }
}