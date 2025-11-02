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
            return DAO.TuaSachDAO.UpdateBookTitle(tuaSach);
        }

        public static bool DeleteBookTitle(int id)
        {
            return DAO.TuaSachDAO.DeleteBookTitle(id);
        }
    }
}
