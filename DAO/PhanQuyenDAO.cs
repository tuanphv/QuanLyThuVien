using DTO;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text;

namespace DAO
{
    public class PhanQuyenDAO
    {
        public static List<PhanQuyenDTO> GetPermissionsByGroupId(int groupId)
        {
            List<PhanQuyenDTO> permissions = new List<PhanQuyenDTO>();
            string query = @"
                SELECT
                    CN.ID AS IDChucNang,
                    CN.TenManHinh AS ChucNang,
                    MAX(CASE WHEN PQ.HanhDong = 'XEM' THEN 1 ELSE 0 END) AS CoXem,
                    MAX(CASE WHEN PQ.HanhDong = 'THEM' THEN 1 ELSE 0 END) AS CoThem,
                    MAX(CASE WHEN PQ.HanhDong = 'SUA' THEN 1 ELSE 0 END) AS CoSua,
                    MAX(CASE WHEN PQ.HanhDong = 'XOA' THEN 1 ELSE 0 END) AS CoXoa
                FROM
                    CHUCNANG CN
                LEFT JOIN
                    PHANQUYEN PQ ON CN.ID = PQ.IDChucNang
                    AND PQ.IDNhomNguoiDung = @GroupId
                GROUP BY
                    CN.ID, CN.TenManHinh
                ORDER BY
                    CN.TenManHinh;
            ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new MySqlParameter("@GroupId", groupId));
            foreach (DataRow row in data.Rows)
            {
                PhanQuyenDTO permission = new PhanQuyenDTO
                {
                    IDChucNang = Convert.ToInt32(row["IDChucNang"]),
                    TenChucNang = row["ChucNang"].ToString() ?? string.Empty,
                    CoQuyenTruyCap = Convert.ToBoolean(row["CoXem"]),
                    CoQuyenThem = Convert.ToBoolean(row["CoThem"]),
                    CoQuyenSua = Convert.ToBoolean(row["CoSua"]),
                    CoQuyenXoa = Convert.ToBoolean(row["CoXoa"])
                };
                permissions.Add(permission);
            }
            return permissions;
        }

        public static bool UpdatePermissions(int groupId, List<PhanQuyenDTO> permissions)
        {
            if (permissions == null)
                throw new ArgumentNullException(nameof(permissions));

            try
            {
                // Delete existing permissions for the group
                string deleteQuery = "DELETE FROM PHANQUYEN WHERE IDNhomNguoiDung = @GroupId";
                DataProvider.Instance.ExecuteNonQuery(deleteQuery, new MySqlParameter("@GroupId", groupId));

                // Prepare inserts for all granted actions
                var valuePlaceholders = new List<string>();
                var parameters = new List<MySqlParameter>();
                int paramIndex = 0;

                foreach (var p in permissions)
                {
                    if (p.CoQuyenTruyCap)
                    {
                        valuePlaceholders.Add($"(@g, @id{paramIndex}, @h{paramIndex})");
                        parameters.Add(new MySqlParameter($"@id{paramIndex}", p.IDChucNang));
                        parameters.Add(new MySqlParameter($"@h{paramIndex}", "XEM"));
                        paramIndex++;
                    }
                    if (p.CoQuyenThem)
                    {
                        valuePlaceholders.Add($"(@g, @id{paramIndex}, @h{paramIndex})");
                        parameters.Add(new MySqlParameter($"@id{paramIndex}", p.IDChucNang));
                        parameters.Add(new MySqlParameter($"@h{paramIndex}", "THEM"));
                        paramIndex++;
                    }
                    if (p.CoQuyenSua)
                    {
                        valuePlaceholders.Add($"(@g, @id{paramIndex}, @h{paramIndex})");
                        parameters.Add(new MySqlParameter($"@id{paramIndex}", p.IDChucNang));
                        parameters.Add(new MySqlParameter($"@h{paramIndex}", "SUA"));
                        paramIndex++;
                    }
                    if (p.CoQuyenXoa)
                    {
                        valuePlaceholders.Add($"(@g, @id{paramIndex}, @h{paramIndex})");
                        parameters.Add(new MySqlParameter($"@id{paramIndex}", p.IDChucNang));
                        parameters.Add(new MySqlParameter($"@h{paramIndex}", "XOA"));
                        paramIndex++;
                    }
                }

                if (valuePlaceholders.Count == 0)
                {
                    // No permissions to insert; we're done after delete
                    return true;
                }

                // Build insert query
                var sb = new StringBuilder();
                sb.Append("INSERT INTO PHANQUYEN (IDNhomNguoiDung, IDChucNang, HanhDong) VALUES ");
                sb.Append(string.Join(",", valuePlaceholders));

                // Add group parameter (same for all tuples)
                parameters.Add(new MySqlParameter("@g", groupId));

                DataProvider.Instance.ExecuteNonQuery(sb.ToString(), parameters.ToArray());

                return true;
            }
            catch
            {
                // bubble up or return false depending on preference
                return false;
            }
        }
    }
}
