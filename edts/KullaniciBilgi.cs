using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static edts.Sabitler;

namespace edts {
    public partial class KullaniciBilgi : Form {
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
        int kullaniciID = 0;
        bool aktiflik = true;

        public KullaniciBilgi(int userID) {
            InitializeComponent();
            kullaniciID = userID;
            kullaniciBilgileriDoldur(kullaniciID);
            butonOlustur();
        }

        public KullaniciBilgi(string userID) {
            InitializeComponent();
            kullaniciStringKurulum(userID);
            kullaniciBilgileriDoldur(kullaniciID);
            butonOlustur();
        }

        private void kullaniciBilgileriDoldur(int id) {
            if (id == AktifKullanici.ID) {
                lblAd.Text = AktifKullanici.TamAd;
                lblKullanici.Text = AktifKullanici.KullaniciAdi;
                lblYetki.Text = ((Sabitler.Rol)AktifKullanici.RolID).ToString();
            } else {
                string sorgu = "SELECT AdSoyad, KullaniciAdi, RolID, AktifMi FROM tblKullanicilar WHERE KullaniciID=@id";
                using (SqlConnection conn = new SqlConnection(baglantiDizesi)) {
                    try {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(sorgu, conn);
                        cmd.Parameters.AddWithValue("@id", id);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read()) {
                            lblAd.Text = reader.GetString(0);
                            lblKullanici.Text = reader.GetString(1);
                            lblYetki.Text = ((Sabitler.Rol)(int)reader["RolID"]).ToString();
                        }
                    } catch (Exception ex) {
                        MessageBox.Show("Profil penceresi gösterilemiyor. Hata:\n" + ex.Message);
                    }
                }
            }

            Image? profilResmi = GorselYonetim.Yukle(kullaniciID, "profil_resmi");
            if (profilResmi != null) {
                pictureBox1.Image = profilResmi;
            } else {
                pictureBox1.Image = Properties.Resources.var_pp;
            }
        }

        private void kullaniciStringKurulum(string id) {

            string sorgu = "SELECT KullaniciID FROM tblKullanicilar WHERE KullaniciAdi=@id";
            using (SqlConnection conn = new SqlConnection(baglantiDizesi)) {
                try {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sorgu, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) {
                        kullaniciID = (int)reader["KullaniciID"];
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Profil penceresi gösterilemiyor. Hata:\n" + ex.Message);
                }

            }
        }

        private void butonOlustur() {
            if (AktifKullanici.RolID == (int)Sabitler.Rol.Admin) {
                if (AktifKullanici.ID != kullaniciID) {
                    panelAdminAyar.Visible = true;
                    btnPPSec.Visible = true;
                    btnResimKaldir.Visible = true;
                }
            }
            if (AktifKullanici.ID == kullaniciID) {
                panelKullaniciAyar.Visible = true;
            }
        }

        private void buttonKullaniciAyar_Click(object sender, EventArgs e) {
            pGuvenlikAyarDegistir tmp = new pGuvenlikAyarDegistir();
            tmp.ShowDialog(this);

            kullaniciBilgileriDoldur(kullaniciID);
        }

        private void buttonBildirim_Click(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            frmKullaniciDüzenle tmp = new frmKullaniciDüzenle(kullaniciID);
            tmp.ShowDialog(this);

            kullaniciBilgileriDoldur(kullaniciID);
        }

        private void resizableButton1_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show(
                "Resmi silmeyi onaylıyor musunuz?",
                "Onay",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                GorselYonetim.Kaydet(kullaniciID, "profil_resmi", null);
                VeritabaniYardimcisi.LogKaydet(AktifKullanici.ID, IslemTuru.Kullanini_Degisiklik, "tblKullanicilar",
                kullaniciID + " kullanıcının profil resmi silindi.");
            }
            kullaniciBilgileriDoldur(kullaniciID);

        }

        private void btnPPSec_Click(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Görsel Seç";

                if (ofd.ShowDialog() == DialogResult.OK) {
                    try {
                        using (Image hamResim = Image.FromFile(ofd.FileName)) {
                            Image islenmisResim = GorselArac.KesveBoyutla(hamResim, 250, 250);

                            pictureBox1.Image = islenmisResim;

                            GorselYonetim.Kaydet(kullaniciID, "profil_resmi", islenmisResim);
                            VeritabaniYardimcisi.LogKaydet(AktifKullanici.ID, IslemTuru.Kullanini_Degisiklik, "tblKullanicilar",
                               kullaniciID +"  kullanıcının profil resmi güncelledi.");
                        }
                    } catch (OutOfMemoryException) {
                        MessageBox.Show("Seçilen dosya geçerli bir resim formatında değil veya çok büyük.");
                    } catch (Exception ex) {
                        MessageBox.Show("Resim yüklenirken hata oluştu: " + ex.Message);
                    }
                }
            }

            kullaniciBilgileriDoldur(kullaniciID);

        }

    }
}
