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
    public partial class frmAdminSolPanel : Form
    {
        private const int CikisHareketID = 11;
       
        private frmAdminAnaMenu? GetParentAdminForm()
        {
            return this.ParentForm as frmAdminAnaMenu;
        }
        public frmAdminSolPanel()

        {
            InitializeComponent();
        }
      

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pbAnasayfa_Click(object sender, EventArgs e)
        {
            frmAdminAnaMenu? anaForm = GetParentAdminForm();

            if (anaForm != null)
            {
                anaForm.IcerikDegistir(new frmAdminHomeIcerik());
            }
        }

        private void pbSistemAyarlari_Click(object sender, EventArgs e)
        {
            frmAdminAnaMenu? anaForm = GetParentAdminForm();

            if (anaForm != null)
            {
                anaForm.IcerikDegistir(new frmAdminSistemAyarlari());
            }
        }

        private void pbDenetimKayitlari_Click(object sender, EventArgs e)
        {
            frmAdminAnaMenu? anaForm = GetParentAdminForm();

            if (anaForm != null)
            {
                anaForm.IcerikDegistir(new frmAdminDenetimKayitlari());
            }
        }

        private void pbKullaniciKayit_Click(object sender, EventArgs e)
        {
            frmAdminAnaMenu? anaForm = GetParentAdminForm();

            if (anaForm != null)
            {
                anaForm.IcerikDegistir(new frmKullaniciYonetimi());
            }
        }

        private const int AcikMenuGenislik = 300; 
                                                  
        private const int KapaliMenuGenislik = 100;  

        private void pbKategori_Click(object sender, EventArgs e)
        {
            frmAdminAnaMenu? anaForm = GetParentAdminForm();
            if (anaForm != null)
            {
                if (anaForm.SolPanelDurumunuDegistir())
                {
                    LabellariGoster();
                }
                else
                {
                    LabellariGizle();
                }
            }
        }
        private void LabellariGizle()
        {
            lblAnasayfa.Visible = false;
            lblSistemAyarlari.Visible = false;
            lblDenetimKayitlari.Visible = false;
            lblKullaniciKayit.Visible = false;
            lblCikis.Visible = false;
            lblSupport.Visible = false;
            lblAyarlar.Visible = false;
            label1.Visible = false;
            pictureBox1.Visible = false;
        }

        private void LabellariGoster()
        {
            lblAnasayfa.Visible = true;
            lblSistemAyarlari.Visible = true;
            lblDenetimKayitlari.Visible = true;
            lblKullaniciKayit.Visible = true;
            lblCikis.Visible = true;
            lblSupport.Visible = true;
            lblAyarlar.Visible = true;
            label1.Visible = true;
            pictureBox1.Visible = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            {
                pbCikisYap.Visible = !pbCikisYap.Visible;
                pbDestek.Visible = !pbDestek.Visible;
            }
        }


        private void pbCikisYap_Click(object sender, EventArgs e)
        {
            try
            {
                VeritabaniYardimcisi.LogKaydet(
                    kullaniciID: AktifKullanici.ID,
                    hareketID: CikisHareketID,
                    tabloAdi: "tblKullanicilar",
                    aciklama: AktifKullanici.KullaniciAdi + " ikon üzerinden çıkış yaptı."
                );

                AktifKullanici.ID = 0;
                AktifKullanici.KullaniciAdi = "";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Çıkış logu kaydedilirken hata oluştu: " + ex.Message);
            }

            this.ParentForm?.Close();
            edts.GirişForm girisFormu = new edts.GirişForm();
            girisFormu.Show();
        }


        private void pbDestek_Click(object sender, EventArgs e)
        {
            frmAdminAnaMenu? anaForm = GetParentAdminForm();

            if (anaForm != null)
            {
                anaForm.IcerikDegistir(new frmSupport());
            }
        }
        private void IcerikAc(Type formTipi)
        {
            frmAdminAnaMenu? anaForm = this.ParentForm as frmAdminAnaMenu;

            if (anaForm == null)
            {
                return;
            }


            if (anaForm != null)
            {
                var instance = Activator.CreateInstance(formTipi);

                if (instance is Form yeniIcerikFormu)
                {
                    yeniIcerikFormu.TopLevel = false;
                    yeniIcerikFormu.Show();
                }
            }
        }
        private void lblAnasayfa_Click(object sender, EventArgs e)
        {
            IcerikAc(typeof(frmAdminHomeIcerik));
        }
        private void lblSistemAyarlari_Click(object sender, EventArgs e)
        {
            IcerikAc(typeof(frmAdminSistemAyarlari));
        }

        private void lblDenetimKayitlari_Click(object sender, EventArgs e)
        {
            IcerikAc(typeof(frmAdminDenetimKayitlari));
        }

        private void lblKullaniciKayit_Click(object sender, EventArgs e)
        {
            IcerikAc(typeof(frmKullaniciYonetimi));
        }

        // 5. DESTEK Label'ı
        private void lblDestek_Click(object sender, EventArgs e)
        {
            IcerikAc(typeof(frmSupport));
        }

        private void label5_Click(object sender, EventArgs e)
        {

            try
            {

                VeritabaniYardimcisi.LogKaydet(
                    kullaniciID: AktifKullanici.ID,
                    hareketID: CikisHareketID,
                    tabloAdi: "tblKullanicilar", 
                    aciklama: AktifKullanici.KullaniciAdi + " menüden çıkış yaptı."
                );

                AktifKullanici.ID = 0;
                AktifKullanici.KullaniciAdi = "";

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Çıkış logu kaydedilirken hata oluştu: " + ex.Message);
            }

            this.ParentForm?.Close();
            edts.GirişForm girisFormu = new edts.GirişForm();
            girisFormu.Show();
        }

        private void pictureBoxChatbot_Click(object sender, EventArgs e)
        {
            frmAdminAnaMenu? anaForm = GetParentAdminForm();
            if (anaForm != null)
            {
                anaForm.IcerikDegistir(new ChatbotForm());
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {
            IcerikAc(typeof(ChatbotForm));
        }
    }
}


