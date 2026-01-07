using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace edts {
    public partial class KullaniciBilgi : Form {
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
        int kullaniciID = 0;
        bool aktiflik = true;

        public KullaniciBilgi(int userID) {
            InitializeComponent();
            kullaniciID = userID;
            kullaniciBilgileriDoldur(kullaniciID);
            butonOlustur();
        }

        public KullaniciBilgi(string userID) {
            InitializeComponent();
            kullaniciStringKurulum(userID);
            kullaniciBilgileriDoldur(kullaniciID);
            butonOlustur();
        }

        private void kullaniciBilgileriDoldur(int id) {
            if (id == AktifKullanici.ID) { 
                lblAd.Text = AktifKullanici.TamAd;
                lblKullanici.Text = AktifKullanici.KullaniciAdi;
                lblYetki.Text = ((Sabitler.Rol)AktifKullanici.RolID).ToString();
            } else {
                string sorgu = "SELECT AdSoyad, KullaniciAdi, RolID, AktifMi FROM tblKullanicilar WHERE KullaniciID=@id";
                using(SqlConnection conn = new SqlConnection(baglantiDizesi)) {
                    try {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(sorgu, conn);
                        cmd.Parameters.AddWithValue("@id", id);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read()) {
                            lblAd.Text = reader.GetString(0);
                            lblKullanici.Text = reader.GetString(1);
                            lblYetki.Text = ((Sabitler.Rol)(int)reader["RolID"]).ToString();
                        } 
                    } catch (Exception ex) {
                        MessageBox.Show("Profil penceresi gösterilemiyor. Hata:\n"+ex.Message);
                    }
                }
            }
        }

        private void kullaniciStringKurulum(string id) {

            string sorgu = "SELECT KullaniciID FROM tblKullanicilar WHERE KullaniciAdi=@id";
            using (SqlConnection conn = new SqlConnection(baglantiDizesi)) {
                try {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sorgu, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) {
                        kullaniciID = (int)reader["KullaniciID"];
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Profil penceresi gösterilemiyor. Hata:\n" + ex.Message);
                }
                
            }
        }

        private void butonOlustur() {
            if (AktifKullanici.RolID == (int)Sabitler.Rol.Admin) {
                if(AktifKullanici.ID != kullaniciID) panelAdminAyar.Enabled = Visible;
                panelBildirim.Visible = true;
            }
            if (AktifKullanici.ID==kullaniciID) {
                panelKullaniciAyar.Visible = true;
            }
        }

        private void buttonKullaniciAyar_Click(object sender, EventArgs e) {

        }

        private void buttonBildirim_Click(object sender, EventArgs e) {

        }
    }
}
