using BUS;
using DTO;
using System.ComponentModel;
using System.Data;

namespace GUI.NhaCungCap
{
    public partial class UCNhaCungCap : UserControl
    {
        private BindingList<NhaCungCapDTO> list;

        public UCNhaCungCap()
        {
            InitializeComponent();
        }

        private void UCNhaCungCap_Load(object sender, EventArgs e)
        {
            dgvNhaCungCap.AutoGenerateColumns = false;
            dgvNhaCungCap.RowTemplate.Height = 40;

            LoadData();

            // Gán sự kiện
            dgvNhaCungCap.EditButtonClicked += EditButtonClicked;
            dgvNhaCungCap.DeleteButtonClicked += DeleteButtonClicked;
        }

        private void LoadData()
        {
            // Gọi BUS lấy toàn bộ danh sách
            list = NhaCungCapBUS.GetAll();
            dgvNhaCungCap.DataSource = list;
        }

        // Nút THÊM
        private void btnThem_Click(object sender, EventArgs e)
        {
            FrmAddEditNhaCungCap frm = new FrmAddEditNhaCungCap();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                list.Add(frm.NCC); // Cập nhật giao diện ngay lập tức
            }
        }

        // Nút SỬA (trong Grid)
        private void EditButtonClicked(object sender, int index)
        {
            if (index < 0 || index >= list.Count) return;

            NhaCungCapDTO selected = list[index];
            FrmAddEditNhaCungCap frm = new FrmAddEditNhaCungCap();
            frm.NCC = selected;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                dgvNhaCungCap.Refresh();
            }
        }

        // Nút XÓA (trong Grid)
        private void DeleteButtonClicked(object sender, int index)
        {
            if (index < 0 || index >= list.Count) return;

            NhaCungCapDTO selected = list[index];

            if (MessageBox.Show($"Bạn có chắc muốn xóa NCC: {selected.TenNCC}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    // Gọi BUS xóa
                    if (NhaCungCapBUS.Delete(selected.ID))
                    {
                        list.RemoveAt(index);
                        MessageBox.Show("Xóa thành công.");
                    }
                }
                catch (Exception ex)
                {
                    // Bắt lỗi nếu NCC đang có Phiếu Nhập
                    MessageBox.Show(ex.Message, "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // TÌM KIẾM Live (Theo Tên hoặc Địa chỉ)
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (list == null) return;
            string tuKhoa = txtTimKiem.Text.ToLower().Trim();

            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                dgvNhaCungCap.DataSource = list;
                return;
            }

            var ketQua = list.Where(ncc =>
                ncc.TenNCC.ToLower().Contains(tuKhoa) ||
                (ncc.DiaChi != null && ncc.DiaChi.ToLower().Contains(tuKhoa))
            ).ToList();

            dgvNhaCungCap.DataSource = new BindingList<NhaCungCapDTO>(ketQua);
        }
    }
}