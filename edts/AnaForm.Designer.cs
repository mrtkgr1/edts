namespace edts {
    partial class AnaForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaForm));
            panel1 = new Panel();
            labelBaslik = new Label();
            pictureBoxNotf = new PictureBox();
            pictureBoxProfile = new PictureBox();
            button8 = new Button();
            prefPictureBox = new PictureBox();
            button10 = new Button();
            btnBuyut = new Button();
            pictureBox1 = new PictureBox();
            yanMenuPanel = new FlowLayoutPanel();
            panelKontrol = new Panel();
            buttonSolKontrol = new Button();
            kayitMenuPanel = new FlowLayoutPanel();
            panelMenuKayit = new Panel();
            buttonSolMenuKayit = new Button();
            panelUrunK = new Panel();
            buttonSolUrunK = new Button();
            panelKategoriK = new Panel();
            buttonSolKategoriK = new Button();
            panelMusteriK = new Panel();
            buttonSolMusteriK = new Button();
            panelTedarikciK = new Panel();
            buttonSolTedarikciK = new Button();
            panelSatisF = new Panel();
            buttonSatisF = new Button();
            panelRapor = new Panel();
            buttonSolRapor = new Button();
            panelSolSistemA = new Panel();
            buttonSolSistemAyar = new Button();
            panelSolDenetinK = new Panel();
            buttonSolDenetimKayit = new Button();
            panelSolKullaniciA = new Panel();
            buttonSolKullaniciAyar = new Button();
            panelSolStokG = new Panel();
            buttonSolStokG = new Button();
            panelSolStokC = new Panel();
            buttonSolStokCıkış = new Button();
            panelSolStokL = new Panel();
            buttonStokList = new Button();
            panelRaporDepo = new Panel();
            buttonRaporDEpo = new Button();
            panelChatBot = new Panel();
            buttonChatBot = new Button();
            panelDestek = new Panel();
            buttonDestek = new Button();
            menuKayitHareket = new System.Windows.Forms.Timer(components);
            yanPanelHareket = new System.Windows.Forms.Timer(components);
            AnaHPanel = new Panel();
            panelForm = new Panel();
            SolHPanel = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxNotf).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)prefPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            yanMenuPanel.SuspendLayout();
            panelKontrol.SuspendLayout();
            kayitMenuPanel.SuspendLayout();
            panelMenuKayit.SuspendLayout();
            panelUrunK.SuspendLayout();
            panelKategoriK.SuspendLayout();
            panelMusteriK.SuspendLayout();
            panelTedarikciK.SuspendLayout();
            panelSatisF.SuspendLayout();
            panelRapor.SuspendLayout();
            panelSolSistemA.SuspendLayout();
            panelSolDenetinK.SuspendLayout();
            panelSolKullaniciA.SuspendLayout();
            panelSolStokG.SuspendLayout();
            panelSolStokC.SuspendLayout();
            panelSolStokL.SuspendLayout();
            panelRaporDepo.SuspendLayout();
            panelChatBot.SuspendLayout();
            panelDestek.SuspendLayout();
            AnaHPanel.SuspendLayout();
            SolHPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 45, 48);
            panel1.Controls.Add(labelBaslik);
            panel1.Controls.Add(pictureBoxNotf);
            panel1.Controls.Add(pictureBoxProfile);
            panel1.Controls.Add(button8);
            panel1.Controls.Add(prefPictureBox);
            panel1.Controls.Add(button10);
            panel1.Controls.Add(btnBuyut);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1146, 36);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // labelBaslik
            // 
            labelBaslik.AutoSize = true;
            labelBaslik.Font = new Font("Segoe UI", 11F);
            labelBaslik.Location = new Point(42, 7);
            labelBaslik.Name = "labelBaslik";
            labelBaslik.Size = new Size(116, 23);
            labelBaslik.TabIndex = 5;
            labelBaslik.Text = "Kontrol Paneli";
            // 
            // pictureBoxNotf
            // 
            pictureBoxNotf.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBoxNotf.Image = Properties.Resources.notf_yok_beyaz;
            pictureBoxNotf.Location = new Point(931, 1);
            pictureBoxNotf.Name = "pictureBoxNotf";
            pictureBoxNotf.Size = new Size(36, 33);
            pictureBoxNotf.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxNotf.TabIndex = 2;
            pictureBoxNotf.TabStop = false;
            pictureBoxNotf.Visible = false;
            pictureBoxNotf.Click += pictureBox4_Click;
            // 
            // pictureBoxProfile
            // 
            pictureBoxProfile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBoxProfile.Image = Properties.Resources.profile_beyaz;
            pictureBoxProfile.Location = new Point(973, 1);
            pictureBoxProfile.Name = "pictureBoxProfile";
            pictureBoxProfile.Size = new Size(36, 33);
            pictureBoxProfile.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxProfile.TabIndex = 2;
            pictureBoxProfile.TabStop = false;
            pictureBoxProfile.Click += pictureBox3_Click;
            // 
            // button8
            // 
            button8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatAppearance.MouseDownBackColor = Color.Red;
            button8.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 128);
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Marlett", 8.830189F);
            button8.Location = new Point(1107, 1);
            button8.Name = "button8";
            button8.Size = new Size(36, 33);
            button8.TabIndex = 2;
            button8.TabStop = false;
            button8.Text = "r";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // prefPictureBox
            // 
            prefPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            prefPictureBox.Image = Properties.Resources.kayan_liste_beyaz_assa;
            prefPictureBox.InitialImage = (Image)resources.GetObject("prefPictureBox.InitialImage");
            prefPictureBox.Location = new Point(889, 1);
            prefPictureBox.Name = "prefPictureBox";
            prefPictureBox.Size = new Size(36, 33);
            prefPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            prefPictureBox.TabIndex = 2;
            prefPictureBox.TabStop = false;
            prefPictureBox.Visible = false;
            prefPictureBox.Click += prefPictureBox_click;
            // 
            // button10
            // 
            button10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button10.FlatAppearance.BorderSize = 0;
            button10.FlatAppearance.MouseOverBackColor = Color.FromArgb(65, 65, 65);
            button10.FlatStyle = FlatStyle.Flat;
            button10.Font = new Font("Marlett", 8.830189F);
            button10.Location = new Point(1023, 1);
            button10.Name = "button10";
            button10.Size = new Size(36, 33);
            button10.TabIndex = 4;
            button10.TabStop = false;
            button10.Text = "0";
            button10.UseVisualStyleBackColor = false;
            button10.Click += button10_Click;
            // 
            // btnBuyut
            // 
            btnBuyut.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuyut.FlatAppearance.BorderSize = 0;
            btnBuyut.FlatAppearance.MouseOverBackColor = Color.FromArgb(65, 65, 65);
            btnBuyut.FlatStyle = FlatStyle.Flat;
            btnBuyut.Font = new Font("Marlett", 8.830189F);
            btnBuyut.Location = new Point(1065, 1);
            btnBuyut.Name = "btnBuyut";
            btnBuyut.Size = new Size(36, 33);
            btnBuyut.TabIndex = 3;
            btnBuyut.TabStop = false;
            btnBuyut.Text = "1";
            btnBuyut.UseVisualStyleBackColor = false;
            btnBuyut.Click += btnBuyut_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(36, 33);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // yanMenuPanel
            // 
            yanMenuPanel.AutoSize = true;
            yanMenuPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            yanMenuPanel.Controls.Add(panelKontrol);
            yanMenuPanel.Controls.Add(kayitMenuPanel);
            yanMenuPanel.Controls.Add(panelSatisF);
            yanMenuPanel.Controls.Add(panelRapor);
            yanMenuPanel.Controls.Add(panelSolSistemA);
            yanMenuPanel.Controls.Add(panelSolDenetinK);
            yanMenuPanel.Controls.Add(panelSolKullaniciA);
            yanMenuPanel.Controls.Add(panelSolStokG);
            yanMenuPanel.Controls.Add(panelSolStokC);
            yanMenuPanel.Controls.Add(panelSolStokL);
            yanMenuPanel.Controls.Add(panelRaporDepo);
            yanMenuPanel.Controls.Add(panelChatBot);
            yanMenuPanel.Controls.Add(panelDestek);
            yanMenuPanel.FlowDirection = FlowDirection.TopDown;
            yanMenuPanel.Location = new Point(0, 0);
            yanMenuPanel.Margin = new Padding(0);
            yanMenuPanel.Name = "yanMenuPanel";
            yanMenuPanel.Size = new Size(175, 702);
            yanMenuPanel.TabIndex = 1;
            // 
            // panelKontrol
            // 
            panelKontrol.Controls.Add(buttonSolKontrol);
            panelKontrol.Location = new Point(3, 3);
            panelKontrol.Name = "panelKontrol";
            panelKontrol.Size = new Size(169, 48);
            panelKontrol.TabIndex = 3;
            // 
            // buttonSolKontrol
            // 
            buttonSolKontrol.Image = (Image)resources.GetObject("buttonSolKontrol.Image");
            buttonSolKontrol.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSolKontrol.Location = new Point(-9, -6);
            buttonSolKontrol.Name = "buttonSolKontrol";
            buttonSolKontrol.Padding = new Padding(10, 0, 0, 0);
            buttonSolKontrol.Size = new Size(250, 62);
            buttonSolKontrol.TabIndex = 2;
            buttonSolKontrol.Text = "           Kontrol Paneli";
            buttonSolKontrol.TextAlign = ContentAlignment.MiddleLeft;
            buttonSolKontrol.UseVisualStyleBackColor = false;
            buttonSolKontrol.Click += buttonKontrol_Click;
            // 
            // kayitMenuPanel
            // 
            kayitMenuPanel.Controls.Add(panelMenuKayit);
            kayitMenuPanel.Controls.Add(panelUrunK);
            kayitMenuPanel.Controls.Add(panelKategoriK);
            kayitMenuPanel.Controls.Add(panelMusteriK);
            kayitMenuPanel.Controls.Add(panelTedarikciK);
            kayitMenuPanel.FlowDirection = FlowDirection.TopDown;
            kayitMenuPanel.Location = new Point(0, 57);
            kayitMenuPanel.Margin = new Padding(0, 3, 3, 3);
            kayitMenuPanel.Name = "kayitMenuPanel";
            kayitMenuPanel.Size = new Size(169, 48);
            kayitMenuPanel.TabIndex = 8;
            // 
            // panelMenuKayit
            // 
            panelMenuKayit.Controls.Add(buttonSolMenuKayit);
            panelMenuKayit.Location = new Point(3, 0);
            panelMenuKayit.Margin = new Padding(3, 0, 0, 0);
            panelMenuKayit.Name = "panelMenuKayit";
            panelMenuKayit.Size = new Size(169, 48);
            panelMenuKayit.TabIndex = 6;
            // 
            // buttonSolMenuKayit
            // 
            buttonSolMenuKayit.Image = (Image)resources.GetObject("buttonSolMenuKayit.Image");
            buttonSolMenuKayit.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSolMenuKayit.Location = new Point(-9, -6);
            buttonSolMenuKayit.Margin = new Padding(3, 0, 3, 0);
            buttonSolMenuKayit.Name = "buttonSolMenuKayit";
            buttonSolMenuKayit.Padding = new Padding(10, 0, 0, 0);
            buttonSolMenuKayit.Size = new Size(250, 62);
            buttonSolMenuKayit.TabIndex = 2;
            buttonSolMenuKayit.Text = "           Kayıtlar";
            buttonSolMenuKayit.TextAlign = ContentAlignment.MiddleLeft;
            buttonSolMenuKayit.UseVisualStyleBackColor = false;
            buttonSolMenuKayit.Click += button4_Click;
            // 
            // panelUrunK
            // 
            panelUrunK.Controls.Add(buttonSolUrunK);
            panelUrunK.Location = new Point(175, 0);
            panelUrunK.Margin = new Padding(3, 0, 3, 0);
            panelUrunK.Name = "panelUrunK";
            panelUrunK.Size = new Size(169, 48);
            panelUrunK.TabIndex = 4;
            // 
            // buttonSolUrunK
            // 
            buttonSolUrunK.Image = (Image)resources.GetObject("buttonSolUrunK.Image");
            buttonSolUrunK.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSolUrunK.Location = new Point(-6, -6);
            buttonSolUrunK.Name = "buttonSolUrunK";
            buttonSolUrunK.Padding = new Padding(10, 0, 0, 0);
            buttonSolUrunK.Size = new Size(250, 62);
            buttonSolUrunK.TabIndex = 2;
            buttonSolUrunK.Text = "          Ürün";
            buttonSolUrunK.TextAlign = ContentAlignment.MiddleLeft;
            buttonSolUrunK.UseVisualStyleBackColor = false;
            buttonSolUrunK.Click += buttonUrunK_Click;
            // 
            // panelKategoriK
            // 
            panelKategoriK.Controls.Add(buttonSolKategoriK);
            panelKategoriK.Location = new Point(350, 0);
            panelKategoriK.Margin = new Padding(3, 0, 3, 0);
            panelKategoriK.Name = "panelKategoriK";
            panelKategoriK.Size = new Size(169, 48);
            panelKategoriK.TabIndex = 5;
            // 
            // buttonSolKategoriK
            // 
            buttonSolKategoriK.Image = (Image)resources.GetObject("buttonSolKategoriK.Image");
            buttonSolKategoriK.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSolKategoriK.Location = new Point(-6, -6);
            buttonSolKategoriK.Name = "buttonSolKategoriK";
            buttonSolKategoriK.Padding = new Padding(10, 0, 0, 0);
            buttonSolKategoriK.Size = new Size(250, 62);
            buttonSolKategoriK.TabIndex = 2;
            buttonSolKategoriK.Text = "          Kategori";
            buttonSolKategoriK.TextAlign = ContentAlignment.MiddleLeft;
            buttonSolKategoriK.UseVisualStyleBackColor = false;
            buttonSolKategoriK.Click += buttonSolKategoriK_Click;
            // 
            // panelMusteriK
            // 
            panelMusteriK.Controls.Add(buttonSolMusteriK);
            panelMusteriK.Location = new Point(525, 0);
            panelMusteriK.Margin = new Padding(3, 0, 3, 0);
            panelMusteriK.Name = "panelMusteriK";
            panelMusteriK.Size = new Size(169, 48);
            panelMusteriK.TabIndex = 8;
            // 
            // buttonSolMusteriK
            // 
            buttonSolMusteriK.Image = (Image)resources.GetObject("buttonSolMusteriK.Image");
            buttonSolMusteriK.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSolMusteriK.Location = new Point(-6, -6);
            buttonSolMusteriK.Name = "buttonSolMusteriK";
            buttonSolMusteriK.Padding = new Padding(10, 0, 0, 0);
            buttonSolMusteriK.Size = new Size(250, 62);
            buttonSolMusteriK.TabIndex = 2;
            buttonSolMusteriK.Text = "          Müsteri";
            buttonSolMusteriK.TextAlign = ContentAlignment.MiddleLeft;
            buttonSolMusteriK.UseVisualStyleBackColor = false;
            buttonSolMusteriK.Click += buttonSolMusteriK_Click;
            // 
            // panelTedarikciK
            // 
            panelTedarikciK.Controls.Add(buttonSolTedarikciK);
            panelTedarikciK.Location = new Point(700, 0);
            panelTedarikciK.Margin = new Padding(3, 0, 3, 0);
            panelTedarikciK.Name = "panelTedarikciK";
            panelTedarikciK.Size = new Size(169, 48);
            panelTedarikciK.TabIndex = 8;
            // 
            // buttonSolTedarikciK
            // 
            buttonSolTedarikciK.Image = (Image)resources.GetObject("buttonSolTedarikciK.Image");
            buttonSolTedarikciK.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSolTedarikciK.Location = new Point(-6, -6);
            buttonSolTedarikciK.Name = "buttonSolTedarikciK";
            buttonSolTedarikciK.Padding = new Padding(10, 0, 0, 0);
            buttonSolTedarikciK.Size = new Size(250, 62);
            buttonSolTedarikciK.TabIndex = 2;
            buttonSolTedarikciK.Text = "          Tedarikçi";
            buttonSolTedarikciK.TextAlign = ContentAlignment.MiddleLeft;
            buttonSolTedarikciK.UseVisualStyleBackColor = false;
            buttonSolTedarikciK.Click += buttonSolTedarikciK_Click;
            // 
            // panelSatisF
            // 
            panelSatisF.Controls.Add(buttonSatisF);
            panelSatisF.Location = new Point(3, 111);
            panelSatisF.Name = "panelSatisF";
            panelSatisF.Size = new Size(169, 48);
            panelSatisF.TabIndex = 8;
            // 
            // buttonSatisF
            // 
            buttonSatisF.Image = (Image)resources.GetObject("buttonSatisF.Image");
            buttonSatisF.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSatisF.Location = new Point(-9, -6);
            buttonSatisF.Name = "buttonSatisF";
            buttonSatisF.Padding = new Padding(10, 0, 0, 0);
            buttonSatisF.Size = new Size(250, 62);
            buttonSatisF.TabIndex = 2;
            buttonSatisF.Text = "           Satış/Fatura";
            buttonSatisF.TextAlign = ContentAlignment.MiddleLeft;
            buttonSatisF.UseVisualStyleBackColor = false;
            buttonSatisF.Click += buttonSatisF_Click;
            // 
            // panelRapor
            // 
            panelRapor.Controls.Add(buttonSolRapor);
            panelRapor.Location = new Point(3, 165);
            panelRapor.Name = "panelRapor";
            panelRapor.Size = new Size(169, 48);
            panelRapor.TabIndex = 7;
            // 
            // buttonSolRapor
            // 
            buttonSolRapor.Image = (Image)resources.GetObject("buttonSolRapor.Image");
            buttonSolRapor.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSolRapor.Location = new Point(-9, -6);
            buttonSolRapor.Name = "buttonSolRapor";
            buttonSolRapor.Padding = new Padding(10, 0, 0, 0);
            buttonSolRapor.Size = new Size(250, 62);
            buttonSolRapor.TabIndex = 2;
            buttonSolRapor.Text = "           Rapor";
            buttonSolRapor.TextAlign = ContentAlignment.MiddleLeft;
            buttonSolRapor.UseVisualStyleBackColor = false;
            buttonSolRapor.Click += buttonRapor_Click;
            // 
            // panelSolSistemA
            // 
            panelSolSistemA.Controls.Add(buttonSolSistemAyar);
            panelSolSistemA.Location = new Point(3, 219);
            panelSolSistemA.Name = "panelSolSistemA";
            panelSolSistemA.Size = new Size(169, 48);
            panelSolSistemA.TabIndex = 9;
            // 
            // buttonSolSistemAyar
            // 
            buttonSolSistemAyar.Image = (Image)resources.GetObject("buttonSolSistemAyar.Image");
            buttonSolSistemAyar.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSolSistemAyar.Location = new Point(-9, -6);
            buttonSolSistemAyar.Name = "buttonSolSistemAyar";
            buttonSolSistemAyar.Padding = new Padding(10, 0, 0, 0);
            buttonSolSistemAyar.Size = new Size(250, 62);
            buttonSolSistemAyar.TabIndex = 2;
            buttonSolSistemAyar.Text = "           Sistem Ayarları";
            buttonSolSistemAyar.TextAlign = ContentAlignment.MiddleLeft;
            buttonSolSistemAyar.UseVisualStyleBackColor = false;
            buttonSolSistemAyar.Click += buttonSistemAyar_Click;
            // 
            // panelSolDenetinK
            // 
            panelSolDenetinK.Controls.Add(buttonSolDenetimKayit);
            panelSolDenetinK.Location = new Point(3, 273);
            panelSolDenetinK.Name = "panelSolDenetinK";
            panelSolDenetinK.Size = new Size(169, 48);
            panelSolDenetinK.TabIndex = 8;
            // 
            // buttonSolDenetimKayit
            // 
            buttonSolDenetimKayit.Image = (Image)resources.GetObject("buttonSolDenetimKayit.Image");
            buttonSolDenetimKayit.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSolDenetimKayit.Location = new Point(-9, -6);
            buttonSolDenetimKayit.Name = "buttonSolDenetimKayit";
            buttonSolDenetimKayit.Padding = new Padding(10, 0, 0, 0);
            buttonSolDenetimKayit.Size = new Size(250, 62);
            buttonSolDenetimKayit.TabIndex = 2;
            buttonSolDenetimKayit.Text = "           Denetim Kayıtları";
            buttonSolDenetimKayit.TextAlign = ContentAlignment.MiddleLeft;
            buttonSolDenetimKayit.UseVisualStyleBackColor = false;
            buttonSolDenetimKayit.Click += buttonDenetimKayit_Click;
            // 
            // panelSolKullaniciA
            // 
            panelSolKullaniciA.Controls.Add(buttonSolKullaniciAyar);
            panelSolKullaniciA.Location = new Point(3, 327);
            panelSolKullaniciA.Name = "panelSolKullaniciA";
            panelSolKullaniciA.Size = new Size(169, 48);
            panelSolKullaniciA.TabIndex = 10;
            // 
            // buttonSolKullaniciAyar
            // 
            buttonSolKullaniciAyar.Image = (Image)resources.GetObject("buttonSolKullaniciAyar.Image");
            buttonSolKullaniciAyar.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSolKullaniciAyar.Location = new Point(-9, -6);
            buttonSolKullaniciAyar.Name = "buttonSolKullaniciAyar";
            buttonSolKullaniciAyar.Padding = new Padding(10, 0, 0, 0);
            buttonSolKullaniciAyar.Size = new Size(250, 62);
            buttonSolKullaniciAyar.TabIndex = 2;
            buttonSolKullaniciAyar.Text = "           Kullanıcı Yönetimi";
            buttonSolKullaniciAyar.TextAlign = ContentAlignment.MiddleLeft;
            buttonSolKullaniciAyar.UseVisualStyleBackColor = false;
            buttonSolKullaniciAyar.Click += buttonKullaniciAyar_Click;
            // 
            // panelSolStokG
            // 
            panelSolStokG.Controls.Add(buttonSolStokG);
            panelSolStokG.Location = new Point(3, 381);
            panelSolStokG.Name = "panelSolStokG";
            panelSolStokG.Size = new Size(169, 48);
            panelSolStokG.TabIndex = 11;
            // 
            // buttonSolStokG
            // 
            buttonSolStokG.Image = (Image)resources.GetObject("buttonSolStokG.Image");
            buttonSolStokG.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSolStokG.Location = new Point(-9, -6);
            buttonSolStokG.Name = "buttonSolStokG";
            buttonSolStokG.Padding = new Padding(10, 0, 0, 0);
            buttonSolStokG.Size = new Size(250, 62);
            buttonSolStokG.TabIndex = 2;
            buttonSolStokG.Text = "           Stok Giriş";
            buttonSolStokG.TextAlign = ContentAlignment.MiddleLeft;
            buttonSolStokG.UseVisualStyleBackColor = false;
            buttonSolStokG.Click += buttonSolStokG_Click;
            // 
            // panelSolStokC
            // 
            panelSolStokC.Controls.Add(buttonSolStokCıkış);
            panelSolStokC.Location = new Point(3, 435);
            panelSolStokC.Name = "panelSolStokC";
            panelSolStokC.Size = new Size(169, 48);
            panelSolStokC.TabIndex = 11;
            // 
            // buttonSolStokCıkış
            // 
            buttonSolStokCıkış.Image = (Image)resources.GetObject("buttonSolStokCıkış.Image");
            buttonSolStokCıkış.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSolStokCıkış.Location = new Point(-9, -6);
            buttonSolStokCıkış.Name = "buttonSolStokCıkış";
            buttonSolStokCıkış.Padding = new Padding(10, 0, 0, 0);
            buttonSolStokCıkış.Size = new Size(250, 62);
            buttonSolStokCıkış.TabIndex = 2;
            buttonSolStokCıkış.Text = "           Stok ÇıkıŞ";
            buttonSolStokCıkış.TextAlign = ContentAlignment.MiddleLeft;
            buttonSolStokCıkış.UseVisualStyleBackColor = false;
            buttonSolStokCıkış.Click += buttonSolStokCıkış_Click;
            // 
            // panelSolStokL
            // 
            panelSolStokL.Controls.Add(buttonStokList);
            panelSolStokL.Location = new Point(3, 489);
            panelSolStokL.Name = "panelSolStokL";
            panelSolStokL.Size = new Size(169, 48);
            panelSolStokL.TabIndex = 12;
            // 
            // buttonStokList
            // 
            buttonStokList.Image = (Image)resources.GetObject("buttonStokList.Image");
            buttonStokList.ImageAlign = ContentAlignment.MiddleLeft;
            buttonStokList.Location = new Point(-9, -6);
            buttonStokList.Name = "buttonStokList";
            buttonStokList.Padding = new Padding(10, 0, 0, 0);
            buttonStokList.Size = new Size(250, 62);
            buttonStokList.TabIndex = 2;
            buttonStokList.Text = "           Stok Listele";
            buttonStokList.TextAlign = ContentAlignment.MiddleLeft;
            buttonStokList.UseVisualStyleBackColor = false;
            buttonStokList.Click += buttonStokList_Click;
            // 
            // panelRaporDepo
            // 
            panelRaporDepo.Controls.Add(buttonRaporDEpo);
            panelRaporDepo.Location = new Point(3, 543);
            panelRaporDepo.Name = "panelRaporDepo";
            panelRaporDepo.Size = new Size(169, 48);
            panelRaporDepo.TabIndex = 8;
            // 
            // buttonRaporDEpo
            // 
            buttonRaporDEpo.Image = (Image)resources.GetObject("buttonRaporDEpo.Image");
            buttonRaporDEpo.ImageAlign = ContentAlignment.MiddleLeft;
            buttonRaporDEpo.Location = new Point(-9, -6);
            buttonRaporDEpo.Name = "buttonRaporDEpo";
            buttonRaporDEpo.Padding = new Padding(10, 0, 0, 0);
            buttonRaporDEpo.Size = new Size(250, 62);
            buttonRaporDEpo.TabIndex = 2;
            buttonRaporDEpo.Text = "           Rapor";
            buttonRaporDEpo.TextAlign = ContentAlignment.MiddleLeft;
            buttonRaporDEpo.UseVisualStyleBackColor = false;
            buttonRaporDEpo.Click += buttonRaporDEpo_Click;
            // 
            // panelChatBot
            // 
            panelChatBot.Controls.Add(buttonChatBot);
            panelChatBot.Location = new Point(3, 597);
            panelChatBot.Name = "panelChatBot";
            panelChatBot.Size = new Size(169, 48);
            panelChatBot.TabIndex = 12;
            // 
            // buttonChatBot
            // 
            buttonChatBot.Image = (Image)resources.GetObject("buttonChatBot.Image");
            buttonChatBot.ImageAlign = ContentAlignment.MiddleLeft;
            buttonChatBot.Location = new Point(-9, -6);
            buttonChatBot.Name = "buttonChatBot";
            buttonChatBot.Padding = new Padding(10, 0, 0, 0);
            buttonChatBot.Size = new Size(250, 62);
            buttonChatBot.TabIndex = 2;
            buttonChatBot.Text = "           Fuzuli ";
            buttonChatBot.TextAlign = ContentAlignment.MiddleLeft;
            buttonChatBot.UseVisualStyleBackColor = false;
            buttonChatBot.Click += buttonChatBot_Click;
            // 
            // panelDestek
            // 
            panelDestek.Controls.Add(buttonDestek);
            panelDestek.Location = new Point(3, 651);
            panelDestek.Name = "panelDestek";
            panelDestek.Size = new Size(169, 48);
            panelDestek.TabIndex = 13;
            // 
            // buttonDestek
            // 
            buttonDestek.Image = (Image)resources.GetObject("buttonDestek.Image");
            buttonDestek.ImageAlign = ContentAlignment.MiddleLeft;
            buttonDestek.Location = new Point(-9, -6);
            buttonDestek.Name = "buttonDestek";
            buttonDestek.Padding = new Padding(10, 0, 0, 0);
            buttonDestek.Size = new Size(250, 62);
            buttonDestek.TabIndex = 2;
            buttonDestek.Text = "           Destek";
            buttonDestek.TextAlign = ContentAlignment.MiddleLeft;
            buttonDestek.UseVisualStyleBackColor = false;
            buttonDestek.Click += buttonDestek_Click;
            // 
            // menuKayitHareket
            // 
            menuKayitHareket.Interval = 10;
            menuKayitHareket.Tick += menuHareket_Tick;
            // 
            // yanPanelHareket
            // 
            yanPanelHareket.Interval = 10;
            yanPanelHareket.Tick += yanPanel_Tick;
            // 
            // AnaHPanel
            // 
            AnaHPanel.Controls.Add(panelForm);
            AnaHPanel.Controls.Add(SolHPanel);
            AnaHPanel.Controls.Add(panel1);
            AnaHPanel.Dock = DockStyle.Fill;
            AnaHPanel.Location = new Point(4, 2);
            AnaHPanel.Margin = new Padding(0);
            AnaHPanel.Name = "AnaHPanel";
            AnaHPanel.Size = new Size(1146, 424);
            AnaHPanel.TabIndex = 2;
            // 
            // panelForm
            // 
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(178, 36);
            panelForm.Margin = new Padding(0);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(968, 388);
            panelForm.TabIndex = 2;
            // 
            // SolHPanel
            // 
            SolHPanel.Controls.Add(yanMenuPanel);
            SolHPanel.Dock = DockStyle.Left;
            SolHPanel.ForeColor = Color.White;
            SolHPanel.Location = new Point(0, 36);
            SolHPanel.Margin = new Padding(0);
            SolHPanel.Name = "SolHPanel";
            SolHPanel.Size = new Size(178, 388);
            SolHPanel.TabIndex = 0;
            // 
            // AnaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1154, 430);
            ControlBox = false;
            Controls.Add(AnaHPanel);
            MinimumSize = new Size(900, 400);
            Name = "AnaForm";
            Padding = new Padding(4, 2, 4, 4);
            ShowIcon = false;
            Text = "Edts";
            Resize += AnaForm_Resize;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxNotf).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).EndInit();
            ((System.ComponentModel.ISupportInitialize)prefPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            yanMenuPanel.ResumeLayout(false);
            panelKontrol.ResumeLayout(false);
            kayitMenuPanel.ResumeLayout(false);
            panelMenuKayit.ResumeLayout(false);
            panelUrunK.ResumeLayout(false);
            panelKategoriK.ResumeLayout(false);
            panelMusteriK.ResumeLayout(false);
            panelTedarikciK.ResumeLayout(false);
            panelSatisF.ResumeLayout(false);
            panelRapor.ResumeLayout(false);
            panelSolSistemA.ResumeLayout(false);
            panelSolDenetinK.ResumeLayout(false);
            panelSolKullaniciA.ResumeLayout(false);
            panelSolStokG.ResumeLayout(false);
            panelSolStokC.ResumeLayout(false);
            panelSolStokL.ResumeLayout(false);
            panelRaporDepo.ResumeLayout(false);
            panelChatBot.ResumeLayout(false);
            panelDestek.ResumeLayout(false);
            AnaHPanel.ResumeLayout(false);
            SolHPanel.ResumeLayout(false);
            SolHPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private void InitializeSecenekPopup() {
            FlowLayoutPanel prefPanel = new FlowLayoutPanel();
            prefPanel.AutoSize = true;
            prefPanel.FlowDirection = FlowDirection.TopDown;
            prefPanel.BackColor = System.Drawing.Color.LightGray;
            prefPanel.BorderStyle = BorderStyle.FixedSingle;

            Button btnProfile = new Button { Text = "Kontrol kutularını düzenle", Location = new System.Drawing.Point(10, 50) };
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.AutoSize = true;
            prefPanel.Controls.Add(btnProfile);

            Button btnProfile2 = new Button { Text = "Ayarlar" };
            btnProfile2.FlatStyle = FlatStyle.Flat;
            btnProfile2.AutoSize = true;    
            prefPanel.Controls.Add(btnProfile2);

            ToolStripControlHost host = new ToolStripControlHost(prefPanel);

            host.Margin = Padding.Empty;
            host.Padding = Padding.Empty;

            popup = new ToolStripDropDown();
            popup.Items.Add(host);
            popup.Padding = Padding.Empty;
            popup.Margin = Padding.Empty;
            popup.DropShadowEnabled = true;
            popup.Closed += prefSecenekMenuKapat;
        }

        private void InitializeProfilePopup() {
            ProfilMenuControl profilMControl = new ProfilMenuControl();

            profilMControl.BackColor = System.Drawing.Color.LightGray;
            profilMControl.BorderStyle = BorderStyle.FixedSingle;

            profilMControl.ProfilDuzenleTiklandi += (s, e) =>
            {
                hesapDuzenle_Tiklandi();
                popupHesap.Close(); 
            };

            profilMControl.AyarlarTiklandi += (s, e) =>
            {
                kullaniciAyarlari_Tiklandi();
                popupHesap.Close(); 
            };

            ToolStripControlHost host = new ToolStripControlHost(profilMControl);

            host.Margin = Padding.Empty;
            host.Padding = Padding.Empty;
            host.AutoSize = false;

            popupHesap = new ToolStripDropDown();
            popupHesap.Items.Add(host);

            popupHesap.Padding = Padding.Empty;
            popupHesap.Margin = Padding.Empty;
            popupHesap.DropShadowEnabled = true;

        }

        private Panel panel1;
        private PictureBox pictureBox1;
        private FlowLayoutPanel yanMenuPanel;
        private Button buttonSolKontrol;
        private Panel panelKontrol;
        private Panel panelUrunK;
        private Button buttonSolUrunK;
        private Panel panelKategoriK;
        private Button buttonSolKategoriK;
        private Panel panelMenuKayit;
        private Button buttonSolMenuKayit;
        private Panel panelRapor;
        private Button buttonSolRapor;
        private FlowLayoutPanel kayitMenuPanel;
        private Panel panelMusteriK;
        private Button buttonSolMusteriK;
        private Panel panelTedarikciK;
        private Button buttonSolTedarikciK;
        private System.Windows.Forms.Timer menuKayitHareket;
        private System.Windows.Forms.Timer yanPanelHareket;
        private Button button8;
        private Button button10;
        private Button btnBuyut;
        private PictureBox prefPictureBox;
        private Panel AnaHPanel;
        private PictureBox pictureBoxProfile;
        private PictureBox pictureBoxNotf;
        private ToolStripDropDown popup;
        private ToolStripDropDown popupHesap;
        private Label labelBaslik;
        private Panel panelForm;
        private Panel SolHPanel;
        private Panel panelSolSistemA;
        private Button buttonSolSistemAyar;
        private Panel panelSolDenetinK;
        private Button buttonSolDenetimKayit;
        private Panel panelSolKullaniciA;
        private Button buttonSolKullaniciAyar;
        private Panel panelSolStokG;
        private Button buttonSolStokG;
        private Panel panelSolStokC;
        private Button buttonSolStokCıkış;
        private Panel panelSolStokL;
        private Button buttonStokList;
        private Panel panelDestek;
        private Button buttonDestek;
        private Panel panelChatBot;
        private Button buttonChatBot;
        private Panel panelRaporDepo;
        private Button buttonRaporDEpo;
        private Panel panelSatisF;
        private Button buttonSatisF;
    }
}