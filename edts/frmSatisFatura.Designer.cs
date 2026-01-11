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
        private void InitializeComponent() {
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
            panel2.Location = new Point(696, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(456, 770);
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
            dgvSatislar.Size = new Size(456, 770);
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
            tabPage5.Location = new Point(4, 34);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(635, 322);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Satış/Fatura";
            // 
            // lblGenelToplam
            // 
            lblGenelToplam.AutoSize = true;
            lblGenelToplam.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblGenelToplam.ForeColor = SystemColors.ControlLightLight;
            lblGenelToplam.Location = new Point(271, 265);
            lblGenelToplam.Name = "lblGenelToplam";
            lblGenelToplam.Size = new Size(0, 21);
            lblGenelToplam.TabIndex = 10;
            // 
            // btnSatisOnay
            // 
            btnSatisOnay.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnSatisOnay.Location = new Point(262, 212);
            btnSatisOnay.Name = "btnSatisOnay";
            btnSatisOnay.Size = new Size(108, 37);
            btnSatisOnay.TabIndex = 9;
            btnSatisOnay.Text = "Satışı Onayla";
            btnSatisOnay.UseVisualStyleBackColor = true;
            btnSatisOnay.Click += btnSatisOnay_Click;
            // 
            // btnSepetEkle
            // 
            btnSepetEkle.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnSepetEkle.Location = new Point(72, 212);
            btnSepetEkle.Name = "btnSepetEkle";
            btnSepetEkle.Size = new Size(108, 37);
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
            label14.Location = new Point(38, 132);
            label14.Name = "label14";
            label14.Size = new Size(127, 21);
            label14.TabIndex = 5;
            label14.Text = "Müşteri Seçimi:";
            // 
            // cmbMusteri
            // 
            cmbMusteri.FormattingEnabled = true;
            cmbMusteri.Location = new Point(164, 128);
            cmbMusteri.Name = "cmbMusteri";
            cmbMusteri.Size = new Size(189, 33);
            cmbMusteri.TabIndex = 4;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label13.ForeColor = SystemColors.ControlLightLight;
            label13.Location = new Point(38, 80);
            label13.Name = "label13";
            label13.Size = new Size(119, 21);
            label13.TabIndex = 3;
            label13.Text = "Miktar Seçimi:";
            // 
            // nmrSatisAdet
            // 
            nmrSatisAdet.Location = new Point(164, 75);
            nmrSatisAdet.Name = "nmrSatisAdet";
            nmrSatisAdet.Size = new Size(188, 31);
            nmrSatisAdet.TabIndex = 2;
            // 
            // txtUrunBarkod
            // 
            txtUrunBarkod.Location = new Point(164, 26);
            txtUrunBarkod.Name = "txtUrunBarkod";
            txtUrunBarkod.Size = new Size(189, 31);
            txtUrunBarkod.TabIndex = 1;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label12.ForeColor = SystemColors.ControlLightLight;
            label12.Location = new Point(38, 31);
            label12.Name = "label12";
            label12.Size = new Size(120, 21);
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
            panel1.Size = new Size(696, 770);
            panel1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.DarkGray;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(270, 20);
            label1.Name = "label1";
            label1.Size = new Size(102, 21);
            label1.TabIndex = 4;
            label1.Text = "Geçici Tablo";
            // 
            // dgvSepet
            // 
            dgvSepet.AllowUserToAddRows = false;
            dgvSepet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSepet.Location = new Point(14, 34);
            dgvSepet.Name = "dgvSepet";
            dgvSepet.RowHeadersWidth = 51;
            dgvSepet.Size = new Size(643, 347);
            dgvSepet.TabIndex = 3;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            tabControl1.Location = new Point(14, 387);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(643, 360);
            tabControl1.TabIndex = 2;
            // 
            // frmSatisFatura
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1152, 770);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmSatisFatura";
            Text = "Satış / Fatura";
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