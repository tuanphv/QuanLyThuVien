using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.PhieuThu
{
    public partial class UCPhieuThu : UserControl
    {
        private BindingList<DTO.PhieuThuDTO> phieuThuList = new BindingList<DTO.PhieuThuDTO>();
        public UCPhieuThu()
        {
            InitializeComponent();
            this.Load += UCPhieuThu_Load;
        }

        private void UCPhieuThu_Load(object sender, EventArgs e)
        {
            // Load dữ liệu phiếu thu khi control được tải
            dgvPhieuThu.AutoGenerateColumns = false;
            LoadPhieuThuData();
        }

        private void LoadPhieuThuData()
        {
            phieuThuList = new BindingList<DTO.PhieuThuDTO>(BUS.PhieuThuBUS.GetAllPhieuThu());
            dgvPhieuThu.DataSource = phieuThuList;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var frmAddPhieuThu = new FrmAddPhieuThu();
            if (frmAddPhieuThu.ShowDialog() == DialogResult.OK)
            {
                //LoadPhieuThuData();
                MessageBox.Show("Thêm phiếu thu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
