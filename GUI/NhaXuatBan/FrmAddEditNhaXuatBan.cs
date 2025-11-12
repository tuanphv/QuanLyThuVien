using DTO;
using BUS;
using System.Windows.Forms;

namespace GUI.NhaXuatBan
{
    public partial class FrmAddEditNhaXuatBan : Form
    {
        // Biến chứa đối tượng để sửa (nếu có)
        public NhaXuatBanDTO? NXB { get; set; }

        public FrmAddEditNhaXuatBan()
        {
            InitializeComponent();
        }

        private void FrmAddEditNhaXuatBan_Load(object sender, EventArgs e)
        {
            // Nếu đang ở chế độ Sửa (NXB khác null)
            if (NXB != null)
            {
                this.Text = "Chỉnh sửa Nhà xuất bản";
                txtTenNXB.Text = NXB.TenNXB;
                // Kiểm tra null cho Địa chỉ vì trong DTO nó cho phép null
                txtDiaChi.Text = NXB.DiaChi ?? string.Empty;
            }
            else
            {
                this.Text = "Thêm Nhà xuất bản";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string ten = txtTenNXB.Text.Trim();
                string diaChi = txtDiaChi.Text.Trim();

                if (NXB == null) // Chế độ THÊM
                {
                    // Tạo DTO mới (ID tự tăng nên để mặc định hoặc 0)
                    NhaXuatBanDTO nxbMoi = new NhaXuatBanDTO(ten, diaChi);

                    // Gọi BUS
                    NhaXuatBanBUS.Add(nxbMoi);

                    // Gán lại vào biến public để Form cha lấy cập nhật
                    this.NXB = nxbMoi;
                    MessageBox.Show("Thêm thành công!", "Thông báo");
                }
                else // Chế độ SỬA
                {
                    // Cập nhật thông tin vào đối tượng hiện tại
                    NXB.TenNXB = ten;
                    NXB.DiaChi = diaChi;

                    // Gọi BUS
                    NhaXuatBanBUS.Update(NXB);
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}