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

            dtpTuNgay.Value = DateTime.Now.AddMonths(-1);
            dtpDenNgay.Value = DateTime.Now;


            LoadBaoCaoTheoKhoang();
            LoadTopSach();
            LoadTopDocGia();
            LoadBaoCaoQuaHan();
        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadBaoCaoTheoKhoang();
        }

        private void LoadBaoCaoTheoKhoang()
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date;

                var result = BaoCaoBUS.GetBaoCaoTheoKhoang(tuNgay, denNgay);


                lblKetQua.Text = $"Kết quả: {result.TongLuotMuon} lượt mượn | {result.TongSachMuon} cu?n sách";

                var dt = new System.Data.DataTable();
                dt.Columns.Add("Tiêu chí", typeof(string));
                dt.Columns.Add("Giá tr?", typeof(int));

                dt.Rows.Add("Tổng lượt mượn", result.TongLuotMuon);
                dt.Rows.Add("Tổng sách mượn", result.TongSachMuon);

                dgvTheoKhoang.DataSource = dt;

                if (dgvTheoKhoang.Columns["Tiêu chí"] != null)
                    dgvTheoKhoang.Columns["Tiêu chí"].Width = 200;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnLoadTopSach_Click(object sender, EventArgs e)
        {
            LoadTopSach();
        }

        private void LoadTopSach()
        {
            try
            {
                int top = (int)numTopSach.Value;
                var list = BaoCaoBUS.GetTopSachMuonNhieu(top);

                dgvTopSach.DataSource = list;

                if (dgvTopSach.Columns["STT"] != null)
                {
                    dgvTopSach.Columns["STT"].HeaderText = "STT";
                }

                if (dgvTopSach.Columns["MaTuaSach"] != null)
                    dgvTopSach.Columns["MaTuaSach"].HeaderText = "Mã sách";

                if (dgvTopSach.Columns["TenTuaSach"] != null)
                    dgvTopSach.Columns["TenTuaSach"].HeaderText = "Tên sách";

                if (dgvTopSach.Columns["TheLoai"] != null)
                    dgvTopSach.Columns["TheLoai"].HeaderText = "Thể loại";

                if (dgvTopSach.Columns["SoLuotMuon"] != null)
                    dgvTopSach.Columns["SoLuotMuon"].HeaderText = "Lượt mượn";

                if (dgvTopSach.Columns["SoLuongHienCo"] != null)
                    dgvTopSach.Columns["SoLuongHienCo"].HeaderText = "Còn lại";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region Tab 3: Top ??c gi? tích c?c
        private void btnLoadTopDocGia_Click(object sender, EventArgs e)
        {
            LoadTopDocGia();
        }

        private void LoadTopDocGia()
        {
            try
            {
                int top = (int)numTopDocGia.Value;
                var list = BaoCaoBUS.GetTopDocGiaTichCuc(top);

                dgvTopDocGia.DataSource = list;


                if (dgvTopDocGia.Columns["STT"] != null)
                {
                    dgvTopDocGia.Columns["STT"].HeaderText = "STT";
                }

                if (dgvTopDocGia.Columns["MaDocGia"] != null)
                    dgvTopDocGia.Columns["MaDocGia"].HeaderText = "Mã độc giả";

                if (dgvTopDocGia.Columns["HoTen"] != null)
                    dgvTopDocGia.Columns["HoTen"].HeaderText = "Họ tên";

                if (dgvTopDocGia.Columns["SoLuotMuon"] != null)
                    dgvTopDocGia.Columns["SoLuotMuon"].HeaderText = "Lượt mượn";

                if (dgvTopDocGia.Columns["TongNo"] != null)
                    dgvTopDocGia.Columns["TongNo"].HeaderText = "Tổng nợ";

                if (dgvTopDocGia.Columns["NgayLapThe"] != null)
                {
                    dgvTopDocGia.Columns["NgayLapThe"].HeaderText = "Ngày lập thể";
                    dgvTopDocGia.Columns["NgayLapThe"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    dgvQuaHan.Columns["TienPhat"].HeaderText = "Tiền phạt";

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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
