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

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM TuaSach");
            foreach (DataRow item in data.Rows)
            {
                TuaSachDTO tuaSach = new TuaSachDTO(
                    Convert.ToInt32(item["ID"]),
                    item["MaTuaSach"].ToString() ?? string.Empty,
                    item["TenTuaSach"].ToString() ?? string.Empty,
                    item["AnhBia"] != DBNull.Value ? (byte[])item["AnhBia"] : null,
                    Convert.ToInt32(item["DaAn"])
                    );
                list.Add(tuaSach);
            }
            return list;
        }
    }
}
