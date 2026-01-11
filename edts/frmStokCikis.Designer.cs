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
            dgvSevkiyatListesi = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            panel4 = new Panel();
            btnCikisiOnayla = new Button();
            btnSil = new Button();
            panel1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSevkiyatListesi).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSlateGray;
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(groupBox4);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(294, 692);
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
            groupBox3.Location = new Point(25, 360);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
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
            btnListeyeEkle.BackColor = Color.LightSteelBlue;
            btnListeyeEkle.FlatAppearance.BorderSize = 0;
            btnListeyeEkle.FlatStyle = FlatStyle.Flat;
            btnListeyeEkle.Location = new Point(107, 195);
            btnListeyeEkle.Margin = new Padding(3, 4, 3, 4);
            btnListeyeEkle.Name = "btnListeyeEkle";
            btnListeyeEkle.Size = new Size(133, 36);
            btnListeyeEkle.TabIndex = 5;
            btnListeyeEkle.Text = "Listeye Ekle";
            btnListeyeEkle.UseVisualStyleBackColor = false;
            btnListeyeEkle.Click += btnListeyeEkle_Click;
            // 
            // lblMevcutStok
            // 
            lblMevcutStok.AutoSize = true;
            lblMevcutStok.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblMevcutStok.ForeColor = SystemColors.ControlLightLight;
            lblMevcutStok.Location = new Point(147, 86);
            lblMevcutStok.Name = "lblMevcutStok";
            lblMevcutStok.Size = new Size(0, 23);
            lblMevcutStok.TabIndex = 4;
            lblMevcutStok.Click += lblMevcutStok_Click;
            // 
            // txtAdet
            // 
            txtAdet.Location = new Point(89, 139);
            txtAdet.Margin = new Padding(3, 4, 3, 4);
            txtAdet.Name = "txtAdet";
            txtAdet.Size = new Size(151, 30);
            txtAdet.TabIndex = 3;
            // 
            // cmbUrun
            // 
            cmbUrun.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbUrun.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbUrun.FormattingEnabled = true;
            cmbUrun.Location = new Point(89, 41);
            cmbUrun.Margin = new Padding(3, 4, 3, 4);
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
            label4.Location = new Point(22, 49);
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
            groupBox4.Location = new Point(25, 26);
            groupBox4.Margin = new Padding(3, 4, 3, 4);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 4, 3, 4);
            groupBox4.Size = new Size(250, 311);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            groupBox4.Text = "Sevkiyat Bilgileri";
            // 
            // cmbCikisNedeni
            // 
            cmbCikisNedeni.FormattingEnabled = true;
            cmbCikisNedeni.Location = new Point(37, 251);
            cmbCikisNedeni.Margin = new Padding(3, 4, 3, 4);
            cmbCikisNedeni.Name = "cmbCikisNedeni";
            cmbCikisNedeni.Size = new Size(151, 31);
            cmbCikisNedeni.TabIndex = 5;
            // 
            // cmbMusteri
            // 
            cmbMusteri.FormattingEnabled = true;
            cmbMusteri.Location = new Point(37, 84);
            cmbMusteri.Margin = new Padding(3, 4, 3, 4);
            cmbMusteri.Name = "cmbMusteri";
            cmbMusteri.Size = new Size(151, 31);
            cmbMusteri.TabIndex = 4;
            // 
            // txtSiparisNo
            // 
            txtSiparisNo.Location = new Point(37, 161);
            txtSiparisNo.Margin = new Padding(3, 4, 3, 4);
            txtSiparisNo.Name = "txtSiparisNo";
            txtSiparisNo.Size = new Size(151, 30);
            txtSiparisNo.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(37, 225);
            label7.Name = "label7";
            label7.Size = new Size(110, 23);
            label7.TabIndex = 2;
            label7.Text = "Çıkış Nedeni";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(37, 135);
            label6.Name = "label6";
            label6.Size = new Size(97, 23);
            label6.TabIndex = 1;
            label6.Text = "Sipariş No:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(37, 56);
            label5.Name = "label5";
            label5.Size = new Size(76, 23);
            label5.TabIndex = 0;
            label5.Text = "Müşteri:";
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvSevkiyatListesi);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 4);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(788, 600);
            panel2.TabIndex = 3;
            // 
            // dgvSevkiyatListesi
            // 
            dgvSevkiyatListesi.AllowUserToAddRows = false;
            dgvSevkiyatListesi.AllowUserToDeleteRows = false;
            dgvSevkiyatListesi.BackgroundColor = Color.WhiteSmoke;
            dgvSevkiyatListesi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSevkiyatListesi.Dock = DockStyle.Fill;
            dgvSevkiyatListesi.Location = new Point(0, 0);
            dgvSevkiyatListesi.Margin = new Padding(3, 4, 3, 4);
            dgvSevkiyatListesi.Name = "dgvSevkiyatListesi";
            dgvSevkiyatListesi.ReadOnly = true;
            dgvSevkiyatListesi.RowHeadersWidth = 51;
            dgvSevkiyatListesi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSevkiyatListesi.Size = new Size(788, 600);
            dgvSevkiyatListesi.TabIndex = 1;
            dgvSevkiyatListesi.CellContentClick += dgvSevkiyatListesi_CellContentClick;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel3, 0, 1);
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(294, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 84F));
            tableLayoutPanel1.Size = new Size(794, 692);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.AutoSize = true;
            panel3.BackColor = SystemColors.ControlLightLight;
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 612);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(788, 76);
            panel3.TabIndex = 4;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnCikisiOnayla);
            panel4.Controls.Add(btnSil);
            panel4.Location = new Point(166, 0);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(431, 88);
            panel4.TabIndex = 2;
            // 
            // btnCikisiOnayla
            // 
            btnCikisiOnayla.BackColor = Color.LightSteelBlue;
            btnCikisiOnayla.FlatAppearance.BorderSize = 0;
            btnCikisiOnayla.FlatStyle = FlatStyle.Flat;
            btnCikisiOnayla.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnCikisiOnayla.ForeColor = SystemColors.ControlLightLight;
            btnCikisiOnayla.Location = new Point(29, 4);
            btnCikisiOnayla.Margin = new Padding(3, 4, 3, 4);
            btnCikisiOnayla.Name = "btnCikisiOnayla";
            btnCikisiOnayla.Size = new Size(182, 76);
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
            btnSil.Location = new Point(217, 4);
            btnSil.Margin = new Padding(3, 4, 3, 4);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(182, 76);
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
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmStokCikis";
            Load += frmStokCikis_Load;
            panel1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSevkiyatListesi).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private DataGridView dgvSevkiyatListesi;
        private Button btnListeyeEkle;
        private ComboBox cmbCikisNedeni;
        private ComboBox cmbMusteri;
        private TextBox txtSiparisNo;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel3;
        private Panel panel4;
        private Button btnCikisiOnayla;
        private Button btnSil;
    }
}