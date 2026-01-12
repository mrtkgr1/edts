namespace edts
{
    partial class frmDepoRapor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDepoRapor));
            panel1 = new Panel();
            panel3 = new Panel();
            label5 = new Label();
            txtHizliAra = new TextBox();
            btnFiltreTemizle = new Button();
            dtBitis = new DateTimePicker();
            dtBaslangic = new DateTimePicker();
            cmbUrunler = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            btnExcelAktar = new Button();
            btnRaporGetir = new Button();
            label1 = new Label();
            cmbIslemTipi = new ComboBox();
            panel2 = new Panel();
            dgvStokRaporu = new DataGridView();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStokRaporu).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSlateGray;
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1114, 305);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLightLight;
            panel3.Controls.Add(label5);
            panel3.Controls.Add(txtHizliAra);
            panel3.Controls.Add(btnFiltreTemizle);
            panel3.Controls.Add(dtBitis);
            panel3.Controls.Add(dtBaslangic);
            panel3.Controls.Add(cmbUrunler);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(btnExcelAktar);
            panel3.Controls.Add(btnRaporGetir);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(cmbIslemTipi);
            panel3.Location = new Point(80, 38);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(871, 256);
            panel3.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label5.Location = new Point(45, 219);
            label5.Name = "label5";
            label5.Size = new Size(128, 23);
            label5.TabIndex = 20;
            label5.Text = "Hızlı Ürün Ara:";
            // 
            // txtHizliAra
            // 
            txtHizliAra.Location = new Point(187, 215);
            txtHizliAra.Margin = new Padding(3, 4, 3, 4);
            txtHizliAra.Name = "txtHizliAra";
            txtHizliAra.Size = new Size(250, 27);
            txtHizliAra.TabIndex = 19;
            txtHizliAra.TextChanged += txtHizliAra_TextChanged;
            // 
            // btnFiltreTemizle
            // 
            btnFiltreTemizle.BackColor = Color.LightSlateGray;
            btnFiltreTemizle.FlatAppearance.BorderSize = 0;
            btnFiltreTemizle.FlatStyle = FlatStyle.Flat;
            btnFiltreTemizle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnFiltreTemizle.ForeColor = SystemColors.ControlLightLight;
            btnFiltreTemizle.Location = new Point(471, 144);
            btnFiltreTemizle.Margin = new Padding(3, 4, 3, 4);
            btnFiltreTemizle.Name = "btnFiltreTemizle";
            btnFiltreTemizle.Size = new Size(128, 34);
            btnFiltreTemizle.TabIndex = 18;
            btnFiltreTemizle.Text = "Filtreyi Sıfırla";
            btnFiltreTemizle.UseVisualStyleBackColor = false;
            btnFiltreTemizle.Click += btnFiltreTemizle_Click;
            // 
            // dtBitis
            // 
            dtBitis.Location = new Point(187, 116);
            dtBitis.Margin = new Padding(3, 4, 3, 4);
            dtBitis.Name = "dtBitis";
            dtBitis.Size = new Size(250, 27);
            dtBitis.TabIndex = 17;
            // 
            // dtBaslangic
            // 
            dtBaslangic.Location = new Point(187, 72);
            dtBaslangic.Margin = new Padding(3, 4, 3, 4);
            dtBaslangic.Name = "dtBaslangic";
            dtBaslangic.Size = new Size(250, 27);
            dtBaslangic.TabIndex = 16;
            // 
            // cmbUrunler
            // 
            cmbUrunler.FormattingEnabled = true;
            cmbUrunler.Location = new Point(187, 167);
            cmbUrunler.Margin = new Padding(3, 4, 3, 4);
            cmbUrunler.Name = "cmbUrunler";
            cmbUrunler.Size = new Size(250, 28);
            cmbUrunler.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label4.Location = new Point(47, 172);
            label4.Name = "label4";
            label4.Size = new Size(112, 23);
            label4.TabIndex = 14;
            label4.Text = "Ürün Seçimi:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label3.Location = new Point(47, 120);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 13;
            label3.Text = "Bitiş Tarihi:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.Location = new Point(45, 76);
            label2.Name = "label2";
            label2.Size = new Size(140, 23);
            label2.TabIndex = 12;
            label2.Text = "Başlangıç Tarihi:";
            // 
            // btnExcelAktar
            // 
            btnExcelAktar.BackColor = Color.LightSlateGray;
            btnExcelAktar.BackgroundImage = (Image)resources.GetObject("btnExcelAktar.BackgroundImage");
            btnExcelAktar.FlatAppearance.BorderSize = 0;
            btnExcelAktar.FlatStyle = FlatStyle.Flat;
            btnExcelAktar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnExcelAktar.ForeColor = SystemColors.ControlLightLight;
            btnExcelAktar.Location = new Point(471, 96);
            btnExcelAktar.Margin = new Padding(3, 4, 3, 4);
            btnExcelAktar.Name = "btnExcelAktar";
            btnExcelAktar.Size = new Size(128, 34);
            btnExcelAktar.TabIndex = 11;
            btnExcelAktar.Text = "Excel'e Aktar";
            btnExcelAktar.UseVisualStyleBackColor = false;
            btnExcelAktar.Click += btnExcelAktar_Click;
            // 
            // btnRaporGetir
            // 
            btnRaporGetir.BackColor = Color.LightSlateGray;
            btnRaporGetir.FlatAppearance.BorderSize = 0;
            btnRaporGetir.FlatStyle = FlatStyle.Flat;
            btnRaporGetir.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnRaporGetir.ForeColor = SystemColors.ControlLightLight;
            btnRaporGetir.Location = new Point(471, 49);
            btnRaporGetir.Margin = new Padding(3, 4, 3, 4);
            btnRaporGetir.Name = "btnRaporGetir";
            btnRaporGetir.Size = new Size(128, 35);
            btnRaporGetir.TabIndex = 10;
            btnRaporGetir.Text = "Raporu Getir";
            btnRaporGetir.UseVisualStyleBackColor = false;
            btnRaporGetir.Click += btnRaporGetir_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label1.Location = new Point(47, 31);
            label1.Name = "label1";
            label1.Size = new Size(93, 23);
            label1.TabIndex = 9;
            label1.Text = "İşlem Tipi:";
            // 
            // cmbIslemTipi
            // 
            cmbIslemTipi.FormattingEnabled = true;
            cmbIslemTipi.Location = new Point(187, 25);
            cmbIslemTipi.Margin = new Padding(3, 4, 3, 4);
            cmbIslemTipi.Name = "cmbIslemTipi";
            cmbIslemTipi.Size = new Size(250, 28);
            cmbIslemTipi.TabIndex = 8;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvStokRaporu);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 305);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1114, 430);
            panel2.TabIndex = 1;
            // 
            // dgvStokRaporu
            // 
            dgvStokRaporu.AllowUserToAddRows = false;
            dgvStokRaporu.BackgroundColor = Color.WhiteSmoke;
            dgvStokRaporu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStokRaporu.Dock = DockStyle.Fill;
            dgvStokRaporu.Location = new Point(0, 0);
            dgvStokRaporu.Margin = new Padding(3, 4, 3, 4);
            dgvStokRaporu.Name = "dgvStokRaporu";
            dgvStokRaporu.RowHeadersWidth = 51;
            dgvStokRaporu.Size = new Size(1114, 430);
            dgvStokRaporu.TabIndex = 1;
            dgvStokRaporu.CellFormatting += dgvStokRaporu_CellFormatting;
            // 
            // frmDepoRapor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1114, 735);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmDepoRapor";
            Text = "Depo Rapor";
            Load += frmDepoRapor_Load;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStokRaporu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private ComboBox cmbUrunler;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnExcelAktar;
        private Button btnRaporGetir;
        private Label label1;
        private ComboBox cmbIslemTipi;
        private DateTimePicker dtBitis;
        private DateTimePicker dtBaslangic;
        private DataGridView dgvStokRaporu;
        private Button btnFiltreTemizle;
        private TextBox txtHizliAra;
        private Label label5;
    }
}