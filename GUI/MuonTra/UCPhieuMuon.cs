using BUS;
using DTO;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GUI.MuonTra
{
    public partial class UCPhieuMuon : UserControl
    {
        private BindingList<PhieuMuonDTO> list = new();

        public UCPhieuMuon()
        {
            InitializeComponent();
            this.Load += UCPhieuMuon_Load;
        }

        private void UCPhieuMuon_Load(object sender, EventArgs e)
        {
            dgvPhieuMuon.AutoGenerateColumns = false;
            dgvPhieuMuon.RowTemplate.Height = 40;

            colPhieu.DataPropertyName = nameof(PhieuMuonDTO.MaPhieuMuon);
            colDocGia.DataPropertyName = nameof(PhieuMuonDTO.HoTenDocGia);
            colNgayMuon.DataPropertyName = nameof(PhieuMuonDTO.NgayMuon);
            colHanTra.DataPropertyName = nameof(PhieuMuonDTO.NgayTraDuKien);
            colNgayTra.DataPropertyName = nameof(PhieuMuonDTO.NgayTraThucTe);
            colTinhTrang.DataPropertyName = nameof(PhieuMuonDTO.TinhTrang);
            colGhiChu.DataPropertyName = nameof(PhieuMuonDTO.GhiChu);

            dgvPhieuMuon.ViewButtonClicked += DgvPhieuMuon_ViewButtonClicked;

            LoadData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterPhieuMuon(txtSearch.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            MoFormThemPhieuMuon();
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            GiaHanPhieuMuonDuocChon();
        }

        private void btnTra_Click(object sender, EventArgs e)
        {
            TraPhieuMuonDuocChon();
        }

        private void LoadData()
        {
            list = MuonTraBUS.LayTatCaPhieuMuon();
            dgvPhieuMuon.DataSource = list;
            DinhDangCotNgay();
        }

        private void DinhDangCotNgay()
        {
            if (dgvPhieuMuon.Columns[nameof(colNgayMuon)] != null)
                dgvPhieuMuon.Columns[nameof(colNgayMuon)].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dgvPhieuMuon.Columns[nameof(colHanTra)] != null)
                dgvPhieuMuon.Columns[nameof(colHanTra)].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dgvPhieuMuon.Columns[nameof(colNgayTra)] != null)
                dgvPhieuMuon.Columns[nameof(colNgayTra)].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void FilterPhieuMuon(string keyword)
        {
            if (list == null) return;
            if (string.IsNullOrWhiteSpace(keyword))
            {
                dgvPhieuMuon.DataSource = list;
                return;
            }

            keyword = keyword.ToLower().Trim();
            var filtered = list.Where(pm =>
                pm.MaPhieuMuon.ToLower().Contains(keyword) ||
                pm.HoTenDocGia.ToLower().Contains(keyword) ||
                pm.MaDocGia.ToLower().Contains(keyword) ||
                pm.TinhTrang.ToLower().Contains(keyword))
                .ToList();

            dgvPhieuMuon.DataSource = new BindingList<PhieuMuonDTO>(filtered);
            DinhDangCotNgay();
        }

        private void MoFormThemPhieuMuon()
        {
            string maDocGia = Interaction.InputBox("Nhập mã độc giả (ví dụ: DG0001)", "Lập phiếu mượn").Trim();
            if (string.IsNullOrWhiteSpace(maDocGia)) return;

            string maCuonStr = Interaction.InputBox("Nhập mã các cuốn sách (phân tách bởi dấu phẩy)", "Lập phiếu mượn");
            var maCuonList = maCuonStr.Split(new[] { ',', ';', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToList();

            if (maCuonList.Count == 0) return;

            try
            {
                var phieu = MuonTraBUS.LapPhieuMuon(maDocGia, maCuonList);
                list.Add(phieu);
                MessageBox.Show($"Lập phiếu thành công. Mã: {phieu.MaPhieuMuon}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GiaHanPhieuMuonDuocChon()
        {
            if (dgvPhieuMuon.CurrentRow == null) return;
            var phieu = dgvPhieuMuon.CurrentRow.DataBoundItem as PhieuMuonDTO;
            if (phieu == null) return;

            string input = Interaction.InputBox("Nhập số ngày muốn gia hạn", "Gia hạn");
            if (!int.TryParse(input, out int soNgay) || soNgay <= 0) return;

            try
            {
                var capNhat = MuonTraBUS.GiaHanPhieuMuon(phieu.ID, soNgay);
                if (capNhat != null)
                {
                    CapNhatItemTrongList(capNhat);
                    dgvPhieuMuon.Refresh();
                    MessageBox.Show("Gia hạn thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TraPhieuMuonDuocChon()
        {
            if (dgvPhieuMuon.CurrentRow == null) return;
            var phieu = dgvPhieuMuon.CurrentRow.DataBoundItem as PhieuMuonDTO;
            if (phieu == null) return;

            if (MessageBox.Show($"Xác nhận trả toàn bộ sách của phiếu {phieu.MaPhieuMuon}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != DialogResult.Yes) return;

            try
            {
                var capNhat = MuonTraBUS.TraPhieuMuon(phieu.ID, out int tienPhat);
                CapNhatItemTrongList(capNhat);

                string thongBao = "Trả sách thành công.";
                if (tienPhat > 0)
                {
                    thongBao += $"\nTiền phạt phát sinh: {tienPhat:N0} đồng.";
                }
                MessageBox.Show(thongBao, "Thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CapNhatItemTrongList(PhieuMuonDTO capNhat)
        {
            var item = list.FirstOrDefault(x => x.ID == capNhat.ID);
            if (item != null)
            {
                int index = list.IndexOf(item);
                list[index] = capNhat;
            }
        }

        private void DgvPhieuMuon_ViewButtonClicked(object sender, int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvPhieuMuon.Rows.Count) return;
            var phieu = dgvPhieuMuon.Rows[rowIndex].DataBoundItem as PhieuMuonDTO;
            if (phieu == null) return;

            var chiTiet = MuonTraBUS.LayChiTietPhieuMuon(phieu.ID);
            string message = string.Join("\n", chiTiet.Select(ct =>
                $"- {ct.MaCuonSach} | {ct.TenSach} | Hạn: {ct.NgayTraDuKien:dd/MM/yyyy} | Trả: {(ct.NgayTraThucTe.HasValue ? ct.NgayTraThucTe.Value.ToString("dd/MM/yyyy") : "Chưa trả")}"));

            if (string.IsNullOrWhiteSpace(message))
            {
                message = "Không có chi tiết sách.";
            }

            MessageBox.Show(message, $"Phiếu {phieu.MaPhieuMuon}");
        }
    }
}
