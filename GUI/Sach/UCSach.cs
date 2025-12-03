// File: UCSach.cs (UserControl cho quản lý Sách, tương tự UCDocGia.cs)
using DTO;
using System;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using GUI.Helpers;

namespace GUI.Sach
{
    public partial class UCSach : UserControl
    {
        private BindingList<SachDTO> list;

        public UCSach()
        {
            InitializeComponent();
        }

        private void LoadPermissions()
        {
            int permissionCode = (int)Helpers.Permission.Sach; // Giả sử enum Permission.Sach = 2 hoặc tương tự
            bool canAdd = SessionManager.HasPermission(permissionCode, Helpers.Action.Add);
            btnThemSach.Visible = canAdd;

            bool canEdit = SessionManager.HasPermission(permissionCode, Helpers.Action.Edit);
            dgvSach.ShowEditButton = canEdit;

            bool canDelete = SessionManager.HasPermission(permissionCode, Helpers.Action.Delete);
            dgvSach.ShowDeleteButton = canDelete;

            if (!canEdit && !canDelete)
            {
                if (dgvSach.Columns.Contains("Actions"))
                    dgvSach.Columns["Actions"].Visible = false;
            }
        }

        private void UCSach_Load(object sender, EventArgs e)
        {
            dgvSach.AutoGenerateColumns = false;

            LoadData();

            dgvSach.EditButtonClicked += EditButtonClicked;
            dgvSach.DeleteButtonClicked += DeleteButtonClicked;

            // Apply permissions after DataGridView and its columns are ready
            LoadPermissions();
        }

        private void LoadData()
        {
            try
            {
                // Lấy dữ liệu từ BUS; đảm bảo chuyển sang BindingList để DataBinding hoạt động ổn định
                var all = BUS.SachBUS.GetAll(); // GetAll() nên trả về IEnumerable<SachDTO> / List<SachDTO> / BindingList<SachDTO>
                if (all is BindingList<SachDTO> bl)
                {
                    list = bl;
                }
                else if (all is IEnumerable<SachDTO> ie)
                {
                    list = new BindingList<SachDTO>(ie.ToList());
                }
                else
                {
                    list = new BindingList<SachDTO>();
                }

                dgvSach.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            FrmAddEditSach frm = new FrmAddEditSach();
            frm.Text = "Thêm sách";
            var result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                list.Add(frm.Sach);
            }
        }

        private void EditButtonClicked(object? sender, int index)
        {
            if (index < 0 || index >= list.Count) return;

            SachDTO selectedSach = list[index];

            FrmAddEditSach frm = new FrmAddEditSach();
            frm.Text = "Chỉnh sửa sách";
            frm.Sach = selectedSach;

            var result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                list[index] = frm.Sach;
            }
        }

        private void DeleteButtonClicked(object? sender, int index)
        {
            if (index < 0 || index >= list.Count) return;

            SachDTO selectedSach = list[index];

            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa sách '{selectedSach.TieuDe}'?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    if (BUS.SachBUS.Delete(selectedSach.MaSach))
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

            string tuKhoa = txtTimKiem.Text?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                dgvSach.DataSource = list;
                return;
            }

            // So sánh không phân biệt hoa thường và tránh NullReference nếu các trường null
            var danhSachLoc = list.Where(dto =>
                (!string.IsNullOrEmpty(dto.TieuDe) && dto.TieuDe.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0) ||
                (!string.IsNullOrEmpty(dto.ISBN) && dto.ISBN.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0)
            ).ToList();

            dgvSach.DataSource = new BindingList<SachDTO>(danhSachLoc);
        }
    }
}