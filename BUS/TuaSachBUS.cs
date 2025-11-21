using DTO;
using System.ComponentModel;

namespace BUS
{
    public class TuaSachBUS
    {
        public static BindingList<DTO.TuaSachDTO> GetAll()
        {
            return DAO.TuaSachDAO.GetAll();
        }

        public static string AddBookTitle(DTO.TuaSachDTO tuaSach)
        {
            if (DAO.TuaSachDAO.IsNameExist(tuaSach.TenTuaSach))
            {
                throw new Exception("Tựa sách với tên này đã tồn tại.");
            }
            return DAO.TuaSachDAO.AddBookTitle(tuaSach);
        }

        public static bool UpdateBookTitle(DTO.TuaSachDTO tuaSach)
        {
            if (DAO.TuaSachDAO.IsNameExist(tuaSach.TenTuaSach, tuaSach.MaTuaSach))
            {
                throw new Exception("Tựa sách với tên này đã tồn tại.");
            }

            bool updated = DAO.TuaSachDAO.UpdateBookTitle(tuaSach);
            if (!updated)
                throw new Exception("Cập nhật tựa sách thất bại.");

            return true;
        }

        public static bool DeleteBookTitle(int id)
        {
            return DAO.TuaSachDAO.DeleteBookTitle(id);
        }

        // Search with optional keyword, genreId and authorId
        public static BindingList<TuaSachDTO> Search(string keyword, int genreId = 0, int authorId = 0)
        {
            return DAO.TuaSachDAO.Search(keyword, genreId, authorId);
        }

        //Trí thêm hàm lấy tựa sách theo mã thể loại
        public static List<TuaSachDTO> GetByMaTheLoai(string maTheLoai)
        {
            return DAO.TuaSachDAO.GetByMaTheLoai(maTheLoai);
        }

        //Trí thêm hàm lấy tựa sách theo mã tác giả
        public static List<DTO.TuaSachDTO> GetByMaTacGia(string maTacGia)
        {
            return DAO.TuaSachDAO.GetByMaTacGia(maTacGia);
        }
    }
}
