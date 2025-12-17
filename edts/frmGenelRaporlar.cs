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

namespace edts
{
    public partial class frmGenelRaporlar : Form {
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

        public frmGenelRaporlar() {
            InitializeComponent();
        }

        private void btnRaporuGetir_Click(object sender, EventArgs e) {
            //HareketleriListele(dtpBaslangic.Value, dtpBitis.Value);
            StokHareketleriniListele(dtpBaslangic.Value, dtpBitis.Value);
            StokDurumuHesapla(dtpBaslangic.Value, dtpBitis.Value);

            String toplamTutar = TarihAraligiToplamTutarGetir(dtpBaslangic.Value, dtpBitis.Value);

            label6.Text = "Toplam Değeri : " + toplamTutar;
        }

        public void StokHareketleriniListele(DateTime baslangicTarihi, DateTime bitisTarihi) {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    baglan.Open();

                    // 1. ADIM: 3 Tabloyu Birleştiren SQL Sorgusu
                    // sh: StokHareketleri (Ana Tablo)
                    // u:  Urunler
                    // ht: HareketTipleri
                    // k:  Kullanicilar
                    string sorgu = @"
                SELECT 
                    sh.IslemID,
                    sh.FaturaNo,
                    u.UrunAd,
                    sh.HareketID,
                    k.KullaniciAdi,
                    sh.Miktar,
                    sh.Tarih
                FROM tblStokHareketleri sh
                INNER JOIN tblUrunler u ON sh.UrunID = u.UrunID
                INNER JOIN tblKullanicilar k ON sh.KullaniciID = k.KullaniciID
                WHERE sh.Tarih BETWEEN @Tarih1 AND @Tarih2
                ORDER BY sh.Tarih DESC"; // En son yapılan işlem en üstte

                    SqlDataAdapter da = new SqlDataAdapter(sorgu, baglan);

                    // 2. ADIM: Tarih Parametreleri (Saat Detayı)
                    // Başlangıç: Seçilen günün 00:00:00 anı
                    da.SelectCommand.Parameters.AddWithValue("@Tarih1", baslangicTarihi.Date);

                    // Bitiş: Seçilen günün 23:59:59 anı (Günün sonuna kadar olanları al)
                    da.SelectCommand.Parameters.AddWithValue("@Tarih2", bitisTarihi.Date.AddDays(1).AddSeconds(-1));

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dt.Columns.Add("IslemAdi", typeof(string));

                    foreach (DataRow row in dt.Rows) {
                        if (row["HareketID"] != DBNull.Value) {
                            int id = Convert.ToInt32(row["HareketID"]);
                            string tmp = Sabitler.IslemAl(id);
                            char ico = (id == (int)Sabitler.IslemTuru.Alim) ? '➕' : (id == (int)Sabitler.IslemTuru.Satım) ? '➖' : 'ℹ';
                            row["IslemAdi"] = ico + Sabitler.IslemAl(id);
                        }
                    }

                    dataGridView1.DataSource = dt;

                    // 3. ADIM: Sütun İsimlendirme ve Gizleme (Kozmetik)

                    // ID'yi gizle (Arka planda silme/güncelleme için lazım)
                    if (dataGridView1.Columns["IslemID"] != null)
                        dataGridView1.Columns["IslemID"].Visible = false;
                    dataGridView1.Columns["HareketID"].Visible = false;

                    // Başlıkları Türkçeleştir
                    dataGridView1.Columns["UrunAd"].HeaderText = "Ürün Adı";
                    //dataGridView1.Columns["HareketAd"].HeaderText = "İşlem Tipi";
                    dataGridView1.Columns["IslemAdi"].HeaderText = "İşlem Tipi";
                    dataGridView1.Columns["IslemAdi"].DisplayIndex = 1;
                    dataGridView1.Columns["KullaniciAdi"].HeaderText = "İşlemi Yapan";
                    dataGridView1.Columns["Miktar"].HeaderText = "Adet";
                    dataGridView1.Columns["Tarih"].HeaderText = "İşlem Tarihi";
                    dataGridView1.Columns["FaturaNo"].HeaderText = "Fatura No";

                    // Sütunları ekrana yay
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Tarih formatını güzelleştir (Gün.Ay.Yıl Saat:Dakika)
                    dataGridView1.Columns["Tarih"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
                } catch (Exception ex) {
                    MessageBox.Show("Veri çekme hatası: " + ex.Message);
                }
            }
        }
        public String TarihAraligiToplamTutarGetir(DateTime baslangic, DateTime bitis) {
            String fnl = "";
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    baglan.Open();

                    // SUM fonksiyonu ile tüm çarpımları topluyoruz
                    string sorgu = @"
                SELECT SUM(h.Miktar * ISNULL(u.BirimFiyat, 0)) 
                FROM tblStokHareketleri h
                INNER JOIN tblUrunler u ON h.UrunID = u.UrunID
                WHERE h.Tarih BETWEEN @tarih1 AND @tarih2";

                    SqlCommand cmd = new SqlCommand(sorgu, baglan);

                    cmd.Parameters.AddWithValue("@tarih1", baslangic.Date);
                    cmd.Parameters.AddWithValue("@tarih2", bitis.Date.AddDays(1).AddSeconds(-1));

                    object sonuc = cmd.ExecuteScalar();

                    if (sonuc != DBNull.Value && sonuc != null) {
                        decimal toplam = Convert.ToDecimal(sonuc);
                        fnl = toplam.ToString("C2");
                    } else {
                        fnl = "₺0,00";
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Hesaplama hatası(Tutar): " + ex.Message);
                }
            }
            return fnl;
        }

        public void StokDurumuHesapla(DateTime baslangic, DateTime bitis) {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    baglan.Open();

                    string sorgu = @"
                SELECT 
                    ISNULL(SUM(CASE WHEN HareketID = 4 THEN Miktar ELSE 0 END), 0) AS ToplamGiris,
                    ISNULL(SUM(CASE WHEN HareketID = 2 THEN Miktar ELSE 0 END), 0) AS ToplamCikis,
                    ISNULL(SUM(CASE WHEN HareketID = 4 THEN Miktar ELSE 0 END) - 
                           SUM(CASE WHEN HareketID = 2 THEN Miktar ELSE 0 END), 0) AS ToplamFark
                FROM tblStokHareketleri
                WHERE Tarih BETWEEN @Baslangic AND @Bitis";

                    SqlCommand cmd = new SqlCommand(sorgu, baglan);

                    // Tarih Saat Ayarı (Günün tamamını kapsasın diye)
                    cmd.Parameters.AddWithValue("@Baslangic", baslangic.Date);
                    cmd.Parameters.AddWithValue("@Bitis", bitis.Date.AddDays(1).AddSeconds(-1));

                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        if (dr.Read()) {
                            // Değerleri alıyoruz
                            int giren = Convert.ToInt32(dr["ToplamGiris"]);
                            int cikan = Convert.ToInt32(dr["ToplamCikis"]);
                            int fark = Convert.ToInt32(dr["ToplamFark"]);

                            // Labellara yazdırıyoruz
                            label3.Text = "Toplam Giriş Miktarı : " + giren.ToString();
                            label4.Text = "Toplam Çıkış Miktarı : " + cikan.ToString() ;
                            label5.Text = "Net Stok Farkı : " + fark.ToString() ;

                        }
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Hesaplama Hatası(Durum): " + ex.Message);
                }
            }
        }
        public void HareketleriListele(DateTime baslangicTarihi, DateTime bitisTarihi) {

            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    baglan.Open();

                    // Sadece istenen sütunları SELECT kısmına yazdık (Aciklama YOK)
                    string sorgu = @"
                SELECT 
                    IslemID, 
                    UrunID, 
                    HareketID, 
                    KullaniciID, 
                    Miktar, 
                    Tarih 
                FROM tblStokHareketleri 
                WHERE Tarih BETWEEN @tarih1 AND @tarih2
                ORDER BY Tarih DESC"; // En yeniden eskiye sırala

                    SqlDataAdapter da = new SqlDataAdapter(sorgu, baglan);

                    da.SelectCommand.Parameters.AddWithValue("@tarih1", baslangicTarihi.Date);
                    
                    DateTime bitisAyari = bitisTarihi.Date.AddDays(1).AddSeconds(-1);
                    da.SelectCommand.Parameters.AddWithValue("@tarih2", bitisAyari);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;

                    // --- KOZMETİK AYARLAR ---

                    if (dataGridView1.Columns["IslemID"] != null)
                        dataGridView1.Columns["IslemID"].Visible = false;

                    dataGridView1.Columns["UrunID"].HeaderText = "Ürün No";
                    dataGridView1.Columns["HareketID"].HeaderText = "Hareket Tipi";
                    dataGridView1.Columns["KullaniciID"].HeaderText = "Kullanıcı";
                    dataGridView1.Columns["Miktar"].HeaderText = "Adet/Miktar";
                    dataGridView1.Columns["Tarih"].HeaderText = "İşlem Tarihi";

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                } catch (Exception ex) {
                    MessageBox.Show("Listeleme hatası: " + ex.Message);
                }
            }
        }
    }

}
