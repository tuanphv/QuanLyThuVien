namespace GUI.NhaXuatBan
{
    partial class UCNhaXuatBan
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
            roundPanel1 = new GUI.Controls.RoundPanel();
            btnThem = new Button();
            panel4 = new Panel();
            button3 = new Button();
            txtTimKiem = new TextBox();
            dgvNhaXuatBan = new GUI.Controls.ActionDataGridView();
            ID = new DataGridViewTextBoxColumn();
            TenNXB = new DataGridViewTextBoxColumn();
            DiaChi = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            roundPanel1.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhaXuatBan).BeginInit();
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
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 25);
            label1.Name = "label1";
            label1.Size = new Size(366, 46);
            label1.TabIndex = 0;
            label1.Text = "Quản lý Nhà xuất bản";
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
            roundPanel1.Controls.Add(dgvNhaXuatBan);
            roundPanel1.Location = new Point(23, 120);
            roundPanel1.Margin = new Padding(23, 27, 23, 27);
            roundPanel1.Name = "roundPanel1";
            roundPanel1.Size = new Size(1821, 859);
            roundPanel1.TabIndex = 3;
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
            btnThem.Location = new Point(954, 26);
            btnThem.Margin = new Padding(23, 27, 23, 27);
            btnThem.Name = "btnThem";
            btnThem.Padding = new Padding(3, 4, 3, 4);
            btnThem.Size = new Size(87, 40);
            btnThem.TabIndex = 19;
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
            panel4.TabIndex = 18;
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
            // dgvNhaXuatBan
            // 
            dgvNhaXuatBan.AllowUserToAddRows = false;
            dgvNhaXuatBan.AllowUserToDeleteRows = false;
            dgvNhaXuatBan.AllowUserToResizeColumns = false;
            dgvNhaXuatBan.AllowUserToResizeRows = false;
            dgvNhaXuatBan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvNhaXuatBan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhaXuatBan.BackgroundColor = Color.White;
            dgvNhaXuatBan.BorderStyle = BorderStyle.None;
            dgvNhaXuatBan.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvNhaXuatBan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvNhaXuatBan.ColumnHeadersHeight = 40;
            dgvNhaXuatBan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvNhaXuatBan.Columns.AddRange(new DataGridViewColumn[] { ID, TenNXB, DiaChi });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvNhaXuatBan.DefaultCellStyle = dataGridViewCellStyle2;
            dgvNhaXuatBan.EnableHeadersVisualStyles = false;
            dgvNhaXuatBan.GridColor = SystemColors.ControlLight;
            dgvNhaXuatBan.Location = new Point(23, 92);
            dgvNhaXuatBan.Margin = new Padding(23, 27, 23, 27);
            dgvNhaXuatBan.Name = "dgvNhaXuatBan";
            dgvNhaXuatBan.RowHeadersVisible = false;
            dgvNhaXuatBan.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvNhaXuatBan.RowTemplate.Height = 50;
            dgvNhaXuatBan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhaXuatBan.ShowCellErrors = false;
            dgvNhaXuatBan.ShowCellToolTips = false;
            dgvNhaXuatBan.ShowDeleteButton = true;
            dgvNhaXuatBan.ShowEditButton = true;
            dgvNhaXuatBan.ShowEditingIcon = false;
            dgvNhaXuatBan.ShowRowErrors = false;
            dgvNhaXuatBan.ShowViewButton = true;
            dgvNhaXuatBan.Size = new Size(1775, 740);
            dgvNhaXuatBan.TabIndex = 17;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            // 
            // TenNXB
            // 
            TenNXB.DataPropertyName = "TenNXB";
            TenNXB.HeaderText = "Tên Nhà xuất bản";
            TenNXB.MinimumWidth = 6;
            TenNXB.Name = "TenNXB";
            // 
            // DiaChi
            // 
            DiaChi.DataPropertyName = "DiaChi";
            DiaChi.HeaderText = "Địa chỉ";
            DiaChi.MinimumWidth = 6;
            DiaChi.Name = "DiaChi";
            // 
            // UCNhaXuatBan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(roundPanel1);
            Controls.Add(panel1);
            Name = "UCNhaXuatBan";
            Size = new Size(1866, 1005);
            Load += UCNhaXuatBan_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            roundPanel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhaXuatBan).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Controls.RoundPanel roundPanel1;
        private Controls.ActionDataGridView dgvNhaXuatBan;
        private Button btnThem;
        private Panel panel4;
        private Button button3;
        private TextBox txtTimKiem;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn TenNXB;
        private DataGridViewTextBoxColumn DiaChi;
    }
}
