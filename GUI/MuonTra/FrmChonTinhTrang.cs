using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GUI.MuonTra
{
    public partial class FrmChonTinhTrang : Form
    {
        public string SelectedIDs { get; private set; } = "";
        public string SelectedNames { get; private set; } = "";

        private CheckedListBox clbList;
        private Button btnOK;
        private Button btnCancel;
        private List<ThamSoPhatDTO> _allRules;
        private bool _isUpdating = false; // Cờ để tránh vòng lặp sự kiện vô tận

        public FrmChonTinhTrang(string currentIds)
        {
            InitializeComponent();
            _allRules = ThamSoPhatBUS.LayTatCa();
            LoadData(currentIds);

            // Đăng ký sự kiện khi user tick chọn
            clbList.ItemCheck += ClbList_ItemCheck;
        }

        private void LoadData(string currentIds)
        {
            var selectedIdList = (currentIds ?? "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var rule in _allRules)
            {
                int index = clbList.Items.Add(rule);
                if (selectedIdList.Contains(rule.ID.ToString()))
                {
                    clbList.SetItemChecked(index, true);
                }
            }
            clbList.DisplayMember = nameof(ThamSoPhatDTO.TenHienThi);
        }

        // XỬ LÝ LOGIC LOẠI TRỪ CÙNG NHÓM
        private void ClbList_ItemCheck(object? sender, ItemCheckEventArgs e)
        {
            if (_isUpdating) return; // Nếu đang update tự động thì bỏ qua

            // Nếu người dùng đang bỏ chọn thì không cần xử lý logic loại trừ
            if (e.NewValue != CheckState.Checked) return;

            var currentItem = clbList.Items[e.Index] as ThamSoPhatDTO;
            if (currentItem == null) return;

            _isUpdating = true; // Bắt đầu update tự động

            // 1. Nếu chọn "Mới" hoặc "Mất" (CoLaDuyNhat = true)
            // -> Bỏ chọn TẤT CẢ cái khác
            if (currentItem.CoLaDuyNhat)
            {
                for (int i = 0; i < clbList.Items.Count; i++)
                {
                    if (i != e.Index) clbList.SetItemChecked(i, false);
                }
            }
            else
            {
                // 2. Nếu chọn lỗi thường (Rách/Bẩn...)
                // -> Bỏ chọn các lỗi Duy Nhất (Mới/Mất) nếu đang có
                for (int i = 0; i < clbList.Items.Count; i++)
                {
                    var item = clbList.Items[i] as ThamSoPhatDTO;
                    if (item != null && item.CoLaDuyNhat)
                    {
                        clbList.SetItemChecked(i, false);
                    }
                }

                // 3. LOGIC CỐT LÕI: Loại trừ các lỗi CÙNG NHÓM (cùng NhomTinhTrang)
                // Ví dụ: Đang chọn Rách < 3 (Nhóm=RACH), giờ chọn Rách > 5 (Nhóm=RACH) -> Bỏ Rách < 3
                if (!string.IsNullOrEmpty(currentItem.NhomTinhTrang))
                {
                    for (int i = 0; i < clbList.Items.Count; i++)
                    {
                        if (i == e.Index) continue; // Bỏ qua chính nó

                        var item = clbList.Items[i] as ThamSoPhatDTO;
                        // Nếu item kia cùng nhóm với item đang chọn
                        if (item != null && item.NhomTinhTrang == currentItem.NhomTinhTrang)
                        {
                            // Nếu item kia đang được check -> Bỏ check
                            if (clbList.GetItemChecked(i))
                            {
                                clbList.SetItemChecked(i, false);
                            }
                        }
                    }
                }
            }

            _isUpdating = false; // Kết thúc update
        }

        private void BtnOK_Click(object? sender, EventArgs e)
        {
            var selectedItems = clbList.CheckedItems.Cast<ThamSoPhatDTO>().ToList();
            if (selectedItems.Count > 0)
            {
                SelectedIDs = string.Join(",", selectedItems.Select(x => x.ID));
                SelectedNames = string.Join(", ", selectedItems.Select(x => x.TenQuyDinh));
            }
            else
            {
                SelectedIDs = "";
                SelectedNames = "";
            }
        }

        private void InitializeComponent()
        {
            this.Text = "Chọn tình trạng sách";
            this.Size = new System.Drawing.Size(450, 400);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            clbList = new CheckedListBox();
            clbList.Location = new System.Drawing.Point(20, 20);
            clbList.Size = new System.Drawing.Size(390, 270);
            clbList.CheckOnClick = true; // Cho phép click 1 lần là check luôn

            btnOK = new Button { Text = "Xác nhận", DialogResult = DialogResult.OK, Location = new System.Drawing.Point(200, 310), Size = new System.Drawing.Size(100, 35), BackColor = System.Drawing.Color.RoyalBlue, ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };
            btnCancel = new Button { Text = "Hủy", DialogResult = DialogResult.Cancel, Location = new System.Drawing.Point(310, 310), Size = new System.Drawing.Size(100, 35), FlatStyle = FlatStyle.Flat };

            btnOK.Click += BtnOK_Click;

            this.Controls.Add(clbList);
            this.Controls.Add(btnOK);
            this.Controls.Add(btnCancel);
        }
    }
}