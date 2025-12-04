using BUS;
using DTO;
using System.ComponentModel;
using System.Data;

namespace GUI.Sach
{
    public partial class UCSach : UserControl
    {
        private BindingList<SachDTO> list;

        public UCSach()
        {
            InitializeComponent();
        }

        private void UCSach_Load(object sender, EventArgs e)
        {
            // 1. Cấu hình DataGridView
            dgvSach.AutoGenerateColumns = false;
            dgvSach.RowTemplate.Height = 35;

            // QUAN TRỌNG: Tắt nút Xóa trên giao diện Grid
            dgvSach.ShowDeleteButton = false; // (Nếu ActionDataGridView hỗ trợ thuộc tính này)
            // Hoặc bạn vào Designer chỉnh property ShowDeleteButton = False

            // 2. Load dữ liệu
            LoadData();

            // 3. Gán sự kiện (Chỉ còn Sửa và Xem)
            dgvSach.EditButtonClicked += EditButtonClicked;
            dgvSach.ViewButtonClicked += ViewButtonClicked;
        }

        private void LoadData()
        {
            list = SachBUS.GetAll();
            dgvSach.DataSource = list;
        }

        // --- KHÔNG CÓ NÚT THÊM ---
        // --- KHÔNG CÓ NÚT XÓA ---

        // Xử lý SỬA (Sửa thông tin: Giá, Năm XB, NXB)
        private void EditButtonClicked(object sender, int index)
        {
            if (index < 0 || index >= list.Count) return;

            SachDTO selected = list[index];

            // Mở form sửa (FrmEditSach)
            FrmEditSach frm = new FrmEditSach(selected);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData(); // Load lại sau khi sửa xong
            }
        }

        // Xử lý XEM CHI TIẾT (Quản lý các cuốn sách con CSxxxx)
        private void ViewButtonClicked(object sender, int index)
        {
            if (index < 0 || index >= list.Count) return;
            SachDTO selected = list[index];

            // Mở form chi tiết
            FrmChiTietCuonSach frm = new FrmChiTietCuonSach(selected);
            frm.ShowDialog();
        }

        // Tìm kiếm Live
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (list == null) return;
            string tuKhoa = txtTimKiem.Text.ToLower().Trim();

            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                dgvSach.DataSource = list;
                return;
            }

            // Lọc theo: Mã sách, Tên tựa sách, Tên NXB
            var ketQua = list.Where(s =>
                s.MaSach.ToLower().Contains(tuKhoa) ||
                s.TenTuaSach.ToLower().Contains(tuKhoa) ||
                s.TenNXB.ToLower().Contains(tuKhoa)
            ).ToList();

            dgvSach.DataSource = new BindingList<SachDTO>(ketQua);
        }
    }
}