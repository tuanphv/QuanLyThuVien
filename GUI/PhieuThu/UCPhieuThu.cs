using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

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

            List <(int ID, string HoTen)> docGiaWithPhieuThu = BUS.PhieuThuBUS.GetAllDocGiaCoPhieuThu();
            docGiaWithPhieuThu.Insert(0, (0, "Tất cả") );
            cbDocGia.DataSource = docGiaWithPhieuThu.Select(x => new { ID = x.ID, HoTen = x.HoTen }).ToList();
            cbDocGia.DisplayMember = "HoTen";
            cbDocGia.ValueMember = "ID";

            cbDocGia.SelectedIndexChanged += cbDocGia_SelectedIndexChanged;

            dgvPhieuThu.DeleteButtonClicked += DeleteButtonClicked;
            dgvPhieuThu.PrintButtonClicked += PrintButtonClicked;
        }

        private void LoadPhieuThuData()
        {
            phieuThuList = new BindingList<DTO.PhieuThuDTO>(BUS.PhieuThuBUS.GetAllPhieuThu());
            dgvPhieuThu.DataSource = phieuThuList;
        }

        private void DeleteButtonClicked(object? sender, int index)
        {
            PhieuThuDTO? selectedPhieuThu = phieuThuList[index];
            if (selectedPhieuThu != null)
            {
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu thu này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    bool success = BUS.PhieuThuBUS.DeletePhieuThu(selectedPhieuThu.ID);
                    if (success)
                    {
                        phieuThuList.RemoveAt(index);
                        MessageBox.Show("Xóa phiếu thu thành công.", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Xóa phiếu thu thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void PrintButtonClicked(object? sender, int index)
        {
            PhieuThuDTO? selectedPhieuThu = phieuThuList[index];
            if (selectedPhieuThu == null) return;
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF file|*.pdf";
                sfd.FileName = $"PhieuThu_{selectedPhieuThu.MaPhieuThu}.pdf";
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    using (var fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write))
                    {
                        var doc = new Document(PageSize.A6, 36, 36, 36, 36);
                        PdfWriter.GetInstance(doc, fs);
                        doc.Open();

                        string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");

                        BaseFont bf = BaseFont.CreateFont(
                            fontPath,
                            BaseFont.IDENTITY_H,
                            BaseFont.EMBEDDED
                        );

                        iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font fontLabel = new iTextSharp.text.Font(bf, 12);
                        iTextSharp.text.Font fontValue = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);

                        doc.Add(new Paragraph("PHIẾU THU TIỀN", fontTitle) { Alignment = Element.ALIGN_CENTER });
                        doc.Add(new Paragraph("\n"));
                        doc.Add(new Paragraph($"Mã phiếu thu: {selectedPhieuThu.MaPhieuThu}", fontLabel));
                        doc.Add(new Paragraph($"Ngày lập: {selectedPhieuThu.NgayLapPhieu:dd/MM/yyyy}", fontLabel));
                        doc.Add(new Paragraph($"Độc giả: {selectedPhieuThu.TenDocGia}", fontLabel));
                        doc.Add(new Paragraph($"Số tiền thu: {selectedPhieuThu.SoTienThu:N0} VNĐ", fontValue));

                        doc.Close();
                    }
                    MessageBox.Show("Xuất PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var frmAddPhieuThu = new FrmAddPhieuThu();
            if (frmAddPhieuThu.ShowDialog() == DialogResult.OK)
            {
                PhieuThuDTO newPhieuThu = frmAddPhieuThu.GetPhieuThu();
                phieuThuList.Add(newPhieuThu);
                // nếu tên độc giả mới được thêm không có trong cbDocGia thì thêm vào
                if (!KiemTraTenDocGiaTonTai(newPhieuThu.TenDocGia))
                {
                    var currentList = (List<dynamic>)cbDocGia.DataSource;
                    currentList.Add(new { ID = newPhieuThu.IDDocGia, HoTen = newPhieuThu.TenDocGia });
                    cbDocGia.DataSource = null;
                    cbDocGia.DataSource = currentList;
                    cbDocGia.DisplayMember = "HoTen";
                    cbDocGia.ValueMember = "ID";
                }
                MessageBox.Show("Thêm phiếu thu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public bool KiemTraTenDocGiaTonTai(string ten)
        {
            foreach (var item in cbDocGia.Items)
            {
                dynamic d = item;
                if (string.Equals(d.HoTen, ten, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }


        private void cbDocGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var val = cbDocGia.SelectedValue;
                if (val == null)
                    return;

                int selectedId;
                if (val is int i) selectedId = i;
                else
                {
                    // sometimes ValueMember returns string
                    if (!int.TryParse(val.ToString(), out selectedId)) return;
                }

                Debug.WriteLine($"Selected DocGia changed. Selected ID: {selectedId}");

                if (selectedId == 0)
                {
                    // show all
                    dgvPhieuThu.DataSource = phieuThuList;
                }
                else
                {
                    var filtered = phieuThuList.Where(p => p.IDDocGia == selectedId).ToList();
                    dgvPhieuThu.DataSource = new BindingList<PhieuThuDTO>(filtered);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in cbDocGia_SelectedIndexChanged: " + ex.Message);
            }
        }
    }
}
