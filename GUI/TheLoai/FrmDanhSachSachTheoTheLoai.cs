using DTO;
using GUI.Controls;
using System.Data;

namespace GUI.TheLoai
{
    public partial class FrmDanhSachSachTheoTheLoai : Form
    {
        private string maTheLoai;
        private string tenTheLoai;

        // 1. Sửa hàm constructor (hàm khởi tạo)
        public FrmDanhSachSachTheoTheLoai(string maTheLoai, string tenTheLoai)
        {
            InitializeComponent();
            this.maTheLoai = maTheLoai;
            this.tenTheLoai = tenTheLoai;
        }

        // 2. Viết hàm Load cho Form này
        private void FrmDanhSachSachTheoTheLoai_Load(object sender, EventArgs e)
        {
            // 3. Đặt tiêu đề cho Form (ví dụ: "Sách thuộc thể loại: Văn học")
            this.Text = "Sách thuộc thể loại: " + this.tenTheLoai;

            // 4. Thiết lập DataGridView (dgvSach)
            dgvSach.AutoGenerateColumns = false;
            // (Nhớ vào [Design] -> Edit Columns -> set DataPropertyName cho các cột)

            // 5. Gọi BUS để lấy dữ liệu
            try
            {
                // (Giả sử bạn có hàm GetByMaTheLoai trong TuaSachBUS)
                dgvSach.DataSource = BUS.TuaSachBUS.GetByMaTheLoai(this.maTheLoai);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sách: " + ex.Message);
            }
        }
    }
}
