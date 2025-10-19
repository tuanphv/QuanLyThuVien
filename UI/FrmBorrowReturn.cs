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
        private readonly ReturnBUS returnBUS = new ReturnBUS();
        private readonly FineBUS fineBUS = new FineBUS();

        public FrmBorrowReturn()
        {
            InitializeComponent();
            this.Load += FrmBorrowReturn_Load;
            txtSearchLoan.KeyDown += TxtSearch_KeyDown;
            txtSearchLoanReturn.KeyDown += TxtSearch_KeyDown;
            txtSearchFine.KeyDown += TxtSearch_KeyDown;
        }
        private void FrmBorrowReturn_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadLoanList();
            LoadReturnTab();
            LoadFineTab();
        }

        //LOAD DỮ LIỆU
        private void LoadComboBoxes()
        {
            var readers = ReaderBUS.GetAllReaders();
            cbReader.DataSource = readers;
            cbReader.DisplayMember = "HoTen";
            cbReader.ValueMember = "MaDocGia";

            var books = BookBUS.GetAllBooks();
            cbBook.DataSource = books;
            cbBook.DisplayMember = "TieuDe";
            cbBook.ValueMember = "MaSach";
        }

        #region tab Borrow

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

            LoadLoanList();
            LoadComboBoxes();

            cbReader.SelectedIndex = -1;
            cbBook.SelectedIndex = 1;
            dtBorrowDate.Value = DateTime.Now;
            dtDueDate.Value = DateTime.Now.AddDays(7);
            dgvLoanList.DataSource = loanBUS.GetAllLoans();
        }

        // CHỌN HÀNG TRONG DATAGRIDVIEW 
        private void dgvLoanList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLoanList.Rows[e.RowIndex];
                int maPhieuMuon = Convert.ToInt32(row.Cells["MaPhieuMuon"].Value);
                int maDocGia = Convert.ToInt32(row.Cells["MaDocGia"].Value);
                DateTime ngayMuon = Convert.ToDateTime(row.Cells["NgayMuon"].Value);
                DateTime hanTra = Convert.ToDateTime(row.Cells["HanTra"].Value);

                cbReader.SelectedValue = maDocGia;
                dtBorrowDate.Value = ngayMuon;
                dtDueDate.Value = hanTra;

                // Lấy thông tin sách từ ChiTietMuon
                var loanDetails = LoanDetailBUS.Instance.GetLoanDetailsByLoanId(maPhieuMuon);
                if (loanDetails.Count > 0)
                {
                    var first = loanDetails[0];
                    cbBook.SelectedValue = first.MaSach;
                    numQuantity.Value = first.SoLuong;
                }
                else
                {
                    cbBook.SelectedIndex = -1;
                    numQuantity.Value = 1;
                }
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
        }
        // XÓA PHIẾU MƯỢN
        private void btnDeleteLoan_Click(object sender, EventArgs e)
        {
            if (dgvLoanList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maPhieuMuon = Convert.ToInt32(dgvLoanList.SelectedRows[0].Cells["MaPhieuMuon"].Value);
            string trangThai = dgvLoanList.SelectedRows[0].Cells["TrangThai"].Value.ToString();

            if (!trangThai.Equals("Đang mượn", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Chỉ có thể xóa phiếu mượn đang trong trạng thái 'Đang mượn'!",
                    "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa phiếu mượn {maPhieuMuon} không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                bool result = loanBUS.DeleteLoan(maPhieuMuon);
                if (result)
                {
                    MessageBox.Show("Xóa phiếu mượn thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLoanList(); // cập nhật lại danh sách
                }
                else
                {
                    MessageBox.Show("Không thể xóa phiếu mượn này. Có thể phiếu đã trả hoặc có lỗi hệ thống.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region tab Return
        private void LoadReturnTab()
        {
            // Hiển thị danh sách phiếu mượn chưa trả
            dgvReturnList.DataSource = loanBUS.GetUnreturnedLoans();
            dgvReturnList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Hiển thị lịch sử phiếu trả
            dgvReturnHistory.DataSource = returnBUS.GetAllReturns();
            if (dgvReturnHistory.Columns.Contains("TienPhat"))
            {
                dgvReturnHistory.Columns["TienPhat"].Visible = false;
            }
            dgvReturnHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ClearReturnForm();
        }
        private void ClearReturnForm()
        {
            txtMaPhieuMuon.Clear(); // Dùng TextBox mới
            dtReturnDate.Value = DateTime.Now;
            cmbBookCondition.Text = "Tốt"; // Dùng ComboBox mới
        }

        private void btnConfirmReturn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPhieuMuon.Text))
            {
                MessageBox.Show("Vui lòng tìm và chọn một phiếu mượn để trả!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ret = new ReturnDTO
            {
                // Lấy từ TextBox
                MaPhieuMuon = Convert.ToInt32(txtMaPhieuMuon.Text),
                NgayTra = dtReturnDate.Value,
                TinhTrangSach = cmbBookCondition.Text // Lấy từ ComboBox mới
            };

            if (returnBUS.AddReturn(ret, out string msg))
            {
                MessageBox.Show(msg, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadReturnTab(); 
                LoadFineTab();   
            }
            else
            {
                MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // TÌM KIẾM PHIẾU TRẢ
        private void btnSearchLoanReturn_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchLoanReturn.Text.Trim(); 

            if (string.IsNullOrEmpty(keyword))
            {
                // Nếu ô tìm kiếm trống, tải lại toàn bộ danh sách chưa trả
                dgvReturnList.DataSource = loanBUS.GetUnreturnedLoans();
                return;
            }

            // Gọi hàm SearchUnreturnedLoans mới 
            var result = loanBUS.SearchUnreturnedLoans(keyword);
            dgvReturnList.DataSource = result; 

            if (result.Count == 0) 
            {
                MessageBox.Show("Không tìm thấy kết quả phù hợp.", "Kết quả tìm kiếm",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReloadReturn_Click(object sender, EventArgs e)
        {
            txtSearchLoanReturn.Clear(); 
            LoadReturnTab();
        }
        private void dgvReturnList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo nhấn vào một dòng hợp lệ
            {
                DataGridViewRow row = dgvReturnList.Rows[e.RowIndex];

                // Lấy MaPhieuMuon từ dòng được chọn
                string maPhieuMuonStr = row.Cells["MaPhieuMuon"].Value.ToString();
                int maPhieuMuon = Convert.ToInt32(maPhieuMuonStr);

                // Điền vào form bên phải
                txtMaPhieuMuon.Text = maPhieuMuonStr;
                dtReturnDate.Value = DateTime.Now;
                cmbBookCondition.Text = "Tốt"; // Đặt lại về mặc định
                try
                {
                    // Lấy chi tiết mượn
                    var loanDetails = LoanDetailBUS.Instance.GetLoanDetailsByLoanId(maPhieuMuon);

                    if (loanDetails.Count > 0)
                    {
                        // Chỉ lấy cuốn sách đầu tiên (giống Tab Mượn)
                        int maSach = loanDetails[0].MaSach;

                        // Lấy thông tin sách
                        var book = BookBUS.GetBookById(maSach); 
                        if (book != null)
                        {                      
                            txtTenSach.Text = book.TieuDe;
                        }
                        else
                        {
                            txtTenSach.Text = "Không tìm thấy sách";
                        }
                    }
                    else
                    {
                        txtTenSach.Text = "Không có chi tiết";
                    }
                }
                catch (Exception ex)
                {
                    txtTenSach.Text = "Lỗi";
                    MessageBox.Show("Lỗi khi lấy tên sách: " + ex.Message);
                }
            }
        }

        #endregion

        #region tab Fine
        private void LoadFineTab()
        {
            var fines = fineBUS.GetAllFines();
            dgvFineList.DataSource = fines;

            // Cấu hình hiển thị
            dgvFineList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFineList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvFineList.ReadOnly = true;
            dgvFineList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFineList.RowHeadersVisible = false;

            // Đặt tên cột
            dgvFineList.Columns["MaPhieuPhat"].HeaderText = "Mã Phiếu Phạt";
            dgvFineList.Columns["MaPhieuTra"].HeaderText = "Mã Phiếu Trả";
            dgvFineList.Columns["LyDo"].HeaderText = "Lý Do";
            dgvFineList.Columns["SoTien"].HeaderText = "Số Tiền (VNĐ)";
            dgvFineList.Columns["NgayLap"].HeaderText = "Ngày Lập";
        }

        private void btnSearchFine_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchFine.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = fineBUS.SearchFines(keyword);
            dgvFineList.DataSource = result;

            if (result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả phù hợp.", "Kết quả tìm kiếm",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReloadFine_Click(object sender, EventArgs e)
        {
            txtSearchFine.Clear();
            LoadFineTab();
        }

        #endregion

        #region event handler
        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn tiếng "ting"
                if (sender == txtSearchLoan)
                    btnSearchLoan.PerformClick();
               
                else if (sender == txtSearchLoanReturn) // Đổi từ txtSearchReturn
                    btnSearchLoanReturn.PerformClick(); // Đổi từ btnSearchReturn

                else if (sender == txtSearchFine)
                    btnSearchFine.PerformClick();
            }
        }
        #endregion

        #region hong có gì
        private void txtSearchReturn_TextChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void dgvReturnHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion   
        
    }
}
