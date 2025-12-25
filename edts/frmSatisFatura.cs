using DocumentFormat.OpenXml.Bibliography;
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
using edts;
namespace edts
{
    public partial class frmSatisFatura : Form
    {// Formun en üstünde tanımla
        DataTable sepetTablosu = new DataTable();
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
        public frmSatisFatura()
        {
            InitializeComponent();
        }

        private void btnSepetEkle_Click(object sender, EventArgs e)
        {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                baglan.Open();
                // Ürün bilgilerini ve stok durumunu barkoddan çekiyoruz
                SqlCommand cmd = new SqlCommand("SELECT UrunAd, SatisFiyat, StokMiktari FROM tblUrunler WHERE Barkod=@barkod", baglan);
                cmd.Parameters.AddWithValue("@barkod", txtUrunBarkod.Text);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    int stok = Convert.ToInt32(dr["StokMiktari"]);
                    int istenen = (int)nmrSatisAdet.Value;

                    if (istenen > stok)
                    {
                        MessageBox.Show($"Yetersiz stok! Mevcut: {stok}", "Uyarı");
                        return;
                    }

                    // Sepete ekle
                    sepetTablosu.Rows.Add(txtUrunBarkod.Text, dr["UrunAd"], istenen, dr["SatisFiyat"]);
                }
                else { MessageBox.Show("Ürün bulunamadı!"); }
            }
        }

        private void btnSatisOnay_Click(object sender, EventArgs e)
        {
            if (sepetTablosu.Rows.Count == 0) return;

            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                baglan.Open();
                SqlTransaction işlem = baglan.BeginTransaction(); // Hata olursa tüm işlemi geri almak için

                try
                {
                    // 1. tblSatislar'a ana kaydı at (Kime satıldı?)
                    SqlCommand cmdSatis = new SqlCommand(@"INSERT INTO tblSatislar (MusteriID, SatisTarihi, ToplamTutar) 
                                                  OUTPUT INSERTED.SatisID 
                                                  VALUES (@mid, GETDATE(), @toplam)", baglan, işlem);
                    cmdSatis.Parameters.AddWithValue("@mid", cmbMusteriSecim.SelectedValue);
                    cmdSatis.Parameters.AddWithValue("@toplam", sepetTablosu.Compute("Sum(Toplam)", ""));
                    int satisID = (int)cmdSatis.ExecuteScalar();

                    // 2. Sepetteki her ürün için işlem yap
                    foreach (DataRow row in sepetTablosu.Rows)
                    {
                        // Satış detayına ekle
                        SqlCommand cmdDetay = new SqlCommand("INSERT INTO tblSatisDetay (SatisID, Barkod, Adet, Fiyat) VALUES (@sid, @barkod, @adet, @fiyat)", baglan, işlem);
                        cmdDetay.Parameters.AddWithValue("@sid", satisID);
                        cmdDetay.Parameters.AddWithValue("@barkod", row["Barkod"]);
                        cmdDetay.Parameters.AddWithValue("@adet", row["Adet"]);
                        cmdDetay.Parameters.AddWithValue("@fiyat", row["Fiyat"]);
                        cmdDetay.ExecuteNonQuery();

                        // STOKTAN DÜŞÜŞ
                        SqlCommand cmdStok = new SqlCommand("UPDATE tblUrunler SET StokMiktari = StokMiktari - @adet WHERE Barkod = @barkod", baglan, işlem);
                        cmdStok.Parameters.AddWithValue("@adet", row["Adet"]);
                        cmdStok.Parameters.AddWithValue("@barkod", row["Barkod"]);
                        cmdStok.ExecuteNonQuery();
                    }

                    işlem.Commit(); // Her şey tamamsa onayla
                    MessageBox.Show("Satış başarıyla tamamlandı, stoklar güncellendi.");
                    sepetTablosu.Clear();

                    VeritabaniYardimcisi.LogKaydet(AktifKullanici.ID, 10, "tblSatislar", "Yeni satış yapıldı. ID: " + satisID);
                }
                catch (Exception ex)
                {
                    işlem.Rollback(); // Hata varsa hiçbir şeyi kaydetme
                    MessageBox.Show("Satış hatası: " + ex.Message);
                }
            }
        }

        private void frmSatisFatura_Load(object sender, EventArgs e)
        {
            // Bellekteki tabloya sütunları ekliyoruz
            sepetTablosu.Columns.Add("Barkod");
            sepetTablosu.Columns.Add("UrunAd");
            sepetTablosu.Columns.Add("Adet", typeof(int));
            sepetTablosu.Columns.Add("Fiyat", typeof(decimal));
            sepetTablosu.Columns.Add("Toplam", typeof(decimal), "Adet * Fiyat"); // Otomatik hesaplar

            // DataGridView'e "Senin verilerin bu sanal tablodur" diyoruz
            dgvSepet.DataSource = sepetTablosu;
        }
    }
}
