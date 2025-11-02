using DTO;
using GUI.Controls;
using System.Data;

namespace GUI.TuaSach
{
    public partial class FrmAddEditBookTitle : Form
    {
        private bool _isEditMode = false;

        public TuaSachDTO TuaSach
        {
            get
            {
                Image image = ptbBookCover.Image;
                byte[]? anh = null;

                if (!IsPlaceholderImage(image))
                {
                    using (var ms = new MemoryStream())
                    {
                        image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        anh = ms.ToArray();
                    }
                }

                TuaSachDTO ts = new TuaSachDTO(
                    id: 0,
                    maTuaSach: txtBookTitleId.Text.Trim(),
                    tenTuaSach: txtBookName.Text.Trim(),
                    anh: anh,
                    theLoai: string.Join(", ", pnlGenres.Controls.OfType<TagPanel>().Select(tag => tag.TagText)),
                    tacGia: string.Join(", ", pnlAuthors.Controls.OfType<TagPanel>().Select(tag => tag.TagText))
                );
                return ts;
            }

            set
            {
                _isEditMode = true;
                txtBookTitleId.Text = value.MaTuaSach;
                txtBookName.Text = value.TenTuaSach;
                if (value.AnhBia != null)
                {
                    using (var ms = new MemoryStream(value.AnhBia))
                    {
                        ptbBookCover.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    ptbBookCover.Image = Properties.Resources.image_placeholder;
                }
                pnlGenres.Controls.Clear();
                foreach (string theLoai in value.TheLoai.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries))
                {
                    TagPanel tag = new TagPanel(theLoai);
                    pnlGenres.Controls.Add(tag);
                }
                pnlAuthors.Controls.Clear();
                foreach (string tacGia in value.TacGia.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries))
                {
                    TagPanel tag = new TagPanel(tacGia);
                    pnlAuthors.Controls.Add(tag);
                }
            }
        }

        private bool IsPlaceholderImage(Image img)
        {
            // So sánh nội dung ảnh bằng cách chuyển về byte[] rồi so sánh
            using (var ms1 = new MemoryStream())
            using (var ms2 = new MemoryStream())
            {
                img.Save(ms1, System.Drawing.Imaging.ImageFormat.Png);
                Properties.Resources.image_placeholder.Save(ms2, System.Drawing.Imaging.ImageFormat.Png);
                return ms1.ToArray().SequenceEqual(ms2.ToArray());
            }
        }


        public FrmAddEditBookTitle()
        {
            InitializeComponent();
        }

        #region Thêm action cho các nút chức năng
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            dialogChonAnh.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (dialogChonAnh.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = dialogChonAnh.FileName;
                ptbBookCover.Image = Image.FromFile(selectedFile);
            }
        }

        private void btnXoaAnh_Click(object sender, EventArgs e)
        {
            ptbBookCover.Image = Properties.Resources.image_placeholder;
        }

        private void btnThemTheLoai_Click(object sender, EventArgs e)
        {
            TextBox txtNhap = new TextBox();
            txtNhap.Width = 120;
            txtNhap.BorderStyle = BorderStyle.FixedSingle;
            txtNhap.Margin = new Padding(5, 8, 5, 8);
            txtNhap.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);

            AutoCompleteStringCollection suggestList = new AutoCompleteStringCollection();
            suggestList.AddRange(new string[]
            {
                "Văn học",
                "Kinh tế",
                "Tâm lý học",
                "Khoa học",
                "Công nghệ thông tin",
                "Lịch sử",
                "Trinh thám",
                "Kinh dị"
            });

            // Cấu hình TextBox
            txtNhap.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtNhap.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtNhap.AutoCompleteCustomSource = suggestList;

            // Khi người dùng nhấn Enter
            txtNhap.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Enter)
                {
                    string theLoaiMoi = txtNhap.Text.Trim();
                    if (!string.IsNullOrEmpty(theLoaiMoi))
                    {
                        TagPanel tag = new TagPanel(theLoaiMoi);

                        // Thêm vào panel và xóa ô nhập
                        int index = pnlGenres.Controls.IndexOf(txtNhap);
                        pnlGenres.Controls.Add(tag);
                        pnlGenres.Controls.SetChildIndex(tag, index);

                        txtNhap.Clear();
                        txtNhap.Focus();
                    }
                    else
                    {
                        pnlGenres.Controls.Remove(txtNhap);
                    }
                }
            };

            // Khi mất focus thì xóa ô nhập
            txtNhap.LostFocus += (s, ev) => pnlGenres.Controls.Remove(txtNhap);

            pnlGenres.Controls.Add(txtNhap);
            txtNhap.Focus();
        }

        private void btnThemTacGia_Click(object sender, EventArgs e)
        {
            TextBox txtNhap = new TextBox();
            txtNhap.Width = 120;
            txtNhap.BorderStyle = BorderStyle.FixedSingle;
            txtNhap.Margin = new Padding(5, 8, 5, 8);
            txtNhap.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);

            AutoCompleteStringCollection suggestList = new AutoCompleteStringCollection();
            suggestList.AddRange(new string[]
            {
                "Nguyễn Nhật Ánh",
                "Nam Cao",
                "Tô Hoài",
                "Hồ Biểu Chánh",
                "Victor Hugo",
                "J. K. Rowling",
                "George Orwell",
                "Ernest Hemingway",
                "Haruki Murakami",
                "Paulo Coelho",
                "Dan Brown",
                "Antoine de Saint-Exupéry",
                "Jane Austen",
                "Leo Tolstoy",
                "Fyodor Dostoevsky",
                "Khaled Hosseini",
                "Gabriel García Márquez",
                "Albert Camus",
                "Nguyễn Huy Thiệp",
                "Kim Dung"
            });


            // Cấu hình TextBox
            txtNhap.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtNhap.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtNhap.AutoCompleteCustomSource = suggestList;

            // Khi người dùng nhấn Enter
            txtNhap.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Enter)
                {
                    string tacGiaMoi = txtNhap.Text.Trim();
                    if (!string.IsNullOrEmpty(tacGiaMoi))
                    {
                        TagPanel tag = new TagPanel(tacGiaMoi);

                        // Thêm vào panel và xóa ô nhập
                        int index = pnlAuthors.Controls.IndexOf(txtNhap);
                        pnlAuthors.Controls.Add(tag);
                        pnlAuthors.Controls.SetChildIndex(tag, index);

                        txtNhap.Clear();
                        txtNhap.Focus();
                    }
                    else
                    {
                        pnlAuthors.Controls.Remove(txtNhap);
                    }
                }
            };

            // Khi mất focus thì xóa ô nhập
            txtNhap.LostFocus += (s, ev) => pnlAuthors.Controls.Remove(txtNhap);

            pnlAuthors.Controls.Add(txtNhap);
            txtNhap.Focus();
        }
        #endregion


        private void FrmAddEditBookTitle_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Cancel)
            {
                var confirm = MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            else if (this.DialogResult == DialogResult.OK)
            {
                if (!ValidateInputs())
                {
                    e.Cancel = true;
                    return;
                }

                bool success = _isEditMode ? UpdateBookTitle() : AddBookTitle();
                e.Cancel = !success;
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtBookName.Text))
            {
                MessageBox.Show("Tên tựa sách không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool AddBookTitle()
        {
            try
            {
                var dto = this.TuaSach;
                var newId = BUS.TuaSachBUS.AddBookTitle(dto);

                if (string.IsNullOrEmpty(newId))
                    throw new Exception("Không nhận được mã tựa sách sau khi thêm.");

                dto.MaTuaSach = newId;
                this.TuaSach = dto;
                return true;
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool UpdateBookTitle()
        {
            try
            {
                var dto = this.TuaSach;
                BUS.TuaSachBUS.UpdateBookTitle(dto);
                return true;
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
