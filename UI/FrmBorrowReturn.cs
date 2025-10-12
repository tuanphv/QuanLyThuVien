using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using UI.Utilities;

namespace UI
{
    public partial class FrmBorrowReturn : Form
    {
        private readonly LoanBUS loanBUS = LoanBUS.Instance;
        private readonly BookBUS bookBUS = new BookBUS();

        public FrmBorrowReturn()
        {
            InitializeComponent();
            this.Load += FrmBorrowReturn_Load;
        }

        #region tab Borrow
        private void FrmBorrowReturn_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadLoanList();
        }

        //LOAD DỮ LIỆU
        private void LoadComboBoxes()
        {
            var readers = ReaderBUS.GetAllReaders();
            cbReader.DataSource = readers;
            cbReader.DisplayMember = "HoTen";
            cbReader.ValueMember = "MaDocGia";

            var books = bookBUS.GetAllBooks();
            cbBook.DataSource = books;
            cbBook.DisplayMember = "TieuDe";
            cbBook.ValueMember = "MaSach";
        }

        private void LoadLoanList()
        {
            dgvLoanList.DataSource = loanBUS.GetAllLoans();
            dgvLoanList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // TÌM KIẾM 
        private void btnSearchLoan_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchLoan.Text.Trim();
            var results = loanBUS.SearchLoans(keyword);

            dgvLoanList.DataSource = results;

            // Giữ lại tên cột hiển thị
            dgvLoanList.Columns["MaPhieuMuon"].HeaderText = "Mã Phiếu Mượn";
            dgvLoanList.Columns["MaDocGia"].HeaderText = "Mã Độc Giả";
            dgvLoanList.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
            dgvLoanList.Columns["NgayMuon"].HeaderText = "Ngày Mượn";
            dgvLoanList.Columns["HanTra"].HeaderText = "Hạn Trả";
            dgvLoanList.Columns["TrangThai"].HeaderText = "Trạng Thái";
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtSearchLoan.Clear();
            dgvLoanList.DataSource = loanBUS.GetAllLoans();
        }

        // CHỌN HÀNG TRONG DATAGRIDVIEW 
        private void dgvLoanList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvLoanList.Rows[e.RowIndex];
                cbReader.SelectedValue = row.Cells["MaDocGia"].Value;
                dtBorrowDate.Value = Convert.ToDateTime(row.Cells["NgayMuon"].Value);
                dtDueDate.Value = Convert.ToDateTime(row.Cells["HanTra"].Value);
            }
        }
        //  TẠO PHIẾU MƯỢN 
        private void btnCreateLoan_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbReader.SelectedValue == null || cbBook.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn độc giả và sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var loan = new LoanDTO
                {
                    MaDocGia = Convert.ToInt32(cbReader.SelectedValue),
                    MaNhanVien = SessionManager.CurrentUser?.MaNhanVien ?? 0,
                    NgayMuon = dtBorrowDate.Value,
                    HanTra = dtDueDate.Value,
                    TrangThai = "Đang mượn"
                };

                var detail = new LoanDetailDTO
                {
                    MaSach = Convert.ToInt32(cbBook.SelectedValue),
                    SoLuong = (int)numQuantity.Value
                };

                string message;
                bool success = loanBUS.AddLoan(loan, new List<LoanDetailDTO> { detail }, out message);

                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK,
                    success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (success)
                    LoadLoanList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo phiếu mượn: " + ex.Message);
            }
            #endregion

        }
    }
}
