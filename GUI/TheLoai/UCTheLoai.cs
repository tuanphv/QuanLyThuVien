using DTO;
using System.ComponentModel;
using System.Data;
using GUI.Helpers;
using ClosedXML.Excel;

namespace GUI.TheLoai // (Hoặc namespace GUI.DanhMuc... của bạn)
{
    public partial class UCTheLoai : UserControl
    {
        private BindingList<TheLoaiDTO> list;

        public UCTheLoai()
        {
            InitializeComponent();
        }

        private void UCTheLoai_Load(object sender, EventArgs e)
        {
            dgvTheLoai.AutoGenerateColumns = false;

            // Tải dữ liệu
            list = BUS.TheLoaiBUS.GetAll();
            dgvTheLoai.DataSource = list;

            // Gán sự kiện cho các nút Sửa/Xóa trong DataGridView
            dgvTheLoai.EditButtonClicked += EditButtonClicked;
            dgvTheLoai.DeleteButtonClicked += DeleteButtonClicked;
            dgvTheLoai.ViewButtonClicked += ViewButtonClicked;

            LoadPermissions();
        }

        private void LoadPermissions()
        {
            int permissionCode = (int)Helpers.Permission.TheLoai;
            bool canAdd = SessionManager.HasPermission(permissionCode, Helpers.Action.Add);
            btnThemTheLoai.Visible = canAdd;

            bool canEdit = SessionManager.HasPermission(permissionCode, Helpers.Action.Edit);
            dgvTheLoai.ShowEditButton = canEdit;

            bool canDelete = SessionManager.HasPermission(permissionCode, Helpers.Action.Delete);
            dgvTheLoai.ShowDeleteButton = canDelete;

            if (!canEdit && !canDelete)
            {
                if (dgvTheLoai.Columns.Contains("Actions"))
                    dgvTheLoai.Columns["Actions"].Visible = false;
            }
        }

        private void btnThemTheLoai_Click(object sender, EventArgs e)
        {
            FrmAddEditTheLoai frm = new FrmAddEditTheLoai();
            frm.Text = "Thêm Thể loại";
            var result = frm.ShowDialog();

            // Nếu Form thêm trả về OK, thêm DTO mới vào BindingList
            // BindingList sẽ tự động cập nhật DataGridView
            if (result == DialogResult.OK)
            {
                list.Add(frm.TheLoai);
            }
        }

        private void EditButtonClicked(object? sender, int index)
        {
            if (index < 0 || index >= list.Count) return;

            // Lấy DTO từ BindingList
            TheLoaiDTO selectedTheLoai = list[index];

            // Mở Form ở chế độ Sửa
            FrmAddEditTheLoai frm = new FrmAddEditTheLoai();
            frm.Text = "Chỉnh sửa Thể loại";
            frm.TheLoai = selectedTheLoai; // Truyền DTO vào Form

            var result = frm.ShowDialog();

            // Nếu Form sửa trả về OK, cập nhật lại DTO trong BindingList
            if (result == DialogResult.OK)
            {
                list[index] = frm.TheLoai; // DTO đã được cập nhật
            }
        }

        private void DeleteButtonClicked(object? sender, int index)
        {
            if (index < 0 || index >= list.Count) return;

            TheLoaiDTO selectedTheLoai = list[index];

            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa thể loại này?", "Xác nhận xóa",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    // Gọi BUS để xóa
                    if (BUS.TheLoaiBUS.Delete(selectedTheLoai.MaTheLoai))
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
            // 1. Kiểm tra index hợp lệ
            if (index < 0 || index >= list.Count) return;

            // 2. Lấy thể loại được chọn từ 'list' (BindingList)
            TheLoaiDTO selectedTheLoai = list[index];

            // 3. Tạo và mở Form mới, truyền Mã và Tên thể loại qua
            FrmDanhSachSachTheoTheLoai frm = new FrmDanhSachSachTheoTheLoai(
                selectedTheLoai.MaTheLoai,
                selectedTheLoai.TenTheLoai
            );

            // 4. Dùng ShowDialog() để mở form
            frm.ShowDialog();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            // 'list' là danh sách BindingList<TheLoaiDTO> gốc mà bạn đã tải lúc Load
            if (list == null) return;

            // 1. Lấy từ khóa, chuyển về chữ thường và xóa khoảng trắng
            string tuKhoa = txtTimKiem.Text.ToLower().Trim();

            // 2. Nếu ô tìm kiếm trống, hiển thị lại TOÀN BỘ danh sách gốc
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                dgvTheLoai.DataSource = list;
                return;
            }

            // 3. Nếu có từ khóa, dùng LINQ để lọc
            // Chúng ta lọc từ danh sách 'list' GỐC (đầy đủ tất cả thể loại)
            var danhSachLoc = list.Where(dto =>
                                    dto.TenTheLoai.ToLower().Contains(tuKhoa) ||
                                    dto.MaTheLoai.ToLower().Contains(tuKhoa)
                                 ).ToList(); // Chuyển kết quả lọc thành một List<> mới

            // 4. Tạo một BindingList MỚI từ danh sách đã lọc và gán lại cho DataGridView
            dgvTheLoai.DataSource = new BindingList<TheLoaiDTO>(danhSachLoc);
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
            sfd.FileName = "DanhSachTheLoai.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 3. Tạo file Excel bằng ClosedXML
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Thể Loại");

                        // 4. Tạo tiêu đề cột (Header)
                        worksheet.Cell(1, 1).Value = "Mã Thể Loại";
                        worksheet.Cell(1, 2).Value = "Tên Thể Loại";

                        // Định dạng Header cho đẹp (In đậm, nền xám)
                        var headerRow = worksheet.Range("A1:B1");
                        headerRow.Style.Font.Bold = true;
                        headerRow.Style.Fill.BackgroundColor = XLColor.LightGray;

                        // 5. Đổ dữ liệu từ List vào Excel
                        for (int i = 0; i < list.Count; i++)
                        {
                            worksheet.Cell(i + 2, 1).Value = list[i].MaTheLoai;
                            worksheet.Cell(i + 2, 2).Value = list[i].TenTheLoai;
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
                            string tenTheLoai = row.Cell(2).GetValue<string>().Trim();

                            if (string.IsNullOrEmpty(tenTheLoai)) continue;

                            // KIỂM TRA LOGIC:
                            // Chỉ thêm nếu tên này chưa tồn tại trong DB
                            // (Bạn đã có hàm IsNameExist trong DAO rồi, quá tiện!)
                            if (!DAO.TheLoaiDAO.IsNameExist(tenTheLoai))
                            {
                                // Tạo DTO mới
                                TheLoaiDTO newTL = new TheLoaiDTO(tenTheLoai);

                                // Gọi BUS để thêm vào DB (Hàm Add sẽ tự sinh Mã)
                                BUS.TheLoaiBUS.Add(newTL);

                                countSuccess++;
                            }
                            else
                            {
                                countFail++; // Bỏ qua vì trùng tên
                            }
                        }

                        // Load lại dữ liệu lên Grid
                        UCTheLoai_Load(null, null);

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