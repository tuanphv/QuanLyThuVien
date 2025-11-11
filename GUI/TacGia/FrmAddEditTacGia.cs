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
                _tacgiaDTO.MaTacGia = txtMaTacGia.Text;
                return _tacgiaDTO;
            }
            set
            {
                // Gán DTO vào control
                _tacgiaDTO = value;
                txtMaTacGia.Text = _tacgiaDTO.MaTacGia;
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
        private void FrmAddEditTheLoai_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Cancel)
            {
                // Không cần làm gì nếu bấm Thoát
                return;
            }

            if (this.DialogResult == DialogResult.OK)
            {
                // Nếu bấm Lưu, kiểm tra dữ liệu
                if (!ValidateInputs())
                {
                    e.Cancel = true; // Hủy việc đóng Form
                    this.DialogResult = DialogResult.None; // Reset DialogResult
                    return;
                }

                // Thực hiện nghiệp vụ Add hoặc Update
                bool success = _isEditMode ? UpdateTheLoai() : AddTheLoai();
                if (!success)
                {
                    e.Cancel = true; // Hủy việc đóng Form nếu lỗi
                    this.DialogResult = DialogResult.None;
                }
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtTenTacGia.Text))
            {
                MessageBox.Show("Tên thể loại không được để trống.", "Lỗi",
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
                    throw new Exception("Không nhận được mã thể loại sau khi thêm.");
                }

                // Cập nhật lại MaTheLoai cho DTO và control
                _tacgiaDTO.MaTacGia = newMa;
                txtMaTacGia.Text = newMa;

                MessageBox.Show("Thêm thể loại thành công.", "Thông báo",
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

                MessageBox.Show("Cập nhật thể loại thành công.", "Thông báo",
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
    }
}