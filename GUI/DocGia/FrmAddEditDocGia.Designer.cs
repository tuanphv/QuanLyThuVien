namespace GUI.DocGia
{
    partial class FrmAddEditDocGia
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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddEditDocGia));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtMaDocGia = new TextBox();
            txtHoTen = new TextBox();
            txtDiaChi = new TextBox();
            txtTongNo = new TextBox();
            dtpNgaySinh = new DateTimePicker();
            dtpNgayLapThe = new DateTimePicker();
            dtpNgayHetHan = new DateTimePicker();
            cboNguoiDung = new ComboBox();
            btnLuu = new Button();
            btnThoat = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label1.Location = new Point(40, 30);
            label1.Name = "label1";
            label1.Size = new Size(106, 23);
            label1.TabIndex = 0;
            label1.Text = "Mã độc giả:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.Location = new Point(40, 75);
            label2.Name = "label2";
            label2.Size = new Size(67, 23);
            label2.TabIndex = 1;
            label2.Text = "Họ tên:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label3.Location = new Point(40, 120);
            label3.Name = "label3";
            label3.Size = new Size(92, 23);
            label3.TabIndex = 2;
            label3.Text = "Ngày sinh:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label4.Location = new Point(40, 165);
            label4.Name = "label4";
            label4.Size = new Size(68, 23);
            label4.TabIndex = 3;
            label4.Text = "Địa chỉ:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label5.Location = new Point(40, 210);
            label5.Name = "label5";
            label5.Size = new Size(113, 23);
            label5.TabIndex = 4;
            label5.Text = "Ngày lập thẻ:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label6.Location = new Point(40, 255);
            label6.Name = "label6";
            label6.Size = new Size(125, 23);
            label6.TabIndex = 5;
            label6.Text = "Ngày hết hạn:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label7.Location = new Point(40, 300);
            label7.Name = "label7";
            label7.Size = new Size(145, 23);
            label7.TabIndex = 6;
            label7.Text = "Tổng nợ hiện tại:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label8.Location = new Point(40, 345);
            label8.Name = "label8";
            label8.Size = new Size(138, 23);
            label8.TabIndex = 7;
            label8.Text = "Gán tài khoản:";
            // 
            // txtMaDocGia
            // 
            txtMaDocGia.BorderStyle = BorderStyle.FixedSingle;
            txtMaDocGia.Font = new Font("Segoe UI", 10.2F);
            txtMaDocGia.Location = new Point(220, 28);
            txtMaDocGia.Name = "txtMaDocGia";
            txtMaDocGia.ReadOnly = true;
            txtMaDocGia.Size = new Size(300, 30);
            txtMaDocGia.TabIndex = 8;
            // 
            // txtHoTen
            // 
            txtHoTen.BorderStyle = BorderStyle.FixedSingle;
            txtHoTen.Font = new Font("Segoe UI", 10.2F);
            txtHoTen.Location = new Point(220, 73);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(300, 30);
            txtHoTen.TabIndex = 9;
            // 
            // txtDiaChi
            // 
            txtDiaChi.BorderStyle = BorderStyle.FixedSingle;
            txtDiaChi.Font = new Font("Segoe UI", 10.2F);
            txtDiaChi.Location = new Point(220, 163);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(300, 30);
            txtDiaChi.TabIndex = 11;
            // 
            // txtTongNo
            // 
            txtTongNo.BorderStyle = BorderStyle.FixedSingle;
            txtTongNo.Font = new Font("Segoe UI", 10.2F);
            txtTongNo.Location = new Point(220, 298);
            txtTongNo.Name = "txtTongNo";
            txtTongNo.ReadOnly = true;
            txtTongNo.Size = new Size(300, 30);
            txtTongNo.TabIndex = 14;
            txtTongNo.Text = "0";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Font = new Font("Segoe UI", 10.2F);
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(220, 118);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(300, 30);
            dtpNgaySinh.TabIndex = 10;
            // 
            // dtpNgayLapThe
            // 
            dtpNgayLapThe.Font = new Font("Segoe UI", 10.2F);
            dtpNgayLapThe.Format = DateTimePickerFormat.Short;
            dtpNgayLapThe.Location = new Point(220, 208);
            dtpNgayLapThe.Name = "dtpNgayLapThe";
            dtpNgayLapThe.Size = new Size(300, 30);
            dtpNgayLapThe.TabIndex = 12;
            dtpNgayLapThe.ValueChanged += dtpNgayLapThe_ValueChanged;
            // 
            // dtpNgayHetHan
            // 
            dtpNgayHetHan.Font = new Font("Segoe UI", 10.2F);
            dtpNgayHetHan.Format = DateTimePickerFormat.Short;
            dtpNgayHetHan.Location = new Point(220, 253);
            dtpNgayHetHan.Name = "dtpNgayHetHan";
            dtpNgayHetHan.Size = new Size(300, 30);
            dtpNgayHetHan.TabIndex = 13;
            // 
            // cboNguoiDung
            // 
            cboNguoiDung.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNguoiDung.Font = new Font("Segoe UI", 10.2F);
            cboNguoiDung.FormattingEnabled = true;
            cboNguoiDung.Location = new Point(220, 342);
            cboNguoiDung.Name = "cboNguoiDung";
            cboNguoiDung.Size = new Size(300, 31);
            cboNguoiDung.TabIndex = 15;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.DarkTurquoise;
            btnLuu.FlatAppearance.BorderSize = 0;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Image = Properties.Resources.save;
            btnLuu.Location = new Point(140, 400);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(110, 45);
            btnLuu.TabIndex = 16;
            btnLuu.Text = "  Lưu";
            btnLuu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.Tomato;
            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnThoat.ForeColor = Color.White;
            btnThoat.Image = (Image)resources.GetObject("btnThoat.Image");
            btnThoat.Location = new Point(310, 400);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(110, 45);
            btnThoat.TabIndex = 17;
            btnThoat.Text = "  Thoát";
            btnThoat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // FrmAddEditDocGia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 470);
            Controls.Add(btnThoat);
            Controls.Add(btnLuu);
            Controls.Add(cboNguoiDung);
            Controls.Add(dtpNgayHetHan);
            Controls.Add(dtpNgayLapThe);
            Controls.Add(dtpNgaySinh);
            Controls.Add(txtTongNo);
            Controls.Add(txtDiaChi);
            Controls.Add(txtHoTen);
            Controls.Add(txtMaDocGia);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmAddEditDocGia";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm độc giả";
            Load += FrmAddEditDocGia_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtMaDocGia;
        private TextBox txtHoTen;
        private TextBox txtDiaChi;
        private TextBox txtTongNo;
        private DateTimePicker dtpNgaySinh;
        private DateTimePicker dtpNgayLapThe;
        private DateTimePicker dtpNgayHetHan;
        private ComboBox cboNguoiDung;
        private Button btnLuu;
        private Button btnThoat;
    }
}
