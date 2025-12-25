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
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                txtFirmaAdi.Text = row.Cells["TedarikciAd"].Value?.ToString();
                txtVergiDairesi.Text = row.Cells["VergiDairesi"].Value?.ToString();
                txtVergiNo.Text = row.Cells["VergiNo"].Value?.ToString();
                txtTelefon.Text = row.Cells["IletisimTel"].Value?.ToString();
            }
        }

        private void btnTedarikciSill_Click(object sender, EventArgs e)
        {

            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();

                    if (dataGridView2.SelectedRows.Count == 0)
                    {
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
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                    {
                        MessageBox.Show("Bu tedarikçiyi silemezsiniz çünkü sistemde kayıtlı ürünleri var. Önce ürünleri silmeli veya başka tedarikçiye aktarmalısınız.", "İlişki Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Silme Hatası: " + ex.Message);
                    }
                }
            }
            TedarikcileriListele();
        }

        private void btnTedarikciGuncellee_Click(object sender, EventArgs e)
        {

            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();

                    if (dataGridView2.SelectedRows.Count == 0)
                    {
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme Hatası: " + ex.Message);
                }
            }
            TedarikcileriListele();
        }

        private void btnTedarikciKaydett_Click(object sender, EventArgs e)
        {
          
            if (txtFirmaAdi.Text.Trim() == "")
            {
                MessageBox.Show("Firma Adı boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ekleme Hatası: " + ex.Message);
                }
            }
            TedarikcileriListele();
        }
    }
}



