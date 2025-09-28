namespace UI
{
    public partial class fLogin : Form
    {
        public fLogin()
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
            bool isConnected = DAO.DataProvider.TestConnection();
            if (isConnected)
            {
                lblConnectionStatus.Text = "Kết nối thành công!";
                lblConnectionStatus.ForeColor = Color.Green;
            }
            else
            {
                lblConnectionStatus.Text = "Kết nối thất bại!";
                lblConnectionStatus.ForeColor = Color.Red;
            }
        }
    }
}
