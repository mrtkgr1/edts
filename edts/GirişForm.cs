using edts;
using Microsoft.Data.SqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace edts
{
    public partial class GirişForm : Form
    {
        private int aktifRolID;
        private int denemeSayisi = 0;

        public GirişForm()
        {
            InitializeComponent();
            SistemAyarYonetim.AyarlariSenkronizeEt();

            txtSifre.KeyDown += TextBox1_KeyDown;
            loginpsw.KeyDown += Loginpsw_KeyDown;
            kavisliButon1.KeyDown += BtnGiris_KeyDown;
        }

        private string appFolder =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "edts");

        private string loginFile => Path.Combine(appFolder, "remember.txt");


        public void GuvenlikKullaniciKontrol(int userId)
        {

            string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(baglantiDizesi))
            {
                string query = @"
            IF NOT EXISTS (SELECT 1 FROM tblKullaniciGuvenlik WHERE userId = @userId)
            BEGIN
                INSERT INTO tblKullaniciGuvenlik 
                (userId, basarisiz_giris_sayi, zorunlu_sifre_degistir, durum_2fa, durum, ayar_engel) 
                VALUES 
                (@userId, 0, 0, 0, 1, 0)
            END";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void GirişForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                txtSifre.Text = "Kullanıcı Adı";
                txtSifre.ForeColor = Color.Gray;
            }
            if (string.IsNullOrWhiteSpace(loginpsw.Text))
            {
                loginpsw.Text = "Şifre";
                loginpsw.ForeColor = Color.Gray;
                loginpsw.PasswordChar = '\0';
            }

            chkRemember.Checked = File.Exists(loginFile);

            if (File.Exists(loginFile) && false)
            {
                try
                {
                    int savedUserId = int.Parse(File.ReadAllText(loginFile));
                    string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

                    using (SqlConnection con = new SqlConnection(baglantiDizesi))
                    {
                        string query = "SELECT KullaniciID, RolID, AdSoyad, KullaniciAdi FROM tblKullanicilar WHERE KullaniciID=@UserId AND AktifMi=1";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@UserId", savedUserId);
                            con.Open();

                            SqlDataReader dr = cmd.ExecuteReader();
                            if (dr.Read())
                            {
                                AktifKullanici.ID = (int)dr["KullaniciID"];
                                AktifKullanici.KullaniciAdi = dr["KullaniciAdi"].ToString();
                                AktifKullanici.RolID = (int)dr["RolID"];
                                AktifKullanici.TamAd = dr["AdSoyad"].ToString();

                                AnaMenuForm anaForm = new AnaMenuForm(AktifKullanici.RolID);
                                anaForm.Show();

                                this.Close();
                            }
                        }
                    }
                }
                catch
                {
                }
            }

            txtSifre.Focus();
        }


        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                loginpsw.Focus();
            }
        }

        private void Loginpsw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                kavisliButon1.Focus();
            }
        }

        private void BtnGiris_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                kavisliButon1.PerformClick();
            }
        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginpsw_TextChanged(object sender, EventArgs e)
        {

        }

        private void kavisliButon1_Click(object sender, EventArgs e)
        {
            GirisIslemi();
        }
        private void GirisIslemi()
        {
            string kullaniciAdi = (txtSifre.Text ?? "").Trim();
            string sifre = (loginpsw.Text ?? "").Trim();

            bool kullaniciAdiPlaceholder = string.Equals(kullaniciAdi, "Kullanıcı Adı", StringComparison.OrdinalIgnoreCase);
            bool sifrePlaceholder = string.Equals(sifre, "Şifre", StringComparison.OrdinalIgnoreCase);

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre) || kullaniciAdiPlaceholder || sifrePlaceholder)
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string girisHash = GuvenlikYardimcisi.HashSifre(sifre);
                string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
                string sorgu = "SELECT KullaniciID, RolID, AdSoyad, SifreHash FROM tblKullanicilar WHERE KullaniciAdi=@pKullaniciAdi AND AktifMi=1";

                using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@pKullaniciAdi", kullaniciAdi);
                    baglanti.Open();

                    SqlDataReader okuyucu = komut.ExecuteReader();
                    if (okuyucu.Read())
                    {
                        int kullaniciID = (int)okuyucu["KullaniciID"];
                        int rolID = (int)okuyucu["RolID"];
                        string adSoyad = okuyucu["AdSoyad"].ToString();
                        string sifreHash = okuyucu["SifreHash"].ToString();

                        GuvenlikKullaniciKontrol(kullaniciID);

                        if (GirisKilidiKontrol(kullaniciID))
                            return;

                        if (girisHash != sifreHash)
                        {
                            HatalıGirisIslemleri(kullaniciID, kullaniciAdi);
                            return;
                        }


                        if (chkRemember.Checked)
                        {
                            if (!Directory.Exists(appFolder))
                                Directory.CreateDirectory(appFolder);

                            File.WriteAllText(loginFile, kullaniciID.ToString());
                        }
                        else
                        {
                            if (File.Exists(loginFile))
                                File.Delete(loginFile);
                        }

                        AktifKullanici.ID = kullaniciID;
                        AktifKullanici.KullaniciAdi = kullaniciAdi;
                        AktifKullanici.RolID = rolID;
                        AktifKullanici.TamAd = adSoyad;

                        VeritabaniYardimcisi.LogKaydet(
                            kullaniciID: AktifKullanici.ID,
                            hareketID: 1,
                            tabloAdi: "tblKullanicilar",
                            aciklama: adSoyad + " (" + kullaniciAdi + ") başarılı bir şekilde sisteme giriş yaptı."
                        );

                        AnaMenuForm anaForm = new AnaMenuForm(rolID);
                        this.Visible = false;
                        anaForm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı.", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool GirisKilidiKontrol(int kullaniciID)
        {
            string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
            using (var connection = new SqlConnection(baglantiDizesi))
            {
                string query = "SELECT kilit_acilma_tarih FROM tblKullaniciGuvenlik WHERE userId = @UserId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", kullaniciID);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        DateTime unlockDate = Convert.ToDateTime(result);
                        if (unlockDate > DateTime.Now)
                        {
                            TimeSpan kalanZaman = unlockDate - DateTime.Now;
                            MessageBox.Show($"Çok fazla hatalı giriş yapıldı. {kalanZaman.Hours} saat {kalanZaman.Minutes} dakika {kalanZaman.Seconds} saniye sonra tekrar deneyin.", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private void HatalıGirisIslemleri(int kullaniciID, string kullaniciAdi)
        {
            VeritabaniYardimcisi.LogKaydet(kullaniciID, Sabitler.IslemTuru.Oturum_Basarisiz, "tblKullanicilar", $"{kullaniciAdi} hatalı şifre girildi. Oturum açma başarısız.");

            GuvenlikKullanici.SetDate(kullaniciID, "son_basarisiz_giris", DateTime.Now);
            int hata_sayi = GuvenlikKullanici.GetInt(kullaniciID, "basarisiz_giris_sayi") + 1;
            GuvenlikKullanici.SetInt(kullaniciID, "basarisiz_giris_sayi", hata_sayi);

            int denemeHak = SistemAyarYonetim.AyarIntGetir("giris_sure_denemesi");
            int denemeHak2 = SistemAyarYonetim.AyarIntGetir("giris_denemesi");

            if (SistemAyarYonetim.AyarBoolGetir("hesabi_kilitleme") && hata_sayi >= denemeHak2)
            {
                string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
                using SqlConnection connection = new SqlConnection(baglantiDizesi);
                string sorguIc = "UPDATE tblKullanicilar SET AktifMi = 0 WHERE KullaniciID = @UserId";
                using SqlCommand command = new SqlCommand(sorguIc, connection);
                command.Parameters.AddWithValue("@UserId", kullaniciID);
                connection.Open();
                command.ExecuteNonQuery();

                MessageBox.Show("Çok fazla hatalı giriş yapıldığı için hesap kalıcı kilitlenmiştir.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (SistemAyarYonetim.AyarBoolGetir("giri_sure_engel") && hata_sayi >= denemeHak)
            {
                GuvenlikKullanici.SetDate(kullaniciID, "kilit_acilma_tarih", DateTime.Now.AddMinutes(SistemAyarYonetim.AyarIntGetir("girs_sure_zaman")));
                MessageBox.Show(
                    $"Hatalı şifre girildi. {((denemeHak - hata_sayi) > 0 ? (denemeHak - hata_sayi).ToString() + " deneme hakkınız kaldı." : "Hesap geçici süre kilitlendi.")}",
                    "Giriş Başarısız",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı.", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSupport registerForm = new frmSupport();
            registerForm.ShowDialog();
        }

        private void txtSifre_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                txtSifre.Text = "Kullanıcı Adı";
                txtSifre.ForeColor = Color.Gray;
            }
        }

        private void loginpsw_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(loginpsw.Text))
            {
                loginpsw.Text = "Şifre";
                loginpsw.ForeColor = Color.Gray;
                loginpsw.PasswordChar = '\0';
            }
        }

        private void txtSifre_Enter(object sender, EventArgs e)
        {
            if (txtSifre.Text == "Kullanıcı Adı")
            {
                txtSifre.Text = "";
                txtSifre.ForeColor = Color.Black;
            }
        }

        private void loginpsw_Enter_1(object sender, EventArgs e)
        {
            if (loginpsw.Text == "Şifre")
            {
                loginpsw.Text = "";
                loginpsw.ForeColor = Color.Black;
                loginpsw.PasswordChar = '*';
            }
        }
    }
}