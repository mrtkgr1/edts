namespace EnvanterDepoSistemitaslak2
{
    partial class frmStokCikis
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
            groupBox3 = new GroupBox();
            label1 = new Label();
            btnListeyeEkle = new Button();
            lblMevcutStok = new Label();
            txtAdet = new TextBox();
            cmbUrun = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            groupBox4 = new GroupBox();
            cmbCikisNedeni = new ComboBox();
            cmbMusteri = new ComboBox();
            txtSiparisNo = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            panel2 = new Panel();
            label2 = new Label();
            dgvSevkiyatListesi = new DataGridView();
            panel3 = new Panel();
            panel4 = new Panel();
            btnCikisiOnayla = new Button();
            btnSil = new Button();
            panel1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSevkiyatListesi).BeginInit();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkOliveGreen;
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(groupBox4);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(389, 692);
            panel1.TabIndex = 2;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(btnListeyeEkle);
            groupBox3.Controls.Add(lblMevcutStok);
            groupBox3.Controls.Add(txtAdet);
            groupBox3.Controls.Add(cmbUrun);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(label4);
            groupBox3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            groupBox3.ForeColor = SystemColors.ControlLightLight;
            groupBox3.Location = new Point(61, 346);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(250, 252);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Ürün Ekleme";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 85);
            label1.Name = "label1";
            label1.Size = new Size(117, 23);
            label1.TabIndex = 6;
            label1.Text = "Mevcut Stok:";
            // 
            // btnListeyeEkle
            // 
            btnListeyeEkle.BackColor = Color.DarkCyan;
            btnListeyeEkle.FlatAppearance.BorderSize = 0;
            btnListeyeEkle.FlatStyle = FlatStyle.Flat;
            btnListeyeEkle.Location = new Point(108, 195);
            btnListeyeEkle.Name = "btnListeyeEkle";
            btnListeyeEkle.Size = new Size(132, 37);
            btnListeyeEkle.TabIndex = 5;
            btnListeyeEkle.Text = "Listeye Ekle";
            btnListeyeEkle.UseVisualStyleBackColor = false;
            btnListeyeEkle.Click += btnListeyeEkle_Click;
            // 
            // lblMevcutStok
            // 
            lblMevcutStok.AutoSize = true;
            lblMevcutStok.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblMevcutStok.ForeColor = SystemColors.ControlLightLight;
            lblMevcutStok.Location = new Point(207, 78);
            lblMevcutStok.Name = "lblMevcutStok";
            lblMevcutStok.Size = new Size(0, 23);
            lblMevcutStok.TabIndex = 4;
            lblMevcutStok.Click += lblMevcutStok_Click;
            // 
            // txtAdet
            // 
            txtAdet.Location = new Point(89, 139);
            txtAdet.Name = "txtAdet";
            txtAdet.Size = new Size(151, 30);
            txtAdet.TabIndex = 3;
            // 
            // cmbUrun
            // 
            cmbUrun.FormattingEnabled = true;
            cmbUrun.Location = new Point(89, 51);
            cmbUrun.Name = "cmbUrun";
            cmbUrun.Size = new Size(151, 31);
            cmbUrun.TabIndex = 2;
            cmbUrun.SelectedIndexChanged += cmbUrun_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(22, 142);
            label3.Name = "label3";
            label3.Size = new Size(54, 23);
            label3.TabIndex = 1;
            label3.Text = "Adet:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(22, 50);
            label4.Name = "label4";
            label4.Size = new Size(54, 23);
            label4.TabIndex = 0;
            label4.Text = "Ürün:";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(cmbCikisNedeni);
            groupBox4.Controls.Add(cmbMusteri);
            groupBox4.Controls.Add(txtSiparisNo);
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(label5);
            groupBox4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            groupBox4.ForeColor = SystemColors.ControlLightLight;
            groupBox4.Location = new Point(61, 12);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(250, 311);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            groupBox4.Text = "Sevkiyat Bilgileri";
            // 
            // cmbCikisNedeni
            // 
            cmbCikisNedeni.FormattingEnabled = true;
            cmbCikisNedeni.Location = new Point(36, 251);
            cmbCikisNedeni.Name = "cmbCikisNedeni";
            cmbCikisNedeni.Size = new Size(151, 31);
            cmbCikisNedeni.TabIndex = 5;
            // 
            // cmbMusteri
            // 
            cmbMusteri.FormattingEnabled = true;
            cmbMusteri.Location = new Point(36, 83);
            cmbMusteri.Name = "cmbMusteri";
            cmbMusteri.Size = new Size(151, 31);
            cmbMusteri.TabIndex = 4;
            // 
            // txtSiparisNo
            // 
            txtSiparisNo.Location = new Point(36, 161);
            txtSiparisNo.Name = "txtSiparisNo";
            txtSiparisNo.Size = new Size(151, 30);
            txtSiparisNo.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(36, 225);
            label7.Name = "label7";
            label7.Size = new Size(110, 23);
            label7.TabIndex = 2;
            label7.Text = "Çıkış Nedeni";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(36, 135);
            label6.Name = "label6";
            label6.Size = new Size(97, 23);
            label6.TabIndex = 1;
            label6.Text = "Sipariş No:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(36, 57);
            label5.Name = "label5";
            label5.Size = new Size(76, 23);
            label5.TabIndex = 0;
            label5.Text = "Müşteri:";
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(dgvSevkiyatListesi);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(389, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(699, 323);
            panel2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ControlDark;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(274, 9);
            label2.Name = "label2";
            label2.Size = new Size(174, 28);
            label2.TabIndex = 2;
            label2.Text = "SEVKİYAT LİSTESİ";
            // 
            // dgvSevkiyatListesi
            // 
            dgvSevkiyatListesi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSevkiyatListesi.Dock = DockStyle.Fill;
            dgvSevkiyatListesi.Location = new Point(0, 0);
            dgvSevkiyatListesi.Name = "dgvSevkiyatListesi";
            dgvSevkiyatListesi.RowHeadersWidth = 51;
            dgvSevkiyatListesi.Size = new Size(699, 323);
            dgvSevkiyatListesi.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLightLight;
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(389, 323);
            panel3.Name = "panel3";
            panel3.Size = new Size(699, 369);
            panel3.TabIndex = 4;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnCikisiOnayla);
            panel4.Controls.Add(btnSil);
            panel4.Location = new Point(141, 23);
            panel4.Name = "panel4";
            panel4.Size = new Size(467, 125);
            panel4.TabIndex = 2;
            // 
            // btnCikisiOnayla
            // 
            btnCikisiOnayla.BackColor = Color.Green;
            btnCikisiOnayla.FlatAppearance.BorderSize = 0;
            btnCikisiOnayla.FlatStyle = FlatStyle.Flat;
            btnCikisiOnayla.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnCikisiOnayla.ForeColor = SystemColors.ControlLightLight;
            btnCikisiOnayla.Location = new Point(48, 24);
            btnCikisiOnayla.Name = "btnCikisiOnayla";
            btnCikisiOnayla.Size = new Size(182, 77);
            btnCikisiOnayla.TabIndex = 3;
            btnCikisiOnayla.Text = "Çıkışı Onayla";
            btnCikisiOnayla.UseVisualStyleBackColor = false;
            btnCikisiOnayla.Click += btnCikisiOnayla_Click;
            // 
            // btnSil
            // 
            btnSil.BackColor = Color.Crimson;
            btnSil.FlatAppearance.BorderSize = 0;
            btnSil.FlatStyle = FlatStyle.Flat;
            btnSil.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnSil.ForeColor = SystemColors.ControlLightLight;
            btnSil.Location = new Point(236, 24);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(182, 77);
            btnSil.TabIndex = 2;
            btnSil.Text = "Listeyi Temizle";
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += btnSil_Click;
            // 
            // frmStokCikis
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1088, 692);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmStokCikis";
            Text = "frmStokCikis";
            panel1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSevkiyatListesi).EndInit();
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private GroupBox groupBox3;
        private Label lblMevcutStok;
        private TextBox txtAdet;
        private ComboBox cmbUrun;
        private Label label3;
        private Label label4;
        private GroupBox groupBox4;
        private Panel panel2;
        private Label label2;
        private DataGridView dgvSevkiyatListesi;
        private Panel panel3;
        private Panel panel4;
        private Button btnCikisiOnayla;
        private Button btnSil;
        private Button btnListeyeEkle;
        private ComboBox cmbCikisNedeni;
        private ComboBox cmbMusteri;
        private TextBox txtSiparisNo;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label1;
    }
}