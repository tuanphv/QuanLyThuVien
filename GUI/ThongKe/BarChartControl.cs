using DotNetEnv;
using System.ComponentModel;

namespace GUI.ThongKe
{
    public class BarDataPoint
    {
        public string Label { get; set; }
        public double Value { get; set; }

        public BarDataPoint() { }
        public BarDataPoint(string label, double value)
        {
            Label = label;
            Value = value;
        }
    }

    public class BarChartControl : UserControl
    {
        private List<BarDataPoint> _data = new List<BarDataPoint>();
        private ToolTip _tooltip;
        private int _hoverIndex = -1;

        public BarChartControl()
        {
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 9f);
            BackColor = Color.White;
            _tooltip = new ToolTip();
            _tooltip.AutomaticDelay = 200;
            _tooltip.IsBalloon = false;
            Resize += (s, e) => Invalidate();
            MouseMove += BarChartControl_MouseMove;
            MouseLeave += (s, e) => { _hoverIndex = -1; Invalidate(); _tooltip.Hide(this); };
        }

        private void BarChartControl_MouseMove(object sender, MouseEventArgs e)
        {
            int idx = HitTestBarIndex(e.Location);
            if (idx != _hoverIndex)
            {
                _hoverIndex = idx;
                Invalidate();
                if (_hoverIndex >= 0 && _hoverIndex < _data.Count)
                {
                    var dp = _data[_hoverIndex];
                    _tooltip.Show($"{dp.Label}: {dp.Value}", this, e.Location.X + 10, e.Location.Y + 10, 1500);
                }
                else _tooltip.Hide(this);
            }
        }

        private int HitTestBarIndex(Point p)
        {
            if (_data == null || _data.Count == 0) return -1;
            var layout = CalculateLayout();
            for (int i = 0; i < layout.BarRects.Count; i++)
            {
                if (layout.BarRects[i].Contains(p)) return i;
            }
            return -1;
        }

        #region Properties

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<BarDataPoint> Data
        {
            get => _data;
            set { _data = value ?? new List<BarDataPoint>(); Invalidate(); }
        }

        private Color _barColor = Color.FromArgb(72, 133, 237);
        [DefaultValue(typeof(Color), "72,133,237")]
        public Color BarColor { get => _barColor; set { _barColor = value; Invalidate(); } }

        private Color _barBorderColor = Color.FromArgb(50, 90, 170);
        [DefaultValue(typeof(Color), "50,90,170")]
        public Color BarBorderColor { get => _barBorderColor; set { _barBorderColor = value; Invalidate(); } }

        private Color _axisColor = Color.FromArgb(120, 120, 120);
        [DefaultValue(typeof(Color), "120,120,120")]
        public Color AxisColor { get => _axisColor; set { _axisColor = value; Invalidate(); } }

        private bool _showValues = true;
        [DefaultValue(true)]
        public bool ShowValues { get => _showValues; set { _showValues = value; Invalidate(); } }

        private Padding _chartPadding = new Padding(20, 20, 20, 40);
        [DefaultValue(typeof(Padding), "20,20,20,40")]
        public Padding ChartPadding { get => _chartPadding; set { _chartPadding = value; Invalidate(); } }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.Clear(BackColor);
            if (_data == null || _data.Count == 0)
            {
                // draw placeholder text
                var txt = "No data";
                var sz = e.Graphics.MeasureString(txt, Font);
                e.Graphics.DrawString(txt, Font, new SolidBrush(AxisColor),
                    (Width - sz.Width) / 2, (Height - sz.Height) / 2);
                return;
            }

            var layout = CalculateLayout();
            DrawYLabels(e.Graphics, layout);
            DrawAxes(e.Graphics, layout);
            DrawBars(e.Graphics, layout);
            DrawXLabels(e.Graphics, layout);
        }

        private void DrawAxes(Graphics g, ChartLayout layout)
        {
            using (var pen = new Pen(AxisColor, 1f))
            {
                // x-axis
                g.DrawLine(pen, layout.ChartArea.Left, layout.ChartArea.Bottom, layout.ChartArea.Right, layout.ChartArea.Bottom);
                // y-axis
                g.DrawLine(pen, layout.ChartArea.Left, layout.ChartArea.Top, layout.ChartArea.Left, layout.ChartArea.Bottom);
            }
        }

        private void DrawBars(Graphics g, ChartLayout layout)
        {
            for (int i = 0; i < _data.Count; i++)
            {
                var r = layout.BarRects[i];
                var dp = _data[i];

                var fillRect = new Rectangle(r.X, r.Y, r.Width, r.Height);
                using (var brush = new SolidBrush(BarColor))
                {
                    g.FillRectangle(brush, fillRect);
                }
                using (var pen = new Pen(BarBorderColor, 1f))
                {
                    g.DrawRectangle(pen, r);
                }

                // highlight on hover
                if (i == _hoverIndex)
                {
                    using (var h = new SolidBrush(Color.FromArgb(60, Color.Black)))
                    {
                        g.FillRectangle(h, r);
                    }
                }

                // draw value on top of bar
                if (ShowValues)
                {
                    var valText = dp.Value.ToString("G");
                    var sz = g.MeasureString(valText, Font);
                    float tx = r.X + (r.Width - sz.Width) / 2f;
                    float ty = Math.Max(r.Y - sz.Height - 2, layout.ChartArea.Top);
                    g.DrawString(valText, Font, Brushes.Black, tx, ty);
                }
            }
        }

        private void DrawXLabels(Graphics g, ChartLayout layout)
        {
            for (int i = 0; i < _data.Count; i++)
            {
                var lbl = _data[i].Label ?? "";
                var r = layout.BarRects[i];
                var sz = g.MeasureString(lbl, Font);
                float tx = r.X + (r.Width - sz.Width) / 2f;
                float ty = layout.ChartArea.Bottom + 4;
                g.DrawString(lbl, Font, new SolidBrush(AxisColor), tx, ty);
            }
        }
        private void DrawYLabels(Graphics g, ChartLayout layout)
        {
            int tickCount = 5; // số tick mong muốn
            double min = layout.MinValue;
            double max = layout.MaxValue; // đã là niceMax từ CalculateLayout
            double step = (max - min) / tickCount;

            using (var pen = new Pen(AxisColor, 1f))
            using (var brush = new SolidBrush(AxisColor))
            {
                for (int i = 0; i <= tickCount; i++)
                {
                    double value = min + i * step;

                    // Tính vị trí y trên chart
                    float y = (float)(layout.ChartArea.Bottom - (value - min) / (max - min) * layout.ChartArea.Height);

                    // Vẽ tick nhỏ
                    g.DrawLine(pen, layout.ChartArea.Left - 5, y, layout.ChartArea.Left, y);

                    // Vẽ nhãn
                    string label = value.ToString("G"); // bạn có thể dùng "0" hoặc "0.0"
                    var sz = g.MeasureString(label, Font);
                    g.DrawString(label, Font, brush, layout.ChartArea.Left - 8 - sz.Width, y - sz.Height / 2f);
                }
            }
        }

        private ChartLayout CalculateLayout()
        {
            Graphics g = CreateGraphics();
            var maxLength = _data.Max(dp => g.MeasureString(dp.Value.ToString(), Font).Width);
            var marginLeft = ChartPadding.Left + (int)maxLength;
            var marginTop = ChartPadding.Top;
            var marginRight = ChartPadding.Right;
            var marginBottom = ChartPadding.Bottom;

            var chartArea = new Rectangle(
                marginLeft,
                marginTop,
                Math.Max(10, Width - marginLeft - marginRight),
                Math.Max(10, Height - marginTop - marginBottom)
            );

            double maxValue = _data.Max(d => d.Value);
            double minValue = 0;
            if (maxValue == minValue)
            {
                // avoid div by zero
                if (maxValue == 0) maxValue = 1;
                else minValue = 0;
            }
            // ensure top padding value (nicely rounded)
            double niceMax = NiceNumber(maxValue);

            var barCount = _data.Count;
            int gap = Math.Max(8, chartArea.Width / Math.Max(10, 5 * barCount)); // adapt gap
            int totalGap = gap * (barCount + 1);
            int barWidth = Math.Max(6, (chartArea.Width - totalGap) / Math.Max(1, barCount));
            var barRects = new List<Rectangle>();

            for (int i = 0; i < barCount; i++)
            {
                int x = chartArea.Left + gap + i * (barWidth + gap);
                double normalized = (_data[i].Value - minValue) / (niceMax - minValue);
                int barHeight = (int)Math.Round(normalized * (chartArea.Height - 20)); // leave for labels
                int y = chartArea.Bottom - barHeight;
                var r = new Rectangle(x, y, barWidth, barHeight);
                barRects.Add(r);
            }

            return new ChartLayout
            {
                ChartArea = chartArea,
                BarRects = barRects,
                MaxValue = niceMax,
                MinValue = minValue
            };
        }

        // make a "nice" round top value (e.g., 123 -> 150)
        private double NiceNumber(double value)
        {
            if (value <= 0) return 1;
            double magnitude = Math.Pow(10, Math.Floor(Math.Log10(value)));
            return Math.Ceiling(value / magnitude) * magnitude;
        }

        private class ChartLayout
        {
            public Rectangle ChartArea { get; set; }
            public List<Rectangle> BarRects { get; set; } = new List<Rectangle>();
            public double MaxValue { get; set; }
            public double MinValue { get; set; }
        }
    }
}
