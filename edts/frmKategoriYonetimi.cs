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
using edts;

namespace edts
{
    public partial class frmKategoriYonetimi : Form
    {
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

        public frmKategoriYonetimi()
        {
            InitializeComponent();
        }

        private void btnKategoriKaydett_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtKategoriAdi.Text))
            {
                MessageBox.Show("Kategori adı boş olamaz!");
                return;
            }

            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();
                    // Sorguyu ve parametreleri kontrol ettim
                    SqlCommand cmdInsert = new SqlCommand("INSERT INTO tblKategoriler (KategoriAd, KategoriAciklama) VALUES (@kat, @aci)", baglan);
                    cmdInsert.Parameters.AddWithValue("@kat", txtKategoriAdi.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@aci", txtKategoriAciklama.Text.Trim());
                    cmdInsert.ExecuteNonQuery();

                    VeritabaniYardimcisi.LogKaydet(AktifKullanici.ID, 6, "tblKategoriler", $"{txtKategoriAdi.Text} adlı kategori eklendi.");

                    MessageBox.Show("Kategori başarıyla eklendi.");
                    txtKategoriAdi.Clear();
                    txtKategoriAciklama.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kategori eklenemedi.\nHata: " + ex.Message);
                }
            }
            KategoriListeGuncelle();
        }

        private void btnKategoriGuncellee_Click(object sender, EventArgs e)
        {

            if (dataGridView2.SelectedRows.Count == 0) return;

            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    int id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["KategoriID"].Value);
                    baglan.Open();
                    // SQL sorgusundaki yazım hataları düzeltildi
                    SqlCommand cmd = new SqlCommand("UPDATE tblKategoriler SET KategoriAd = @ad, KategoriAciklama = @aciklama WHERE KategoriID = @id", baglan);
                    cmd.Parameters.AddWithValue("@ad", txtKategoriAdi.Text); // .Text eklendi
                    cmd.Parameters.AddWithValue("@aciklama", txtKategoriAciklama.Text); // .Text eklendi
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                    VeritabaniYardimcisi.LogKaydet(AktifKullanici.ID, 6, "tblKategoriler", $"{txtKategoriAdi.Text} güncellendi.");
                    MessageBox.Show("Güncelleme başarılı.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme hatası: " + ex.Message);
                }
            }
            KategoriListeGuncelle();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                txtKategoriAdi.Text = row.Cells["KategoriAd"].Value.ToString();
                txtKategoriAciklama.Text = row.Cells["KategoriAciklama"].Value.ToString();
            }
        }

        private void btnKategoriSill_Click(object sender, EventArgs e)
        {

            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz kategorinin solundaki kutuya basarak tüm satırı seçiniz.");
                return;
            }

            // Kullanıcıya onay soralım
            DialogResult onay = MessageBox.Show("Bu kategoriyi silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (onay == DialogResult.Yes)
            {
                using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
                {
                    try
                    {
                        int id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["KategoriID"].Value);
                        string silinenAd = dataGridView2.SelectedRows[0].Cells["KategoriAd"].Value?.ToString() ?? "";

                        baglan.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM tblKategoriler WHERE KategoriID = @id", baglan);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();

                        VeritabaniYardimcisi.LogKaydet(
                            kullaniciID: AktifKullanici.ID,
                            hareketID: 6,
                            tabloAdi: "tblKategoriler",
                            aciklama: $"{silinenAd} adlı kategori silindi."
                        );

                        MessageBox.Show("Kategori başarıyla silindi.");
                        txtKategoriAdi.Clear();
                        txtKategoriAciklama.Clear();
                    }
                    catch (SqlException sqlEx) when (sqlEx.Number == 547)
                    {
                        MessageBox.Show("Bu kategoriye ait ürünler olduğu için silme işlemi yapılamaz.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
                KategoriListeGuncelle();
            }
        }
        private void KategoriListeGuncelle()
        {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();
                    // Sorguya KategoriAciklama eklendi
                    string sorgu = "SELECT KategoriID, KategoriAd, KategoriAciklama FROM tblKategoriler";

                    SqlDataAdapter da = new SqlDataAdapter(sorgu, baglan);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView2.DataSource = dt;

                    // Görsel iyileştirme
                    dataGridView2.Columns["KategoriID"].Visible = false; // ID'yi gizle
                    dataGridView2.Columns["KategoriAd"].HeaderText = "Kategori Adı";
                    dataGridView2.Columns["KategoriAciklama"].HeaderText = "Açıklama";
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri çekilemedi: " + ex.Message);
                }
            }
        }

        private void frmKategoriYonetimi_Load(object sender, EventArgs e)
        {

        }
    }
}


