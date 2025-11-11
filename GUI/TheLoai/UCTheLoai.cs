using DTO;
using System.ComponentModel;
using System.Data;

namespace GUI.TheLoai // (Hoặc namespace GUI.DanhMuc... của bạn)
{
    public partial class UCTheLoai : UserControl
    {
        private BindingList<TheLoaiDTO> list;

        public UCTheLoai()
        {
            InitializeComponent();
        }

        private void UCTheLoai_Load(object sender, EventArgs e)
        {
            dgvTheLoai.AutoGenerateColumns = false;

            // Tải dữ liệu
            list = BUS.TheLoaiBUS.GetAll();
            dgvTheLoai.DataSource = list;

            // Gán sự kiện cho các nút Sửa/Xóa trong DataGridView
            dgvTheLoai.EditButtonClicked += EditButtonClicked;
            dgvTheLoai.DeleteButtonClicked += DeleteButtonClicked;
        }

        private void btnThemTheLoai_Click(object sender, EventArgs e)
        {
            FrmAddEditTheLoai frm = new FrmAddEditTheLoai();
            frm.Text = "Thêm Thể loại";
            var result = frm.ShowDialog();

            // Nếu Form thêm trả về OK, thêm DTO mới vào BindingList
            // BindingList sẽ tự động cập nhật DataGridView
            if (result == DialogResult.OK)
            {
                list.Add(frm.TheLoai);
            }
        }

        private void EditButtonClicked(object? sender, int index)
        {
            if (index < 0 || index >= list.Count) return;

            // Lấy DTO từ BindingList
            TheLoaiDTO selectedTheLoai = list[index];

            // Mở Form ở chế độ Sửa
            FrmAddEditTheLoai frm = new FrmAddEditTheLoai();
            frm.Text = "Chỉnh sửa Thể loại";
            frm.TheLoai = selectedTheLoai; // Truyền DTO vào Form

            var result = frm.ShowDialog();

            // Nếu Form sửa trả về OK, cập nhật lại DTO trong BindingList
            if (result == DialogResult.OK)
            {
                list[index] = frm.TheLoai; // DTO đã được cập nhật
            }
        }

        private void DeleteButtonClicked(object? sender, int index)
        {
            if (index < 0 || index >= list.Count) return;

            TheLoaiDTO selectedTheLoai = list[index];

            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa thể loại này?", "Xác nhận xóa",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    // Gọi BUS để xóa
                    if (BUS.TheLoaiBUS.Delete(selectedTheLoai.MaTheLoai))
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

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            // 'list' là danh sách BindingList<TheLoaiDTO> gốc mà bạn đã tải lúc Load
            if (list == null) return;

            // 1. Lấy từ khóa, chuyển về chữ thường và xóa khoảng trắng
            string tuKhoa = txtTimKiem.Text.ToLower().Trim();

            // 2. Nếu ô tìm kiếm trống, hiển thị lại TOÀN BỘ danh sách gốc
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                dgvTheLoai.DataSource = list;
                return;
            }

            // 3. Nếu có từ khóa, dùng LINQ để lọc
            // Chúng ta lọc từ danh sách 'list' GỐC (đầy đủ tất cả thể loại)
            var danhSachLoc = list.Where(dto =>
                                    dto.TenTheLoai.ToLower().Contains(tuKhoa) ||
                                    dto.MaTheLoai.ToLower().Contains(tuKhoa)
                                 ).ToList(); // Chuyển kết quả lọc thành một List<> mới

            // 4. Tạo một BindingList MỚI từ danh sách đã lọc và gán lại cho DataGridView
            dgvTheLoai.DataSource = new BindingList<TheLoaiDTO>(danhSachLoc);
        }               
        
    }
}