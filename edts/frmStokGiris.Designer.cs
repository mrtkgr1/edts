namespace EnvanterDepoSistemitaslak2
{
    partial class frmStokGiris
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
            groupBox1 = new GroupBox();
            btnEkle = new Button();
            cmbUrunSecimi = new ComboBox();
            cmbGirisNedeni = new ComboBox();
            cmbTedarikci = new ComboBox();
            txtFaturaNo = new TextBox();
            txtGirisMiktari = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            dgvStokDetaylari = new DataGridView();
            panel3 = new Panel();
            btnGirisOnayla = new Button();
            btnSil = new Button();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStokDetaylari).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(542, 735);
            panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.DarkOliveGreen;
            groupBox1.Controls.Add(btnEkle);
            groupBox1.Controls.Add(cmbUrunSecimi);
            groupBox1.Controls.Add(cmbGirisNedeni);
            groupBox1.Controls.Add(cmbTedarikci);
            groupBox1.Controls.Add(txtFaturaNo);
            groupBox1.Controls.Add(txtGirisMiktari);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            groupBox1.ForeColor = SystemColors.ControlLightLight;
            groupBox1.Location = new Point(63, 47);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(414, 633);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Mal Kabul Bilgileri";
            // 
            // btnEkle
            // 
            btnEkle.BackColor = Color.DarkCyan;
            btnEkle.Location = new Point(245, 537);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(108, 40);
            btnEkle.TabIndex = 10;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = false;
            btnEkle.Click += btnEkle_Click;
            // 
            // cmbUrunSecimi
            // 
            cmbUrunSecimi.FormattingEnabled = true;
            cmbUrunSecimi.Location = new Point(171, 382);
            cmbUrunSecimi.Name = "cmbUrunSecimi";
            cmbUrunSecimi.Size = new Size(182, 36);
            cmbUrunSecimi.TabIndex = 9;
            // 
            // cmbGirisNedeni
            // 
            cmbGirisNedeni.FormattingEnabled = true;
            cmbGirisNedeni.Location = new Point(171, 295);
            cmbGirisNedeni.Name = "cmbGirisNedeni";
            cmbGirisNedeni.Size = new Size(182, 36);
            cmbGirisNedeni.TabIndex = 8;
            // 
            // cmbTedarikci
            // 
            cmbTedarikci.FormattingEnabled = true;
            cmbTedarikci.Location = new Point(171, 91);
            cmbTedarikci.Name = "cmbTedarikci";
            cmbTedarikci.Size = new Size(182, 36);
            cmbTedarikci.TabIndex = 7;
            // 
            // txtFaturaNo
            // 
            txtFaturaNo.Location = new Point(171, 193);
            txtFaturaNo.Name = "txtFaturaNo";
            txtFaturaNo.Size = new Size(182, 34);
            txtFaturaNo.TabIndex = 6;
            // 
            // txtGirisMiktari
            // 
            txtGirisMiktari.Location = new Point(171, 471);
            txtGirisMiktari.Name = "txtGirisMiktari";
            txtGirisMiktari.Size = new Size(182, 34);
            txtGirisMiktari.TabIndex = 5;
            txtGirisMiktari.TextChanged += txtGirisMiktari_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(50, 475);
            label5.Name = "label5";
            label5.Size = new Size(115, 23);
            label5.TabIndex = 4;
            label5.Text = "Giriş Miktarı:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(50, 387);
            label4.Name = "label4";
            label4.Size = new Size(112, 23);
            label4.TabIndex = 3;
            label4.Text = "Ürün Seçimi:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(50, 300);
            label3.Name = "label3";
            label3.Size = new Size(113, 23);
            label3.TabIndex = 2;
            label3.Text = "Giriş Nedeni:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(50, 197);
            label2.Name = "label2";
            label2.Size = new Size(93, 23);
            label2.TabIndex = 1;
            label2.Text = "Fatura No:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(50, 91);
            label1.Name = "label1";
            label1.Size = new Size(87, 23);
            label1.TabIndex = 0;
            label1.Text = "Tedarikçi:";
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvStokDetaylari);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(542, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(608, 362);
            panel2.TabIndex = 1;
            // 
            // dgvStokDetaylari
            // 
            dgvStokDetaylari.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStokDetaylari.Dock = DockStyle.Fill;
            dgvStokDetaylari.Location = new Point(0, 0);
            dgvStokDetaylari.Name = "dgvStokDetaylari";
            dgvStokDetaylari.RowHeadersWidth = 51;
            dgvStokDetaylari.Size = new Size(608, 362);
            dgvStokDetaylari.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnGirisOnayla);
            panel3.Controls.Add(btnSil);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(542, 362);
            panel3.Name = "panel3";
            panel3.Size = new Size(608, 373);
            panel3.TabIndex = 1;
            // 
            // btnGirisOnayla
            // 
            btnGirisOnayla.BackColor = Color.DarkOliveGreen;
            btnGirisOnayla.FlatAppearance.BorderSize = 0;
            btnGirisOnayla.FlatStyle = FlatStyle.Flat;
            btnGirisOnayla.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnGirisOnayla.ForeColor = SystemColors.ControlLightLight;
            btnGirisOnayla.Location = new Point(131, 90);
            btnGirisOnayla.Name = "btnGirisOnayla";
            btnGirisOnayla.Size = new Size(153, 73);
            btnGirisOnayla.TabIndex = 1;
            btnGirisOnayla.Text = "Girişi Onayla";
            btnGirisOnayla.UseVisualStyleBackColor = false;
            btnGirisOnayla.Click += btnGirisOnayla_Click;
            // 
            // btnSil
            // 
            btnSil.BackColor = Color.Crimson;
            btnSil.FlatAppearance.BorderSize = 0;
            btnSil.FlatStyle = FlatStyle.Flat;
            btnSil.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnSil.ForeColor = SystemColors.ControlLightLight;
            btnSil.Location = new Point(290, 90);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(153, 73);
            btnSil.TabIndex = 0;
            btnSil.Text = "Temizle";
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += btnSil_Click;
            // 
            // frmStokGiris
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1150, 735);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmStokGiris";
            Text = "frmStokGiris";
            Load += frmStokGiris_Load;
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStokDetaylari).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private GroupBox groupBox1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView dgvStokDetaylari;
        private Panel panel3;
        private Button btnGirisOnayla;
        private Button btnSil;
        private Button btnEkle;
        private ComboBox cmbUrunSecimi;
        private ComboBox cmbGirisNedeni;
        private ComboBox cmbTedarikci;
        private TextBox txtFaturaNo;
        private TextBox txtGirisMiktari;
    }
}