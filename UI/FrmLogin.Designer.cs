namespace UI
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            label2 = new Label();
            panel1 = new Panel();
            txtPassword = new UI.UICustom.PlaceholderTextBox();
            txtUsername = new UI.UICustom.PlaceholderTextBox();
            btnTestConnection = new Button();
            btnCancel = new Button();
            btnLogin = new Button();
            label4 = new Label();
            label3 = new Label();
            lblConnectionStatus = new Label();
            gradientPanel1 = new UI.UICustom.GradientPanel();
            panel1.SuspendLayout();
            gradientPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top;
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(116, 28);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(567, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "HỆ THỐNG QUẢN LÝ THƯ VIỆN";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 14F);
            label2.ForeColor = SystemColors.Window;
            label2.Location = new Point(251, 90);
            label2.Name = "label2";
            label2.Size = new Size(295, 25);
            label2.TabIndex = 1;
            label2.Text = "Chào mừng bạn đến với hệ thống";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            panel1.BackColor = SystemColors.ButtonFace;
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(btnTestConnection);
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(204, 142);
            panel1.Name = "panel1";
            panel1.Size = new Size(370, 266);
            panel1.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.Gray;
            txtPassword.Location = new Point(46, 136);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderColor = Color.Gray;
            txtPassword.PlaceholderText = "Mật khẩu";
            txtPassword.Size = new Size(279, 35);
            txtPassword.TabIndex = 2;
            txtPassword.Text = "Mật khẩu";
            txtPassword.TextColor = Color.Black;
            txtPassword.Enter += txtPassword_Enter;
            txtPassword.Leave += txtPassword_Leave;
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.ForeColor = Color.Gray;
            txtUsername.Location = new Point(46, 52);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderColor = Color.Gray;
            txtUsername.PlaceholderText = "Tên đăng nhập";
            txtUsername.Size = new Size(279, 35);
            txtUsername.TabIndex = 1;
            txtUsername.Text = "Tên đăng nhập";
            txtUsername.TextColor = Color.Black;
            // 
            // btnTestConnection
            // 
            btnTestConnection.BackColor = Color.FromArgb(255, 128, 0);
            btnTestConnection.FlatAppearance.BorderSize = 0;
            btnTestConnection.FlatAppearance.MouseDownBackColor = Color.FromArgb(204, 116, 0);
            btnTestConnection.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 145, 0);
            btnTestConnection.FlatStyle = FlatStyle.Flat;
            btnTestConnection.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTestConnection.ForeColor = SystemColors.Window;
            btnTestConnection.Location = new Point(285, 202);
            btnTestConnection.Name = "btnTestConnection";
            btnTestConnection.Size = new Size(40, 40);
            btnTestConnection.TabIndex = 5;
            btnTestConnection.Text = "🔧";
            btnTestConnection.TextAlign = ContentAlignment.TopCenter;
            btnTestConnection.UseVisualStyleBackColor = false;
            btnTestConnection.Click += btnTestConnection_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(149, 165, 166);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatAppearance.MouseDownBackColor = Color.FromArgb(137, 152, 153);
            btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(171, 190, 191);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = SystemColors.Window;
            btnCancel.Location = new Point(189, 202);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(71, 40);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Thoát";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(52, 152, 219);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(48, 131, 204);
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 155, 242);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = SystemColors.Window;
            btnLogin.Location = new Point(46, 202);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(112, 40);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(52, 73, 94);
            label4.Location = new Point(46, 113);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 0;
            label4.Text = "Mật khẩu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(52, 73, 94);
            label3.Location = new Point(46, 29);
            label3.Name = "label3";
            label3.Size = new Size(112, 20);
            label3.TabIndex = 0;
            label3.Text = "Tên đăng nhập";
            // 
            // lblConnectionStatus
            // 
            lblConnectionStatus.Anchor = AnchorStyles.Bottom;
            lblConnectionStatus.AutoSize = true;
            lblConnectionStatus.BackColor = Color.Transparent;
            lblConnectionStatus.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblConnectionStatus.ForeColor = SystemColors.Window;
            lblConnectionStatus.Location = new Point(223, 431);
            lblConnectionStatus.Name = "lblConnectionStatus";
            lblConnectionStatus.Size = new Size(341, 20);
            lblConnectionStatus.TabIndex = 3;
            lblConnectionStatus.Text = "Đang kiểm tra trạng thái kết nối cơ sở dữ liệu ...";
            lblConnectionStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gradientPanel1
            // 
            gradientPanel1.Color1 = Color.FromArgb(52, 152, 219);
            gradientPanel1.Color2 = Color.LightSkyBlue;
            gradientPanel1.Controls.Add(lblConnectionStatus);
            gradientPanel1.Controls.Add(lblTitle);
            gradientPanel1.Controls.Add(label2);
            gradientPanel1.Location = new Point(-1, 1);
            gradientPanel1.Name = "gradientPanel1";
            gradientPanel1.Size = new Size(785, 462);
            gradientPanel1.TabIndex = 4;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(52, 152, 219);
            ClientSize = new Size(784, 461);
            Controls.Add(panel1);
            Controls.Add(gradientPanel1);
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống quản lý thư viện - Đăng nhập";
            Load += FrmLogin_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            gradientPanel1.ResumeLayout(false);
            gradientPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Label label2;
        private Panel panel1;
        private Label label3;
        private Label label4;
        private Button btnLogin;
        private Button btnCancel;
        private Label lblConnectionStatus;
        private Button btnTestConnection;
        private UICustom.GradientPanel gradientPanel1;
        private UICustom.PlaceholderTextBox txtUsername;
        private UICustom.PlaceholderTextBox txtPassword;
    }
}
