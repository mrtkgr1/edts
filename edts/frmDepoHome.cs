using EnvanterDepoSistemitaslak2;
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

    public partial class frmDepoHome : Form
    {    
        
        // <<< BURAYA EKLEYİN: Aktif Kullanıcı ID'sini tutacak değişken >>>
        private int aktifKullaniciID;

        public frmDepoHome()
        {
            InitializeComponent();
            // Gelen ID'yi sınıf değişkenine atayın
            
        }
        private void IcerikYukle(Form yeniForm)
        {
            pnlAnaIcerik.Controls.Clear();
            yeniForm.TopLevel = false;
            yeniForm.FormBorderStyle = FormBorderStyle.None;
            yeniForm.Dock = DockStyle.Fill;
            pnlAnaIcerik.Controls.Add(yeniForm);
            yeniForm.Show();
        }
        private int ayarlarMenuDurum = 0;

        private void frmDepoHome_Load(object sender, EventArgs e)
        {

        }


        private void pbxAyarlar_Click(object sender, EventArgs e)
        {
            // Mevcut görünürlük durumunu kontrol et (Destek Label'ı üzerinden kontrol ediyoruz)
            bool mevcutDurum = lblDestek.Visible;

            // Durumu tersine çevir (Gizli ise göster, görünürse gizle)
            bool yeniDurum = !mevcutDurum;

            // Destek ve Çıkış Yap bölümlerini göster/gizle
            lblDestek.Visible = yeniDurum;
            pbxDestek.Visible = yeniDurum;

            lblCikisYap.Visible = yeniDurum;
            pbxCikisYap.Visible = yeniDurum;

            // Not: Tüm bu kontrollerin (lblDestek, pbxDestek, vb.) tasarımcıda doğru adlandırıldığından emin olun.
        }

        private void pbxCikisYap_Click(object sender, EventArgs e)
        {
            // Çıkış yapma işlemini Label'ın Click olayına yönlendiriyoruz
            lblCikisYap_Click(sender, e);
        }

        private void lblCikisYap_Click(object sender, EventArgs e)
        {
            // frmDepoHome'u gizle ve kapat
            this.Hide();
            this.Close();

            // Giriş formunu yeniden aç
            GirişForm loginFormu = new GirişForm();
            loginFormu.Show();
        }

        private void lblDestek_Click(object sender, EventArgs e)
        {
            // Destek formunun yeni bir örneğini oluştur
            frmSupport supportForm = new frmSupport();

            // pnlAnaIcerik paneline yükle
            IcerikYukle(supportForm);
        }

        private void pbxDestek_Click(object sender, EventArgs e)
        {
            // PictureBox'a tıklandığında Label'ın Click olayını tetikle
            // Bu, kodu iki kez yazmamızı engeller.
            lblDestek_Click(sender, e);
        }

        private void pbxKategori_Click(object sender, EventArgs e)
        {
            ayarlarMenuDurum++;

            // Tüm PictureBox ve Label'ları tek bir koleksiyonda tutmak daha temizdir,
            // ancak şimdilik manuel olarak ekleyelim:

            // GİZLENECEK/GÖSTERİLECEK TÜM KONTROLLERİ TANIMLAYIN
            // (Lütfen formunuzdaki tüm menü öğelerini buraya ekleyin)
            Control[] tumMenüKontrolleri = new Control[]
            {
        // PICTUREBOX'LAR
        pbxAnasayfa, pbxStokGiris, pbxStokCikis, pbxRapor, pbxStokListele, pbxDestek, pbxCikisYap,
        
        // LABEL'LAR
       lblAnaSayfa, lblStokGiris, lblStokCikis, lblRapor, lblStokListele, lblDestek, lblCikisYap,lblAyarlar
            };


            if (ayarlarMenuDurum == 1)
            {
                // DURUM 1: Sadece PictureBox'ları göster (Label'ları gizli tut)

                foreach (Control control in tumMenüKontrolleri)
                {
                    if (control is PictureBox)
                    {
                        control.Visible = true;
                    }
                    else if (control is Label)
                    {
                        control.Visible = false;
                    }
                }
            }
            else if (ayarlarMenuDurum == 2)
            {
                // DURUM 2: Hem PictureBox'ları hem Label'ları göster

                foreach (Control control in tumMenüKontrolleri)
                {
                    control.Visible = true; // Hepsini göster
                }

                // Reset: Bir sonraki tıklamada Durum 0'a (Gizliye) dönsün
                ayarlarMenuDurum = 0;
            }
            else // ayarlarMenuDurum == 0 (veya 3 olduysa)
            {
                // DURUM 0: Hepsini gizle

                foreach (Control control in tumMenüKontrolleri)
                {
                    control.Visible = false;
                }

                // Reset: Bir sonraki tıklamada Durum 1'e geçmesi için
                ayarlarMenuDurum = 0;
            }
        }

        private void pbxStokGiris_Click(object sender, EventArgs e)
        {
            lblStokGiris_Click(sender, e); // Label olayına yönlendir
        }

        private void lblStokGiris_Click(object sender, EventArgs e)
        {
            IcerikYukle(new frmStokGiris()); // <-- PARAMETRESİZ Çağrıya geri döndü
        }

        private void pbxRapor_Click(object sender, EventArgs e)
        {
            lblRapor_Click(sender, e); // Label olayına yönlendir
        }

        private void lblRapor_Click(object sender, EventArgs e)
        {
            IcerikYukle(new frmDepoRapor());
        }

        private void lblStokListele_Click(object sender, EventArgs e)
        {
            IcerikYukle(new frmStokListele());
        }

        private void pbxStokListele_Click(object sender, EventArgs e)
        {
            lblStokListele_Click(sender, e); // Label olayına yönlendir
        }

        private void lblStokCikis_Click(object sender, EventArgs e)
        {
            IcerikYukle(new frmStokCikis());
        }

        private void pbxStokCikis_Click(object sender, EventArgs e)
        {
            lblStokCikis_Click(sender, e); // Label olayına yönlendir
        }

        private void lblAnaSayfa_Click(object sender, EventArgs e)
        {
            IcerikYukle(new frmAnaSayfa());
        }

        private void pbxAnasayfa_Click(object sender, EventArgs e)
        {
            lblAnaSayfa_Click(sender, e); // Label olayına yönlendir
        }
    }
}

