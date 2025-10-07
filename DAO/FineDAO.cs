using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using MySql.Data.MySqlClient;

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
    }
}

