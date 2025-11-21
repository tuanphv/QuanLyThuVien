using DTO;
using System.ComponentModel;

namespace GUI.PhanQuyen
{
    public partial class FrmPermissions : Form
    {
        BindingList<PhanQuyenDTO>? permissionsList;
        private NhomNguoiDungDTO? currentGroup;

        public FrmPermissions()
        {
            InitializeComponent();
            dgvPermissions.AutoGenerateColumns = false;
            permissionsList = new BindingList<PhanQuyenDTO>(BUS.PhanQuyenBUS.GetPermissionsByGroupId(0));
            dgvPermissions.DataSource = permissionsList;

            btnSave.Click += BtnSave_Click;
        }

        /// <summary>
        /// Put the form into a read-only/view-only mode: hide Save, make grid read-only and adjust UI.
        /// </summary>
        public void SetReadOnlyMode()
        {
            btnSave.Visible = false;
            // Ensure the group name textbox is not editable/visible when viewing
            txtUserGroupName.Visible = false;
            // Make grid read-only to prevent editing checkboxes
            dgvPermissions.ReadOnly = true;
            // Change cancel button text to Close for clarity
            btnCancel.Text = "Đóng";
        }

        /// <summary>
        /// Prepare the form to create a new user group. Shows the group name textbox for input
        /// and initializes permissions with default values (no permissions granted).
        /// </summary>
        public void StartNewGroup()
        {
            currentGroup = null;
            txtUserGroupName.Visible = true;
            txtUserGroupName.Text = string.Empty;
            this.Text = "Thêm nhóm người dùng mới";

            // Initialize permissions list from functions; by using groupId=0 we expect GetPermissionsByGroupId to return all functions with no permissions
            var perms = BUS.PhanQuyenBUS.GetPermissionsByGroupId(0);
            permissionsList = new BindingList<PhanQuyenDTO>(perms);
            dgvPermissions.DataSource = permissionsList;

            // Ensure editable mode
            btnSave.Visible = true;
            dgvPermissions.ReadOnly = false;
            btnCancel.Text = "Hủy";
        }

        public void LoadPermissions(NhomNguoiDungDTO nnd)
        {
            try
            {
                currentGroup = nnd;
                var permissions = BUS.PhanQuyenBUS.GetPermissionsByGroupId(nnd.ID);
                permissionsList = new BindingList<PhanQuyenDTO>(permissions);
                dgvPermissions.DataSource = permissionsList;

                // Cập nhật tiêu đề form
                this.Text = $"Phân quyền cho nhóm: {nnd.TenNhom}";
                lbUserGroupName.Text = $"Tên nhóm: {nnd.TenNhom}";
                lbTotalUser.Text = $"Tổng số người dùng: {nnd.TongSoNguoi}";
                txtUserGroupName.Visible = false;

                // Ensure editable mode by default when loading for edit
                btnSave.Visible = true;
                dgvPermissions.ReadOnly = false;
                btnCancel.Text = "Hủy";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải quyền: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            // If currentGroup is null, we are creating a new group
            if (currentGroup == null)
            {
                string ten = txtUserGroupName?.Text.Trim() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(ten))
                {
                    MessageBox.Show("Tên nhóm không được rỗng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create group and get generated MaNhom
                var generatedMa = BUS.NhomNguoiDungBUS.AddNhomNguoiDung(ten);
                if (string.IsNullOrEmpty(generatedMa))
                {
                    MessageBox.Show("Tạo nhóm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Retrieve full DTO by MaNhom
                var createdDto = BUS.NhomNguoiDungBUS.GetNhomByMaNhom(generatedMa);
                if (createdDto == null)
                {
                    MessageBox.Show("Không lấy được thông tin nhóm vừa tạo.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                currentGroup = createdDto;
            }

            if (currentGroup == null)
            {
                MessageBox.Show("Không có nhóm để lưu quyền.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Collect current permission states from the binding list
            var listToSave = permissionsList?.ToList() ?? new List<PhanQuyenDTO>();

            bool ok = BUS.PhanQuyenBUS.UpdatePermissions(currentGroup.ID, listToSave);
            if (ok)
            {
                MessageBox.Show("Lưu quyền thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Lưu quyền thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmPermissions_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Cancel)
            {
                var confirm = MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
