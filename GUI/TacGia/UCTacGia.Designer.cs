namespace GUI.TacGia
{
    partial class UCTacGia
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
            dgvTacGia = new GUI.Controls.ActionDataGridView();
            MaTacGia = new DataGridViewTextBoxColumn();
            TenTacGia = new DataGridViewTextBoxColumn();
            btnAdd = new Button();
            panel2 = new Panel();
            button2 = new Button();
            txtSearch = new TextBox();
            btnThemTheLoai = new Button();
            panel3 = new Panel();
            btnSearch = new Button();
            txtTimKiem = new TextBox();
            panel1.SuspendLayout();
            roundPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTacGia).BeginInit();
            panel2.SuspendLayout();
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
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 25);
            label1.Name = "label1";
            label1.Size = new Size(257, 46);
            label1.TabIndex = 0;
            label1.Text = "Quản lý tác giả";
            // 
            // roundPanel1
            // 
            roundPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roundPanel1.BackColor = Color.Transparent;
            roundPanel1.BackgroundColor = Color.White;
            roundPanel1.BorderColor = Color.White;
            roundPanel1.BorderRadius = 10;
            roundPanel1.BorderWidth = 0F;
            roundPanel1.Controls.Add(dgvTacGia);
            roundPanel1.Controls.Add(btnAdd);
            roundPanel1.Controls.Add(panel2);
            roundPanel1.Controls.Add(btnThemTheLoai);
            roundPanel1.Controls.Add(panel3);
            roundPanel1.Location = new Point(23, 120);
            roundPanel1.Margin = new Padding(23, 27, 23, 27);
            roundPanel1.Name = "roundPanel1";
            roundPanel1.Size = new Size(1821, 859);
            roundPanel1.TabIndex = 2;
            // 
            // dgvTacGia
            // 
            dgvTacGia.AllowUserToAddRows = false;
            dgvTacGia.AllowUserToDeleteRows = false;
            dgvTacGia.AllowUserToResizeColumns = false;
            dgvTacGia.AllowUserToResizeRows = false;
            dgvTacGia.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTacGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTacGia.BackgroundColor = Color.White;
            dgvTacGia.BorderStyle = BorderStyle.None;
            dgvTacGia.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvTacGia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTacGia.ColumnHeadersHeight = 40;
            dgvTacGia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvTacGia.Columns.AddRange(new DataGridViewColumn[] { MaTacGia, TenTacGia });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvTacGia.DefaultCellStyle = dataGridViewCellStyle2;
            dgvTacGia.EnableHeadersVisualStyles = false;
            dgvTacGia.GridColor = SystemColors.ControlLight;
            dgvTacGia.Location = new Point(23, 92);
            dgvTacGia.Margin = new Padding(23, 27, 23, 27);
            dgvTacGia.Name = "dgvTacGia";
            dgvTacGia.ReadOnly = true;
            dgvTacGia.RowHeadersVisible = false;
            dgvTacGia.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvTacGia.RowTemplate.Height = 40;
            dgvTacGia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTacGia.ShowCellErrors = false;
            dgvTacGia.ShowCellToolTips = false;
            dgvTacGia.ShowDeleteButton = true;
            dgvTacGia.ShowEditButton = true;
            dgvTacGia.ShowEditingIcon = false;
            dgvTacGia.ShowRowErrors = false;
            dgvTacGia.ShowViewButton = true;
            dgvTacGia.Size = new Size(1775, 740);
            dgvTacGia.TabIndex = 17;
            // 
            // MaTacGia
            // 
            MaTacGia.DataPropertyName = "MaTacGia";
            MaTacGia.HeaderText = "Mã tác giả";
            MaTacGia.MinimumWidth = 6;
            MaTacGia.Name = "MaTacGia";
            MaTacGia.ReadOnly = true;
            // 
            // TenTacGia
            // 
            TenTacGia.DataPropertyName = "TenTacGia";
            TenTacGia.HeaderText = "Tên tác giả";
            TenTacGia.MinimumWidth = 6;
            TenTacGia.Name = "TenTacGia";
            TenTacGia.ReadOnly = true;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.BackColor = Color.DeepSkyBlue;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Image = Properties.Resources.plus;
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(931, 26);
            btnAdd.Margin = new Padding(23, 27, 23, 27);
            btnAdd.Name = "btnAdd";
            btnAdd.Padding = new Padding(3, 4, 3, 4);
            btnAdd.Size = new Size(87, 40);
            btnAdd.TabIndex = 16;
            btnAdd.Text = "Thêm";
            btnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnThemTacGia_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(button2);
            panel2.Controls.Add(txtSearch);
            panel2.Location = new Point(420, 27);
            panel2.Margin = new Padding(23, 27, 23, 27);
            panel2.Name = "panel2";
            panel2.Size = new Size(465, 39);
            panel2.TabIndex = 15;
            // 
            // button2
            // 
            button2.BackColor = Color.DarkTurquoise;
            button2.Dock = DockStyle.Right;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Image = Properties.Resources.search;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(381, 0);
            button2.Margin = new Padding(0, 27, 23, 0);
            button2.Name = "button2";
            button2.Padding = new Padding(2, 3, 2, 3);
            button2.Size = new Size(82, 37);
            button2.TabIndex = 1;
            button2.Text = "  Tìm";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.TextImageRelation = TextImageRelation.ImageBeforeText;
            button2.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(6, 7);
            txtSearch.Margin = new Padding(6, 7, 6, 7);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(369, 22);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtTimKiem_TextChanged;
            // 
            // btnThemTheLoai
            // 
            btnThemTheLoai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThemTheLoai.BackColor = Color.DeepSkyBlue;
            btnThemTheLoai.FlatAppearance.BorderSize = 0;
            btnThemTheLoai.FlatStyle = FlatStyle.Flat;
            btnThemTheLoai.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThemTheLoai.ForeColor = Color.White;
            btnThemTheLoai.Image = Properties.Resources.plus;
            btnThemTheLoai.ImageAlign = ContentAlignment.MiddleLeft;
            btnThemTheLoai.Location = new Point(2556, 28);
            btnThemTheLoai.Margin = new Padding(23, 27, 23, 27);
            btnThemTheLoai.Name = "btnThemTheLoai";
            btnThemTheLoai.Padding = new Padding(3, 4, 3, 4);
            btnThemTheLoai.Size = new Size(87, 40);
            btnThemTheLoai.TabIndex = 14;
            btnThemTheLoai.Text = "Thêm";
            btnThemTheLoai.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThemTheLoai.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(btnSearch);
            panel3.Controls.Add(txtTimKiem);
            panel3.Location = new Point(2045, 29);
            panel3.Margin = new Padding(23, 27, 23, 27);
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
            btnSearch.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.White;
            btnSearch.Image = Properties.Resources.search;
            btnSearch.ImageAlign = ContentAlignment.MiddleLeft;
            btnSearch.Location = new Point(381, 0);
            btnSearch.Margin = new Padding(0, 27, 23, 0);
            btnSearch.Name = "btnSearch";
            btnSearch.Padding = new Padding(2, 3, 2, 3);
            btnSearch.Size = new Size(82, 37);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "  Tìm";
            btnSearch.TextAlign = ContentAlignment.MiddleLeft;
            btnSearch.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTimKiem.BorderStyle = BorderStyle.None;
            txtTimKiem.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimKiem.Location = new Point(6, 7);
            txtTimKiem.Margin = new Padding(6, 7, 6, 7);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(632, 22);
            txtTimKiem.TabIndex = 0;
            // 
            // UCTacGia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(roundPanel1);
            Controls.Add(panel1);
            Name = "UCTacGia";
            Size = new Size(1866, 1005);
            Load += UCTacGia_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            roundPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTacGia).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Controls.RoundPanel roundPanel1;
        private Button btnThemTheLoai;
        private Panel panel3;
        private Button btnSearch;
        private TextBox txtTimKiem;
        private Button btnAdd;
        private Panel panel2;
        private Button button2;
        private TextBox txtSearch;
        private Controls.ActionDataGridView dgvTacGia;
        private DataGridViewTextBoxColumn MaTacGia;
        private DataGridViewTextBoxColumn TenTacGia;
    }
}
