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
    public partial class frmTedarikciYonetimKaydetpopup : Form
    {
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
        public frmTedarikciYonetimKaydetpopup()
        {
            InitializeComponent();
        }

        private void frmTedarikciYonetimKaydetpopup_Load(object sender, EventArgs e)
        {

        }

        private void btnTedarikciKaydett_Click(object sender, EventArgs e)
        {

           
            if (txtFirmaAdi.Text.Trim() == "")
            {
                MessageBox.Show("Firma Adı boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

          
            DialogResult soru = MessageBox.Show(
                $"{txtFirmaAdi.Text} firmasını yeni tedarikçi olarak kaydetmek istiyor musunuz?",
                "Tedarikçi Kayıt Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            
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

                   
                    MessageBox.Show("Tedarikçi kaydı başarıyla tamamlandı.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    VeritabaniYardimcisi.LogKaydet(
                        kullaniciID: AktifKullanici.ID,
                        hareketID: 8,
                        tabloAdi: "tblTedarikciler",
                        aciklama: $"{txtFirmaAdi.Text} adlı tedarikçi eklendi."
                    );

                  
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
            
        }
    }
}
