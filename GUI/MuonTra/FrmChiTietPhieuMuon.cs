using BUS;
using DTO;
using GUI.Helpers;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GUI.MuonTra
{
    public partial class FrmChiTietPhieuMuon : Form
    {
        private readonly PhieuMuonDTO _phieu;
        private BindingList<ChiTietPhieuMuonDTO> _chiTiet = new();

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
            colMaCuon.DataPropertyName = nameof(ChiTietPhieuMuonDTO.MaCuonSach);
            colTenSach.DataPropertyName = nameof(ChiTietPhieuMuonDTO.TenSach);
            colHanTra.DataPropertyName = nameof(ChiTietPhieuMuonDTO.NgayTraDuKien);
            colNgayTra.DataPropertyName = nameof(ChiTietPhieuMuonDTO.NgayTraThucTe);

            colHanTra.DefaultCellStyle.Format = "dd/MM/yyyy";
            colNgayTra.DefaultCellStyle.Format = "dd/MM/yyyy";

            _chiTiet = MuonTraBUS.LayChiTietPhieuMuon(_phieu.ID);
            dgvChiTiet.DataSource = _chiTiet;
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
            var confirm = MessageBox.Show("Xác nhận trả toàn bộ sách trong phiếu này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                var capNhat = MuonTraBUS.TraPhieuMuon(_phieu.ID, out int tienPhat);
                _phieu.NgayTraThucTe = capNhat.NgayTraThucTe;
                _phieu.SoSachChuaTra = capNhat.SoSachChuaTra;
                lblTinhTrang.Text = _phieu.TinhTrang;
                btnTraSach.Enabled = false;
                btnGiaHan.Enabled = false;

                _chiTiet = MuonTraBUS.LayChiTietPhieuMuon(_phieu.ID);
                dgvChiTiet.DataSource = _chiTiet;
                string message = "Trả sách thành công.";
                if (tienPhat > 0)
                {
                    message += $"\nTiền phạt: {tienPhat:N0} đồng.";
                }
                MessageBox.Show(message, "Thành công");
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

            dgvChiTiet = new DataGridView
            {
                Left = 20,
                Top = 220,
                Width = 660,
                Height = 200,
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
            dgvChiTiet.Columns.AddRange(colMaCuon, colTenSach, colHanTra, colNgayTra);

            btnGiaHan = new Button { Text = "Gia hạn", Left = 400, Top = 440, Width = 120, Height = 32, BackColor = System.Drawing.Color.DodgerBlue, ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };
            btnGiaHan.Click += btnGiaHan_Click;
            btnTraSach = new Button { Text = "Trả sách", Left = 540, Top = 440, Width = 120, Height = 32, BackColor = System.Drawing.Color.SeaGreen, ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };
            btnTraSach.Click += btnTraSach_Click;

            Controls.AddRange(new Control[] { lblTitle, lblMa, lblMaPhieu, lblDG, lblDocGia, lblNgayM, lblNgayMuon, lblHan, lblHanTra, lblTinh, lblTinhTrang, dgvChiTiet, btnGiaHan, btnTraSach });
        }

        private Label lblMaPhieu = null!;
        private Label lblDocGia = null!;
        private Label lblNgayMuon = null!;
        private Label lblHanTra = null!;
        private Label lblTinhTrang = null!;
        private DataGridView dgvChiTiet = null!;
        private DataGridViewTextBoxColumn colMaCuon = null!;
        private DataGridViewTextBoxColumn colTenSach = null!;
        private DataGridViewTextBoxColumn colHanTra = null!;
        private DataGridViewTextBoxColumn colNgayTra = null!;
        private Button btnGiaHan = null!;
        private Button btnTraSach = null!;
    }
}
