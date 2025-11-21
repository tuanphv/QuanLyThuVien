using DTO;
using GUI.Controls;
using System.Data;

namespace GUI.TacGia
{
    public partial class FrmDanhSachSachTheoTacGia : Form
    {
        private string maTacGia;
        private string tenTacGia;

        public FrmDanhSachSachTheoTacGia(string maTacGia, string tenTacGia)
        {
            InitializeComponent();
            this.maTacGia = maTacGia;
            this.tenTacGia = tenTacGia;
        }

        private void FrmDanhSachSachTheoTacGia_Load(object sender, EventArgs e)
        {
            this.Text = "Sách của tác giả: " + this.tenTacGia;
            dgvSach.AutoGenerateColumns = false;

            try
            {
                // Gọi hàm mới vừa viết trong BUS
                dgvSach.DataSource = BUS.TuaSachBUS.GetByMaTacGia(this.maTacGia);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
