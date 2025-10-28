using System.ComponentModel;

namespace BUS
{
    public class TuaSachBUS
    {
        public static BindingList<DTO.TuaSachDTO> GetAll()
        {
            return DAO.TuaSachDAO.GetAll();
        }
    }
}
