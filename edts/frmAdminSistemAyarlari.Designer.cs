namespace edts
{
    partial class frmAdminSistemAyarlari
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
            groupBox1 = new GroupBox();
            txtVarsayilanDepoKonum = new TextBox();
            label6 = new Label();
            cmbVarsayilanBirimTip = new ComboBox();
            label5 = new Label();
            label1 = new Label();
            numKritikStok = new NumericUpDown();
            groupBox2 = new GroupBox();
            numSifreDegistirmeSuresi = new NumericUpDown();
            label4 = new Label();
            numOturumZamanAsimi = new NumericUpDown();
            label3 = new Label();
            numMaksimumGirisDenemesi = new NumericUpDown();
            label2 = new Label();
            btnAyarlariKaydet = new Button();
            groupBox3 = new GroupBox();
            btnHareketTipiSil = new Button();
            cmbHareketYonu = new ComboBox();
            btnHareketTipiEkle = new Button();
            dgvHareketTipleri = new DataGridView();
            btnDuzenle = new DataGridViewButtonColumn();
            txtHareketTipiAd = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numKritikStok).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSifreDegistirmeSuresi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numOturumZamanAsimi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaksimumGirisDenemesi).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHareketTipleri).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.LightSlateGray;
            groupBox1.Controls.Add(txtVarsayilanDepoKonum);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(cmbVarsayilanBirimTip);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(numKritikStok);
            groupBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            groupBox1.ForeColor = SystemColors.ControlLightLight;
            groupBox1.Location = new Point(72, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(921, 195);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Genel Stok Yönetimi Ayarları";
            // 
            // txtVarsayilanDepoKonum
            // 
            txtVarsayilanDepoKonum.Location = new Point(261, 119);
            txtVarsayilanDepoKonum.Name = "txtVarsayilanDepoKonum";
            txtVarsayilanDepoKonum.Size = new Size(151, 30);
            txtVarsayilanDepoKonum.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.ControlLightLight;
            label6.Location = new Point(31, 122);
            label6.Name = "label6";
            label6.Size = new Size(210, 23);
            label6.TabIndex = 4;
            label6.Text = "Varsayılan Depo Konumu";
            // 
            // cmbVarsayilanBirimTip
            // 
            cmbVarsayilanBirimTip.FormattingEnabled = true;
            cmbVarsayilanBirimTip.Location = new Point(261, 74);
            cmbVarsayilanBirimTip.Name = "cmbVarsayilanBirimTip";
            cmbVarsayilanBirimTip.Size = new Size(151, 31);
            cmbVarsayilanBirimTip.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(30, 81);
            label5.Name = "label5";
            label5.Size = new Size(175, 23);
            label5.TabIndex = 2;
            label5.Text = "Varsayılan Birim Tipi";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(30, 45);
            label1.Name = "label1";
            label1.Size = new Size(139, 23);
            label1.TabIndex = 1;
            label1.Text = "Kritik Stok Eşiği";
            // 
            // numKritikStok
            // 
            numKritikStok.Location = new Point(261, 38);
            numKritikStok.Name = "numKritikStok";
            numKritikStok.Size = new Size(151, 30);
            numKritikStok.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.LightSlateGray;
            groupBox2.Controls.Add(numSifreDegistirmeSuresi);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(numOturumZamanAsimi);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(numMaksimumGirisDenemesi);
            groupBox2.Controls.Add(label2);
            groupBox2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            groupBox2.ForeColor = SystemColors.ControlLightLight;
            groupBox2.Location = new Point(72, 213);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(921, 227);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Kullanıcı Güvenlik Ayarları";
            // 
            // numSifreDegistirmeSuresi
            // 
            numSifreDegistirmeSuresi.Location = new Point(259, 71);
            numSifreDegistirmeSuresi.Name = "numSifreDegistirmeSuresi";
            numSifreDegistirmeSuresi.Size = new Size(150, 30);
            numSifreDegistirmeSuresi.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(30, 78);
            label4.Name = "label4";
            label4.Size = new Size(195, 23);
            label4.TabIndex = 4;
            label4.Text = "Şifre Değiştirme Süresi";
            // 
            // numOturumZamanAsimi
            // 
            numOturumZamanAsimi.Location = new Point(259, 153);
            numOturumZamanAsimi.Name = "numOturumZamanAsimi";
            numOturumZamanAsimi.Size = new Size(150, 30);
            numOturumZamanAsimi.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(30, 160);
            label3.Name = "label3";
            label3.Size = new Size(182, 23);
            label3.TabIndex = 2;
            label3.Text = "Oturum Zaman Aşımı";
            // 
            // numMaksimumGirisDenemesi
            // 
            numMaksimumGirisDenemesi.Location = new Point(259, 115);
            numMaksimumGirisDenemesi.Name = "numMaksimumGirisDenemesi";
            numMaksimumGirisDenemesi.Size = new Size(150, 30);
            numMaksimumGirisDenemesi.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(30, 117);
            label2.Name = "label2";
            label2.Size = new Size(223, 23);
            label2.TabIndex = 0;
            label2.Text = "Maksimum Giriş Denemesi";
            // 
            // btnAyarlariKaydet
            // 
            btnAyarlariKaydet.BackColor = Color.DarkCyan;
            btnAyarlariKaydet.FlatAppearance.BorderSize = 0;
            btnAyarlariKaydet.FlatStyle = FlatStyle.Flat;
            btnAyarlariKaydet.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnAyarlariKaydet.ForeColor = SystemColors.ControlLightLight;
            btnAyarlariKaydet.Location = new Point(423, 747);
            btnAyarlariKaydet.Name = "btnAyarlariKaydet";
            btnAyarlariKaydet.Size = new Size(232, 41);
            btnAyarlariKaydet.TabIndex = 2;
            btnAyarlariKaydet.Text = "Kaydet";
            btnAyarlariKaydet.UseVisualStyleBackColor = false;
            btnAyarlariKaydet.Click += btnAyarlariKaydet_Click;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.LightSlateGray;
            groupBox3.Controls.Add(btnHareketTipiSil);
            groupBox3.Controls.Add(cmbHareketYonu);
            groupBox3.Controls.Add(btnHareketTipiEkle);
            groupBox3.Controls.Add(dgvHareketTipleri);
            groupBox3.Controls.Add(txtHareketTipiAd);
            groupBox3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            groupBox3.ForeColor = SystemColors.ControlLightLight;
            groupBox3.Location = new Point(72, 446);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(921, 295);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Stok Hareket Tipleri Tanımlama";
            // 
            // btnHareketTipiSil
            // 
            btnHareketTipiSil.BackColor = Color.IndianRed;
            btnHareketTipiSil.FlatAppearance.BorderSize = 0;
            btnHareketTipiSil.FlatStyle = FlatStyle.Flat;
            btnHareketTipiSil.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnHareketTipiSil.ForeColor = SystemColors.ControlLightLight;
            btnHareketTipiSil.Location = new Point(418, 65);
            btnHareketTipiSil.Name = "btnHareketTipiSil";
            btnHareketTipiSil.Size = new Size(132, 36);
            btnHareketTipiSil.TabIndex = 5;
            btnHareketTipiSil.Text = "Sil";
            btnHareketTipiSil.UseVisualStyleBackColor = false;
            btnHareketTipiSil.Click += btnHareketTipiSil_Click;
            // 
            // cmbHareketYonu
            // 
            cmbHareketYonu.FormattingEnabled = true;
            cmbHareketYonu.Items.AddRange(new object[] { "Giriş, Çıkış" });
            cmbHareketYonu.Location = new Point(261, 64);
            cmbHareketYonu.Name = "cmbHareketYonu";
            cmbHareketYonu.Size = new Size(151, 31);
            cmbHareketYonu.TabIndex = 8;
            // 
            // btnHareketTipiEkle
            // 
            btnHareketTipiEkle.BackColor = Color.LightSteelBlue;
            btnHareketTipiEkle.FlatAppearance.BorderSize = 0;
            btnHareketTipiEkle.FlatStyle = FlatStyle.Flat;
            btnHareketTipiEkle.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnHareketTipiEkle.ForeColor = SystemColors.ControlLightLight;
            btnHareketTipiEkle.Location = new Point(418, 23);
            btnHareketTipiEkle.Name = "btnHareketTipiEkle";
            btnHareketTipiEkle.Size = new Size(132, 36);
            btnHareketTipiEkle.TabIndex = 4;
            btnHareketTipiEkle.Text = "Ekle";
            btnHareketTipiEkle.UseVisualStyleBackColor = false;
            btnHareketTipiEkle.Click += btnHareketTipiEkle_Click;
            // 
            // dgvHareketTipleri
            // 
            dgvHareketTipleri.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHareketTipleri.Columns.AddRange(new DataGridViewColumn[] { btnDuzenle });
            dgvHareketTipleri.Location = new Point(6, 107);
            dgvHareketTipleri.Name = "dgvHareketTipleri";
            dgvHareketTipleri.RowHeadersWidth = 51;
            dgvHareketTipleri.Size = new Size(909, 188);
            dgvHareketTipleri.TabIndex = 7;
            dgvHareketTipleri.CellContentClick += dgvHareketTipleri_CellContentClick;
            // 
            // btnDuzenle
            // 
            btnDuzenle.FlatStyle = FlatStyle.Flat;
            btnDuzenle.HeaderText = "İşlem";
            btnDuzenle.MinimumWidth = 6;
            btnDuzenle.Name = "btnDuzenle";
            btnDuzenle.Text = "Düzenle";
            btnDuzenle.UseColumnTextForButtonValue = true;
            btnDuzenle.Width = 125;
            // 
            // txtHareketTipiAd
            // 
            txtHareketTipiAd.Location = new Point(261, 29);
            txtHareketTipiAd.Name = "txtHareketTipiAd";
            txtHareketTipiAd.Size = new Size(151, 30);
            txtHareketTipiAd.TabIndex = 6;
            // 
            // frmAdminSistemAyarlari
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSlateGray;
            ClientSize = new Size(1170, 812);
            Controls.Add(groupBox3);
            Controls.Add(btnAyarlariKaydet);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmAdminSistemAyarlari";
            Text = "frmAdminSistemAyarlari";
            Load += frmAdminSistemAyarlari_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numKritikStok).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSifreDegistirmeSuresi).EndInit();
            ((System.ComponentModel.ISupportInitialize)numOturumZamanAsimi).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaksimumGirisDenemesi).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHareketTipleri).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnAyarlariKaydet;
        private GroupBox groupBox3;
        private ComboBox cmbHareketYonu;
        private DataGridView dgvHareketTipleri;
        private TextBox txtHareketTipiAd;
        private Button btnHareketTipiEkle;
        private Button btnHareketTipiSil;
        private Label label1;
        private NumericUpDown numKritikStok;
        private Label label6;
        private ComboBox cmbVarsayilanBirimTip;
        private Label label5;
        private NumericUpDown numSifreDegistirmeSuresi;
        private Label label4;
        private NumericUpDown numOturumZamanAsimi;
        private Label label3;
        private NumericUpDown numMaksimumGirisDenemesi;
        private Label label2;
        private TextBox txtVarsayilanDepoKonum;
        private DataGridViewButtonColumn btnDuzenle;
    }
}