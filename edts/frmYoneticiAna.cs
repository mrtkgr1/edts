using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace edts
{
    public partial class frmYoneticiAna : Form
    {
        private const int CikisHareketID = 11;
        private bool isMenuAcik = true;
        public frmYoneticiAna()
        {
            InitializeComponent();
            SayfaGoster(new frmYoneticiHomeIcerik());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (isMenuAcik)
            {
                tableLayoutPanel1.ColumnStyles[0].Width = 90;
                isMenuAcik = false;
                label4.Visible = false;
            }
            else
            {
                tableLayoutPanel1.ColumnStyles[0].Width = 300;
                isMenuAcik = true;
                label4.Visible = true;
            }
        }

        private void SayfaGoster(Form yeniForm)
        {
            panel2.Controls.Clear();

            panel2.AutoScroll = true;

            yeniForm.TopLevel = false;

            yeniForm.FormBorderStyle = FormBorderStyle.None;

            yeniForm.Dock = DockStyle.Fill;

            panel2.Controls.Add(yeniForm);

            yeniForm.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            SayfaGoster(new frmSupport());
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            SayfaGoster(new frmUrunYonetimi());
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SayfaGoster(new frmGenelRaporlar());
        }

        private void pbAnasayfa_Click(object sender, EventArgs e)
        {
            SayfaGoster(new frmYoneticiHomeIcerik());
        }

        private void anaMet(object sender, EventArgs e)
        {
            SayfaGoster(new frmYoneticiHomeIcerik());
        }

        private void urunMet(object sender, EventArgs e)
        {
            SayfaGoster(new frmUrunYonetimi());
        }

        private void raporMet(object sender, EventArgs e)
        {
            SayfaGoster(new frmGenelRaporlar());
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
                VeritabaniYardimcisi.LogKaydet(
                    kullaniciID: AktifKullanici.ID,
                    hareketID: CikisHareketID,
                    tabloAdi: "tblKullanicilar",
                    aciklama: AktifKullanici.KullaniciAdi + " ikon üzerinden çıkış yaptı."
                );

                AktifKullanici.ID = 0;
                AktifKullanici.KullaniciAdi = "";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Çıkış logu kaydedilirken hata oluştu: " + ex.Message);
            }

            this.Close();
            edts.GirisForm girisFormu = new edts.GirisForm();
            girisFormu.Show();
        }

        private void pbChatbottt_Click(object sender, EventArgs e)
        {
            ChatbotYonetici chat = new ChatbotYonetici();
            chat.ShowDialog();
        }

        private void lblChatBottt_Click(object sender, EventArgs e)
        {
            ChatbotYonetici chat = new ChatbotYonetici();
            chat.ShowDialog();
        }
    }
}
