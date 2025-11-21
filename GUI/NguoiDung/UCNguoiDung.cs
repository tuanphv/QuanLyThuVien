using DTO;
using System.ComponentModel;

namespace GUI.NguoiDung
{
    public partial class UCNguoiDung : UserControl
    {
        private BindingList<NguoiDungDTO> list;

        public UCNguoiDung()
        {
            InitializeComponent();
        }

        private void UCNguoiDung_Load(object sender, EventArgs e)
        {
            dgvNguoiDung.AutoGenerateColumns = false;

            // T?i d? li?u
            LoadData();

            // Gán s? ki?n cho các nút S?a/Xóa trong DataGridView
            dgvNguoiDung.EditButtonClicked += EditButtonClicked;
            dgvNguoiDung.DeleteButtonClicked += DeleteButtonClicked;
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
                MessageBox.Show("L?i khi t?i d? li?u: " + ex.Message, "L?i",
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
            frm.Text = "Ch?nh s?a Ng??i dùng";
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

            var confirm = MessageBox.Show($"B?n có ch?c ch?n mu?n xóa ng??i dùng '{selectedNguoiDung.TenNguoiDung}'?", 
                "Xác nh?n xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                    MessageBox.Show(ex.Message, "L?i",
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
