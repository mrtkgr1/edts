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
    public partial class frmMusteriTanimlama : Form
    {
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
        public frmMusteriTanimlama()
        {
            InitializeComponent();
        }

        private void frmMusteriTanimlama_Load(object sender, EventArgs e)
        {
            musteriListele(); // Form açılır açılmaz verileri getirir
        }

        private void musteriListele()
        {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Listeleme Hatası: " + ex.Message);
                }
            }
        }

      
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                textMusteriAd.Text = row.Cells["MusteriAd"].Value?.ToString();
                textMusteriVd.Text = row.Cells["VergiDairesi"].Value?.ToString();
                textMusteriVNo.Text = row.Cells["VergiNo"].Value?.ToString();
                textMusteriTel.Text = row.Cells["Telefon"].Value?.ToString();
            }
        }

        private void btnMusteriKayit_Click(object sender, EventArgs e)
        {

            // 1. ADIM: Boş kontrolü (Zaten yapmışsın, çok iyi)
            if (textMusteriAd.Text.Trim() == "")
            {
                MessageBox.Show("Müsteri Adı boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. ADIM: ONAY SORUSU (Kritik Nokta)
            DialogResult soru = MessageBox.Show(
                $"{textMusteriAd.Text} isimli müşteriyi kaydetmek istediğinize emin misiniz?",
                "Kayıt Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Eğer kullanıcı 'Hayır' derse kodu burada durduruyoruz
            if (soru != DialogResult.Yes) return;

            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();

                    string sorgu = @"INSERT INTO tblMusteriler 
                             (MusteriAd, VergiDairesi, VergiNo, Telefon) 
                             VALUES (@Ad, @VD, @VN, @Tel)";

                    SqlCommand cmd = new SqlCommand(sorgu, baglan);

                    cmd.Parameters.AddWithValue("@Ad", textMusteriAd.Text);
                    cmd.Parameters.AddWithValue("@VD", textMusteriVd.Text);
                    cmd.Parameters.AddWithValue("@VN", textMusteriVNo.Text);
                    cmd.Parameters.AddWithValue("@Tel", textMusteriTel.Text);

                    cmd.ExecuteNonQuery();

                    // 3. ADIM: BAŞARI MESAJI
                    MessageBox.Show("Müşteri başarıyla sisteme kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    VeritabaniYardimcisi.LogKaydet(
                        kullaniciID: AktifKullanici.ID,
                        hareketID: 9,
                        tabloAdi: "tblMusteriler",
                        aciklama: $"{textMusteriAd.Text} adlı müsteri eklendi."
                    );

                    // İsteğe bağlı: Kayıttan sonra kutuları temizleyebilirsin
                    // textMusteriAd.Clear(); textMusteriVd.Clear(); ...
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ekleme Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            musteriListele();
        }

        private void btnMusteriGuncel_Click(object sender, EventArgs e)
        {

            // 1. ADIM: Önce seçim kontrolü
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Müsteri güncelleme ve silme işlemleri için listede ilgili satırın solundaki kutuya basarak tüm satırı seçiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. ADIM: ONAY SORUSU (Kritik Nokta)
            DialogResult soru = MessageBox.Show(
                $"{textMusteriAd.Text} isimli müşterinin bilgilerini güncellemek istediğinize emin misiniz?",
                "Güncelleme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Eğer kullanıcı 'Hayır' derse işlemi iptal et (metottan çık)
            if (soru != DialogResult.Yes) return;

            // 3. ADIM: İşlem Başlıyor (Evet dediyse buraya geçer)
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();
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
                    cmd.Parameters.AddWithValue("@Tel", textMusteriTel.Text);

                    int etkilenenSatir = cmd.ExecuteNonQuery();

                    // 4. ADIM: BAŞARI MESAJI
                    if (etkilenenSatir > 0)
                    {
                        MessageBox.Show("Müşteri bilgileri başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        VeritabaniYardimcisi.LogKaydet(
                            kullaniciID: AktifKullanici.ID,
                            hareketID: 9,
                            tabloAdi: "tblMusteriler",
                            aciklama: $"{textMusteriAd.Text} adlı müsteri güncellendi."
                        );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // 5. ADIM: Listeyi yenile
            musteriListele();
        }

        private void btnMusteriSil_Click(object sender, EventArgs e)
        {
            // 1. Seçim Kontrolü
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Müsteri güncelleme ve silme işlemleri için listede ilgili satırın solundaki kutuya basarak tüm satırı seçiniz");
                return;
            }

            // 2. ONAY ALMA (Emin misiniz sorusu)
            DialogResult secim = MessageBox.Show(
                $"{textMusteriAd.Text} isimli müşteriyi silmek istediğinize emin misiniz? Bu işlem geri alınamaz!",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            // Eğer kullanıcı 'Hayır' derse metottan çık, silme (return)
            if (secim != DialogResult.Yes) return;

            // 3. Silme İşlemi (Kullanıcı Evet dediyse buraya geçer)
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();
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
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                    {
                        MessageBox.Show("Bu müşteriyi silemezsiniz çünkü bu müşteriye ait geçmiş satış kayıtları (faturalar) var.", "Silme Engellendi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        MessageBox.Show("Silme Hatası: " + ex.Message);
                    }
                }
            }
            musteriListele(); // Listeyi güncelle
        }
    }
    }



