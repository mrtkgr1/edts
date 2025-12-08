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
            panel2 = new Panel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            btnSil = new Button();
            btnGuncelle = new Button();
            btnKaydet = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lblKategoriAdi = new Label();
            txtKategoriAdi = new TextBox();
            lblAciklama = new Label();
            txtKategoriAciklama = new TextBox();
            btnKategoriKaydet = new Button();
            btnKategoriGuncelle = new Button();
            btnKategoriSil = new Button();
            dataGridView1 = new DataGridView();
            lblFirmaAdi = new Label();
            lblYetkiliKisi = new Label();
            lblTelefon = new Label();
            txtFirmaAdi = new TextBox();
            txtYetkiliKisi = new TextBox();
            txtTelefon = new TextBox();
            textBox4 = new TextBox();
            lblAdres = new Label();
            btnTedarikciKaydet = new Button();
            btnTedarikciSil = new Button();
            btnTedarikciGuncelle = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
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
            panel1.Size = new Size(493, 607);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(493, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(585, 607);
            panel2.TabIndex = 1;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(12, 30);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(415, 556);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.DarkOliveGreen;
            tabPage1.Controls.Add(comboBox2);
            tabPage1.Controls.Add(comboBox1);
            tabPage1.Controls.Add(textBox3);
            tabPage1.Controls.Add(textBox2);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(btnSil);
            tabPage1.Controls.Add(btnGuncelle);
            tabPage1.Controls.Add(btnKaydet);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(407, 523);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Ürün Tanımlama";
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
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(407, 523);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Kategori Tanımlama";
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
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(407, 523);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Tedarikçi Tanımlama";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(209, 220);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 26;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(209, 183);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 25;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(209, 144);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(151, 27);
            textBox3.TabIndex = 24;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(209, 259);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(151, 27);
            textBox2.TabIndex = 23;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(209, 105);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(151, 27);
            textBox1.TabIndex = 22;
            // 
            // btnSil
            // 
            btnSil.BackColor = Color.Crimson;
            btnSil.FlatAppearance.BorderSize = 0;
            btnSil.FlatStyle = FlatStyle.Flat;
            btnSil.ForeColor = SystemColors.ControlLightLight;
            btnSil.Location = new Point(193, 354);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(94, 29);
            btnSil.TabIndex = 21;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = false;
            // 
            // btnGuncelle
            // 
            btnGuncelle.BackColor = Color.DarkCyan;
            btnGuncelle.FlatAppearance.BorderSize = 0;
            btnGuncelle.FlatStyle = FlatStyle.Flat;
            btnGuncelle.ForeColor = SystemColors.ControlLightLight;
            btnGuncelle.Location = new Point(82, 389);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(94, 29);
            btnGuncelle.TabIndex = 20;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = false;
            // 
            // btnKaydet
            // 
            btnKaydet.BackColor = Color.DarkCyan;
            btnKaydet.FlatAppearance.BorderSize = 0;
            btnKaydet.FlatStyle = FlatStyle.Flat;
            btnKaydet.ForeColor = SystemColors.ControlLightLight;
            btnKaydet.Location = new Point(82, 354);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(94, 29);
            btnKaydet.TabIndex = 19;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(46, 260);
            label5.Name = "label5";
            label5.Size = new Size(157, 23);
            label5.TabIndex = 18;
            label5.Text = "Kritik Stok Seviyesi:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(46, 225);
            label4.Name = "label4";
            label4.Size = new Size(85, 23);
            label4.TabIndex = 17;
            label4.Text = "Birim Tipi:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(46, 188);
            label3.Name = "label3";
            label3.Size = new Size(78, 23);
            label3.TabIndex = 16;
            label3.Text = "Kategori:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(46, 148);
            label2.Name = "label2";
            label2.Size = new Size(97, 23);
            label2.TabIndex = 15;
            label2.Text = "Ürün Kodu:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(46, 109);
            label1.Name = "label1";
            label1.Size = new Size(82, 23);
            label1.TabIndex = 14;
            label1.Text = "Ürün Adı:";
            // 
            // lblKategoriAdi
            // 
            lblKategoriAdi.AutoSize = true;
            lblKategoriAdi.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblKategoriAdi.ForeColor = SystemColors.ControlLightLight;
            lblKategoriAdi.Location = new Point(41, 84);
            lblKategoriAdi.Name = "lblKategoriAdi";
            lblKategoriAdi.Size = new Size(108, 23);
            lblKategoriAdi.TabIndex = 0;
            lblKategoriAdi.Text = "Kategori Adı:";
            // 
            // txtKategoriAdi
            // 
            txtKategoriAdi.Location = new Point(149, 84);
            txtKategoriAdi.Name = "txtKategoriAdi";
            txtKategoriAdi.Size = new Size(188, 27);
            txtKategoriAdi.TabIndex = 1;
            // 
            // lblAciklama
            // 
            lblAciklama.AutoSize = true;
            lblAciklama.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblAciklama.ForeColor = SystemColors.ControlLightLight;
            lblAciklama.Location = new Point(41, 131);
            lblAciklama.Name = "lblAciklama";
            lblAciklama.Size = new Size(88, 23);
            lblAciklama.TabIndex = 2;
            lblAciklama.Text = "Açıklama :";
            // 
            // txtKategoriAciklama
            // 
            txtKategoriAciklama.Location = new Point(149, 128);
            txtKategoriAciklama.Multiline = true;
            txtKategoriAciklama.Name = "txtKategoriAciklama";
            txtKategoriAciklama.Size = new Size(188, 34);
            txtKategoriAciklama.TabIndex = 3;
            // 
            // btnKategoriKaydet
            // 
            btnKategoriKaydet.BackColor = Color.Blue;
            btnKategoriKaydet.FlatAppearance.BorderSize = 0;
            btnKategoriKaydet.FlatStyle = FlatStyle.Flat;
            btnKategoriKaydet.ForeColor = SystemColors.ControlLightLight;
            btnKategoriKaydet.Location = new Point(149, 216);
            btnKategoriKaydet.Name = "btnKategoriKaydet";
            btnKategoriKaydet.Size = new Size(94, 29);
            btnKategoriKaydet.TabIndex = 4;
            btnKategoriKaydet.Text = "Kaydet";
            btnKategoriKaydet.UseVisualStyleBackColor = false;
            // 
            // btnKategoriGuncelle
            // 
            btnKategoriGuncelle.BackColor = Color.MediumTurquoise;
            btnKategoriGuncelle.FlatAppearance.BorderSize = 0;
            btnKategoriGuncelle.FlatStyle = FlatStyle.Flat;
            btnKategoriGuncelle.ForeColor = SystemColors.ControlLightLight;
            btnKategoriGuncelle.Location = new Point(252, 216);
            btnKategoriGuncelle.Name = "btnKategoriGuncelle";
            btnKategoriGuncelle.Size = new Size(94, 29);
            btnKategoriGuncelle.TabIndex = 5;
            btnKategoriGuncelle.Text = "Güncelle";
            btnKategoriGuncelle.UseVisualStyleBackColor = false;
            btnKategoriGuncelle.Click += button2_Click;
            // 
            // btnKategoriSil
            // 
            btnKategoriSil.BackColor = Color.Crimson;
            btnKategoriSil.FlatAppearance.BorderSize = 0;
            btnKategoriSil.FlatStyle = FlatStyle.Flat;
            btnKategoriSil.ForeColor = SystemColors.ControlLightLight;
            btnKategoriSil.Location = new Point(149, 251);
            btnKategoriSil.Name = "btnKategoriSil";
            btnKategoriSil.Size = new Size(94, 29);
            btnKategoriSil.TabIndex = 6;
            btnKategoriSil.Text = "Sil";
            btnKategoriSil.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(585, 607);
            dataGridView1.TabIndex = 0;
            // 
            // lblFirmaAdi
            // 
            lblFirmaAdi.AutoSize = true;
            lblFirmaAdi.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblFirmaAdi.ForeColor = SystemColors.ControlLightLight;
            lblFirmaAdi.Location = new Point(40, 54);
            lblFirmaAdi.Name = "lblFirmaAdi";
            lblFirmaAdi.Size = new Size(87, 23);
            lblFirmaAdi.TabIndex = 0;
            lblFirmaAdi.Text = "Firma Adı:";
            // 
            // lblYetkiliKisi
            // 
            lblYetkiliKisi.AutoSize = true;
            lblYetkiliKisi.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblYetkiliKisi.ForeColor = SystemColors.ControlLightLight;
            lblYetkiliKisi.Location = new Point(40, 107);
            lblYetkiliKisi.Name = "lblYetkiliKisi";
            lblYetkiliKisi.Size = new Size(84, 23);
            lblYetkiliKisi.TabIndex = 1;
            lblYetkiliKisi.Text = "Yetkili Kişi";
            // 
            // lblTelefon
            // 
            lblTelefon.AutoSize = true;
            lblTelefon.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblTelefon.ForeColor = SystemColors.ControlLightLight;
            lblTelefon.Location = new Point(40, 162);
            lblTelefon.Name = "lblTelefon";
            lblTelefon.Size = new Size(69, 23);
            lblTelefon.TabIndex = 2;
            lblTelefon.Text = "Telefon:";
            // 
            // txtFirmaAdi
            // 
            txtFirmaAdi.Location = new Point(142, 50);
            txtFirmaAdi.Name = "txtFirmaAdi";
            txtFirmaAdi.Size = new Size(125, 27);
            txtFirmaAdi.TabIndex = 3;
            // 
            // txtYetkiliKisi
            // 
            txtYetkiliKisi.Location = new Point(142, 100);
            txtYetkiliKisi.Name = "txtYetkiliKisi";
            txtYetkiliKisi.Size = new Size(125, 27);
            txtYetkiliKisi.TabIndex = 4;
            // 
            // txtTelefon
            // 
            txtTelefon.Location = new Point(142, 155);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(125, 27);
            txtTelefon.TabIndex = 5;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(142, 209);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 34);
            textBox4.TabIndex = 6;
            // 
            // lblAdres
            // 
            lblAdres.AutoSize = true;
            lblAdres.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblAdres.ForeColor = SystemColors.ControlLightLight;
            lblAdres.Location = new Point(40, 216);
            lblAdres.Name = "lblAdres";
            lblAdres.Size = new Size(62, 23);
            lblAdres.TabIndex = 7;
            lblAdres.Text = "Adres :";
            // 
            // btnTedarikciKaydet
            // 
            btnTedarikciKaydet.FlatAppearance.BorderSize = 0;
            btnTedarikciKaydet.Location = new Point(66, 322);
            btnTedarikciKaydet.Name = "btnTedarikciKaydet";
            btnTedarikciKaydet.Size = new Size(94, 29);
            btnTedarikciKaydet.TabIndex = 8;
            btnTedarikciKaydet.Text = "Kaydet";
            btnTedarikciKaydet.UseVisualStyleBackColor = true;
            // 
            // btnTedarikciSil
            // 
            btnTedarikciSil.FlatAppearance.BorderSize = 0;
            btnTedarikciSil.Location = new Point(66, 357);
            btnTedarikciSil.Name = "btnTedarikciSil";
            btnTedarikciSil.Size = new Size(94, 29);
            btnTedarikciSil.TabIndex = 9;
            btnTedarikciSil.Text = "Sil";
            btnTedarikciSil.UseVisualStyleBackColor = true;
            // 
            // btnTedarikciGuncelle
            // 
            btnTedarikciGuncelle.FlatAppearance.BorderSize = 0;
            btnTedarikciGuncelle.Location = new Point(166, 322);
            btnTedarikciGuncelle.Name = "btnTedarikciGuncelle";
            btnTedarikciGuncelle.Size = new Size(94, 29);
            btnTedarikciGuncelle.TabIndex = 10;
            btnTedarikciGuncelle.Text = "Güncelle";
            btnTedarikciGuncelle.UseVisualStyleBackColor = true;
            // 
            // frmUrunYonetimi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1078, 607);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmUrunYonetimi";
            Text = "frmUrunYonetimi";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
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
        private ComboBox comboBox1;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
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