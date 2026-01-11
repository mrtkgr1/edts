using Microsoft.Data.SqlClient;
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
    public partial class pSfrD : Form {

        string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
        int kullaniciId = AktifKullanici.ID;
        public pSfrD() {
            InitializeComponent();
        }

        private void buttonOnay_Click() {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text)) {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!");
                return;
            }

            if (textBox2.Text != textBox3.Text) {
                MessageBox.Show("Yeni şifreler uyuşmuyor!");
                return;
            }

            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi)) {

                baglanti.Open();
                string sqlSifreAl = "SELECT SifreHash FROM tblKullanicilar WHERE KullaniciID=@pKullaniciID";
                string veritabanindakiHash = "";

                using (SqlCommand komutAl = new SqlCommand(sqlSifreAl, baglanti)) {
                    komutAl.Parameters.AddWithValue("@pKullaniciID", kullaniciId);
                    object sonuc = komutAl.ExecuteScalar();
                    if (sonuc != null) veritabanindakiHash = sonuc.ToString();
                }

                if (GuvenlikYardimcisi.HashSifre(textBox1.Text) == veritabanindakiHash) {
                    string yeniSifreHashli = GuvenlikYardimcisi.HashSifre(textBox2.Text);
                    string sqlGuncelle = "UPDATE tblKullanicilar SET SifreHash=@pYeniSifre WHERE KullaniciID=@pKullaniciID";

                    using (SqlCommand komutGuncelle = new SqlCommand(sqlGuncelle, baglanti)) {
                        komutGuncelle.Parameters.AddWithValue("@pYeniSifre", yeniSifreHashli);
                        komutGuncelle.Parameters.AddWithValue("@pKullaniciID", kullaniciId);

                        GuvenlikKullanici.SetDate(kullaniciId, "son_sifre_degisiklik", DateTime.Now);
                        VeritabaniYardimcisi.LogKaydet(AktifKullanici.ID, Sabitler.IslemTuru.Kullanici_Sifre_Degisiklik, "tblKullanicilar", AktifKullanici.KullaniciAdi + " adlı kullanıcı şifresini değiştirdi.");
                        MessageBox.Show("Şifre başarıyla değiştirildi.");

                        komutGuncelle.ExecuteNonQuery();
                        this.Close();
                        return;
                    }

                } else {
                    VeritabaniYardimcisi.LogKaydet(AktifKullanici.ID, Sabitler.IslemTuru.Oturum_Basarisiz, "tblKullanicilar", AktifKullanici.KullaniciAdi + " adlı kullanıcı şifre değiştirme penceresinde mevcut şifreyi hatalı girdi.");
                    MessageBox.Show("Mevcut şifre hatalı!");
                    return;
                }
            }
        }

        private void buttonOnay_Click_1(object sender, EventArgs e) {
            buttonOnay_Click();
        }

        private void button2_Click_1(object sender, EventArgs e) {
            this.Close();
        }
    }
}
