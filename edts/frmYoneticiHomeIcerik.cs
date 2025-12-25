using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace edts
{
    public partial class frmYoneticiHomeIcerik : Form
    {
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

        public frmYoneticiHomeIcerik()
        {
            // BU SATIR ÇOK ÖNEMLİ: Tasarımı ve olayları yükler.
            InitializeComponent();

            // Olayı (Event) koda bağlıyoruz
            this.Load += new EventHandler(frmYoneticiHome_Load);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }



        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void GroupBoxKoseleriniYuvarla(GroupBox gb, int yariCap)
        {
            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddArc(0, 0, yariCap, yariCap, 180, 90);
                gp.AddArc(gb.Width - yariCap, 0, yariCap, yariCap, 270, 90);
                gp.AddArc(gb.Width - yariCap, gb.Height - yariCap, yariCap, yariCap, 0, 90);
                gp.AddArc(0, gb.Height - yariCap, yariCap, yariCap, 90, 90);
                gp.CloseAllFigures();

                gb.Region = new Region(gp);
            }
        }

       

        private void KullaniciIstatistikleriniGetir()
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            {
                // 1. Aktif Kullanıcı Sorgusu (AktifMi = 1)
                string aktifSorgu = "SELECT COUNT(*) FROM tblKullanicilar WHERE AktifMi = 1";
                // 2. Pasif Kullanıcı Sorgusu (AktifMi = 0)
                string pasifSorgu = "SELECT COUNT(*) FROM tblKullanicilar WHERE AktifMi = 0";

                baglanti.Open();

                // Aktifleri çek ve yaz
                SqlCommand cmdAktif = new SqlCommand(aktifSorgu, baglanti);
                lblAktifUser.Text = cmdAktif.ExecuteScalar().ToString();

                // Pasifleri çek ve yaz
                SqlCommand cmdPasif = new SqlCommand(pasifSorgu, baglanti);
                lblPasifUser.Text = cmdPasif.ExecuteScalar().ToString();
            }
        }
      
        public static void EnCokSatanlarDonutDoldur(Chart chart, string baglantiDizesi)
        {
            chart.Series[0].Points.Clear();
            chart.Series[0].ChartType = SeriesChartType.Doughnut; // Donut tipi
            chart.Series[0]["DoughnutRadius"] = "50"; // İç delik büyüklüğü

            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            {
                string sorgu = @"SELECT TOP 3 u.UrunAd, SUM(sd.Miktar) as Toplam 
                         FROM tblSatisDetay sd 
                         JOIN tblUrunler u ON sd.UrunID = u.UrunID 
                         GROUP BY u.UrunAd ORDER BY Toplam DESC";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                try
                {
                    baglanti.Open();
                    SqlDataReader dr = komut.ExecuteReader();
                    bool veriVarmi = false;

                    while (dr.Read())
                    {
                        chart.Series[0].Points.AddXY(dr["UrunAd"].ToString(), dr["Toplam"]);
                        veriVarmi = true;
                    }

                    // EĞER VERİ YOKSA: Tasarımı görmek için geçici örnek veri ekleyelim
                    if (!veriVarmi)
                    {
                        chart.Series[0].Points.AddXY("Satış Bekleniyor", 1);
                        chart.Series[0].Points[0].Color = Color.LightGray; // Gri göster
                    }
                }
                catch { /* Hata yönetimi */ }
            }
        }

        private void KullaniciBilgisiYaz(Label lblAktif, Label lblPasif)
        {
            using (SqlConnection bag = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    bag.Open();
                    // Aktif kullanıcıları say (AktifMi = 1)
                    int aktif = (int)new SqlCommand("SELECT COUNT(*) FROM tblKullanicilar WHERE AktifMi=1", bag).ExecuteScalar();

                    // Pasif kullanıcıları say (AktifMi = 0)
                    int pasif = (int)new SqlCommand("SELECT COUNT(*) FROM tblKullanicilar WHERE AktifMi=0", bag).ExecuteScalar();

                    // Verileri senin tasarımındaki ilgili label'lara yaz
                    lblAktif.Text = aktif.ToString();
                    lblPasif.Text = pasif.ToString();
                }
                catch
                {
                    lblAktif.Text = "0";
                    lblPasif.Text = "0";
                }
            }
        }

     
       
        // Bunlar da yardımcı fonksiyonların:
        private GroupBox KutuOlustur(string baslik, int x, int y, int w, int h)
        {
            GroupBox gb = new GroupBox { Text = baslik, Location = new Point(x, y), Size = new Size(w, h), Font = new Font("Segoe UI", 10, FontStyle.Bold), BackColor = Color.White };
            this.Controls.Add(gb);
            return gb;
        }

   
        // Grafiği senin tasarımındaki GroupBox'ın içine çizen yardımcı metot
     
     
       
      

        

        private void VeriyiGetirVeYaz(Label hedefLabel, string sqlSorgusu)
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(sqlSorgusu, baglanti);
                    object sonuc = komut.ExecuteScalar();

                    // Eğer veritabanı boşsa 0 yaz, doluysa para formatında yaz
                    decimal miktar = (sonuc != null && sonuc != DBNull.Value) ? Convert.ToDecimal(sonuc) : 0;
                    hedefLabel.Text = miktar.ToString("C2"); // Örn: 1.250,00 ₺
                }
                catch (Exception)
                {
                    hedefLabel.Text = "0,00 ₺";
                }
            }
        }

        private void KullaniciSayilariniGuncelle(Label lblAktif, Label lblPasif, Label lblToplam)
        {
            using (SqlConnection bag = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    bag.Open();
                    // 3 farklı sayıyı da sırayla çekiyoruz
                    int aktif = (int)new SqlCommand("SELECT COUNT(*) FROM tblKullanicilar WHERE AktifMi=1", bag).ExecuteScalar();
                    int pasif = (int)new SqlCommand("SELECT COUNT(*) FROM tblKullanicilar WHERE AktifMi=0", bag).ExecuteScalar();
                    int toplam = aktif + pasif;

                    lblAktif.Text = aktif.ToString();
                    lblPasif.Text = pasif.ToString();
                    lblToplam.Text = toplam.ToString();
                }
                catch { /* Hata olursa 0 kalsın */ }
            }
        }

        private void EnleriVeEnazlariGetir(Label lblEnCok, Label lblEnAz)
        {
            using (SqlConnection bag = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    bag.Open();

                    // En çok satan ürünün adını getir
                    string enCokSorgu = "SELECT TOP 1 u.UrunAd FROM tblSatisDetay sd JOIN tblUrunler u ON sd.UrunID = u.UrunID GROUP BY u.UrunAd ORDER BY SUM(sd.Miktar) DESC";
                    object enCok = new SqlCommand(enCokSorgu, bag).ExecuteScalar();
                    lblEnCok.Text = enCok != null ? enCok.ToString() : "Veri Yok";

                    // En az satan ürünün adını getir
                    string enAzSorgu = "SELECT TOP 1 u.UrunAd FROM tblSatisDetay sd JOIN tblUrunler u ON sd.UrunID = u.UrunID GROUP BY u.UrunAd ORDER BY SUM(sd.Miktar) ASC";
                    object enAz = new SqlCommand(enAzSorgu, bag).ExecuteScalar();
                    lblEnAz.Text = enAz != null ? enAz.ToString() : "Veri Yok";
                }
                catch
                {
                    lblEnCok.Text = "Hata!";
                    lblEnAz.Text = "Hata!";
                }
            }
        }

        // Başına System.Windows.Forms ekleyerek "bu formdaki nesnedir" diyoruz
        private void KarZararCubugunuGuncelle(System.Windows.Forms.ProgressBar pb, Label lblTutar)
        {
            using (SqlConnection bag = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    bag.Open();
                    string sorgu = "SELECT ISNULL(SUM(ToplamTutar), 0) FROM tblSatislar";
                    SqlCommand komut = new SqlCommand(sorgu, bag);

                    // Decimal dönüşümünü garantiye alalım
                    object sonuc = komut.ExecuteScalar();
                    decimal toplamSatis = (sonuc != null && sonuc != DBNull.Value) ? Convert.ToDecimal(sonuc) : 0;

                    decimal hedef = 50000; // Aylık hedefin

                    // Yüzde hesaplama
                    int yuzde = 0;
                    if (toplamSatis > 0)
                    {
                        yuzde = (int)((toplamSatis / hedef) * 100);
                    }

                    // Değeri ata (100'ü aşmasın)
                    pb.Value = yuzde > 100 ? 100 : yuzde;
                    lblTutar.Text = "Toplam Kâr: " + toplamSatis.ToString("C2");
                }
                catch (Exception ex)
                {
                    pb.Value = 0;
                    // Debug için: MessageBox.Show(ex.Message);
                }
            }
        }

        private void YuksekKarGetirenUrunuGetir(Label lblYuksekKar)
        {
            using (SqlConnection bag = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    bag.Open();
                    // En yüksek fiyatlı (kar getirme potansiyeli en yüksek) ürünü getirir
                    string sorgu = "SELECT TOP 1 UrunAd FROM tblUrunler ORDER BY SatisFiyat DESC";
                    object urun = new SqlCommand(sorgu, bag).ExecuteScalar();

                    lblYuksekKar.Text = urun != null ? urun.ToString() : "Ürün Bulunamadı";
                }
                catch { lblYuksekKar.Text = "Hata!"; }
            }
        }
        private void frmYoneticiHome_Load(object sender, EventArgs e)
        {
            // 1. Günlük Satış
            VeriyiGetirVeYaz(lblSatisGun, "SELECT SUM(ToplamTutar) FROM tblSatislar WHERE CAST(SatisTarihi AS DATE) = CAST(GETDATE() AS DATE)");

            // 2. Haftalık Satış
            VeriyiGetirVeYaz(lblSatisHafta, "SELECT SUM(ToplamTutar) FROM tblSatislar WHERE SatisTarihi >= DATEADD(day, -7, GETDATE())");

            // 3. Aylık Satış
            VeriyiGetirVeYaz(lblSatisAy, "SELECT SUM(ToplamTutar) FROM tblSatislar WHERE MONTH(SatisTarihi) = MONTH(GETDATE()) AND YEAR(SatisTarihi) = YEAR(GETDATE())");

            // 4. Yıllık Satış
            VeriyiGetirVeYaz(lblSatisYil, "SELECT SUM(ToplamTutar) FROM tblSatislar WHERE YEAR(SatisTarihi) = YEAR(GETDATE())");

            // Tasarımındaki Label isimlerine göre burayı güncelle:
            KullaniciSayilariniGuncelle(lblAktifUser, lblPasifUser, lblToplamUser);
            // İsimleri kendi tasarımındakilerle eşleştir:
            EnleriVeEnazlariGetir(lblEnCok, lblEnAz);
            KarZararCubugunuGuncelle(pbKarZarar, lblToplamKarZararText);
            YuksekKarGetirenUrunuGetir(lblYuksekKar);
        }
        

        private void basitGrafik1_Click(object sender, EventArgs e)
        {

        }

    }
}



