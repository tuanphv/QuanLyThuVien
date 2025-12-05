using BUS;
using DTO;
using System.ComponentModel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace GUI.MuonTra
{
    public partial class FrmChiTietPhieuTra : Form
    {
        private readonly PhieuTraDTO _phieu;
        private BindingList<ChiTietPhieuTraDTO> _chiTiet = new();
        private Button btnExportPdf = null!;

        public FrmChiTietPhieuTra(PhieuTraDTO phieu)
        {
            _phieu = phieu;
            InitializeComponent();
            Load += FrmChiTietPhieuTra_Load;
        }

        private void FrmChiTietPhieuTra_Load(object? sender, EventArgs e)
        {
            lblMaPhieu.Text = _phieu.MaPhieuMuon;
            lblDocGia.Text = $"{_phieu.HoTenDocGia} ({_phieu.MaDocGia})";
            lblNgayTra.Text = _phieu.NgayTra.ToString("dd/MM/yyyy");
            lblTongSach.Text = _phieu.TongSachTra.ToString();
            lblTongTienPhat.Text = _phieu.TongTienPhat.ToString("N0");

            dgvChiTiet.AutoGenerateColumns = false;
            colMaCuon.DataPropertyName = nameof(ChiTietPhieuTraDTO.MaCuonSach);
            colTenSach.DataPropertyName = nameof(ChiTietPhieuTraDTO.TenSach);
            colHanTra.DataPropertyName = nameof(ChiTietPhieuTraDTO.NgayTraDuKien);
            colNgayTra.DataPropertyName = nameof(ChiTietPhieuTraDTO.NgayTraThucTe);
            colSoNgayTre.DataPropertyName = nameof(ChiTietPhieuTraDTO.SoNgayTre);
            colTienPhat.DataPropertyName = nameof(ChiTietPhieuTraDTO.TienPhat);
            colHanTra.DefaultCellStyle.Format = "dd/MM/yyyy";
            colNgayTra.DefaultCellStyle.Format = "dd/MM/yyyy";

            _chiTiet = MuonTraBUS.LayChiTietPhieuTra(_phieu.IDPhieuMuon);
            dgvChiTiet.DataSource = _chiTiet;
        }

        private void InitializeComponent()
        {
            Text = "Chi tiết phiếu trả";
            Width = 760;
            Height = 520;
            StartPosition = FormStartPosition.CenterParent;

            var lblTitle = new Label { Text = "Thông tin phiếu trả", Left = 20, Top = 15, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold) };
            var lblMa = new Label { Text = "Mã phiếu mượn:", Left = 20, Top = 50, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            lblMaPhieu = new Label { Left = 150, Top = 50, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold) };
            var lblDG = new Label { Text = "Độc giả:", Left = 20, Top = 80, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            lblDocGia = new Label { Left = 150, Top = 80, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            var lblNgayT = new Label { Text = "Ngày trả:", Left = 20, Top = 110, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            lblNgayTra = new Label { Left = 150, Top = 110, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            var lblTong = new Label { Text = "Tổng sách trả:", Left = 20, Top = 140, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            lblTongSach = new Label { Left = 150, Top = 140, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            var lblPhat = new Label { Text = "Tiền phạt:", Left = 20, Top = 170, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            lblTongTienPhat = new Label { Left = 150, Top = 170, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold) };

            btnExportPdf = new Button { Text = "Xuất PDF", Left = 600, Top = 170, Width = 120, Height = 32 };
            btnExportPdf.Click += BtnExportPdf_Click;

            dgvChiTiet = new DataGridView
            {
                Left = 20,
                Top = 210,
                Width = 700,
                Height = 240,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            colMaCuon = new DataGridViewTextBoxColumn { HeaderText = "Mã cuốn", MinimumWidth = 80 };
            colTenSach = new DataGridViewTextBoxColumn { HeaderText = "Tên sách", MinimumWidth = 180 };
            colHanTra = new DataGridViewTextBoxColumn { HeaderText = "Hạn trả", MinimumWidth = 90 };
            colNgayTra = new DataGridViewTextBoxColumn { HeaderText = "Ngày trả", MinimumWidth = 90 };
            colSoNgayTre = new DataGridViewTextBoxColumn { HeaderText = "Số ngày trễ", MinimumWidth = 70 };
            colTienPhat = new DataGridViewTextBoxColumn { HeaderText = "Tiền phạt", MinimumWidth = 90 };
            dgvChiTiet.Columns.AddRange(colMaCuon, colTenSach, colHanTra, colNgayTra, colSoNgayTre, colTienPhat);

            Controls.AddRange(new Control[] { lblTitle, lblMa, lblMaPhieu, lblDG, lblDocGia, lblNgayT, lblNgayTra, lblTong, lblTongSach, lblPhat, lblTongTienPhat, btnExportPdf, dgvChiTiet });
        }

        private void BtnExportPdf_Click(object? sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF file|*.pdf";
                sfd.FileName = $"PhieuTra_{_phieu.MaPhieuMuon}.pdf";
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    using (var fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write))
                    {
                        var doc = new Document(PageSize.A4, 36, 36, 36, 36);
                        PdfWriter.GetInstance(doc, fs);
                        doc.Open();

                        string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");

                        BaseFont bf = BaseFont.CreateFont(
                            fontPath,
                            BaseFont.IDENTITY_H,
                            BaseFont.EMBEDDED
                        );

                        iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font fontLabel = new iTextSharp.text.Font(bf, 12);
                        iTextSharp.text.Font fontValue = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);

                        doc.Add(new Paragraph("PHIẾU TRẢ SÁCH", fontTitle) { Alignment = Element.ALIGN_CENTER });
                        doc.Add(new Paragraph("\n"));
                        doc.Add(new Paragraph($"Mã phiếu mượn: {_phieu.MaPhieuMuon}", fontLabel));
                        doc.Add(new Paragraph($"Độc giả: {_phieu.HoTenDocGia} ({_phieu.MaDocGia})", fontLabel));
                        doc.Add(new Paragraph($"Ngày trả: {_phieu.NgayTra:dd/MM/yyyy}", fontLabel));
                        doc.Add(new Paragraph($"Tổng sách trả: {_phieu.TongSachTra}", fontLabel));
                        doc.Add(new Paragraph($"Tổng tiền phạt: {_phieu.TongTienPhat:N0} đ", fontValue));
                        doc.Add(new Paragraph("\n"));

                        // Table for details
                        PdfPTable table = new PdfPTable(6) { WidthPercentage = 100 };
                        table.SetWidths(new float[] { 1.2f, 2.5f, 1.5f, 1.5f, 1.2f, 1.5f });
                        string[] headers = { "Mã cuốn", "Tên sách", "Hạn trả", "Ngày trả", "Số ngày trễ", "Tiền phạt" };
                        foreach (var h in headers)
                        {
                            var cell = new PdfPCell(new Phrase(h, fontLabel)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER };
                            table.AddCell(cell);
                        }
                        foreach (var ct in _chiTiet)
                        {
                            table.AddCell(new PdfPCell(new Phrase(ct.MaCuonSach, fontValue)));
                            table.AddCell(new PdfPCell(new Phrase(ct.TenSach, fontLabel)));
                            table.AddCell(new PdfPCell(new Phrase(ct.NgayTraDuKien.ToString("dd/MM/yyyy"), fontLabel)));
                            table.AddCell(new PdfPCell(new Phrase(ct.NgayTraThucTe.ToString("dd/MM/yyyy"), fontLabel)));
                            table.AddCell(new PdfPCell(new Phrase(ct.SoNgayTre.ToString(), fontLabel)));
                            table.AddCell(new PdfPCell(new Phrase(ct.TienPhat.ToString("N0"), fontValue)));
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

        private Label lblMaPhieu = null!;
        private Label lblDocGia = null!;
        private Label lblNgayTra = null!;
        private Label lblTongSach = null!;
        private Label lblTongTienPhat = null!;
        private DataGridView dgvChiTiet = null!;
        private DataGridViewTextBoxColumn colMaCuon = null!;
        private DataGridViewTextBoxColumn colTenSach = null!;
        private DataGridViewTextBoxColumn colHanTra = null!;
        private DataGridViewTextBoxColumn colNgayTra = null!;
        private DataGridViewTextBoxColumn colSoNgayTre = null!;
        private DataGridViewTextBoxColumn colTienPhat = null!;
    }
}
