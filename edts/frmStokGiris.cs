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
    public partial class frmStokGiris : Form
    {
        // Geçici stok detaylarını tutacak DataTable
        private DataTable stokDetaylari = new DataTable();

        // **BURAYA EKLEYİN** (Sınıf düzeyinde tanımlama)

        public frmStokGiris()
        {
            InitializeComponent();
            VeriYukle();
            DetayTablosunuOlustur();
        }
        private void DetayTablosunuOlustur()
        {
            // *** 1. ÖNCE SIFIRLA VE YENİ DATATABLE OLUŞTUR ***
            stokDetaylari = new DataTable();

            // *** 2. ZORUNLU SÜTUNLARI EKLE (Veritabanına gidecek olanlar) ***
            stokDetaylari.Columns.Add("UrunID", typeof(int));
            stokDetaylari.Columns.Add("UrunAd", typeof(string)); // Görüntüleme amaçlı
            stokDetaylari.Columns.Add("Miktar", typeof(decimal));

            // Stok Hareketleri tablosunda kaydetmeniz gereken diğer ID'ler
            // Örneğin: stokDetaylari.Columns.Add("BirimFiyat", typeof(decimal));

            // *** 3. DataGrid'de göstermek istediğimiz ve btnEkle'den gelen değerleri ekle ***
            stokDetaylari.Columns.Add("TedarikciAdi", typeof(string));
            stokDetaylari.Columns.Add("FaturaNo", typeof(string));
            stokDetaylari.Columns.Add("GirisNedeni", typeof(string));

            // ŞU ANDA DATATABLE'INIZDA TOPLAM 6 SÜTUN VAR.

            // *** 4. DataGridView'e DataTable'ı bağla (BU ÇOK ÖNEMLİ) ***
            dgvStokDetaylari.DataSource = stokDetaylari;

            // *** 5. DataSource kullanıldığı için manuel sütun ekleme YAPMA! ***
            // DataSource kullanıldığında, DataGrid sütunları DataTable'dan otomatik oluşturulur.
            // Sadece özelleştirme (gizleme, başlık değiştirme) yapılır.

            // Kullanıcıya göstermek istemediğimiz ID sütununu gizleyelim
            dgvStokDetaylari.Columns["UrunID"].Visible = false;

            // Not: Artık dgvStokDetaylari.Columns.Add("TedarikciAdi", "Tedarikçi"); satırlarına gerek yok!
        }
        // ComboBox'ları doldurmak için temel metot
        private void VeriYukle()
        {
            string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglanti.Open();

                    // ------------------------------------------------------------------
                    // A. TEDARİKÇİ YÜKLEME (cmbTedarikci)
                    // SORGULAR DÜZELTİLDİ: Artık TedarikciAd kullanılıyor ve AktifMi kaldırıldı.
                    // ------------------------------------------------------------------
                    string tedarikciSorgu = "SELECT TedarikciID, TedarikciAd FROM tblTedarikciler";
                    DataTable dtTedarikci = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(tedarikciSorgu, baglanti))
                    {
                        da.Fill(dtTedarikci);
                    }

                    cmbTedarikci.DataSource = dtTedarikci;
                    cmbTedarikci.DisplayMember = "TedarikciAd"; // <-- DÜZELTİLDİ
                    cmbTedarikci.ValueMember = "TedarikciID";
                    cmbTedarikci.SelectedIndex = -1;

                    // ------------------------------------------------------------------
                    // B. ÜRÜN YÜKLEME (cmbUrunSecimi)
                    // AktifMi sütununuz olmadığı için kontrol kaldırıldı.
                    // ------------------------------------------------------------------
                    string urunSorgu = "SELECT UrunID, UrunAd FROM tblUrunler";
                    DataTable dtUrun = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(urunSorgu, baglanti))
                    {
                        da.Fill(dtUrun);
                    }

                    cmbUrunSecimi.DataSource = dtUrun;
                    cmbUrunSecimi.DisplayMember = "UrunAd";
                    cmbUrunSecimi.ValueMember = "UrunID";
                    cmbUrunSecimi.SelectedIndex = -1;

                    // ------------------------------------------------------------------
                    // C. GİRİŞ NEDENİ YÜKLEME
                    // ------------------------------------------------------------------
                    if (cmbGirisNedeni.Items.Count == 0)
                    {
                        cmbGirisNedeni.Items.Add("Satın Alma (Normal Giriş)");
                        cmbGirisNedeni.Items.Add("Müşteri İadesi");
                        cmbGirisNedeni.Items.Add("Sayım Fazlası");
                        cmbGirisNedeni.Items.Add("Transfer Girişi");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Tedarikçi ComboBox'ını Doldurma Metodu
        private void TedarikcileriYukle()
        {
            string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            {
                string sorgu = "SELECT TedarikciID, Ad FROM tblTedarikciler WHERE AktifMi = 1";

                // Bu sorgunun TedarikciID ve Ad sütunlarını içerdiğinden emin olun!

                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbTedarikci.DataSource = dt;
                    // !!! BURAYA DİKKAT !!! 
                    cmbTedarikci.DisplayMember = "Ad";        // DB'deki sütun adı
                    cmbTedarikci.ValueMember = "TedarikciID"; // DB'deki sütun adı

                    cmbTedarikci.SelectedIndex = -1; // Seçim yapılmadan boş başlat
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tedarikçi yüklenirken hata oluştu: " + ex.Message);
                }
            }
        }

        // Ürün ComboBox'ını Doldurma Metodu (Barkod yerine buradan seçim yapılacak)
        private void UrunleriYukle()
        {
            string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
            // UrunKodu ve UrunAd'ı birleştirerek ComboBox'ta daha anlaşılır bir gösterim sağlayalım
            string sorgu = "SELECT UrunID, UrunKodu + ' - ' + UrunAd AS UrunTamAd FROM tblUrunler ORDER BY UrunTamAd";

            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            {
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbUrunSecimi.DisplayMember = "UrunTamAd";
                cmbUrunSecimi.ValueMember = "UrunID";
                cmbUrunSecimi.DataSource = dt;
                cmbUrunSecimi.SelectedIndex = -1;
            }
        }

        private void frmStokGiris_Load(object sender, EventArgs e)
        {


        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (cmbUrunSecimi.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir ürün seçimi yapınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtGirisMiktari.Text, out decimal miktar) || miktar <= 0)
            {
                MessageBox.Show("Geçerli bir giriş miktarı giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gerekli değerleri al
            int urunID = (int)cmbUrunSecimi.SelectedValue;
            string urunAd = cmbUrunSecimi.Text;
            string tedarikciAd = cmbTedarikci.Text;
            string faturaNo = txtFaturaNo.Text;
            string girisNedeni = cmbGirisNedeni.Text;

            // *** DEĞİŞİKLİK BURADA: TOPLAMA MANTIĞI KALDIRILDI! ***
            // Artık her zaman yeni bir satır ekliyoruz.
            stokDetaylari.Rows.Add(
                urunID,
                urunAd,
                miktar,
                tedarikciAd,
                faturaNo,
                girisNedeni
            );
            // *******************************************************

            // Giriş alanlarını temizle
            cmbUrunSecimi.SelectedIndex = -1;
            txtGirisMiktari.Clear();
        }

        private void btnGirisOnayla_Click(object sender, EventArgs e)
        {
            // 1. Gerekli Kontroller
            if (stokDetaylari.Rows.Count == 0)
            {
                MessageBox.Show("Listeye eklenecek ürün detayı bulunmamaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbTedarikci.SelectedValue == null)
            {
                MessageBox.Show("Lütfen Tedarikçi seçimi yapınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Varsayım: txtFaturaNo, cmbGirisNedeni ve cmbDepo isimlerini kullandınız.
            // Varsayım: Oturum açan kullanıcının ID'si 'aktifKullaniciID' sınıf değişkeninde tutuluyor.
            // Eğer Depo seçimi combobox'ta yoksa, Ana Depo ID'sini (1) varsayın.

            int hareketID_GIRIS = 1; // 💡 Lütfen veritabanınızdaki Stok Giriş HareketID'sini buraya yazın!
            int tedarikciID = (int)cmbTedarikci.SelectedValue;
            string faturaNo = txtFaturaNo.Text.Trim();
            string girisNedeni = cmbGirisNedeni.Text; // ComboBox text'i olarak alalım

            // Eğer Depo ComboBox'ı varsa
            // int depoID = (cmbDepo.SelectedValue != null) ? (int)cmbDepo.SelectedValue : 1; 
            // Eğer Depo seçimi formu yoksa, varsayılan DepoID 1'i kullanalım
            int depoID = 1;

            string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            {
                baglanti.Open();
                SqlTransaction transaction = baglanti.BeginTransaction(); // İŞLEM BAŞLAT!

                try
                {
                    // Liste içindeki her bir satır için işlem yap
                    foreach (DataRow row in stokDetaylari.Rows)
                    {
                        int urunID = (int)row["UrunID"];
                        decimal miktar = (decimal)row["Miktar"];
                        string aciklama = $"Giriş Nedeni: {girisNedeni}";

                        // 1. STOK HAREKETİ KAYDI ATMA
                        string stokHareketSorgu = @"
                    INSERT INTO tblStokHareketleri 
                    (UrunID, HareketID, KullaniciID, Miktar, Tarih, Aciklama, DepoID, TedarikciID, FaturaNo)
                    VALUES (@UrunID, @HareketID, @KullaniciID, @Miktar, @Tarih, @Aciklama, @DepoID, @TedarikciID, @FaturaNo)";

                        using (SqlCommand komutHareket = new SqlCommand(stokHareketSorgu, baglanti, transaction))
                        {
                            // Varsayılan KullaniciID'ninizi buraya ekleyin
                            komutHareket.Parameters.AddWithValue("@UrunID", urunID);
                            komutHareket.Parameters.AddWithValue("@HareketID", hareketID_GIRIS);
                            komutHareket.Parameters.AddWithValue("@KullaniciID", AktifKullanici.ID); // Buraya oturan kullanıcı ID'sini ekleyin
                            komutHareket.Parameters.AddWithValue("@Miktar", miktar);
                            komutHareket.Parameters.AddWithValue("@Tarih", DateTime.Now);
                            komutHareket.Parameters.AddWithValue("@Aciklama", aciklama);
                            komutHareket.Parameters.AddWithValue("@DepoID", depoID);
                            komutHareket.Parameters.AddWithValue("@TedarikciID", tedarikciID);
                            komutHareket.Parameters.AddWithValue("@FaturaNo", faturaNo);
                            komutHareket.ExecuteNonQuery();
                        }

                        // 2. ÜRÜN STOĞUNU GÜNCELLEME (MevcutStok artırılıyor)
                        string stokGuncelleSorgu = "UPDATE tblUrunler SET MevcutStok = MevcutStok + @Miktar WHERE UrunID = @UrunID";

                        using (SqlCommand komutGuncelle = new SqlCommand(stokGuncelleSorgu, baglanti, transaction))
                        {
                            komutGuncelle.Parameters.AddWithValue("@Miktar", miktar);
                            komutGuncelle.Parameters.AddWithValue("@UrunID", urunID);
                            komutGuncelle.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit(); // HER ŞEY BAŞARILIYSA KAYITLARI ONAYLA
                    MessageBox.Show("Stok girişi başarıyla tamamlandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Formu temizle ve resetle
                    FormuTemizle();
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // BİR HATA OLDUYSA İŞLEMLERİ GERİ AL
                    MessageBox.Show("Stok girişi sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Kayıt sonrası formu temizleyecek metot (Temizle butonu için de kullanılabilir)
        private void FormuTemizle()
        {
            stokDetaylari.Clear(); // DataGridView'i temizle
            cmbTedarikci.SelectedIndex = -1;
            cmbGirisNedeni.SelectedIndex = -1;
            txtFaturaNo.Clear();
            txtGirisMiktari.Clear();
            cmbUrunSecimi.SelectedIndex = -1;
            // Eğer varsa, dgvStokDetaylari'yi de yenileyin.
        }

        private void txtGirisMiktari_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            // Datagrid'de seçili satır olup olmadığını kontrol et
            if (dgvStokDetaylari.SelectedRows.Count > 0)
            {
                // Seçili satırı DataGrid'den kaldır
                dgvStokDetaylari.Rows.RemoveAt(dgvStokDetaylari.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Lütfen silinecek bir satır seçin.", "Uyarı");
            }
        }
    }

}
