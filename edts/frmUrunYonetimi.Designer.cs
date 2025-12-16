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
        private void InitializeComponent() {
            panel1 = new Panel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            birimFiyat = new NumericUpDown();
            label10 = new Label();
            comboBox2 = new ComboBox();
            comboBoxKategori = new ComboBox();
            txtUrunKod = new TextBox();
            txtKritik = new TextBox();
            txtUrunAd = new TextBox();
            btnSil = new Button();
            btnGuncelle = new Button();
            btnKaydet = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            btnKategoriSil = new Button();
            btnKategoriGuncelle = new Button();
            btnKategoriKaydet = new Button();
            txtKategoriAciklama = new TextBox();
            lblAciklama = new Label();
            txtKategoriAdi = new TextBox();
            lblKategoriAdi = new Label();
            tabPage3 = new TabPage();
            btnTedarikciGuncelle = new Button();
            btnTedarikciSil = new Button();
            btnTedarikciKaydet = new Button();
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
            dataGridView1 = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)birimFiyat).BeginInit();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkOliveGreen;
            panel1.Controls.Add(tabControl1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(390, 516);
            panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(10, 26);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(363, 473);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.DarkOliveGreen;
            tabPage1.Controls.Add(birimFiyat);
            tabPage1.Controls.Add(label10);
            tabPage1.Controls.Add(comboBox2);
            tabPage1.Controls.Add(comboBoxKategori);
            tabPage1.Controls.Add(txtUrunKod);
            tabPage1.Controls.Add(txtKritik);
            tabPage1.Controls.Add(txtUrunAd);
            tabPage1.Controls.Add(btnSil);
            tabPage1.Controls.Add(btnGuncelle);
            tabPage1.Controls.Add(btnKaydet);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 48);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(355, 421);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Ürün Tanımlama";
            // 
            // birimFiyat
            // 
            birimFiyat.Location = new Point(183, 235);
            birimFiyat.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            birimFiyat.Name = "birimFiyat";
            birimFiyat.Size = new Size(145, 25);
            birimFiyat.TabIndex = 28;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label10.ForeColor = SystemColors.ControlLightLight;
            label10.Location = new Point(34, 239);
            label10.Name = "label10";
            label10.Size = new Size(92, 21);
            label10.TabIndex = 27;
            label10.Text = "Birim fiyat: ";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(183, 173);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(145, 25);
            comboBox2.TabIndex = 26;
            // 
            // comboBoxKategori
            // 
            comboBoxKategori.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxKategori.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxKategori.FormattingEnabled = true;
            comboBoxKategori.Location = new Point(183, 142);
            comboBoxKategori.Name = "comboBoxKategori";
            comboBoxKategori.Size = new Size(145, 25);
            comboBoxKategori.TabIndex = 25;
            // 
            // txtUrunKod
            // 
            txtUrunKod.Location = new Point(183, 111);
            txtUrunKod.Name = "txtUrunKod";
            txtUrunKod.Size = new Size(145, 25);
            txtUrunKod.TabIndex = 24;
            // 
            // txtKritik
            // 
            txtKritik.Location = new Point(183, 204);
            txtKritik.Name = "txtKritik";
            txtKritik.Size = new Size(145, 25);
            txtKritik.TabIndex = 23;
            // 
            // txtUrunAd
            // 
            txtUrunAd.Location = new Point(183, 80);
            txtUrunAd.Name = "txtUrunAd";
            txtUrunAd.Size = new Size(145, 25);
            txtUrunAd.TabIndex = 22;
            // 
            // btnSil
            // 
            btnSil.BackColor = Color.Crimson;
            btnSil.FlatAppearance.BorderSize = 0;
            btnSil.FlatStyle = FlatStyle.Flat;
            btnSil.ForeColor = SystemColors.ControlLightLight;
            btnSil.Location = new Point(169, 301);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(82, 25);
            btnSil.TabIndex = 21;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += btnSil_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.BackColor = Color.DarkCyan;
            btnGuncelle.FlatAppearance.BorderSize = 0;
            btnGuncelle.FlatStyle = FlatStyle.Flat;
            btnGuncelle.ForeColor = SystemColors.ControlLightLight;
            btnGuncelle.Location = new Point(72, 331);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(82, 25);
            btnGuncelle.TabIndex = 20;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = false;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // btnKaydet
            // 
            btnKaydet.BackColor = Color.DarkCyan;
            btnKaydet.FlatAppearance.BorderSize = 0;
            btnKaydet.FlatStyle = FlatStyle.Flat;
            btnKaydet.ForeColor = SystemColors.ControlLightLight;
            btnKaydet.Location = new Point(72, 301);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(82, 25);
            btnKaydet.TabIndex = 19;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = false;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(34, 212);
            label5.Name = "label5";
            label5.Size = new Size(151, 21);
            label5.TabIndex = 18;
            label5.Text = "Kritik Stok Seviyesi:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(34, 182);
            label4.Name = "label4";
            label4.Size = new Size(83, 21);
            label4.TabIndex = 17;
            label4.Text = "Birim Tipi:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(34, 148);
            label3.Name = "label3";
            label3.Size = new Size(77, 21);
            label3.TabIndex = 16;
            label3.Text = "Kategori:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(34, 117);
            label2.Name = "label2";
            label2.Size = new Size(92, 21);
            label2.TabIndex = 15;
            label2.Text = "Ürün Kodu:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(34, 84);
            label1.Name = "label1";
            label1.Size = new Size(78, 21);
            label1.TabIndex = 14;
            label1.Text = "Ürün Adı:";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.DarkOliveGreen;
            tabPage2.Controls.Add(btnKategoriSil);
            tabPage2.Controls.Add(btnKategoriGuncelle);
            tabPage2.Controls.Add(btnKategoriKaydet);
            tabPage2.Controls.Add(txtKategoriAciklama);
            tabPage2.Controls.Add(lblAciklama);
            tabPage2.Controls.Add(txtKategoriAdi);
            tabPage2.Controls.Add(lblKategoriAdi);
            tabPage2.Location = new Point(4, 48);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(355, 421);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Kategori Tanımlama";
            // 
            // btnKategoriSil
            // 
            btnKategoriSil.BackColor = Color.Crimson;
            btnKategoriSil.FlatAppearance.BorderSize = 0;
            btnKategoriSil.FlatStyle = FlatStyle.Flat;
            btnKategoriSil.ForeColor = SystemColors.ControlLightLight;
            btnKategoriSil.Location = new Point(130, 276);
            btnKategoriSil.Name = "btnKategoriSil";
            btnKategoriSil.Size = new Size(82, 25);
            btnKategoriSil.TabIndex = 6;
            btnKategoriSil.Text = "Sil";
            btnKategoriSil.UseVisualStyleBackColor = false;
            btnKategoriSil.Click += btnKategoriSil_Click;
            // 
            // btnKategoriGuncelle
            // 
            btnKategoriGuncelle.BackColor = Color.MediumTurquoise;
            btnKategoriGuncelle.FlatAppearance.BorderSize = 0;
            btnKategoriGuncelle.FlatStyle = FlatStyle.Flat;
            btnKategoriGuncelle.ForeColor = SystemColors.ControlLightLight;
            btnKategoriGuncelle.Location = new Point(218, 232);
            btnKategoriGuncelle.Name = "btnKategoriGuncelle";
            btnKategoriGuncelle.Size = new Size(82, 25);
            btnKategoriGuncelle.TabIndex = 5;
            btnKategoriGuncelle.Text = "Güncelle";
            btnKategoriGuncelle.UseVisualStyleBackColor = false;
            btnKategoriGuncelle.Click += btnKategoriGuncelle_Click;
            // 
            // btnKategoriKaydet
            // 
            btnKategoriKaydet.BackColor = Color.Blue;
            btnKategoriKaydet.FlatAppearance.BorderSize = 0;
            btnKategoriKaydet.FlatStyle = FlatStyle.Flat;
            btnKategoriKaydet.ForeColor = SystemColors.ControlLightLight;
            btnKategoriKaydet.Location = new Point(130, 232);
            btnKategoriKaydet.Name = "btnKategoriKaydet";
            btnKategoriKaydet.Size = new Size(82, 25);
            btnKategoriKaydet.TabIndex = 4;
            btnKategoriKaydet.Text = "Kaydet";
            btnKategoriKaydet.UseVisualStyleBackColor = false;
            btnKategoriKaydet.Click += btnKategoriKaydet_Click;
            // 
            // txtKategoriAciklama
            // 
            txtKategoriAciklama.Location = new Point(130, 109);
            txtKategoriAciklama.Multiline = true;
            txtKategoriAciklama.Name = "txtKategoriAciklama";
            txtKategoriAciklama.ScrollBars = ScrollBars.Vertical;
            txtKategoriAciklama.Size = new Size(170, 90);
            txtKategoriAciklama.TabIndex = 3;
            // 
            // lblAciklama
            // 
            lblAciklama.AutoSize = true;
            lblAciklama.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblAciklama.ForeColor = SystemColors.ControlLightLight;
            lblAciklama.Location = new Point(41, 110);
            lblAciklama.Name = "lblAciklama";
            lblAciklama.Size = new Size(83, 21);
            lblAciklama.TabIndex = 2;
            lblAciklama.Text = "Açıklama :";
            // 
            // txtKategoriAdi
            // 
            txtKategoriAdi.Location = new Point(130, 71);
            txtKategoriAdi.Name = "txtKategoriAdi";
            txtKategoriAdi.Size = new Size(170, 25);
            txtKategoriAdi.TabIndex = 1;
            // 
            // lblKategoriAdi
            // 
            lblKategoriAdi.AutoSize = true;
            lblKategoriAdi.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblKategoriAdi.ForeColor = SystemColors.ControlLightLight;
            lblKategoriAdi.Location = new Point(18, 72);
            lblKategoriAdi.Name = "lblKategoriAdi";
            lblKategoriAdi.Size = new Size(106, 21);
            lblKategoriAdi.TabIndex = 0;
            lblKategoriAdi.Text = "Kategori Adı:";
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.DarkOliveGreen;
            tabPage3.Controls.Add(btnTedarikciGuncelle);
            tabPage3.Controls.Add(btnTedarikciSil);
            tabPage3.Controls.Add(btnTedarikciKaydet);
            tabPage3.Controls.Add(lblAdres);
            tabPage3.Controls.Add(txtTelefon);
            tabPage3.Controls.Add(txtVergiDairesi);
            tabPage3.Controls.Add(txtVergiNo);
            tabPage3.Controls.Add(txtFirmaAdi);
            tabPage3.Controls.Add(lblTelefon);
            tabPage3.Controls.Add(lblYetkiliKisi);
            tabPage3.Controls.Add(lblFirmaAdi);
            tabPage3.Location = new Point(4, 48);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(355, 421);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Tedarikçi Tanımlama";
            // 
            // btnTedarikciGuncelle
            // 
            btnTedarikciGuncelle.FlatAppearance.BorderSize = 0;
            btnTedarikciGuncelle.Location = new Point(145, 274);
            btnTedarikciGuncelle.Name = "btnTedarikciGuncelle";
            btnTedarikciGuncelle.Size = new Size(82, 25);
            btnTedarikciGuncelle.TabIndex = 10;
            btnTedarikciGuncelle.Text = "Güncelle";
            btnTedarikciGuncelle.UseVisualStyleBackColor = true;
            btnTedarikciGuncelle.Click += btnTedarikciGuncelle_Click;
            // 
            // btnTedarikciSil
            // 
            btnTedarikciSil.FlatAppearance.BorderSize = 0;
            btnTedarikciSil.Location = new Point(58, 303);
            btnTedarikciSil.Name = "btnTedarikciSil";
            btnTedarikciSil.Size = new Size(82, 25);
            btnTedarikciSil.TabIndex = 9;
            btnTedarikciSil.Text = "Sil";
            btnTedarikciSil.UseVisualStyleBackColor = true;
            btnTedarikciSil.Click += btnTedarikciSil_Click;
            // 
            // btnTedarikciKaydet
            // 
            btnTedarikciKaydet.FlatAppearance.BorderSize = 0;
            btnTedarikciKaydet.Location = new Point(58, 274);
            btnTedarikciKaydet.Name = "btnTedarikciKaydet";
            btnTedarikciKaydet.Size = new Size(82, 25);
            btnTedarikciKaydet.TabIndex = 8;
            btnTedarikciKaydet.Text = "Kaydet";
            btnTedarikciKaydet.UseVisualStyleBackColor = true;
            btnTedarikciKaydet.Click += btnTedarikciEkle_Click;
            // 
            // lblAdres
            // 
            lblAdres.AutoSize = true;
            lblAdres.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblAdres.ForeColor = SystemColors.ControlLightLight;
            lblAdres.Location = new Point(35, 184);
            lblAdres.Name = "lblAdres";
            lblAdres.Size = new Size(72, 21);
            lblAdres.TabIndex = 7;
            lblAdres.Text = "Telefon: ";
            // 
            // txtTelefon
            // 
            txtTelefon.Location = new Point(142, 184);
            txtTelefon.Multiline = true;
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(176, 25);
            txtTelefon.TabIndex = 6;
            // 
            // txtVergiDairesi
            // 
            txtVergiDairesi.Location = new Point(142, 132);
            txtVergiDairesi.Name = "txtVergiDairesi";
            txtVergiDairesi.Size = new Size(176, 25);
            txtVergiDairesi.TabIndex = 5;
            // 
            // txtVergiNo
            // 
            txtVergiNo.Location = new Point(142, 87);
            txtVergiNo.Name = "txtVergiNo";
            txtVergiNo.Size = new Size(176, 25);
            txtVergiNo.TabIndex = 4;
            // 
            // txtFirmaAdi
            // 
            txtFirmaAdi.Location = new Point(142, 46);
            txtFirmaAdi.Name = "txtFirmaAdi";
            txtFirmaAdi.Size = new Size(176, 25);
            txtFirmaAdi.TabIndex = 3;
            // 
            // lblTelefon
            // 
            lblTelefon.AutoSize = true;
            lblTelefon.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblTelefon.ForeColor = SystemColors.ControlLightLight;
            lblTelefon.Location = new Point(35, 133);
            lblTelefon.Name = "lblTelefon";
            lblTelefon.Size = new Size(105, 21);
            lblTelefon.TabIndex = 2;
            lblTelefon.Text = "Vergi Dairesi:";
            // 
            // lblYetkiliKisi
            // 
            lblYetkiliKisi.AutoSize = true;
            lblYetkiliKisi.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblYetkiliKisi.ForeColor = SystemColors.ControlLightLight;
            lblYetkiliKisi.Location = new Point(35, 88);
            lblYetkiliKisi.Name = "lblYetkiliKisi";
            lblYetkiliKisi.Size = new Size(78, 21);
            lblYetkiliKisi.TabIndex = 1;
            lblYetkiliKisi.Text = "Vergi No:";
            // 
            // lblFirmaAdi
            // 
            lblFirmaAdi.AutoSize = true;
            lblFirmaAdi.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblFirmaAdi.ForeColor = SystemColors.ControlLightLight;
            lblFirmaAdi.Location = new Point(35, 46);
            lblFirmaAdi.Name = "lblFirmaAdi";
            lblFirmaAdi.Size = new Size(83, 21);
            lblFirmaAdi.TabIndex = 0;
            lblFirmaAdi.Text = "Firma Adı:";
            // 
            // tabPage4
            // 
            tabPage4.BackColor = Color.DarkOliveGreen;
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
            tabPage4.Location = new Point(4, 48);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(355, 421);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Müsteri Tanımlama";
            // 
            // musteriGuncel
            // 
            musteriGuncel.FlatAppearance.BorderSize = 0;
            musteriGuncel.Location = new Point(145, 274);
            musteriGuncel.Name = "musteriGuncel";
            musteriGuncel.Size = new Size(82, 25);
            musteriGuncel.TabIndex = 10;
            musteriGuncel.Text = "Güncelle";
            musteriGuncel.UseVisualStyleBackColor = true;
            musteriGuncel.Click += musteriGuncel_Click;
            // 
            // musteriSil
            // 
            musteriSil.FlatAppearance.BorderSize = 0;
            musteriSil.Location = new Point(58, 303);
            musteriSil.Name = "musteriSil";
            musteriSil.Size = new Size(82, 25);
            musteriSil.TabIndex = 9;
            musteriSil.Text = "Sil";
            musteriSil.UseVisualStyleBackColor = true;
            musteriSil.Click += musteriSil_Click;
            // 
            // musteriKayit
            // 
            musteriKayit.FlatAppearance.BorderSize = 0;
            musteriKayit.Location = new Point(58, 274);
            musteriKayit.Name = "musteriKayit";
            musteriKayit.Size = new Size(82, 25);
            musteriKayit.TabIndex = 8;
            musteriKayit.Text = "Kaydet";
            musteriKayit.UseVisualStyleBackColor = true;
            musteriKayit.Click += musteriKayit_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label6.ForeColor = SystemColors.ControlLightLight;
            label6.Location = new Point(26, 185);
            label6.Name = "label6";
            label6.Size = new Size(72, 21);
            label6.TabIndex = 7;
            label6.Text = "Telefon: ";
            // 
            // textMusteriTel
            // 
            textMusteriTel.Location = new Point(142, 184);
            textMusteriTel.Multiline = true;
            textMusteriTel.Name = "textMusteriTel";
            textMusteriTel.Size = new Size(176, 30);
            textMusteriTel.TabIndex = 6;
            // 
            // textMusteriVd
            // 
            textMusteriVd.Location = new Point(142, 132);
            textMusteriVd.Name = "textMusteriVd";
            textMusteriVd.Size = new Size(176, 25);
            textMusteriVd.TabIndex = 5;
            // 
            // textMusteriVNo
            // 
            textMusteriVNo.Location = new Point(142, 87);
            textMusteriVNo.Name = "textMusteriVNo";
            textMusteriVNo.Size = new Size(176, 25);
            textMusteriVNo.TabIndex = 4;
            // 
            // textMusteriAd
            // 
            textMusteriAd.Location = new Point(142, 46);
            textMusteriAd.Name = "textMusteriAd";
            textMusteriAd.Size = new Size(176, 25);
            textMusteriAd.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label7.ForeColor = SystemColors.ControlLightLight;
            label7.Location = new Point(26, 136);
            label7.Name = "label7";
            label7.Size = new Size(105, 21);
            label7.TabIndex = 2;
            label7.Text = "Vergi Dairesi:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label8.ForeColor = SystemColors.ControlLightLight;
            label8.Location = new Point(26, 91);
            label8.Name = "label8";
            label8.Size = new Size(78, 21);
            label8.TabIndex = 1;
            label8.Text = "Vergi No:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label9.ForeColor = SystemColors.ControlLightLight;
            label9.Location = new Point(26, 50);
            label9.Name = "label9";
            label9.Size = new Size(99, 21);
            label9.TabIndex = 0;
            label9.Text = "Müsteri Adı:";
            // 
            // panel2
            // 
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.Controls.Add(dataGridView1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(390, 0);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(553, 516);
            panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(553, 516);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 390F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(panel2, 1, 0);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(943, 516);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // frmUrunYonetimi
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(943, 516);
            Controls.Add(tableLayoutPanel1);
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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private ComboBox comboBox2;
        private ComboBox comboBoxKategori;
        private TextBox txtUrunKod;
        private TextBox txtKritik;
        private TextBox txtUrunAd;
        private Button btnSil;
        private Button btnGuncelle;
        private Button btnKaydet;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnKategoriGuncelle;
        private Button btnKategoriKaydet;
        private TextBox txtKategoriAciklama;
        private Label lblAciklama;
        private TextBox txtKategoriAdi;
        private Label lblKategoriAdi;
        private Button btnKategoriSil;
        private Label lblAdres;
        private TextBox txtTelefon;
        private TextBox txtVergiDairesi;
        private TextBox txtVergiNo;
        private TextBox txtFirmaAdi;
        private Label lblTelefon;
        private Label lblYetkiliKisi;
        private Label lblFirmaAdi;
        private DataGridView dataGridView1;
        private Button btnTedarikciGuncelle;
        private Button btnTedarikciSil;
        private Button btnTedarikciKaydet;
        private TableLayoutPanel tableLayoutPanel1;
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
        private Label label10;
        private NumericUpDown birimFiyat;
    }
}