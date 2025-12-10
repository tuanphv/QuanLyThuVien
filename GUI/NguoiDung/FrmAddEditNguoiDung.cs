using DTO;

namespace GUI.NguoiDung
{
    public partial class FrmAddEditNguoiDung : Form
    {
        private bool _isEditMode = false;
        private NguoiDungDTO _nguoiDungDTO;

        public NguoiDungDTO NguoiDung
        {
            get
            {
                _nguoiDungDTO.TenNguoiDung = txtTenNguoiDung.Text.Trim();
                _nguoiDungDTO.NgaySinh = dtpNgaySinh.Checked ? dtpNgaySinh.Value : (DateTime?)null;
                _nguoiDungDTO.TenDangNhap = txtTenDangNhap.Text.Trim();
                _nguoiDungDTO.MatKhau = txtMatKhau.Text.Trim();

                if (cboNhomNguoiDung.SelectedValue != null)
                {
                    _nguoiDungDTO.IDNhomNguoiDung = (int)cboNhomNguoiDung.SelectedValue;
                }

                return _nguoiDungDTO;
            }
            set
            {
                _nguoiDungDTO = value;
                txtMaNguoiDung.Text = _nguoiDungDTO.MaNguoiDung;
                txtTenNguoiDung.Text = _nguoiDungDTO.TenNguoiDung;

                if (_nguoiDungDTO.NgaySinh.HasValue)
                {
                    dtpNgaySinh.Value = _nguoiDungDTO.NgaySinh.Value;
                    dtpNgaySinh.Checked = true;
                }
                else
                {
                    dtpNgaySinh.Checked = false;
                }

                txtTenDangNhap.Text = _nguoiDungDTO.TenDangNhap;
                txtMatKhau.Text = _nguoiDungDTO.MatKhau;
                cboNhomNguoiDung.SelectedValue = _nguoiDungDTO.IDNhomNguoiDung;
                //cboNhomNguoiDung.DisplayMember = _nguoiDungDTO.TenNhomNguoiDung;
                _isEditMode = true;
            }
        }

        public FrmAddEditNguoiDung()
        {
            InitializeComponent();
            _nguoiDungDTO = new NguoiDungDTO();
        }

        private void FrmAddEditNguoiDung_Load(object sender, EventArgs e)
        {
      
            LoadNhomNguoiDung();

            if (string.IsNullOrEmpty(txtMaNguoiDung.Text))
            {
                try
                {
                    txtMaNguoiDung.Text = BUS.NguoiDungBUS.GetNewMaNguoiDung();
                    _nguoiDungDTO.MaNguoiDung = txtMaNguoiDung.Text;
                    txtMaNguoiDung.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lấy mã mới: " + ex.Message);
                }
            }
        }

        private void LoadNhomNguoiDung()
        {
            try
            {
                var listNhom = BUS.NhomNguoiDungBUS.GetAll();
                cboNhomNguoiDung.DataSource = listNhom;
                cboNhomNguoiDung.ValueMember = "ID";
                cboNhomNguoiDung.DisplayMember = "TenNhom";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải nhóm người dùng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }

            bool success = _isEditMode ? UpdateNguoiDung() : AddNguoiDung();

            if (success)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtTenNguoiDung.Text))
            {
                MessageBox.Show("Tên người dùng không được để trống.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenNguoiDung.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                MessageBox.Show("Tên đăng nhập không được để trống.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenDangNhap.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Focus();
                return false;
            }

            if (cboNhomNguoiDung.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhóm người dùng.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboNhomNguoiDung.Focus();
                return false;
            }

            return true;
        }

        private bool AddNguoiDung()
        {
            try
            {
                var dto = this.NguoiDung;
                string newMa = BUS.NguoiDungBUS.Add(dto);

                if (string.IsNullOrEmpty(newMa))
                {
                    throw new Exception("Không nhận được mã người dùng sau khi thêm.");
                }

                _nguoiDungDTO.MaNguoiDung = newMa;
                txtMaNguoiDung.Text = newMa;

                MessageBox.Show("Thêm người dùng thành công.", "Thông báo",
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

        private bool UpdateNguoiDung()
        {
            try
            {
                var dto = this.NguoiDung;
                BUS.NguoiDungBUS.Update(dto);

                MessageBox.Show("Cập nhật người dùng thành công.", "Thông báo",
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
