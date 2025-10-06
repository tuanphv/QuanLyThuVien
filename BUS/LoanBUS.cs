using System;
using System.Collections.Generic;
using DTO;
using DAO;

namespace BUS
{
    public class LoanBUS
    {
        private readonly LoanDAO loanDAO = new LoanDAO();

        // Lấy danh sách tất cả phiếu mượn
        public List<LoanDTO> GetAllLoans()
        {
            return loanDAO.GetAllLoans();
        }

        // Thêm phiếu mượn mới (kèm chi tiết)
        public bool AddLoan(LoanDTO loan, List<LoanDetailDTO> details, out string message)
        {
            // 1️⃣ Kiểm tra dữ liệu cơ bản
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

            // Gọi xuống DAO
            bool result = loanDAO.AddLoan(loan, details);

            // Trả thông báo cho UI
            message = result ? "Thêm phiếu mượn thành công!" : "Lỗi khi thêm phiếu mượn!";
            return result;
        }
    }
}
