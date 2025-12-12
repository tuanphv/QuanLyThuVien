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

        // Cờ để tránh vòng lặp vô tận khi set check trong event
        private bool _isUpdatingCheck = false;

        public SachMuonLuaChonDTO? SachChon { get; private set; }

        public FrmAddSachToPhieuMuon(IEnumerable<string> maDaChon)
        {
            _maDaChon = new HashSet<string>(maDaChon ?? Array.Empty<string>(), StringComparer.OrdinalIgnoreCase);
            InitializeComponent();
            Load += FrmAddSachToPhieuMuon_Load;
        }

        private void FrmAddSachToPhieuMuon_Load(object? sender, EventArgs e)
        {
            _thamSoPhat = ThamSoPhatBUS.LayTatCa();
            clbTinhTrang.Items.Clear();
            foreach (var item in _thamSoPhat)
            {
                string hienThi = item.MucPhatPhanTram > 0
                    ? $"{item.TenQuyDinh} (Phạt {item.MucPhatPhanTram}%)"
                    : item.TenQuyDinh;
                clbTinhTrang.Items.Add(item, false);
            }
            clbTinhTrang.DisplayMember = nameof(ThamSoPhatDTO.TenHienThi);

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
            string tinhTrangHienThi;
            string? danhSachIdLoi = null;

            if (danhSachChon.Any())
            {
                tinhTrangHienThi = string.Join(", ", danhSachChon.Select(t => t.TenQuyDinh));
                danhSachIdLoi = string.Join(",", danhSachChon.Select(t => t.ID));
            }
            else
            {
                tinhTrangHienThi = cuon.TinhTrangHienTai ?? "Mới nguyên";
                danhSachIdLoi = null;
            }

            SachChon = new SachMuonLuaChonDTO
            {
                IDCuonSach = cuon.IDCuonSach,
                MaCuonSach = cuon.MaCuonSach,
                TenSach = cuon.TenSach,
                TacGia = cuon.TacGia,
                NhaXuatBan = cuon.NhaXuatBan,
                TinhTrangMuon = tinhTrangHienThi,
                TinhTrangHienTai = cuon.TinhTrangHienTai,
                DanhSachLoiMoi = danhSachIdLoi
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        // --- LOGIC XỬ LÝ CHECKBOX ---
        private void ClbTinhTrang_ItemCheck(object? sender, ItemCheckEventArgs e)
        {
            // Nếu đang update tự động thì bỏ qua để tránh loop
            if (_isUpdatingCheck) return;

            // Chỉ xử lý khi người dùng TICK CHỌN (Checked)
            if (e.NewValue != CheckState.Checked) return;

            var currentItem = clbTinhTrang.Items[e.Index] as ThamSoPhatDTO;
            if (currentItem == null) return;

            _isUpdatingCheck = true; // Bật cờ

            // 1. Nếu chọn "Mới" hoặc "Mất" (Duy Nhất) -> Bỏ chọn tất cả cái khác
            if (currentItem.CoLaDuyNhat)
            {
                for (int i = 0; i < clbTinhTrang.Items.Count; i++)
                {
                    if (i != e.Index) clbTinhTrang.SetItemChecked(i, false);
                }
            }
            else
            {
                // 2. Nếu chọn lỗi thường -> Bỏ chọn các lỗi Duy Nhất (Mới/Mất)
                for (int i = 0; i < clbTinhTrang.Items.Count; i++)
                {
                    var item = clbTinhTrang.Items[i] as ThamSoPhatDTO;
                    if (item != null && item.CoLaDuyNhat)
                    {
                        clbTinhTrang.SetItemChecked(i, false);
                    }
                }

                // 3. Xử lý nhóm (Cùng nhóm thì loại trừ nhau)
                if (!string.IsNullOrEmpty(currentItem.NhomTinhTrang))
                {
                    for (int i = 0; i < clbTinhTrang.Items.Count; i++)
                    {
                        if (i == e.Index) continue;

                        var item = clbTinhTrang.Items[i] as ThamSoPhatDTO;
                        // Nếu item kia cùng nhóm với item đang chọn -> Bỏ check
                        if (item != null && item.NhomTinhTrang == currentItem.NhomTinhTrang)
                        {
                            if (clbTinhTrang.GetItemChecked(i))
                            {
                                clbTinhTrang.SetItemChecked(i, false);
                            }
                        }
                    }
                }
            }

            _isUpdatingCheck = false; // Tắt cờ
        }

        private void InitializeComponent()
        {
            Text = "Chọn sách để mượn";
            Width = 850;
            Height = 560;
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
                Width = 350,
                Height = 70,
                Font = new System.Drawing.Font("Segoe UI", 10F),
                CheckOnClick = true
            };

            // Đăng ký sự kiện
            clbTinhTrang.ItemCheck += ClbTinhTrang_ItemCheck;

            dgvCuonSach = new DataGridView
            {
                Left = 20,
                Top = 90,
                Width = 790,
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
                if (dgvCuonSach.CurrentRow != null)
                {
                    // Reset checkbox khi chọn sách khác
                    _isUpdatingCheck = true;
                    for (int i = 0; i < clbTinhTrang.Items.Count; i++)
                        clbTinhTrang.SetItemChecked(i, false);
                    _isUpdatingCheck = false;
                }
            };

            var colMaCuon = new DataGridViewTextBoxColumn { HeaderText = "Mã cuốn", DataPropertyName = nameof(SachMuonLuaChonDTO.MaCuonSach), MinimumWidth = 80 };
            var colTenSach = new DataGridViewTextBoxColumn { HeaderText = "Tên sách", DataPropertyName = nameof(SachMuonLuaChonDTO.TenSach), MinimumWidth = 160 };
            var colTacGia = new DataGridViewTextBoxColumn { HeaderText = "Tác giả", DataPropertyName = nameof(SachMuonLuaChonDTO.TacGia), MinimumWidth = 140 };
            var colNxb = new DataGridViewTextBoxColumn { HeaderText = "Nhà xuất bản", DataPropertyName = nameof(SachMuonLuaChonDTO.NhaXuatBan), MinimumWidth = 140 };
            var colTinhTrang = new DataGridViewTextBoxColumn { HeaderText = "Tình trạng", DataPropertyName = nameof(SachMuonLuaChonDTO.TinhTrangHienTai), MinimumWidth = 150 };
            dgvCuonSach.Columns.AddRange(colMaCuon, colTenSach, colTacGia, colNxb, colTinhTrang);

            var lblTinhTrang = new Label { Text = "Tình trạng lúc mươn", Left = 20, Top = 445, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };

            var btnChon = new Button { Text = "Thêm vào phiếu", Left = 580, Top = 438, Width = 120, Height = 32, BackColor = System.Drawing.Color.SeaGreen, ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };
            btnChon.Click += (s, e) => ChonCuonSach();
            var btnHuy = new Button { Text = "Hủy", Left = 710, Top = 438, Width = 100, Height = 32, FlatStyle = FlatStyle.Flat };
            btnHuy.Click += (s, e) => Close();

            Controls.AddRange(new Control[] { lblSearch, txtSearch, btnSearch, dgvCuonSach, lblTinhTrang, clbTinhTrang, btnChon, btnHuy });
        }
    }
}