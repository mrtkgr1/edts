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

namespace edts
{
    public partial class frmUrunYonetimi : Form
    {
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

        public frmUrunYonetimi()
        {
            InitializeComponent();
            UrunListeGuncelle();
            KategorileriYukle();

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    UrunListeGuncelle();
                    KategorileriYukle();
                    break;
                case 1:
                    KategoriListeGuncelle();
                    break;
              
                default:
                    break;
            }
        }

        //------------------- ÜRÜN İŞLEMLERİ ------------------//

        private void btnKaydet_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUrunAd.Text) || string.IsNullOrEmpty(txtAlisFiyati.Text))
            {
                MessageBox.Show("Lütfen ürün adı ve alış fiyatı gibi zorunlu alanları doldurun!");
                return;
            }

            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();
                    // Sorguya "BirimTipi" kolonunu ve "@BirimTipi" parametresini ekledik
                    SqlCommand cmdInsert = new SqlCommand(@"INSERT INTO tblUrunler  
            (KategoriID, UrunKodu, UrunAd, KritikStok, MevcutStok, Durum, BirimFiyat, AlisFiyat, BirimTipi)  
            VALUES (@KategoriID, @UrunKodu, @UrunAd, @KritikStok, 0, 'Aktif', @BirimFiyat, @AlisFiyat, @BirimTipi)", baglan);

                    cmdInsert.Parameters.AddWithValue("@KategoriID", comboBoxKategori.SelectedValue ?? DBNull.Value);
                    cmdInsert.Parameters.AddWithValue("@UrunKodu", txtUrunKod.Text);
                    cmdInsert.Parameters.AddWithValue("@UrunAd", txtUrunAd.Text);

                    int kritikStok = 0;
                    int.TryParse(txtKritik.Text, out kritikStok);
                    cmdInsert.Parameters.AddWithValue("@KritikStok", kritikStok);

                    decimal satisFiyati = 0;
                    decimal.TryParse(birimFiyat.Value.ToString(), out satisFiyati);
                    cmdInsert.Parameters.AddWithValue("@BirimFiyat", satisFiyati);

                    decimal alisFiyati = 0;
                    decimal.TryParse(txtAlisFiyati.Text, out alisFiyati);
                    cmdInsert.Parameters.AddWithValue("@AlisFiyat", alisFiyati);

                    // --- BURAYI EKLEDİK ---
                    cmdInsert.Parameters.AddWithValue("@BirimTipi", cmbBirimTipi.Text);

                    cmdInsert.ExecuteNonQuery();

                    VeritabaniYardimcisi.LogKaydet(AktifKullanici.ID, 5, "tblUrunler", $"{txtUrunAd.Text} adlı ürün eklendi.");
                    MessageBox.Show("Ürün başarıyla kaydedildi.");

                    txtUrunAd.Clear();
                    txtUrunKod.Clear();
                    txtAlisFiyati.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ürün kayıt edilemedi.\nHata: " + ex.Message);
                }
            }
            UrunListeGuncelle();
        }
        private void btnSill_Click(object sender, EventArgs e)
        {
            // 1. Satır seçili mi kontrol et
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz ürünün en solundaki boşluğa tıklayarak satırı seçin.");
                return;
            }

            // 2. Kullanıcıdan onay al (Yanlışlıkla silmeyi önler)
            DialogResult onay = MessageBox.Show("Bu ürünü silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (onay == DialogResult.Yes)
            {
                using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
                {
                    try
                    {
                        // Grid'den ID ve Ürün Adını alalım
                        int id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["UrunID"].Value);
                        string silinenUrunAdi = dataGridView2.SelectedRows[0].Cells["UrunAd"].Value.ToString();

                        baglan.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM tblUrunler WHERE UrunID = @id", baglan);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();

                        // Log kaydını grid'den aldığımız isimle yapalım (daha güvenli)
                        VeritabaniYardimcisi.LogKaydet(AktifKullanici.ID, 5, "tblUrunler", $"{silinenUrunAdi} adlı ürün silindi.");

                        MessageBox.Show("Ürün başarıyla silindi.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ürün silinemedi. Hata: " + ex.Message);
                    }
                }
                UrunListeGuncelle(); // Listeyi yenile
            }
        }

        private void btnGuncelle_Click_1(object sender, EventArgs e)
        {
           
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz ürünün en solundaki boşluğa tıklayarak tüm satırı seçiniz.");
                return;
            }

            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    int id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["UrunID"].Value);
                    baglan.Open();

                    // 1. ADIM: SQL Sorgusuna BirimTipi'ni ekledik
                    string sorgu = @"UPDATE tblUrunler 
                             SET KategoriID = @KategoriID, 
                                 UrunKodu = @UrunKodu, 
                                 UrunAd = @UrunAd, 
                                 KritikStok = @KritikStok,
                                 BirimFiyat = @BirimFiyat,
                                 AlisFiyat = @AlisFiyat,
                                 BirimTipi = @BirimTipi
                             WHERE UrunID = @UrunID";

                    SqlCommand cmdUpdate = new SqlCommand(sorgu, baglan);

                    cmdUpdate.Parameters.AddWithValue("@UrunID", id);
                    cmdUpdate.Parameters.AddWithValue("@KategoriID", comboBoxKategori.SelectedValue ?? DBNull.Value);
                    cmdUpdate.Parameters.AddWithValue("@UrunKodu", txtUrunKod.Text);
                    cmdUpdate.Parameters.AddWithValue("@UrunAd", txtUrunAd.Text);

                    // 2. ADIM: BirimTipi parametresini ComboBox'tan alıp ekledik
                    cmdUpdate.Parameters.AddWithValue("@BirimTipi", cmbBirimTipi.Text);

                    decimal satisFiyat;
                    decimal.TryParse(birimFiyat.Value.ToString(), out satisFiyat);
                    cmdUpdate.Parameters.AddWithValue("@BirimFiyat", satisFiyat);

                    decimal alisFiyat;
                    decimal.TryParse(txtAlisFiyati.Text, out alisFiyat);
                    cmdUpdate.Parameters.AddWithValue("@AlisFiyat", alisFiyat);

                    int kritikStok;
                    int.TryParse(txtKritik.Text, out kritikStok);
                    cmdUpdate.Parameters.AddWithValue("@KritikStok", kritikStok);

                    cmdUpdate.ExecuteNonQuery();

                    VeritabaniYardimcisi.LogKaydet(AktifKullanici.ID, 5, "tblUrunler", $"{txtUrunAd.Text} adlı ürün güncellendi.");
                    MessageBox.Show("Ürün bilgileri başarıyla güncellendi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme hatası: " + ex.Message);
                }
            }
            UrunListeGuncelle();
        }
        
        private void UrunListeGuncelle()
        {
         
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();

                    string sorgu = @"
            SELECT 
                u.UrunID,
                u.UrunKodu,
                u.UrunAd,
                u.BirimFiyat,
                u.AlisFiyat,
                u.BirimTipi,  -- İŞTE BURASI EKSİKTİ!
                u.KritikStok,  -- BURASI EKLENDİ
                u.MevcutStok,  -- BURASI EKLENDİ (Stok miktarını görmek için)
                k.KategoriAd   
            FROM tblUrunler u
            INNER JOIN tblKategoriler k ON u.KategoriID = k.KategoriID";

                    SqlDataAdapter da = new SqlDataAdapter(sorgu, baglan);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView2.DataSource = dt;

                    // Görünürlük ve Başlık Düzenlemeleri
                    if (dataGridView2.Columns["UrunID"] != null) dataGridView2.Columns["UrunID"].Visible = false;

                    dataGridView2.Columns["UrunKodu"].HeaderText = "Ürün Kodu";
                    dataGridView2.Columns["UrunAd"].HeaderText = "Ürün Adı";
                    dataGridView2.Columns["AlisFiyat"].HeaderText = "Alış Fiyatı";
                    dataGridView2.Columns["BirimFiyat"].HeaderText = "Satış Fiyatı";
                    dataGridView2.Columns["KategoriAd"].HeaderText = "Kategori";

                    // Yeni eklediğimiz sütunun başlığı
                    if (dataGridView2.Columns["BirimTipi"] != null)
                        dataGridView2.Columns["BirimTipi"].HeaderText = "Birim";
                    // Yeni Eklenen Sütun Başlıkları
                    dataGridView2.Columns["KritikStok"].HeaderText = "Kritik Seviye";
                    dataGridView2.Columns["MevcutStok"].HeaderText = "Stok Adedi";

                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // --- BONUS ÖZELLİK BURAYA GELİYOR ---
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        // Satırın boş olmadığından emin olalım
                        if (row.Cells["MevcutStok"].Value != null && row.Cells["KritikStok"].Value != null)
                        {
                            int stok = Convert.ToInt32(row.Cells["MevcutStok"].Value);
                            int kritik = Convert.ToInt32(row.Cells["KritikStok"].Value);

                            if (stok <= kritik)
                            {
                                row.DefaultCellStyle.BackColor = Color.Salmon; // Arka plan rengi
                                row.DefaultCellStyle.ForeColor = Color.Black; // Yazı rengi
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri çekilemedi: " + ex.Message);
                }
            }
        }
        void KategorileriYukle()
        {
            using (SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString))
            {
                try
                {
                    baglan.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT KategoriID, KategoriAd FROM tblKategoriler", baglan);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboBoxKategori.DisplayMember = "KategoriAd";
                    comboBoxKategori.ValueMember = "KategoriID";


                    comboBoxKategori.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kategoriler yüklenirken hata: " + ex.Message);
                }
            }
        }
        public void UrunBilgileriniGetir(int id)
        {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();

                    string sorgu = "SELECT UrunKodu, UrunAd, KategoriID, KritikStok, BirimFiyat FROM tblUrunler WHERE UrunID = @UrunID";

                    SqlCommand cmd = new SqlCommand(sorgu, baglan);
                    cmd.Parameters.AddWithValue("@UrunID", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            txtUrunKod.Text = dr["UrunKodu"].ToString();
                            txtUrunAd.Text = dr["UrunAd"].ToString();
                            txtKritik.Text = dr["KritikStok"].ToString();

                            comboBoxKategori.SelectedValue = Convert.ToInt32(dr["KategoriID"]);

                            birimFiyat.Value = Convert.ToDecimal(dr["BirimFiyat"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bilgiler getirilemedi: " + ex.Message);
                }
            }
        }

        //------------------- KATEGORİ İŞLEMLERİ ------------------//
       
       

       
        private void KategoriListeGuncelle()
        {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();
                    string sorgu = "SELECT KategoriID, KategoriAd FROM tblKategoriler";

                    SqlDataAdapter da = new SqlDataAdapter(sorgu, baglan);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dataGridView2.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri çekilemedi: " + ex.Message);
                }
            }
        }

       
   
        private void musteriBilgiAl(int id, out string ad, out string verigiNo, out string vergiDairesi, out string tel)
        {
            ad = string.Empty;
            verigiNo = string.Empty;
            vergiDairesi = string.Empty;
            tel = string.Empty;
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("SELECT MusteriAd, VergiDairesi, VergiNo, Telefon FROM tblMusteriler WHERE MusteriID = @id", baglan);
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ad = dr["MusteriAd"].ToString();
                            vergiDairesi = dr["VergiDairesi"].ToString();
                            verigiNo = dr["VergiNo"].ToString();
                            tel = dr["Telefon"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Müsteri kaydı yüklenirken hata: " + ex.Message);
                }
            }
        }

        //------------------- DataGridView Seçim İşlemleri ------------------//
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    if (e.RowIndex >= 0)
                    {
                        UrunBilgileriniGetir(Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["UrunID"].Value));
                    }
                    break;
               
                    }   
        }

        private void frmUrunYonetimi_Load(object sender, EventArgs e)
        {
            KategorileriYukle();
            UrunListeGuncelle(); // Form açılır açılmaz liste gelsin
                                 // Bunu Form_Load içine yaz
            cmbBirimTipi.Items.AddRange(new string[] { "Adet", "KG", "Metre", "Paket","gram" });
            cmbBirimTipi.SelectedIndex = 0; // İlk sıradakini seçili getirir
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         
            // 1. ADIM: Başlık satırına (-1) veya en alttaki boş yeni satıra (IsNewRow) tıklandıysa işlemi bitir
            if (e.RowIndex < 0 || dataGridView2.Rows[e.RowIndex].IsNewRow)
                return;

            // Tıklanan satırı bir değişkene atayalım
            DataGridViewRow satir = dataGridView2.Rows[e.RowIndex];

            try
            {
                // 2. ADIM: Verileri kutulara aktarırken null (boş) kontrolü yapalım
                // ?.ToString() kullanımı değer null ise hata vermez, boş string döner.

                txtUrunKod.Text = satir.Cells["UrunKodu"].Value?.ToString();
                txtUrunAd.Text = satir.Cells["UrunAd"].Value?.ToString();
                txtAlisFiyati.Text = satir.Cells["AlisFiyat"].Value?.ToString();
                comboBoxKategori.Text = satir.Cells["KategoriAd"].Value?.ToString();
                cmbBirimTipi.Text = satir.Cells["BirimTipi"].Value?.ToString();

                // Kritik Stok (Grid'e eklediysen)
                if (dataGridView2.Columns.Contains("KritikStok"))
                    txtKritik.Text = satir.Cells["KritikStok"].Value?.ToString();

                // 3. ADIM: Sayısal Dönüşüm (Hata aldığın kritik nokta)
                // Eğer hücre boş (DBNull) ise Convert.ToDecimal hata verir, bu yüzden kontrol ediyoruz.
                if (satir.Cells["BirimFiyat"].Value != DBNull.Value && satir.Cells["BirimFiyat"].Value != null)
                {
                    birimFiyat.Value = Convert.ToDecimal(satir.Cells["BirimFiyat"].Value);
                }
                else
                {
                    birimFiyat.Value = 0; // Değer yoksa hata verme, 0 yap.
                }
            }
            catch (Exception ex)
            {
                // Beklenmedik bir hata olursa program kapanmasın, bize söylesin.
                MessageBox.Show("Satır seçilirken hata oluştu: " + ex.Message);
            }
        }

        private void btnTedarikciKaydett_Click(object sender, EventArgs e)
        {

        }
    }
}
    




