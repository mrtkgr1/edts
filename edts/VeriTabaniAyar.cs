using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace edts {
    public partial class VeriTabaniAyar : Form {
        public VeriTabaniAyar() {
            InitializeComponent();
        }

        string mevcutBaglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

        string yeniBaglantiDizesi = string.Empty;

        private void VeriTabaniAyar_Load(object sender, EventArgs e) {
            veriTabaniBilgi.Text = "Mevcut Veri Tabanı Bağlantısı: " + VeritabaniYardimcisi.SunucuyuGetir();
            mevcutAd.Text = "Mevcut Veritabanı Adı: " + VeritabaniYardimcisi.VeritabaniAdiniGetir();
           // mevcutTest.Text = VeritabaniYardimcisi.BaglantiyiTestEt(mevcutBaglantiDizesi, out string hataMesaji) ? "Mevcut bağlantı geçerli." : "Mevcut bağlantı geçersiz: " + hataMesaji;

        }

        //test

        private void buttonMevcutTest_Click(object sender, EventArgs e) {
            mevcutTest.Text = "Test yapılıyor...";
            mevcutTest.Update();
            mevcutTest.Text = VeritabaniYardimcisi.BaglantiyiTestEt(mevcutBaglantiDizesi, out string hataMesaji) ? "Mevcut bağlantı geçerli." : "Mevcut bağlantı geçersiz: " + hataMesaji;
        }

        private void buttonYeniTest_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(yeniBaglantiDizesi)) {
                yeniTest.Text = "Bağlantı dizesi oluşturulamadı.";
                return;
            }

            yeniTest.Text = "Test yapılıyor...";
            yeniTest.Update();
            yeniTest.Text = VeritabaniYardimcisi.BaglantiyiTestEt(yeniBaglantiDizesi, out string hataMesaji) ? "Yeni bağlantı geçerli." : "Yeni bağlantı geçersiz: " + hataMesaji;
        }

        //değiştir kısa süreli yeni bağlantı bilgilerini gösterir 

        private void buttonDegistir_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(textBoxYeniDizi.Text.Trim()) && string.IsNullOrEmpty(textBoxYeniAd.Text.Trim())){
                MessageBox.Show(this,"Lütfen en az bir değer girin.");
                return;
            }

            string tmpDizi = textBoxYeniDizi.Text.Trim();
            string tmpAd = textBoxYeniAd.Text.Trim();

            if (string.IsNullOrWhiteSpace(tmpDizi)) {
                tmpDizi = VeritabaniYardimcisi.SunucuyuGetir();
            }
            if (string.IsNullOrWhiteSpace(tmpAd)) {
                tmpAd = VeritabaniYardimcisi.VeritabaniAdiniGetir();
            }

            yeniBaglantiDizesi = VeritabaniYardimcisi.BaglaniOlustur(mevcutBaglantiDizesi, tmpDizi, tmpAd);
            yeniVeriTabaniBilgi.Text = "Yeni Veri Tabanı Bağlantısı: " + VeritabaniYardimcisi.SunucuyuGetir(yeniBaglantiDizesi);
            yeniAd.Text = "Yeni Veritabanı Adı: " + VeritabaniYardimcisi.VeritabaniAdiniGetir(yeniBaglantiDizesi);

            buttonYeniTest.PerformClick();
        }

        //kaydet
        private void button1_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(yeniBaglantiDizesi)) {
                if (!VeritabaniYardimcisi.BaglantiyiTestEt(yeniBaglantiDizesi, out string hataMesaji)) {
                    MessageBox.Show("Yeni bağlantı geçersiz: \n" + hataMesaji);
                    return;
                }
                VeritabaniYardimcisi.BaglantiyiGuncelle(yeniBaglantiDizesi);
            }
            MessageBox.Show("Değişiklikler kaydedildi. Uygulama kapanacak ve yeni bağlantı ayarları ile yeniden başlatılacak.");
            Application.Restart();
        }

        private void label3_Click(object sender, EventArgs e) {

        }
    }
}
