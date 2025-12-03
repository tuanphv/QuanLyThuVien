using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace DAO
{
    public class DocGiaDAO
    {
        // 1. Lấy tất cả độc giả
        public static BindingList<DocGiaDTO> GetAll()
        {
            BindingList<DocGiaDTO> list = new BindingList<DocGiaDTO>();
            string query = @"
                SELECT
                    dg.ID,
                    dg.MaDocGia,
                    dg.HoTen,
                    dg.NgaySinh,
                    dg.DiaChi,
                    dg.NgayLapThe,
                    dg.NgayHetHan,
                    dg.TongNoHienTai,
                    dg.IDNguoiDung,
                    nd.TenDangNhap
                FROM DOCGIA dg
                LEFT JOIN NGUOIDUNG nd ON dg.IDNguoiDung = nd.ID
                ORDER BY dg.ID
            ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                list.Add(MapDocGia(item));
            }
            return list;
        }

        // 2. Tạo mã mới
        public static string TaoMaMoi()
        {
            string query = "SELECT MaDocGia FROM DOCGIA ORDER BY ID DESC LIMIT 1";
            object result = DataProvider.Instance.ExecuteScalar(query);

            if (result == null || result == DBNull.Value)
            {
                return "DG0001";
            }

            string maCuoi = result.ToString(); // Ví dụ: "DG0005"
            string phanSo = maCuoi.Substring(2);
            int so = int.Parse(phanSo);
            so++;

            return "DG" + so.ToString("D4");
        }

        // 3. Thêm mới độc giả
        public static string Add(DocGiaDTO docGia)
        {
            string maMoi = TaoMaMoi();

            string query = @"
                INSERT INTO DOCGIA (MaDocGia, HoTen, NgaySinh, DiaChi,
                    NgayLapThe, NgayHetHan, TongNoHienTai, IDNguoiDung)
                VALUES (@MaDocGia, @HoTen, @NgaySinh, @DiaChi,
                    @NgayLapThe, @NgayHetHan, @TongNoHienTai, @IDNguoiDung);
            ";

            int result = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@MaDocGia", maMoi),
                new MySqlParameter("@HoTen", docGia.HoTen),
                new MySqlParameter("@NgaySinh", docGia.NgaySinh),
                new MySqlParameter("@DiaChi", docGia.DiaChi ?? (object)DBNull.Value),
                new MySqlParameter("@NgayLapThe", docGia.NgayLapThe),
                new MySqlParameter("@NgayHetHan", docGia.NgayHetHan),
                new MySqlParameter("@TongNoHienTai", docGia.TongNoHienTai),
                new MySqlParameter("@IDNguoiDung", docGia.IDNguoiDung ?? (object)DBNull.Value)
            );

            return result > 0 ? maMoi : string.Empty;
        }

        // 4. Cập nhật độc giả
        public static bool Update(DocGiaDTO docGia)
        {
            string query = @"
                UPDATE DOCGIA
                SET HoTen = @HoTen,
                    NgaySinh = @NgaySinh,
                    DiaChi = @DiaChi,
                    NgayLapThe = @NgayLapThe,
                    NgayHetHan = @NgayHetHan,
                    IDNguoiDung = @IDNguoiDung
                WHERE MaDocGia = @MaDocGia
            ";

            int count = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@HoTen", docGia.HoTen),
                new MySqlParameter("@NgaySinh", docGia.NgaySinh),
                new MySqlParameter("@DiaChi", docGia.DiaChi ?? (object)DBNull.Value),
                new MySqlParameter("@NgayLapThe", docGia.NgayLapThe),
                new MySqlParameter("@NgayHetHan", docGia.NgayHetHan),
                new MySqlParameter("@IDNguoiDung", docGia.IDNguoiDung ?? (object)DBNull.Value),
                new MySqlParameter("@MaDocGia", docGia.MaDocGia)
            );

            return count > 0;
        }

        // 5. Xóa độc giả
        public static bool Delete(string maDocGia)
        {
            string query = "DELETE FROM DOCGIA WHERE MaDocGia = @MaDocGia";
            int count = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@MaDocGia", maDocGia)
            );
            return count > 0;
        }

        // 6. Kiểm tra độc giả có đang mượn sách không
        public static bool IsInUse(string maDocGia)
        {
            string queryGetId = "SELECT ID FROM DOCGIA WHERE MaDocGia = @MaDocGia";
            object? result = DataProvider.Instance.ExecuteScalar(queryGetId,
                new MySqlParameter("@MaDocGia", maDocGia));

            if (result == null || result == DBNull.Value)
            {
                return false;
            }

            int idDocGia = Convert.ToInt32(result);

            // Kiểm tra xem có phiếu mượn nào của độc giả này không
            string queryCheckUse = "SELECT COUNT(*) FROM PHIEUMUON WHERE IDDocGia = @IDDocGia";
            int count = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(queryCheckUse,
                new MySqlParameter("@IDDocGia", idDocGia)
            ));

            return count > 0;
        }

        // 7. Lấy danh sách người dùng chưa là độc giả (để gán tài khoản)
        public static BindingList<NguoiDungDTO> GetNguoiDungChuaLaDocGia()
        {
            BindingList<NguoiDungDTO> list = new BindingList<NguoiDungDTO>();
            string query = @"
                SELECT
                    nd.ID,
                    nd.MaNguoiDung,
                    nd.TenNguoiDung,
                    nd.TenDangNhap
                FROM NGUOIDUNG nd
                LEFT JOIN DOCGIA dg ON nd.ID = dg.IDNguoiDung
                WHERE dg.ID IS NULL AND nd.IDNhomNguoiDung = (
                    SELECT ID FROM NHOMNGUOIDUNG WHERE TenNhomNguoiDung = N'Độc Giả'
                )
                ORDER BY nd.ID
            ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                NguoiDungDTO nguoiDung = new NguoiDungDTO();
                nguoiDung.ID = Convert.ToInt32(item["ID"]);
                nguoiDung.MaNguoiDung = item["MaNguoiDung"].ToString() ?? string.Empty;
                nguoiDung.TenNguoiDung = item["TenNguoiDung"].ToString() ?? string.Empty;
                nguoiDung.TenDangNhap = item["TenDangNhap"].ToString() ?? string.Empty;
                list.Add(nguoiDung);
            }
            return list;
        }

        // 8. Cập nhật tổng nợ
        public static bool UpdateTongNo(string maDocGia, int soTien)
        {
            string query = @"
                UPDATE DOCGIA
                SET TongNoHienTai = TongNoHienTai + @SoTien
                WHERE MaDocGia = @MaDocGia
            ";

            int count = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@SoTien", soTien),
                new MySqlParameter("@MaDocGia", maDocGia)
            );

            return count > 0;
        }

        public static DocGiaDTO? GetByUserId(int userId)
        {
            string query = @"
                SELECT
                    dg.ID,
                    dg.MaDocGia,
                    dg.HoTen,
                    dg.NgaySinh,
                    dg.DiaChi,
                    dg.NgayLapThe,
                    dg.NgayHetHan,
                    dg.TongNoHienTai,
                    dg.IDNguoiDung,
                    nd.TenDangNhap
                FROM DOCGIA dg
                LEFT JOIN NGUOIDUNG nd ON dg.IDNguoiDung = nd.ID
                WHERE dg.IDNguoiDung = @IDNguoiDung
                LIMIT 1
            ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query,
                new MySqlParameter("@IDNguoiDung", userId));

            if (data.Rows.Count == 0)
            {
                return null;
            }

            return MapDocGia(data.Rows[0]);
        }

        private static DocGiaDTO MapDocGia(DataRow item)
        {
            return new DocGiaDTO(
                Convert.ToInt32(item["ID"]),
                item["MaDocGia"].ToString() ?? string.Empty,
                item["HoTen"].ToString() ?? string.Empty,
                Convert.ToDateTime(item["NgaySinh"]),
                item["DiaChi"]?.ToString() ?? string.Empty,
                Convert.ToDateTime(item["NgayLapThe"]),
                Convert.ToDateTime(item["NgayHetHan"]),
                Convert.ToInt32(item["TongNoHienTai"]),
                item["IDNguoiDung"] != DBNull.Value ? Convert.ToInt32(item["IDNguoiDung"]) : (int?)null,
                item["TenDangNhap"]?.ToString() ?? string.Empty
            );
        }
    }
}
