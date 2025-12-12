using DTO;
using System.ComponentModel;

namespace GUI.TuaSach
{

    public partial class UCBookTitle : UserControl
    {
        private BindingList<TuaSachDTO> allList = new BindingList<TuaSachDTO>();
        private BindingList<TuaSachDTO> list = new BindingList<TuaSachDTO>();
        private System.Windows.Forms.Timer searchTimer;
        private bool isInitialized = false;

        public UCBookTitle()
        {
            InitializeComponent();
        }

        private void LoadPermissions()
        {
            int perCode = (int)Helpers.Permission.TuaSach;
            bool canAdd = GUI.Helpers.SessionManager.HasPermission(perCode, Helpers.Action.Add);
            btnAddBookTitle.Visible = canAdd;
            bool canEdit = GUI.Helpers.SessionManager.HasPermission(perCode, Helpers.Action.Edit);
            dgvBookTitles.ShowEditButton = canEdit;
            bool canDelete = GUI.Helpers.SessionManager.HasPermission(perCode, Helpers.Action.Delete);
            dgvBookTitles.ShowDeleteButton = canDelete;
            if (!canEdit && !canDelete)
            {
                dgvBookTitles.Columns["Actions"].Visible = false;
            }
        }

        private void UCBookTitle_Load(object sender, EventArgs e)
        {
            dgvBookTitles.AutoGenerateColumns = false;

            allList = new BindingList<TuaSachDTO>(BUS.TuaSachBUS.GetAll());
            list = new BindingList<TuaSachDTO>(allList.ToList());
            dgvBookTitles.DataSource = list;

            LoadPermissions();

            dgvBookTitles.EditButtonClicked += EditButtonClicked;
            dgvBookTitles.DeleteButtonClicked += DeleteButtonClicked;

            // Load thể loại vào combobox
            var listTheLoai = BUS.TheLoaiBUS.GetAll();
            listTheLoai.Insert(0, new TheLoaiDTO { ID = 0, TenTheLoai = "-- Tất cả --" });
            cbTheLoai.DataSource = listTheLoai;
            cbTheLoai.DisplayMember = "TenTheLoai";
            cbTheLoai.ValueMember = "ID";
            // Load tác giả vào combobox
            var listTacGia = BUS.TacGiaBUS.GetAll();
            listTacGia.Insert(0, new TacGiaDTO { ID = 0, TenTacGia = "-- Tất cả --" });
            cbTacGia.DataSource = listTacGia;
            cbTacGia.DisplayMember = "TenTacGia";
            cbTacGia.ValueMember = "ID";

            // Setup debounce timer for live search
            searchTimer = new System.Windows.Forms.Timer();
            searchTimer.Interval = 300;
            searchTimer.Tick += (s, ev) =>
            {
                searchTimer.Stop();
                PerformSearch();
            };

            // Wire events for search
            btnSearch.Click += (s, ev) => { searchTimer.Stop(); PerformSearch(); };
            textBox1.TextChanged += (s, ev) => { searchTimer.Stop(); searchTimer.Start(); };
            textBox1.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) { searchTimer.Stop(); PerformSearch(); } };
            cbTheLoai.SelectedIndexChanged += (s, ev) => { if (isInitialized) PerformSearch(); };
            cbTacGia.SelectedIndexChanged += (s, ev) => { if (isInitialized) PerformSearch(); };

            isInitialized = true;
        }

        private void PerformSearch()
        {
            string keyword = textBox1.Text.Trim();
            string keywordLower = keyword.ToLowerInvariant();

            string selectedGenre = null;
            string selectedAuthor = null;

            if (cbTheLoai.SelectedItem is TheLoaiDTO tl && tl.ID != 0)
                selectedGenre = tl.TenTheLoai?.ToLowerInvariant();
            if (cbTacGia.SelectedItem is TacGiaDTO tg && tg.ID != 0)
                selectedAuthor = tg.TenTacGia?.ToLowerInvariant();

            var filtered = allList.Where(t =>
            {
                bool matchKeyword = string.IsNullOrEmpty(keyword)
                    || (!string.IsNullOrEmpty(t.TenTuaSach) && t.TenTuaSach.ToLowerInvariant().Contains(keywordLower))
                    || (!string.IsNullOrEmpty(t.MaTuaSach) && t.MaTuaSach.ToLowerInvariant().Contains(keywordLower));

                bool matchGenre = string.IsNullOrEmpty(selectedGenre) || (!string.IsNullOrEmpty(t.TheLoai) && t.TheLoai.ToLowerInvariant().Contains(selectedGenre));
                bool matchAuthor = string.IsNullOrEmpty(selectedAuthor) || (!string.IsNullOrEmpty(t.TacGia) && t.TacGia.ToLowerInvariant().Contains(selectedAuthor));
                return matchKeyword && matchGenre && matchAuthor;
            }).ToList();

            // Update displayed list while keeping a new BindingList to reflect changes
            list = new BindingList<TuaSachDTO>(filtered);
            dgvBookTitles.DataSource = list;
        }

        private void EditButtonClicked(object? sender, int index)
        {
            TuaSachDTO? selectedBookTitle = list[index];
            if (selectedBookTitle != null)
            {
                FrmAddEditBookTitle frm = new FrmAddEditBookTitle();
                frm.TuaSach = selectedBookTitle;
                frm.Text = "Chỉnh sửa Tựa sách";
                var result = frm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    TuaSachDTO ts = frm.TuaSach;
                    // Update both displayed list and master list
                    list[index] = ts;
                    var idxAll = allList.ToList().FindIndex(x => x.ID == ts.ID);
                    if (idxAll >= 0)
                        allList[idxAll] = ts;
                    MessageBox.Show("Cập nhật tựa sách thành công.", "Thông báo");
                }
            }
        }

        private void DeleteButtonClicked(object? sender, int index)
        {
            TuaSachDTO? selectedBookTitle = list[index];
            if (selectedBookTitle != null)
            {
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa tựa sách này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    if (BUS.TuaSachBUS.DeleteBookTitle(selectedBookTitle.ID))
                    {
                        // remove from both lists
                        var idxAll = allList.ToList().FindIndex(x => x.ID == selectedBookTitle.ID);
                        if (idxAll >= 0) allList.RemoveAt(idxAll);
                        list.RemoveAt(index);
                    }
                    else
                    {
                        MessageBox.Show("Xóa tựa sách thất bại.");
                    }
                }
            }
        }

        private void btnAddBookTitle_Click(object sender, EventArgs e)
        {
            FrmAddEditBookTitle frm = new FrmAddEditBookTitle();
            frm.Text = "Thêm Tựa sách";
            var result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                TuaSachDTO ts = frm.TuaSach;
                // add to both master and current displayed list
                allList.Add(ts);
                list.Add(ts);
                MessageBox.Show("Thêm tựa sách thành công.", "Thông báo");
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var fileBytes = BUS.TuaSachBUS.ExportToExcel();

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "DanhSachTuaSach.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        System.IO.File.WriteAllBytes(sfd.FileName, fileBytes);
                        MessageBox.Show("Xuất file thành công.", "Thông báo");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi lưu file: " + ex.Message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Excel Workbook|*.xlsx;*.xls",
                Title = "Chọn file Excel để nhập tựa sách"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var result = BUS.TuaSachBUS.ImportFromExcel(ofd.FileName);
                    foreach (var ts in result.importedList)
                    {
                        allList.Add(ts);
                        list.Add(ts);
                    }
                    MessageBox.Show($"Nhập file thành công.\n\n- Đã thêm: {result.importedList.Count} tựa sách.\n- Thêm thất bại {result.fail} tựa sách do dữ liệu trùng hoặc lỗi.", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi nhập file: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvBookTitles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
