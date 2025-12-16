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
        private void InitializeComponent() {
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
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStokDetaylari).BeginInit();
            panel3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(340, 625);
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
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            groupBox1.ForeColor = SystemColors.ControlLightLight;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(340, 625);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Mal Kabul Bilgileri";
            // 
            // btnEkle
            // 
            btnEkle.BackColor = Color.DarkCyan;
            btnEkle.Location = new Point(214, 456);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(94, 34);
            btnEkle.TabIndex = 10;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = false;
            btnEkle.Click += btnEkle_Click;
            // 
            // cmbUrunSecimi
            // 
            cmbUrunSecimi.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbUrunSecimi.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbUrunSecimi.FormattingEnabled = true;
            cmbUrunSecimi.Location = new Point(139, 317);
            cmbUrunSecimi.Name = "cmbUrunSecimi";
            cmbUrunSecimi.Size = new Size(160, 33);
            cmbUrunSecimi.TabIndex = 9;
            // 
            // cmbGirisNedeni
            // 
            cmbGirisNedeni.FormattingEnabled = true;
            cmbGirisNedeni.Location = new Point(139, 243);
            cmbGirisNedeni.Name = "cmbGirisNedeni";
            cmbGirisNedeni.Size = new Size(160, 33);
            cmbGirisNedeni.TabIndex = 8;
            // 
            // cmbTedarikci
            // 
            cmbTedarikci.FormattingEnabled = true;
            cmbTedarikci.Location = new Point(139, 69);
            cmbTedarikci.Name = "cmbTedarikci";
            cmbTedarikci.Size = new Size(160, 33);
            cmbTedarikci.TabIndex = 7;
            // 
            // txtFaturaNo
            // 
            txtFaturaNo.Location = new Point(139, 156);
            txtFaturaNo.Name = "txtFaturaNo";
            txtFaturaNo.Size = new Size(160, 31);
            txtFaturaNo.TabIndex = 6;
            // 
            // txtGirisMiktari
            // 
            txtGirisMiktari.Location = new Point(139, 392);
            txtGirisMiktari.Name = "txtGirisMiktari";
            txtGirisMiktari.Size = new Size(160, 31);
            txtGirisMiktari.TabIndex = 5;
            txtGirisMiktari.TextChanged += txtGirisMiktari_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(33, 396);
            label5.Name = "label5";
            label5.Size = new Size(107, 21);
            label5.TabIndex = 4;
            label5.Text = "Giriş Miktarı:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(33, 321);
            label4.Name = "label4";
            label4.Size = new Size(107, 21);
            label4.TabIndex = 3;
            label4.Text = "Ürün Seçimi:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(33, 247);
            label3.Name = "label3";
            label3.Size = new Size(108, 21);
            label3.TabIndex = 2;
            label3.Text = "Giriş Nedeni:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(33, 159);
            label2.Name = "label2";
            label2.Size = new Size(89, 21);
            label2.TabIndex = 1;
            label2.Text = "Fatura No:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(33, 69);
            label1.Name = "label1";
            label1.Size = new Size(83, 21);
            label1.TabIndex = 0;
            label1.Text = "Tedarikçi:";
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvStokDetaylari);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(660, 548);
            panel2.TabIndex = 1;
            // 
            // dgvStokDetaylari
            // 
            dgvStokDetaylari.AllowUserToAddRows = false;
            dgvStokDetaylari.AllowUserToDeleteRows = false;
            dgvStokDetaylari.AllowUserToResizeRows = false;
            dgvStokDetaylari.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStokDetaylari.Dock = DockStyle.Fill;
            dgvStokDetaylari.Location = new Point(0, 0);
            dgvStokDetaylari.Name = "dgvStokDetaylari";
            dgvStokDetaylari.RowHeadersWidth = 51;
            dgvStokDetaylari.Size = new Size(660, 548);
            dgvStokDetaylari.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnGirisOnayla);
            panel3.Controls.Add(btnSil);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 557);
            panel3.Name = "panel3";
            panel3.Size = new Size(660, 65);
            panel3.TabIndex = 1;
            // 
            // btnGirisOnayla
            // 
            btnGirisOnayla.BackColor = Color.DarkOliveGreen;
            btnGirisOnayla.FlatAppearance.BorderSize = 0;
            btnGirisOnayla.FlatStyle = FlatStyle.Flat;
            btnGirisOnayla.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnGirisOnayla.ForeColor = SystemColors.ControlLightLight;
            btnGirisOnayla.Location = new Point(126, 3);
            btnGirisOnayla.Name = "btnGirisOnayla";
            btnGirisOnayla.Size = new Size(134, 62);
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
            btnSil.Location = new Point(319, 0);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(134, 62);
            btnSil.TabIndex = 0;
            btnSil.Text = "Temizle";
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += btnSil_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel3, 0, 1);
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(340, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 71F));
            tableLayoutPanel1.Size = new Size(666, 625);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // frmStokGiris
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 625);
            Controls.Add(tableLayoutPanel1);
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
            tableLayoutPanel1.ResumeLayout(false);
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
        private TableLayoutPanel tableLayoutPanel1;
    }
}