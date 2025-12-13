using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace edts
{
    public partial class AnaMenuForm : Form
    {
        private int aktifRolID;
        
        private void AnaMenuForm_Load(object? sender, EventArgs e)
        {
            Form? acilacakForm = null;

            // ... switch (aktifRolID) bloğu ...
            switch (aktifRolID)
            {
                case 1: // Admin Rolü
                    acilacakForm = new frmAdminAnaMenu();
                    break;
                    // ...
            }

            if (acilacakForm != null)
            {
                // frmAdminAnaMenu'yu modal (diyalog) olarak aç. 
                // Bu, frmAdminAnaMenu kapanana kadar kodun burada beklemesini sağlar.
                acilacakForm.ShowDialog(); // <-- Düzeltme: Show() yerine ShowDialog()

                // frmAdminAnaMenu kapandığında kod buraya döner.

                // Yönlendirme görevini tamamladığı için kendini kapat.
                this.Close();
            }
            else
            {
                // Yetkisiz girişte kapatma
                MessageBox.Show("Yetkiniz bulunmamaktadır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                // Application.Exit(); yerine sadece formu kapatarak kontrolü GirişForm'a geri verin
                this.Close(); // <-- Sadece bu formu kapatır.
            }
        }
        public AnaMenuForm(int gelenRolID)
        {
            InitializeComponent();
            aktifRolID = gelenRolID;

            // Yönlendirme görevini üstlenmeden önce bu pencereyi gizle
            this.Visible = false;

            // KRİTİK: Bu formun pencere çerçevesini kaldır (Bazı sistemlerde pencere açılmasını engeller)
            this.FormBorderStyle = FormBorderStyle.None;

            this.Load += AnaMenuForm_Load;
        }
    }
}
