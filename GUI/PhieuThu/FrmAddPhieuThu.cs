using DTO;
using System.ComponentModel;

namespace GUI.PhieuThu
{
    public partial class FrmAddPhieuThu : Form
    {
        private DocGiaDTO selectedDocGia;

        public FrmAddPhieuThu()
        {
            InitializeComponent();
        }

        private void FrmAddPhieuThu_Load(object sender, EventArgs e)
        {
            dtpNgayLapPhieu.Value = DateTime.Now;
            BindingList<DocGiaDTO> docGiaList = BUS.DocGiaBUS.GetAll();
            var list = docGiaList.ToList().FindAll(e => e.TongNoHienTai > 0);
            cbDocGia.DataSource = list;
            cbDocGia.DisplayMember = "HoTen";
            cbDocGia.ValueMember = "ID";
        }

        private void cbDocGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedDocGia = (DocGiaDTO)cbDocGia.SelectedItem;
            lblTongNo.Text = $"Tổng nợ: {selectedDocGia.TongNoHienTai.ToString("N0")} VNĐ";

            if (Convert.ToInt32(txtTienThu.Text) > selectedDocGia.TongNoHienTai)
            {
                txtTienThu.Text = selectedDocGia.TongNoHienTai.ToString();
            }

            txtConNo.Text = (selectedDocGia.TongNoHienTai - Convert.ToInt32(txtTienThu.Text)).ToString();
        }

        private void txtTienThu_Leave(object sender, EventArgs e)
        {
            txtConNo.Text = (selectedDocGia.TongNoHienTai - Convert.ToInt32(txtTienThu.Text)).ToString();
        }

        private void txtTienThu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtConNo.Text = (selectedDocGia.TongNoHienTai - Convert.ToInt32(txtTienThu.Text)).ToString();
            }
        }

        private void txtTienThu_Enter(object sender, EventArgs e)
        {
            txtTienThu.SelectAll();
        }
    }
}
