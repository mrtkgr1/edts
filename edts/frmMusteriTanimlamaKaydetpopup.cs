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
    public partial class frmMusteriTanimlamaKaydetpopup : Form
    {
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
        public frmMusteriTanimlamaKaydetpopup()
        {
            InitializeComponent();
        }
        public int GuncellenecekMusteriID = 0;
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
                    this.DialogResult = DialogResult.OK; // Ana forma "İşlem başarılı" sinyali gönderir
                    this.Close(); // Formu kapatır

                    // İsteğe bağlı: Kayıttan sonra kutuları temizleyebilirsin
                    // textMusteriAd.Clear(); textMusteriVd.Clear(); ...
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ekleme Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }

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



        private void frmMusteriTanimlamaKaydetpopup_Load(object sender, EventArgs e)
        {
            // Eğer dışarıdan bir ID gönderilmişse (yani güncelleme modundaysak)
            if (GuncellenecekMusteriID > 0)
            {
                this.Text = "Müşteri Bilgilerini Güncelle";
                btnMusteriKayit.Text = "Bilgileri Güncelle"; // Butonun yazısını değiştiririz

                MusteriBilgileriniGetir(GuncellenecekMusteriID);
            }
        }
    }

}
