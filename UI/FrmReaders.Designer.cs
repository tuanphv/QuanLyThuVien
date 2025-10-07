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
            btnReloadReaders = new Button();
            btnSearchReader = new Button();
            txtSearchReader = new UI.UICustom.PlaceholderTextBox();
            pnlReaderInput = new Panel();
            dtpRegistrationDate = new DateTimePicker();
            label13 = new Label();
            btnCancel = new Button();
            btnSave = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            cboGender = new ComboBox();
            dtpDateOfBirth = new DateTimePicker();
            txtPhoneNumber = new TextBox();
            label8 = new Label();
            txtEmail = new TextBox();
            label7 = new Label();
            txtAddress = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            txtFullName = new TextBox();
            label3 = new Label();
            txtReaderID = new TextBox();
            label2 = new Label();
            dgvReaders = new DataGridView();
            panel3 = new Panel();
            tbcReaders = new TabControl();
            tabPage1 = new TabPage();
            panel4 = new Panel();
            label1 = new Label();
            lblTitle = new Label();
            tabPage2 = new TabPage();
            pnlLibraryCardInput = new Panel();
            dtpExpiryDate = new DateTimePicker();
            label14 = new Label();
            btnCancelCard = new Button();
            btnSaveCard = new Button();
            pctBoxQRCode = new PictureBox();
            btnDeleteCard = new Button();
            btnEditCard = new Button();
            btnAddCard = new Button();
            cboStatus = new ComboBox();
            dtpIssueDate = new DateTimePicker();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            txtCardReaderID = new TextBox();
            label18 = new Label();
            txtCardID = new TextBox();
            label19 = new Label();
            panel9 = new Panel();
            dgvLibraryCards = new DataGridView();
            panel7 = new Panel();
            panel8 = new Panel();
            btnReloadCards = new Button();
            btnSearchLibraryCard = new Button();
            button1 = new Button();
            txtSearchLibraryCard = new UI.UICustom.PlaceholderTextBox();
            panel6 = new Panel();
            label10 = new Label();
            label11 = new Label();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            pnlReaderInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReaders).BeginInit();
            panel3.SuspendLayout();
            tbcReaders.SuspendLayout();
            tabPage1.SuspendLayout();
            panel4.SuspendLayout();
            tabPage2.SuspendLayout();
            pnlLibraryCardInput.SuspendLayout();
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
            panel5.Controls.Add(btnReloadReaders);
            panel5.Controls.Add(btnSearchReader);
            panel5.Controls.Add(txtSearchReader);
            panel5.Dock = DockStyle.Left;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(600, 50);
            panel5.TabIndex = 0;
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
            btnReloadReaders.Location = new Point(500, 10);
            btnReloadReaders.Name = "btnReloadReaders";
            btnReloadReaders.Padding = new Padding(2);
            btnReloadReaders.Size = new Size(28, 28);
            btnReloadReaders.TabIndex = 3;
            btnReloadReaders.UseVisualStyleBackColor = false;
            btnReloadReaders.Click += btnReloadReaders_Click;
            // 
            // btnSearchReader
            // 
            btnSearchReader.Anchor = AnchorStyles.Right;
            btnSearchReader.BackColor = Color.DeepSkyBlue;
            btnSearchReader.FlatAppearance.BorderSize = 0;
            btnSearchReader.FlatStyle = FlatStyle.Flat;
            btnSearchReader.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearchReader.ForeColor = SystemColors.Window;
            btnSearchReader.Location = new Point(400, 10);
            btnSearchReader.Name = "btnSearchReader";
            btnSearchReader.Size = new Size(90, 28);
            btnSearchReader.TabIndex = 2;
            btnSearchReader.Text = "Tìm kiếm";
            btnSearchReader.UseVisualStyleBackColor = false;
            btnSearchReader.Click += btnSearchReader_Click;
            // 
            // txtSearchReader
            // 
            txtSearchReader.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSearchReader.BorderStyle = BorderStyle.FixedSingle;
            txtSearchReader.ForeColor = Color.Gray;
            txtSearchReader.Location = new Point(20, 12);
            txtSearchReader.Name = "txtSearchReader";
            txtSearchReader.PlaceholderColor = Color.Gray;
            txtSearchReader.PlaceholderText = "Nhập tên, email, số điện thoại ...";
            txtSearchReader.Size = new Size(360, 23);
            txtSearchReader.TabIndex = 1;
            txtSearchReader.Text = "Nhập tên, email, số điện thoại ...";
            txtSearchReader.TextColor = Color.Black;
            txtSearchReader.KeyDown += txtSearchReader_KeyDown;
            // 
            // pnlReaderInput
            // 
            pnlReaderInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlReaderInput.BackColor = Color.WhiteSmoke;
            pnlReaderInput.Controls.Add(dtpRegistrationDate);
            pnlReaderInput.Controls.Add(label13);
            pnlReaderInput.Controls.Add(btnCancel);
            pnlReaderInput.Controls.Add(btnSave);
            pnlReaderInput.Controls.Add(btnDelete);
            pnlReaderInput.Controls.Add(btnEdit);
            pnlReaderInput.Controls.Add(btnAdd);
            pnlReaderInput.Controls.Add(cboGender);
            pnlReaderInput.Controls.Add(dtpDateOfBirth);
            pnlReaderInput.Controls.Add(txtPhoneNumber);
            pnlReaderInput.Controls.Add(label8);
            pnlReaderInput.Controls.Add(txtEmail);
            pnlReaderInput.Controls.Add(label7);
            pnlReaderInput.Controls.Add(txtAddress);
            pnlReaderInput.Controls.Add(label6);
            pnlReaderInput.Controls.Add(label5);
            pnlReaderInput.Controls.Add(label4);
            pnlReaderInput.Controls.Add(txtFullName);
            pnlReaderInput.Controls.Add(label3);
            pnlReaderInput.Controls.Add(txtReaderID);
            pnlReaderInput.Controls.Add(label2);
            pnlReaderInput.Location = new Point(602, 112);
            pnlReaderInput.Name = "pnlReaderInput";
            pnlReaderInput.Size = new Size(371, 521);
            pnlReaderInput.TabIndex = 1;
            // 
            // dtpRegistrationDate
            // 
            dtpRegistrationDate.Enabled = false;
            dtpRegistrationDate.Format = DateTimePickerFormat.Short;
            dtpRegistrationDate.Location = new Point(156, 267);
            dtpRegistrationDate.Name = "dtpRegistrationDate";
            dtpRegistrationDate.Size = new Size(121, 23);
            dtpRegistrationDate.TabIndex = 24;
            dtpRegistrationDate.Value = new DateTime(2025, 1, 1, 0, 0, 0, 0);
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(23, 267);
            label13.Name = "label13";
            label13.Size = new Size(100, 20);
            label13.TabIndex = 22;
            label13.Text = "Ngày đăng ký";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightGray;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = SystemColors.Window;
            btnCancel.Location = new Point(145, 346);
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
            btnSave.Location = new Point(28, 346);
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
            btnDelete.Location = new Point(262, 346);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(85, 30);
            btnDelete.TabIndex = 19;
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
            btnEdit.Location = new Point(145, 346);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(85, 30);
            btnEdit.TabIndex = 18;
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
            btnAdd.Location = new Point(28, 346);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(85, 30);
            btnAdd.TabIndex = 17;
            btnAdd.Text = "Thêm";
            btnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // cboGender
            // 
            cboGender.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboGender.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboGender.Enabled = false;
            cboGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboGender.Location = new Point(156, 127);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(121, 23);
            cboGender.TabIndex = 16;
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Enabled = false;
            dtpDateOfBirth.Format = DateTimePickerFormat.Short;
            dtpDateOfBirth.Location = new Point(156, 92);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(121, 23);
            dtpDateOfBirth.TabIndex = 15;
            dtpDateOfBirth.Value = new DateTime(2025, 1, 1, 0, 0, 0, 0);
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.BorderStyle = BorderStyle.FixedSingle;
            txtPhoneNumber.Location = new Point(156, 232);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.ReadOnly = true;
            txtPhoneNumber.Size = new Size(188, 23);
            txtPhoneNumber.TabIndex = 13;
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
            txtEmail.ReadOnly = true;
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
            // txtAddress
            // 
            txtAddress.BorderStyle = BorderStyle.FixedSingle;
            txtAddress.Location = new Point(156, 162);
            txtAddress.Name = "txtAddress";
            txtAddress.ReadOnly = true;
            txtAddress.Size = new Size(188, 23);
            txtAddress.TabIndex = 9;
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
            // txtFullName
            // 
            txtFullName.BorderStyle = BorderStyle.FixedSingle;
            txtFullName.Location = new Point(156, 57);
            txtFullName.Name = "txtFullName";
            txtFullName.ReadOnly = true;
            txtFullName.Size = new Size(188, 23);
            txtFullName.TabIndex = 3;
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
            // txtReaderID
            // 
            txtReaderID.BorderStyle = BorderStyle.FixedSingle;
            txtReaderID.Location = new Point(156, 22);
            txtReaderID.Name = "txtReaderID";
            txtReaderID.ReadOnly = true;
            txtReaderID.Size = new Size(188, 23);
            txtReaderID.TabIndex = 1;
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
            dgvReaders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReaders.BackgroundColor = Color.White;
            dgvReaders.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
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
            dgvReaders.Dock = DockStyle.Fill;
            dgvReaders.GridColor = Color.White;
            dgvReaders.Location = new Point(0, 0);
            dgvReaders.MultiSelect = false;
            dgvReaders.Name = "dgvReaders";
            dgvReaders.ReadOnly = true;
            dgvReaders.RowHeadersVisible = false;
            dgvReaders.RowHeadersWidth = 51;
            dgvReaders.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvReaders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReaders.ShowEditingIcon = false;
            dgvReaders.Size = new Size(600, 521);
            dgvReaders.TabIndex = 2;
            dgvReaders.DataBindingComplete += dtgvReaders_DataBindingComplete;
            dgvReaders.SelectionChanged += dgvReaders_SelectionChanged;
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
            tabPage1.Controls.Add(pnlReaderInput);
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
            tabPage2.Controls.Add(pnlLibraryCardInput);
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
            // pnlLibraryCardInput
            // 
            pnlLibraryCardInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlLibraryCardInput.BackColor = Color.WhiteSmoke;
            pnlLibraryCardInput.Controls.Add(dtpExpiryDate);
            pnlLibraryCardInput.Controls.Add(label14);
            pnlLibraryCardInput.Controls.Add(btnCancelCard);
            pnlLibraryCardInput.Controls.Add(btnSaveCard);
            pnlLibraryCardInput.Controls.Add(pctBoxQRCode);
            pnlLibraryCardInput.Controls.Add(btnDeleteCard);
            pnlLibraryCardInput.Controls.Add(btnEditCard);
            pnlLibraryCardInput.Controls.Add(btnAddCard);
            pnlLibraryCardInput.Controls.Add(cboStatus);
            pnlLibraryCardInput.Controls.Add(dtpIssueDate);
            pnlLibraryCardInput.Controls.Add(label15);
            pnlLibraryCardInput.Controls.Add(label16);
            pnlLibraryCardInput.Controls.Add(label17);
            pnlLibraryCardInput.Controls.Add(txtCardReaderID);
            pnlLibraryCardInput.Controls.Add(label18);
            pnlLibraryCardInput.Controls.Add(txtCardID);
            pnlLibraryCardInput.Controls.Add(label19);
            pnlLibraryCardInput.Location = new Point(602, 112);
            pnlLibraryCardInput.Name = "pnlLibraryCardInput";
            pnlLibraryCardInput.Size = new Size(371, 521);
            pnlLibraryCardInput.TabIndex = 9;
            // 
            // dtpExpiryDate
            // 
            dtpExpiryDate.Enabled = false;
            dtpExpiryDate.Format = DateTimePickerFormat.Short;
            dtpExpiryDate.Location = new Point(156, 127);
            dtpExpiryDate.Name = "dtpExpiryDate";
            dtpExpiryDate.Size = new Size(121, 23);
            dtpExpiryDate.TabIndex = 25;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(23, 125);
            label14.Name = "label14";
            label14.Size = new Size(75, 20);
            label14.TabIndex = 24;
            label14.Text = "Ngày cấp:";
            // 
            // btnCancelCard
            // 
            btnCancelCard.BackColor = Color.LightGray;
            btnCancelCard.Cursor = Cursors.Hand;
            btnCancelCard.FlatAppearance.BorderSize = 0;
            btnCancelCard.FlatStyle = FlatStyle.Flat;
            btnCancelCard.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelCard.ForeColor = SystemColors.Window;
            btnCancelCard.Location = new Point(144, 395);
            btnCancelCard.Name = "btnCancelCard";
            btnCancelCard.Size = new Size(85, 30);
            btnCancelCard.TabIndex = 23;
            btnCancelCard.Text = "Hủy";
            btnCancelCard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancelCard.UseVisualStyleBackColor = false;
            btnCancelCard.Visible = false;
            btnCancelCard.Click += btnCancelCard_Click;
            // 
            // btnSaveCard
            // 
            btnSaveCard.BackColor = Color.LightGreen;
            btnSaveCard.Cursor = Cursors.Hand;
            btnSaveCard.FlatAppearance.BorderSize = 0;
            btnSaveCard.FlatStyle = FlatStyle.Flat;
            btnSaveCard.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveCard.ForeColor = SystemColors.Window;
            btnSaveCard.Location = new Point(27, 395);
            btnSaveCard.Name = "btnSaveCard";
            btnSaveCard.Size = new Size(85, 30);
            btnSaveCard.TabIndex = 22;
            btnSaveCard.Text = "Lưu";
            btnSaveCard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSaveCard.UseVisualStyleBackColor = false;
            btnSaveCard.Visible = false;
            btnSaveCard.Click += btnSaveCard_Click;
            // 
            // pctBoxQRCode
            // 
            pctBoxQRCode.BackColor = Color.White;
            pctBoxQRCode.BackgroundImage = Properties.Resources.qr_code;
            pctBoxQRCode.BackgroundImageLayout = ImageLayout.Center;
            pctBoxQRCode.Location = new Point(156, 197);
            pctBoxQRCode.Name = "pctBoxQRCode";
            pctBoxQRCode.Size = new Size(180, 180);
            pctBoxQRCode.SizeMode = PictureBoxSizeMode.AutoSize;
            pctBoxQRCode.TabIndex = 20;
            pctBoxQRCode.TabStop = false;
            // 
            // btnDeleteCard
            // 
            btnDeleteCard.BackColor = Color.Red;
            btnDeleteCard.Cursor = Cursors.Hand;
            btnDeleteCard.FlatAppearance.BorderSize = 0;
            btnDeleteCard.FlatStyle = FlatStyle.Flat;
            btnDeleteCard.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteCard.ForeColor = SystemColors.Window;
            btnDeleteCard.Location = new Point(261, 395);
            btnDeleteCard.Name = "btnDeleteCard";
            btnDeleteCard.Size = new Size(85, 30);
            btnDeleteCard.TabIndex = 19;
            btnDeleteCard.Text = "Xóa";
            btnDeleteCard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDeleteCard.UseVisualStyleBackColor = false;
            btnDeleteCard.Click += btnDeleteCard_Click;
            // 
            // btnEditCard
            // 
            btnEditCard.BackColor = Color.Orange;
            btnEditCard.BackgroundImageLayout = ImageLayout.Stretch;
            btnEditCard.Cursor = Cursors.Hand;
            btnEditCard.FlatAppearance.BorderSize = 0;
            btnEditCard.FlatStyle = FlatStyle.Flat;
            btnEditCard.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditCard.ForeColor = SystemColors.Window;
            btnEditCard.Location = new Point(144, 395);
            btnEditCard.Name = "btnEditCard";
            btnEditCard.Size = new Size(85, 30);
            btnEditCard.TabIndex = 18;
            btnEditCard.Text = "Sửa";
            btnEditCard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEditCard.UseVisualStyleBackColor = false;
            btnEditCard.Click += btnEditCard_Click;
            // 
            // btnAddCard
            // 
            btnAddCard.BackColor = Color.Green;
            btnAddCard.Cursor = Cursors.Hand;
            btnAddCard.FlatAppearance.BorderSize = 0;
            btnAddCard.FlatStyle = FlatStyle.Flat;
            btnAddCard.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddCard.ForeColor = SystemColors.Window;
            btnAddCard.Location = new Point(27, 395);
            btnAddCard.Name = "btnAddCard";
            btnAddCard.Size = new Size(85, 30);
            btnAddCard.TabIndex = 17;
            btnAddCard.Text = "Thêm";
            btnAddCard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAddCard.UseVisualStyleBackColor = false;
            btnAddCard.Click += btnAddCard_Click;
            // 
            // cboStatus
            // 
            cboStatus.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboStatus.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboStatus.Enabled = false;
            cboStatus.Items.AddRange(new object[] { "Hoạt động", "Bị khóa" });
            cboStatus.Location = new Point(155, 162);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(121, 23);
            cboStatus.TabIndex = 16;
            // 
            // dtpIssueDate
            // 
            dtpIssueDate.Enabled = false;
            dtpIssueDate.Format = DateTimePickerFormat.Short;
            dtpIssueDate.Location = new Point(156, 92);
            dtpIssueDate.Name = "dtpIssueDate";
            dtpIssueDate.Size = new Size(121, 23);
            dtpIssueDate.TabIndex = 15;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(23, 197);
            label15.Name = "label15";
            label15.Size = new Size(71, 20);
            label15.TabIndex = 8;
            label15.Text = "QR Code:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.Location = new Point(23, 162);
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
            label17.Size = new Size(75, 20);
            label17.TabIndex = 4;
            label17.Text = "Ngày cấp:";
            // 
            // txtCardReaderID
            // 
            txtCardReaderID.BorderStyle = BorderStyle.FixedSingle;
            txtCardReaderID.Location = new Point(156, 57);
            txtCardReaderID.Name = "txtCardReaderID";
            txtCardReaderID.ReadOnly = true;
            txtCardReaderID.Size = new Size(188, 23);
            txtCardReaderID.TabIndex = 3;
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
            // txtCardID
            // 
            txtCardID.BorderStyle = BorderStyle.FixedSingle;
            txtCardID.Location = new Point(156, 22);
            txtCardID.Name = "txtCardID";
            txtCardID.ReadOnly = true;
            txtCardID.Size = new Size(188, 23);
            txtCardID.TabIndex = 1;
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
            dgvLibraryCards.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLibraryCards.BackgroundColor = Color.White;
            dgvLibraryCards.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvLibraryCards.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvLibraryCards.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvLibraryCards.DefaultCellStyle = dataGridViewCellStyle4;
            dgvLibraryCards.Dock = DockStyle.Fill;
            dgvLibraryCards.GridColor = Color.White;
            dgvLibraryCards.Location = new Point(0, 0);
            dgvLibraryCards.MultiSelect = false;
            dgvLibraryCards.Name = "dgvLibraryCards";
            dgvLibraryCards.ReadOnly = true;
            dgvLibraryCards.RowHeadersVisible = false;
            dgvLibraryCards.RowHeadersWidth = 51;
            dgvLibraryCards.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvLibraryCards.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibraryCards.ShowEditingIcon = false;
            dgvLibraryCards.Size = new Size(600, 521);
            dgvLibraryCards.TabIndex = 2;
            dgvLibraryCards.DataBindingComplete += dgvLibraryCards_DataBindingComplete;
            dgvLibraryCards.SelectionChanged += dgvLibraryCards_SelectionChanged;
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
            panel8.Controls.Add(btnReloadCards);
            panel8.Controls.Add(btnSearchLibraryCard);
            panel8.Controls.Add(button1);
            panel8.Controls.Add(txtSearchLibraryCard);
            panel8.Dock = DockStyle.Left;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(600, 50);
            panel8.TabIndex = 0;
            // 
            // btnReloadCards
            // 
            btnReloadCards.Anchor = AnchorStyles.Right;
            btnReloadCards.BackColor = Color.Transparent;
            btnReloadCards.FlatAppearance.BorderSize = 0;
            btnReloadCards.FlatStyle = FlatStyle.Flat;
            btnReloadCards.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReloadCards.ForeColor = SystemColors.Window;
            btnReloadCards.Image = Properties.Resources.refresh_icon;
            btnReloadCards.Location = new Point(500, 10);
            btnReloadCards.Name = "btnReloadCards";
            btnReloadCards.Padding = new Padding(2);
            btnReloadCards.Size = new Size(28, 28);
            btnReloadCards.TabIndex = 9;
            btnReloadCards.UseVisualStyleBackColor = false;
            btnReloadCards.Click += btnReloadCards_Click;
            // 
            // btnSearchLibraryCard
            // 
            btnSearchLibraryCard.Anchor = AnchorStyles.Right;
            btnSearchLibraryCard.BackColor = Color.DeepSkyBlue;
            btnSearchLibraryCard.FlatAppearance.BorderSize = 0;
            btnSearchLibraryCard.FlatStyle = FlatStyle.Flat;
            btnSearchLibraryCard.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearchLibraryCard.ForeColor = SystemColors.Window;
            btnSearchLibraryCard.Location = new Point(400, 10);
            btnSearchLibraryCard.Name = "btnSearchLibraryCard";
            btnSearchLibraryCard.Size = new Size(90, 28);
            btnSearchLibraryCard.TabIndex = 8;
            btnSearchLibraryCard.Text = "Tìm kiếm";
            btnSearchLibraryCard.UseVisualStyleBackColor = false;
            btnSearchLibraryCard.Click += btnSearchLibraryCard_Click;
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
            // txtSearchLibraryCard
            // 
            txtSearchLibraryCard.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSearchLibraryCard.BorderStyle = BorderStyle.FixedSingle;
            txtSearchLibraryCard.ForeColor = Color.Gray;
            txtSearchLibraryCard.Location = new Point(20, 12);
            txtSearchLibraryCard.Name = "txtSearchLibraryCard";
            txtSearchLibraryCard.PlaceholderColor = Color.Gray;
            txtSearchLibraryCard.PlaceholderText = "Nhập mã thẻ, mã độc giả, ngày tạo ...";
            txtSearchLibraryCard.Size = new Size(360, 23);
            txtSearchLibraryCard.TabIndex = 1;
            txtSearchLibraryCard.Text = "Nhập mã thẻ, mã độc giả, ngày tạo ...";
            txtSearchLibraryCard.TextColor = Color.Black;
            txtSearchLibraryCard.KeyDown += txtSearchLibraryCard_KeyDown;
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
            pnlReaderInput.ResumeLayout(false);
            pnlReaderInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReaders).EndInit();
            panel3.ResumeLayout(false);
            tbcReaders.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            tabPage2.ResumeLayout(false);
            pnlLibraryCardInput.ResumeLayout(false);
            pnlLibraryCardInput.PerformLayout();
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
        private Panel pnlReaderInput;
        private DataGridView dgvReaders;
        private Panel panel3;
        private TabControl tbcReaders;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel panel4;
        private Label label1;
        private Label lblTitle;
        private Label label2;
        private TextBox txtReaderID;
        private TextBox txtEmail;
        private Label label7;
        private TextBox txtAddress;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txtFullName;
        private Label label3;
        private TextBox txtPhoneNumber;
        private Label label8;
        private DateTimePicker dtpDateOfBirth;
        private ComboBox cboGender;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnAdd;
        private Panel panel5;
        private UICustom.PlaceholderTextBox txtSearchReader;
        private Button btnSearchReader;
        private Panel panel7;
        private Panel panel8;
        private Button button1;
        private UICustom.PlaceholderTextBox txtSearchLibraryCard;
        private Panel panel6;
        private Label label10;
        private Label label11;
        private Button btnSearchLibraryCard;
        private Panel pnlLibraryCardInput;
        private Button btnDeleteCard;
        private Button btnEditCard;
        private Button btnAddCard;
        private ComboBox cboStatus;
        private DateTimePicker dtpIssueDate;
        private Label label15;
        private Label label16;
        private Label label17;
        private TextBox txtCardReaderID;
        private Label label18;
        private TextBox txtCardID;
        private Label label19;
        private Panel panel9;
        private DataGridView dgvLibraryCards;
        private PictureBox pctBoxQRCode;
        private Button btnCancel;
        private Button btnSave;
        private DateTimePicker dtpRegistrationDate;
        private Label label13;
        private Button btnCancelCard;
        private Button btnSaveCard;
        private DateTimePicker dtpExpiryDate;
        private Label label14;
        private Button btnReloadReaders;
        private Button btnReloadCards;
    }
}