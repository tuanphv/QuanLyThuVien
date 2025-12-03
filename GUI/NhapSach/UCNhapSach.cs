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
                dgvPhieuNhap.Columns["colTongTien"].DefaultCellStyle.Format = "#,##0 ?";
                dgvPhieuNhap.Columns["colTongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void btnThemPhieuNhap_Click(object sender, EventArgs e)
        {
            FrmAddPhieuNhap frm = new FrmAddPhieuNhap();
            frm.Text = "L?p phi?u nh?p sách";
            
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                MessageBox.Show("Nh?p sách thành công!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvPhieuNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvPhieuNhap.Columns[e.ColumnIndex].Name == "colActions")
            {
                var phieu = list[e.RowIndex];
                FrmChiTietPhieuNhap frm = new FrmChiTietPhieuNhap(phieu.ID);
                frm.ShowDialog();
            }
        }
    }
}
