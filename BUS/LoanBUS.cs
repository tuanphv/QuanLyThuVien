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
        public List<LoanDTO> SearchLoans(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return loanDAO.GetAllLoans(); // nếu ô tìm kiếm trống thì trả về toàn bộ danh sách

            return loanDAO.SearchLoans(keyword);
        }

        public bool DeleteLoan(int maPhieuMuon)
        {
            return loanDAO.DeleteLoan(maPhieuMuon);
        }

        public List<LoanDTO> SearchUnreturnedLoans(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                // Nếu ô tìm kiếm trống, trả về TẤT CẢ phiếu chưa trả
                return loanDAO.GetUnreturnedLoans();
            }

            // Nếu có từ khóa, gọi hàm tìm kiếm mới
            return loanDAO.SearchUnreturnedLoans(keyword);
        }


        public bool ExtendDueDate(int maPhieuMuon, DateTime newDueDate, out string message)
        {
            // Lấy thông tin phiếu mượn cũ để kiểm tra
            var loan = loanDAO.GetLoanById(maPhieuMuon); // Hàm này bạn đã có
            if (loan == null)
            {
                message = "Không tìm thấy phiếu mượn!";
                return false;
            }

            // Kiểm tra logic nghiệp vụ
            if (newDueDate.Date <= loan.NgayMuon.Date)
            {
                message = "Hạn trả mới phải sau ngày mượn!";
                return false;
            }
            if (newDueDate.Date <= loan.HanTra.Date)
            {
                message = "Hạn trả mới phải sau hạn trả cũ!";
                return false;
            }
            if (loan.TrangThai == "Đã trả")
            {
                message = "Phiếu này đã trả, không thể gia hạn!";
                return false;
            }

            // Gọi DAO để cập nhật
            bool result = loanDAO.ExtendDueDate(maPhieuMuon, newDueDate);
            message = result ? "Gia hạn phiếu mượn thành công!" : "Lỗi khi gia hạn phiếu mượn!";
            return result;
        }
    }
}
