namespace GUI.DocGia
{
    partial class UCDocGia
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            label1 = new Label();
            roundPanel1 = new GUI.Controls.RoundPanel();
            dgvDocGia = new GUI.Controls.ActionDataGridView();
            btnExport = new Button();
            btnThemDocGia = new Button();
            panel3 = new Panel();
            btnSearch = new Button();
            txtTimKiem = new TextBox();
            MaDocGia = new DataGridViewTextBoxColumn();
            HoTen = new DataGridViewTextBoxColumn();
            NgaySinh = new DataGridViewTextBoxColumn();
            NgayLapThe = new DataGridViewTextBoxColumn();
            NgayHetHan = new DataGridViewTextBoxColumn();
            TongNoHienTai = new DataGridViewTextBoxColumn();
            TenDangNhap = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            roundPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDocGia).BeginInit();
            panel3.SuspendLayout();
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
            label1.Size = new Size(215, 37);
            label1.TabIndex = 0;
            label1.Text = "Quản lý độc giả";
            // 
            // roundPanel1
            // 
            roundPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roundPanel1.BackColor = Color.Transparent;
            roundPanel1.BackgroundColor = Color.White;
            roundPanel1.BorderColor = Color.White;
            roundPanel1.BorderRadius = 10;
            roundPanel1.BorderWidth = 0F;
            roundPanel1.Controls.Add(dgvDocGia);
            roundPanel1.Controls.Add(btnExport);
            roundPanel1.Controls.Add(btnThemDocGia);
            roundPanel1.Controls.Add(panel3);
            roundPanel1.Location = new Point(20, 90);
            roundPanel1.Margin = new Padding(0);
            roundPanel1.Name = "roundPanel1";
            roundPanel1.Size = new Size(1593, 644);
            roundPanel1.TabIndex = 1;
            // 
            // dgvDocGia
            // 
            dgvDocGia.AllowUserToAddRows = false;
            dgvDocGia.AllowUserToDeleteRows = false;
            dgvDocGia.AllowUserToResizeColumns = false;
            dgvDocGia.AllowUserToResizeRows = false;
            dgvDocGia.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDocGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDocGia.BackgroundColor = Color.White;
            dgvDocGia.BorderStyle = BorderStyle.None;
            dgvDocGia.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDocGia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDocGia.ColumnHeadersHeight = 40;
            dgvDocGia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDocGia.Columns.AddRange(new DataGridViewColumn[] { MaDocGia, HoTen, NgaySinh, NgayLapThe, NgayHetHan, TongNoHienTai, TenDangNhap });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvDocGia.DefaultCellStyle = dataGridViewCellStyle2;
            dgvDocGia.EnableHeadersVisualStyles = false;
            dgvDocGia.GridColor = SystemColors.ControlLight;
            dgvDocGia.Location = new Point(20, 69);
            dgvDocGia.Margin = new Padding(3, 2, 3, 2);
            dgvDocGia.Name = "dgvDocGia";
            dgvDocGia.ReadOnly = true;
            dgvDocGia.RowHeadersVisible = false;
            dgvDocGia.RowTemplate.Height = 40;
            dgvDocGia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDocGia.ShowCellErrors = false;
            dgvDocGia.ShowCellToolTips = false;
            dgvDocGia.ShowDeleteButton = true;
            dgvDocGia.ShowEditButton = true;
            dgvDocGia.ShowEditingIcon = false;
            dgvDocGia.ShowExtendButton = false;
            dgvDocGia.ShowPrintButton = false;
            dgvDocGia.ShowReturnButton = false;
            dgvDocGia.ShowRowErrors = false;
            dgvDocGia.ShowViewButton = false;
            dgvDocGia.Size = new Size(1553, 555);
            dgvDocGia.TabIndex = 14;
            // 
            // btnExport
            // 
            btnExport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExport.BackColor = Color.SeaGreen;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.ImageAlign = ContentAlignment.MiddleLeft;
            btnExport.Location = new Point(1343, 21);
            btnExport.Margin = new Padding(3, 2, 3, 2);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(103, 30);
            btnExport.TabIndex = 15;
            btnExport.Text = "Xuất Excel";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnThemDocGia
            // 
            btnThemDocGia.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThemDocGia.BackColor = Color.DeepSkyBlue;
            btnThemDocGia.FlatAppearance.BorderSize = 0;
            btnThemDocGia.FlatStyle = FlatStyle.Flat;
            btnThemDocGia.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnThemDocGia.ForeColor = Color.White;
            btnThemDocGia.Image = Properties.Resources.plus;
            btnThemDocGia.ImageAlign = ContentAlignment.MiddleLeft;
            btnThemDocGia.Location = new Point(1470, 21);
            btnThemDocGia.Margin = new Padding(3, 2, 3, 2);
            btnThemDocGia.Name = "btnThemDocGia";
            btnThemDocGia.Size = new Size(103, 30);
            btnThemDocGia.TabIndex = 14;
            btnThemDocGia.Text = "   Thêm";
            btnThemDocGia.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThemDocGia.UseVisualStyleBackColor = false;
            btnThemDocGia.Click += btnThemDocGia_Click;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(btnSearch);
            panel3.Controls.Add(txtTimKiem);
            panel3.Location = new Point(896, 22);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(407, 30);
            panel3.TabIndex = 13;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.DarkTurquoise;
            btnSearch.Dock = DockStyle.Right;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Image = Properties.Resources.search;
            btnSearch.ImageAlign = ContentAlignment.MiddleLeft;
            btnSearch.Location = new Point(333, 0);
            btnSearch.Margin = new Padding(3, 2, 3, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(72, 28);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "  Tìm";
            btnSearch.TextAlign = ContentAlignment.MiddleLeft;
            btnSearch.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += txtTimKiem_TextChanged;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTimKiem.BorderStyle = BorderStyle.None;
            txtTimKiem.Font = new Font("Segoe UI", 9.75F);
            txtTimKiem.Location = new Point(5, 5);
            txtTimKiem.Margin = new Padding(3, 2, 3, 2);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(323, 18);
            txtTimKiem.TabIndex = 0;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // MaDocGia
            // 
            MaDocGia.DataPropertyName = "MaDocGia";
            MaDocGia.HeaderText = "Mã độc giả";
            MaDocGia.Name = "MaDocGia";
            MaDocGia.ReadOnly = true;
            // 
            // HoTen
            // 
            HoTen.DataPropertyName = "HoTen";
            HoTen.HeaderText = "Họ tên";
            HoTen.Name = "HoTen";
            HoTen.ReadOnly = true;
            // 
            // NgaySinh
            // 
            NgaySinh.DataPropertyName = "NgaySinh";
            NgaySinh.HeaderText = "Ngày sinh";
            NgaySinh.Name = "NgaySinh";
            NgaySinh.ReadOnly = true;
            // 
            // NgayLapThe
            // 
            NgayLapThe.DataPropertyName = "NgayLapThe";
            NgayLapThe.HeaderText = "Ngày lập thẻ";
            NgayLapThe.Name = "NgayLapThe";
            NgayLapThe.ReadOnly = true;
            // 
            // NgayHetHan
            // 
            NgayHetHan.DataPropertyName = "NgayHetHan";
            NgayHetHan.HeaderText = "Ngày hết hạn";
            NgayHetHan.Name = "NgayHetHan";
            NgayHetHan.ReadOnly = true;
            // 
            // TongNoHienTai
            // 
            TongNoHienTai.DataPropertyName = "TongNoHienTai";
            TongNoHienTai.HeaderText = "Tổng nợ";
            TongNoHienTai.Name = "TongNoHienTai";
            TongNoHienTai.ReadOnly = true;
            // 
            // TenDangNhap
            // 
            TenDangNhap.DataPropertyName = "TenDangNhap";
            TenDangNhap.HeaderText = "Tên đăng nhập";
            TenDangNhap.Name = "TenDangNhap";
            TenDangNhap.ReadOnly = true;
            // 
            // UCDocGia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(roundPanel1);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UCDocGia";
            Size = new Size(1633, 754);
            Load += UCDocGia_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            roundPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDocGia).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panel1;
        private Label label1;
        private GUI.Controls.RoundPanel roundPanel1;
        private Panel panel3;
        private Button btnSearch;
        private TextBox txtTimKiem;
        private GUI.Controls.ActionDataGridView dgvDocGia;
        private Button btnThemDocGia;
        private Button btnExport;
        private DataGridViewTextBoxColumn MaDocGia;
        private DataGridViewTextBoxColumn HoTen;
        private DataGridViewTextBoxColumn NgaySinh;
        private DataGridViewTextBoxColumn NgayLapThe;
        private DataGridViewTextBoxColumn NgayHetHan;
        private DataGridViewTextBoxColumn TongNoHienTai;
        private DataGridViewTextBoxColumn TenDangNhap;
    }
}
