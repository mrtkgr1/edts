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
        private void InitializeComponent() {
            groupBox1 = new GroupBox();
            textBoxVarDepo = new TextBox();
            label6 = new Label();
            comboBoxVarBirim = new ComboBox();
            label5 = new Label();
            label1 = new Label();
            numerickritikStok = new NumericUpDown();
            groupBox2 = new GroupBox();
            numericSifreDeg = new NumericUpDown();
            label4 = new Label();
            numericOturumSure = new NumericUpDown();
            label3 = new Label();
            numericmaxGir = new NumericUpDown();
            label2 = new Label();
            btnAyarlariKaydet = new Button();
            groupBox3 = new GroupBox();
            btnTipSil = new Button();
            comboBox1 = new ComboBox();
            btnTipEkle = new Button();
            dgvIslemTipleri = new DataGridView();
            textBox1 = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numerickritikStok).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericSifreDeg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericOturumSure).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericmaxGir).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIslemTipleri).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.DarkCyan;
            groupBox1.Controls.Add(textBoxVarDepo);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(comboBoxVarBirim);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(numerickritikStok);
            groupBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            groupBox1.ForeColor = SystemColors.ControlLightLight;
            groupBox1.Location = new Point(63, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(806, 166);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Genel Stok Yönetimi Ayarları";
            // 
            // textBoxVarDepo
            // 
            textBoxVarDepo.Location = new Point(228, 101);
            textBoxVarDepo.Name = "textBoxVarDepo";
            textBoxVarDepo.Size = new Size(133, 27);
            textBoxVarDepo.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.ControlLightLight;
            label6.Location = new Point(27, 104);
            label6.Name = "label6";
            label6.Size = new Size(203, 21);
            label6.TabIndex = 4;
            label6.Text = "Varsayılan Depo Konumu";
            // 
            // comboBoxVarBirim
            // 
            comboBoxVarBirim.FormattingEnabled = true;
            comboBoxVarBirim.Location = new Point(228, 63);
            comboBoxVarBirim.Name = "comboBoxVarBirim";
            comboBoxVarBirim.Size = new Size(133, 28);
            comboBoxVarBirim.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(26, 69);
            label5.Name = "label5";
            label5.Size = new Size(167, 21);
            label5.TabIndex = 2;
            label5.Text = "Varsayılan Birim Tipi";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(26, 38);
            label1.Name = "label1";
            label1.Size = new Size(129, 21);
            label1.TabIndex = 1;
            label1.Text = "Kritik Stok Eşiği";
            // 
            // numerickritikStok
            // 
            numerickritikStok.Location = new Point(228, 32);
            numerickritikStok.Name = "numerickritikStok";
            numerickritikStok.Size = new Size(132, 27);
            numerickritikStok.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.DarkCyan;
            groupBox2.Controls.Add(numericSifreDeg);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(numericOturumSure);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(numericmaxGir);
            groupBox2.Controls.Add(label2);
            groupBox2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            groupBox2.ForeColor = SystemColors.ControlLightLight;
            groupBox2.Location = new Point(63, 181);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(806, 193);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Kullanıcı Güvenlik Ayarları";
            // 
            // numericSifreDeg
            // 
            numericSifreDeg.Location = new Point(227, 60);
            numericSifreDeg.Name = "numericSifreDeg";
            numericSifreDeg.Size = new Size(131, 27);
            numericSifreDeg.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(26, 66);
            label4.Name = "label4";
            label4.Size = new Size(183, 21);
            label4.TabIndex = 4;
            label4.Text = "Şifre Değiştirme Süresi";
            // 
            // numericOturumSure
            // 
            numericOturumSure.Location = new Point(227, 130);
            numericOturumSure.Name = "numericOturumSure";
            numericOturumSure.Size = new Size(131, 27);
            numericOturumSure.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(26, 136);
            label3.Name = "label3";
            label3.Size = new Size(173, 21);
            label3.TabIndex = 2;
            label3.Text = "Oturum Zaman Aşımı";
            // 
            // numericmaxGir
            // 
            numericmaxGir.Location = new Point(227, 98);
            numericmaxGir.Name = "numericmaxGir";
            numericmaxGir.Size = new Size(131, 27);
            numericmaxGir.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(26, 99);
            label2.Name = "label2";
            label2.Size = new Size(213, 21);
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
            btnAyarlariKaydet.Location = new Point(377, 635);
            btnAyarlariKaydet.Name = "btnAyarlariKaydet";
            btnAyarlariKaydet.Size = new Size(197, 31);
            btnAyarlariKaydet.TabIndex = 2;
            btnAyarlariKaydet.Text = "Kaydet";
            btnAyarlariKaydet.UseVisualStyleBackColor = false;
            btnAyarlariKaydet.Click += btnAyarlariKaydet_Click;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.DarkCyan;
            groupBox3.Controls.Add(btnTipSil);
            groupBox3.Controls.Add(comboBox1);
            groupBox3.Controls.Add(btnTipEkle);
            groupBox3.Controls.Add(dgvIslemTipleri);
            groupBox3.Controls.Add(textBox1);
            groupBox3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            groupBox3.ForeColor = SystemColors.ControlLightLight;
            groupBox3.Location = new Point(63, 379);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(806, 251);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Stok Hareket Tipleri Tanımlama";
            // 
            // btnTipSil
            // 
            btnTipSil.BackColor = Color.Crimson;
            btnTipSil.FlatAppearance.BorderSize = 0;
            btnTipSil.FlatStyle = FlatStyle.Flat;
            btnTipSil.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnTipSil.ForeColor = SystemColors.ControlLightLight;
            btnTipSil.Location = new Point(366, 54);
            btnTipSil.Name = "btnTipSil";
            btnTipSil.Size = new Size(116, 31);
            btnTipSil.TabIndex = 5;
            btnTipSil.Text = "Sil";
            btnTipSil.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Giriş, Çıkış" });
            comboBox1.Location = new Point(228, 54);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(133, 28);
            comboBox1.TabIndex = 8;
            // 
            // btnTipEkle
            // 
            btnTipEkle.BackColor = Color.DarkOliveGreen;
            btnTipEkle.FlatAppearance.BorderSize = 0;
            btnTipEkle.FlatStyle = FlatStyle.Flat;
            btnTipEkle.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnTipEkle.ForeColor = SystemColors.ControlLightLight;
            btnTipEkle.Location = new Point(366, 21);
            btnTipEkle.Name = "btnTipEkle";
            btnTipEkle.Size = new Size(116, 31);
            btnTipEkle.TabIndex = 4;
            btnTipEkle.Text = "Ekle";
            btnTipEkle.UseVisualStyleBackColor = false;
            // 
            // dgvIslemTipleri
            // 
            dgvIslemTipleri.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIslemTipleri.Location = new Point(228, 86);
            dgvIslemTipleri.Name = "dgvIslemTipleri";
            dgvIslemTipleri.RowHeadersWidth = 51;
            dgvIslemTipleri.Size = new Size(253, 160);
            dgvIslemTipleri.TabIndex = 7;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(228, 25);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(133, 27);
            textBox1.TabIndex = 6;
            // 
            // frmAdminSistemAyarlari
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkOliveGreen;
            ClientSize = new Size(1024, 690);
            Controls.Add(groupBox3);
            Controls.Add(btnAyarlariKaydet);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmAdminSistemAyarlari";
            Text = "frmAdminSistemAyarlari";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numerickritikStok).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericSifreDeg).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericOturumSure).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericmaxGir).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIslemTipleri).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnAyarlariKaydet;
        private GroupBox groupBox3;
        private ComboBox comboBox1;
        private DataGridView dgvIslemTipleri;
        private TextBox textBox1;
        private Button btnTipEkle;
        private Button btnTipSil;
        private Label label1;
        private NumericUpDown numerickritikStok;
        private Label label6;
        private ComboBox comboBoxVarBirim;
        private Label label5;
        private NumericUpDown numericSifreDeg;
        private Label label4;
        private NumericUpDown numericOturumSure;
        private Label label3;
        private NumericUpDown numericmaxGir;
        private Label label2;
        private TextBox textBoxVarDepo;
    }
}