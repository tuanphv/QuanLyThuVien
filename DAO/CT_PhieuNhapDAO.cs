using DTO;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;

namespace DAO
{
    public class CT_PhieuNhapDAO
    {
        public static List<CT_PhieuNhapDTO> GetByPhieuNhapID(int idPhieuNhap)
        {
            List<CT_PhieuNhapDTO> list = new List<CT_PhieuNhapDTO>();
            string query = @"
                SELECT 
                    CT.IDPhieuNhap, CT.IDSach, S.MaSach, TS.TenTuaSach,
                    CT.SoLuongNhap, CT.DonGiaNhap, CT.ThanhTien
                FROM CT_PHIEUNHAP CT
                INNER JOIN SACH S ON CT.IDSach = S.ID
                INNER JOIN TUASACH TS ON S.IDTuaSach = TS.ID
                WHERE CT.IDPhieuNhap = @IDPhieuNhap
            ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new MySqlParameter("@IDPhieuNhap", idPhieuNhap));
            foreach (DataRow item in data.Rows)
            {
                CT_PhieuNhapDTO ct = new CT_PhieuNhapDTO(
                    Convert.ToInt32(item["IDPhieuNhap"]),
                    Convert.ToInt32(item["IDSach"]),
                    item["MaSach"].ToString() ?? string.Empty,
                    item["TenTuaSach"].ToString() ?? string.Empty,
                    Convert.ToInt32(item["SoLuongNhap"]),
                    Convert.ToInt32(item["DonGiaNhap"]),
                    Convert.ToInt32(item["ThanhTien"])
                );
                list.Add(ct);
            }
            return list;
        }

        public static bool Add(CT_PhieuNhapDTO ct)
        {
            string query = @"
                INSERT INTO CT_PHIEUNHAP (IDPhieuNhap, IDSach, SoLuongNhap, DonGiaNhap)
                VALUES (@IDPhieuNhap, @IDSach, @SoLuongNhap, @DonGiaNhap)
            ";

            int count = DataProvider.Instance.ExecuteNonQuery(query,
                new MySqlParameter("@IDPhieuNhap", ct.IDPhieuNhap),
                new MySqlParameter("@IDSach", ct.IDSach),
                new MySqlParameter("@SoLuongNhap", ct.SoLuongNhap),
                new MySqlParameter("@DonGiaNhap", ct.DonGiaNhap)
            );

            return count > 0;
        }
    }
}
