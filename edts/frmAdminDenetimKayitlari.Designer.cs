namespace edts
{
    partial class frmAdminDenetimKayitlari
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
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnExcelAktar = new Button();
            btnKayitlariGetir = new Button();
            cmbHareketTipi = new ComboBox();
            cmbKullaniciSecim = new ComboBox();
            dtpBitis = new DateTimePicker();
            dtpBaslangic = new DateTimePicker();
            panel2 = new Panel();
            dgvDenetimKayitlari = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDenetimKayitlari).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnExcelAktar);
            panel1.Controls.Add(btnKayitlariGetir);
            panel1.Controls.Add(cmbHareketTipi);
            panel1.Controls.Add(cmbKullaniciSecim);
            panel1.Controls.Add(dtpBitis);
            panel1.Controls.Add(dtpBaslangic);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1201, 108);
            panel1.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label4.Location = new Point(681, 20);
            label4.Name = "label4";
            label4.Size = new Size(131, 23);
            label4.TabIndex = 15;
            label4.Text = "Kullanıcı Seçim";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label3.Location = new Point(524, 20);
            label3.Name = "label3";
            label3.Size = new Size(110, 23);
            label3.TabIndex = 14;
            label3.Text = "Hareket Tipi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.Location = new Point(290, 20);
            label2.Name = "label2";
            label2.Size = new Size(95, 23);
            label2.TabIndex = 13;
            label2.Text = "Bitiş Tarihi";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label1.Location = new Point(56, 19);
            label1.Name = "label1";
            label1.Size = new Size(135, 23);
            label1.TabIndex = 12;
            label1.Text = "Başlangıç Tarihi";
            // 
            // btnExcelAktar
            // 
            btnExcelAktar.BackColor = Color.LightSlateGray;
            btnExcelAktar.FlatAppearance.BorderSize = 0;
            btnExcelAktar.FlatStyle = FlatStyle.Flat;
            btnExcelAktar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnExcelAktar.ForeColor = SystemColors.ControlLightLight;
            btnExcelAktar.Location = new Point(845, 44);
            btnExcelAktar.Margin = new Padding(3, 4, 3, 4);
            btnExcelAktar.Name = "btnExcelAktar";
            btnExcelAktar.Size = new Size(134, 29);
            btnExcelAktar.TabIndex = 11;
            btnExcelAktar.Text = "Excel'e Aktar";
            btnExcelAktar.UseVisualStyleBackColor = false;
            btnExcelAktar.Click += btnExcelAktar_Click;
            // 
            // btnKayitlariGetir
            // 
            btnKayitlariGetir.BackColor = Color.LightSlateGray;
            btnKayitlariGetir.FlatAppearance.BorderSize = 0;
            btnKayitlariGetir.FlatStyle = FlatStyle.Flat;
            btnKayitlariGetir.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnKayitlariGetir.ForeColor = SystemColors.ControlLightLight;
            btnKayitlariGetir.Location = new Point(985, 44);
            btnKayitlariGetir.Margin = new Padding(3, 4, 3, 4);
            btnKayitlariGetir.Name = "btnKayitlariGetir";
            btnKayitlariGetir.Size = new Size(131, 29);
            btnKayitlariGetir.TabIndex = 10;
            btnKayitlariGetir.Text = "Kayıtları Getir";
            btnKayitlariGetir.UseVisualStyleBackColor = false;
            btnKayitlariGetir.Click += btnKayitlariGetir_Click;
            // 
            // cmbHareketTipi
            // 
            cmbHareketTipi.FormattingEnabled = true;
            cmbHareketTipi.Location = new Point(524, 45);
            cmbHareketTipi.Margin = new Padding(3, 4, 3, 4);
            cmbHareketTipi.Name = "cmbHareketTipi";
            cmbHareketTipi.Size = new Size(151, 28);
            cmbHareketTipi.TabIndex = 9;
            // 
            // cmbKullaniciSecim
            // 
            cmbKullaniciSecim.FormattingEnabled = true;
            cmbKullaniciSecim.Location = new Point(681, 44);
            cmbKullaniciSecim.Margin = new Padding(3, 4, 3, 4);
            cmbKullaniciSecim.Name = "cmbKullaniciSecim";
            cmbKullaniciSecim.Size = new Size(158, 28);
            cmbKullaniciSecim.TabIndex = 8;
            // 
            // dtpBitis
            // 
            dtpBitis.Location = new Point(290, 44);
            dtpBitis.Margin = new Padding(3, 4, 3, 4);
            dtpBitis.Name = "dtpBitis";
            dtpBitis.Size = new Size(228, 27);
            dtpBitis.TabIndex = 7;
            // 
            // dtpBaslangic
            // 
            dtpBaslangic.Location = new Point(56, 43);
            dtpBaslangic.Margin = new Padding(3, 4, 3, 4);
            dtpBaslangic.Name = "dtpBaslangic";
            dtpBaslangic.Size = new Size(228, 27);
            dtpBaslangic.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvDenetimKayitlari);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 108);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1201, 416);
            panel2.TabIndex = 1;
            // 
            // dgvDenetimKayitlari
            // 
            dgvDenetimKayitlari.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDenetimKayitlari.Dock = DockStyle.Fill;
            dgvDenetimKayitlari.Location = new Point(0, 0);
            dgvDenetimKayitlari.Margin = new Padding(3, 4, 3, 4);
            dgvDenetimKayitlari.Name = "dgvDenetimKayitlari";
            dgvDenetimKayitlari.RowHeadersWidth = 51;
            dgvDenetimKayitlari.Size = new Size(1201, 416);
            dgvDenetimKayitlari.TabIndex = 0;
            // 
            // frmAdminDenetimKayitlari
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1201, 524);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmAdminDenetimKayitlari";
            Text = "frmAdminDenetimKayitlari";
            Load += frmAdminDenetimKayitlari_Load_1;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDenetimKayitlari).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private Button btnExcelAktar;
        private Button btnKayitlariGetir;
        private ComboBox cmbHareketTipi;
        private ComboBox cmbKullaniciSecim;
        private DateTimePicker dtpBitis;
        private DateTimePicker dtpBaslangic;
        private Panel panel2;
        private Label label4;
        private Label label3;
        private DataGridView dgvDenetimKayitlari;
    }
}