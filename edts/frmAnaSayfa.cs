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
    public partial class frmAnaSayfa : Form
    {
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
        public frmAnaSayfa() {
            InitializeComponent();
            BugunkuIslemSayilariniGetir();
            UrunDurumunuGetir();
        }
        public void BugunkuIslemSayilariniGetir() {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    baglan.Open();

                    // SQL SORGUSU:
                    // Tarih aralığı "Bugün" olanları filtrele.
                    // HareketID 4 ise (Alım) sayacı 1 artır.
                    // HareketID 2 ise (Satım) sayacı 1 artır.
                    string sorgu = @"
                SELECT 
                    SUM(CASE WHEN HareketID = 4 THEN 1 ELSE 0 END) AS AlimSayisi,
                    SUM(CASE WHEN HareketID = 2 THEN 1 ELSE 0 END) AS SatisSayisi
                FROM tblStokHareketleri
                WHERE Tarih BETWEEN @Baslangic AND @Bitis";

                    SqlCommand cmd = new SqlCommand(sorgu, baglan);

                    // PARAMETRELER (Bugünün Tamamı):
                    // DateTime.Today -> Bugünün tarihi saat 00:00:00
                    cmd.Parameters.AddWithValue("@Baslangic", DateTime.Today);

                    // Bugünün son saniyesi -> 23:59:59
                    cmd.Parameters.AddWithValue("@Bitis", DateTime.Today.AddDays(1).AddSeconds(-1));

                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        if (dr.Read()) {
                            // Değerleri okuyalım (Eğer veritabanı boşsa veya o gün işlem yoksa 0 gelir)
                            int alimAdet = dr["AlimSayisi"] != DBNull.Value ? Convert.ToInt32(dr["AlimSayisi"]) : 0;
                            int satisAdet = dr["SatisSayisi"] != DBNull.Value ? Convert.ToInt32(dr["SatisSayisi"]) : 0;

                            // Label'lara yazdıralım
                            label2.Text = "Günlük Giriş: " + alimAdet.ToString();
                            label4.Text = "Günlük Çıkış: " + satisAdet.ToString();
                        }
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Bugünkü veriler çekilemedi: " + ex.Message);
                }
            }
        }
        public void UrunDurumunuGetir() {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    baglan.Open();

                    // TEK SORGUDA İKİ İŞLEM:
                    // 1. COUNT(*) -> Tablodaki her şeyi say (Toplam Ürün)
                    // 2. SUM(CASE...) -> Sadece stoğu kritikten az olanlara '1' verip topla (Kritik Ürün)
                    string sorgu = @"
                SELECT 
                    COUNT(*) AS ToplamSayi,
                    ISNULL(SUM(CASE WHEN MevcutStok < KritikStok THEN 1 ELSE 0 END), 0) AS KritikSayi
                FROM tblUrunler";

                    SqlCommand cmd = new SqlCommand(sorgu, baglan);

                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        if (dr.Read()) {
                            // Değerleri okuyoruz
                            string toplam = dr["ToplamSayi"].ToString();
                            string kritik = dr["KritikSayi"].ToString();

                            // Label'lara yazdırıyoruz
                            label3.Text = "Kritik Stok Adeti: "+toplam;
                            label1.Text = "Toplam Ürün Çeşidi: " + kritik;


                        }
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Veriler alınamadı: " + ex.Message);
                }
            }
        }
        private void pnlUstSol_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
