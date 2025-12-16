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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace edts
{
    public partial class frmYoneticiHomeIcerik : Form {
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

        public frmYoneticiHomeIcerik() {
            InitializeComponent();
            KritikDurumuGoster();
            ToplamStokDegeriniGetir();
            //label3.Text = "Son 7 Gün Giriş/Çıkış Farkı ";
        }

        private void groupBox2_Enter(object sender, EventArgs e) {

        }
        public void ToplamStokDegeriniGetir() {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    baglan.Open();

                    // SQL MANTIĞI:
                    // 1. Her satır için (MevcutStok * BirimFiyat) işlemini yap.
                    // 2. Çıkan sonuçların Hepsini TOPLA (SUM).
                    // 3. ISNULL: Eğer boş değer varsa 0 kabul et ki hesap bozulmasın.
                    string sorgu = "SELECT SUM(ISNULL(MevcutStok, 0) * ISNULL(BirimFiyat, 0)) FROM tblUrunler";

                    SqlCommand cmd = new SqlCommand(sorgu, baglan);

                    // Tek bir sonuç (para değeri) döneceği için ExecuteScalar kullanıyoruz
                    object sonuc = cmd.ExecuteScalar();

                    if (sonuc != DBNull.Value && sonuc != null) {
                        decimal toplamTutar = Convert.ToDecimal(sonuc);

                        // Label'a Para Birimi (₺) formatında yazdır
                        label1.Text = "Toplam Envanter Değeri: " + toplamTutar.ToString("C2");
                    } else {
                        label1.Text = "Toplam Envanter Değeri: " +"₺0,00";
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Hesaplama hatası: " + ex.Message);
                }
            }
        }
        public void KritikDurumuGoster() {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    baglan.Open();

                    string sorgu = @"
                SELECT 
                    SUM(CASE WHEN MevcutStok < KritikStok THEN 1 ELSE 0 END) AS KritikAdet,
                    CAST(
                        (SUM(CASE WHEN MevcutStok < KritikStok THEN 1 ELSE 0 END) * 100.0) 
                        / NULLIF(COUNT(*), 0) 
                    AS DECIMAL(5, 2)) AS KritikOran
                FROM tblUrunler";

                    SqlCommand cmd = new SqlCommand(sorgu, baglan);

                    // Birden fazla sütun okuyacağımız için ExecuteReader kullanıyoruz
                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        if (dr.Read()) {
                            // 1. ADETİ ALALIM (Veritabanı boşsa 0 gelsin)
                            int adet = dr["KritikAdet"] != DBNull.Value ? Convert.ToInt32(dr["KritikAdet"]) : 0;

                            // 2. ORANI ALALIM
                            decimal oran = dr["KritikOran"] != DBNull.Value ? Convert.ToDecimal(dr["KritikOran"]) : 0;

                            // 3. FORMATLI YAZDIRALIM
                            // Çıktı Örneği: %15.45 (3 Ürün)
                            lblKritikBilgi.Text = $"%{oran} ({adet} adet)";
                            prbKritikStok.Value = (int)oran;

                            // Renklendirme (Opsiyonel)
                            if (oran > 0.5m) {
                                lblKritikBilgi.ForeColor = Color.Red;
                            } else if (oran > 0.25m) {
                                lblKritikBilgi.ForeColor = Color.Orange;
                            } else {
                                lblKritikBilgi.Text = "%0";
                                lblKritikBilgi.ForeColor = Color.Green;
                            }
                        }
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Veri çekilemedi: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {

        }
    }
}
