using RoundButton.Extensions;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GUI.Controls
{
    public class RoundPanel : Panel
    {
        private int _radius = 10;
        public int BorderRadius
        {
            get { return _radius; }
            set
            {
                _radius = value;
                Invalidate();
            }
        }

        private SolidBrush _backgroundBrush = new SolidBrush(SystemColors.Control);
        private Color _backgroundColor = SystemColors.Control;
        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                _backgroundBrush = new SolidBrush(_backgroundColor = value);
                Invalidate();
            }
        }

        private Color _borderColor = SystemColors.ControlDark;
        private Pen _borderPen = new Pen(SystemColors.ControlDark, 1.0f);
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                _borderPen = new Pen(_borderColor, _borderWidth);
                Invalidate();
            }
        }

        private float _borderWidth = 1.0f;
        public float BorderWidth
        {
            get { return _borderWidth; }
            set
            {
                _borderWidth = value;
                _borderPen = new Pen(_borderColor, _borderWidth);
                Invalidate();
            }
        }

        public RoundPanel()
        {
            // Bật double buffer để vẽ mượt
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            this.BackColor = Color.Transparent;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Vẽ nền trước
            drawBackground(g);

            // Vẽ viền sau
            drawBorder(g);
        }

        private void drawBorder(Graphics g)
        {
            RectangleF rect = new RectangleF(
                _borderWidth / 2,
                _borderWidth / 2,
                Width - _borderWidth,
                Height - _borderWidth
            );
            g.DrawRoundedRectangle(_borderPen, rect.X, rect.Y, rect.Width, rect.Height, _radius);
        }

        private void drawBackground(Graphics g)
        {
            RectangleF rect = new RectangleF(
                _borderWidth / 2,
                _borderWidth / 2,
                Width - _borderWidth,
                Height - _borderWidth
            );
            g.FillRoundedRectangle(_backgroundBrush, rect.X, rect.Y, rect.Width, rect.Height, _radius);
        }
    }
}