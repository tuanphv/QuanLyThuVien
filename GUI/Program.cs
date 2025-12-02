using GUI.Helpers;

namespace GUI
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
            Application.SetHighDpiMode(HighDpiMode.DpiUnaware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();

            while (true)
            {
                // Show login dialog
                using (var login = new Login.FrmLogin())
                {
                    var dlg = login.ShowDialog();
                    if (dlg != DialogResult.OK || !SessionManager.IsLoggedIn)
                    {
                        // user cancelled or login failed → exit app
                        break;
                    }
                }

                // Run main window. When it closes, we decide whether to loop back to login (logout) or exit.
                using (var main = new FrmMain())
                {
                    Application.Run(main);
                }

                // After main closes: if session was cleared (Logout called), continue to show login again.
                // If session still valid (user closed main without logging out), break and exit.
                if (!SessionManager.IsLoggedIn)
                    continue; // show login again
                else
                    break; // exit app
            }
        }
    }
}