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
                    MessageBox.Show("Hesaplama hatası: " + ex.Message);
                }
            }
            return fnl;
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
                FROM tblHareketler 
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
