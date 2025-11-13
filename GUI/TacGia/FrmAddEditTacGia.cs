using DAO;
using DTO;
using GUI.Controls;
using System.Data;

namespace GUI.TacGia
{
    public partial class FrmAddEditTacGia : Form
    {
        private bool _isEditMode = false;
        private TacGiaDTO _tacgiaDTO;

        // Property để truyền DTO vào và lấy DTO ra
        public TacGiaDTO TacGia
        {
            get
            {
                // Lấy dữ liệu từ control
                _tacgiaDTO.TenTacGia = txtTenTacGia.Text.Trim();
                //_tacgiaDTO.MaTacGia = txtMaTacGia.Text;
                return _tacgiaDTO;
            }
            set
            {
                // Gán DTO vào control
                _tacgiaDTO = value;
                //txtMaTacGia.Text = _tacgiaDTO.MaTacGia;
                txtTenTacGia.Text = _tacgiaDTO.TenTacGia;
                _isEditMode = true;
            }
        }

        public FrmAddEditTacGia()
        {
            InitializeComponent();
            _tacgiaDTO = new TacGiaDTO("", ""); // Khởi tạo DTO rỗng
        }

        // Xử lý logic chính khi đóng form (bấm Lưu hoặc Thoát)
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Bước 1: Kiểm tra dữ liệu đầu vào
            if (!ValidateInputs())
            {
                return; // Nếu lỗi thì dừng lại, không làm gì cả
            }

            // Bước 2: Thực hiện Thêm hoặc Sửa
            // Hàm AddTheLoai/UpdateTheLoai của bạn đã có sẵn try-catch và MessageBox rồi
            bool success = _isEditMode ? UpdateTheLoai() : AddTheLoai();

            // Bước 3: Nếu thành công thì mới đóng Form và trả về OK
            if (success)
            {
                this.DialogResult = DialogResult.OK; // Dòng này báo cho Form cha biết là "Đã Lưu Xong"
                this.Close(); // Đóng form lại
            }
        }

        private void btnThoat_Click(object sender, EventArgs e) // (Nếu bạn có nút Thoát)
        {
            this.Close();
        }


        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtTenTacGia.Text))
            {
                MessageBox.Show("Tên tác giả không được để trống.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenTacGia.Focus();
                return false;
            }
            return true;
        }

        private bool AddTheLoai()
        {
            try
            {
                // Lấy DTO từ property (nó sẽ gọi 'get' block)
                var dto = this.TacGia;

                // Gọi BUS và nhận lại Mã mới
                string newMa = BUS.TacGiaBUS.Add(dto);
                if (string.IsNullOrEmpty(newMa))
                {
                    throw new Exception("Không nhận được mã tác giả sau khi thêm.");
                }

                // Cập nhật lại MaTheLoai cho DTO và control
                _tacgiaDTO.MaTacGia = newMa;
                //txtMaTacGia.Text = newMa;

                MessageBox.Show("Thêm tác giả thành công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool UpdateTheLoai()
        {
            try
            {
                // Lấy DTO từ property (nó sẽ gọi 'get' block)
                var dto = this.TacGia;

                // Gọi BUS
                BUS.TacGiaBUS.Update(dto);

                MessageBox.Show("Cập nhật tác giả thành công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void txtTenTheLoai_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenTacGia_TextChanged(object sender, EventArgs e)
        {

        }
    }
}