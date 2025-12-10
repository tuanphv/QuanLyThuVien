using DTO;
using GUI.ThongKe;
using System.Data;
using System.Diagnostics;

namespace GUI.ThongKe
{
    public partial class UCDashboard : UserControl
    {
        public UCDashboard()
        {
            InitializeComponent();            
        }

        private void UCDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                //// Thiết lập ComboBox khoảng thời gian
                //DataTable dt = new DataTable();
                //dt.Columns.Add("Text", typeof(string));
                //dt.Columns.Add("Value", typeof(string));

                //dt.Rows.Add("Theo khoảng", "DateRange");
                //dt.Rows.Add("Theo tháng", "Monthly");
                //dt.Rows.Add("Theo quý", "Quarterly");

                //cbTimeInterval.DataSource = dt;
                //cbTimeInterval.DisplayMember = "Text";
                //cbTimeInterval.ValueMember = "Value";
                //cbTimeInterval.SelectedIndex = 1; // Mặc định chọn "Theo tháng"

                //// Ẩn panel lọc theo khoảng thời gian
                //panel10.Visible = false;

                //// Gán sự kiện cho nút lọc
                //button5.Click += button5_Click;

                // Load dữ liệu thống kê
                LoadThongKeTongQuan();
                //LoadTop5SachMuonNhieu();
                //LoadTop3DocGiaTichCuc();
                //LoadBarChartData("Monthly");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo dashboard: {ex.Message}\n\nChi tiết: {ex.StackTrace}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadThongKeTongQuan()
        {
            try
            {
                var thongKe = BUS.ThongKeBUS.GetThongKeTongQuan();

                lblTotalBooks.Text = thongKe.TongSach.ToString("N0");
                lblTotalBooksBorrow.Text = thongKe.SachDangMuon.ToString("N0");
                lblTotalReaders.Text = thongKe.TongDocGia.ToString("N0");
                lblTotalDebt.Text = thongKe.TongNo.ToString("N0") + " đ";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thống kê tổng quan: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // Set giá trị mặc định
                lblTotalBooks.Text = "0";
                lblTotalBooksBorrow.Text = "0";
                lblTotalReaders.Text = "0";
                lblTotalDebt.Text = "0 đ";
            }
        }

        //private void LoadTop5SachMuonNhieu()
        //{
        //    try
        //    {
        //        Debug.WriteLine("=== Bắt đầu LoadTop5SachMuonNhieu ===");
                
        //        var list = BUS.ThongKeBUS.GetTop5SachMuonNhieu();
        //        Debug.WriteLine($"Lấy được {list?.Count ?? 0} sách");

        //        // Nếu không có dữ liệu, không làm gì (giữ nguyên panel mẫu)
        //        if (list == null || list.Count == 0)
        //        {
        //            Debug.WriteLine("Không có dữ liệu, giữ nguyên panel mẫu");
        //            return;
        //        }

        //        // Danh sách các panel cần cập nhật
        //        var panelMappings = new Dictionary<int, (Panel panel, string labelName, string metricName)>
        //        {
        //            { 0, (panel4, "lblBookBorrow1", "lblBorrowCount1") },
        //            { 1, (panel5, "label7", "metricPanel1") },
        //            { 2, (panel7, "label9", "metricPanel3") },
        //            { 3, (panel8, "label10", "metricPanel4") },
        //            { 4, (panel6, "label8", "metricPanel2") }
        //        };

        //        for (int i = 0; i < Math.Min(5, list.Count); i++)
        //        {
        //            if (!panelMappings.ContainsKey(i)) continue;

        //            var item = list[i];
        //            var (panel, labelName, metricName) = panelMappings[i];

        //            if (panel == null)
        //            {
        //                Debug.WriteLine($"Panel {i} là null");
        //                continue;
        //            }

        //            Debug.WriteLine($"Đang xử lý sách thứ {i}: {item.TenSach}");

        //            // Cập nhật label tên sách
        //            UpdateLabelInPanel(panel, labelName, item.TenSach ?? "N/A");

        //            // Cập nhật metric panel
        //            UpdateMetricPanelInPanel(panel, metricName, $"{item.SoLuotMuon} lượt");
        //        }

        //        Debug.WriteLine("=== Hoàn thành LoadTop5SachMuonNhieu ===");
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine($"Exception trong LoadTop5SachMuonNhieu: {ex.Message}");
        //        Debug.WriteLine($"StackTrace: {ex.StackTrace}");
        //        MessageBox.Show($"Lỗi khi tải top sách mượn nhiều:\n{ex.Message}\n\nChi tiết: {ex.StackTrace}", 
        //            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void LoadTop3DocGiaTichCuc()
        //{
        //    try
        //    {
        //        Debug.WriteLine("=== Bắt đầu LoadTop3DocGiaTichCuc ===");
                
        //        var list = BUS.ThongKeBUS.GetTop3DocGiaTichCuc();
        //        Debug.WriteLine($"Lấy được {list?.Count ?? 0} độc giả");

        //        // Nếu không có dữ liệu, không làm gì (giữ nguyên panel mẫu)
        //        if (list == null || list.Count == 0)
        //        {
        //            Debug.WriteLine("Không có dữ liệu, giữ nguyên panel mẫu");
        //            return;
        //        }

        //        // Danh sách các panel cần cập nhật
        //        var panelMappings = new Dictionary<int, (Panel panel, string labelName, string metricName)>
        //        {
        //            { 0, (panel11, "label14", "metricPanel7") },
        //            { 1, (panel13, "label16", "metricPanel9") },
        //            { 2, (panel12, "label15", "metricPanel8") }
        //        };

        //        for (int i = 0; i < Math.Min(3, list.Count); i++)
        //        {
        //            if (!panelMappings.ContainsKey(i)) continue;

        //            var item = list[i];
        //            var (panel, labelName, metricName) = panelMappings[i];

        //            if (panel == null)
        //            {
        //                Debug.WriteLine($"Panel {i} là null");
        //                continue;
        //            }

        //            Debug.WriteLine($"Đang xử lý độc giả thứ {i}: {item.HoTen}");

        //            // Cập nhật label tên độc giả
        //            UpdateLabelInPanel(panel, labelName, item.HoTen ?? "N/A");

        //            // Cập nhật metric panel
        //            UpdateMetricPanelInPanel(panel, metricName, $"{item.SoLuotMuon} mượn");
        //        }

        //        Debug.WriteLine("=== Hoàn thành LoadTop3DocGiaTichCuc ===");
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine($"Exception trong LoadTop3DocGiaTichCuc: {ex.Message}");
        //        Debug.WriteLine($"StackTrace: {ex.StackTrace}");
        //        MessageBox.Show($"Lỗi khi tải top độc giả tích cực:\n{ex.Message}\n\nChi tiết: {ex.StackTrace}", 
        //            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void UpdateLabelInPanel(Panel panel, string labelName, string text)
        //{
        //    try
        //    {
        //        // Tìm label theo tên
        //        var label = panel.Controls.Find(labelName, false).FirstOrDefault() as Label;
                
        //        if (label != null)
        //        {
        //            label.Text = text;
        //            Debug.WriteLine($"Đã cập nhật {labelName} = {text}");
        //        }
        //        else
        //        {
        //            Debug.WriteLine($"Không tìm thấy label: {labelName}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine($"Lỗi UpdateLabelInPanel({labelName}): {ex.Message}");
        //    }
        //}

        //private void UpdateMetricPanelInPanel(Panel panel, string metricName, string text)
        //{
        //    try
        //    {
        //        // Tìm metric panel theo tên
        //        var metric = panel.Controls.Find(metricName, false).FirstOrDefault() as GUI.Controls.MetricPanel;
                
        //        if (metric != null)
        //        {
        //            metric.TextValue = text;
        //            Debug.WriteLine($"Đã cập nhật {metricName} = {text}");
        //        }
        //        else
        //        {
        //            Debug.WriteLine($"Không tìm thấy metric panel: {metricName}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine($"Lỗi UpdateMetricPanelInPanel({metricName}): {ex.Message}");
        //    }
        //}

        //private void LoadBarChartData(string timeInterval)
        //{
        //    try
        //    {
        //        if (timeInterval == "Monthly")
        //        {
        //            var monthlyStats = BUS.ThongKeBUS.GetThongKeTheoThang();
                    
        //            if (monthlyStats == null || monthlyStats.Count == 0)
        //            {
        //                // Tạo dữ liệu mặc định nếu không có
        //                monthlyStats = new List<ThongKeMuonTheoThangDTO>();
        //                for (int i = 1; i <= 12; i++)
        //                {
        //                    monthlyStats.Add(new ThongKeMuonTheoThangDTO(i, 0));
        //                }
        //            }

        //            var monthlyData = new List<BarDataPoint>();
        //            string[] monthNames = { "T1", "T2", "T3", "T4", "T5", "T6", 
        //                                  "T7", "T8", "T9", "T10", "T11", "T12" };

        //            for (int i = 0; i < monthlyStats.Count; i++)
        //            {
        //                monthlyData.Add(new BarDataPoint(
        //                    monthNames[i],
        //                    monthlyStats[i].SoLuotMuon
        //                ));
        //            }

        //            barChartControl1.Data = monthlyData;
        //        }
        //        else if (timeInterval == "Quarterly")
        //        {
        //            var quarterlyStats = BUS.ThongKeBUS.GetThongKeTheoQuy();
                    
        //            if (quarterlyStats == null || quarterlyStats.Count == 0)
        //            {
        //                // Tạo dữ liệu mặc định nếu không có
        //                quarterlyStats = new List<ThongKeMuonTheoQuyDTO>();
        //                for (int i = 1; i <= 4; i++)
        //                {
        //                    quarterlyStats.Add(new ThongKeMuonTheoQuyDTO(i, 0));
        //                }
        //            }

        //            var quarterlyData = new List<BarDataPoint>();

        //            for (int i = 0; i < quarterlyStats.Count; i++)
        //            {
        //                quarterlyData.Add(new BarDataPoint(
        //                    $"Q{quarterlyStats[i].Quy}",
        //                    quarterlyStats[i].SoLuotMuon
        //                ));
        //            }

        //            barChartControl1.Data = quarterlyData;
        //        }
        //        else if (timeInterval == "DateRange")
        //        {
        //            // Xử lý khi người dùng chọn khoảng thời gian
        //            DateTime fromDate = dateTimePicker2.Value.Date;
        //            DateTime toDate = dateTimePicker1.Value.Date;

        //            if (fromDate > toDate)
        //            {
        //                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc.", "Thông báo",
        //                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                return;
        //            }

        //            int totalBorrows = BUS.ThongKeBUS.GetThongKeTheoKhoang(fromDate, toDate);
                    
        //            var dateRangeData = new List<BarDataPoint>
        //            {
        //                new BarDataPoint($"{fromDate:dd/MM} - {toDate:dd/MM}", totalBorrows)
        //            };

        //            barChartControl1.Data = dateRangeData;
        //        }

        //        barChartControl1.Invalidate();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Lỗi khi tải biểu đồ: {ex.Message}\n\nChi tiết: {ex.InnerException?.Message}", 
        //            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void cbTimeInterval_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (cbTimeInterval.SelectedValue == null)
        //            return;

        //        string selectedInterval = cbTimeInterval.SelectedValue.ToString();

        //        // Hiện/ẩn panel lọc theo khoảng
        //        panel10.Visible = (selectedInterval == "DateRange");

        //        if (selectedInterval != "DateRange")
        //        {
        //            LoadBarChartData(selectedInterval);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Lỗi khi thay đổi khoảng thời gian: {ex.Message}", "Lỗi",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Xử lý khi nhấn nút Lọc
        //        LoadBarChartData("DateRange");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Lỗi khi lọc dữ liệu: {ex.Message}", "Lỗi",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
    }
}
