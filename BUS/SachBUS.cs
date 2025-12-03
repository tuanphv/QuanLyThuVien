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

        public static SachDTO? GetByID(int id)
        {
            return SachDAO.GetByID(id);
        }

        public static int Add(SachDTO sach)
        {
            if (sach.IDTuaSach <= 0)
                throw new Exception("Vui lòng ch?n t?a sách.");
            if (sach.IDNhaXuatBan <= 0)
                throw new Exception("Vui lòng ch?n nhà xu?t b?n.");
            if (sach.NamXB <= 0)
                throw new Exception("N?m xu?t b?n không h?p l?.");
            if (sach.DonGia < 0)
                throw new Exception("??n giá không h?p l?.");

            return SachDAO.Add(sach);
        }

        public static bool Update(SachDTO sach)
        {
            if (sach.IDTuaSach <= 0)
                throw new Exception("Vui lòng ch?n t?a sách.");
            if (sach.IDNhaXuatBan <= 0)
                throw new Exception("Vui lòng ch?n nhà xu?t b?n.");
            if (sach.NamXB <= 0)
                throw new Exception("N?m xu?t b?n không h?p l?.");
            if (sach.DonGia < 0)
                throw new Exception("??n giá không h?p l?.");

            return SachDAO.Update(sach);
        }

        public static bool Delete(int id)
        {
            return SachDAO.Delete(id);
        }

        public static SachDTO? FindByTuaSachAndNXBAndNamXB(int idTuaSach, int idNhaXuatBan, int namXB)
        {
            return SachDAO.FindByTuaSachAndNXBAndNamXB(idTuaSach, idNhaXuatBan, namXB);
        }
    }
}
