namespace GUI.NguoiDung
{
    partial class UCNguoiDung
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
            dgvNguoiDung = new GUI.Controls.ActionDataGridView();
            MaNguoiDung = new DataGridViewTextBoxColumn();
            TenNguoiDung = new DataGridViewTextBoxColumn();
            TenDangNhap = new DataGridViewTextBoxColumn();
            TenNhomNguoiDung = new DataGridViewTextBoxColumn();
            btnThemNguoiDung = new Button();
            panel3 = new Panel();
            btnSearch = new Button();
            txtTimKiem = new TextBox();
            panel1.SuspendLayout();
            roundPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNguoiDung).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1866, 93);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8F, FontStyle.Bold);
            label1.Location = new Point(23, 25);
            label1.Name = "label1";
            label1.Size = new Size(327, 46);
            label1.TabIndex = 0;
            label1.Text = "Quản lý người dùng";
            // 
            // roundPanel1
            // 
            roundPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roundPanel1.BackColor = Color.Transparent;
            roundPanel1.BackgroundColor = Color.White;
            roundPanel1.BorderColor = Color.White;
            roundPanel1.BorderRadius = 10;
            roundPanel1.BorderWidth = 0F;
            roundPanel1.Controls.Add(dgvNguoiDung);
            roundPanel1.Controls.Add(btnThemNguoiDung);
            roundPanel1.Controls.Add(panel3);
            roundPanel1.Location = new Point(23, 120);
            roundPanel1.Name = "roundPanel1";
            roundPanel1.Size = new Size(1821, 859);
            roundPanel1.TabIndex = 1;
            // 
            // dgvNguoiDung
            // 
            dgvNguoiDung.AllowUserToAddRows = false;
            dgvNguoiDung.AllowUserToDeleteRows = false;
            dgvNguoiDung.AllowUserToResizeColumns = false;
            dgvNguoiDung.AllowUserToResizeRows = false;
            dgvNguoiDung.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvNguoiDung.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNguoiDung.BackgroundColor = Color.White;
            dgvNguoiDung.BorderStyle = BorderStyle.None;
            dgvNguoiDung.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvNguoiDung.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvNguoiDung.ColumnHeadersHeight = 40;
            dgvNguoiDung.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvNguoiDung.Columns.AddRange(new DataGridViewColumn[] { MaNguoiDung, TenNguoiDung, TenDangNhap, TenNhomNguoiDung });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvNguoiDung.DefaultCellStyle = dataGridViewCellStyle2;
            dgvNguoiDung.EnableHeadersVisualStyles = false;
            dgvNguoiDung.GridColor = SystemColors.ControlLight;
            dgvNguoiDung.Location = new Point(23, 92);
            dgvNguoiDung.Name = "dgvNguoiDung";
            dgvNguoiDung.ReadOnly = true;
            dgvNguoiDung.RowHeadersVisible = false;
            dgvNguoiDung.RowTemplate.Height = 40;
            dgvNguoiDung.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNguoiDung.ShowCellErrors = false;
            dgvNguoiDung.ShowCellToolTips = false;
            dgvNguoiDung.ShowDeleteButton = true;
            dgvNguoiDung.ShowEditButton = true;
            dgvNguoiDung.ShowEditingIcon = false;
            dgvNguoiDung.ShowRowErrors = false;
            dgvNguoiDung.ShowViewButton = false;
            dgvNguoiDung.Size = new Size(1775, 740);
            dgvNguoiDung.TabIndex = 14;
            // 
            // MaNguoiDung
            // 
            MaNguoiDung.DataPropertyName = "MaNguoiDung";
            MaNguoiDung.HeaderText = "Mã người dùng";
            MaNguoiDung.Name = "MaNguoiDung";
            MaNguoiDung.ReadOnly = true;
            // 
            // TenNguoiDung
            // 
            TenNguoiDung.DataPropertyName = "TenNguoiDung";
            TenNguoiDung.HeaderText = "Tên người dùng";
            TenNguoiDung.Name = "TenNguoiDung";
            TenNguoiDung.ReadOnly = true;
            // 
            // TenDangNhap
            // 
            TenDangNhap.DataPropertyName = "TenDangNhap";
            TenDangNhap.HeaderText = "Tên đăng nhập";
            TenDangNhap.Name = "TenDangNhap";
            TenDangNhap.ReadOnly = true;
            // 
            // TenNhomNguoiDung
            // 
            TenNhomNguoiDung.DataPropertyName = "TenNhomNguoiDung";
            TenNhomNguoiDung.HeaderText = "Nhóm người dùng";
            TenNhomNguoiDung.Name = "TenNhomNguoiDung";
            TenNhomNguoiDung.ReadOnly = true;
            // 
            // btnThemNguoiDung
            // 
            btnThemNguoiDung.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThemNguoiDung.BackColor = Color.DeepSkyBlue;
            btnThemNguoiDung.FlatAppearance.BorderSize = 0;
            btnThemNguoiDung.FlatStyle = FlatStyle.Flat;
            btnThemNguoiDung.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnThemNguoiDung.ForeColor = Color.White;
            btnThemNguoiDung.Image = Properties.Resources.plus;
            btnThemNguoiDung.ImageAlign = ContentAlignment.MiddleLeft;
            btnThemNguoiDung.Location = new Point(1680, 28);
            btnThemNguoiDung.Name = "btnThemNguoiDung";
            btnThemNguoiDung.Size = new Size(118, 40);
            btnThemNguoiDung.TabIndex = 14;
            btnThemNguoiDung.Text = "   Thêm";
            btnThemNguoiDung.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThemNguoiDung.UseVisualStyleBackColor = false;
            btnThemNguoiDung.Click += btnThemNguoiDung_Click;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(btnSearch);
            panel3.Controls.Add(txtTimKiem);
            panel3.Location = new Point(1169, 29);
            panel3.Name = "panel3";
            panel3.Size = new Size(465, 39);
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
            btnSearch.Location = new Point(381, 0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(82, 37);
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
            txtTimKiem.Location = new Point(6, 7);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(369, 22);
            txtTimKiem.TabIndex = 0;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // UCNguoiDung
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(roundPanel1);
            Controls.Add(panel1);
            Name = "UCNguoiDung";
            Size = new Size(1866, 1005);
            Load += UCNguoiDung_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            roundPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNguoiDung).EndInit();
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
        private GUI.Controls.ActionDataGridView dgvNguoiDung;
        private Button btnThemNguoiDung;
        private DataGridViewTextBoxColumn MaNguoiDung;
        private DataGridViewTextBoxColumn TenNguoiDung;
        private DataGridViewTextBoxColumn TenDangNhap;
        private DataGridViewTextBoxColumn TenNhomNguoiDung;
    }
}
