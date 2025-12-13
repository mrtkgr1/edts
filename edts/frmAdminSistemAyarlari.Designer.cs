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
            textBox2 = new TextBox();
            label6 = new Label();
            comboBox2 = new ComboBox();
            label5 = new Label();
            label1 = new Label();
            numericUpDown1 = new NumericUpDown();
            groupBox2 = new GroupBox();
            numericUpDown4 = new NumericUpDown();
            label4 = new Label();
            numericUpDown3 = new NumericUpDown();
            label3 = new Label();
            numericUpDown2 = new NumericUpDown();
            label2 = new Label();
            btnAyarlariKaydet = new Button();
            groupBox3 = new GroupBox();
            btnTipSil = new Button();
            comboBox1 = new ComboBox();
            btnTipEkle = new Button();
            dgvIslemTipleri = new DataGridView();
            textBox1 = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIslemTipleri).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.DarkCyan;
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(comboBox2);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(numericUpDown1);
            groupBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            groupBox1.ForeColor = SystemColors.ControlLightLight;
            groupBox1.Location = new Point(72, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(921, 195);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Genel Stok Yönetimi Ayarları";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(261, 119);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(151, 30);
            textBox2.TabIndex = 5;
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
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(261, 74);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 31);
            comboBox2.TabIndex = 3;
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
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(261, 38);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(151, 30);
            numericUpDown1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.DarkCyan;
            groupBox2.Controls.Add(numericUpDown4);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(numericUpDown3);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(numericUpDown2);
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
            // numericUpDown4
            // 
            numericUpDown4.Location = new Point(259, 71);
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(150, 30);
            numericUpDown4.TabIndex = 5;
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
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(259, 153);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(150, 30);
            numericUpDown3.TabIndex = 3;
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
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(259, 115);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(150, 30);
            numericUpDown2.TabIndex = 1;
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
            btnAyarlariKaydet.Location = new Point(431, 747);
            btnAyarlariKaydet.Name = "btnAyarlariKaydet";
            btnAyarlariKaydet.Size = new Size(225, 36);
            btnAyarlariKaydet.TabIndex = 2;
            btnAyarlariKaydet.Text = "Kaydet";
            btnAyarlariKaydet.UseVisualStyleBackColor = false;
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
            groupBox3.Location = new Point(72, 446);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(921, 295);
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
            btnTipSil.Location = new Point(418, 64);
            btnTipSil.Name = "btnTipSil";
            btnTipSil.Size = new Size(132, 36);
            btnTipSil.TabIndex = 5;
            btnTipSil.Text = "Sil";
            btnTipSil.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Giriş, Çıkış" });
            comboBox1.Location = new Point(261, 64);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 31);
            comboBox1.TabIndex = 8;
            // 
            // btnTipEkle
            // 
            btnTipEkle.BackColor = Color.DarkOliveGreen;
            btnTipEkle.FlatAppearance.BorderSize = 0;
            btnTipEkle.FlatStyle = FlatStyle.Flat;
            btnTipEkle.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnTipEkle.ForeColor = SystemColors.ControlLightLight;
            btnTipEkle.Location = new Point(418, 25);
            btnTipEkle.Name = "btnTipEkle";
            btnTipEkle.Size = new Size(132, 36);
            btnTipEkle.TabIndex = 4;
            btnTipEkle.Text = "Ekle";
            btnTipEkle.UseVisualStyleBackColor = false;
            // 
            // dgvIslemTipleri
            // 
            dgvIslemTipleri.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIslemTipleri.Location = new Point(261, 101);
            dgvIslemTipleri.Name = "dgvIslemTipleri";
            dgvIslemTipleri.RowHeadersWidth = 51;
            dgvIslemTipleri.Size = new Size(289, 188);
            dgvIslemTipleri.TabIndex = 7;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(261, 29);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(151, 30);
            textBox1.TabIndex = 6;
            // 
            // frmAdminSistemAyarlari
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkOliveGreen;
            ClientSize = new Size(1170, 812);
            Controls.Add(groupBox3);
            Controls.Add(btnAyarlariKaydet);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmAdminSistemAyarlari";
            Text = "frmAdminSistemAyarlari";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
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
        private NumericUpDown numericUpDown1;
        private Label label6;
        private ComboBox comboBox2;
        private Label label5;
        private NumericUpDown numericUpDown4;
        private Label label4;
        private NumericUpDown numericUpDown3;
        private Label label3;
        private NumericUpDown numericUpDown2;
        private Label label2;
        private TextBox textBox2;
    }
}