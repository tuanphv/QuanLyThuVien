using DTO;
using DTO.Enums;
using QRCoder;
using UI.Utilities;
using UI.UICustom; // Add this for modern dialogs

namespace UI
{
    public partial class FrmReaders : Form
    {
        private FormMode currentMode = FormMode.None;
        public FrmReaders()
        {
            InitializeComponent();
        }

        private void FrmReaders_Load(object sender, EventArgs e)
        {
            LoadReaders();
        }

        private void LoadReaders()
        {
            var readers = BUS.ReaderBUS.GetAllReaders();
            dgvReaders.DataSource = null;
            dgvReaders.DataSource = readers;
        }

        private void LoadLibraryCards()
        {
            var libraryCards = BUS.LibraryCardBUS.GetAllLibraryCards();
            dgvLibraryCards.DataSource = null;
            dgvLibraryCards.DataSource = libraryCards;
        }

        private void dtgvReaders_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvReaders.ClearSelection();
            ClearInput();
        }

        private void tbcReaders_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = tbcReaders.SelectedIndex;
            if (index == 0)
            {
                LoadReaders();
            }
            else if (index == 1)
            {
                LoadLibraryCards();
            }
        }

        public static Bitmap GenerateQrBitmap(string text, int pixelsPerModule = 20)
        {
            using (var qrGenerator = new QRCodeGenerator())
            using (var qrData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q)) // ECCLevel: L, M, Q, H
            using (var qrCode = new QRCode(qrData))
            {
                return qrCode.GetGraphic(pixelsPerModule); // trả về Bitmap
            }
        }

        public static void DisplayQRCode(PictureBox pictureBox, string payload)
        {
            Bitmap bmp = GenerateQrBitmap(payload, 4); // điều chỉnh kích thước qua pixelsPerModule
            pictureBox.Image = bmp;

            // Lưu file PNG
            //bmp.Save("qrcode.png", System.Drawing.Imaging.ImageFormat.Png);
        }

        private void ClearInput()
        {

            foreach (Control control in pnlInput.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                }
                else if (control is DateTimePicker dateTimePicker)
                {
                    dateTimePicker.Format = DateTimePickerFormat.Custom;
                    dateTimePicker.CustomFormat = " ";
                    dateTimePicker.Value = DateTime.Now;
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.SelectedIndex = -1;
                }
            }
        }

        private void AllowEditing(bool allow)
        {
            txtFullName.ReadOnly = !allow;
            dtpDateOfBirth.Enabled = allow;
            cboGender.Enabled = allow;
            txtAddress.ReadOnly = !allow;
            txtEmail.ReadOnly = !allow;
            txtPhoneNumber.ReadOnly = !allow;
            dtpRegistrationDate.Enabled = allow;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                ModernToast.ShowWarning("Vui lòng nhập họ tên độc giả.");
                txtFullName.Focus();
                return false;
            }
            if (cboGender.SelectedIndex == -1)
            {
                ModernToast.ShowWarning("Vui lòng chọn giới tính.");
                cboGender.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                ModernToast.ShowWarning("Vui lòng nhập địa chỉ.");
                txtAddress.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                ModernToast.ShowWarning("Vui lòng nhập email.");
                txtEmail.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                ModernToast.ShowWarning("Vui lòng nhập số điện thoại.");
                txtPhoneNumber.Focus();
                return false;
            }
            return true;
        }

        private ReaderDTO GetReaderFromInput()
        {
            return new ReaderDTO
            {
                MaDocGia = int.Parse(txtReaderID.Text),
                HoTen = txtFullName.Text,
                NgaySinh = dtpDateOfBirth.Value,
                GioiTinh = cboGender.SelectedItem?.ToString() ?? string.Empty,
                DiaChi = txtAddress.Text,
                Email = txtEmail.Text,
                SoDienThoai = txtPhoneNumber.Text,
                NgayDangKy = dtpRegistrationDate.Value
            };
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearInput();
            dgvReaders.ClearSelection();
            dgvReaders.Enabled = false;
            dtpDateOfBirth.Format = DateTimePickerFormat.Short;
            dtpDateOfBirth.Value = DateTime.Now;
            dtpRegistrationDate.Format = DateTimePickerFormat.Short;
            dtpRegistrationDate.Value = DateTime.Now;
            AllowEditing(true);
            currentMode = FormMode.Add;
            ControlHelper.SetButtonsVisible(false, btnAdd, btnEdit, btnDelete);
            ControlHelper.SetButtonsVisible(true, btnSave, btnCancel);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvReaders.SelectedRows.Count == 0)
            {
                ModernToast.ShowWarning("Vui lòng chọn độc giả cần sửa.");
                return;
            }
            dgvReaders.Enabled = false;
            AllowEditing(true);
            currentMode = FormMode.Edit;
            ControlHelper.SetButtonsVisible(false, btnAdd, btnEdit, btnDelete);
            ControlHelper.SetButtonsVisible(true, btnSave, btnCancel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var reader = GetReaderFromInput();
            bool success = false;
            if (reader != null)
            {
                if (currentMode == FormMode.Add)
                {
                    success = BUS.ReaderBUS.AddReader(reader);
                }
                else if (currentMode == FormMode.Edit)
                {
                    success = BUS.ReaderBUS.UpdateReader(reader);
                }
            }
            if (success)
            {
                ModernToast.ShowSuccess("Lưu thông tin độc giả thành công.");
                LoadReaders();
            }
            else
            {
                ModernToast.ShowError("Lưu thông tin độc giả thất bại. Vui lòng kiểm tra lại dữ liệu nhập.");
                return; // Không thoát khỏi chế độ chỉnh sửa nếu lưu thất bại
            }
            dgvReaders.Enabled = true;
            AllowEditing(false);
            currentMode = FormMode.None;
            ControlHelper.SetButtonsVisible(true, btnAdd, btnEdit, btnDelete);
            ControlHelper.SetButtonsVisible(false, btnSave, btnCancel);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (currentMode == FormMode.Add)
            {
                ClearInput();
            }
            else if (currentMode == FormMode.Edit)
            {
                dgvReaders_SelectionChanged(null, null);
            }
            dgvReaders.Enabled = true;
            AllowEditing(false);
            currentMode = FormMode.None;
            ControlHelper.SetButtonsVisible(true, btnAdd, btnEdit, btnDelete);
            ControlHelper.SetButtonsVisible(false, btnSave, btnCancel);
        }

        private void dgvReaders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReaders.SelectedRows.Count > 0)
            {
                var selectedRow = dgvReaders.SelectedRows[0];
                var reader = (ReaderDTO)selectedRow.DataBoundItem;
                txtReaderID.Text = reader.MaDocGia.ToString();
                txtFullName.Text = reader.HoTen;
                dtpDateOfBirth.Format = DateTimePickerFormat.Short;
                dtpDateOfBirth.Value = reader.NgaySinh;
                cboGender.SelectedItem = reader.GioiTinh;
                txtAddress.Text = reader.DiaChi;
                txtEmail.Text = reader.Email;
                txtPhoneNumber.Text = reader.SoDienThoai;
                dtpRegistrationDate.Format = DateTimePickerFormat.Short;
                dtpRegistrationDate.Value = reader.NgayDangKy;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int maDocGia;
            if (int.TryParse(txtReaderID.Text, out maDocGia))
            {
                var result = ModernConfirmDialog.ShowDelete($"độc giả '{txtFullName.Text}'");
                if (result == DialogResult.Yes)
                {
                    bool success = BUS.ReaderBUS.DeleteReader(maDocGia);
                    if (success)
                    {
                        ModernToast.ShowSuccess("Xóa độc giả thành công.");
                        LoadReaders();
                    }
                    else
                    {
                        ModernToast.ShowError("Xóa độc giả thất bại.");
                    }
                }
            }
            else
            {
                ModernToast.ShowWarning("Vui lòng chọn độc giả cần xóa.");
            }
        }
    }
}
