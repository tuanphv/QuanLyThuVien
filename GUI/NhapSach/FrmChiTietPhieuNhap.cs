using BUS;

namespace GUI.NhapSach
{
    public partial class FrmChiTietPhieuNhap : Form
    {
        private int idPhieuNhap;

        public FrmChiTietPhieuNhap(int idPhieuNhap)
        {
            InitializeComponent();
            this.idPhieuNhap = idPhieuNhap;
        }

        private void FrmChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadPhieuNhap();
            LoadChiTiet();
            FormatDataGridView();
        }

        private void LoadPhieuNhap()
        {
            try
            {
                var phieu = PhieuNhapSachBUS.GetByID(idPhieuNhap);
                if (phieu != null)
                {
                    lblMaPhieu.Text = phieu.MaPhieuNhap;
                    lblNhaCungCap.Text = phieu.TenNhaCungCap;
                    lblNgayNhap.Text = phieu.NgayNhap.ToString("dd/MM/yyyy HH:mm");
                    lblTongTien.Text = phieu.TongTien.ToString("#,##0 đ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin phiếu nhập: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadChiTiet()
        {
            try
            {
                var list = PhieuNhapSachBUS.GetChiTiet(idPhieuNhap);
                dgvChiTiet.AutoGenerateColumns = false;
                dgvChiTiet.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết phiếu nhập: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            if (dgvChiTiet.Columns["colDonGia"] != null)
            {
                dgvChiTiet.Columns["colDonGia"].DefaultCellStyle.Format = "#,##0 đ";
                dgvChiTiet.Columns["colDonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvChiTiet.Columns["colThanhTien"] != null)
            {
                dgvChiTiet.Columns["colThanhTien"].DefaultCellStyle.Format = "#,##0 đ";
                dgvChiTiet.Columns["colThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
