using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace DAO
{
    public class MuonTraDAO
    {
        public static ThamSoMuonTraDTO LayThamSoMuonTra()
        {
            string query = @"SELECT SoSachMuonToiDa, SoNgayMuonToiDa, DonGiaPhatMoiNgay, TuoiToiThieu, TuoiToiDa FROM THAMSO LIMIT 1";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count == 0)
                throw new Exception("Chưa cấu hình bảng THAMSO.");

            DataRow row = data.Rows[0];
            return new ThamSoMuonTraDTO
            {
                SoSachMuonToiDa = row["SoSachMuonToiDa"] != DBNull.Value ? Convert.ToInt32(row["SoSachMuonToiDa"]) : 0,
                SoNgayMuonToiDa = row["SoNgayMuonToiDa"] != DBNull.Value ? Convert.ToInt32(row["SoNgayMuonToiDa"]) : 0,
                DonGiaPhatMoiNgay = row["DonGiaPhatMoiNgay"] != DBNull.Value ? Convert.ToInt32(row["DonGiaPhatMoiNgay"]) : 0,
                TuoiToiThieu = row["TuoiToiThieu"] != DBNull.Value ? Convert.ToInt32(row["TuoiToiThieu"]) : 0,
                TuoiToiDa = row["TuoiToiDa"] != DBNull.Value ? Convert.ToInt32(row["TuoiToiDa"]) : 0,
            };
        }

        public static DocGiaMuonInfoDTO? LayThongTinDocGia(string maDocGia)
        {
            string query = @"SELECT ID, MaDocGia, HoTen, NgaySinh, NgayHetHan, TongNoHienTai FROM DOCGIA WHERE MaDocGia = @MaDocGia";
            DataTable data = DataProvider.Instance.ExecuteQuery(query,
                new MySqlParameter("@MaDocGia", maDocGia));
            if (data.Rows.Count == 0) return null;
            DataRow row = data.Rows[0];
            return new DocGiaMuonInfoDTO
            {
                ID = Convert.ToInt32(row["ID"]),
                MaDocGia = row["MaDocGia"]?.ToString() ?? string.Empty,
                HoTen = row["HoTen"]?.ToString() ?? string.Empty,
                NgaySinh = row["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(row["NgaySinh"]) : DateTime.MinValue,
                NgayHetHan = row["NgayHetHan"] != DBNull.Value ? Convert.ToDateTime(row["NgayHetHan"]) : DateTime.MinValue,
                TongNoHienTai = row["TongNoHienTai"] != DBNull.Value ? Convert.ToInt32(row["TongNoHienTai"]) : 0
            };
        }

        public static int? LayIDCuonSach(string maCuonSach)
        {
            string query = "SELECT ID FROM CUONSACH WHERE MaCuonSach = @Ma";
            object? result = DataProvider.Instance.ExecuteScalar(query, new MySqlParameter("@Ma", maCuonSach));
            if (result == null || result == DBNull.Value) return null;
            return Convert.ToInt32(result);
        }

        public static bool CuonSachSanSang(int idCuonSach)
        {
            string query = "SELECT TinhTrang FROM CUONSACH WHERE ID = @ID";
            object? result = DataProvider.Instance.ExecuteScalar(query, new MySqlParameter("@ID", idCuonSach));
            if (result == null || result == DBNull.Value) return false;
            return Convert.ToInt32(result) == 1;
        }

        public static int DemSoSachDangMuon(int idDocGia)
        {
            string query = @"SELECT COUNT(*) FROM CT_PHIEUMUON cp
                             INNER JOIN PHIEUMUON p ON cp.IDPhieuMuon = p.ID
                             WHERE p.IDDocGia = @IDDocGia AND cp.NgayTraThucTe IS NULL";
            object? result = DataProvider.Instance.ExecuteScalar(query, new MySqlParameter("@IDDocGia", idDocGia));
            return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
        }

        private static string TaoMaPhieuMuonMoi(MySqlConnection connection, MySqlTransaction transaction)
        {
            string query = "SELECT MaPhieuMuon FROM PHIEUMUON ORDER BY ID DESC LIMIT 1";
            using var command = new MySqlCommand(query, connection, transaction);
            object? result = command.ExecuteScalar();

            if (result == null || result == DBNull.Value)
            {
                return "PM000001";
            }

            string maCuoi = result.ToString() ?? "PM000000";
            string phanSo = maCuoi.Substring(2);
            int so = int.Parse(phanSo) + 1;
            return "PM" + so.ToString("D6");
        }

        public static PhieuMuonDTO TaoPhieuMuonVaChiTiet(DocGiaMuonInfoDTO docGia, List<int> danhSachCuon,
            DateTime ngayMuon, DateTime ngayTraDuKien)
        {
            PhieuMuonDTO phieu = new PhieuMuonDTO();

            bool success = DataProvider.Instance.ExecuteTransaction((connection, transaction) =>
            {
                string maMoi = TaoMaPhieuMuonMoi(connection, transaction);
                string queryInsert = @"INSERT INTO PHIEUMUON (MaPhieuMuon, IDDocGia, NgayMuon, NgayTraDuKien)
                                        VALUES (@MaPhieuMuon, @IDDocGia, @NgayMuon, @NgayTraDuKien);
                                        SELECT LAST_INSERT_ID();";

                using var cmdInsert = new MySqlCommand(queryInsert, connection, transaction);
                cmdInsert.Parameters.AddWithValue("@MaPhieuMuon", maMoi);
                cmdInsert.Parameters.AddWithValue("@IDDocGia", docGia.ID);
                cmdInsert.Parameters.AddWithValue("@NgayMuon", ngayMuon);
                cmdInsert.Parameters.AddWithValue("@NgayTraDuKien", ngayTraDuKien);

                object? idResult = cmdInsert.ExecuteScalar();
                if (idResult == null || idResult == DBNull.Value)
                {
                    return false;
                }

                int idPhieu = Convert.ToInt32(idResult);
                foreach (int idCuon in danhSachCuon)
                {
                    string queryCT = @"INSERT INTO CT_PHIEUMUON (IDPhieuMuon, IDCuonSach)
                                        VALUES (@IDPhieuMuon, @IDCuonSach);";
                    using var cmdCT = new MySqlCommand(queryCT, connection, transaction);
                    cmdCT.Parameters.AddWithValue("@IDPhieuMuon", idPhieu);
                    cmdCT.Parameters.AddWithValue("@IDCuonSach", idCuon);
                    cmdCT.ExecuteNonQuery();

                    string queryUpdateCuon = "UPDATE CUONSACH SET TinhTrang = 0 WHERE ID = @IDCuon";
                    using var cmdUpdateCuon = new MySqlCommand(queryUpdateCuon, connection, transaction);
                    cmdUpdateCuon.Parameters.AddWithValue("@IDCuon", idCuon);
                    cmdUpdateCuon.ExecuteNonQuery();
                }

                phieu = new PhieuMuonDTO
                {
                    ID = idPhieu,
                    MaPhieuMuon = maMoi,
                    MaDocGia = docGia.MaDocGia,
                    HoTenDocGia = docGia.HoTen,
                    NgayMuon = ngayMuon,
                    NgayTraDuKien = ngayTraDuKien,
                    TongSach = danhSachCuon.Count,
                    SoSachChuaTra = danhSachCuon.Count
                };
                return true;
            });

            if (!success)
                throw new Exception("Không thể tạo phiếu mượn.");

            return phieu;
        }

        public static BindingList<PhieuMuonDTO> LayTatCaPhieuMuon()
        {
            BindingList<PhieuMuonDTO> list = new BindingList<PhieuMuonDTO>();
            string query = @"SELECT pm.ID, pm.MaPhieuMuon, dg.MaDocGia, dg.HoTen, pm.NgayMuon, pm.NgayTraDuKien,
                                    COUNT(cp.IDCuonSach) as TongSach,
                                    SUM(CASE WHEN cp.NgayTraThucTe IS NULL THEN 1 ELSE 0 END) as SachChuaTra,
                                    MAX(cp.NgayTraThucTe) as NgayTraThucTe
                             FROM PHIEUMUON pm
                             INNER JOIN DOCGIA dg ON pm.IDDocGia = dg.ID
                             LEFT JOIN CT_PHIEUMUON cp ON cp.IDPhieuMuon = pm.ID
                             GROUP BY pm.ID, pm.MaPhieuMuon, dg.MaDocGia, dg.HoTen, pm.NgayMuon, pm.NgayTraDuKien
                             ORDER BY pm.NgayMuon DESC";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                PhieuMuonDTO item = new PhieuMuonDTO
                {
                    ID = Convert.ToInt32(row["ID"]),
                    MaPhieuMuon = row["MaPhieuMuon"]?.ToString() ?? string.Empty,
                    MaDocGia = row["MaDocGia"]?.ToString() ?? string.Empty,
                    HoTenDocGia = row["HoTen"]?.ToString() ?? string.Empty,
                    NgayMuon = row["NgayMuon"] != DBNull.Value ? Convert.ToDateTime(row["NgayMuon"]) : DateTime.MinValue,
                    NgayTraDuKien = row["NgayTraDuKien"] != DBNull.Value ? Convert.ToDateTime(row["NgayTraDuKien"]) : DateTime.MinValue,
                    NgayTraThucTe = row["NgayTraThucTe"] != DBNull.Value ? Convert.ToDateTime(row["NgayTraThucTe"]) : null,
                    TongSach = row["TongSach"] != DBNull.Value ? Convert.ToInt32(row["TongSach"]) : 0,
                    SoSachChuaTra = row["SachChuaTra"] != DBNull.Value ? Convert.ToInt32(row["SachChuaTra"]) : 0,
                };
                list.Add(item);
            }
            return list;
        }

        public static PhieuMuonDTO? LayPhieuMuonTheoID(int idPhieuMuon)
        {
            string query = @"SELECT pm.ID, pm.MaPhieuMuon, dg.MaDocGia, dg.HoTen, pm.NgayMuon, pm.NgayTraDuKien,
                                    COUNT(cp.IDCuonSach) as TongSach,
                                    SUM(CASE WHEN cp.NgayTraThucTe IS NULL THEN 1 ELSE 0 END) as SachChuaTra,
                                    MAX(cp.NgayTraThucTe) as NgayTraThucTe
                             FROM PHIEUMUON pm
                             INNER JOIN DOCGIA dg ON pm.IDDocGia = dg.ID
                             LEFT JOIN CT_PHIEUMUON cp ON cp.IDPhieuMuon = pm.ID
                             WHERE pm.ID = @ID
                             GROUP BY pm.ID, pm.MaPhieuMuon, dg.MaDocGia, dg.HoTen, pm.NgayMuon, pm.NgayTraDuKien";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new MySqlParameter("@ID", idPhieuMuon));
            if (data.Rows.Count == 0) return null;
            DataRow row = data.Rows[0];
            return new PhieuMuonDTO
            {
                ID = Convert.ToInt32(row["ID"]),
                MaPhieuMuon = row["MaPhieuMuon"]?.ToString() ?? string.Empty,
                MaDocGia = row["MaDocGia"]?.ToString() ?? string.Empty,
                HoTenDocGia = row["HoTen"]?.ToString() ?? string.Empty,
                NgayMuon = row["NgayMuon"] != DBNull.Value ? Convert.ToDateTime(row["NgayMuon"]) : DateTime.MinValue,
                NgayTraDuKien = row["NgayTraDuKien"] != DBNull.Value ? Convert.ToDateTime(row["NgayTraDuKien"]) : DateTime.MinValue,
                NgayTraThucTe = row["NgayTraThucTe"] != DBNull.Value ? Convert.ToDateTime(row["NgayTraThucTe"]) : null,
                TongSach = row["TongSach"] != DBNull.Value ? Convert.ToInt32(row["TongSach"]) : 0,
                SoSachChuaTra = row["SachChuaTra"] != DBNull.Value ? Convert.ToInt32(row["SachChuaTra"]) : 0,
            };
        }

        public static BindingList<ChiTietPhieuMuonDTO> LayChiTietPhieuMuon(int idPhieuMuon)
        {
            BindingList<ChiTietPhieuMuonDTO> list = new BindingList<ChiTietPhieuMuonDTO>();
            string query = @"SELECT cp.IDPhieuMuon, cp.IDCuonSach, cs.MaCuonSach, ts.TenTuaSach, cp.NgayTraThucTe, pm.NgayTraDuKien
                             FROM CT_PHIEUMUON cp
                             INNER JOIN CUONSACH cs ON cp.IDCuonSach = cs.ID
                             INNER JOIN SACH s ON cs.IDSach = s.ID
                             INNER JOIN TUASACH ts ON s.IDTuaSach = ts.ID
                             INNER JOIN PHIEUMUON pm ON pm.ID = cp.IDPhieuMuon
                             WHERE cp.IDPhieuMuon = @ID";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new MySqlParameter("@ID", idPhieuMuon));
            foreach (DataRow row in data.Rows)
            {
                list.Add(new ChiTietPhieuMuonDTO
                {
                    IDPhieuMuon = Convert.ToInt32(row["IDPhieuMuon"]),
                    IDCuonSach = Convert.ToInt32(row["IDCuonSach"]),
                    MaCuonSach = row["MaCuonSach"]?.ToString() ?? string.Empty,
                    TenSach = row["TenTuaSach"]?.ToString() ?? string.Empty,
                    NgayTraThucTe = row["NgayTraThucTe"] != DBNull.Value ? Convert.ToDateTime(row["NgayTraThucTe"]) : null,
                    NgayTraDuKien = row["NgayTraDuKien"] != DBNull.Value ? Convert.ToDateTime(row["NgayTraDuKien"]) : DateTime.MinValue,
                });
            }
            return list;
        }

        public static bool GiaHanPhieuMuon(int idPhieuMuon, DateTime hanTraMoi)
        {
            string query = "UPDATE PHIEUMUON SET NgayTraDuKien = @HanTraMoi WHERE ID = @ID";
            int count = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@HanTraMoi", hanTraMoi),
                new MySqlParameter("@ID", idPhieuMuon));
            return count > 0;
        }

        public static bool TraPhieuMuon(int idPhieuMuon, DateTime ngayTra, int donGiaPhatMoiNgay, out int tongTienPhat)
        {
            tongTienPhat = 0;
            return DataProvider.Instance.ExecuteTransaction((connection, transaction) =>
            {
                string queryNgayTraDuKien = "SELECT NgayTraDuKien FROM PHIEUMUON WHERE ID = @ID";
                DateTime ngayTraDuKien;
                using (var cmdGetNgay = new MySqlCommand(queryNgayTraDuKien, connection, transaction))
                {
                    cmdGetNgay.Parameters.AddWithValue("@ID", idPhieuMuon);
                    object? resultNgay = cmdGetNgay.ExecuteScalar();
                    if (resultNgay == null || resultNgay == DBNull.Value) return false;
                    ngayTraDuKien = Convert.ToDateTime(resultNgay);
                }

                string queryDocGia = "SELECT IDDocGia FROM PHIEUMUON WHERE ID = @ID";
                int idDocGia;
                using (var cmdDocGia = new MySqlCommand(queryDocGia, connection, transaction))
                {
                    cmdDocGia.Parameters.AddWithValue("@ID", idPhieuMuon);
                    object? resultDG = cmdDocGia.ExecuteScalar();
                    if (resultDG == null || resultDG == DBNull.Value) return false;
                    idDocGia = Convert.ToInt32(resultDG);
                }

                string querySelectCT = @"SELECT IDCuonSach FROM CT_PHIEUMUON
                                           WHERE IDPhieuMuon = @ID AND NgayTraThucTe IS NULL";
                using var cmdSelectCT = new MySqlCommand(querySelectCT, connection, transaction);
                cmdSelectCT.Parameters.AddWithValue("@ID", idPhieuMuon);
                using var reader = cmdSelectCT.ExecuteReader();
                List<int> cuonChuaTra = new List<int>();
                while (reader.Read())
                {
                    cuonChuaTra.Add(reader.GetInt32("IDCuonSach"));
                }
                reader.Close();

                int soNgayTre = Math.Max(0, (ngayTra.Date - ngayTraDuKien.Date).Days);
                tongTienPhat = soNgayTre * donGiaPhatMoiNgay * cuonChuaTra.Count;

                string queryUpdateCT = @"UPDATE CT_PHIEUMUON
                                          SET NgayTraThucTe = @NgayTra, SoNgayTre = @SoNgayTre, TienPhat = @TienPhat
                                          WHERE IDPhieuMuon = @ID AND NgayTraThucTe IS NULL";
                using (var cmdUpdateCT = new MySqlCommand(queryUpdateCT, connection, transaction))
                {
                    cmdUpdateCT.Parameters.AddWithValue("@NgayTra", ngayTra);
                    cmdUpdateCT.Parameters.AddWithValue("@SoNgayTre", soNgayTre);
                    cmdUpdateCT.Parameters.AddWithValue("@TienPhat", tongTienPhat);
                    cmdUpdateCT.Parameters.AddWithValue("@ID", idPhieuMuon);
                    cmdUpdateCT.ExecuteNonQuery();
                }

                foreach (int idCuon in cuonChuaTra)
                {
                    string queryUpdateCuon = "UPDATE CUONSACH SET TinhTrang = 1 WHERE ID = @ID";
                    using var cmdUpdateCuon = new MySqlCommand(queryUpdateCuon, connection, transaction);
                    cmdUpdateCuon.Parameters.AddWithValue("@ID", idCuon);
                    cmdUpdateCuon.ExecuteNonQuery();
                }

                if (tongTienPhat > 0)
                {
                    string queryUpdateNo = "UPDATE DOCGIA SET TongNoHienTai = TongNoHienTai + @Tien WHERE ID = @ID";
                    using var cmdUpdateNo = new MySqlCommand(queryUpdateNo, connection, transaction);
                    cmdUpdateNo.Parameters.AddWithValue("@Tien", tongTienPhat);
                    cmdUpdateNo.Parameters.AddWithValue("@ID", idDocGia);
                    cmdUpdateNo.ExecuteNonQuery();
                }

                return true;
            });
        }
    }
}
