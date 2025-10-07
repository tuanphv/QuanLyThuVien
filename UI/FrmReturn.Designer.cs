namespace UI
{
    partial class FrmReturn
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
            dgvReturnList = new DataGridView();
            panel1 = new Panel();
            btnReturn = new Button();
            numFine = new NumericUpDown();
            txtBookCondition = new TextBox();
            dtReturnDate = new DateTimePicker();
            cbLoan = new ComboBox();
            lblFine = new Label();
            lblCondition = new Label();
            lblReturnDate = new Label();
            lblLoan = new Label();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvReturnList).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numFine).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvReturnList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            dgvReturnList.Size = new Size(450, 503);
            dgvReturnList.TabIndex = 0;
            dgvReturnList.CellContentClick += dgvReturnList_CellContentClick;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveBorder;
            panel1.Controls.Add(btnReturn);
            panel1.Controls.Add(numFine);
            panel1.Controls.Add(txtBookCondition);
            panel1.Controls.Add(dtReturnDate);
            panel1.Controls.Add(cbLoan);
            panel1.Controls.Add(lblFine);
            panel1.Controls.Add(lblCondition);
            panel1.Controls.Add(lblReturnDate);
            panel1.Controls.Add(lblLoan);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(450, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(350, 503);
            panel1.TabIndex = 1;
            // 
            // btnReturn
            // 
            btnReturn.BackColor = Color.FromArgb(0, 192, 0);
            btnReturn.Cursor = Cursors.Hand;
            btnReturn.FlatAppearance.BorderSize = 0;
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReturn.ForeColor = Color.White;
            btnReturn.Location = new Point(88, 253);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(162, 51);
            btnReturn.TabIndex = 8;
            btnReturn.Text = "Xác nhận trả";
            btnReturn.UseVisualStyleBackColor = false;
            btnReturn.Click += btnReturn_Click;
            // 
            // numFine
            // 
            numFine.DecimalPlaces = 2;
            numFine.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            numFine.Location = new Point(147, 179);
            numFine.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numFine.Name = "numFine";
            numFine.Size = new Size(150, 27);
            numFine.TabIndex = 7;
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
            // lblFine
            // 
            lblFine.AutoSize = true;
            lblFine.Location = new Point(19, 185);
            lblFine.Name = "lblFine";
            lblFine.Size = new Size(115, 20);
            lblFine.TabIndex = 3;
            lblFine.Text = "TIền phạt(VNĐ):";
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
            // panel2
            // 
            panel2.Controls.Add(dgvReturnList);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(450, 503);
            panel2.TabIndex = 2;
            // 
            // FrmReturn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 503);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "FrmReturn";
            Text = "FrmReturn";
            ((System.ComponentModel.ISupportInitialize)dgvReturnList).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numFine).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvReturnList;
        private Panel panel1;
        private Button btnReturn;
        private NumericUpDown numFine;
        private TextBox txtBookCondition;
        private DateTimePicker dtReturnDate;
        private ComboBox cbLoan;
        private Label lblFine;
        private Label lblCondition;
        private Label lblReturnDate;
        private Label lblLoan;
        private Panel panel2;
    }
}