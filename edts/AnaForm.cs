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
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        public AnaForm() {
            InitializeComponent();
            InitializeSecenekPopup();
            InitializeProfilePopup();
            SolMenuButtonAyarla();
            KontrolFormGoster();
        }

        //-----Sayfa gösterme işlemleri -----
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
        }

        private void SolMenuButtonAyarla() {
            panelKontrol.Visible = true;

            kayitMenuPanel.Visible = AktifKullanici.RolID == (int)Sabitler.Rol.Yonetici;
            panelRapor.Visible = AktifKullanici.RolID == (int)Sabitler.Rol.Yonetici;

        }

        //-----Menü açma kapama işlemleri -----
        bool isKayitMenuAcik = false;
        private void menuHareket_Tick(object sender, EventArgs e) {
            if (isKayitMenuAcik) {
                kayitMenuPanel.Height -= 10;
                if (kayitMenuPanel.Height <= 49) {
                    isKayitMenuAcik = false;
                    menuKayitHareket.Stop();
                }
            } else {
                kayitMenuPanel.Height += 10;
                if (kayitMenuPanel.Height >= 240) {
                    isKayitMenuAcik = true;
                    menuKayitHareket.Stop();
                }
            }
        }

        bool yanMenuAcik = true;
        private void yanPanel_Tick(object sender, EventArgs e) {
            if (yanMenuAcik) {
                yanMenuPanel.Width -= 10;
                if (yanMenuPanel.Width <= 53) {
                    yanMenuAcik = false;
                    yanPanelHareket.Stop();
                }
            } else {
                yanMenuPanel.Width += 10;
                if (yanMenuPanel.Width >= 172) {
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

        //-----Form kontrol buton işlemleri -----
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
                prefPictureBox.Image = Properties.Resources.kayan_liste_assa;
                isListeAcik = false;
            } else {
                popup.Show(senderControl, popup.Size.Width/2*-1+16, senderControl.Height);
                prefPictureBox.Image = Properties.Resources.kayan_liste_yukari;
                isListeAcik = true;
            }
        }
        private void prefSecenekMenuKapat(object sender, ToolStripDropDownClosedEventArgs e) {
            isListeAcik = false;
            prefPictureBox.Image = Properties.Resources.kayan_liste_assa;
        }

        bool bildiirmVar = true;
        private void pictureBox4_Click(object sender, EventArgs e) {

            if (bildiirmVar) {
                pictureBox4.Image = Properties.Resources.notf_var;
                bildiirmVar = false;
            } else {
                kayitMenuPanel.Visible = true;
                pictureBox4.Image = Properties.Resources.notf_yok;
            }
        }

        private void kullaniciAyarlari_Tiklandi() {
            MessageBox.Show("Kullanıcı ayarları tıklandı.");
        }

        private void hesapDuzenle_Tiklandi() {
            MessageBox.Show("Hesap düzenle tıklandı.");
        }

        //-----Form çerçeve işlemleri ----- 
        //
        private void panel1_MouseDown(object sender, MouseEventArgs e) {
            ReleaseCapture(); //Panelin fare ileetkileşimini kesiyoruz
            //normalde windows uygulama için çerçeve çizer ve o çerçeve üzerinden taşıma işlemi yapar
            //SendMessage ile genel api kullanarak windowsa tıklanan panele, çerçeve gibi davranmasını söylüyoruz
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            //Tasıma işlemini windowsa bırakıyoruz
        }

        //WndProc: windows ile programın iletişimi yönetiyor
        //override ederek manipüle ediyoruz
        protected override void WndProc(ref Message m) {
            const int WM_NCCALCSIZE = 0x0083;
            const int WM_NCHITTEST = 0x0084;
            const int resizeArea = 10;

            //WM_NCCALCSIZE: windows çerçeve çizmek için programa boyut soruları soruyor
            //Base.WndProc çalışmadan return diyoruz winforms bilgileri veremiyor, çerçeve olmuyor
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1) {
                return;
            }

            //Boyutlandırma 
            //WM_NCHITTEST: windows fare imlecinin nerede olduğunu soruyor
            if (m.Msg == WM_NCHITTEST) {
                base.WndProc(ref m);
                //1 çıktısıÇ fare boş alan üzerinde
                if ((int)m.Result == 1) {

                    //Farenin konumunu pencerenin sol üst köşesine göre alıyor
                    Point screenPoint = new Point(m.LParam.ToInt32());
                    Point clientPoint = this.PointToClient(screenPoint);

                    //Farenin, pencrenin hangi kenar/köşesinde olduğunu tespit edip sayısal kodu windowsa veriyor
                    if (clientPoint.Y <= resizeArea) { // üst kontrol
                        if (clientPoint.X <= resizeArea) m.Result = (IntPtr)13; //sol üst
                        else if (clientPoint.X >= (this.Size.Width - resizeArea)) m.Result = (IntPtr)14; //sağ üst
                        else m.Result = (IntPtr)12; //üst
                    } else if (clientPoint.Y >= (this.Size.Height - resizeArea)) {// alt kontrol
                        if (clientPoint.X <= resizeArea) m.Result = (IntPtr)16; //sol alt
                        else if (clientPoint.X >= (this.Size.Width - resizeArea)) m.Result = (IntPtr)17; //sağ alt
                        else m.Result = (IntPtr)15; //alt
                    } else { // sol-sağ kontrol
                        if (clientPoint.X <= resizeArea) m.Result = (IntPtr)10; //sol
                        else if (clientPoint.X >= (this.Size.Width - resizeArea)) m.Result = (IntPtr)11; //sağ
                    }
                }
                return;
            }

            //Farenin, elemanlar (textbox,button vb.) ile etkileşimini sağlamak için base çağrısı yapıyoruz
            base.WndProc(ref m);
        }

        // Kodda fare pencerenin içinde ve kenare 10 pixel yakında ise boyutlandırma yapıyor
        // Aynı anda hem boyutlandırma hem eleman etkileşimi olamaz ve kenara 10 pixel elemalar çalışmaz
        // Butonlar ayarlansa bile scroll bar mecbur kenarda olacak
        // Fare elemanın üstünde değil diye kontrol yapıyoruz
        // Farenin hem pencere içinde olması hem de bir elemanın üstünde olmaması lazım
        // Tüm sahnede panel doluğu için boşluk yani Padding ekliyoruz
        // Yine çerçeve oluyor ancak her kenarın boyutunu ayarlayabiliyoruz, üst panelde grinin üzerinde beyaz güzel durmuyordu

        private void AnaForm_Resize(object sender, EventArgs e) {
            //Tam ekran yapıldığında windows kenarlardan 8 pixel ekran dışına çıkartıyor.
            //Tam ekran yapınca fazladan boşluk ekliyoruz
            if (this.WindowState == FormWindowState.Maximized) {
                if (this.Padding.All != 8) this.Padding = new Padding(8);
            } else {
                Padding hedefPadding = new Padding(2, 1, 4, 4);
                if (this.Padding != hedefPadding) this.Padding = hedefPadding;
            }
        }


        //-----Yan menü buton işlemleri -----

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
                    SayfaGoster(new frmYoneticiHomeIcerik());
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
            popupHesap.Show(senderControl, popupHesap.Size.Width/2*-1+16, senderControl.Height);
        }
    }
}
