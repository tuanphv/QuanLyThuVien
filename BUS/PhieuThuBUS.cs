using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class PhieuThuBUS
    {
        public static List<DTO.PhieuThuDTO> GetAllPhieuThu()
        {
            try
            {
                return DAO.PhieuThuDAO.GetAllPhieuThu();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách phiếu thu: {ex.Message}", ex);
            }
        }

        public static string AddPhieuThu(DTO.PhieuThuDTO phieuThu)
        {
            try
            {
                return DAO.PhieuThuDAO.AddPhieuThu(phieuThu);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm phiếu thu: {ex.Message}", ex);
            }
        }
    }
}
