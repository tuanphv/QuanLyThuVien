using UI.UICustom;
using BUS;
using UI.Utilities;

namespace UI
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muôn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            bool isConnected = DAO.DataProvider.Instance.TestConnection();
            if (isConnected)
            {
                lblConnectionStatus.Text = "Kết nối cơ sở dữ liệu thành công!";
                lblConnectionStatus.ForeColor = Color.Green;
            }
            else
            {
                lblConnectionStatus.Text = "Kết nối cơ sở dữ liệu thất bại!";
                lblConnectionStatus.ForeColor = Color.Red;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Kiểm tra kết nối database trước
            if (!DAO.DataProvider.Instance.TestConnection())
            {
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu!\nVui lòng kiểm tra kết nối.", 
                    "Lỗi Kết Nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy thông tin đăng nhập
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Kiểm tra input
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            // Hiển thị loading
            btnLogin.Enabled = false;
            btnLogin.Text = "Đang đăng nhập...";
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // Xác thực tài khoản
                var user = AuthBUS.Login(username, password);

                if (user != null)
                {
                    // Đăng nhập thành công
                    SessionManager.Login(user);

                    MessageBox.Show($"Đăng nhập thành công!\nXin chào {user.HoTen} ({user.VaiTro})", 
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở form chính và ẩn form login
                    ShowMainForm();
                }
                else
                {
                    // Đăng nhập thất bại
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!\nVui lòng thử lại.", 
                        "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    // Xóa mật khẩu và focus lại username
                    ResetLoginForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình đăng nhập:\n{ex.Message}", 
                    "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Khôi phục trạng thái ban đầu
                btnLogin.Enabled = true;
                btnLogin.Text = "Đăng nhập";
                this.Cursor = Cursors.Default;
            }
        }

        private void ShowMainForm()
        {
            try
            {
                // Ẩn form login
                this.Hide();

                // Tạo và hiển thị form chính
                using (FrmMain frmMain = new FrmMain())
                {
                    DialogResult result = frmMain.ShowDialog(this); // Modal dialog với parent

                    // Khi FrmMain đóng, quay lại form login
                    this.Show();
                    this.BringToFront();
                    this.Focus();
                    
                    // Xử lý kết quả từ form chính
                    if (result == DialogResult.OK)
                    {
                        // Đăng xuất bình thường - reset form để sẵn sàng đăng nhập lại
                        ResetAfterLogout();
                        ShowLogoutMessage();
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        // Form đóng bất thường hoặc session error
                        ResetAfterLogout();
                        MessageBox.Show("Phiên làm việc đã kết thúc.", "Thông báo", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Other cases
                        ResetAfterLogout();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form chính:\n{ex.Message}", 
                    "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // Đảm bảo form login được hiển thị
                this.Show();
                this.BringToFront();
                ResetAfterLogout();
            }
        }

        private void ResetLoginForm()
        {
            txtPassword.Text = "";
            txtUsername.Focus();
            txtUsername.SelectAll();
        }

        private void ResetAfterLogout()
        {
            // Đảm bảo session được clear
            if (SessionManager.IsLoggedIn)
            {
                SessionManager.ForceLogout("Form reset after logout");
            }

            // Clear form
            txtUsername.Text = "";
            txtPassword.Text = "";
            
            // Focus username
            txtUsername.Focus();
            
            // Update UI
            this.Text = "Đăng nhập - Hệ thống Quản lý Thư viện";
            
            // Refresh connection status
            CheckDatabaseConnection();
        }

        private void ShowLogoutMessage()
        {
            // Hiển thị thông báo đăng xuất thành công (tùy chọn)
            // MessageBox.Show("Bạn đã đăng xuất thành công!", "Thông báo", 
            //     MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CheckDatabaseConnection()
        {
            lblConnectionStatus.Text = "Đang kiểm tra kết nối...";
            lblConnectionStatus.ForeColor = Color.Blue;

            Task.Run(() =>
            {
                try
                {
                    bool connected = DAO.DataProvider.Instance.TestConnection();

                    this.Invoke((Action)(() =>
                    {
                        if (!connected)
                        {
                            lblConnectionStatus.Text = "Không thể kết nối cơ sở dữ liệu!";
                            lblConnectionStatus.ForeColor = Color.Red;
                            btnLogin.Enabled = false;
                        }
                        else
                        {
                            lblConnectionStatus.Text = "Kết nối cơ sở dữ liệu thành công!";
                            lblConnectionStatus.ForeColor = Color.Green;
                            btnLogin.Enabled = true;
                        }
                    }));
                }
                catch (Exception ex)
                {
                    this.Invoke((Action)(() =>
                    {
                        lblConnectionStatus.Text = "Lỗi kết nối cơ sở dữ liệu!";
                        lblConnectionStatus.ForeColor = Color.Red;
                        btnLogin.Enabled = false;
                    }));
                }
            });
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // Đảm bảo không có session cũ
            if (SessionManager.IsLoggedIn)
            {
                SessionManager.ForceLogout("Previous session cleanup on load");
            }

            txtUsername.Focus();
            CheckDatabaseConnection();
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            (sender as PlaceholderTextBox).PasswordChar = '●'; // Set your desired masking character
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            PlaceholderTextBox txt = sender as PlaceholderTextBox;
            if (txt.IsPlaceholderActive)
            {
                txt.PasswordChar = '\0'; // Reset to no masking
            }
        }

        // Hỗ trợ nhấn Enter để đăng nhập
        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        // Xử lý khi form login đóng
        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Đảm bảo cleanup session nếu có
            if (SessionManager.IsLoggedIn)
            {
                SessionManager.ForceLogout("Application closing");
            }
        }

        // Method để show login form từ external (nếu cần)
        public void ShowLoginForm()
        {
            ResetAfterLogout();
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
            this.Focus();
        }

        private void FrmLogin_Shown(object sender, EventArgs e)
        {
            // Đảm bảo form được focus khi hiển thị
            this.Activate();
            txtUsername.Focus();
        }
    }
}
