using DTO;
using GUI.TuaSach;
using System.ComponentModel;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using GUI.Helpers;

namespace GUI.PhanQuyen
{
    public partial class UCPermissions : UserControl
    {
        BindingList<NhomNguoiDungDTO> list = new BindingList<NhomNguoiDungDTO>();
        public UCPermissions()
        {
            InitializeComponent();
            dgvUsersGroup.EditButtonClicked += EditButtonClicked;
            dgvUsersGroup.DeleteButtonClicked += DeleteButtonClicked;
            dgvUsersGroup.ViewButtonClicked += ViewButtonClicked;
        }

        private void UCPermissions_Load(object sender, EventArgs e)
        {
            list = BUS.NhomNguoiDungBUS.GetAllNhomNguoiDung();
            dgvUsersGroup.DataSource = list;

            // Apply permissions after grid and columns are ready
            LoadPermissions();
        }

        private void LoadPermissions()
        {
            int permissionCode = (int)Helpers.Permission.PhanQuyen; // permission code for managing permissions
            bool canAdd = SessionManager.HasPermission(permissionCode, Helpers.Action.Add);
            btnAddBookTitle.Visible = canAdd;

            bool canEdit = SessionManager.HasPermission(permissionCode, Helpers.Action.Edit);
            dgvUsersGroup.ShowEditButton = canEdit;

            bool canDelete = SessionManager.HasPermission(permissionCode, Helpers.Action.Delete);
            dgvUsersGroup.ShowDeleteButton = canDelete;

            if (!canEdit && !canDelete)
            {
                if (dgvUsersGroup.Columns.Contains("Actions"))
                    dgvUsersGroup.Columns["Actions"].Visible = false;
            }
        }

        private void btnAddBookTitle_Click(object sender, EventArgs e)
        {
            // Open the Permissions form in 'create new group' mode
            FrmPermissions frm = new FrmPermissions();
            frm.StartNewGroup();
            var res = frm.ShowDialog();
            if (res == DialogResult.OK)
            {
                // Refresh list after creating group and setting permissions
                list = BUS.NhomNguoiDungBUS.GetAllNhomNguoiDung();
                dgvUsersGroup.DataSource = list;
            }
        }

        private void EditButtonClicked(object? sender, int index)
        {
            NhomNguoiDungDTO? selected = list[index];
            if (selected != null)
            {
                FrmPermissions frm = new FrmPermissions();
                frm.LoadPermissions(selected);
                var result = frm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    list = BUS.NhomNguoiDungBUS.GetAllNhomNguoiDung();
                    dgvUsersGroup.DataSource = list;
                }
            }
        }

        private void DeleteButtonClicked(object? sender, int index)
        {
            NhomNguoiDungDTO? selected = list[index];
            if (selected == null) return;

            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa nhóm '{selected.TenNhom}' không? Tất cả quyền phân cho nhóm cũng sẽ bị xóa.", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            bool ok = BUS.NhomNguoiDungBUS.DeleteNhomNguoiDung(selected.ID);
            if (ok)
            {
                MessageBox.Show("Xóa nhóm thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                list = BUS.NhomNguoiDungBUS.GetAllNhomNguoiDung();
                dgvUsersGroup.DataSource = list;
            }
            else
            {
                MessageBox.Show("Không thể xóa nhóm. Có thể nhóm đang có người dùng hoặc xảy ra lỗi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewButtonClicked(object? sender, int index)
        {
            NhomNguoiDungDTO? selected = list[index];
            if (selected == null) return;

            FrmPermissions frm = new FrmPermissions();
            frm.LoadPermissions(selected);
            frm.SetReadOnlyMode();
            frm.ShowDialog();
        }
    }
}
