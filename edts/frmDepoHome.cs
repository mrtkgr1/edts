using EnvanterDepoSistemitaslak2;
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

    public partial class frmDepoHome : Form
    {


        public frmDepoHome()
        {
            InitializeComponent();
           
            IcerikYukle(new frmAnaSayfa());

        }
        private void IcerikYukle(Form yeniForm)
        {
            pnlAnaIcerik.Controls.Clear();
            yeniForm.TopLevel = false;
            yeniForm.FormBorderStyle = FormBorderStyle.None;
            yeniForm.Dock = DockStyle.Fill;
            pnlAnaIcerik.Controls.Add(yeniForm);
            yeniForm.Show();
        }
        private int ayarlarMenuDurum = 0;

        private void frmDepoHome_Load(object sender, EventArgs e)
        {

        }


        private void pbxAyarlar_Click(object sender, EventArgs e)
        {
           
            bool mevcutDurum = lblDestek.Visible;

            
            bool yeniDurum = !mevcutDurum;

           
            lblDestek.Visible = yeniDurum;
            pbxDestek.Visible = yeniDurum;

            lblCikisYap.Visible = yeniDurum;
            pbxCikisYap.Visible = yeniDurum;

           
        }

        private void pbxCikisYap_Click(object sender, EventArgs e)
        {
           
            lblCikisYap_Click(sender, e);
        }

        private void lblCikisYap_Click(object sender, EventArgs e)
        {
            VeritabaniYardimcisi.LogKaydet(
         kullaniciID: AktifKullanici.ID,
         hareketID: 11,
         tabloAdi: "tblKullanicilar",
         aciklama: AktifKullanici.KullaniciAdi + " ikon üzerinden çıkış yaptı."
     );
           
            this.Hide();
            this.Close();

            
            GirisForm loginFormu = new GirisForm();
            loginFormu.Show();
        }

        private void lblDestek_Click(object sender, EventArgs e)
        {
            
            frmSupport supportForm = new frmSupport();

           
            IcerikYukle(supportForm);
        }

        private void pbxDestek_Click(object sender, EventArgs e)
        {
            
            lblDestek_Click(sender, e);
        }

        private void pbxKategori_Click(object sender, EventArgs e)
        {
            ayarlarMenuDurum++;

           
            Control[] tumMenüKontrolleri = new Control[]
            {
       
        pbxAnasayfa, pbxStokGiris, pbxStokCikis, pbxRapor, pbxStokListele, pbxDestek, pbxCikisYap,
        
       
       lblAnaSayfa, lblStokGiris, lblStokCikis, lblRapor, lblStokListele, lblDestek, lblCikisYap,lblAyarlar
            };


            if (ayarlarMenuDurum == 1)
            {

                foreach (Control control in tumMenüKontrolleri)
                {
                    if (control is PictureBox)
                    {
                        control.Visible = true;
                    }
                    else if (control is Label)
                    {
                        control.Visible = false;
                    }
                }
            }
            else if (ayarlarMenuDurum == 2)
            {

                foreach (Control control in tumMenüKontrolleri)
                {
                    control.Visible = true; 
                }

                ayarlarMenuDurum = 0;
            }
            else
            {

                foreach (Control control in tumMenüKontrolleri)
                {
                    control.Visible = false;
                }

                ayarlarMenuDurum = 0;
            }
        }

        private void pbxStokGiris_Click(object sender, EventArgs e)
        {
            lblStokGiris_Click(sender, e); 
        }

        private void lblStokGiris_Click(object sender, EventArgs e)
        {
            IcerikYukle(new frmStokGiris()); 
        }

        private void pbxRapor_Click(object sender, EventArgs e)
        {
            lblRapor_Click(sender, e); 
        }

        private void lblRapor_Click(object sender, EventArgs e)
        {
            IcerikYukle(new frmDepoRapor());
        }

        private void lblStokListele_Click(object sender, EventArgs e)
        {
            IcerikYukle(new frmStokListele());
        }

        private void pbxStokListele_Click(object sender, EventArgs e)
        {
            lblStokListele_Click(sender, e); 
        }

        private void lblStokCikis_Click(object sender, EventArgs e)
        {
            IcerikYukle(new frmStokCikis());
        }

        private void pbxStokCikis_Click(object sender, EventArgs e)
        {
            lblStokCikis_Click(sender, e); 
        }

        private void lblAnaSayfa_Click(object sender, EventArgs e)
        {
            IcerikYukle(new frmAnaSayfa());
        }

        private void pbxAnasayfa_Click(object sender, EventArgs e)
        {
            lblAnaSayfa_Click(sender, e); 
        }

        private void pbChatbott_Click(object sender, EventArgs e)
        {
            lblChatBott_Click(sender, e);
        }

        private void lblChatBott_Click(object sender, EventArgs e)
        {
            IcerikYukle(new ChatbotDepo());
        }
    }
}

