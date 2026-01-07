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
           
            InitializeComponent();

           
            this.Load += new EventHandler(frmYoneticiHomeIcerik_Load);
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



        private void VeriyiGetirVeYaz(Label hedefLabel, string sqlSorgusu)
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(sqlSorgusu, baglanti);
                    object sonuc = komut.ExecuteScalar();

                   
                    decimal miktar = (sonuc != null && sonuc != DBNull.Value) ? Convert.ToDecimal(sonuc) : 0;
                    hedefLabel.Text = miktar.ToString("C2"); 
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
                   
                    int aktif = (int)new SqlCommand("SELECT COUNT(*) FROM tblKullanicilar WHERE AktifMi=1", bag).ExecuteScalar();
                    int pasif = (int)new SqlCommand("SELECT COUNT(*) FROM tblKullanicilar WHERE AktifMi=0", bag).ExecuteScalar();
                    int toplam = aktif + pasif;

                    lblAktif.Text = aktif.ToString();
                    lblPasif.Text = pasif.ToString();
                    lblToplam.Text = toplam.ToString();
                }
                catch {  }
            }
        }



       
        private void KarZararCubugunuGuncelle(System.Windows.Forms.ProgressBar pb, Label lblTutar)
        {
            using (SqlConnection bag = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    bag.Open();
                   
                    string sorgu = @"SELECT ISNULL(SUM((sd.BirimFiyat - u.AlisFiyat) * sd.Miktar), 0) 
                             FROM tblSatisDetay sd 
                             JOIN tblUrunler u ON sd.UrunID = u.UrunID";

                    SqlCommand komut = new SqlCommand(sorgu, bag);
                    decimal netKar = Convert.ToDecimal(komut.ExecuteScalar());

                    decimal hedefKar = 10000;
                    int yuzde = (netKar > 0) ? (int)((netKar / hedefKar) * 100) : 0;

                    pb.Value = Math.Max(0, Math.Min(100, yuzde));
                    lblTutar.Text = "Toplam Kâr: " + netKar.ToString("C2");
                }
                catch (Exception ex)
                {
                   
                    MessageBox.Show("Hata Detayı: " + ex.Message);
                    pb.Value = 0;
                }
            }
        }



        private void EnCokSatanlariGetir(Label lblEnCok)
        {
            using (SqlConnection bag = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    bag.Open();
                    string sorgu = @"SELECT TOP 3 u.UrunAd, SUM(sd.Miktar) as ToplamAdet 
                             FROM tblSatisDetay sd 
                             JOIN tblUrunler u ON sd.UrunID = u.UrunID 
                             GROUP BY u.UrunAd ORDER BY ToplamAdet DESC";

                    SqlCommand cmd = new SqlCommand(sorgu, bag);
                    SqlDataReader dr = cmd.ExecuteReader();
                    lblEnCok.Text = "";
                    int sira = 1;
                    while (dr.Read())
                    {
                        lblEnCok.Text += $"{sira}. {dr["UrunAd"]} ({dr["ToplamAdet"]} Adet)\n";
                        sira++;
                    }
                    dr.Close();
                }
                catch { lblEnCok.Text = "Veri Yok"; }
            }
        }
        private void EnAzSatanlariGetir(Label lblEnAz)
        {
            using (SqlConnection bag = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    bag.Open();
                    string sorgu = @"SELECT TOP 3 u.UrunAd, SUM(sd.Miktar) as ToplamAdet 
                             FROM tblSatisDetay sd 
                             JOIN tblUrunler u ON sd.UrunID = u.UrunID 
                             GROUP BY u.UrunAd ORDER BY ToplamAdet ASC";

                    SqlCommand cmd = new SqlCommand(sorgu, bag);
                    SqlDataReader dr = cmd.ExecuteReader();
                    lblEnAz.Text = "";
                    int sira = 1;
                    while (dr.Read())
                    {
                        lblEnAz.Text += $"{sira}. {dr["UrunAd"]} ({dr["ToplamAdet"]} Adet)\n";
                        sira++;
                    }
                    dr.Close();
                }
                catch { lblEnAz.Text = "Veri Yok"; }
            }
        }
        private void YuksekKarGetirenUrunuGetir(Label lblYuksekKar)
        {
            using (SqlConnection bag = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    bag.Open();
                   
                    string sorgu = @"SELECT TOP 3 UrunAd, (BirimFiyat - AlisFiyat) as BirimKar 
                             FROM tblUrunler 
                             WHERE BirimFiyat > AlisFiyat
                             ORDER BY BirimKar DESC";

                    SqlCommand cmd = new SqlCommand(sorgu, bag);
                    SqlDataReader dr = cmd.ExecuteReader();
                    lblYuksekKar.Text = "";
                    int sira = 1;
                    while (dr.Read())
                    {
                        decimal kar = Convert.ToDecimal(dr["BirimKar"]);
                        lblYuksekKar.Text += $"{sira}. {dr["UrunAd"]} ({kar:C2} Kâr)\n";
                        sira++;
                    }
                    dr.Close();

                    if (sira == 1) lblYuksekKar.Text = "Kârlı ürün bulunamadı.";
                }
                catch (Exception ex)
                {
                    lblYuksekKar.Text = "Sütun Hatası!";
                   
                }
            }
        }


        private void basitGrafik1_Click(object sender, EventArgs e)
        {

        }

        private void frmYoneticiHomeIcerik_Load(object sender, EventArgs e)
        {
            
            VeriyiGetirVeYaz(lblSatisGun,
                "SELECT SUM(ToplamTutar) FROM tblSatislar WHERE CAST(SatisTarihi AS DATE) = CAST(GETDATE() AS DATE)");

           
            VeriyiGetirVeYaz(lblSatisHafta,
                "SELECT SUM(ToplamTutar) FROM tblSatislar WHERE SatisTarihi >= DATEADD(DAY, -7, GETDATE())");

           
            VeriyiGetirVeYaz(lblSatisAy,
                "SELECT SUM(ToplamTutar) FROM tblSatislar WHERE MONTH(SatisTarihi) = MONTH(GETDATE()) AND YEAR(SatisTarihi) = YEAR(GETDATE())");

           
            VeriyiGetirVeYaz(lblSatisYil,
                "SELECT SUM(ToplamTutar) FROM tblSatislar WHERE YEAR(SatisTarihi) = YEAR(GETDATE())");

           
            KullaniciSayilariniGuncelle(lblAktifUser, lblPasifUser, lblToplamUser);
            EnCokSatanlariGetir(lblEnCok);       
            EnAzSatanlariGetir(lblEnAz);        
            YuksekKarGetirenUrunuGetir(lblYuksekKar); 
            KarZararCubugunuGuncelle(pbKarZarar, lblToplamKarZararText);


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            frmYoneticiHomeIcerik_Load(null, null);
        }

        private void frmYoneticiHomeIcerik_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer1 != null)
            {
                timer1.Enabled = false; 
                timer1.Stop();
                timer1.Dispose(); 
            }
        }
    }
}



