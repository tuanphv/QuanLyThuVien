namespace GUI.Sach
{
    partial class UCSach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCSach));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panel1 = new Panel();
            label1 = new Label();
            roundPanel1 = new GUI.Controls.RoundPanel();
            btnReload = new Button();
            panel4 = new Panel();
            button3 = new Button();
            txtTimKiem = new TextBox();
            dgvSach = new GUI.Controls.ActionDataGridView();
            MaSach = new DataGridViewTextBoxColumn();
            TenTuaSach = new DataGridViewTextBoxColumn();
            TenNXB = new DataGridViewTextBoxColumn();
            NamXB = new DataGridViewTextBoxColumn();
            DonGia = new DataGridViewTextBoxColumn();
            SoLuongTong = new DataGridViewTextBoxColumn();
            SoLuongConLai = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            roundPanel1.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSach).BeginInit();
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
            panel1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 19);
            label1.Name = "label1";
            label1.Size = new Size(180, 37);
            label1.TabIndex = 0;
            label1.Text = "Quản lý Sách";
            // 
            // roundPanel1
            // 
            roundPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roundPanel1.BackColor = Color.Transparent;
            roundPanel1.BackgroundColor = Color.White;
            roundPanel1.BorderColor = Color.White;
            roundPanel1.BorderRadius = 10;
            roundPanel1.BorderWidth = 0F;
            roundPanel1.Controls.Add(btnReload);
            roundPanel1.Controls.Add(panel4);
            roundPanel1.Controls.Add(dgvSach);
            roundPanel1.Location = new Point(20, 90);
            roundPanel1.Margin = new Padding(20);
            roundPanel1.Name = "roundPanel1";
            roundPanel1.Size = new Size(1593, 644);
            roundPanel1.TabIndex = 5;
            // 
            // btnReload
            // 
            btnReload.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReload.BackColor = Color.LightSeaGreen;
            btnReload.FlatAppearance.BorderSize = 0;
            btnReload.FlatStyle = FlatStyle.Flat;
            btnReload.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReload.ForeColor = Color.White;
            btnReload.Image = (Image)resources.GetObject("btnReload.Image");
            btnReload.ImageAlign = ContentAlignment.MiddleLeft;
            btnReload.Location = new Point(1485, 22);
            btnReload.Margin = new Padding(3, 2, 3, 2);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(88, 28);
            btnReload.TabIndex = 22;
            btnReload.Text = "Tải lại";
            btnReload.TextAlign = ContentAlignment.MiddleRight;
            btnReload.UseVisualStyleBackColor = false;
            btnReload.Click += btnReload_Click;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(button3);
            panel4.Controls.Add(txtTimKiem);
            panel4.Location = new Point(20, 20);
            panel4.Margin = new Padding(20);
            panel4.Name = "panel4";
            panel4.Size = new Size(407, 30);
            panel4.TabIndex = 21;
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
            button3.Location = new Point(333, 0);
            button3.Margin = new Padding(0, 20, 20, 0);
            button3.Name = "button3";
            button3.Padding = new Padding(2);
            button3.Size = new Size(72, 28);
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
            txtTimKiem.Location = new Point(5, 5);
            txtTimKiem.Margin = new Padding(5);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Tìm theo mã sách, tên tựa sách, nhà xuất bản";
            txtTimKiem.Size = new Size(323, 18);
            txtTimKiem.TabIndex = 0;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // dgvSach
            // 
            dgvSach.AllowUserToAddRows = false;
            dgvSach.AllowUserToDeleteRows = false;
            dgvSach.AllowUserToResizeColumns = false;
            dgvSach.AllowUserToResizeRows = false;
            dgvSach.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSach.BackgroundColor = Color.White;
            dgvSach.BorderStyle = BorderStyle.None;
            dgvSach.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSach.ColumnHeadersHeight = 40;
            dgvSach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvSach.Columns.AddRange(new DataGridViewColumn[] { MaSach, TenTuaSach, TenNXB, NamXB, DonGia, SoLuongTong, SoLuongConLai });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.Padding = new Padding(5);
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvSach.DefaultCellStyle = dataGridViewCellStyle5;
            dgvSach.EnableHeadersVisualStyles = false;
            dgvSach.GridColor = SystemColors.ControlLight;
            dgvSach.Location = new Point(20, 69);
            dgvSach.Margin = new Padding(20);
            dgvSach.Name = "dgvSach";
            dgvSach.RowHeadersVisible = false;
            dgvSach.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvSach.RowTemplate.Height = 70;
            dgvSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSach.ShowCellErrors = false;
            dgvSach.ShowCellToolTips = false;
            dgvSach.ShowDeleteButton = true;
            dgvSach.ShowEditButton = true;
            dgvSach.ShowEditingIcon = false;
            dgvSach.ShowExtendButton = false;
            dgvSach.ShowPrintButton = false;
            dgvSach.ShowReturnButton = false;
            dgvSach.ShowRowErrors = false;
            dgvSach.ShowViewButton = true;
            dgvSach.Size = new Size(1553, 555);
            dgvSach.TabIndex = 17;
            // 
            // MaSach
            // 
            MaSach.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            MaSach.DataPropertyName = "MaSach";
            MaSach.HeaderText = "Mã sách";
            MaSach.MinimumWidth = 6;
            MaSach.Name = "MaSach";
            // 
            // TenTuaSach
            // 
            TenTuaSach.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TenTuaSach.DataPropertyName = "TenTuaSach";
            TenTuaSach.HeaderText = "Tựa sách";
            TenTuaSach.MinimumWidth = 6;
            TenTuaSach.Name = "TenTuaSach";
            // 
            // TenNXB
            // 
            TenNXB.DataPropertyName = "TenNXB";
            TenNXB.HeaderText = "Nhà XB";
            TenNXB.MinimumWidth = 6;
            TenNXB.Name = "TenNXB";
            // 
            // NamXB
            // 
            NamXB.DataPropertyName = "NamXB";
            NamXB.HeaderText = "Năm XB";
            NamXB.Name = "NamXB";
            // 
            // DonGia
            // 
            DonGia.DataPropertyName = "DonGia";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            DonGia.DefaultCellStyle = dataGridViewCellStyle2;
            DonGia.HeaderText = "Đơn giá";
            DonGia.MinimumWidth = 6;
            DonGia.Name = "DonGia";
            // 
            // SoLuongTong
            // 
            SoLuongTong.DataPropertyName = "SoLuongTong";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            SoLuongTong.DefaultCellStyle = dataGridViewCellStyle3;
            SoLuongTong.HeaderText = "Tổng SL";
            SoLuongTong.MinimumWidth = 6;
            SoLuongTong.Name = "SoLuongTong";
            // 
            // SoLuongConLai
            // 
            SoLuongConLai.DataPropertyName = "SoLuongConLai";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            SoLuongConLai.DefaultCellStyle = dataGridViewCellStyle4;
            SoLuongConLai.HeaderText = "Còn lại";
            SoLuongConLai.MinimumWidth = 6;
            SoLuongConLai.Name = "SoLuongConLai";
            // 
            // UCSach
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(roundPanel1);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UCSach";
            Size = new Size(1633, 754);
            Load += UCSach_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            roundPanel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSach).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Controls.RoundPanel roundPanel1;
        private Controls.ActionDataGridView dgvSach;
        private Panel panel4;
        private Button button3;
        private TextBox txtTimKiem;
        private Button btnReload;
        private DataGridViewTextBoxColumn MaSach;
        private DataGridViewTextBoxColumn TenTuaSach;
        private DataGridViewTextBoxColumn TenNXB;
        private DataGridViewTextBoxColumn NamXB;
        private DataGridViewTextBoxColumn DonGia;
        private DataGridViewTextBoxColumn SoLuongTong;
        private DataGridViewTextBoxColumn SoLuongConLai;
    }
}
