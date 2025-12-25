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

            if (textMusteriAd.Text.Trim() == "")
            {
                MessageBox.Show("Müsteri Adı boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ekleme Hatası: " + ex.Message);
                }
            }
            musteriListele();
        }

        private void btnMusteriGuncel_Click(object sender, EventArgs e)
        {

            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();

                    if (dataGridView2.SelectedRows.Count == 0)
                    {
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
                    cmd.Parameters.AddWithValue("@Tel", textMusteriTel.Text);

                    cmd.ExecuteNonQuery();
                    VeritabaniYardimcisi.LogKaydet(
                        kullaniciID: AktifKullanici.ID,
                        hareketID: 9,
                        tabloAdi: "tblMusteriler",
                        aciklama: $"{textMusteriAd.Text} adlı müsteri güncellendi."
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme Hatası: " + ex.Message);
                }
            }
            musteriListele();
        }

        private void btnMusteriSil_Click(object sender, EventArgs e)
        {
          
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();

                    if (dataGridView2.SelectedRows.Count == 0)
                    {
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
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                    {
                        MessageBox.Show("Bu müsteriyi silemezsiniz çünkü sistemde kayıtlı ürünleri var. Önce ürünleri silmeli veya başka müsteriye aktarmalısınız.", "İlişki Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Silme Hatası: " + ex.Message);
                    }
                }
            }
            musteriListele();
        }
    }
    }



