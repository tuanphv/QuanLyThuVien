namespace GUI.NhapSach
{
    partial class FrmAddPhieuNhap
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel1 = new Panel();
            dtpNgayNhap = new DateTimePicker();
            label2 = new Label();
            cbNhaCungCap = new ComboBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            btnXoa = new Button();
            btnThem = new Button();
            nudSoLuong = new NumericUpDown();
            label6 = new Label();
            nudDonGia = new NumericUpDown();
            label5 = new Label();
            nudNamXB = new NumericUpDown();
            label4 = new Label();
            cbNhaXuatBan = new ComboBox();
            label7 = new Label();
            cbTuaSach = new ComboBox();
            label3 = new Label();
            dgvChiTiet = new DataGridView();
            colTenTuaSach = new DataGridViewTextBoxColumn();
            colNhaXuatBan = new DataGridViewTextBoxColumn();
            colNamXB = new DataGridViewTextBoxColumn();
            colSoLuong = new DataGridViewTextBoxColumn();
            colDonGia = new DataGridViewTextBoxColumn();
            colThanhTien = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            btnHuy = new Button();
            btnLuu = new Button();
            lblTongTien = new Label();
            label8 = new Label();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDonGia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNamXB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(dtpNgayNhap);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cbNhaCungCap);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(20);
            panel1.Size = new Size(984, 90);
            panel1.TabIndex = 0;
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpNgayNhap.Font = new Font("Segoe UI", 10F);
            dtpNgayNhap.Format = DateTimePickerFormat.Custom;
            dtpNgayNhap.Location = new Point(593, 43);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(200, 25);
            dtpNgayNhap.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(593, 20);
            label2.Name = "label2";
            label2.Size = new Size(79, 19);
            label2.TabIndex = 2;
            label2.Text = "Ngày nhập:";
            // 
            // cbNhaCungCap
            // 
            cbNhaCungCap.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNhaCungCap.Font = new Font("Segoe UI", 10F);
            cbNhaCungCap.FormattingEnabled = true;
            cbNhaCungCap.Location = new Point(23, 43);
            cbNhaCungCap.Name = "cbNhaCungCap";
            cbNhaCungCap.Size = new Size(400, 25);
            cbNhaCungCap.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(23, 20);
            label1.Name = "label1";
            label1.Size = new Size(96, 19);
            label1.TabIndex = 0;
            label1.Text = "Nhà cung cấp:";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(nudSoLuong);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(nudDonGia);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(nudNamXB);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cbNhaXuatBan);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(cbTuaSach);
            groupBox1.Controls.Add(label3);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox1.Location = new Point(0, 90);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(20);
            groupBox1.Size = new Size(984, 160);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin sách nhập";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(220, 53, 69);
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(887, 102);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 35);
            btnXoa.TabIndex = 11;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(0, 119, 200);
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(887, 50);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(75, 35);
            btnThem.TabIndex = 10;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // nudSoLuong
            // 
            nudSoLuong.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudSoLuong.Location = new Point(593, 112);
            nudSoLuong.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSoLuong.Name = "nudSoLuong";
            nudSoLuong.Size = new Size(120, 25);
            nudSoLuong.TabIndex = 9;
            nudSoLuong.TextAlign = HorizontalAlignment.Right;
            nudSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(593, 90);
            label6.Name = "label6";
            label6.Size = new Size(66, 19);
            label6.TabIndex = 8;
            label6.Text = "Số lượng:";
            // 
            // nudDonGia
            // 
            nudDonGia.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudDonGia.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            nudDonGia.Location = new Point(593, 50);
            nudDonGia.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudDonGia.Name = "nudDonGia";
            nudDonGia.Size = new Size(200, 25);
            nudDonGia.TabIndex = 7;
            nudDonGia.TextAlign = HorizontalAlignment.Right;
            nudDonGia.ThousandsSeparator = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(593, 28);
            label5.Name = "label5";
            label5.Size = new Size(73, 19);
            label5.TabIndex = 6;
            label5.Text = "Giá (VNĐ):";
            // 
            // nudNamXB
            // 
            nudNamXB.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudNamXB.Location = new Point(303, 112);
            nudNamXB.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            nudNamXB.Minimum = new decimal(new int[] { 1900, 0, 0, 0 });
            nudNamXB.Name = "nudNamXB";
            nudNamXB.Size = new Size(120, 25);
            nudNamXB.TabIndex = 5;
            nudNamXB.TextAlign = HorizontalAlignment.Right;
            nudNamXB.Value = new decimal(new int[] { 2025, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(303, 90);
            label4.Name = "label4";
            label4.Size = new Size(98, 19);
            label4.TabIndex = 4;
            label4.Text = "Năm xuất bản:";
            // 
            // cbNhaXuatBan
            // 
            cbNhaXuatBan.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNhaXuatBan.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbNhaXuatBan.FormattingEnabled = true;
            cbNhaXuatBan.Location = new Point(23, 112);
            cbNhaXuatBan.Name = "cbNhaXuatBan";
            cbNhaXuatBan.Size = new Size(250, 25);
            cbNhaXuatBan.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(23, 90);
            label7.Name = "label7";
            label7.Size = new Size(94, 19);
            label7.TabIndex = 2;
            label7.Text = "Nhà xuất bản:";
            // 
            // cbTuaSach
            // 
            cbTuaSach.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbTuaSach.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbTuaSach.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbTuaSach.FormattingEnabled = true;
            cbTuaSach.Location = new Point(23, 50);
            cbTuaSach.Name = "cbTuaSach";
            cbTuaSach.Size = new Size(500, 25);
            cbTuaSach.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(23, 28);
            label3.Name = "label3";
            label3.Size = new Size(65, 19);
            label3.TabIndex = 0;
            label3.Text = "Tựa sách:";
            label3.Click += label3_Click;
            // 
            // dgvChiTiet
            // 
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.AllowUserToDeleteRows = false;
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.BackgroundColor = Color.White;
            dgvChiTiet.BorderStyle = BorderStyle.None;
            dgvChiTiet.ColumnHeadersHeight = 35;
            dgvChiTiet.Columns.AddRange(new DataGridViewColumn[] { colTenTuaSach, colNhaXuatBan, colNamXB, colSoLuong, colDonGia, colThanhTien });
            dgvChiTiet.Dock = DockStyle.Fill;
            dgvChiTiet.Location = new Point(0, 250);
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.RowHeadersVisible = false;
            dgvChiTiet.RowHeadersWidth = 51;
            dgvChiTiet.RowTemplate.Height = 30;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.Size = new Size(984, 308);
            dgvChiTiet.TabIndex = 2;
            // 
            // colTenTuaSach
            // 
            colTenTuaSach.HeaderText = "Tựa sách";
            colTenTuaSach.MinimumWidth = 6;
            colTenTuaSach.Name = "colTenTuaSach";
            colTenTuaSach.ReadOnly = true;
            // 
            // colNhaXuatBan
            // 
            colNhaXuatBan.HeaderText = "Nhà xuất bản";
            colNhaXuatBan.MinimumWidth = 6;
            colNhaXuatBan.Name = "colNhaXuatBan";
            colNhaXuatBan.ReadOnly = true;
            // 
            // colNamXB
            // 
            colNamXB.HeaderText = "Năm XB";
            colNamXB.MinimumWidth = 6;
            colNamXB.Name = "colNamXB";
            colNamXB.ReadOnly = true;
            // 
            // colSoLuong
            // 
            colSoLuong.HeaderText = "Số lượng";
            colSoLuong.MinimumWidth = 6;
            colSoLuong.Name = "colSoLuong";
            colSoLuong.ReadOnly = true;
            // 
            // colDonGia
            // 
            colDonGia.HeaderText = "Đơn giá";
            colDonGia.MinimumWidth = 6;
            colDonGia.Name = "colDonGia";
            colDonGia.ReadOnly = true;
            // 
            // colThanhTien
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            colThanhTien.DefaultCellStyle = dataGridViewCellStyle1;
            colThanhTien.HeaderText = "Thành tiền";
            colThanhTien.MinimumWidth = 6;
            colThanhTien.Name = "colThanhTien";
            colThanhTien.ReadOnly = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(btnHuy);
            panel2.Controls.Add(btnLuu);
            panel2.Controls.Add(lblTongTien);
            panel2.Controls.Add(label8);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 558);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(20);
            panel2.Size = new Size(984, 80);
            panel2.TabIndex = 3;
            // 
            // btnHuy
            // 
            btnHuy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHuy.BackColor = Color.FromArgb(108, 117, 125);
            btnHuy.DialogResult = DialogResult.Cancel;
            btnHuy.FlatAppearance.BorderSize = 0;
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(867, 20);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(95, 40);
            btnHuy.TabIndex = 3;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            btnLuu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLuu.BackColor = Color.FromArgb(40, 167, 69);
            btnLuu.DialogResult = DialogResult.OK;
            btnLuu.FlatAppearance.BorderSize = 0;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(756, 20);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(95, 40);
            btnLuu.TabIndex = 2;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTongTien.ForeColor = Color.FromArgb(220, 53, 69);
            lblTongTien.Location = new Point(118, 24);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(80, 30);
            lblTongTien.TabIndex = 1;
            lblTongTien.Text = "0 VNĐ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label8.Location = new Point(23, 28);
            label8.Name = "label8";
            label8.Size = new Size(87, 21);
            label8.TabIndex = 0;
            label8.Text = "Tổng tiền:";
            // 
            // FrmAddPhieuNhap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 240);
            ClientSize = new Size(984, 638);
            Controls.Add(dgvChiTiet);
            Controls.Add(panel2);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAddPhieuNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lập phiếu nhập sách";
            Load += FrmAddPhieuNhap_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDonGia).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudNamXB).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbNhaCungCap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbTuaSach;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudNamXB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudDonGia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.ComboBox cbNhaXuatBan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenTuaSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNhaXuatBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNamXB;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
    }
}
