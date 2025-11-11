namespace GUI.TheLoai
{
    partial class UCTheLoai
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
            dgvTheLoai = new GUI.Controls.ActionDataGridView();
            MaTheLoai = new DataGridViewTextBoxColumn();
            TenTheLoai = new DataGridViewTextBoxColumn();
            btnThemTheLoai = new Button();
            panel3 = new Panel();
            btnSearch = new Button();
            txtTimKiem = new TextBox();
            panel1.SuspendLayout();
            roundPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTheLoai).BeginInit();
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
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 25);
            label1.Name = "label1";
            label1.Size = new Size(271, 46);
            label1.TabIndex = 0;
            label1.Text = "Quản lý thể loại";
            // 
            // roundPanel1
            // 
            roundPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roundPanel1.BackColor = Color.Transparent;
            roundPanel1.BackgroundColor = SystemColors.Control;
            roundPanel1.BorderColor = SystemColors.ControlDark;
            roundPanel1.BorderRadius = 10;
            roundPanel1.BorderWidth = 1F;
            roundPanel1.Controls.Add(dgvTheLoai);
            roundPanel1.Controls.Add(btnThemTheLoai);
            roundPanel1.Controls.Add(panel3);
            roundPanel1.Location = new Point(23, 120);
            roundPanel1.Margin = new Padding(23, 27, 23, 27);
            roundPanel1.Name = "roundPanel1";
            roundPanel1.Size = new Size(1821, 859);
            roundPanel1.TabIndex = 1;
            // 
            // dgvTheLoai
            // 
            dgvTheLoai.AllowUserToAddRows = false;
            dgvTheLoai.AllowUserToDeleteRows = false;
            dgvTheLoai.AllowUserToResizeColumns = false;
            dgvTheLoai.AllowUserToResizeRows = false;
            dgvTheLoai.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTheLoai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTheLoai.BackgroundColor = Color.White;
            dgvTheLoai.BorderStyle = BorderStyle.None;
            dgvTheLoai.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvTheLoai.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTheLoai.ColumnHeadersHeight = 40;
            dgvTheLoai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvTheLoai.Columns.AddRange(new DataGridViewColumn[] { MaTheLoai, TenTheLoai });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvTheLoai.DefaultCellStyle = dataGridViewCellStyle2;
            dgvTheLoai.EnableHeadersVisualStyles = false;
            dgvTheLoai.GridColor = SystemColors.ControlLight;
            dgvTheLoai.Location = new Point(23, 92);
            dgvTheLoai.Margin = new Padding(23, 27, 23, 27);
            dgvTheLoai.Name = "dgvTheLoai";
            dgvTheLoai.ReadOnly = true;
            dgvTheLoai.RowHeadersVisible = false;
            dgvTheLoai.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvTheLoai.RowTemplate.Height = 80;
            dgvTheLoai.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTheLoai.ShowCellErrors = false;
            dgvTheLoai.ShowCellToolTips = false;
            dgvTheLoai.ShowDeleteButton = true;
            dgvTheLoai.ShowEditButton = true;
            dgvTheLoai.ShowEditingIcon = false;
            dgvTheLoai.ShowRowErrors = false;
            dgvTheLoai.ShowViewButton = true;
            dgvTheLoai.Size = new Size(1773, 740);
            dgvTheLoai.TabIndex = 14;
            // 
            // MaTheLoai
            // 
            MaTheLoai.DataPropertyName = "MaTheLoai";
            MaTheLoai.HeaderText = "Mã thể loại";
            MaTheLoai.MinimumWidth = 6;
            MaTheLoai.Name = "MaTheLoai";
            MaTheLoai.ReadOnly = true;
            // 
            // TenTheLoai
            // 
            TenTheLoai.DataPropertyName = "TenTheLoai";
            TenTheLoai.HeaderText = "Tên thể loại";
            TenTheLoai.MinimumWidth = 6;
            TenTheLoai.Name = "TenTheLoai";
            TenTheLoai.ReadOnly = true;
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
            btnThemTheLoai.Location = new Point(905, 27);
            btnThemTheLoai.Margin = new Padding(23, 27, 23, 27);
            btnThemTheLoai.Name = "btnThemTheLoai";
            btnThemTheLoai.Padding = new Padding(3, 4, 3, 4);
            btnThemTheLoai.Size = new Size(87, 40);
            btnThemTheLoai.TabIndex = 14;
            btnThemTheLoai.Text = "Thêm";
            btnThemTheLoai.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThemTheLoai.UseVisualStyleBackColor = false;
            btnThemTheLoai.Click += btnThemTheLoai_Click;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(btnSearch);
            panel3.Controls.Add(txtTimKiem);
            panel3.Location = new Point(429, 27);
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
            btnSearch.Click += txtTimKiem_TextChanged;
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
            // UCTheLoai
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(roundPanel1);
            Controls.Add(panel1);
            Name = "UCTheLoai";
            Size = new Size(1866, 1005);
            Load += UCTheLoai_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            roundPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTheLoai).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Controls.RoundPanel roundPanel1;
        private Panel panel3;
        private Button btnSearch;
        private TextBox txtTimKiem;
        private Controls.ActionDataGridView dgvTheLoai;
        private Button btnThemTheLoai;
        private DataGridViewTextBoxColumn MaTheLoai;
        private DataGridViewTextBoxColumn TenTheLoai;
    }
}
