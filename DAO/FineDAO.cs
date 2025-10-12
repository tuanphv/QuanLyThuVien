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
            string query = @"INSERT INTO PhieuPhat (MaDocGia, LyDo, SoTien, NgayLap)
                             VALUES (@MaDocGia, @LyDo, @SoTien, @NgayLap)";
            int result = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@MaDocGia", fine.MaDocGia),
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
                    MaDocGia = Convert.ToInt32(row["MaDocGia"]),
                    LyDo = row["LyDo"].ToString() ?? "",
                    SoTien = Convert.ToDecimal(row["SoTien"]),
                    NgayLap = Convert.ToDateTime(row["NgayLap"])
                });
            }
            return list;
        }

        public List<FineDTO> SearchFinesByReader(string keyword)
        {
            string query = @"
        SELECT pp.* 
        FROM PhieuPhat pp
        JOIN DocGia dg ON pp.MaDocGia = dg.MaDocGia
        WHERE dg.HoTen LIKE CONCAT('%', @keyword, '%')
        ORDER BY NgayLap DESC";

            var dt = DataProvider.Instance.ExecuteQuery(query,
                new MySql.Data.MySqlClient.MySqlParameter("@keyword", keyword));

            var list = new List<FineDTO>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new FineDTO
                {
                    MaPhieuPhat = Convert.ToInt32(row["MaPhieuPhat"]),
                    MaDocGia = Convert.ToInt32(row["MaDocGia"]),
                    LyDo = row["LyDo"].ToString() ?? "",
                    SoTien = Convert.ToDecimal(row["SoTien"]),
                    NgayLap = Convert.ToDateTime(row["NgayLap"])
                });
            }
            return list;
        }
    }

}

