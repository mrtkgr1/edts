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
    public partial class frmUrunYonetimiGuncellepopup : Form
    {
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
        public frmUrunYonetimiGuncellepopup()
        {
            InitializeComponent();
            KategorileriYukle();
            this.Load += new EventHandler(frmUrunYonetimiGuncellepopup_Load);
        }

        public int GuncellenecekUrunID;

        private void MevcutBilgileriGetir()
        {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();
                    string sorgu = "SELECT * FROM tblUrunler WHERE UrunID = @id";
                    SqlCommand cmd = new SqlCommand(sorgu, baglan);
                    cmd.Parameters.AddWithValue("@id", GuncellenecekUrunID);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtUrunAd.Text = dr["UrunAd"].ToString();
                        txtUrunKod.Text = dr["UrunKodu"].ToString();
                        txtAlisFiyati.Text = dr["AlisFiyat"].ToString();
                        birimFiyat.Value = Convert.ToDecimal(dr["BirimFiyat"]);
                        txtKritik.Text = dr["KritikStok"].ToString();
                        cmbBirimTipi.Text = dr["BirimTipi"].ToString();

                      
                        comboBoxKategori.SelectedValue = dr["KategoriID"];
                    }
                }
                catch (Exception ex) { MessageBox.Show("Veri yükleme hatası: " + ex.Message); }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();
                    string sorgu = @"UPDATE tblUrunler 
                             SET KategoriID = @KategoriID, 
                                 UrunKodu = @UrunKodu, 
                                 UrunAd = @UrunAd, 
                                 KritikStok = @KritikStok,
                                 BirimFiyat = @BirimFiyat,
                                 AlisFiyat = @AlisFiyat,
                                 BirimTipi = @BirimTipi
                             WHERE UrunID = @UrunID";

                    SqlCommand cmdUpdate = new SqlCommand(sorgu, baglan);

                    cmdUpdate.Parameters.AddWithValue("@UrunID", GuncellenecekUrunID);
                    cmdUpdate.Parameters.AddWithValue("@KategoriID", comboBoxKategori.SelectedValue ?? DBNull.Value);
                    cmdUpdate.Parameters.AddWithValue("@UrunKodu", txtUrunKod.Text);
                    cmdUpdate.Parameters.AddWithValue("@UrunAd", txtUrunAd.Text);
                    cmdUpdate.Parameters.AddWithValue("@BirimTipi", cmbBirimTipi.Text);
                    cmdUpdate.Parameters.AddWithValue("@BirimFiyat", birimFiyat.Value);

                   
                    decimal alisFiyat = 0;
                    decimal.TryParse(txtAlisFiyati.Text, out alisFiyat);
                    cmdUpdate.Parameters.AddWithValue("@AlisFiyat", alisFiyat);

                    int kritikStok = 0;
                    int.TryParse(txtKritik.Text, out kritikStok);
                    cmdUpdate.Parameters.AddWithValue("@KritikStok", kritikStok);

                    int sonuc = cmdUpdate.ExecuteNonQuery();

                    if (sonuc > 0)
                    {
                        VeritabaniYardimcisi.LogKaydet(AktifKullanici.ID, 5, "tblUrunler", $"{txtUrunAd.Text} güncellendi.");
                        MessageBox.Show("Başarıyla güncellendi!");

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme sırasında hata oluştu: " + ex.Message);
                }
            }
        }
      


        void KategorileriYukle()
        {
            using (SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString))
            {
                try
                {
                    baglan.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT KategoriID, KategoriAd FROM tblKategoriler", baglan);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboBoxKategori.DisplayMember = "KategoriAd";
                    comboBoxKategori.ValueMember = "KategoriID";


                    comboBoxKategori.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kategoriler yüklenirken hata: " + ex.Message);
                }
            }
        }
        public void UrunBilgileriniGetir(int id)
        {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();

                    string sorgu = "SELECT UrunKodu, UrunAd, KategoriID, KritikStok, BirimFiyat FROM tblUrunler WHERE UrunID = @UrunID";

                    SqlCommand cmd = new SqlCommand(sorgu, baglan);
                    cmd.Parameters.AddWithValue("@UrunID", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            txtUrunKod.Text = dr["UrunKodu"].ToString();
                            txtUrunAd.Text = dr["UrunAd"].ToString();
                            txtKritik.Text = dr["KritikStok"].ToString();

                            comboBoxKategori.SelectedValue = Convert.ToInt32(dr["KategoriID"]);

                            birimFiyat.Value = Convert.ToDecimal(dr["BirimFiyat"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bilgiler getirilemedi: " + ex.Message);
                }
            }
        }




        private void frmUrunYonetimiGuncellepopup_Load(object sender, EventArgs e)
        {
            KategorileriYukle();

            cmbBirimTipi.Items.Clear();
            cmbBirimTipi.Items.AddRange(new string[] { "Adet", "KG", "Metre", "Paket", "gram" });

            if (GuncellenecekUrunID > 0)
            {
                MevcutBilgileriGetir();
            }
        }
    }
}
