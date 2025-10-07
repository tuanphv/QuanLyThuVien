using System;
using System.Collections.Generic;
using DTO;
using DAO;

namespace BUS
{
    public class LoanBUS
    {
        private static LoanBUS? instance;
        public static LoanBUS Instance => instance ??= new LoanBUS();

        private readonly LoanDAO loanDAO = new LoanDAO();

        private LoanBUS() { }

        public List<LoanDTO> GetAllLoans()
        {
            return loanDAO.GetAllLoans();
        }

        public bool AddLoan(LoanDTO loan, List<LoanDetailDTO> details, out string message)
        {
            if (loan.MaDocGia <= 0)
            {
                message = "Vui lòng chọn độc giả hợp lệ!";
                return false;
            }

            if (details == null || details.Count == 0)
            {
                message = "Không có sách nào được chọn để mượn!";
                return false;
            }

            if (loan.HanTra <= loan.NgayMuon)
            {
                message = "Hạn trả phải sau ngày mượn!";
                return false;
            }

            bool result = loanDAO.AddLoan(loan, details);
            message = result ? "Thêm phiếu mượn thành công!" : "Lỗi khi thêm phiếu mượn!";
            return result;
        }

        public List<LoanDTO> GetUnreturnedLoans()
        {
            return loanDAO.GetUnreturnedLoans();
        }

    }
}
