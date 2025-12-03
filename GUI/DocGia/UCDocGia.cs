using DTO;
using System.ComponentModel;
using GUI.Helpers;

namespace GUI.DocGia
{
    public partial class UCDocGia : UserControl
    {
        private BindingList<DocGiaDTO> list;

        public UCDocGia()
        {
            InitializeComponent();
        }

        private void LoadPermissions()
        {
            int permissionCode = (int)Helpers.Permission.DocGia;
            bool canAdd = SessionManager.HasPermission(permissionCode, Helpers.Action.Add);
            btnThemDocGia.Visible = canAdd;

            bool canEdit = SessionManager.HasPermission(permissionCode, Helpers.Action.Edit);
            dgvDocGia.ShowEditButton = canEdit;

            bool canDelete = SessionManager.HasPermission(permissionCode, Helpers.Action.Delete);
            dgvDocGia.ShowDeleteButton = canDelete;

            if (!canEdit && !canDelete)
            {
                if (dgvDocGia.Columns.Contains("Actions"))
                    dgvDocGia.Columns["Actions"].Visible = false;
            }
        }

        private void UCDocGia_Load(object sender, EventArgs e)
        {
            dgvDocGia.AutoGenerateColumns = false;

            LoadData();


            dgvDocGia.EditButtonClicked += EditButtonClicked;
            dgvDocGia.DeleteButtonClicked += DeleteButtonClicked;

            // Apply permissions after DataGridView and its columns are ready
            LoadPermissions();
        }

        private void LoadData()
        {
            try
            {
                list = BUS.DocGiaBUS.GetAll();
                dgvDocGia.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemDocGia_Click(object sender, EventArgs e)
        {
            FrmAddEditDocGia frm = new FrmAddEditDocGia();
            frm.Text = "Thêm độc giả";
            var result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                list.Add(frm.DocGia);
            }
        }

        private void EditButtonClicked(object? sender, int index)
        {
            if (index < 0 || index >= list.Count) return;

            DocGiaDTO selectedDocGia = list[index];

            FrmAddEditDocGia frm = new FrmAddEditDocGia();
            frm.Text = "Chỉnh sữa độc giả";
            frm.DocGia = selectedDocGia;

            var result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                list[index] = frm.DocGia;
            }
        }

        private void DeleteButtonClicked(object? sender, int index)
        {
            if (index < 0 || index >= list.Count) return;

            DocGiaDTO selectedDocGia = list[index];

            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa độc giả '{selectedDocGia.HoTen}'?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    if (BUS.DocGiaBUS.Delete(selectedDocGia.MaDocGia))
                    {
                        list.RemoveAt(index);
                        MessageBox.Show("Xóa thành công.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (list == null) return;

            string tuKhoa = txtTimKiem.Text.ToLower().Trim();

            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                dgvDocGia.DataSource = list;
                return;
            }

            var danhSachLoc = list.Where(dto =>
                dto.HoTen.ToLower().Contains(tuKhoa) ||
                dto.MaDocGia.ToLower().Contains(tuKhoa) ||
                (dto.DiaChi != null && dto.DiaChi.ToLower().Contains(tuKhoa)) ||
                (dto.TenDangNhap != null && dto.TenDangNhap.ToLower().Contains(tuKhoa))
            ).ToList();

            dgvDocGia.DataSource = new BindingList<DocGiaDTO>(danhSachLoc);
        }
    }
}
