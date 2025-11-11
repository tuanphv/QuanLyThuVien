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
            label1.Location = new Point(100, 47);
            label1.Name = "label1";
            label1.Size = new Size(87, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã thể loại:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(100, 113);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 1;
            label2.Text = "Tên thể loại:";
            // 
            // txtMaTheLoai
            // 
            txtMaTheLoai.Location = new Point(220, 40);
            txtMaTheLoai.Name = "txtMaTheLoai";
            txtMaTheLoai.ReadOnly = true;
            txtMaTheLoai.Size = new Size(125, 27);
            txtMaTheLoai.TabIndex = 2;
            // 
            // txtTenTheLoai
            // 
            txtTenTheLoai.Location = new Point(220, 106);
            txtTenTheLoai.Name = "txtTenTheLoai";
            txtTenTheLoai.Size = new Size(125, 27);
            txtTenTheLoai.TabIndex = 3;
            // 
            // btnLuu
            // 
            btnLuu.DialogResult = DialogResult.OK;
            btnLuu.Location = new Point(72, 204);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(94, 29);
            btnLuu.TabIndex = 4;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            btnThoat.DialogResult = DialogResult.Cancel;
            btnThoat.Location = new Point(251, 204);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 5;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // FrmAddEditTheLoai
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 301);
            Controls.Add(btnThoat);
            Controls.Add(btnLuu);
            Controls.Add(txtTenTheLoai);
            Controls.Add(txtMaTheLoai);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmAddEditTheLoai";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmAddEditTheLoai";
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