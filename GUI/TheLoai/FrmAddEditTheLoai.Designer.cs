namespace GUI.TheLoai
{
    partial class FrmAddEditTheLoai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddEditTheLoai));
            label1 = new Label();
            label2 = new Label();
            txtMaTheLoai = new TextBox();
            txtTenTheLoai = new TextBox();
            btnLuu = new Button();
            btnThoat = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label1.Location = new Point(77, 48);
            label1.Name = "label1";
            label1.Size = new Size(105, 23);
            label1.TabIndex = 0;
            label1.Text = "Mã thể loại:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.Location = new Point(77, 114);
            label2.Name = "label2";
            label2.Size = new Size(107, 23);
            label2.TabIndex = 1;
            label2.Text = "Tên thể loại:";
            // 
            // txtMaTheLoai
            // 
            txtMaTheLoai.BorderStyle = BorderStyle.FixedSingle;
            txtMaTheLoai.Location = new Point(197, 48);
            txtMaTheLoai.Name = "txtMaTheLoai";
            txtMaTheLoai.ReadOnly = true;
            txtMaTheLoai.Size = new Size(175, 27);
            txtMaTheLoai.TabIndex = 2;
            // 
            // txtTenTheLoai
            // 
            txtTenTheLoai.BorderStyle = BorderStyle.FixedSingle;
            txtTenTheLoai.Location = new Point(197, 114);
            txtTenTheLoai.Name = "txtTenTheLoai";
            txtTenTheLoai.Size = new Size(175, 27);
            txtTenTheLoai.TabIndex = 3;
            txtTenTheLoai.TextChanged += txtTenTheLoai_TextChanged;
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
            btnLuu.Location = new Point(90, 179);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(92, 41);
            btnLuu.TabIndex = 4;
            btnLuu.Text = "Lưu";
            btnLuu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLuu.UseVisualStyleBackColor = false;
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
            btnThoat.Location = new Point(269, 179);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(92, 41);
            btnThoat.TabIndex = 5;
            btnThoat.Text = "Thoát";
            btnThoat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThoat.UseVisualStyleBackColor = false;
            // 
            // FrmAddEditTheLoai
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 268);
            Controls.Add(btnThoat);
            Controls.Add(btnLuu);
            Controls.Add(txtTenTheLoai);
            Controls.Add(txtMaTheLoai);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmAddEditTheLoai";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm thể loại";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtMaTheLoai;
        private TextBox txtTenTheLoai;
        private Button btnLuu;
        private Button btnThoat;
    }
}