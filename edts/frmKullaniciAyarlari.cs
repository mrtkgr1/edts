using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;

namespace edts {
    public partial class frmKullaniciAyarlari : Form {
        public frmKullaniciAyarlari() {
            InitializeComponent();
            AyarListesiOlustur();
        }
        private void AyarListesiOlustur() {
            pnlSettings.Controls.Clear();
            pnlSettings.AutoScroll = true;
            pnlSettings.FlowDirection = FlowDirection.TopDown;
            pnlSettings.WrapContents = false;
            pnlSettings.Dock = DockStyle.Fill;

            foreach (var ayar in AyarYonetimi.Ayarlar) {
                Panel rowPanel = new Panel();
                rowPanel.Size = new Size(pnlSettings.ClientSize.Width - 30, 60);
                rowPanel.BorderStyle = BorderStyle.None;


                Label lbl = new Label();
                lbl.Text = ayar.AyarAdi;
                lbl.Location = new Point(10, 10);
                lbl.AutoSize = true;
                lbl.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                rowPanel.Controls.Add(lbl);


                Control inputControl = CreateControlForSetting(ayar);
                inputControl.Location = new Point(10, 30);
                inputControl.Width = rowPanel.Width - 20;

                rowPanel.Controls.Add(inputControl);

                pnlSettings.Controls.Add(rowPanel);
            }

            Button btnKAyit = new Button();
            btnKAyit.Text = "Kaydet";
            btnKAyit.Height = 40;
            btnKAyit.Dock = DockStyle.Bottom;
            btnKAyit.Click += BtnSave_Click;
            this.Controls.Add(btnKAyit);
        }

        private Control CreateControlForSetting(KullaniciAyar ayarG) {
            switch (ayarG.Tur) {
                case AyarTuru.Mantik:
                    CheckBox chk = new CheckBox();
                    chk.Text = "Aktif / Pasif";
                    chk.Checked = AyarYonetimi.AyarBoolGetir(ayarG.Id);
                    chk.Tag = ayarG;
                    return chk;

                case AyarTuru.Sayi:
                    NumericUpDown num = new NumericUpDown();
                    num.Value = AyarYonetimi.AyarIntGetir(ayarG.Id);
                    num.Maximum = 99999;
                    num.Tag = ayarG;
                    return num;

                case AyarTuru.Sifre:
                    TextBox txtPass = new TextBox();
                    txtPass.Text = ayarG.Deger.ToString();
                    txtPass.UseSystemPasswordChar = true;
                    txtPass.Tag = ayarG;
                    return txtPass;

                case AyarTuru.Metin:
                default:
                    TextBox txt = new TextBox();
                    txt.Text = ayarG.Deger.ToString();
                    txt.Tag = ayarG;
                    return txt;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e) {
            foreach (Control row in pnlSettings.Controls) {
                foreach (Control ctrl in row.Controls) {
                    if (ctrl.Tag is KullaniciAyar ayar) {
                        if (ctrl is CheckBox chk)
                            ayar.Deger = chk.Checked.ToString();
                        else if (ctrl is NumericUpDown num)
                            ayar.Deger = num.Value.ToString();
                        else if (ctrl is TextBox txt)
                            ayar.Deger = txt.Text.ToString();
                    }
                }
            }

            AyarYonetimi.AyarlariKaydet(AktifKullanici.ID);
        }
    }
}
