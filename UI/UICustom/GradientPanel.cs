using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace UI.UICustom
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(Panel))]
    [Description("Panel có nền chuyển màu (gradient).")]
    public class GradientPanel : Panel
    {
        private Color _color1 = Color.LightSkyBlue;
        private Color _color2 = Color.MidnightBlue;
        private LinearGradientMode _gradientMode = LinearGradientMode.Vertical;

        public GradientPanel()
        {
            // Giảm nháy (flicker) và cho phép vẽ lại khi resize
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint, true);
            DoubleBuffered = true;
        }

        [Category("Appearance")]
        [Description("Màu bắt đầu của gradient.")]
        [DefaultValue(typeof(Color), "LightSkyBlue")]
        public Color Color1
        {
            get => _color1;
            set { _color1 = value; Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Màu kết thúc của gradient.")]
        [DefaultValue(typeof(Color), "MidnightBlue")]
        public Color Color2
        {
            get => _color2;
            set { _color2 = value; Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Hướng của gradient.")]
        [DefaultValue(LinearGradientMode.Vertical)]
        public LinearGradientMode GradientMode
        {
            get => _gradientMode;
            set { _gradientMode = value; Invalidate(); }
        }

        // Vẽ background bằng gradient
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Rectangle rect = this.ClientRectangle;
            if (rect.Width <= 0 || rect.Height <= 0)
            {
                base.OnPaintBackground(e);
                return;
            }

            using (LinearGradientBrush brush = new LinearGradientBrush(rect, _color1, _color2, _gradientMode))
            {
                e.Graphics.FillRectangle(brush, rect);
            }
        }
    }
}
