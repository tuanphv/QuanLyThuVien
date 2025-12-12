using BUS;
using DTO;
using System;
using System.ComponentModel;
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
        private TextBox txtDocGia = null!;
        private DateTimePicker dtpNgayTra = null!;

        public FrmLapPhieuMuon()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Text = "Lập phiếu mượn";
            Width = 780;
            Height = 560;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            var lblDocGia = new Label { Text = "Mã độc giả", AutoSize = true, Left = 30, Top = 30, Font = new System.Drawing.Font("Segoe UI", 10F) };
            txtDocGia = new TextBox { Name = "txtDocGia", Left = 30, Top = 55, Width = 250, Font = new System.Drawing.Font("Segoe UI", 10F) };

            var lblNgayMuon = new Label { Text = "Ngày mượn", AutoSize = true, Left = 320, Top = 30, Font = new System.Drawing.Font("Segoe UI", 10F) };
            var dtpNgayMuon = new DateTimePicker { Name = "dtpNgayMuon", Left = 430, Top = 25, Width = 170, Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy", Enabled = false, Value = DateTime.Today };
            var lblNgayTra = new Label { Text = "Hạn trả", AutoSize = true, Left = 320, Top = 75, Font = new System.Drawing.Font("Segoe UI", 10F) };
            _hanTraMacDinh = MuonTraBUS.TinhHanTraMacDinh(DateTime.Today);
            dtpNgayTra = new DateTimePicker { Name = "dtpNgayTra", Left = 430, Top = 70, Width = 170, Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy", MinDate = DateTime.Today, Value = _hanTraMacDinh };
            dtpNgayTra.ValueChanged += (s, e) => { _ngayTraDaChinhSua = true; };

            var lblHuongDan = new Label
            {
                Text = "Chọn sách bằng nút \"Thêm sách\". Hệ thống sẽ lưu tình trạng mượn cho từng cuốn.",
                Left = 30,
                Top = 105,
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
                    if (string.IsNullOrWhiteSpace(txtDocGia.Text))
                    {
                        MessageBox.Show("Vui lòng nhập mã độc giả.");
                        return;
                    }
                    if (_sachDuocChon.Count == 0)
                    {
                        MessageBox.Show("Cần chọn ít nhất một cuốn sách để mượn.");
                        return;
                    }

                    DateTime? ngayTra = _ngayTraDaChinhSua ? dtpNgayTra.Value.Date : (DateTime?)null;
                    PhieuMoi = MuonTraBUS.LapPhieuMuon(txtDocGia.Text, _sachDuocChon.ToList(), ngayTra);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            Controls.AddRange(new Control[] { lblDocGia, txtDocGia, lblNgayMuon, dtpNgayMuon, lblNgayTra, dtpNgayTra, lblHuongDan, dgvSach, btnThemSach, btnXoa, btnLuu });
        }
    }
}
