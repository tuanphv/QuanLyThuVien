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
            // Load báo cáo quá hạn cũ (theo phiếu mượn)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (listNoDocGia == null || listNoDocGia.Count == 0) return;

            string tuKhoa = txtTimKiem.Text.ToLower().Trim();

            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                listNoDocGiaFiltered = listNoDocGia;
                dgvQuaHan.DataSource = listNoDocGiaFiltered;
                return;
            }

            var danhSachLoc = listNoDocGia.Where(dto =>
                dto.MaDocGia.ToLower().Contains(tuKhoa) ||
                dto.HoTen.ToLower().Contains(tuKhoa)
            ).ToList();

            listNoDocGiaFiltered = new BindingList<BaoCaoNoDocGiaDTO>(danhSachLoc);
            dgvQuaHan.DataSource = listNoDocGiaFiltered;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (listNoDocGiaFiltered == null || listNoDocGiaFiltered.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Workbook|*.xlsx";
            sfd.FileName = $"BaoCaoNoQuaHan_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Báo Cáo Nợ");

                        // Title
                        worksheet.Cell(1, 1).Value = "BÁO CÁO NỢ QUÁ HẠN";
                        worksheet.Cell(1, 1).Style.Font.Bold = true;
                        worksheet.Cell(1, 1).Style.Font.FontSize = 16;
                        worksheet.Range("A1:E1").Merge();
                        worksheet.Range("A1:E1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        worksheet.Cell(2, 1).Value = "Ngày xuất:";
                        worksheet.Cell(2, 2).Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                        worksheet.Range("B2:E2").Merge();

                        // Header
                        worksheet.Cell(4, 1).Value = "Mã Độc Giả";
                        worksheet.Cell(4, 2).Value = "Họ Tên";
                        worksheet.Cell(4, 3).Value = "Nợ Hiện Tại";
                        worksheet.Cell(4, 4).Value = "Số Sách Quá Hạn";
                        worksheet.Cell(4, 5).Value = "Tổng Nợ Ước Tính";

                        var headerRow = worksheet.Range("A4:E4");
                        headerRow.Style.Font.Bold = true;
                        headerRow.Style.Fill.BackgroundColor = XLColor.LightBlue;
                        headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        headerRow.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                        // Data
                        for (int i = 0; i < listNoDocGiaFiltered.Count; i++)
                        {
                            var item = listNoDocGiaFiltered[i];
                            int rowIndex = i + 5;

                            worksheet.Cell(rowIndex, 1).Value = item.MaDocGia;
                            worksheet.Cell(rowIndex, 2).Value = item.HoTen;
                            worksheet.Cell(rowIndex, 3).Value = item.NoHienTai;
                            worksheet.Cell(rowIndex, 4).Value = item.SoSachQuaHan;
                            worksheet.Cell(rowIndex, 5).Value = item.TongNoUocTinh;

                            worksheet.Cell(rowIndex, 3).Style.NumberFormat.Format = "#,##0";
                            worksheet.Cell(rowIndex, 5).Style.NumberFormat.Format = "#,##0";
                        }

                        // Total
                        int totalRow = listNoDocGiaFiltered.Count + 5;
                        worksheet.Cell(totalRow, 1).Value = "TỔNG CỘNG";
                        worksheet.Cell(totalRow, 1).Style.Font.Bold = true;
                        worksheet.Range($"A{totalRow}:B{totalRow}").Merge();
                        
                        int tongNoHienTai = listNoDocGiaFiltered.Sum(x => x.NoHienTai);
                        int tongSachQuaHan = listNoDocGiaFiltered.Sum(x => x.SoSachQuaHan);
                        int tongNoUocTinh = listNoDocGiaFiltered.Sum(x => x.TongNoUocTinh);

                        worksheet.Cell(totalRow, 3).Value = tongNoHienTai;
                        worksheet.Cell(totalRow, 4).Value = tongSachQuaHan;
                        worksheet.Cell(totalRow, 5).Value = tongNoUocTinh;

                        worksheet.Cell(totalRow, 3).Style.NumberFormat.Format = "#,##0";
                        worksheet.Cell(totalRow, 3).Style.Font.Bold = true;
                        worksheet.Cell(totalRow, 4).Style.Font.Bold = true;
                        worksheet.Cell(totalRow, 5).Style.NumberFormat.Format = "#,##0";
                        worksheet.Cell(totalRow, 5).Style.Font.Bold = true;

                        // Border
                        var dataRange = worksheet.Range($"A4:E{totalRow}");
                        dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                        dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                        worksheet.Columns().AdjustToContents();

                        workbook.SaveAs(sfd.FileName);
                    }

                    MessageBox.Show("Xuất file Excel thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var openFile = MessageBox.Show("Bạn có muốn mở file vừa xuất không?", "Mở file",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (openFile == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = sfd.FileName,
                            UseShellExecute = true
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvQuaHan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= listNoDocGiaFiltered.Count) return;

            var selectedItem = listNoDocGiaFiltered[e.RowIndex];
            
            if (selectedItem.SoSachQuaHan > 0)
            {
                FrmChiTietSachQuaHan frm = new FrmChiTietSachQuaHan(
                    selectedItem.MaDocGia, 
                    selectedItem.HoTen);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Độc giả này không có sách quá hạn.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
