namespace edts
{
    partial class frmSatisFatura
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
            panel2 = new Panel();
            dgvSatislar = new DataGridView();
            tabPage5 = new TabPage();
            lblGenelToplam = new Label();
            btnSatisOnay = new Button();
            btnSepetEkle = new Button();
            label14 = new Label();
            cmbMusteri = new ComboBox();
            label13 = new Label();
            nmrSatisAdet = new NumericUpDown();
            txtUrunBarkod = new TextBox();
            label12 = new Label();
            panel1 = new Panel();
            label1 = new Label();
            dgvSepet = new DataGridView();
            tabControl1 = new TabControl();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSatislar).BeginInit();
            tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmrSatisAdet).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSepet).BeginInit();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvSatislar);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(796, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(521, 906);
            panel2.TabIndex = 5;
            // 
            // dgvSatislar
            // 
            dgvSatislar.AllowUserToAddRows = false;
            dgvSatislar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSatislar.BackgroundColor = Color.WhiteSmoke;
            dgvSatislar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSatislar.Dock = DockStyle.Fill;
            dgvSatislar.Location = new Point(0, 0);
            dgvSatislar.Name = "dgvSatislar";
            dgvSatislar.RowHeadersWidth = 51;
            dgvSatislar.Size = new Size(521, 906);
            dgvSatislar.TabIndex = 0;
            dgvSatislar.CellContentClick += dgvSatislar_CellContentClick;
            // 
            // tabPage5
            // 
            tabPage5.BackColor = Color.LightSlateGray;
            tabPage5.Controls.Add(lblGenelToplam);
            tabPage5.Controls.Add(btnSatisOnay);
            tabPage5.Controls.Add(btnSepetEkle);
            tabPage5.Controls.Add(label14);
            tabPage5.Controls.Add(cmbMusteri);
            tabPage5.Controls.Add(label13);
            tabPage5.Controls.Add(nmrSatisAdet);
            tabPage5.Controls.Add(txtUrunBarkod);
            tabPage5.Controls.Add(label12);
            tabPage5.Location = new Point(4, 37);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(727, 382);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Satış/Fatura";
            // 
            // lblGenelToplam
            // 
            lblGenelToplam.AutoSize = true;
            lblGenelToplam.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblGenelToplam.ForeColor = SystemColors.ControlLightLight;
            lblGenelToplam.Location = new Point(310, 312);
            lblGenelToplam.Name = "lblGenelToplam";
            lblGenelToplam.Size = new Size(0, 23);
            lblGenelToplam.TabIndex = 10;
            // 
            // btnSatisOnay
            // 
            btnSatisOnay.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnSatisOnay.Location = new Point(299, 250);
            btnSatisOnay.Name = "btnSatisOnay";
            btnSatisOnay.Size = new Size(124, 44);
            btnSatisOnay.TabIndex = 9;
            btnSatisOnay.Text = "Satışı Onayla";
            btnSatisOnay.UseVisualStyleBackColor = true;
            btnSatisOnay.Click += btnSatisOnay_Click;
            // 
            // btnSepetEkle
            // 
            btnSepetEkle.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnSepetEkle.Location = new Point(82, 250);
            btnSepetEkle.Name = "btnSepetEkle";
            btnSepetEkle.Size = new Size(124, 44);
            btnSepetEkle.TabIndex = 8;
            btnSepetEkle.Text = "Sepete Ekle";
            btnSepetEkle.UseVisualStyleBackColor = true;
            btnSepetEkle.Click += btnSepetEkle_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label14.ForeColor = SystemColors.ControlLightLight;
            label14.Location = new Point(44, 155);
            label14.Name = "label14";
            label14.Size = new Size(134, 23);
            label14.TabIndex = 5;
            label14.Text = "Müşteri Seçimi:";
            // 
            // cmbMusteri
            // 
            cmbMusteri.FormattingEnabled = true;
            cmbMusteri.Location = new Point(188, 151);
            cmbMusteri.Name = "cmbMusteri";
            cmbMusteri.Size = new Size(215, 36);
            cmbMusteri.TabIndex = 4;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label13.ForeColor = SystemColors.ControlLightLight;
            label13.Location = new Point(44, 94);
            label13.Name = "label13";
            label13.Size = new Size(127, 23);
            label13.TabIndex = 3;
            label13.Text = "Miktar Seçimi:";
            // 
            // nmrSatisAdet
            // 
            nmrSatisAdet.Location = new Point(188, 88);
            nmrSatisAdet.Name = "nmrSatisAdet";
            nmrSatisAdet.Size = new Size(215, 34);
            nmrSatisAdet.TabIndex = 2;
            // 
            // txtUrunBarkod
            // 
            txtUrunBarkod.Location = new Point(188, 30);
            txtUrunBarkod.Name = "txtUrunBarkod";
            txtUrunBarkod.Size = new Size(215, 34);
            txtUrunBarkod.TabIndex = 1;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label12.ForeColor = SystemColors.ControlLightLight;
            label12.Location = new Point(44, 37);
            label12.Name = "label12";
            label12.Size = new Size(127, 23);
            label12.TabIndex = 0;
            label12.Text = "Ürün Barkodu:";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dgvSepet);
            panel1.Controls.Add(tabControl1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(796, 906);
            panel1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.DarkGray;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(309, 23);
            label1.Name = "label1";
            label1.Size = new Size(114, 25);
            label1.TabIndex = 4;
            label1.Text = "Geçici Tablo";
            // 
            // dgvSepet
            // 
            dgvSepet.AllowUserToAddRows = false;
            dgvSepet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSepet.Location = new Point(16, 40);
            dgvSepet.Name = "dgvSepet";
            dgvSepet.RowHeadersWidth = 51;
            dgvSepet.Size = new Size(735, 408);
            dgvSepet.TabIndex = 3;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            tabControl1.Location = new Point(16, 455);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(735, 423);
            tabControl1.TabIndex = 2;
            // 
            // frmSatisFatura
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1317, 906);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmSatisFatura";
            Text = "frmSatisFatura";
            Load += frmSatisFatura_Load;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSatislar).EndInit();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmrSatisAdet).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSepet).EndInit();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private DataGridView dgvSatislar;
        private TabPage tabPage5;
        private Button btnSatisOnay;
        private Button btnSepetEkle;
        private Label label14;
        private ComboBox cmbMusteri;
        private Label label13;
        private NumericUpDown nmrSatisAdet;
        private TextBox txtUrunBarkod;
        private Label label12;
        private Panel panel1;
        private TabControl tabControl1;
        private DataGridView dgvSepet;
        private Label label1;
        private Label lblGenelToplam;
    }
}