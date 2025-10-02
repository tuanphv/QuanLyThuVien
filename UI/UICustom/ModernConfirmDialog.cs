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
            this.pnlMain = new Panel();
            this.pnlHeader = new Panel();
            this.pnlContent = new Panel();
            this.pnlButtons = new Panel();
            this.lblIcon = new Label();
            this.lblTitle = new Label();
            this.lblMessage = new Label();
            this.btnConfirm = new Button();
            this.btnCancel = new Button();

            this.SuspendLayout();

            // Form
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.ClientSize = new Size(420, 240);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
            this.TopMost = true;

            // Add drop shadow effect
            this.Region = CreateRoundedRegion(this.ClientRectangle, 12);

            // Main Panel
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.BackColor = Color.White;
            this.pnlMain.Padding = new Padding(1);
            this.pnlMain.Paint += PnlMain_Paint;

            // Header Panel
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Height = 80;
            this.pnlHeader.BackColor = Color.White;
            this.pnlHeader.MouseDown += Header_MouseDown;
            this.pnlHeader.MouseMove += Header_MouseMove;
            this.pnlHeader.MouseUp += Header_MouseUp;

            // Icon
            this.lblIcon.Text = "??";
            this.lblIcon.Font = new Font("Segoe UI Emoji", 24F);
            this.lblIcon.ForeColor = Color.FromArgb(255, 140, 0);
            this.lblIcon.AutoSize = true;
            this.lblIcon.Location = new Point(25, 20);

            // Title
            this.lblTitle.Text = "Xác nh?n";
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(51, 51, 51);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(80, 25);

            // Content Panel
            this.pnlContent.Dock = DockStyle.Fill;
            this.pnlContent.BackColor = Color.White;
            this.pnlContent.Padding = new Padding(25, 10, 25, 10);

            // Message
            this.lblMessage.Text = "B?n có ch?c mu?n th?c hi?n hành ??ng này?";
            this.lblMessage.Font = new Font("Segoe UI", 11F);
            this.lblMessage.ForeColor = Color.FromArgb(102, 102, 102);
            this.lblMessage.AutoSize = false;
            this.lblMessage.Size = new Size(360, 60);
            this.lblMessage.Location = new Point(25, 15);
            this.lblMessage.TextAlign = ContentAlignment.MiddleLeft;

            // Buttons Panel
            this.pnlButtons.Dock = DockStyle.Bottom;
            this.pnlButtons.Height = 70;
            this.pnlButtons.BackColor = Color.FromArgb(250, 250, 250);
            this.pnlButtons.Padding = new Padding(25, 15, 25, 15);

            // Confirm Button
            this.btnConfirm.Text = "Có";
            this.btnConfirm.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnConfirm.ForeColor = Color.White;
            this.btnConfirm.BackColor = Color.FromArgb(76, 175, 80);
            this.btnConfirm.FlatStyle = FlatStyle.Flat;
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.Size = new Size(100, 40);
            this.btnConfirm.Location = new Point(190, 15);
            this.btnConfirm.Cursor = Cursors.Hand;
            this.btnConfirm.Click += BtnConfirm_Click;
            this.btnConfirm.MouseEnter += BtnConfirm_MouseEnter;
            this.btnConfirm.MouseLeave += BtnConfirm_MouseLeave;

            // Cancel Button
            this.btnCancel.Text = "Không";
            this.btnCancel.Font = new Font("Segoe UI", 10F);
            this.btnCancel.ForeColor = Color.FromArgb(102, 102, 102);
            this.btnCancel.BackColor = Color.FromArgb(240, 240, 240);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Size = new Size(100, 40);
            this.btnCancel.Location = new Point(300, 15);
            this.btnCancel.Cursor = Cursors.Hand;
            this.btnCancel.Click += BtnCancel_Click;
            this.btnCancel.MouseEnter += BtnCancel_MouseEnter;
            this.btnCancel.MouseLeave += BtnCancel_MouseLeave;

            // Add controls to panels
            this.pnlHeader.Controls.Add(this.lblIcon);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlContent.Controls.Add(this.lblMessage);
            this.pnlButtons.Controls.Add(this.btnConfirm);
            this.pnlButtons.Controls.Add(this.btnCancel);

            // Add panels to main panel
            this.pnlMain.Controls.Add(this.pnlContent);
            this.pnlMain.Controls.Add(this.pnlButtons);
            this.pnlMain.Controls.Add(this.pnlHeader);

            // Add main panel to form
            this.Controls.Add(this.pnlMain);

            this.ResumeLayout(false);
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
            return Show("Xác nh?n", message);
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
            string message = $"B?n có ch?c mu?n ??ng xu?t?\n\n" +
                           $"Phiên làm vi?c: {sessionDuration.Hours:D2}:{sessionDuration.Minutes:D2}:{sessionDuration.Seconds:D2}\n" +
                           $"Tài kho?n: {userName} ({role})";
            
            using (var dialog = new ModernConfirmDialog("??ng xu?t", message, "??ng xu?t", "H?y", Color.FromArgb(244, 67, 54)))
            {
                dialog.lblIcon.Text = "??";
                dialog.lblIcon.ForeColor = Color.FromArgb(244, 67, 54);
                dialog.ShowDialog();
                return dialog.Result;
            }
        }

        public static DialogResult ShowDelete(string itemName)
        {
            string message = $"B?n có ch?c ch?n mu?n xóa {itemName}?\n\nHành ??ng này không th? hoàn tác.";
            
            using (var dialog = new ModernConfirmDialog("Xác nh?n xóa", message, "Xóa", "H?y", Color.FromArgb(244, 67, 54)))
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