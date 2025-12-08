using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GUI.MuonTra
{
    public class FrmAddSachToPhieuMuon : Form
    {
        private readonly HashSet<string> _maDaChon;
        private BindingList<SachMuonLuaChonDTO> _danhSach = new();

        private TextBox txtSearch = null!;
        private TextBox txtTinhTrang = null!;
        private DataGridView dgvCuonSach = null!;

        public SachMuonLuaChonDTO? SachChon { get; private set; }

        public FrmAddSachToPhieuMuon(IEnumerable<string> maDaChon)
        {
            _maDaChon = new HashSet<string>(maDaChon ?? Array.Empty<string>(), StringComparer.OrdinalIgnoreCase);
            InitializeComponent();
            Load += FrmAddSachToPhieuMuon_Load;
        }

        private void FrmAddSachToPhieuMuon_Load(object? sender, EventArgs e)
        {
            TaiDanhSach();
        }

        private void TaiDanhSach()
        {
            _danhSach = MuonTraBUS.TimCuonSachSanSang(txtSearch.Text?.Trim() ?? string.Empty, _maDaChon);
            dgvCuonSach.DataSource = _danhSach;
        }

        private void ChonCuonSach()
        {
            if (dgvCuonSach.CurrentRow?.DataBoundItem is not SachMuonLuaChonDTO cuon)
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách trong danh sách.");
                return;
            }

            string tinhTrang = string.IsNullOrWhiteSpace(txtTinhTrang.Text)
                ? cuon.TinhTrangHienTai ?? "Bình thường"
                : txtTinhTrang.Text.Trim();

            SachChon = new SachMuonLuaChonDTO
            {
                IDCuonSach = cuon.IDCuonSach,
                MaCuonSach = cuon.MaCuonSach,
                TenSach = cuon.TenSach,
                TacGia = cuon.TacGia,
                NhaXuatBan = cuon.NhaXuatBan,
                TinhTrangMuon = tinhTrang,
                TinhTrangHienTai = cuon.TinhTrangHienTai
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void InitializeComponent()
        {
            Text = "Chọn sách để mượn";
            Width = 820;
            Height = 540;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            var lblSearch = new Label { Text = "Tìm kiếm (mã hoặc tên sách)", Left = 20, Top = 20, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            txtSearch = new TextBox { Left = 20, Top = 45, Width = 260, Font = new System.Drawing.Font("Segoe UI", 10F) };
            var btnSearch = new Button { Text = "Tìm", Left = 300, Top = 43, Width = 80, Height = 30, BackColor = System.Drawing.Color.RoyalBlue, ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };
            btnSearch.Click += (s, e) => TaiDanhSach();

            dgvCuonSach = new DataGridView
            {
                Left = 20,
                Top = 90,
                Width = 760,
                Height = 340,
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            dgvCuonSach.CellDoubleClick += (s, e) => ChonCuonSach();
            dgvCuonSach.SelectionChanged += (s, e) =>
            {
                if (dgvCuonSach.CurrentRow?.DataBoundItem is SachMuonLuaChonDTO cuon)
                {
                    txtTinhTrang.Text = cuon.TinhTrangHienTai ?? txtTinhTrang.Text;
                }
            };

            var colMaCuon = new DataGridViewTextBoxColumn { HeaderText = "Mã cuốn", DataPropertyName = nameof(SachMuonLuaChonDTO.MaCuonSach), MinimumWidth = 80 };
            var colTenSach = new DataGridViewTextBoxColumn { HeaderText = "Tên sách", DataPropertyName = nameof(SachMuonLuaChonDTO.TenSach), MinimumWidth = 160 };
            var colTacGia = new DataGridViewTextBoxColumn { HeaderText = "Tác giả", DataPropertyName = nameof(SachMuonLuaChonDTO.TacGia), MinimumWidth = 140 };
            var colNxb = new DataGridViewTextBoxColumn { HeaderText = "Nhà xuất bản", DataPropertyName = nameof(SachMuonLuaChonDTO.NhaXuatBan), MinimumWidth = 140 };
            var colTinhTrang = new DataGridViewTextBoxColumn { HeaderText = "Tình trạng hiện tại", DataPropertyName = nameof(SachMuonLuaChonDTO.TinhTrangHienTai), MinimumWidth = 150 };
            dgvCuonSach.Columns.AddRange(colMaCuon, colTenSach, colTacGia, colNxb, colTinhTrang);

            var lblTinhTrang = new Label { Text = "Ghi chú tình trạng khi mượn", Left = 20, Top = 445, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            txtTinhTrang = new TextBox { Left = 220, Top = 440, Width = 300, Font = new System.Drawing.Font("Segoe UI", 10F) };

            var btnChon = new Button { Text = "Thêm vào phiếu", Left = 540, Top = 438, Width = 120, Height = 32, BackColor = System.Drawing.Color.SeaGreen, ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };
            btnChon.Click += (s, e) => ChonCuonSach();
            var btnHuy = new Button { Text = "Hủy", Left = 670, Top = 438, Width = 110, Height = 32, FlatStyle = FlatStyle.Flat };
            btnHuy.Click += (s, e) => Close();

            Controls.AddRange(new Control[] { lblSearch, txtSearch, btnSearch, dgvCuonSach, lblTinhTrang, txtTinhTrang, btnChon, btnHuy });
        }
    }
}
