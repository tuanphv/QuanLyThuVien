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

namespace UI
{
    public partial class FrmReturn : Form
    {
        private readonly ReturnBUS returnBUS = new();
        private readonly LoanBUS loanBUS = LoanBUS.Instance;
        public FrmReturn()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            this.Load += FrmReturn_Load;
        }

        private void FrmReturn_Load(object sender, EventArgs e)
        {
            LoadLoanCombo();
            LoadReturnList();
            LoadUnreturnedLoans();
        }

        private void LoadUnreturnedLoans()
        {
            var unreturnedLoans = loanBUS.GetUnreturnedLoans();
            dgvReturnList.DataSource = unreturnedLoans;

            
            // Đổi tên cột (nếu cần)
            dgvReturnList.Columns["MaPhieuMuon"].HeaderText = "Mã Phiếu Mượn";
            dgvReturnList.Columns["MaDocGia"].HeaderText = "Mã Độc Giả";
            dgvReturnList.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
            dgvReturnList.Columns["NgayMuon"].HeaderText = "Ngày Mượn";
            dgvReturnList.Columns["HanTra"].HeaderText = "Hạn Trả";
            dgvReturnList.Columns["TrangThai"].HeaderText = "Trạng Thái";
        }

        private void LoadLoanCombo()
        {
            var loans = loanBUS.GetAllLoans()
                               .Where(x => x.TrangThai != "Đã trả")
                               .ToList();

            cbLoan.DataSource = loans;
            cbLoan.DisplayMember = "MaPhieuMuon";
            cbLoan.ValueMember = "MaPhieuMuon";
        }

        private void LoadReturnList()
        {
            dgvReturnList.DataSource = returnBUS.GetAllReturns();
            dgvReturnList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (cbLoan.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ret = new ReturnDTO
            {
                MaPhieuMuon = Convert.ToInt32(cbLoan.SelectedValue),
                NgayTra = dtReturnDate.Value,
                TinhTrangSach = txtBookCondition.Text,
                TienPhat = numFine.Value
            };

            if (returnBUS.AddReturn(ret, out string msg))
            {
                MessageBox.Show(msg, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadLoanCombo();
                LoadReturnList();
            }
            else
            {
                MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvReturnList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
