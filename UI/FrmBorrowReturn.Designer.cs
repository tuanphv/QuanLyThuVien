namespace UI
{
    partial class FrmBorrowReturn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            tabBorrowReturn = new TabControl();
            tabPage1 = new TabPage();
            panel4 = new Panel();
            panel5 = new Panel();
            dgvLoanList = new DataGridView();
            panel3 = new Panel();
            btnDeleteLoan = new Button();
            btnCreateLoan = new Button();
            numQuantity = new NumericUpDown();
            dtDueDate = new DateTimePicker();
            dtBorrowDate = new DateTimePicker();
            lblQuantity = new Label();
            cbBook = new ComboBox();
            cbReader = new ComboBox();
            lblDueDate = new Label();
            lblBorrowDate = new Label();
            lblBook = new Label();
            lblReader = new Label();
            panel2 = new Panel();
            btnReloadLoan = new Button();
            btnSearchLoan = new Button();
            txtSearchLoan = new UI.UICustom.PlaceholderTextBox();
            panel1 = new Panel();
            lblTitle = new Label();
            tabPage2 = new TabPage();
            panel9 = new Panel();
            dgvReturnHistory = new DataGridView();
            panel8 = new Panel();
            panel13 = new Panel();
            btnReturn = new Button();
            txtBookCondition = new TextBox();
            dtReturnDate = new DateTimePicker();
            cbLoan = new ComboBox();
            lblCondition = new Label();
            lblReturnDate = new Label();
            lblLoan = new Label();
            panel14 = new Panel();
            dgvReturnList = new DataGridView();
            panel7 = new Panel();
            btnReloadReturn = new Button();
            btnSearchReturn = new Button();
            txtSearchReturn = new UI.UICustom.PlaceholderTextBox();
            panel6 = new Panel();
            label1 = new Label();
            tabPage3 = new TabPage();
            panel12 = new Panel();
            dgvFineList = new DataGridView();
            panel11 = new Panel();
            btnReloanFine = new Button();
            btnSearchFine = new Button();
            txtSearchFine = new UI.UICustom.PlaceholderTextBox();
            panel10 = new Panel();
            label2 = new Label();
            tabBorrowReturn.SuspendLayout();
            tabPage1.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLoanList).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            tabPage2.SuspendLayout();
            panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReturnHistory).BeginInit();
            panel8.SuspendLayout();
            panel13.SuspendLayout();
            panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReturnList).BeginInit();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            tabPage3.SuspendLayout();
            panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFineList).BeginInit();
            panel11.SuspendLayout();
            panel10.SuspendLayout();
            SuspendLayout();
            // 
            // tabBorrowReturn
            // 
            tabBorrowReturn.Controls.Add(tabPage1);
            tabBorrowReturn.Controls.Add(tabPage2);
            tabBorrowReturn.Controls.Add(tabPage3);
            tabBorrowReturn.Dock = DockStyle.Fill;
            tabBorrowReturn.Location = new Point(0, 0);
            tabBorrowReturn.Name = "tabBorrowReturn";
            tabBorrowReturn.SelectedIndex = 0;
            tabBorrowReturn.Size = new Size(1006, 860);
            tabBorrowReturn.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel4);
            tabPage1.Controls.Add(panel2);
            tabPage1.Controls.Add(panel1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(998, 827);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Mượn sách";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(panel5);
            panel4.Controls.Add(panel3);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 148);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(992, 676);
            panel4.TabIndex = 3;
            // 
            // panel5
            // 
            panel5.Controls.Add(dgvLoanList);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 0);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(642, 676);
            panel5.TabIndex = 2;
            // 
            // dgvLoanList
            // 
            dgvLoanList.AllowUserToAddRows = false;
            dgvLoanList.AllowUserToDeleteRows = false;
            dgvLoanList.AllowUserToResizeColumns = false;
            dgvLoanList.AllowUserToResizeRows = false;
            dgvLoanList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLoanList.BackgroundColor = Color.White;
            dgvLoanList.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvLoanList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvLoanList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLoanList.Dock = DockStyle.Fill;
            dgvLoanList.GridColor = Color.White;
            dgvLoanList.Location = new Point(0, 0);
            dgvLoanList.MultiSelect = false;
            dgvLoanList.Name = "dgvLoanList";
            dgvLoanList.ReadOnly = true;
            dgvLoanList.RowHeadersVisible = false;
            dgvLoanList.RowHeadersWidth = 51;
            dgvLoanList.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvLoanList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLoanList.ShowEditingIcon = false;
            dgvLoanList.Size = new Size(642, 676);
            dgvLoanList.TabIndex = 0;
            dgvLoanList.CellClick += dgvLoanList_CellClick;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Silver;
            panel3.Controls.Add(btnDeleteLoan);
            panel3.Controls.Add(btnCreateLoan);
            panel3.Controls.Add(numQuantity);
            panel3.Controls.Add(dtDueDate);
            panel3.Controls.Add(dtBorrowDate);
            panel3.Controls.Add(lblQuantity);
            panel3.Controls.Add(cbBook);
            panel3.Controls.Add(cbReader);
            panel3.Controls.Add(lblDueDate);
            panel3.Controls.Add(lblBorrowDate);
            panel3.Controls.Add(lblBook);
            panel3.Controls.Add(lblReader);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(642, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(350, 676);
            panel3.TabIndex = 1;
            // 
            // btnDeleteLoan
            // 
            btnDeleteLoan.BackColor = Color.FromArgb(255, 128, 0);
            btnDeleteLoan.Cursor = Cursors.Hand;
            btnDeleteLoan.FlatAppearance.BorderSize = 0;
            btnDeleteLoan.FlatStyle = FlatStyle.Flat;
            btnDeleteLoan.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteLoan.ForeColor = Color.White;
            btnDeleteLoan.Location = new Point(203, 285);
            btnDeleteLoan.Name = "btnDeleteLoan";
            btnDeleteLoan.Size = new Size(114, 43);
            btnDeleteLoan.TabIndex = 14;
            btnDeleteLoan.Text = "Xóa Phiếu";
            btnDeleteLoan.UseVisualStyleBackColor = false;
            btnDeleteLoan.Click += btnDeleteLoan_Click;
            // 
            // btnCreateLoan
            // 
            btnCreateLoan.BackColor = Color.FromArgb(0, 192, 0);
            btnCreateLoan.Cursor = Cursors.Hand;
            btnCreateLoan.FlatAppearance.BorderSize = 0;
            btnCreateLoan.FlatStyle = FlatStyle.Flat;
            btnCreateLoan.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateLoan.ForeColor = Color.White;
            btnCreateLoan.Location = new Point(32, 285);
            btnCreateLoan.Name = "btnCreateLoan";
            btnCreateLoan.Size = new Size(114, 43);
            btnCreateLoan.TabIndex = 13;
            btnCreateLoan.Text = "Tạo Phiếu";
            btnCreateLoan.UseVisualStyleBackColor = false;
            btnCreateLoan.Click += btnCreateLoan_Click;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(123, 203);
            numQuantity.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(74, 27);
            numQuantity.TabIndex = 11;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // dtDueDate
            // 
            dtDueDate.CustomFormat = "dd/MM/yyyy";
            dtDueDate.Format = DateTimePickerFormat.Short;
            dtDueDate.Location = new Point(123, 159);
            dtDueDate.Name = "dtDueDate";
            dtDueDate.Size = new Size(153, 27);
            dtDueDate.TabIndex = 10;
            // 
            // dtBorrowDate
            // 
            dtBorrowDate.CustomFormat = "dd/MM/yyyy";
            dtBorrowDate.Format = DateTimePickerFormat.Short;
            dtBorrowDate.Location = new Point(123, 117);
            dtBorrowDate.Name = "dtBorrowDate";
            dtBorrowDate.Size = new Size(153, 27);
            dtBorrowDate.TabIndex = 9;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(19, 209);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(72, 20);
            lblQuantity.TabIndex = 8;
            lblQuantity.Text = "Số lượng:";
            // 
            // cbBook
            // 
            cbBook.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBook.FormattingEnabled = true;
            cbBook.Location = new Point(123, 75);
            cbBook.Name = "cbBook";
            cbBook.Size = new Size(186, 28);
            cbBook.TabIndex = 7;
            // 
            // cbReader
            // 
            cbReader.DropDownStyle = ComboBoxStyle.DropDownList;
            cbReader.FormattingEnabled = true;
            cbReader.Location = new Point(123, 29);
            cbReader.Name = "cbReader";
            cbReader.Size = new Size(186, 28);
            cbReader.TabIndex = 6;
            // 
            // lblDueDate
            // 
            lblDueDate.AutoSize = true;
            lblDueDate.Location = new Point(19, 165);
            lblDueDate.Name = "lblDueDate";
            lblDueDate.Size = new Size(71, 20);
            lblDueDate.TabIndex = 5;
            lblDueDate.Text = "Ngày Trả:";
            // 
            // lblBorrowDate
            // 
            lblBorrowDate.AutoSize = true;
            lblBorrowDate.Location = new Point(19, 124);
            lblBorrowDate.Name = "lblBorrowDate";
            lblBorrowDate.Size = new Size(90, 20);
            lblBorrowDate.TabIndex = 4;
            lblBorrowDate.Text = "Ngày mượn:";
            // 
            // lblBook
            // 
            lblBook.AutoSize = true;
            lblBook.Location = new Point(17, 83);
            lblBook.Name = "lblBook";
            lblBook.Size = new Size(43, 20);
            lblBook.TabIndex = 3;
            lblBook.Text = "Sách:";
            // 
            // lblReader
            // 
            lblReader.AutoSize = true;
            lblReader.Location = new Point(17, 37);
            lblReader.Name = "lblReader";
            lblReader.Size = new Size(64, 20);
            lblReader.TabIndex = 2;
            lblReader.Text = "Độc giả:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightGray;
            panel2.Controls.Add(btnReloadLoan);
            panel2.Controls.Add(btnSearchLoan);
            panel2.Controls.Add(txtSearchLoan);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 83);
            panel2.Name = "panel2";
            panel2.Size = new Size(992, 65);
            panel2.TabIndex = 1;
            // 
            // btnReloadLoan
            // 
            btnReloadLoan.Anchor = AnchorStyles.Right;
            btnReloadLoan.BackColor = Color.Transparent;
            btnReloadLoan.FlatAppearance.BorderSize = 0;
            btnReloadLoan.FlatStyle = FlatStyle.Flat;
            btnReloadLoan.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReloadLoan.ForeColor = SystemColors.Window;
            btnReloadLoan.Image = Properties.Resources.refresh_icon;
            btnReloadLoan.Location = new Point(566, 16);
            btnReloadLoan.Margin = new Padding(3, 4, 3, 4);
            btnReloadLoan.Name = "btnReloadLoan";
            btnReloadLoan.Padding = new Padding(2, 3, 2, 3);
            btnReloadLoan.Size = new Size(32, 37);
            btnReloadLoan.TabIndex = 6;
            btnReloadLoan.UseVisualStyleBackColor = false;
            btnReloadLoan.Click += btnReload_Click;
            // 
            // btnSearchLoan
            // 
            btnSearchLoan.Anchor = AnchorStyles.Right;
            btnSearchLoan.BackColor = Color.DeepSkyBlue;
            btnSearchLoan.FlatAppearance.BorderSize = 0;
            btnSearchLoan.FlatStyle = FlatStyle.Flat;
            btnSearchLoan.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearchLoan.ForeColor = SystemColors.Window;
            btnSearchLoan.Location = new Point(452, 16);
            btnSearchLoan.Margin = new Padding(3, 4, 3, 4);
            btnSearchLoan.Name = "btnSearchLoan";
            btnSearchLoan.Size = new Size(103, 37);
            btnSearchLoan.TabIndex = 5;
            btnSearchLoan.Text = "Tìm kiếm";
            btnSearchLoan.UseVisualStyleBackColor = false;
            btnSearchLoan.Click += btnSearchLoan_Click;
            // 
            // txtSearchLoan
            // 
            txtSearchLoan.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSearchLoan.BorderStyle = BorderStyle.FixedSingle;
            txtSearchLoan.ForeColor = Color.Gray;
            txtSearchLoan.Location = new Point(18, 19);
            txtSearchLoan.Margin = new Padding(3, 4, 3, 4);
            txtSearchLoan.Name = "txtSearchLoan";
            txtSearchLoan.PlaceholderColor = Color.Gray;
            txtSearchLoan.PlaceholderText = "Nhập tên độc giả,tên sách, trạng thái...";
            txtSearchLoan.Size = new Size(411, 27);
            txtSearchLoan.TabIndex = 4;
            txtSearchLoan.Text = "Nhập tên độc giả,tên sách, trạng thái...";
            txtSearchLoan.TextColor = Color.Black;
            txtSearchLoan.Click += btnSearchLoan_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblTitle);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(992, 80);
            panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(5, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(261, 37);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "Quản lý Mượn sách";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel9);
            tabPage2.Controls.Add(panel8);
            tabPage2.Controls.Add(panel7);
            tabPage2.Controls.Add(panel6);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(998, 827);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Trả sách";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            panel9.Controls.Add(dgvReturnHistory);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(3, 550);
            panel9.Name = "panel9";
            panel9.Size = new Size(992, 274);
            panel9.TabIndex = 3;
            // 
            // dgvReturnHistory
            // 
            dgvReturnHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReturnHistory.Dock = DockStyle.Fill;
            dgvReturnHistory.Location = new Point(0, 0);
            dgvReturnHistory.Name = "dgvReturnHistory";
            dgvReturnHistory.RowHeadersWidth = 51;
            dgvReturnHistory.Size = new Size(992, 274);
            dgvReturnHistory.TabIndex = 0;
            dgvReturnHistory.CellContentClick += dgvReturnHistory_CellContentClick;
            // 
            // panel8
            // 
            panel8.Controls.Add(panel13);
            panel8.Controls.Add(panel14);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(3, 150);
            panel8.Name = "panel8";
            panel8.Size = new Size(992, 400);
            panel8.TabIndex = 2;
            // 
            // panel13
            // 
            panel13.BackColor = SystemColors.ActiveBorder;
            panel13.Controls.Add(btnReturn);
            panel13.Controls.Add(txtBookCondition);
            panel13.Controls.Add(dtReturnDate);
            panel13.Controls.Add(cbLoan);
            panel13.Controls.Add(lblCondition);
            panel13.Controls.Add(lblReturnDate);
            panel13.Controls.Add(lblLoan);
            panel13.Dock = DockStyle.Right;
            panel13.Location = new Point(642, 0);
            panel13.Name = "panel13";
            panel13.Size = new Size(350, 400);
            panel13.TabIndex = 3;
            // 
            // btnReturn
            // 
            btnReturn.BackColor = Color.FromArgb(0, 192, 0);
            btnReturn.Cursor = Cursors.Hand;
            btnReturn.FlatAppearance.BorderSize = 0;
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReturn.ForeColor = Color.White;
            btnReturn.Location = new Point(83, 210);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(162, 51);
            btnReturn.TabIndex = 8;
            btnReturn.Text = "Xác nhận trả";
            btnReturn.UseVisualStyleBackColor = false;
            btnReturn.Click += btnReturn_Click;
            // 
            // txtBookCondition
            // 
            txtBookCondition.BorderStyle = BorderStyle.FixedSingle;
            txtBookCondition.Location = new Point(147, 136);
            txtBookCondition.Name = "txtBookCondition";
            txtBookCondition.Size = new Size(151, 27);
            txtBookCondition.TabIndex = 6;
            // 
            // dtReturnDate
            // 
            dtReturnDate.Format = DateTimePickerFormat.Short;
            dtReturnDate.Location = new Point(147, 92);
            dtReturnDate.Name = "dtReturnDate";
            dtReturnDate.Size = new Size(114, 27);
            dtReturnDate.TabIndex = 5;
            // 
            // cbLoan
            // 
            cbLoan.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            cbLoan.FormattingEnabled = true;
            cbLoan.Location = new Point(147, 45);
            cbLoan.Name = "cbLoan";
            cbLoan.Size = new Size(151, 28);
            cbLoan.TabIndex = 4;
            cbLoan.Text = "Chọn phiếu mượn";
            // 
            // lblCondition
            // 
            lblCondition.AutoSize = true;
            lblCondition.Location = new Point(19, 143);
            lblCondition.Name = "lblCondition";
            lblCondition.Size = new Size(112, 20);
            lblCondition.TabIndex = 2;
            lblCondition.Text = "Tình trạng sách:";
            // 
            // lblReturnDate
            // 
            lblReturnDate.AutoSize = true;
            lblReturnDate.Location = new Point(19, 97);
            lblReturnDate.Name = "lblReturnDate";
            lblReturnDate.Size = new Size(69, 20);
            lblReturnDate.TabIndex = 1;
            lblReturnDate.Text = "Ngày trả:";
            // 
            // lblLoan
            // 
            lblLoan.AutoSize = true;
            lblLoan.Location = new Point(19, 49);
            lblLoan.Name = "lblLoan";
            lblLoan.Size = new Size(91, 20);
            lblLoan.TabIndex = 0;
            lblLoan.Text = "Phiếu mượn:";
            // 
            // panel14
            // 
            panel14.Controls.Add(dgvReturnList);
            panel14.Dock = DockStyle.Fill;
            panel14.Location = new Point(0, 0);
            panel14.Margin = new Padding(3, 4, 3, 4);
            panel14.Name = "panel14";
            panel14.Size = new Size(992, 400);
            panel14.TabIndex = 4;
            // 
            // dgvReturnList
            // 
            dgvReturnList.AllowUserToAddRows = false;
            dgvReturnList.AllowUserToDeleteRows = false;
            dgvReturnList.AllowUserToResizeColumns = false;
            dgvReturnList.AllowUserToResizeRows = false;
            dgvReturnList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReturnList.BackgroundColor = Color.White;
            dgvReturnList.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvReturnList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvReturnList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReturnList.Dock = DockStyle.Fill;
            dgvReturnList.GridColor = Color.White;
            dgvReturnList.Location = new Point(0, 0);
            dgvReturnList.MultiSelect = false;
            dgvReturnList.Name = "dgvReturnList";
            dgvReturnList.ReadOnly = true;
            dgvReturnList.RowHeadersVisible = false;
            dgvReturnList.RowHeadersWidth = 51;
            dgvReturnList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReturnList.Size = new Size(992, 400);
            dgvReturnList.TabIndex = 0;
            
            // 
            // panel7
            // 
            panel7.BackColor = Color.LightGray;
            panel7.Controls.Add(btnReloadReturn);
            panel7.Controls.Add(btnSearchReturn);
            panel7.Controls.Add(txtSearchReturn);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(3, 83);
            panel7.Name = "panel7";
            panel7.Size = new Size(992, 67);
            panel7.TabIndex = 1;
            // 
            // btnReloadReturn
            // 
            btnReloadReturn.Anchor = AnchorStyles.Right;
            btnReloadReturn.BackColor = Color.Transparent;
            btnReloadReturn.FlatAppearance.BorderSize = 0;
            btnReloadReturn.FlatStyle = FlatStyle.Flat;
            btnReloadReturn.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReloadReturn.ForeColor = SystemColors.Window;
            btnReloadReturn.Image = Properties.Resources.refresh_icon;
            btnReloadReturn.Location = new Point(567, 17);
            btnReloadReturn.Margin = new Padding(3, 4, 3, 4);
            btnReloadReturn.Name = "btnReloadReturn";
            btnReloadReturn.Padding = new Padding(2, 3, 2, 3);
            btnReloadReturn.Size = new Size(32, 37);
            btnReloadReturn.TabIndex = 6;
            btnReloadReturn.UseVisualStyleBackColor = false;
            btnReloadReturn.Click += btnReloadReturn_Click;
            // 
            // btnSearchReturn
            // 
            btnSearchReturn.Anchor = AnchorStyles.Right;
            btnSearchReturn.BackColor = Color.DeepSkyBlue;
            btnSearchReturn.FlatAppearance.BorderSize = 0;
            btnSearchReturn.FlatStyle = FlatStyle.Flat;
            btnSearchReturn.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearchReturn.ForeColor = SystemColors.Window;
            btnSearchReturn.Location = new Point(453, 17);
            btnSearchReturn.Margin = new Padding(3, 4, 3, 4);
            btnSearchReturn.Name = "btnSearchReturn";
            btnSearchReturn.Size = new Size(103, 37);
            btnSearchReturn.TabIndex = 5;
            btnSearchReturn.Text = "Tìm kiếm";
            btnSearchReturn.UseVisualStyleBackColor = false;
            btnSearchReturn.Click += btnSearchReturn_Click;
            // 
            // txtSearchReturn
            // 
            txtSearchReturn.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSearchReturn.BorderStyle = BorderStyle.FixedSingle;
            txtSearchReturn.ForeColor = Color.Gray;
            txtSearchReturn.Location = new Point(19, 20);
            txtSearchReturn.Margin = new Padding(3, 4, 3, 4);
            txtSearchReturn.Name = "txtSearchReturn";
            txtSearchReturn.PlaceholderColor = Color.Gray;
            txtSearchReturn.PlaceholderText = "Nhập mã phiếu trả ...";
            txtSearchReturn.Size = new Size(411, 27);
            txtSearchReturn.TabIndex = 4;
            txtSearchReturn.Text = "Nhập mã phiếu trả ...";
            txtSearchReturn.TextColor = Color.Black;
            txtSearchReturn.TextChanged += txtSearchReturn_TextChanged;
            // 
            // panel6
            // 
            panel6.Controls.Add(label1);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(3, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(992, 80);
            panel6.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(19, 21);
            label1.Name = "label1";
            label1.Size = new Size(224, 37);
            label1.TabIndex = 4;
            label1.Text = "Quản lý Trả sách";
            label1.Click += label1_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(panel12);
            tabPage3.Controls.Add(panel11);
            tabPage3.Controls.Add(panel10);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(998, 827);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Phiếu phạt";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel12
            // 
            panel12.Controls.Add(dgvFineList);
            panel12.Dock = DockStyle.Fill;
            panel12.Location = new Point(3, 150);
            panel12.Name = "panel12";
            panel12.Size = new Size(992, 674);
            panel12.TabIndex = 2;
            // 
            // dgvFineList
            // 
            dgvFineList.BackgroundColor = Color.White;
            dgvFineList.BorderStyle = BorderStyle.None;
            dgvFineList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFineList.Dock = DockStyle.Fill;
            dgvFineList.Location = new Point(0, 0);
            dgvFineList.Name = "dgvFineList";
            dgvFineList.RowHeadersWidth = 51;
            dgvFineList.Size = new Size(992, 674);
            dgvFineList.TabIndex = 0;
            // 
            // panel11
            // 
            panel11.BackColor = Color.LightGray;
            panel11.Controls.Add(btnReloanFine);
            panel11.Controls.Add(btnSearchFine);
            panel11.Controls.Add(txtSearchFine);
            panel11.Dock = DockStyle.Top;
            panel11.Location = new Point(3, 83);
            panel11.Name = "panel11";
            panel11.Size = new Size(992, 67);
            panel11.TabIndex = 1;
            // 
            // btnReloanFine
            // 
            btnReloanFine.Anchor = AnchorStyles.Right;
            btnReloanFine.BackColor = Color.Transparent;
            btnReloanFine.FlatAppearance.BorderSize = 0;
            btnReloanFine.FlatStyle = FlatStyle.Flat;
            btnReloanFine.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReloanFine.ForeColor = SystemColors.Window;
            btnReloanFine.Image = Properties.Resources.refresh_icon;
            btnReloanFine.Location = new Point(573, 19);
            btnReloanFine.Margin = new Padding(3, 4, 3, 4);
            btnReloanFine.Name = "btnReloanFine";
            btnReloanFine.Padding = new Padding(2, 3, 2, 3);
            btnReloanFine.Size = new Size(32, 37);
            btnReloanFine.TabIndex = 6;
            btnReloanFine.UseVisualStyleBackColor = false;
            btnReloanFine.Click += btnReloadFine_Click;
            // 
            // btnSearchFine
            // 
            btnSearchFine.Anchor = AnchorStyles.Right;
            btnSearchFine.BackColor = Color.DeepSkyBlue;
            btnSearchFine.FlatAppearance.BorderSize = 0;
            btnSearchFine.FlatStyle = FlatStyle.Flat;
            btnSearchFine.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearchFine.ForeColor = SystemColors.Window;
            btnSearchFine.Location = new Point(459, 19);
            btnSearchFine.Margin = new Padding(3, 4, 3, 4);
            btnSearchFine.Name = "btnSearchFine";
            btnSearchFine.Size = new Size(103, 37);
            btnSearchFine.TabIndex = 5;
            btnSearchFine.Text = "Tìm kiếm";
            btnSearchFine.UseVisualStyleBackColor = false;
            btnSearchFine.Click += btnSearchFine_Click;
            // 
            // txtSearchFine
            // 
            txtSearchFine.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSearchFine.BorderStyle = BorderStyle.FixedSingle;
            txtSearchFine.ForeColor = Color.Gray;
            txtSearchFine.Location = new Point(25, 22);
            txtSearchFine.Margin = new Padding(3, 4, 3, 4);
            txtSearchFine.Name = "txtSearchFine";
            txtSearchFine.PlaceholderColor = Color.Gray;
            txtSearchFine.PlaceholderText = "Nhập mã phiếu phạt, mã độc giả, tên độc giả ...";
            txtSearchFine.Size = new Size(411, 27);
            txtSearchFine.TabIndex = 4;
            txtSearchFine.Text = "Nhập mã phiếu phạt, mã độc giả, tên độc giả ...";
            txtSearchFine.TextColor = Color.Black;
            // 
            // panel10
            // 
            panel10.Controls.Add(label2);
            panel10.Dock = DockStyle.Top;
            panel10.Location = new Point(3, 3);
            panel10.Name = "panel10";
            panel10.Size = new Size(992, 80);
            panel10.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 17);
            label2.Name = "label2";
            label2.Size = new Size(259, 37);
            label2.TabIndex = 4;
            label2.Text = "Quản lý Phiếu phạt";
            // 
            // FrmBorrowReturn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 860);
            Controls.Add(tabBorrowReturn);
            Name = "FrmBorrowReturn";
            Text = "FrmBorrowReturn";
            tabBorrowReturn.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLoanList).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabPage2.ResumeLayout(false);
            panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReturnHistory).EndInit();
            panel8.ResumeLayout(false);
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            panel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReturnList).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            tabPage3.ResumeLayout(false);
            panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFineList).EndInit();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabBorrowReturn;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Panel panel2;
        private Panel panel1;
        private Label lblTitle;
        private Button btnReloadLoan;
        private Button btnSearchLoan;
        private UICustom.PlaceholderTextBox txtSearchLoan;
        private Panel panel4;
        private Panel panel5;
        private DataGridView dgvLoanList;
        private Panel panel7;
        private Panel panel6;
        private Button btnReloadReturn;
        private Button btnSearchReturn;
        private UICustom.PlaceholderTextBox txtSearchReturn;
        private Label label1;
        private Panel panel12;
        private Panel panel11;
        private Panel panel10;
        private Label label2;
        private DataGridView dgvFineList;
        private Button btnReloanFine;
        private Button btnSearchFine;
        private UICustom.PlaceholderTextBox txtSearchFine;
        private Panel panel3;
        private Button btnDeleteLoan;
        private Button btnCreateLoan;
        private NumericUpDown numQuantity;
        private DateTimePicker dtDueDate;
        private DateTimePicker dtBorrowDate;
        private Label lblQuantity;
        private ComboBox cbBook;
        private ComboBox cbReader;
        private Label lblDueDate;
        private Label lblBorrowDate;
        private Label lblBook;
        private Label lblReader;
        private Panel panel9;
        private Panel panel8;
        private DataGridView dgvReturnHistory;
        private Panel panel13;
        private Button btnReturn;
        private TextBox txtBookCondition;
        private DateTimePicker dtReturnDate;
        private ComboBox cbLoan;
        private Label lblCondition;
        private Label lblReturnDate;
        private Label lblLoan;
        private Panel panel14;
        private DataGridView dgvReturnList;
    }
}