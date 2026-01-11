using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using static Azure.Core.HttpHeader;

namespace edts {
    public partial class frmKullaniciAyarlari : Form {
        public frmKullaniciAyarlari() {
            InitializeComponent();
            AyarListesiOlustur();
        }
        private void AyarListesiOlustur() {
            pnlSettings.Controls.Clear();
            pnlSettings.AutoScroll = true;
            pnlSettings.VerticalScroll.Enabled = false;

            pnlSettings.FlowDirection = FlowDirection.LeftToRight;
            pnlSettings.WrapContents = true;
            pnlSettings.Dock = DockStyle.Fill;
            pnlSettings.BackColor = Color.FromArgb(245, 245, 245);
            pnlSettings.Padding = new Padding(0, 0, 0, 80);

            pnlSettings.SizeChanged -= PnlSettings_SizeChanged;
            pnlSettings.SizeChanged += PnlSettings_SizeChanged;

            var gruplar = AyarYonetimi.Ayarlar.GroupBy(x => x.Kategori);

            foreach (var grup in gruplar) {
                Label lblBaslik = new Label();
                lblBaslik.Text = grup.Key.ToUpper();
                lblBaslik.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                lblBaslik.ForeColor = Color.DimGray;
                lblBaslik.AutoSize = true;

                pnlSettings.Controls.Add(lblBaslik);
                pnlSettings.SetFlowBreak(lblBaslik, true); 

                foreach (var ayar in grup) {
                    Panel pnlSatir = new Panel();
                    pnlSatir.Height = 55;
                    pnlSatir.BackColor = Color.White;
                    pnlSatir.Margin = new Padding(0, 1, 0, 0);

                    Label lbl = new Label();
                    lbl.Text = ayar.AyarAdi;
                    lbl.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    lbl.AutoSize = false;
                    lbl.TextAlign = ContentAlignment.MiddleLeft;
                    lbl.Dock = DockStyle.Left;
                    lbl.Width = 450;
                    lbl.Padding = new Padding(15, 0, 0, 0);

                    Control inputControl = AyarOzelKontrolOlustur(ayar); 

                    Panel pnlDegerInput = new Panel();
                    pnlDegerInput.Dock = DockStyle.Right;
                    pnlDegerInput.Width = 200;
                    pnlDegerInput.Padding = new Padding(0, 15, 15, 0);
                    pnlDegerInput.Controls.Add(inputControl);

                    pnlSatir.Controls.Add(pnlDegerInput);
                    pnlSatir.Controls.Add(lbl);


                    pnlSettings.Controls.Add(pnlSatir);
                    pnlSettings.SetFlowBreak(pnlSatir, true);

                    if(inputControl is ComboBox combo) {
                        if (AyarYonetimi.SecenekListesi.TryGetValue(ayar.Id, out (string, string)[] v)) {
                            List<ComboboxDItem> itms = ComboboxDItem.ListeOlustur(v);
                            combo.DisplayMember = "text";
                            combo.ValueMember = "id";
                            combo.DataSource = itms;

                            ComboboxDItem secilecekOge = itms.FirstOrDefault(x => x.id == ayar.Deger);
                            if (secilecekOge != null) {
                                combo.SelectedItem = secilecekOge;
                            }
                        }
                    }
                }
            }



            PnlSettings_SizeChanged(null, null);
        }
        private void PnlSettings_SizeChanged(object sender, EventArgs e) {
            pnlSettings.SuspendLayout();

            int maxGenislik = 800;

            int formGenislik = pnlSettings.ClientSize.Width - 25;

            int hedefGenislik = Math.Min(formGenislik, maxGenislik);
            int solBosluk = (pnlSettings.ClientSize.Width - hedefGenislik) / 2;

            if (solBosluk < 0) solBosluk = 0;

            foreach (Control child in pnlSettings.Controls) {
                if (child is Label) {
                    child.Margin = new Padding(solBosluk, 25, 0, 5);
                } else {
                    child.Width = hedefGenislik;
                    child.Margin = new Padding(solBosluk, 1, 0, 0);
                }
            }

            btnKayit.Location = new Point((pnlSettings.ClientSize.Width - btnKayit.Width) / 2, 0);

            pnlSettings.ResumeLayout();
        }

        public Control AyarOzelKontrolOlustur(KullaniciAyar ayarG) {
            Control resultControl;

            switch (ayarG.Tur) {
                case AyarTuru.Mantik:
                    CheckBox chk = new CheckBox();
                    chk.Text = "";
                    chk.Checked = AyarYonetimi.AyarBoolGetir(ayarG.Id);
                    chk.Tag = ayarG;
                    chk.AutoSize = true;
                    chk.Dock = DockStyle.Right;
                    resultControl = chk;
                    break;

                case AyarTuru.Sayi:
                    NumericUpDown num = new NumericUpDown();
                    num.Value = AyarYonetimi.AyarIntGetir(ayarG.Id);
                    num.Maximum = 99999;
                    num.Tag = ayarG;
                    num.Width = 80;
                    num.Dock = DockStyle.Right;
                    resultControl = num;
                    break;

                case AyarTuru.Sifre:
                    TextBox txtPass = new TextBox();
                    txtPass.Text = ayarG.Deger.ToString();
                    txtPass.UseSystemPasswordChar = true;
                    txtPass.Tag = ayarG;
                    txtPass.Width = 150;
                    txtPass.Dock = DockStyle.Right;
                    resultControl = txtPass;
                    break;
                case AyarTuru.Liste:
                    ComboBox combo = new ComboBox();
                    combo.Tag = ayarG;
                    combo.Width = 150;
                    combo.Dock = DockStyle.Right;

                    

                    resultControl = combo;
                    break;
                case AyarTuru.Metin:
                default:
                    TextBox txt = new TextBox();
                    txt.Text = ayarG.Deger.ToString();
                    txt.Tag = ayarG;
                    txt.Width = 150;
                    txt.Dock = DockStyle.Right;
                    resultControl = txt;
                    break;
            }
            return resultControl;
        }

        private void BtnSave_Click(object sender, EventArgs e) {
            foreach (Control row in pnlSettings.Controls) {
                foreach (Control row2 in row.Controls) {
                    foreach (Control ctrl in row2.Controls) {
                        if(ctrl == null) continue;

                        if (ctrl.Tag is KullaniciAyar ayarG) {
                            if (ctrl is CheckBox chk)
                                ayarG.Deger = chk.Checked.ToString();
                            else if (ctrl is NumericUpDown num)
                                ayarG.Deger = num.Value.ToString();
                            else if (ctrl is TextBox txt)
                                ayarG.Deger = txt.Text.ToString();
                            else if (ctrl is ComboBox combo)
                                ayarG.Deger = combo.SelectedValue.ToString();
                        }
                    }
                }
            }

            AyarYonetimi.AyarlariKaydet(AktifKullanici.ID);
            AnlikOturumGuncelleme();
        }

        private void AnlikOturumGuncelleme() {
            AnaForm.reff?.TemaGuncelle();
        }
    }

    public class ComboboxDItem {
        public string id { set; get; }
        public string text { set; get; }

        public ComboboxDItem(string id, string text) {
            this.id = id;
            this.text = text;
        }

        public static List<ComboboxDItem >ListeOlustur((string, string)[] a) {
            List<ComboboxDItem> f = new List<ComboboxDItem>();
            foreach ((string i,string d) e in a) {
                f.Add(new(e.d,e.i));
            }
            return f;
        }
    }

}


