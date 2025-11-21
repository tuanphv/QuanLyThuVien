namespace BUS
{
    public class PhanQuyenBUS
    {
        public static List<DTO.PhanQuyenDTO> GetPermissionsByGroupId(int groupId)
        {
            return DAO.PhanQuyenDAO.GetPermissionsByGroupId(groupId);
        }

        public static bool UpdatePermissions(int groupId, List<DTO.PhanQuyenDTO> permissions)
        {
            return DAO.PhanQuyenDAO.UpdatePermissions(groupId, permissions);
        }
    }
}
