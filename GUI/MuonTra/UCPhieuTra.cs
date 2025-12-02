using BUS;
using DTO;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GUI.MuonTra
{
    public partial class UCPhieuTra : UserControl
    {
        private BindingList<PhieuTraDTO> _list = new();

        public UCPhieuTra()
        {
            InitializeComponent();
            Load += UCPhieuTra_Load;
        }

        private void UCPhieuTra_Load(object? sender, EventArgs e)
        {
            dgvPhieuTra.AutoGenerateColumns = false;
            dgvPhieuTra.RowTemplate.Height = 42;
            dgvPhieuTra.EditButtonClicked += DgvPhieuTra_EditButtonClicked;
            dgvPhieuTra.DeleteButtonClicked += DgvPhieuTra_DeleteButtonClicked;
            dgvPhieuTra.ViewButtonClicked += DgvPhieuTra_ViewButtonClicked;

            colMaPhieu.DataPropertyName = nameof(PhieuTraDTO.MaPhieuMuon);
            colDocGia.DataPropertyName = nameof(PhieuTraDTO.HoTenDocGia);
            colNgayTra.DataPropertyName = nameof(PhieuTraDTO.NgayTra);
            colTongSach.DataPropertyName = nameof(PhieuTraDTO.TongSachTra);
            colTienPhat.DataPropertyName = nameof(PhieuTraDTO.TongTienPhat);

            if (dgvPhieuTra.Columns[nameof(colNgayTra)] != null)
                dgvPhieuTra.Columns[nameof(colNgayTra)].DefaultCellStyle.Format = "dd/MM/yyyy";

            LoadData();
        }

        private void LoadData()
        {
            _list = MuonTraBUS.LayTatCaPhieuTra();
            dgvPhieuTra.DataSource = _list;
        }

        private void txtSearch_TextChanged(object? sender, EventArgs e)
        {
            Filter(txtSearch.Text);
        }

        private void Filter(string keyword)
        {
            if (_list == null) return;
            if (string.IsNullOrWhiteSpace(keyword))
            {
                dgvPhieuTra.DataSource = _list;
                return;
            }

            keyword = keyword.ToLower().Trim();
            var filtered = _list.Where(p =>
                p.MaPhieuMuon.ToLower().Contains(keyword) ||
                p.HoTenDocGia.ToLower().Contains(keyword) ||
                p.MaDocGia.ToLower().Contains(keyword))
                .ToList();
            dgvPhieuTra.DataSource = new BindingList<PhieuTraDTO>(filtered);
        }

        private void btnLapPhieuTra_Click(object? sender, EventArgs e)
        {
            using var frm = new FrmLapPhieuTra();
            if (frm.ShowDialog() == DialogResult.OK && frm.PhieuTra != null)
            {
                LoadData();
                MessageBox.Show("Đã tạo phiếu trả.", "Thông báo");
            }
        }

        private void DgvPhieuTra_ViewButtonClicked(object? sender, int e)
        {
            if (e < 0 || e >= dgvPhieuTra.Rows.Count) return;
            var phieu = dgvPhieuTra.Rows[e].DataBoundItem as PhieuTraDTO;
            if (phieu == null) return;
            using var frm = new FrmChiTietPhieuTra(phieu);
            frm.ShowDialog();
        }

        private void DgvPhieuTra_DeleteButtonClicked(object? sender, int e)
        {
            MessageBox.Show("Phiếu trả không thể xóa để đảm bảo lịch sử.", "Thông tin");
        }

        private void DgvPhieuTra_EditButtonClicked(object? sender, int e)
        {
            MessageBox.Show("Phiếu trả không hỗ trợ chỉnh sửa.");
        }
    }
}
