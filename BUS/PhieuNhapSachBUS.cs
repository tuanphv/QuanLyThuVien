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
                throw new Exception("Vui lòng chọn nhà cung cấp.");
            if (chiTietList == null || chiTietList.Count == 0)
                throw new Exception("Vui lòng thêm ít nhất một sách vào phiếu nhập.");

            // Tạo phiếu nhập
            int idPhieuNhap = PhieuNhapSachDAO.Add(phieu);
            if (idPhieuNhap <= 0)
                throw new Exception("Không thể tạo phiếu nhập.");

            // Thêm chi ti?t
            foreach (var ct in chiTietList)
            {
                ct.IDPhieuNhap = idPhieuNhap;
                bool success = CT_PhieuNhapDAO.Add(ct);
                if (!success)
                    throw new Exception($"Không thể thêm chi tiết nhập cho sách ID {ct.IDSach}.");
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
