using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace edts
{
    public partial class frmAdminHomeIcerik : Form
    {
        public frmAdminHomeIcerik()
        {
            InitializeComponent();
        }

        private void frmAdminHomeIcerik_Load(object sender, EventArgs e)
        {
            const int ADMIN_ROL_ID = 1;
            const int YONETICI_ROL_ID = 2;
            const int DEPO_ROL_ID = 3;


            try
            {
                int toplamKullanici = VeritabaniYardimcisi.KayitSayisiGetir("tblKullanicilar");
                lblToplamKullaniciSayisi.Text = toplamKullanici.ToString();

                int kilitliSayisi = VeritabaniYardimcisi.KayitSayisiGetir("tblKullanicilar", "AktifMi = 0");
                lblKilitliHesapSayisi.Text = kilitliSayisi.ToString();


                int adminSayisi = VeritabaniYardimcisi.KayitSayisiGetir("tblKullanicilar", $"RolID = {ADMIN_ROL_ID} AND AktifMi = 1");
                lblAdminSayisi.Text = adminSayisi.ToString();

                int yoneticiSayisi = VeritabaniYardimcisi.KayitSayisiGetir("tblKullanicilar", $"RolID = {YONETICI_ROL_ID} AND AktifMi = 1");
                lblYoneticiSayisi.Text = yoneticiSayisi.ToString();

                int depoSayisi = VeritabaniYardimcisi.KayitSayisiGetir("tblKullanicilar", $"RolID = {DEPO_ROL_ID} AND AktifMi = 1");
                lblDepoPersoneliSayisi.Text = depoSayisi.ToString();


                lblEskiSifreKullananSayisi.Text = "0";

                lblAdminOturumlariSayisi.Text = "0";

                lblBekleyenIslemSayisi.Text = "0";

                lblHataKayitlariSayisi.Text = "0";

            }
            catch (Exception ex)
            {
                MessageBox.Show("İstatistikler yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                lblToplamKullaniciSayisi.Text = "-";
                lblKilitliHesapSayisi.Text = "-";
                lblYoneticiSayisi.Text = "-";
                lblDepoPersoneliSayisi.Text = "-";
                lblAdminSayisi.Text = "-";
                lblEskiSifreKullananSayisi.Text = "-";
                lblAdminOturumlariSayisi.Text = "-";
                lblBekleyenIslemSayisi.Text = "-";
                lblHataKayitlariSayisi.Text = "-";
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
