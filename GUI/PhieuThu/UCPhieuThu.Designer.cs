namespace GUI.PhieuThu
{
    partial class UCPhieuThu
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            label1 = new Label();
            dgvPhieuThu = new GUI.Controls.ActionDataGridView();
            colMaPhieuThu = new DataGridViewTextBoxColumn();
            colDocGia = new DataGridViewTextBoxColumn();
            colSoTienThu = new DataGridViewTextBoxColumn();
            colNgayLap = new DataGridViewTextBoxColumn();
            roundPanel1 = new GUI.Controls.RoundPanel();
            cbDocGia = new ComboBox();
            label2 = new Label();
            btnThem = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhieuThu).BeginInit();
            roundPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1200, 80);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(243, 37);
            label1.TabIndex = 0;
            label1.Text = "Quản lý Phiếu thu";
            // 
            // dgvPhieuThu
            // 
            dgvPhieuThu.AllowUserToAddRows = false;
            dgvPhieuThu.AllowUserToDeleteRows = false;
            dgvPhieuThu.AllowUserToResizeColumns = false;
            dgvPhieuThu.AllowUserToResizeRows = false;
            dgvPhieuThu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPhieuThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhieuThu.BackgroundColor = Color.White;
            dgvPhieuThu.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPhieuThu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPhieuThu.ColumnHeadersHeight = 40;
            dgvPhieuThu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPhieuThu.Columns.AddRange(new DataGridViewColumn[] { colMaPhieuThu, colDocGia, colSoTienThu, colNgayLap });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvPhieuThu.DefaultCellStyle = dataGridViewCellStyle3;
            dgvPhieuThu.EnableHeadersVisualStyles = false;
            dgvPhieuThu.Location = new Point(20, 64);
            dgvPhieuThu.Margin = new Padding(20, 10, 20, 20);
            dgvPhieuThu.Name = "dgvPhieuThu";
            dgvPhieuThu.RowHeadersVisible = false;
            dgvPhieuThu.RowTemplate.Height = 40;
            dgvPhieuThu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhieuThu.ShowDeleteButton = true;
            dgvPhieuThu.ShowEditButton = false;
            dgvPhieuThu.ShowExtendButton = false;
            dgvPhieuThu.ShowPrintButton = true;
            dgvPhieuThu.ShowReturnButton = false;
            dgvPhieuThu.ShowViewButton = false;
            dgvPhieuThu.Size = new Size(1120, 558);
            dgvPhieuThu.TabIndex = 1;
            // 
            // colMaPhieuThu
            // 
            colMaPhieuThu.DataPropertyName = "MaPhieuThu";
            colMaPhieuThu.HeaderText = "Mã phiếu thu";
            colMaPhieuThu.Name = "colMaPhieuThu";
            // 
            // colDocGia
            // 
            colDocGia.DataPropertyName = "TenDocGia";
            colDocGia.HeaderText = "Độc giả";
            colDocGia.Name = "colDocGia";
            // 
            // colSoTienThu
            // 
            colSoTienThu.DataPropertyName = "SoTienThu";
            colSoTienThu.HeaderText = "Số tiền thu";
            colSoTienThu.Name = "colSoTienThu";
            // 
            // colNgayLap
            // 
            colNgayLap.DataPropertyName = "NgayLapPhieu";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            colNgayLap.DefaultCellStyle = dataGridViewCellStyle2;
            colNgayLap.HeaderText = "Ngày lập phiếu";
            colNgayLap.Name = "colNgayLap";
            // 
            // roundPanel1
            // 
            roundPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roundPanel1.BackColor = Color.Transparent;
            roundPanel1.BackgroundColor = Color.White;
            roundPanel1.BorderColor = Color.White;
            roundPanel1.BorderRadius = 10;
            roundPanel1.BorderWidth = 0F;
            roundPanel1.Controls.Add(cbDocGia);
            roundPanel1.Controls.Add(label2);
            roundPanel1.Controls.Add(btnThem);
            roundPanel1.Controls.Add(dgvPhieuThu);
            roundPanel1.Location = new Point(20, 103);
            roundPanel1.Margin = new Padding(20);
            roundPanel1.Name = "roundPanel1";
            roundPanel1.Size = new Size(1160, 642);
            roundPanel1.TabIndex = 2;
            // 
            // cbDocGia
            // 
            cbDocGia.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbDocGia.FormattingEnabled = true;
            cbDocGia.Location = new Point(87, 23);
            cbDocGia.Name = "cbDocGia";
            cbDocGia.Size = new Size(187, 28);
            cbDocGia.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(20, 27);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 2;
            label2.Text = "Độc giả";
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThem.BackColor = Color.CornflowerBlue;
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.ForeColor = SystemColors.HighlightText;
            btnThem.Image = Properties.Resources.plus;
            btnThem.Location = new Point(983, 20);
            btnThem.Margin = new Padding(20, 20, 20, 0);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(157, 34);
            btnThem.TabIndex = 1;
            btnThem.Text = "  Thêm phiếu thu";
            btnThem.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // UCPhieuThu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(panel1);
            Controls.Add(roundPanel1);
            Name = "UCPhieuThu";
            Size = new Size(1200, 765);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhieuThu).EndInit();
            roundPanel1.ResumeLayout(false);
            roundPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Controls.ActionDataGridView dgvPhieuThu;
        private Controls.RoundPanel roundPanel1;
        private Button btnThem;
        private ComboBox cbDocGia;
        private Label label2;
        private DataGridViewTextBoxColumn colMaPhieuThu;
        private DataGridViewTextBoxColumn colDocGia;
        private DataGridViewTextBoxColumn colSoTienThu;
        private DataGridViewTextBoxColumn colNgayLap;
    }
}
