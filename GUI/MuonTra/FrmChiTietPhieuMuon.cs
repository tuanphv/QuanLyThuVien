using BUS;
using DTO;
using GUI.Helpers;
using System.ComponentModel;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace GUI.MuonTra
{
    public partial class FrmChiTietPhieuMuon : Form
    {
        private readonly PhieuMuonDTO _phieu;
        private BindingList<ChiTietPhieuMuonDTO> _chiTiet = new();
        private Button btnExportPdf = null!;

        public PhieuMuonDTO PhieuCapNhat => _phieu;

        public FrmChiTietPhieuMuon(PhieuMuonDTO phieu)
        {
            _phieu = phieu;
            InitializeComponent();
            Load += FrmChiTietPhieuMuon_Load;
        }

        private void FrmChiTietPhieuMuon_Load(object? sender, EventArgs e)
        {
            lblMaPhieu.Text = _phieu.MaPhieuMuon;
            lblDocGia.Text = $"{_phieu.HoTenDocGia} ({_phieu.MaDocGia})";
            lblNgayMuon.Text = _phieu.NgayMuon.ToString("dd/MM/yyyy");
            lblHanTra.Text = _phieu.NgayTraDuKien.ToString("dd/MM/yyyy");
            lblTinhTrang.Text = _phieu.TinhTrang;

            dgvChiTiet.AutoGenerateColumns = false;
            colChonTra.DataPropertyName = nameof(ChiTietPhieuMuonDTO.ChonTra);
            colMaCuon.DataPropertyName = nameof(ChiTietPhieuMuonDTO.MaCuonSach);
            colTenSach.DataPropertyName = nameof(ChiTietPhieuMuonDTO.TenSach);
            colNgayMuon.DataPropertyName = nameof(ChiTietPhieuMuonDTO.NgayMuon);
            colNgayTra.DataPropertyName = nameof(ChiTietPhieuMuonDTO.NgayTraThucTe);
            colTinhTrangMuon.DataPropertyName = nameof(ChiTietPhieuMuonDTO.TinhTrangMuon);
            colTrangThai.DataPropertyName = nameof(ChiTietPhieuMuonDTO.TrangThai);

            colNgayMuon.DefaultCellStyle.Format = "dd/MM/yyyy";
            colNgayTra.DefaultCellStyle.Format = "dd/MM/yyyy";

            _chiTiet = MuonTraBUS.LayChiTietPhieuMuon(_phieu.ID);
            foreach (var ct in _chiTiet)
            {
                ct.ChonTra = !ct.DaTra;
            }
            dgvChiTiet.DataSource = _chiTiet;
            dgvChiTiet.CurrentCellDirtyStateChanged += (s, args) =>
            {
                if (dgvChiTiet.IsCurrentCellDirty)
                {
                    dgvChiTiet.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            };
            btnTraSach.Enabled = _chiTiet.Any(c => !c.NgayTraThucTe.HasValue);
            btnGiaHan.Enabled = btnTraSach.Enabled;

            bool isReader = SessionManager.CurrentUser?.TenNhomNguoiDung?.Equals("Độc Giả", StringComparison.OrdinalIgnoreCase) == true;
            if (isReader)
            {
                btnGiaHan.Visible = false;
                btnTraSach.Left = btnGiaHan.Left;
            }
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            using var frm = new FrmGiaHanPhieuMuon(_phieu);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                lblHanTra.Text = _phieu.NgayTraDuKien.ToString("dd/MM/yyyy");
            }
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            var danhSachTra = _chiTiet.Where(c => c.ChonTra && !c.DaTra).ToList();
            if (danhSachTra.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một cuốn sách đang mượn để trả.");
                return;
            }

            try
            {
                using var frm = new FrmLapPhieuTra(_phieu, danhSachTra);
                if (frm.ShowDialog() == DialogResult.OK && frm.PhieuTra != null)
                {
                    var capNhat = MuonTraBUS.LayPhieuMuonTheoID(_phieu.ID);
                    if (capNhat != null)
                    {
                        _phieu.NgayTraThucTe = capNhat.NgayTraThucTe;
                        _phieu.SoSachChuaTra = capNhat.SoSachChuaTra;
                        lblTinhTrang.Text = _phieu.TinhTrang;
                    }

                    _chiTiet = MuonTraBUS.LayChiTietPhieuMuon(_phieu.ID);
                    foreach (var ct in _chiTiet)
                    {
                        ct.ChonTra = !ct.DaTra;
                    }
                    dgvChiTiet.DataSource = _chiTiet;
                    btnTraSach.Enabled = _chiTiet.Any(c => !c.NgayTraThucTe.HasValue);
                    btnGiaHan.Enabled = btnTraSach.Enabled;

                    string message = "Trả sách thành công.";
                    if (frm.PhieuTra.TongTienPhat > 0)
                    {
                        message += $"\nTiền phạt: {frm.PhieuTra.TongTienPhat:N0} đồng.";
                    }
                    MessageBox.Show(message, "Thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            Text = "Chi tiết phiếu mượn";
            Width = 720;
            Height = 520;
            StartPosition = FormStartPosition.CenterParent;

            var lblTitle = new Label { Text = "Thông tin phiếu mượn", Left = 20, Top = 15, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold) };
            var lblMa = new Label { Text = "Mã phiếu:", Left = 20, Top = 60, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            lblMaPhieu = new Label { Left = 110, Top = 60, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold) };
            var lblDG = new Label { Text = "Độc giả:", Left = 20, Top = 90, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            lblDocGia = new Label { Left = 110, Top = 90, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            var lblNgayM = new Label { Text = "Ngày mượn:", Left = 20, Top = 120, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            lblNgayMuon = new Label { Left = 110, Top = 120, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            var lblHan = new Label { Text = "Hạn trả:", Left = 20, Top = 150, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            lblHanTra = new Label { Left = 110, Top = 150, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold) };
            var lblTinh = new Label { Text = "Tình trạng:", Left = 20, Top = 180, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            lblTinhTrang = new Label { Left = 110, Top = 180, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };

            btnExportPdf = new Button { Text = "Xuất PDF", Left = 560, Top = 170, Width = 120, Height = 32 };
            btnExportPdf.Click += BtnExportPdf_Click;

            dgvChiTiet = new DataGridView
            {
                Left = 20,
                Top = 220,
                Width = 660,
                Height = 200,
                ReadOnly = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            colChonTra = new DataGridViewCheckBoxColumn { HeaderText = "Chọn", MinimumWidth = 60 };
            colMaCuon = new DataGridViewTextBoxColumn { HeaderText = "Mã cuốn", MinimumWidth = 80, ReadOnly = true };
            colTenSach = new DataGridViewTextBoxColumn { HeaderText = "Tên sách", MinimumWidth = 180, ReadOnly = true };
            colNgayMuon = new DataGridViewTextBoxColumn { HeaderText = "Ngày mượn", MinimumWidth = 100, ReadOnly = true };
            colNgayTra = new DataGridViewTextBoxColumn { HeaderText = "Ngày trả", MinimumWidth = 100, ReadOnly = true };
            colTinhTrangMuon = new DataGridViewTextBoxColumn { HeaderText = "Tình trạng mượn", MinimumWidth = 120, ReadOnly = true };
            colTrangThai = new DataGridViewTextBoxColumn { HeaderText = "Trạng thái", MinimumWidth = 100, ReadOnly = true };
            dgvChiTiet.Columns.AddRange(colChonTra, colMaCuon, colTenSach, colNgayMuon, colNgayTra, colTrangThai, colTinhTrangMuon);

            btnGiaHan = new Button { Text = "Gia hạn", Left = 400, Top = 440, Width = 120, Height = 32, BackColor = System.Drawing.Color.DodgerBlue, ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };
            btnGiaHan.Click += btnGiaHan_Click;
            btnTraSach = new Button { Text = "Trả sách", Left = 540, Top = 440, Width = 120, Height = 32, BackColor = System.Drawing.Color.SeaGreen, ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };
            btnTraSach.Click += btnTraSach_Click;

            Controls.AddRange(new Control[] { lblTitle, lblMa, lblMaPhieu, lblDG, lblDocGia, lblNgayM, lblNgayMuon, lblHan, lblHanTra, lblTinh, lblTinhTrang, btnExportPdf, dgvChiTiet, btnGiaHan, btnTraSach });
        }
                    private void BtnExportPdf_Click(object? sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF file|*.pdf";
                sfd.FileName = $"PhieuMuon_{_phieu.MaPhieuMuon}.pdf";
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

                        doc.Add(new Paragraph("PHIẾU MƯỢN SÁCH", fontTitle) { Alignment = Element.ALIGN_CENTER });
                        doc.Add(new Paragraph("\n"));
                        doc.Add(new Paragraph($"Mã phiếu mượn: {_phieu.MaPhieuMuon}", fontLabel));
                        doc.Add(new Paragraph($"Độc giả: {_phieu.HoTenDocGia} ({_phieu.MaDocGia})", fontLabel));
                        doc.Add(new Paragraph($"Ngày mượn: {_phieu.NgayMuon:dd/MM/yyyy}", fontLabel));
                        doc.Add(new Paragraph($"Hạn trả: {_phieu.NgayTraDuKien:dd/MM/yyyy}", fontLabel));
                        doc.Add(new Paragraph($"Tổng sách: {_phieu.TongSach}", fontValue));
                        doc.Add(new Paragraph($"Tình trạng: {_phieu.TinhTrang}", fontLabel));
                        doc.Add(new Paragraph("\n"));

                        // Table for details
                        PdfPTable table = new PdfPTable(6) { WidthPercentage = 100 };
                        table.SetWidths(new float[] { 1.2f, 2.5f, 1.3f, 1.3f, 1.3f, 2f });
                        string[] headers = { "Mã cuốn", "Tên sách", "Ngày mượn", "Ngày trả", "Trạng thái", "Tình trạng mượn" };
                        foreach (var h in headers)
                        {
                            var cell = new PdfPCell(new Phrase(h, fontLabel)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER };
                            table.AddCell(cell);
                        }
                        foreach (var ct in _chiTiet)
                        {
                            table.AddCell(new PdfPCell(new Phrase(ct.MaCuonSach, fontValue)));
                            table.AddCell(new PdfPCell(new Phrase(ct.TenSach, fontLabel)));
                            table.AddCell(new PdfPCell(new Phrase(ct.NgayMuon.ToString("dd/MM/yyyy"), fontLabel)));
                            table.AddCell(new PdfPCell(
                                new Phrase(
                                    ct.NgayTraThucTe.HasValue
                                        ? ct.NgayTraThucTe.Value.ToString("dd/MM/yyyy")
                                        : string.Empty,
                                    fontLabel
                                )
                            ));
                            table.AddCell(new PdfPCell(new Phrase(ct.TrangThai, fontLabel)));
                            table.AddCell(new PdfPCell(new Phrase(ct.TinhTrangMuon ?? string.Empty, fontLabel)));

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
        private Label lblNgayMuon = null!;
        private Label lblHanTra = null!;
        private Label lblTinhTrang = null!;
        private DataGridView dgvChiTiet = null!;
        private DataGridViewCheckBoxColumn colChonTra = null!;
        private DataGridViewTextBoxColumn colMaCuon = null!;
        private DataGridViewTextBoxColumn colTenSach = null!;
        private DataGridViewTextBoxColumn colNgayMuon = null!;
        private DataGridViewTextBoxColumn colNgayTra = null!;
        private DataGridViewTextBoxColumn colTinhTrangMuon = null!;
        private DataGridViewTextBoxColumn colTrangThai = null!;
        private Button btnGiaHan = null!;
        private Button btnTraSach = null!;
    }
}
