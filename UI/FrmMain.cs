using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            HighlightActiveButton(btnOverview);
        }

        private void btnOverview_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(sender as Button);
        }

        private void btnReaders_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(sender as Button);
            LoadEmbeddedForm(new FrmReaders(), "Quản lý độc giả");
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(sender as Button);
            //LoadEmbeddedForm(, "Quản lý sách");
        }
        private void btnGenrePublisher_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(sender as Button);
        }

        private void btnBorrowReturn_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(sender as Button);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(sender as Button);
        }

        /// <summary>
        /// Chuyển tất cả các nút menu về trạng thái mặc định, và làm nổi bật nút hiện tại
        /// </summary>
        /// <param name="activeButton"></param>
        private void HighlightActiveButton(Button activeButton)
        {
            // Reset all menu buttons
            foreach (Control control in pnlSidebar.Controls)
            {
                if (control is Button btn && btn.Name.StartsWith("btn") && btn != btnLogout)
                {
                    btn.BackColor = Color.Transparent;
                    btn.ForeColor = Color.DarkSlateGray;
                }
            }

            // Highlight active button
            if (activeButton != null)
            {
                activeButton.BackColor = Color.DarkSlateBlue;
                activeButton.ForeColor = Color.White;
            }
        }

        /// <summary>
        /// Load form vào panel
        /// </summary>
        /// <param name="form"></param>
        /// <param name="title"></param>
        private void LoadEmbeddedForm(Form form, string title)
        {
            // Clear any existing forms
            foreach (Control control in pnlContent.Controls.OfType<Form>().ToArray())
            {
                pnlContent.Controls.Remove(control);
                control.Dispose();
            }

            // Add new form
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(form);
            form.Show();

            // Update title
            lblHeaderTitle.Text = title;
        }

    }
}
