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
    public partial class frmMusteriTanimlamaGuncellepopup : Form
    {
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
        public frmMusteriTanimlamaGuncellepopup()
        {


            InitializeComponent();
        }

        public int GuncellenecekMusteriID = 0;

        private void MusteriBilgileriniGetir(int id)
        {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                baglan.Open();
                string sorgu = "SELECT * FROM tblMusteriler WHERE MusteriID = @id";
                SqlCommand cmd = new SqlCommand(sorgu, baglan);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    textMusteriAd.Text = dr["MusteriAd"].ToString();
                    textMusteriVd.Text = dr["VergiDairesi"].ToString();
                    textMusteriVNo.Text = dr["VergiNo"].ToString();
                    textMusteriTel.Text = dr["Telefon"].ToString();
                }
            }
        }

        private void frmMusteriTanimlamaGuncellepopup_Load(object sender, EventArgs e)
        {
            if (GuncellenecekMusteriID > 0)
            {
                this.Text = "Müşteri Bilgilerini Güncelle";
                btnMusteriGuncel.Text = "Bilgileri Güncelle";

                // Bilgileri TextBoxlara doldur
                MusteriBilgileriniGetir(GuncellenecekMusteriID);
            }
        }

        private void btnMusteriGuncel_Click(object sender, EventArgs e)
        {
            // ONAY SORUSU
            DialogResult soru = MessageBox.Show(
                $"{textMusteriAd.Text} isimli müşteriyi güncellemek istediğinize emin misiniz?",
                "Güncelleme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (soru != DialogResult.Yes) return;

            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();
                    // DİKKAT: ID'yi DataGrid'den değil, yukarıdaki değişkenden alıyoruz!
                    string sorgu = @"UPDATE tblMusteriler 
                                   SET MusteriAd = @Ad, 
                                       VergiDairesi = @VD, 
                                       VergiNo = @VN, 
                                       Telefon = @Tel 
                                   WHERE MusteriID = @ID";

                    SqlCommand cmd = new SqlCommand(sorgu, baglan);
                    cmd.Parameters.AddWithValue("@ID", GuncellenecekMusteriID);
                    cmd.Parameters.AddWithValue("@Ad", textMusteriAd.Text);
                    cmd.Parameters.AddWithValue("@VD", textMusteriVd.Text);
                    cmd.Parameters.AddWithValue("@VN", textMusteriVNo.Text);
                    cmd.Parameters.AddWithValue("@Tel", textMusteriTel.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Müşteri başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Log Kaydı
                    VeritabaniYardimcisi.LogKaydet(
                        kullaniciID: AktifKullanici.ID,
                        hareketID: 9,
                        tabloAdi: "tblMusteriler",
                        aciklama: $"{textMusteriAd.Text} adlı müşteri güncellendi."
                    );

                    this.DialogResult = DialogResult.OK; // Ana forma "İşlem Tamam" mesajı gönderir
                    this.Close(); // Formu kapatır
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

