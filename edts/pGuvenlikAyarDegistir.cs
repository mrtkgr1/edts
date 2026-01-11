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
using static edts.Sabitler;

namespace edts {
    public partial class pGuvenlikAyarDegistir : Form {

        string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

        public pGuvenlikAyarDegistir() {
            InitializeComponent();
            AyarKurulum();
        }

        private void AyarKurulum() {
            textBoxKAd.Text = AktifKullanici.KullaniciAdi;
            textBoxTad.Text = AktifKullanici.TamAd;
            DateTime? tmp = GuvenlikKullanici.GetDate(AktifKullanici.ID, "son_sifre_degisiklik");
            labelSfr.Text = "Şifre: Son Değişiklik " + (tmp != null ? tmp.Value.ToString("dd.MM.yy") : "Yok");

            if (!SistemAyarYonetim.AyarBoolGetir("hesap_ayark_kad")) {
                buttonKad.Enabled = false;
                textBoxKAd.Enabled = false;
            }

            if (!SistemAyarYonetim.AyarBoolGetir("hesap_ayark_tad")) {
                buttonTad.Enabled = false;
                textBoxTad.Enabled = false;
            }

            if (!SistemAyarYonetim.AyarBoolGetir("hesap_ayark_sfr")) {
                buttonSfr.Enabled = false;
            }
        }

        private void buttonKad_Click(object sender, EventArgs e) {
            string tmp = textBoxKAd.Text;

            if (String.IsNullOrEmpty(tmp)) {
                MessageBox.Show("Alan boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try {
                string sorgu = @"UPDATE tblKullanicilar SET KullaniciAdi = @pKullaniciAdi, WHERE KullaniciID = @pID";

                using (SqlConnection baglanti = new SqlConnection(baglantiDizesi)) {
                    using (SqlCommand komut = new SqlCommand(sorgu, baglanti)) {

                        komut.Parameters.AddWithValue("@pKullaniciAdi", tmp);


                        baglanti.Open();
                        komut.ExecuteNonQuery();
                    }
                }
                VeritabaniYardimcisi.LogKaydet(AktifKullanici.ID, IslemTuru.Kullanini_Degisiklik, "tblKullanicilar",
                    "\"" + tmp + "(" + AktifKullanici.ID + ")\" adlı kullanıcı bilgileri değiştiirldi.");
                AktifKullanici.KullaniciAdi = tmp;

                this.Close();

            } catch (Exception ex) {
                MessageBox.Show("Güncelleme sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonTad_Click(object sender, EventArgs e) {
            string tmp = textBoxTad.Text;
            if (String.IsNullOrEmpty(tmp)) {
                MessageBox.Show("Alan boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try {
                string sorgu = @"UPDATE tblKullanicilar SET AdSoyad = @pAdSoyad, WHERE KullaniciID = @pID";

                using (SqlConnection baglanti = new SqlConnection(baglantiDizesi)) {
                    using (SqlCommand komut = new SqlCommand(sorgu, baglanti)) {

                        komut.Parameters.AddWithValue("@pAdSoyad", tmp);


                        baglanti.Open();
                        komut.ExecuteNonQuery();
                    }
                }
                VeritabaniYardimcisi.LogKaydet(AktifKullanici.ID, IslemTuru.Kullanini_Degisiklik, "tblKullanicilar",
                    "\"" + tmp + "(" + AktifKullanici.ID + ")\" adlı kullanıcı bilgileri değiştiirldi.");
                AktifKullanici.TamAd = tmp;

                this.Close();

            } catch (Exception ex) {
                MessageBox.Show("Güncelleme sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSfr_Click(object sender, EventArgs e) {

        }
    }
}
