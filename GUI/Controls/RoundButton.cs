namespace RoundButton
{
    public partial class RoundButton : RoundControl
    {
        public string ButtonText { get => button1.Text; set => button1.Text = value; }
        public bool UseMouseOverBackColor { get; set; } = false;
        public Color MouseOverBackColor { get; set; }
        private Color backgroundColor;
        public RoundButton() => InitializeComponent();
        private void RoundButton_Load(object sender, EventArgs e)
        {
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.BackColor = BackgroundColor;
            backgroundColor = BackgroundColor;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            button1.Location = new Point(20, 20);
            button1.Size = new Size(Size.Width - 40, Size.Height - 40);
            button1.BackColor = BackgroundColor;
        }

        private void button1_Click(object sender, EventArgs e) => InvokeOnClick(this, e);

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            if (UseMouseOverBackColor)
                BackgroundColor = button1.BackColor = MouseOverBackColor;
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            if (UseMouseOverBackColor)
                BackgroundColor = button1.BackColor = backgroundColor;
        }

        private void RoundButton_MouseEnter(object sender, EventArgs e) => button1_MouseEnter((object)sender, e);

        private void RoundButton_MouseLeave(object sender, EventArgs e) => button1_MouseLeave((object)sender, e);

    }
}
