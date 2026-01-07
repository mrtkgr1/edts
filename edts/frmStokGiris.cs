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
    public partial class frmStokGiris : Form
    {
       
        private DataTable stokDetaylari = new DataTable();

       

        public frmStokGiris()
        {
            InitializeComponent();
            VeriYukle();
            DetayTablosunuOlustur();
        }
        private void DetayTablosunuOlustur()
        {
            stokDetaylari = new DataTable();
           
            stokDetaylari.Columns.Add("UrunID", typeof(int));
           
            stokDetaylari.Columns.Add("UrunAd", typeof(string));
           
            stokDetaylari.Columns.Add("Miktar", typeof(decimal));
            
            stokDetaylari.Columns.Add("TedarikciAd", typeof(string));
           
            stokDetaylari.Columns.Add("FaturaNo", typeof(string));
            
            stokDetaylari.Columns.Add("GirisNedeni", typeof(string));

            dgvStokDetaylari.DataSource = stokDetaylari;

           
            dgvStokDetaylari.Columns["UrunID"].Visible = false;
            dgvStokDetaylari.Columns["UrunAd"].HeaderText = "Ürün Adı";
            dgvStokDetaylari.Columns["Miktar"].HeaderText = "Miktar";
            dgvStokDetaylari.Columns["TedarikciAd"].HeaderText = "Tedarikçi";
            dgvStokDetaylari.Columns["FaturaNo"].HeaderText = "Fatura No";
            dgvStokDetaylari.Columns["GirisNedeni"].HeaderText = "Giriş Nedeni";
            dgvStokDetaylari.Columns["btnSilGrid"].DisplayIndex = dgvStokDetaylari.ColumnCount - 1;
        }

        private void VeriYukle()
        {
            string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglanti.Open();

                   
                    SqlDataAdapter daTedarik = new SqlDataAdapter("SELECT TedarikciID, TedarikciAd FROM tblTedarikciler", baglanti);
                    DataTable dtTedarikci = new DataTable();
                    daTedarik.Fill(dtTedarikci);
                    cmbTedarikci.DataSource = dtTedarikci;
                    cmbTedarikci.DisplayMember = "TedarikciAd";
                    cmbTedarikci.ValueMember = "TedarikciID";
                    cmbTedarikci.SelectedIndex = -1;

                    
                    SqlDataAdapter daUrun = new SqlDataAdapter("SELECT UrunID, UrunAd FROM tblUrunler", baglanti);
                    DataTable dtUrun = new DataTable();
                    daUrun.Fill(dtUrun);
                    cmbUrunSecimi.DataSource = dtUrun; 
                    cmbUrunSecimi.DisplayMember = "UrunAd";
                    cmbUrunSecimi.ValueMember = "UrunID";
                    cmbUrunSecimi.SelectedIndex = -1;

                    
                    cmbGirisNedeni.Items.Clear();
                    cmbGirisNedeni.Items.Add("Satın Alma");
                    cmbGirisNedeni.Items.Add("İade");
                    cmbGirisNedeni.Items.Add("Sayım Fazlası");
                }
                catch (Exception ex) { MessageBox.Show("Yükleme Hatası: " + ex.Message); }
            }
        }

       
        private void TedarikcileriYukle()
        {
            string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            {
                string sorgu = "SELECT TedarikciID, Ad FROM tblTedarikciler WHERE AktifMi = 1";

               

                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbTedarikci.DataSource = dt;
                   
                    cmbTedarikci.DisplayMember = "Ad";       
                    cmbTedarikci.ValueMember = "TedarikciID"; 

                    cmbTedarikci.SelectedIndex = -1; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tedarikçi yüklenirken hata oluştu: " + ex.Message);
                }
            }
        }

       
        private void UrunleriYukle()
        {
            string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
            
            string sorgu = "SELECT UrunID, UrunKodu + ' - ' + UrunAd AS UrunTamAd FROM tblUrunler ORDER BY UrunTamAd";

            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            {
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbUrunSecimi.DisplayMember = "UrunTamAd";
                cmbUrunSecimi.ValueMember = "UrunID";
                cmbUrunSecimi.DataSource = dt;
                cmbUrunSecimi.SelectedIndex = -1;
            }
        }

        private void frmStokGiris_Load(object sender, EventArgs e)
        {
            dgvStokDetaylari.AllowUserToAddRows = false;

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
           
            if (cmbUrunSecimi.SelectedValue == null || string.IsNullOrWhiteSpace(txtGirisMiktari.Text))
            {
                MessageBox.Show("Lütfen ürün ve miktar bilgilerini giriniz!", "Uyarı");
                return;
            }

            try
            {
                
                int urunID = Convert.ToInt32(cmbUrunSecimi.SelectedValue);
                string urunAd = cmbUrunSecimi.Text;
                decimal miktar = decimal.Parse(txtGirisMiktari.Text);
                string tedarikciAd = cmbTedarikci.Text;
                string faturaNo = txtFaturaNo.Text;
                string girisNedeni = cmbGirisNedeni.Text;

               
                stokDetaylari.Rows.Add(
                    urunID,       
                    urunAd,       
                    miktar,      
                    tedarikciAd,  
                    faturaNo,     
                    girisNedeni  
                );

                txtGirisMiktari.Clear(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Listeye eklerken hata oluştu: " + ex.Message);
            }
        }

        private void btnGirisOnayla_Click(object sender, EventArgs e)
        {
            if (stokDetaylari.Rows.Count == 0 || cmbTedarikci.SelectedValue == null)
            {
                MessageBox.Show("Eksik bilgi var!");
                return;
            }

            string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            {
                baglanti.Open();
                SqlTransaction trans = baglanti.BeginTransaction();

                try
                {
                    foreach (DataRow row in stokDetaylari.Rows)
                    {
                        

                        string sql = @"INSERT INTO tblStokHareketleri 
                                     (UrunID, HareketID, KullaniciID, Miktar, Tarih, Aciklama, DepoID, TedarikciID, FaturaNo) 
                                     VALUES (@u, (SELECT TOP 1 HareketID FROM tblHareketTipleri WHERE CarpimFaktoru > 0), 55, @m, GETDATE(), @a, 1, @t, @f)";

                        using (SqlCommand cmd = new SqlCommand(sql, baglanti, trans))
                        {
                            cmd.Parameters.AddWithValue("@u", row["UrunID"]);
                            cmd.Parameters.AddWithValue("@m", row["Miktar"]);
                            cmd.Parameters.AddWithValue("@a", row["GirisNedeni"]);
                            cmd.Parameters.AddWithValue("@t", cmbTedarikci.SelectedValue);
                            cmd.Parameters.AddWithValue("@f", row["FaturaNo"]);
                            cmd.ExecuteNonQuery();
                        }

                        
                        SqlCommand cmdUp = new SqlCommand("UPDATE tblUrunler SET MevcutStok += @m WHERE UrunID = @u", baglanti, trans);
                        cmdUp.Parameters.AddWithValue("@m", row["Miktar"]);
                        cmdUp.Parameters.AddWithValue("@u", row["UrunID"]);
                        cmdUp.ExecuteNonQuery();
                    }
                    trans.Commit();
                    MessageBox.Show("Kayıt Başarılı!");
                    stokDetaylari.Clear();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
            }
        }


      
        private void FormuTemizle()
        {
            stokDetaylari.Clear(); 
            cmbTedarikci.SelectedIndex = -1;
            cmbGirisNedeni.SelectedIndex = -1;
            txtFaturaNo.Clear();
            txtGirisMiktari.Clear();
            cmbUrunSecimi.SelectedIndex = -1;
           
        }

        private void txtGirisMiktari_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
           
            if (dgvStokDetaylari.SelectedRows.Count > 0)
            {
               
                dgvStokDetaylari.Rows.RemoveAt(dgvStokDetaylari.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Lütfen silinecek bir satır seçin.", "Uyarı");
            }
        }

        private void dgvStokDetaylari_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (dgvStokDetaylari.Columns[e.ColumnIndex].Name == "btnSilGrid" && e.RowIndex >= 0)
            {
               
                var cevap = MessageBox.Show("Bu ürünü listeden çıkarmak istiyor musunuz?", "Sil", MessageBoxButtons.YesNo);

                if (cevap == DialogResult.Yes)
                {
                   
                    dgvStokDetaylari.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
    }

}
