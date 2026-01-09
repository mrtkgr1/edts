using edts.Properties;
using EnvanterDepoSistemitaslak2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace edts {
    public partial class AnaForm : Form {
        public static AnaForm? reff;

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        public AnaForm() {
            reff = this;
            InitializeComponent();
            InitializeSecenekPopup();
            InitializeProfilePopup();
            SolMenuButtonAyarla();
            KontrolFormGoster();
            SolPanelScroll();
            AyarKurulum();
        }

        private void SolPanelScroll() {
            SolHPanel.MouseWheel += Panel_MouseWheel!;

            SolHPanel.MouseEnter += (s, e) => SolHPanel.Focus();
            yanMenuPanel.MouseEnter += (s, e) => SolHPanel.Focus();
        }

        private void Panel_MouseWheel(object sender, MouseEventArgs e) {

            if (yanMenuPanel.Height <= SolHPanel.Height) return;

            int yeniY;

            if (e.Delta > 0) {
                yeniY = yanMenuPanel.Top + 20;
            } else {
                yeniY = yanMenuPanel.Top - 20;
            }

            if (yeniY > 0) yeniY = 0;


            int minY = SolHPanel.Height - yanMenuPanel.Height;
            if (yeniY < minY) yeniY = minY;

            yanMenuPanel.Top = yeniY;
        }

        private void SayfaGoster(Form yeniForm) {
            if (panelForm.Controls.Count > 0) {
                panelForm.Controls[0].Dispose();
            }
            panelForm.Controls.Clear();


            panelForm.AutoScroll = true;
            yeniForm.TopLevel = false;
            yeniForm.FormBorderStyle = FormBorderStyle.None;
            yeniForm.Dock = DockStyle.Fill;

            panelForm.Controls.Add(yeniForm);
            yeniForm.Show();

            labelBaslik.Text = yeniForm.Name;
        }

        private void SolMenuButtonAyarla() {
            panelKontrol.Visible = true;

            kayitMenuPanel.Visible = AktifKullanici.RolID == (int)Sabitler.Rol.Yonetici;
            panelRapor.Visible = AktifKullanici.RolID == (int)Sabitler.Rol.Yonetici;
            panelSatisF.Visible = AktifKullanici.RolID == (int)Sabitler.Rol.Yonetici;

            panelSolSistemA.Visible = AktifKullanici.RolID == (int)Sabitler.Rol.Admin;
            panelSolDenetinK.Visible = AktifKullanici.RolID == (int)Sabitler.Rol.Admin;
            panelSolKullaniciA.Visible = AktifKullanici.RolID == (int)Sabitler.Rol.Admin;

            panelSolStokG.Visible = AktifKullanici.RolID == (int)Sabitler.Rol.Personel;
            panelSolStokC.Visible = AktifKullanici.RolID == (int)Sabitler.Rol.Personel;
            panelSolStokL.Visible = AktifKullanici.RolID == (int)Sabitler.Rol.Personel;
            panelRaporDepo.Visible = AktifKullanici.RolID == (int)Sabitler.Rol.Personel;

        }

       
        public void AyarKurulum() {
            TemaGuncelle();

        }
        public void TemaGuncelle() {
            TemaYonetim.TemaDegistir(AyarYonetimi.AyarGetir("tema"));
            Tema tema = (TemaYonetim.TemaAl());

            if (tema.siyahIcon) {
                pictureBox1.Image = Resources.menu_siyah;
                prefPictureBox.Image = Resources.kayan_liste_assa;
                pictureBoxProfile.Image = Resources.profile_siyah;
                pictureBoxNotf.Image = Resources.notf_yok;
                panel1.ForeColor = Color.Black;
            } else {
                pictureBox1.Image = Resources.menu_beyaz;
                prefPictureBox.Image = Resources.kayan_liste_beyaz_assa;
                pictureBoxProfile.Image = Resources.profile_beyaz;
                pictureBoxNotf.Image = Resources.notf_yok_beyaz;
                panel1.ForeColor = Color.White;
            }

            panel1.BackColor = tema.ustPanelArkaPlan;
            SolHPanel.BackColor = tema.solMenuArkaPlan;
            panelMenuKayit.BackColor = tema.solMenuArkaPlan;
            SolHPanel.ForeColor = tema.yaziRengi;

            kayitMenuPanel.BackColor = tema.solMenuAltMenu;
        }

        bool isKayitMenuAcik = false;
        private void menuHareket_Tick(object sender, EventArgs e) {
            if (isKayitMenuAcik) {
                kayitMenuPanel.AutoSize = false;
                kayitMenuPanel.Height -= 10;
                if (kayitMenuPanel.Height <= 49) {
                    isKayitMenuAcik = false;
                    menuKayitHareket.Stop();
                }
            } else {
                kayitMenuPanel.Height += 10;
                if (kayitMenuPanel.Height >= 250) {
                    isKayitMenuAcik = true;
                    menuKayitHareket.Stop();
                    kayitMenuPanel.AutoSize = true;
                }
            }
        }

        bool yanMenuAcik = true;
        private void yanPanel_Tick(object sender, EventArgs e) {
            if (yanMenuAcik) {
                SolHPanel.Width -= 10;
                if (SolHPanel.Width <= 53) {
                    SolHPanel.Width = 53;
                    yanMenuAcik = false;
                    yanPanelHareket.Stop();
                }
            } else {
                SolHPanel.Width += 10;
                if (SolHPanel.Width >= 172) {
                    yanMenuAcik = true;
                    yanPanelHareket.Stop();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) {
            yanPanelHareket.Start();
        }

        private void button4_Click(object sender, EventArgs e) {
            menuKayitHareket.Start();
        }

        private void button8_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnBuyut_Click(object sender, EventArgs e) {
            if (this.WindowState == FormWindowState.Maximized) {
                this.WindowState = FormWindowState.Normal;
                btnBuyut.Text = "1";
            } else {
                this.WindowState = FormWindowState.Maximized;
                btnBuyut.Text = "2";
            }
        }

        bool isListeAcik = false;
        private void prefPictureBox_click(object sender, EventArgs e) {
            Control senderControl = (Control)sender;
            if (isListeAcik) {
                prefPictureBox.Image = (TemaYonetim.TemaAl().siyahIcon ? 
                    Resources.kayan_liste_assa : Resources.kayan_liste_beyaz_assa);
                isListeAcik = false;
            } else {
                popup.Show(senderControl, popup.Size.Width / 2 * -1 + 16, senderControl.Height);
                prefPictureBox.Image = (TemaYonetim.TemaAl().siyahIcon ?
                    Resources.kayan_liste_yukari : Resources.kayan_liste_beyaz_yukari);
                isListeAcik = true;
            }
        }
        private void prefSecenekMenuKapat(object sender, ToolStripDropDownClosedEventArgs e) {
            isListeAcik = false;
            prefPictureBox.Image = Properties.Resources.kayan_liste_assa;
        }

        bool bildiirmVar = true;
        private void pictureBox4_Click(object sender, EventArgs e) {
            BildirimGoster("xsa","sasa");
            if (bildiirmVar) {
                pictureBoxNotf.Image = Properties.Resources.notf_var;
                bildiirmVar = false;
            } else {
                kayitMenuPanel.Visible = true;
                pictureBoxNotf.Image = Properties.Resources.notf_yok;
            }
        }
        public void BildirimGoster(string baslik, string mesaj) {
            NotifyIcon bildirimCubugu = new NotifyIcon();

            bildirimCubugu.Icon = SystemIcons.Information;

            
            bildirimCubugu.Visible = true;

            bildirimCubugu.ShowBalloonTip(3000, baslik, mesaj, ToolTipIcon.Info);

        }

        private void kullaniciAyarlari_Tiklandi() {
            SayfaGoster(new frmKullaniciAyarlari());
        }

        private void hesapDuzenle_Tiklandi() {
            KullaniciBilgi tmp = new KullaniciBilgi(AktifKullanici.ID);
            tmp.ShowDialog();
        }

        
        private void panel1_MouseDown(object sender, MouseEventArgs e) {
            ReleaseCapture();
            
            SendMessage(this.Handle, 0x112, 0xf012, 0);
           
        }

        protected override void WndProc(ref Message m) {
            const int WM_NCCALCSIZE = 0x0083;
            const int WM_NCHITTEST = 0x0084;
            const int resizeArea = 10;

            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1) {
                return;
            }

            
            if (m.Msg == WM_NCHITTEST) {
                base.WndProc(ref m);
               
                if ((int)m.Result == 1) {

                    Point screenPoint = new Point(m.LParam.ToInt32());
                    Point clientPoint = this.PointToClient(screenPoint);

                    if (clientPoint.Y <= resizeArea) { 
                        if (clientPoint.X <= resizeArea) m.Result = (IntPtr)13; 
                        else if (clientPoint.X >= (this.Size.Width - resizeArea)) m.Result = (IntPtr)14; 
                        else m.Result = (IntPtr)12; 
                    } else if (clientPoint.Y >= (this.Size.Height - resizeArea)) {
                        if (clientPoint.X <= resizeArea) m.Result = (IntPtr)16; 
                        else if (clientPoint.X >= (this.Size.Width - resizeArea)) m.Result = (IntPtr)17;
                        else m.Result = (IntPtr)15; 
                    } else { 
                        if (clientPoint.X <= resizeArea) m.Result = (IntPtr)10; 
                        else if (clientPoint.X >= (this.Size.Width - resizeArea)) m.Result = (IntPtr)11; 
                    }
                }
                return;
            }

            base.WndProc(ref m);
        }

       
        private void AnaForm_Resize(object sender, EventArgs e) {
            if (this.WindowState == FormWindowState.Maximized) {
                if (this.Padding.All != 8) this.Padding = new Padding(8);
            } else {
                Padding hedefPadding = new Padding(2, 1, 4, 4);
                if (this.Padding != hedefPadding) this.Padding = hedefPadding;
            }
        }



        private void buttonKontrol_Click(object sender, EventArgs e) {
            KontrolFormGoster();
        }
        private void KontrolFormGoster() {
            switch (AktifKullanici.RolID) {
                case (int)Sabitler.Rol.Admin:
                    SayfaGoster(new frmAdminHomeIcerik());
                    break;

                case (int)Sabitler.Rol.Yonetici:
                    SayfaGoster(new frmYoneticiHomeIcerik());
                    break;

                case (int)Sabitler.Rol.Personel:
                    SayfaGoster(new frmAnaSayfa());
                    break;
                default:
                    break;
            }
        }

        private void buttonUrunK_Click(object sender, EventArgs e) {
            SayfaGoster(new frmUrunYonetimi());
        }

        private void buttonRapor_Click(object sender, EventArgs e) {
            SayfaGoster(new frmGenelRaporlar());
        }

        private void pictureBox3_Click(object sender, EventArgs e) {
            Control senderControl = (Control)sender;
            popupHesap.Show(senderControl, popupHesap.Size.Width / 2 * -1 + 16, senderControl.Height);
        }

        private void buttonSistemAyar_Click(object sender, EventArgs e) {
            SayfaGoster(new SistemAyarlari());
        }

        private void buttonDenetimKayit_Click(object sender, EventArgs e) {
            SayfaGoster(new frmAdminDenetimKayitlari());
        }

        private void buttonKullaniciAyar_Click(object sender, EventArgs e) {
            SayfaGoster(new frmKullaniciYonetimi());
        }

        private void buttonSolStokG_Click(object sender, EventArgs e) {
            SayfaGoster(new frmStokGiris());
        }

        private void buttonStokList_Click(object sender, EventArgs e) {
            SayfaGoster(new frmStokListele());
        }

        private void buttonSolStokCıkış_Click(object sender, EventArgs e) {
            SayfaGoster(new frmStokCikis());
        }

        private void buttonDestek_Click(object sender, EventArgs e) {
            SayfaGoster(new frmSupport());
        }

        private void buttonChatBot_Click(object sender, EventArgs e) {
            switch (AktifKullanici.RolID) {
                case (int)Sabitler.Rol.Admin:
                    SayfaGoster(new ChatbotForm());
                    break;

                case (int)Sabitler.Rol.Yonetici:
                    SayfaGoster(new ChatbotYonetici());
                    break;

                case (int)Sabitler.Rol.Personel:
                    SayfaGoster(new ChatbotDepo());
                    break;
                default:
                    break;
            }
        }

        private void buttonRaporDEpo_Click(object sender, EventArgs e) {
            SayfaGoster(new frmDepoRapor());
        }

        private void buttonSolKategoriK_Click(object sender, EventArgs e) {
            SayfaGoster(new frmKategoriYonetimi());
        }

        private void buttonSolMusteriK_Click(object sender, EventArgs e) {
            SayfaGoster(new frmMusteriTanimlama());
        }

        private void buttonSolTedarikciK_Click(object sender, EventArgs e) {
            SayfaGoster(new frmTedarikciYonetim());
        }

        private void buttonSatisF_Click(object sender, EventArgs e) {
            SayfaGoster(new frmSatisFatura());
        }
    }
}
