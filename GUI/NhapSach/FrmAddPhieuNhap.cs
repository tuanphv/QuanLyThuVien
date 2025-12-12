using BUS;
using DTO;

namespace GUI.NhapSach
{
    public partial class FrmAddPhieuNhap : Form
    {
        private class Range
        {
            public int Start { get; set; }
            public int End { get; set; }
        }

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
            public List<Range> MaCuonSach { get; set; } = new List<Range>();
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
                MessageBox.Show($"Lỗi khi tải nhà cung cấp: {ex.Message}", "Lỗi",
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
                MessageBox.Show($"Lỗi khi tải tựa sách: {ex.Message}", "Lỗi",
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
                MessageBox.Show($"Lỗi khi tải nhà xuất bản: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbTuaSach.SelectedValue == null || cbNhaXuatBan.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn tựa sách và nhà xuất bản.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var tuaSach = cbTuaSach.SelectedItem as TuaSachDTO;
                var nhaXuatBan = cbNhaXuatBan.SelectedItem as NhaXuatBanDTO;

                if (tuaSach == null || nhaXuatBan == null) return;

                // Kiểm tra mã cuốn sách đã tồn tại chưa
                var sach = SachBUS.FindByTuaSachAndNXBAndNamXB(tuaSach.ID, nhaXuatBan.ID, (int)nudNamXB.Value);

                if (sach != null)
                {

                    string maCS = CuonSachBUS.KiemTraMaCuonSach(sach.ID, (int)nudMaDau.Value, (int)nudMaCuoi.Value);
                    if (maCS != string.Empty)
                    {
                        MessageBox.Show($"Mã cuốn sách {maCS} đã tồn tại trong hệ thống. Vui lòng kiểm tra lại.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Kiểm tra xem đã có trong danh sách chưa
                var existing = chiTietList.FirstOrDefault(x =>
                    x.IDTuaSach == tuaSach.ID &&
                    x.IDNhaXuatBan == nhaXuatBan.ID &&
                    x.NamXB == (int)nudNamXB.Value);

                if (existing != null)
                {
                    // Nếu đã có
                    // -> Cập nhật số lượng và mã sách
                    foreach (var range in existing.MaCuonSach)
                    {
                        if (range.End >= (int)nudMaDau.Value && range.Start <= (int)nudMaCuoi.Value)
                        {
                            MessageBox.Show("Dãy mã cuốn sách bị trùng với dãy đã thêm trước đó.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    existing.SoLuong += (int)nudSoLuong.Value;
                    existing.MaCuonSach.Add(new Range
                    {
                        Start = (int)nudMaDau.Value,
                        End = (int)nudMaCuoi.Value
                    });
                }
                else
                {
                    // Thêm vào danh sách
                    var item = new ChiTietNhapItem
                    {
                        IDTuaSach = tuaSach.ID,
                        TenTuaSach = tuaSach.TenTuaSach,
                        IDNhaXuatBan = nhaXuatBan.ID,
                        TenNhaXuatBan = nhaXuatBan.TenNXB,
                        NamXB = (int)nudNamXB.Value,
                        SoLuong = (int)nudSoLuong.Value,
                        DonGia = (int)nudDonGia.Value,
                        MaCuonSach = new List<Range>
                        {
                            new Range
                            {
                                Start = (int)nudMaDau.Value,
                                End = (int)nudMaCuoi.Value
                            }
                        }
                    };
                    chiTietList.Add(item);
                }
                RefreshDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    item.DonGia.ToString("#,##0 đ"),
                    item.ThanhTien.ToString("#,##0 đ")
                );
                tongTien += item.ThanhTien;
            }

            lblTongTien.Text = tongTien.ToString("#,##0 VNĐ");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbNhaCungCap.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.None;
                    return;
                }

                if (chiTietList.Count == 0)
                {
                    MessageBox.Show("Vui lòng thêm ít nhất một sách vào phiếu nhập.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.None;
                    return;
                }

                // Tạo phiếu nhập
                var phieu = new PhieuNhapSachDTO
                {
                    IDNhaCungCap = (int)cbNhaCungCap.SelectedValue,
                    NgayNhap = dtpNgayNhap.Value
                };

                // Tạo danh sách chi tiết và xử lý Sach/CuonSach
                var chiTiet = new List<CT_PhieuNhapDTO>();

                foreach (var item in chiTietList)
                {
                    // Tìm hoặc tạo mới lô sách
                    var sach = SachBUS.FindByTuaSachAndNXBAndNamXB(item.IDTuaSach, item.IDNhaXuatBan, item.NamXB);

                    int idSach;
                    if (sach == null)
                    {
                        // Tạo phiên bản sách mới
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

                    foreach (var range in item.MaCuonSach)
                    {
                        // Tạo danh sách mã cuốn sách từ dãy
                        for (int ma = range.Start; ma <= range.End; ma++)
                        {
                            // Thêm mã cuốn sách vào danh sách
                            var cuonSach = new CuonSachDTO
                            {
                                IDSach = idSach,
                                MaCuonSach = $"S{idSach.ToString().PadLeft(4, '0')}-{ma.ToString().PadLeft(4, '0')}"
                            };
                            CuonSachBUS.ThemCuonSach(cuonSach);
                        }
                    }

                    // Thêm vào chi tiết phiếu nhập
                    chiTiet.Add(new CT_PhieuNhapDTO
                    {
                        IDSach = idSach,
                        SoLuongNhap = item.SoLuong,
                        DonGiaNhap = item.DonGia,
                        ThanhTien = item.ThanhTien,
                    });
                }

                // Lỗi phiếu nhập
                PhieuNhapSachBUS.Add(phieu, chiTiet);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu phiếu nhập: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }

        private void nudSoLuong_ValueChanged(object sender, EventArgs e)
        {
            nudMaCuoi.Value = nudSoLuong.Value + nudMaDau.Value - 1;
        }

        private void nudMaDau_ValueChanged(object sender, EventArgs e)
        {
            if (nudMaDau.Value > nudMaCuoi.Value)
            {
                nudMaCuoi.Value = nudMaDau.Value;
            }
            nudSoLuong.Value = nudMaCuoi.Value - nudMaDau.Value + 1;
        }

        private void nudMaCuoi_ValueChanged(object sender, EventArgs e)
        {
            if (nudMaDau.Value > nudMaCuoi.Value)
            {
                nudMaDau.Value = nudMaCuoi.Value;
            }
            nudSoLuong.Value = nudMaCuoi.Value - nudMaDau.Value + 1;
        }

        public List<int> ParseRanges(string input)
        {
            var result = new List<int>();
            var parts = input.Split(',');

            foreach (var part in parts)
            {
                var range = part.Trim();

                if (range.Contains("-"))
                {
                    var bounds = range.Split('-');
                    int start = int.Parse(bounds[0]);
                    int end = int.Parse(bounds[1]);

                    for (int i = start; i <= end; i++)
                    {
                        result.Add(i);
                    }
                }
                else
                {
                    result.Add(int.Parse(range));
                }
            }

            return result;
        }

    }
}
