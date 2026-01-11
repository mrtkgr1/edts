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

namespace EnvanterDepoSistemitaslak2
{

    public partial class frmStokCikis : Form
    {
        public frmStokCikis()
        {
            InitializeComponent();
           
            DetayTablosunuOlustur();

           
            VerileriDoldur(); 
        }
        public DataTable cikisDetaylari = new DataTable(); 

        private void DetayTablosunuOlustur()
        {
            cikisDetaylari = new DataTable();
            cikisDetaylari.Columns.Add("UrunID", typeof(int));
            cikisDetaylari.Columns.Add("UrunAd", typeof(string));
            cikisDetaylari.Columns.Add("Miktar", typeof(decimal));
            cikisDetaylari.Columns.Add("MusteriAd", typeof(string));
            cikisDetaylari.Columns.Add("SiparisNo", typeof(string));
            cikisDetaylari.Columns.Add("CikisNedeni", typeof(string));

            dgvSevkiyatListesi.DataSource = cikisDetaylari;

            
            dgvSevkiyatListesi.Columns["UrunID"].Visible = false;
            dgvSevkiyatListesi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSevkiyatListesi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSevkiyatListesi.RowHeadersVisible = false;

           
            if (!dgvSevkiyatListesi.Columns.Contains("btnSilGrid"))
            {
                DataGridViewButtonColumn btnSil = new DataGridViewButtonColumn();
                btnSil.Name = "btnSilGrid";
                btnSil.HeaderText = "İşlem";
                btnSil.Text = "🗑";
                btnSil.UseColumnTextForButtonValue = true;
                btnSil.Width = 50;
                btnSil.DefaultCellStyle.ForeColor = Color.Red;
                dgvSevkiyatListesi.Columns.Add(btnSil);
            }
        }

        private void btnListeyeEkle_Click(object sender, EventArgs e)
        {
           
            if (cmbUrun.SelectedValue == null)
            {
                MessageBox.Show("Lütfen çıkışı yapılacak ürünü seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtAdet.Text, out decimal cikisMiktar) || cikisMiktar <= 0)
            {
                MessageBox.Show("Geçerli bir çıkış miktarı (Adet) giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbMusteri.SelectedValue == null)
            {
                MessageBox.Show("Lütfen çıkışın yapılacağı Müşteriyi seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           

            
            int urunID = (int)cmbUrun.SelectedValue;
          

            
            string urunAd = cmbUrun.Text;
            string musteriAd = cmbMusteri.Text;

           
            string siparisNo = txtSiparisNo.Text;
            string cikisNedeni = cmbCikisNedeni.Text;


          
            decimal mevcutStok = StokMiktariCek(urunID);

            if (cikisMiktar > mevcutStok)
            {
                MessageBox.Show(
                    $"Mevcut stok ({mevcutStok}) miktarından daha fazla çıkış yapamazsınız.",
                    "Yetersiz Stok",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

           
            cikisDetaylari.Rows.Add(
                urunID,      
                urunAd,       
                cikisMiktar, 
                musteriAd,    
                siparisNo,   
                cikisNedeni   
            );

          
            cmbUrun.SelectedIndex = -1;
            txtAdet.Clear();

           
        }
        
        private decimal StokMiktariCek(int urunID)
        {
           
            string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
            string sorgu = "SELECT MevcutStok FROM tblUrunler WHERE UrunID = @UrunID";
            decimal mevcutStok = 0;

            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            {
                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@UrunID", urunID);

                    try
                    {
                        baglanti.Open();
                        object sonuc = komut.ExecuteScalar();

                        if (sonuc != null && sonuc != DBNull.Value)
                        {
                            mevcutStok = Convert.ToDecimal(sonuc);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Stok kontrolü sırasında veritabanı hatası oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
           
            return mevcutStok;
        }

        private void btnCikisiOnayla_Click(object sender, EventArgs e)
        {
            if (cikisDetaylari.Rows.Count == 0) return;

           
            int hareketID_CIKIS = 2;

            string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            {
                baglanti.Open();
                SqlTransaction trans = baglanti.BeginTransaction();

                try
                {
                    foreach (DataRow row in cikisDetaylari.Rows)
                    {
                        
                        string sqlHareket = @"INSERT INTO tblStokHareketleri 
                    (UrunID, HareketID, KullaniciID, Miktar, Tarih, Aciklama, DepoID, TedarikciID, FaturaNo) 
                    VALUES (@u, @h, @k, @m, GETDATE(), @a, 1, @t, @f)";

                        using (SqlCommand cmd = new SqlCommand(sqlHareket, baglanti, trans))
                        {
                            cmd.Parameters.AddWithValue("@u", row["UrunID"]);
                            cmd.Parameters.AddWithValue("@h", hareketID_CIKIS);
                            cmd.Parameters.AddWithValue("@k", 55); 
                            cmd.Parameters.AddWithValue("@m", row["Miktar"]);
                            cmd.Parameters.AddWithValue("@a", row["CikisNedeni"]);
                            cmd.Parameters.AddWithValue("@t", cmbMusteri.SelectedValue); 
                            cmd.Parameters.AddWithValue("@f", row["SiparisNo"]);
                            cmd.ExecuteNonQuery();
                        }

                       
                        string sqlStokGuncelle = "UPDATE tblUrunler SET MevcutStok = MevcutStok - @m WHERE UrunID = @u";
                        using (SqlCommand cmdUp = new SqlCommand(sqlStokGuncelle, baglanti, trans))
                        {
                            cmdUp.Parameters.AddWithValue("@m", row["Miktar"]);
                            cmdUp.Parameters.AddWithValue("@u", row["UrunID"]);
                            cmdUp.ExecuteNonQuery();
                        }
                    }
                    trans.Commit();
                    MessageBox.Show("Stok çıkışı başarıyla tamamlandı.");
                    FormuTemizle();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
        private void FormuTemizle()
        {
           
            cikisDetaylari.Clear();

            
            cmbMusteri.SelectedIndex = -1;
            cmbCikisNedeni.SelectedIndex = -1;
            txtSiparisNo.Clear();

            
            cmbUrun.SelectedIndex = -1;
            txtAdet.Clear();

        }

        private void VerileriDoldur()
        {
            string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            {
                try
                {
                   
                    string urunSorgu = "SELECT UrunID, UrunAd FROM tblUrunler ORDER BY UrunAd";
                    DataTable dtUrun = new DataTable();
                    using (SqlDataAdapter daUrun = new SqlDataAdapter(urunSorgu, baglanti))
                    {
                        daUrun.Fill(dtUrun);
                    }
                   
                    cmbUrun.DataSource = dtUrun;
                    cmbUrun.DisplayMember = "UrunAd";
                    cmbUrun.ValueMember = "UrunID";
                    cmbUrun.SelectedIndex = -1;

                  
                    string musteriSorgu = "SELECT MusteriID, MusteriAd FROM tblMusteriler ORDER BY MusteriAd";
                    DataTable dtMusteri = new DataTable();
                    using (SqlDataAdapter daMusteri = new SqlDataAdapter(musteriSorgu, baglanti))
                    {
                        daMusteri.Fill(dtMusteri);
                    }
                    cmbMusteri.DataSource = dtMusteri;
                    cmbMusteri.DisplayMember = "MusteriAd";
                    cmbMusteri.ValueMember = "MusteriID";
                    cmbMusteri.SelectedIndex = -1;

                   
                    if (cmbCikisNedeni.Items.Count == 0)
                    {
                        cmbCikisNedeni.Items.Add("Satış (Normal Çıkış)");
                        cmbCikisNedeni.Items.Add("Sarf/Tüketim");
                        cmbCikisNedeni.Items.Add("İade (Tedarikçiye)");
                        cmbCikisNedeni.Items.Add("Sayım Eksiği");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            
            if (cikisDetaylari.Rows.Count == 0)
            {
                MessageBox.Show("Liste zaten boş.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

           
            DialogResult onay = MessageBox.Show(
                "Hazırladığınız tüm liste temizlenecek. Emin misiniz?",
                "Listeyi Boşalt",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (onay == DialogResult.Yes)
            {
                
                cikisDetaylari.Clear();

               
                txtAdet.Clear();
                cmbUrun.SelectedIndex = -1;
                lblMevcutStok.Text = "0,00";

                MessageBox.Show("Tüm liste temizlendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lblMevcutStok_Click(object sender, EventArgs e)
        {

        }

        private void cmbUrun_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cmbUrun.SelectedIndex == -1 || cmbUrun.SelectedValue == null)
            {
               
                if (cmbUrun.Focused) lblMevcutStok.Text = "0,00";
                return;
            }

          
            int urunID;
            bool isValid = int.TryParse(cmbUrun.SelectedValue.ToString(), out urunID);

            if (isValid)
            {
                try
                {
                    decimal mevcutStok = StokMiktariCek(urunID);
                    lblMevcutStok.Text = mevcutStok.ToString("N2");
                }
                catch
                {
                    lblMevcutStok.Text = "Hata";
                }
            }
        }

        private void frmStokCikis_Load(object sender, EventArgs e)
        {
            dgvSevkiyatListesi.AllowUserToAddRows = false;

        }

        private void dgvSevkiyatListesi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (dgvSevkiyatListesi.Columns[e.ColumnIndex].Name == "btnSilGrid" && e.RowIndex >= 0)
            {
                if (MessageBox.Show("Bu ürünü listeden çıkarmak istiyor musunuz?", "Sil", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cikisDetaylari.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
    }
}

        
    
