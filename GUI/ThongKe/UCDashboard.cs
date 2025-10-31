using GUI.ThongKe;
using System.Data;

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
            DataTable dt = new DataTable();
            dt.Columns.Add("Text", typeof(string));
            dt.Columns.Add("Value", typeof(string));

            // Thêm dòng
            dt.Rows.Add("Theo khoảng", "DateRange");
            dt.Rows.Add("Theo tháng", "Monthly");
            dt.Rows.Add("Theo quý", "Quarterly");

            cbTimeInterval.DataSource = dt;
            cbTimeInterval.DisplayMember = "Text";
            cbTimeInterval.ValueMember = "Value";
            cbTimeInterval.SelectedIndex = 1; // Mặc định chọn "Theo tháng"

            lblBorrowCount1.TextValue = "1200000 lượt";
        }

        private void LoadBarChartData(string timeInterval) // monthly, quarterly
        {
            
            if (timeInterval == "Monthly")
            {
                var monthlyData = new List<BarDataPoint>
                    {
                        new BarDataPoint("Jan", 120),
                        new BarDataPoint("Feb", 180),
                        new BarDataPoint("Mar", 95),
                        new BarDataPoint("Apr", 220),
                        new BarDataPoint("May", 150),
                        new BarDataPoint("Jun", 260),
                        new BarDataPoint("Jul", 180),
                        new BarDataPoint("Aug", 200),
                        new BarDataPoint("Sep", 140),
                        new BarDataPoint("Oct", 175),
                        new BarDataPoint("Nov", 90),
                        new BarDataPoint("Dec", 210)
                    };
                barChartControl1.Data = monthlyData;
            }
            else if (timeInterval == "Quarterly")
            {
                var quarterlyData = new List<BarDataPoint>
                {
                    new BarDataPoint("Q1", 450),
                    new BarDataPoint("Q2", 520),
                    new BarDataPoint("Q3", 380),
                    new BarDataPoint("Q4", 610)
                };
                barChartControl1.Data = quarterlyData;
            }
            barChartControl1.Invalidate();
        }

        private void cbTimeInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedInterval = cbTimeInterval.SelectedValue.ToString();
            LoadBarChartData(selectedInterval);
        }
    }
}
