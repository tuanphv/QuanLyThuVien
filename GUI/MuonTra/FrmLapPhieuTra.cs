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
        private readonly bool _khoiTaoSanChiTiet;
        private ThamSoMuonTraDTO? _thamSo;
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

        public FrmLapPhieuTra(PhieuMuonDTO phieuMuon, IEnumerable<ChiTietPhieuMuonDTO> chiTietChon) : this(phieuMuon.MaPhieuMuon)
        {
            _phieuMuon = phieuMuon;
            _chiTiet = new BindingList<ChiTietPhieuMuonDTO>(chiTietChon.ToList());
            _khoiTaoSanChiTiet = true;
        }

        private void FrmLapPhieuTra_Load(object? sender, EventArgs e)
        {
            _thamSo = MuonTraBUS.LayThamSoMuonTra();

            dgvSach.AutoGenerateColumns = false;
            colMaCuon.DataPropertyName = nameof(ChiTietPhieuMuonDTO.MaCuonSach);
            colTenSach.DataPropertyName = nameof(ChiTietPhieuMuonDTO.TenSach);
            colHanTra.DataPropertyName = nameof(ChiTietPhieuMuonDTO.NgayTraDuKien);
            colNgayTra.DataPropertyName = nameof(ChiTietPhieuMuonDTO.NgayTraThucTe);
            colTinhTrangMuon.DataPropertyName = nameof(ChiTietPhieuMuonDTO.TinhTrangMuon);
            colTinhTrangTra.DataPropertyName = nameof(ChiTietPhieuMuonDTO.TinhTrangTra);
            colTrangThai.DataPropertyName = nameof(ChiTietPhieuMuonDTO.TrangThai);
            colChonTra.DataPropertyName = nameof(ChiTietPhieuMuonDTO.ChonTra);
            colHanTra.DefaultCellStyle.Format = "dd/MM/yyyy";
            colNgayTra.DefaultCellStyle.Format = "dd/MM/yyyy";

            if (_khoiTaoSanChiTiet)
            {
                txtMaPhieu.ReadOnly = true;
                HienThiThongTinPhieu(_phieuMuon, _chiTiet);
            }

            dgvSach.CellValueChanged += DgvSach_CellValueChanged;
            dgvSach.CellBeginEdit += DgvSach_CellBeginEdit;
            dgvSach.CurrentCellDirtyStateChanged += (s, args) =>
            {
                if (dgvSach.IsCurrentCellDirty)
                {
                    dgvSach.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            };
        }

        private void DgvSach_CellBeginEdit(object? sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvSach.Rows.Count) return;
            var item = dgvSach.Rows[e.RowIndex].DataBoundItem as ChiTietPhieuMuonDTO;
            if (item?.DaTra == true)
            {
                e.Cancel = true;
            }
        }

        private void DgvSach_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvSach.Rows.Count) return;
            if (_thamSo == null) return;
            var item = dgvSach.Rows[e.RowIndex].DataBoundItem as ChiTietPhieuMuonDTO;
            if (item == null) return;
            CapNhatTienPhat(item);
            CapNhatThongTinPhat();
            btnTaoPhieu.Enabled = _chiTiet.Any(c => !c.NgayTraThucTe.HasValue);
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
                var chiTiet = MuonTraBUS.LayChiTietPhieuMuon(phieu.ID);
                HienThiThongTinPhieu(phieu, chiTiet);
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
                PhieuTra = MuonTraBUS.LapPhieuTra(_phieuMuon.ID, _chiTiet, out int tienPhat);
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

        private void HienThiThongTinPhieu(PhieuMuonDTO? phieu, BindingList<ChiTietPhieuMuonDTO> chiTiet)
        {
            if (phieu == null) return;

            _phieuMuon = phieu;
            lblDocGia.Text = $"{phieu.HoTenDocGia} ({phieu.MaDocGia})";
            lblNgayMuon.Text = phieu.NgayMuon.ToString("dd/MM/yyyy");
            lblHanTra.Text = phieu.NgayTraDuKien.ToString("dd/MM/yyyy");
            lblTinhTrang.Text = phieu.TinhTrang;

            foreach (var ct in chiTiet)
            {
                ct.ChonTra = !ct.DaTra;
                CapNhatTienPhat(ct);
            }

            _chiTiet = chiTiet;
            dgvSach.DataSource = _chiTiet;
            CapNhatThongTinPhat();
            btnTaoPhieu.Enabled = _chiTiet.Any(c => c.ChonTra && !c.NgayTraThucTe.HasValue);
        }

        private void CapNhatTienPhat(ChiTietPhieuMuonDTO chiTiet)
        {
            if (_thamSo == null) return;
            int soNgayTre = Math.Max(0, (DateTime.Today.Date - chiTiet.NgayTraDuKien.Date).Days);
            chiTiet.SoNgayTre = soNgayTre;
            int phatTreHen = soNgayTre * _thamSo.DonGiaPhatMoiNgay;
            int mucPhat = chiTiet.MucPhatTra ?? chiTiet.MucPhatMuon ?? 0;
            int phatHuHong = (chiTiet.DonGia * mucPhat) / 100;
            chiTiet.TienPhat = phatTreHen + phatHuHong;
        }

        private void CapNhatThongTinPhat()
        {
            int tong = _chiTiet.Where(c => c.ChonTra && !c.DaTra).Sum(c => c.TienPhat);
            lblThongTinPhat.Text = tong > 0 ? $"Dự kiến tiền phạt: {tong:N0} đồng" : "Không có tiền phạt";
            btnTaoPhieu.Enabled = _chiTiet.Any(c => c.ChonTra && !c.DaTra);
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
                ReadOnly = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            colChonTra = new DataGridViewCheckBoxColumn { HeaderText = "Chọn trả", MinimumWidth = 70 };
            colMaCuon = new DataGridViewTextBoxColumn { HeaderText = "Mã cuốn", MinimumWidth = 80, ReadOnly = true };
            colTenSach = new DataGridViewTextBoxColumn { HeaderText = "Tên sách", MinimumWidth = 180, ReadOnly = true };
            colHanTra = new DataGridViewTextBoxColumn { HeaderText = "Hạn trả", MinimumWidth = 90, ReadOnly = true };
            colNgayTra = new DataGridViewTextBoxColumn { HeaderText = "Ngày trả", MinimumWidth = 90, ReadOnly = true };
            colTinhTrangMuon = new DataGridViewTextBoxColumn { HeaderText = "Tình trạng mượn", MinimumWidth = 120, ReadOnly = true };
            colTinhTrangTra = new DataGridViewTextBoxColumn { HeaderText = "Tình trạng trả", MinimumWidth = 150 };
            colTrangThai = new DataGridViewTextBoxColumn { HeaderText = "Trạng thái", MinimumWidth = 90, ReadOnly = true };
            dgvSach.Columns.AddRange(colChonTra, colMaCuon, colTenSach, colHanTra, colNgayTra, colTinhTrangMuon, colTinhTrangTra, colTrangThai);

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
        private DataGridViewCheckBoxColumn colChonTra = null!;
        private DataGridViewTextBoxColumn colMaCuon = null!;
        private DataGridViewTextBoxColumn colTenSach = null!;
        private DataGridViewTextBoxColumn colHanTra = null!;
        private DataGridViewTextBoxColumn colNgayTra = null!;
        private DataGridViewTextBoxColumn colTinhTrangMuon = null!;
        private DataGridViewTextBoxColumn colTinhTrangTra = null!;
        private DataGridViewTextBoxColumn colTrangThai = null!;
        private Button btnTaoPhieu = null!;
    }
}
