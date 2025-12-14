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
        private const int CikisHareketID = 2;
        private bool isMenuAcik = true;
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

        // 2. pbSistemAyarlari (frmAdminSistemAyarlari açar)
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

        // Menünün varsayılan (açık) genişliği
        private const int AcikMenuGenislik = 300; // Bu değeri kendi tasarımınıza göre ayarlayın
                                                  // Menünün katlanmış (sadece ikon) genişliği
        private const int KapaliMenuGenislik = 100;  // Bu değeri ikon boyutuna göre ayarlayın

        private void pbKategori_Click(object sender, EventArgs e)
        {
            frmAdminAnaMenu? anaForm = GetParentAdminForm();
            if (anaForm != null) {
                if (anaForm.SolPanelDurumunuDegistir()) {
                    LabellariGoster();
                } else {
                    LabellariGizle();
                }
            }
        }
        private void LabellariGizle()
        {
            // Tüm Label (etiket) kontrollerini burada listeleyin ve Visible = false yapın.
            lblAnasayfa.Visible = false;
            lblSistemAyarlari.Visible = false;
            lblDenetimKayitlari.Visible = false;
            lblKullaniciKayit.Visible = false;
            lblCikis.Visible = false;
            lblSupport.Visible = false;
            lblAyarlar.Visible = false;
            // Opsiyonel: "Hoşgeldiniz" ve kullanıcı adı etiketlerini de gizleyebilirsiniz
            label1.Visible = false; 
            pictureBox1.Visible = false;
        }

        private void LabellariGoster()
        {
            // Tüm Label (etiket) kontrollerini burada listeleyin ve Visible = true yapın.
            lblAnasayfa.Visible = true;
            lblSistemAyarlari.Visible = true;
            lblDenetimKayitlari.Visible = true;
            lblKullaniciKayit.Visible = true;
            lblCikis.Visible = true;
            lblSupport.Visible = true;
            lblAyarlar.Visible = true;
            // Opsiyonel: "Hoşgeldiniz" ve kullanıcı adı etiketlerini de gösterin
            label1.Visible = true;
            pictureBox1.Visible = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            // Varsayılan olarak altındaki kontrollerin Visible=false olduğunu varsayıyoruz.
            {
                // Altındaki kontrollerin Visible özelliğini tersine çevir
                // (Lütfen alt menü kontrollerinizin isimlerini buraya yazın)
                pbCikisYap.Visible = !pbCikisYap.Visible;
                pbDestek.Visible = !pbDestek.Visible;
            }
        }


           private void pbCikisYap_Click(object sender, EventArgs e)
        {
            // Bu kodun içini, label5_Click'teki loglama bloğuyla aynı şekilde doldurun.
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

            this.ParentForm.Close();
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
        // Bu metot, form adını alıp ilgili içeriği Ana Menüde açar.
        private void IcerikAc(Type formTipi)
        {
            // 1. Ana formu (frmAdminAnaMenu) bulma
            frmAdminAnaMenu anaForm = this.ParentForm as frmAdminAnaMenu;

            if (anaForm != null)
            {
                // 2. Dinamik olarak form örneği oluşturma
                // (Not: Activator.CreateInstance() kullanmak, formları daha esnek açmanızı sağlar)
                Form yeniIcerikFormu = (Form)Activator.CreateInstance(formTipi);

                // 3. Ana formdaki IcerikDegistir metodunu çağırarak içeriği değiştirme
                anaForm.IcerikDegistir(yeniIcerikFormu);
            }
        }
        // 1. ANASAYFA Label'ı
        private void lblAnasayfa_Click(object sender, EventArgs e)
        {
            // PictureBox'ın açtığı formun aynısını açar.
            IcerikAc(typeof(frmAdminHomeIcerik));
        }
        // 2. SİSTEM AYARLARI Label'ı
        private void lblSistemAyarlari_Click(object sender, EventArgs e)
        {
            IcerikAc(typeof(frmAdminSistemAyarlari));
        }

        // 3. DENETİM KAYITLARI Label'ı
        private void lblDenetimKayitlari_Click(object sender, EventArgs e)
        {
            IcerikAc(typeof(frmAdminDenetimKayitlari));
        }

        // 4. KULLANICI KAYIT Label'ı
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
           
            // 1. LOG KAYDINI YAP (Veritabanı bağlantı kütüphanelerini kullan)
            try
            {
                // KullanıcıID: Çıkış yapan kullanıcının ID'si
                // HareketID: 2 (Çıkış)

                VeritabaniYardimcisi.LogKaydet(
                    kullaniciID: AktifKullanici.ID,
                    hareketID: CikisHareketID,
                    tabloAdi: "tblKullanicilar", // Uygulamadan çıkış olduğu için genelde bu tablo verilir.
                    aciklama: AktifKullanici.KullaniciAdi + " menüden çıkış yaptı."
                );

                // Önemli: Loglama başarılı olduktan sonra aktif kullanıcı bilgilerini temizlemek isteyebilirsiniz.
                AktifKullanici.ID = 0;
                AktifKullanici.KullaniciAdi = "";

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Çıkış logu kaydedilirken hata oluştu: " + ex.Message);
            }

            // 2. FORMU KAPAT ve Giriş Formunu Aç
            this.ParentForm.Close();
            edts.GirişForm girisFormu = new edts.GirişForm();
            girisFormu.Show();
        }
    }
    }


