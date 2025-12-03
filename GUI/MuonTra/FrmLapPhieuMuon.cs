using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI.MuonTra
{
    public partial class FrmLapPhieuMuon : Form
    {
        private readonly List<string> _maCuon = new();
        public PhieuMuonDTO? PhieuMoi { get; private set; }

        public FrmLapPhieuMuon()
        {
            InitializeComponent();
        }

        private bool _ngayTraDaChinhSua;
        private DateTime _hanTraMacDinh;

        private void InitializeComponent()
        {
            Text = "Lập phiếu mượn";
            Width = 640;
            Height = 550;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            var lblDocGia = new Label { Text = "Mã độc giả", AutoSize = true, Left = 30, Top = 30, Font = new System.Drawing.Font("Segoe UI", 10F) };
            var lblCuon = new Label { Text = "Danh sách mã cuốn (mỗi dòng một mã)", AutoSize = true, Left = 30, Top = 150, Font = new System.Drawing.Font("Segoe UI", 10F) };

            var txtDocGia = new TextBox { Name = "txtDocGia", Left = 30, Top = 55, Width = 250, Font = new System.Drawing.Font("Segoe UI", 10F) };
            var txtMaCuon = new TextBox { Name = "txtMaCuon", Left = 30, Top = 180, Width = 250, Font = new System.Drawing.Font("Segoe UI", 10F) };
            var lstCuon = new ListBox { Name = "lstCuon", Left = 30, Top = 370, Width = 390, Height = 120, Font = new System.Drawing.Font("Segoe UI", 10F) };
            var btnThemMa = new Button { Text = "Thêm mã", Left = 300, Top = 178, Width = 100, Height = 32, BackColor = System.Drawing.Color.DeepSkyBlue, FlatStyle = FlatStyle.Flat, ForeColor = System.Drawing.Color.White };
            btnThemMa.Click += (s, e) =>
            {
                if (!string.IsNullOrWhiteSpace(txtMaCuon.Text))
                {
                    AddMaCuon(txtMaCuon.Text);
                    txtMaCuon.Clear();
                }
            };

            var txtNhapNhanh = new TextBox { Name = "txtNhapNhanh", Multiline = true, Left = 30, Top = 230, Width = 250, Height = 120, Font = new System.Drawing.Font("Segoe UI", 10F) };
            var btnNhapNhanh = new Button { Text = "Thêm hàng loạt", Left = 300, Top = 230, Width = 120, Height = 32, BackColor = System.Drawing.Color.MediumSeaGreen, FlatStyle = FlatStyle.Flat, ForeColor = System.Drawing.Color.White };
            btnNhapNhanh.Click += (s, e) =>
            {
                if (!string.IsNullOrWhiteSpace(txtNhapNhanh.Text))
                {
                    var lines = txtNhapNhanh.Text.Split(new[] { '\n', ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var line in lines)
                    {
                        AddMaCuon(line);
                    }
                    txtNhapNhanh.Clear();
                }
            };
            var btnXoa = new Button { Text = "Xóa mã chọn", Left = 430, Top = 370, Width = 150, Height = 32, BackColor = System.Drawing.Color.LightCoral, FlatStyle = FlatStyle.Flat, ForeColor = System.Drawing.Color.White };
            btnXoa.Click += (s, e) =>
            {
                if (lstCuon.SelectedItem is string ma)
                {
                    _maCuon.Remove(ma);
                    lstCuon.Items.Remove(ma);
                }
            };

            var lblNgayMuon = new Label { Text = "Ngày mượn", AutoSize = true, Left = 320, Top = 30, Font = new System.Drawing.Font("Segoe UI", 10F) };
            var dtpNgayMuon = new DateTimePicker { Name = "dtpNgayMuon", Left = 430, Top = 25, Width = 170, Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy", Enabled = false, Value = DateTime.Today };
            var lblNgayTra = new Label { Text = "Hạn trả", AutoSize = true, Left = 320, Top = 75, Font = new System.Drawing.Font("Segoe UI", 10F) };
            _hanTraMacDinh = MuonTraBUS.TinhHanTraMacDinh(DateTime.Today);
            var dtpNgayTra = new DateTimePicker { Name = "dtpNgayTra", Left = 430, Top = 70, Width = 170, Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy", MinDate = DateTime.Today, Value = _hanTraMacDinh };
            dtpNgayTra.ValueChanged += (s, e) => { _ngayTraDaChinhSua = true; };

            var btnLuu = new Button { Text = "Tạo phiếu", Left = 430, Top = 458, Width = 150, Height = 32, BackColor = System.Drawing.Color.RoyalBlue, FlatStyle = FlatStyle.Flat, ForeColor = System.Drawing.Color.White };
            btnLuu.Click += (s, e) =>
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(txtDocGia.Text))
                    {
                        MessageBox.Show("Vui lòng nhập mã độc giả.");
                        return;
                    }
                    if (_maCuon.Count == 0)
                    {
                        MessageBox.Show("Cần nhập ít nhất một mã cuốn sách.");
                        return;
                    }

                    DateTime? ngayTra = _ngayTraDaChinhSua ? dtpNgayTra.Value.Date : (DateTime?)null;
                    PhieuMoi = MuonTraBUS.LapPhieuMuon(txtDocGia.Text, _maCuon.ToList(), ngayTra);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            Controls.AddRange(new Control[] { lblDocGia, txtDocGia, lblNgayMuon, dtpNgayMuon, lblNgayTra, dtpNgayTra, lblCuon, txtMaCuon, btnThemMa, txtNhapNhanh, btnNhapNhanh, lstCuon, btnXoa, btnLuu });

            void AddMaCuon(string ma)
            {
                ma = ma.Trim();
                if (string.IsNullOrWhiteSpace(ma)) return;
                if (_maCuon.Contains(ma, StringComparer.OrdinalIgnoreCase)) return;
                _maCuon.Add(ma);
                lstCuon.Items.Add(ma);
            }
        }
    }
}
