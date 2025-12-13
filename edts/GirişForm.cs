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
            Form acilacakForm = null;

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
            // Hata etiketini temizle (lblHata kontrolünün adını kontrol edin)
            // Eğer etiketiniz yoksa aşağıdaki satırı yorum satırı yapabilirsiniz.
            // lblHata.Visible = false;

            // 1. Kullanıcıdan alınan değerler
            string kullaniciAdi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text; // Şifrenizi hash'lemeyi unutmayın!

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                // lblHata.Text = "Kullanıcı adı ve şifre boş bırakılamaz.";
                // lblHata.Visible = true;
                MessageBox.Show("Kullanıcı adı ve şifre boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
              


                // Bağlantı dizesini App.config'den okur
                string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

                // 1. GÜNCELLENMİŞ SORGUNUZ: @pSifreHash parametresini kullanmalı
                string sorgu = "SELECT RolID, AdSoyad FROM tblKullanicilar WHERE KullaniciAdi=@pKullaniciAdi AND SifreHash=@pSifreHash AND AktifMi=1";

                using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
                {
                    using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@pKullaniciAdi", kullaniciAdi);
                        komut.Parameters.AddWithValue("@pSifreHash", sifre);

                        baglanti.Open();
                        SqlDataReader okuyucu = komut.ExecuteReader();

                        if (okuyucu.Read())
                        {
                            int rolID = (int)okuyucu["RolID"];

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

        }
   
    }
} 
