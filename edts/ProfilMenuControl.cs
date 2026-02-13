using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace edts {
    public partial class ProfilMenuControl : UserControl {
        public event EventHandler ProfilDuzenleTiklandi;
        public event EventHandler AyarlarTiklandi;

        public ProfilMenuControl() {
            InitializeComponent();
            AdlariYaz();
            
        }

        private void AdlariYaz() {
            fullAd.Text = (AktifKullanici.TamAd != null ? AktifKullanici.TamAd : "");
            userAd.Text = AktifKullanici.KullaniciAdi;
            rolAd.Text = ((Sabitler.Rol)AktifKullanici.RolID).ToString();

            Image? profilResmi = GorselYonetim.Yukle(AktifKullanici.ID, "profil_resmi");
            if (profilResmi != null) {
                pictureBox1.Image = profilResmi;
            } else {
                pictureBox1.Image = Properties.Resources.var_pp;
            }
        }
        private void btnProfile_Click(object sender, EventArgs e) {
            ProfilDuzenleTiklandi?.Invoke(this, EventArgs.Empty);
            AdlariYaz();
        }

        private void btnAyarlar_Click(object sender, EventArgs e) {
            AyarlarTiklandi?.Invoke(this, EventArgs.Empty);
            AdlariYaz();
        }
    }

}
