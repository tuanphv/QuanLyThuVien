using BUS;
using DTO;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GUI.Helpers;

namespace GUI.MuonTra
{
    public partial class UCPhieuMuon : UserControl
    {
        private BindingList<PhieuMuonDTO> list = new();
        private bool _isInitialized;
        private bool _isReader;
        private string? _maDocGiaDangNhap;

        public UCPhieuMuon()
        {
            InitializeComponent();
            this.Load += UCPhieuMuon_Load;
            VisibleChanged += UCPhieuMuon_VisibleChanged;
        }

        private void UCPhieuMuon_Load(object sender, EventArgs e)
        {
            KhoiTaoCheDoNguoiDung();
            dgvPhieuMuon.AutoGenerateColumns = false;
            dgvPhieuMuon.RowTemplate.Height = 40;

            colPhieu.DataPropertyName = nameof(PhieuMuonDTO.MaPhieuMuon);
            colDocGia.DataPropertyName = nameof(PhieuMuonDTO.HoTenDocGia);
            colNgayMuon.DataPropertyName = nameof(PhieuMuonDTO.NgayMuon);
            colHanTra.DataPropertyName = nameof(PhieuMuonDTO.NgayTraDuKien);
            colTinhTrang.DataPropertyName = nameof(PhieuMuonDTO.TinhTrang);

            dgvPhieuMuon.ShowEditButton = false;
            dgvPhieuMuon.ShowDeleteButton = !_isReader;
            dgvPhieuMuon.ShowExtendButton = false;
            dgvPhieuMuon.ShowReturnButton = !_isReader;

            btnImport.Visible = !_isReader;
            btnExport.Visible = !_isReader;

            dgvPhieuMuon.ViewButtonClicked += DgvPhieuMuon_ViewButtonClicked;
            dgvPhieuMuon.ReturnButtonClicked += DgvPhieuMuon_ReturnButtonClicked;
            dgvPhieuMuon.DeleteButtonClicked += DgvPhieuMuon_DeleteButtonClicked;

            cbStatusFilter.SelectedIndex = 0;
            LoadData();
            _isInitialized = true;
        }

        private void UCPhieuMuon_VisibleChanged(object? sender, EventArgs e)
        {
            if (Visible && _isInitialized)
            {
                LoadData();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            MoFormThemPhieuMuon();
        }

        private void LoadData()
        {
            list = MuonTraBUS.LayTatCaPhieuMuon();
            if (_isReader)
            {
                list = string.IsNullOrEmpty(_maDocGiaDangNhap)
                    ? new BindingList<PhieuMuonDTO>()
                    : new BindingList<PhieuMuonDTO>(list.Where(pm => pm.MaDocGia == _maDocGiaDangNhap).ToList());
            }
            ApplyFilters();
        }

        private void DinhDangCotNgay()
        {
            if (dgvPhieuMuon.Columns[nameof(colNgayMuon)] != null)
                dgvPhieuMuon.Columns[nameof(colNgayMuon)].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dgvPhieuMuon.Columns[nameof(colHanTra)] != null)
                dgvPhieuMuon.Columns[nameof(colHanTra)].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void ApplyFilters()
        {
            if (list == null) return;

            string keyword = txtSearch.Text?.Trim().ToLower() ?? string.Empty;
            string trangThai = cbStatusFilter.SelectedItem?.ToString() ?? "Tất cả";

            var filtered = list.AsEnumerable();
            bool coLoc = false;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                filtered = filtered.Where(pm =>
                    pm.MaPhieuMuon.ToLower().Contains(keyword) ||
                    pm.HoTenDocGia.ToLower().Contains(keyword) ||
                    pm.MaDocGia.ToLower().Contains(keyword));
                coLoc = true;
            }

            if (trangThai == "Đang mượn")
            {
                filtered = filtered.Where(pm => pm.SoSachChuaTra > 0);
                coLoc = true;
            }
            else if (trangThai == "Đã trả")
            {
                filtered = filtered.Where(pm => pm.SoSachChuaTra <= 0);
                coLoc = true;
            }
            else if (trangThai == "Quá hạn")
            {
                filtered = filtered.Where(pm => pm.SoSachChuaTra > 0 && DateTime.Today.Date > pm.NgayTraDuKien.Date);
                coLoc = true;
            }

            if (!coLoc)
            {
                dgvPhieuMuon.DataSource = list;
            }
            else
            {
                dgvPhieuMuon.DataSource = new BindingList<PhieuMuonDTO>(filtered.ToList());
            }
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

        private void KhoiTaoCheDoNguoiDung()
        {
            _isReader = SessionManager.CurrentUser?.TenNhomNguoiDung?.Equals("Độc Giả", StringComparison.OrdinalIgnoreCase) == true;
            if (_isReader && SessionManager.GetUserId() is int userId)
            {
                var docGia = DocGiaBUS.GetByUserId(userId);
                _maDocGiaDangNhap = docGia?.MaDocGia;
            }

            btnThem.Visible = !_isReader;
            btnImport.Visible = !_isReader;
            btnExport.Visible = !_isReader;
        }

        private void GiaHanPhieuMuonDuocChon()
        {
            if (dgvPhieuMuon.CurrentRow == null) return;
            var phieu = dgvPhieuMuon.CurrentRow.DataBoundItem as PhieuMuonDTO;
            if (phieu == null) return;

            if (phieu.SoSachChuaTra <= 0)
            {
                MessageBox.Show("Phiếu đã trả hết, không thể gia hạn.");
                return;
            }

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

            if (phieu.SoSachChuaTra <= 0)
            {
                MessageBox.Show("Phiếu đã trả hết sách.");
                return;
            }

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

        private void DgvPhieuMuon_DeleteButtonClicked(object? sender, int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvPhieuMuon.Rows.Count) return;
            dgvPhieuMuon.CurrentCell = dgvPhieuMuon.Rows[rowIndex].Cells[0];
            XoaPhieuMuonDuocChon();
        }

        private void XoaPhieuMuonDuocChon()
        {
            if (dgvPhieuMuon.CurrentRow == null) return;
            var phieu = dgvPhieuMuon.CurrentRow.DataBoundItem as PhieuMuonDTO;
            if (phieu == null) return;

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa phiếu mượn {phieu.MaPhieuMuon}?\nToàn bộ sách sẽ được chuyển về trạng thái sẵn sàng.",
                "Xác nhận",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.OK) return;

            try
            {
                if (MuonTraBUS.XoaPhieuMuon(phieu.ID))
                {
                    list.Remove(phieu);
                    ApplyFilters();
                    MessageBox.Show("Đã xóa phiếu mượn.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                var bytes = MuonTraBUS.ExportPhieuMuonToExcel();
                using SaveFileDialog sfd = new() { Filter = "Excel Workbook|*.xlsx", FileName = "PhieuMuon.xlsx" };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(sfd.FileName, bytes);
                    MessageBox.Show("Xuất danh sách phiếu mượn thành công.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new()
            {
                Filter = "Excel Workbook|*.xlsx;*.xls",
                Title = "Chọn file Excel chứa phiếu mượn"
            };

            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                var result = MuonTraBUS.ImportPhieuMuonFromExcel(ofd.FileName);
                LoadData();
                MessageBox.Show($"Nhập phiếu mượn thành công.\n\n- Đã thêm: {result.importedList.Count} phiếu.\n- Thất bại: {result.fail} hàng.", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể nhập Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
