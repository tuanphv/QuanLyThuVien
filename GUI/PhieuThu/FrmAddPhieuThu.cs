using DTO;
using System.ComponentModel;

namespace GUI.PhieuThu
{
    public partial class FrmAddPhieuThu : Form
    {
        private DocGiaDTO selectedDocGia;
        private PhieuThuDTO phieuThu;

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

            TinhNo();
        }

        private void txtTienThu_Leave(object sender, EventArgs e)
        {
            ValidateTienThu("0");
            TinhNo();
        }

        private void txtTienThu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ValidateTienThu();
                TinhNo();
            }
        }

        private void txtTienThu_Enter(object sender, EventArgs e)
        {
            txtTienThu.SelectAll();
        }

        private void ValidateTienThu(string resetValue = "")
        {
            try
            {
                int tienThu = Convert.ToInt32(txtTienThu.Text);
                if (tienThu > selectedDocGia.TongNoHienTai)
                {
                    txtTienThu.Text = selectedDocGia.TongNoHienTai.ToString();
                }
                else if (tienThu < 0)
                {
                    txtTienThu.Text = resetValue;
                }
                else
                {
                    txtTienThu.Text = tienThu.ToString();
                }
            }
            catch
            {
                txtTienThu.Text = resetValue;
            }
        }

        private void TinhNo()
        {
            txtConNo.Text = (selectedDocGia.TongNoHienTai - Convert.ToInt32(txtTienThu.Text)).ToString();
        }

        private void FrmAddPhieuThu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                phieuThu = new PhieuThuDTO
                {
                    IDDocGia = selectedDocGia.ID,
                    TenDocGia = selectedDocGia.HoTen,
                    NgayLapPhieu = dtpNgayLapPhieu.Value,
                    SoTienThu = Convert.ToInt32(txtTienThu.Text),
                };
                string maPhieuThu = BUS.PhieuThuBUS.AddPhieuThu(phieuThu);
                phieuThu.MaPhieuThu = maPhieuThu;
                if (maPhieuThu == string.Empty)
                {
                    MessageBox.Show("Thêm phiếu thu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }

        public PhieuThuDTO GetPhieuThu()
        {
            return phieuThu;
        }
    }
}
