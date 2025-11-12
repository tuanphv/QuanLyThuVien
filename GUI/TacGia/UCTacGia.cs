using DAO;
using DTO;
using System.ComponentModel;
using System.Data;

namespace GUI.TacGia // (Hoặc namespace GUI.DanhMuc... của bạn)
{
    public partial class UCTacGia : UserControl
    {
        private BindingList<TacGiaDTO> list;

        public UCTacGia()
        {
            InitializeComponent();
        }

        private void UCTacGia_Load(object sender, EventArgs e)
        {
            dgvTacGia.AutoGenerateColumns = false;

            // Tải dữ liệu
            list = BUS.TacGiaBUS.GetAll();
            dgvTacGia.DataSource = list;

            // Gán sự kiện cho các nút Sửa/Xóa trong DataGridView
            dgvTacGia.EditButtonClicked += EditButtonClicked;
            dgvTacGia.DeleteButtonClicked += DeleteButtonClicked;
            dgvTacGia.ViewButtonClicked += ViewButtonClicked;
        }

        private void DgvTacGia_ViewButtonClicked(object? sender, int e)
        {
            throw new NotImplementedException();
        }

        private void btnThemTacGia_Click(object sender, EventArgs e)
        {
            FrmAddEditTacGia frm = new FrmAddEditTacGia();
            frm.Text = "Thêm Tác giả";
            var result = frm.ShowDialog();

            // Nếu Form thêm trả về OK, thêm DTO mới vào BindingList
            // BindingList sẽ tự động cập nhật DataGridView
            if (result == DialogResult.OK)
            {
                list.Add(frm.TacGia);
            }
        }

        private void EditButtonClicked(object? sender, int index)
        {
            if (index < 0 || index >= list.Count) return;

            // Lấy DTO từ BindingList
            TacGiaDTO selectedTacGia = list[index];

            // Mở Form ở chế độ Sửa
            FrmAddEditTacGia frm = new FrmAddEditTacGia();
            frm.Text = "Chỉnh sửa Tác giả";
            frm.TacGia = selectedTacGia; // Truyền DTO vào Form

            var result = frm.ShowDialog();

            // Nếu Form sửa trả về OK, cập nhật lại DTO trong BindingList
            if (result == DialogResult.OK)
            {
                list[index] = frm.TacGia; // DTO đã được cập nhật
            }
        }

        private void DeleteButtonClicked(object? sender, int index)
        {
            if (index < 0 || index >= list.Count) return;

            TacGiaDTO selectedTacGia = list[index];

            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa tác giả này?", "Xác nhận xóa",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    // Gọi BUS để xóa
                    if (BUS.TacGiaBUS.Delete(selectedTacGia.MaTacGia))
                    {
                        // Xóa khỏi BindingList, DataGridView tự cập nhật
                        list.RemoveAt(index);
                        MessageBox.Show("Xóa thành công.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    // Bắt lỗi nghiệp vụ (ví dụ: "Không thể xóa...")
                    MessageBox.Show(ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ViewButtonClicked(object? sender, int index)
        {
            if (index < 0 || index >= list.Count) return;

            // Lấy tác giả được chọn
            TacGiaDTO selectedTacGia = list[index];

            // Mở form danh sách sách, truyền Mã và Tên tác giả sang
            FrmDanhSachSachTheoTacGia frm = new FrmDanhSachSachTheoTacGia(
                selectedTacGia.MaTacGia,
                selectedTacGia.TenTacGia
            );

            frm.StartPosition = FormStartPosition.CenterParent; // Căn giữa cho đẹp
            frm.ShowDialog();
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {            
            if (list == null) return;

            // 1. Lấy từ khóa, chuyển về chữ thường và xóa khoảng trắng
            string tuKhoa = txtSearch.Text.ToLower().Trim();

            // 2. Nếu ô tìm kiếm trống, hiển thị lại TOÀN BỘ danh sách gốc
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                dgvTacGia.DataSource = list;
                return;
            }

            // 3. Nếu có từ khóa, dùng LINQ để lọc
            // Chúng ta lọc từ danh sách 'list' GỐC (đầy đủ tất cả thể loại)
            var danhSachLoc = list.Where(dto =>
                                    dto.TenTacGia.ToLower().Contains(tuKhoa) ||
                                    dto.MaTacGia.ToLower().Contains(tuKhoa)
                                 ).ToList(); // Chuyển kết quả lọc thành một List<> mới

            // 4. Tạo một BindingList MỚI từ danh sách đã lọc và gán lại cho DataGridView
            dgvTacGia.DataSource = new BindingList<TacGiaDTO>(danhSachLoc);
        }

    }
}