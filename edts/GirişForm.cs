using edts;
using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;
using System.Configuration;
namespace edts
{
    // Bu, formunuzun başlangıç tanımıdır.
    public partial class GirişForm : Form
    {
        private int aktifRolID;
        public GirişForm()
        {
            InitializeComponent();
            // Diğer kodlar veya atamalar BURAYA GELMEZ. Sadece başlatma yapılır.
            button2.Image = Properties.Resources.eyek;

        }
        public GirişForm(int gelenRolID)
        {
            InitializeComponent(); // <-- Bu satır şimdi çalışmalı
            aktifRolID = gelenRolID;

            this.Load += AnaMenuForm_Load;
            this.Visible = false;
        }

        private void AnaMenuForm_Load(object sender, EventArgs e)
        {
            Form? acilacakForm = null;


            switch (aktifRolID)
            {
                case 1:
                    acilacakForm = new frmAdminAnaMenu();
                    break;
                // ...
                default:
                    MessageBox.Show("Yetkiniz bulunmamaktadır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                    return;
            }

            if (acilacakForm != null)
            {
                acilacakForm.Show();
            }

            this.Close();
        }
        private void btnGiris_Click(object sender, EventArgs e)
        {

            string kullaniciAdi = textBox1.Text;
            string sifre = loginpsw.Text; 

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {

                MessageBox.Show("Kullanıcı adı ve şifre boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {


                string girisHash = GuvenlikYardimcisi.HashSifre(sifre);
                string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;


                string sorgu = "SELECT KullaniciID, RolID, AdSoyad FROM tblKullanicilar WHERE KullaniciAdi=@pKullaniciAdi AND SifreHash=@pSifreHash AND AktifMi=1";

                using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
                {
                    using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@pKullaniciAdi", kullaniciAdi);
                        // 🟢 KRİTİK DÜZELTME: SQL'e HASH'lenmiş değeri gönderiyoruz.
                        komut.Parameters.AddWithValue("@pSifreHash", girisHash); // <-- Düzeltildi!

                        baglanti.Open();
                        SqlDataReader okuyucu = komut.ExecuteReader();
                        if (okuyucu.Read())
                        {
                            int kullaniciID = (int)okuyucu["KullaniciID"];
                            int rolID = (int)okuyucu["RolID"];
                            string adSoyad = okuyucu["AdSoyad"].ToString();


                                AktifKullanici.ID = kullaniciID;
                                AktifKullanici.KullaniciAdi = kullaniciAdi;
                                AktifKullanici.RolID = rolID;
                                AktifKullanici.TamAd = adSoyad;

                            // 🟢 KRİTİK LOGLAMA ADIMI 2: Giriş Başarısını Denetim Kaydına Ekleme
                            int girisHareketID = 1; // Artık biliyoruz: GİRİŞ'in HareketID'si 1.

                                VeritabaniYardimcisi.LogKaydet(
                                    kullaniciID: AktifKullanici.ID,
                                    hareketID: girisHareketID,
                                    tabloAdi: "tblKullanicilar",
                                    aciklama: adSoyad + " (" + kullaniciAdi + ") başarılı bir şekilde sisteme giriş yaptı."
                                );

                                AnaMenuForm anaForm = new AnaMenuForm(rolID);

                            // Göz yanılmasını engellemek için Giriş Formunu gizle
                            this.Visible = false;

                            // Yönlendirici formu MODAL olarak aç. 
                            // AnaMenuForm kapanana kadar kod burada BEKLER.
                            anaForm.ShowDialog();

                            // AnaMenuForm (yönlendirici) kapandığında buraya döneriz.
                            // Artık ana formunuz (frmAdminAnaMenu) arkada açıktır.
                            this.Close(); // <-- GİRİŞ FORMUNU KAPATAN SATIR!

                            return;
                        }
                        else
                        {
                            // Kullanıcı veya şifre hatalı
                            // lblHata.Text = "*Kullanıcı Adı veya Şifre Hatalı";
                            // lblHata.Visible = true;
                            MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı.", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // 1. Yeni Destek/Yardım formunun bir örneğini oluştur
            frmSupport supportForm = new frmSupport();

            // 2. Destek formunu göster
            supportForm.Show();

            // Not: Bu formu (frmLogin) kapatmak/gizlemek isteyip istemediğiniz size kalmış.
            // Eğer kullanıcının giriş yapana kadar Login ekranını görmesini istiyorsanız, 
            // alttaki satırı KULLANMAYIN.
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

    }
} 
