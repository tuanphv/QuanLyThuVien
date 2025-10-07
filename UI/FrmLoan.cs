using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Utilities;

namespace UI
{
    public partial class FrmLoan : Form
    {
        private readonly LoanBUS loanBUS = LoanBUS.Instance;
        public FrmLoan()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            this.Load += FrmLoan_Load;
        }
        private void FrmLoan_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();
            LoadLoanList();
            LoadUnreturnedLoans();
        }

        private void LoadUnreturnedLoans()
        {
            var unreturnedLoans = loanBUS.GetUnreturnedLoans();
            dgvLoanList.DataSource = unreturnedLoans;

            // Cấu hình hiển thị DataGridView
            //dgvLoanList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //dgvLoanList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //dgvLoanList.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Đổi tên cột (nếu cần)
            dgvLoanList.Columns["MaPhieuMuon"].HeaderText = "Mã Phiếu Mượn";
            dgvLoanList.Columns["MaDocGia"].HeaderText = "Mã Độc Giả";
            dgvLoanList.Columns["NgayMuon"].HeaderText = "Ngày Mượn";
            dgvLoanList.Columns["HanTra"].HeaderText = "Hạn Trả";
            dgvLoanList.Columns["TrangThai"].HeaderText = "Trạng Thái";
        }

        private void LoadComboBoxData()
        {
            // Load data for readers
            var readers = ReaderBUS.GetAllReaders();
            cbReader.DataSource = readers;
            cbReader.DisplayMember = "HoTen";
            cbReader.ValueMember = "MaDocGia";
            // Load data for books
            var bookBUS = new BookBUS();
            var books = bookBUS.GetAllBooks();
            cbBook.DataSource = books;
            cbBook.DisplayMember = "TieuDe";
            cbBook.ValueMember = "MaSach";
        }

        private void LoadLoanList()
        {
            var loans = LoanBUS.Instance.GetAllLoans();
            dgvLoanList.DataSource = loans;
            dgvLoanList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void lblDueDate_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateLoan_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbReader.SelectedValue == null || cbBook.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn độc giả và sách!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                bool success = LoanBUS.Instance.AddLoan(loan, new List<LoanDetailDTO> { detail }, out message);

                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK,
                    success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (success)
                    LoadLoanList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo phiếu mượn: " + ex.Message);
            }
        }        

        private void btnReturnBook_Click_1(object sender, EventArgs e)
        {
            // Gọi form trả sách
            FrmReturn frmReturn = new FrmReturn();
            frmReturn.TopLevel = false;
            frmReturn.FormBorderStyle = FormBorderStyle.None;
            frmReturn.Dock = DockStyle.Fill;

            // Thêm vào panel chính hoặc container hiển thị form (không phải panel1)
            var parent = this.Parent as Panel; // hoặc container nào bạn đang dùng
            if (parent != null)
            {
                parent.Controls.Clear();
                parent.Controls.Add(frmReturn);
                frmReturn.Show();
            }
        }
    }
}
