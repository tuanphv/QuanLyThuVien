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
    public partial class FrmLoan : Form
    {
        public FrmLoan()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
        }
        private void FrmLoan_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();
            LoadLoanList();
        }

        private void LoadComboBoxData()
        {
            // Load data for readers
            List<ReaderDTO> readers = ReaderBUS.GetAllReaders();
            cbReader.DataSource = readers;
            cbReader.DisplayMember = "TenDocGia";
            cbReader.ValueMember = "MaDocGia";
            // Load data for books
            //var bookBUS = new BookBUS();
            //var books = bookBUS.GetAllBooks();
            //cbBook.DataSource = books;
            //cbBook.DisplayMember = "TenSach";
            //cbBook.ValueMember = "MaSach";
        }

        private void LoadLoanList()
        {
            //dgvLoanList.DataSource = LoanBUS.GetAllLoans();
        }

        private void lblDueDate_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateLoan_Click(object sender, EventArgs e)
        {
            
        }
    }
}
