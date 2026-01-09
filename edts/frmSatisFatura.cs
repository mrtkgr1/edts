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
    public partial class frmSatisFatura : Form
    {
        DataTable sepetTablosu = new DataTable();
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
        public frmSatisFatura()
        {
            InitializeComponent();
        }

        private void btnSepetEkle_Click(object sender, EventArgs e)
        {
          
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                baglan.Open();
                SqlCommand cmd = new SqlCommand("SELECT UrunID, UrunAd, BirimFiyat, MevcutStok FROM tblUrunler WHERE UrunKodu=@kod", baglan);
                cmd.Parameters.AddWithValue("@kod", txtUrunBarkod.Text);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    decimal stok = Convert.ToDecimal(dr["MevcutStok"]);
                    decimal istenen = nmrSatisAdet.Value;

                    if (istenen > stok)
                    {
                        MessageBox.Show($"Yetersiz stok! Mevcut: {stok}", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    decimal birimFiyat = Convert.ToDecimal(dr["BirimFiyat"]);
                    decimal toplamFiyat = birimFiyat * istenen;

                    sepetTablosu.Rows.Add(
                        dr["UrunID"],
                        txtUrunBarkod.Text,
                        dr["UrunAd"],
                        istenen,
                        birimFiyat,
                        toplamFiyat
                    );

                    txtUrunBarkod.Clear();
                    txtUrunBarkod.Focus();

                  
                    lblGenelToplam.Text = Convert.ToDecimal(sepetTablosu.Compute("Sum(Toplam)", "")).ToString("C2");
                }
                else
                {
                    MessageBox.Show("Ürün bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        

        private void btnSatisOnay_Click(object sender, EventArgs e)
        {
            if (cmbMusteri.SelectedValue == null)
            {
                MessageBox.Show("Lütfen önce bir müşteri seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (sepetTablosu.Rows.Count == 0)
            {
                MessageBox.Show("Sepette ürün bulunmuyor!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                baglan.Open();
                SqlTransaction işlem = baglan.BeginTransaction();

                try
                {
                    SqlCommand cmdSatis = new SqlCommand(@"INSERT INTO tblSatislar (MusteriID, SatisTarihi, ToplamTutar) 
                                                  OUTPUT INSERTED.SatisID 
                                                  VALUES (@mid, GETDATE(), @toplam)", baglan, işlem);

                    cmdSatis.Parameters.AddWithValue("@mid", cmbMusteri.SelectedValue);
                    cmdSatis.Parameters.AddWithValue("@toplam", sepetTablosu.Compute("Sum(Toplam)", ""));
                    int satisID = (int)cmdSatis.ExecuteScalar();

                    foreach (DataRow row in sepetTablosu.Rows)
                    {
                       
                        SqlCommand cmdDetay = new SqlCommand(@"INSERT INTO tblSatisDetay (SatisID, UrunID, Miktar, BirimFiyat) 
                                                       VALUES (@sid, @uid, @miktar, @fiyat)", baglan, işlem);

                        cmdDetay.Parameters.AddWithValue("@sid", satisID);
                       
                        cmdDetay.Parameters.AddWithValue("@uid", row["UrunID"]);
                        cmdDetay.Parameters.AddWithValue("@miktar", row["Adet"]);
                        cmdDetay.Parameters.AddWithValue("@fiyat", row["Fiyat"]);
                        cmdDetay.ExecuteNonQuery();

                       
                        SqlCommand cmdStok = new SqlCommand(@"UPDATE tblUrunler SET MevcutStok = MevcutStok - @adet 
                                                       WHERE UrunKodu = @barkod", baglan, işlem);
                        cmdStok.Parameters.AddWithValue("@adet", row["Adet"]);
                        cmdStok.Parameters.AddWithValue("@barkod", row["Barkod"]);
                        cmdStok.ExecuteNonQuery();
                    }

                    işlem.Commit();
                    MessageBox.Show("Satış başarıyla tamamlandı, stoklar güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sepetTablosu.Clear();

                    VeritabaniYardimcisi.LogKaydet(AktifKullanici.ID, 10, "tblSatislar", "Satış yapıldı. ID: " + satisID);

                   
                    lblGenelToplam.Text = "0.00";

                   
                    txtUrunBarkod.Focus();
                }
                catch (Exception ex)
                {
                    işlem.Rollback();
                    MessageBox.Show("Satış hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        

        private void MusterileriGetir()
        {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
              
                SqlDataAdapter da = new SqlDataAdapter("SELECT MusteriID, MusteriAd FROM tblMusteriler", baglan);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbMusteri.DataSource = dt;
                cmbMusteri.DisplayMember = "MusteriAd";
                cmbMusteri.ValueMember = "MusteriID";   

                cmbMusteri.SelectedIndex = -1;
            }
        }

        private void SatislariGetir()
        {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                string sorgu = @"SELECT S.SatisID, M.MusteriAd, S.SatisTarihi, S.ToplamTutar 
                         FROM tblSatislar S 
                         INNER JOIN tblMusteriler M ON S.MusteriID = M.MusteriID 
                         ORDER BY S.SatisID DESC";

                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglan);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvSatislar.DataSource = dt; 
            }
        }
        private void frmSatisFatura_Load(object sender, EventArgs e)
        {
            sepetTablosu.Columns.Add("UrunID", typeof(int));   
            sepetTablosu.Columns.Add("Barkod");                 
            sepetTablosu.Columns.Add("UrunAd");               
            sepetTablosu.Columns.Add("Adet", typeof(decimal));  
            sepetTablosu.Columns.Add("Fiyat", typeof(decimal)); 
            sepetTablosu.Columns.Add("Toplam", typeof(decimal));

            dgvSepet.DataSource = sepetTablosu;

            dgvSepet.Columns["UrunID"].Visible = false;

            MusterileriGetir();
            SatislariGetir(); 
        }
    }
    }

