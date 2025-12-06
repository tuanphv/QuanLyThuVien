using Dapper;
using DTO;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;

namespace DAO
{
    public class ThamSoPhatDAO
    {
        private static MySqlConnection OpenConnection()
        {
            return DataProvider.Instance.GetOpenConnection();
        }

        public static IEnumerable<ThamSoPhatDTO> LayTatCa()
        {
            const string query = "SELECT * FROM THAMSOPHAT ORDER BY LoaiTinhTrang, MucDo";
            using var connection = OpenConnection();
            return connection.Query<ThamSoPhatDTO>(query).ToList();
        }

        public static IEnumerable<ThamSoPhatDTO> LayTheoLoai(string loaiTinhTrang)
        {
            const string query = "SELECT * FROM THAMSOPHAT WHERE LoaiTinhTrang = @Loai ORDER BY MucDo";
            using var connection = OpenConnection();
            return connection.Query<ThamSoPhatDTO>(query, new { Loai = loaiTinhTrang }).ToList();
        }

        public static ThamSoPhatDTO? Them(ThamSoPhatDTO thamSo)
        {
            const string insert = @"INSERT INTO THAMSOPHAT (MaQuyDinh, LoaiTinhTrang, MucDo, TienPhat, GhiChu)
                                 VALUES (@MaQuyDinh, @LoaiTinhTrang, @MucDo, @TienPhat, @GhiChu);
                                 SELECT LAST_INSERT_ID();";

            using var connection = OpenConnection();
            long id = connection.ExecuteScalar<long>(insert, thamSo);
            if (id <= 0)
            {
                return null;
            }

            thamSo.ID = (int)id;
            return thamSo;
        }

        public static bool CapNhat(ThamSoPhatDTO thamSo)
        {
            const string update = @"UPDATE THAMSOPHAT
                                   SET MaQuyDinh = @MaQuyDinh,
                                       LoaiTinhTrang = @LoaiTinhTrang,
                                       MucDo = @MucDo,
                                       TienPhat = @TienPhat,
                                       GhiChu = @GhiChu
                                   WHERE ID = @ID";

            using var connection = OpenConnection();
            int rows = connection.Execute(update, thamSo);
            return rows > 0;
        }

        public static bool Xoa(int id)
        {
            const string delete = "DELETE FROM THAMSOPHAT WHERE ID = @ID";
            using var connection = OpenConnection();
            int rows = connection.Execute(delete, new { ID = id });
            return rows > 0;
        }
    }
}
