using Cleaver.Classes;

namespace Cleaver
{
    internal static class Program
    {
        [STAThread]
        internal static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            AppInstance instance = new AppInstance();

            Application.Run(instance);
        }
    }
}