using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace edts
{
    public partial class frmAdminHomeIcerik : Form
    {
        public frmAdminHomeIcerik()
        {
            InitializeComponent();
        }

        private void frmAdminHomeIcerik_Load(object sender, EventArgs e)
        {
            // KESİNLEŞTİRİLMİŞ ROL ID'LERİ: Lütfen veritabanınızdaki RolID'leriniz bu şekildeyse kullanın.
            const int ADMIN_ROL_ID = 1;
            const int YONETICI_ROL_ID = 2;
            const int DEPO_ROL_ID = 3;

            // Veritabanı Yardımıcısı metodunun (KayitSayisiGetir) bu sınıfta erişilebilir olduğundan emin olun.

            try
            {
                // 1. TOPLAM ve KİLİTLİ KULLANICILAR (tblKullanicilar)

                // Toplam Kayıtlı Kullanıcı
                int toplamKullanici = VeritabaniYardimcisi.KayitSayisiGetir("tblKullanicilar");
                lblToplamKullaniciSayisi.Text = toplamKullanici.ToString();

                // Kilitli Hesap Sayısı (AktifMi = 0 olanlar)
                // Kullanicilar tablonuzda 'AktifMi' sütunu 'bit' (bool) tipinde olduğu için 0 kullanıyoruz.
                int kilitliSayisi = VeritabaniYardimcisi.KayitSayisiGetir("tblKullanicilar", "AktifMi = 0");
                lblKilitliHesapSayisi.Text = kilitliSayisi.ToString();

                // 2. ROL BAZLI KULLANICILAR (Aktif Olanlar)

                // Admin Sayısı
                int adminSayisi = VeritabaniYardimcisi.KayitSayisiGetir("tblKullanicilar", $"RolID = {ADMIN_ROL_ID} AND AktifMi = 1");
                lblAdminSayisi.Text = adminSayisi.ToString();

                // Yönetici Sayısı
                int yoneticiSayisi = VeritabaniYardimcisi.KayitSayisiGetir("tblKullanicilar", $"RolID = {YONETICI_ROL_ID} AND AktifMi = 1");
                lblYoneticiSayisi.Text = yoneticiSayisi.ToString();

                // Depo Personeli Sayısı
                int depoSayisi = VeritabaniYardimcisi.KayitSayisiGetir("tblKullanicilar", $"RolID = {DEPO_ROL_ID} AND AktifMi = 1");
                lblDepoPersoneliSayisi.Text = depoSayisi.ToString();

                // 3. LOG VE ÖZEL İSTATİSTİKLER (Gerekli Log/Hata tabloları eksik)

                // Eski Şifre Kullananlar: (Şifre değişim tarihi sütunu eksik)
                lblEskiSifreKullananSayisi.Text = "0";

                // Admin Oturumları: (Denetim Log tablosu eksik)
                lblAdminOturumlariSayisi.Text = "0";

                // Bekleyen İşlem Sayısı: (Sipariş/Görev tablosu eksik)
                lblBekleyenIslemSayisi.Text = "0";

                // Hata Kayıtları Sayısı: (Hata Log tablosu eksik)
                lblHataKayitlariSayisi.Text = "0";

            }
            catch (Exception ex)
            {
                MessageBox.Show("İstatistikler yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Hata durumunda tüm etiketlere "-" atayarak hatayı görselleştirme
                lblToplamKullaniciSayisi.Text = "-";
                lblKilitliHesapSayisi.Text = "-";
                lblYoneticiSayisi.Text = "-";
                lblDepoPersoneliSayisi.Text = "-";
                lblAdminSayisi.Text = "-";
                lblEskiSifreKullananSayisi.Text = "-";
                lblAdminOturumlariSayisi.Text = "-";
                lblBekleyenIslemSayisi.Text = "-";
                lblHataKayitlariSayisi.Text = "-";
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
