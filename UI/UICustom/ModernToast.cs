using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace UI.UICustom
{
    public partial class ModernToast : Form
    {
        private System.Windows.Forms.Timer animationTimer;
        private System.Windows.Forms.Timer displayTimer;
        private int targetX;
        private int startX;
        private bool isClosing = false;

        public enum ToastType
        {
            Success,
            Info,
            Warning,
            Error
        }

        private Label lblIcon;
        private Label lblMessage;
        private Panel pnlMain;
        private Button btnClose;

        public ModernToast(string message, ToastType type = ToastType.Info, int duration = 3000)
        {
            InitializeComponent();
            SetupToast(message, type);
            
            // Position at bottom right of screen
            PositionToast();
            
            // Start slide-in animation
            StartSlideInAnimation();
            
            // Auto close after duration
            displayTimer = new System.Windows.Forms.Timer();
            displayTimer.Interval = duration;
            displayTimer.Tick += (s, e) => { displayTimer.Stop(); StartSlideOutAnimation(); };
            displayTimer.Start();
        }

        private void InitializeComponent()
        {
            this.pnlMain = new Panel();
            this.lblIcon = new Label();
            this.lblMessage = new Label();
            this.btnClose = new Button();

            this.SuspendLayout();

            // Form
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Magenta; // Will be made transparent
            this.TransparencyKey = Color.Magenta;
            this.ClientSize = new Size(350, 80);
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.StartPosition = FormStartPosition.Manual;

            // Main Panel
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.BackColor = Color.White;
            this.pnlMain.Padding = new Padding(15);
            this.pnlMain.Paint += PnlMain_Paint;

            // Icon
            this.lblIcon.Text = "??";
            this.lblIcon.Font = new Font("Segoe UI Emoji", 16F);
            this.lblIcon.AutoSize = true;
            this.lblIcon.Location = new Point(15, 25);

            // Message
            this.lblMessage.Text = "Toast message";
            this.lblMessage.Font = new Font("Segoe UI", 10F);
            this.lblMessage.ForeColor = Color.FromArgb(51, 51, 51);
            this.lblMessage.AutoSize = false;
            this.lblMessage.Size = new Size(270, 50);
            this.lblMessage.Location = new Point(50, 15);
            this.lblMessage.TextAlign = ContentAlignment.MiddleLeft;

            // Close Button
            this.btnClose.Text = "?";
            this.btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnClose.ForeColor = Color.FromArgb(128, 128, 128);
            this.btnClose.BackColor = Color.Transparent;
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Size = new Size(25, 25);
            this.btnClose.Location = new Point(315, 10);
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.Click += BtnClose_Click;
            this.btnClose.MouseEnter += (s, e) => btnClose.ForeColor = Color.FromArgb(244, 67, 54);
            this.btnClose.MouseLeave += (s, e) => btnClose.ForeColor = Color.FromArgb(128, 128, 128);

            // Add controls
            this.pnlMain.Controls.Add(this.lblIcon);
            this.pnlMain.Controls.Add(this.lblMessage);
            this.pnlMain.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlMain);

            // Handle Load event to set up the rounded region
            this.Load += ModernToast_Load;

            this.ResumeLayout(false);
        }

        private void ModernToast_Load(object sender, EventArgs e)
        {
            // Create rounded region after the form is loaded
            this.Region = CreateRoundedRegion(new Rectangle(0, 0, this.Width, this.Height), 8);
        }

        private void SetupToast(string message, ToastType type)
        {
            lblMessage.Text = message;

            switch (type)
            {
                case ToastType.Success:
                    lblIcon.Text = "?";
                    pnlMain.BackColor = Color.FromArgb(232, 245, 233);
                    lblMessage.ForeColor = Color.FromArgb(27, 94, 32);
                    break;
                case ToastType.Info:
                    lblIcon.Text = "??";
                    pnlMain.BackColor = Color.FromArgb(227, 242, 253);
                    lblMessage.ForeColor = Color.FromArgb(13, 71, 161);
                    break;
                case ToastType.Warning:
                    lblIcon.Text = "??";
                    pnlMain.BackColor = Color.FromArgb(255, 248, 225);
                    lblMessage.ForeColor = Color.FromArgb(230, 81, 0);
                    break;
                case ToastType.Error:
                    lblIcon.Text = "?";
                    pnlMain.BackColor = Color.FromArgb(255, 235, 238);
                    lblMessage.ForeColor = Color.FromArgb(198, 40, 40);
                    break;
            }
        }

        private void PositionToast()
        {
            Screen screen = Screen.PrimaryScreen;
            Rectangle workingArea = screen.WorkingArea;
            
            startX = workingArea.Right;
            targetX = workingArea.Right - this.Width - 20;
            
            this.Location = new Point(startX, workingArea.Bottom - this.Height - 20);
        }

        private void StartSlideInAnimation()
        {
            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 15;
            animationTimer.Tick += SlideInAnimation_Tick;
            animationTimer.Start();
        }

        private void SlideInAnimation_Tick(object sender, EventArgs e)
        {
            if (this.Left > targetX)
            {
                this.Left -= 8;
            }
            else
            {
                this.Left = targetX;
                animationTimer.Stop();
                animationTimer.Dispose();
            }
        }

        private void StartSlideOutAnimation()
        {
            if (isClosing) return;
            isClosing = true;

            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 15;
            animationTimer.Tick += SlideOutAnimation_Tick;
            animationTimer.Start();
        }

        private void SlideOutAnimation_Tick(object sender, EventArgs e)
        {
            if (this.Left < startX)
            {
                this.Left += 8;
            }
            else
            {
                animationTimer.Stop();
                animationTimer.Dispose();
                this.Close();
            }
        }

        private void PnlMain_Paint(object sender, PaintEventArgs e)
        {
            // Draw subtle shadow/border
            using (var pen = new Pen(Color.FromArgb(220, 220, 220), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            displayTimer?.Stop();
            StartSlideOutAnimation();
        }

        // Static helper methods
        public static void Show(string message)
        {
            var toast = new ModernToast(message, ToastType.Info);
            toast.Show();
        }

        public static void ShowSuccess(string message)
        {
            var toast = new ModernToast(message, ToastType.Success);
            toast.Show();
        }

        public static void ShowInfo(string message)
        {
            var toast = new ModernToast(message, ToastType.Info);
            toast.Show();
        }

        public static void ShowWarning(string message)
        {
            var toast = new ModernToast(message, ToastType.Warning);
            toast.Show();
        }

        public static void ShowError(string message)
        {
            var toast = new ModernToast(message, ToastType.Error);
            toast.Show();
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(true);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x08000000; // WS_EX_NOACTIVATE
                return cp;
            }
        }
    }
}