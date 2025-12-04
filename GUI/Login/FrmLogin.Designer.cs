namespace GUI.Login
{
    partial class FrmLogin
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
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            roundPanel1 = new GUI.Controls.RoundPanel();
            txtUsername = new GUI.Controls.PlaceholderTextBox();
            btnLogin = new Button();
            btnExit = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            roundPanel2 = new GUI.Controls.RoundPanel();
            txtPassword = new GUI.Controls.PlaceholderTextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            roundPanel1.SuspendLayout();
            roundPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Window;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.library;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(673, 653);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1130, 653);
            panel1.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(pictureBox1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(673, 653);
            panel3.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(127, 145, 228);
            panel2.Controls.Add(roundPanel1);
            panel2.Controls.Add(btnLogin);
            panel2.Controls.Add(btnExit);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(roundPanel2);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(673, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(457, 653);
            panel2.TabIndex = 0;
            // 
            // roundPanel1
            // 
            roundPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            roundPanel1.BackColor = Color.Transparent;
            roundPanel1.BackgroundColor = Color.White;
            roundPanel1.BorderColor = Color.White;
            roundPanel1.BorderRadius = 20;
            roundPanel1.BorderWidth = 0F;
            roundPanel1.Controls.Add(txtUsername);
            roundPanel1.Cursor = Cursors.IBeam;
            roundPanel1.Location = new Point(43, 225);
            roundPanel1.Margin = new Padding(40, 0, 40, 0);
            roundPanel1.Name = "roundPanel1";
            roundPanel1.Size = new Size(374, 49);
            roundPanel1.TabIndex = 2;
            roundPanel1.Click += roundPanel1_Click;
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.ForeColor = Color.Gray;
            txtUsername.Location = new Point(17, 14);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderColor = Color.Gray;
            txtUsername.PlaceholderText = "Tên đăng nhập";
            txtUsername.Size = new Size(340, 22);
            txtUsername.TabIndex = 1;
            txtUsername.Text = "Tên đăng nhập";
            txtUsername.TextColor = Color.Black;
            txtUsername.KeyDown += txtUsername_KeyDown;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.White;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.FromArgb(127, 145, 228);
            btnLogin.Location = new Point(43, 440);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(374, 49);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.FlatAppearance.BorderSize = 2;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(43, 507);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(374, 49);
            btnExit.TabIndex = 4;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnCancel_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(198, 146);
            label4.Name = "label4";
            label4.Size = new Size(69, 30);
            label4.TabIndex = 4;
            label4.Text = "Login";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(47, 61);
            label3.Name = "label3";
            label3.Size = new Size(370, 32);
            label3.TabIndex = 3;
            label3.Text = "HỆ THỐNG QUẢN LÝ THƯ VIỆN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(43, 306);
            label2.Name = "label2";
            label2.Size = new Size(82, 21);
            label2.TabIndex = 1;
            label2.Text = "Mật khẩu";
            // 
            // roundPanel2
            // 
            roundPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            roundPanel2.BackColor = Color.Transparent;
            roundPanel2.BackgroundColor = Color.White;
            roundPanel2.BorderColor = Color.White;
            roundPanel2.BorderRadius = 20;
            roundPanel2.BorderWidth = 2F;
            roundPanel2.Controls.Add(txtPassword);
            roundPanel2.Cursor = Cursors.IBeam;
            roundPanel2.Location = new Point(43, 333);
            roundPanel2.Margin = new Padding(40, 0, 40, 0);
            roundPanel2.Name = "roundPanel2";
            roundPanel2.Size = new Size(374, 49);
            roundPanel2.TabIndex = 2;
            roundPanel2.Click += roundPanel2_Click;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.Gray;
            txtPassword.Location = new Point(17, 14);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderColor = Color.Gray;
            txtPassword.PlaceholderText = "Mật khẩu";
            txtPassword.Size = new Size(340, 22);
            txtPassword.TabIndex = 2;
            txtPassword.Text = "Mật khẩu";
            txtPassword.TextColor = Color.Black;
            txtPassword.Enter += txtPassword_Enter;
            txtPassword.KeyDown += txtPassword_KeyDown;
            txtPassword.Leave += txtPassword_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(43, 198);
            label1.Name = "label1";
            label1.Size = new Size(123, 21);
            label1.TabIndex = 1;
            label1.Text = "Tên đăng nhập";
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1130, 653);
            Controls.Add(panel1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmLogin";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            roundPanel1.ResumeLayout(false);
            roundPanel1.PerformLayout();
            roundPanel2.ResumeLayout(false);
            roundPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private Controls.PlaceholderTextBox txtUsername;
        private Label label1;
        private Controls.RoundPanel roundPanel1;
        private Label label2;
        private Controls.RoundPanel roundPanel2;
        private Controls.PlaceholderTextBox txtPassword;
        private Button btnExit;
        private Label label4;
        private Label label3;
        private Button btnLogin;
    }
}