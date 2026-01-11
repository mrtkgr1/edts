using edts;
using Microsoft.Data.SqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
namespace edts
{
    public partial class GirişForm : Form {
        private int aktifRolID;
        private int denemeSayisi = 0;
        public GirişForm() {
            InitializeComponent();
            button2.Image = Properties.Resources.eyek;
            SistemAyarYonetim.AyarlariSenkronizeEt();
        }
        public GirişForm(int gelenRolID) {
            InitializeComponent();
            aktifRolID = gelenRolID;

            this.Load += AnaMenuForm_Load;
            this.Visible = false;
        }

        private void AnaMenuForm_Load(object sender, EventArgs e) {
            Form? acilacakForm = null;


            switch (aktifRolID) {
                case 1:
                    acilacakForm = new frmAdminAnaMenu();
                    break;
                // ...
                default:
                    MessageBox.Show("Yetkiniz bulunmamaktadır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                    return;
            }

            if (acilacakForm != null) {
                acilacakForm.Show();
            }

            this.Close();
        }
        private void btnGiris_Click(object sender, EventArgs e) {

            string kullaniciAdi = textBox1.Text;
            string sifre = loginpsw.Text;

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre)) {

                MessageBox.Show("Kullanıcı adı ve şifre boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try {
                string girisHash = GuvenlikYardimcisi.HashSifre(sifre);
                string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;


                string sorgu = "SELECT KullaniciID, RolID, AdSoyad, SifreHash FROM tblKullanicilar WHERE KullaniciAdi=@pKullaniciAdi AND AktifMi=1";

                using (SqlConnection baglanti = new SqlConnection(baglantiDizesi)) {
                    using (SqlCommand komut = new SqlCommand(sorgu, baglanti)) {
                        komut.Parameters.AddWithValue("@pKullaniciAdi", kullaniciAdi);

                        baglanti.Open();
                        SqlDataReader okuyucu = komut.ExecuteReader();

                        if (okuyucu.Read()) {

                            int kullaniciID = (int)okuyucu["KullaniciID"];
                            int rolID = (int)okuyucu["RolID"];
                            string adSoyad = okuyucu["AdSoyad"].ToString();
                            string sifreHash = okuyucu["SifreHash"].ToString();

                            GuvenlikKullaniciKontrol(kullaniciID);

                            TimeSpan? kalanZaman = null;

                            using (var connection = new SqlConnection(baglantiDizesi)) {
                                string query = "SELECT kilit_acilma_tarih FROM tblKullaniciGuvenlik WHERE userId = @UserId";
                                using (var command = new SqlCommand(query, connection)) {
                                    command.Parameters.Add("@UserId", SqlDbType.Int).Value = kullaniciID;
                                    connection.Open();
                                    object result = command.ExecuteScalar();

                                    if (result != null && result != DBNull.Value) {
                                        DateTime unlockDate = Convert.ToDateTime(result);
                                        if (unlockDate > DateTime.Now) {
                                            kalanZaman = unlockDate - DateTime.Now;
                                        }
                                    }
                                }
                            }

                            if (kalanZaman != null) {
                                MessageBox.Show("Çok fazla hatalı giriş yapma denemesi yapıldı. " + kalanZaman.Value.Hours + "saat " + kalanZaman.Value.Minutes + "dakika " + kalanZaman.Value.Seconds + "saniye" + " sonra tekrar deneyin.", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (girisHash != sifreHash) {

                                VeritabaniYardimcisi.LogKaydet(
                                     kullaniciID,
                                     Sabitler.IslemTuru.Oturum_Basarisiz,
                                     "tblKullanicilar",
                                     "\n" + kullaniciAdi + "\n hatalı şifre girildi. Oturum açma başarısız."
                                );

                                GuvenlikKullanici.SetDate(kullaniciID, "son_basarisiz_giris", DateTime.Now);

                                int hata_sayi = GuvenlikKullanici.GetInt(kullaniciID, "basarisiz_giris_sayi") + 1;
                                GuvenlikKullanici.SetInt(kullaniciID, "basarisiz_giris_sayi", hata_sayi);
                                int denemeHak = SistemAyarYonetim.AyarIntGetir("giris_sure_denemesi");
                                int denemeHak2 = SistemAyarYonetim.AyarIntGetir("giris_denemesi");

                                if (SistemAyarYonetim.AyarBoolGetir("hesabi_kilitleme")) {
                                    if (hata_sayi >= denemeHak2) {

                                        using (var connection = new SqlConnection(baglantiDizesi)) {
                                            string sorguIc = "UPDATE tblKullanicilar SET AktifMi = @aa WHERE KullaniciID = @UserId";
                                            using (var command = new SqlCommand(sorguIc, connection)) {
                                                command.Parameters.AddWithValue("@UserId", kullaniciID);
                                                command.Parameters.AddWithValue("@aa", 0);
                                                connection.Open();
                                                command.ExecuteNonQuery();
                                            }
                                        }
                                        MessageBox.Show("Çok fazla hatalı giriş yapıldığı için hesap kalıcı kilitlenmiştir.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        VeritabaniYardimcisi.LogKaydet(
                                             kullaniciID,
                                             Sabitler.IslemTuru.Oturum_Basarisiz,
                                             "tblKullanicilar",
                                             "\n" + kullaniciAdi + "\n hesabı çok fazla hatalı giriş denemesi nedeniyle kalıcı olarak kilitlendi."
                                        );
                                        return;
                                    }
                                }

                                if (SistemAyarYonetim.AyarBoolGetir("giri_sure_engel")) {
                                    if (hata_sayi >= denemeHak) {
                                        GuvenlikKullanici.SetDate(kullaniciID, "kilit_acilma_tarih", DateTime.Now.AddMinutes(SistemAyarYonetim.AyarIntGetir("girs_sure_zaman")));

                                    }
                                    MessageBox.Show("Hatalı şifre girildi. " + ((denemeHak - hata_sayi) > 0 ? (denemeHak - hata_sayi) + " deneme hakkınız kaldı." : " Çok fazla hatalı giriş yapıldığı için hesap geçici süre kilitlendi."), "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                } else {
                                    MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı.", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                return;
                            }

                            //----------- Başarılı giriş işlemleri -----------

                            AktifKullanici.ID = kullaniciID;
                            AktifKullanici.KullaniciAdi = kullaniciAdi;
                            AktifKullanici.RolID = rolID;
                            AktifKullanici.TamAd = adSoyad;

                            int girisHareketID = 1;

                            VeritabaniYardimcisi.LogKaydet(
                                kullaniciID: AktifKullanici.ID,
                                hareketID: girisHareketID,
                                tabloAdi: "tblKullanicilar",
                                aciklama: adSoyad + " (" + kullaniciAdi + ") başarılı bir şekilde sisteme giriş yaptı."
                            );


                            AnaMenuForm anaForm = new AnaMenuForm(rolID);

                            this.Visible = false;

                            anaForm.ShowDialog();

                            this.Close();

                            return;
                        } else {
                            MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı.", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show("Veritabanı Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            frmSupport supportForm = new frmSupport();

            supportForm.Show();
        }

        public void GuvenlikKullaniciKontrol(int userId) {

            string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(baglantiDizesi)) {
                string query = @"
            IF NOT EXISTS (SELECT 1 FROM tblKullaniciGuvenlik WHERE userId = @userId)
            BEGIN
                INSERT INTO tblKullaniciGuvenlik 
                (userId, basarisiz_giris_sayi, zorunlu_sifre_degistir, durum_2fa, durum, ayar_engel) 
                VALUES 
                (@userId, 0, 0, 0, 1, 0)
            END";

                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@userId", userId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }



        private void button2_Click(object sender, EventArgs e) {
            if (loginpsw.PasswordChar == '*') {
                button2.Image = Properties.Resources.eye;
                loginpsw.PasswordChar = '\0';
            } else {
                button2.Image = Properties.Resources.eyek;
                loginpsw.PasswordChar = '*';
            }
        }

        private void GirişForm_Load(object sender, EventArgs e) {

            loginForm.BackColor = Color.FromArgb(100, 255, 255, 255);
        }

        private void textBox1_Enter(object sender, EventArgs e) {
            if (textBox1.Text == "Kullanıcı Adı") {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(textBox1.Text)) {
                textBox1.Text = "Kullanıcı Adı";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void loginpsw_Enter(object sender, EventArgs e) {
            if (loginpsw.Text == "Şifre") {
                loginpsw.Text = "";
                loginpsw.ForeColor = Color.Black;
                loginpsw.PasswordChar = '*';
            }
        }

        private void loginpsw_Leave(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(loginpsw.Text)) {
                loginpsw.Text = "Şifre";
                loginpsw.ForeColor = Color.Gray;
                loginpsw.PasswordChar = '\0';
            }
        }

        private void txtKullanici_Enter(object sender, EventArgs e) {

        }

    }
} 
