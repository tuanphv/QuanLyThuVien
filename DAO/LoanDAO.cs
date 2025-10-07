using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAO
{
    public class LoanDAO
    {
        // Thêm phiếu mượn mới
        public bool AddLoan(LoanDTO loan, List<LoanDetailDTO> details)
        {
            try
            {
                string sqlLoan = @"
                    INSERT INTO PhieuMuon (MaDocGia, MaNhanVien, NgayMuon, HanTra, TrangThai)
                    VALUES (@MaDocGia, @MaNhanVien, @NgayMuon, @HanTra, @TrangThai);
                    SELECT LAST_INSERT_ID();";

                // Lấy ID của phiếu mượn vừa thêm
                object? result = DataProvider.Instance.ExecuteScalar(sqlLoan,
                    new MySqlParameter("@MaDocGia", loan.MaDocGia),
                    new MySqlParameter("@MaNhanVien", loan.MaNhanVien),
                    new MySqlParameter("@NgayMuon", loan.NgayMuon),
                    new MySqlParameter("@HanTra", loan.HanTra),
                    new MySqlParameter("@TrangThai", loan.TrangThai)
                );

                if (result == null) return false;
                int maPhieuMuon = Convert.ToInt32(result);

                // Thêm chi tiết mượn
                foreach (var d in details)
                {
                    string sqlDetail = @"
                        INSERT INTO ChiTietMuon (MaPhieuMuon, MaSach, SoLuong)
                        VALUES (@MaPhieuMuon, @MaSach, @SoLuong)";
                    DataProvider.Instance.ExecuteNonQuery(sqlDetail,
                        new MySqlParameter("@MaPhieuMuon", maPhieuMuon),
                        new MySqlParameter("@MaSach", d.MaSach),
                        new MySqlParameter("@SoLuong", d.SoLuong)
                    );
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm phiếu mượn: " + ex.Message);
                return false;
            }
        }

        // Lấy danh sách tất cả phiếu mượn
        public List<LoanDTO> GetAllLoans()
        {
            var list = new List<LoanDTO>();

            string query = "SELECT * FROM PhieuMuon ORDER BY NgayMuon DESC";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new LoanDTO
                {
                    MaPhieuMuon = Convert.ToInt32(row["MaPhieuMuon"]),
                    MaDocGia = Convert.ToInt32(row["MaDocGia"]),
                    MaNhanVien = Convert.ToInt32(row["MaNhanVien"]),
                    NgayMuon = Convert.ToDateTime(row["NgayMuon"]),
                    HanTra = Convert.ToDateTime(row["HanTra"]),
                    TrangThai = row["TrangThai"].ToString() ?? ""
                });
            }

            return list;
        }

        public List<LoanDTO> GetUnreturnedLoans()
        {
            var list = new List<LoanDTO>();
            string query = "SELECT * FROM PhieuMuon WHERE TrangThai = 'Đang mượn' ORDER BY NgayMuon DESC";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new LoanDTO
                {
                    MaPhieuMuon = Convert.ToInt32(row["MaPhieuMuon"]),
                    MaDocGia = Convert.ToInt32(row["MaDocGia"]),
                    MaNhanVien = Convert.ToInt32(row["MaNhanVien"]),
                    NgayMuon = Convert.ToDateTime(row["NgayMuon"]),
                    HanTra = Convert.ToDateTime(row["HanTra"]),
                    TrangThai = row["TrangThai"].ToString() ?? ""
                });
            }
            return list;
        }

        public LoanDTO GetLoanById(int maPhieuMuon)
        {
            string query = "SELECT * FROM PhieuMuon WHERE MaPhieuMuon = @id";
            var dt = DataProvider.Instance.ExecuteQuery(query, new MySql.Data.MySqlClient.MySqlParameter("@id", maPhieuMuon));
            if (dt.Rows.Count == 0) return null;

            var row = dt.Rows[0];
            return new LoanDTO
            {
                MaPhieuMuon = Convert.ToInt32(row["MaPhieuMuon"]),
                MaDocGia = Convert.ToInt32(row["MaDocGia"]),
                MaNhanVien = Convert.ToInt32(row["MaNhanVien"]),
                NgayMuon = Convert.ToDateTime(row["NgayMuon"]),
                HanTra = Convert.ToDateTime(row["HanTra"]),
                TrangThai = row["TrangThai"].ToString() ?? ""
            };
        }

        public void UpdateLoanStatus(int maPhieuMuon, string trangThai)
        {
            string query = "UPDATE PhieuMuon SET TrangThai = @trangThai WHERE MaPhieuMuon = @id";
            DataProvider.Instance.ExecuteNonQuery(query,
                new MySql.Data.MySqlClient.MySqlParameter("@trangThai", trangThai),
                new MySql.Data.MySqlClient.MySqlParameter("@id", maPhieuMuon));
        }

    }
}
