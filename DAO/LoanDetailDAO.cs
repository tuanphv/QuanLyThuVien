using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAO
{
    public class LoanDetailDAO
    {
        private static LoanDetailDAO instance;
        public static LoanDetailDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoanDetailDAO();
                return instance;
            }
        }

        private LoanDetailDAO() { }

        public List<LoanDetailDTO> GetLoanDetailsByLoanId(int maPhieuMuon)
        {
            string query = "SELECT * FROM ChiTietMuon WHERE MaPhieuMuon = @MaPhieuMuon";
            MySqlParameter[] parameters = {new MySqlParameter("@MaPhieuMuon", maPhieuMuon)
};
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, parameters);
            List<LoanDetailDTO> list = new List<LoanDetailDTO>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new LoanDetailDTO
                {
                    MaPhieuMuon = Convert.ToInt32(row["MaPhieuMuon"]),
                    MaSach = Convert.ToInt32(row["MaSach"]),
                    SoLuong = Convert.ToInt32(row["SoLuong"])
                });
            }
            return list;
        }
    }
}
