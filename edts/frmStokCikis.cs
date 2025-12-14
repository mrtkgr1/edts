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

namespace EnvanterDepoSistemitaslak2
{

    public partial class frmStokCikis : Form
    {
        public frmStokCikis()
        {
            InitializeComponent();
            // 1. Detay tablosunu oluştur ve DGV'ye bağla
            DetayTablosunuOlustur();

            // 2. ComboBox'ları verilerle doldur
            VerileriDoldur(); // <-- BURAYA EKLENMELİ
        }
        public DataTable cikisDetaylari = new DataTable(); // Sınıf düzeyinde tanımlandığından emin olun

        private void DetayTablosunuOlustur()
        {
            // DataTable'ı her zaman sıfırlamak iyi bir uygulamadır, ancak Constructor içinde olduğu için şimdilik gerek yok.
            cikisDetaylari = new DataTable();

            // 6 SÜTUN TEK SEFER TANIMLANIYOR
            cikisDetaylari.Columns.Add("UrunID", typeof(int));
            cikisDetaylari.Columns.Add("UrunAd", typeof(string));
            cikisDetaylari.Columns.Add("Miktar", typeof(decimal));
            cikisDetaylari.Columns.Add("MusteriAd", typeof(string));
            cikisDetaylari.Columns.Add("SiparisNo", typeof(string));
            cikisDetaylari.Columns.Add("CikisNedeni", typeof(string));

            dgvSevkiyatListesi.DataSource = cikisDetaylari;
            dgvSevkiyatListesi.Columns["UrunID"].Visible = false;

            // NOT: Artık DataGridView'de manuel sütun ekleme yok.
        }

        private void btnListeyeEkle_Click(object sender, EventArgs e)
        {
            // 1. ZORUNLU KONTROLLER
            if (cmbUrun.SelectedValue == null)
            {
                MessageBox.Show("Lütfen çıkışı yapılacak ürünü seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtAdet.Text, out decimal cikisMiktar) || cikisMiktar <= 0)
            {
                MessageBox.Show("Geçerli bir çıkış miktarı (Adet) giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbMusteri.SelectedValue == null)
            {
                MessageBox.Show("Lütfen çıkışın yapılacağı Müşteriyi seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. VERİ ÇEKME VE TANIMLAMA

            // Gerekli ID'ler
            int urunID = (int)cmbUrun.SelectedValue;
            // int musteriID = (int)cmbMusteri.SelectedValue; // DataTable'a ID yerine AD ekliyoruz

            // Gerekli metinsel değerler
            string urunAd = cmbUrun.Text;
            string musteriAd = cmbMusteri.Text;

            // Hata veren değişkenler şimdi tanımlanıyor
            string siparisNo = txtSiparisNo.Text;
            string cikisNedeni = cmbCikisNedeni.Text;

            // 3. KRİTİK STOK KONTROLÜ

            // StokMiktariCek metodunu kullanarak mevcut stoğu veritabanından çek.
            decimal mevcutStok = StokMiktariCek(urunID);

            if (cikisMiktar > mevcutStok)
            {
                MessageBox.Show(
                    $"Mevcut stok ({mevcutStok}) miktarından daha fazla çıkış yapamazsınız.",
                    "Yetersiz Stok",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // 4. DATATABLE'A EKLEME
            // Bu sıra, DetayTablosunuOlustur metodunuzdaki 6 sütun sırasıyla uyumlu olmalıdır!
            cikisDetaylari.Rows.Add(
                urunID,       // 1. UrunID (int)
                urunAd,       // 2. UrunAd (string)
                cikisMiktar,  // 3. Miktar (decimal)
                musteriAd,    // 4. MusteriAd (string)
                siparisNo,    // 5. SiparisNo (string)
                cikisNedeni   // 6. CikisNedeni (string)
            );

            // 5. GİRİŞ ALANLARINI TEMİZLE
            cmbUrun.SelectedIndex = -1;
            txtAdet.Clear();

            // Stok bilgisini sıfırla (eğer lblMevcutStok kullanılıyorsa)
            // lblMevcutStok.Text = "0";
        }
        // tblUrunler tablosundan MevcutStok miktarını çeken yardımcı metot
        // Bu metot, formun herhangi bir yerinden çağrılabilir olmalıdır (private).
        private decimal StokMiktariCek(int urunID)
        {
            // Hatanın çözümü için System.Configuration referansının ekli olduğundan emin olun.
            string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
            string sorgu = "SELECT MevcutStok FROM tblUrunler WHERE UrunID = @UrunID";
            decimal mevcutStok = 0;

            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            {
                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@UrunID", urunID);

                    try
                    {
                        baglanti.Open();
                        object sonuc = komut.ExecuteScalar(); // Tek bir değer çeker

                        if (sonuc != null && sonuc != DBNull.Value)
                        {
                            mevcutStok = Convert.ToDecimal(sonuc);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Stok kontrolü sırasında veritabanı hatası oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            // Seçilen ürünün mevcut stoğunu etikete (lblMevcutStok) de yansıtabiliriz
            // lblMevcutStok.Text = mevcutStok.ToString(); 
            return mevcutStok;
        }

        private void btnCikisiOnayla_Click(object sender, EventArgs e)
        {
            // 1. Gerekli Kontroller
            if (cikisDetaylari.Rows.Count == 0)
            {
                MessageBox.Show("Sevkiyat listesinde ürün detayı bulunmamaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbMusteri.SelectedValue == null)
            {
                MessageBox.Show("Lütfen Müşteri seçimi yapınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gerekli genel değerleri al
            int hareketID_CIKIS = 2; // 💡 Lütfen veritabanınızdaki Stok Çıkış HareketID'sini buraya yazın!
            int musteriID = (int)cmbMusteri.SelectedValue;
            string siparisNo = txtSiparisNo.Text.Trim();
            string cikisNedeni = cmbCikisNedeni.Text;

            // DepoID'yi varsayılan olarak 1 alalım (veya formdaki alandan çekelim)
            int depoID = 1;

            string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            {
                baglanti.Open();
                SqlTransaction transaction = baglanti.BeginTransaction(); // İŞLEM BAŞLAT!

                try
                {
                    // Liste içindeki her bir satır için işlem yap
                    foreach (DataRow row in cikisDetaylari.Rows)
                    {
                        int urunID = (int)row["UrunID"];
                        decimal miktar = (decimal)row["Miktar"];
                        string aciklama = $"Çıkış Nedeni: {cikisNedeni}";

                        // 1. INSERT Sorgusunu Güncelleme
                        string stokHareketSorgu = @"
INSERT INTO tblStokHareketleri 
(UrunID, HareketID, KullaniciID, Miktar, Tarih, Aciklama, DepoID, TedarikciID, FaturaNo) -- 💡 MusteriID yerine TedarikciID
VALUES (@UrunID, @HareketID, @KullaniciID, @Miktar, @Tarih, @Aciklama, @DepoID, @TedarikciID, @FaturaNo)";
                        // Parametre adını da @TedarikciID olarak değiştirdik.

                        using (SqlCommand komutHareket = new SqlCommand(stokHareketSorgu, baglanti, transaction))
                        {
                            komutHareket.Parameters.AddWithValue("@UrunID", urunID);
                            komutHareket.Parameters.AddWithValue("@HareketID", hareketID_CIKIS);
                            komutHareket.Parameters.AddWithValue("@KullaniciID", AktifKullanici.ID); // Oturan kullanıcı ID'sini ekleyin
                            komutHareket.Parameters.AddWithValue("@Miktar", miktar);
                            komutHareket.Parameters.AddWithValue("@Tarih", DateTime.Now);
                            komutHareket.Parameters.AddWithValue("@Aciklama", aciklama);
                            komutHareket.Parameters.AddWithValue("@DepoID", depoID);
                            // 💡 MusteriID yerine TedarikciID parametresini ekliyoruz
                            komutHareket.Parameters.AddWithValue("@TedarikciID", musteriID); // cmbMusteri'den gelen ID'yi kullanıyoruz
                            komutHareket.Parameters.AddWithValue("@FaturaNo", siparisNo);
                            komutHareket.ExecuteNonQuery();
                        }

                        // 2. ÜRÜN STOĞUNU GÜNCELLEME (MevcutStok AZALTILIYOR)
                        string stokGuncelleSorgu = "UPDATE tblUrunler SET MevcutStok = MevcutStok - @Miktar WHERE UrunID = @UrunID";

                        using (SqlCommand komutGuncelle = new SqlCommand(stokGuncelleSorgu, baglanti, transaction))
                        {
                            komutGuncelle.Parameters.AddWithValue("@Miktar", miktar);
                            komutGuncelle.Parameters.AddWithValue("@UrunID", urunID);
                            komutGuncelle.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit(); // HER ŞEY BAŞARILIYSA KAYITLARI ONAYLA
                    MessageBox.Show("Stok çıkışı başarıyla tamamlandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Formu temizle ve resetle
                    FormuTemizle(); // Stok Girişi'nde olduğu gibi bu metodu da ayarlamanız gerekecek
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // BİR HATA OLDUYSA İŞLEMLERİ GERİ AL
                    MessageBox.Show("Stok çıkışı sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void FormuTemizle()
        {
            // 1. DataGridView'i (Sevkiyat Listesi) temizle
            cikisDetaylari.Clear();

            // 2. Genel Sevkiyat Bilgilerini Temizle
            cmbMusteri.SelectedIndex = -1;
            cmbCikisNedeni.SelectedIndex = -1;
            txtSiparisNo.Clear();

            // 3. Ürün Ekleme Alanlarını Temizle
            cmbUrun.SelectedIndex = -1;
            txtAdet.Clear();

            // Stok bilgisini de sıfırla (eğer lblMevcutStok ismini kullanıyorsanız)
            // lblMevcutStok.Text = "0"; 
        }

        private void VerileriDoldur()
        {
            string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    // 1. ÜRÜN COMBOBOX'INI DOLDURMA
                    string urunSorgu = "SELECT UrunID, UrunAd FROM tblUrunler ORDER BY UrunAd";
                    DataTable dtUrun = new DataTable();
                    using (SqlDataAdapter daUrun = new SqlDataAdapter(urunSorgu, baglanti))
                    {
                        daUrun.Fill(dtUrun);
                    }
                    // Not: Stok Çıkış formunda Ürün ComboBox adının cmbUrun olduğunu varsayıyorum
                    cmbUrun.DataSource = dtUrun;
                    cmbUrun.DisplayMember = "UrunAd";
                    cmbUrun.ValueMember = "UrunID";
                    cmbUrun.SelectedIndex = -1;

                    // 2. MÜŞTERİ COMBOBOX'INI DOLDURMA
                    string musteriSorgu = "SELECT MusteriID, MusteriAd FROM tblMusteriler ORDER BY MusteriAd";
                    DataTable dtMusteri = new DataTable();
                    using (SqlDataAdapter daMusteri = new SqlDataAdapter(musteriSorgu, baglanti))
                    {
                        daMusteri.Fill(dtMusteri);
                    }
                    cmbMusteri.DataSource = dtMusteri;
                    cmbMusteri.DisplayMember = "MusteriAd";
                    cmbMusteri.ValueMember = "MusteriID";
                    cmbMusteri.SelectedIndex = -1;

                    // 3. ÇIKIŞ NEDENİ COMBOBOX'INI DOLDURMA (Sabit değerler)
                    if (cmbCikisNedeni.Items.Count == 0)
                    {
                        cmbCikisNedeni.Items.Add("Satış (Normal Çıkış)");
                        cmbCikisNedeni.Items.Add("Sarf/Tüketim");
                        cmbCikisNedeni.Items.Add("İade (Tedarikçiye)");
                        cmbCikisNedeni.Items.Add("Sayım Eksiği");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            // 1. DataGridView'de seçili satır kontrolü
            if (dgvSevkiyatListesi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz ürünü listeden seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kullanıcıdan onay alma
            DialogResult dialogResult = MessageBox.Show(
                "Seçili ürünü sevkiyat listesinden silmek istediğinizden emin misiniz?",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    // DataGridView'den seçili satırı al
                    int selectedIndex = dgvSevkiyatListesi.SelectedRows[0].Index;

                    // Eğer dgv, DataTable'a bağlıysa, satırı DataTable'dan silmeliyiz.
                    // Bu, DGV'den satırı otomatik olarak kaldıracaktır.
                    if (selectedIndex >= 0 && selectedIndex < cikisDetaylari.Rows.Count)
                    {
                        cikisDetaylari.Rows.RemoveAt(selectedIndex);
                    }

                    // Not: Silme işlemi sadece listeden yapılır, stoktan veya veritabanından değil.

                    MessageBox.Show("Ürün listeden başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Silme işlemi sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lblMevcutStok_Click(object sender, EventArgs e)
        {

        }

        private void cmbUrun_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Yalnızca geçerli bir ürün seçildiğinde ve bu seçimin bir ID değeri varsa çalışsın
            if (cmbUrun.SelectedValue != null && cmbUrun.SelectedValue is int)
            {
                try
                {
                    int urunID = (int)cmbUrun.SelectedValue;

                    // Mevcut stoğu veritabanından çeken metodu çağırıyoruz
                    decimal mevcutStok = StokMiktariCek(urunID);

                    // lblMevcutStok etiketini güncelliyoruz
                    lblMevcutStok.Text = mevcutStok.ToString("N2");
                }
                catch
                {
                    // Hata oluşursa stoğu sıfırla/hata mesajı göster
                    lblMevcutStok.Text = "Hata";
                }
            }
            else
            {
                // Hiçbir şey seçili değilse etiketi sıfırla
                lblMevcutStok.Text = "0,00";
            }
        }
    }
}
        
    
