using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace edts {
    public partial class frmUrunYonetimi : Form {
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

        public frmUrunYonetimi() {
            InitializeComponent();
            UrunListeGuncelle();
                    KategorileriYukle();

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {
            switch (tabControl1.SelectedIndex) {
                case 0:
                    UrunListeGuncelle();
                    KategorileriYukle();
                    break;
                case 1:
                    KategoriListeGuncelle();
                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }

        //------------------- ÜRÜN İŞLEMLERİ ------------------//
        private void btnKaydet_Click(object sender, EventArgs e) {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    baglan.Open();
                    SqlCommand cmdInsert = new SqlCommand("INSERT INTO tblUrunler (KategoriID, UrunKodu, UrunAd, KritikStok, MevcutStok, Durum, BirimFiyat) VALUES (@KategoriID, @UrunKodu, @UrunAd, @KritikStok, 0, 'yeni eklendi', 0)", baglan);
                    cmdInsert.Parameters.AddWithValue("@KategoriID", Convert.ToInt32(comboBoxKategori.SelectedValue));
                    cmdInsert.Parameters.AddWithValue("@UrunKodu", txtUrunKod.Text);
                    cmdInsert.Parameters.AddWithValue("@UrunAd", txtUrunAd.Text);
                    cmdInsert.Parameters.AddWithValue("@KritikStok", txtKritik.Text);
                    cmdInsert.ExecuteNonQuery();
                } catch (Exception ex) {
                    MessageBox.Show("Ürün kayıt edilemedi.\nHata: " + ex.Message);
                }
            }
            UrunListeGuncelle();
        }

        private void btnSil_Click(object sender, EventArgs e) {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    if (dataGridView1.SelectedRows.Count == 0) return;
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["UrunID"].Value);
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblUrunler WHERE UrunID = @id", baglan);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                } catch (Exception ex) {
                    MessageBox.Show("Ürün silinemedi. Hata: " + ex.Message);
                }
            }
            UrunListeGuncelle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e) {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["UrunID"].Value);
                    baglan.Open();

                    // SQL Sorgusu: ID'si eşleşen satırı bul ve diğer sütunları değiştir
                    string sorgu = @"UPDATE tblUrunler 
                             SET KategoriID = @KategoriID, 
                                 UrunKodu = @UrunKodu, 
                                 UrunAd = @UrunAd, 
                                 KritikStok = @KritikStok 
                             WHERE UrunID = @UrunID";

                    SqlCommand cmdUpdate = new SqlCommand(sorgu, baglan);

                    // 1. Kimi güncelliyoruz? (En önemli parametre)
                    cmdUpdate.Parameters.AddWithValue("@UrunID", id);

                    // 2. Yeni değerler neler? (Senin verdiğin kodlar)
                    cmdUpdate.Parameters.AddWithValue("@KategoriID", Convert.ToInt32(comboBoxKategori.SelectedValue));
                    cmdUpdate.Parameters.AddWithValue("@UrunKodu", txtUrunKod.Text);
                    cmdUpdate.Parameters.AddWithValue("@UrunAd", txtUrunAd.Text);

                    // Kritik Stok genelde sayıdır, çevirmekte fayda var
                    cmdUpdate.Parameters.AddWithValue("@KritikStok", Convert.ToInt32(txtKritik.Text));

                    // Komutu çalıştır
                    cmdUpdate.ExecuteNonQuery();

                } catch (Exception ex) {
                    MessageBox.Show("Güncelleme hatası: " + ex.Message);
                }
                UrunListeGuncelle();
            }
        }
        private void UrunListeGuncelle() {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    baglan.Open();

                    // 1. ADIM: SQL Sorgusunu INNER JOIN ile güncelledik
                    // "u" -> tblUrunler'in takma adı
                    // "k" -> tblKategoriler'in takma adı
                    string sorgu = @"
            SELECT 
                u.UrunID,
                u.UrunKodu,
                u.UrunAd,
                k.KategoriAd   -- Artık ID değil, İsim çekiyoruz
            FROM tblUrunler u
            INNER JOIN tblKategoriler k ON u.KategoriID = k.KategoriID";

                    SqlDataAdapter da = new SqlDataAdapter(sorgu, baglan);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Veriyi Gride Bağla
                    dataGridView1.DataSource = dt;

                    // 2. ADIM: Tablo Tasarım Ayarları (Kozmetik Düzenleme)

                    // ID sütununu gizle (Kullanıcı görmesin ama arka planda dursun)
                    if (dataGridView1.Columns["UrunID"] != null) {
                        dataGridView1.Columns["UrunID"].Visible = false;
                    }

                    // Başlıkları Türkçeleştir ve Düzenle
                    dataGridView1.Columns["UrunKodu"].HeaderText = "Ürün Kodu";
                    dataGridView1.Columns["UrunAd"].HeaderText = "Ürün Adı";
                    dataGridView1.Columns["KategoriAd"].HeaderText = "Kategori";

                    // Sütun genişliklerini otomatik sığdır
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                } catch (Exception ex) {
                    MessageBox.Show("Veri çekilemedi: " + ex.Message);
                }
            }
        }
        void KategorileriYukle() {
            using (SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString)) {
                try {
                    baglan.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT KategoriID, KategoriAd FROM tblKategoriler", baglan);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboBoxKategori.DisplayMember = "KategoriAd";
                    comboBoxKategori.ValueMember = "KategoriID";


                    comboBoxKategori.DataSource = dt;
                } catch (Exception ex) {
                    MessageBox.Show("Kategoriler yüklenirken hata: " + ex.Message);
                }
            }
        }
        public void UrunBilgileriniGetir(int id) {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    baglan.Open();

                    // Sadece güncellemede kullandığımız sütunları çekiyoruz
                    string sorgu = "SELECT UrunKodu, UrunAd, KategoriID, KritikStok FROM tblUrunler WHERE UrunID = @UrunID";

                    SqlCommand cmd = new SqlCommand(sorgu, baglan);
                    cmd.Parameters.AddWithValue("@UrunID", id);

                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        if (dr.Read()) // Eğer kayıt bulunduysa
                        {
                            // 1. Textboxları doldur
                            txtUrunKod.Text = dr["UrunKodu"].ToString();
                            txtUrunAd.Text = dr["UrunAd"].ToString();
                            txtKritik.Text = dr["KritikStok"].ToString();

                            // 2. ComboBox'ta o kategoriyi seçili hale getir (EN ÖNEMLİ KISIM)
                            // ComboBox'ın ValueMember özelliği "KategoriID" olduğu için direkt ID atıyoruz.
                            comboBoxKategori.SelectedValue = Convert.ToInt32(dr["KategoriID"]);
                        }
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Bilgiler getirilemedi: " + ex.Message);
                }
            }
        }

        //------------------- KATEGORİ İŞLEMLERİ ------------------//
        private void btnKategoriKaydet_Click(object sender, EventArgs e) {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    baglan.Open();

                    SqlCommand cmdInsert = new SqlCommand("INSERT INTO tblKategoriler (KategoriAd, KategoriAciklama) VALUES (@kat, @aci)", baglan);
                    cmdInsert.Parameters.AddWithValue("@kat", txtKategoriAdi.Text);
                    cmdInsert.Parameters.AddWithValue("@aci", txtKategoriAciklama.Text);
                    cmdInsert.ExecuteNonQuery();

                } catch (Exception ex) {
                    MessageBox.Show("Kategori eklenemedi.\nHata: " + ex.Message);
                }
            }

            txtKategoriAdi.Clear();
            txtKategoriAciklama.Clear();
            KategoriListeGuncelle();
        }

        private void btnKategoriGuncelle_Click(object sender, EventArgs e) {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    if (dataGridView1.SelectedRows.Count == 0) return;
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["KategoriID"].Value);
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE tblKategoriler SET KategoriAd = @ad, KategoriAcıklama = @aciklama WHERE KategoriID = @id", baglan);
                    cmd.Parameters.AddWithValue("@ad", txtKategoriAdi);
                    cmd.Parameters.AddWithValue("@aciklama", txtKategoriAciklama);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                } catch (Exception ex) {
                    MessageBox.Show("Kategori güncellenemedi. Hata: " + ex.Message);
                }
            }
            KategoriListeGuncelle();
        }

        private void btnKategoriSil_Click(object sender, EventArgs e) {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    if (dataGridView1.SelectedRows.Count == 0) return;
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["KategoriID"].Value);
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblKategoriler WHERE KategoriID = @id", baglan);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }catch (SqlException sqlEx) when (sqlEx.Number == 547) {
                    MessageBox.Show("Bu kategori silinemedi çünkü bu kategoriye ait ürünler mevcut. Lütfen önce ilgili ürünleri silin veya başka bir kategoriye taşıyın.");
                } catch (Exception ex) {
                    MessageBox.Show("Kategori silinemedi. Hata: " + ex.Message);
                }
            }
            KategoriListeGuncelle();
        }
        private void KategoriListeGuncelle() {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    baglan.Open();
                    string sorgu = "SELECT KategoriID, KategoriAd FROM tblKategoriler";

                    SqlDataAdapter da = new SqlDataAdapter(sorgu, baglan);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                } catch (Exception ex) {
                    MessageBox.Show("Veri çekilemedi: " + ex.Message);
                }
            }
        }

        private void kategoriBigiAl(int id, out string ad, out string aciklama) {
            ad = string.Empty;
            aciklama = string.Empty;
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("SELECT KategoriAd, KategoriAciklama FROM tblKategoriler WHERE KategoriID = @id", baglan);
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        if (dr.Read()) {
                            ad = dr["KategoriAd"].ToString();
                            aciklama = dr["KategoriAciklama"].ToString();
                        }
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Kategoriler yüklenirken hata: " + ex.Message);
                }
            }
        }

        //------------------- DataGridView Seçim İşlemleri ------------------//
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            switch (tabControl1.SelectedIndex) {
                case 0:
                    if (e.RowIndex >= 0) { 
                        UrunBilgileriniGetir(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["UrunID"].Value));
                    }
                    break;
                case 1:
                    if (e.RowIndex>=0) {
                        string ad = "", aciklama="";
                        kategoriBigiAl(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["KategoriID"].Value), out ad, out aciklama);
                        txtKategoriAdi.Text = ad;
                        txtKategoriAciklama.Text = aciklama;
                    }
                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }
    }
}
