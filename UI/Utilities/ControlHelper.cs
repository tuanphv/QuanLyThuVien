using QRCoder;

namespace UI.Utilities
{
    public class ControlHelper
    {
        /// <summary>
        /// Bật hoặc tắt nhiều button cùng lúc.
        /// </summary>
        /// <param name="enabled">true để bật, false để tắt</param>
        /// <param name="buttons">Danh sách button cần xử lý</param>
        public static void SetButtonsEnabled(bool enabled, params Button[] buttons)
        {
            foreach (var btn in buttons)
            {
                btn.Enabled = enabled;
            }
        }

        /// <summary>
        /// Hiện hoặc ẩn nhiều button cùng lúc.<br/>
        /// visible = true để hiện, false để ẩn
        /// </summary>
        /// <param name="enabled">true để bật, false để tắt</param>
        /// <param name="buttons">Danh sách button cần xử lý</param>
        public static void SetButtonsVisible(bool visible, params Button[] buttons)
        {
            foreach (var btn in buttons)
            {
                btn.Visible = visible;
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

        public static void DisplayQRCode(PictureBox pictureBox, string payload, int pixelsPerModule = 4)
        {
            Bitmap bmp = GenerateQrBitmap(payload, pixelsPerModule); // điều chỉnh kích thước qua pixelsPerModule
            pictureBox.Image = bmp;

            // Lưu file PNG
            //bmp.Save("qrcode.png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
