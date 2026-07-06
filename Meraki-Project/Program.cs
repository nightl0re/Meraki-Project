namespace Meraki_Project
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

            // Navigation.Start runs a message loop that is NOT tied to any single
            // form, so navigating between forms (which closes the current one)
            // never accidentally exits the application. The app quits when the
            // last open window is closed.
            Navigation.Start(new LoginForm());
        }
    }
}
