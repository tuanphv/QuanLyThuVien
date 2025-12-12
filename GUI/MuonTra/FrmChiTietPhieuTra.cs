using BUS;
using DTO;
using System;
using System.ComponentModel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Forms;

namespace GUI.MuonTra
{
    public partial class FrmChiTietPhieuTra : Form
    {
        private readonly PhieuTraDTO _phieu;
        private BindingList<ChiTietPhieuTraDTO> _chiTiet = new();

        // Khai báo các control giao diện
        private Label lblMaPhieu = null!;
        private Label lblMaPhieuTra = null!;
        private Label lblDocGia = null!;
        private Label lblNgayTra = null!;
        private Label lblTongSach = null!;
        private Label lblTongTienPhat = null!;
        private DataGridView dgvChiTiet = null!;
        private DataGridViewTextBoxColumn colMaCuon = null!;
        private DataGridViewTextBoxColumn colTenSach = null!;
        private DataGridViewTextBoxColumn colNgayMuon = null!;
        private DataGridViewTextBoxColumn colNgayTra = null!;
        private DataGridViewTextBoxColumn colTienPhat = null!;
        private DataGridViewTextBoxColumn colTinhTrangTra = null!;
        private Button btnExportPdf = null!;

        public FrmChiTietPhieuTra(PhieuTraDTO phieu)
        {
            _phieu = phieu;
            InitializeComponent();
            Load += FrmChiTietPhieuTra_Load;
        }

        private void FrmChiTietPhieuTra_Load(object? sender, EventArgs e)
        {
            try
            {
                if (_phieu == null) return;

                lblMaPhieuTra.Text = _phieu.MaPhieuTra;
                lblMaPhieu.Text = _phieu.MaPhieuMuon;
                lblDocGia.Text = $"{_phieu.HoTenDocGia}";
                lblNgayTra.Text = _phieu.NgayTra.ToString("dd/MM/yyyy");
                lblTongSach.Text = _phieu.TongSachTra.ToString();
                lblTongTienPhat.Text = $"{_phieu.TongTienPhat:N0} VNĐ";


                dgvChiTiet.AutoGenerateColumns = false;

                // Map Data Properties an toàn
                if (colMaCuon != null) colMaCuon.DataPropertyName = nameof(ChiTietPhieuTraDTO.MaCuonSach);
                if (colTenSach != null) colTenSach.DataPropertyName = nameof(ChiTietPhieuTraDTO.TenSach);
                if (colNgayMuon != null)
                {
                    colNgayMuon.DataPropertyName = nameof(ChiTietPhieuTraDTO.NgayMuon);
                    colNgayMuon.DefaultCellStyle.Format = "dd/MM/yyyy";
                }
                if (colNgayTra != null)
                {
                    colNgayTra.DataPropertyName = nameof(ChiTietPhieuTraDTO.NgayTraThucTe);
                    colNgayTra.DefaultCellStyle.Format = "dd/MM/yyyy";
                }
                if (colTienPhat != null)
                {
                    colTienPhat.DataPropertyName = nameof(ChiTietPhieuTraDTO.TienPhat);
                    colTienPhat.DefaultCellStyle.Format = "N0";
                }
                if (colTinhTrangTra != null) colTinhTrangTra.DataPropertyName = nameof(ChiTietPhieuTraDTO.TinhTrangTra);

                _chiTiet = MuonTraBUS.LayChiTietPhieuTra(_phieu.ID);
                dgvChiTiet.DataSource = _chiTiet;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExportPdf_Click(object? sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF file|*.pdf";
                sfd.FileName = $"PhieuTra_{_phieu.MaPhieuTra}.pdf";
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    using (var fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write))
                    {
                        var doc = new Document(PageSize.A4, 36, 36, 36, 36);
                        PdfWriter.GetInstance(doc, fs);
                        doc.Open();

                        // Xử lý Font chữ tiếng Việt
                        string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                        BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                        iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font fontLabel = new iTextSharp.text.Font(bf, 12);
                        iTextSharp.text.Font fontValue = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);

                        // Header
                        doc.Add(new Paragraph("PHIẾU TRẢ SÁCH", fontTitle) { Alignment = Element.ALIGN_CENTER });
                        doc.Add(new Paragraph("\n"));
                        doc.Add(new Paragraph($"Mã phiếu trả: {_phieu.MaPhieuTra}", fontLabel));
                        doc.Add(new Paragraph($"Mã phiếu mượn: {_phieu.MaPhieuMuon}", fontLabel));
                        doc.Add(new Paragraph($"Độc giả: {_phieu.HoTenDocGia}", fontLabel));
                        doc.Add(new Paragraph($"Ngày trả: {_phieu.NgayTra:dd/MM/yyyy}", fontLabel));
                        doc.Add(new Paragraph($"Tổng sách trả: {_phieu.TongSachTra}", fontLabel));
                        doc.Add(new Paragraph($"Tổng tiền phạt: {_phieu.TongTienPhat:N0} đ", fontValue));
                        doc.Add(new Paragraph("\n"));

                        // Table
                        PdfPTable table = new PdfPTable(6) { WidthPercentage = 100 };
                        // Điều chỉnh độ rộng cột: Mã, Tên, Ngày Mượn, Ngày Trả, Tình trạng, Phạt
                        table.SetWidths(new float[] { 1.2f, 2.5f, 1.3f, 1.3f, 1.5f, 1.2f });

                        string[] headers = { "Mã cuốn", "Tên sách", "Ngày mượn", "Ngày trả", "Tình trạng", "Tiền phạt" };
                        foreach (var h in headers)
                        {
                            var cell = new PdfPCell(new Phrase(h, fontLabel))
                            {
                                BackgroundColor = new BaseColor(220, 220, 220),
                                HorizontalAlignment = Element.ALIGN_CENTER,
                                Padding = 5
                            };
                            table.AddCell(cell);
                        }

                        if (_chiTiet != null)
                        {
                            foreach (var ct in _chiTiet)
                            {
                                // Sử dụng chuỗi rỗng nếu giá trị null để tránh NullReferenceException
                                table.AddCell(new PdfPCell(new Phrase(ct.MaCuonSach ?? "", fontValue)));
                                table.AddCell(new PdfPCell(new Phrase(ct.TenSach ?? "", fontLabel)));
                                table.AddCell(new PdfPCell(new Phrase(ct.NgayMuon.ToString("dd/MM/yyyy"), fontLabel)));
                                table.AddCell(new PdfPCell(new Phrase(ct.NgayTraThucTe.ToString("dd/MM/yyyy"), fontLabel)));
                                table.AddCell(new PdfPCell(new Phrase(ct.TinhTrangTra ?? "", fontLabel)));
                                table.AddCell(new PdfPCell(new Phrase(ct.TienPhat.ToString("N0"), fontValue)));
                            }
                        }

                        doc.Add(table);
                        doc.Close();
                    }
                    MessageBox.Show("Xuất PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InitializeComponent()
        {
            Text = "Chi tiết phiếu trả";
            Width = 800; // Tăng width để hiển thị đủ cột
            Height = 550;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            var lblTitle = new Label { Text = "Thông tin phiếu trả", Left = 20, Top = 15, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold) };

            var lblMaTra = new Label { Text = "Mã phiếu trả:", Left = 20, Top = 50, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            lblMaPhieuTra = new Label { Left = 150, Top = 50, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold) };

            var lblMa = new Label { Text = "Mã phiếu mượn:", Left = 20, Top = 80, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            lblMaPhieu = new Label { Left = 150, Top = 80, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };

            var lblDG = new Label { Text = "Độc giả:", Left = 20, Top = 110, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            lblDocGia = new Label { Left = 150, Top = 110, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };

            var lblNgayT = new Label { Text = "Ngày trả:", Left = 20, Top = 140, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            lblNgayTra = new Label { Left = 150, Top = 140, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };

            var lblTong = new Label { Text = "Tổng sách trả:", Left = 20, Top = 170, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            lblTongSach = new Label { Left = 150, Top = 170, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };

            var lblPhat = new Label { Text = "Tiền phạt:", Left = 20, Top = 200, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            lblTongTienPhat = new Label { Left = 150, Top = 200, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };

            btnExportPdf = new Button { Text = "Xuất PDF", Left = 640, Top = 200, Width = 120, Height = 32 };
            btnExportPdf.Click += BtnExportPdf_Click;

            dgvChiTiet = new DataGridView
            {
                Left = 20,
                Top = 250,
                Width = 740,
                Height = 240,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = System.Drawing.Color.White
            };

            // Khởi tạo các cột và gán vào biến thành viên
            colMaCuon = new DataGridViewTextBoxColumn { HeaderText = "Mã cuốn", MinimumWidth = 80 };
            colTenSach = new DataGridViewTextBoxColumn { HeaderText = "Tên sách", MinimumWidth = 180 };
            colNgayMuon = new DataGridViewTextBoxColumn { HeaderText = "Ngày mượn", MinimumWidth = 90 };
            colNgayTra = new DataGridViewTextBoxColumn { HeaderText = "Ngày trả", MinimumWidth = 90 };
            colTinhTrangTra = new DataGridViewTextBoxColumn { HeaderText = "Tình trạng trả", MinimumWidth = 120 };
            colTienPhat = new DataGridViewTextBoxColumn { HeaderText = "Tiền phạt", MinimumWidth = 90 };

            dgvChiTiet.Columns.AddRange(colMaCuon, colTenSach, colNgayMuon, colNgayTra, colTinhTrangTra, colTienPhat);

            Controls.AddRange(new Control[] { lblTitle, lblMaTra, lblMaPhieuTra, lblMa, lblMaPhieu, lblDG, lblDocGia, lblNgayT, lblNgayTra, lblTong, lblTongSach, lblPhat, lblTongTienPhat, btnExportPdf, dgvChiTiet });
        }
    }
}