using DTO;
using System.Data;

namespace DAO
{
    public class ThamSoDAO
    {
        public static ThamSoDTO GetThamSo()
        {
            string query = "SELECT * FROM THAMSO LIMIT 1";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                DataRow item = data.Rows[0];
                return new ThamSoDTO(
                    Convert.ToInt32(item["TuoiToiThieu"]),
                    Convert.ToInt32(item["TuoiToiDa"]),
                    Convert.ToInt32(item["ThoiHanThe"]),
                    Convert.ToInt32(item["KhoangCachXuatBan"]),
                    Convert.ToInt32(item["SoSachMuonToiDa"]),
                    Convert.ToInt32(item["SoNgayMuonToiDa"]),
                    Convert.ToInt32(item["DonGiaPhatMoiNgay"])
                );
            }
            return null; // Tr??ng h?p ch?a c� tham s?
        }
    }
}