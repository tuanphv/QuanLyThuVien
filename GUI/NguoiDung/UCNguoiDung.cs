using DTO;
using System.ComponentModel;
using GUI.Helpers;

namespace GUI.NguoiDung
{

    public partial class UCNguoiDung : UserControl
    {
        private bool _isLoaded = false;

        private BindingList<NguoiDungDTO> list;

        public UCNguoiDung()
        {
            InitializeComponent();
            this.VisibleChanged += UCNguoiDung_VisibleChanged;
        }

        private void LoadPermissions()
        {
            int permissionCode = (int)Helpers.Permission.NguoiDung;
            bool canAdd = SessionManager.HasPermission(permissionCode, Helpers.Action.Add);
            btnThemNguoiDung.Visible = canAdd;

            bool canEdit = SessionManager.HasPermission(permissionCode, Helpers.Action.Edit);
            dgvNguoiDung.ShowEditButton = canEdit;

            bool canDelete = SessionManager.HasPermission(permissionCode, Helpers.Action.Delete);
            dgvNguoiDung.ShowDeleteButton = canDelete;

            if (!canEdit && !canDelete)
            {
                if (dgvNguoiDung.Columns.Contains("Actions"))
                    dgvNguoiDung.Columns["Actions"].Visible = false;
            }
        }

        private void UCNguoiDung_Load(object sender, EventArgs e)
        {
            dgvNguoiDung.AutoGenerateColumns = false;

            // Tải dữ liệu
            LoadData();

            // Gán sự kiện cho các nút Sửa/Xóa trong DataGridView
            dgvNguoiDung.EditButtonClicked += EditButtonClicked;
            dgvNguoiDung.DeleteButtonClicked += DeleteButtonClicked;
            LoadPermissions();
            _isLoaded = true;
        }

        private void UCNguoiDung_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && _isLoaded)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            try
            {
                list = BUS.NguoiDungBUS.GetAll();
                dgvNguoiDung.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemNguoiDung_Click(object sender, EventArgs e)
        {
            FrmAddEditNguoiDung frm = new FrmAddEditNguoiDung();
            frm.Text = "Thêm Người dùng";
            var result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                list.Add(frm.NguoiDung);
            }
        }

        private void EditButtonClicked(object? sender, int index)
        {
            if (index < 0 || index >= list.Count) return;

            NguoiDungDTO selectedNguoiDung = list[index];

            FrmAddEditNguoiDung frm = new FrmAddEditNguoiDung();
            frm.Text = "Chỉnh sửa Người dùng";
            frm.NguoiDung = selectedNguoiDung;

            var result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                list[index] = frm.NguoiDung;
            }
        }

        private void DeleteButtonClicked(object? sender, int index)
        {
            if (index < 0 || index >= list.Count) return;

            NguoiDungDTO selectedNguoiDung = list[index];

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa người dùng '{selectedNguoiDung.TenNguoiDung}'?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    if (BUS.NguoiDungBUS.Delete(selectedNguoiDung.MaNguoiDung))
                    {
                        list.RemoveAt(index);
                        MessageBox.Show("Xóa thành công.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi",
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
                dgvNguoiDung.DataSource = list;
                return;
            }

            var danhSachLoc = list.Where(dto =>
                dto.TenNguoiDung.ToLower().Contains(tuKhoa) ||
                dto.MaNguoiDung.ToLower().Contains(tuKhoa) ||
                dto.TenDangNhap.ToLower().Contains(tuKhoa) ||
                (dto.ChucVu != null && dto.ChucVu.ToLower().Contains(tuKhoa)) ||
                (dto.TenNhomNguoiDung != null && dto.TenNhomNguoiDung.ToLower().Contains(tuKhoa))
            ).ToList();

            dgvNguoiDung.DataSource = new BindingList<NguoiDungDTO>(danhSachLoc);
        }
    }
}
