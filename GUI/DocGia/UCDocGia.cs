using DTO;
using System.ComponentModel;

namespace GUI.DocGia
{
    public partial class UCDocGia : UserControl
    {
        private BindingList<DocGiaDTO> list;

        public UCDocGia()
        {
            InitializeComponent();
        }

        private void UCDocGia_Load(object sender, EventArgs e)
        {
            dgvDocGia.AutoGenerateColumns = false;

            // T?i d? li?u
            LoadData();

            // Gán s? ki?n cho các nút S?a/Xóa trong DataGridView
            dgvDocGia.EditButtonClicked += EditButtonClicked;
            dgvDocGia.DeleteButtonClicked += DeleteButtonClicked;
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
                MessageBox.Show("L?i khi t?i d? li?u: " + ex.Message, "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemDocGia_Click(object sender, EventArgs e)
        {
            FrmAddEditDocGia frm = new FrmAddEditDocGia();
            frm.Text = "Thêm ??c gi?";
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
            frm.Text = "Ch?nh s?a ??c gi?";
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

            var confirm = MessageBox.Show($"B?n có ch?c ch?n mu?n xóa ??c gi? '{selectedDocGia.HoTen}'?",
                "Xác nh?n xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
