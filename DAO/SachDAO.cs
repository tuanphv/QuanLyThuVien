using DTO;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;

namespace DAO
{
    public class SachDAO
    {
        public static BindingList<SachDTO> GetAll()
        {
            BindingList<SachDTO> list = new BindingList<SachDTO>();
            string query = @"
                SELECT S.*, TS.TenTuaSach, NXB.TenNXB 
                FROM SACH S
                JOIN TUASACH TS ON S.IDTuaSach = TS.ID
                JOIN NHAXUATBAN NXB ON S.IDNhaXuatBan = NXB.ID
                WHERE S.DaAn = 0
            ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                SachDTO s = new SachDTO(
                    Convert.ToInt32(item["ID"]),
                    item["MaSach"].ToString(),
                    Convert.ToInt32(item["IDTuaSach"]),
                    item["TenTuaSach"].ToString(),
                    Convert.ToInt32(item["SoLuongTong"]),
                    Convert.ToInt32(item["SoLuongConLai"]),
                    Convert.ToInt32(item["DonGia"]),
                    Convert.ToInt32(item["NamXB"]),
                    Convert.ToInt32(item["IDNhaXuatBan"]),
                    item["TenNXB"].ToString()
                );
                list.Add(s);
            }
            return list;
        }

        // Thêm sách mới
        // Trong DAO/SachDAO.cs

        public static int Add(SachDTO sach)
        {
            try
            {
                // 1. Insert Lô Sách
                string querySach = @"
            INSERT INTO SACH (IDTuaSach, SoLuongTong, SoLuongConLai, DonGia, NamXB, IDNhaXuatBan)
            VALUES (@IDTuaSach, @SoLuong, @SoLuong, @DonGia, @NamXB, @IDNXB);
            SELECT LAST_INSERT_ID();
        ";

                object resultID = DataProvider.Instance.ExecuteScalar(querySach,
                    new MySqlParameter("@IDTuaSach", sach.IDTuaSach),
                    new MySqlParameter("@SoLuong", sach.SoLuongTong),
                    new MySqlParameter("@DonGia", sach.DonGia),
                    new MySqlParameter("@NamXB", sach.NamXB),
                    new MySqlParameter("@IDNXB", sach.IDNhaXuatBan)
                );

                int idSachMoi = Convert.ToInt32(resultID);

                return idSachMoi;
            }
            catch
            {
                return -1;
            }
        }

        // Cập nhật thông tin sách
        public static bool Update(SachDTO sach)
        {
            string query = @"
                UPDATE SACH
                SET DonGia = @DonGia,
                    NamXB = @NamXB,
                    IDNhaXuatBan = @IDNXB
                WHERE ID = @ID
            ";
            int result = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@DonGia", sach.DonGia),
                new MySqlParameter("@NamXB", sach.NamXB),
                new MySqlParameter("@IDNXB", sach.IDNhaXuatBan),
                new MySqlParameter("@ID", sach.ID)
            );
            return result > 0;
        }

        // Xóa sách (Soft Delete)
        public static bool Delete(int id)
        {
            string query = "UPDATE SACH SET DaAn = 1 WHERE ID = @ID";
            return DataProvider.Instance.ExecuteNonQuery(query, new MySqlParameter("@ID", id)) > 0;
        }

        public static SachDTO? FindByTuaSachAndNXBAndNamXB(int idTuaSach, int idNhaXuatBan, int namXB)
        {
            string query = @"
                SELECT 
                    S.ID, S.MaSach, S.IDTuaSach, TS.TenTuaSach,
                    S.SoLuongTong, S.SoLuongConLai, S.DonGia, S.NamXB,
                    S.IDNhaXuatBan, NXB.TenNXB as TenNhaXuatBan
                FROM SACH S
                INNER JOIN TUASACH TS ON S.IDTuaSach = TS.ID
                INNER JOIN NHAXUATBAN NXB ON S.IDNhaXuatBan = NXB.ID
                WHERE S.IDTuaSach = @IDTuaSach 
                  AND S.IDNhaXuatBan = @IDNhaXuatBan 
                  AND S.NamXB = @NamXB 
                  AND S.DaAn = 0
                LIMIT 1
            ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query,
                new MySqlParameter("@IDTuaSach", idTuaSach),
                new MySqlParameter("@IDNhaXuatBan", idNhaXuatBan),
                new MySqlParameter("@NamXB", namXB)
            );

            if (data.Rows.Count > 0)
            {
                DataRow item = data.Rows[0];
                return new SachDTO(
                    Convert.ToInt32(item["ID"]),
                    item["MaSach"].ToString() ?? string.Empty,
                    Convert.ToInt32(item["IDTuaSach"]),
                    item["TenTuaSach"].ToString() ?? string.Empty,
                    Convert.ToInt32(item["SoLuongTong"]),
                    Convert.ToInt32(item["SoLuongConLai"]),
                    Convert.ToInt32(item["DonGia"]),
                    Convert.ToInt32(item["NamXB"]),
                    Convert.ToInt32(item["IDNhaXuatBan"]),
                    item["TenNhaXuatBan"].ToString() ?? string.Empty
                );
            }
            return null;
        }

        public static int GetLatestID()
        {
            string query = "SELECT LAST_INSERT_ID()";
            object result = DataProvider.Instance.ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : -1;
        }
    }
}
