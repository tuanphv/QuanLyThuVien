using DTO;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Helpers
{
    public static class SessionManager
    {
        private static NguoiDungDTO? _currentUser;
        private static List<PhanQuyenDTO>? _permissions = new List<PhanQuyenDTO>();
        private static DateTime _loginTime;

        public static NguoiDungDTO? CurrentUser
        {
            get => _currentUser;
            private set => _currentUser = value;
        }

        public static List<PhanQuyenDTO> Permissions
        {
            get => _permissions;
            set => _permissions = value;
        }

        public static bool IsLoggedIn => _currentUser != null;

        public static void Login(NguoiDungDTO user)
        {
            _currentUser = user;
            _loginTime = DateTime.Now;

            // Log thông tin đăng nhập
            System.Diagnostics.Debug.WriteLine($"User logged in: {user.TenNguoiDung} ({user.TenNhomNguoiDung}) at {_loginTime}");
        }

        public static void Logout()
        {
            if (_currentUser != null)
            {
                System.Diagnostics.Debug.WriteLine($"User logged in: {_currentUser.TenNguoiDung} ({_currentUser.TenNhomNguoiDung}) at {DateTime.Now}");
            }

            _currentUser = null;
            _loginTime = default;
        }

        public static void SetPermissions(List<PhanQuyenDTO> permissions)
        {
            _permissions = permissions;
        }

        public static int? GetUserId()
        {
            if (_currentUser == null)
                return null;

            return _currentUser.ID;
        }

        public static bool HasPermission(int permission, Action action)
        {
            if (!IsLoggedIn) return false;
            if (_permissions == null) return false;

            foreach (PhanQuyenDTO p in _permissions)
            {
                if (p.IDChucNang == permission)
                {
                    return action switch
                    {
                        Action.View => p.CoQuyenTruyCap,
                        Action.Add => p.CoQuyenThem,
                        Action.Edit => p.CoQuyenSua,
                        Action.Delete => p.CoQuyenXoa,
                        _ => false,
                    };
                }
            }
            return false;
        }

        // Kiểm tra session có còn hợp lệ không
        public static bool IsSessionValid()
        {
            return IsLoggedIn; // Có th? thêm logic timeout sau
        }

        // Force logout (dùng khi có lỗi security)
        public static void ForceLogout(string reason = "")
        {
            if (!string.IsNullOrEmpty(reason))
            {
                System.Diagnostics.Debug.WriteLine($"Force logout: {reason}");
            }
            Logout();
        }
    }
}
