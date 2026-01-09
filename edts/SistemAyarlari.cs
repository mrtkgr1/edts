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
    public partial class SistemAyarlari : Form {
        public SistemAyarlari() {
            InitializeComponent();

            AyarListesiOlustur();
        }
        private void AyarListesiOlustur() {
            pnlSettings.Controls.Clear();
            pnlSettings.AutoScroll = true;
            pnlSettings.FlowDirection = FlowDirection.TopDown;
            pnlSettings.WrapContents = false;
            pnlSettings.Dock = DockStyle.Fill;
            pnlSettings.BackColor = Color.FromArgb(245, 245, 245);
            pnlSettings.Padding = new Padding(10);

            pnlSettings.SizeChanged -= PnlSettings_SizeChanged;
            pnlSettings.SizeChanged += PnlSettings_SizeChanged;

            int genelGenislik = pnlSettings.ClientSize.Width - 25;
            if (genelGenislik <= 0) genelGenislik = 500;

            var gruplar = SistemAyarYonetim.Ayarlar.GroupBy(x => x.Kategori);
            
            foreach (var grup in gruplar) {
                Panel pnlGrupBorder = new Panel();
                pnlGrupBorder.Name = "pnlGroup_" + grup.Key;
                pnlGrupBorder.AutoSize = true;
                pnlGrupBorder.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                pnlGrupBorder.BackColor = Color.Silver;
                pnlGrupBorder.Padding = new Padding(1);
                pnlGrupBorder.Margin = new Padding(0, 0, 0, 15);
                pnlGrupBorder.Width = genelGenislik; 

                FlowLayoutPanel pnlGrupMain = new FlowLayoutPanel();
                pnlGrupMain.Dock = DockStyle.Fill;
                pnlGrupMain.FlowDirection = FlowDirection.TopDown;
                pnlGrupMain.WrapContents = false;
                pnlGrupMain.AutoSize = true;
                pnlGrupMain.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                pnlGrupMain.BackColor = Color.White;

                Panel pnlHeader = new Panel();
                pnlHeader.Height = 45;
                pnlHeader.BackColor = Color.FromArgb(230, 230, 230);
                pnlHeader.Margin = new Padding(0);
                pnlHeader.Width = genelGenislik - 2; 

                Label lblBaslik = new Label();
                lblBaslik.Text = "  " + grup.Key.ToUpper();
                lblBaslik.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                lblBaslik.ForeColor = Color.DimGray;
                lblBaslik.TextAlign = ContentAlignment.MiddleLeft;
                lblBaslik.Dock = DockStyle.Fill;

                Button btnToggle = new Button();
                btnToggle.Text = "−";
                btnToggle.Font = new Font("Consolas", 14, FontStyle.Bold);
                btnToggle.Size = new Size(45, 45);
                btnToggle.FlatStyle = FlatStyle.Flat;
                btnToggle.FlatAppearance.BorderSize = 0;
                btnToggle.Dock = DockStyle.Right;
                btnToggle.Cursor = Cursors.Hand;

                pnlHeader.Controls.Add(lblBaslik);
                pnlHeader.Controls.Add(btnToggle);

                FlowLayoutPanel pnlContent = new FlowLayoutPanel();
                pnlContent.AutoSize = true;
                pnlContent.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                pnlContent.FlowDirection = FlowDirection.TopDown;
                pnlContent.WrapContents = false;
                pnlContent.BackColor = Color.White;
                pnlContent.Margin = new Padding(0);
                pnlContent.Width = pnlHeader.Width; 

               
                btnToggle.Click += (s, e) => {
                    pnlContent.Visible = !pnlContent.Visible;
                    btnToggle.Text = pnlContent.Visible ? "−" : "+";
                };
                lblBaslik.Click += (s, e) => btnToggle.PerformClick();

                foreach (var ayar in grup) {
                    Panel pnlSatir = new Panel();
                    pnlSatir.Height = 55;
                    pnlSatir.BackColor = Color.White;
                    pnlSatir.Margin = new Padding(0); 
                    pnlSatir.Width = pnlContent.Width;

                    Label lbl = new Label();
                    lbl.Text = ayar.AyarAdi;
                    lbl.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    lbl.AutoSize = false;
                    lbl.TextAlign = ContentAlignment.MiddleLeft;
                    lbl.Dock = DockStyle.Fill;
                    lbl.Padding = new Padding(15, 0, 0, 0);

                    Control inputControl = AyarOzelKontrolOlustur(ayar);

                    Panel pnlDegerInput = new Panel();
                    pnlDegerInput.Dock = DockStyle.Right;
                    pnlDegerInput.Width = 250;
                    pnlDegerInput.Padding = new Padding(0, 12, 15, 0);
                    pnlDegerInput.Controls.Add(inputControl);

                    inputControl.Width = 230;

                    pnlSatir.Controls.Add(lbl);
                    pnlSatir.Controls.Add(pnlDegerInput);

                    pnlContent.Controls.Add(pnlSatir);

                    if (inputControl is ComboBox combo) {
                        if (SistemAyarYonetim.SecenekListesi.TryGetValue(ayar.Id, out (string, string)[] v)) {
                            List<ComboboxDItem> itms = ComboboxDItem.ListeOlustur(v);
                            combo.DisplayMember = "text";
                            combo.ValueMember = "id";
                            combo.DataSource = itms;

                            ComboboxDItem secilecekOge = itms.FirstOrDefault(x => x.id == ayar.Deger);
                            if (secilecekOge != null) combo.SelectedItem = secilecekOge;
                        }
                    }
                }

                pnlGrupMain.Controls.Add(pnlHeader);
                pnlGrupMain.Controls.Add(pnlContent);
                pnlGrupBorder.Controls.Add(pnlGrupMain);
                pnlSettings.Controls.Add(pnlGrupBorder);
            }
        }

        public Control AyarOzelKontrolOlustur(SistemAyar ayarG) {
            Control resultControl;

            switch (ayarG.Tur) {
                case AyarTuru.Mantik:
                    CheckBox chk = new CheckBox();
                    chk.Text = "";
                    chk.Checked = SistemAyarYonetim.AyarBoolGetir(ayarG.Id);
                    chk.Tag = ayarG;
                    chk.AutoSize = true;
                    chk.Dock = DockStyle.Right;
                    resultControl = chk;
                    break;

                case AyarTuru.Sayi:
                    NumericUpDown num = new NumericUpDown();
                    num.Value = SistemAyarYonetim.AyarIntGetir(ayarG.Id);
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

        private void PnlSettings_SizeChanged(object sender, EventArgs e) {
            pnlSettings.SuspendLayout();

            int newWidth = pnlSettings.ClientSize.Width - 25;
            if (newWidth <= 0) return;

            foreach (Control borderCtrl in pnlSettings.Controls) {
                if (borderCtrl is Panel pnlBorder) {
                    pnlBorder.Width = newWidth;

                    if (pnlBorder.Controls.Count > 0 && pnlBorder.Controls[0] is FlowLayoutPanel pnlMain) {
                        int innerWidth = pnlMain.ClientSize.Width;

                        foreach (Control mainChild in pnlMain.Controls) {
                            mainChild.Width = innerWidth;

                            if (mainChild is FlowLayoutPanel pnlContent) {
                                foreach (Control satir in pnlContent.Controls) {
                                    satir.Width = pnlContent.ClientSize.Width;
                                }
                            }
                        }
                    }
                }
            }
            pnlSettings.ResumeLayout();
        }

       


    }
}
