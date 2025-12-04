using BUS;
using DTO;
using System.Windows.Forms;

namespace GUI.Sach
{
    public partial class FrmEditSach : Form
    {
        private SachDTO _sachHienTai;
        public FrmEditSach(SachDTO sach)
        {
            InitializeComponent();
            _sachHienTai = sach;
        }

        private void FrmEditSach_Load(object sender, EventArgs e)
        {
            // 1. Load danh sách Nhà Xuất Bản vào ComboBox trước
            LoadComboBoxNXB();

            // 2. Đổ dữ liệu cũ lên các ô
            txtMaSach.Text = _sachHienTai.MaSach;
            txtTenTuaSach.Text = _sachHienTai.TenTuaSach;
            txtSoLuong.Text = _sachHienTai.SoLuongTong.ToString(); // Chỉ hiện tổng để xem

            txtNamXB.Text = _sachHienTai.NamXB.ToString();
            txtDonGia.Text = _sachHienTai.DonGia.ToString();

            // Chọn đúng NXB hiện tại trong ComboBox
            cboNXB.SelectedValue = _sachHienTai.IDNhaXuatBan;
        }

        private void LoadComboBoxNXB()
        {
            // Lấy danh sách NXB từ BUS
            var listNXB = NhaXuatBanBUS.GetAll();

            cboNXB.DataSource = listNXB;
            cboNXB.DisplayMember = "TenNXB"; // Hiển thị tên
            cboNXB.ValueMember = "ID";       // Giá trị ngầm là ID
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validate dữ liệu nhập vào
                if (!int.TryParse(txtNamXB.Text, out int namXB))
                {
                    MessageBox.Show("Năm xuất bản phải là số.", "Lỗi nhập liệu");
                    return;
                }

                if (!int.TryParse(txtDonGia.Text, out int donGia) || donGia < 0)
                {
                    MessageBox.Show("Đơn giá phải là số dương.", "Lỗi nhập liệu");
                    return;
                }

                if (cboNXB.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn Nhà xuất bản.", "Lỗi nhập liệu");
                    return;
                }

                // 2. Cập nhật vào DTO
                _sachHienTai.NamXB = namXB;
                _sachHienTai.DonGia = donGia;
                _sachHienTai.IDNhaXuatBan = (int)cboNXB.SelectedValue; // Lấy ID từ ComboBox

                // 3. Gọi BUS để lưu xuống DB
                if (SachBUS.Update(_sachHienTai))
                {
                    MessageBox.Show("Cập nhật lô sách thành công!", "Thông báo");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại.", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi hệ thống");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
