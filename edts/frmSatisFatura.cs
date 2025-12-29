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
                // SORGUNU GÜNCELLEDİM: UrunID bilgisini de çekiyoruz
                SqlCommand cmd = new SqlCommand("SELECT UrunID, UrunAd, BirimFiyat, MevcutStok FROM tblUrunler WHERE UrunKodu=@kod", baglan);
                cmd.Parameters.AddWithValue("@kod", txtUrunBarkod.Text);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    decimal stok = Convert.ToDecimal(dr["MevcutStok"]);
                    decimal istenen = nmrSatisAdet.Value;

                    if (istenen > stok)
                    {
                        MessageBox.Show($"Yetersiz stok! Mevcut: {stok}", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // SEPETE EKLEME: UrunID ve Toplam Fiyat hesaplaması eklendi
                    decimal birimFiyat = Convert.ToDecimal(dr["BirimFiyat"]);
                    decimal toplamFiyat = birimFiyat * istenen;

                    // Sütun sıralamasına dikkat (ID, Barkod, Ad, Adet, Fiyat, Toplam)
                    sepetTablosu.Rows.Add(
                        dr["UrunID"],
                        txtUrunBarkod.Text,
                        dr["UrunAd"],
                        istenen,
                        birimFiyat,
                        toplamFiyat
                    );

                    txtUrunBarkod.Clear();
                    txtUrunBarkod.Focus();

                    // Genel toplamı ekrandaki etikete yansıtmak için:
                  
                    lblGenelToplam.Text = Convert.ToDecimal(sepetTablosu.Compute("Sum(Toplam)", "")).ToString("C2");
                }
                else
                {
                    MessageBox.Show("Ürün bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        

        private void btnSatisOnay_Click(object sender, EventArgs e)
        {
            // 1. Müşteri seçimi kontrolü (@mid hatasını önlemek için)
            if (cmbMusteri.SelectedValue == null)
            {
                MessageBox.Show("Lütfen önce bir müşteri seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (sepetTablosu.Rows.Count == 0)
            {
                MessageBox.Show("Sepette ürün bulunmuyor!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                baglan.Open();
                SqlTransaction işlem = baglan.BeginTransaction();

                try
                {
                    // 2. tblSatislar'a ana kaydı at
                    SqlCommand cmdSatis = new SqlCommand(@"INSERT INTO tblSatislar (MusteriID, SatisTarihi, ToplamTutar) 
                                                  OUTPUT INSERTED.SatisID 
                                                  VALUES (@mid, GETDATE(), @toplam)", baglan, işlem);

                    cmdSatis.Parameters.AddWithValue("@mid", cmbMusteri.SelectedValue);
                    cmdSatis.Parameters.AddWithValue("@toplam", sepetTablosu.Compute("Sum(Toplam)", ""));
                    int satisID = (int)cmdSatis.ExecuteScalar();

                    // 3. Sepetteki her ürün için işlem yap
                    foreach (DataRow row in sepetTablosu.Rows)
                    {
                        // Sütun isimlerini tblSatisDetay tasarımına göre güncelledim:
                        // UrunKodu -> UrunID | Adet -> Miktar | Fiyat -> BirimFiyat
                        SqlCommand cmdDetay = new SqlCommand(@"INSERT INTO tblSatisDetay (SatisID, UrunID, Miktar, BirimFiyat) 
                                                       VALUES (@sid, @uid, @miktar, @fiyat)", baglan, işlem);

                        cmdDetay.Parameters.AddWithValue("@sid", satisID);
                        // NOT: Sepet tablonuzda ürünün ID'sini tuttuğunuzdan emin olun. 
                        // Eğer Barkod ile işlem yapıyorsanız, burada önce ID'yi bulmamız gerekebilir.
                        cmdDetay.Parameters.AddWithValue("@uid", row["UrunID"]);
                        cmdDetay.Parameters.AddWithValue("@miktar", row["Adet"]);
                        cmdDetay.Parameters.AddWithValue("@fiyat", row["Fiyat"]);
                        cmdDetay.ExecuteNonQuery();

                        // 4. STOKTAN DÜŞÜŞ (tblUrunler yapına göre)
                        // UrunKodu ve MevcutStok isimlerini kullandım
                        SqlCommand cmdStok = new SqlCommand(@"UPDATE tblUrunler SET MevcutStok = MevcutStok - @adet 
                                                       WHERE UrunKodu = @barkod", baglan, işlem);
                        cmdStok.Parameters.AddWithValue("@adet", row["Adet"]);
                        cmdStok.Parameters.AddWithValue("@barkod", row["Barkod"]);
                        cmdStok.ExecuteNonQuery();
                    }

                    işlem.Commit();
                    MessageBox.Show("Satış başarıyla tamamlandı, stoklar güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sepetTablosu.Clear();

                    VeritabaniYardimcisi.LogKaydet(AktifKullanici.ID, 10, "tblSatislar", "Satış yapıldı. ID: " + satisID);

                    // İŞTE BURAYA EKLE: Etiketi görsel olarak sıfırla
                    lblGenelToplam.Text = "0.00";

                    // İsteğe bağlı: İmleci tekrar barkod girişine odakla
                    txtUrunBarkod.Focus();
                }
                catch (Exception ex)
                {
                    işlem.Rollback();
                    MessageBox.Show("Satış hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        

        private void MusterileriGetir()
        {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                // Sadece ID ve Ad Soyad çekiyoruz
                SqlDataAdapter da = new SqlDataAdapter("SELECT MusteriID, MusteriAd FROM tblMusteriler", baglan);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbMusteri.DataSource = dt;
                cmbMusteri.DisplayMember = "MusteriAd"; // Ekranda görünecek olan
                cmbMusteri.ValueMember = "MusteriID";   // Arka planda tutulacak olan ID

                cmbMusteri.SelectedIndex = -1; // İlk açılışta boş görünsün
            }
        }

        private void SatislariGetir()
        {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                // En son yapılan satışı en üstte görmek için 'ORDER BY SatisID DESC' ekledik
                string sorgu = @"SELECT S.SatisID, M.MusteriAd, S.SatisTarihi, S.ToplamTutar 
                         FROM tblSatislar S 
                         INNER JOIN tblMusteriler M ON S.MusteriID = M.MusteriID 
                         ORDER BY S.SatisID DESC";

                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglan);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvSatislar.DataSource = dt; // Sağdaki tabloyu doldurur
            }
        }
        private void frmSatisFatura_Load(object sender, EventArgs e)
        {
            // Sütunları Rows.Add içindeki sırayla birebir aynı yapmalısın:
            sepetTablosu.Columns.Add("UrunID", typeof(int));    // 1. Sütun
            sepetTablosu.Columns.Add("Barkod");                 // 2. Sütun
            sepetTablosu.Columns.Add("UrunAd");                 // 3. Sütun
            sepetTablosu.Columns.Add("Adet", typeof(decimal));  // 4. Sütun
            sepetTablosu.Columns.Add("Fiyat", typeof(decimal)); // 5. Sütun
            sepetTablosu.Columns.Add("Toplam", typeof(decimal));// 6. Sütun

            dgvSepet.DataSource = sepetTablosu;

            // Görsellik: UrunID'yi kullanıcı görmesin ama kod kullansın
            dgvSepet.Columns["UrunID"].Visible = false;

            MusterileriGetir();
            SatislariGetir(); // Sağdaki kalıcı tabloyu doldurur
        }
    }
    }

