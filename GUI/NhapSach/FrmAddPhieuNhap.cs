using BUS;
using DTO;

namespace GUI.NhapSach
{
    public partial class FrmAddPhieuNhap : Form
    {
        private class ChiTietNhapItem
        {
            public int IDTuaSach { get; set; }
            public string TenTuaSach { get; set; } = string.Empty;
            public int IDNhaXuatBan { get; set; }
            public string TenNhaXuatBan { get; set; } = string.Empty;
            public int NamXB { get; set; }
            public int SoLuong { get; set; }
            public int DonGia { get; set; }
            public int ThanhTien => SoLuong * DonGia;
        }

        private List<ChiTietNhapItem> chiTietList = new List<ChiTietNhapItem>();

        public FrmAddPhieuNhap()
        {
            InitializeComponent();
        }

        private void FrmAddPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadNhaCungCap();
            LoadTuaSach();
            LoadNhaXuatBan();
            dtpNgayNhap.Value = DateTime.Now;
        }

        private void LoadNhaCungCap()
        {
            try
            {
                var list = NhaCungCapBUS.GetAll();
                cbNhaCungCap.DataSource = list;
                cbNhaCungCap.DisplayMember = "TenNCC";
                cbNhaCungCap.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"L?i khi t?i nhà cung c?p: {ex.Message}", "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTuaSach()
        {
            try
            {
                var list = TuaSachBUS.GetAll();
                cbTuaSach.DataSource = list;
                cbTuaSach.DisplayMember = "TenTuaSach";
                cbTuaSach.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"L?i khi t?i t?a sách: {ex.Message}", "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadNhaXuatBan()
        {
            try
            {
                var list = NhaXuatBanBUS.GetAll();
                cbNhaXuatBan.DataSource = list;
                cbNhaXuatBan.DisplayMember = "TenNXB";
                cbNhaXuatBan.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"L?i khi t?i nhà xu?t b?n: {ex.Message}", "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbTuaSach.SelectedValue == null || cbNhaXuatBan.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng ch?n t?a sách và nhà xu?t b?n.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var tuaSach = cbTuaSach.SelectedItem as TuaSachDTO;
                var nhaXuatBan = cbNhaXuatBan.SelectedItem as NhaXuatBanDTO;

                if (tuaSach == null || nhaXuatBan == null) return;

                // Ki?m tra xem ?ã có trong danh sách ch?a
                var existing = chiTietList.FirstOrDefault(x =>
                    x.IDTuaSach == tuaSach.ID &&
                    x.IDNhaXuatBan == nhaXuatBan.ID &&
                    x.NamXB == (int)nudNamXB.Value);

                if (existing != null)
                {
                    MessageBox.Show("Sách v?i thông tin này ?ã có trong danh sách nh?p.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thêm vào danh sách
                var item = new ChiTietNhapItem
                {
                    IDTuaSach = tuaSach.ID,
                    TenTuaSach = tuaSach.TenTuaSach,
                    IDNhaXuatBan = nhaXuatBan.ID,
                    TenNhaXuatBan = nhaXuatBan.TenNXB,
                    NamXB = (int)nudNamXB.Value,
                    SoLuong = (int)nudSoLuong.Value,
                    DonGia = (int)nudDonGia.Value
                };

                chiTietList.Add(item);
                RefreshDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"L?i: {ex.Message}", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = dgvChiTiet.SelectedRows[0].Index;
            chiTietList.RemoveAt(index);
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            dgvChiTiet.Rows.Clear();
            int tongTien = 0;

            foreach (var item in chiTietList)
            {
                dgvChiTiet.Rows.Add(
                    item.TenTuaSach,
                    item.TenNhaXuatBan,
                    item.NamXB,
                    item.SoLuong,
                    item.DonGia.ToString("#,##0 ?"),
                    item.ThanhTien.ToString("#,##0 ?")
                );
                tongTien += item.ThanhTien;
            }

            lblTongTien.Text = tongTien.ToString("#,##0 ?");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbNhaCungCap.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng ch?n nhà cung c?p.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.None;
                    return;
                }

                if (chiTietList.Count == 0)
                {
                    MessageBox.Show("Vui lòng thêm ít nh?t m?t sách vào phi?u nh?p.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.None;
                    return;
                }

                // T?o phi?u nh?p
                var phieu = new PhieuNhapSachDTO
                {
                    IDNhaCungCap = (int)cbNhaCungCap.SelectedValue,
                    NgayNhap = dtpNgayNhap.Value
                };

                // T?o danh sách chi ti?t và x? lý Sach/CuonSach
                var chiTiet = new List<CT_PhieuNhapDTO>();

                foreach (var item in chiTietList)
                {
                    // Tìm ho?c t?o m?i lô sách
                    var sach = SachBUS.FindByTuaSachAndNXBAndNamXB(item.IDTuaSach, item.IDNhaXuatBan, item.NamXB);

                    int idSach;
                    if (sach == null)
                    {
                        // T?o lô sách m?i
                        var sachMoi = new SachDTO
                        {
                            IDTuaSach = item.IDTuaSach,
                            IDNhaXuatBan = item.IDNhaXuatBan,
                            NamXB = item.NamXB,
                            SoLuongTong = 0,
                            SoLuongConLai = 0,
                            DonGia = item.DonGia
                        };
                        idSach = SachBUS.Add(sachMoi);
                    }
                    else
                    {
                        idSach = sach.ID;
                    }

                    // Thêm vào chi ti?t phi?u nh?p
                    chiTiet.Add(new CT_PhieuNhapDTO
                    {
                        IDSach = idSach,
                        SoLuongNhap = item.SoLuong,
                        DonGiaNhap = item.DonGia,
                        ThanhTien = item.ThanhTien
                    });
                }

                // L?u phi?u nh?p
                PhieuNhapSachBUS.Add(phieu, chiTiet);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"L?i khi l?u phi?u nh?p: {ex.Message}", "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
