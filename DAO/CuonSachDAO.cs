using DocumentFormat.OpenXml.Bibliography;
using DTO;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;

namespace DAO
{
    public class CuonSachDAO
    {
        public static BindingList<CuonSachDTO> GetByIDSach(int idSach)
        {
            BindingList<CuonSachDTO> list = new BindingList<CuonSachDTO>();
            string query = "SELECT * FROM CUONSACH WHERE IDSach = @IDSach AND DaAn = 0";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new MySqlParameter("@IDSach", idSach));
            foreach (DataRow item in data.Rows)
            {
                CuonSachDTO cs = new CuonSachDTO(
                    Convert.ToInt32(item["ID"]),
                    item["MaCuonSach"].ToString() ?? string.Empty,
                    Convert.ToInt32(item["IDSach"]),
                    Convert.ToInt32(item["TinhTrang"])
                );
                list.Add(cs);
            }
            return list;
        }

        // Kiểm tra xem Lô sách này có cuốn nào đang bị mượn không
        public static bool IsBatchBeingBorrowed(int idSach)
        {
            // TinhTrang = 0 nghĩa là Đang mượn
            string query = "SELECT COUNT(*) FROM CUONSACH WHERE IDSach = @IDSach AND TinhTrang = 0 AND DaAn = 0";

            int count = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query,
                new MySqlParameter("@IDSach", idSach)
            ));

            return count > 0; // Trả về true nếu có sách đang mượn
        }

        public static bool UpdateTinhTrang(int idCuonSach, int tinhTrangMoi)
        {
            string query = "UPDATE CUONSACH SET TinhTrang = @TinhTrang WHERE ID = @ID";
            int result = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@TinhTrang", tinhTrangMoi),
                new MySqlParameter("@ID", idCuonSach)
            );
            return result > 0;
        }

        public static bool AddCuonSach(CuonSachDTO dto)
        {
            string query = @"
                INSERT INTO CUONSACH (IDSach, MaCuonSach)
                VALUES (@IDSach, @MaCuonSach);
            ";
            int result = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@IDSach", dto.IDSach),
                new MySqlParameter("@MaCuonSach", dto.MaCuonSach)
            );
            return result > 0;
        }

        public static bool TonTaiMaCuonSach(string maCuonSach)
        {
            string query = "SELECT COUNT(*) FROM CUONSACH WHERE MaCuonSach = @MaCuonSach";
            int count = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query,
                new MySqlParameter("@MaCuonSach", maCuonSach)
            ));
            return count > 0;
        }

        public static int GetLastBookCopyCode(int idSach)
        {
            string query = @"
                SELECT MaCuonSach
                FROM CUONSACH
                WHERE IDSach = @IDSach
                ORDER BY MaCuonSach DESC
                LIMIT 1;";
            string code = DataProvider.Instance.ExecuteScalar(query,
                new MySqlParameter("@MaCuonSach", idSach)
            ).ToString();

            int dashIndex = code.IndexOf('-');
            string numberPart = code.Substring(dashIndex + 1); // "0011"
            int number = int.Parse(numberPart); // 11

            return number;
        }

    }
}