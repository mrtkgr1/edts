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

    public partial class frmKullaniciDüzenle : Form {

        string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
        int userId = 0;
        public frmKullaniciDüzenle(int id) {
            InitializeComponent();
            RolleriDoldur();
            userId = id;
            KullaniciBilgileriniGetir(id);
        }

        private void KullaniciBilgileriniGetir(int id) {
            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi)) {
                string sorgu = "SELECT AdSoyad, KullaniciAdi, RolID, AktifMi FROM tblKullanicilar WHERE KullaniciID = @id";
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@id", id);

                baglanti.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read()) {
                    textBoxTamAd.Text = dr["AdSoyad"].ToString();
                    textBoxKullaniciAd.Text = dr["KullaniciAdi"].ToString();
                    comboBoxRol.SelectedValue = dr["RolID"];
                    checkBoxAktiflik.Checked = Convert.ToBoolean(dr["AktifMi"]);
                }
                baglanti.Close();
            }


            TimeSpan? kalanZaman = null;
            DateTime? unlockDate = null;

            using (var connection = new SqlConnection(baglantiDizesi)) {
                string query = "SELECT kilit_acilma_tarih FROM tblKullaniciGuvenlik WHERE userId = @UserId";
                using (var command = new SqlCommand(query, connection)) {
                    command.Parameters.Add("@UserId", SqlDbType.Int).Value = id;
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value) {
                        unlockDate = Convert.ToDateTime(result);
                        if (unlockDate > DateTime.Now) {
                            kalanZaman = unlockDate - DateTime.Now;
                        }
                    }
                }
            }

            if (kalanZaman != null) {
                buttonKilit.Enabled = true;
                labelKilit.Text = unlockDate.Value.ToString("dd.MM.yyyy HH:mm:ss") + " tarihine kadar kilitli.";
            }

            DateTime? hataliGiris = GuvenlikKullanici.GetDate(id, "son_basarisiz_giris");

            labelHataliGiris.Text = "Son hatalı giriş: "+(hataliGiris != null ? hataliGiris.ToString() : "yok.");
        }

        private void btnHesapGuncelle_Click(int dID) {
            if (string.IsNullOrEmpty(textBoxKullaniciAd.Text) ||
            string.IsNullOrEmpty(textBoxTamAd.Text) ||
            comboBoxRol.SelectedValue == null) {
                MessageBox.Show("Ad Soyad, Kullanıcı Adı ve Rol alanları boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try {
                string sorgu = "";
                string sifreHash = "";

                if (!string.IsNullOrEmpty(textBoxsifre.Text)) {
                    sifreHash = GuvenlikYardimcisi.HashSifre(textBoxsifre.Text);

                    sorgu = @"UPDATE tblKullanicilar SET 
                 AdSoyad = @pAdSoyad, KullaniciAdi = @pKullaniciAdi, SifreHash = @pSifreHash, 
                 RolID = @pRolID, AktifMi = @pAktifMi 
                 WHERE KullaniciID = @pID";
                } else {
                    sorgu = @"UPDATE tblKullanicilar SET 
                 AdSoyad = @pAdSoyad, KullaniciAdi = @pKullaniciAdi, 
                 RolID = @pRolID, AktifMi = @pAktifMi 
                 WHERE KullaniciID = @pID";

                }

                bool aktifMi = checkBoxAktiflik.Checked;

                using (SqlConnection baglanti = new SqlConnection(baglantiDizesi)) {
                    using (SqlCommand komut = new SqlCommand(sorgu, baglanti)) {

                        komut.Parameters.AddWithValue("@pAdSoyad", textBoxTamAd.Text);
                        komut.Parameters.AddWithValue("@pKullaniciAdi", textBoxKullaniciAd.Text);
                        komut.Parameters.AddWithValue("@pRolID", (int)comboBoxRol.SelectedValue);
                        komut.Parameters.AddWithValue("@pAktifMi", aktifMi ? 1 : 0);
                        komut.Parameters.AddWithValue("@pID", userId);

                        if (!string.IsNullOrEmpty(textBoxsifre.Text)) {
                            komut.Parameters.AddWithValue("@pSifreHash", sifreHash);
                        }

                        baglanti.Open();
                        komut.ExecuteNonQuery();
                    }
                }
                if(!string.IsNullOrEmpty(textBoxsifre.Text))
                VeritabaniYardimcisi.LogKaydet(AktifKullanici.ID, IslemTuru.Kullanici_Sifre_Degisiklik, "tblKullanicilar",
                 "\"" + textBoxKullaniciAd.Text + "(" + userId + ")\" adlı kullanıcının şifresi güncellendi.");

                VeritabaniYardimcisi.LogKaydet(AktifKullanici.ID, IslemTuru.Kullanini_Degisiklik, "tblKullanicilar", 
                    "\"" + textBoxKullaniciAd.Text + "("+ userId +")\" adlı kullanıcı bilgileri değiştiirldi.");

                MessageBox.Show("Kullanıcı bilgileri başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();

            } catch (Exception ex) {
                MessageBox.Show("Güncelleme sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RolleriDoldur() {
            var rolListesi = Enum.GetValues(typeof(Rol))
            .Cast<Rol>()
            .Select(r => new {
                RolID = (int)r,
                RolAd = r.ToString()
            })
            .ToList();

            rolListesi.Insert(0, new {
                RolID = 0,
                RolAd = "Tüm Roller"
            });

            comboBoxRol.DataSource = rolListesi;
            comboBoxRol.DisplayMember = "RolAd";
            comboBoxRol.ValueMember = "RolID";
        }
        private void button2_Click(object sender, EventArgs e) {
            btnHesapGuncelle_Click(userId);
        }

        private void buttonKilit_Click(object sender, EventArgs e) {
            buttonKilit.Enabled = false;
            labelKilit.Text = "Kilit kaldırıldı.";
            GuvenlikKullanici.SetDate(userId, "kilit_acilma_tarih", null);
        }
    }
}
