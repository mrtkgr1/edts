using DocumentFormat.OpenXml.Bibliography;
using edts;
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
    public partial class frmTedarikciYonetim : Form
    {
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
        public frmTedarikciYonetim()
        {
            InitializeComponent();
        }

        private void frmTedarikciYonetim_Load(object sender, EventArgs e)
        {
            // Form açılır açılmaz listeyi doldurur
            TedarikcileriListele();
        }

        public void TedarikcileriListele()
        {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();

                    string sorgu = "SELECT TedarikciID, TedarikciAd, VergiDairesi, VergiNo, IletisimTel FROM tblTedarikciler";

                    SqlDataAdapter da = new SqlDataAdapter(sorgu, baglan);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView2.DataSource = dt;

                    
                    btnGuncelleSutun.DisplayIndex = dataGridView2.ColumnCount - 1;
                    btnSilSutun.DisplayIndex = dataGridView2.ColumnCount - 1;
                    // --- KOZMETİK AYARLAR ---

                    if (dataGridView2.Columns["TedarikciID"] != null)
                        dataGridView2.Columns["TedarikciID"].Visible = false;

                    dataGridView2.Columns["TedarikciAd"].HeaderText = "Firma Adı";
                    dataGridView2.Columns["VergiDairesi"].HeaderText = "Vergi Dairesi";
                    dataGridView2.Columns["VergiNo"].HeaderText = "Vergi No";
                    dataGridView2.Columns["IletisimTel"].HeaderText = "Telefon";

                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Listeleme Hatası: " + ex.Message);
                }
            }
        }
        private void TedarikciBigiAl(int id, out string ad, out string verigiNo, out string vergiDairesi, out string tel)
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
                    SqlCommand cmd = new SqlCommand("SELECT TedarikciAd, VergiDairesi, VergiNo, IletisimTel FROM tblTedarikciler WHERE TedarikciID = @id", baglan);
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ad = dr["TedarikciAd"].ToString();
                            vergiDairesi = dr["VergiDairesi"].ToString();
                            verigiNo = dr["VergiNo"].ToString();
                            tel = dr["IletisimTel"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tedarikci yüklenirken hata: " + ex.Message);
                }
            }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           /* if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                txtFirmaAdi.Text = row.Cells["TedarikciAd"].Value?.ToString();
                txtVergiDairesi.Text = row.Cells["VergiDairesi"].Value?.ToString();
                txtVergiNo.Text = row.Cells["VergiNo"].Value?.ToString();
                txtTelefon.Text = row.Cells["IletisimTel"].Value?.ToString();
            } */
        }

        private void btnTedarikciSill_Click(object sender, EventArgs e)
        {
         /*   // 1. ADIM: Seçim Kontrolü
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Tedarikçi silme işlemi için listede ilgili satırın solundaki kutuya basarak tüm satırı seçiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Silinecek firmanın adını log ve mesaj için değişkene alalım
            string firmaAdi = txtFirmaAdi.Text;

            // 2. ADIM: ONAY SORUSU (Kritik nokta)
            DialogResult soru = MessageBox.Show(
                $"{firmaAdi} isimli tedarikçiyi silmek istediğinize emin misiniz?\nBu işlem geri alınamaz!",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            // Eğer kullanıcı 'Hayır' derse işlemi iptal et
            if (soru != DialogResult.Yes) return;

            // 3. ADIM: İŞLEM (Kullanıcı Evet dediyse burası çalışır)
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();
                    int id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["TedarikciID"].Value);

                    string sorgu = "DELETE FROM tblTedarikciler WHERE TedarikciID = @ID";

                    SqlCommand cmd = new SqlCommand(sorgu, baglan);
                    cmd.Parameters.AddWithValue("@ID", id);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Tedarikçi başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    VeritabaniYardimcisi.LogKaydet(
                        kullaniciID: AktifKullanici.ID,
                        hareketID: 8,
                        tabloAdi: "tblTedarikciler",
                        aciklama: $"{firmaAdi} adlı tedarikçi silindi."
                    );

                    // Silme işleminden sonra kutuları temizlemek iyi bir pratiktir
                    txtFirmaAdi.Clear();
                    txtVergiDairesi.Clear();
                    txtVergiNo.Clear();
                    txtTelefon.Clear();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                    {
                        MessageBox.Show("Bu tedarikçiyi silemezsiniz çünkü bu tedarikçiden alınmış ürünler veya fatura kayıtları sistemde mevcut. Önce bu kayıtları temizlemelisiniz.", "İlişki Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Silme Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            TedarikcileriListele();  */
        }
        
        private void btnTedarikciGuncellee_Click(object sender, EventArgs e)
        {
           /* // 1. ADIM: Seçili satır kontrolü
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Tedarikçi güncelleme işlemi için listede ilgili satırın solundaki kutuya basarak tüm satırı seçiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. ADIM: KULLANICIYA SORALIM (Onay Mekanizması)
            DialogResult soru = MessageBox.Show(
                $"{txtFirmaAdi.Text} firmasının bilgilerini güncellemek istediğinize emin misiniz?",
                "Güncelleme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Eğer kullanıcı 'Hayır' derse işlemi burada durdur
            if (soru != DialogResult.Yes) return;

            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();
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

                    int sonuc = cmd.ExecuteNonQuery();

                    // 3. ADIM: BAŞARI BİLDİRİMİ
                    if (sonuc > 0)
                    {
                        MessageBox.Show("Tedarikçi bilgileri başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        VeritabaniYardimcisi.LogKaydet(
                            kullaniciID: AktifKullanici.ID,
                            hareketID: 8,
                            tabloAdi: "tblTedarikciler",
                            aciklama: $"{txtFirmaAdi.Text} adlı tedarikçi güncellendi."
                        );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            TedarikcileriListele(); */
        }

        private void btnTedarikciKaydett_Click(object sender, EventArgs e)
        {
/*
            // 1. ADIM: Boş kontrolü (Zaten harika bir şekilde yapmışsın)
            if (txtFirmaAdi.Text.Trim() == "")
            {
                MessageBox.Show("Firma Adı boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. ADIM: ONAY SORUSU (Kullanıcıya soruyoruz)
            DialogResult soru = MessageBox.Show(
                $"{txtFirmaAdi.Text} firmasını yeni tedarikçi olarak kaydetmek istiyor musunuz?",
                "Tedarikçi Kayıt Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Eğer kullanıcı 'Hayır' derse işlemi burada bitir
            if (soru != DialogResult.Yes) return;

            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();

                    string sorgu = @"INSERT INTO tblTedarikciler 
                             (TedarikciAd, VergiDairesi, VergiNo, IletisimTel) 
                             VALUES (@Ad, @VD, @VN, @Tel)";

                    SqlCommand cmd = new SqlCommand(sorgu, baglan);

                    cmd.Parameters.AddWithValue("@Ad", txtFirmaAdi.Text);
                    cmd.Parameters.AddWithValue("@VD", txtVergiDairesi.Text);
                    cmd.Parameters.AddWithValue("@VN", txtVergiNo.Text);
                    cmd.Parameters.AddWithValue("@Tel", txtTelefon.Text);

                    cmd.ExecuteNonQuery();

                    // 3. ADIM: BAŞARI MESAJI (Kullanıcıyı bilgilendiriyoruz)
                    MessageBox.Show("Tedarikçi kaydı başarıyla tamamlandı.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    VeritabaniYardimcisi.LogKaydet(
                        kullaniciID: AktifKullanici.ID,
                        hareketID: 8,
                        tabloAdi: "tblTedarikciler",
                        aciklama: $"{txtFirmaAdi.Text} adlı tedarikçi eklendi."
                    );

                    // İsteğe bağlı: Kayıttan sonra kutuları temizleyebilirsin
                    txtFirmaAdi.Clear();
                    txtVergiDairesi.Clear();
                    txtVergiNo.Clear();
                    txtTelefon.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ekleme Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            TedarikcileriListele();  */
        }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
           
        }

        private void TedarikciSil(string id)
        {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblTedarikciler WHERE TedarikciID = @id", baglan);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tedarikçi silindi.");
                }
                catch (SqlException sqlEx) when (sqlEx.Number == 547)
                {
                    MessageBox.Show("Bu tedarikçiye ait alış kayıtları olduğu için silemezsiniz. Pasife almayı deneyin.");
                }
            }
        }

        private void dataGridView2_MouseMove(object sender, MouseEventArgs e)
        {
            var hit = dataGridView2.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.Cell && dataGridView2.Columns[hit.ColumnIndex].Name == "btnSilSutun")
            {
                dataGridView2.InvalidateCell(hit.ColumnIndex, hit.RowIndex);
            }
        }

        private void dataGridView2_MouseLeave(object sender, EventArgs e)
        {
            dataGridView2.Invalidate();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // --- GÜNCELLEME BUTONU ---
            if (dataGridView2.Columns[e.ColumnIndex].Name == "btnGuncelleSutun")
            {
                int id = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["TedarikciID"].Value);

                frmTedarikciYonetimGuncellepopup popup = new frmTedarikciYonetimGuncellepopup();
                popup.GuncellenecekUrunID = id;

                // Soruyu burada sormuyoruz, direkt formu açıyoruz.
                // Form kapandığında eğer işlem başarılıysa (OK) listeyi yeniliyoruz.
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    TedarikcileriListele();
                }
            }

            // --- SİLME BUTONU ---
            else if (dataGridView2.Columns[e.ColumnIndex].Name == "btnSilSutun")
            {
                string idSil = dataGridView2.Rows[e.RowIndex].Cells["TedarikciID"].Value.ToString();
                string adSil = dataGridView2.Rows[e.RowIndex].Cells["TedarikciAd"].Value?.ToString();

                // Silme işlemi geri alınamaz olduğu için burada onay sormaya devam etmelisin
                if (MessageBox.Show($"{adSil} silinsin mi?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    TedarikciSil(idSil);
                    TedarikcileriListele();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frmTedarikciYonetimKaydetpopup yeniForm = new frmTedarikciYonetimKaydetpopup();
            yeniForm.ShowDialog();
            TedarikcileriListele();
        }
    }
}



