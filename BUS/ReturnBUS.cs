using System;
using System.Collections.Generic;
using DAO;
using DTO;

namespace BUS
{
    public class ReturnBUS
    {
        private readonly ReturnDAO returnDAO = new();

        public List<ReturnDTO> GetAllReturns()
        {
            return returnDAO.GetAllReturns();
        }

        public bool AddReturn(ReturnDTO ret, out string message)
        {
            if (ret.MaPhieuMuon <= 0)
            {
                message = "Vui lòng chọn phiếu mượn hợp lệ!";
                return false;
            }

            if (ret.NgayTra == DateTime.MinValue)
            {
                message = "Vui lòng chọn ngày trả hợp lệ!";
                return false;
            }

            bool result = returnDAO.AddReturn(ret);
            message = result ? "Trả sách thành công!" : "Lỗi khi trả sách!";
            return result;
        }
    }
}

