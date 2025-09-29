using UI.UICustom;

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
            FrmMain frmMain = new FrmMain();
            this.Hide();
            frmMain.ShowDialog();
            this.Close();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();

            // Test database connection with user-friendly feedback
            lblConnectionStatus.Text = "Đang kiểm tra cơ sở dữ liệu...";
            lblConnectionStatus.ForeColor = Color.Blue;

            // Async connection test
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

                            MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu\n\n" +
                                "Vui lòng kiểm tra:\n" +
                                "• MySQL Server đã khởi động chưa\n" +
                                "• Thông tin kết nối trong DataProvider.cs\n" +
                                "• Thông tin trong .env\n" +
                                "• Cơ sở dữ liệu QuanLyThuVien đã được tạo chưa",
                                "Lỗi Kết Nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                        MessageBox.Show($"Lỗi kết nối: {ex.Message}\n\n" +
                            "Vui lòng kiểm tra cấu hình database.",
                            "Lỗi Kết Nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
            });
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
    }
}
