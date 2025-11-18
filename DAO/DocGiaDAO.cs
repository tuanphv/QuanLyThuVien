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
        // 1. L?y t?t c? ??c gi?
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
                DocGiaDTO docGia = new DocGiaDTO(
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
                list.Add(docGia);
            }
            return list;
        }

        // 2. T?o mã m?i
        public static string TaoMaMoi()
        {
            string query = "SELECT MaDocGia FROM DOCGIA ORDER BY ID DESC LIMIT 1";
            object result = DataProvider.Instance.ExecuteScalar(query);

            if (result == null || result == DBNull.Value)
            {
                return "DG0001";
            }

            string maCuoi = result.ToString(); // Ví d?: "DG0005"
            string phanSo = maCuoi.Substring(2);
            int so = int.Parse(phanSo);
            so++;

            return "DG" + so.ToString("D4");
        }

        // 3. Thêm m?i ??c gi?
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

        // 4. C?p nh?t ??c gi?
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

        // 5. Xóa ??c gi?
        public static bool Delete(string maDocGia)
        {
            string query = "DELETE FROM DOCGIA WHERE MaDocGia = @MaDocGia";
            int count = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@MaDocGia", maDocGia)
            );
            return count > 0;
        }

        // 6. Ki?m tra ??c gi? có ?ang m??n sách không
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

            // Ki?m tra xem có phi?u m??n nào c?a ??c gi? này không
            string queryCheckUse = "SELECT COUNT(*) FROM PHIEUMUON WHERE IDDocGia = @IDDocGia";
            int count = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(queryCheckUse,
                new MySqlParameter("@IDDocGia", idDocGia)
            ));

            return count > 0;
        }

        // 7. L?y danh sách ng??i dùng ch?a là ??c gi? (?? gán tài kho?n)
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
                    SELECT ID FROM NHOMNGUOIDUNG WHERE TenNhomNguoiDung = N'??c Gi?'
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

        // 8. C?p nh?t t?ng n?
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
    }
}
