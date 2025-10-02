using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace UI.UICustom
{
    public partial class ModernConfirmDialog : Form
    {
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);

        public DialogResult Result { get; private set; }
        
        private Panel pnlMain;
        private Panel pnlHeader;
        private Panel pnlContent;
        private Panel pnlButtons;
        private Label lblIcon;
        private Label lblTitle;
        private Label lblMessage;
        private Button btnConfirm;
        private Button btnCancel;
        private System.Windows.Forms.Timer fadeTimer;
        private double opacity = 0.0;

        public ModernConfirmDialog(string title, string message, string confirmText = "Có", string cancelText = "Không", Color? accentColor = null)
        {
            InitializeComponent();
            
            this.lblTitle.Text = title;
            this.lblMessage.Text = message;
            this.btnConfirm.Text = confirmText;
            this.btnCancel.Text = cancelText;

            if (accentColor.HasValue)
            {
                this.btnConfirm.BackColor = accentColor.Value;
            }

            // Fade in animation
            this.Opacity = 0;
            fadeTimer = new System.Windows.Forms.Timer();
            fadeTimer.Interval = 15;
            fadeTimer.Tick += FadeTimer_Tick;
            fadeTimer.Start();
        }

        private void InitializeComponent()
        {
            pnlMain = new Panel();
            pnlContent = new Panel();
            lblMessage = new Label();
            pnlButtons = new Panel();
            btnConfirm = new Button();
            btnCancel = new Button();
            pnlHeader = new Panel();
            lblIcon = new Label();
            lblTitle = new Label();
            pnlMain.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlButtons.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.White;
            pnlMain.Controls.Add(pnlContent);
            pnlMain.Controls.Add(pnlButtons);
            pnlMain.Controls.Add(pnlHeader);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(1);
            pnlMain.Size = new Size(420, 240);
            pnlMain.TabIndex = 0;
            pnlMain.Paint += PnlMain_Paint;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.White;
            pnlContent.Controls.Add(lblMessage);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(1, 81);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(25, 10, 25, 10);
            pnlContent.Size = new Size(418, 88);
            pnlContent.TabIndex = 0;
            // 
            // lblMessage
            // 
            lblMessage.Font = new Font("Segoe UI", 11F);
            lblMessage.ForeColor = Color.FromArgb(102, 102, 102);
            lblMessage.Location = new Point(25, 15);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(360, 60);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "Bạn có chắc muốn thực hiện hành động này";
            lblMessage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlButtons
            // 
            pnlButtons.BackColor = Color.FromArgb(250, 250, 250);
            pnlButtons.Controls.Add(btnConfirm);
            pnlButtons.Controls.Add(btnCancel);
            pnlButtons.Dock = DockStyle.Bottom;
            pnlButtons.Location = new Point(1, 169);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Padding = new Padding(25, 15, 25, 15);
            pnlButtons.Size = new Size(418, 70);
            pnlButtons.TabIndex = 1;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.FromArgb(76, 175, 80);
            btnConfirm.Cursor = Cursors.Hand;
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.Location = new Point(190, 15);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(100, 40);
            btnConfirm.TabIndex = 0;
            btnConfirm.Text = "Có";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += BtnConfirm_Click;
            btnConfirm.MouseEnter += BtnConfirm_MouseEnter;
            btnConfirm.MouseLeave += BtnConfirm_MouseLeave;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(240, 240, 240);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.ForeColor = Color.FromArgb(102, 102, 102);
            btnCancel.Location = new Point(300, 15);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 40);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Không";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            btnCancel.MouseEnter += BtnCancel_MouseEnter;
            btnCancel.MouseLeave += BtnCancel_MouseLeave;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblIcon);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(1, 1);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(418, 80);
            pnlHeader.TabIndex = 2;
            pnlHeader.MouseDown += Header_MouseDown;
            pnlHeader.MouseMove += Header_MouseMove;
            pnlHeader.MouseUp += Header_MouseUp;
            // 
            // lblIcon
            // 
            lblIcon.AutoSize = true;
            lblIcon.Font = new Font("Segoe UI Emoji", 24F);
            lblIcon.ForeColor = Color.FromArgb(255, 140, 0);
            lblIcon.Location = new Point(25, 20);
            lblIcon.Name = "lblIcon";
            lblIcon.Size = new Size(47, 43);
            lblIcon.TabIndex = 0;
            lblIcon.Text = "??";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(51, 51, 51);
            lblTitle.Location = new Point(80, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(107, 30);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Xác nhận";
            // 
            // ModernConfirmDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 240);
            ClientSize = new Size(420, 240);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ModernConfirmDialog";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;
            pnlMain.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlButtons.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            opacity += 0.05;
            if (opacity >= 1.0)
            {
                opacity = 1.0;
                fadeTimer.Stop();
                fadeTimer.Dispose();
            }
            this.Opacity = opacity;
        }

        private void PnlMain_Paint(object sender, PaintEventArgs e)
        {
            // Draw subtle border
            using (var pen = new Pen(Color.FromArgb(220, 220, 220), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }

            // Draw separator line between content and buttons
            using (var pen = new Pen(Color.FromArgb(230, 230, 230), 1))
            {
                int y = this.Height - this.pnlButtons.Height;
                e.Graphics.DrawLine(pen, 0, y, this.Width, y);
            }
        }

        private Region CreateRoundedRegion(Rectangle bounds, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, radius * 2, radius * 2, 180, 90);
            path.AddArc(bounds.Right - radius * 2, bounds.Y, radius * 2, radius * 2, 270, 90);
            path.AddArc(bounds.Right - radius * 2, bounds.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseAllFigures();
            return new Region(path);
        }

        // Dragging functionality
        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }

        private void Header_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void Header_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        // Button hover effects
        private void BtnConfirm_MouseEnter(object sender, EventArgs e)
        {
            btnConfirm.BackColor = Color.FromArgb(67, 160, 71);
        }

        private void BtnConfirm_MouseLeave(object sender, EventArgs e)
        {
            btnConfirm.BackColor = Color.FromArgb(76, 175, 80);
        }

        private void BtnCancel_MouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.FromArgb(220, 220, 220);
        }

        private void BtnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.FromArgb(240, 240, 240);
        }

        // Button click events
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            Result = DialogResult.Yes;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Result = DialogResult.No;
            this.Close();
        }

        // Static helper methods
        public static DialogResult Show(string message)
        {
            return Show("Xác nhận", message);
        }

        public static DialogResult Show(string title, string message)
        {
            return Show(title, message, "Có", "Không");
        }

        public static DialogResult Show(string title, string message, string confirmText, string cancelText)
        {
            using (var dialog = new ModernConfirmDialog(title, message, confirmText, cancelText))
            {
                dialog.ShowDialog();
                return dialog.Result;
            }
        }

        public static DialogResult ShowLogout(string userName, string role, TimeSpan sessionDuration)
        {
            string message = $"Bạn có chắc muốn đăng xuất?\n\n" +
                           $"Phiên làm việc: {sessionDuration.Hours:D2}:{sessionDuration.Minutes:D2}:{sessionDuration.Seconds:D2}\n" +
                           $"Tài khoản: {userName} ({role})";
            
            using (var dialog = new ModernConfirmDialog("Đăng xuất", message, "Đăng xuất", "Hủy", Color.FromArgb(244, 67, 54)))
            {
                dialog.lblIcon.Text = "??";
                dialog.lblIcon.ForeColor = Color.FromArgb(244, 67, 54);
                dialog.ShowDialog();
                return dialog.Result;
            }
        }

        public static DialogResult ShowDelete(string itemName)
        {
            string message = $"Bạn có chắc chắn muốn xóa {itemName}?\n\nHành động này không thể hoàn tác.";
            
            using (var dialog = new ModernConfirmDialog("Xác nhận xóa", message, "Xóa", "Hủy", Color.FromArgb(244, 67, 54)))
            {
                dialog.lblIcon.Text = "???";
                dialog.lblIcon.ForeColor = Color.FromArgb(244, 67, 54);
                dialog.ShowDialog();
                return dialog.Result;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Result = DialogResult.No;
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                Result = DialogResult.Yes;
                this.Close();
            }
            base.OnKeyDown(e);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
    }
}