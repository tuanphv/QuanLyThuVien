using System;
using System.Collections.Generic;
namespace UI
{
    public partial class FrmReaders : Form
    {
        public FrmReaders()
        {
            InitializeComponent();
        }

        private void FrmReaders_Load(object sender, EventArgs e)
        {
            LoadReaders();
        }

        private void LoadReaders()
        {
            var readers = BUS.ReaderBUS.GetAllReaders();
            dtgvReaders.Columns.Clear();
            dtgvReaders.DataSource = null;
            dtgvReaders.DataSource = readers;
            
        }

        private void dtgvReaders_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dtgvReaders.ClearSelection();
        }
    }
}
