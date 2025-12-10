namespace GUI.NguoiDung
{
    partial class FrmAddEditNguoiDung
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
            txtMaNguoiDung = new TextBox();
            txtTenNguoiDung = new TextBox();
            txtTenDangNhap = new TextBox();
            txtMatKhau = new TextBox();
            dtpNgaySinh = new DateTimePicker();
            cboNhomNguoiDung = new ComboBox();
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
            label1.Size = new Size(115, 19);
            label1.TabIndex = 0;
            label1.Text = "Mã người dùng:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.Location = new Point(35, 56);
            label2.Name = "label2";
            label2.Size = new Size(117, 19);
            label2.TabIndex = 1;
            label2.Text = "Tên người dùng:";
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
            label5.Size = new Size(111, 19);
            label5.TabIndex = 4;
            label5.Text = "Tên đăng nhập:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label6.Location = new Point(35, 157);
            label6.Name = "label6";
            label6.Size = new Size(75, 19);
            label6.TabIndex = 5;
            label6.Text = "Mật khẩu:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label7.Location = new Point(35, 191);
            label7.Name = "label7";
            label7.Size = new Size(135, 19);
            label7.TabIndex = 6;
            label7.Text = "Nhóm người dùng:";
            // 
            // txtMaNguoiDung
            // 
            txtMaNguoiDung.BorderStyle = BorderStyle.FixedSingle;
            txtMaNguoiDung.Font = new Font("Segoe UI", 10.2F);
            txtMaNguoiDung.Location = new Point(192, 21);
            txtMaNguoiDung.Margin = new Padding(3, 2, 3, 2);
            txtMaNguoiDung.Name = "txtMaNguoiDung";
            txtMaNguoiDung.ReadOnly = true;
            txtMaNguoiDung.Size = new Size(263, 26);
            txtMaNguoiDung.TabIndex = 7;
            // 
            // txtTenNguoiDung
            // 
            txtTenNguoiDung.BorderStyle = BorderStyle.FixedSingle;
            txtTenNguoiDung.Font = new Font("Segoe UI", 10.2F);
            txtTenNguoiDung.Location = new Point(192, 55);
            txtTenNguoiDung.Margin = new Padding(3, 2, 3, 2);
            txtTenNguoiDung.Name = "txtTenNguoiDung";
            txtTenNguoiDung.Size = new Size(263, 26);
            txtTenNguoiDung.TabIndex = 8;
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.BorderStyle = BorderStyle.FixedSingle;
            txtTenDangNhap.Font = new Font("Segoe UI", 10.2F);
            txtTenDangNhap.Location = new Point(192, 122);
            txtTenDangNhap.Margin = new Padding(3, 2, 3, 2);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(263, 26);
            txtTenDangNhap.TabIndex = 11;
            // 
            // txtMatKhau
            // 
            txtMatKhau.BorderStyle = BorderStyle.FixedSingle;
            txtMatKhau.Font = new Font("Segoe UI", 10.2F);
            txtMatKhau.Location = new Point(192, 156);
            txtMatKhau.Margin = new Padding(3, 2, 3, 2);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(263, 26);
            txtMatKhau.TabIndex = 12;
            txtMatKhau.UseSystemPasswordChar = true;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Font = new Font("Segoe UI", 10.2F);
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(192, 88);
            dtpNgaySinh.Margin = new Padding(3, 2, 3, 2);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.ShowCheckBox = true;
            dtpNgaySinh.Size = new Size(263, 26);
            dtpNgaySinh.TabIndex = 9;
            // 
            // cboNhomNguoiDung
            // 
            cboNhomNguoiDung.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhomNguoiDung.Font = new Font("Segoe UI", 10.2F);
            cboNhomNguoiDung.FormattingEnabled = true;
            cboNhomNguoiDung.Location = new Point(192, 189);
            cboNhomNguoiDung.Margin = new Padding(3, 2, 3, 2);
            cboNhomNguoiDung.Name = "cboNhomNguoiDung";
            cboNhomNguoiDung.Size = new Size(263, 27);
            cboNhomNguoiDung.TabIndex = 13;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.DarkTurquoise;
            btnLuu.FlatAppearance.BorderSize = 0;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Image = Properties.Resources.save;
            btnLuu.Location = new Point(122, 236);
            btnLuu.Margin = new Padding(3, 2, 3, 2);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(96, 34);
            btnLuu.TabIndex = 14;
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
            btnThoat.Location = new Point(271, 236);
            btnThoat.Margin = new Padding(3, 2, 3, 2);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(96, 34);
            btnThoat.TabIndex = 15;
            btnThoat.Text = "  Thoát";
            btnThoat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // FrmAddEditNguoiDung
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(490, 289);
            Controls.Add(btnThoat);
            Controls.Add(btnLuu);
            Controls.Add(cboNhomNguoiDung);
            Controls.Add(dtpNgaySinh);
            Controls.Add(txtMatKhau);
            Controls.Add(txtTenDangNhap);
            Controls.Add(txtTenNguoiDung);
            Controls.Add(txtMaNguoiDung);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmAddEditNguoiDung";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm người dùng";
            Load += FrmAddEditNguoiDung_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtMaNguoiDung;
        private TextBox txtTenNguoiDung;
        private TextBox txtTenDangNhap;
        private TextBox txtMatKhau;
        private DateTimePicker dtpNgaySinh;
        private ComboBox cboNhomNguoiDung;
        private Button btnLuu;
        private Button btnThoat;
    }
}
