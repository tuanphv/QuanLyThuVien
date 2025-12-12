using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI.MuonTra
{
    public partial class FrmLapPhieuMuon : Form
    {
        private readonly BindingList<SachMuonLuaChonDTO> _sachDuocChon = new();
        public PhieuMuonDTO? PhieuMoi { get; private set; }

        private bool _ngayTraDaChinhSua;
        private DateTime _hanTraMacDinh;

        private DataGridView dgvSach = null!;

        // [CẬP NHẬT] Thay TextBox bằng ComboBox để làm Live Search
        private ComboBox cbDocGia = null!;

        private DateTimePicker dtpNgayTra = null!;

        // Danh sách gốc chứa toàn bộ độc giả để lọc
        private List<DocGiaSearchItem> _fullDocGiaSource = new();

        // Class phụ trợ để hiển thị trên ComboBox
        private class DocGiaSearchItem
        {
            public string MaDocGia { get; set; } = string.Empty;
            public string HoTen { get; set; } = string.Empty;
            // Property này sẽ được hiển thị trên ComboBox
            public string DisplayText => $"{MaDocGia} - {HoTen}";
        }

        public FrmLapPhieuMuon()
        {
            InitializeComponent();
            Load += FrmLapPhieuMuon_Load;
        }

        private void FrmLapPhieuMuon_Load(object? sender, EventArgs e)
        {
            try
            {
                // 1. Tải danh sách độc giả từ BUS
                // Chỉ lấy độc giả thẻ còn hạn
                var listRaw = DocGiaBUS.GetAll().Where(d => d.NgayHetHan >= DateTime.Today).ToList();

                // 2. Chuyển đổi sang list items phụ trợ
                _fullDocGiaSource = listRaw.Select(d => new DocGiaSearchItem
                {
                    MaDocGia = d.MaDocGia,
                    HoTen = d.HoTen
                }).ToList();

                // 3. Cấu hình ComboBox ban đầu
                cbDocGia.DisplayMember = "DisplayText";
                cbDocGia.ValueMember = "MaDocGia";
                cbDocGia.DataSource = _fullDocGiaSource;
                cbDocGia.SelectedIndex = -1; // Mặc định không chọn ai

                // 4. Đăng ký sự kiện gõ phím để lọc (Live Search)
                cbDocGia.TextUpdate += CbDocGia_TextUpdate;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách độc giả: " + ex.Message);
            }
        }

        // --- LOGIC TÌM KIẾM LIVE SEARCH ---
        private void CbDocGia_TextUpdate(object? sender, EventArgs e)
        {
            // Lưu lại text người dùng đang gõ
            string strSearch = cbDocGia.Text;

            if (_fullDocGiaSource == null || !_fullDocGiaSource.Any()) return;

            // Lọc danh sách: Tìm theo Mã HOẶC Tên (Không phân biệt hoa thường)
            var filteredList = _fullDocGiaSource
                .Where(x => x.DisplayText.IndexOf(strSearch, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            // Cập nhật lại DataSource (việc này sẽ làm mất text đang gõ)
            cbDocGia.DataSource = filteredList;

            // Khôi phục lại text và đưa con trỏ về cuối để gõ tiếp
            cbDocGia.Text = strSearch;
            cbDocGia.SelectionStart = strSearch.Length;
            cbDocGia.SelectionLength = 0;

            // Tự động mở dropdown nếu có kết quả
            if (filteredList.Count > 0 && !cbDocGia.DroppedDown)
            {
                cbDocGia.DroppedDown = true;
                cbDocGia.Cursor = Cursors.Default; // Fix lỗi con trỏ chuột bị ẩn
            }
            else if (filteredList.Count == 0)
            {
                cbDocGia.DroppedDown = false; // Đóng nếu không tìm thấy
            }
        }

        private void InitializeComponent()
        {
            Text = "Lập phiếu mượn";
            Width = 780;
            Height = 560;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            var lblDocGia = new Label { Text = "Mã độc giả / Tên", AutoSize = true, Left = 30, Top = 30, Font = new System.Drawing.Font("Segoe UI", 10F) };

            // [CẬP NHẬT] Khởi tạo ComboBox thay vì TextBox
            cbDocGia = new ComboBox
            {
                Name = "cbDocGia",
                Left = 30,
                Top = 55,
                Width = 250,
                Font = new System.Drawing.Font("Segoe UI", 10F),
                // Tắt AutoComplete mặc định của WinForms để dùng Custom Logic
                AutoCompleteMode = AutoCompleteMode.None,
                DropDownStyle = ComboBoxStyle.DropDown
            };

            var lblNgayMuon = new Label { Text = "Ngày mượn", AutoSize = true, Left = 320, Top = 30, Font = new System.Drawing.Font("Segoe UI", 10F) };
            var dtpNgayMuon = new DateTimePicker { Name = "dtpNgayMuon", Left = 430, Top = 25, Width = 170, Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy", Enabled = false, Value = DateTime.Today };
            var lblNgayTra = new Label { Text = "Hạn trả", AutoSize = true, Left = 320, Top = 75, Font = new System.Drawing.Font("Segoe UI", 10F) };

            try
            {
                _hanTraMacDinh = MuonTraBUS.TinhHanTraMacDinh(DateTime.Today);
            }
            catch
            {
                _hanTraMacDinh = DateTime.Today.AddDays(7); // Fallback
            }

            dtpNgayTra = new DateTimePicker { Name = "dtpNgayTra", Left = 430, Top = 70, Width = 170, Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy", MinDate = DateTime.Today, Value = _hanTraMacDinh };
            dtpNgayTra.ValueChanged += (s, e) => { _ngayTraDaChinhSua = true; };

            var lblHuongDan = new Label
            {
                Text = "Gợi ý: Nhập mã hoặc tên độc giả để tìm kiếm nhanh.",
                Left = 30,
                Top = 90,
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic),
                ForeColor = System.Drawing.Color.DimGray
            };

            dgvSach = new DataGridView
            {
                Left = 30,
                Top = 140,
                Width = 700,
                Height = 300,
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            var colMaCuon = new DataGridViewTextBoxColumn { HeaderText = "Mã cuốn", DataPropertyName = nameof(SachMuonLuaChonDTO.MaCuonSach), MinimumWidth = 80 };
            var colTenSach = new DataGridViewTextBoxColumn { HeaderText = "Tên sách", DataPropertyName = nameof(SachMuonLuaChonDTO.TenSach), MinimumWidth = 180 };
            var colTacGia = new DataGridViewTextBoxColumn { HeaderText = "Tác giả", DataPropertyName = nameof(SachMuonLuaChonDTO.TacGia), MinimumWidth = 140 };
            var colNxb = new DataGridViewTextBoxColumn { HeaderText = "Nhà xuất bản", DataPropertyName = nameof(SachMuonLuaChonDTO.NhaXuatBan), MinimumWidth = 140 };
            var colTinhTrang = new DataGridViewTextBoxColumn { HeaderText = "Tình trạng mượn", DataPropertyName = nameof(SachMuonLuaChonDTO.TinhTrangMuon), MinimumWidth = 140 };
            dgvSach.Columns.AddRange(colMaCuon, colTenSach, colTacGia, colNxb, colTinhTrang);
            dgvSach.DataSource = _sachDuocChon;

            var btnThemSach = new Button { Text = "Thêm sách", Left = 30, Top = 460, Width = 120, Height = 32, BackColor = System.Drawing.Color.DeepSkyBlue, FlatStyle = FlatStyle.Flat, ForeColor = System.Drawing.Color.White };
            btnThemSach.Click += (s, e) =>
            {
                using var frm = new FrmAddSachToPhieuMuon(_sachDuocChon.Select(s => s.MaCuonSach));
                if (frm.ShowDialog() == DialogResult.OK && frm.SachChon != null)
                {
                    if (_sachDuocChon.Any(c => c.MaCuonSach.Equals(frm.SachChon.MaCuonSach, StringComparison.OrdinalIgnoreCase)))
                    {
                        MessageBox.Show("Cuốn sách này đã có trong danh sách.");
                        return;
                    }
                    _sachDuocChon.Add(frm.SachChon);
                }
            };

            var btnXoa = new Button { Text = "Xóa sách chọn", Left = 170, Top = 460, Width = 140, Height = 32, BackColor = System.Drawing.Color.LightCoral, FlatStyle = FlatStyle.Flat, ForeColor = System.Drawing.Color.White };
            btnXoa.Click += (s, e) =>
            {
                if (dgvSach.CurrentRow?.DataBoundItem is SachMuonLuaChonDTO sach)
                {
                    _sachDuocChon.Remove(sach);
                }
            };

            var btnLuu = new Button { Text = "Tạo phiếu", Left = 580, Top = 460, Width = 150, Height = 32, BackColor = System.Drawing.Color.RoyalBlue, FlatStyle = FlatStyle.Flat, ForeColor = System.Drawing.Color.White };
            btnLuu.Click += (s, e) =>
            {
                try
                {
                    // Lấy mã độc giả từ giá trị đã chọn hoặc text nhập vào
                    string maDocGia = "";

                    if (cbDocGia.SelectedValue != null)
                    {
                        maDocGia = cbDocGia.SelectedValue.ToString() ?? "";
                    }
                    else
                    {
                        // Nếu người dùng nhập tay nhưng chưa chọn (VD gõ "DG001 - An" rồi enter)
                        // Ta thử cắt chuỗi để lấy phần mã trước dấu "-"
                        var text = cbDocGia.Text;
                        var parts = text.Split(new[] { " - " }, StringSplitOptions.None);
                        if (parts.Length > 0) maDocGia = parts[0].Trim();
                    }

                    if (string.IsNullOrWhiteSpace(maDocGia))
                    {
                        MessageBox.Show("Vui lòng chọn hoặc nhập mã độc giả hợp lệ.");
                        return;
                    }
                    if (_sachDuocChon.Count == 0)
                    {
                        MessageBox.Show("Cần chọn ít nhất một cuốn sách để mượn.");
                        return;
                    }

                    DateTime? ngayTra = _ngayTraDaChinhSua ? dtpNgayTra.Value.Date : (DateTime?)null;
                    PhieuMoi = MuonTraBUS.LapPhieuMuon(maDocGia, _sachDuocChon.ToList(), ngayTra);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            Controls.AddRange(new Control[] { lblDocGia, cbDocGia, lblNgayMuon, dtpNgayMuon, lblNgayTra, dtpNgayTra, lblHuongDan, dgvSach, btnThemSach, btnXoa, btnLuu });
        }
    }
}