using DTO;
using GUI.Controls;
using System.ComponentModel;

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

            AddTag("Demo Tag");
            AddTag("Click X to Remove");
            AddTag("Science Fiction");
            AddTag("Fantasy");
            AddTag("Mystery");
            AddTag("Romance");
        }

        private void LoadBookList()
        {
            dgvBooks.DataSource = null;
            dgvBooks.DataSource = list;
        }
        // Phương thức để tạo và thêm một thẻ mới
        private void AddTag(string tagText)
        {
            TagPanel tagPanel = new TagPanel
            {
                TagText = tagText,
                TagBackColor = Color.LightBlue,
                TagForeColor = Color.DarkBlue
            };
            pnlGenres.Controls.Add(tagPanel);
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
    }
}
