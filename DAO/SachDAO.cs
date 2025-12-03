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
                SELECT 
                    S.ID, S.MaSach, S.IDTuaSach, TS.TenTuaSach,
                    S.SoLuongTong, S.SoLuongConLai, S.DonGia, S.NamXB,
                    S.IDNhaXuatBan, NXB.TenNXB as TenNhaXuatBan
                FROM SACH S
                INNER JOIN TUASACH TS ON S.IDTuaSach = TS.ID
                INNER JOIN NHAXUATBAN NXB ON S.IDNhaXuatBan = NXB.ID
                WHERE S.DaAn = 0
                ORDER BY S.ID DESC
            ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                SachDTO sach = new SachDTO(
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
                list.Add(sach);
            }
            return list;
        }

        public static SachDTO? GetByID(int id)
        {
            string query = @"
                SELECT 
                    S.ID, S.MaSach, S.IDTuaSach, TS.TenTuaSach,
                    S.SoLuongTong, S.SoLuongConLai, S.DonGia, S.NamXB,
                    S.IDNhaXuatBan, NXB.TenNXB as TenNhaXuatBan
                FROM SACH S
                INNER JOIN TUASACH TS ON S.IDTuaSach = TS.ID
                INNER JOIN NHAXUATBAN NXB ON S.IDNhaXuatBan = NXB.ID
                WHERE S.ID = @ID AND S.DaAn = 0
            ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new MySqlParameter("@ID", id));
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

        public static int Add(SachDTO sach)
        {
            string query = @"
                INSERT INTO SACH (IDTuaSach, SoLuongTong, SoLuongConLai, DonGia, NamXB, IDNhaXuatBan)
                VALUES (@IDTuaSach, @SoLuongTong, @SoLuongConLai, @DonGia, @NamXB, @IDNhaXuatBan);
                SELECT LAST_INSERT_ID();
            ";

            object? result = DataProvider.Instance.ExecuteScalar(query,
                new MySqlParameter("@IDTuaSach", sach.IDTuaSach),
                new MySqlParameter("@SoLuongTong", sach.SoLuongTong),
                new MySqlParameter("@SoLuongConLai", sach.SoLuongConLai),
                new MySqlParameter("@DonGia", sach.DonGia),
                new MySqlParameter("@NamXB", sach.NamXB),
                new MySqlParameter("@IDNhaXuatBan", sach.IDNhaXuatBan)
            );

            return result != null ? Convert.ToInt32(result) : 0;
        }

        public static bool Update(SachDTO sach)
        {
            string query = @"
                UPDATE SACH
                SET IDTuaSach = @IDTuaSach,
                    DonGia = @DonGia,
                    NamXB = @NamXB,
                    IDNhaXuatBan = @IDNhaXuatBan
                WHERE ID = @ID
            ";

            int count = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@IDTuaSach", sach.IDTuaSach),
                new MySqlParameter("@DonGia", sach.DonGia),
                new MySqlParameter("@NamXB", sach.NamXB),
                new MySqlParameter("@IDNhaXuatBan", sach.IDNhaXuatBan),
                new MySqlParameter("@ID", sach.ID)
            );

            return count > 0;
        }

        public static bool Delete(int id)
        {
            string query = "UPDATE SACH SET DaAn = 1 WHERE ID = @ID";
            int count = DataProvider.Instance.ExecuteNonQuery(query, new MySqlParameter("@ID", id));
            return count > 0;
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
    }
}
