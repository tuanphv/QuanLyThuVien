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
        }

        private void btnLuu_Click(object? sender, EventArgs e)
        {
            int soNgay = (int)numSoNgay.Value;
            try
            {
                var capNhat = MuonTraBUS.GiaHanPhieuMuon(_phieu.ID, soNgay);
                if (capNhat != null)
                {
                    _phieu.NgayTraDuKien = capNhat.NgayTraDuKien;
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            Text = "Gia hạn phiếu mượn";
            Width = 360;
            Height = 200;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            var lbl = new Label { Text = "Số ngày gia hạn", Left = 20, Top = 30, AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10F) };
            numSoNgay = new NumericUpDown { Left = 20, Top = 60, Width = 120, Minimum = 1, Maximum = 60, Value = 1, Font = new System.Drawing.Font("Segoe UI", 10F) };
            var btn = new Button { Text = "Lưu", Left = 200, Top = 60, Width = 120, Height = 32, BackColor = System.Drawing.Color.RoyalBlue, ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };
            btn.Click += btnLuu_Click;

            Controls.AddRange(new Control[] { lbl, numSoNgay, btn });
        }

        private NumericUpDown numSoNgay = null!;
    }
}
