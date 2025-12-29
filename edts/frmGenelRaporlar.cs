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
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
namespace edts
{
    public partial class frmGenelRaporlar : Form
    {
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

        public frmGenelRaporlar()
        {
            InitializeComponent();
        }

        private void btnRaporuGetir_Click(object sender, EventArgs e)
        {
            //HareketleriListele(dtpBaslangic.Value, dtpBitis.Value);
            StokHareketleriniListele(dtpBaslangic.Value, dtpBitis.Value);
            StokDurumuHesapla(dtpBaslangic.Value, dtpBitis.Value);

            String toplamTutar = TarihAraligiToplamTutarGetir(dtpBaslangic.Value, dtpBitis.Value);

            label6.Text = "Toplam Değeri : " + toplamTutar;
        }

        public void StokHareketleriniListele(DateTime baslangicTarihi, DateTime bitisTarihi)
        {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();

                    // Sorguya ht (HareketTipleri) tablosunu ekledik
                    string sorgu = @"
    SELECT 
        sh.IslemID,
        sh.FaturaNo,
        ISNULL(u.UrunAd, 'Ürün Bulunamadı') as UrunAd, -- Eğer isim gelmiyorsa 'Ürün Bulunamadı' yazar
        ht.HareketAd,
        k.KullaniciAdi,
        sh.Miktar,
        sh.Tarih,
        sh.HareketID
    FROM tblStokHareketleri sh
    LEFT JOIN tblUrunler u ON CAST(sh.UrunID AS INT) = CAST(u.UrunID AS INT) -- Tip uyuşmazlığına karşı CAST ekledik
    INNER JOIN tblKullanicilar k ON sh.KullaniciID = k.KullaniciID
    INNER JOIN tblHareketTipleri ht ON sh.HareketID = ht.HareketID
    WHERE sh.Tarih BETWEEN @Tarih1 AND @Tarih2
    ORDER BY sh.Tarih DESC";
                    SqlDataAdapter da = new SqlDataAdapter(sorgu, baglan);
                    da.SelectCommand.Parameters.Add("@Tarih1", SqlDbType.DateTime).Value = baslangicTarihi.Date;
                    da.SelectCommand.Parameters.Add("@Tarih2", SqlDbType.DateTime).Value = bitisTarihi.Date.AddDays(1).AddSeconds(-1);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Görseldeki "Oturum Açıldı" karmaşasını bitiren kısım:
                    dt.Columns.Add("IslemGorsel", typeof(string)); // Yeni bir sütun oluşturuyoruz

                    foreach (DataRow row in dt.Rows)
                    {
                        string gercekAd = row["HareketAd"].ToString();
                        // Veritabanındaki HareketID'ye göre ikon atıyoruz (4: Giriş, 2: Çıkış)
                        int hID = Convert.ToInt32(row["HareketID"]);
                        char ico = (hID == 4) ? '➕' : (hID == 2) ? '➖' : 'ℹ';

                        row["IslemGorsel"] = ico + " " + gercekAd;
                    }

                    dataGridView1.DataSource = dt;

                    // --- SÜTUN AYARLARI ---
                    if (dataGridView1.Columns["IslemID"] != null) dataGridView1.Columns["IslemID"].Visible = false;
                    if (dataGridView1.Columns["HareketID"] != null) dataGridView1.Columns["HareketID"].Visible = false;
                    if (dataGridView1.Columns["HareketAd"] != null) dataGridView1.Columns["HareketAd"].Visible = false;

                    dataGridView1.Columns["IslemGorsel"].HeaderText = "İşlem Tipi";
                    dataGridView1.Columns["IslemGorsel"].DisplayIndex = 0; // En başa al
                    dataGridView1.Columns["UrunAd"].HeaderText = "Ürün Adı";
                    dataGridView1.Columns["KullaniciAdi"].HeaderText = "İşlemi Yapan";
                    dataGridView1.Columns["Miktar"].HeaderText = "Adet";
                    dataGridView1.Columns["Tarih"].HeaderText = "İşlem Tarihi";
                    dataGridView1.Columns["Tarih"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
        public String TarihAraligiToplamTutarGetir(DateTime baslangic, DateTime bitis)
        {

            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();

                    // 1. Değişiklik: LEFT JOIN yaparak fiyatı olmayan veya eşleşmeyen ürünleri de hesaba katmaya çalışıyoruz.
                    // 2. Değişiklik: CAST kullanarak para birimi ve miktar çarpmalarında veri tipi hatasını önlüyoruz.
                    string sorgu = @"
                SELECT SUM(CAST(h.Miktar AS DECIMAL(18,2)) * CAST(ISNULL(u.BirimFiyat, 0) AS DECIMAL(18,2))) 
                FROM tblStokHareketleri h
                LEFT JOIN tblUrunler u ON h.UrunID = u.UrunID
                WHERE h.Tarih BETWEEN @tarih1 AND @tarih2";

                    SqlCommand cmd = new SqlCommand(sorgu, baglan);

                    // Tarih ayarını garantiye alalım
                    cmd.Parameters.AddWithValue("@tarih1", baslangic.Date);
                    cmd.Parameters.AddWithValue("@tarih2", bitis.Date.AddDays(1).AddSeconds(-1));

                    object sonuc = cmd.ExecuteScalar();

                    if (sonuc != DBNull.Value && sonuc != null)
                    {
                        decimal toplam = Convert.ToDecimal(sonuc);
                        return toplam.ToString("C2");
                    }
                }
                catch (Exception ex)
                {
                    // Hatanın tam olarak ne olduğunu görelim
                    MessageBox.Show("Hesaplama Detay Hatası: " + ex.Message);
                }
            }
            return "₺0,00";
        }

        public void StokDurumuHesapla(DateTime baslangic, DateTime bitis)
        {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();

                    // DÜZELTME: HareketID = 4 yerine 1 (Giriş), 2 (Çıkış) kullanıyoruz
                    string sorgu = @"
                SELECT 
                    ISNULL(SUM(CASE WHEN HareketID = 1 THEN Miktar ELSE 0 END), 0) AS ToplamGiris,
                    ISNULL(SUM(CASE WHEN HareketID = 2 THEN Miktar ELSE 0 END), 0) AS ToplamCikis,
                    ISNULL(SUM(CASE WHEN HareketID = 1 THEN Miktar ELSE 0 END) - 
                           SUM(CASE WHEN HareketID = 2 THEN Miktar ELSE 0 END), 0) AS ToplamFark
                FROM tblStokHareketleri
                WHERE Tarih BETWEEN @Baslangic AND @Bitis";

                    SqlCommand cmd = new SqlCommand(sorgu, baglan);
                    cmd.Parameters.AddWithValue("@Baslangic", baslangic.Date);
                    cmd.Parameters.AddWithValue("@Bitis", bitis.Date.AddDays(1).AddSeconds(-1));

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            // Artık veritabanındaki HareketID=1 olan kayıtları toplayacak
                            int giren = Convert.ToInt32(dr["ToplamGiris"]);
                            int cikan = Convert.ToInt32(dr["ToplamCikis"]);
                            int fark = Convert.ToInt32(dr["ToplamFark"]);

                            label3.Text = "Toplam Giriş Miktarı : " + giren.ToString();
                            label4.Text = "Toplam Çıkış Miktarı : " + cikan.ToString();
                            label5.Text = "Net Stok Farkı : " + fark.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hesaplama Hatası(Durum): " + ex.Message);
                }
            }
        }
        public void HareketleriListele(DateTime baslangicTarihi, DateTime bitisTarihi)
        {

            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();

                    // Sadece istenen sütunları SELECT kısmına yazdık (Aciklama YOK)
                    string sorgu = @"
    SELECT 
        sh.IslemID,
        sh.FaturaNo,
        u.UrunAd,           -- tblUrunler tablosundan geliyor
        ht.HareketAd,       -- tblHareketTipleri tablosundan geliyor (Oturum Açıldı hatasını çözer)
        k.KullaniciAdi,
        sh.Miktar,
        sh.Tarih
    FROM tblStokHareketleri sh
    INNER JOIN tblUrunler u ON sh.UrunID = u.UrunID
    INNER JOIN tblKullanicilar k ON sh.KullaniciID = k.KullaniciID
    INNER JOIN tblHareketTipleri ht ON sh.HareketID = ht.HareketID
    WHERE sh.Tarih BETWEEN @Tarih1 AND @Tarih2
    ORDER BY sh.Tarih DESC";

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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Listeleme hatası: " + ex.Message);
                }
                // Satırların daha ferah görünmesi için yüksekliği artır
                dataGridView1.RowTemplate.Height = 30;

                // Zebra deseni (Bir satır açık renk, diğeri beyaz)
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(242, 242, 242);

                // Başlık stilini özelleştir (Kendi yeşil tonunu kullanabilirsin)
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 94, 58); // Kavisli butonunla uyumlu yeşil
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(64, 94, 58);
            }
        }

        private void btnExcelAktar_Click(object sender, EventArgs e)
        {

        }

        private void kavisliButon1_Click(object sender, EventArgs e)
        {
            //HareketleriListele(dtpBaslangic.Value, dtpBitis.Value);
            StokHareketleriniListele(dtpBaslangic.Value, dtpBitis.Value);
            StokDurumuHesapla(dtpBaslangic.Value, dtpBitis.Value);

            String toplamTutar = TarihAraligiToplamTutarGetir(dtpBaslangic.Value, dtpBitis.Value);

            label6.Text = "Toplam Değeri : " + toplamTutar;
        }

        private void btnExcelAktar_Click_1(object sender, EventArgs e)
        { 

            // 1. Veri kontrolü
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Aktarılacak veri bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Dosya Kaydetme Diyaloğu (Kullanıcıya nereye kaydedeceğini soralım)
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel Dosyası |*.xlsx";
            saveFile.Title = "Raporu Kaydet";
            saveFile.FileName = "Stok_Raporu_" + DateTime.Now.ToString("dd_MM_yyyy");

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 3. Excel'i arka planda başlat
                    Type excelType = Type.GetTypeFromProgID("Excel.Application");
                    dynamic excelApp = Activator.CreateInstance(excelType);
                    excelApp.Visible = false; // İşlem bitene kadar gizli kalsın (daha hızlıdır)
                    dynamic workbook = excelApp.Workbooks.Add();
                    dynamic worksheet = workbook.ActiveSheet;
                    worksheet.Name = "Genel Rapor";

                    // 4. Başlıkları Aktar ve Biçimlendir
                    int excelSutun = 1;
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (dataGridView1.Columns[j].Visible)
                        {
                            dynamic cell = worksheet.Cells[1, excelSutun];
                            cell.Value = dataGridView1.Columns[j].HeaderText;
                            cell.Font.Bold = true; // Kalın yazı
                            cell.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(64, 94, 58)); // Senin yeşil tonun
                            cell.Font.Color = ColorTranslator.ToOle(Color.White); // Beyaz yazı
                            excelSutun++;
                        }
                    }

                    // 5. Verileri Aktar
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        excelSutun = 1;
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            if (dataGridView1.Columns[j].Visible)
                            {
                                worksheet.Cells[i + 2, excelSutun] = dataGridView1.Rows[i].Cells[j].Value?.ToString();
                                excelSutun++;
                            }
                        }
                    }

                    // 6. Sütun Genişliklerini Ayarla ve Kenarlık Ekle
                    dynamic allCells = worksheet.UsedRange;
                    allCells.Columns.AutoFit();
                    allCells.Borders.LineStyle = 1; // İnce kenarlıklar

                    // 7. Dosyayı Kaydet ve Kapat
                    workbook.SaveAs(saveFile.FileName);
                    excelApp.Visible = true; // İşlem bitince kullanıcıya göster

                    MessageBox.Show("Rapor başarıyla oluşturuldu ve kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excel profesyonel aktarım hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmGenelRaporlar_Load(object sender, EventArgs e)
        {
            // Form açıldığında son 1 ayın raporunu otomatik getir
            dtpBaslangic.Value = DateTime.Now.AddMonths(-1);
            dtpBitis.Value = DateTime.Now;

            // Raporu getiren butonun içindeki işlemleri başlat
            btnRaporGetir.PerformClick();
        }
    }

}
