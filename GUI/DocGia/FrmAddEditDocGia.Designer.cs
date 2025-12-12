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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtMaDocGia = new TextBox();
            txtHoTen = new TextBox();
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
            label1.Location = new Point(35, 22);
            label1.Name = "label1";
            label1.Size = new Size(88, 19);
            label1.TabIndex = 0;
            label1.Text = "Mã độc giả:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.Location = new Point(35, 56);
            label2.Name = "label2";
            label2.Size = new Size(58, 19);
            label2.TabIndex = 1;
            label2.Text = "Họ tên:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label3.Location = new Point(35, 90);
            label3.Name = "label3";
            label3.Size = new Size(79, 19);
            label3.TabIndex = 2;
            label3.Text = "Ngày sinh:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label5.Location = new Point(35, 124);
            label5.Name = "label5";
            label5.Size = new Size(99, 19);
            label5.TabIndex = 4;
            label5.Text = "Ngày lập thẻ:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label6.Location = new Point(35, 157);
            label6.Name = "label6";
            label6.Size = new Size(102, 19);
            label6.TabIndex = 5;
            label6.Text = "Ngày hết hạn:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label7.Location = new Point(35, 191);
            label7.Name = "label7";
            label7.Size = new Size(121, 19);
            label7.TabIndex = 6;
            label7.Text = "Tổng nợ hiện tại:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label8.Location = new Point(35, 225);
            label8.Name = "label8";
            label8.Size = new Size(105, 19);
            label8.TabIndex = 7;
            label8.Text = "Gán tài khoản:";
            // 
            // txtMaDocGia
            // 
            txtMaDocGia.BorderStyle = BorderStyle.FixedSingle;
            txtMaDocGia.Font = new Font("Segoe UI", 10.2F);
            txtMaDocGia.Location = new Point(192, 21);
            txtMaDocGia.Margin = new Padding(3, 2, 3, 2);
            txtMaDocGia.Name = "txtMaDocGia";
            txtMaDocGia.ReadOnly = true;
            txtMaDocGia.Size = new Size(263, 26);
            txtMaDocGia.TabIndex = 8;
            // 
            // txtHoTen
            // 
            txtHoTen.BorderStyle = BorderStyle.FixedSingle;
            txtHoTen.Font = new Font("Segoe UI", 10.2F);
            txtHoTen.Location = new Point(192, 55);
            txtHoTen.Margin = new Padding(3, 2, 3, 2);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(263, 26);
            txtHoTen.TabIndex = 9;
            // 
            // txtTongNo
            // 
            txtTongNo.BorderStyle = BorderStyle.FixedSingle;
            txtTongNo.Font = new Font("Segoe UI", 10.2F);
            txtTongNo.Location = new Point(192, 190);
            txtTongNo.Margin = new Padding(3, 2, 3, 2);
            txtTongNo.Name = "txtTongNo";
            txtTongNo.ReadOnly = true;
            txtTongNo.Size = new Size(263, 26);
            txtTongNo.TabIndex = 14;
            txtTongNo.Text = "0";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Font = new Font("Segoe UI", 10.2F);
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(192, 88);
            dtpNgaySinh.Margin = new Padding(3, 2, 3, 2);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(263, 26);
            dtpNgaySinh.TabIndex = 10;
            // 
            // dtpNgayLapThe
            // 
            dtpNgayLapThe.Font = new Font("Segoe UI", 10.2F);
            dtpNgayLapThe.Format = DateTimePickerFormat.Short;
            dtpNgayLapThe.Location = new Point(192, 122);
            dtpNgayLapThe.Margin = new Padding(3, 2, 3, 2);
            dtpNgayLapThe.Name = "dtpNgayLapThe";
            dtpNgayLapThe.Size = new Size(263, 26);
            dtpNgayLapThe.TabIndex = 12;
            dtpNgayLapThe.ValueChanged += dtpNgayLapThe_ValueChanged;
            // 
            // dtpNgayHetHan
            // 
            dtpNgayHetHan.Font = new Font("Segoe UI", 10.2F);
            dtpNgayHetHan.Format = DateTimePickerFormat.Short;
            dtpNgayHetHan.Location = new Point(192, 156);
            dtpNgayHetHan.Margin = new Padding(3, 2, 3, 2);
            dtpNgayHetHan.Name = "dtpNgayHetHan";
            dtpNgayHetHan.Size = new Size(263, 26);
            dtpNgayHetHan.TabIndex = 13;
            // 
            // cboNguoiDung
            // 
            cboNguoiDung.BackColor = Color.White;
            cboNguoiDung.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNguoiDung.Font = new Font("Segoe UI", 10.2F);
            cboNguoiDung.FormattingEnabled = true;
            cboNguoiDung.Location = new Point(192, 222);
            cboNguoiDung.Margin = new Padding(3, 2, 3, 2);
            cboNguoiDung.Name = "cboNguoiDung";
            cboNguoiDung.Size = new Size(263, 27);
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
            btnLuu.Location = new Point(122, 266);
            btnLuu.Margin = new Padding(3, 2, 3, 2);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(96, 34);
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
            btnThoat.Location = new Point(271, 266);
            btnThoat.Margin = new Padding(3, 2, 3, 2);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(96, 34);
            btnThoat.TabIndex = 17;
            btnThoat.Text = "  Thoát";
            btnThoat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // FrmAddEditDocGia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(490, 319);
            Controls.Add(btnThoat);
            Controls.Add(btnLuu);
            Controls.Add(cboNguoiDung);
            Controls.Add(dtpNgayHetHan);
            Controls.Add(dtpNgayLapThe);
            Controls.Add(dtpNgaySinh);
            Controls.Add(txtTongNo);
            Controls.Add(txtHoTen);
            Controls.Add(txtMaDocGia);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
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
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtMaDocGia;
        private TextBox txtHoTen;
        private TextBox txtTongNo;
        private DateTimePicker dtpNgaySinh;
        private DateTimePicker dtpNgayLapThe;
        private DateTimePicker dtpNgayHetHan;
        private ComboBox cboNguoiDung;
        private Button btnLuu;
        private Button btnThoat;
    }
}
