using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.MuonTra
{
    public partial class UCPhieuMuon : UserControl
    {
        public UCPhieuMuon()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterPhieuMuon(txtSearch.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            MoFormThemPhieuMuon();
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            GiaHanPhieuMuonDuocChon();
        }

        private void btnTra_Click(object sender, EventArgs e)
        {
            TraPhieuMuonDuocChon();
        }

        private void FilterPhieuMuon(string keyword)
        {
            // TODO: Thực hiện lọc dữ liệu phiếu mượn theo từ khóa
        }

        private void MoFormThemPhieuMuon()
        {
            // TODO: Mở form thêm phiếu mượn mới
        }

        private void GiaHanPhieuMuonDuocChon()
        {
            // TODO: Gọi nghiệp vụ gia hạn phiếu mượn được chọn
        }

        private void TraPhieuMuonDuocChon()
        {
            // TODO: Gọi nghiệp vụ trả phiếu mượn được chọn
        }
    }
}
