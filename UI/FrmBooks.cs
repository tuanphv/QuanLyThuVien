using DTO;
using DTO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.UICustom;
using UI.Utilities;

namespace UI
{
    public partial class FrmBooks : Form
    {
        private FormMode currentMode = FormMode.None;
        public FrmBooks()
        {
            InitializeComponent();
        }

        private void FrmBooks_Load(object sender, EventArgs e)
        {
            LoadAllBooks();
        }

        private void LoadAllBooks()
        {
            dgvBooks.DataSource = null;
            dgvBooks.DataSource = BUS.BookBUS.GetAllBooks();
        }

        private void dgvBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0)
            {
                var selectedRow = dgvBooks.SelectedRows[0];
                txtBookID.Text = selectedRow.Cells["MaSach"].Value?.ToString() ?? string.Empty;
                txtTitle.Text = selectedRow.Cells["TieuDe"].Value?.ToString() ?? string.Empty;
                txtISBN.Text = selectedRow.Cells["ISBN"].Value?.ToString() ?? string.Empty;
                txtYearPublished.Text = selectedRow.Cells["NamXuatBan"].Value?.ToString() ?? string.Empty;
                txtPrice.Text = selectedRow.Cells["GiaSach"].Value?.ToString() ?? string.Empty;
                txtTotalQuantity.Text = selectedRow.Cells["SoLuongTong"].Value?.ToString() ?? string.Empty;
                txtAvailableQuantity.Text = selectedRow.Cells["SoLuongCon"].Value?.ToString() ?? string.Empty;
                txtPublisherId.Text = selectedRow.Cells["MaNXB"].Value?.ToString() ?? string.Empty;
                txtCategoryId.Text = selectedRow.Cells["MaTheLoai"].Value?.ToString() ?? string.Empty;
            }
        }

        private BookDTO GetBookFromInput()
        {
            return new BookDTO
            {
                MaSach = int.TryParse(txtBookID.Text, out int maSach) ? maSach : 0,
                TieuDe = txtTitle.Text,
                ISBN = txtISBN.Text,
                NamXuatBan = int.TryParse(txtYearPublished.Text, out int namXuatBan) ? namXuatBan : 0,
                GiaSach = decimal.TryParse(txtPrice.Text, out decimal giaSach) ? giaSach : 0,
                SoLuongTong = int.TryParse(txtTotalQuantity.Text, out int soLuongTong) ? soLuongTong : 0,
                SoLuongCon = int.TryParse(txtAvailableQuantity.Text, out int soLuongCon) ? soLuongCon : 0,
                MaNXB = int.TryParse(txtPublisherId.Text, out int maNXB) ? maNXB : 0,
                MaTheLoai = int.TryParse(txtCategoryId.Text, out int maTheLoai) ? maTheLoai : 0
            };
        }

        private void ClearInputFields()
        {
            TextBox[] textBoxes = {
                txtBookID, txtTitle, txtISBN, txtYearPublished,
                txtPrice, txtTotalQuantity, txtAvailableQuantity,
                txtPublisherId, txtCategoryId
            };

            ControlHelper.ClearTextBoxes(textBoxes);
        }

        private void AllowEditInputFields(bool allow)
        {
            TextBox[] textBoxes = {
                txtTitle, txtISBN, txtYearPublished,
                txtPrice, txtTotalQuantity, txtAvailableQuantity,
                txtPublisherId, txtCategoryId
            };
            ControlHelper.SetTextBoxesReadOnly(!allow, textBoxes);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            currentMode = FormMode.Add;
            dgvBooks.ClearSelection();
            dgvBooks.Enabled = false;
            ClearInputFields();
            AllowEditInputFields(true);
            txtTitle.Focus();
            ControlHelper.SetButtonsVisible(false, btnAdd, btnEdit, btnDelete);
            ControlHelper.SetButtonsVisible(true, btnSave, btnCancel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentMode == FormMode.Add)
            {
                BookDTO newBook = GetBookFromInput();
                bool success = BUS.BookBUS.AddBook(newBook);
                if (success)
                {
                    MessageBox.Show("Thêm sách thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AllowEditInputFields(false);
                    LoadAllBooks();
                }
                else
                {
                    MessageBox.Show("Thêm sách thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (currentMode == FormMode.Edit)
            {
                BookDTO updatedBook = GetBookFromInput();
                bool success = BUS.BookBUS.UpdateBook(updatedBook);
                if (success)
                {
                    MessageBox.Show("Cập nhật sách thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AllowEditInputFields(false);
                    LoadAllBooks();
                }
                else
                {
                    MessageBox.Show("Cập nhật sách thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            dgvBooks.Enabled = true;
            AllowEditInputFields(false);
            currentMode = FormMode.None;
            ControlHelper.SetButtonsVisible(true, btnAdd, btnEdit, btnDelete);
            ControlHelper.SetButtonsVisible(false, btnSave, btnCancel);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (currentMode == FormMode.Add)
            {
                ClearInputFields();
            }
            else if (currentMode == FormMode.Edit)
            {
                dgvBooks_SelectionChanged(null, null);
            }
            dgvBooks.Enabled = true;
            AllowEditInputFields(false);
            currentMode = FormMode.None;
            ControlHelper.SetButtonsVisible(true, btnAdd, btnEdit, btnDelete);
            ControlHelper.SetButtonsVisible(false, btnSave, btnCancel);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0)
            {
                ModernToast.ShowWarning("Vui lòng chọn độc giả cần sửa.");
                return;
            }
            currentMode = FormMode.Edit;
            dgvBooks.Enabled = false;
            AllowEditInputFields(true);
            txtTitle.Focus();
            ControlHelper.SetButtonsVisible(false, btnAdd, btnEdit, btnDelete);
            ControlHelper.SetButtonsVisible(true, btnSave, btnCancel);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int maSach;
            if (int.TryParse(txtBookID.Text, out maSach))
            {
                var result = ModernConfirmDialog.ShowDelete($"sách '{txtTitle.Text}'");
                if (result == DialogResult.Yes)
                {
                    bool success = BUS.BookBUS.DeleteBook(maSach);
                    if (success)
                    {
                        ModernToast.ShowSuccess("Xóa sách thành công.");
                        LoadAllBooks();
                    }
                    else
                    {
                        ModernToast.ShowError("Xóa sách thất bại.");
                    }
                }
            }
            else
            {
                ModernToast.ShowWarning("Vui lòng chọn sách cần xóa.");
            }
        }
    }
}
