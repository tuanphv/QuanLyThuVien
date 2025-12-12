using BUS;
using ClosedXML.Excel;
using DTO;
using GUI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI.BaoCao
{
    public partial class UCBaoCao : UserControl
    {
        private BindingList<BaoCaoNoDocGiaDTO> listNoDocGia = new();
        private BindingList<BaoCaoNoDocGiaDTO> listNoDocGiaFiltered = new();
        private BindingList<ThongKeSachDTO> listThongKeSach = new();
        private BindingList<ThongKeSachDTO> listThongKeSachFiltered = new();
        private string maDocGiaSelected = string.Empty;
        private bool _isLoaded = false;

        public UCBaoCao()
        {
            InitializeComponent();

            // Đăng ký sự kiện
            this.Load += UCBaoCao_Load;
            this.VisibleChanged += UCBaoCao_VisibleChanged; // Thêm sự kiện này
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
        }

        // --- CẬP NHẬT: TỰ ĐỘNG RELOAD KHI HIỂN THỊ ---
        private void UCBaoCao_VisibleChanged(object? sender, EventArgs e)
        {
            // Nếu control đang hiện và đã từng load lần đầu
            if (this.Visible && _isLoaded)
            {
                // Reload lại dữ liệu nợ để cập nhật số liệu mới nhất sau khi thu tiền
                LoadBaoCaoNoDocGia();
                // Có thể reload thêm các tab khác nếu cần, nhưng tab Nợ là quan trọng nhất
            }
        }

        private void UCBaoCao_Load(object sender, EventArgs e)
        {
            // Load báo cáo nợ theo độc giả (báo cáo mới)
            bool _isReader = SessionManager.CurrentUser?.TenNhomNguoiDung?.Equals("Độc Giả", StringComparison.OrdinalIgnoreCase) == true;
            if (_isReader && SessionManager.GetUserId() is int userId)
            {
                var docGia = DocGiaBUS.GetByUserId(userId);
                maDocGiaSelected = docGia?.MaDocGia;
            }

            // Khởi tạo DateTimePicker
            dtpTuNgay.Value = DateTime.Now.AddMonths(-1);
            dtpDenNgay.Value = DateTime.Now;

            // Khởi tạo ComboBox khoảng thời gian
            cboTimePeriodSach.SelectedIndex = 0; // Mặc định: Toàn thời gian
            cboTimePeriodDocGia.SelectedIndex = 0; // Mặc định: Toàn thời gian

            LoadBaoCaoNoDocGia();
            LoadThongKeSach();
            LoadTopSachStatistics();
            LoadTopDocGiaStatistics();

            _isLoaded = true;
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0: // Tab Báo cáo nợ độc giả
                    LoadBaoCaoNoDocGia();
                    break;

                case 1: // Tab Thống kê sách
                    LoadThongKeSach();
                    break;

                case 2: // Tab Thống kê mượn/trả
                    btnLoadThongKe_Click(sender, e);
                    break;

                default:
                    break;
            }
        }


        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            // Tự động load lại khi thay đổi ngày bắt đầu
            if (tabControl1.SelectedIndex == 2)
            {
                btnLoadThongKe_Click(sender, e);
            }
        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            // Tự động load lại khi thay đổi ngày kết thúc
            if (tabControl1.SelectedIndex == 2)
            {
                btnLoadThongKe_Click(sender, e);
            }
        }

        #region Báo cáo nợ độc giả
        private void btnLoadQuaHan_Click(object sender, EventArgs e)
        {
            LoadBaoCaoQuaHan();
        }

        private void btnLoadNoDocGia_Click(object sender, EventArgs e)
        {
            // Load báo cáo nợ theo độc giả (báo cáo mới)
            LoadBaoCaoNoDocGia();
        }

        private void LoadBaoCaoNoDocGia()
        {
            try
            {
                var list = BaoCaoBUS.GetBaoCaoNoDocGia();
                if (!string.IsNullOrEmpty(maDocGiaSelected))
                {
                    list = list.Where(x => x.MaDocGia == maDocGiaSelected).ToList();
                }
                listNoDocGia = new BindingList<BaoCaoNoDocGiaDTO>(list);
                listNoDocGiaFiltered = listNoDocGia;

                dgvQuaHan.DataSource = null;
                dgvQuaHan.DataSource = listNoDocGiaFiltered;

                // Nếu không có dữ liệu thì không cần config cột
                if (list == null || list.Count == 0) return;

                ConfigureDebtReportColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}\n\n{ex.StackTrace}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDebtReportColumns()
        {
            var style = new DataGridViewCellStyle
            {
                BackColor = Color.CornflowerBlue,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = SystemColors.HighlightText,
                SelectionBackColor = Color.CornflowerBlue,
                SelectionForeColor = SystemColors.HighlightText,
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            dgvQuaHan.ColumnHeadersDefaultCellStyle = style;

            if (dgvQuaHan.Columns["MaDocGia"] != null)
            {
                dgvQuaHan.Columns["MaDocGia"].HeaderText = "Mã độc giả";
                dgvQuaHan.Columns["MaDocGia"].FillWeight = 15;
                dgvQuaHan.Columns["MaDocGia"].MinimumWidth = 100;
            }

            if (dgvQuaHan.Columns["HoTen"] != null)
            {
                dgvQuaHan.Columns["HoTen"].HeaderText = "Họ tên";
                dgvQuaHan.Columns["HoTen"].FillWeight = 30;
                dgvQuaHan.Columns["HoTen"].MinimumWidth = 180;
            }

            if (dgvQuaHan.Columns["NoHienTai"] != null)
            {
                dgvQuaHan.Columns["NoHienTai"].HeaderText = "Nợ hiện tại";
                dgvQuaHan.Columns["NoHienTai"].DefaultCellStyle.Format = "#,##0 đ";
                dgvQuaHan.Columns["NoHienTai"].FillWeight = 20;
                dgvQuaHan.Columns["NoHienTai"].MinimumWidth = 120;
                dgvQuaHan.Columns["NoHienTai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvQuaHan.Columns["SoSachQuaHan"] != null)
            {
                dgvQuaHan.Columns["SoSachQuaHan"].HeaderText = "Số sách quá hạn";
                dgvQuaHan.Columns["SoSachQuaHan"].FillWeight = 15;
                dgvQuaHan.Columns["SoSachQuaHan"].MinimumWidth = 120;
                dgvQuaHan.Columns["SoSachQuaHan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvQuaHan.Columns["TongNoUocTinh"] != null)
            {
                dgvQuaHan.Columns["TongNoUocTinh"].HeaderText = "Tổng nợ ước tính";
                dgvQuaHan.Columns["TongNoUocTinh"].DefaultCellStyle.Format = "#,##0 đ";
                dgvQuaHan.Columns["TongNoUocTinh"].DefaultCellStyle.Font =
                    new Font(dgvQuaHan.Font, FontStyle.Bold);
                dgvQuaHan.Columns["TongNoUocTinh"].DefaultCellStyle.ForeColor = Color.Red;
                dgvQuaHan.Columns["TongNoUocTinh"].FillWeight = 20;
                dgvQuaHan.Columns["TongNoUocTinh"].MinimumWidth = 150;
                dgvQuaHan.Columns["TongNoUocTinh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Ẩn các cột không cần thiết
            string[] hiddenColumns = { "MaPhieuMuon", "NgayMuon", "NgayTraDuKien", "SoNgayQuaHan", "TienPhat" };
            foreach (var colName in hiddenColumns)
            {
                if (dgvQuaHan.Columns[colName] != null)
                    dgvQuaHan.Columns[colName].Visible = false;
            }
        }

        private void LoadBaoCaoQuaHan()
        {
            try
            {
                var list = BaoCaoBUS.GetBaoCaoQuaHan();
                if (!string.IsNullOrEmpty(maDocGiaSelected))
                {
                    list = list.Where(x => x.MaDocGia == maDocGiaSelected).ToList();
                }

                dgvQuaHan.DataSource = null;
                dgvQuaHan.DataSource = list;

                if (list == null || list.Count == 0)
                {
                    MessageBox.Show("Không có độc giả nào quá hạn chưa trả sách.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Configure columns for overdue report
                ConfigureOverdueReportColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}\n\nChi tiết: {ex.StackTrace}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureOverdueReportColumns()
        {
            var style = new DataGridViewCellStyle
            {
                BackColor = Color.CornflowerBlue,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = SystemColors.HighlightText,
                SelectionBackColor = Color.CornflowerBlue,
                SelectionForeColor = SystemColors.HighlightText,
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            dgvQuaHan.ColumnHeadersDefaultCellStyle = style;

            if (dgvQuaHan.Columns["MaDocGia"] != null)
            {
                dgvQuaHan.Columns["MaDocGia"].HeaderText = "Mã độc giả";
                dgvQuaHan.Columns["MaDocGia"].FillWeight = 15;
                dgvQuaHan.Columns["MaDocGia"].MinimumWidth = 100;
            }

            if (dgvQuaHan.Columns["HoTen"] != null)
            {
                dgvQuaHan.Columns["HoTen"].HeaderText = "Họ tên";
                dgvQuaHan.Columns["HoTen"].FillWeight = 25;
                dgvQuaHan.Columns["HoTen"].MinimumWidth = 150;
            }

            if (dgvQuaHan.Columns["MaPhieuMuon"] != null)
            {
                dgvQuaHan.Columns["MaPhieuMuon"].HeaderText = "Mã phiếu";
                dgvQuaHan.Columns["MaPhieuMuon"].FillWeight = 15;
                dgvQuaHan.Columns["MaPhieuMuon"].MinimumWidth = 100;
            }

            if (dgvQuaHan.Columns["NgayMuon"] != null)
            {
                dgvQuaHan.Columns["NgayMuon"].HeaderText = "Ngày mượn";
                dgvQuaHan.Columns["NgayMuon"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvQuaHan.Columns["NgayMuon"].FillWeight = 15;
                dgvQuaHan.Columns["NgayMuon"].MinimumWidth = 100;
                dgvQuaHan.Columns["NgayMuon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvQuaHan.Columns["NgayTraDuKien"] != null)
            {
                dgvQuaHan.Columns["NgayTraDuKien"].HeaderText = "Hạn trả";
                dgvQuaHan.Columns["NgayTraDuKien"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvQuaHan.Columns["NgayTraDuKien"].FillWeight = 15;
                dgvQuaHan.Columns["NgayTraDuKien"].MinimumWidth = 100;
                dgvQuaHan.Columns["NgayTraDuKien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvQuaHan.Columns["SoNgayQuaHan"] != null)
            {
                dgvQuaHan.Columns["SoNgayQuaHan"].HeaderText = "Số ngày quá hạn";
                dgvQuaHan.Columns["SoNgayQuaHan"].FillWeight = 15;
                dgvQuaHan.Columns["SoNgayQuaHan"].MinimumWidth = 120;
                dgvQuaHan.Columns["SoNgayQuaHan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvQuaHan.Columns["SoNgayQuaHan"].DefaultCellStyle.ForeColor = Color.Red;
                dgvQuaHan.Columns["SoNgayQuaHan"].DefaultCellStyle.Font =
                    new Font(dgvQuaHan.Font, FontStyle.Bold);
            }

            if (dgvQuaHan.Columns["TienPhat"] != null)
            {
                dgvQuaHan.Columns["TienPhat"].HeaderText = "Tiền phạt";
                dgvQuaHan.Columns["TienPhat"].DefaultCellStyle.Format = "#,##0 đ";
                dgvQuaHan.Columns["TienPhat"].FillWeight = 20;
                dgvQuaHan.Columns["TienPhat"].MinimumWidth = 120;
                dgvQuaHan.Columns["TienPhat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvQuaHan.Columns["TienPhat"].DefaultCellStyle.ForeColor = Color.Red;
                dgvQuaHan.Columns["TienPhat"].DefaultCellStyle.Font =
                    new Font(dgvQuaHan.Font, FontStyle.Bold);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (listNoDocGia == null || listNoDocGia.Count == 0) return;

            string tuKhoa = txtTimKiem.Text.ToLower().Trim();

            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                listNoDocGiaFiltered = listNoDocGia;
                dgvQuaHan.DataSource = listNoDocGiaFiltered;
                return;
            }

            var danhSachLoc = listNoDocGia.Where(dto =>
                dto.MaDocGia.ToLower().Contains(tuKhoa) ||
                dto.HoTen.ToLower().Contains(tuKhoa)
            ).ToList();

            listNoDocGiaFiltered = new BindingList<BaoCaoNoDocGiaDTO>(danhSachLoc);
            dgvQuaHan.DataSource = listNoDocGiaFiltered;
        }

        private void dgvQuaHan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= listNoDocGiaFiltered.Count) return;

            var selectedItem = listNoDocGiaFiltered[e.RowIndex];

            if (selectedItem.SoSachQuaHan > 0)
            {
                // Kiểm tra xem form chi tiết có tồn tại không trước khi gọi
                // FrmChiTietSachQuaHan frm = new FrmChiTietSachQuaHan(selectedItem.MaDocGia, selectedItem.HoTen);
                // frm.ShowDialog();
                MessageBox.Show($"Độc giả {selectedItem.HoTen} đang giữ {selectedItem.SoSachQuaHan} cuốn sách quá hạn.", "Chi tiết");
            }
            else
            {
                MessageBox.Show("Độc giả này không có sách quá hạn.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (listNoDocGiaFiltered == null || listNoDocGiaFiltered.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Workbook|*.xlsx";
            sfd.FileName = $"BaoCaoNoQuaHan_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Báo Cáo Nợ");

                        worksheet.Cell(1, 1).Value = "BÁO CÁO NỢ QUÁ HẠN";
                        worksheet.Cell(1, 1).Style.Font.Bold = true;
                        worksheet.Cell(1, 1).Style.Font.FontSize = 16;
                        worksheet.Range("A1:E1").Merge();
                        worksheet.Range("A1:E1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        worksheet.Cell(2, 1).Value = "Ngày xuất:";
                        worksheet.Cell(2, 2).Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                        worksheet.Range("B2:E2").Merge();

                        worksheet.Cell(4, 1).Value = "Mã Độc Giả";
                        worksheet.Cell(4, 2).Value = "Họ Tên";
                        worksheet.Cell(4, 3).Value = "Nợ Hiện Tại";
                        worksheet.Cell(4, 4).Value = "Số Sách Quá Hạn";
                        worksheet.Cell(4, 5).Value = "Tổng Nợ Ước Tính";

                        var headerRow = worksheet.Range("A4:E4");
                        headerRow.Style.Font.Bold = true;
                        headerRow.Style.Fill.BackgroundColor = XLColor.LightBlue;
                        headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        headerRow.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                        for (int i = 0; i < listNoDocGiaFiltered.Count; i++)
                        {
                            var item = listNoDocGiaFiltered[i];
                            int rowIndex = i + 5;

                            worksheet.Cell(rowIndex, 1).Value = item.MaDocGia;
                            worksheet.Cell(rowIndex, 2).Value = item.HoTen;
                            worksheet.Cell(rowIndex, 3).Value = item.NoHienTai;
                            worksheet.Cell(rowIndex, 4).Value = item.SoSachQuaHan;
                            worksheet.Cell(rowIndex, 5).Value = item.TongNoUocTinh;

                            worksheet.Cell(rowIndex, 3).Style.NumberFormat.Format = "#,##0";
                            worksheet.Cell(rowIndex, 5).Style.NumberFormat.Format = "#,##0";
                        }

                        int totalRow = listNoDocGiaFiltered.Count + 5;
                        worksheet.Cell(totalRow, 1).Value = "TỔNG CỘNG";
                        worksheet.Cell(totalRow, 1).Style.Font.Bold = true;
                        worksheet.Range($"A{totalRow}:B{totalRow}").Merge();

                        worksheet.Cell(totalRow, 3).Value = listNoDocGiaFiltered.Sum(x => x.NoHienTai);
                        worksheet.Cell(totalRow, 4).Value = listNoDocGiaFiltered.Sum(x => x.SoSachQuaHan);
                        worksheet.Cell(totalRow, 5).Value = listNoDocGiaFiltered.Sum(x => x.TongNoUocTinh);

                        worksheet.Cell(totalRow, 3).Style.NumberFormat.Format = "#,##0";
                        worksheet.Cell(totalRow, 3).Style.Font.Bold = true;
                        worksheet.Cell(totalRow, 4).Style.Font.Bold = true;
                        worksheet.Cell(totalRow, 5).Style.NumberFormat.Format = "#,##0";
                        worksheet.Cell(totalRow, 5).Style.Font.Bold = true;

                        var dataRange = worksheet.Range($"A4:E{totalRow}");
                        dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                        dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                        worksheet.Columns().AdjustToContents();
                        workbook.SaveAs(sfd.FileName);
                    }

                    MessageBox.Show("Xuất file Excel thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var openFile = MessageBox.Show("Bạn có muốn mở file vừa xuất không?", "Mở file",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (openFile == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = sfd.FileName,
                            UseShellExecute = true
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Thống kê sách
        private void LoadThongKeSach()
        {
            try
            {
                var thongKe = BaoCaoBUS.GetThongKeSach();

                listThongKeSach = new BindingList<ThongKeSachDTO>(thongKe);
                listThongKeSachFiltered = listThongKeSach;

                dgvThongKeSach.DataSource = null;
                dgvThongKeSach.DataSource = listThongKeSachFiltered;

                ConfigureBookStatisticsColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thống kê sách: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureBookStatisticsColumns()
        {
            var style = new DataGridViewCellStyle
            {
                BackColor = Color.CornflowerBlue,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = SystemColors.HighlightText,
                SelectionBackColor = Color.CornflowerBlue,
                SelectionForeColor = SystemColors.HighlightText,
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            dgvThongKeSach.ColumnHeadersDefaultCellStyle = style;

            // Ẩn cột ID
            if (dgvThongKeSach.Columns["IDTuaSach"] != null)
            {
                dgvThongKeSach.Columns["IDTuaSach"].Visible = false;
            }

            if (dgvThongKeSach.Columns["TenSach"] != null)
            {
                dgvThongKeSach.Columns["TenSach"].HeaderText = "Tên sách";
                dgvThongKeSach.Columns["TenSach"].FillWeight = 40;
            }

            if (dgvThongKeSach.Columns["TongSoLuong"] != null)
            {
                dgvThongKeSach.Columns["TongSoLuong"].HeaderText = "Tổng số lượng";
                dgvThongKeSach.Columns["TongSoLuong"].FillWeight = 15;
                dgvThongKeSach.Columns["TongSoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvThongKeSach.Columns["DangMuon"] != null)
            {
                dgvThongKeSach.Columns["DangMuon"].HeaderText = "Đang mượn";
                dgvThongKeSach.Columns["DangMuon"].FillWeight = 15;
                dgvThongKeSach.Columns["DangMuon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvThongKeSach.Columns["DangMuon"].DefaultCellStyle.ForeColor = Color.Orange;
            }

            if (dgvThongKeSach.Columns["ConLai"] != null)
            {
                dgvThongKeSach.Columns["ConLai"].HeaderText = "Còn lại";
                dgvThongKeSach.Columns["ConLai"].FillWeight = 15;
                dgvThongKeSach.Columns["ConLai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvThongKeSach.Columns["ConLai"].DefaultCellStyle.ForeColor = Color.Green;
            }

            if (dgvThongKeSach.Columns["TyLeMuon"] != null)
            {
                dgvThongKeSach.Columns["TyLeMuon"].HeaderText = "Tỷ lệ mượn (%)";
                dgvThongKeSach.Columns["TyLeMuon"].FillWeight = 15;
                dgvThongKeSach.Columns["TyLeMuon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvThongKeSach.Columns["TyLeMuon"].DefaultCellStyle.Format = "0.0";
            }
        }

        private void txtTimKiemSach_TextChanged(object sender, EventArgs e)
        {
            if (listThongKeSach == null || listThongKeSach.Count == 0) return;

            string keyword = txtTimKiemSach.Text.ToLower().Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                listThongKeSachFiltered = listThongKeSach;
                dgvThongKeSach.DataSource = listThongKeSachFiltered;
                return;
            }

            var danhSachLoc = listThongKeSach
                .Where(s => s.TenSach.ToLower().Contains(keyword))
                .ToList();

            listThongKeSachFiltered = new BindingList<ThongKeSachDTO>(danhSachLoc);
            dgvThongKeSach.DataSource = listThongKeSachFiltered;
        }

        private void btnExportSach_Click(object sender, EventArgs e)
        {
            if (listThongKeSachFiltered == null || listThongKeSachFiltered.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                FileName = $"ThongKeSach_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Thống Kê Sách");

                        worksheet.Cell(1, 1).Value = "THỐNG KÊ TÌNH TRẠNG SÁCH";
                        worksheet.Cell(1, 1).Style.Font.Bold = true;
                        worksheet.Cell(1, 1).Style.Font.FontSize = 16;
                        worksheet.Range("A1:E1").Merge();
                        worksheet.Range("A1:E1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        worksheet.Cell(2, 1).Value = "Ngày xuất:";
                        worksheet.Cell(2, 2).Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                        worksheet.Cell(4, 1).Value = "Tên sách";
                        worksheet.Cell(4, 2).Value = "Tổng số lượng";
                        worksheet.Cell(4, 3).Value = "Đang mượn";
                        worksheet.Cell(4, 4).Value = "Còn lại";
                        worksheet.Cell(4, 5).Value = "Tỷ lệ mượn (%)";

                        var headerRow = worksheet.Range("A4:E4");
                        headerRow.Style.Font.Bold = true;
                        headerRow.Style.Fill.BackgroundColor = XLColor.LightBlue;
                        headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        int row = 5;
                        foreach (var item in listThongKeSachFiltered)
                        {
                            worksheet.Cell(row, 1).Value = item.TenSach;
                            worksheet.Cell(row, 2).Value = item.TongSoLuong;
                            worksheet.Cell(row, 3).Value = item.DangMuon;
                            worksheet.Cell(row, 4).Value = item.ConLai;
                            worksheet.Cell(row, 5).Value = item.TyLeMuon;
                            row++;
                        }

                        worksheet.Columns().AdjustToContents();
                        workbook.SaveAs(sfd.FileName);
                    }

                    MessageBox.Show("Xuất file Excel thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (MessageBox.Show("Bạn có muốn mở file vừa xuất không?", "Mở file",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = sfd.FileName,
                            UseShellExecute = true
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Thống kê mượn/trả
        private void btnLoadThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date;

                if (tuNgay > denNgay)
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var thongKe = BaoCaoBUS.GetThongKeMuonTraTheoNgay(tuNgay, denNgay)
                    .Select(x => new
                    {
                        Ngay = x.Ngay.ToString("dd/MM/yyyy"),
                        x.SoPhieuMuon,
                        x.TongSachMuon,
                        x.SoPhieuDaTra,
                        x.SoPhieuChuaTra
                    })
                    .ToList();

                dgvThongKeMuonTra.DataSource = thongKe;
                ConfigureBorrowReturnStatisticsColumns();

                if (thongKe.Count == 0)
                {
                    // Tùy chọn: Có thể hiện thông báo hoặc chỉ clear grid
                    // MessageBox.Show("Không có dữ liệu trong khoảng thời gian đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thống kê: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureBorrowReturnStatisticsColumns()
        {
            var style = new DataGridViewCellStyle
            {
                BackColor = Color.CornflowerBlue,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = SystemColors.HighlightText,
                SelectionBackColor = Color.CornflowerBlue,
                SelectionForeColor = SystemColors.HighlightText,
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            dgvThongKeMuonTra.ColumnHeadersDefaultCellStyle = style;

            if (dgvThongKeMuonTra.Columns["Ngay"] != null)
            {
                dgvThongKeMuonTra.Columns["Ngay"].HeaderText = "Ngày";
                dgvThongKeMuonTra.Columns["Ngay"].FillWeight = 20;
            }

            if (dgvThongKeMuonTra.Columns["SoPhieuMuon"] != null)
            {
                dgvThongKeMuonTra.Columns["SoPhieuMuon"].HeaderText = "Số phiếu mượn";
                dgvThongKeMuonTra.Columns["SoPhieuMuon"].FillWeight = 20;
                dgvThongKeMuonTra.Columns["SoPhieuMuon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvThongKeMuonTra.Columns["TongSachMuon"] != null)
            {
                dgvThongKeMuonTra.Columns["TongSachMuon"].HeaderText = "Tổng sách mượn";
                dgvThongKeMuonTra.Columns["TongSachMuon"].FillWeight = 20;
                dgvThongKeMuonTra.Columns["TongSachMuon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvThongKeMuonTra.Columns["SoPhieuDaTra"] != null)
            {
                dgvThongKeMuonTra.Columns["SoPhieuDaTra"].HeaderText = "Đã trả";
                dgvThongKeMuonTra.Columns["SoPhieuDaTra"].FillWeight = 20;
                dgvThongKeMuonTra.Columns["SoPhieuDaTra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvThongKeMuonTra.Columns["SoPhieuDaTra"].DefaultCellStyle.ForeColor = Color.Green;
            }

            if (dgvThongKeMuonTra.Columns["SoPhieuChuaTra"] != null)
            {
                dgvThongKeMuonTra.Columns["SoPhieuChuaTra"].HeaderText = "Chưa trả";
                dgvThongKeMuonTra.Columns["SoPhieuChuaTra"].FillWeight = 20;
                dgvThongKeMuonTra.Columns["SoPhieuChuaTra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvThongKeMuonTra.Columns["SoPhieuChuaTra"].DefaultCellStyle.ForeColor = Color.Red;
            }
        }

        private void btnExportMuonTra_Click(object sender, EventArgs e)
        {
            if (dgvThongKeMuonTra.DataSource == null || dgvThongKeMuonTra.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất. Vui lòng tải thống kê trước.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                FileName = $"ThongKeMuonTra_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Thống Kê Mượn Trả");

                        worksheet.Cell(1, 1).Value = "THỐNG KÊ MƯỢN/TRẢ SÁCH";
                        worksheet.Cell(1, 1).Style.Font.Bold = true;
                        worksheet.Cell(1, 1).Style.Font.FontSize = 16;
                        worksheet.Range("A1:E1").Merge();
                        worksheet.Range("A1:E1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        worksheet.Cell(2, 1).Value = "Từ ngày:";
                        worksheet.Cell(2, 2).Value = dtpTuNgay.Value.ToString("dd/MM/yyyy");
                        worksheet.Cell(2, 3).Value = "Đến ngày:";
                        worksheet.Cell(2, 4).Value = dtpDenNgay.Value.ToString("dd/MM/yyyy");

                        worksheet.Cell(4, 1).Value = "Ngày";
                        worksheet.Cell(4, 2).Value = "Số phiếu mượn";
                        worksheet.Cell(4, 3).Value = "Tổng sách mượn";
                        worksheet.Cell(4, 4).Value = "Đã trả";
                        worksheet.Cell(4, 5).Value = "Chưa trả";

                        var headerRow = worksheet.Range("A4:E4");
                        headerRow.Style.Font.Bold = true;
                        headerRow.Style.Fill.BackgroundColor = XLColor.LightBlue;
                        headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        int row = 5;
                        foreach (DataGridViewRow dgvRow in dgvThongKeMuonTra.Rows)
                        {
                            if (dgvRow.IsNewRow) continue;
                            worksheet.Cell(row, 1).Value = dgvRow.Cells["Ngay"].Value?.ToString();
                            worksheet.Cell(row, 2).Value = Convert.ToInt32(dgvRow.Cells["SoPhieuMuon"].Value ?? 0);
                            worksheet.Cell(row, 3).Value = Convert.ToInt32(dgvRow.Cells["TongSachMuon"].Value ?? 0);
                            worksheet.Cell(row, 4).Value = Convert.ToInt32(dgvRow.Cells["SoPhieuDaTra"].Value ?? 0);
                            worksheet.Cell(row, 5).Value = Convert.ToInt32(dgvRow.Cells["SoPhieuChuaTra"].Value ?? 0);
                            row++;
                        }

                        worksheet.Columns().AdjustToContents();
                        workbook.SaveAs(sfd.FileName);
                    }

                    MessageBox.Show("Xuất file Excel thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (MessageBox.Show("Bạn có muốn mở file vừa xuất không?", "Mở file",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = sfd.FileName,
                            UseShellExecute = true
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Thống kê Top sách
        private void LoadTopSachStatistics()
        {
            try
            {
                DateTime? tuNgay = null;
                DateTime? denNgay = null;

                string selectedPeriod = cboTimePeriodSach.SelectedItem?.ToString() ?? "Toàn thời gian";

                switch (selectedPeriod)
                {
                    case "7 ngày qua":
                        tuNgay = DateTime.Now.AddDays(-7);
                        denNgay = DateTime.Now;
                        break;

                    case "30 ngày qua":
                        tuNgay = DateTime.Now.AddDays(-30);
                        denNgay = DateTime.Now;
                        break;

                    default: // "Toàn thời gian"
                        tuNgay = null;
                        denNgay = null;
                        break;
                }

                var topSach = tuNgay.HasValue && denNgay.HasValue
                    ? BaoCaoBUS.GetTopSachMuonNhieuTheoKhoang(10, tuNgay, denNgay)
                    : BaoCaoBUS.GetTopSachMuonNhieu(10);

                dgvTopSach.DataSource = topSach;
                ConfigureTopBooksColumns();

                if (tuNgay.HasValue && denNgay.HasValue)
                {
                    label6.Text = $"🏆 Top 10 sách mượn nhiều ({selectedPeriod})";
                }
                else
                {
                    label6.Text = "🏆 Top 10 sách mượn nhiều (Toàn thời gian)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thống kê top sách: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshTopSach_Click(object sender, EventArgs e)
        {
            LoadTopSachStatistics();
        }

        private void cboTimePeriodSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTopSachStatistics();
        }

        private void ConfigureTopBooksColumns()
        {
            var style = new DataGridViewCellStyle
            {
                BackColor = Color.CornflowerBlue,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = SystemColors.HighlightText,
                SelectionBackColor = Color.CornflowerBlue,
                SelectionForeColor = SystemColors.HighlightText,
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            dgvTopSach.ColumnHeadersDefaultCellStyle = style;

            if (dgvTopSach.Columns["TenTuaSach"] != null)
            {
                dgvTopSach.Columns["TenTuaSach"].HeaderText = "Tên tựa sách";
                dgvTopSach.Columns["TenTuaSach"].FillWeight = 50;
            }

            if (dgvTopSach.Columns["SoLuotMuon"] != null)
            {
                dgvTopSach.Columns["SoLuotMuon"].HeaderText = "Số lần mượn";
                dgvTopSach.Columns["SoLuotMuon"].FillWeight = 20;
                dgvTopSach.Columns["SoLuotMuon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvTopSach.Columns["SoLuotMuon"].DefaultCellStyle.ForeColor = Color.Green;
                dgvTopSach.Columns["SoLuotMuon"].DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            }

            if (dgvTopSach.Columns["TheLoai"] != null)
            {
                dgvTopSach.Columns["TheLoai"].HeaderText = "Thể loại";
                dgvTopSach.Columns["TheLoai"].FillWeight = 20;
            }

            // Hide unnecessary columns
            if (dgvTopSach.Columns["STT"] != null)
                dgvTopSach.Columns["STT"].Visible = false;
            if (dgvTopSach.Columns["MaTuaSach"] != null)
                dgvTopSach.Columns["MaTuaSach"].Visible = false;
            if (dgvTopSach.Columns["SoLuongHienCo"] != null)
                dgvTopSach.Columns["SoLuongHienCo"].Visible = false;
        }
        #endregion

        #region Thống kê Top độc giả
        private void LoadTopDocGiaStatistics()
        {
            try
            {
                DateTime? tuNgay = null;
                DateTime? denNgay = null;

                string selectedPeriod = cboTimePeriodDocGia.SelectedItem?.ToString() ?? "Toàn thời gian";

                switch (selectedPeriod)
                {
                    case "7 ngày qua":
                        tuNgay = DateTime.Now.AddDays(-7);
                        denNgay = DateTime.Now;
                        break;

                    case "30 ngày qua":
                        tuNgay = DateTime.Now.AddDays(-30);
                        denNgay = DateTime.Now;
                        break;

                    default:
                        tuNgay = null;
                        denNgay = null;
                        break;
                }

                var topDocGia = tuNgay.HasValue && denNgay.HasValue
                    ? BaoCaoBUS.GetTopDocGiaTichCucTheoKhoang(10, tuNgay, denNgay)
                    : BaoCaoBUS.GetTopDocGiaTichCuc(10);

                dgvTopDocGia.DataSource = topDocGia;
                ConfigureTopReadersColumns();

                if (tuNgay.HasValue && denNgay.HasValue)
                {
                    label7.Text = $"🏆 Top 10 độc giả tích cực nhất ({selectedPeriod})";
                }
                else
                {
                    label7.Text = "🏆 Top 10 độc giả tích cực nhất (Toàn thời gian)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thống kê top độc giả: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshTopDocGia_Click(object sender, EventArgs e)
        {
            LoadTopDocGiaStatistics();
        }
        private void cboTimePeriodDocGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTopDocGiaStatistics();
        }

        private void ConfigureTopReadersColumns()
        {
            var style = new DataGridViewCellStyle
            {
                BackColor = Color.CornflowerBlue,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = SystemColors.HighlightText,
                SelectionBackColor = Color.CornflowerBlue,
                SelectionForeColor = SystemColors.HighlightText,
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            dgvTopDocGia.ColumnHeadersDefaultCellStyle = style;

            if (dgvTopDocGia.Columns["MaDocGia"] != null)
            {
                dgvTopDocGia.Columns["MaDocGia"].HeaderText = "Mã độc giả";
                dgvTopDocGia.Columns["MaDocGia"].FillWeight = 20;
            }

            if (dgvTopDocGia.Columns["HoTen"] != null)
            {
                dgvTopDocGia.Columns["HoTen"].HeaderText = "Họ tên";
                dgvTopDocGia.Columns["HoTen"].FillWeight = 40;
            }

            if (dgvTopDocGia.Columns["SoLuotMuon"] != null)
            {
                dgvTopDocGia.Columns["SoLuotMuon"].HeaderText = "Số sách đã mượn";
                dgvTopDocGia.Columns["SoLuotMuon"].FillWeight = 20;
                dgvTopDocGia.Columns["SoLuotMuon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvTopDocGia.Columns["SoLuotMuon"].DefaultCellStyle.ForeColor = Color.Green;
                dgvTopDocGia.Columns["SoLuotMuon"].DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            }

            // Hide unnecessary columns
            if (dgvTopDocGia.Columns["STT"] != null)
                dgvTopDocGia.Columns["STT"].Visible = false;
            if (dgvTopDocGia.Columns["TongNo"] != null)
                dgvTopDocGia.Columns["TongNo"].Visible = false;
            if (dgvTopDocGia.Columns["NgayLapThe"] != null)
                dgvTopDocGia.Columns["NgayLapThe"].Visible = false;
        }
        #endregion
    }
}