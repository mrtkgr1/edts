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
            textBox4 = new TextBox();
            txtTelefon = new TextBox();
            txtYetkiliKisi = new TextBox();
            txtFirmaAdi = new TextBox();
            lblTelefon = new Label();
            lblYetkiliKisi = new Label();
            lblFirmaAdi = new Label();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkOliveGreen;
            panel1.Controls.Add(tabControl1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(431, 516);
            panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(10, 26);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(363, 473);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.DarkOliveGreen;
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
            tabPage1.Location = new Point(4, 26);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(355, 443);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Ürün Tanımlama";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(183, 187);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(133, 25);
            comboBox2.TabIndex = 26;
            // 
            // comboBoxKategori
            // 
            comboBoxKategori.FormattingEnabled = true;
            comboBoxKategori.Location = new Point(183, 156);
            comboBoxKategori.Name = "comboBoxKategori";
            comboBoxKategori.Size = new Size(133, 25);
            comboBoxKategori.TabIndex = 25;
            // 
            // txtUrunKod
            // 
            txtUrunKod.Location = new Point(183, 122);
            txtUrunKod.Name = "txtUrunKod";
            txtUrunKod.Size = new Size(133, 25);
            txtUrunKod.TabIndex = 24;
            // 
            // txtKritik
            // 
            txtKritik.Location = new Point(183, 220);
            txtKritik.Name = "txtKritik";
            txtKritik.Size = new Size(133, 25);
            txtKritik.TabIndex = 23;
            // 
            // txtUrunAd
            // 
            txtUrunAd.Location = new Point(183, 89);
            txtUrunAd.Name = "txtUrunAd";
            txtUrunAd.Size = new Size(133, 25);
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
            label5.Location = new Point(40, 221);
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
            label4.Location = new Point(40, 191);
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
            label3.Location = new Point(40, 160);
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
            label2.Location = new Point(40, 126);
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
            label1.Location = new Point(40, 93);
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
            tabPage2.Location = new Point(4, 26);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(355, 443);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Kategori Tanımlama";
            // 
            // btnKategoriSil
            // 
            btnKategoriSil.BackColor = Color.Crimson;
            btnKategoriSil.FlatAppearance.BorderSize = 0;
            btnKategoriSil.FlatStyle = FlatStyle.Flat;
            btnKategoriSil.ForeColor = SystemColors.ControlLightLight;
            btnKategoriSil.Location = new Point(130, 213);
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
            btnKategoriGuncelle.Location = new Point(220, 184);
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
            btnKategoriKaydet.Location = new Point(130, 184);
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
            txtKategoriAciklama.Name = "txtKategoriAciklama";
            txtKategoriAciklama.Size = new Size(165, 25);
            txtKategoriAciklama.TabIndex = 3;
            // 
            // lblAciklama
            // 
            lblAciklama.AutoSize = true;
            lblAciklama.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblAciklama.ForeColor = SystemColors.ControlLightLight;
            lblAciklama.Location = new Point(36, 111);
            lblAciklama.Name = "lblAciklama";
            lblAciklama.Size = new Size(83, 21);
            lblAciklama.TabIndex = 2;
            lblAciklama.Text = "Açıklama :";
            // 
            // txtKategoriAdi
            // 
            txtKategoriAdi.Location = new Point(130, 71);
            txtKategoriAdi.Name = "txtKategoriAdi";
            txtKategoriAdi.Size = new Size(165, 25);
            txtKategoriAdi.TabIndex = 1;
            // 
            // lblKategoriAdi
            // 
            lblKategoriAdi.AutoSize = true;
            lblKategoriAdi.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblKategoriAdi.ForeColor = SystemColors.ControlLightLight;
            lblKategoriAdi.Location = new Point(36, 71);
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
            tabPage3.Controls.Add(textBox4);
            tabPage3.Controls.Add(txtTelefon);
            tabPage3.Controls.Add(txtYetkiliKisi);
            tabPage3.Controls.Add(txtFirmaAdi);
            tabPage3.Controls.Add(lblTelefon);
            tabPage3.Controls.Add(lblYetkiliKisi);
            tabPage3.Controls.Add(lblFirmaAdi);
            tabPage3.Location = new Point(4, 26);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(355, 443);
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
            // 
            // lblAdres
            // 
            lblAdres.AutoSize = true;
            lblAdres.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblAdres.ForeColor = SystemColors.ControlLightLight;
            lblAdres.Location = new Point(35, 184);
            lblAdres.Name = "lblAdres";
            lblAdres.Size = new Size(61, 21);
            lblAdres.TabIndex = 7;
            lblAdres.Text = "Adres :";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(124, 178);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(110, 30);
            textBox4.TabIndex = 6;
            // 
            // txtTelefon
            // 
            txtTelefon.Location = new Point(124, 132);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(110, 25);
            txtTelefon.TabIndex = 5;
            // 
            // txtYetkiliKisi
            // 
            txtYetkiliKisi.Location = new Point(124, 85);
            txtYetkiliKisi.Name = "txtYetkiliKisi";
            txtYetkiliKisi.Size = new Size(110, 25);
            txtYetkiliKisi.TabIndex = 4;
            // 
            // txtFirmaAdi
            // 
            txtFirmaAdi.Location = new Point(124, 42);
            txtFirmaAdi.Name = "txtFirmaAdi";
            txtFirmaAdi.Size = new Size(110, 25);
            txtFirmaAdi.TabIndex = 3;
            // 
            // lblTelefon
            // 
            lblTelefon.AutoSize = true;
            lblTelefon.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblTelefon.ForeColor = SystemColors.ControlLightLight;
            lblTelefon.Location = new Point(35, 138);
            lblTelefon.Name = "lblTelefon";
            lblTelefon.Size = new Size(68, 21);
            lblTelefon.TabIndex = 2;
            lblTelefon.Text = "Telefon:";
            // 
            // lblYetkiliKisi
            // 
            lblYetkiliKisi.AutoSize = true;
            lblYetkiliKisi.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblYetkiliKisi.ForeColor = SystemColors.ControlLightLight;
            lblYetkiliKisi.Location = new Point(35, 91);
            lblYetkiliKisi.Name = "lblYetkiliKisi";
            lblYetkiliKisi.Size = new Size(82, 21);
            lblYetkiliKisi.TabIndex = 1;
            lblYetkiliKisi.Text = "Yetkili Kişi";
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
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(431, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(512, 516);
            panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(512, 516);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // frmUrunYonetimi
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(943, 516);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmUrunYonetimi";
            Text = "frmUrunYonetimi";
            panel1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
        private TextBox textBox4;
        private TextBox txtTelefon;
        private TextBox txtYetkiliKisi;
        private TextBox txtFirmaAdi;
        private Label lblTelefon;
        private Label lblYetkiliKisi;
        private Label lblFirmaAdi;
        private DataGridView dataGridView1;
        private Button btnTedarikciGuncelle;
        private Button btnTedarikciSil;
        private Button btnTedarikciKaydet;
    }
}