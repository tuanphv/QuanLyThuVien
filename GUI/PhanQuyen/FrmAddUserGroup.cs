using DTO;

namespace GUI.PhanQuyen
{
    public partial class FrmAddUserGroup : Form
    {
        public NhomNguoiDungDTO? GeneratedGroup { get; private set; }

        public FrmAddUserGroup()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => this.Close();
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            string ten = txtGroupName?.Text.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Tên nhóm không được rỗng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Tạo nhóm và nhận về mã nhóm sinh tự động
                var generatedMa = BUS.NhomNguoiDungBUS.AddNhomNguoiDung(ten);
                if (string.IsNullOrEmpty(generatedMa))
                {
                    MessageBox.Show("Thêm nhóm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy DTO theo mã nhóm
                var dto = BUS.NhomNguoiDungBUS.GetNhomByMaNhom(generatedMa);
                if (dto != null)
                {
                    GeneratedGroup = dto;
                }

                MessageBox.Show($"Thêm nhóm thành công. Mã nhóm: {generatedMa}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhóm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
