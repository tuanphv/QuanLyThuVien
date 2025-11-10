using DAO;
using DTO;
using System.ComponentModel;

namespace BUS
{
    public class NhaCungCapBUS
    {
        public static BindingList<NhaCungCapDTO> GetAll()
        {
            return NhaCungCapDAO.GetAll();
        }

        public static int Add(NhaCungCapDTO ncc)
        {
            if (string.IsNullOrWhiteSpace(ncc.TenNCC))
            {
                throw new Exception("Tên nhà cung cấp không được để trống.");
            }
            if (NhaCungCapDAO.IsNameExist(ncc.TenNCC))
            {
                throw new Exception("Nhà cung cấp với tên này đã tồn tại.");
            }
            return NhaCungCapDAO.Add(ncc);
        }

        public static bool Update(NhaCungCapDTO ncc)
        {
            if (string.IsNullOrWhiteSpace(ncc.TenNCC))
            {
                throw new Exception("Tên nhà cung cấp không được để trống.");
            }
            if (NhaCungCapDAO.IsNameExist(ncc.TenNCC, ncc.ID))
            {
                throw new Exception("Nhà cung cấp với tên này đã tồn tại.");
            }
            return NhaCungCapDAO.Update(ncc);
        }

        public static bool Delete(int id)
        {
            if (NhaCungCapDAO.IsInUse(id))
            {
                throw new Exception("Không thể xóa nhà cung cấp này.\nNhà cung cấp đang được liên kết với các phiếu nhập sách.");
            }
            return NhaCungCapDAO.Delete(id);
        }
    }
}