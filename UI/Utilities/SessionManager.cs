using DTO;

namespace UI.Utilities
{
    public static class SessionManager
    {
        private static AuthDTO? _currentUser;
        private static DateTime _loginTime;

        public static AuthDTO? CurrentUser 
        { 
            get => _currentUser; 
            private set => _currentUser = value; 
        }

        public static bool IsLoggedIn => _currentUser != null;

        public static bool IsNhanVien => _currentUser?.VaiTro == "NhanVien";

        public static bool IsDocGia => _currentUser?.VaiTro == "DocGia";

        public static DateTime LoginTime => _loginTime;

        public static TimeSpan SessionDuration => DateTime.Now - _loginTime;

        public static void Login(AuthDTO user)
        {
            _currentUser = user;
            _loginTime = DateTime.Now;
            
            // Log thông tin ??ng nh?p (có th? m? r?ng sau)
            System.Diagnostics.Debug.WriteLine($"User logged in: {user.HoTen} ({user.VaiTro}) at {_loginTime}");
        }

        public static void Logout()
        {
            if (_currentUser != null)
            {
                // Log thông tin ??ng xu?t
                var sessionDuration = SessionDuration;
                System.Diagnostics.Debug.WriteLine($"User logged out: {_currentUser.HoTen} after {sessionDuration.TotalMinutes:F1} minutes");
            }
            
            _currentUser = null;
            _loginTime = default;
        }

        public static string GetUserDisplayName()
        {
            if (_currentUser == null)
                return "Ch?a ??ng nh?p";

            return $"{_currentUser.HoTen} ({_currentUser.VaiTro})";
        }

        public static string GetDetailedUserInfo()
        {
            if (_currentUser == null)
                return "Ch?a ??ng nh?p";

            return $"Tên: {_currentUser.HoTen}\n" +
                   $"Vai trò: {_currentUser.VaiTro}\n" +
                   $"??ng nh?p: {_loginTime:dd/MM/yyyy HH:mm:ss}\n" +
                   $"Th?i gian online: {SessionDuration.Hours:D2}:{SessionDuration.Minutes:D2}:{SessionDuration.Seconds:D2}";
        }

        public static int? GetUserId()
        {
            if (_currentUser == null)
                return null;

            return _currentUser.VaiTro == "NhanVien" ? _currentUser.MaNhanVien : _currentUser.MaDocGia;
        }

        public static bool HasPermission(string permission)
        {
            if (!IsLoggedIn) return false;

            return permission.ToLower() switch
            {
                "manage_readers" => IsNhanVien,
                "manage_books" => IsNhanVien,
                "manage_borrow_return" => IsNhanVien,
                "manage_reports" => IsNhanVien,
                "manage_categories" => IsNhanVien,
                "view_books" => true, // C? nhân viên và ??c gi? ??u xem ???c
                "view_own_history" => true, // C? nhân viên và ??c gi? ??u xem ???c l?ch s?
                _ => IsNhanVien // Default: ch? nhân viên
            };
        }

        // Ki?m tra session có còn h?p l? không (có th? m? r?ng v?i timeout)
        public static bool IsSessionValid()
        {
            return IsLoggedIn; // Có th? thêm logic timeout sau
        }

        // Force logout (dùng khi có l?i security)
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