using DTO;
using GUI.Controls;
using System.ComponentModel;
using System.Windows.Forms;

namespace GUI
{
    public partial class UCBookTitle : UserControl
    {
        private BindingList<TuaSachDTO> list = new BindingList<TuaSachDTO>();
        public UCBookTitle()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            list = BUS.TuaSachBUS.GetAll();
            dgvBooks.AutoGenerateColumns = false;
            LoadBookList();
        }

        private void LoadBookList()
        {
            dgvBooks.DataSource = null;
            dgvBooks.DataSource = list;
        }
        // Phương thức để tạo và thêm một thẻ mới
        private void AddTag(Control panel, TagPanel tag)
        {
            panel.Controls.Add(tag);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // Lấy Button đã được click
            Button clickedButton = (Button)sender;

            // Control cha của Button là Panel (chính là thẻ tag)
            Panel tagPanel = (Panel)clickedButton.Parent;

            // Xóa Panel (thẻ) khỏi FlowLayoutPanel
            pnlGenres.Controls.Remove(tagPanel);

            // Giải phóng tài nguyên
            tagPanel.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dialogChonAnh.Filter = "Ảnh (*.jpg; *.png; *.jpeg)|*.jpg;*.png;*.jpeg|Tất cả (*.*)|*.*";

            // Thiết lập thư mục mở mặc định (tùy chọn)
            dialogChonAnh.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            // Hiện hộp thoại
            if (dialogChonAnh.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn file
                string filePath = dialogChonAnh.FileName;

                // Hoặc hiển thị ảnh vào PictureBox
                ptbBookCover.Image = Image.FromFile(filePath);
                ptbBookCover.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void dgvBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0)
            {
                TuaSachDTO selectedBook = (TuaSachDTO)dgvBooks.SelectedRows[0].DataBoundItem;
                txtBookTitleId.Text = selectedBook.MaTuaSach;
                txtBookName.Text = selectedBook.TenTuaSach;
                //chkDaAn.Checked = selectedBook.DaAn;
                // Hiển thị ảnh bìa nếu có
                if (selectedBook.AnhBia != null && selectedBook.AnhBia.Length > 0)
                {
                    using (var ms = new MemoryStream(selectedBook.AnhBia))
                    {
                        ptbBookCover.Image = Image.FromStream(ms);
                        ptbBookCover.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                else
                {
                    ptbBookCover.Image = null; // Hoặc đặt ảnh mặc định
                }

                string[] theLoai = selectedBook.TheLoai.Split(", ");
                pnlGenres.Controls.Clear();
                foreach (string tag in theLoai)
                {
                    TagPanel tagPanel = new TagPanel
                    {
                        TagText = tag
                    };
                    AddTag(pnlGenres, tagPanel);
                }

                string[] tacGia = selectedBook.TacGia.Split(", ");
                pnlAuthors.Controls.Clear();
                foreach (string tag in tacGia)
                {
                    TagPanel tagPanel = new TagPanel
                    {
                        TagText = tag,
                        TagBackColor = Color.LightGreen,
                        TagForeColor = Color.DarkGreen
                    };
                    AddTag(pnlAuthors, tagPanel);
                }
            }
        }
    }
}
