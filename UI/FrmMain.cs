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

        private void btnReaders_Click(object sender, EventArgs e)
        {
            var frmReaders = new FrmReaders();
            frmReaders.TopLevel = false;
            frmReaders.FormBorderStyle = FormBorderStyle.None;
            frmReaders.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(frmReaders);
            frmReaders.Show();
        }
    }
}
