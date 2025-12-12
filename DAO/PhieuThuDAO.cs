using Dapper;
using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAO
{
    public class PhieuThuDAO
    {
        private static MySqlConnection OpenConnection()
        {
            return DataProvider.Instance.GetOpenConnection();
        }

        public static List<PhieuThuDTO> GetAllPhieuThu()
        {
            string sql = @"SELECT pt.ID, pt.MaPhieuThu, pt.IDDocGia, dg.HoTen AS TenDocGia, pt.SoTienThu, pt.NgayLap 
                           FROM PHIEUTHU pt
                           JOIN DOCGIA dg ON dg.ID = pt.IDDocGia
                           ORDER BY pt.NgayLap DESC";

            using var connection = OpenConnection();
            return connection.Query<PhieuThuDTO>(sql).ToList();
        }

        // --- HÀM THÊM PHIẾU THU (DÙNG DAPPER + TRANSACTION) ---
        public static string AddPhieuThu(PhieuThuDTO phieuThu)
        {
            using var connection = OpenConnection();
            using var transaction = connection.BeginTransaction();

            try
            {
                // 1. Insert Phiếu Thu
                string sqlInsert = @"INSERT INTO PHIEUTHU (IDDocGia, SoTienThu, NgayLap)
                                     VALUES (@IDDocGia, @SoTienThu, @NgayLapPhieu);
                                     SELECT LAST_INSERT_ID();";

                // Dùng Dapper: connection.ExecuteScalar (đúng cú pháp)
                int idPhieu = connection.ExecuteScalar<int>(sqlInsert, new
                {
                    phieuThu.IDDocGia,
                    phieuThu.SoTienThu,
                    phieuThu.NgayLapPhieu
                }, transaction);

                if (idPhieu <= 0) throw new Exception("Không thể tạo phiếu thu.");

                // Lấy mã phiếu vừa sinh (Trigger sinh mã PM...)
                string maPhieu = connection.ExecuteScalar<string>("SELECT MaPhieuThu FROM PHIEUTHU WHERE ID = @ID", new { ID = idPhieu }, transaction);

                // 2. CẬP NHẬT NỢ ĐỘC GIẢ (TRỪ TIỀN)
                string sqlUpdateNo = @"UPDATE DOCGIA 
                                       SET TongNoHienTai = TongNoHienTai - @TienThu 
                                       WHERE ID = @IDDocGia";

                connection.Execute(sqlUpdateNo, new { TienThu = phieuThu.SoTienThu, IDDocGia = phieuThu.IDDocGia }, transaction);

                transaction.Commit();
                return maPhieu;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        // Giữ lại hàm này để tương thích nếu BUS gọi tên cũ, nhưng trỏ về hàm mới
        public static string AddPhieuThu_Fixed(PhieuThuDTO phieuThu) => AddPhieuThu(phieuThu);

        // --- CẬP NHẬT: XÓA PHIẾU THU ---
        public static bool DeletePhieuThu(int idPhieuThu)
        {
            using var connection = OpenConnection();
            using var transaction = connection.BeginTransaction();

            try
            {
                // 1. Lấy thông tin phiếu trước khi xóa
                var phieu = connection.QueryFirstOrDefault<PhieuThuDTO>("SELECT IDDocGia, SoTienThu FROM PHIEUTHU WHERE ID = @ID", new { ID = idPhieuThu }, transaction);

                if (phieu == null) return false;

                // 2. Xóa phiếu
                int rows = connection.Execute("DELETE FROM PHIEUTHU WHERE ID = @ID", new { ID = idPhieuThu }, transaction);

                // 3. Hoàn tác nợ (Cộng lại tiền vào nợ)
                if (rows > 0)
                {
                    string sqlUpdateNo = @"UPDATE DOCGIA 
                                           SET TongNoHienTai = TongNoHienTai + @SoTien 
                                           WHERE ID = @IDDocGia";
                    connection.Execute(sqlUpdateNo, new { SoTien = phieu.SoTienThu, IDDocGia = phieu.IDDocGia }, transaction);
                }

                transaction.Commit();
                return rows > 0;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public static List<DocGiaSimpleDTO> GetAllDocGiaCoPhieuThu()
        {
            string sql = @"SELECT DISTINCT dg.ID, dg.HoTen
                           FROM DOCGIA dg
                           JOIN PHIEUTHU pt ON dg.ID = pt.IDDocGia
                           ORDER BY dg.HoTen";

            using var connection = OpenConnection();
            return connection.Query<DocGiaSimpleDTO>(sql).ToList();
        }
    }
}