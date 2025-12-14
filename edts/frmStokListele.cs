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
using System.Configuration;

namespace EnvanterDepoSistemitaslak2
{
    public partial class frmStokListele : Form
    {
        public frmStokListele()
        {
            InitializeComponent();
        }
        private void VerileriDoldur()
        {
            // Kategori ComboBox'ını Doldur
            string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

            // 1. Kategori ComboBox'ı (tblKategoriler)
            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    string kategoriSorgu = "SELECT KategoriID, KategoriAd FROM tblKategoriler ORDER BY KategoriAd";
                    DataTable dtKategori = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(kategoriSorgu, baglanti))
                    {
                        da.Fill(dtKategori);
                    }

                    // "Tümü" seçeneğini ekle
                    DataRow tumuRow = dtKategori.NewRow();
                    tumuRow["KategoriID"] = 0; // Filtrede 0, tümünü seçecek
                    tumuRow["KategoriAd"] = "Tümü";
                    dtKategori.Rows.InsertAt(tumuRow, 0);

                    // cmbKategoriFiltresi bileşenine bağlama
                    cmbKategoriFiltresi.DataSource = dtKategori;
                    cmbKategoriFiltresi.DisplayMember = "KategoriAd";
                    cmbKategoriFiltresi.ValueMember = "KategoriID";
                    cmbKategoriFiltresi.SelectedIndex = 0; // "Tümü" seçili gelsin
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kategori verileri yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // 2. Durum Filtresi (cmbDurumFiltresi) - Sabit Değerler
            if (cmbDurumFiltresi.Items.Count == 0)
            {
                cmbDurumFiltresi.Items.Add("Tümü");
                cmbDurumFiltresi.Items.Add("Normal");
                cmbDurumFiltresi.Items.Add("Kritik Seviye");
            }
            cmbDurumFiltresi.SelectedIndex = 0;
        }
        private void StoklariListele(string aramaMetni = "", int kategoriID = 0, string durumFiltresi = "")
        {
            string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

            // NOT: tblBirimler tablosunun var olduğunu varsayıyoruz.
            string sorgu = @"
        SELECT
            U.UrunID,
            U.UrunAd,
            U.MevcutStok,
            C.KategoriAd,
            B.BirimAd,
            U.KritikStok,
            CASE 
                WHEN U.MevcutStok <= U.KritikStok THEN 'Kritik Seviye'
                ELSE 'Normal'
            END AS StokDurumu
        FROM 
            tblUrunler U
        INNER JOIN 
            tblKategoriler C ON U.KategoriID = C.KategoriID
        LEFT JOIN  -- *** DEĞİŞİKLİK BURADA ***
            tblBirimler B ON U.BirimID = B.BirimID
        WHERE 1=1 ";

            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            {
                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    // FİLTRE KOŞULLARI

                    // 1. Arama Filtresi (txtArama)
                    if (!string.IsNullOrEmpty(aramaMetni))
                    {
                        komut.CommandText += " AND U.UrunAd LIKE @AramaMetni ";
                        komut.Parameters.AddWithValue("@AramaMetni", "%" + aramaMetni + "%");
                    }

                    // 2. Kategori Filtresi (cmbKategoriFiltresi)
                    if (kategoriID > 0)
                    {
                        komut.CommandText += " AND U.KategoriID = @KategoriID ";
                        komut.Parameters.AddWithValue("@KategoriID", kategoriID);
                    }

                    // 3. Durum Filtresi (cmbDurumFiltresi)
                    if (!string.IsNullOrEmpty(durumFiltresi) && durumFiltresi != "Tümü")
                    {
                        // Kritik veya Normal durumu filtrele
                        if (durumFiltresi == "Kritik Seviye")
                        {
                            komut.CommandText += " AND U.MevcutStok <= U.KritikStok ";
                        }
                        else if (durumFiltresi == "Normal")
                        {
                            komut.CommandText += " AND U.MevcutStok > U.KritikStok ";
                        }
                    }

                    komut.CommandText += " ORDER BY U.UrunAd";

                    try
                    {
                        SqlDataAdapter da = new SqlDataAdapter(komut);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // *** KRİTİK ADIM ***
                        dgvStoklar.DataSource = dt;
                        dgvStoklar.Refresh(); // DataGridView'i güncellemeyi zorla

                        if (dt.Rows.Count == 0)
                        {
                            // Listede kayıt yoksa kullanıcıyı bilgilendir
                            MessageBox.Show("Filtreleme kriterlerine uygun ürün bulunamadı. Lütfen filtreleri kontrol edin.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        // *** GEÇİCİ ÇÖZÜM: GÖRÜNÜM AYARLARINI DEVRE DIŞI BIRAKMA ***
                        // Eğer veriler görünmüyorsa, sorun DGV sütunlarının adlarında olabilir.
                        // Bu kısmı yorum satırı yapın ve AutoGenerateColumns=True olduğundan emin olun.
                        /*
                        dgvStoklar.Columns["UrunID"].Visible = false;
                        dgvStoklar.Columns["UrunAd"].HeaderText = "Ürün Adı";
                        dgvStoklar.Columns["MevcutStok"].HeaderText = "Stok";
                        dgvStoklar.Columns["KategoriAd"].HeaderText = "Kategori";
                        dgvStoklar.Columns["BirimAd"].HeaderText = "Birim";
                        dgvStoklar.Columns["KritikStok"].HeaderText = "Kritik Sınır";
                        dgvStoklar.Columns["StokDurumu"].HeaderText = "Durum";
                        */

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Stok listesi yüklenirken veritabanı hatası oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void frmStokListele_Load(object sender, EventArgs e)
        {
            // 1. Filtre ComboBox'larını Doldur
            VerileriDoldur(); // Bu metot cmbKategoriFiltresi ve cmbDurumFiltresi'ni doldurur.

            // 2. KRİTİK ADIM: FİLTRE DEĞERLERİNİ 'TÜMÜ' OLARAK AYARLAMA
            // cmbKategoriFiltresi ve cmbDurumFiltresi'nin ilk elemanının ("Tümü") olduğunu varsayıyoruz.
            if (cmbKategoriFiltresi.Items.Count > 0)
            {
                cmbKategoriFiltresi.SelectedIndex = 0;
            }
            if (cmbDurumFiltresi.Items.Count > 0)
            {
                cmbDurumFiltresi.SelectedIndex = 0;
            }

            // Arama kutusunu da temizleyelim.
            txtArama.Text = string.Empty;

            // 3. Listelemeyi Başlat
            StoklariListele();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            // Bileşenlerden değerleri okuma
            string aramaMetni = txtArama.Text.Trim();

            // Kategori ID'yi oku: SelectedValue null değilse oku, null ise 0 yap.
            int kategoriID = 0;
            if (cmbKategoriFiltresi.SelectedValue != null &&
                cmbKategoriFiltresi.SelectedValue != DBNull.Value)
            {
                // SelectedValue'nun int olduğunu varsayıyoruz.
                kategoriID = Convert.ToInt32(cmbKategoriFiltresi.SelectedValue);
            }

            // NOT: Eğer "Tümü" seçeneği (örneğin 0 ID'li) cmb'ye elle eklendiyse ve 
            // SelectedValue'su 0 ise, bu kod çalışır.

            string durumFiltresi = cmbDurumFiltresi.Text;

            // Listeleme metodunu filtrelerle çağırma
            StoklariListele(aramaMetni, kategoriID, durumFiltresi);
        }

       
    }

}
