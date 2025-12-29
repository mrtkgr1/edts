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
           /* switch (aktifRolID)
            {
                case 1: 
                    acilacakForm = new frmAdminAnaMenu();
                    break;

                case 2: 
                    acilacakForm = new frmYoneticiAna();
                    break;

                case 3: 
                    acilacakForm = new frmDepoHome();
                    break;
                
                default:
                    // Tanımlanmamış rol ID'si için
                    MessageBox.Show("Rol ID'niz sisteme tanımlı değildir.", "Yetki Hatası", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();
                    return; // Formu kapattıktan sonra daha fazla işlem yapma
            }*/
            AyarYonetimi.AyarlariSenkronizeEt(AktifKullanici.ID);
            acilacakForm = new AnaForm();

            if (acilacakForm != null)
            {
                acilacakForm.ShowDialog();

                this.Close();
            }
            else
            {
                // Rol ID'si tanımlı ama form açılmadıysa
                MessageBox.Show("Yetkiniz bulunmamaktadır veya hedef form oluşturulmamıştır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
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
