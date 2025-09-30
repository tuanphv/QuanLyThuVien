using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Utilities;

namespace UI
{
    public partial class FrmMain : Form
    {
        private Control currentUserControl;
        private System.Windows.Forms.Timer sessionTimer;
        private bool isLoggingOut = false;

        public FrmMain()
        {
            InitializeComponent();
            InitializeSessionTimer();
        }

        private void InitializeSessionTimer()
        {
            // Timer để cập nhật thông tin session
            sessionTimer = new System.Windows.Forms.Timer();
            sessionTimer.Interval = 1000; // 1 giây
            sessionTimer.Tick += SessionTimer_Tick;
            sessionTimer.Start();
        }

        private void SessionTimer_Tick(object sender, EventArgs e)
        {
            if (!SessionManager.IsLoggedIn)
            {
                sessionTimer.Stop();
                return;
            }

            // Cập nhật user info với thời gian online
            UpdateUserInfo();
        }

        private void UpdateUserInfo()
        {
            if (SessionManager.IsLoggedIn && lblUserInfo != null)
            {
                var duration = SessionManager.SessionDuration;
                var user = SessionManager.CurrentUser;
                
                // Hiển thị tên, vai trò và thời gian online
                lblUserInfo.Text = $"👤 {user?.HoTen} ({user?.VaiTro}) | ⏱️ {duration.Hours:D2}:{duration.Minutes:D2}:{duration.Seconds:D2}";
                
                // Đổi màu theo vai trò
                lblUserInfo.ForeColor = SessionManager.IsNhanVien ? Color.DarkBlue : Color.DarkGreen;
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            HighlightActiveButton(btnOverview);
            LoadUserInfo();
            ConfigureUserPermissions();
            LoadOverviewInfo(); // Load trang chính ngay khi mở
        }

        private void LoadUserInfo()
        {
            if (SessionManager.IsLoggedIn)
            {
                UpdateUserInfo();
                
                // Cập nhật title form
                this.Text = $"Hệ thống Quản lý Thư viện - {SessionManager.CurrentUser?.HoTen}";
            }
            else
            {
                // Nếu không có session, đóng form và quay về login
                MessageBox.Show("Phiên đăng nhập không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void ConfigureUserPermissions()
        {
            // Cấu hình quyền truy cập theo vai trò
            if (SessionManager.IsDocGia)
            {
                // Độc giả chỉ được xem thông tin sách và mượn/trả
                btnReaders.Visible = false;
                btnGenrePublisher.Visible = false;
                btnReports.Visible = false;

                // Có thể truy cập
                btnBooks.Text = "Xem sách";
                btnBorrowReturn.Text = "Lịch sử mượn/trả";
            }
            
            // Nhân viên có sẵn full quyền
        }

        private void btnOverview_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(sender as Button);
            LoadEmbeddedForm(null, "Tổng quan");
            LoadOverviewInfo();
        }

        // Mấy bạn sửa lại sau nhá, cái này để test thôi
        private void LoadOverviewInfo()
        {
            // Clear current content và hiển thị thông tin tổng quan
            if (currentUserControl != null)
            {
                pnlContent.Controls.Remove(currentUserControl);
                currentUserControl.Dispose();
                currentUserControl = null;
            }

            // Tạo panel chứa thông tin tổng quan
            Panel pnlOverview = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(20)
            };

            // Label chào mừng
            Label lblWelcome = new Label
            {
                Text = $"Chào mừng {SessionManager.CurrentUser?.HoTen}!",
                Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold),
                ForeColor = Color.DarkSlateBlue,
                AutoSize = true,
                Location = new Point(20, 20)
            };

            // Label thông tin chi tiết
            Label lblDetails = new Label
            {
                Text = SessionManager.GetDetailedUserInfo(),
                Font = new Font("Microsoft Sans Serif", 11F),
                ForeColor = Color.DarkSlateGray,
                AutoSize = true,
                Location = new Point(20, 60)
            };

            // Label quyền hạn
            Label lblPermissions = new Label
            {
                Text = SessionManager.IsNhanVien ? 
                    "🔓 Bạn có quyền truy cập đầy đủ vào hệ thống:\n" +
                    "• Quản lý độc giả\n" +
                    "• Quản lý sách\n" +
                    "• Quản lý mượn/trả\n" +
                    "• Xem báo cáo\n" +
                    "• Quản lý thể loại & NXB" :
                    "🔒 Quyền hạn của bạn:\n" +
                    "• Xem danh sách sách\n" +
                    "• Xem lịch sử mượn/trả cá nhân\n" +
                    "• Cập nhật thông tin cá nhân",
                Font = new Font("Microsoft Sans Serif", 10F),
                ForeColor = SessionManager.IsNhanVien ? Color.Green : Color.Orange,
                AutoSize = true,
                Location = new Point(20, 160)
            };

            pnlOverview.Controls.Add(lblWelcome);
            pnlOverview.Controls.Add(lblDetails);
            pnlOverview.Controls.Add(lblPermissions);

            pnlContent.Controls.Add(pnlOverview);
            currentUserControl = pnlOverview;
            lblHeaderTitle.Text = "Tổng quan";
        }

        private void btnReaders_Click(object sender, EventArgs e)
        {
            if (!SessionManager.HasPermission("manage_readers"))
            {
                MessageBox.Show("Chỉ nhân viên mới có quyền quản lý độc giả!", "Không có quyền", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HighlightActiveButton(sender as Button);
            LoadEmbeddedForm(new FrmReaders(), "Quản lý độc giả");
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(sender as Button);
            string title = SessionManager.HasPermission("manage_books") ? "Quản lý sách (Chưa phát triển)" : "Danh sách sách (Chưa phát triển)";
            LoadEmbeddedForm(null, title); // Thay null bằng form quản lý sách khi phát triển xong
        }

        private void btnGenrePublisher_Click(object sender, EventArgs e)
        {
            if (!SessionManager.HasPermission("manage_categories"))
            {
                MessageBox.Show("Bạn không có quyền quản lý thể loại và nhà xuất bản!\n" +
                    "Liên hệ quản lý để được cấp quyền", "Không có quyền", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadEmbeddedForm(null, "Quản lý thể loại & NXB (Chưa phát triển)"); // Thay null bằng form quản lý thể loại & NXB khi phát triển xong
            HighlightActiveButton(sender as Button);
        }

        private void btnBorrowReturn_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(sender as Button);
            string title = SessionManager.HasPermission("manage_borrow_return") ? "Quản lý mượn/trả (Chưa phát triển)" : "Lịch sử mượn/trả (Chưa phát triển)";
            LoadEmbeddedForm(null, title);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            if (!SessionManager.HasPermission("manage_reports"))
            {
                MessageBox.Show("Bạn không có quyền xem báo cáo!\n" +
                    "Liên hệ quản lý để được cấp quyền", "Không có quyền", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadEmbeddedForm(null, "Báo cáo thống kê (Chưa phát triển)");
            HighlightActiveButton(sender as Button);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            PerformLogout();
        }

        private void PerformLogout()
        {
            if (isLoggingOut) return; // Tránh multiple logout calls

            var user = SessionManager.CurrentUser;
            var sessionDuration = SessionManager.SessionDuration;

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn đăng xuất?\n\n" +
                $"Phiên làm việc: {sessionDuration.Hours:D2}:{sessionDuration.Minutes:D2}:{sessionDuration.Seconds:D2}\n" +
                $"Tài khoản: {user?.HoTen} ({user?.VaiTro})",
                "Xác nhận đăng xuất", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                isLoggingOut = true;

                try
                {
                    // Dọn dẹp resources
                    CleanupResources();

                    // Clear session
                    SessionManager.Logout();

                    // Hiển thị thông báo ngắn gọn
                    MessageBox.Show("Đăng xuất thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Set DialogResult để FrmLogin biết là logout thành công
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi đăng xuất: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isLoggingOut = false;
                }
            }
        }

        private void CleanupResources()
        {
            // Dừng timer
            if (sessionTimer != null)
            {
                sessionTimer.Stop();
                sessionTimer.Dispose();
                sessionTimer = null;
            }

            // Clear current user control
            if (currentUserControl != null)
            {
                pnlContent.Controls.Remove(currentUserControl);
                currentUserControl.Dispose();
                currentUserControl = null;
            }

            // Clear tất cả embedded forms
            foreach (Control control in pnlContent.Controls.OfType<Form>().ToArray())
            {
                pnlContent.Controls.Remove(control);
                control.Dispose();
            }
        }

        private void HighlightActiveButton(Button activeButton)
        {
            // Reset all menu buttons
            foreach (Control control in pnlSidebar.Controls)
            {
                if (control is Button btn && btn.Name.StartsWith("btn") && btn != btnLogout)
                {
                    btn.BackColor = Color.Transparent;
                    btn.ForeColor = Color.DarkSlateGray;
                }
            }

            // Highlight active button
            if (activeButton != null)
            {
                activeButton.BackColor = Color.DarkSlateBlue;
                activeButton.ForeColor = Color.White;
            }
        }

        private void LoadEmbeddedForm(Form form, string title)
        {
            // Clear current content
            if (currentUserControl != null)
            {
                pnlContent.Controls.Remove(currentUserControl);
                currentUserControl.Dispose();
                currentUserControl = null;
            }

            // Clear any existing forms
            foreach (Control control in pnlContent.Controls.OfType<Form>().ToArray())
            {
                pnlContent.Controls.Remove(control);
                control.Dispose();
            }

            // Add new form if not null
            if (form != null)
            {
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                pnlContent.Controls.Add(form);
                form.Show();
            }

            // Update title
            lblHeaderTitle.Text = title;
        }

        // Xử lý khi form đóng
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Nếu không phải đang logout và vẫn còn session thì hỏi xác nhận
            if (!isLoggingOut && SessionManager.IsLoggedIn)
            {
                var result = MessageBox.Show("Bạn có muốn đăng xuất khỏi hệ thống?", 
                    "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                
                // Nếu chọn Yes thì logout
                SessionManager.Logout();
                this.DialogResult = DialogResult.Cancel;
            }

            // Cleanup resources
            CleanupResources();
        }

        // Method để handle khi có lỗi session
        private void HandleSessionError()
        {
            if (!SessionManager.IsSessionValid())
            {
                MessageBox.Show("Phiên đăng nhập đã hết hạn hoặc không hợp lệ!", 
                    "Lỗi bảo mật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SessionManager.ForceLogout("Invalid session");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void OnOffSidebarButtons(bool state)
        {
            btnOverview.Enabled = state;
            btnReaders.Enabled = state;
            btnBooks.Enabled = state;
            btnGenrePublisher.Enabled = state;
            btnBorrowReturn.Enabled = state;
            btnReports.Enabled = state;
        }
    }
}
