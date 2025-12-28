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
            label11 = new Label();
            txtAlisFiyati = new TextBox();
            btnGuncelle = new KavisliButon();
            btnKaydett = new KavisliButon();
            birimFiyat = new NumericUpDown();
            label10 = new Label();
            cmbBirimTipi = new ComboBox();
            comboBoxKategori = new ComboBox();
            txtUrunKod = new TextBox();
            txtKritik = new TextBox();
            txtUrunAd = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            dataGridView2 = new DataGridView();
            btnSilSutun = new DataGridViewButtonColumn();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)birimFiyat).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(tabControl1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(594, 792);
            panel1.TabIndex = 2;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            tabControl1.Location = new Point(12, 155);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(576, 624);
            tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.LightSlateGray;
            tabPage1.Controls.Add(label11);
            tabPage1.Controls.Add(txtAlisFiyati);
            tabPage1.Controls.Add(btnGuncelle);
            tabPage1.Controls.Add(btnKaydett);
            tabPage1.Controls.Add(birimFiyat);
            tabPage1.Controls.Add(label10);
            tabPage1.Controls.Add(cmbBirimTipi);
            tabPage1.Controls.Add(comboBoxKategori);
            tabPage1.Controls.Add(txtUrunKod);
            tabPage1.Controls.Add(txtKritik);
            tabPage1.Controls.Add(txtUrunAd);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 37);
            tabPage1.Margin = new Padding(3, 4, 3, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 4, 3, 4);
            tabPage1.Size = new Size(568, 583);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Ürün Tanımlama";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label11.ForeColor = SystemColors.ControlLightLight;
            label11.Location = new Point(55, 394);
            label11.Name = "label11";
            label11.Size = new Size(93, 23);
            label11.TabIndex = 33;
            label11.Text = "Alış Fiyatı:";
            // 
            // txtAlisFiyati
            // 
            txtAlisFiyati.Location = new Point(256, 390);
            txtAlisFiyati.Name = "txtAlisFiyati";
            txtAlisFiyati.Size = new Size(189, 34);
            txtAlisFiyati.TabIndex = 32;
            // 
            // btnGuncelle
            // 
            btnGuncelle.BorderRadius = 30;
            btnGuncelle.FlatAppearance.BorderSize = 0;
            btnGuncelle.FlatStyle = FlatStyle.System;
            btnGuncelle.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnGuncelle.Location = new Point(355, 472);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(104, 38);
            btnGuncelle.TabIndex = 31;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = true;
            btnGuncelle.Click += btnGuncelle_Click_1;
            // 
            // btnKaydett
            // 
            btnKaydett.BorderRadius = 30;
            btnKaydett.FlatAppearance.BorderSize = 0;
            btnKaydett.FlatStyle = FlatStyle.System;
            btnKaydett.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnKaydett.Location = new Point(245, 472);
            btnKaydett.Name = "btnKaydett";
            btnKaydett.Size = new Size(104, 38);
            btnKaydett.TabIndex = 30;
            btnKaydett.Text = "Kaydet";
            btnKaydett.UseVisualStyleBackColor = true;
            btnKaydett.Click += btnKaydet_Click_1;
            // 
            // birimFiyat
            // 
            birimFiyat.Location = new Point(256, 339);
            birimFiyat.Margin = new Padding(3, 4, 3, 4);
            birimFiyat.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            birimFiyat.Name = "birimFiyat";
            birimFiyat.Size = new Size(189, 34);
            birimFiyat.TabIndex = 28;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label10.ForeColor = SystemColors.ControlLightLight;
            label10.Location = new Point(55, 343);
            label10.Name = "label10";
            label10.Size = new Size(106, 23);
            label10.TabIndex = 27;
            label10.Text = "Birim fiyat: ";
            // 
            // cmbBirimTipi
            // 
            cmbBirimTipi.FormattingEnabled = true;
            cmbBirimTipi.Location = new Point(256, 243);
            cmbBirimTipi.Margin = new Padding(3, 4, 3, 4);
            cmbBirimTipi.Name = "cmbBirimTipi";
            cmbBirimTipi.Size = new Size(189, 36);
            cmbBirimTipi.TabIndex = 26;
            // 
            // comboBoxKategori
            // 
            comboBoxKategori.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxKategori.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxKategori.FormattingEnabled = true;
            comboBoxKategori.Location = new Point(256, 198);
            comboBoxKategori.Margin = new Padding(3, 4, 3, 4);
            comboBoxKategori.Name = "comboBoxKategori";
            comboBoxKategori.Size = new Size(188, 36);
            comboBoxKategori.TabIndex = 25;
            // 
            // txtUrunKod
            // 
            txtUrunKod.Location = new Point(256, 151);
            txtUrunKod.Margin = new Padding(3, 4, 3, 4);
            txtUrunKod.Name = "txtUrunKod";
            txtUrunKod.Size = new Size(188, 34);
            txtUrunKod.TabIndex = 24;
            // 
            // txtKritik
            // 
            txtKritik.Location = new Point(256, 290);
            txtKritik.Margin = new Padding(3, 4, 3, 4);
            txtKritik.Name = "txtKritik";
            txtKritik.Size = new Size(189, 34);
            txtKritik.TabIndex = 23;
            // 
            // txtUrunAd
            // 
            txtUrunAd.Location = new Point(256, 107);
            txtUrunAd.Margin = new Padding(3, 4, 3, 4);
            txtUrunAd.Name = "txtUrunAd";
            txtUrunAd.Size = new Size(189, 34);
            txtUrunAd.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(55, 298);
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
            label4.Location = new Point(56, 252);
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
            label3.Location = new Point(55, 204);
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
            label2.Location = new Point(55, 157);
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
            label1.Location = new Point(56, 111);
            label1.Name = "label1";
            label1.Size = new Size(87, 23);
            label1.TabIndex = 14;
            label1.Text = "Ürün Adı:";
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(594, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(615, 792);
            panel2.TabIndex = 3;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { btnSilSutun });
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.Location = new Point(0, 0);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(615, 792);
            dataGridView2.TabIndex = 0;
            dataGridView2.CellClick += dataGridView2_CellClick;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            dataGridView2.CellPainting += dataGridView2_CellPainting;
            dataGridView2.MouseLeave += dataGridView2_MouseLeave;
            dataGridView2.MouseMove += dataGridView2_MouseMove;
            // 
            // btnSilSutun
            // 
            btnSilSutun.FlatStyle = FlatStyle.Flat;
            btnSilSutun.HeaderText = "Column1";
            btnSilSutun.MinimumWidth = 6;
            btnSilSutun.Name = "btnSilSutun";
            btnSilSutun.Text = "Sil";
            btnSilSutun.UseColumnTextForButtonValue = true;
            btnSilSutun.Width = 125;
            // 
            // frmUrunYonetimi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1209, 792);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmUrunYonetimi";
            Text = "frmUrunYonetimi";
            Load += frmUrunYonetimi_Load;
            panel1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)birimFiyat).EndInit();
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
        private ComboBox cmbBirimTipi;
        private ComboBox comboBoxKategori;
        private TextBox txtUrunKod;
        private TextBox txtKritik;
        private TextBox txtUrunAd;
     
       
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Panel panel2;
        private KavisliButon btnKaydett;
        private DataGridView dataGridView2;
        private KavisliButon btnGuncelle;
        private TextBox txtAlisFiyati;
        private Label label11;
        private DataGridViewButtonColumn btnSilSutun;
    }
}