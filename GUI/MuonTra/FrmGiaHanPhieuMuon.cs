using BUS;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI.MuonTra
{
    public partial class FrmGiaHanPhieuMuon : Form
    {
        private readonly PhieuMuonDTO _phieu;

        public FrmGiaHanPhieuMuon(PhieuMuonDTO phieu)
        {
            _phieu = phieu;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            lblMaPhieu.Text = _phieu.MaPhieuMuon;
            lblHanCu.Text = _phieu.NgayTraDuKien.ToString("dd/MM/yyyy");
            numSoNgay.Value = 7; // Mặc định gia hạn 7 ngày
        }

        private void btnLuu_Click(object? sender, EventArgs e)
        {
            try
            {
                int soNgay = (int)numSoNgay.Value;
                // Tính ngày hạn mới
                DateTime hanTraMoi = _phieu.NgayTraDuKien.AddDays(soNgay);

                // Gọi BUS với tham số DateTime (Sửa lỗi CS0117)
                bool thanhCong = MuonTraBUS.GiaHanPhieuMuon(_phieu.ID, hanTraMoi);

                if (thanhCong)
                {
                    _phieu.NgayTraDuKien = hanTraMoi;
                    MessageBox.Show($"Gia hạn thành công đến ngày {hanTraMoi:dd/MM/yyyy}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Gia hạn thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e) => Close();

        private void InitializeComponent()
        {
            Text = "Gia hạn phiếu mượn";
            Width = 360;
            Height = 260;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            var lblTitle = new Label { Text = "Gia hạn sách", Left = 20, Top = 20, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold) };
            var lblMa = new Label { Text = "Mã phiếu:", Left = 20, Top = 60, AutoSize = true };
            lblMaPhieu = new Label { Left = 120, Top = 60, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold) };
            var lblCu = new Label { Text = "Hạn trả cũ:", Left = 20, Top = 90, AutoSize = true };
            lblHanCu = new Label { Left = 120, Top = 90, AutoSize = true };
            var lblMoi = new Label { Text = "Thêm (ngày):", Left = 20, Top = 130, AutoSize = true };

            numSoNgay = new NumericUpDown { Left = 120, Top = 125, Width = 100, Minimum = 1, Maximum = 60, Value = 7 };

            var btnLuu = new Button { Text = "Lưu", Left = 80, Top = 180, Width = 80, Height = 30, BackColor = System.Drawing.Color.RoyalBlue, ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };
            btnLuu.Click += btnLuu_Click;
            var btnHuy = new Button { Text = "Hủy", Left = 180, Top = 180, Width = 80, Height = 30, FlatStyle = FlatStyle.Flat };
            btnHuy.Click += btnHuy_Click;

            Controls.AddRange(new Control[] { lblTitle, lblMa, lblMaPhieu, lblCu, lblHanCu, lblMoi, numSoNgay, btnLuu, btnHuy });
        }

        private Label lblMaPhieu = null!;
        private Label lblHanCu = null!;
        private NumericUpDown numSoNgay = null!;
    }
}