using DTO;
using System.ComponentModel;

namespace GUI.TuaSach
{

    public partial class UCBookTitle : UserControl
    {
        private BindingList<TuaSachDTO> list = new BindingList<TuaSachDTO>();
        public UCBookTitle()
        {
            InitializeComponent();
        }
        private void UCBookTitle_Load(object sender, EventArgs e)
        {
            dgvBookTitles.AutoGenerateColumns = false;

            list = BUS.TuaSachBUS.GetAll();
            dgvBookTitles.DataSource = list;

            dgvBookTitles.EditButtonClicked += EditButtonClicked;
            dgvBookTitles.DeleteButtonClicked += DeleteButtonClicked;
        }

        private void EditButtonClicked(object? sender, int index)
        {
            TuaSachDTO? selectedBookTitle = list[index];
            if (selectedBookTitle != null)
            {
                FrmAddEditBookTitle frm = new FrmAddEditBookTitle();
                frm.TuaSach = selectedBookTitle;
                frm.Text = "Chỉnh sửa Tựa sách";
                var result = frm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    TuaSachDTO ts = frm.TuaSach;
                    list[index] = ts;
                }
            }
        }

        private void DeleteButtonClicked(object? sender, int index)
        {
            TuaSachDTO? selectedBookTitle = list[index];
            if (selectedBookTitle != null)
            {
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa tựa sách này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    if (BUS.TuaSachBUS.DeleteBookTitle(selectedBookTitle.ID))
                    {
                        MessageBox.Show("Xóa tựa sách thành công.");
                        list.RemoveAt(index);
                    } else
                    {
                        MessageBox.Show("Xóa tựa sách thất bại.");
                    }
                }
            }
        }

        private void btnAddBookTitle_Click(object sender, EventArgs e)
        {
            FrmAddEditBookTitle frm = new FrmAddEditBookTitle();
            frm.Text = "Thêm Tựa sách";
            var result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                // TODO: Thêm tựa sách vào danh sách
                TuaSachDTO ts = frm.TuaSach;
                list.Add(ts);
            }
        }

    }
}
