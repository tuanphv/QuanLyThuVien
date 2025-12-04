namespace GUI.Sach
{
    partial class FrmChiTietCuonSach
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChiTietCuonSach));
            panel1 = new Panel();
            lblTieuDe = new Label();
            panel2 = new Panel();
            dgvCuonSach = new DataGridView();
            panel3 = new Panel();
            grpXuLy = new GroupBox();
            label1 = new Label();
            cboTinhTrang = new ComboBox();
            lblMaDangChon = new Label();
            btnThoat = new Button();
            btnCapNhat = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCuonSach).BeginInit();
            panel3.SuspendLayout();
            grpXuLy.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(lblTieuDe);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(921, 83);
            panel1.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDe.Location = new Point(40, 21);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(533, 46);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Danh sách cuốn sách thuộc lô: ...";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(dgvCuonSach);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 450);
            panel2.Name = "panel2";
            panel2.Size = new Size(921, 362);
            panel2.TabIndex = 1;
            // 
            // dgvCuonSach
            // 
            dgvCuonSach.BorderStyle = BorderStyle.None;
            dgvCuonSach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCuonSach.Dock = DockStyle.Fill;
            dgvCuonSach.Location = new Point(0, 0);
            dgvCuonSach.Name = "dgvCuonSach";
            dgvCuonSach.RowHeadersWidth = 51;
            dgvCuonSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCuonSach.Size = new Size(921, 362);
            dgvCuonSach.TabIndex = 0;
            dgvCuonSach.CellContentClick += dgvCuonSach_CellClick;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(grpXuLy);
            panel3.Location = new Point(24, 102);
            panel3.Name = "panel3";
            panel3.Size = new Size(874, 333);
            panel3.TabIndex = 2;
            // 
            // grpXuLy
            // 
            grpXuLy.Controls.Add(label1);
            grpXuLy.Controls.Add(cboTinhTrang);
            grpXuLy.Controls.Add(lblMaDangChon);
            grpXuLy.Controls.Add(btnThoat);
            grpXuLy.Controls.Add(btnCapNhat);
            grpXuLy.Dock = DockStyle.Fill;
            grpXuLy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpXuLy.Location = new Point(0, 0);
            grpXuLy.Name = "grpXuLy";
            grpXuLy.Size = new Size(874, 333);
            grpXuLy.TabIndex = 0;
            grpXuLy.TabStop = false;
            grpXuLy.Text = "Cập nhật trạng thái";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(79, 137);
            label1.Name = "label1";
            label1.Size = new Size(105, 28);
            label1.TabIndex = 30;
            label1.Text = "Tình trạng:";
            // 
            // cboTinhTrang
            // 
            cboTinhTrang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTinhTrang.FormattingEnabled = true;
            cboTinhTrang.Location = new Point(190, 129);
            cboTinhTrang.Name = "cboTinhTrang";
            cboTinhTrang.Size = new Size(221, 36);
            cboTinhTrang.TabIndex = 29;
            // 
            // lblMaDangChon
            // 
            lblMaDangChon.AutoSize = true;
            lblMaDangChon.Location = new Point(79, 69);
            lblMaDangChon.Name = "lblMaDangChon";
            lblMaDangChon.Size = new Size(221, 28);
            lblMaDangChon.TabIndex = 28;
            lblMaDangChon.Text = "Đang chọn: [Chưa chọn]";
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.Tomato;
            btnThoat.DialogResult = DialogResult.Cancel;
            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnThoat.ForeColor = Color.White;
            btnThoat.Image = (Image)resources.GetObject("btnThoat.Image");
            btnThoat.Location = new Point(548, 248);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(90, 53);
            btnThoat.TabIndex = 27;
            btnThoat.Text = "Đóng";
            btnThoat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnCapNhat
            // 
            btnCapNhat.BackColor = Color.DarkTurquoise;
            btnCapNhat.DialogResult = DialogResult.OK;
            btnCapNhat.FlatAppearance.BorderSize = 0;
            btnCapNhat.FlatStyle = FlatStyle.Flat;
            btnCapNhat.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCapNhat.ForeColor = Color.White;
            btnCapNhat.Image = Properties.Resources.save;
            btnCapNhat.Location = new Point(235, 248);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(176, 53);
            btnCapNhat.TabIndex = 26;
            btnCapNhat.Text = "Lưu trạng thái";
            btnCapNhat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCapNhat.UseVisualStyleBackColor = false;
            btnCapNhat.Click += btnCapNhat_Click;
            // 
            // FrmChiTietCuonSach
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(921, 812);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "FrmChiTietCuonSach";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chi tiết";
            Load += FrmChiTietCuonSach_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCuonSach).EndInit();
            panel3.ResumeLayout(false);
            grpXuLy.ResumeLayout(false);
            grpXuLy.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblTieuDe;
        private Panel panel2;
        private Panel panel3;
        private DataGridView dgvCuonSach;
        private GroupBox grpXuLy;
        private Button btnThoat;
        private Button btnCapNhat;
        private Label label1;
        private ComboBox cboTinhTrang;
        private Label lblMaDangChon;
    }
}