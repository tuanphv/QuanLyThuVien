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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            label1 = new Label();
            tabControl1 = new TabControl();
            tabBaoCaoNo = new TabPage();
            dgvQuaHan = new DataGridView();
            panel2 = new Panel();
            btnExportExcel = new Button();
            btnLoadQuaHan = new Button();
            txtTimKiem = new TextBox();
            label2 = new Label();
            tabThongKeSach = new TabPage();
            dgvThongKeSach = new DataGridView();
            panel3 = new Panel();
            btnExportSach = new Button();
            txtTimKiemSach = new TextBox();
            label3 = new Label();
            tabThongKeMuonTra = new TabPage();
            dgvThongKeMuonTra = new DataGridView();
            panel4 = new Panel();
            dtpDenNgay = new DateTimePicker();
            label5 = new Label();
            dtpTuNgay = new DateTimePicker();
            label4 = new Label();
            btnExportMuonTra = new Button();
            btnLoadThongKe = new Button();
            tabTopStatistics = new TabPage();
            splitContainer1 = new SplitContainer();
            dgvTopSach = new DataGridView();
            panel5 = new Panel();
            btnRefreshTopSach = new Button();
            cboTimePeriodSach = new ComboBox();
            label8 = new Label();
            label6 = new Label();
            dgvTopDocGia = new DataGridView();
            panel6 = new Panel();
            btnRefreshTopDocGia = new Button();
            cboTimePeriodDocGia = new ComboBox();
            label9 = new Label();
            label7 = new Label();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabBaoCaoNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvQuaHan).BeginInit();
            panel2.SuspendLayout();
            tabThongKeSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThongKeSach).BeginInit();
            panel3.SuspendLayout();
            tabThongKeMuonTra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThongKeMuonTra).BeginInit();
            panel4.SuspendLayout();
            tabTopStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopSach).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopDocGia).BeginInit();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1633, 70);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8F, FontStyle.Bold);
            label1.Location = new Point(20, 19);
            label1.Name = "label1";
            label1.Size = new Size(296, 37);
            label1.TabIndex = 0;
            label1.Text = "Báo cáo && Thống kê";
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabBaoCaoNo);
            tabControl1.Controls.Add(tabThongKeSach);
            tabControl1.Controls.Add(tabThongKeMuonTra);
            tabControl1.Controls.Add(tabTopStatistics);
            tabControl1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            tabControl1.Location = new Point(20, 90);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1593, 644);
            tabControl1.TabIndex = 3;
            // 
            // tabBaoCaoNo
            // 
            tabBaoCaoNo.BackColor = SystemColors.ControlLight;
            tabBaoCaoNo.Controls.Add(dgvQuaHan);
            tabBaoCaoNo.Controls.Add(panel2);
            tabBaoCaoNo.Location = new Point(4, 28);
            tabBaoCaoNo.Name = "tabBaoCaoNo";
            tabBaoCaoNo.Padding = new Padding(3);
            tabBaoCaoNo.Size = new Size(1585, 612);
            tabBaoCaoNo.TabIndex = 0;
            tabBaoCaoNo.Text = "📊 Báo cáo nợ độc giả";
            // 
            // dgvQuaHan
            // 
            dgvQuaHan.AllowUserToAddRows = false;
            dgvQuaHan.AllowUserToDeleteRows = false;
            dgvQuaHan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvQuaHan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvQuaHan.BackgroundColor = Color.White;
            dgvQuaHan.BorderStyle = BorderStyle.None;
            dgvQuaHan.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvQuaHan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvQuaHan.ColumnHeadersHeight = 40;
            dgvQuaHan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvQuaHan.DefaultCellStyle = dataGridViewCellStyle2;
            dgvQuaHan.EnableHeadersVisualStyles = false;
            dgvQuaHan.GridColor = SystemColors.ControlLight;
            dgvQuaHan.Location = new Point(6, 56);
            dgvQuaHan.Margin = new Padding(3, 2, 3, 2);
            dgvQuaHan.Name = "dgvQuaHan";
            dgvQuaHan.ReadOnly = true;
            dgvQuaHan.RowHeadersVisible = false;
            dgvQuaHan.RowHeadersWidth = 51;
            dgvQuaHan.RowTemplate.Height = 50;
            dgvQuaHan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvQuaHan.Size = new Size(1573, 550);
            dgvQuaHan.TabIndex = 2;
            dgvQuaHan.CellDoubleClick += dgvQuaHan_CellDoubleClick;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.White;
            panel2.Controls.Add(btnExportExcel);
            panel2.Controls.Add(btnLoadQuaHan);
            panel2.Controls.Add(txtTimKiem);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(6, 6);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(1573, 45);
            panel2.TabIndex = 1;
            // 
            // btnExportExcel
            // 
            btnExportExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportExcel.BackColor = Color.SeaGreen;
            btnExportExcel.FlatAppearance.BorderSize = 0;
            btnExportExcel.FlatStyle = FlatStyle.Flat;
            btnExportExcel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnExportExcel.ForeColor = Color.White;
            btnExportExcel.Location = new Point(1450, 9);
            btnExportExcel.Margin = new Padding(3, 2, 3, 2);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(103, 26);
            btnExportExcel.TabIndex = 4;
            btnExportExcel.Text = "Xuất Excel";
            btnExportExcel.UseVisualStyleBackColor = false;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // btnLoadQuaHan
            // 
            btnLoadQuaHan.BackColor = Color.SlateGray;
            btnLoadQuaHan.FlatAppearance.BorderSize = 0;
            btnLoadQuaHan.FlatStyle = FlatStyle.Flat;
            btnLoadQuaHan.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnLoadQuaHan.ForeColor = Color.White;
            btnLoadQuaHan.Location = new Point(9, 9);
            btnLoadQuaHan.Margin = new Padding(3, 2, 3, 2);
            btnLoadQuaHan.Name = "btnLoadQuaHan";
            btnLoadQuaHan.Size = new Size(170, 26);
            btnLoadQuaHan.TabIndex = 1;
            btnLoadQuaHan.Text = "Báo cáo theo phiếu";
            btnLoadQuaHan.UseVisualStyleBackColor = false;
            btnLoadQuaHan.Visible = false;
            btnLoadQuaHan.Click += btnLoadQuaHan_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTimKiem.Font = new Font("Segoe UI", 10F);
            txtTimKiem.Location = new Point(1130, 9);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập mã hoặc tên độc giả...";
            txtTimKiem.Size = new Size(300, 25);
            txtTimKiem.TabIndex = 3;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(1050, 12);
            label2.Name = "label2";
            label2.Size = new Size(67, 19);
            label2.TabIndex = 2;
            label2.Text = "Tìm kiếm:";
            // 
            // tabThongKeSach
            // 
            tabThongKeSach.BackColor = SystemColors.ControlLight;
            tabThongKeSach.Controls.Add(dgvThongKeSach);
            tabThongKeSach.Controls.Add(panel3);
            tabThongKeSach.Location = new Point(4, 28);
            tabThongKeSach.Name = "tabThongKeSach";
            tabThongKeSach.Padding = new Padding(3);
            tabThongKeSach.Size = new Size(1585, 612);
            tabThongKeSach.TabIndex = 1;
            tabThongKeSach.Text = "📚 Thống kê sách";
            // 
            // dgvThongKeSach
            // 
            dgvThongKeSach.AllowUserToAddRows = false;
            dgvThongKeSach.AllowUserToDeleteRows = false;
            dgvThongKeSach.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvThongKeSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThongKeSach.BackgroundColor = Color.White;
            dgvThongKeSach.BorderStyle = BorderStyle.None;
            dgvThongKeSach.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvThongKeSach.ColumnHeadersHeight = 40;
            dgvThongKeSach.EnableHeadersVisualStyles = false;
            dgvThongKeSach.GridColor = SystemColors.ControlLight;
            dgvThongKeSach.Location = new Point(6, 56);
            dgvThongKeSach.Name = "dgvThongKeSach";
            dgvThongKeSach.ReadOnly = true;
            dgvThongKeSach.RowHeadersVisible = false;
            dgvThongKeSach.RowTemplate.Height = 50;
            dgvThongKeSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThongKeSach.Size = new Size(1573, 550);
            dgvThongKeSach.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.White;
            panel3.Controls.Add(btnExportSach);
            panel3.Controls.Add(txtTimKiemSach);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(6, 6);
            panel3.Name = "panel3";
            panel3.Size = new Size(1573, 45);
            panel3.TabIndex = 0;
            // 
            // btnExportSach
            // 
            btnExportSach.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportSach.BackColor = Color.SeaGreen;
            btnExportSach.FlatAppearance.BorderSize = 0;
            btnExportSach.FlatStyle = FlatStyle.Flat;
            btnExportSach.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnExportSach.ForeColor = Color.White;
            btnExportSach.Location = new Point(1450, 9);
            btnExportSach.Name = "btnExportSach";
            btnExportSach.Size = new Size(103, 26);
            btnExportSach.TabIndex = 2;
            btnExportSach.Text = "Xuất Excel";
            btnExportSach.UseVisualStyleBackColor = false;
            btnExportSach.Click += btnExportSach_Click;
            // 
            // txtTimKiemSach
            // 
            txtTimKiemSach.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTimKiemSach.Font = new Font("Segoe UI", 10F);
            txtTimKiemSach.Location = new Point(1130, 9);
            txtTimKiemSach.Name = "txtTimKiemSach";
            txtTimKiemSach.PlaceholderText = "Nhập tên sách...";
            txtTimKiemSach.Size = new Size(300, 25);
            txtTimKiemSach.TabIndex = 1;
            txtTimKiemSach.TextChanged += txtTimKiemSach_TextChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(1050, 12);
            label3.Name = "label3";
            label3.Size = new Size(67, 19);
            label3.TabIndex = 0;
            label3.Text = "Tìm kiếm:";
            // 
            // tabThongKeMuonTra
            // 
            tabThongKeMuonTra.BackColor = SystemColors.ControlLight;
            tabThongKeMuonTra.Controls.Add(dgvThongKeMuonTra);
            tabThongKeMuonTra.Controls.Add(panel4);
            tabThongKeMuonTra.Location = new Point(4, 28);
            tabThongKeMuonTra.Name = "tabThongKeMuonTra";
            tabThongKeMuonTra.Padding = new Padding(3);
            tabThongKeMuonTra.Size = new Size(1585, 612);
            tabThongKeMuonTra.TabIndex = 2;
            tabThongKeMuonTra.Text = "📈 Thống kê mượn/trả";
            // 
            // dgvThongKeMuonTra
            // 
            dgvThongKeMuonTra.AllowUserToAddRows = false;
            dgvThongKeMuonTra.AllowUserToDeleteRows = false;
            dgvThongKeMuonTra.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvThongKeMuonTra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThongKeMuonTra.BackgroundColor = Color.White;
            dgvThongKeMuonTra.BorderStyle = BorderStyle.None;
            dgvThongKeMuonTra.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvThongKeMuonTra.ColumnHeadersHeight = 40;
            dgvThongKeMuonTra.EnableHeadersVisualStyles = false;
            dgvThongKeMuonTra.GridColor = SystemColors.ControlLight;
            dgvThongKeMuonTra.Location = new Point(6, 56);
            dgvThongKeMuonTra.Name = "dgvThongKeMuonTra";
            dgvThongKeMuonTra.ReadOnly = true;
            dgvThongKeMuonTra.RowHeadersVisible = false;
            dgvThongKeMuonTra.RowTemplate.Height = 50;
            dgvThongKeMuonTra.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThongKeMuonTra.Size = new Size(1573, 550);
            dgvThongKeMuonTra.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel4.BackColor = Color.White;
            panel4.Controls.Add(dtpDenNgay);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(dtpTuNgay);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(btnExportMuonTra);
            panel4.Controls.Add(btnLoadThongKe);
            panel4.Location = new Point(6, 6);
            panel4.Name = "panel4";
            panel4.Size = new Size(1573, 45);
            panel4.TabIndex = 0;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Font = new Font("Segoe UI", 10F);
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(360, 10);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(120, 25);
            dtpDenNgay.TabIndex = 5;
            dtpDenNgay.ValueChanged += dtpDenNgay_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(285, 13);
            label5.Name = "label5";
            label5.Size = new Size(69, 19);
            label5.TabIndex = 4;
            label5.Text = "Đến ngày:";
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Font = new Font("Segoe UI", 10F);
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(145, 10);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(120, 25);
            dtpTuNgay.TabIndex = 3;
            dtpTuNgay.ValueChanged += dtpTuNgay_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(76, 13);
            label4.Name = "label4";
            label4.Size = new Size(63, 19);
            label4.TabIndex = 2;
            label4.Text = "Từ ngày:";
            // 
            // btnExportMuonTra
            // 
            btnExportMuonTra.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportMuonTra.BackColor = Color.SeaGreen;
            btnExportMuonTra.FlatAppearance.BorderSize = 0;
            btnExportMuonTra.FlatStyle = FlatStyle.Flat;
            btnExportMuonTra.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnExportMuonTra.ForeColor = Color.White;
            btnExportMuonTra.Location = new Point(1450, 9);
            btnExportMuonTra.Name = "btnExportMuonTra";
            btnExportMuonTra.Size = new Size(103, 26);
            btnExportMuonTra.TabIndex = 1;
            btnExportMuonTra.Text = "Xuất Excel";
            btnExportMuonTra.UseVisualStyleBackColor = false;
            btnExportMuonTra.Click += btnExportMuonTra_Click;
            // 
            // btnLoadThongKe
            // 
            btnLoadThongKe.BackColor = Color.RoyalBlue;
            btnLoadThongKe.FlatAppearance.BorderSize = 0;
            btnLoadThongKe.FlatStyle = FlatStyle.Flat;
            btnLoadThongKe.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnLoadThongKe.ForeColor = Color.White;
            btnLoadThongKe.Location = new Point(9, 9);
            btnLoadThongKe.Name = "btnLoadThongKe";
            btnLoadThongKe.Size = new Size(60, 26);
            btnLoadThongKe.TabIndex = 0;
            btnLoadThongKe.Text = "Xem";
            btnLoadThongKe.UseVisualStyleBackColor = false;
            btnLoadThongKe.Visible = false;
            btnLoadThongKe.Click += btnLoadThongKe_Click;
            // 
            // tabTopStatistics
            // 
            tabTopStatistics.BackColor = SystemColors.ControlLight;
            tabTopStatistics.Controls.Add(splitContainer1);
            tabTopStatistics.Location = new Point(4, 28);
            tabTopStatistics.Name = "tabTopStatistics";
            tabTopStatistics.Padding = new Padding(3);
            tabTopStatistics.Size = new Size(1585, 612);
            tabTopStatistics.TabIndex = 3;
            tabTopStatistics.Text = "🏆 Top sách & độc giả";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvTopSach);
            splitContainer1.Panel1.Controls.Add(panel5);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvTopDocGia);
            splitContainer1.Panel2.Controls.Add(panel6);
            splitContainer1.Size = new Size(1579, 606);
            splitContainer1.SplitterDistance = 300;
            splitContainer1.TabIndex = 0;
            // 
            // dgvTopSach
            // 
            dgvTopSach.AllowUserToAddRows = false;
            dgvTopSach.AllowUserToDeleteRows = false;
            dgvTopSach.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTopSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTopSach.BackgroundColor = Color.White;
            dgvTopSach.BorderStyle = BorderStyle.None;
            dgvTopSach.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTopSach.ColumnHeadersHeight = 40;
            dgvTopSach.EnableHeadersVisualStyles = false;
            dgvTopSach.GridColor = SystemColors.ControlLight;
            dgvTopSach.Location = new Point(6, 51);
            dgvTopSach.Name = "dgvTopSach";
            dgvTopSach.ReadOnly = true;
            dgvTopSach.RowHeadersVisible = false;
            dgvTopSach.RowTemplate.Height = 50;
            dgvTopSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTopSach.Size = new Size(1567, 243);
            dgvTopSach.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel5.BackColor = Color.White;
            panel5.Controls.Add(btnRefreshTopSach);
            panel5.Controls.Add(cboTimePeriodSach);
            panel5.Controls.Add(label8);
            panel5.Controls.Add(label6);
            panel5.Location = new Point(6, 6);
            panel5.Name = "panel5";
            panel5.Size = new Size(1567, 40);
            panel5.TabIndex = 0;
            // 
            // btnRefreshTopSach
            // 
            btnRefreshTopSach.BackColor = Color.RoyalBlue;
            btnRefreshTopSach.FlatAppearance.BorderSize = 0;
            btnRefreshTopSach.FlatStyle = FlatStyle.Flat;
            btnRefreshTopSach.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnRefreshTopSach.ForeColor = Color.White;
            btnRefreshTopSach.Location = new Point(580, 7);
            btnRefreshTopSach.Name = "btnRefreshTopSach";
            btnRefreshTopSach.Size = new Size(80, 26);
            btnRefreshTopSach.TabIndex = 3;
            btnRefreshTopSach.Text = "Xem";
            btnRefreshTopSach.UseVisualStyleBackColor = false;
            btnRefreshTopSach.Click += btnRefreshTopSach_Click;
            // 
            // cboTimePeriodSach
            // 
            cboTimePeriodSach.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTimePeriodSach.Font = new Font("Segoe UI", 10F);
            cboTimePeriodSach.FormattingEnabled = true;
            cboTimePeriodSach.Items.AddRange(new object[] { "Toàn thời gian", "7 ngày qua", "30 ngày qua" });
            cboTimePeriodSach.Location = new Point(380, 8);
            cboTimePeriodSach.Name = "cboTimePeriodSach";
            cboTimePeriodSach.Size = new Size(180, 25);
            cboTimePeriodSach.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F);
            label8.Location = new Point(280, 11);
            label8.Name = "label8";
            label8.Size = new Size(94, 19);
            label8.TabIndex = 1;
            label8.Text = "Khoảng thời gian:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(10, 10);
            label6.Name = "label6";
            label6.Size = new Size(229, 21);
            label6.TabIndex = 0;
            label6.Text = "🏆 Top 10 sách mượn nhiều";
            // 
            // dgvTopDocGia
            // 
            dgvTopDocGia.AllowUserToAddRows = false;
            dgvTopDocGia.AllowUserToDeleteRows = false;
            dgvTopDocGia.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTopDocGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTopDocGia.BackgroundColor = Color.White;
            dgvTopDocGia.BorderStyle = BorderStyle.None;
            dgvTopDocGia.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTopDocGia.ColumnHeadersHeight = 40;
            dgvTopDocGia.EnableHeadersVisualStyles = false;
            dgvTopDocGia.GridColor = SystemColors.ControlLight;
            dgvTopDocGia.Location = new Point(6, 51);
            dgvTopDocGia.Name = "dgvTopDocGia";
            dgvTopDocGia.ReadOnly = true;
            dgvTopDocGia.RowHeadersVisible = false;
            dgvTopDocGia.RowTemplate.Height = 50;
            dgvTopDocGia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTopDocGia.Size = new Size(1567, 243);
            dgvTopDocGia.TabIndex = 1;
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel6.BackColor = Color.White;
            panel6.Controls.Add(btnRefreshTopDocGia);
            panel6.Controls.Add(cboTimePeriodDocGia);
            panel6.Controls.Add(label9);
            panel6.Controls.Add(label7);
            panel6.Location = new Point(6, 6);
            panel6.Name = "panel6";
            panel6.Size = new Size(1567, 40);
            panel6.TabIndex = 0;
            // 
            // btnRefreshTopDocGia
            // 
            btnRefreshTopDocGia.BackColor = Color.RoyalBlue;
            btnRefreshTopDocGia.FlatAppearance.BorderSize = 0;
            btnRefreshTopDocGia.FlatStyle = FlatStyle.Flat;
            btnRefreshTopDocGia.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnRefreshTopDocGia.ForeColor = Color.White;
            btnRefreshTopDocGia.Location = new Point(580, 7);
            btnRefreshTopDocGia.Name = "btnRefreshTopDocGia";
            btnRefreshTopDocGia.Size = new Size(80, 26);
            btnRefreshTopDocGia.TabIndex = 3;
            btnRefreshTopDocGia.Text = "Xem";
            btnRefreshTopDocGia.UseVisualStyleBackColor = false;
            btnRefreshTopDocGia.Click += btnRefreshTopDocGia_Click;
            // 
            // cboTimePeriodDocGia
            // 
            cboTimePeriodDocGia.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTimePeriodDocGia.Font = new Font("Segoe UI", 10F);
            cboTimePeriodDocGia.FormattingEnabled = true;
            cboTimePeriodDocGia.Items.AddRange(new object[] { "Toàn thời gian", "7 ngày qua", "30 ngày qua" });
            cboTimePeriodDocGia.Location = new Point(380, 8);
            cboTimePeriodDocGia.Name = "cboTimePeriodDocGia";
            cboTimePeriodDocGia.Size = new Size(180, 25);
            cboTimePeriodDocGia.TabIndex = 2;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F);
            label9.Location = new Point(280, 11);
            label9.Name = "label9";
            label9.Size = new Size(94, 19);
            label9.TabIndex = 1;
            label9.Text = "Khoảng thời gian:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.Location = new Point(10, 10);
            label7.Name = "label7";
            label7.Size = new Size(242, 21);
            label7.TabIndex = 0;
            label7.Text = "🏆 Top 10 độc giả tích cực nhất";
            // 
            // UCBaoCao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UCBaoCao";
            Size = new Size(1633, 754);
            Load += UCBaoCao_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabBaoCaoNo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvQuaHan).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tabThongKeSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvThongKeSach).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tabThongKeMuonTra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvThongKeMuonTra).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            tabTopStatistics.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTopSach).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopDocGia).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Button btnLoadQuaHan;
        private DataGridView dgvQuaHan;
        private TextBox txtTimKiem;
        private Label label2;
        private Button btnExportExcel;
        private TabControl tabControl1;
        private TabPage tabBaoCaoNo;
        private TabPage tabThongKeSach;
        private TabPage tabThongKeMuonTra;
        private DataGridView dgvThongKeSach;
        private Panel panel3;
        private TextBox txtTimKiemSach;
        private Label label3;
        private Button btnExportSach;
        private DataGridView dgvThongKeMuonTra;
        private Panel panel4;
        private Button btnExportMuonTra;
        private Button btnLoadThongKe;
        private DateTimePicker dtpTuNgay;
        private Label label4;
        private DateTimePicker dtpDenNgay;
        private Label label5;
        private TabPage tabTopStatistics;
        private SplitContainer splitContainer1;
        private DataGridView dgvTopSach;
        private Panel panel5;
        private ComboBox cboTimePeriodSach;
        private Label label8;
        private Button btnRefreshTopSach;
        private Label label6;
        private DataGridView dgvTopDocGia;
        private Panel panel6;
        private Button btnRefreshTopDocGia;
        private ComboBox cboTimePeriodDocGia;
        private Label label9;
        private Label label7;
    }
}
