using DTO;
using MySql.Data.MySqlClient;
using System.Data;

namespace DAO
{
    public class ReturnDAO
    {
        public bool AddReturn(ReturnDTO ret)
        {
            string query = @"
                INSERT INTO PhieuTra (MaPhieuMuon, NgayTra, TinhTrangSach, TienPhat)
                VALUES (@MaPhieuMuon, @NgayTra, @TinhTrangSach, @TienPhat);";

            int result = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@MaPhieuMuon", ret.MaPhieuMuon),
                new MySqlParameter("@NgayTra", ret.NgayTra),
                new MySqlParameter("@TinhTrangSach", ret.TinhTrangSach),
                new MySqlParameter("@TienPhat", ret.TienPhat));

            if (result > 0)
            {
                // Cập nhật trạng thái phiếu mượn
                string updateLoan = "UPDATE PhieuMuon SET TrangThai = 'Đã trả' WHERE MaPhieuMuon = @MaPhieuMuon";
                DataProvider.Instance.ExecuteNonQuery(updateLoan,
                    new MySqlParameter("@MaPhieuMuon", ret.MaPhieuMuon));
            }

            return result > 0;
        }

        public List<ReturnDTO> GetAllReturns()
        {
            List<ReturnDTO> list = new();
            string query = "SELECT * FROM PhieuTra ORDER BY NgayTra DESC";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ReturnDTO
                {
                    MaPhieuTra = Convert.ToInt32(row["MaPhieuTra"]),
                    MaPhieuMuon = Convert.ToInt32(row["MaPhieuMuon"]),
                    NgayTra = Convert.ToDateTime(row["NgayTra"]),
                    TinhTrangSach = row["TinhTrangSach"]?.ToString() ?? "",
                    TienPhat = row["TienPhat"] == DBNull.Value ? 0 : Convert.ToDecimal(row["TienPhat"])
                });
            }

            return list;
        }
    }
}

