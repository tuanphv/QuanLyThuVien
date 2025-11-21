using DTO;
using BUS;
using System.Windows.Forms;

namespace GUI.NhaCungCap
{
    public partial class FrmAddEditNhaCungCap : Form
    {
        public NhaCungCapDTO? NCC { get; set; }
        public FrmAddEditNhaCungCap()
        {
            InitializeComponent();
        }

        private void FrmAddEditNhaCungCap_Load(object sender, EventArgs e)
        {
            if (NCC != null) // Chế độ SỬA
            {
                this.Text = "Chỉnh sửa Nhà cung cấp";
                txtTenNCC.Text = NCC.TenNCC;
                txtDiaChi.Text = NCC.DiaChi ?? string.Empty; //
            }
            else // Chế độ THÊM
            {
                this.Text = "Thêm Nhà cung cấp";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string ten = txtTenNCC.Text.Trim();
                string diaChi = txtDiaChi.Text.Trim();

                if (NCC == null) // THÊM MỚI
                {
                    NhaCungCapDTO nccMoi = new NhaCungCapDTO(ten, diaChi);

                    // Gọi BUS.Add
                    int newId = NhaCungCapBUS.Add(nccMoi);

                    // Gán ID mới để hiển thị lại trên lưới
                    nccMoi.ID = newId;
                    this.NCC = nccMoi;

                    MessageBox.Show("Thêm thành công!", "Thông báo");
                }
                else // CẬP NHẬT
                {
                    NCC.TenNCC = ten;
                    NCC.DiaChi = diaChi;

                    // Gọi BUS.Update
                    NhaCungCapBUS.Update(NCC);
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
