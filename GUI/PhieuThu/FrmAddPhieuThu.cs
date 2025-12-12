using BUS;
using DTO;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GUI.PhieuThu
{
    public partial class FrmAddPhieuThu : Form
    {
        private DocGiaDTO? selectedDocGia;

        // Property để lấy kết quả trả về cho Form cha
        public PhieuThuDTO? PhieuThuMoi { get; private set; }

        public FrmAddPhieuThu()
        {
            InitializeComponent();

            // --- QUAN TRỌNG: KẾT NỐI SỰ KIỆN THỦ CÔNG ---
            // Đảm bảo nút bấm hoạt động dù Designer có bị lỗi link
            this.btnSave.Click += new System.EventHandler(this.btnLuu_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnHuy_Click);
        }

        private void FrmAddPhieuThu_Load(object sender, EventArgs e)
        {
            dtpNgayLapPhieu.Value = DateTime.Now;

            // Lấy danh sách độc giả có nợ
            var docGiaList = DocGiaBUS.GetAll();
            var listNo = docGiaList.Where(d => d.TongNoHienTai > 0).ToList();

            if (listNo.Count == 0)
            {
                MessageBox.Show("Không có độc giả nào đang nợ tiền.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Disable nút lưu nếu không có ai nợ
                btnSave.Enabled = false;
            }

            cbDocGia.DataSource = listNo;
            cbDocGia.DisplayMember = "HoTen";
            cbDocGia.ValueMember = "ID";

            // Trigger chọn dòng đầu tiên nếu có
            if (cbDocGia.Items.Count > 0)
            {
                cbDocGia.SelectedIndex = 0;
                cbDocGia_SelectedIndexChanged(cbDocGia, EventArgs.Empty);
            }
        }

        private void cbDocGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedDocGia = cbDocGia.SelectedItem as DocGiaDTO;
            if (selectedDocGia != null)
            {
                lblTongNo.Text = $"Tổng nợ: {selectedDocGia.TongNoHienTai:N0} VNĐ";

                // Mặc định điền số tiền bằng tổng nợ
                txtTienThu.Text = selectedDocGia.TongNoHienTai.ToString("N0");
                TinhNo();
            }
        }

        private void txtTienThu_TextChanged(object? sender, EventArgs e)
        {
            TinhNo();
        }

        private void txtTienThu_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho nhập số và phím điều khiển (backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // --- CÁC HÀM SỰ KIỆN DO DESIGNER GỌI (GIỮ ĐỂ TRÁNH LỖI CS0103) ---

        private void txtTienThu_Enter(object sender, EventArgs e)
        {
            txtTienThu.SelectAll();
        }

        private void txtTienThu_Leave(object sender, EventArgs e)
        {
            // Khi rời ô nhập, format lại số cho đẹp (VD: 10000 -> 10,000)
            string rawText = new string(txtTienThu.Text.Where(char.IsDigit).ToArray());
            if (long.TryParse(rawText, out long val))
            {
                txtTienThu.Text = val.ToString("N0");
            }
            TinhNo();
        }

        private void txtTienThu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Khi nhấn Enter ở ô tiền, gọi luôn hàm Lưu
                btnLuu_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void FrmAddPhieuThu_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Không cần xử lý gì đặc biệt
        }

        // ------------------------------------------------------------

        private void TinhNo()
        {
            if (selectedDocGia == null) return;

            // Lấy số từ textbox (loại bỏ dấu phẩy/chấm format)
            string rawText = new string(txtTienThu.Text.Where(char.IsDigit).ToArray());

            if (long.TryParse(rawText, out long tienThu))
            {
                long conNo = (long)selectedDocGia.TongNoHienTai - tienThu;
                txtConNo.Text = conNo.ToString("N0");

                // Đổi màu nếu âm (thu quá nợ)
                if (conNo < 0)
                    txtConNo.ForeColor = System.Drawing.Color.Red;
                else
                    txtConNo.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                txtConNo.Text = selectedDocGia.TongNoHienTai.ToString("N0");
            }
        }

        // Hàm xử lý khi bấm nút LƯU
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (selectedDocGia == null)
            {
                MessageBox.Show("Vui lòng chọn độc giả.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string rawText = new string(txtTienThu.Text.Where(char.IsDigit).ToArray());
            if (!int.TryParse(rawText, out int tienThu) || tienThu <= 0)
            {
                MessageBox.Show("Số tiền thu không hợp lệ (phải > 0).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tienThu > selectedDocGia.TongNoHienTai)
            {
                MessageBox.Show($"Số tiền thu ({tienThu:N0}) không được vượt quá tổng nợ ({selectedDocGia.TongNoHienTai:N0}).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo DTO
            PhieuThuMoi = new PhieuThuDTO
            {
                IDDocGia = selectedDocGia.ID,
                TenDocGia = selectedDocGia.HoTen,
                NgayLapPhieu = dtpNgayLapPhieu.Value,
                SoTienThu = tienThu
            };

            try
            {
                // Gọi BUS để thêm vào DB
                string maPhieu = PhieuThuBUS.AddPhieuThu(PhieuThuMoi);

                if (!string.IsNullOrEmpty(maPhieu))
                {
                    PhieuThuMoi.MaPhieuThu = maPhieu;
                    MessageBox.Show($"Lập phiếu thu thành công!\nMã phiếu: {maPhieu}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm phiếu thu thất bại (Lỗi Database).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hệ thống: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Hàm tương thích
        public PhieuThuDTO? GetPhieuThu()
        {
            return PhieuThuMoi;
        }
    }
}