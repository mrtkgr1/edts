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
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace edts
{
    public partial class frmAdminHomeIcerik : Form
    {

        static string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
        public frmAdminHomeIcerik()
        {
            InitializeComponent();
            SolPanelScroll();
        }

        private void SolPanelScroll() {
            panel1.MouseWheel += Panel_MouseWheel!;

            panel1.MouseEnter += (s, e) => panel1.Focus();
            panel3.MouseEnter += (s, e) => panel1.Focus();
        }

        private void Panel_MouseWheel(object sender, MouseEventArgs e) {

            if (panel3.Height <= panel1.Height) return;

            int yeniY;

            if (e.Delta > 0) {
                yeniY = panel3.Top + 20;
            } else {
                yeniY = panel3.Top - 20;
            }

            if (yeniY > 0) yeniY = 0;


            int minY = panel1.Height - panel3.Height;
            if (yeniY < minY) yeniY = minY;

            panel3.Top = yeniY;
        }

        private void frmAdminHomeIcerik_Load(object sender, EventArgs e)
        {
            const int ADMIN_ROL_ID = 1;
            const int YONETICI_ROL_ID = 2;
            const int DEPO_ROL_ID = 3;


            try
            {
                lblToplamKullaniciSayisi.Text = HaftaGirisYapmayan().ToString();

                int kilitliSayisi = VeritabaniYardimcisi.KayitSayisiGetir("tblKullanicilar", "AktifMi = 0");
                lblKilitliHesapSayisi.Text = kilitliSayisi.ToString();


                int adminSayisi = VeritabaniYardimcisi.KayitSayisiGetir("tblKullanicilar", $"RolID = {ADMIN_ROL_ID} AND AktifMi = 1");
                lblAdminSayisi.Text = adminSayisi.ToString();

                int yoneticiSayisi = VeritabaniYardimcisi.KayitSayisiGetir("tblKullanicilar", $"RolID = {YONETICI_ROL_ID} AND AktifMi = 1");
                lblYoneticiSayisi.Text = yoneticiSayisi.ToString();

                int depoSayisi = VeritabaniYardimcisi.KayitSayisiGetir("tblKullanicilar", $"RolID = {DEPO_ROL_ID} AND AktifMi = 1");
                lblDepoPersoneliSayisi.Text = depoSayisi.ToString();


                lblEskiSifreKullananSayisi.Text = SfrIslem().ToString();

                lblAdminOturumlariSayisi.Text = BugunGirisSayisi().ToString();

                lblBekleyenIslemSayisi.Text = (VeritabaniYardimcisi.KayitSayisiGetir("tblKullanicilar") - BugunGirisSayisi()).ToString();

                lblHataKayitlariSayisi.Text = HareketSayisiniGetir().ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("İstatistikler yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        public int BugunGirisSayisi() {
            int sayi = 0;
            DateTime bugunBaslangic = DateTime.Today;

            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi)) {
                string sql = "SELECT COUNT(DISTINCT KullaniciID) FROM tblDenetimKayitlari WHERE HareketID = @pHareketID AND IslemTarihi >= @pTarih";

                using (SqlCommand komut = new SqlCommand(sql, baglanti)) {
                    komut.Parameters.AddWithValue("@pHareketID", 1);
                    komut.Parameters.AddWithValue("@pTarih", bugunBaslangic);

                    baglanti.Open();
                    sayi = (int)komut.ExecuteScalar();
                }
            }
            return sayi;
        }

        public int HaftaGirisYapmayan() {
            int sayi = 0;
            DateTime bugunBaslangic = DateTime.Now.AddDays(-7);

            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi)) {
                string sql = "SELECT COUNT(DISTINCT KullaniciID) FROM tblDenetimKayitlari WHERE HareketID = @pHareketID AND IslemTarihi >= @pTarih";

                using (SqlCommand komut = new SqlCommand(sql, baglanti)) {
                    komut.Parameters.AddWithValue("@pHareketID", 1);
                    komut.Parameters.AddWithValue("@pTarih", bugunBaslangic);

                    baglanti.Open();
                    sayi = (int)komut.ExecuteScalar();
                }
            }
            return VeritabaniYardimcisi.KayitSayisiGetir("tblKullanicilar") - sayi;
        }

        public int HareketSayisiniGetir() {
                int islemSayisi = 0;
                DateTime sonBirGun = DateTime.Now.AddDays(-1);

                using (SqlConnection baglanti = new SqlConnection(baglantiDizesi)) {
                    string sql = "SELECT COUNT(*) FROM tblDenetimKayitlari WHERE HareketID = @pHareketID AND IslemTarihi >= @pTarih";

                    using (SqlCommand komut = new SqlCommand(sql, baglanti)) {
                        komut.Parameters.AddWithValue("@pHareketID", 12);
                        komut.Parameters.AddWithValue("@pTarih", sonBirGun);

                        baglanti.Open();
                        islemSayisi = (int)komut.ExecuteScalar();
                    }
                }
                return islemSayisi;
            }

         public int SfrIslem() {
            int toplam = 0;
            DateTime otuzGunOncesi = DateTime.Now.AddDays(SistemAyarYonetim.AyarIntGetir("sifre_yenile_gun"));

            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi)) {
                string sql = "SELECT COUNT(*) FROM tblKullaniciGuvenlik WHERE son_sifre_degisiklik IS NOT NULL AND son_sifre_degisiklik < @pTarih";

                using (SqlCommand komut = new SqlCommand(sql, baglanti)) {
                    komut.Parameters.AddWithValue("@pTarih", otuzGunOncesi);
                    baglanti.Open();
                    toplam = (int)komut.ExecuteScalar();
                }
            }
            return toplam;
        }
        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
