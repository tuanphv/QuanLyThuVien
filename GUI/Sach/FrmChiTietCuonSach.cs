using BUS;
using DTO;
using GUI.Helpers;
using System.ComponentModel;
using System.Data;


namespace GUI.Sach
{
    public partial class FrmChiTietCuonSach : Form
    {
        private SachDTO _loSachHienTai;
        private int _idCuonSachDangChon = -1;

        // Class phụ để đổ dữ liệu vào ComboBox tình trạng
        public class TrangThaiItem
        {
            public int Value { get; set; }
            public string Text { get; set; }
        }

        public FrmChiTietCuonSach(SachDTO loSach)
        {
            InitializeComponent();
            _loSachHienTai = loSach;
        }

        private void FrmChiTietCuonSach_Load(object sender, EventArgs e)
        {
            // 1. Hiển thị thông tin lô sách lên tiêu đề
            lblTieuDe.Text = $"Chi tiết lô: {_loSachHienTai.MaSach} - {_loSachHienTai.TenTuaSach}";

            // 2. Cấu hình ComboBox Tình trạng
            LoadComboBoxTinhTrang();

            // 3. Cấu hình DataGridView cột
            SetupDataGridView();

            // 4. Tải dữ liệu
            LoadData();

            btnCapNhat.Visible = SessionManager.HasPermission((int)Helpers.Permission.Sach, Helpers.Action.Edit);
        }

        private void LoadComboBoxTinhTrang()
        {
            List<TrangThaiItem> listTrangThai = new List<TrangThaiItem>()
            {
                new TrangThaiItem { Value = 1, Text = "Sẵn sàng" },
                new TrangThaiItem { Value = 2, Text = "Hỏng / Mất / Thanh lý" },
                // Lưu ý: Không cho chọn '0 - Đang mượn' ở đây vì trạng thái đó do quy trình Mượn/Trả quản lý
            };

            cboTinhTrang.DataSource = listTrangThai;
            cboTinhTrang.DisplayMember = "Text";
            cboTinhTrang.ValueMember = "Value";
        }

        private void SetupDataGridView()
        {
            dgvCuonSach.AutoGenerateColumns = false;

            // Xóa cột cũ nếu có
            dgvCuonSach.Columns.Clear();

            // Thêm cột Mã cuốn sách
            DataGridViewTextBoxColumn colMa = new DataGridViewTextBoxColumn();
            colMa.Name = "MaCuonSach";
            colMa.HeaderText = "Mã vạch";
            colMa.DataPropertyName = "MaCuonSach";
            colMa.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCuonSach.Columns.Add(colMa);

            // Thêm cột Tình trạng (Hiển thị chữ)
            DataGridViewTextBoxColumn colTinhTrang = new DataGridViewTextBoxColumn();
            colTinhTrang.Name = "TenTinhTrang";
            colTinhTrang.HeaderText = "Tình trạng";
            colTinhTrang.DataPropertyName = "TenTinhTrang"; // Property này bạn đã viết trong DTO
            colTinhTrang.Width = 150;
            dgvCuonSach.Columns.Add(colTinhTrang);
        }

        private void LoadData()
        {
            try
            {
                var list = CuonSachBUS.GetByIDSach(_loSachHienTai.ID);
                dgvCuonSach.DataSource = list;

                // Reset các control nhập liệu
                _idCuonSachDangChon = -1;
                lblMaDangChon.Text = "Đang chọn: [Chưa chọn]";
                btnCapNhat.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // Sự kiện khi click vào một dòng trên lưới
        private void dgvCuonSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Lấy object từ dòng đang chọn
            // (Cách lấy an toàn khi DataSource là BindingList)
            if (dgvCuonSach.Rows[e.RowIndex].DataBoundItem is CuonSachDTO selectedItem)
            {
                _idCuonSachDangChon = selectedItem.ID;
                lblMaDangChon.Text = $"Đang chọn: {selectedItem.MaCuonSach}";

                // Gán giá trị lên ComboBox
                // Nếu đang mượn (0) thì có thể không có trong list combo, cần xử lý khéo
                if (selectedItem.TinhTrang == 0)
                {
                    cboTinhTrang.SelectedIndex = -1; // Không chọn gì cả
                    lblMaDangChon.Text += " (Đang được mượn - Không thể sửa)";
                    btnCapNhat.Enabled = false; // Khóa nút sửa
                }
                else
                {
                    cboTinhTrang.SelectedValue = selectedItem.TinhTrang;
                    btnCapNhat.Enabled = true;
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (_idCuonSachDangChon == -1) return;

            if (cboTinhTrang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn tình trạng mới.");
                return;
            }

            int tinhTrangMoi = (int)cboTinhTrang.SelectedValue;

            try
            {
                if (CuonSachBUS.CapNhatTinhTrang(_idCuonSachDangChon, tinhTrangMoi))
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Load lại lưới để thấy thay đổi
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại.", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
