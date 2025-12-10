using DTO;
using System.ComponentModel;
using GUI.Helpers;
using ClosedXML.Excel;

namespace GUI.DocGia
{
    public partial class UCDocGia : UserControl
    {
        private bool _isLoaded = false;

        private BindingList<DocGiaDTO> list;

        public UCDocGia()
        {
            InitializeComponent();
            this.VisibleChanged += UCDocGia_VisibleChanged;
        }

        private void LoadPermissions()
        {
            int permissionCode = (int)Helpers.Permission.DocGia;
            bool canAdd = SessionManager.HasPermission(permissionCode, Helpers.Action.Add);
            btnThemDocGia.Visible = canAdd;
            

            bool canEdit = SessionManager.HasPermission(permissionCode, Helpers.Action.Edit);
            dgvDocGia.ShowEditButton = canEdit;

            bool canDelete = SessionManager.HasPermission(permissionCode, Helpers.Action.Delete);
            dgvDocGia.ShowDeleteButton = canDelete;
        }

        private void UCDocGia_Load(object sender, EventArgs e)
        {
            dgvDocGia.AutoGenerateColumns = false;

            LoadData();

            dgvDocGia.EditButtonClicked += EditButtonClicked;
            dgvDocGia.DeleteButtonClicked += DeleteButtonClicked;

            // Apply permissions after DataGridView and its columns are ready
            LoadPermissions();
            _isLoaded = true;
        }

        private void UCDocGia_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && _isLoaded)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            try
            {
                list = BUS.DocGiaBUS.GetAll();
                dgvDocGia.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemDocGia_Click(object sender, EventArgs e)
        {
            FrmAddEditDocGia frm = new FrmAddEditDocGia();
            frm.Text = "Thêm độc giả";
            var result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                list.Add(frm.DocGia);
            }
        }

        private void EditButtonClicked(object? sender, int index)
        {
            if (index < 0 || index >= list.Count) return;

            DocGiaDTO selectedDocGia = list[index];

            FrmAddEditDocGia frm = new FrmAddEditDocGia();
            frm.Text = "Chỉnh sữa độc giả";
            frm.DocGia = selectedDocGia;

            var result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                list[index] = frm.DocGia;
            }
        }

        private void DeleteButtonClicked(object? sender, int index)
        {
            if (index < 0 || index >= list.Count) return;

            DocGiaDTO selectedDocGia = list[index];

            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa độc giả '{selectedDocGia.HoTen}'?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    if (BUS.DocGiaBUS.Delete(selectedDocGia.MaDocGia))
                    {
                        list.RemoveAt(index);
                        MessageBox.Show("Xóa thành công.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (list == null) return;

            string tuKhoa = txtTimKiem.Text.ToLower().Trim();

            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                dgvDocGia.DataSource = list;
                return;
            }

            var danhSachLoc = list.Where(dto =>
                dto.HoTen.ToLower().Contains(tuKhoa) ||
                dto.MaDocGia.ToLower().Contains(tuKhoa) ||
                (dto.DiaChi != null && dto.DiaChi.ToLower().Contains(tuKhoa)) ||
                (dto.TenDangNhap != null && dto.TenDangNhap.ToLower().Contains(tuKhoa))
            ).ToList();

            dgvDocGia.DataSource = new BindingList<DocGiaDTO>(danhSachLoc);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem có dữ liệu không
            if (list == null || list.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Mở hộp thoại chọn nơi lưu
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Workbook|*.xlsx";
            sfd.FileName = $"DanhSachDocGia_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 3. Tạo file Excel bằng ClosedXML
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Độc Giả");

                        // 4. Tạo tiêu đề cột (Header)
                        worksheet.Cell(1, 1).Value = "Mã độc giả";
                        worksheet.Cell(1, 2).Value = "Họ tên";
                        worksheet.Cell(1, 3).Value = "Ngày sinh";
                        worksheet.Cell(1, 4).Value = "Ngày lập thẻ";
                        worksheet.Cell(1, 5).Value = "Ngày hết hạn";
                        worksheet.Cell(1, 6).Value = "Tổng nợ";
                        worksheet.Cell(1, 7).Value = "Tên đăng nhập";

                        // Định dạng Header cho đẹp (In đậm, nền xanh)
                        var headerRow = worksheet.Range("A1:H1");
                        headerRow.Style.Font.Bold = true;
                        headerRow.Style.Fill.BackgroundColor = XLColor.LightBlue;
                        headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        headerRow.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                        // 5. Đổ dữ liệu từ List vào Excel
                        for (int i = 0; i < list.Count; i++)
                        {
                            var docGia = list[i];
                            int rowIndex = i + 2;

                            worksheet.Cell(rowIndex, 1).Value = docGia.MaDocGia;
                            worksheet.Cell(rowIndex, 2).Value = docGia.HoTen;
                            worksheet.Cell(rowIndex, 3).Value = docGia.NgaySinh.ToString("dd/MM/yyyy");
                            worksheet.Cell(rowIndex, 4).Value = docGia.NgayLapThe.ToString("dd/MM/yyyy");
                            worksheet.Cell(rowIndex, 5).Value = docGia.NgayHetHan.ToString("dd/MM/yyyy");
                            worksheet.Cell(rowIndex, 6).Value = docGia.TongNoHienTai;
                            worksheet.Cell(rowIndex, 7).Value = docGia.TenDangNhap ?? "";

                            // Định dạng số tiền
                            worksheet.Cell(rowIndex, 7).Style.NumberFormat.Format = "#,##0";
                        }

                        // Thêm border cho toàn bộ dữ liệu
                        var dataRange = worksheet.Range($"A1:H{list.Count + 1}");
                        dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                        dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                        // Tự động chỉnh độ rộng cột
                        worksheet.Columns().AdjustToContents();

                        // 6. Lưu file
                        workbook.SaveAs(sfd.FileName);
                    }

                    MessageBox.Show("Xuất file Excel thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Hỏi người dùng có muốn mở file không
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
    }
}
