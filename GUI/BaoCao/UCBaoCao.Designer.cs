namespace GUI.BaoCao
{
    partial class UCBaoCao
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle57 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle58 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle59 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle60 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle61 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle62 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle63 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle64 = new DataGridViewCellStyle();
            tabControl = new TabControl();
            tabTheoKhoang = new TabPage();
            panel1 = new Panel();
            dgvTheoKhoang = new DataGridView();
            panel2 = new Panel();
            lblKetQua = new Label();
            btnTimKiem = new Button();
            dtpDenNgay = new DateTimePicker();
            label2 = new Label();
            dtpTuNgay = new DateTimePicker();
            label1 = new Label();
            tabTopSach = new TabPage();
            dgvTopSach = new DataGridView();
            panel3 = new Panel();
            btnLoadTopSach = new Button();
            numTopSach = new NumericUpDown();
            label3 = new Label();
            tabTopDocGia = new TabPage();
            dgvTopDocGia = new DataGridView();
            panel4 = new Panel();
            btnLoadTopDocGia = new Button();
            numTopDocGia = new NumericUpDown();
            label4 = new Label();
            tabQuaHan = new TabPage();
            dgvQuaHan = new DataGridView();
            panel5 = new Panel();
            btnLoadQuaHan = new Button();
            label5 = new Label();
            tabControl.SuspendLayout();
            tabTheoKhoang.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTheoKhoang).BeginInit();
            panel2.SuspendLayout();
            tabTopSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopSach).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTopSach).BeginInit();
            tabTopDocGia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopDocGia).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTopDocGia).BeginInit();
            tabQuaHan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvQuaHan).BeginInit();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabTheoKhoang);
            tabControl.Controls.Add(tabTopSach);
            tabControl.Controls.Add(tabTopDocGia);
            tabControl.Controls.Add(tabQuaHan);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Font = new Font("Segoe UI", 10F);
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1000, 600);
            tabControl.TabIndex = 0;
            // 
            // tabTheoKhoang
            // 
            tabTheoKhoang.BackColor = SystemColors.ControlLight;
            tabTheoKhoang.Controls.Add(panel1);
            tabTheoKhoang.Controls.Add(panel2);
            tabTheoKhoang.Location = new Point(4, 32);
            tabTheoKhoang.Name = "tabTheoKhoang";
            tabTheoKhoang.Padding = new Padding(3);
            tabTheoKhoang.Size = new Size(992, 564);
            tabTheoKhoang.TabIndex = 0;
            tabTheoKhoang.Text = "Thống kê theo khoảng thời gian";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(dgvTheoKhoang);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 103);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(986, 458);
            panel1.TabIndex = 1;
            // 
            // dgvTheoKhoang
            // 
            dgvTheoKhoang.AllowUserToAddRows = false;
            dgvTheoKhoang.AllowUserToDeleteRows = false;
            dgvTheoKhoang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTheoKhoang.BackgroundColor = Color.White;
            dgvTheoKhoang.BorderStyle = BorderStyle.None;
            dgvTheoKhoang.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle57.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle57.BackColor = Color.CornflowerBlue;
            dataGridViewCellStyle57.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle57.ForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle57.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle57.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle57.WrapMode = DataGridViewTriState.True;
            dgvTheoKhoang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle57;
            dgvTheoKhoang.ColumnHeadersHeight = 40;
            dgvTheoKhoang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle58.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle58.BackColor = SystemColors.Window;
            dataGridViewCellStyle58.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle58.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle58.Padding = new Padding(5);
            dataGridViewCellStyle58.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle58.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle58.WrapMode = DataGridViewTriState.False;
            dgvTheoKhoang.DefaultCellStyle = dataGridViewCellStyle58;
            dgvTheoKhoang.Dock = DockStyle.Fill;
            dgvTheoKhoang.EnableHeadersVisualStyles = false;
            dgvTheoKhoang.GridColor = SystemColors.ControlLight;
            dgvTheoKhoang.Location = new Point(10, 10);
            dgvTheoKhoang.Name = "dgvTheoKhoang";
            dgvTheoKhoang.ReadOnly = true;
            dgvTheoKhoang.RowHeadersVisible = false;
            dgvTheoKhoang.RowHeadersWidth = 51;
            dgvTheoKhoang.RowTemplate.Height = 40;
            dgvTheoKhoang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTheoKhoang.Size = new Size(966, 438);
            dgvTheoKhoang.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(lblKetQua);
            panel2.Controls.Add(btnTimKiem);
            panel2.Controls.Add(dtpDenNgay);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(dtpTuNgay);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(986, 100);
            panel2.TabIndex = 0;
            // 
            // lblKetQua
            // 
            lblKetQua.AutoSize = true;
            lblKetQua.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblKetQua.ForeColor = Color.DarkBlue;
            lblKetQua.Location = new Point(10, 70);
            lblKetQua.Name = "lblKetQua";
            lblKetQua.Size = new Size(0, 23);
            lblKetQua.TabIndex = 5;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.DeepSkyBlue;
            btnTimKiem.FlatAppearance.BorderSize = 0;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(570, 20);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(120, 35);
            btnTimKiem.TabIndex = 4;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            dtpDenNgay.Font = new Font("Segoe UI", 10F);
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.Location = new Point(380, 23);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(150, 30);
            dtpDenNgay.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(287, 26);
            label2.Name = "label2";
            label2.Size = new Size(87, 23);
            label2.TabIndex = 2;
            label2.Text = "Đến ngày:";
            label2.Click += label2_Click;
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            dtpTuNgay.Font = new Font("Segoe UI", 10F);
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.Location = new Point(100, 23);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(150, 30);
            dtpTuNgay.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(10, 26);
            label1.Name = "label1";
            label1.Size = new Size(75, 23);
            label1.TabIndex = 0;
            label1.Text = "Từ ngày:";
            label1.Click += label1_Click;
            // 
            // tabTopSach
            // 
            tabTopSach.BackColor = SystemColors.ControlLight;
            tabTopSach.Controls.Add(dgvTopSach);
            tabTopSach.Controls.Add(panel3);
            tabTopSach.Location = new Point(4, 32);
            tabTopSach.Name = "tabTopSach";
            tabTopSach.Padding = new Padding(3);
            tabTopSach.Size = new Size(992, 564);
            tabTopSach.TabIndex = 1;
            tabTopSach.Text = "Top sách mượn nhiều";
            // 
            // dgvTopSach
            // 
            dgvTopSach.AllowUserToAddRows = false;
            dgvTopSach.AllowUserToDeleteRows = false;
            dgvTopSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTopSach.BackgroundColor = Color.White;
            dgvTopSach.BorderStyle = BorderStyle.None;
            dgvTopSach.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle59.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle59.BackColor = Color.CornflowerBlue;
            dataGridViewCellStyle59.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle59.ForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle59.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle59.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle59.WrapMode = DataGridViewTriState.True;
            dgvTopSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle59;
            dgvTopSach.ColumnHeadersHeight = 40;
            dgvTopSach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle60.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle60.BackColor = SystemColors.Window;
            dataGridViewCellStyle60.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle60.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle60.Padding = new Padding(5);
            dataGridViewCellStyle60.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle60.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle60.WrapMode = DataGridViewTriState.False;
            dgvTopSach.DefaultCellStyle = dataGridViewCellStyle60;
            dgvTopSach.Dock = DockStyle.Fill;
            dgvTopSach.EnableHeadersVisualStyles = false;
            dgvTopSach.GridColor = SystemColors.ControlLight;
            dgvTopSach.Location = new Point(3, 83);
            dgvTopSach.Name = "dgvTopSach";
            dgvTopSach.ReadOnly = true;
            dgvTopSach.RowHeadersVisible = false;
            dgvTopSach.RowHeadersWidth = 51;
            dgvTopSach.RowTemplate.Height = 40;
            dgvTopSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTopSach.Size = new Size(986, 478);
            dgvTopSach.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(btnLoadTopSach);
            panel3.Controls.Add(numTopSach);
            panel3.Controls.Add(label3);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(986, 80);
            panel3.TabIndex = 0;
            // 
            // btnLoadTopSach
            // 
            btnLoadTopSach.BackColor = Color.DeepSkyBlue;
            btnLoadTopSach.FlatAppearance.BorderSize = 0;
            btnLoadTopSach.FlatStyle = FlatStyle.Flat;
            btnLoadTopSach.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnLoadTopSach.ForeColor = Color.White;
            btnLoadTopSach.Location = new Point(230, 20);
            btnLoadTopSach.Name = "btnLoadTopSach";
            btnLoadTopSach.Size = new Size(120, 35);
            btnLoadTopSach.TabIndex = 2;
            btnLoadTopSach.Text = "Xem";
            btnLoadTopSach.UseVisualStyleBackColor = false;
            btnLoadTopSach.Click += btnLoadTopSach_Click;
            // 
            // numTopSach
            // 
            numTopSach.Font = new Font("Segoe UI", 10F);
            numTopSach.Location = new Point(120, 25);
            numTopSach.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numTopSach.Name = "numTopSach";
            numTopSach.Size = new Size(80, 30);
            numTopSach.TabIndex = 1;
            numTopSach.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(10, 27);
            label3.Name = "label3";
            label3.Size = new Size(105, 23);
            label3.TabIndex = 0;
            label3.Text = "Hiển thị top:";
            // 
            // tabTopDocGia
            // 
            tabTopDocGia.BackColor = SystemColors.ControlLight;
            tabTopDocGia.Controls.Add(dgvTopDocGia);
            tabTopDocGia.Controls.Add(panel4);
            tabTopDocGia.Location = new Point(4, 32);
            tabTopDocGia.Name = "tabTopDocGia";
            tabTopDocGia.Size = new Size(992, 564);
            tabTopDocGia.TabIndex = 2;
            tabTopDocGia.Text = "Top độc giả tích cực";
            // 
            // dgvTopDocGia
            // 
            dgvTopDocGia.AllowUserToAddRows = false;
            dgvTopDocGia.AllowUserToDeleteRows = false;
            dgvTopDocGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTopDocGia.BackgroundColor = Color.White;
            dgvTopDocGia.BorderStyle = BorderStyle.None;
            dgvTopDocGia.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle61.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle61.BackColor = Color.CornflowerBlue;
            dataGridViewCellStyle61.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle61.ForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle61.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle61.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle61.WrapMode = DataGridViewTriState.True;
            dgvTopDocGia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle61;
            dgvTopDocGia.ColumnHeadersHeight = 40;
            dgvTopDocGia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle62.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle62.BackColor = SystemColors.Window;
            dataGridViewCellStyle62.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle62.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle62.Padding = new Padding(5);
            dataGridViewCellStyle62.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle62.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle62.WrapMode = DataGridViewTriState.False;
            dgvTopDocGia.DefaultCellStyle = dataGridViewCellStyle62;
            dgvTopDocGia.Dock = DockStyle.Fill;
            dgvTopDocGia.EnableHeadersVisualStyles = false;
            dgvTopDocGia.GridColor = SystemColors.ControlLight;
            dgvTopDocGia.Location = new Point(0, 80);
            dgvTopDocGia.Name = "dgvTopDocGia";
            dgvTopDocGia.ReadOnly = true;
            dgvTopDocGia.RowHeadersVisible = false;
            dgvTopDocGia.RowHeadersWidth = 51;
            dgvTopDocGia.RowTemplate.Height = 40;
            dgvTopDocGia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTopDocGia.Size = new Size(992, 484);
            dgvTopDocGia.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(btnLoadTopDocGia);
            panel4.Controls.Add(numTopDocGia);
            panel4.Controls.Add(label4);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(992, 80);
            panel4.TabIndex = 0;
            // 
            // btnLoadTopDocGia
            // 
            btnLoadTopDocGia.BackColor = Color.DeepSkyBlue;
            btnLoadTopDocGia.FlatAppearance.BorderSize = 0;
            btnLoadTopDocGia.FlatStyle = FlatStyle.Flat;
            btnLoadTopDocGia.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnLoadTopDocGia.ForeColor = Color.White;
            btnLoadTopDocGia.Location = new Point(230, 20);
            btnLoadTopDocGia.Name = "btnLoadTopDocGia";
            btnLoadTopDocGia.Size = new Size(120, 35);
            btnLoadTopDocGia.TabIndex = 2;
            btnLoadTopDocGia.Text = " Xem";
            btnLoadTopDocGia.UseVisualStyleBackColor = false;
            btnLoadTopDocGia.Click += btnLoadTopDocGia_Click;
            // 
            // numTopDocGia
            // 
            numTopDocGia.Font = new Font("Segoe UI", 10F);
            numTopDocGia.Location = new Point(120, 25);
            numTopDocGia.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numTopDocGia.Name = "numTopDocGia";
            numTopDocGia.Size = new Size(80, 30);
            numTopDocGia.TabIndex = 1;
            numTopDocGia.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(10, 27);
            label4.Name = "label4";
            label4.Size = new Size(105, 23);
            label4.TabIndex = 0;
            label4.Text = "Hiển thị top:";
            label4.Click += label4_Click;
            // 
            // tabQuaHan
            // 
            tabQuaHan.BackColor = SystemColors.ControlLight;
            tabQuaHan.Controls.Add(dgvQuaHan);
            tabQuaHan.Controls.Add(panel5);
            tabQuaHan.Location = new Point(4, 32);
            tabQuaHan.Name = "tabQuaHan";
            tabQuaHan.Size = new Size(992, 564);
            tabQuaHan.TabIndex = 3;
            tabQuaHan.Text = "Báo cáo quá hạn";
            // 
            // dgvQuaHan
            // 
            dgvQuaHan.AllowUserToAddRows = false;
            dgvQuaHan.AllowUserToDeleteRows = false;
            dgvQuaHan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvQuaHan.BackgroundColor = Color.White;
            dgvQuaHan.BorderStyle = BorderStyle.None;
            dgvQuaHan.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle63.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle63.BackColor = Color.CornflowerBlue;
            dataGridViewCellStyle63.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle63.ForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle63.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle63.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle63.WrapMode = DataGridViewTriState.True;
            dgvQuaHan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle63;
            dgvQuaHan.ColumnHeadersHeight = 40;
            dgvQuaHan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle64.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle64.BackColor = SystemColors.Window;
            dataGridViewCellStyle64.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle64.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle64.Padding = new Padding(5);
            dataGridViewCellStyle64.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle64.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle64.WrapMode = DataGridViewTriState.False;
            dgvQuaHan.DefaultCellStyle = dataGridViewCellStyle64;
            dgvQuaHan.Dock = DockStyle.Fill;
            dgvQuaHan.EnableHeadersVisualStyles = false;
            dgvQuaHan.GridColor = SystemColors.ControlLight;
            dgvQuaHan.Location = new Point(0, 80);
            dgvQuaHan.Name = "dgvQuaHan";
            dgvQuaHan.ReadOnly = true;
            dgvQuaHan.RowHeadersVisible = false;
            dgvQuaHan.RowHeadersWidth = 51;
            dgvQuaHan.RowTemplate.Height = 40;
            dgvQuaHan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvQuaHan.Size = new Size(992, 484);
            dgvQuaHan.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(btnLoadQuaHan);
            panel5.Controls.Add(label5);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(992, 80);
            panel5.TabIndex = 0;
            // 
            // btnLoadQuaHan
            // 
            btnLoadQuaHan.BackColor = Color.DeepSkyBlue;
            btnLoadQuaHan.FlatAppearance.BorderSize = 0;
            btnLoadQuaHan.FlatStyle = FlatStyle.Flat;
            btnLoadQuaHan.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnLoadQuaHan.ForeColor = Color.White;
            btnLoadQuaHan.Location = new Point(270, 20);
            btnLoadQuaHan.Name = "btnLoadQuaHan";
            btnLoadQuaHan.Size = new Size(150, 35);
            btnLoadQuaHan.TabIndex = 1;
            btnLoadQuaHan.Text = "Tải dữ liệu";
            btnLoadQuaHan.UseVisualStyleBackColor = false;
            btnLoadQuaHan.Click += btnLoadQuaHan_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(10, 27);
            label5.Name = "label5";
            label5.Size = new Size(262, 23);
            label5.TabIndex = 0;
            label5.Text = "Danh sách độc giả chưa trả sách:";
            label5.Click += label5_Click;
            // 
            // UCBaoCao
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(tabControl);
            Name = "UCBaoCao";
            Size = new Size(1000, 600);
            Load += UCBaoCao_Load;
            tabControl.ResumeLayout(false);
            tabTheoKhoang.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTheoKhoang).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tabTopSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTopSach).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numTopSach).EndInit();
            tabTopDocGia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTopDocGia).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numTopDocGia).EndInit();
            tabQuaHan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvQuaHan).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabTheoKhoang;
        private TabPage tabTopSach;
        private TabPage tabTopDocGia;
        private TabPage tabQuaHan;
        private Panel panel1;
        private DataGridView dgvTheoKhoang;
        private Panel panel2;
        private DateTimePicker dtpTuNgay;
        private Label label1;
        private DateTimePicker dtpDenNgay;
        private Label label2;
        private Button btnTimKiem;
        private Label lblKetQua;
        private DataGridView dgvTopSach;
        private Panel panel3;
        private NumericUpDown numTopSach;
        private Label label3;
        private Button btnLoadTopSach;
        private DataGridView dgvTopDocGia;
        private Panel panel4;
        private Button btnLoadTopDocGia;
        private NumericUpDown numTopDocGia;
        private Label label4;
        private DataGridView dgvQuaHan;
        private Panel panel5;
        private Label label5;
        private Button btnLoadQuaHan;
    }
}
