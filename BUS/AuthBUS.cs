using DTO;

namespace BUS
{
    public class AuthBUS
    {
        public static AuthDTO? Login(string tenDangNhap, string matKhau)
        {
            // Ki?m tra input
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau))
            {
                return null;
            }

            // G?i DAO ?? xác th?c
            return DAO.AuthDAO.ValidateLogin(tenDangNhap.Trim(), matKhau);
        }

        public static bool IsUserExists(string tenDangNhap)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap))
                return false;

            return DAO.AuthDAO.CheckUserExists(tenDangNhap.Trim());
        }

        public static bool ChangePassword(string tenDangNhap, string matKhauCu, string matKhauMoi)
        {
            // Ki?m tra m?t kh?u c? tr??c
            var user = Login(tenDangNhap, matKhauCu);
            if (user == null)
                return false;

            // C?p nh?t m?t kh?u m?i
            return DAO.AuthDAO.ChangePassword(tenDangNhap, matKhauMoi);
        }
    }
}