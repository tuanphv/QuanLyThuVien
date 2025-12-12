using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
            dgvPhieuThu.AutoGenerateColumns = false;
            LoadPhieuThuData();

            // --- KHẮC PHỤC LỖI CAST ---
            LoadDocGiaCombobox();

            cbDocGia.SelectedIndexChanged += cbDocGia_SelectedIndexChanged;

            dgvPhieuThu.DeleteButtonClicked += DeleteButtonClicked;
            dgvPhieuThu.PrintButtonClicked += PrintButtonClicked;
        }

        private void LoadDocGiaCombobox()
        {
            // Lấy danh sách từ BUS (đang trả về Tuple)
            var rawList = BUS.PhieuThuBUS.GetAllDocGiaCoPhieuThu();

            // Chuyển sang List<DocGiaSimpleDTO>
            List<DocGiaSimpleDTO> displayList = new List<DocGiaSimpleDTO>();

            // Thêm mục mặc định
            displayList.Add(new DocGiaSimpleDTO { ID = 0, HoTen = "Tất cả" });

            // Map dữ liệu
            foreach (var item in rawList)
            {
                displayList.Add(new DocGiaSimpleDTO { ID = item.ID, HoTen = item.HoTen });
            }

            // Gán DataSource
            cbDocGia.DataSource = displayList;
            cbDocGia.DisplayMember = "HoTen";
            cbDocGia.ValueMember = "ID";
        }

        private void LoadPhieuThuData()
        {
            phieuThuList = new BindingList<DTO.PhieuThuDTO>(BUS.PhieuThuBUS.GetAllPhieuThu());
            dgvPhieuThu.DataSource = phieuThuList;
        }

        private void DeleteButtonClicked(object? sender, int index)
        {
            if (index < 0 || index >= phieuThuList.Count) return;

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
            if (index < 0 || index >= phieuThuList.Count) return;

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
                        BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

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
                PhieuThuDTO? newPhieuThu = frmAddPhieuThu.GetPhieuThu();
                if (newPhieuThu != null)
                {
                    phieuThuList.Add(newPhieuThu);

                    // Cập nhật Combobox nếu độc giả mới chưa có
                    if (!KiemTraTenDocGiaTonTai(newPhieuThu.TenDocGia))
                    {
                        // SỬA LỖI TẠI ĐÂY: Cast sang List<DocGiaSimpleDTO>
                        var currentList = cbDocGia.DataSource as List<DocGiaSimpleDTO>;

                        if (currentList != null)
                        {
                            currentList.Add(new DocGiaSimpleDTO
                            {
                                ID = newPhieuThu.IDDocGia,
                                HoTen = newPhieuThu.TenDocGia
                            });

                            // Refresh binding
                            cbDocGia.DataSource = null;
                            cbDocGia.DataSource = currentList;
                            cbDocGia.DisplayMember = "HoTen";
                            cbDocGia.ValueMember = "ID";
                        }
                        else
                        {
                            // Fallback: reload từ đầu
                            LoadDocGiaCombobox();
                        }
                    }
                    MessageBox.Show("Thêm phiếu thu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public bool KiemTraTenDocGiaTonTai(string ten)
        {
            // Kiểm tra dựa trên DTO mới
            if (cbDocGia.DataSource is List<DocGiaSimpleDTO> list)
            {
                return list.Any(d => d.HoTen.Equals(ten, StringComparison.OrdinalIgnoreCase));
            }
            return false;
        }

        private void cbDocGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbDocGia.SelectedValue == null) return;

                if (int.TryParse(cbDocGia.SelectedValue.ToString(), out int selectedId))
                {
                    if (selectedId == 0) // Tất cả
                    {
                        dgvPhieuThu.DataSource = phieuThuList;
                    }
                    else
                    {
                        var filtered = phieuThuList.Where(p => p.IDDocGia == selectedId).ToList();
                        dgvPhieuThu.DataSource = new BindingList<DTO.PhieuThuDTO>(filtered);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in cbDocGia_SelectedIndexChanged: " + ex.Message);
            }
        }
    }
}