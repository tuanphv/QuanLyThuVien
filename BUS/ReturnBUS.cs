using System;
using System.Collections.Generic;
using DAO;
using DTO;

namespace BUS
{
    public class ReturnBUS
    {
        private readonly ReturnDAO returnDAO = new();
        private readonly LoanDAO loanDAO = new();
        private readonly FineBUS fineBUS = new();

        public List<ReturnDTO> GetAllReturns()
        {
            return returnDAO.GetAllReturns();
        }

        public bool AddReturn(ReturnDTO ret, out string message)
        {
            // Kiểm tra đầu vào
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

            // Thêm phiếu trả
            bool result = returnDAO.AddReturn(ret);
            if (!result)
            {
                message = "Lỗi khi thêm phiếu trả!";
                return false;
            }

            // Lấy thông tin phiếu mượn
            var loan = loanDAO.GetLoanById(ret.MaPhieuMuon);
            if (loan == null)
            {
                message = "Không tìm thấy phiếu mượn tương ứng!";
                return false;
            }

            // Cập nhật trạng thái phiếu mượn
            loanDAO.UpdateLoanStatus(loan.MaPhieuMuon, "Đã trả");

            // Xử lý phạt nếu có
            bool hasFine = false;
            decimal soTien = 0;
            string lyDo = "";

            // Nếu trả trễ
            if (ret.NgayTra > loan.HanTra)
            {
                int soNgayTre = (ret.NgayTra.Date - loan.HanTra.Date).Days;
                if (soNgayTre > 0)
                {
                    soTien += soNgayTre * 5000; // ví dụ: 5k/ngày trễ
                    lyDo += $"Trả trễ {soNgayTre} ngày. ";
                    hasFine = true;
                }
            }

            // Nếu sách hư hỏng
            if (!string.IsNullOrEmpty(ret.TinhTrangSach) && ret.TinhTrangSach != "Tốt")
            {
                soTien += 10000; // ví dụ 10.000đ phạt hư hỏng
                lyDo += "Sách bị hư hỏng. ";
                hasFine = true;
            }

            // Nếu có phạt → thêm phiếu phạt
            if (hasFine)
            {
                var fine = new FineDTO
                {
                    MaDocGia = loan.MaDocGia,
                    LyDo = lyDo.Trim(),
                    SoTien = soTien,
                    NgayLap = DateTime.Now
                };
                fineBUS.AddFine(fine);

                message = $"Trả sách thành công, bị phạt {soTien:N0}đ ({lyDo.Trim()})";
            }
            else
            {
                message = "Trả sách thành công, không có tiền phạt.";
            }

            return true;
        }
        public List<ReturnDTO> SearchReturns(string keyword)
        {
            return returnDAO.SearchReturns(keyword);
        }
    }
}
