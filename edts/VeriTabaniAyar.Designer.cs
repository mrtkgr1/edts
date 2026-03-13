namespace edts {
    partial class VeriTabaniAyar {
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
            veriTabaniBilgi = new Label();
            SabitBaslik = new Label();
            yeniVeriTabaniBilgi = new Label();
            buttonMevcutTest = new Button();
            buttonYeniTest = new Button();
            mevcutTest = new Label();
            yeniTest = new Label();
            label2 = new Label();
            textBoxYeniDizi = new TextBox();
            buttonDegistir = new Button();
            buttonKayit = new Button();
            label1 = new Label();
            textBoxYeniAd = new TextBox();
            yeniAd = new Label();
            label4 = new Label();
            mevcutAd = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // veriTabaniBilgi
            // 
            veriTabaniBilgi.AutoSize = true;
            veriTabaniBilgi.Location = new Point(12, 37);
            veriTabaniBilgi.Name = "veriTabaniBilgi";
            veriTabaniBilgi.Size = new Size(184, 17);
            veriTabaniBilgi.TabIndex = 0;
            veriTabaniBilgi.Text = "Mevcut Veri Tabanı Bağlantısı: ";
            // 
            // SabitBaslik
            // 
            SabitBaslik.AutoSize = true;
            SabitBaslik.Font = new Font("Segoe UI", 10.8679247F, FontStyle.Bold, GraphicsUnit.Point, 162);
            SabitBaslik.Location = new Point(150, 9);
            SabitBaslik.Name = "SabitBaslik";
            SabitBaslik.Size = new Size(238, 21);
            SabitBaslik.TabIndex = 1;
            SabitBaslik.Text = "Veri Tabanı Ayarlarını Değiştir";
            // 
            // yeniVeriTabaniBilgi
            // 
            yeniVeriTabaniBilgi.AutoSize = true;
            yeniVeriTabaniBilgi.Location = new Point(12, 240);
            yeniVeriTabaniBilgi.Name = "yeniVeriTabaniBilgi";
            yeniVeriTabaniBilgi.Size = new Size(256, 17);
            yeniVeriTabaniBilgi.TabIndex = 2;
            yeniVeriTabaniBilgi.Text = "Yeni Veri Tabanı Bağlantısı: Henüz girilmedi";
            // 
            // buttonMevcutTest
            // 
            buttonMevcutTest.Location = new Point(12, 74);
            buttonMevcutTest.Name = "buttonMevcutTest";
            buttonMevcutTest.Size = new Size(68, 25);
            buttonMevcutTest.TabIndex = 3;
            buttonMevcutTest.Text = "Test Et";
            buttonMevcutTest.UseVisualStyleBackColor = true;
            buttonMevcutTest.Click += buttonMevcutTest_Click;
            // 
            // buttonYeniTest
            // 
            buttonYeniTest.Location = new Point(14, 277);
            buttonYeniTest.Name = "buttonYeniTest";
            buttonYeniTest.Size = new Size(68, 25);
            buttonYeniTest.TabIndex = 8;
            buttonYeniTest.Text = "Test Et";
            buttonYeniTest.UseVisualStyleBackColor = true;
            buttonYeniTest.Click += buttonYeniTest_Click;
            // 
            // mevcutTest
            // 
            mevcutTest.Location = new Point(81, 78);
            mevcutTest.Name = "mevcutTest";
            mevcutTest.Size = new Size(446, 69);
            mevcutTest.TabIndex = 9;
            mevcutTest.Text = "Test Daha başlatılmadı";
            // 
            // yeniTest
            // 
            yeniTest.Location = new Point(88, 281);
            yeniTest.Name = "yeniTest";
            yeniTest.Size = new Size(446, 71);
            yeniTest.TabIndex = 10;
            yeniTest.Text = "Test Daha başlatılmadı";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 147);
            label2.Name = "label2";
            label2.Size = new Size(202, 17);
            label2.TabIndex = 11;
            label2.Text = "Yeni Veri Tabanı Bağlantısını Girin:";
            // 
            // textBoxYeniDizi
            // 
            textBoxYeniDizi.Location = new Point(14, 167);
            textBoxYeniDizi.Name = "textBoxYeniDizi";
            textBoxYeniDizi.Size = new Size(242, 25);
            textBoxYeniDizi.TabIndex = 12;
            // 
            // buttonDegistir
            // 
            buttonDegistir.Location = new Point(444, 202);
            buttonDegistir.Name = "buttonDegistir";
            buttonDegistir.Size = new Size(83, 25);
            buttonDegistir.TabIndex = 13;
            buttonDegistir.Text = "Değiştir";
            buttonDegistir.UseVisualStyleBackColor = true;
            buttonDegistir.Click += buttonDegistir_Click;
            // 
            // buttonKayit
            // 
            buttonKayit.Enabled = false;
            buttonKayit.Location = new Point(407, 355);
            buttonKayit.Name = "buttonKayit";
            buttonKayit.Size = new Size(127, 33);
            buttonKayit.TabIndex = 14;
            buttonKayit.Text = "Ayarları Kaydet";
            buttonKayit.UseVisualStyleBackColor = true;
            buttonKayit.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(287, 147);
            label1.Name = "label1";
            label1.Size = new Size(166, 17);
            label1.TabIndex = 15;
            label1.Text = "Yeni Veri Tabanı Adını Girin:";
            // 
            // textBoxYeniAd
            // 
            textBoxYeniAd.Location = new Point(287, 167);
            textBoxYeniAd.Name = "textBoxYeniAd";
            textBoxYeniAd.Size = new Size(242, 25);
            textBoxYeniAd.TabIndex = 16;
            // 
            // yeniAd
            // 
            yeniAd.AutoSize = true;
            yeniAd.Location = new Point(12, 257);
            yeniAd.Name = "yeniAd";
            yeniAd.Size = new Size(220, 17);
            yeniAd.TabIndex = 17;
            yeniAd.Text = "Yeni Veri Tabanı Adı: Henüz girilmedi";
            yeniAd.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Light", 8.830189F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label4.Location = new Point(241, 206);
            label4.Name = "label4";
            label4.Size = new Size(197, 17);
            label4.TabIndex = 18;
            label4.Text = "Değiştirilmeyen değerler aynı kalır.";
            // 
            // mevcutAd
            // 
            mevcutAd.AutoSize = true;
            mevcutAd.Location = new Point(12, 54);
            mevcutAd.Name = "mevcutAd";
            mevcutAd.Size = new Size(148, 17);
            mevcutAd.TabIndex = 19;
            mevcutAd.Text = "Mevcut Veri Tabanı Adı: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Light", 8.830189F, FontStyle.Underline, GraphicsUnit.Point, 162);
            label5.Location = new Point(14, 363);
            label5.Name = "label5";
            label5.Size = new Size(374, 17);
            label5.TabIndex = 20;
            label5.Text = "*Değerlerin kayıt edilmesi için \"Ayarları Kaydet\" butonu kullanılmalı";
            // 
            // VeriTabaniAyar
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(544, 398);
            Controls.Add(label5);
            Controls.Add(mevcutAd);
            Controls.Add(label4);
            Controls.Add(yeniAd);
            Controls.Add(textBoxYeniAd);
            Controls.Add(label1);
            Controls.Add(buttonKayit);
            Controls.Add(buttonDegistir);
            Controls.Add(textBoxYeniDizi);
            Controls.Add(label2);
            Controls.Add(yeniTest);
            Controls.Add(mevcutTest);
            Controls.Add(buttonYeniTest);
            Controls.Add(buttonMevcutTest);
            Controls.Add(yeniVeriTabaniBilgi);
            Controls.Add(SabitBaslik);
            Controls.Add(veriTabaniBilgi);
            MaximizeBox = false;
            Name = "VeriTabaniAyar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Veri Tabanı Ayarları";
            Load += VeriTabaniAyar_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label veriTabaniBilgi;
        private Label SabitBaslik;
        private Label yeniVeriTabaniBilgi;
        private Button buttonMevcutTest;
        private Button buttonYeniTest;
        private Label mevcutTest;
        private Label yeniTest;
        private Label label2;
        private TextBox textBoxYeniDizi;
        private Button buttonDegistir;
        private Button buttonKayit;
        private Label label1;
        private TextBox textBoxYeniAd;
        private Label yeniAd;
        private Label label4;
        private Label mevcutAd;
        private Label label5;
    }
}