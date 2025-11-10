using DAO;
using DTO;
using System.ComponentModel;

namespace BUS
{
    public class TacGiaBUS
    {
        public static BindingList<TacGiaDTO> GetAll()
        {
            return TacGiaDAO.GetAll();
        }

        public static string Add(TacGiaDTO tacGia)
        {
            if (string.IsNullOrWhiteSpace(tacGia.TenTacGia))
            {
                throw new Exception("Tên tác giả không được để trống.");
            }

            if (TacGiaDAO.IsNameExist(tacGia.TenTacGia))
            {
                throw new Exception("Tác giả với tên này đã tồn tại.");
            }
            return TacGiaDAO.Add(tacGia);
        }

        public static bool Update(TacGiaDTO tacGia)
        {
            if (string.IsNullOrWhiteSpace(tacGia.TenTacGia))
            {
                throw new Exception("Tên tác giả không được để trống.");
            }

            if (TacGiaDAO.IsNameExist(tacGia.TenTacGia, tacGia.MaTacGia))
            {
                throw new Exception("Tác giả với tên này đã tồn tại.");
            }
            return TacGiaDAO.Update(tacGia);
        }

        public static bool Delete(string maTacGia)
        {
            // Logic nghiệp vụ: Không cho xóa nếu Tác giả đang được sử dụng
            if (TacGiaDAO.IsInUse(maTacGia))
            {
                throw new Exception("Không thể xóa tác giả này.\nTác giả đang được gán cho các tựa sách hiện có.");
            }

            return TacGiaDAO.Delete(maTacGia);
        }
    }
}