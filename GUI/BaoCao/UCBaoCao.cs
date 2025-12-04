using BUS;
using ClosedXML.Excel;
using DTO;
using System.ComponentModel;

namespace GUI.BaoCao
{
    public partial class UCBaoCao : UserControl
    {
        private BindingList<BaoCaoNoDocGiaDTO> listNoDocGia = new();
        private BindingList<BaoCaoNoDocGiaDTO> listNoDocGiaFiltered = new();

        public UCBaoCao()
        {
            InitializeComponent();
        }

        private void UCBaoCao_Load(object sender, EventArgs e)
        {
            // Load báo cáo nợ theo độc giá (báo cáo mới)
            LoadBaoCaoNoDocGia();
        }

        private void btnLoadQuaHan_Click(object sender, EventArgs e)
        {
            LoadBaoCaoQuaHan();
        }

        private void btnLoadNoDocGia_Click(object sender, EventArgs e)
        {
            // Load báo cáo nợ theo độc giả (báo cáo mới)
            LoadBaoCaoNoDocGia();
        }

        private void LoadBaoCaoNoDocGia()
        {
            try
            {
                var list = BaoCaoBUS.GetBaoCaoNoDocGia();
                listNoDocGia = new BindingList<BaoCaoNoDocGiaDTO>(list);
                listNoDocGiaFiltered = listNoDocGia;

                dgvQuaHan.DataSource = listNoDocGiaFiltered;

                if (list == null || list.Count == 0)
                {
                    MessageBox.Show("Không có độc giả nào có nợ hoặc sách quá hạn.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Cấu hình cột
                if (dgvQuaHan.Columns["MaDocGia"] != null)
                {
                    dgvQuaHan.Columns["MaDocGia"].HeaderText = "Mã độc giả";
                    dgvQuaHan.Columns["MaDocGia"].Width = 120;
                }

                if (dgvQuaHan.Columns["HoTen"] != null)
                {
                    dgvQuaHan.Columns["HoTen"].HeaderText = "Họ tên";
                    dgvQuaHan.Columns["HoTen"].Width = 200;
                }

                if (dgvQuaHan.Columns["NoHienTai"] != null)
                {
                    dgvQuaHan.Columns["NoHienTai"].HeaderText = "Nợ hiện tại";
                    dgvQuaHan.Columns["NoHienTai"].DefaultCellStyle.Format = "#,##0 đ";
                    dgvQuaHan.Columns["NoHienTai"].Width = 120;
                }

                if (dgvQuaHan.Columns["SoSachQuaHan"] != null)
                {
                    dgvQuaHan.Columns["SoSachQuaHan"].HeaderText = "Số sách quá hạn";
                    dgvQuaHan.Columns["SoSachQuaHan"].Width = 120;
                }

                if (dgvQuaHan.Columns["TongNoUocTinh"] != null)
                {
                    dgvQuaHan.Columns["TongNoUocTinh"].HeaderText = "Tổng nợ ước tính";
                    dgvQuaHan.Columns["TongNoUocTinh"].DefaultCellStyle.Format = "#,##0 đ";
                    dgvQuaHan.Columns["TongNoUocTinh"].DefaultCellStyle.Font = 
                        new Font(dgvQuaHan.Font, FontStyle.Bold);
                    dgvQuaHan.Columns["TongNoUocTinh"].DefaultCellStyle.ForeColor = Color.Red;
                    dgvQuaHan.Columns["TongNoUocTinh"].Width = 150;
                }

                // Highlight các dòng có tổng nợ cao (> 50,000)
                foreach (DataGridViewRow row in dgvQuaHan.Rows)
                {
                    if (row.Cells["TongNoUocTinh"].Value != null)
                    {
                        int tongNo = Convert.ToInt32(row.Cells["TongNoUocTinh"].Value);
                        if (tongNo > 50000)
                        {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBaoCaoQuaHan()
        {
            try
            {
                var list = BaoCaoBUS.GetBaoCaoQuaHan();

                dgvQuaHan.DataSource = list;

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
