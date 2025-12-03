using BUS;
using DTO;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using GUI.Helpers;

namespace GUI.MuonTra
{
    public partial class UCPhieuTra : UserControl
    {
        private BindingList<PhieuTraDTO> _list = new();
        private bool _isInitialized;
        private bool _isReader;
        private string? _maDocGiaDangNhap;

        public UCPhieuTra()
        {
            InitializeComponent();
            Load += UCPhieuTra_Load;
            VisibleChanged += UCPhieuTra_VisibleChanged;
        }

        private void UCPhieuTra_Load(object? sender, EventArgs e)
        {
            KhoiTaoCheDoNguoiDung();
            dgvPhieuTra.AutoGenerateColumns = false;
            dgvPhieuTra.RowTemplate.Height = 42;
            dgvPhieuTra.EditButtonClicked += DgvPhieuTra_EditButtonClicked;
            dgvPhieuTra.DeleteButtonClicked += DgvPhieuTra_DeleteButtonClicked;
            dgvPhieuTra.ViewButtonClicked += DgvPhieuTra_ViewButtonClicked;

            dgvPhieuTra.ShowEditButton = !_isReader;
            dgvPhieuTra.ShowDeleteButton = !_isReader;

            colMaPhieu.DataPropertyName = nameof(PhieuTraDTO.MaPhieuMuon);
            colDocGia.DataPropertyName = nameof(PhieuTraDTO.HoTenDocGia);
            colNgayTra.DataPropertyName = nameof(PhieuTraDTO.NgayTra);
            colTongSach.DataPropertyName = nameof(PhieuTraDTO.TongSachTra);
            colTienPhat.DataPropertyName = nameof(PhieuTraDTO.TongTienPhat);

            if (dgvPhieuTra.Columns[nameof(colNgayTra)] != null)
                dgvPhieuTra.Columns[nameof(colNgayTra)].DefaultCellStyle.Format = "dd/MM/yyyy";

            btnLapPhieuTra.Visible = !_isReader;

            LoadData();
            _isInitialized = true;
        }

        private void UCPhieuTra_VisibleChanged(object? sender, EventArgs e)
        {
            if (Visible && _isInitialized)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            _list = MuonTraBUS.LayTatCaPhieuTra();
            if (_isReader)
            {
                _list = string.IsNullOrEmpty(_maDocGiaDangNhap)
                    ? new BindingList<PhieuTraDTO>()
                    : new BindingList<PhieuTraDTO>(_list.Where(p => p.MaDocGia == _maDocGiaDangNhap).ToList());
            }
            dgvPhieuTra.DataSource = _list;
            Filter(txtSearch.Text);
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
            if (e < 0 || e >= dgvPhieuTra.Rows.Count) return;
            var phieu = dgvPhieuTra.Rows[e].DataBoundItem as PhieuTraDTO;
            if (phieu == null) return;

            var confirm = MessageBox.Show(
                $"Xóa phiếu trả của {phieu.HoTenDocGia} (mã {phieu.MaPhieuMuon})?\nSách sẽ trở lại trạng thái đang mượn.",
                "Xác nhận",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.OK) return;

            try
            {
                if (MuonTraBUS.XoaPhieuTra(phieu.IDPhieuMuon))
                {
                    LoadData();
                    MessageBox.Show("Đã xóa phiếu trả.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvPhieuTra_EditButtonClicked(object? sender, int e)
        {
            MessageBox.Show("Phiếu trả không hỗ trợ chỉnh sửa.");
        }

        private void KhoiTaoCheDoNguoiDung()
        {
            _isReader = SessionManager.CurrentUser?.TenNhomNguoiDung?.Equals("Độc Giả", StringComparison.OrdinalIgnoreCase) == true;
            if (_isReader && SessionManager.GetUserId() is int userId)
            {
                var docGia = DocGiaBUS.GetByUserId(userId);
                _maDocGiaDangNhap = docGia?.MaDocGia;
            }
        }
    }
}
