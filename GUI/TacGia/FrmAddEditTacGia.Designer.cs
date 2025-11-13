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
            label2 = new Label();
            SuspendLayout();
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.Tomato;
            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnThoat.ForeColor = Color.White;
            btnThoat.Image = (Image)resources.GetObject("btnThoat.Image");
            btnThoat.Location = new Point(276, 122);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(92, 41);
            btnThoat.TabIndex = 11;
            btnThoat.Text = "Thoát";
            btnThoat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.DarkTurquoise;
            btnLuu.FlatAppearance.BorderSize = 0;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Image = Properties.Resources.save;
            btnLuu.Location = new Point(97, 122);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(92, 41);
            btnLuu.TabIndex = 10;
            btnLuu.Text = "Lưu";
            btnLuu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // txtTenTacGia
            // 
            txtTenTacGia.BorderStyle = BorderStyle.FixedSingle;
            txtTenTacGia.Location = new Point(204, 57);
            txtTenTacGia.Name = "txtTenTacGia";
            txtTenTacGia.Size = new Size(175, 27);
            txtTenTacGia.TabIndex = 9;
            txtTenTacGia.TextChanged += txtTenTacGia_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.Location = new Point(84, 57);
            label2.Name = "label2";
            label2.Size = new Size(101, 23);
            label2.TabIndex = 7;
            label2.Text = "Tên tác giả:";
            //label2.Click += this.label2_Click;
            // 
            // FrmAddEditTacGia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(465, 220);
            Controls.Add(btnThoat);
            Controls.Add(btnLuu);
            Controls.Add(txtTenTacGia);
            Controls.Add(label2);
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
        private Label label2;
    }
}