using System;
using System.Collections.Generic;
using DTO;

namespace BUS
{
    public class PhieuThuBUS
    {
        public static List<PhieuThuDTO> GetAllPhieuThu()
        {
            try
            {
                return DAO.PhieuThuDAO.GetAllPhieuThu();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi BUS: {ex.Message}", ex);
            }
        }

        public static string AddPhieuThu(PhieuThuDTO phieuThu)
        {
            try
            {
                return DAO.PhieuThuDAO.AddPhieuThu(phieuThu);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi BUS: {ex.Message}", ex);
            }
        }

        public static List<DocGiaSimpleDTO> GetAllDocGiaCoPhieuThu()
        {
            return DAO.PhieuThuDAO.GetAllDocGiaCoPhieuThu();
        }

        public static bool DeletePhieuThu(int idPhieuThu)
        {
            try
            {
                return DAO.PhieuThuDAO.DeletePhieuThu(idPhieuThu);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi BUS: {ex.Message}", ex);
            }
        }
    }
}