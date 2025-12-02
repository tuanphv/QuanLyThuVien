using BUS;
using DTO;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GUI.MuonTra
{
    public partial class FrmLapPhieuTra : Form
    {
        private PhieuMuonDTO? _phieuMuon;
        private BindingList<ChiTietPhieuMuonDTO> _chiTiet = new();
        public PhieuTraDTO? PhieuTra { get; private set; }

        public FrmLapPhieuTra(string? maPhieu = null)
        {
            InitializeComponent();
            Load += FrmLapPhieuTra_Load;
            if (!string.IsNullOrWhiteSpace(maPhieu))
            {
                txtMaPhieu.Text = maPhieu;
            }
        }

        private void FrmLapPhieuTra_Load(object? sender, EventArgs e)
        {
            dgvSach.AutoGenerateColumns = false;
            colMaCuon.DataPropertyName = nameof(ChiTietPhieuMuonDTO.MaCuonSach);
            colTenSach.DataPropertyName = nameof(ChiTietPhieuMuonDTO.TenSach);
            colHanTra.DataPropertyName = nameof(ChiTietPhieuMuonDTO.NgayTraDuKien);
            colNgayTra.DataPropertyName = nameof(ChiTietPhieuMuonDTO.NgayTraThucTe);
            colHanTra.DefaultCellStyle.Format = "dd/MM/yyyy";
            colNgayTra.DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void btnTaiPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                var phieu = MuonTraBUS.LayPhieuMuonTheoMa(txtMaPhieu.Text ?? string.Empty);
                if (phieu == null)
                {
                    MessageBox.Show("Không tìm thấy phiếu mượn.");
                    return;
                }
                _phieuMuon = phieu;
                lblDocGia.Text = $"{phieu.HoTenDocGia} ({phieu.MaDocGia})";
                lblNgayMuon.Text = phieu.NgayMuon.ToString("dd/MM/yyyy");
                lblHanTra.Text = phieu.NgayTraDuKien.ToString("dd/MM/yyyy");
                lblTinhTrang.Text = phieu.TinhTrang;

                _chiTiet = MuonTraBUS.LayChiTietPhieuMuon(phieu.ID);
                dgvSach.DataSource = _chiTiet;
                btnTaoPhieu.Enabled = _chiTiet.Any(c => !c.NgayTraThucTe.HasValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            if (_phieuMuon == null)
            {
                MessageBox.Show("Vui lòng nhập mã phiếu mượn.");
                return;
            }

            try
            {
                PhieuTra = MuonTraBUS.LapPhieuTra(_phieuMuon.MaPhieuMuon, out int tienPhat);
                _phieuMuon = MuonTraBUS.LayPhieuMuonTheoID(_phieuMuon.ID);
                lblTinhTrang.Text = _phieuMuon?.TinhTrang;
                lblThongTinPhat.Text = tienPhat > 0 ? $"Tiền phạt: {tienPhat:N0} đồng" : "Không có tiền phạt";
                btnTaoPhieu.Enabled = false;
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            Text = "Tạo phiếu trả";
            Width = 760;
            Height = 520;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            var lblTitle = new Label { Text = "Nhập mã phiếu mượn", Left = 20, Top = 20, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold) };
            txtMaPhieu = new TextBox { Left = 20, Top = 50, Width = 220, Font = new System.Drawing.Font("Segoe UI", 10F) };
            btnTaiPhieu = new Button { Text = "Tải phiếu", Left = 260, Top = 48, Width = 100, Height = 32, BackColor = System.Drawing.Color.RoyalBlue, ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };
            btnTaiPhieu.Click += btnTaiPhieu_Click;

            var group = new GroupBox { Text = "Thông tin phiếu", Left = 20, Top = 90, Width = 700, Height = 130 };
            var lblDG = new Label { Text = "Độc giả:", Left = 20, Top = 30, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            lblDocGia = new Label { Left = 110, Top = 30, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            var lblNgayM = new Label { Text = "Ngày mượn:", Left = 20, Top = 60, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            lblNgayMuon = new Label { Left = 110, Top = 60, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            var lblHan = new Label { Text = "Hạn trả:", Left = 20, Top = 90, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            lblHanTra = new Label { Left = 110, Top = 90, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            var lblTinh = new Label { Text = "Tình trạng:", Left = 400, Top = 30, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            lblTinhTrang = new Label { Left = 500, Top = 30, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            lblThongTinPhat = new Label { Left = 400, Top = 60, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold) };
            group.Controls.AddRange(new Control[] { lblDG, lblDocGia, lblNgayM, lblNgayMuon, lblHan, lblHanTra, lblTinh, lblTinhTrang, lblThongTinPhat });

            dgvSach = new DataGridView
            {
                Left = 20,
                Top = 240,
                Width = 700,
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
            dgvSach.Columns.AddRange(colMaCuon, colTenSach, colHanTra, colNgayTra);

            btnTaoPhieu = new Button { Text = "Tạo phiếu trả", Left = 560, Top = 450, Width = 160, Height = 32, BackColor = System.Drawing.Color.SeaGreen, ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat, Enabled = false };
            btnTaoPhieu.Click += btnTaoPhieu_Click;

            Controls.AddRange(new Control[] { lblTitle, txtMaPhieu, btnTaiPhieu, group, dgvSach, btnTaoPhieu });
        }

        private TextBox txtMaPhieu = null!;
        private Button btnTaiPhieu = null!;
        private Label lblDocGia = null!;
        private Label lblNgayMuon = null!;
        private Label lblHanTra = null!;
        private Label lblTinhTrang = null!;
        private Label lblThongTinPhat = null!;
        private DataGridView dgvSach = null!;
        private DataGridViewTextBoxColumn colMaCuon = null!;
        private DataGridViewTextBoxColumn colTenSach = null!;
        private DataGridViewTextBoxColumn colHanTra = null!;
        private DataGridViewTextBoxColumn colNgayTra = null!;
        private Button btnTaoPhieu = null!;
    }
}
