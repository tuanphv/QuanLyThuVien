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
            if (index < 0 || index >= list.Count) return;

            // Lấy DTO từ BindingList
            TacGiaDTO selectedTacGia = list[index];

            // Mở Form ở chế độ Sửa
            FrmAddEditTacGia frm = new FrmAddEditTacGia();
            frm.Text = "Chỉnh sửa Tác giả";
            frm.TacGia = selectedTacGia; // Truyền DTO vào Form

            var result = frm.ShowDialog();

            // Nếu Form sửa trả về OK, cập nhật lại DTO trong BindingList
            if (result == DialogResult.OK)
            {
                list[index] = frm.TacGia; // DTO đã được cập nhật
            }
        }

        private void DeleteButtonClicked(object? sender, int index)
        {
            if (index < 0 || index >= list.Count) return;

            TacGiaDTO selectedTacGia = list[index];

            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa tác giả này?", "Xác nhận xóa",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    // Gọi BUS để xóa
                    if (BUS.TacGiaBUS.Delete(selectedTacGia.MaTacGia))
                    {
                        // Xóa khỏi BindingList, DataGridView tự cập nhật
                        list.RemoveAt(index);
                        MessageBox.Show("Xóa thành công.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    // Bắt lỗi nghiệp vụ (ví dụ: "Không thể xóa...")
                    MessageBox.Show(ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        var worksheet = workbook.Worksheet(1); // Lấy sheet đầu tiên
                        var rows = worksheet.RangeUsed().RowsUsed().Skip(1); // Bỏ qua dòng tiêu đề (dòng 1)

                        int countSuccess = 0;
                        int countFail = 0;

                        foreach (var row in rows)
                        {
                            // Đọc dữ liệu từ cột 2 (Tên Thể Loại). Cột 1 là Mã thì tự sinh nên ko cần đọc.
                            string tenTacGia = row.Cell(2).GetValue<string>().Trim();

                            if (string.IsNullOrEmpty(tenTacGia)) continue;
                            int namSinh = 0; // Khai báo năm sinh mặc định là 0 cho file Excel

                            if (!DAO.TacGiaDAO.IsNameExist(tenTacGia, namSinh))
                            {
                                // Tạo DTO mới
                                TacGiaDTO newTG = new TacGiaDTO(tenTacGia, 0);

                                // Gọi BUS để thêm vào DB (Hàm Add sẽ tự sinh Mã)
                                BUS.TacGiaBUS.Add(newTG);

                                countSuccess++;
                            }
                            else
                            {
                                countFail++; // Bỏ qua vì trùng tên
                            }
                        }

                        // Load lại dữ liệu lên Grid
                        UCTacGia_Load(null, null);

                        MessageBox.Show($"Đã nhập xong!\n- Thành công: {countSuccess}\n- Bỏ qua (trùng): {countFail}", "Kết quả");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đọc file: " + ex.Message, "Lỗi");
                }
            }
        }
    }
}