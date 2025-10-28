namespace GUI
{
    public partial class UCDashboard : UserControl
    {
        public UCDashboard()
        {
            InitializeComponent();
        }

        private void UCDashboard_Load(object sender, EventArgs e)
        {
            lblBorrowCount1.TextValue = "1200000 lượt";
        }
    }
}
