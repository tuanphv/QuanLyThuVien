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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
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
            label1.Size = new Size(270, 37);
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
            roundPanel1.Location = new Point(20, 90);
            roundPanel1.Margin = new Padding(0);
            roundPanel1.Name = "roundPanel1";
            roundPanel1.Size = new Size(1593, 644);
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.CornflowerBlue;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvNguoiDung.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvNguoiDung.ColumnHeadersHeight = 40;
            dgvNguoiDung.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvNguoiDung.Columns.AddRange(new DataGridViewColumn[] { MaNguoiDung, TenNguoiDung, TenDangNhap, TenNhomNguoiDung });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvNguoiDung.DefaultCellStyle = dataGridViewCellStyle4;
            dgvNguoiDung.EnableHeadersVisualStyles = false;
            dgvNguoiDung.GridColor = SystemColors.ControlLight;
            dgvNguoiDung.Location = new Point(20, 69);
            dgvNguoiDung.Margin = new Padding(3, 2, 3, 2);
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
            dgvNguoiDung.Size = new Size(1553, 555);
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
            btnThemNguoiDung.Location = new Point(1470, 21);
            btnThemNguoiDung.Margin = new Padding(3, 2, 3, 2);
            btnThemNguoiDung.Name = "btnThemNguoiDung";
            btnThemNguoiDung.Padding = new Padding(5, 0, 0, 0);
            btnThemNguoiDung.Size = new Size(103, 30);
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
            panel3.Location = new Point(1023, 22);
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
            // UCNguoiDung
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(roundPanel1);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UCNguoiDung";
            Size = new Size(1633, 754);
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
