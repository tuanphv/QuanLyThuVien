namespace GUI.NhaCungCap
{
    partial class UCNhaCungCap
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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            panel1 = new Panel();
            label1 = new Label();
            roundPanel1 = new GUI.Controls.RoundPanel();
            btnThem = new Button();
            panel4 = new Panel();
            button3 = new Button();
            txtTimKiem = new TextBox();
            dgvNhaCungCap = new GUI.Controls.ActionDataGridView();
            ID = new DataGridViewTextBoxColumn();
            TenNCC = new DataGridViewTextBoxColumn();
            DiaChi = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            roundPanel1.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhaCungCap).BeginInit();
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
            panel1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 25);
            label1.Name = "label1";
            label1.Size = new Size(369, 46);
            label1.TabIndex = 0;
            label1.Text = "Quản lý Nhà cung cấp";
            // 
            // roundPanel1
            // 
            roundPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roundPanel1.BackColor = Color.Transparent;
            roundPanel1.BackgroundColor = Color.White;
            roundPanel1.BorderColor = Color.White;
            roundPanel1.BorderRadius = 10;
            roundPanel1.BorderWidth = 0F;
            roundPanel1.Controls.Add(btnThem);
            roundPanel1.Controls.Add(panel4);
            roundPanel1.Controls.Add(dgvNhaCungCap);
            roundPanel1.Location = new Point(23, 120);
            roundPanel1.Margin = new Padding(23, 27, 23, 27);
            roundPanel1.Name = "roundPanel1";
            roundPanel1.Size = new Size(1821, 859);
            roundPanel1.TabIndex = 4;
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThem.BackColor = Color.DeepSkyBlue;
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.ForeColor = Color.White;
            btnThem.Image = Properties.Resources.plus;
            btnThem.ImageAlign = ContentAlignment.MiddleLeft;
            btnThem.Location = new Point(942, 26);
            btnThem.Margin = new Padding(23, 27, 23, 27);
            btnThem.Name = "btnThem";
            btnThem.Padding = new Padding(3, 4, 3, 4);
            btnThem.Size = new Size(87, 40);
            btnThem.TabIndex = 21;
            btnThem.Text = "Thêm";
            btnThem.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(button3);
            panel4.Controls.Add(txtTimKiem);
            panel4.Location = new Point(420, 27);
            panel4.Margin = new Padding(23, 27, 23, 27);
            panel4.Name = "panel4";
            panel4.Size = new Size(465, 39);
            panel4.TabIndex = 20;
            // 
            // button3
            // 
            button3.BackColor = Color.DarkTurquoise;
            button3.Dock = DockStyle.Right;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Image = Properties.Resources.search;
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(381, 0);
            button3.Margin = new Padding(0, 27, 23, 0);
            button3.Name = "button3";
            button3.Padding = new Padding(2, 3, 2, 3);
            button3.Size = new Size(82, 37);
            button3.TabIndex = 1;
            button3.Text = "  Tìm";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.TextImageRelation = TextImageRelation.ImageBeforeText;
            button3.UseVisualStyleBackColor = false;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTimKiem.BorderStyle = BorderStyle.None;
            txtTimKiem.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimKiem.Location = new Point(6, 7);
            txtTimKiem.Margin = new Padding(6, 7, 6, 7);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(369, 22);
            txtTimKiem.TabIndex = 0;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // dgvNhaCungCap
            // 
            dgvNhaCungCap.AllowUserToAddRows = false;
            dgvNhaCungCap.AllowUserToDeleteRows = false;
            dgvNhaCungCap.AllowUserToResizeColumns = false;
            dgvNhaCungCap.AllowUserToResizeRows = false;
            dgvNhaCungCap.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvNhaCungCap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhaCungCap.BackgroundColor = Color.White;
            dgvNhaCungCap.BorderStyle = BorderStyle.None;
            dgvNhaCungCap.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.CornflowerBlue;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvNhaCungCap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvNhaCungCap.ColumnHeadersHeight = 40;
            dgvNhaCungCap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvNhaCungCap.Columns.AddRange(new DataGridViewColumn[] { ID, TenNCC, DiaChi });
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.Padding = new Padding(5);
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvNhaCungCap.DefaultCellStyle = dataGridViewCellStyle8;
            dgvNhaCungCap.EnableHeadersVisualStyles = false;
            dgvNhaCungCap.GridColor = SystemColors.ControlLight;
            dgvNhaCungCap.Location = new Point(23, 92);
            dgvNhaCungCap.Margin = new Padding(23, 27, 23, 27);
            dgvNhaCungCap.Name = "dgvNhaCungCap";
            dgvNhaCungCap.RowHeadersVisible = false;
            dgvNhaCungCap.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvNhaCungCap.RowTemplate.Height = 50;
            dgvNhaCungCap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhaCungCap.ShowCellErrors = false;
            dgvNhaCungCap.ShowCellToolTips = false;
            dgvNhaCungCap.ShowDeleteButton = true;
            dgvNhaCungCap.ShowEditButton = true;
            dgvNhaCungCap.ShowEditingIcon = false;
            dgvNhaCungCap.ShowRowErrors = false;
            dgvNhaCungCap.ShowViewButton = true;
            dgvNhaCungCap.Size = new Size(1775, 740);
            dgvNhaCungCap.TabIndex = 17;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            // 
            // TenNCC
            // 
            TenNCC.DataPropertyName = "TenNCC";
            TenNCC.HeaderText = "Tên Nhà cung cấp";
            TenNCC.MinimumWidth = 6;
            TenNCC.Name = "TenNCC";
            // 
            // DiaChi
            // 
            DiaChi.DataPropertyName = "DiaChi";
            DiaChi.HeaderText = "Địa chỉ";
            DiaChi.MinimumWidth = 6;
            DiaChi.Name = "DiaChi";
            // 
            // UCNhaCungCap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(roundPanel1);
            Controls.Add(panel1);
            Name = "UCNhaCungCap";
            Size = new Size(1866, 1005);
            Load += UCNhaCungCap_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            roundPanel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhaCungCap).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Controls.RoundPanel roundPanel1;
        private Controls.ActionDataGridView dgvNhaCungCap;
        private Button btnThem;
        private Panel panel4;
        private Button button3;
        private TextBox txtTimKiem;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn TenNCC;
        private DataGridViewTextBoxColumn DiaChi;
    }
}
