using BUS;
using DTO;
using System;
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
            colTinhTrang.DataPropertyName = nameof(PhieuMuonDTO.TinhTrang);

            dgvPhieuMuon.ShowEditButton = false;
            dgvPhieuMuon.ShowDeleteButton = false;
            dgvPhieuMuon.ShowExtendButton = true;
            dgvPhieuMuon.ShowReturnButton = true;

            dgvPhieuMuon.ViewButtonClicked += DgvPhieuMuon_ViewButtonClicked;
            dgvPhieuMuon.ExtendButtonClicked += DgvPhieuMuon_ExtendButtonClicked;
            dgvPhieuMuon.ReturnButtonClicked += DgvPhieuMuon_ReturnButtonClicked;

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
            using var frm = new FrmLapPhieuMuon();
            if (frm.ShowDialog() == DialogResult.OK && frm.PhieuMoi != null)
            {
                list.Add(frm.PhieuMoi);
                MessageBox.Show($"Lập phiếu thành công. Mã: {frm.PhieuMoi.MaPhieuMuon}");
            }
        }

        private void GiaHanPhieuMuonDuocChon()
        {
            if (dgvPhieuMuon.CurrentRow == null) return;
            var phieu = dgvPhieuMuon.CurrentRow.DataBoundItem as PhieuMuonDTO;
            if (phieu == null) return;

            using var frm = new FrmGiaHanPhieuMuon(phieu);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CapNhatItemTrongList(phieu);
                dgvPhieuMuon.Refresh();
                MessageBox.Show("Gia hạn thành công.");
            }
        }

        private void TraPhieuMuonDuocChon()
        {
            if (dgvPhieuMuon.CurrentRow == null) return;
            var phieu = dgvPhieuMuon.CurrentRow.DataBoundItem as PhieuMuonDTO;
            if (phieu == null) return;

            using var frm = new FrmLapPhieuTra(phieu.MaPhieuMuon);
            frm.StartPosition = FormStartPosition.CenterParent;
            if (frm.ShowDialog() == DialogResult.OK && frm.PhieuTra != null)
            {
                var capNhat = MuonTraBUS.LayPhieuMuonTheoMa(phieu.MaPhieuMuon);
                if (capNhat != null)
                {
                    CapNhatItemTrongList(capNhat);
                    dgvPhieuMuon.Refresh();
                }

                string thongBao = "Trả sách thành công.";
                if (frm.PhieuTra.TongTienPhat > 0)
                {
                    thongBao += $"\nTiền phạt: {frm.PhieuTra.TongTienPhat:N0} đồng.";
                }
                MessageBox.Show(thongBao, "Thành công");
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

            using var frm = new FrmChiTietPhieuMuon(phieu);
            frm.ShowDialog();
        }

        private void DgvPhieuMuon_ExtendButtonClicked(object? sender, int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvPhieuMuon.Rows.Count) return;
            dgvPhieuMuon.CurrentCell = dgvPhieuMuon.Rows[rowIndex].Cells[0];
            GiaHanPhieuMuonDuocChon();
        }

        private void DgvPhieuMuon_ReturnButtonClicked(object? sender, int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvPhieuMuon.Rows.Count) return;
            dgvPhieuMuon.CurrentCell = dgvPhieuMuon.Rows[rowIndex].Cells[0];
            TraPhieuMuonDuocChon();
        }

    }
}
