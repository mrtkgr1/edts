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
using Microsoft.Data.SqlClient;

namespace edts
{
    public partial class frmAnaSayfa : Form
    {
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
        public frmAnaSayfa()
        {
            InitializeComponent();
           
        }
       
       
        private void pnlUstSol_Paint(object sender, PaintEventArgs e)
        {

        }


        private void OzetVerileriYukle()
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            {
                string sorgu = @"
            SELECT 
                -- 1. Grup: Genel Envanter
                (SELECT COUNT(*) FROM tblUrunler) AS ToplamCesit,
                (SELECT ISNULL(SUM(MevcutStok), 0) FROM tblUrunler) AS ToplamStok,
                (SELECT COUNT(*) FROM tblUrunler WHERE MevcutStok <= KritikStok) AS KritikAdet,
                (SELECT COUNT(*) FROM tblUrunler WHERE MevcutStok = 0) AS BitenAdet,
                
                -- 2. Grup: Bugünün Hareketleri (tblStokHareketleri üzerinden)
                -- Not: HareketID = 1 Giriş, HareketID = 2 Çıkış olarak varsayıldı
                (SELECT ISNULL(SUM(Miktar), 0) FROM tblStokHareketleri 
                 WHERE HareketID = 1 AND CAST(Tarih AS DATE) = CAST(GETDATE() AS DATE)) AS BugunGelen,
                
                (SELECT ISNULL(SUM(Miktar), 0) FROM tblStokHareketleri 
                 WHERE HareketID = 2 AND CAST(Tarih AS DATE) = CAST(GETDATE() AS DATE)) AS BugunCikan,
                
                -- 3. Grup: Kritik Bilgi
                (SELECT TOP 1 UrunAd FROM tblUrunler ORDER BY MevcutStok ASC) AS EnAzUrunAd,
                (SELECT TOP 1 MevcutStok FROM tblUrunler ORDER BY MevcutStok ASC) AS EnAzUrunMiktar
            ";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                try
                {
                    baglanti.Open();
                    SqlDataReader dr = komut.ExecuteReader();

                    if (dr.Read())
                    {
                       
                        lblToplamUrunCesidi.Text = dr["ToplamCesit"].ToString();
                        lblToplamStokMiktari.Text = Convert.ToDecimal(dr["ToplamStok"]).ToString("N0");
                        lblKritikStokAdet.Text = dr["KritikAdet"].ToString();
                        lblBitenUrunler.Text = dr["BitenAdet"].ToString();

                       
                        lblBugunGelen.Text = Convert.ToDecimal(dr["BugunGelen"]).ToString("N0");
                        lblBugunCikan.Text = Convert.ToDecimal(dr["BugunCikan"]).ToString("N0");

                        
                        lblEnAzUrunAd.Text = dr["EnAzUrunAd"].ToString() + " (" + dr["EnAzUrunMiktar"].ToString() + ")";
                       

                        
                        int kritik = Convert.ToInt32(dr["KritikAdet"]);
                        lblSistemMesaji.Text = kritik > 0 ? $"{kritik} Ürün Kritik Seviyede!" : "Her şey yolunda.";
                        lblSistemMesaji.ForeColor = kritik > 0 ? Color.Red : Color.Green;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }
        }


        private void frmAnaSayfa_Load(object sender, EventArgs e)
        {
            OzetVerileriYukle();
        }
    }
}
