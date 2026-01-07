using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Configuration;


namespace edts
{
    public partial class frmDepoRapor : Form
    {
        private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
        public frmDepoRapor()
        {
            InitializeComponent();
        }

        private void frmDepoRapor_Load(object sender, EventArgs e)
        {
            
            UrunleriGetir();
            IslemTipleriniGetir();

            
            dtBaslangic.Value = DateTime.Now.AddMonths(-1);
            dtBitis.Value = DateTime.Now;

           
            RaporuYukle();
           
            dgvStokRaporu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            
            dgvStokRaporu.Columns["Miktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvStokRaporu.Columns["Tarih"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

        }
        private void UrunleriGetir()
        {
            using (SqlConnection bag = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    bag.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT UrunID, UrunAd FROM tblUrunler ORDER BY UrunAd ASC", bag);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                   
                    DataRow dr = dt.NewRow();
                    dr["UrunID"] = 0;
                    dr["UrunAd"] = "--- Tümü ---";
                    dt.Rows.InsertAt(dr, 0);

                    cmbUrunler.DataSource = dt;
                    cmbUrunler.DisplayMember = "UrunAd";
                    cmbUrunler.ValueMember = "UrunID";
                }
                catch (Exception ex) { MessageBox.Show("Ürün listesi yüklenirken hata: " + ex.Message); }
            }
        }

        private void IslemTipleriniGetir()
        {
           
            cmbIslemTipi.Items.Clear();
            cmbIslemTipi.Items.Add("Tümü");
            cmbIslemTipi.Items.Add("Giriş");
            cmbIslemTipi.Items.Add("Çıkış");
            cmbIslemTipi.SelectedIndex = 0;
        }

        private void btnFiltreTemizle_Click(object sender, EventArgs e)
        {
            FiltreleriSifirla();
        }
        private void FiltreleriSifirla()
        {
            cmbUrunler.SelectedIndex = 0; 
            cmbIslemTipi.SelectedIndex = 0; 
            dtBaslangic.Value = DateTime.Now.AddMonths(-1); 
            dtBitis.Value = DateTime.Now;
            txtHizliAra.Clear();

            
        }

        private void txtHizliAra_TextChanged(object sender, EventArgs e)
        {
            
            DataTable dt = (DataTable)dgvStokRaporu.DataSource;

            if (dt != null)
            {
               
                dt.DefaultView.RowFilter = string.Format("UrunAd LIKE '%{0}%' OR UrunKodu LIKE '%{0}%'", txtHizliAra.Text);
            }
        }

        private void dgvStokRaporu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
            if (dgvStokRaporu.Columns[e.ColumnIndex].Name == "Miktar")
            {
                if (e.Value != null && Convert.ToDecimal(e.Value) <= 5) 
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                }
            }
        }

        private void btnRaporGetir_Click(object sender, EventArgs e)
        {
            RaporuYukle();
        }

        private void btnExcelAktar_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV Dosyası|*.csv";
            sfd.FileName = "Stok_Raporu_" + DateTime.Now.ToString("ddMMyyyy");

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                {
                    var headers = dgvStokRaporu.Columns.Cast<DataGridViewColumn>().Select(x => x.HeaderText);
                    sw.WriteLine(string.Join(";", headers));

                    foreach (DataGridViewRow row in dgvStokRaporu.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            var cells = row.Cells.Cast<DataGridViewCell>().Select(x => x.Value?.ToString() ?? "");
                            sw.WriteLine(string.Join(";", cells));
                        }
                    }
                }
                MessageBox.Show("Rapor Excel formatında kaydedildi!", "Başarılı");
            }
        }



        public void RaporuYukle()
        {
            using (SqlConnection bag = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    bag.Open();
                    string sorgu = @"SELECT 
                    sh.Tarih, 
                    u.UrunKodu as [UrunKodu], -- Köşeli parantez ve as kullanımı garantiye alır
                    u.UrunAd as [UrunAd], 
                    ht.HareketAd as [IslemTipi], 
                    sh.Miktar as [Miktar], 
                    ISNULL(b.BirimAd, 'Adet') as [BirimAd], 
                    d.DepoAd as [DepoAd],
                    sh.Aciklama as [Aciklama]
                 FROM tblStokHareketleri sh
                 LEFT JOIN tblUrunler u ON sh.UrunID = u.UrunID
                 LEFT JOIN tblHareketTipleri ht ON sh.HareketID = ht.HareketID
                 LEFT JOIN tblBirimler b ON u.BirimID = b.BirimID
                 LEFT JOIN tblDepolar d ON sh.DepoID = d.DepoID
                 WHERE (sh.Tarih >= @baslangic AND sh.Tarih <= @bitis)";

                   
                    if (cmbUrunler.SelectedValue != null && Convert.ToInt32(cmbUrunler.SelectedValue) > 0)
                    {
                        sorgu += " AND (sh.UrunID = @urunID)";
                    }

                    if (cmbIslemTipi.Text == "Giriş")
                        sorgu += " AND (ht.CarpimFaktoru > 0)";
                    else if (cmbIslemTipi.Text == "Çıkış")
                        sorgu += " AND (ht.CarpimFaktoru < 0)";

                    SqlCommand komut = new SqlCommand(sorgu, bag);

                  
                    komut.Parameters.Add("@baslangic", SqlDbType.DateTime).Value = dtBaslangic.Value.Date;
                    komut.Parameters.Add("@bitis", SqlDbType.DateTime).Value = dtBitis.Value.Date.AddDays(1).AddTicks(-1);

                    if (cmbUrunler.SelectedValue != null && Convert.ToInt32(cmbUrunler.SelectedValue) > 0)
                    {
                        komut.Parameters.Add("@urunID", SqlDbType.Int).Value = cmbUrunler.SelectedValue;
                    }

                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvStokRaporu.DataSource = dt;
                    void BaslikDuzenle(string kolonAdi, string yeniBaslik)
                    {
                        if (dgvStokRaporu.Columns.Contains(kolonAdi))
                        {
                            dgvStokRaporu.Columns[kolonAdi].HeaderText = yeniBaslik;
                        }
                    }
                    BaslikDuzenle("Tarih", "İşlem Tarihi");
                    BaslikDuzenle("UrunKodu", "Ürün Kodu");
                    BaslikDuzenle("UrunAd", "Ürün Adı");
                    BaslikDuzenle("IslemTipi", "İşlem Türü");
                    BaslikDuzenle("Miktar", "Miktar");
                    BaslikDuzenle("BirimAd", "Birim");
                    BaslikDuzenle("DepoAd", "Depo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
            }
        }
    }
}
