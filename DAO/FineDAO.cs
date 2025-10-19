using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class FineDAO
    {
        public bool AddFine(FineDTO fine)
        {
            string query = @"INSERT INTO PhieuPhat (MaPhieuTra, LyDo, SoTien, NgayLap)
                             VALUES (@MaPhieuTra, @LyDo, @SoTien, @NgayLap)";
            int result = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@MaPhieuTra", fine.MaPhieuTra),
                new MySqlParameter("@LyDo", fine.LyDo),
                new MySqlParameter("@SoTien", fine.SoTien),
                new MySqlParameter("@NgayLap", fine.NgayLap));
            return result > 0;
        }
        public List<FineDTO> GetAllFines()
        {
            string query = "SELECT * FROM PhieuPhat ORDER BY NgayLap DESC";
            var dt = DataProvider.Instance.ExecuteQuery(query);
            var list = new List<FineDTO>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new FineDTO
                {
                    MaPhieuPhat = Convert.ToInt32(row["MaPhieuPhat"]),
                    MaPhieuTra = Convert.ToInt32(row["MaPhieuTra"]),
                    LyDo = row["LyDo"].ToString() ?? "",
                    SoTien = Convert.ToDecimal(row["SoTien"]),
                    NgayLap = Convert.ToDateTime(row["NgayLap"])
                });
            }
            return list;
        }

        public List<FineDTO> SearchFines(string keyword)
        {
            string query = @"
                SELECT pp.* FROM PhieuPhat pp
                JOIN PhieuTra pt ON pp.MaPhieuTra = pt.MaPhieuTra
                JOIN PhieuMuon pm ON pt.MaPhieuMuon = pm.MaPhieuMuon
                JOIN DocGia dg ON pm.MaDocGia = dg.MaDocGia
                WHERE (dg.MaDocGia LIKE @kw OR dg.HoTen LIKE @kw OR pp.MaPhieuPhat LIKE @kw)";

            MySqlParameter[] parameters = { new MySqlParameter("@kw", "%" + keyword + "%") };

            var dt = DataProvider.Instance.ExecuteQuery(query, parameters);
            var list = new List<FineDTO>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new FineDTO
                {
                    MaPhieuPhat = Convert.ToInt32(row["MaPhieuPhat"]),
                    MaPhieuTra = Convert.ToInt32(row["MaPhieuTra"]),
                    LyDo = row["LyDo"].ToString() ?? "",
                    SoTien = Convert.ToDecimal(row["SoTien"]),
                    NgayLap = Convert.ToDateTime(row["NgayLap"])
                });
            }
            return list;
        }
    }

}

