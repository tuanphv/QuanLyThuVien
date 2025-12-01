using DTO;
using GUI.Helpers;

namespace GUI.Login
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Xử lý đăng nhập ở đây
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            // Ví dụ kiểm tra đơn giản (thay thế bằng logic thực tế)

            try
            {
                NguoiDungDTO? user = BUS.NguoiDungBUS.Login(username, password);
                if (user != null)
                {
                    SessionManager.Login(user);
                    List<PhanQuyenDTO> permissions = BUS.PhanQuyenBUS.GetPermissionsByGroupId(user.IDNhomNguoiDung);
                    SessionManager.SetPermissions(permissions);
                    // Signal success to Program.Main and let it start FrmMain
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng nhập: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void roundPanel1_Click(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void roundPanel2_Click(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.IsPlaceholderActive)
                txtPassword.UseSystemPasswordChar = false;
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnLogin.PerformClick();
            }
        }
    }
}
