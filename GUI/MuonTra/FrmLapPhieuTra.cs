using BUS;
using DTO;
using System;
using System.Collections.Generic;
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
        private List<ThamSoPhatDTO> _allRules = new();

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
            try
            {
                _thamSo = MuonTraBUS.LayThamSoMuonTra();
                _allRules = ThamSoPhatBUS.LayTatCa();

                if (dgvSach == null) return;

                dgvSach.AutoGenerateColumns = false;

                // Map Data Properties with Null Checks
                if (colMaCuon != null) colMaCuon.DataPropertyName = nameof(ChiTietPhieuMuonDTO.MaCuonSach);
                if (colTenSach != null) colTenSach.DataPropertyName = nameof(ChiTietPhieuMuonDTO.TenSach);
                if (colHanTra != null)
                {
                    colHanTra.DataPropertyName = nameof(ChiTietPhieuMuonDTO.NgayTraDuKien);
                    colHanTra.DefaultCellStyle.Format = "dd/MM/yyyy";
                }
                if (colNgayTra != null)
                {
                    colNgayTra.DataPropertyName = nameof(ChiTietPhieuMuonDTO.NgayTraThucTe);
                    colNgayTra.DefaultCellStyle.Format = "dd/MM/yyyy";
                }
                if (colTinhTrangMuon != null) colTinhTrangMuon.DataPropertyName = nameof(ChiTietPhieuMuonDTO.TinhTrangMuon);
                if (colTrangThai != null) colTrangThai.DataPropertyName = nameof(ChiTietPhieuMuonDTO.TrangThai);
                if (colChonTra != null) colChonTra.DataPropertyName = nameof(ChiTietPhieuMuonDTO.ChonTra);
                if (colTinhTrangTra != null) colTinhTrangTra.DataPropertyName = nameof(ChiTietPhieuMuonDTO.TinhTrangTra);

                // Format Currency Column if exists and is accessible
                if (dgvSach.Columns.Contains("colTienPhat"))
                {
                    dgvSach.Columns["colTienPhat"].DataPropertyName = "TienPhat";
                    dgvSach.Columns["colTienPhat"].DefaultCellStyle.Format = "N0";
                }

                if (_khoiTaoSanChiTiet)
                {
                    txtMaPhieu.ReadOnly = true;
                    HienThiThongTinPhieu(_phieuMuon, _chiTiet);
                }

                // Subscribe events safely
                dgvSach.CellContentClick -= DgvSach_CellContentClick;
                dgvSach.CellContentClick += DgvSach_CellContentClick;

                dgvSach.CellValueChanged -= DgvSach_CellValueChanged;
                dgvSach.CellValueChanged += DgvSach_CellValueChanged;

                dgvSach.CurrentCellDirtyStateChanged -= DgvSach_CurrentCellDirtyStateChanged;
                dgvSach.CurrentCellDirtyStateChanged += DgvSach_CurrentCellDirtyStateChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải form: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvSach_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (dgvSach.IsCurrentCellDirty)
            {
                dgvSach.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DgvSach_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvSach.Columns.Contains("colBtnChonLoi") && e.ColumnIndex == dgvSach.Columns["colBtnChonLoi"].Index)
            {
                var item = dgvSach.Rows[e.RowIndex].DataBoundItem as ChiTietPhieuMuonDTO;
                if (item == null || item.DaTra) return;

                string currentIds = item.DanhSachIdLoiTra ?? item.DanhSachIdLoiMuon ?? "";

                using (var frm = new FrmChonTinhTrang(currentIds))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        item.DanhSachIdLoiTra = frm.SelectedIDs;
                        item.TinhTrangTra = frm.SelectedNames;

                        if (_thamSo != null)
                            MuonTraBUS.CapNhatTienPhatChiTiet(item, _thamSo, _allRules);

                        dgvSach.Refresh();
                        CapNhatThongTinPhat();
                    }
                }
            }
        }

        private void DgvSach_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var item = dgvSach.Rows[e.RowIndex].DataBoundItem as ChiTietPhieuMuonDTO;
            if (item == null) return;

            if (colChonTra != null && e.ColumnIndex == colChonTra.Index && item.ChonTra && string.IsNullOrEmpty(item.DanhSachIdLoiTra))
            {
                item.DanhSachIdLoiTra = item.DanhSachIdLoiMuon;
                item.TinhTrangTra = item.TinhTrangMuon;
                if (_thamSo != null)
                    MuonTraBUS.CapNhatTienPhatChiTiet(item, _thamSo, _allRules);
            }

            CapNhatThongTinPhat();
        }

        private void CapNhatThongTinPhat()
        {
            decimal tong = _chiTiet.Where(c => c.ChonTra && !c.DaTra).Sum(c => c.TienPhat);
            lblThongTinPhat.Text = tong > 0 ? $"Dự kiến tiền phạt: {tong:N0} đồng" : "Không có tiền phạt";
            btnTaoPhieu.Enabled = _chiTiet.Any(c => c.ChonTra && !c.DaTra);
        }

        private void btnTaiPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                var phieu = MuonTraBUS.LayPhieuMuonTheoMa(txtMaPhieu.Text ?? string.Empty);
                if (phieu == null) { MessageBox.Show("Không tìm thấy phiếu."); return; }
                HienThiThongTinPhieu(phieu, MuonTraBUS.LayChiTietPhieuMuon(phieu.ID));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            if (_phieuMuon == null) return;
            try
            {
                decimal tienPhat;
                PhieuTra = MuonTraBUS.LapPhieuTra(_phieuMuon.ID, _chiTiet, out tienPhat);

                _phieuMuon = MuonTraBUS.LayPhieuMuonTheoID(_phieuMuon.ID);
                if (_phieuMuon != null)
                {
                    HienThiThongTinPhieu(_phieuMuon, MuonTraBUS.LayChiTietPhieuMuon(_phieuMuon.ID));
                }

                lblThongTinPhat.Text = tienPhat > 0 ? $"Tổng phạt thực tế: {tienPhat:N0} đồng" : "Hoàn tất";
                MessageBox.Show("Tạo phiếu trả thành công!", "Thông báo");
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                if (!ct.DaTra)
                {
                    ct.DanhSachIdLoiTra = ct.DanhSachIdLoiMuon;
                    ct.TinhTrangTra = ct.TinhTrangMuon;
                }
                if (_thamSo != null)
                    MuonTraBUS.CapNhatTienPhatChiTiet(ct, _thamSo, _allRules);
            }

            _chiTiet = chiTiet;
            dgvSach.DataSource = _chiTiet;
            CapNhatThongTinPhat();
        }

        private void InitializeComponent()
        {
            Text = "Tạo phiếu trả"; Width = 900; Height = 550; StartPosition = FormStartPosition.CenterParent;

            var lblTitle = new Label { Text = "Trả sách & Tính phạt", Left = 20, Top = 20, Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold), AutoSize = true };
            txtMaPhieu = new TextBox { Left = 20, Top = 55, Width = 200 };
            btnTaiPhieu = new Button { Text = "Tìm", Left = 230, Top = 53, Width = 80, BackColor = System.Drawing.Color.RoyalBlue, ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };
            btnTaiPhieu.Click += btnTaiPhieu_Click;

            var grpInfo = new GroupBox { Text = "Thông tin", Left = 20, Top = 90, Width = 840, Height = 100 };
            lblDocGia = new Label { Left = 20, Top = 30, AutoSize = true };
            lblNgayMuon = new Label { Left = 300, Top = 30, AutoSize = true };
            lblHanTra = new Label { Left = 300, Top = 60, AutoSize = true };
            lblTinhTrang = new Label { Left = 550, Top = 30, AutoSize = true };
            lblThongTinPhat = new Label { Left = 550, Top = 60, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.Red };
            grpInfo.Controls.AddRange(new Control[] { lblDocGia, lblNgayMuon, lblHanTra, lblTinhTrang, lblThongTinPhat });

            dgvSach = new DataGridView { Left = 20, Top = 210, Width = 840, Height = 250, AutoGenerateColumns = false, AllowUserToAddRows = false, RowHeadersVisible = false };

            colChonTra = new DataGridViewCheckBoxColumn { HeaderText = "Trả", DataPropertyName = "ChonTra", Width = 50 };
            colMaCuon = new DataGridViewTextBoxColumn { HeaderText = "Mã sách", DataPropertyName = "MaCuonSach", Width = 100, ReadOnly = true };
            colTenSach = new DataGridViewTextBoxColumn { HeaderText = "Tên sách", DataPropertyName = "TenSach", Width = 200, ReadOnly = true };
            colHanTra = new DataGridViewTextBoxColumn { HeaderText = "Hạn trả", DataPropertyName = "NgayTraDuKien", Width = 100, ReadOnly = true };
            colTinhTrangMuon = new DataGridViewTextBoxColumn { HeaderText = "Lỗi lúc mượn", DataPropertyName = "TinhTrangMuon", Width = 150, ReadOnly = true };

            var colBtnChonLoi = new DataGridViewButtonColumn { Name = "colBtnChonLoi", HeaderText = "Tình trạng lúc trả", Text = "Chọn lỗi...", UseColumnTextForButtonValue = true, Width = 100 };

            colTinhTrangTra = new DataGridViewTextBoxColumn { HeaderText = "Ghi nhận", DataPropertyName = "TinhTrangTra", Width = 150, ReadOnly = true };
            var colTienPhat = new DataGridViewTextBoxColumn { Name = "colTienPhat", HeaderText = "Phạt", DataPropertyName = "TienPhat", Width = 100, ReadOnly = true };

            dgvSach.Columns.AddRange(colChonTra, colMaCuon, colTenSach, colHanTra, colTinhTrangMuon, colBtnChonLoi, colTinhTrangTra, colTienPhat);

            btnTaoPhieu = new Button { Text = "Hoàn tất trả sách", Left = 700, Top = 470, Width = 160, Height = 40, BackColor = System.Drawing.Color.SeaGreen, ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };
            btnTaoPhieu.Click += btnTaoPhieu_Click;

            Controls.AddRange(new Control[] { lblTitle, txtMaPhieu, btnTaiPhieu, grpInfo, dgvSach, btnTaoPhieu });
        }

        private TextBox txtMaPhieu = null!;
        private Button btnTaiPhieu = null!, btnTaoPhieu = null!;
        private Label lblDocGia = null!, lblNgayMuon = null!, lblHanTra = null!, lblTinhTrang = null!, lblThongTinPhat = null!;
        private DataGridView dgvSach = null!;
        private DataGridViewCheckBoxColumn colChonTra = null!;
        private DataGridViewTextBoxColumn colMaCuon = null!, colTenSach = null!, colHanTra = null!, colNgayTra = null!, colTinhTrangMuon = null!, colTinhTrangTra = null!, colTrangThai = null!;
    }
}