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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panel1 = new Panel();
            btnExport = new Button();
            btnImport = new Button();
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
            panel1.Controls.Add(btnExport);
            panel1.Controls.Add(btnImport);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1633, 70);
            panel1.TabIndex = 0;
            // 
            // btnExport
            // 
            btnExport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExport.BackColor = Color.PaleGreen;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExport.Image = Properties.Resources.excel;
            btnExport.ImageAlign = ContentAlignment.TopCenter;
            btnExport.Location = new Point(1529, 8);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(65, 55);
            btnExport.TabIndex = 16;
            btnExport.Text = "Export";
            btnExport.TextAlign = ContentAlignment.BottomCenter;
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnImport
            // 
            btnImport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnImport.BackColor = Color.LightBlue;
            btnImport.FlatStyle = FlatStyle.Flat;
            btnImport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnImport.Image = Properties.Resources.upload;
            btnImport.ImageAlign = ContentAlignment.TopCenter;
            btnImport.Location = new Point(1446, 8);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(65, 55);
            btnImport.TabIndex = 17;
            btnImport.Text = "Import";
            btnImport.TextAlign = ContentAlignment.BottomCenter;
            btnImport.UseVisualStyleBackColor = false;
            btnImport.Click += btnImport_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 19);
            label1.Name = "label1";
            label1.Size = new Size(218, 37);
            label1.TabIndex = 0;
            label1.Text = "Quản lý thể loại";
            // 
            // roundPanel1
            // 
            roundPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roundPanel1.BackColor = Color.Transparent;
            roundPanel1.BackgroundColor = Color.White;
            roundPanel1.BorderColor = Color.White;
            roundPanel1.BorderRadius = 10;
            roundPanel1.BorderWidth = 0F;
            roundPanel1.Controls.Add(dgvTheLoai);
            roundPanel1.Controls.Add(btnThemTheLoai);
            roundPanel1.Controls.Add(panel3);
            roundPanel1.Location = new Point(20, 90);
            roundPanel1.Margin = new Padding(20, 20, 20, 20);
            roundPanel1.Name = "roundPanel1";
            roundPanel1.Size = new Size(1593, 644);
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.CornflowerBlue;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvTheLoai.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvTheLoai.ColumnHeadersHeight = 40;
            dgvTheLoai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvTheLoai.Columns.AddRange(new DataGridViewColumn[] { MaTheLoai, TenTheLoai });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvTheLoai.DefaultCellStyle = dataGridViewCellStyle4;
            dgvTheLoai.EnableHeadersVisualStyles = false;
            dgvTheLoai.GridColor = SystemColors.ControlLight;
            dgvTheLoai.Location = new Point(20, 69);
            dgvTheLoai.Margin = new Padding(20, 20, 20, 20);
            dgvTheLoai.Name = "dgvTheLoai";
            dgvTheLoai.ReadOnly = true;
            dgvTheLoai.RowHeadersVisible = false;
            dgvTheLoai.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvTheLoai.RowTemplate.Height = 40;
            dgvTheLoai.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTheLoai.ShowCellErrors = false;
            dgvTheLoai.ShowCellToolTips = false;
            dgvTheLoai.ShowDeleteButton = true;
            dgvTheLoai.ShowEditButton = true;
            dgvTheLoai.ShowEditingIcon = false;
            dgvTheLoai.ShowExtendButton = false;
            dgvTheLoai.ShowPrintButton = false;
            dgvTheLoai.ShowReturnButton = false;
            dgvTheLoai.ShowRowErrors = false;
            dgvTheLoai.ShowViewButton = true;
            dgvTheLoai.Size = new Size(1553, 555);
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
            btnThemTheLoai.Location = new Point(1491, 20);
            btnThemTheLoai.Margin = new Padding(20, 20, 20, 20);
            btnThemTheLoai.Name = "btnThemTheLoai";
            btnThemTheLoai.Padding = new Padding(3, 3, 3, 3);
            btnThemTheLoai.Size = new Size(82, 30);
            btnThemTheLoai.TabIndex = 14;
            btnThemTheLoai.Text = " Thêm";
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
            panel3.Location = new Point(1044, 20);
            panel3.Margin = new Padding(20, 20, 20, 20);
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
            btnSearch.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.White;
            btnSearch.Image = Properties.Resources.search;
            btnSearch.ImageAlign = ContentAlignment.MiddleLeft;
            btnSearch.Location = new Point(333, 0);
            btnSearch.Margin = new Padding(0, 20, 20, 0);
            btnSearch.Name = "btnSearch";
            btnSearch.Padding = new Padding(2, 2, 2, 2);
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
            txtTimKiem.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimKiem.Location = new Point(5, 5);
            txtTimKiem.Margin = new Padding(5, 5, 5, 5);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(323, 18);
            txtTimKiem.TabIndex = 0;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // UCTheLoai
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(roundPanel1);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UCTheLoai";
            Size = new Size(1633, 754);
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
        private Button btnExport;
        private Button btnImport;
    }
}
