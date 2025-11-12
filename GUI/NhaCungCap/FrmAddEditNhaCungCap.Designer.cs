namespace GUI.NhaCungCap
{
    partial class FrmAddEditNhaCungCap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddEditNhaCungCap));
            btnThoat = new Button();
            btnLuu = new Button();
            txtDiaChi = new TextBox();
            txtTenNCC = new TextBox();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
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
            btnThoat.Location = new Point(284, 171);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(92, 41);
            btnThoat.TabIndex = 23;
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
            btnLuu.Location = new Point(105, 171);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(92, 41);
            btnLuu.TabIndex = 22;
            btnLuu.Text = "Lưu";
            btnLuu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // txtDiaChi
            // 
            txtDiaChi.BorderStyle = BorderStyle.FixedSingle;
            txtDiaChi.Location = new Point(212, 106);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(175, 27);
            txtDiaChi.TabIndex = 21;
            // 
            // txtTenNCC
            // 
            txtTenNCC.BorderStyle = BorderStyle.FixedSingle;
            txtTenNCC.Location = new Point(212, 40);
            txtTenNCC.Name = "txtTenNCC";
            txtTenNCC.ReadOnly = true;
            txtTenNCC.Size = new Size(175, 27);
            txtTenNCC.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.Location = new Point(92, 106);
            label2.Name = "label2";
            label2.Size = new Size(70, 23);
            label2.TabIndex = 19;
            label2.Text = "Địa chỉ:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label1.Location = new Point(92, 40);
            label1.Name = "label1";
            label1.Size = new Size(81, 23);
            label1.TabIndex = 18;
            label1.Text = "Tên NCC:";
            // 
            // FrmAddEditNhaXuatBan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 252);
            Controls.Add(btnThoat);
            Controls.Add(btnLuu);
            Controls.Add(txtDiaChi);
            Controls.Add(txtTenNCC);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmAddEditNhaXuatBan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmAddEditNhaXuatBan";
            Load += FrmAddEditNhaCungCap_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnThoat;
        private Button btnLuu;
        private TextBox txtDiaChi;
        private TextBox txtTenNCC;
        private Label label2;
        private Label label1;
    }
}