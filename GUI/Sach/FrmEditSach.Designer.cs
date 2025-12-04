namespace GUI.Sach
{
    partial class FrmEditSach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditSach));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtMaSach = new TextBox();
            txtTenTuaSach = new TextBox();
            txtSoLuong = new TextBox();
            txtNamXB = new TextBox();
            txtDonGia = new TextBox();
            cboNXB = new ComboBox();
            btnThoat = new Button();
            btnLuu = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label1.Location = new Point(91, 37);
            label1.Name = "label1";
            label1.Size = new Size(60, 23);
            label1.TabIndex = 0;
            label1.Text = "Mã lô:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.Location = new Point(91, 91);
            label2.Name = "label2";
            label2.Size = new Size(84, 23);
            label2.TabIndex = 1;
            label2.Text = "Tựa sách:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label3.Location = new Point(91, 148);
            label3.Name = "label3";
            label3.Size = new Size(122, 23);
            label3.TabIndex = 2;
            label3.Text = "Nhà xuất bản:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label4.Location = new Point(454, 148);
            label4.Name = "label4";
            label4.Size = new Size(80, 23);
            label4.TabIndex = 3;
            label4.Text = "Năm XB:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label5.Location = new Point(91, 208);
            label5.Name = "label5";
            label5.Size = new Size(88, 23);
            label5.TabIndex = 4;
            label5.Text = "Số lượng:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label6.Location = new Point(455, 208);
            label6.Name = "label6";
            label6.Size = new Size(79, 23);
            label6.TabIndex = 5;
            label6.Text = "Đơn giá:";
            // 
            // txtMaSach
            // 
            txtMaSach.BorderStyle = BorderStyle.FixedSingle;
            txtMaSach.Enabled = false;
            txtMaSach.Location = new Point(219, 37);
            txtMaSach.Name = "txtMaSach";
            txtMaSach.ReadOnly = true;
            txtMaSach.Size = new Size(125, 27);
            txtMaSach.TabIndex = 6;
            // 
            // txtTenTuaSach
            // 
            txtTenTuaSach.BorderStyle = BorderStyle.FixedSingle;
            txtTenTuaSach.Enabled = false;
            txtTenTuaSach.Location = new Point(219, 87);
            txtTenTuaSach.Name = "txtTenTuaSach";
            txtTenTuaSach.ReadOnly = true;
            txtTenTuaSach.Size = new Size(376, 27);
            txtTenTuaSach.TabIndex = 7;
            // 
            // txtSoLuong
            // 
            txtSoLuong.BorderStyle = BorderStyle.FixedSingle;
            txtSoLuong.Enabled = false;
            txtSoLuong.Location = new Point(219, 204);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.ReadOnly = true;
            txtSoLuong.Size = new Size(125, 27);
            txtSoLuong.TabIndex = 9;
            // 
            // txtNamXB
            // 
            txtNamXB.BorderStyle = BorderStyle.FixedSingle;
            txtNamXB.Location = new Point(540, 144);
            txtNamXB.Name = "txtNamXB";
            txtNamXB.Size = new Size(125, 27);
            txtNamXB.TabIndex = 10;
            // 
            // txtDonGia
            // 
            txtDonGia.BorderStyle = BorderStyle.FixedSingle;
            txtDonGia.Location = new Point(540, 204);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(125, 27);
            txtDonGia.TabIndex = 11;
            // 
            // cboNXB
            // 
            cboNXB.FormattingEnabled = true;
            cboNXB.Location = new Point(219, 143);
            cboNXB.Name = "cboNXB";
            cboNXB.Size = new Size(213, 28);
            cboNXB.TabIndex = 12;
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
            btnThoat.Location = new Point(430, 304);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(92, 41);
            btnThoat.TabIndex = 25;
            btnThoat.Text = "Thoát";
            btnThoat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.DarkTurquoise;
            btnLuu.DialogResult = DialogResult.OK;
            btnLuu.FlatAppearance.BorderSize = 0;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Image = Properties.Resources.save;
            btnLuu.Location = new Point(215, 304);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(92, 41);
            btnLuu.TabIndex = 24;
            btnLuu.Text = "Lưu";
            btnLuu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // FrmEditSach
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(756, 394);
            Controls.Add(btnThoat);
            Controls.Add(btnLuu);
            Controls.Add(cboNXB);
            Controls.Add(txtDonGia);
            Controls.Add(txtNamXB);
            Controls.Add(txtSoLuong);
            Controls.Add(txtTenTuaSach);
            Controls.Add(txtMaSach);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmEditSach";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sửa";
            Load += FrmEditSach_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtMaSach;
        private TextBox txtTenTuaSach;
        private TextBox txtSoLuong;
        private TextBox txtNamXB;
        private TextBox txtDonGia;
        private ComboBox cboNXB;
        private Button btnThoat;
        private Button btnLuu;
    }
}