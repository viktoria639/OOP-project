namespace Tic_Tack_Toe
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new LogInForm(new Game()));
        }
    }
}