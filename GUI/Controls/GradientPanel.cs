using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace GUI.Controls
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(Panel))]
    [Description("Panel có nền chuyển màu (gradient) hỗ trợ nhiều màu và hướng.")]
    public class GradientPanel : Panel
    {
        private Color[] _colors = new Color[] { Color.LightSkyBlue, Color.MidnightBlue };
        private LinearGradientMode _gradientMode = LinearGradientMode.Vertical;
        private bool _useCustomBlend = false;

        public GradientPanel()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint, true);
            DoubleBuffered = true;
        }

        [Category("Appearance")]
        [Description("Danh sách các màu gradient. Tối thiểu 2 màu.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Color[] GradientColors
        {
            get => _colors;
            set
            {
                if (value == null || value.Length < 2)
                    throw new ArgumentException("Phải có ít nhất 2 màu trong gradient.");
                _colors = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Hướng của gradient.")]
        [DefaultValue(LinearGradientMode.Vertical)]
        public LinearGradientMode GradientMode
        {
            get => _gradientMode;
            set { _gradientMode = value; Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Bật chế độ hòa trộn nhiều màu (Blend) thay vì LinearGradient thông thường.")]
        [DefaultValue(false)]
        public bool UseCustomBlend
        {
            get => _useCustomBlend;
            set { _useCustomBlend = value; Invalidate(); }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Rectangle rect = ClientRectangle;
            if (rect.Width <= 0 || rect.Height <= 0)
            {
                base.OnPaintBackground(e);
                return;
            }

            if (_colors == null || _colors.Length < 2)
            {
                base.OnPaintBackground(e);
                return;
            }

            using (LinearGradientBrush brush = new LinearGradientBrush(rect, _colors.First(), _colors.Last(), _gradientMode))
            {
                if (_useCustomBlend && _colors.Length > 2)
                {
                    // Tính toán Blend dựa trên số lượng màu
                    int count = _colors.Length;
                    float[] positions = Enumerable.Range(0, count)
                        .Select(i => (float)i / (count - 1))
                        .ToArray();

                    ColorBlend blend = new ColorBlend
                    {
                        Colors = _colors,
                        Positions = positions
                    };
                    brush.InterpolationColors = blend;
                }

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillRectangle(brush, rect);
            }
        }
    }
}
