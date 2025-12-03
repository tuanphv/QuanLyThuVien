using DTO;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;

namespace DAO
{
    public class PhieuNhapSachDAO
    {
        public static BindingList<PhieuNhapSachDTO> GetAll()
        {
            BindingList<PhieuNhapSachDTO> list = new BindingList<PhieuNhapSachDTO>();
            string query = @"
                SELECT 
                    PNS.ID, PNS.MaPhieuNhap, PNS.IDNhaCungCap, 
                    NCC.TenNCC, PNS.NgayNhap, PNS.TongTien
                FROM PHIEUNHAPSACH PNS
                INNER JOIN NHACUNGCAP NCC ON PNS.IDNhaCungCap = NCC.ID
                ORDER BY PNS.NgayNhap DESC, PNS.ID DESC
            ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                PhieuNhapSachDTO phieu = new PhieuNhapSachDTO(
                    Convert.ToInt32(item["ID"]),
                    item["MaPhieuNhap"].ToString() ?? string.Empty,
                    Convert.ToInt32(item["IDNhaCungCap"]),
                    item["TenNCC"].ToString() ?? string.Empty,
                    Convert.ToDateTime(item["NgayNhap"]),
                    Convert.ToInt32(item["TongTien"])
                );
                list.Add(phieu);
            }
            return list;
        }

        public static int Add(PhieuNhapSachDTO phieu)
        {
            string query = @"
                INSERT INTO PHIEUNHAPSACH (IDNhaCungCap, NgayNhap, TongTien)
                VALUES (@IDNhaCungCap, @NgayNhap, 0);
                SELECT LAST_INSERT_ID();
            ";

            object? result = DataProvider.Instance.ExecuteScalar(query,
                new MySqlParameter("@IDNhaCungCap", phieu.IDNhaCungCap),
                new MySqlParameter("@NgayNhap", phieu.NgayNhap)
            );

            return result != null ? Convert.ToInt32(result) : 0;
        }

        public static PhieuNhapSachDTO? GetByID(int id)
        {
            string query = @"
                SELECT 
                    PNS.ID, PNS.MaPhieuNhap, PNS.IDNhaCungCap, 
                    NCC.TenNCC, PNS.NgayNhap, PNS.TongTien
                FROM PHIEUNHAPSACH PNS
                INNER JOIN NHACUNGCAP NCC ON PNS.IDNhaCungCap = NCC.ID
                WHERE PNS.ID = @ID
            ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new MySqlParameter("@ID", id));
            if (data.Rows.Count > 0)
            {
                DataRow item = data.Rows[0];
                return new PhieuNhapSachDTO(
                    Convert.ToInt32(item["ID"]),
                    item["MaPhieuNhap"].ToString() ?? string.Empty,
                    Convert.ToInt32(item["IDNhaCungCap"]),
                    item["TenNCC"].ToString() ?? string.Empty,
                    Convert.ToDateTime(item["NgayNhap"]),
                    Convert.ToInt32(item["TongTien"])
                );
            }
            return null;
        }
    }
}
