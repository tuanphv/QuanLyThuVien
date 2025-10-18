namespace UI
{
    partial class FrmBooks
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel4 = new Panel();
            label1 = new Label();
            lblTitle = new Label();
            panel1 = new Panel();
            panel5 = new Panel();
            btnRefresh = new Button();
            btnReloadReaders = new Button();
            btnSearch = new Button();
            btnSearchReader = new Button();
            txtSearch = new UI.UICustom.PlaceholderTextBox();
            dgvBooks = new DataGridView();
            pnlReaderInput = new Panel();
            label9 = new Label();
            label13 = new Label();
            btnCancel = new Button();
            btnSave = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            txtCategoryId = new TextBox();
            txtPublisherId = new TextBox();
            txtAvailableQuantity = new TextBox();
            label8 = new Label();
            txtTotalQuantity = new TextBox();
            label7 = new Label();
            txtPrice = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            txtYearPublished = new TextBox();
            txtISBN = new TextBox();
            txtTitle = new TextBox();
            label3 = new Label();
            txtBookID = new TextBox();
            label2 = new Label();
            panel2 = new Panel();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            pnlReaderInput.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(label1);
            panel4.Controls.Add(lblTitle);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(998, 60);
            panel4.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(18, 30);
            label1.Name = "label1";
            label1.Size = new Size(156, 20);
            label1.TabIndex = 4;
            label1.Text = "Quản lý thông tin sách";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(15, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(138, 30);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Quản lý sách";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightGray;
            panel1.Controls.Add(panel5);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 60);
            panel1.Name = "panel1";
            panel1.Size = new Size(998, 50);
            panel1.TabIndex = 7;
            // 
            // panel5
            // 
            panel5.Controls.Add(btnRefresh);
            panel5.Controls.Add(btnReloadReaders);
            panel5.Controls.Add(btnSearch);
            panel5.Controls.Add(btnSearchReader);
            panel5.Controls.Add(txtSearch);
            panel5.Dock = DockStyle.Left;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(600, 50);
            panel5.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Right;
            btnRefresh.BackColor = Color.Transparent;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.ForeColor = SystemColors.Window;
            btnRefresh.Image = Properties.Resources.refresh_icon;
            btnRefresh.Location = new Point(548, 10);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Padding = new Padding(2);
            btnRefresh.Size = new Size(28, 28);
            btnRefresh.TabIndex = 9;
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnReloadReaders
            // 
            btnReloadReaders.Anchor = AnchorStyles.Right;
            btnReloadReaders.BackColor = Color.Transparent;
            btnReloadReaders.FlatAppearance.BorderSize = 0;
            btnReloadReaders.FlatStyle = FlatStyle.Flat;
            btnReloadReaders.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReloadReaders.ForeColor = SystemColors.Window;
            btnReloadReaders.Image = Properties.Resources.refresh_icon;
            btnReloadReaders.Location = new Point(900, -15);
            btnReloadReaders.Name = "btnReloadReaders";
            btnReloadReaders.Padding = new Padding(2);
            btnReloadReaders.Size = new Size(28, 28);
            btnReloadReaders.TabIndex = 3;
            btnReloadReaders.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Right;
            btnSearch.BackColor = Color.DeepSkyBlue;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = SystemColors.Window;
            btnSearch.Location = new Point(448, 10);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(90, 28);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnSearchReader
            // 
            btnSearchReader.Anchor = AnchorStyles.Right;
            btnSearchReader.BackColor = Color.DeepSkyBlue;
            btnSearchReader.FlatAppearance.BorderSize = 0;
            btnSearchReader.FlatStyle = FlatStyle.Flat;
            btnSearchReader.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearchReader.ForeColor = SystemColors.Window;
            btnSearchReader.Location = new Point(800, -15);
            btnSearchReader.Name = "btnSearchReader";
            btnSearchReader.Size = new Size(90, 28);
            btnSearchReader.TabIndex = 2;
            btnSearchReader.Text = "Tìm kiếm";
            btnSearchReader.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Location = new Point(12, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderColor = Color.Gray;
            txtSearch.PlaceholderText = "Nhập tên sách, ...";
            txtSearch.Size = new Size(393, 23);
            txtSearch.TabIndex = 1;
            txtSearch.Text = "Nhập tên sách, ...";
            txtSearch.TextColor = Color.Black;
            // 
            // dgvBooks
            // 
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.AllowUserToResizeColumns = false;
            dgvBooks.AllowUserToResizeRows = false;
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.BackgroundColor = Color.White;
            dgvBooks.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvBooks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvBooks.DefaultCellStyle = dataGridViewCellStyle2;
            dgvBooks.Dock = DockStyle.Fill;
            dgvBooks.GridColor = Color.White;
            dgvBooks.Location = new Point(0, 0);
            dgvBooks.MultiSelect = false;
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.RowHeadersVisible = false;
            dgvBooks.RowHeadersWidth = 51;
            dgvBooks.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.ShowEditingIcon = false;
            dgvBooks.Size = new Size(627, 636);
            dgvBooks.TabIndex = 8;
            dgvBooks.SelectionChanged += dgvBooks_SelectionChanged;
            // 
            // pnlReaderInput
            // 
            pnlReaderInput.BackColor = Color.WhiteSmoke;
            pnlReaderInput.Controls.Add(label9);
            pnlReaderInput.Controls.Add(label13);
            pnlReaderInput.Controls.Add(btnCancel);
            pnlReaderInput.Controls.Add(btnSave);
            pnlReaderInput.Controls.Add(btnDelete);
            pnlReaderInput.Controls.Add(btnEdit);
            pnlReaderInput.Controls.Add(btnAdd);
            pnlReaderInput.Controls.Add(txtCategoryId);
            pnlReaderInput.Controls.Add(txtPublisherId);
            pnlReaderInput.Controls.Add(txtAvailableQuantity);
            pnlReaderInput.Controls.Add(label8);
            pnlReaderInput.Controls.Add(txtTotalQuantity);
            pnlReaderInput.Controls.Add(label7);
            pnlReaderInput.Controls.Add(txtPrice);
            pnlReaderInput.Controls.Add(label6);
            pnlReaderInput.Controls.Add(label5);
            pnlReaderInput.Controls.Add(label4);
            pnlReaderInput.Controls.Add(txtYearPublished);
            pnlReaderInput.Controls.Add(txtISBN);
            pnlReaderInput.Controls.Add(txtTitle);
            pnlReaderInput.Controls.Add(label3);
            pnlReaderInput.Controls.Add(txtBookID);
            pnlReaderInput.Controls.Add(label2);
            pnlReaderInput.Dock = DockStyle.Right;
            pnlReaderInput.Location = new Point(627, 110);
            pnlReaderInput.Name = "pnlReaderInput";
            pnlReaderInput.Size = new Size(371, 636);
            pnlReaderInput.TabIndex = 9;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(23, 302);
            label9.Name = "label9";
            label9.Size = new Size(87, 20);
            label9.TabIndex = 22;
            label9.Text = "Mã thể loại:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(23, 267);
            label13.Name = "label13";
            label13.Size = new Size(122, 20);
            label13.TabIndex = 22;
            label13.Text = "Mã nhà xuất bản:";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightGray;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = SystemColors.Window;
            btnCancel.Location = new Point(142, 377);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(85, 30);
            btnCancel.TabIndex = 21;
            btnCancel.Text = "Hủy";
            btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Visible = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.LightGreen;
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = SystemColors.Window;
            btnSave.Location = new Point(25, 377);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(85, 30);
            btnSave.TabIndex = 20;
            btnSave.Text = "Lưu";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Visible = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = SystemColors.Window;
            btnDelete.Location = new Point(259, 377);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(85, 30);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Xóa";
            btnDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.Orange;
            btnEdit.BackgroundImageLayout = ImageLayout.Stretch;
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEdit.ForeColor = SystemColors.Window;
            btnEdit.Location = new Point(142, 377);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(85, 30);
            btnEdit.TabIndex = 10;
            btnEdit.Text = "Sửa";
            btnEdit.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Green;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = SystemColors.Window;
            btnAdd.Location = new Point(25, 377);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(85, 30);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Thêm";
            btnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtCategoryId
            // 
            txtCategoryId.BorderStyle = BorderStyle.FixedSingle;
            txtCategoryId.Location = new Point(156, 302);
            txtCategoryId.Name = "txtCategoryId";
            txtCategoryId.ReadOnly = true;
            txtCategoryId.Size = new Size(188, 23);
            txtCategoryId.TabIndex = 8;
            // 
            // txtPublisherId
            // 
            txtPublisherId.BorderStyle = BorderStyle.FixedSingle;
            txtPublisherId.Location = new Point(156, 267);
            txtPublisherId.Name = "txtPublisherId";
            txtPublisherId.ReadOnly = true;
            txtPublisherId.Size = new Size(188, 23);
            txtPublisherId.TabIndex = 7;
            // 
            // txtAvailableQuantity
            // 
            txtAvailableQuantity.BorderStyle = BorderStyle.FixedSingle;
            txtAvailableQuantity.Location = new Point(156, 232);
            txtAvailableQuantity.Name = "txtAvailableQuantity";
            txtAvailableQuantity.ReadOnly = true;
            txtAvailableQuantity.Size = new Size(188, 23);
            txtAvailableQuantity.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(23, 232);
            label8.Name = "label8";
            label8.Size = new Size(100, 20);
            label8.TabIndex = 12;
            label8.Text = "Số lượng còn:";
            // 
            // txtTotalQuantity
            // 
            txtTotalQuantity.BorderStyle = BorderStyle.FixedSingle;
            txtTotalQuantity.Location = new Point(156, 197);
            txtTotalQuantity.Name = "txtTotalQuantity";
            txtTotalQuantity.ReadOnly = true;
            txtTotalQuantity.Size = new Size(188, 23);
            txtTotalQuantity.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(23, 197);
            label7.Name = "label7";
            label7.Size = new Size(107, 20);
            label7.TabIndex = 10;
            label7.Text = "Số lượng tổng:";
            // 
            // txtPrice
            // 
            txtPrice.BorderStyle = BorderStyle.FixedSingle;
            txtPrice.Location = new Point(156, 162);
            txtPrice.Name = "txtPrice";
            txtPrice.ReadOnly = true;
            txtPrice.Size = new Size(188, 23);
            txtPrice.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(23, 162);
            label6.Name = "label6";
            label6.Size = new Size(67, 20);
            label6.TabIndex = 8;
            label6.Text = "Giá sách:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(23, 127);
            label5.Name = "label5";
            label5.Size = new Size(105, 20);
            label5.TabIndex = 6;
            label5.Text = "Năm xuất bản:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(23, 92);
            label4.Name = "label4";
            label4.Size = new Size(41, 20);
            label4.TabIndex = 4;
            label4.Text = "ISBN";
            // 
            // txtYearPublished
            // 
            txtYearPublished.BorderStyle = BorderStyle.FixedSingle;
            txtYearPublished.Location = new Point(156, 127);
            txtYearPublished.Name = "txtYearPublished";
            txtYearPublished.ReadOnly = true;
            txtYearPublished.Size = new Size(188, 23);
            txtYearPublished.TabIndex = 3;
            // 
            // txtISBN
            // 
            txtISBN.BorderStyle = BorderStyle.FixedSingle;
            txtISBN.Location = new Point(156, 92);
            txtISBN.Name = "txtISBN";
            txtISBN.ReadOnly = true;
            txtISBN.Size = new Size(188, 23);
            txtISBN.TabIndex = 2;
            // 
            // txtTitle
            // 
            txtTitle.BorderStyle = BorderStyle.FixedSingle;
            txtTitle.Location = new Point(156, 57);
            txtTitle.Name = "txtTitle";
            txtTitle.ReadOnly = true;
            txtTitle.Size = new Size(188, 23);
            txtTitle.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(23, 57);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 2;
            label3.Text = "Tiêu đề:";
            // 
            // txtBookID
            // 
            txtBookID.BorderStyle = BorderStyle.FixedSingle;
            txtBookID.Location = new Point(156, 22);
            txtBookID.Name = "txtBookID";
            txtBookID.ReadOnly = true;
            txtBookID.Size = new Size(188, 23);
            txtBookID.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(23, 22);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 0;
            label2.Text = "Mã sách:";
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvBooks);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 110);
            panel2.Name = "panel2";
            panel2.Size = new Size(627, 636);
            panel2.TabIndex = 10;
            // 
            // FrmBooks
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(998, 746);
            Controls.Add(panel2);
            Controls.Add(pnlReaderInput);
            Controls.Add(panel1);
            Controls.Add(panel4);
            Name = "FrmBooks";
            Text = "FrmBook";
            Load += FrmBooks_Load;
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            pnlReaderInput.ResumeLayout(false);
            pnlReaderInput.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel4;
        private Label label1;
        private Label lblTitle;
        private Panel panel1;
        private Panel panel5;
        private Button btnReloadReaders;
        private Button btnSearchReader;
        private UICustom.PlaceholderTextBox txtSearch;
        private Button btnRefresh;
        private Button btnSearch;
        private DataGridView dgvBooks;
        private Panel pnlReaderInput;
        private DateTimePicker dtpRegistrationDate;
        private Label label13;
        private Button btnCancel;
        private Button btnSave;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnAdd;
        private ComboBox cboGender;
        private TextBox txtAvailableQuantity;
        private Label label8;
        private TextBox txtTotalQuantity;
        private Label label7;
        private TextBox txtPrice;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox txtBookID;
        private Label label2;
        private Panel panel2;
        private Label label9;
        private TextBox txtTitle;
        private TextBox txtCategoryId;
        private TextBox txtPublisherId;
        private TextBox txtYearPublished;
        private TextBox txtISBN;
    }
}