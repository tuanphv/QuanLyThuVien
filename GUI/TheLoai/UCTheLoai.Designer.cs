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
            label1 = new Label();
            roundPanel1 = new GUI.Controls.RoundPanel();
            dgvTheLoai = new GUI.Controls.ActionDataGridView();
            MaTheLoai = new DataGridViewTextBoxColumn();
            TenTheLoai = new DataGridViewTextBoxColumn();
            btnThemTheLoai = new Button();
            panel3 = new Panel();
            btnSearch = new Button();
            txtTimKiem = new TextBox();
            button1 = new Button();
            button2 = new Button();
            panel1.SuspendLayout();
            roundPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTheLoai).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button2);
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
            roundPanel1.BackgroundColor = Color.White;
            roundPanel1.BorderColor = Color.White;
            roundPanel1.BorderRadius = 10;
            roundPanel1.BorderWidth = 0F;
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
            dgvTheLoai.Location = new Point(23, 92);
            dgvTheLoai.Margin = new Padding(23, 27, 23, 27);
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
            dgvTheLoai.ShowReturnButton = false;
            dgvTheLoai.ShowRowErrors = false;
            dgvTheLoai.ShowViewButton = true;
            dgvTheLoai.Size = new Size(1775, 740);
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
            btnThemTheLoai.Location = new Point(1704, 27);
            btnThemTheLoai.Margin = new Padding(23, 27, 23, 27);
            btnThemTheLoai.Name = "btnThemTheLoai";
            btnThemTheLoai.Padding = new Padding(3, 4, 3, 4);
            btnThemTheLoai.Size = new Size(94, 40);
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
            panel3.Location = new Point(1193, 27);
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
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.PaleGreen;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.Image = Properties.Resources.excel;
            button1.ImageAlign = ContentAlignment.TopCenter;
            button1.Location = new Point(1747, 4);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(74, 73);
            button1.TabIndex = 16;
            button1.Text = "Export";
            button1.TextAlign = ContentAlignment.BottomCenter;
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnExport_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.BackColor = Color.LightBlue;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button2.Image = Properties.Resources.upload;
            button2.ImageAlign = ContentAlignment.TopCenter;
            button2.Location = new Point(1652, 4);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(74, 73);
            button2.TabIndex = 17;
            button2.Text = "Import";
            button2.TextAlign = ContentAlignment.BottomCenter;
            button2.UseVisualStyleBackColor = false;
            button2.Click += btnImport_Click;
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
        private Button button1;
        private Button button2;
    }
}
