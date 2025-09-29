namespace UI
{
    partial class FrmReaders
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panel1 = new Panel();
            panel5 = new Panel();
            btnSearch = new Button();
            txtSearch = new UI.UICustom.PlaceholderTextBox();
            label9 = new Label();
            panel2 = new Panel();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            cbGioiTinh = new ComboBox();
            dtpNgaySinh = new DateTimePicker();
            txtSDT = new TextBox();
            label8 = new Label();
            txtEmail = new TextBox();
            label7 = new Label();
            txtDiaChi = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            txtTenDocGia = new TextBox();
            label3 = new Label();
            txtMaDocGia = new TextBox();
            label2 = new Label();
            dgvReaders = new DataGridView();
            panel3 = new Panel();
            tbcReaders = new TabControl();
            tabPage1 = new TabPage();
            panel4 = new Panel();
            label1 = new Label();
            lblTitle = new Label();
            tabPage2 = new TabPage();
            panel10 = new Panel();
            pctBoxQRCode = new PictureBox();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            cbTrangThai = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            textBox4 = new TextBox();
            label18 = new Label();
            textBox5 = new TextBox();
            label19 = new Label();
            panel9 = new Panel();
            dgvLibraryCards = new DataGridView();
            panel7 = new Panel();
            panel8 = new Panel();
            button2 = new Button();
            button1 = new Button();
            placeholderTextBox1 = new UI.UICustom.PlaceholderTextBox();
            label12 = new Label();
            panel6 = new Panel();
            label10 = new Label();
            label11 = new Label();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReaders).BeginInit();
            panel3.SuspendLayout();
            tbcReaders.SuspendLayout();
            tabPage1.SuspendLayout();
            panel4.SuspendLayout();
            tabPage2.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pctBoxQRCode).BeginInit();
            panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLibraryCards).BeginInit();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightGray;
            panel1.Controls.Add(panel5);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 63);
            panel1.Name = "panel1";
            panel1.Size = new Size(970, 50);
            panel1.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Controls.Add(btnSearch);
            panel5.Controls.Add(txtSearch);
            panel5.Controls.Add(label9);
            panel5.Dock = DockStyle.Left;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(600, 50);
            panel5.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Right;
            btnSearch.BackColor = Color.DeepSkyBlue;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = SystemColors.Window;
            btnSearch.Location = new Point(490, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(89, 28);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Location = new Point(90, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderColor = Color.Gray;
            txtSearch.PlaceholderText = "Nhập tên, email, số điện thoại ...";
            txtSearch.Size = new Size(375, 23);
            txtSearch.TabIndex = 1;
            txtSearch.Text = "Nhập tên, email, số điện thoại ...";
            txtSearch.TextColor = Color.Black;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(15, 15);
            label9.Name = "label9";
            label9.Size = new Size(73, 20);
            label9.TabIndex = 0;
            label9.Text = "Tìm kiếm:";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel2.BackColor = Color.WhiteSmoke;
            panel2.Controls.Add(btnDelete);
            panel2.Controls.Add(btnEdit);
            panel2.Controls.Add(btnAdd);
            panel2.Controls.Add(cbGioiTinh);
            panel2.Controls.Add(dtpNgaySinh);
            panel2.Controls.Add(txtSDT);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(txtEmail);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtDiaChi);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtTenDocGia);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(txtMaDocGia);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(602, 112);
            panel2.Name = "panel2";
            panel2.Size = new Size(371, 521);
            panel2.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = SystemColors.Window;
            btnDelete.Location = new Point(259, 311);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(85, 30);
            btnDelete.TabIndex = 19;
            btnDelete.Text = "Xóa";
            btnDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDelete.UseVisualStyleBackColor = false;
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
            btnEdit.Location = new Point(142, 311);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(85, 30);
            btnEdit.TabIndex = 18;
            btnEdit.Text = "Sửa";
            btnEdit.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Green;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = SystemColors.Window;
            btnAdd.Location = new Point(25, 311);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(85, 30);
            btnAdd.TabIndex = 17;
            btnAdd.Text = "Thêm";
            btnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // cbGioiTinh
            // 
            cbGioiTinh.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbGioiTinh.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cbGioiTinh.Location = new Point(156, 127);
            cbGioiTinh.Name = "cbGioiTinh";
            cbGioiTinh.Size = new Size(121, 23);
            cbGioiTinh.TabIndex = 16;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(156, 92);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(121, 23);
            dtpNgaySinh.TabIndex = 15;
            dtpNgaySinh.Value = new DateTime(2025, 1, 1, 0, 0, 0, 0);
            // 
            // txtSDT
            // 
            txtSDT.BorderStyle = BorderStyle.FixedSingle;
            txtSDT.Location = new Point(156, 232);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(188, 23);
            txtSDT.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(23, 232);
            label8.Name = "label8";
            label8.Size = new Size(100, 20);
            label8.TabIndex = 12;
            label8.Text = "Số điện thoại:";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(156, 197);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(188, 23);
            txtEmail.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(23, 197);
            label7.Name = "label7";
            label7.Size = new Size(49, 20);
            label7.TabIndex = 10;
            label7.Text = "Email:";
            // 
            // txtDiaChi
            // 
            txtDiaChi.BorderStyle = BorderStyle.FixedSingle;
            txtDiaChi.Location = new Point(156, 162);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(188, 23);
            txtDiaChi.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(23, 162);
            label6.Name = "label6";
            label6.Size = new Size(58, 20);
            label6.TabIndex = 8;
            label6.Text = "Địa chỉ:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(23, 127);
            label5.Name = "label5";
            label5.Size = new Size(68, 20);
            label5.TabIndex = 6;
            label5.Text = "Giới tính:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(23, 92);
            label4.Name = "label4";
            label4.Size = new Size(77, 20);
            label4.TabIndex = 4;
            label4.Text = "Ngày sinh:";
            // 
            // txtTenDocGia
            // 
            txtTenDocGia.BorderStyle = BorderStyle.FixedSingle;
            txtTenDocGia.Location = new Point(156, 57);
            txtTenDocGia.Name = "txtTenDocGia";
            txtTenDocGia.Size = new Size(188, 23);
            txtTenDocGia.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(23, 57);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 2;
            label3.Text = "Họ tên:";
            // 
            // txtMaDocGia
            // 
            txtMaDocGia.BorderStyle = BorderStyle.FixedSingle;
            txtMaDocGia.Location = new Point(156, 22);
            txtMaDocGia.Name = "txtMaDocGia";
            txtMaDocGia.Size = new Size(188, 23);
            txtMaDocGia.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(23, 22);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 0;
            label2.Text = "Mã độc giả:";
            // 
            // dgvReaders
            // 
            dgvReaders.AllowUserToAddRows = false;
            dgvReaders.AllowUserToDeleteRows = false;
            dgvReaders.AllowUserToResizeColumns = false;
            dgvReaders.AllowUserToResizeRows = false;
            dgvReaders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvReaders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReaders.BackgroundColor = Color.White;
            dgvReaders.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvReaders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvReaders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvReaders.DefaultCellStyle = dataGridViewCellStyle2;
            dgvReaders.GridColor = Color.White;
            dgvReaders.Location = new Point(20, 20);
            dgvReaders.MultiSelect = false;
            dgvReaders.Name = "dgvReaders";
            dgvReaders.ReadOnly = true;
            dgvReaders.RowHeadersVisible = false;
            dgvReaders.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvReaders.ShowEditingIcon = false;
            dgvReaders.Size = new Size(557, 481);
            dgvReaders.TabIndex = 2;
            dgvReaders.DataBindingComplete += dtgvReaders_DataBindingComplete;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.White;
            panel3.Controls.Add(dgvReaders);
            panel3.Location = new Point(3, 112);
            panel3.Name = "panel3";
            panel3.Size = new Size(600, 521);
            panel3.TabIndex = 2;
            // 
            // tbcReaders
            // 
            tbcReaders.Controls.Add(tabPage1);
            tbcReaders.Controls.Add(tabPage2);
            tbcReaders.Dock = DockStyle.Fill;
            tbcReaders.Location = new Point(0, 0);
            tbcReaders.Multiline = true;
            tbcReaders.Name = "tbcReaders";
            tbcReaders.SelectedIndex = 0;
            tbcReaders.Size = new Size(984, 661);
            tbcReaders.TabIndex = 3;
            tbcReaders.SelectedIndexChanged += tbcReaders_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel2);
            tabPage1.Controls.Add(panel3);
            tabPage1.Controls.Add(panel1);
            tabPage1.Controls.Add(panel4);
            tabPage1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(976, 633);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Độc giả";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(label1);
            panel4.Controls.Add(lblTitle);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(970, 60);
            panel4.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(18, 30);
            label1.Name = "label1";
            label1.Size = new Size(177, 20);
            label1.TabIndex = 4;
            label1.Text = "Quản lý thông tin độc giả";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(15, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(167, 30);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Quản lý độc giả";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel10);
            tabPage2.Controls.Add(panel9);
            tabPage2.Controls.Add(panel7);
            tabPage2.Controls.Add(panel6);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(976, 633);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Thẻ thư viện";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            panel10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel10.BackColor = Color.WhiteSmoke;
            panel10.Controls.Add(pctBoxQRCode);
            panel10.Controls.Add(button3);
            panel10.Controls.Add(button4);
            panel10.Controls.Add(button5);
            panel10.Controls.Add(cbTrangThai);
            panel10.Controls.Add(dateTimePicker1);
            panel10.Controls.Add(label15);
            panel10.Controls.Add(label16);
            panel10.Controls.Add(label17);
            panel10.Controls.Add(textBox4);
            panel10.Controls.Add(label18);
            panel10.Controls.Add(textBox5);
            panel10.Controls.Add(label19);
            panel10.Location = new Point(602, 112);
            panel10.Name = "panel10";
            panel10.Size = new Size(371, 521);
            panel10.TabIndex = 9;
            // 
            // pctBoxQRCode
            // 
            pctBoxQRCode.BackColor = Color.White;
            pctBoxQRCode.BackgroundImage = Properties.Resources.qr_code;
            pctBoxQRCode.BackgroundImageLayout = ImageLayout.Center;
            pctBoxQRCode.Location = new Point(157, 162);
            pctBoxQRCode.Name = "pctBoxQRCode";
            pctBoxQRCode.Size = new Size(180, 180);
            pctBoxQRCode.SizeMode = PictureBoxSizeMode.AutoSize;
            pctBoxQRCode.TabIndex = 20;
            pctBoxQRCode.TabStop = false;
            // 
            // button3
            // 
            button3.BackColor = Color.Red;
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.Window;
            button3.Location = new Point(262, 366);
            button3.Name = "button3";
            button3.Size = new Size(85, 30);
            button3.TabIndex = 19;
            button3.Text = "Xóa";
            button3.TextImageRelation = TextImageRelation.ImageBeforeText;
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.Orange;
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            button4.Cursor = Cursors.Hand;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = SystemColors.Window;
            button4.Location = new Point(145, 366);
            button4.Name = "button4";
            button4.Size = new Size(85, 30);
            button4.TabIndex = 18;
            button4.Text = "Sửa";
            button4.TextImageRelation = TextImageRelation.ImageBeforeText;
            button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.Green;
            button5.Cursor = Cursors.Hand;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = SystemColors.Window;
            button5.Location = new Point(28, 366);
            button5.Name = "button5";
            button5.Size = new Size(85, 30);
            button5.TabIndex = 17;
            button5.Text = "Thêm";
            button5.TextImageRelation = TextImageRelation.ImageBeforeText;
            button5.UseVisualStyleBackColor = false;
            // 
            // cbTrangThai
            // 
            cbTrangThai.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbTrangThai.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbTrangThai.Items.AddRange(new object[] { "Hoạt động", "Bị khóa" });
            cbTrangThai.Location = new Point(156, 127);
            cbTrangThai.Name = "cbTrangThai";
            cbTrangThai.Size = new Size(121, 23);
            cbTrangThai.TabIndex = 16;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(156, 92);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(121, 23);
            dateTimePicker1.TabIndex = 15;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(23, 162);
            label15.Name = "label15";
            label15.Size = new Size(71, 20);
            label15.TabIndex = 8;
            label15.Text = "QR Code:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.Location = new Point(23, 127);
            label16.Name = "label16";
            label16.Size = new Size(78, 20);
            label16.TabIndex = 6;
            label16.Text = "Trạng thái:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label17.Location = new Point(23, 92);
            label17.Name = "label17";
            label17.Size = new Size(73, 20);
            label17.TabIndex = 4;
            label17.Text = "Ngày tạo:";
            // 
            // textBox4
            // 
            textBox4.BorderStyle = BorderStyle.FixedSingle;
            textBox4.Location = new Point(156, 57);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(188, 23);
            textBox4.TabIndex = 3;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label18.Location = new Point(23, 57);
            label18.Name = "label18";
            label18.Size = new Size(87, 20);
            label18.TabIndex = 2;
            label18.Text = "Mã độc giả:";
            // 
            // textBox5
            // 
            textBox5.BorderStyle = BorderStyle.FixedSingle;
            textBox5.Location = new Point(156, 22);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(188, 23);
            textBox5.TabIndex = 1;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label19.Location = new Point(23, 22);
            label19.Name = "label19";
            label19.Size = new Size(58, 20);
            label19.TabIndex = 0;
            label19.Text = "Mã thẻ:";
            // 
            // panel9
            // 
            panel9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel9.BackColor = Color.White;
            panel9.Controls.Add(dgvLibraryCards);
            panel9.Location = new Point(3, 112);
            panel9.Name = "panel9";
            panel9.Size = new Size(600, 521);
            panel9.TabIndex = 8;
            // 
            // dgvLibraryCards
            // 
            dgvLibraryCards.AllowUserToAddRows = false;
            dgvLibraryCards.AllowUserToDeleteRows = false;
            dgvLibraryCards.AllowUserToResizeColumns = false;
            dgvLibraryCards.AllowUserToResizeRows = false;
            dgvLibraryCards.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLibraryCards.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLibraryCards.BackgroundColor = Color.White;
            dgvLibraryCards.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvLibraryCards.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvLibraryCards.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvLibraryCards.DefaultCellStyle = dataGridViewCellStyle4;
            dgvLibraryCards.GridColor = Color.White;
            dgvLibraryCards.Location = new Point(20, 20);
            dgvLibraryCards.MultiSelect = false;
            dgvLibraryCards.Name = "dgvLibraryCards";
            dgvLibraryCards.ReadOnly = true;
            dgvLibraryCards.RowHeadersVisible = false;
            dgvLibraryCards.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvLibraryCards.ShowEditingIcon = false;
            dgvLibraryCards.Size = new Size(557, 480);
            dgvLibraryCards.TabIndex = 2;
            // 
            // panel7
            // 
            panel7.BackColor = Color.LightGray;
            panel7.Controls.Add(panel8);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(3, 63);
            panel7.Name = "panel7";
            panel7.Size = new Size(970, 50);
            panel7.TabIndex = 7;
            // 
            // panel8
            // 
            panel8.Controls.Add(button2);
            panel8.Controls.Add(button1);
            panel8.Controls.Add(placeholderTextBox1);
            panel8.Controls.Add(label12);
            panel8.Dock = DockStyle.Left;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(600, 50);
            panel8.TabIndex = 0;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Right;
            button2.BackColor = Color.DeepSkyBlue;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.Window;
            button2.Location = new Point(490, 12);
            button2.Name = "button2";
            button2.Size = new Size(89, 28);
            button2.TabIndex = 8;
            button2.Text = "Tìm kiếm";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Right;
            button1.BackColor = Color.DeepSkyBlue;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.Window;
            button1.Location = new Point(896, -13);
            button1.Name = "button1";
            button1.Size = new Size(89, 28);
            button1.TabIndex = 2;
            button1.Text = "Tìm kiếm";
            button1.UseVisualStyleBackColor = false;
            // 
            // placeholderTextBox1
            // 
            placeholderTextBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            placeholderTextBox1.BorderStyle = BorderStyle.FixedSingle;
            placeholderTextBox1.ForeColor = Color.Gray;
            placeholderTextBox1.Location = new Point(90, 15);
            placeholderTextBox1.Name = "placeholderTextBox1";
            placeholderTextBox1.PlaceholderColor = Color.Gray;
            placeholderTextBox1.PlaceholderText = "Nhập mã thẻ, mã độc giả, ngày tạo ...";
            placeholderTextBox1.Size = new Size(375, 23);
            placeholderTextBox1.TabIndex = 1;
            placeholderTextBox1.Text = "Nhập mã thẻ, mã độc giả, ngày tạo ...";
            placeholderTextBox1.TextColor = Color.Black;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(15, 15);
            label12.Name = "label12";
            label12.Size = new Size(73, 20);
            label12.TabIndex = 0;
            label12.Text = "Tìm kiếm:";
            // 
            // panel6
            // 
            panel6.BackColor = Color.White;
            panel6.Controls.Add(label10);
            panel6.Controls.Add(label11);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(3, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(970, 60);
            panel6.TabIndex = 6;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(18, 30);
            label10.Name = "label10";
            label10.Size = new Size(205, 20);
            label10.TabIndex = 4;
            label10.Text = "Quản lý thông tin thẻ thư viện";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(15, 0);
            label11.Name = "label11";
            label11.Size = new Size(215, 30);
            label11.TabIndex = 3;
            label11.Text = "Quản lý thẻ thư viện";
            // 
            // FrmReaders
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 661);
            Controls.Add(tbcReaders);
            Name = "FrmReaders";
            Text = "FrmReaders";
            Load += FrmReaders_Load;
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReaders).EndInit();
            panel3.ResumeLayout(false);
            tbcReaders.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            tabPage2.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pctBoxQRCode).EndInit();
            panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLibraryCards).EndInit();
            panel7.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private DataGridView dgvReaders;
        private Panel panel3;
        private TabControl tbcReaders;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel panel4;
        private Label label1;
        private Label lblTitle;
        private Label label2;
        private TextBox txtMaDocGia;
        private TextBox txtEmail;
        private Label label7;
        private TextBox txtDiaChi;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txtTenDocGia;
        private Label label3;
        private TextBox txtSDT;
        private Label label8;
        private DateTimePicker dtpNgaySinh;
        private ComboBox cbGioiTinh;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnAdd;
        private Panel panel5;
        private UICustom.PlaceholderTextBox txtSearch;
        private Label label9;
        private Button btnSearch;
        private Panel panel7;
        private Panel panel8;
        private Button button1;
        private UICustom.PlaceholderTextBox placeholderTextBox1;
        private Label label12;
        private Panel panel6;
        private Label label10;
        private Label label11;
        private Button button2;
        private Panel panel10;
        private Button button3;
        private Button button4;
        private Button button5;
        private ComboBox cbTrangThai;
        private DateTimePicker dateTimePicker1;
        private Label label15;
        private Label label16;
        private Label label17;
        private TextBox textBox4;
        private Label label18;
        private TextBox textBox5;
        private Label label19;
        private Panel panel9;
        private DataGridView dgvLibraryCards;
        private PictureBox pctBoxQRCode;
    }
}