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
    public partial class frmTedarikciYonetimGuncellepopup : Form
    {
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
        public frmTedarikciYonetimGuncellepopup()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmTedarikciYonetimGuncellepopup_Load);
        }
        public int GuncellenecekUrunID;

        private void TedarikciBilgileriniYukle(int id)
        {
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
                            txtFirmaAdi.Text = dr["TedarikciAd"].ToString();
                            txtVergiDairesi.Text = dr["VergiDairesi"].ToString();
                            txtVergiNo.Text = dr["VergiNo"].ToString();
                            txtTelefon.Text = dr["IletisimTel"].ToString();
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Veri yükleme hatası: " + ex.Message); }
            }
        }

        private void frmTedarikciYonetimGuncellepopup_Load(object sender, EventArgs e)
        {
         
            if (GuncellenecekUrunID > 0)
            {
                TedarikciBilgileriniYukle(GuncellenecekUrunID);
            }
        }

        private void btnTedarikciGuncellee_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirmaAdi.Text)) { MessageBox.Show("Firma adı boş olamaz!"); return; }

            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();
                    string sorgu = @"UPDATE tblTedarikciler 
                                     SET TedarikciAd=@Ad, VergiDairesi=@VD, VergiNo=@VN, IletisimTel=@Tel 
                                     WHERE TedarikciID=@ID";

                    SqlCommand cmd = new SqlCommand(sorgu, baglan);
                    cmd.Parameters.AddWithValue("@ID", GuncellenecekUrunID);
                    cmd.Parameters.AddWithValue("@Ad", txtFirmaAdi.Text);
                    cmd.Parameters.AddWithValue("@VD", txtVergiDairesi.Text);
                    cmd.Parameters.AddWithValue("@VN", txtVergiNo.Text);
                    cmd.Parameters.AddWithValue("@Tel", txtTelefon.Text);

                    cmd.ExecuteNonQuery();

                    VeritabaniYardimcisi.LogKaydet(AktifKullanici.ID, 8, "tblTedarikciler", $"{txtFirmaAdi.Text} güncellendi.");

                    MessageBox.Show("Bilgiler başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK; 
                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show("Güncelleme hatası: " + ex.Message); }
            }
        }
    }
}
 
