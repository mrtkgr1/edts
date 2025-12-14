using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2010.Excel;
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
                    TedarikcileriListele();
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
                    if (dataGridView1.SelectedRows.Count == 0) {
                        MessageBox.Show("Kategori güncelleme ve silme işlemleri için listede ilgili satırın solundaki kutuya basarak tüm satırı seçiniz");
                        return;
                    }
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
                    if (dataGridView1.SelectedRows.Count == 0) {
                        MessageBox.Show("Kategori güncelleme ve silme işlemleri için listede ilgili satırın solundaki kutuya basarak tüm satırı seçiniz");
                        return;
                    }
                    if (dataGridView1.SelectedRows.Count == 0) return;
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["KategoriID"].Value);
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblKategoriler WHERE KategoriID = @id", baglan);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                } catch (SqlException sqlEx) when (sqlEx.Number == 547) {
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

        //------------------- Tedarikçi İşlemleri ------------------//

        private void btnTedarikciEkle_Click(object sender, EventArgs e) {
            if (txtFirmaAdi.Text.Trim() == "") { 
                MessageBox.Show("Firma Adı boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    baglan.Open();

                    string sorgu = @"INSERT INTO tblTedarikciler 
                             (TedarikciAd, VergiDairesi, VergiNo, IletisimTel) 
                             VALUES (@Ad, @VD, @VN, @Tel)";

                    SqlCommand cmd = new SqlCommand(sorgu, baglan);

                    // Parametreleri ekliyoruz
                    cmd.Parameters.AddWithValue("@Ad", txtFirmaAdi.Text);
                    cmd.Parameters.AddWithValue("@VD", txtVergiDairesi.Text);
                    cmd.Parameters.AddWithValue("@VN", txtVergiNo.Text);
                    cmd.Parameters.AddWithValue("@Tel", txtTelefon.Text);

                    cmd.ExecuteNonQuery();

                } catch (Exception ex) {
                    MessageBox.Show("Ekleme Hatası: " + ex.Message);
                }
            }
            TedarikcileriListele();
        }

        private void btnTedarikciGuncelle_Click(object sender, EventArgs e) {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    baglan.Open();

                    if (dataGridView1.SelectedRows.Count == 0) {
                        MessageBox.Show("Tedarikçi güncelleme ve silme işlemleri için listede ilgili satırın solundaki kutuya basarak tüm satırı seçiniz");
                        return;
                    }
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["TedarikciID"].Value);

                    string sorgu = @"UPDATE tblTedarikciler 
                             SET TedarikciAd = @Ad, 
                                 VergiDairesi = @VD, 
                                 VergiNo = @VN, 
                                 IletisimTel = @Tel 
                             WHERE TedarikciID = @ID";

                    SqlCommand cmd = new SqlCommand(sorgu, baglan);

                    cmd.Parameters.AddWithValue("@ID", id); 
                    cmd.Parameters.AddWithValue("@Ad", txtFirmaAdi.Text);
                    cmd.Parameters.AddWithValue("@VD", txtVergiDairesi.Text);
                    cmd.Parameters.AddWithValue("@VN", txtVergiNo.Text);
                    cmd.Parameters.AddWithValue("@Tel", txtTelefon.Text);

                    cmd.ExecuteNonQuery();

                } catch (Exception ex) {
                    MessageBox.Show("Güncelleme Hatası: " + ex.Message);
                }
            }
            TedarikcileriListele();
        }

        private void btnTedarikciSil_Click(object sender, EventArgs e) {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    baglan.Open();

                    if (dataGridView1.SelectedRows.Count == 0) {
                        MessageBox.Show("Tedarikçi güncelleme ve silme işlemleri için listede ilgili satırın solundaki kutuya basarak tüm satırı seçiniz");
                        return;
                    }
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["TedarikciID"].Value);

                    string sorgu = "DELETE FROM tblTedarikciler WHERE TedarikciID = @ID";

                    SqlCommand cmd = new SqlCommand(sorgu, baglan);
                    cmd.Parameters.AddWithValue("@ID", id);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Tedarikçi silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } catch (SqlException ex) {
                    if (ex.Number == 547) {
                        MessageBox.Show("Bu tedarikçiyi silemezsiniz çünkü sistemde kayıtlı ürünleri var. Önce ürünleri silmeli veya başka tedarikçiye aktarmalısınız.", "İlişki Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    } else {
                        MessageBox.Show("Silme Hatası: " + ex.Message);
                    }
                }
            }
            TedarikcileriListele();
        }

        public void TedarikcileriListele() {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    baglan.Open();

                    string sorgu = "SELECT TedarikciID, TedarikciAd, VergiDairesi, VergiNo, IletisimTel FROM tblTedarikciler";

                    SqlDataAdapter da = new SqlDataAdapter(sorgu, baglan);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;

                    // --- KOZMETİK AYARLAR ---

                    if (dataGridView1.Columns["TedarikciID"] != null)
                        dataGridView1.Columns["TedarikciID"].Visible = false;

                    dataGridView1.Columns["TedarikciAd"].HeaderText = "Firma Adı";
                    dataGridView1.Columns["VergiDairesi"].HeaderText = "Vergi Dairesi";
                    dataGridView1.Columns["VergiNo"].HeaderText = "Vergi No";
                    dataGridView1.Columns["IletisimTel"].HeaderText = "Telefon";

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                } catch (Exception ex) {
                    MessageBox.Show("Listeleme Hatası: " + ex.Message);
                }
            }
        }

        private void TedarikciBigiAl(int id, out string ad, out string verigiNo, out string vergiDairesi, out string tel) {
            ad = string.Empty;
            verigiNo = string.Empty;
            vergiDairesi = string.Empty;
            tel = string.Empty;
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("SELECT TedarikciAd, VergiDairesi, VergiNo, IletisimTel FROM tblTedarikciler WHERE TedarikciID = @id", baglan);
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        if (dr.Read()) {
                            ad = dr["TedarikciAd"].ToString();
                            vergiDairesi = dr["VergiDairesi"].ToString();
                            verigiNo = dr["VergiNo"].ToString();
                            tel = dr["IletisimTel"].ToString();
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
                    if (e.RowIndex >= 0) {
                        string ad = "", aciklama = "";
                        kategoriBigiAl(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["KategoriID"].Value), out ad, out aciklama);
                        txtKategoriAdi.Text = ad;
                        txtKategoriAciklama.Text = aciklama;
                    }
                    break;
                case 2:
                    if (e.RowIndex >= 0) {
                        string ad = "", aciklama = "";
                        TedarikciBigiAl(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["TedarikciID"].Value), out ad, out string vergiNo, out string vergiDairesi, out string tel);
                        txtFirmaAdi.Text = ad;
                        txtVergiDairesi.Text = vergiDairesi;
                        txtVergiNo.Text = vergiNo;
                        txtTelefon.Text = tel;
                    }
                    break;
                default:
                    break;
            }
        }

        private void lblAdres_Click(object sender, EventArgs e) {

        }
    }
}
