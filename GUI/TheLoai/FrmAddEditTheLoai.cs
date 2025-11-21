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
                //_theLoaiDTO.MaTheLoai = txtMaTheLoai.Text;
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

        private void FrmAddEditTheLoai_Load(object sender, EventArgs e)
        {
            // Kiểm tra: Nếu ô Mã đang trống (tức là đang THÊM MỚI)
            if (string.IsNullOrEmpty(txtMaTheLoai.Text))
            {
                try
                {
                    // Gọi BUS lấy mã mới và hiển thị lên màn hình
                    txtMaTheLoai.Text = BUS.TheLoaiBUS.GetNewMaTheLoai();

                    // Gán luôn vào DTO tạm thời (để không bị lỗi validate nếu có)
                    _theLoaiDTO.MaTheLoai = txtMaTheLoai.Text;

                    // Khóa ô mã lại không cho sửa (chỉ cho xem)
                    txtMaTheLoai.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lấy mã mới: " + ex.Message);
                }
            }
        }
    }
}