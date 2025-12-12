using Dapper;
using DTO;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace DAO
{
    public class CuonSachDAO
    {
        private static MySqlConnection GetOpenConnection()
        {
            return DataProvider.Instance.GetOpenConnection();
        }

        public static BindingList<CuonSachDTO> GetByIDSach(int idSach)
        {
            BindingList<CuonSachDTO> list = new BindingList<CuonSachDTO>();

            string query = @"SELECT cs.ID, cs.MaCuonSach, cs.IDSach, cs.TrangThai,
                                    GROUP_CONCAT(tsp.TenTinhTrang SEPARATOR ', ') AS ChiTietTinhTrang
                             FROM CUONSACH cs
                             LEFT JOIN CUONSACH_TINHTRANG cst ON cst.IDCuonSach = cs.ID
                             LEFT JOIN THAMSOPHAT tsp ON tsp.ID = cst.IDThamSoPhat
                             WHERE cs.IDSach = @IDSach AND cs.DaAn = 0
                             GROUP BY cs.ID, cs.MaCuonSach, cs.IDSach, cs.TrangThai";

            using var connection = GetOpenConnection();
            var result = connection.Query<CuonSachDTO>(query, new { IDSach = idSach }).ToList();
            return new BindingList<CuonSachDTO>(result);
        }

        public static bool CallSP_ThemTinhTrang(int idCuonSach, int idThamSoPhat)
        {
            using var connection = GetOpenConnection();
            int rows = connection.Execute("SP_ThemTinhTrang",
                new { p_IDCuonSach = idCuonSach, p_IDThamSoPhat = idThamSoPhat },
                commandType: CommandType.StoredProcedure);
            return rows > 0;
        }

        public static bool IsBatchBeingBorrowed(int idSach)
        {
            const string query = "SELECT COUNT(*) FROM CUONSACH WHERE IDSach = @IDSach AND TrangThai = 0 AND DaAn = 0";
            using var connection = GetOpenConnection();
            int count = connection.ExecuteScalar<int>(query, new { IDSach = idSach });
            return count > 0;
        }

        public static bool UpdateTinhTrang(int idCuonSach, int tinhTrangMoi)
        {
            string query = "UPDATE CUONSACH SET TrangThai = @TinhTrang WHERE ID = @ID";
            using var connection = GetOpenConnection();
            int result = connection.Execute(query, new { TinhTrang = tinhTrangMoi, ID = idCuonSach });
            return result > 0;
        }
    }
}