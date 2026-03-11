using System;
using System.Configuration;
using System.Windows.Forms; 
using SQLitePCL; 

namespace edts
{
    internal static class Program
    {
        [STAThread] 
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (VeritabaniYardimcisi.BaglantiyiTestEt(ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString, out String hataMesaji)) {
                Application.Run(new GirisForm());
            } else {
                Application.Run(new VeriTabaniAyar());
            }
        }
    }
}