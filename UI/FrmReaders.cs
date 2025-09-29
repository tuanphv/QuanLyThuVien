using QRCoder;

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
            dgvReaders.DataSource = null;
            dgvReaders.DataSource = readers;

        }

        private void LoadLibraryCards()
        {
            DisplayQRCode(pctBoxQRCode, "QR001_e0765d33 - 9c84 - 11f0 - 9641 - 28c5c83a206c");
            var libraryCards = BUS.LibraryCardBUS.GetAllLibraryCards();
            dgvLibraryCards.DataSource = null;
            dgvLibraryCards.DataSource = libraryCards;
        }

        private void dtgvReaders_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvReaders.ClearSelection();
        }

        private void tbcReaders_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = tbcReaders.SelectedIndex;
            if (index == 0)
            {
                LoadReaders();
            }
            else if (index == 1)
            {
                LoadLibraryCards();
            }
        }

        public static Bitmap GenerateQrBitmap(string text, int pixelsPerModule = 20)
        {
            using (var qrGenerator = new QRCodeGenerator())
            using (var qrData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q)) // ECCLevel: L, M, Q, H
            using (var qrCode = new QRCode(qrData))
            {
                return qrCode.GetGraphic(pixelsPerModule); // trả về Bitmap
            }
        }

        public static void DisplayQRCode(PictureBox pictureBox, string payload)
        {
            Bitmap bmp = GenerateQrBitmap(payload, 4); // điều chỉnh kích thước qua pixelsPerModule
            pictureBox.Image = bmp;

            // Lưu file PNG
            //bmp.Save("qrcode.png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
