using DTO;
using DTO.Enums;
using UI.Utilities;
using UI.UICustom;
using System.ComponentModel;

namespace UI
{
    public partial class FrmReaders : Form
    {
        private BindingList<ReaderDTO> list = BUS.ReaderBUS.GetAllReaders();

        private FormMode currentMode = FormMode.None;
        public FrmReaders()
        {
            InitializeComponent();
        }

        private void FrmReaders_Load(object sender, EventArgs e)
        {
            LoadAllReadersData();
        }

        private void LoadAllReadersData()
        {
            dgvReaders.DataSource = list;
        }

        private void LoadAllLibraryCardsData()
        {
            var libraryCards = BUS.LibraryCardBUS.GetAllLibraryCards();
            dgvLibraryCards.DataSource = null;
            dgvLibraryCards.DataSource = libraryCards;
        }

        // Chuyển tab
        private void tbcReaders_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = tbcReaders.SelectedIndex;
            if (index == 0)
            {
                LoadAllReadersData();
            }
            else if (index == 1)
            {
                LoadAllLibraryCardsData();
            }
        }

        private void ClearInput(Panel panel)
        {

            foreach (Control control in panel.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                }
                else if (control is DateTimePicker dateTimePicker)
                {
                    dateTimePicker.Format = DateTimePickerFormat.Custom;
                    dateTimePicker.CustomFormat = " ";
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.SelectedIndex = -1;
                }
            }
        }

        #region Xử lí reader infomation form
        private bool ValidateInputReader()
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

        private bool ValidateInputLibraryCard()
        {
            int maDocGia;
            if (!int.TryParse(txtCardReaderID.Text, out maDocGia) || maDocGia <= 0)
            {
                ModernToast.ShowWarning("Vui lòng nhập mã độc giả hợp lệ.");
                txtCardReaderID.Focus();
                return false;
            }
            if (dtpIssueDate.Value == DateTime.MinValue || dtpIssueDate.Value > DateTime.Now)
            {
                ModernToast.ShowWarning("Vui lòng chọn ngày cấp hợp lệ.");
                dtpIssueDate.Focus();
                return false;
            }
            if (dtpExpiryDate.Value == DateTime.MinValue || dtpExpiryDate.Value <= dtpIssueDate.Value)
            {
                ModernToast.ShowWarning("Vui lòng chọn ngày hết hạn hợp lệ.");
                dtpExpiryDate.Focus();
                return false;
            }
            if (cboStatus.SelectedIndex == -1)
            {
                ModernToast.ShowWarning("Vui lòng chọn trạng thái thẻ.");
                cboStatus.Focus();
                return false;
            }
            return true;
        }

        private void AllowEditingInputReaderForm(bool allow)
        {
            txtFullName.ReadOnly = !allow;
            dtpDateOfBirth.Enabled = allow;
            cboGender.Enabled = allow;
            txtAddress.ReadOnly = !allow;
            txtEmail.ReadOnly = !allow;
            txtPhoneNumber.ReadOnly = !allow;
            dtpRegistrationDate.Enabled = allow;
        }

        private ReaderDTO GetReaderFromInput()
        {
            int maDocGia;
            if (!int.TryParse(txtReaderID.Text, out maDocGia))
                maDocGia = 0;
            return new ReaderDTO
            {
                MaDocGia = maDocGia,
                HoTen = txtFullName.Text,
                NgaySinh = dtpDateOfBirth.Value,
                GioiTinh = cboGender.SelectedItem?.ToString() ?? string.Empty,
                DiaChi = txtAddress.Text,
                Email = txtEmail.Text,
                SoDienThoai = txtPhoneNumber.Text,
                NgayDangKy = dtpRegistrationDate.Value
            };
        }
        #endregion

        #region Xử lí library card information form
        private void AllowEditingInputLibraryCardForm(bool allow)
        {
            txtCardReaderID.ReadOnly = !allow;
            dtpIssueDate.Enabled = allow;
            dtpExpiryDate.Enabled = allow;
            cboStatus.Enabled = allow;
        }

        private LibraryCardDTO GetLibraryCardFromInput()
        {
            int maThe, maDocGia;
            if (!int.TryParse(txtCardID.Text, out maThe))
                maThe = 0;
            return new LibraryCardDTO
            {
                MaThe = maThe,
                MaDocGia = int.Parse(txtCardReaderID.Text),
                NgayCap = dtpIssueDate.Value,
                NgayHetHan = dtpExpiryDate.Value,
                TrangThai = cboStatus.SelectedItem?.ToString() ?? string.Empty,
                QRCode = string.Empty // QRCode sẽ được tạo tự động khi thêm mới
            };
        }
        #endregion

        #region Xử lí data grid view
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

        private void dtgvReaders_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvReaders.ClearSelection();
            ClearInput(pnlReaderInput);
        }

        private void dgvLibraryCards_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLibraryCards.SelectedRows.Count > 0)
            {
                var selectedRow = dgvLibraryCards.SelectedRows[0];
                var card = (LibraryCardDTO)selectedRow.DataBoundItem;
                txtCardID.Text = card.MaThe.ToString();
                txtCardReaderID.Text = card.MaDocGia.ToString();
                dtpIssueDate.Format = DateTimePickerFormat.Short;
                dtpIssueDate.Value = card.NgayCap;
                dtpExpiryDate.Format = DateTimePickerFormat.Short;
                dtpExpiryDate.Value = card.NgayHetHan;
                cboStatus.SelectedItem = card.TrangThai;
                ControlHelper.DisplayQRCode(pctBoxQRCode, card.QRCode);
            }
        }

        private void dgvLibraryCards_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvLibraryCards.ClearSelection();
            ClearInput(pnlLibraryCardInput);
        }
        #endregion

        #region Xử lí nút cho form reader
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearInput(pnlReaderInput);
            dgvReaders.ClearSelection();
            dgvReaders.Enabled = false;
            dtpDateOfBirth.Format = DateTimePickerFormat.Short;
            dtpDateOfBirth.Value = DateTime.Now;
            dtpRegistrationDate.Format = DateTimePickerFormat.Short;
            dtpRegistrationDate.Value = DateTime.Now;
            AllowEditingInputReaderForm(true);
            currentMode = FormMode.Add;
            txtFullName.Focus();
            cboGender.SelectedIndex = 0;
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
            AllowEditingInputReaderForm(true);
            currentMode = FormMode.Edit;
            txtFullName.Focus();
            ControlHelper.SetButtonsVisible(false, btnAdd, btnEdit, btnDelete);
            ControlHelper.SetButtonsVisible(true, btnSave, btnCancel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputReader())
                return;
            var reader = GetReaderFromInput();
            int maDocGia = -1;
            bool success = false;
            if (reader != null)
            {
                if (currentMode == FormMode.Add)
                {
                    maDocGia = BUS.ReaderBUS.AddReader(reader);
                }
                else if (currentMode == FormMode.Edit)
                {
                    success = BUS.ReaderBUS.UpdateReader(reader);
                }
            }
            if (maDocGia != -1)
            {
                ModernToast.ShowSuccess("Thêm thông tin độc giả thành công.");
                reader.MaDocGia = maDocGia;
                list.Add(reader);
            }
            else if (success)
            {
                ModernToast.ShowSuccess("Chỉnh sửa thông tin độc giả thành công.");
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].MaDocGia == reader.MaDocGia)
                    {
                        list[i] = reader;
                        break;
                    }
                }
            }
            else
            {
                ModernToast.ShowError("Lưu thông tin độc giả thất bại. Vui lòng kiểm tra lại dữ liệu nhập.");
                return; // Không thoát khỏi chế độ chỉnh sửa nếu lưu thất bại
            }
            dgvReaders.Enabled = true;
            AllowEditingInputReaderForm(false);
            currentMode = FormMode.None;
            ControlHelper.SetButtonsVisible(true, btnAdd, btnEdit, btnDelete);
            ControlHelper.SetButtonsVisible(false, btnSave, btnCancel);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (currentMode == FormMode.Add)
            {
                ClearInput(pnlReaderInput);
            }
            else if (currentMode == FormMode.Edit)
            {
                dgvReaders_SelectionChanged(null, null);
            }
            dgvReaders.Enabled = true;
            AllowEditingInputReaderForm(false);
            currentMode = FormMode.None;
            ControlHelper.SetButtonsVisible(true, btnAdd, btnEdit, btnDelete);
            ControlHelper.SetButtonsVisible(false, btnSave, btnCancel);
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
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].MaDocGia == maDocGia)
                            {
                                list.RemoveAt(i);
                                break;
                            }
                        }
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
        #endregion

        #region Xử lí nút cho form library card
        private void btnAddCard_Click(object sender, EventArgs e)
        {
            ClearInput(pnlLibraryCardInput);
            pctBoxQRCode.Image = null;
            dgvLibraryCards.ClearSelection();
            dgvLibraryCards.Enabled = false;
            AllowEditingInputLibraryCardForm(true);
            dtpIssueDate.Format = DateTimePickerFormat.Short;
            dtpIssueDate.Value = DateTime.Now;
            dtpExpiryDate.Format = DateTimePickerFormat.Short;
            dtpExpiryDate.Value = DateTime.Now.AddYears(1);
            currentMode = FormMode.Add;
            txtCardReaderID.Focus();
            cboStatus.SelectedIndex = 0;
            ControlHelper.SetButtonsVisible(false, btnAddCard, btnEditCard, btnDeleteCard);
            ControlHelper.SetButtonsVisible(true, btnSaveCard, btnCancelCard);
        }

        private void btnEditCard_Click(object sender, EventArgs e)
        {
            if (dgvLibraryCards.SelectedRows.Count == 0)
            {
                ModernToast.ShowWarning("Vui lòng chọn thẻ thư viện cần sửa.");
                return;
            }
            dgvLibraryCards.Enabled = false;
            AllowEditingInputLibraryCardForm(true);
            currentMode = FormMode.Edit;
            txtCardReaderID.Focus();
            ControlHelper.SetButtonsVisible(false, btnAddCard, btnEditCard, btnDeleteCard);
            ControlHelper.SetButtonsVisible(true, btnSaveCard, btnCancelCard);
        }

        private void btnDeleteCard_Click(object sender, EventArgs e)
        {
            int maThe;
            if (int.TryParse(txtCardID.Text, out maThe))
            {
                var result = ModernConfirmDialog.ShowDelete($"thẻ thư viện '{txtCardID.Text}'");
                if (result == DialogResult.Yes)
                {
                    bool success = BUS.LibraryCardBUS.DeleteLibraryCard(maThe);
                    if (success)
                    {
                        ModernToast.ShowSuccess("Xóa thẻ thư viện thành công.");
                        LoadAllLibraryCardsData();
                    }
                    else
                    {
                        ModernToast.ShowError("Xóa thẻ thư viện thất bại.");
                    }
                }
            }
            else
            {
                ModernToast.ShowWarning("Vui lòng chọn thẻ thư viện cần xóa.");
            }
        }

        private void btnSaveCard_Click(object sender, EventArgs e)
        {
            if (!ValidateInputLibraryCard())
                return;
            var card = GetLibraryCardFromInput();
            bool success = false;
            if (card != null)
            {
                if (currentMode == FormMode.Add)
                {
                    success = BUS.LibraryCardBUS.AddLibraryCard(card);
                }
                else if (currentMode == FormMode.Edit)
                {

                    success = BUS.LibraryCardBUS.UpdateLibraryCard(card);
                }
            }
            if (success)
            {
                ModernToast.ShowSuccess("Lưu thông tin thẻ thư viện thành công.");
                LoadAllLibraryCardsData();
            }
            else
            {
                ModernToast.ShowError("Lưu thông tin thẻ thư viện thất bại. Vui lòng kiểm tra lại dữ liệu nhập.");
                return; // Không thoát khỏi chế độ chỉnh sửa nếu lưu thất bại
            }

            dgvLibraryCards.Enabled = true;
            AllowEditingInputLibraryCardForm(false);
            currentMode = FormMode.None;
            ControlHelper.SetButtonsVisible(true, btnAddCard, btnEditCard, btnDeleteCard);
            ControlHelper.SetButtonsVisible(false, btnSaveCard, btnCancelCard);
        }

        private void btnCancelCard_Click(object sender, EventArgs e)
        {
            if (currentMode == FormMode.Add)
            {
                ClearInput(pnlLibraryCardInput);
                pctBoxQRCode.Image = null;
            }
            else if (currentMode == FormMode.Edit)
            {
                dgvLibraryCards_SelectionChanged(null, null);
            }
            dgvLibraryCards.Enabled = true;
            AllowEditingInputLibraryCardForm(false);
            currentMode = FormMode.None;
            ControlHelper.SetButtonsVisible(true, btnAddCard, btnEditCard, btnDeleteCard);
            ControlHelper.SetButtonsVisible(false, btnSaveCard, btnCancelCard);
        }
        #endregion

        #region Xử lí tìm kiếm
        private void btnSearchReader_Click(object sender, EventArgs e)
        {
            if (!txtSearchReader.IsPlaceholderActive)
            {
                string text = txtSearchReader.Text;
                dgvReaders.DataSource = BUS.ReaderBUS.SearchReaders(list, text);
            }
            else
            {
                dgvReaders.DataSource = list;
            }
        }

        private void txtSearchReader_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchReader_Click(sender, e);
            }
        }


        private void btnSearchLibraryCard_Click(object sender, EventArgs e)
        {
            List<LibraryCardDTO> list;

            if (!txtSearchLibraryCard.IsPlaceholderActive)
            {
                string text = txtSearchLibraryCard.Text;
                list = BUS.LibraryCardBUS.SearchLibraryCards(text);
            }
            else
            {
                list = BUS.LibraryCardBUS.GetAllLibraryCards();
            }

            dgvLibraryCards.DataSource = list;
        }

        private void txtSearchLibraryCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchLibraryCard_Click(sender, e);
            }
        }
        #endregion

        #region Refresh datagridview
        private void btnReloadCards_Click(object sender, EventArgs e)
        {
            LoadAllLibraryCardsData();
            txtSearchLibraryCard.ResetPlaceholder();
        }

        private void btnReloadReaders_Click(object sender, EventArgs e)
        {
            txtSearchReader.ResetPlaceholder();
            LoadAllReadersData();
        }

        #endregion
    }
}
