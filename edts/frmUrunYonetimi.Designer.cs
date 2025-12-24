namespace edts
{
    partial class frmUrunYonetimi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btnGuncelle = new KavisliButon();
            btnKaydett = new KavisliButon();
            btnSill = new KavisliButon();
            birimFiyat = new NumericUpDown();
            label10 = new Label();
            comboBox2 = new ComboBox();
            comboBoxKategori = new ComboBox();
            txtUrunKod = new TextBox();
            txtKritik = new TextBox();
            txtUrunAd = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            btnKategoriSill = new KavisliButon();
            btnKategoriGuncellee = new KavisliButon();
            btnKategoriKaydett = new KavisliButon();
            txtKategoriAciklama = new TextBox();
            lblAciklama = new Label();
            txtKategoriAdi = new TextBox();
            lblKategoriAdi = new Label();
            tabPage3 = new TabPage();
            btnTedarikciSill = new KavisliButon();
            btnTedarikciGuncellee = new KavisliButon();
            btnTedarikciKaydett = new KavisliButon();
            lblAdres = new Label();
            txtTelefon = new TextBox();
            txtVergiDairesi = new TextBox();
            txtVergiNo = new TextBox();
            txtFirmaAdi = new TextBox();
            lblTelefon = new Label();
            lblYetkiliKisi = new Label();
            lblFirmaAdi = new Label();
            tabPage4 = new TabPage();
            musteriGuncel = new Button();
            musteriSil = new Button();
            musteriKayit = new Button();
            label6 = new Label();
            textMusteriTel = new TextBox();
            textMusteriVd = new TextBox();
            textMusteriVNo = new TextBox();
            textMusteriAd = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            panel2 = new Panel();
            dataGridView2 = new DataGridView();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)birimFiyat).BeginInit();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSteelBlue;
            panel1.Controls.Add(tabControl1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(588, 766);
            panel1.TabIndex = 2;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(12, 131);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(554, 556);
            tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.LightSlateGray;
            tabPage1.Controls.Add(btnGuncelle);
            tabPage1.Controls.Add(btnKaydett);
            tabPage1.Controls.Add(btnSill);
            tabPage1.Controls.Add(birimFiyat);
            tabPage1.Controls.Add(label10);
            tabPage1.Controls.Add(comboBox2);
            tabPage1.Controls.Add(comboBoxKategori);
            tabPage1.Controls.Add(txtUrunKod);
            tabPage1.Controls.Add(txtKritik);
            tabPage1.Controls.Add(txtUrunAd);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Margin = new Padding(3, 4, 3, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 4, 3, 4);
            tabPage1.Size = new Size(546, 523);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Ürün Tanımlama";
            // 
            // btnGuncelle
            // 
            btnGuncelle.BorderRadius = 30;
            btnGuncelle.FlatAppearance.BorderSize = 0;
            btnGuncelle.FlatStyle = FlatStyle.System;
            btnGuncelle.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnGuncelle.Location = new Point(221, 317);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(104, 38);
            btnGuncelle.TabIndex = 31;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = true;
            // 
            // btnKaydett
            // 
            btnKaydett.BorderRadius = 30;
            btnKaydett.FlatAppearance.BorderSize = 0;
            btnKaydett.FlatStyle = FlatStyle.System;
            btnKaydett.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnKaydett.Location = new Point(111, 317);
            btnKaydett.Name = "btnKaydett";
            btnKaydett.Size = new Size(104, 38);
            btnKaydett.TabIndex = 30;
            btnKaydett.Text = "Kaydet";
            btnKaydett.UseVisualStyleBackColor = true;
            // 
            // btnSill
            // 
            btnSill.BorderRadius = 30;
            btnSill.FlatAppearance.BorderSize = 0;
            btnSill.FlatStyle = FlatStyle.System;
            btnSill.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnSill.Location = new Point(331, 317);
            btnSill.Name = "btnSill";
            btnSill.Size = new Size(104, 38);
            btnSill.TabIndex = 29;
            btnSill.Text = "Sil";
            btnSill.UseVisualStyleBackColor = true;
            // 
            // birimFiyat
            // 
            birimFiyat.Location = new Point(246, 240);
            birimFiyat.Margin = new Padding(3, 4, 3, 4);
            birimFiyat.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            birimFiyat.Name = "birimFiyat";
            birimFiyat.Size = new Size(189, 27);
            birimFiyat.TabIndex = 28;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label10.ForeColor = SystemColors.ControlLightLight;
            label10.Location = new Point(45, 244);
            label10.Name = "label10";
            label10.Size = new Size(106, 23);
            label10.TabIndex = 27;
            label10.Text = "Birim fiyat: ";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(246, 168);
            comboBox2.Margin = new Padding(3, 4, 3, 4);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(188, 28);
            comboBox2.TabIndex = 26;
            // 
            // comboBoxKategori
            // 
            comboBoxKategori.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxKategori.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxKategori.FormattingEnabled = true;
            comboBoxKategori.Location = new Point(246, 131);
            comboBoxKategori.Margin = new Padding(3, 4, 3, 4);
            comboBoxKategori.Name = "comboBoxKategori";
            comboBoxKategori.Size = new Size(188, 28);
            comboBoxKategori.TabIndex = 25;
            // 
            // txtUrunKod
            // 
            txtUrunKod.Location = new Point(246, 95);
            txtUrunKod.Margin = new Padding(3, 4, 3, 4);
            txtUrunKod.Name = "txtUrunKod";
            txtUrunKod.Size = new Size(188, 27);
            txtUrunKod.TabIndex = 24;
            // 
            // txtKritik
            // 
            txtKritik.Location = new Point(246, 204);
            txtKritik.Margin = new Padding(3, 4, 3, 4);
            txtKritik.Name = "txtKritik";
            txtKritik.Size = new Size(188, 27);
            txtKritik.TabIndex = 23;
            // 
            // txtUrunAd
            // 
            txtUrunAd.Location = new Point(246, 58);
            txtUrunAd.Margin = new Padding(3, 4, 3, 4);
            txtUrunAd.Name = "txtUrunAd";
            txtUrunAd.Size = new Size(188, 27);
            txtUrunAd.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(45, 212);
            label5.Name = "label5";
            label5.Size = new Size(170, 23);
            label5.TabIndex = 18;
            label5.Text = "Kritik Stok Seviyesi:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(45, 177);
            label4.Name = "label4";
            label4.Size = new Size(95, 23);
            label4.TabIndex = 17;
            label4.Text = "Birim Tipi:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(45, 137);
            label3.Name = "label3";
            label3.Size = new Size(84, 23);
            label3.TabIndex = 16;
            label3.Text = "Kategori:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(45, 101);
            label2.Name = "label2";
            label2.Size = new Size(101, 23);
            label2.TabIndex = 15;
            label2.Text = "Ürün Kodu:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(45, 62);
            label1.Name = "label1";
            label1.Size = new Size(87, 23);
            label1.TabIndex = 14;
            label1.Text = "Ürün Adı:";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.LightSlateGray;
            tabPage2.Controls.Add(btnKategoriSill);
            tabPage2.Controls.Add(btnKategoriGuncellee);
            tabPage2.Controls.Add(btnKategoriKaydett);
            tabPage2.Controls.Add(txtKategoriAciklama);
            tabPage2.Controls.Add(lblAciklama);
            tabPage2.Controls.Add(txtKategoriAdi);
            tabPage2.Controls.Add(lblKategoriAdi);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Margin = new Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 4, 3, 4);
            tabPage2.Size = new Size(546, 523);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Kategori Tanımlama";
            // 
            // btnKategoriSill
            // 
            btnKategoriSill.BorderRadius = 30;
            btnKategoriSill.FlatStyle = FlatStyle.System;
            btnKategoriSill.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnKategoriSill.Location = new Point(388, 411);
            btnKategoriSill.Name = "btnKategoriSill";
            btnKategoriSill.Size = new Size(101, 39);
            btnKategoriSill.TabIndex = 9;
            btnKategoriSill.Text = "Sil";
            btnKategoriSill.UseVisualStyleBackColor = true;
            // 
            // btnKategoriGuncellee
            // 
            btnKategoriGuncellee.BorderRadius = 30;
            btnKategoriGuncellee.FlatStyle = FlatStyle.System;
            btnKategoriGuncellee.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnKategoriGuncellee.Location = new Point(281, 411);
            btnKategoriGuncellee.Name = "btnKategoriGuncellee";
            btnKategoriGuncellee.Size = new Size(101, 39);
            btnKategoriGuncellee.TabIndex = 8;
            btnKategoriGuncellee.Text = "Güncelle";
            btnKategoriGuncellee.UseVisualStyleBackColor = true;
            // 
            // btnKategoriKaydett
            // 
            btnKategoriKaydett.BorderRadius = 30;
            btnKategoriKaydett.FlatStyle = FlatStyle.System;
            btnKategoriKaydett.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnKategoriKaydett.Location = new Point(174, 411);
            btnKategoriKaydett.Name = "btnKategoriKaydett";
            btnKategoriKaydett.Size = new Size(101, 39);
            btnKategoriKaydett.TabIndex = 7;
            btnKategoriKaydett.Text = "Kaydet";
            btnKategoriKaydett.UseVisualStyleBackColor = true;
            // 
            // txtKategoriAciklama
            // 
            txtKategoriAciklama.Location = new Point(153, 104);
            txtKategoriAciklama.Margin = new Padding(3, 4, 3, 4);
            txtKategoriAciklama.Multiline = true;
            txtKategoriAciklama.Name = "txtKategoriAciklama";
            txtKategoriAciklama.ScrollBars = ScrollBars.Vertical;
            txtKategoriAciklama.Size = new Size(350, 300);
            txtKategoriAciklama.TabIndex = 3;
            // 
            // lblAciklama
            // 
            lblAciklama.AutoSize = true;
            lblAciklama.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblAciklama.ForeColor = SystemColors.ControlLightLight;
            lblAciklama.Location = new Point(56, 108);
            lblAciklama.Name = "lblAciklama";
            lblAciklama.Size = new Size(94, 23);
            lblAciklama.TabIndex = 2;
            lblAciklama.Text = "Açıklama :";
            // 
            // txtKategoriAdi
            // 
            txtKategoriAdi.Location = new Point(156, 57);
            txtKategoriAdi.Margin = new Padding(3, 4, 3, 4);
            txtKategoriAdi.Name = "txtKategoriAdi";
            txtKategoriAdi.Size = new Size(347, 27);
            txtKategoriAdi.TabIndex = 1;
            // 
            // lblKategoriAdi
            // 
            lblKategoriAdi.AutoSize = true;
            lblKategoriAdi.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblKategoriAdi.ForeColor = SystemColors.ControlLightLight;
            lblKategoriAdi.Location = new Point(33, 61);
            lblKategoriAdi.Name = "lblKategoriAdi";
            lblKategoriAdi.Size = new Size(117, 23);
            lblKategoriAdi.TabIndex = 0;
            lblKategoriAdi.Text = "Kategori Adı:";
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.LightSlateGray;
            tabPage3.Controls.Add(btnTedarikciSill);
            tabPage3.Controls.Add(btnTedarikciGuncellee);
            tabPage3.Controls.Add(btnTedarikciKaydett);
            tabPage3.Controls.Add(lblAdres);
            tabPage3.Controls.Add(txtTelefon);
            tabPage3.Controls.Add(txtVergiDairesi);
            tabPage3.Controls.Add(txtVergiNo);
            tabPage3.Controls.Add(txtFirmaAdi);
            tabPage3.Controls.Add(lblTelefon);
            tabPage3.Controls.Add(lblYetkiliKisi);
            tabPage3.Controls.Add(lblFirmaAdi);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Margin = new Padding(3, 4, 3, 4);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3, 4, 3, 4);
            tabPage3.Size = new Size(546, 523);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Tedarikçi Tanımlama";
            // 
            // btnTedarikciSill
            // 
            btnTedarikciSill.BackColor = Color.White;
            btnTedarikciSill.BorderRadius = 30;
            btnTedarikciSill.FlatAppearance.BorderSize = 0;
            btnTedarikciSill.FlatStyle = FlatStyle.System;
            btnTedarikciSill.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnTedarikciSill.Location = new Point(382, 292);
            btnTedarikciSill.Name = "btnTedarikciSill";
            btnTedarikciSill.Size = new Size(93, 45);
            btnTedarikciSill.TabIndex = 13;
            btnTedarikciSill.Text = "Sil";
            btnTedarikciSill.UseVisualStyleBackColor = false;
            // 
            // btnTedarikciGuncellee
            // 
            btnTedarikciGuncellee.BackColor = Color.White;
            btnTedarikciGuncellee.BorderRadius = 30;
            btnTedarikciGuncellee.FlatAppearance.BorderSize = 0;
            btnTedarikciGuncellee.FlatStyle = FlatStyle.System;
            btnTedarikciGuncellee.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnTedarikciGuncellee.Location = new Point(283, 292);
            btnTedarikciGuncellee.Name = "btnTedarikciGuncellee";
            btnTedarikciGuncellee.Size = new Size(93, 45);
            btnTedarikciGuncellee.TabIndex = 12;
            btnTedarikciGuncellee.Text = "Güncelle";
            btnTedarikciGuncellee.UseVisualStyleBackColor = false;
            // 
            // btnTedarikciKaydett
            // 
            btnTedarikciKaydett.BackColor = Color.White;
            btnTedarikciKaydett.BorderRadius = 30;
            btnTedarikciKaydett.FlatAppearance.BorderSize = 0;
            btnTedarikciKaydett.FlatStyle = FlatStyle.System;
            btnTedarikciKaydett.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnTedarikciKaydett.Location = new Point(184, 292);
            btnTedarikciKaydett.Name = "btnTedarikciKaydett";
            btnTedarikciKaydett.Size = new Size(93, 45);
            btnTedarikciKaydett.TabIndex = 11;
            btnTedarikciKaydett.Text = "Kaydet";
            btnTedarikciKaydett.UseVisualStyleBackColor = false;
            // 
            // lblAdres
            // 
            lblAdres.AutoSize = true;
            lblAdres.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblAdres.ForeColor = SystemColors.ControlLightLight;
            lblAdres.Location = new Point(49, 228);
            lblAdres.Name = "lblAdres";
            lblAdres.Size = new Size(78, 23);
            lblAdres.TabIndex = 7;
            lblAdres.Text = "Telefon: ";
            // 
            // txtTelefon
            // 
            txtTelefon.Location = new Point(184, 220);
            txtTelefon.Margin = new Padding(3, 4, 3, 4);
            txtTelefon.Multiline = true;
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(291, 29);
            txtTelefon.TabIndex = 6;
            // 
            // txtVergiDairesi
            // 
            txtVergiDairesi.Location = new Point(184, 159);
            txtVergiDairesi.Margin = new Padding(3, 4, 3, 4);
            txtVergiDairesi.Name = "txtVergiDairesi";
            txtVergiDairesi.Size = new Size(291, 27);
            txtVergiDairesi.TabIndex = 5;
            // 
            // txtVergiNo
            // 
            txtVergiNo.Location = new Point(184, 106);
            txtVergiNo.Margin = new Padding(3, 4, 3, 4);
            txtVergiNo.Name = "txtVergiNo";
            txtVergiNo.Size = new Size(291, 27);
            txtVergiNo.TabIndex = 4;
            // 
            // txtFirmaAdi
            // 
            txtFirmaAdi.Location = new Point(184, 58);
            txtFirmaAdi.Margin = new Padding(3, 4, 3, 4);
            txtFirmaAdi.Name = "txtFirmaAdi";
            txtFirmaAdi.Size = new Size(291, 27);
            txtFirmaAdi.TabIndex = 3;
            // 
            // lblTelefon
            // 
            lblTelefon.AutoSize = true;
            lblTelefon.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblTelefon.ForeColor = SystemColors.ControlLightLight;
            lblTelefon.Location = new Point(49, 168);
            lblTelefon.Name = "lblTelefon";
            lblTelefon.Size = new Size(117, 23);
            lblTelefon.TabIndex = 2;
            lblTelefon.Text = "Vergi Dairesi:";
            // 
            // lblYetkiliKisi
            // 
            lblYetkiliKisi.AutoSize = true;
            lblYetkiliKisi.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblYetkiliKisi.ForeColor = SystemColors.ControlLightLight;
            lblYetkiliKisi.Location = new Point(49, 116);
            lblYetkiliKisi.Name = "lblYetkiliKisi";
            lblYetkiliKisi.Size = new Size(85, 23);
            lblYetkiliKisi.TabIndex = 1;
            lblYetkiliKisi.Text = "Vergi No:";
            // 
            // lblFirmaAdi
            // 
            lblFirmaAdi.AutoSize = true;
            lblFirmaAdi.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblFirmaAdi.ForeColor = SystemColors.ControlLightLight;
            lblFirmaAdi.Location = new Point(49, 66);
            lblFirmaAdi.Name = "lblFirmaAdi";
            lblFirmaAdi.Size = new Size(94, 23);
            lblFirmaAdi.TabIndex = 0;
            lblFirmaAdi.Text = "Firma Adı:";
            // 
            // tabPage4
            // 
            tabPage4.BackColor = Color.LightSlateGray;
            tabPage4.Controls.Add(musteriGuncel);
            tabPage4.Controls.Add(musteriSil);
            tabPage4.Controls.Add(musteriKayit);
            tabPage4.Controls.Add(label6);
            tabPage4.Controls.Add(textMusteriTel);
            tabPage4.Controls.Add(textMusteriVd);
            tabPage4.Controls.Add(textMusteriVNo);
            tabPage4.Controls.Add(textMusteriAd);
            tabPage4.Controls.Add(label7);
            tabPage4.Controls.Add(label8);
            tabPage4.Controls.Add(label9);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Margin = new Padding(3, 4, 3, 4);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3, 4, 3, 4);
            tabPage4.Size = new Size(546, 523);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Müşteri Tanımlama";
            // 
            // musteriGuncel
            // 
            musteriGuncel.BackColor = SystemColors.ControlLightLight;
            musteriGuncel.FlatAppearance.BorderSize = 0;
            musteriGuncel.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            musteriGuncel.Location = new Point(308, 298);
            musteriGuncel.Margin = new Padding(3, 4, 3, 4);
            musteriGuncel.Name = "musteriGuncel";
            musteriGuncel.Size = new Size(91, 33);
            musteriGuncel.TabIndex = 10;
            musteriGuncel.Text = "Güncelle";
            musteriGuncel.UseVisualStyleBackColor = false;
            // 
            // musteriSil
            // 
            musteriSil.BackColor = SystemColors.ControlLightLight;
            musteriSil.FlatAppearance.BorderSize = 0;
            musteriSil.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            musteriSil.Location = new Point(405, 298);
            musteriSil.Margin = new Padding(3, 4, 3, 4);
            musteriSil.Name = "musteriSil";
            musteriSil.Size = new Size(91, 33);
            musteriSil.TabIndex = 9;
            musteriSil.Text = "Sil";
            musteriSil.UseVisualStyleBackColor = false;
            // 
            // musteriKayit
            // 
            musteriKayit.BackColor = SystemColors.ControlLightLight;
            musteriKayit.FlatAppearance.BorderSize = 0;
            musteriKayit.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            musteriKayit.Location = new Point(211, 298);
            musteriKayit.Margin = new Padding(3, 4, 3, 4);
            musteriKayit.Name = "musteriKayit";
            musteriKayit.Size = new Size(91, 33);
            musteriKayit.TabIndex = 8;
            musteriKayit.Text = "Kaydet";
            musteriKayit.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label6.ForeColor = SystemColors.ControlLightLight;
            label6.Location = new Point(66, 241);
            label6.Name = "label6";
            label6.Size = new Size(78, 23);
            label6.TabIndex = 7;
            label6.Text = "Telefon: ";
            // 
            // textMusteriTel
            // 
            textMusteriTel.Location = new Point(211, 229);
            textMusteriTel.Margin = new Padding(3, 4, 3, 4);
            textMusteriTel.Multiline = true;
            textMusteriTel.Name = "textMusteriTel";
            textMusteriTel.Size = new Size(285, 35);
            textMusteriTel.TabIndex = 6;
            // 
            // textMusteriVd
            // 
            textMusteriVd.Location = new Point(211, 168);
            textMusteriVd.Margin = new Padding(3, 4, 3, 4);
            textMusteriVd.Name = "textMusteriVd";
            textMusteriVd.Size = new Size(285, 27);
            textMusteriVd.TabIndex = 5;
            // 
            // textMusteriVNo
            // 
            textMusteriVNo.Location = new Point(211, 115);
            textMusteriVNo.Margin = new Padding(3, 4, 3, 4);
            textMusteriVNo.Name = "textMusteriVNo";
            textMusteriVNo.Size = new Size(285, 27);
            textMusteriVNo.TabIndex = 4;
            // 
            // textMusteriAd
            // 
            textMusteriAd.Location = new Point(211, 67);
            textMusteriAd.Margin = new Padding(3, 4, 3, 4);
            textMusteriAd.Name = "textMusteriAd";
            textMusteriAd.Size = new Size(285, 27);
            textMusteriAd.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label7.ForeColor = SystemColors.ControlLightLight;
            label7.Location = new Point(66, 172);
            label7.Name = "label7";
            label7.Size = new Size(117, 23);
            label7.TabIndex = 2;
            label7.Text = "Vergi Dairesi:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label8.ForeColor = SystemColors.ControlLightLight;
            label8.Location = new Point(66, 119);
            label8.Name = "label8";
            label8.Size = new Size(85, 23);
            label8.TabIndex = 1;
            label8.Text = "Vergi No:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label9.ForeColor = SystemColors.ControlLightLight;
            label9.Location = new Point(66, 71);
            label9.Name = "label9";
            label9.Size = new Size(109, 23);
            label9.TabIndex = 0;
            label9.Text = "Müşteri Adı:";
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(588, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(621, 766);
            panel2.TabIndex = 3;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.Location = new Point(0, 0);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(621, 766);
            dataGridView2.TabIndex = 0;
            // 
            // frmUrunYonetimi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1209, 766);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmUrunYonetimi";
            Text = "frmUrunYonetimi";
            panel1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)birimFiyat).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private NumericUpDown birimFiyat;
        private Label label10;
        private ComboBox comboBox2;
        private ComboBox comboBoxKategori;
        private TextBox txtUrunKod;
        private TextBox txtKritik;
        private TextBox txtUrunAd;
        private Button btnSil;
        private Button btnKaydet;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TabPage tabPage2;
        private KavisliButon btnKategoriSill;
        private KavisliButon btnKategoriGuncellee;
        private KavisliButon btnKategoriKaydett;
        private TextBox txtKategoriAciklama;
        private Label lblAciklama;
        private TextBox txtKategoriAdi;
        private Label lblKategoriAdi;
        private TabPage tabPage3;
        private KavisliButon btnTedarikciSill;
        private KavisliButon btnTedarikciKaydett;
        private Label lblAdres;
        private TextBox txtTelefon;
        private TextBox txtVergiDairesi;
        private TextBox txtVergiNo;
        private TextBox txtFirmaAdi;
        private Label lblTelefon;
        private Label lblYetkiliKisi;
        private Label lblFirmaAdi;
        private TabPage tabPage4;
        private Button musteriGuncel;
        private Button musteriSil;
        private Button musteriKayit;
        private Label label6;
        private TextBox textMusteriTel;
        private TextBox textMusteriVd;
        private TextBox textMusteriVNo;
        private TextBox textMusteriAd;
        private Label label7;
        private Label label8;
        private Label label9;
        private Panel panel2;
        private KavisliButon btnSill;
        private KavisliButon kavisliButon3;
        private KavisliButon btnKaydett;
        private DataGridView dataGridView2;
        private KavisliButon btnGuncelle;
        private KavisliButon btnTedarikciGuncellee;
    }
}