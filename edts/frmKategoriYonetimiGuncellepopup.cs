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
    public partial class frmKategoriYonetimiGuncellepopup : Form
    {
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
        public frmKategoriYonetimiGuncellepopup()
        {
            InitializeComponent();
        }
        public int GuncellenecekKategoriID;

        private void KategoriBilgileriniGetir(int id)
        {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                baglan.Open();
                SqlCommand cmd = new SqlCommand("SELECT KategoriAd, KategoriAciklama FROM tblKategoriler WHERE KategoriID = @id", baglan);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtKategoriAdi.Text = dr["KategoriAd"].ToString();
                    txtKategoriAciklama.Text = dr["KategoriAciklama"].ToString();
                }
            }
        }

        private void frmKategoriYonetimiGuncellepopup_Load(object sender, EventArgs e)
        {
            // Form açıldığında ID kontrolü yap ve verileri yükle
            if (GuncellenecekKategoriID > 0)
            {
                KategoriBilgileriniGetir(GuncellenecekKategoriID);
            }
        }

        private void btnKategoriGuncellee_Click(object sender, EventArgs e)
        {
            // --- ONAY SORUSU BURADA ---
            DialogResult soru = MessageBox.Show(
                $"{txtKategoriAdi.Text} kategorisini güncellemek istediğinize emin misiniz?",
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
                    SqlCommand cmd = new SqlCommand("UPDATE tblKategoriler SET KategoriAd=@ad, KategoriAciklama=@aci WHERE KategoriID=@id", baglan);
                    cmd.Parameters.AddWithValue("@ad", txtKategoriAdi.Text);
                    cmd.Parameters.AddWithValue("@aci", txtKategoriAciklama.Text);
                    cmd.Parameters.AddWithValue("@id", GuncellenecekKategoriID);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Kategori başarıyla güncellendi.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
            }
        }
    }
}
