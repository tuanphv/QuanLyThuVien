using DTO;
using System.ComponentModel;
using System.Data;

namespace DAO
{
    public class TuaSachDAO
    {
        public static BindingList<TuaSachDTO> GetAll()
        {
            BindingList<TuaSachDTO> list = new BindingList<TuaSachDTO>();
            string query = @"
                SELECT
                    TS.*,
                    GROUP_CONCAT(DISTINCT TL.TenTheLoai SEPARATOR ', ') AS TheLoai,
                    GROUP_CONCAT(DISTINCT TG.TenTacGia SEPARATOR ', ') AS TacGia
                FROM TuaSach AS TS
                JOIN
                    CT_TheLoai AS CT_TL ON TS.ID = CT_TL.IDTuaSach
                JOIN
                    TheLoai AS TL ON CT_TL.IDTheLoai = TL.ID
                JOIN 
                    CT_TacGia AS CT_TG ON TS.ID = CT_TG.IDTuaSach
                JOIN
                    TacGia AS TG ON CT_TG.IDTacGia = TG.ID
                GROUP BY TS.ID
            ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                TuaSachDTO tuaSach = new TuaSachDTO(
                    Convert.ToInt32(item["ID"]),
                    item["MaTuaSach"].ToString() ?? string.Empty,
                    item["TenTuaSach"].ToString() ?? string.Empty,
                    item["AnhBia"] != DBNull.Value ? (byte[])item["AnhBia"] : null,
                    item["TheLoai"].ToString() ?? string.Empty,
                    item["TacGia"].ToString() ?? string.Empty
                    );
                list.Add(tuaSach);
            }
            return list;
        }
    }
}
