using Microsoft.Data.SqlClient; // SQL kütüphanesini ekleyin
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; // ConfigurationManager için ekleyin
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel; // XLSX işlemleri için yeni kütüphane
using System.IO;       // StreamWriter yerine bu gerekli

namespace edts
{
    public partial class frmAdminDenetimKayitlari : Form
    {
        public frmAdminDenetimKayitlari()
        {
            InitializeComponent();
        }
        private void KullaniciSecimleriniDoldur()
        {
            try
            {
                string baglantiDizesi = System.Configuration.ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
                // KullanıcıID ve KullaniciAdi çekiliyor
                string sorgu = "SELECT KullaniciID, KullaniciAdi FROM tblKullanicilar ORDER BY KullaniciAdi";

                using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
                {
                    SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // "Tümü" seçeneğini ekle (ID=0 ile filtreleme kolaylığı için)
                    DataRow tumuRow = dt.NewRow();
                    tumuRow["KullaniciID"] = 0;
                    tumuRow["KullaniciAdi"] = "Tümü";
                    dt.Rows.InsertAt(tumuRow, 0);

                    cmbKullaniciSecim.DisplayMember = "KullaniciAdi";
                    cmbKullaniciSecim.ValueMember = "KullaniciID";
                    cmbKullaniciSecim.DataSource = dt;
                    cmbKullaniciSecim.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı listesi yüklenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HareketTipleriniDoldur()
        {
            try
            {
                string baglantiDizesi = System.Configuration.ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
                // HareketID ve HareketAd çekiliyor
                string sorgu = "SELECT HareketID, HareketAd FROM tblHareketTipleri ORDER BY HareketAd";

                using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
                {
                    SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // "Tümü" seçeneğini ekle (ID=0 ile filtreleme kolaylığı için)
                    DataRow tumuRow = dt.NewRow();
                    tumuRow["HareketID"] = 0;
                    tumuRow["HareketAd"] = "Tümü";
                    dt.Rows.InsertAt(tumuRow, 0);

                    cmbHareketTipi.DisplayMember = "HareketAd";
                    cmbHareketTipi.ValueMember = "HareketID";
                    cmbHareketTipi.DataSource = dt;
                    cmbHareketTipi.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hareket tipleri yüklenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void KayitlariGetir()
        {
            try
            {
                // Bağlantı dizesini App.config'den okur
                string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

                // Başlangıç ve Bitiş Tarihlerini al
                // Başlangıç tarihi için günün en başı (00:00:00)
                DateTime baslangicTarihi = dtpBaslangic.Value.Date;
                // Bitiş tarihi için günün en sonu (23:59:59)
                DateTime bitisTarihi = dtpBitis.Value.Date.AddDays(1).AddSeconds(-1);

                // Hareket Tipi ID'sini ComboBox'tan al
                // Eğer "Tümü" seçiliyse (SelectedIndex 0 ise) veya seçili bir şey yoksa, null/boş ID kullanırız.
                int? hareketID = null;
                if (cmbHareketTipi.SelectedIndex > 0 && cmbHareketTipi.SelectedValue != null)
                {
                    // SelectedValue, HareketID'yi tutar
                    if (int.TryParse(cmbHareketTipi.SelectedValue.ToString(), out int id))
                    {
                        hareketID = id;
                    }
                }

                // 1. SQL Sorgusu: Şartlı WHERE koşulları için başlangıç ve bitiş tarihini ekliyoruz.
                // Ayrıca tblKullanicilar ve tblHareketTipleri ile JOIN yapıyoruz.
                string sorgu = @"
                SELECT
                    D.LogID,
                    D.IslemTarihi,
                    K.KullaniciAdi,
                    H.HareketAd,
                    D.TabloAdi,
                    D.Aciklama
                FROM 
                    tblDenetimKayitlari D
                INNER JOIN 
                    tblKullanicilar K ON D.KullaniciID = K.KullaniciID
                INNER JOIN 
                    tblHareketTipleri H ON D.HareketID = H.HareketID
                WHERE 
                    D.IslemTarihi >= @pBaslangicTarihi 
                    AND D.IslemTarihi <= @pBitisTarihi";

                // Hareket ID filtresi varsa sorguya ekle
                if (hareketID.HasValue)
                {
                    sorgu += " AND D.HareketID = @pHareketID";
                }

                sorgu += " ORDER BY D.IslemTarihi DESC"; // Son kayıtlar üstte çıksın

                using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
                {
                    using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                    {
                        // 2. Parametreleri Ekle
                        komut.Parameters.AddWithValue("@pBaslangicTarihi", baslangicTarihi);
                        komut.Parameters.AddWithValue("@pBitisTarihi", bitisTarihi);

                        if (hareketID.HasValue)
                        {
                            komut.Parameters.AddWithValue("@pHareketID", hareketID.Value);
                        }

                        SqlDataAdapter da = new SqlDataAdapter(komut);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // 3. DataGridView'ı doldur
                        dgvDenetimKayitlari.DataSource = dt;

                        // Başlıkları yeniden düzenle (isteğe bağlı)
                        if (dgvDenetimKayitlari.Columns.Count > 0)
                        {
                            dgvDenetimKayitlari.Columns["LogID"].Visible = false; // LogID'yi gizle
                            dgvDenetimKayitlari.Columns["IslemTarihi"].HeaderText = "İşlem Tarihi";
                            dgvDenetimKayitlari.Columns["KullaniciAdi"].HeaderText = "Kullanıcı Adı";
                            dgvDenetimKayitlari.Columns["HareketAd"].HeaderText = "Hareket Tipi";
                            dgvDenetimKayitlari.Columns["TabloAdi"].HeaderText = "Tablo";
                            dgvDenetimKayitlari.Columns["Aciklama"].HeaderText = "Açıklama";

                            // Sütun boyutlarını otomatik ayarla
                            dgvDenetimKayitlari.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıtları getirirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnKayitlariGetir_Click(object sender, EventArgs e)
        {
            // Tarih, Kullanıcı ve Hareket Tipi filtrelerine göre verileri yeniler.
            KayitlariGetir();
        }

        private void btnExcelAktar_Click(object sender, EventArgs e)
        {
            // 1. DataGridView'de veri olup olmadığını kontrol et
            if (dgvDenetimKayitlari.Rows.Count == 0 || dgvDenetimKayitlari.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow || r.Visible == false))
            {
                MessageBox.Show("Aktarılacak kayıt bulunmamaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kullanıcıdan dosyayı nereye kaydedeceğini sor
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            // Filtreyi sadece XLSX olarak ayarla
            saveFileDialog.Filter = "Excel Dosyaları (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = "DenetimKayitlari_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Yeni kütüphaneyi kullanmak için üst kısımlara ekleyin: using ClosedXML.Excel;

                    // 3. DataGridView verilerini DataTable'a aktar
                    DataTable dt = new DataTable();

                    // Başlıkları (Sütunları) ekle
                    foreach (DataGridViewColumn column in dgvDenetimKayitlari.Columns)
                    {
                        // Gizli sütunları (LogID gibi) ve görünmezleri atla
                        if (column.Visible)
                        {
                            dt.Columns.Add(column.HeaderText);
                        }
                    }

                    // Satır verilerini ekle
                    foreach (DataGridViewRow row in dgvDenetimKayitlari.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            DataRow newRow = dt.NewRow();
                            int dtColumnIndex = 0;

                            for (int i = 0; i < dgvDenetimKayitlari.Columns.Count; i++)
                            {
                                if (dgvDenetimKayitlari.Columns[i].Visible)
                                {
                                    newRow[dtColumnIndex] = row.Cells[i].Value;
                                    dtColumnIndex++;
                                }
                            }
                            dt.Rows.Add(newRow);
                        }
                    }

                    // 4. ClosedXML kullanarak Excel dosyasını oluştur ve kaydet
                    using (var wb = new XLWorkbook())
                    {
                        // DataTable'ı Çalışma Sayfası olarak ekle
                        var ws = wb.Worksheets.Add(dt, "Denetim Kayıtları");

                        // İlk satırı (Başlıkları) kalın yap
                        ws.Row(1).Style.Font.Bold = true;

                        // Sütunları içeriğe göre otomatik boyutlandır
                        ws.Columns().AdjustToContents();

                        // Dosyayı kaydet
                        wb.SaveAs(saveFileDialog.FileName);
                    }

                    MessageBox.Show("Kayıtlar başarıyla XLSX formatında Excel dosyasına aktarıldı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excel'e aktarım sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       

        private void frmAdminDenetimKayitlari_Load_1(object sender, EventArgs e)
        {
            
            // 1. ComboBox'ları doldur (Bu, formun boş görünmesini engeller)
            KullaniciSecimleriniDoldur();
            HareketTipleriniDoldur();

            // 2. Varsayılan kayıtları getir
            KayitlariGetir();
        }
    }
    }

