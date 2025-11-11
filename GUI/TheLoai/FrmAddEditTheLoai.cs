using DTO;
using GUI.Controls;
using System.Data;

namespace GUI.TheLoai 
{
    public partial class FrmAddEditTheLoai : Form
    {
        private bool _isEditMode = false;
        private TheLoaiDTO _theLoaiDTO;

        // Property để truyền DTO vào và lấy DTO ra
        public TheLoaiDTO TheLoai
        {
            get
            {
                // Lấy dữ liệu từ control
                _theLoaiDTO.TenTheLoai = txtTenTheLoai.Text.Trim();
                _theLoaiDTO.MaTheLoai = txtMaTheLoai.Text; 
                return _theLoaiDTO;
            }
            set
            {
                // Gán DTO vào control
                _theLoaiDTO = value;
                txtMaTheLoai.Text = _theLoaiDTO.MaTheLoai;
                txtTenTheLoai.Text = _theLoaiDTO.TenTheLoai;
                _isEditMode = true; 
            }
        }

        public FrmAddEditTheLoai()
        {
            InitializeComponent();
            _theLoaiDTO = new TheLoaiDTO("", ""); // Khởi tạo DTO rỗng
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
            if (string.IsNullOrWhiteSpace(txtTenTheLoai.Text))
            {
                MessageBox.Show("Tên thể loại không được để trống.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenTheLoai.Focus();
                return false;
            }
            return true;
        }

        private bool AddTheLoai()
        {
            try
            {
                // Lấy DTO từ property (nó sẽ gọi 'get' block)
                var dto = this.TheLoai;

                // Gọi BUS và nhận lại Mã mới
                string newMa = BUS.TheLoaiBUS.Add(dto);
                if (string.IsNullOrEmpty(newMa))
                {
                    throw new Exception("Không nhận được mã thể loại sau khi thêm.");
                }

                // Cập nhật lại MaTheLoai cho DTO và control
                _theLoaiDTO.MaTheLoai = newMa;
                txtMaTheLoai.Text = newMa;

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
                var dto = this.TheLoai;

                // Gọi BUS
                BUS.TheLoaiBUS.Update(dto);

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
    }
}