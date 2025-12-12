using DTO;

namespace GUI.DocGia
{
    public partial class FrmAddEditDocGia : Form
    {
        private bool _isEditMode = false;
        private DocGiaDTO _docGiaDTO;

        public DocGiaDTO DocGia
        {
            get
            {
                _docGiaDTO.HoTen = txtHoTen.Text.Trim();
                _docGiaDTO.NgaySinh = dtpNgaySinh.Value;
                _docGiaDTO.NgayLapThe = dtpNgayLapThe.Value;
                _docGiaDTO.NgayHetHan = dtpNgayHetHan.Value;

                if (cboNguoiDung.SelectedValue != null && (int)cboNguoiDung.SelectedValue > 0)
                {
                    _docGiaDTO.IDNguoiDung = (int)cboNguoiDung.SelectedValue;
                }
                else
                {
                    _docGiaDTO.IDNguoiDung = null;
                }

                return _docGiaDTO;
            }
            set
            {
                _docGiaDTO = value;
                txtMaDocGia.Text = _docGiaDTO.MaDocGia;
                txtHoTen.Text = _docGiaDTO.HoTen;
                dtpNgaySinh.Value = _docGiaDTO.NgaySinh;
                dtpNgayLapThe.Value = _docGiaDTO.NgayLapThe;
                dtpNgayHetHan.Value = _docGiaDTO.NgayHetHan;
                txtTongNo.Text = _docGiaDTO.TongNoHienTai.ToString("N0");

                if (_docGiaDTO.IDNguoiDung.HasValue)
                {
                    cboNguoiDung.SelectedValue = _docGiaDTO.IDNguoiDung.Value;
                }

                _isEditMode = true;
            }
        }

        public FrmAddEditDocGia()
        {
            InitializeComponent();
            _docGiaDTO = new DocGiaDTO();
        }

        private void FrmAddEditDocGia_Load(object sender, EventArgs e)
        {
            LoadNguoiDung();

            if (string.IsNullOrEmpty(txtMaDocGia.Text))
            {
                try
                {
                    txtMaDocGia.Text = BUS.DocGiaBUS.GetNewMaDocGia();
                    _docGiaDTO.MaDocGia = txtMaDocGia.Text;
                    txtMaDocGia.Enabled = false;

                  
                    dtpNgayLapThe.Value = DateTime.Now;
                    dtpNgayHetHan.Value = DateTime.Now.AddMonths(6); 
                    txtTongNo.Text = "0";
                    txtTongNo.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lấy mã mới: " + ex.Message);
                }
            }
            else
            {
                txtTongNo.Enabled = false;
            }
        }

        private void LoadNguoiDung()
        {
            try
            {
                var listNguoiDung = BUS.DocGiaBUS.GetNguoiDungChuaLaDocGia();
                
                var emptyItem = new NguoiDungDTO();
                emptyItem.ID = 0;
                emptyItem.TenNguoiDung = "-- Không gán tài khoản --";
                listNguoiDung.Insert(0, emptyItem);

                cboNguoiDung.DataSource = listNguoiDung;
                cboNguoiDung.DisplayMember = "TenNguoiDung";
                cboNguoiDung.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải người dùng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }

            bool success = _isEditMode ? UpdateDocGia() : AddDocGia();

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
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoTen.Focus();
                return false;
            }

            if (dtpNgaySinh.Value >= DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không hợp lệ.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNgaySinh.Focus();
                return false;
            }

            // Ki?m tra tu?i
            int tuoi = DateTime.Now.Year - dtpNgaySinh.Value.Year;
            if (dtpNgaySinh.Value > DateTime.Now.AddYears(-tuoi)) tuoi--;

            if (tuoi < 18 || tuoi > 55)
            {
                MessageBox.Show("Tuổi của độc gia phải từ 18 đến 55.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNgaySinh.Focus();
                return false;
            }

            if (dtpNgayHetHan.Value <= dtpNgayLapThe.Value)
            {
                MessageBox.Show("Ngày hết hạn phải sau ngày lập thể.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNgayHetHan.Focus();
                return false;
            }

            return true;
        }

        private bool AddDocGia()
        {
            try
            {
                var dto = this.DocGia;
                string newMa = BUS.DocGiaBUS.Add(dto);

                if (string.IsNullOrEmpty(newMa))
                {
                    throw new Exception("Không nhận được mã tác giả sau khi thêm.");
                }

                _docGiaDTO.MaDocGia = newMa;
                txtMaDocGia.Text = newMa;

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

        private bool UpdateDocGia()
        {
            try
            {
                var dto = this.DocGia;
                BUS.DocGiaBUS.Update(dto);

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

        private void dtpNgayLapThe_ValueChanged(object sender, EventArgs e)
        {
            if (!_isEditMode)
            {
                dtpNgayHetHan.Value = dtpNgayLapThe.Value.AddMonths(6);
            }
        }
    }
}
