using BUS;
using DTO;
using System.ComponentModel;
using System.Data;

namespace GUI.NhaXuatBan
{
    public partial class UCNhaXuatBan : UserControl
    {
        private BindingList<NhaXuatBanDTO> list;

        public UCNhaXuatBan()
        {
            InitializeComponent();
        }

        private void UCNhaXuatBan_Load(object sender, EventArgs e)
        {
            // Cấu hình hiển thị
            dgvNhaXuatBan.AutoGenerateColumns = false;
            dgvNhaXuatBan.RowTemplate.Height = 40;

            // Load dữ liệu từ BUS
            LoadData();

            // Gán sự kiện click (Sửa/Xóa/Xem)
            dgvNhaXuatBan.EditButtonClicked += EditButtonClicked;
            dgvNhaXuatBan.DeleteButtonClicked += DeleteButtonClicked;
            // dgvNhaXuatBan.ViewButtonClicked += ViewButtonClicked; (Nếu bạn làm nút Xem)
        }

        private void LoadData()
        {
            list = NhaXuatBanBUS.GetAll();
            dgvNhaXuatBan.DataSource = list;
        }

        // Xử lý nút THÊM
        private void btnThem_Click(object sender, EventArgs e)
        {
            FrmAddEditNhaXuatBan frm = new FrmAddEditNhaXuatBan();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData(); // Tải lại danh sách sau khi thêm
            }
        }

        // Xử lý nút SỬA
        private void EditButtonClicked(object sender, int index)
        {
            if (index < 0 || index >= list.Count) return;

            NhaXuatBanDTO selected = list[index];
            FrmAddEditNhaXuatBan frm = new FrmAddEditNhaXuatBan();
            frm.NXB = selected; // Truyền đối tượng cần sửa sang Form

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData(); // Tải lại danh sách sau khi sửa
            }
        }

        // Xử lý nút XÓA
        private void DeleteButtonClicked(object sender, int index)
        {
            if (index < 0 || index >= list.Count) return;

            NhaXuatBanDTO selected = list[index];
            if (MessageBox.Show($"Bạn có chắc muốn xóa NXB: {selected.TenNXB}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Gọi BUS để xóa
                    if (NhaXuatBanBUS.Delete(selected.ID))
                    {
                        list.RemoveAt(index); // Xóa trên lưới
                        MessageBox.Show("Xóa thành công.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Xử lý TÌM KIẾM (Live search)
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (list == null) return;

            string tuKhoa = txtTimKiem.Text.ToLower().Trim();

            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                dgvNhaXuatBan.DataSource = list;
                return;
            }

            // Lọc theo Tên NXB hoặc Địa chỉ
            var ketQua = list.Where(nxb =>
                nxb.TenNXB.ToLower().Contains(tuKhoa) ||
                (nxb.DiaChi != null && nxb.DiaChi.ToLower().Contains(tuKhoa))
            ).ToList();

            dgvNhaXuatBan.DataSource = new BindingList<NhaXuatBanDTO>(ketQua);
        }
    }
}