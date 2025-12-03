using DAO;
using DTO;
using System.ComponentModel;

namespace BUS
{
    public class PhieuNhapSachBUS
    {
        public static BindingList<PhieuNhapSachDTO> GetAll()
        {
            return PhieuNhapSachDAO.GetAll();
        }

        public static int Add(PhieuNhapSachDTO phieu, List<CT_PhieuNhapDTO> chiTietList)
        {
            if (phieu.IDNhaCungCap <= 0)
                throw new Exception("Vui lòng ch?n nhà cung c?p.");
            if (chiTietList == null || chiTietList.Count == 0)
                throw new Exception("Vui lòng thêm ít nh?t m?t sách vào phi?u nh?p.");

            // T?o phi?u nh?p
            int idPhieuNhap = PhieuNhapSachDAO.Add(phieu);
            if (idPhieuNhap <= 0)
                throw new Exception("Không th? t?o phi?u nh?p.");

            // Thêm chi ti?t
            foreach (var ct in chiTietList)
            {
                ct.IDPhieuNhap = idPhieuNhap;
                bool success = CT_PhieuNhapDAO.Add(ct);
                if (!success)
                    throw new Exception($"Không th? thêm chi ti?t nh?p cho sách ID {ct.IDSach}.");
            }

            return idPhieuNhap;
        }

        public static PhieuNhapSachDTO? GetByID(int id)
        {
            return PhieuNhapSachDAO.GetByID(id);
        }

        public static List<CT_PhieuNhapDTO> GetChiTiet(int idPhieuNhap)
        {
            return CT_PhieuNhapDAO.GetByPhieuNhapID(idPhieuNhap);
        }
    }
}
