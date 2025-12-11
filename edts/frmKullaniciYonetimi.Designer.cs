namespace edts
{
    partial class frmKullaniciYonetimi
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
            btnHesapSil = new Button();
            btnHesapGuncelle = new Button();
            btnKullaniciKaydet = new Button();
            cmbRolSecim = new ComboBox();
            txtSifre = new TextBox();
            txtKullaniciAdi = new TextBox();
            txtAdSoyad = new TextBox();
            lblRol = new Label();
            lblSifre = new Label();
            lblKullaniciAdi = new Label();
            lblAdSoyad = new Label();
            panel2 = new Panel();
            dgvKullaniciListesi = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKullaniciListesi).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkOliveGreen;
            panel1.Controls.Add(btnHesapSil);
            panel1.Controls.Add(btnHesapGuncelle);
            panel1.Controls.Add(btnKullaniciKaydet);
            panel1.Controls.Add(cmbRolSecim);
            panel1.Controls.Add(txtSifre);
            panel1.Controls.Add(txtKullaniciAdi);
            panel1.Controls.Add(txtAdSoyad);
            panel1.Controls.Add(lblRol);
            panel1.Controls.Add(lblSifre);
            panel1.Controls.Add(lblKullaniciAdi);
            panel1.Controls.Add(lblAdSoyad);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(404, 655);
            panel1.TabIndex = 0;
            // 
            // btnHesapSil
            // 
            btnHesapSil.BackColor = Color.Crimson;
            btnHesapSil.FlatAppearance.BorderSize = 0;
            btnHesapSil.FlatStyle = FlatStyle.Flat;
            btnHesapSil.Location = new Point(187, 313);
            btnHesapSil.Name = "btnHesapSil";
            btnHesapSil.Size = new Size(127, 29);
            btnHesapSil.TabIndex = 10;
            btnHesapSil.Text = "Hesap Sil";
            btnHesapSil.UseVisualStyleBackColor = false;
            // 
            // btnHesapGuncelle
            // 
            btnHesapGuncelle.BackColor = Color.DarkOrange;
            btnHesapGuncelle.FlatAppearance.BorderSize = 0;
            btnHesapGuncelle.FlatStyle = FlatStyle.Flat;
            btnHesapGuncelle.Location = new Point(54, 348);
            btnHesapGuncelle.Name = "btnHesapGuncelle";
            btnHesapGuncelle.Size = new Size(127, 29);
            btnHesapGuncelle.TabIndex = 9;
            btnHesapGuncelle.Text = "Hesap Güncelle";
            btnHesapGuncelle.UseVisualStyleBackColor = false;
            // 
            // btnKullaniciKaydet
            // 
            btnKullaniciKaydet.BackColor = Color.LightSeaGreen;
            btnKullaniciKaydet.FlatAppearance.BorderSize = 0;
            btnKullaniciKaydet.FlatStyle = FlatStyle.Flat;
            btnKullaniciKaydet.Location = new Point(54, 313);
            btnKullaniciKaydet.Name = "btnKullaniciKaydet";
            btnKullaniciKaydet.Size = new Size(127, 29);
            btnKullaniciKaydet.TabIndex = 8;
            btnKullaniciKaydet.Text = "Kullanıcı Kaydet";
            btnKullaniciKaydet.UseVisualStyleBackColor = false;
            // 
            // cmbRolSecim
            // 
            cmbRolSecim.FormattingEnabled = true;
            cmbRolSecim.Items.AddRange(new object[] { "Yönetici", "Depo Personeli", "" });
            cmbRolSecim.Location = new Point(168, 243);
            cmbRolSecim.Name = "cmbRolSecim";
            cmbRolSecim.Size = new Size(151, 28);
            cmbRolSecim.TabIndex = 7;
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(168, 196);
            txtSifre.Name = "txtSifre";
            txtSifre.PasswordChar = '*';
            txtSifre.Size = new Size(151, 27);
            txtSifre.TabIndex = 6;
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.Location = new Point(168, 144);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(151, 27);
            txtKullaniciAdi.TabIndex = 5;
            txtKullaniciAdi.TextChanged += txtKullaniciAdi_TextChanged;
            // 
            // txtAdSoyad
            // 
            txtAdSoyad.Location = new Point(168, 103);
            txtAdSoyad.Name = "txtAdSoyad";
            txtAdSoyad.Size = new Size(151, 27);
            txtAdSoyad.TabIndex = 4;
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblRol.ForeColor = SystemColors.ControlLightLight;
            lblRol.Location = new Point(12, 244);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(157, 23);
            lblRol.TabIndex = 3;
            lblRol.Text = "Rol / Yetki Seviyesi:";
            // 
            // lblSifre
            // 
            lblSifre.AutoSize = true;
            lblSifre.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblSifre.ForeColor = SystemColors.ControlLightLight;
            lblSifre.Location = new Point(12, 197);
            lblSifre.Name = "lblSifre";
            lblSifre.Size = new Size(48, 23);
            lblSifre.TabIndex = 2;
            lblSifre.Text = "Şifre:";
            // 
            // lblKullaniciAdi
            // 
            lblKullaniciAdi.AutoSize = true;
            lblKullaniciAdi.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblKullaniciAdi.ForeColor = SystemColors.ControlLightLight;
            lblKullaniciAdi.Location = new Point(12, 148);
            lblKullaniciAdi.Name = "lblKullaniciAdi";
            lblKullaniciAdi.Size = new Size(107, 23);
            lblKullaniciAdi.TabIndex = 1;
            lblKullaniciAdi.Text = "Kullanıcı Adı:";
            // 
            // lblAdSoyad
            // 
            lblAdSoyad.AutoSize = true;
            lblAdSoyad.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblAdSoyad.ForeColor = SystemColors.ControlLightLight;
            lblAdSoyad.Location = new Point(12, 104);
            lblAdSoyad.Name = "lblAdSoyad";
            lblAdSoyad.Size = new Size(87, 23);
            lblAdSoyad.TabIndex = 0;
            lblAdSoyad.Text = "Ad Soyad:";
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvKullaniciListesi);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(404, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(577, 655);
            panel2.TabIndex = 1;
            // 
            // dgvKullaniciListesi
            // 
            dgvKullaniciListesi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKullaniciListesi.Dock = DockStyle.Fill;
            dgvKullaniciListesi.Location = new Point(0, 0);
            dgvKullaniciListesi.Name = "dgvKullaniciListesi";
            dgvKullaniciListesi.RowHeadersWidth = 51;
            dgvKullaniciListesi.Size = new Size(577, 655);
            dgvKullaniciListesi.TabIndex = 0;
            // 
            // frmKullaniciYonetimi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(981, 655);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmKullaniciYonetimi";
            Text = "frmKullaniciYonetimi";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKullaniciListesi).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtSifre;
        private TextBox txtKullaniciAdi;
        private TextBox txtAdSoyad;
        private Label lblRol;
        private Label lblSifre;
        private Label lblKullaniciAdi;
        private Label lblAdSoyad;
        private Panel panel2;
        private Button btnHesapSil;
        private Button btnHesapGuncelle;
        private Button btnKullaniciKaydet;
        private ComboBox cmbRolSecim;
        private DataGridView dgvKullaniciListesi;
    }
}