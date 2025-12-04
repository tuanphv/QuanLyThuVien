using BUS;
using DTO;
using System.ComponentModel;

namespace GUI.NhapSach
{
    public partial class UCNhapSach : UserControl
    {
        private BindingList<PhieuNhapSachDTO> list;

        public UCNhapSach()
        {
            InitializeComponent();
        }

        private void UCNhapSach_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadPermissions();
            FormatDataGridView();
        }

        private void LoadData()
        {
            try
            {
                list = PhieuNhapSachBUS.GetAll();
                dgvPhieuNhap.AutoGenerateColumns = false;
                dgvPhieuNhap.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"L?i khi t?i d? li?u: {ex.Message}", "L?i", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPermissions()
        {
            int permissionCode = (int)Helpers.Permission.PhieuNhapSach;
            bool canAdd = Helpers.SessionManager.HasPermission(permissionCode, Helpers.Action.Add);
            btnThemPhieuNhap.Visible = canAdd;
        }

        private void FormatDataGridView()
        {
            if (dgvPhieuNhap.Columns["colTongTien"] != null)
            {
                dgvPhieuNhap.Columns["colTongTien"].DefaultCellStyle.Format = "#,##0 đ";
                dgvPhieuNhap.Columns["colTongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            dgvPhieuNhap.ViewButtonClicked += (s, rowIndex) =>
            {
                var phieu = list[rowIndex];
                FrmChiTietPhieuNhap frm = new FrmChiTietPhieuNhap(phieu.ID);
                frm.ShowDialog();
            };
        }

        private void btnThemPhieuNhap_Click(object sender, EventArgs e)
        {
            FrmAddPhieuNhap frm = new FrmAddPhieuNhap();
            frm.Text = "Lập phiếu nhập sách";
            
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                MessageBox.Show("Nhập sách thành công!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
