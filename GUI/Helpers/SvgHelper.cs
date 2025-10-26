using Svg;

namespace GUI.Helpers
{
    public static class SvgHelper
    {
        // ----------------------------------------------------
        // HÀM CHÍNH: Tải và Thay đổi màu SVG từ Resource
        // ----------------------------------------------------
        /// <summary>
        /// Tải SVG từ Properties.Resources, thay đổi màu, và render thành Bitmap.
        /// </summary>
        /// <param name="svgBytes">Mảng bytes của file SVG, lấy từ Properties.Resources.</param>
        /// <param name="newFillColor">Màu mới cho icon.</param>
        /// <param name="size">Kích thước (width/height) mong muốn của ảnh Bitmap đầu ra.</param>
        /// <returns>Đối tượng Image (Bitmap) đã được thay đổi màu sắc và kích thước.</returns>
        public static Image LoadSvgAndChangeColor(byte[] svgBytes, Color newFillColor, int width = 20, int height = -1)
        {
            if (height == -1) height = width;
            if (svgBytes == null || svgBytes.Length == 0)
            {
                // Trả về ảnh trống nếu resource không tồn tại hoặc bị lỗi
                return new Bitmap(width, height);
            }

            // 1. Tải tài liệu SVG từ MemoryStream
            // Sử dụng MemoryStream để đọc mảng bytes như một file
            using (MemoryStream ms = new MemoryStream(svgBytes))
            {
                var svgDocument = SvgDocument.Open<SvgDocument>(ms);

                // 2. Thay đổi màu sắc (sử dụng hàm hỗ trợ đệ quy)
                ChangeColorRecursive(svgDocument.Children, newFillColor);

                // 3. Render (Kết xuất) SVG thành Bitmap
                return svgDocument.Draw(width, height);
            }
        }

        // ----------------------------------------------------
        // HÀM HỖ TRỢ ĐỆ QUY (Không đổi)
        // ----------------------------------------------------
        private static void ChangeColorRecursive(SvgElementCollection elements, Color newFillColor)
        {
            foreach (var element in elements)
            {
                if (element is Svg.SvgVisualElement visualElement)
                {
                    visualElement.Fill = new SvgColourServer(newFillColor);

                    if (visualElement.Stroke != SvgPaintServer.None)
                    {
                        visualElement.Stroke = new SvgColourServer(newFillColor);
                    }
                }

                if (element.Children != null && element.Children.Count > 0)
                {
                    ChangeColorRecursive(element.Children, newFillColor);
                }
            }
        }
    }
}