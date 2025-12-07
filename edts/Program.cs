using SQLitePCL;
namespace edts
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
            Edts.DbOlustur();

            /*ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            MessageBox.Show("asa");*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var login = new FormLogin())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new UserMainForm(login.Username));
                }
            }
        }
    }
}