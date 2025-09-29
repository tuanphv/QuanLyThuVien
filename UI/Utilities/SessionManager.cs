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
            
            // Log th�ng tin ??ng nh?p (c� th? m? r?ng sau)
            System.Diagnostics.Debug.WriteLine($"User logged in: {user.HoTen} ({user.VaiTro}) at {_loginTime}");
        }

        public static void Logout()
        {
            if (_currentUser != null)
            {
                // Log th�ng tin ??ng xu?t
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

            return $"T�n: {_currentUser.HoTen}\n" +
                   $"Vai tr�: {_currentUser.VaiTro}\n" +
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
                "view_books" => true, // C? nh�n vi�n v� ??c gi? ??u xem ???c
                "view_own_history" => true, // C? nh�n vi�n v� ??c gi? ??u xem ???c l?ch s?
                _ => IsNhanVien // Default: ch? nh�n vi�n
            };
        }

        // Ki?m tra session c� c�n h?p l? kh�ng (c� th? m? r?ng v?i timeout)
        public static bool IsSessionValid()
        {
            return IsLoggedIn; // C� th? th�m logic timeout sau
        }

        // Force logout (d�ng khi c� l?i security)
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