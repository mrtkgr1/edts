namespace EnvanterDepoSistemitaslak2
{
    partial class frmStokListele
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStokListele));
            panel1 = new Panel();
            panel3 = new Panel();
            label3 = new Label();
            btnExcelAktar = new Button();
            label2 = new Label();
            label1 = new Label();
            btnYenile = new Button();
            cmbDurumFiltresi = new ComboBox();
            cmbKategoriFiltresi = new ComboBox();
            txtArama = new TextBox();
            panel2 = new Panel();
            dgvStoklar = new DataGridView();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStoklar).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSlateGray;
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(935, 226);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLight;
            panel3.Controls.Add(label3);
            panel3.Controls.Add(btnExcelAktar);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(btnYenile);
            panel3.Controls.Add(cmbDurumFiltresi);
            panel3.Controls.Add(cmbKategoriFiltresi);
            panel3.Controls.Add(txtArama);
            panel3.Location = new Point(153, 47);
            panel3.Name = "panel3";
            panel3.Size = new Size(651, 162);
            panel3.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label3.Location = new Point(10, 59);
            label3.Name = "label3";
            label3.Size = new Size(82, 21);
            label3.TabIndex = 15;
            label3.Text = "Ürün Ara:";
            // 
            // btnExcelAktar
            // 
            btnExcelAktar.BackColor = Color.LightSlateGray;
            btnExcelAktar.BackgroundImage = (Image)resources.GetObject("btnExcelAktar.BackgroundImage");
            btnExcelAktar.BackgroundImageLayout = ImageLayout.Zoom;
            btnExcelAktar.FlatAppearance.BorderSize = 0;
            btnExcelAktar.FlatStyle = FlatStyle.Flat;
            btnExcelAktar.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnExcelAktar.ForeColor = SystemColors.ControlLightLight;
            btnExcelAktar.Location = new Point(425, 72);
            btnExcelAktar.Name = "btnExcelAktar";
            btnExcelAktar.Size = new Size(72, 36);
            btnExcelAktar.TabIndex = 14;
            btnExcelAktar.UseVisualStyleBackColor = false;
            btnExcelAktar.Click += btnExcelAktar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.Location = new Point(288, 59);
            label2.Name = "label2";
            label2.Size = new Size(122, 21);
            label2.TabIndex = 13;
            label2.Text = "Durum Filtresi:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label1.Location = new Point(150, 59);
            label1.Name = "label1";
            label1.Size = new Size(134, 21);
            label1.TabIndex = 12;
            label1.Text = "Kategori Filtresi:";
            // 
            // btnYenile
            // 
            btnYenile.BackColor = Color.LightSlateGray;
            btnYenile.BackgroundImage = (Image)resources.GetObject("btnYenile.BackgroundImage");
            btnYenile.BackgroundImageLayout = ImageLayout.Zoom;
            btnYenile.FlatAppearance.BorderSize = 0;
            btnYenile.FlatStyle = FlatStyle.Flat;
            btnYenile.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnYenile.ForeColor = SystemColors.ControlLightLight;
            btnYenile.Location = new Point(502, 72);
            btnYenile.Name = "btnYenile";
            btnYenile.Size = new Size(72, 36);
            btnYenile.TabIndex = 11;
            btnYenile.UseVisualStyleBackColor = false;
            btnYenile.Click += btnYenile_Click;
            // 
            // cmbDurumFiltresi
            // 
            cmbDurumFiltresi.FormattingEnabled = true;
            cmbDurumFiltresi.Location = new Point(288, 80);
            cmbDurumFiltresi.Name = "cmbDurumFiltresi";
            cmbDurumFiltresi.Size = new Size(133, 25);
            cmbDurumFiltresi.TabIndex = 10;
            // 
            // cmbKategoriFiltresi
            // 
            cmbKategoriFiltresi.FormattingEnabled = true;
            cmbKategoriFiltresi.Location = new Point(150, 80);
            cmbKategoriFiltresi.Name = "cmbKategoriFiltresi";
            cmbKategoriFiltresi.Size = new Size(133, 25);
            cmbKategoriFiltresi.TabIndex = 9;
            // 
            // txtArama
            // 
            txtArama.Location = new Point(10, 81);
            txtArama.Name = "txtArama";
            txtArama.Size = new Size(133, 25);
            txtArama.TabIndex = 8;
            txtArama.Text = "🔎";
            txtArama.TextChanged += txtArama_TextChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvStoklar);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 226);
            panel2.Name = "panel2";
            panel2.Size = new Size(935, 276);
            panel2.TabIndex = 1;
            // 
            // dgvStoklar
            // 
            dgvStoklar.AllowUserToAddRows = false;
            dgvStoklar.BackgroundColor = Color.WhiteSmoke;
            dgvStoklar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStoklar.Dock = DockStyle.Fill;
            dgvStoklar.Location = new Point(0, 0);
            dgvStoklar.Name = "dgvStoklar";
            dgvStoklar.RowHeadersWidth = 51;
            dgvStoklar.Size = new Size(935, 276);
            dgvStoklar.TabIndex = 0;
            dgvStoklar.CellFormatting += dgvStoklar_CellFormatting;
            // 
            // frmStokListele
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(935, 502);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmStokListele";
            Text = "Stok Listele";
            Load += frmStokListele_Load;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStoklar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Label label2;
        private Label label1;
        private Button btnYenile;
        private ComboBox cmbDurumFiltresi;
        private ComboBox cmbKategoriFiltresi;
        private TextBox txtArama;
        private Panel panel2;
        private DataGridView dgvStoklar;
        private Button btnExcelAktar;
        private Label label3;
    }
}