namespace UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            try
            {
                Application.SetDefaultFont(new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point));
            } catch (Exception)
            {
                // If the font is not available, fallback to the default font.
                Application.SetDefaultFont(SystemFonts.DefaultFont);
            }
            Application.Run(new fLogin());
        }
    }
}