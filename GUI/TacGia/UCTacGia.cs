using ClosedXML.Excel;
using DAO;
using DTO;
using GUI.Helpers;
using System.ComponentModel;
using System.Data;

namespace GUI.TacGia // (Hoặc namespace GUI.DanhMuc... của bạn)
{
    public partial class UCTacGia : UserControl
    {
        private BindingList<TacGiaDTO> list;

        public UCTacGia()
        {
            InitializeComponent();
        }

        private void UCTacGia_Load(object sender, EventArgs e)
        {
            dgvTacGia.AutoGenerateColumns = false;

            // Tải dữ liệu
            list = BUS.TacGiaBUS.GetAll();
            dgvTacGia.DataSource = list;

            // Gán sự kiện cho các nút Sửa/Xóa trong DataGridView
            dgvTacGia.EditButtonClicked += EditButtonClicked;
            dgvTacGia.DeleteButtonClicked += DeleteButtonClicked;
            dgvTacGia.ViewButtonClicked += ViewButtonClicked;

            LoadPermissions();
        }

        public void LoadPermissions()
        {
            int permissionCode = (int)Helpers.Permission.TacGia;
            bool canAdd = SessionManager.HasPermission(permissionCode, Helpers.Action.Add);
            btnAdd.Visible = canAdd;

            bool canEdit = SessionManager.HasPermission(permissionCode, Helpers.Action.Edit);
            dgvTacGia.ShowEditButton = canEdit;

            bool canDelete = SessionManager.HasPermission(permissionCode, Helpers.Action.Delete);
            dgvTacGia.ShowDeleteButton = canDelete;

            if (!canEdit && !canDelete)
            {
                if (dgvTacGia.Columns.Contains("Actions"))
                    dgvTacGia.Columns["Actions"].Visible = false;
            }

            bool isReader = SessionManager.CurrentUser.TenNhomNguoiDung.Equals("Độc giả", StringComparison.OrdinalIgnoreCase);
            btnImport.Visible = !isReader;
            btnExport.Visible = !isReader;
        }

        private void DgvTacGia_ViewButtonClicked(object? sender, int e)
        {
            throw new NotImplementedException();
        }

        private void btnThemTacGia_Click(object sender, EventArgs e)
        {
            FrmAddEditTacGia frm = new FrmAddEditTacGia();
            frm.Text = "Thêm Tác giả";
            var result = frm.ShowDialog();

            // Nếu Form thêm trả về OK, thêm DTO mới vào BindingList
            // BindingList sẽ tự động cập nhật DataGridView
            if (result == DialogResult.OK)
            {
                list.Add(frm.TacGia);
            }
        }

        private void EditButtonClicked(object? sender, int index)
        {
            if (index < 0) return;

            // [QUAN TRỌNG] Lấy object từ dòng hiện tại trên Grid (đã lọc) chứ không lấy từ list gốc
            var selectedTacGia = dgvTacGia.Rows[index].DataBoundItem as TacGiaDTO;
            if (selectedTacGia == null) return;

            FrmAddEditTacGia frm = new FrmAddEditTacGia();
            frm.Text = "Chỉnh sửa Tác giả";
            frm.TacGia = selectedTacGia;

            var result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {                
                UCTacGia_Load(null, null);
            }
        }

        private void DeleteButtonClicked(object? sender, int index)
        {
            if (index < 0) return;

            // [QUAN TRỌNG] Lấy object từ dòng hiện tại
            var selectedTacGia = dgvTacGia.Rows[index].DataBoundItem as TacGiaDTO;
            if (selectedTacGia == null) return;

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa tác giả: {selectedTacGia.TenTacGia}?",
                                          "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    if (BUS.TacGiaBUS.Delete(selectedTacGia.MaTacGia))
                    {
                        MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Load lại dữ liệu
                        UCTacGia_Load(null, null);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ViewButtonClicked(object? sender, int index)
        {
            if (index < 0 || index >= list.Count) return;

            // Lấy tác giả được chọn
            TacGiaDTO selectedTacGia = list[index];

            // Mở form danh sách sách, truyền Mã và Tên tác giả sang
            FrmDanhSachSachTheoTacGia frm = new FrmDanhSachSachTheoTacGia(
                selectedTacGia.MaTacGia,
                selectedTacGia.TenTacGia
            );

            frm.StartPosition = FormStartPosition.CenterParent; // Căn giữa cho đẹp
            frm.ShowDialog();
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (list == null) return;

            // 1. Lấy từ khóa, chuyển về chữ thường và xóa khoảng trắng
            string tuKhoa = txtSearch.Text.ToLower().Trim();

            // 2. Nếu ô tìm kiếm trống, hiển thị lại TOÀN BỘ danh sách gốc
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                dgvTacGia.DataSource = list;
                return;
            }

            // 3. Nếu có từ khóa, dùng LINQ để lọc
            var danhSachLoc = list.Where(dto =>
                                    dto.TenTacGia.ToLower().Contains(tuKhoa) ||
                                    dto.MaTacGia.ToLower().Contains(tuKhoa)
                                 ).ToList(); // Chuyển kết quả lọc thành một List<> mới

            // 4. Tạo một BindingList MỚI từ danh sách đã lọc và gán lại cho DataGridView
            dgvTacGia.DataSource = new BindingList<TacGiaDTO>(danhSachLoc);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem có dữ liệu không
            if (list == null || list.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo");
                return;
            }

            // 2. Mở hộp thoại chọn nơi lưu
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Workbook|*.xlsx";
            sfd.FileName = "DanhSachTacGia.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 3. Tạo file Excel bằng ClosedXML
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Tác giả");

                        // 4. Tạo tiêu đề cột (Header)
                        worksheet.Cell(1, 1).Value = "Mã Tác giả";
                        worksheet.Cell(1, 2).Value = "Tên Tác giả";
                        worksheet.Cell(1, 3).Value = "Năm sinh";

                        // Định dạng Header 
                        var headerRow = worksheet.Range("A1:C1");
                        headerRow.Style.Font.Bold = true;
                        headerRow.Style.Fill.BackgroundColor = XLColor.LightGray;

                        // 5. Đổ dữ liệu từ List vào Excel
                        for (int i = 0; i < list.Count; i++)
                        {
                            worksheet.Cell(i + 2, 1).Value = list[i].MaTacGia;
                            worksheet.Cell(i + 2, 2).Value = list[i].TenTacGia;
                            if (list[i].NamSinh > 0)
                            {
                                worksheet.Cell(i + 2, 3).Value = list[i].NamSinh;
                            }
                            else
                            {
                                worksheet.Cell(i + 2, 3).Value = "";
                            }
                        }

                        // Tự động chỉnh độ rộng cột
                        worksheet.Columns().AdjustToContents();

                        // 6. Lưu file
                        workbook.SaveAs(sfd.FileName);
                    }

                    MessageBox.Show("Xuất file Excel thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi");
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Workbook|*.xlsx";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new XLWorkbook(ofd.FileName))
                    {
                        var worksheet = workbook.Worksheet(1);
                        var rows = worksheet.RangeUsed().RowsUsed().Skip(1); 

                        int countSuccess = 0;
                        int countFail = 0; // Số dòng bị bỏ qua do trùng

                        foreach (var row in rows)
                        {
                            // 1.Tên (Cột 2)
                            string tenTacGia = row.Cell(2).GetValue<string>().Trim();
                            if (string.IsNullOrEmpty(tenTacGia)) continue;

                            // 2.Năm sinh (Cột 3) - [SỬA QUAN TRỌNG]
                            int namSinh = 0;
                            var cellNamSinh = row.Cell(3);
                            if (!cellNamSinh.IsEmpty())
                            {
                                int.TryParse(cellNamSinh.GetValue<string>(), out namSinh);
                            }

                            // 3. Kiểm tra trùng
                            if (!DAO.TacGiaDAO.IsNameExist(tenTacGia, namSinh))
                            {
                                TacGiaDTO newTG = new TacGiaDTO(tenTacGia, namSinh);
                                BUS.TacGiaBUS.Add(newTG);
                                countSuccess++;
                            }
                            else
                            {
                                countFail++;
                            }
                        }

                        // Load lại 
                        UCTacGia_Load(null, null);

                        MessageBox.Show($"Nhập dữ liệu hoàn tất!\n- Thêm mới thành công: {countSuccess}\n- Bỏ qua (đã tồn tại): {countFail}",
                            "Kết quả Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đọc file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}