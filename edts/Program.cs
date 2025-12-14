using System;
using System.Windows.Forms; // BU SATIR KRÝTÝK!
using SQLitePCL; // SQLite kütüphaneniz de kalsýn

namespace edts
{
    internal static class Program
    {
        [STAThread] // Bu nitelik burada olmalý
        static void Main()
        {
            // Bu ayarlar görsel arayüzün (WinForms) düzgün çalýþmasýný saðlar
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Uygulama artýk GirisForm ile baþlayacak
            Application.Run(new frmYoneticiAna());
        }
    }
}