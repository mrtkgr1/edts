using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace edts
{
    public partial class frmAdminSistemAyarlari : Form
    {
        private System.Windows.Forms.Timer refreshTimer;
        public frmAdminSistemAyarlari()
        {


            InitializeComponent();

            // Timer'ı kurun
            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 50; // 50 milisaniye gecikme
            refreshTimer.Tick += RefreshTimer_Tick;
        }
        private void RefreshTimer_Tick(object? sender, EventArgs e)
        {
            refreshTimer.Stop(); // Timer'ı durdur (Tekrar tekrar çalışmasını engelle)

            // Görsel yenilemeyi tekrar zorla
            dgvHareketTipleri.Invalidate();
            dgvHareketTipleri.Update();

            // Ekranı da zorla yenileyelim
            this.Invalidate();
            this.Update();
        }
        private void AyarlariYukle()
        {
            // Ayar tablosundan verileri al
            DataTable dtAyarlar = VeritabaniYardimcisi.SistemAyarlariGetir();

            if (dtAyarlar != null && dtAyarlar.Rows.Count > 0)
            {
                DataRow ayar = dtAyarlar.Rows[0]; // İlk satırdaki veriyi al

                // 1. GENEL STOK YÖNETİM AYARLARI
                numKritikStok.Value = Convert.ToInt32(ayar["KritikStokEsigi"]);
                txtVarsayilanDepoKonum.Text = ayar["VarsayilanDepoAd"].ToString();

                // 2. KULLANICI GÜVENLİK AYARLARI (YENİ SÜTUNLAR)
                numSifreDegistirmeSuresi.Value = Convert.ToInt32(ayar["SifreGecerlilikGunu"]);
                numMaksimumGirisDenemesi.Value = Convert.ToInt32(ayar["GirisHataLimiti"]);
                numOturumZamanAsimi.Value = Convert.ToInt32(ayar["OturumZamanAsimiDk"]);

                // NOT: Varsayılan Birim Tipi ComboBox'ı doldurulmalıdır!
            }
        }
        private bool GenelAyarlariKaydet()
        {
            // Hata Kontrolleri
            if (txtVarsayilanDepoKonum.Text.Trim() == "")
            {
                MessageBox.Show("Varsayılan Depo Konumu boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Değerleri oku
            int kritikStok = (int)numKritikStok.Value;
            string varsayilanDepo = txtVarsayilanDepoKonum.Text.Trim();

            // GÜVENLİK AYARLARI DEĞERLERİ OKUNUYOR
            int sifreGecerlilikGunu = (int)numSifreDegistirmeSuresi.Value;
            int girisHataLimiti = (int)numMaksimumGirisDenemesi.Value;
            int oturumZamanAsimiDk = (int)numOturumZamanAsimi.Value;

            // Veritabanı Yardımıcısı metodu ile güncelle
            return VeritabaniYardimcisi.SistemAyarlariniKaydet(kritikStok, varsayilanDepo,
                                                             sifreGecerlilikGunu, girisHataLimiti, oturumZamanAsimiDk);
        }
        private void HareketTipleriniYukle()
        {
            string sorgu = "SELECT HareketID, HareketAd, CarpimFaktoru FROM tblHareketTipleri";
            DataTable dt = VeritabaniYardimcisi.DataTableGetir(sorgu);

            try
            {
                if (dt != null)
                {
                    // 1. Veriyi sadece ata (Yenileme işini Timer'a bırakıyoruz)
                    dgvHareketTipleri.DataSource = null;
                    dgvHareketTipleri.DataSource = dt;

                    // 2. Sütun Ayarları
                    if (dgvHareketTipleri.Columns.Count > 0)
                    {
                        if (dgvHareketTipleri.Columns.Contains("HareketID"))
                            dgvHareketTipleri.Columns["HareketID"].Visible = false;

                        if (dgvHareketTipleri.Columns.Contains("HareketAd"))
                            dgvHareketTipleri.Columns["HareketAd"].HeaderText = "Hareket Adı";

                        dgvHareketTipleri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }

                    // 3. KRİTİK: Timer'ı başlat (50ms gecikme ile görsel yenilemeyi tetikleyecek)
                    refreshTimer.Start();
                }
                else
                {
                    dgvHareketTipleri.DataSource = null; // Veri gelmezse DataGrid'i boşalt
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hareket Tipleri yüklenirken kritik bir hata oluştu. Detay: " + ex.Message, "Veri Yükleme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void SistemAyarlariniYukle()
        {
            DataTable dtAyarlar = VeritabaniYardimcisi.SistemAyarlariGetir();

            if (dtAyarlar != null && dtAyarlar.Rows.Count > 0)
            {
                DataRow ayarSatiri = dtAyarlar.Rows[0];
                decimal tempValue; // Dönüşüm için geçici değişken

                // 1. Kritik Stok (kritikstok)
                if (ayarSatiri["kritikstok"] != DBNull.Value)
                {
                    if (decimal.TryParse(ayarSatiri["kritikstok"].ToString(), out tempValue))
                    {
                        numKritikStok.Value = tempValue;
                    }
                }

                // 2. Varsayılan Depo Adı (VarsayilanDepoAd)
                txtVarsayilanDepoKonum.Text = ayarSatiri["VarsayilanDepoAd"].ToString();

                // 3. Şifre Geçerlilik Günü (sifregun)
                if (ayarSatiri["sifregun"] != DBNull.Value)
                {
                    if (decimal.TryParse(ayarSatiri["sifregun"].ToString(), out tempValue))
                    {
                        numSifreDegistirmeSuresi.Value = tempValue;
                    }
                }

                // 4. Maksimum Giriş Denemesi (girishata)
                if (ayarSatiri["girishata"] != DBNull.Value)
                {
                    if (decimal.TryParse(ayarSatiri["girishata"].ToString(), out tempValue))
                    {
                        numMaksimumGirisDenemesi.Value = tempValue;
                    }
                }

                // 5. Oturum Zaman Aşımı (oturumzaman)
                if (ayarSatiri["oturumzaman"] != DBNull.Value)
                {
                    if (decimal.TryParse(ayarSatiri["oturumzaman"].ToString(), out tempValue))
                    {
                        numOturumZamanAsimi.Value = tempValue;
                    }
                }
            }
            else
            {
                MessageBox.Show("Sistem Ayarları veritabanından yüklenemedi. Lütfen SQL veritabanında AyarID=1 olan satırın varlığını ve sütun adlarını kontrol edin.", "Kritik Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAdminSistemAyarlari_Load(object sender, EventArgs e)
        {
            // 1. Manuel Birim Tiplerini ComboBox'a Ekleme
            cmbVarsayilanBirimTip.Items.Add("Adet");
            cmbVarsayilanBirimTip.Items.Add("Koli");
            cmbVarsayilanBirimTip.Items.Add("Kutu");
            cmbVarsayilanBirimTip.Items.Add("Kilogram (KG)");
            cmbVarsayilanBirimTip.Items.Add("Litre (LT)");

            // Başlangıçta ilk değeri seçelim
            if (cmbVarsayilanBirimTip.Items.Count > 0)
            {
                cmbVarsayilanBirimTip.SelectedIndex = 0;
            }

            // 2. Sistem Ayarlarını Yükleme (Bu kısım sizde zaten olmalı)
            SistemAyarlariniYukle();

            // 3. Hareket Tiplerini Yükleme (Bu kısım sizde zaten olmalı)
            HareketTipleriniYukle();
        }

        private void btnHareketTipiEkle_Click(object sender, EventArgs e)
        {
            string yeniHareketAd = txtHareketTipiAd.Text.Trim();
            if (string.IsNullOrEmpty(yeniHareketAd))
            {
                MessageBox.Show("Lütfen yeni hareket tipinin adını giriniz.", "Uyarı");
                return;
            }

            // Varsayım: Yeni eklenen hareket tipini stok "Girişi" olarak kabul ediyoruz (Değer = 1).
            // Eğer formunuzda Giriş/Çıkış seçimi varsa, o değeri almalısınız.
            int carpimFaktoru = 1;

            // KRİTİK DÜZELTME: Tablo adını ve zorunlu CarpimFaktoru sütununu ekledik.
            string sorgu = "INSERT INTO tblHareketTipleri (HareketAd, CarpimFaktoru) VALUES (@pHareketAd, @pCarpimFaktoru)";

            // Microsoft.Data.SqlClient'e uygun SqlParameter[] tanımı
            SqlParameter[] parametreler = new SqlParameter[]
            {
        new SqlParameter("@pHareketAd", yeniHareketAd),
        new SqlParameter("@pCarpimFaktoru", carpimFaktoru)
            };

            if (VeritabaniYardimcisi.ExecuteNonQuery(sorgu, parametreler))
            {
                MessageBox.Show("Hareket tipi başarıyla eklendi.", "Başarılı");
                HareketTipleriniYukle();
                txtHareketTipiAd.Clear();
            }
            else
            {
                // Eğer bu hatayı almaya devam ediyorsanız, sorun artık sorguda veya bağlantıda değil,
                // parametrelerin ExecuteNonQuery metodunda doğru eklenmesindedir.
                MessageBox.Show("Ekleme başarısız oldu. Lütfen veritabanı bağlantı dizesini kontrol edin.", "Hata");
            }
        }

        private void btnHareketTipiSil_Click(object sender, EventArgs e)
        {
            // 1. Seçili satırı kontrol etme
            if (dgvHareketTipleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz hareketi listeden seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Hareket ID'sini alma
            // DataGridView'da "HareketID" sütununun gizli olduğunu varsayıyoruz.
            int hareketID = Convert.ToInt32(dgvHareketTipleri.SelectedRows[0].Cells["HareketID"].Value);
            string hareketAd = dgvHareketTipleri.SelectedRows[0].Cells["HareketAd"].Value.ToString();

            // 3. Kullanıcıdan Onay Alma
            DialogResult onay = MessageBox.Show(
                $"{hareketAd} adlı hareket tipini kalıcı olarak silmek istediğinizden emin misiniz? Bu işlem geri alınamaz.",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (onay == DialogResult.Yes)
            {
                // 4. SQL Sorgusu ve Parametre
                string sorgu = "DELETE FROM tblHareketTipleri WHERE HareketID = @pHareketID";

                // Microsoft.Data.SqlClient kullandığınızı varsayarak:
                SqlParameter[] parametreler = new SqlParameter[]
                {
            new SqlParameter("@pHareketID", hareketID)
                };

                // 5. Silme İşlemini Gerçekleştirme
                if (VeritabaniYardimcisi.ExecuteNonQuery(sorgu, parametreler))
                {
                    MessageBox.Show("Hareket tipi başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // DataGridView'ı güncelle
                    HareketTipleriniYukle();
                }
                else
                {
                    // Genellikle bu hata, hareket tipinin başka bir tabloda (örn: StokHareketleri) kullanılıyor olmasından kaynaklanır.
                    MessageBox.Show("Hareket tipi silinirken bir hata oluştu veya bu hareket tipi başka kayıtlarda kullanılıyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAyarlariKaydet_Click(object sender, EventArgs e)
        {
            // Bu kısım, butona basıldığında çalışacak kod bloğudur.
            // Gerekli verileri NumericUpDown ve TextBox'lardan alıyoruz.

            // 1. Değerleri form kontrollerinden alma
            int kritikStok = (int)numKritikStok.Value;

            // NOT: Veritabanı sütun adı: 'varsayilandepo' veya 'varsayilandepoad' (Küçük harf)
            string varsayilanDepoAd = txtVarsayilanDepoKonum.Text.Trim();

            int sifreGecerlilikGunu = (int)numSifreDegistirmeSuresi.Value;
            int girisHataLimiti = (int)numMaksimumGirisDenemesi.Value;
            int oturumZamanAsimiDk = (int)numOturumZamanAsimi.Value;

            // 2. Veritabanı Yardımcısı metodu ile kaydetme işlemini çağırma
            bool sonuc = VeritabaniYardimcisi.SistemAyarlariniKaydet(
                kritikStok,
                varsayilanDepoAd,
                sifreGecerlilikGunu,
                girisHataLimiti,
                oturumZamanAsimiDk
            );

            // 3. Sonuca göre kullanıcıyı bilgilendirme
            if (sonuc)
            {
                MessageBox.Show("Sistem ayarları başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SistemAyarlariniYukle(); // Kaydettikten sonra formdaki verileri yenile
            }
            else
            {
                // SistemAyarlariniKaydet metodunun içindeki hata mesajı burada gösterilebilir, 
                // ya da genel bir hata mesajı verilir.
                MessageBox.Show("Ayarlar kaydedilirken bir sorun oluştu. Detaylar için 'VeritabaniYardimcisi.cs' dosyasındaki hata mesajlarını kontrol edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
