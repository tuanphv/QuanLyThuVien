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
    }
}
