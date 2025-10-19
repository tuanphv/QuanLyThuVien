using DTO;
using MySql.Data.MySqlClient;
using System.Data;

namespace DAO
{
    public class ReturnDAO
    {
        public int AddReturn(ReturnDTO ret)
        {
            string query = @"
                INSERT INTO PhieuTra (MaPhieuMuon, NgayTra, TinhTrangSach, TienPhat)
                VALUES (@MaPhieuMuon, @NgayTra, @TinhTrangSach, @TienPhat);
                SELECT LAST_INSERT_ID();";

            object result = DataProvider.Instance.ExecuteScalar(query,
                new MySqlParameter("@MaPhieuMuon", ret.MaPhieuMuon),
                new MySqlParameter("@NgayTra", ret.NgayTra),
                new MySqlParameter("@TinhTrangSach", ret.TinhTrangSach),
                new MySqlParameter("@TienPhat", ret.TienPhat));

            if (result != null && result != DBNull.Value)
            {
                int maPhieuTra = Convert.ToInt32(result);

                // Cập nhật trạng thái phiếu mượn
                string updateLoan = "UPDATE PhieuMuon SET TrangThai = 'Đã trả' WHERE MaPhieuMuon = @MaPhieuMuon";
                DataProvider.Instance.ExecuteNonQuery(updateLoan,
                    new MySqlParameter("@MaPhieuMuon", ret.MaPhieuMuon));

                return maPhieuTra; // <-- Trả về mã phiếu trả mới
            }

            return 0;
        }

        public List<ReturnDTO> GetAllReturns()
        {
            string query = "SELECT * FROM phieutra";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);

            List<ReturnDTO> list = new();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ReturnDTO
                {
                    MaPhieuTra = Convert.ToInt32(row["MaPhieuTra"]),
                    MaPhieuMuon = Convert.ToInt32(row["MaPhieuMuon"]),
                    NgayTra = Convert.ToDateTime(row["NgayTra"]),
                    TinhTrangSach = row["TinhTrangSach"].ToString(),
                    TienPhat = Convert.ToDecimal(row["TienPhat"])
                });
            }

            return list;
        }
        public List<ReturnDTO> SearchReturns(string keyword)
        {
            string query = @"
                SELECT * FROM phieutra 
                WHERE MaPhieuTra LIKE @kw 
                OR MaPhieuMuon LIKE @kw 
                OR TinhTrangSach LIKE @kw";

            MySqlParameter[] parameters = { new MySqlParameter("@kw", "%" + keyword + "%") };

            DataTable dt = DataProvider.Instance.ExecuteQuery(query, parameters);
            List<ReturnDTO> list = new();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ReturnDTO
                {
                    MaPhieuTra = Convert.ToInt32(row["MaPhieuTra"]),
                    MaPhieuMuon = Convert.ToInt32(row["MaPhieuMuon"]),
                    NgayTra = Convert.ToDateTime(row["NgayTra"]),
                    TinhTrangSach = row["TinhTrangSach"].ToString(),
                    TienPhat = Convert.ToDecimal(row["TienPhat"])
                });
            }
            return list;
        }

    }
}

