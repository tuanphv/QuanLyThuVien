namespace UI
{
    partial class FrmLoan
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dgvLoanList = new DataGridView();
            panel1 = new Panel();
            btnReturnBook = new Button();
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
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvLoanList).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvLoanList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            dgvLoanList.Size = new Size(603, 549);
            dgvLoanList.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Silver;
            panel1.Controls.Add(btnReturnBook);
            panel1.Controls.Add(btnCreateLoan);
            panel1.Controls.Add(numQuantity);
            panel1.Controls.Add(dtDueDate);
            panel1.Controls.Add(dtBorrowDate);
            panel1.Controls.Add(lblQuantity);
            panel1.Controls.Add(cbBook);
            panel1.Controls.Add(cbReader);
            panel1.Controls.Add(lblDueDate);
            panel1.Controls.Add(lblBorrowDate);
            panel1.Controls.Add(lblBook);
            panel1.Controls.Add(lblReader);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(603, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(350, 549);
            panel1.TabIndex = 1;
            // 
            // btnReturnBook
            // 
            btnReturnBook.BackColor = Color.FromArgb(255, 128, 0);
            btnReturnBook.Cursor = Cursors.Hand;
            btnReturnBook.FlatAppearance.BorderSize = 0;
            btnReturnBook.FlatStyle = FlatStyle.Flat;
            btnReturnBook.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReturnBook.ForeColor = Color.White;
            btnReturnBook.Location = new Point(203, 285);
            btnReturnBook.Name = "btnReturnBook";
            btnReturnBook.Size = new Size(114, 43);
            btnReturnBook.TabIndex = 14;
            btnReturnBook.Text = "Trả sách";
            btnReturnBook.UseVisualStyleBackColor = false;
            btnReturnBook.Click += btnReturnBook_Click_1;
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
            lblDueDate.Click += lblDueDate_Click;
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
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(panel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(953, 549);
            panel2.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(dgvLoanList);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(603, 549);
            panel3.TabIndex = 2;
            // 
            // FrmLoan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(953, 549);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmLoan";
            Text = "FrmLoan";
            ((System.ComponentModel.ISupportInitialize)dgvLoanList).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvLoanList;
        private Panel panel1;
        private Label lblDueDate;
        private Label lblBorrowDate;
        private Label lblBook;
        private Label lblReader;
        private NumericUpDown numQuantity;
        private DateTimePicker dtDueDate;
        private DateTimePicker dtBorrowDate;
        private Label lblQuantity;
        private ComboBox cbBook;
        private ComboBox cbReader;
        private Button btnReturnBook;
        private Button btnCreateLoan;
        private Panel panel2;
        private Panel panel3;
    }
}