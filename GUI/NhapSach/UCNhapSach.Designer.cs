namespace GUI.NhapSach
{
    partial class UCNhapSach
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            btnThemPhieuNhap = new Button();
            label1 = new Label();
            dgvPhieuNhap = new GUI.Controls.ActionDataGridView();
            colMaPhieuNhap = new DataGridViewTextBoxColumn();
            colNhaCungCap = new DataGridViewTextBoxColumn();
            colNgayNhap = new DataGridViewTextBoxColumn();
            colTongTien = new DataGridViewTextBoxColumn();
            Actions = new DataGridViewTextBoxColumn();
            roundPanel1 = new GUI.Controls.RoundPanel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhieuNhap).BeginInit();
            roundPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnThemPhieuNhap);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(20, 15, 20, 15);
            panel1.Size = new Size(982, 70);
            panel1.TabIndex = 0;
            // 
            // btnThemPhieuNhap
            // 
            btnThemPhieuNhap.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThemPhieuNhap.BackColor = Color.FromArgb(0, 119, 200);
            btnThemPhieuNhap.FlatAppearance.BorderSize = 0;
            btnThemPhieuNhap.FlatStyle = FlatStyle.Flat;
            btnThemPhieuNhap.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThemPhieuNhap.ForeColor = Color.White;
            btnThemPhieuNhap.Location = new Point(813, 15);
            btnThemPhieuNhap.Name = "btnThemPhieuNhap";
            btnThemPhieuNhap.Size = new Size(139, 40);
            btnThemPhieuNhap.TabIndex = 1;
            btnThemPhieuNhap.Text = "Thêm phiếu nhập";
            btnThemPhieuNhap.UseVisualStyleBackColor = false;
            btnThemPhieuNhap.Click += btnThemPhieuNhap_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(0, 119, 200);
            label1.Location = new Point(20, 15);
            label1.Name = "label1";
            label1.Size = new Size(183, 32);
            label1.TabIndex = 0;
            label1.Text = "Nhập sách mới";
            // 
            // dgvPhieuNhap
            // 
            dgvPhieuNhap.AllowUserToAddRows = false;
            dgvPhieuNhap.AllowUserToDeleteRows = false;
            dgvPhieuNhap.AllowUserToResizeColumns = false;
            dgvPhieuNhap.AllowUserToResizeRows = false;
            dgvPhieuNhap.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPhieuNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhieuNhap.BackgroundColor = Color.White;
            dgvPhieuNhap.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPhieuNhap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPhieuNhap.ColumnHeadersHeight = 40;
            dgvPhieuNhap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPhieuNhap.Columns.AddRange(new DataGridViewColumn[] { colMaPhieuNhap, colNhaCungCap, colNgayNhap, colTongTien, Actions });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvPhieuNhap.DefaultCellStyle = dataGridViewCellStyle2;
            dgvPhieuNhap.EnableHeadersVisualStyles = false;
            dgvPhieuNhap.Location = new Point(20, 20);
            dgvPhieuNhap.Margin = new Padding(20);
            dgvPhieuNhap.MultiSelect = false;
            dgvPhieuNhap.Name = "dgvPhieuNhap";
            dgvPhieuNhap.RowHeadersVisible = false;
            dgvPhieuNhap.RowHeadersWidth = 40;
            dgvPhieuNhap.RowTemplate.Height = 40;
            dgvPhieuNhap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhieuNhap.ShowDeleteButton = false;
            dgvPhieuNhap.ShowEditButton = false;
            dgvPhieuNhap.ShowExtendButton = false;
            dgvPhieuNhap.ShowReturnButton = false;
            dgvPhieuNhap.ShowViewButton = true;
            dgvPhieuNhap.Size = new Size(922, 529);
            dgvPhieuNhap.TabIndex = 2;
            // 
            // colMaPhieuNhap
            // 
            colMaPhieuNhap.DataPropertyName = "MaPhieuNhap";
            colMaPhieuNhap.HeaderText = "Mã phiếu nhập";
            colMaPhieuNhap.Name = "colMaPhieuNhap";
            // 
            // colNhaCungCap
            // 
            colNhaCungCap.DataPropertyName = "TenNhaCungCap";
            colNhaCungCap.HeaderText = "Nhà cung cấp";
            colNhaCungCap.Name = "colNhaCungCap";
            // 
            // colNgayNhap
            // 
            colNgayNhap.DataPropertyName = "NgayNhap";
            colNgayNhap.HeaderText = "Ngày nhập";
            colNgayNhap.Name = "colNgayNhap";
            // 
            // colTongTien
            // 
            colTongTien.DataPropertyName = "TongTien";
            colTongTien.HeaderText = "Tổng tiền";
            colTongTien.Name = "colTongTien";
            // 
            // Actions
            // 
            Actions.HeaderText = "Xem chi tiết";
            Actions.Name = "Actions";
            // 
            // roundPanel1
            // 
            roundPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roundPanel1.BackColor = Color.Transparent;
            roundPanel1.BackgroundColor = Color.White;
            roundPanel1.BorderColor = Color.White;
            roundPanel1.BorderRadius = 10;
            roundPanel1.BorderWidth = 0F;
            roundPanel1.Controls.Add(dgvPhieuNhap);
            roundPanel1.Location = new Point(10, 83);
            roundPanel1.Margin = new Padding(10);
            roundPanel1.Name = "roundPanel1";
            roundPanel1.Size = new Size(962, 569);
            roundPanel1.TabIndex = 3;
            // 
            // UCNhapSach
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 240);
            Controls.Add(panel1);
            Controls.Add(roundPanel1);
            Name = "UCNhapSach";
            Size = new Size(982, 662);
            Load += UCNhapSach_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhieuNhap).EndInit();
            roundPanel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnThemPhieuNhap;
        private System.Windows.Forms.Label label1;
        private Controls.ActionDataGridView dgvPhieuNhap;
        private Controls.RoundPanel roundPanel1;
        private DataGridViewTextBoxColumn colMaPhieuNhap;
        private DataGridViewTextBoxColumn colNhaCungCap;
        private DataGridViewTextBoxColumn colNgayNhap;
        private DataGridViewTextBoxColumn colTongTien;
        private DataGridViewTextBoxColumn Actions;
    }
}
