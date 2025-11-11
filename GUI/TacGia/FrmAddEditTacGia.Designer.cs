namespace GUI.TacGia
{
    partial class FrmAddEditTacGia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddEditTacGia));
            btnThoat = new Button();
            btnLuu = new Button();
            txtTenTacGia = new TextBox();
            txtMaTacGia = new TextBox();
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
            btnThoat.Location = new Point(277, 172);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(92, 41);
            btnThoat.TabIndex = 11;
            btnThoat.Text = "Thoát";
            btnThoat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThoat.UseVisualStyleBackColor = false;
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
            btnLuu.Location = new Point(98, 172);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(92, 41);
            btnLuu.TabIndex = 10;
            btnLuu.Text = "Lưu";
            btnLuu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLuu.UseVisualStyleBackColor = false;
            // 
            // txtTenTacGia
            // 
            txtTenTacGia.BorderStyle = BorderStyle.FixedSingle;
            txtTenTacGia.Location = new Point(205, 107);
            txtTenTacGia.Name = "txtTenTacGia";
            txtTenTacGia.Size = new Size(175, 27);
            txtTenTacGia.TabIndex = 9;
            // 
            // txtMaTacGia
            // 
            txtMaTacGia.BorderStyle = BorderStyle.FixedSingle;
            txtMaTacGia.Location = new Point(205, 41);
            txtMaTacGia.Name = "txtMaTacGia";
            txtMaTacGia.ReadOnly = true;
            txtMaTacGia.Size = new Size(175, 27);
            txtMaTacGia.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.Location = new Point(85, 107);
            label2.Name = "label2";
            label2.Size = new Size(101, 23);
            label2.TabIndex = 7;
            label2.Text = "Tên tác giả:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label1.Location = new Point(85, 41);
            label1.Name = "label1";
            label1.Size = new Size(99, 23);
            label1.TabIndex = 6;
            label1.Text = "Mã tác giả:";
            // 
            // FrmAddEditTacGia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(465, 269);
            Controls.Add(btnThoat);
            Controls.Add(btnLuu);
            Controls.Add(txtTenTacGia);
            Controls.Add(txtMaTacGia);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmAddEditTacGia";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm tác giả";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnThoat;
        private Button btnLuu;
        private TextBox txtTenTacGia;
        private TextBox txtMaTacGia;
        private Label label2;
        private Label label1;
    }
}