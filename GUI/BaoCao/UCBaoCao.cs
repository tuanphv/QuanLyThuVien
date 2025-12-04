using BUS;
using DTO;

namespace GUI.BaoCao
{
    public partial class UCBaoCao : UserControl
    {
        public UCBaoCao()
        {
            InitializeComponent();
        }

        private void UCBaoCao_Load(object sender, EventArgs e)
        {
            LoadBaoCaoQuaHan();
        }

        private void btnLoadQuaHan_Click(object sender, EventArgs e)
        {
            LoadBaoCaoQuaHan();
        }

        private void LoadBaoCaoQuaHan()
        {
            try
            {
                var list = BaoCaoBUS.GetBaoCaoQuaHan();

                dgvQuaHan.DataSource = list;

                // Hiển thị số lượng kết quả
                if (list == null || list.Count == 0)
                {
                    MessageBox.Show("Không có độc giả nào quá hạn chưa trả sách.", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (dgvQuaHan.Columns["MaDocGia"] != null)
                    dgvQuaHan.Columns["MaDocGia"].HeaderText = "Mã độc giả";

                if (dgvQuaHan.Columns["HoTen"] != null)
                    dgvQuaHan.Columns["HoTen"].HeaderText = "Họ tên";

                if (dgvQuaHan.Columns["MaPhieuMuon"] != null)
                    dgvQuaHan.Columns["MaPhieuMuon"].HeaderText = "Mã phiếu";

                if (dgvQuaHan.Columns["NgayMuon"] != null)
                {
                    dgvQuaHan.Columns["NgayMuon"].HeaderText = "Ngày mượn";
                    dgvQuaHan.Columns["NgayMuon"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }

                if (dgvQuaHan.Columns["NgayTraDuKien"] != null)
                {
                    dgvQuaHan.Columns["NgayTraDuKien"].HeaderText = "Hạn trả";
                    dgvQuaHan.Columns["NgayTraDuKien"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }

                if (dgvQuaHan.Columns["SoNgayQuaHan"] != null)
                    dgvQuaHan.Columns["SoNgayQuaHan"].HeaderText = "Số ngày trễ";

                if (dgvQuaHan.Columns["TienPhat"] != null)
                {
                    dgvQuaHan.Columns["TienPhat"].HeaderText = "Tiền phạt";
                    dgvQuaHan.Columns["TienPhat"].DefaultCellStyle.Format = "#,##0 đ";
                }

                // Highlight các dòng quá hạn nhiều (> 7 ngày) bằng màu đỏ nhạt
                foreach (DataGridViewRow row in dgvQuaHan.Rows)
                {
                    if (row.Cells["SoNgayQuaHan"].Value != null)
                    {
                        int soNgayTre = Convert.ToInt32(row.Cells["SoNgayQuaHan"].Value);
                        if (soNgayTre > 7)
                        {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200);
                        }
                    }
                }

                // Hiển thị số lượng kết quả ở title
                label1.Text = $"Báo cáo nợ quá hạn ({list.Count} độc giả)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}\n\nChi tiết: {ex.StackTrace}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
