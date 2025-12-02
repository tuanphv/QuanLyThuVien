using BUS;
using DTO;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace GUI.MuonTra
{
    public partial class FrmChiTietPhieuTra : Form
    {
        private readonly PhieuTraDTO _phieu;
        private BindingList<ChiTietPhieuTraDTO> _chiTiet = new();

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

            Controls.AddRange(new Control[] { lblTitle, lblMa, lblMaPhieu, lblDG, lblDocGia, lblNgayT, lblNgayTra, lblTong, lblTongSach, lblPhat, lblTongTienPhat, dgvChiTiet });
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
