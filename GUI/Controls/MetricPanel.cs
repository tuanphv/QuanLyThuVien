using System.Drawing.Drawing2D;

namespace GUI.Controls
{

    public class MetricPanel : RoundPanel
    {
        private Label lblText;

        public MetricPanel()
        {
            lblText = new Label
            {
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.SteelBlue,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Margin = new Padding(0)
            };
            Controls.Add(lblText);
            this.FontChanged += (s, e) => lblText.Font = this.Font;
            this.ForeColorChanged += (s, e) => lblText.ForeColor = this.ForeColor;
            this.BackColor = Color.LightBlue;
            this.Padding = new Padding(10, 5, 10, 5);
            this.AutoSize = true; // Để panel tự co theo label
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        public string TextValue
        {
            get => lblText.Text;
            set
            {
                lblText.Text = value;
                ResizeToFit();
            }
        }

        private void ResizeToFit()
        {
            // Đảm bảo panel luôn đủ chỗ cho label + padding
            Size textSize = TextRenderer.MeasureText(lblText.Text, lblText.Font);
            this.Width = textSize.Width + this.Padding.Horizontal;
            this.Height = textSize.Height + this.Padding.Vertical;

            // Căn giữa label trong panel
            lblText.Location = new Point(
                (this.Width - lblText.Width) / 2,
                (this.Height - lblText.Height) / 2
            );

            this.Invalidate(); // Vẽ lại bo góc nếu có
        }
    }
}