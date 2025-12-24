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
                case 3:
                    musteriListele();
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
                    SqlCommand cmdInsert = new SqlCommand("INSERT INTO tblUrunler (KategoriID, UrunKodu, UrunAd, KritikStok, MevcutStok, Durum, BirimFiyat) VALUES (@KategoriID, @UrunKodu, @UrunAd, @KritikStok, 0, 'yeni eklendi', @BirimFiyat)", baglan);
                    cmdInsert.Parameters.AddWithValue("@KategoriID", Convert.ToInt32(comboBoxKategori.SelectedValue));
                    cmdInsert.Parameters.AddWithValue("@UrunKodu", txtUrunKod.Text);
                    cmdInsert.Parameters.AddWithValue("@UrunAd", txtUrunAd.Text);
                    cmdInsert.Parameters.AddWithValue("@KritikStok", txtKritik.Text);
                    cmdInsert.Parameters.AddWithValue("@BirimFiyat", Convert.ToInt32(birimFiyat.Value));
                    cmdInsert.ExecuteNonQuery();
                    VeritabaniYardimcisi.LogKaydet(
    kullaniciID: AktifKullanici.ID,
    hareketID: 5,
    tabloAdi: "tblUrunler",
    aciklama: $"{txtUrunAd.Text} adlı ürün eklendi."
);
                } catch (Exception ex) {
                    MessageBox.Show("Ürün kayıt edilemedi.\nHata: " + ex.Message);
                }
            }
            UrunListeGuncelle();

        }

        private void btnSil_Click(object sender, EventArgs e) {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    if (dataGridView2.SelectedRows.Count == 0) {
                        MessageBox.Show("Kategori güncelleme ve silme işlemleri için listede ilgili satırın solundaki kutuya basarak tüm satırı seçiniz");
                        return;
                    }
                    if (dataGridView2.SelectedRows.Count == 0) return;
                    int id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["UrunID"].Value);
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblUrunler WHERE UrunID = @id", baglan);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    VeritabaniYardimcisi.LogKaydet(AktifKullanici.ID, 5, "tblUrunler", $"{txtUrunAd.Text} adlı ürün silindi." );
                } catch (Exception ex) {
                    MessageBox.Show("Ürün silinemedi. Hata: " + ex.Message);
                }
            }
            UrunListeGuncelle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e) {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    if (dataGridView2.SelectedRows.Count == 0) {
                        MessageBox.Show("Ürün güncelleme ve silme işlemleri için listede ilgili satırın solundaki kutuya basarak tüm satırı seçiniz");
                        return;
                    }
                    int id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["UrunID"].Value);
                    baglan.Open();

                    // SQL Sorgusu: ID'si eşleşen satırı bul ve diğer sütunları değiştir
                    string sorgu = @"UPDATE tblUrunler 
                             SET KategoriID = @KategoriID, 
                                 UrunKodu = @UrunKodu, 
                                 UrunAd = @UrunAd, 
                                 KritikStok = @KritikStok,
                                 BirimFiyat = @BirimFiyat
                             WHERE UrunID = @UrunID";

                    SqlCommand cmdUpdate = new SqlCommand(sorgu, baglan);

                    cmdUpdate.Parameters.AddWithValue("@UrunID", id);

                    cmdUpdate.Parameters.AddWithValue("@KategoriID", Convert.ToInt32(comboBoxKategori.SelectedValue));
                    cmdUpdate.Parameters.AddWithValue("@UrunKodu", txtUrunKod.Text);
                    cmdUpdate.Parameters.AddWithValue("@UrunAd", txtUrunAd.Text);
                    cmdUpdate.Parameters.AddWithValue("@BirimFiyat", Convert.ToInt32(birimFiyat.Value));


                    cmdUpdate.Parameters.AddWithValue("@KritikStok", Convert.ToInt32(txtKritik.Text));

                    // Komutu çalıştır
                    cmdUpdate.ExecuteNonQuery();

                VeritabaniYardimcisi.LogKaydet(AktifKullanici.ID, 5, "tblUrunler", $"{txtUrunAd.Text} adlı ürün güncellendi.");
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

                    string sorgu = @"
            SELECT 
                u.UrunID,
                u.UrunKodu,
                u.UrunAd,
                u.BirimFiyat,
                k.KategoriAd   -- Artık ID değil, İsim çekiyoruz
            FROM tblUrunler u
            INNER JOIN tblKategoriler k ON u.KategoriID = k.KategoriID";

                    SqlDataAdapter da = new SqlDataAdapter(sorgu, baglan);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView2.DataSource = dt;

                    if (dataGridView2.Columns["UrunID"] != null) {
                        dataGridView2.Columns["UrunID"].Visible = false;
                    }

                    dataGridView2.Columns["UrunKodu"].HeaderText = "Ürün Kodu";
                    dataGridView2.Columns["UrunAd"].HeaderText = "Ürün Adı";
                    dataGridView2.Columns["KategoriAd"].HeaderText = "Kategori";

                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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

                    string sorgu = "SELECT UrunKodu, UrunAd, KategoriID, KritikStok, BirimFiyat FROM tblUrunler WHERE UrunID = @UrunID";

                    SqlCommand cmd = new SqlCommand(sorgu, baglan);
                    cmd.Parameters.AddWithValue("@UrunID", id);

                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        if (dr.Read()) 
                        {
                            txtUrunKod.Text = dr["UrunKodu"].ToString();
                            txtUrunAd.Text = dr["UrunAd"].ToString();
                            txtKritik.Text = dr["KritikStok"].ToString();

                            comboBoxKategori.SelectedValue = Convert.ToInt32(dr["KategoriID"]);
                     
                            birimFiyat.Value = Convert.ToDecimal(dr["BirimFiyat"]);
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

                    VeritabaniYardimcisi.LogKaydet(
                        kullaniciID: AktifKullanici.ID,
                        hareketID: 6,
                        tabloAdi: "tblKategoriler",
                        aciklama: $"{txtKategoriAdi.Text} adlı kategori eklendi."
                    );
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
                    if (dataGridView2.SelectedRows.Count == 0) {
                        MessageBox.Show("Kategori güncelleme ve silme işlemleri için listede ilgili satırın solundaki kutuya basarak tüm satırı seçiniz");
                        return;
                    }
                    int id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["KategoriID"].Value);
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE tblKategoriler SET KategoriAd = @ad, KategoriAcıklama = @aciklama WHERE KategoriID = @id", baglan);
                    cmd.Parameters.AddWithValue("@ad", txtKategoriAdi);
                    cmd.Parameters.AddWithValue("@aciklama", txtKategoriAciklama);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    VeritabaniYardimcisi.LogKaydet(
                        kullaniciID: AktifKullanici.ID,
                        hareketID: 6,
                        tabloAdi: "tblKategoriler",
                        aciklama: $"{txtKategoriAdi.Text} adlı kategori güncellendi."
                    );
                } catch (Exception ex) {
                    MessageBox.Show("Kategori güncellenemedi. Hata: " + ex.Message);
                }
            }
            KategoriListeGuncelle();
        }

        private void btnKategoriSil_Click(object sender, EventArgs e) {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    if (dataGridView2.SelectedRows.Count == 0) {
                        MessageBox.Show("Kategori güncelleme ve silme işlemleri için listede ilgili satırın solundaki kutuya basarak tüm satırı seçiniz");
                        return;
                    }
                    if (dataGridView2.SelectedRows.Count == 0) return;
                    int id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["KategoriID"].Value);
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblKategoriler WHERE KategoriID = @id", baglan);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    VeritabaniYardimcisi.LogKaydet(
                        kullaniciID: AktifKullanici.ID,
                        hareketID: 6,
                        tabloAdi: "tblKategoriler",
                        aciklama: $"{txtKategoriAdi.Text} adlı kategori silindi."
                    );
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

                    dataGridView2.DataSource = dt;
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

                VeritabaniYardimcisi.LogKaydet(
                    kullaniciID: AktifKullanici.ID,
                    hareketID: 8,
                    tabloAdi: "tblTedarikciler",
                    aciklama: $"{txtFirmaAdi.Text} adlı tedarikçi eklendi."
                );
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

                    if (dataGridView2.SelectedRows.Count == 0) {
                        MessageBox.Show("Tedarikçi güncelleme ve silme işlemleri için listede ilgili satırın solundaki kutuya basarak tüm satırı seçiniz");
                        return;
                    }
                    int id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["TedarikciID"].Value);

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

                    VeritabaniYardimcisi.LogKaydet(
                        kullaniciID: AktifKullanici.ID,
                        hareketID: 8,
                        tabloAdi: "tblTedarikciler",
                        aciklama: $"{txtFirmaAdi.Text} adlı tedarikçi güncellendi."
                    );
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

                    if (dataGridView2.SelectedRows.Count == 0) {
                        MessageBox.Show("Tedarikçi güncelleme ve silme işlemleri için listede ilgili satırın solundaki kutuya basarak tüm satırı seçiniz");
                        return;
                    }
                    int id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["TedarikciID"].Value);

                    string sorgu = "DELETE FROM tblTedarikciler WHERE TedarikciID = @ID";

                    SqlCommand cmd = new SqlCommand(sorgu, baglan);
                    cmd.Parameters.AddWithValue("@ID", id);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Tedarikçi silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    VeritabaniYardimcisi.LogKaydet(
                        kullaniciID: AktifKullanici.ID,
                        hareketID: 8,
                        tabloAdi: "tblTedarikciler",
                        aciklama: $"{txtFirmaAdi.Text} adlı tedarikçi silindi."
                    );
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

                    dataGridView2.DataSource = dt;

                    // --- KOZMETİK AYARLAR ---

                    if (dataGridView2.Columns["TedarikciID"] != null)
                        dataGridView2.Columns["TedarikciID"].Visible = false;

                    dataGridView2.Columns["TedarikciAd"].HeaderText = "Firma Adı";
                    dataGridView2.Columns["VergiDairesi"].HeaderText = "Vergi Dairesi";
                    dataGridView2.Columns["VergiNo"].HeaderText = "Vergi No";
                    dataGridView2.Columns["IletisimTel"].HeaderText = "Telefon";

                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                    MessageBox.Show("Tedarikci yüklenirken hata: " + ex.Message);
                }
            }
        }

        //------------------- Müşteri İşlemleri ------------------//
        private void musteriKayit_Click(object sender, EventArgs e) {
            if (textMusteriAd.Text.Trim() == "") {
                MessageBox.Show("Müsteri Adı boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    baglan.Open();

                    string sorgu = @"INSERT INTO tblMusteriler 
                             (MusteriAd, VergiDairesi, VergiNo, Telefon) 
                             VALUES (@Ad, @VD, @VN, @Tel)";

                    SqlCommand cmd = new SqlCommand(sorgu, baglan);

                    // Parametreleri ekliyoruz
                    cmd.Parameters.AddWithValue("@Ad", textMusteriAd.Text);
                    cmd.Parameters.AddWithValue("@VD", textMusteriVd.Text);
                    cmd.Parameters.AddWithValue("@VN", textMusteriVNo.Text);
                    cmd.Parameters.AddWithValue("@Tel", textMusteriTel.Text);

                    cmd.ExecuteNonQuery();
                    VeritabaniYardimcisi.LogKaydet(
                        kullaniciID: AktifKullanici.ID,
                        hareketID: 9,
                        tabloAdi: "tblMusteriler",
                        aciklama: $"{textMusteriAd.Text} adlı müsteri eklendi."
                    );
                } catch (Exception ex) {
                    MessageBox.Show("Ekleme Hatası: " + ex.Message);
                }
            }
            musteriListele();
        }

        private void musteriGuncel_Click(object sender, EventArgs e) {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    baglan.Open();

                    if (dataGridView2.SelectedRows.Count == 0) {
                        MessageBox.Show("Müsteri güncelleme ve silme işlemleri için listede ilgili satırın solundaki kutuya basarak tüm satırı seçiniz");
                        return;
                    }
                    int id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["MusteriID"].Value);

                    string sorgu = @"UPDATE tblMusteriler 
                             SET MusteriAd = @Ad, 
                                 VergiDairesi = @VD, 
                                 VergiNo = @VN, 
                                 Telefon = @Tel 
                             WHERE MusteriID = @ID";

                    SqlCommand cmd = new SqlCommand(sorgu, baglan);

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Ad", textMusteriAd.Text);
                    cmd.Parameters.AddWithValue("@VD", textMusteriVd.Text);
                    cmd.Parameters.AddWithValue("@VN", textMusteriVNo.Text);
                    cmd.Parameters.AddWithValue("@Tel",textMusteriTel.Text);

                    cmd.ExecuteNonQuery();
                    VeritabaniYardimcisi.LogKaydet(
                        kullaniciID: AktifKullanici.ID,
                        hareketID: 9,
                        tabloAdi: "tblMusteriler",
                        aciklama: $"{textMusteriAd.Text} adlı müsteri güncellendi."
                    );
                } catch (Exception ex) {
                    MessageBox.Show("Güncelleme Hatası: " + ex.Message);
                }
            }
            musteriListele();
        }

        private void musteriSil_Click(object sender, EventArgs e) {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    baglan.Open();

                    if (dataGridView2.SelectedRows.Count == 0) {
                        MessageBox.Show("Müsteri güncelleme ve silme işlemleri için listede ilgili satırın solundaki kutuya basarak tüm satırı seçiniz");
                        return;
                    }
                    int id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["MusteriID"].Value);

                    string sorgu = "DELETE FROM tblMusteriler WHERE MusteriID = @ID";

                    SqlCommand cmd = new SqlCommand(sorgu, baglan);
                    cmd.Parameters.AddWithValue("@ID", id);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Müsteri silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    VeritabaniYardimcisi.LogKaydet(
                        kullaniciID: AktifKullanici.ID,
                        hareketID: 9,
                        tabloAdi: "tblMusteriler",
                        aciklama: $"{textMusteriAd.Text} adlı müsteri silindi."
                    );
                } catch (SqlException ex) {
                    if (ex.Number == 547) {
                        MessageBox.Show("Bu müsteriyi silemezsiniz çünkü sistemde kayıtlı ürünleri var. Önce ürünleri silmeli veya başka müsteriye aktarmalısınız.", "İlişki Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    } else {
                        MessageBox.Show("Silme Hatası: " + ex.Message);
                    }
                }
            }
            musteriListele();
        }
        private void musteriListele() {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    baglan.Open();

                    string sorgu = "SELECT MusteriID, MusteriAd, VergiDairesi, VergiNo, Telefon FROM tblMusteriler";

                    SqlDataAdapter da = new SqlDataAdapter(sorgu, baglan);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView2.DataSource = dt;

                    // --- KOZMETİK AYARLAR ---

                    if (dataGridView2.Columns["MusteriID"] != null)
                        dataGridView2.Columns["MusteriID"].Visible = false;

                    dataGridView2.Columns["MusteriAd"].HeaderText = "Müsteri Adı";
                    dataGridView2.Columns["VergiDairesi"].HeaderText = "Vergi Dairesi";
                    dataGridView2.Columns["VergiNo"].HeaderText = "Vergi No";
                    dataGridView2.Columns["Telefon"].HeaderText = "Telefon";

                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                } catch (Exception ex) {
                    MessageBox.Show("Listeleme Hatası: " + ex.Message);
                }
            }
        }

        private void musteriBilgiAl(int id, out string ad, out string verigiNo, out string vergiDairesi, out string tel) {
            ad = string.Empty;
            verigiNo = string.Empty;
            vergiDairesi = string.Empty;
            tel = string.Empty;
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("SELECT MusteriAd, VergiDairesi, VergiNo, Telefon FROM tblMusteriler WHERE MusteriID = @id", baglan);
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        if (dr.Read()) {
                            ad = dr["MusteriAd"].ToString();
                            vergiDairesi = dr["VergiDairesi"].ToString();
                            verigiNo = dr["VergiNo"].ToString();
                            tel = dr["Telefon"].ToString();
                        }
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Müsteri kaydı yüklenirken hata: " + ex.Message);
                }
            }
        }

        //------------------- DataGridView Seçim İşlemleri ------------------//
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            switch (tabControl1.SelectedIndex) {
                case 0:
                    if (e.RowIndex >= 0) {
                        UrunBilgileriniGetir(Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["UrunID"].Value));
                    }
                    break;
                case 1:
                    if (e.RowIndex >= 0) {
                        string ad = "", aciklama = "";
                        kategoriBigiAl(Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["KategoriID"].Value), out ad, out aciklama);
                        txtKategoriAdi.Text = ad;
                        txtKategoriAciklama.Text = aciklama;
                    }
                    break;
                case 2:
                    if (e.RowIndex >= 0) {
                        TedarikciBigiAl(Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["TedarikciID"].Value), out string ad, out string vergiNo, out string vergiDairesi, out string tel);
                        txtFirmaAdi.Text = ad;
                        txtVergiDairesi.Text = vergiDairesi;
                        txtVergiNo.Text = vergiNo;
                        txtTelefon.Text = tel;
                    }
                    break;
                case 3:
                    if (e.RowIndex >= 0) {
                        musteriBilgiAl(Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["MusteriID"].Value), out string ad, out string vergiNo, out string vergiDairesi, out string tel);
                        textMusteriAd.Text = ad;
                        textMusteriVd.Text = vergiDairesi;
                        textMusteriVNo.Text = vergiNo;
                        textMusteriTel.Text = tel;
                    }
                    break;
                default:
                    break;
            }
        }

    }
}
