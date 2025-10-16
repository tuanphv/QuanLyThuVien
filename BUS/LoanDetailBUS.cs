using System.Collections.Generic;
using DAO;
using DTO;

namespace BUS
{
    public class LoanDetailBUS
    {
        private static LoanDetailBUS instance;
        public static LoanDetailBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoanDetailBUS();
                return instance;
            }
        }

        private LoanDetailBUS() { }

        public List<LoanDetailDTO> GetLoanDetailsByLoanId(int maPhieuMuon)
        {
            return LoanDetailDAO.Instance.GetLoanDetailsByLoanId(maPhieuMuon);
        }
    }
}
