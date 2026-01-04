using edts;
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
namespace edts
{
    public partial class frmKullaniciYonetimi : Form {
        public frmKullaniciYonetimi() {
            InitializeComponent();
            // Diğer başlangıç ayarları buraya gelebilir
        }
        private int aktifKullaniciID = 0; // Seçili kullanıcının ID'sini tutar.
        private void KullanicilariListele() {
            try {
                // App.config dosyanızdaki "baglanti" adlı bağlantı dizesini okur.
                string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

                // NOT: Şifre (SifreHash) alanını güvenlik nedeniyle listelemiyoruz.
                string sorgu = "SELECT KullaniciID, AdSoyad, KullaniciAdi, RolID, AktifMi FROM tblKullanicilar ORDER BY KullaniciID DESC";

                using (SqlConnection baglanti = new SqlConnection(baglantiDizesi)) {
                    SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                    DataTable dt = new DataTable();

                    // Veriyi veritabanından DataTable'a doldurur.
                    da.Fill(dt);

                    // DataGridView'in veri kaynağını ayarlar.
                    dgvKullaniciListesi.DataSource = dt;

                    // İsteğe bağlı: Sütun başlıklarını okunaklı hale getirir.
                    dgvKullaniciListesi.Columns["KullaniciID"].HeaderText = "ID";
                    dgvKullaniciListesi.Columns["AdSoyad"].HeaderText = "Adı Soyadı";
                    dgvKullaniciListesi.Columns["KullaniciAdi"].HeaderText = "Kullanıcı Adı";
                    dgvKullaniciListesi.Columns["RolID"].HeaderText = "Rol ID";
                    dgvKullaniciListesi.Columns["AktifMi"].HeaderText = "Aktif";

                    // İsteğe bağlı: ID sütununu gizleyebiliriz veya en başta tutabiliriz.
                    // dgvKullaniciListesi.Columns["KullaniciID"].Visible = false;
                }
            } catch (Exception ex) {
                MessageBox.Show("Kullanıcılar listelenirken bir hata oluştu: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtKullaniciAdi_TextChanged(object sender, EventArgs e) {

        }

        private void frmKullaniciYonetimi_Load(object sender, EventArgs e) {
            try {
               // RolleriDoldur();
                KullanicilariListele();
            } catch (Exception ex) {
                // BU MESAJ KUTUSUNU GÖRMENİZ GEREKİYOR!
                MessageBox.Show("Form yüklenirken kritik bir hata oluştu: " + ex.Message,
                                "Kullanıcı Yönetimi Yükleme Hatası",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
       /* private void RolleriDoldur() {
            var rolListesi = Enum.GetValues(typeof(Rol))
                .Cast<Rol>()
                .Select(r => new {
                    RolID = (int)r,          
                    RolAd = r.ToString()    
                })
                .ToList();

            cmbRolSecim.DataSource = rolListesi;
            cmbRolSecim.DisplayMember = "RolAd"; 
            cmbRolSecim.ValueMember = "RolID";  

            cmbRolSecim.SelectedIndex = -1;
        }


        private void btnKullaniciKaydet_Click(object sender, EventArgs e) {
            // Zorunlu alan kontrolü
            if (string.IsNullOrEmpty(txtAdSoyad.Text) ||
                string.IsNullOrEmpty(txtKullaniciAdi.Text) ||
                string.IsNullOrEmpty(txtSifre.Text) ||
                cmbRolSecim.SelectedValue == null) {
                MessageBox.Show("Lütfen tüm zorunlu alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try {
                // 1. Şifreyi Hashle (Çok Önemli Güvenlik Adımı)
                string sifreHash = GuvenlikYardimcisi.HashSifre(txtSifre.Text);

                // 2. Kontrollerden verileri al
                string adSoyad = txtAdSoyad.Text;
                string kullaniciAdi = txtKullaniciAdi.Text;

                int rolID = Convert.ToInt32(cmbRolSecim.SelectedValue);
                // CheckBox durumunu al (true ise 1, false ise 0)
                bool aktifMi = chkAktifMi.Checked;

                string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

                // NOT: SifreHash sütununuzun veri tipinin veritabanında VARCHAR(64) veya daha uzun olduğundan emin olun!
                string sorgu = @"INSERT INTO tblKullanicilar 
                         (AdSoyad, KullaniciAdi, SifreHash, RolID, AktifMi) 
                         VALUES (@pAdSoyad, @pKullaniciAdi, @pSifreHash, @pRolID, @pAktifMi)";

                using (SqlConnection baglanti = new SqlConnection(baglantiDizesi)) {
                    using (SqlCommand komut = new SqlCommand(sorgu, baglanti)) {
                        // SQL Injection'ı önlemek için parametreleri kullan
                        komut.Parameters.AddWithValue("@pAdSoyad", adSoyad);
                        komut.Parameters.AddWithValue("@pKullaniciAdi", kullaniciAdi);
                        komut.Parameters.AddWithValue("@pSifreHash", sifreHash);
                        komut.Parameters.AddWithValue("@pRolID", rolID);
                        komut.Parameters.AddWithValue("@pAktifMi", aktifMi ? 1 : 0);

                        baglanti.Open();
                        komut.ExecuteNonQuery(); // Sorguyu çalıştır
                    }
                }

                MessageBox.Show("Kullanıcı başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ekrandaki DataGridView'i yenile
                KullanicilariListele();
                // Giriş alanlarını temizle
                AlanlariTemizle();

            } catch (Exception ex) {
                MessageBox.Show("Kayıt sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AlanlariTemizle() {
            txtAdSoyad.Clear();
            txtKullaniciAdi.Clear();
            txtSifre.Clear();
            cmbRolSecim.SelectedIndex = -1; // Seçimi sıfırla
            chkAktifMi.Checked = false; // CheckBox'ı sıfırla (veya true yapabilirsiniz)
            txtAdSoyad.Focus();
        }

        private void dgvKullaniciListesi_CellClick(object sender, DataGridViewCellEventArgs e) {
            // Başlık satırına tıklamayı veya geçersiz bir satıra tıklamayı kontrol et
            if (e.RowIndex >= 0) {
                // Seçilen satırdaki tüm verileri al
                DataGridViewRow secilenSatir = dgvKullaniciListesi.Rows[e.RowIndex];

                // KRİTİK: Güncelleme yapabilmek için seçilen KullaniciID'sini
                // form düzeyinde bir değişkende saklamalıyız.
                // Formun üst kısmına bu değişkeni tanımlayın (bkz. B Maddesi):
                aktifKullaniciID = Convert.ToInt32(secilenSatir.Cells["KullaniciID"].Value);

                // Verileri soldaki kontrollere doldur:
                txtAdSoyad.Text = secilenSatir.Cells["AdSoyad"].Value.ToString();
                txtKullaniciAdi.Text = secilenSatir.Cells["KullaniciAdi"].Value.ToString();

                // Şifre hash'ini geri alamayız, bu yüzden şifre alanını boş bırakmak en iyisidir.
                // Kullanıcı güncelleme yaparken sadece yeni şifre girmeyi seçebilir.
                txtSifre.Clear();

                // ComboBox'ı RolID'ye göre seç
                cmbRolSecim.SelectedValue = Convert.ToInt32(secilenSatir.Cells["RolID"].Value);

                // CheckBox'ı AktifMi değerine göre ayarla
                // AktifMi veritabanında BIT (boolean) olarak tutulduğu varsayılıyor
                chkAktifMi.Checked = Convert.ToBoolean(secilenSatir.Cells["AktifMi"].Value);
            }
        }

        private void btnHesapGuncelle_Click(object sender, EventArgs e) {
            // Güncellenecek bir kullanıcı seçilmiş mi?
            if (aktifKullaniciID == 0) {
                MessageBox.Show("Lütfen önce listeden bir kullanıcı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Zorunlu alan kontrolü (Şifre hariç)
            if (string.IsNullOrEmpty(txtAdSoyad.Text) ||
                string.IsNullOrEmpty(txtKullaniciAdi.Text) ||
                cmbRolSecim.SelectedValue == null) {
                MessageBox.Show("Ad Soyad, Kullanıcı Adı ve Rol alanları boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try {
                string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
                string sorgu = "";
                string sifreHash = "";

                // 1. Şifre Alanı Kontrolü: Kullanıcı şifreyi değiştirmek istiyor mu?
                if (!string.IsNullOrEmpty(txtSifre.Text)) {
                    // Yeni şifreyi hashle
                    sifreHash = GuvenlikYardimcisi.HashSifre(txtSifre.Text);

                    // Hem şifreyi hem de diğer alanları güncelleyen sorgu
                    sorgu = @"UPDATE tblKullanicilar SET 
                      AdSoyad = @pAdSoyad, KullaniciAdi = @pKullaniciAdi, SifreHash = @pSifreHash, 
                      RolID = @pRolID, AktifMi = @pAktifMi 
                      WHERE KullaniciID = @pID";
                } else {
                    // Şifreyi değiştirmeyen (mevcut hash'i koruyan) sorgu
                    sorgu = @"UPDATE tblKullanicilar SET 
                      AdSoyad = @pAdSoyad, KullaniciAdi = @pKullaniciAdi, 
                      RolID = @pRolID, AktifMi = @pAktifMi 
                      WHERE KullaniciID = @pID";
                }

                // 2. Kontrollerden verileri al
                bool aktifMi = chkAktifMi.Checked;

                using (SqlConnection baglanti = new SqlConnection(baglantiDizesi)) {
                    using (SqlCommand komut = new SqlCommand(sorgu, baglanti)) {
                        // Ortak Parametreler
                        komut.Parameters.AddWithValue("@pAdSoyad", txtAdSoyad.Text);
                        komut.Parameters.AddWithValue("@pKullaniciAdi", txtKullaniciAdi.Text);
                        komut.Parameters.AddWithValue("@pRolID", (int)cmbRolSecim.SelectedValue);
                        komut.Parameters.AddWithValue("@pAktifMi", aktifMi ? 1 : 0);
                        komut.Parameters.AddWithValue("@pID", aktifKullaniciID); // KRİTİK ID

                        // Şifre parametresi sadece şifre değiştiriliyorsa eklenir
                        if (!string.IsNullOrEmpty(txtSifre.Text)) {
                            komut.Parameters.AddWithValue("@pSifreHash", sifreHash);
                        }

                        baglanti.Open();
                        komut.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Kullanıcı bilgileri başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // DataGridView'i yenile ve alanları temizle/sıfırla
                KullanicilariListele();
                AlanlariTemizle();
                aktifKullaniciID = 0; // ID'yi sıfırla, böylece yanlışlıkla tekrar güncelleme yapılmaz.

            } catch (Exception ex) {
                MessageBox.Show("Güncelleme sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHesapSil_Click(object sender, EventArgs e) {
            // Silinecek bir kullanıcı seçilmiş mi kontrol et.
            if (aktifKullaniciID == 0) {
                MessageBox.Show("Lütfen silmek istediğiniz kullanıcıyı listeden seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kullanıcıdan onay alma
            DialogResult result = MessageBox.Show(
                // txtKullaniciAdi.Text kullanarak kullanıcı adı bilgisini mesajda gösterelim.
                "Seçilen kullanıcıyı (" + txtKullaniciAdi.Text + ") silmek istediğinizden emin misiniz? Bu işlem geri alınamaz.",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes) {
                try {
                    // Bağlantı dizesini App.config'den al
                    string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
                    string sorgu = "DELETE FROM tblKullanicilar WHERE KullaniciID = @pID";

                    using (SqlConnection baglanti = new SqlConnection(baglantiDizesi)) {
                        using (SqlCommand komut = new SqlCommand(sorgu, baglanti)) {
                            // Güvenli silme için parametre kullan
                            komut.Parameters.AddWithValue("@pID", aktifKullaniciID);

                            baglanti.Open();
                            komut.ExecuteNonQuery(); // Sorguyu çalıştır
                        }
                    }

                    MessageBox.Show("Kullanıcı başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // İşlem sonrası DataGridView'i yenile ve giriş alanlarını temizle
                    KullanicilariListele();
                    AlanlariTemizle();
                    aktifKullaniciID = 0; // ID'yi sıfırla

                } catch (Exception ex) {
                    MessageBox.Show("Silme işlemi sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }*/
    }
}
