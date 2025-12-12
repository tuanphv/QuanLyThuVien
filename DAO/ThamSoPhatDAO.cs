using Dapper;
using DTO;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;

namespace DAO
{
    public class ThamSoPhatDAO
    {
        private static MySqlConnection GetOpenConnection()
        {
            return DataProvider.Instance.GetOpenConnection();
        }

        public static List<ThamSoPhatDTO> LayDanhSach()
        {
            // Lấy thêm cột NhomTinhTrang
            const string query = @"SELECT ID, MaQuyDinh, TenTinhTrang AS TenQuyDinh, 
                                          NhomTinhTrang, -- Cột mới quan trọng
                                          MucPhatPhanTram, GhiChu, 
                                          CoLaDuyNhat, CoLaMacDinh, CoLaHuHong 
                                   FROM THAMSOPHAT 
                                   ORDER BY NhomTinhTrang, MucPhatPhanTram ASC";

            using var connection = GetOpenConnection();
            return connection.Query<ThamSoPhatDTO>(query).ToList();
        }

        public static ThamSoPhatDTO? Them(ThamSoPhatDTO thamSo)
        {
            const string insert = @"INSERT INTO THAMSOPHAT (MaQuyDinh, TenTinhTrang, MucPhatPhanTram, GhiChu, CoLaDuyNhat, CoLaMacDinh, CoLaHuHong)
                                    VALUES (@MaQuyDinh, @TenQuyDinh, @MucPhatPhanTram, @GhiChu, @CoLaDuyNhat, @CoLaMacDinh, @CoLaHuHong);
                                    SELECT LAST_INSERT_ID();";

            using var connection = GetOpenConnection();
            long id = connection.ExecuteScalar<long>(insert, thamSo);
            if (id <= 0) return null;

            thamSo.ID = (int)id;
            return thamSo;
        }

        public static bool CapNhat(ThamSoPhatDTO thamSo)
        {
            const string update = @"UPDATE THAMSOPHAT
                                    SET MaQuyDinh = @MaQuyDinh,
                                        TenTinhTrang = @TenQuyDinh,
                                        MucPhatPhanTram = @MucPhatPhanTram,
                                        GhiChu = @GhiChu,
                                        CoLaDuyNhat = @CoLaDuyNhat,
                                        CoLaMacDinh = @CoLaMacDinh,
                                        CoLaHuHong = @CoLaHuHong
                                    WHERE ID = @ID";

            using var connection = GetOpenConnection();
            int rows = connection.Execute(update, thamSo);
            return rows > 0;
        }

        public static bool Xoa(int id)
        {
            const string delete = "DELETE FROM THAMSOPHAT WHERE ID = @ID";
            using var connection = GetOpenConnection();
            int rows = connection.Execute(delete, new { ID = id });
            return rows > 0;
        }

        public static IEnumerable<ThamSoPhatDTO> LayTatCa() => LayDanhSach();
    }
}