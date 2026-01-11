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
    public partial class frmUrunTanimlamapopup : Form
    {
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
        public frmUrunTanimlamapopup()
        {
            InitializeComponent();
          KategorileriYukle();
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

        private void frmUrunTanimlamapopup_Load(object sender, EventArgs e)
        {
           
            cmbBirimTipi.Items.AddRange(new string[] { "Adet", "KG", "Metre", "Paket", "gram" });
            cmbBirimTipi.SelectedIndex = 0; 

        }

        private void btnKaydett_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUrunAd.Text) || string.IsNullOrEmpty(txtAlisFiyati.Text))
            {
                MessageBox.Show("Lütfen ürün adı ve alış fiyatı gibi zorunlu alanları doldurun!");
                return;
            }

            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();
                    

                    SqlCommand cmdInsert = new SqlCommand(@"INSERT INTO tblUrunler  
            (KategoriID, UrunKodu, UrunAd, KritikStok, MevcutStok, Durum, BirimFiyat, AlisFiyat, BirimTipi)  
            VALUES (@KategoriID, @UrunKodu, @UrunAd, @KritikStok, 0, 'Aktif', @BirimFiyat, @AlisFiyat, @BirimTipi)", baglan);

                    cmdInsert.Parameters.AddWithValue("@KategoriID", comboBoxKategori.SelectedValue ?? DBNull.Value);
                    cmdInsert.Parameters.AddWithValue("@UrunKodu", txtUrunKod.Text);
                    cmdInsert.Parameters.AddWithValue("@UrunAd", txtUrunAd.Text);

                    int kritikStok = 0;
                    int.TryParse(txtKritik.Text, out kritikStok);
                    cmdInsert.Parameters.AddWithValue("@KritikStok", kritikStok);

                    decimal satisFiyati = 0;
                    decimal.TryParse(birimFiyat.Value.ToString(), out satisFiyati);
                    cmdInsert.Parameters.AddWithValue("@BirimFiyat", satisFiyati);

                    decimal alisFiyati = 0;
                    decimal.TryParse(txtAlisFiyati.Text, out alisFiyati);
                    cmdInsert.Parameters.AddWithValue("@AlisFiyat", alisFiyati);

                    cmdInsert.Parameters.AddWithValue("@BirimTipi", cmbBirimTipi.Text);

                    cmdInsert.ExecuteNonQuery();

                    VeritabaniYardimcisi.LogKaydet(AktifKullanici.ID, 5, "tblUrunler", $"{txtUrunAd.Text} adlı ürün eklendi.");
                    MessageBox.Show("Ürün başarıyla kaydedildi.");

                    txtUrunAd.Clear();
                    txtUrunKod.Clear();
                    txtAlisFiyati.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ürün kayıt edilemedi.\nHata: " + ex.Message);
                }
            }
       
        }


        private void musteriBilgiAl(int id, out string ad, out string verigiNo, out string vergiDairesi, out string tel)
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
                        SqlCommand cmd = new SqlCommand("SELECT MusteriAd, VergiDairesi, VergiNo, Telefon FROM tblMusteriler WHERE MusteriID = @id", baglan);
                        cmd.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                ad = dr["MusteriAd"].ToString();
                                vergiDairesi = dr["VergiDairesi"].ToString();
                                verigiNo = dr["VergiNo"].ToString();
                                tel = dr["Telefon"].ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Müsteri kaydı yüklenirken hata: " + ex.Message);
                    }
                }
            }  
    }
}

