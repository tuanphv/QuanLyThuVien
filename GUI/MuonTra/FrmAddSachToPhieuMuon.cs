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
        private List<ThamSoPhatDTO> _thamSoPhat = new();

        private TextBox txtSearch = null!;
        private CheckedListBox clbTinhTrang = null!;
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
            _thamSoPhat = ThamSoPhatBUS.LayTatCa().ToList();
            clbTinhTrang.Items.Clear();
            foreach (var item in _thamSoPhat)
            {
                clbTinhTrang.Items.Add(item, false);
            }

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

            var danhSachChon = clbTinhTrang.CheckedItems.Cast<ThamSoPhatDTO>().ToList();
            string? tinhTrang = danhSachChon.Any()
                ? string.Join(", ", danhSachChon.Select(t => t.TenHienThi))
                : (cuon.TinhTrangHienTai ?? "Mới");
            int? idThamSoPhatMuon = danhSachChon.FirstOrDefault()?.ID;

            SachChon = new SachMuonLuaChonDTO
            {
                IDCuonSach = cuon.IDCuonSach,
                MaCuonSach = cuon.MaCuonSach,
                TenSach = cuon.TenSach,
                TacGia = cuon.TacGia,
                NhaXuatBan = cuon.NhaXuatBan,
                TinhTrangMuon = tinhTrang,
                TinhTrangHienTai = cuon.TinhTrangHienTai,
                IDThamSoPhatMuon = idThamSoPhatMuon
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

            clbTinhTrang = new CheckedListBox
            {
                Left = 220,
                Top = 440,
                Width = 300,
                Height = 70,
                Font = new System.Drawing.Font("Segoe UI", 10F),
                CheckOnClick = true
            };

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
                    clbTinhTrang.ItemCheck -= ClbTinhTrang_ItemCheck;
                    try
                    {
                        for (int i = 0; i < clbTinhTrang.Items.Count; i++)
                        {
                            clbTinhTrang.SetItemChecked(i, false);
                        }

                        bool daChonTheoMa = false;
                        if (cuon.IDThamSoPhatMuon.HasValue)
                        {
                            for (int i = 0; i < clbTinhTrang.Items.Count; i++)
                            {
                                if (clbTinhTrang.Items[i] is ThamSoPhatDTO thamSo && thamSo.ID == cuon.IDThamSoPhatMuon)
                                {
                                    clbTinhTrang.SetItemChecked(i, true);
                                    daChonTheoMa = true;
                                    break;
                                }
                            }
                        }

                        if (!daChonTheoMa && !string.IsNullOrWhiteSpace(cuon.TinhTrangHienTai))
                        {
                            for (int i = 0; i < clbTinhTrang.Items.Count; i++)
                            {
                                if (clbTinhTrang.Items[i] is ThamSoPhatDTO thamSo && thamSo.TenHienThi.Equals(cuon.TinhTrangHienTai, StringComparison.OrdinalIgnoreCase))
                                {
                                    clbTinhTrang.SetItemChecked(i, true);
                                    daChonTheoMa = true;
                                    break;
                                }
                            }
                        }

                        if (!daChonTheoMa)
                        {
                            for (int i = 0; i < clbTinhTrang.Items.Count; i++)
                            {
                                if (clbTinhTrang.Items[i] is ThamSoPhatDTO thamSo &&
                                    (thamSo.LoaiTinhTrang.Equals("MOI", StringComparison.OrdinalIgnoreCase) ||
                                     thamSo.TenHienThi.Equals("Mới", StringComparison.OrdinalIgnoreCase)))
                                {
                                    clbTinhTrang.SetItemChecked(i, true);
                                    break;
                                }
                            }
                        }
                    }
                    finally
                    {
                        clbTinhTrang.ItemCheck += ClbTinhTrang_ItemCheck;
                    }
                }
            };

            var colMaCuon = new DataGridViewTextBoxColumn { HeaderText = "Mã cuốn", DataPropertyName = nameof(SachMuonLuaChonDTO.MaCuonSach), MinimumWidth = 80 };
            var colTenSach = new DataGridViewTextBoxColumn { HeaderText = "Tên sách", DataPropertyName = nameof(SachMuonLuaChonDTO.TenSach), MinimumWidth = 160 };
            var colTacGia = new DataGridViewTextBoxColumn { HeaderText = "Tác giả", DataPropertyName = nameof(SachMuonLuaChonDTO.TacGia), MinimumWidth = 140 };
            var colNxb = new DataGridViewTextBoxColumn { HeaderText = "Nhà xuất bản", DataPropertyName = nameof(SachMuonLuaChonDTO.NhaXuatBan), MinimumWidth = 140 };
            var colTinhTrang = new DataGridViewTextBoxColumn { HeaderText = "Tình trạng hiện tại", DataPropertyName = nameof(SachMuonLuaChonDTO.TinhTrangHienTai), MinimumWidth = 150 };
            dgvCuonSach.Columns.AddRange(colMaCuon, colTenSach, colTacGia, colNxb, colTinhTrang);

            var lblTinhTrang = new Label { Text = "Tình trạng mượn", Left = 20, Top = 445, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            clbTinhTrang.ItemCheck += ClbTinhTrang_ItemCheck;

            var btnChon = new Button { Text = "Thêm vào phiếu", Left = 540, Top = 438, Width = 120, Height = 32, BackColor = System.Drawing.Color.SeaGreen, ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };
            btnChon.Click += (s, e) => ChonCuonSach();
            var btnHuy = new Button { Text = "Hủy", Left = 670, Top = 438, Width = 110, Height = 32, FlatStyle = FlatStyle.Flat };
            btnHuy.Click += (s, e) => Close();

            Controls.AddRange(new Control[] { lblSearch, txtSearch, btnSearch, dgvCuonSach, lblTinhTrang, clbTinhTrang, btnChon, btnHuy });
        }

        private void ClbTinhTrang_ItemCheck(object? sender, ItemCheckEventArgs e)
        {
            // No-op handler used to temporarily detach events when syncing selection.
        }
    }
}
