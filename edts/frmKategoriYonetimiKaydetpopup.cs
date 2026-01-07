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

namespace edts
{
    public partial class frmKategoriYonetimiKaydetpopup : Form
    {
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
        public frmKategoriYonetimiKaydetpopup()
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
          
        }
    }
}
