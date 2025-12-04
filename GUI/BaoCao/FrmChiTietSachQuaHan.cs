using BUS;
using ClosedXML.Excel;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace GUI.BaoCao
{
    public partial class FrmChiTietSachQuaHan : Form
    {
        private readonly string _maDocGia;
        private readonly string _tenDocGia;
        private BindingList<ChiTietSachQuaHanDTO> _chiTiet = new();

        public FrmChiTietSachQuaHan(string maDocGia, string tenDocGia)
        {
            _maDocGia = maDocGia;
            _tenDocGia = tenDocGia;
            InitializeComponent();
            Load += FrmChiTietSachQuaHan_Load;
        }

        private void FrmChiTietSachQuaHan_Load(object? sender, EventArgs e)
        {
            lblDocGia.Text = $"{_tenDocGia} ({_maDocGia})";

            dgvChiTiet.AutoGenerateColumns = false;
            colMaCuon.DataPropertyName = nameof(ChiTietSachQuaHanDTO.MaCuonSach);
            colTenSach.DataPropertyName = nameof(ChiTietSachQuaHanDTO.TenSach);
            colMaPhieu.DataPropertyName = nameof(ChiTietSachQuaHanDTO.MaPhieuMuon);
            colNgayTraDuKien.DataPropertyName = nameof(ChiTietSachQuaHanDTO.NgayTraDuKien);
            colSoNgayQuaHan.DataPropertyName = nameof(ChiTietSachQuaHanDTO.SoNgayQuaHan);
            colTienPhat.DataPropertyName = nameof(ChiTietSachQuaHanDTO.TienPhatUocTinh);

            colNgayTraDuKien.DefaultCellStyle.Format = "dd/MM/yyyy";
            colTienPhat.DefaultCellStyle.Format = "#,##0 đ";

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = BaoCaoBUS.GetChiTietSachQuaHan(_maDocGia);
                _chiTiet = new BindingList<ChiTietSachQuaHanDTO>(list);
                dgvChiTiet.DataSource = _chiTiet;

                // Tính tổng
                int tongSach = list.Count;
                int tongTienPhat = 0;
                foreach (var item in list)
                {
                    tongTienPhat += item.TienPhatUocTinh;
                }

                lblTongSach.Text = tongSach.ToString();
                lblTongTienPhat.Text = tongTienPhat.ToString("#,##0 đ");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_chiTiet == null || _chiTiet.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Workbook|*.xlsx";
            sfd.FileName = $"ChiTietSachQuaHan_{_maDocGia}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Chi Tiết Sách Quá Hạn");

                        // Header
                        worksheet.Cell(1, 1).Value = "CHI TIẾT SÁCH QUÁ HẠN";
                        worksheet.Cell(1, 1).Style.Font.Bold = true;
                        worksheet.Cell(1, 1).Style.Font.FontSize = 16;
                        worksheet.Range("A1:F1").Merge();
                        worksheet.Range("A1:F1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        worksheet.Cell(2, 1).Value = "Độc giả:";
                        worksheet.Cell(2, 2).Value = lblDocGia.Text;
                        worksheet.Cell(2, 2).Style.Font.Bold = true;
                        worksheet.Range("B2:F2").Merge();

                        worksheet.Cell(3, 1).Value = "Ngày xuất:";
                        worksheet.Cell(3, 2).Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                        worksheet.Range("B3:F3").Merge();

                        // Table Header
                        worksheet.Cell(5, 1).Value = "Mã Cuốn Sách";
                        worksheet.Cell(5, 2).Value = "Tên Sách";
                        worksheet.Cell(5, 3).Value = "Mã Phiếu Mượn";
                        worksheet.Cell(5, 4).Value = "Ngày Trả Dự Kiến";
                        worksheet.Cell(5, 5).Value = "Số Ngày Quá Hạn";
                        worksheet.Cell(5, 6).Value = "Tiền Phạt Ước Tính";

                        var headerRow = worksheet.Range("A5:F5");
                        headerRow.Style.Font.Bold = true;
                        headerRow.Style.Fill.BackgroundColor = XLColor.LightBlue;
                        headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        headerRow.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                        // Data
                        for (int i = 0; i < _chiTiet.Count; i++)
                        {
                            var item = _chiTiet[i];
                            int rowIndex = i + 6;

                            worksheet.Cell(rowIndex, 1).Value = item.MaCuonSach;
                            worksheet.Cell(rowIndex, 2).Value = item.TenSach;
                            worksheet.Cell(rowIndex, 3).Value = item.MaPhieuMuon;
                            worksheet.Cell(rowIndex, 4).Value = item.NgayTraDuKien.ToString("dd/MM/yyyy");
                            worksheet.Cell(rowIndex, 5).Value = item.SoNgayQuaHan;
                            worksheet.Cell(rowIndex, 6).Value = item.TienPhatUocTinh;
                            worksheet.Cell(rowIndex, 6).Style.NumberFormat.Format = "#,##0";
                        }

                        // Total
                        int totalRow = _chiTiet.Count + 6;
                        worksheet.Cell(totalRow, 1).Value = "TỔNG CỘNG";
                        worksheet.Cell(totalRow, 1).Style.Font.Bold = true;
                        worksheet.Range($"A{totalRow}:E{totalRow}").Merge();
                        worksheet.Range($"A{totalRow}:E{totalRow}").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        
                        int tongTienPhat = 0;
                        foreach (var item in _chiTiet)
                            tongTienPhat += item.TienPhatUocTinh;
                        
                        worksheet.Cell(totalRow, 6).Value = tongTienPhat;
                        worksheet.Cell(totalRow, 6).Style.NumberFormat.Format = "#,##0";
                        worksheet.Cell(totalRow, 6).Style.Font.Bold = true;

                        // Border
                        var dataRange = worksheet.Range($"A5:F{totalRow}");
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

        private void InitializeComponent()
        {
            Text = "Chi tiết sách quá hạn";
            Width = 900;
            Height = 600;
            StartPosition = FormStartPosition.CenterParent;

            var lblTitle = new Label 
            { 
                Text = "Chi tiết sách quá hạn", 
                Left = 20, 
                Top = 15, 
                AutoSize = true, 
                Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold) 
            };

            var lblDG = new Label 
            { 
                Text = "Độc giả:", 
                Left = 20, 
                Top = 50, 
                AutoSize = true, 
                Font = new System.Drawing.Font("Segoe UI", 10F) 
            };

            lblDocGia = new Label 
            { 
                Left = 100, 
                Top = 50, 
                AutoSize = true, 
                Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold) 
            };

            dgvChiTiet = new DataGridView
            {
                Left = 20,
                Top = 90,
                Width = 840,
                Height = 380,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            colMaCuon = new DataGridViewTextBoxColumn { HeaderText = "Mã cuốn", MinimumWidth = 80 };
            colTenSach = new DataGridViewTextBoxColumn { HeaderText = "Tên sách", MinimumWidth = 200 };
            colMaPhieu = new DataGridViewTextBoxColumn { HeaderText = "Mã phiếu", MinimumWidth = 90 };
            colNgayTraDuKien = new DataGridViewTextBoxColumn { HeaderText = "Hạn trả", MinimumWidth = 90 };
            colSoNgayQuaHan = new DataGridViewTextBoxColumn { HeaderText = "Số ngày quá hạn", MinimumWidth = 80 };
            colTienPhat = new DataGridViewTextBoxColumn { HeaderText = "Tiền phạt ước tính", MinimumWidth = 100 };
            
            dgvChiTiet.Columns.AddRange(colMaCuon, colTenSach, colMaPhieu, colNgayTraDuKien, colSoNgayQuaHan, colTienPhat);

            var lblTong = new Label 
            { 
                Text = "Tổng sách:", 
                Left = 20, 
                Top = 485, 
                AutoSize = true, 
                Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold) 
            };

            lblTongSach = new Label 
            { 
                Left = 120, 
                Top = 485, 
                AutoSize = true, 
                Font = new System.Drawing.Font("Segoe UI", 10F) 
            };

            var lblPhat = new Label 
            { 
                Text = "Tổng tiền phạt ước tính:", 
                Left = 200, 
                Top = 485, 
                AutoSize = true, 
                Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold) 
            };

            lblTongTienPhat = new Label 
            { 
                Left = 380, 
                Top = 485, 
                AutoSize = true, 
                Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.Red
            };

            btnExport = new Button
            {
                Text = "Xuất Excel",
                Left = 740,
                Top = 520,
                Width = 120,
                Height = 35,
                BackColor = System.Drawing.Color.FromArgb(40, 167, 69),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold)
            };
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.Click += btnExport_Click;

            Controls.AddRange(new Control[] 
            { 
                lblTitle, lblDG, lblDocGia, dgvChiTiet, 
                lblTong, lblTongSach, lblPhat, lblTongTienPhat, btnExport 
            });
        }

        private Label lblDocGia = null!;
        private Label lblTongSach = null!;
        private Label lblTongTienPhat = null!;
        private DataGridView dgvChiTiet = null!;
        private DataGridViewTextBoxColumn colMaCuon = null!;
        private DataGridViewTextBoxColumn colTenSach = null!;
        private DataGridViewTextBoxColumn colMaPhieu = null!;
        private DataGridViewTextBoxColumn colNgayTraDuKien = null!;
        private DataGridViewTextBoxColumn colSoNgayQuaHan = null!;
        private DataGridViewTextBoxColumn colTienPhat = null!;
        private Button btnExport = null!;
    }
}
