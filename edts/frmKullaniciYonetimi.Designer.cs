namespace edts
{
    partial class frmKullaniciYonetimi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKullaniciYonetimi));
            panel2 = new Panel();
            dgvKullaniciListesi = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            resizableButton1 = new ResizableButton();
            flowLayoutPanel2 = new FlowLayoutPanel();
            resizableButton4 = new ResizableButton();
            resizableButtonExcel = new ResizableButton();
            panel1 = new Panel();
            resizableButtonFiltreSil = new ResizableButton();
            resizableButtonAra = new ResizableButton();
            textBoxArama = new TextBox();
            comboBoxRol = new ComboBox();
            comboBoxAktif = new ComboBox();
            comboBoxSirala = new ComboBox();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKullaniciListesi).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvKullaniciListesi);
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(981, 655);
            panel2.TabIndex = 1;
            // 
            // dgvKullaniciListesi
            // 
            dgvKullaniciListesi.AllowUserToAddRows = false;
            dgvKullaniciListesi.AllowUserToDeleteRows = false;
            dgvKullaniciListesi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKullaniciListesi.BackgroundColor = Color.WhiteSmoke;
            dgvKullaniciListesi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKullaniciListesi.Dock = DockStyle.Fill;
            dgvKullaniciListesi.Location = new Point(0, 54);
            dgvKullaniciListesi.Margin = new Padding(3, 4, 3, 4);
            dgvKullaniciListesi.Name = "dgvKullaniciListesi";
            dgvKullaniciListesi.ReadOnly = true;
            dgvKullaniciListesi.RowHeadersVisible = false;
            dgvKullaniciListesi.RowHeadersWidth = 51;
            dgvKullaniciListesi.Size = new Size(981, 601);
            dgvKullaniciListesi.TabIndex = 0;
            dgvKullaniciListesi.CellContentClick += dgvKullaniciListesi_CellContentClick;
            dgvKullaniciListesi.CellDoubleClick += dgvKullaniciListesi_CellDouble;
            dgvKullaniciListesi.CellFormatting += dgvKullaniciListesi_CellFormatting;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            tableLayoutPanel1.Size = new Size(981, 54);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(resizableButton1);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(160, 54);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // resizableButton1
            // 
            resizableButton1.Image = (Image)resources.GetObject("resizableButton1.Image");
            resizableButton1.ImageAlign = ContentAlignment.MiddleLeft;
            resizableButton1.KaynakResim = (Image)resources.GetObject("resizableButton1.KaynakResim");
            resizableButton1.Location = new Point(3, 4);
            resizableButton1.Margin = new Padding(3, 4, 3, 4);
            resizableButton1.Name = "resizableButton1";
            resizableButton1.ResimBoyutu = 32;
            resizableButton1.Size = new Size(153, 45);
            resizableButton1.TabIndex = 0;
            resizableButton1.Text = "     Kullanıcı ekle";
            resizableButton1.UseVisualStyleBackColor = true;
            resizableButton1.Click += resizableButton1_Click;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel2.Controls.Add(resizableButton4);
            flowLayoutPanel2.Controls.Add(resizableButtonExcel);
            flowLayoutPanel2.Controls.Add(panel1);
            flowLayoutPanel2.Controls.Add(resizableButtonFiltreSil);
            flowLayoutPanel2.Controls.Add(resizableButtonAra);
            flowLayoutPanel2.Controls.Add(textBoxArama);
            flowLayoutPanel2.Controls.Add(comboBoxRol);
            flowLayoutPanel2.Controls.Add(comboBoxAktif);
            flowLayoutPanel2.Controls.Add(comboBoxSirala);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel2.Location = new Point(160, 0);
            flowLayoutPanel2.Margin = new Padding(0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(821, 54);
            flowLayoutPanel2.TabIndex = 1;
            // 
            // resizableButton4
            // 
            resizableButton4.Image = (Image)resources.GetObject("resizableButton4.Image");
            resizableButton4.KaynakResim = (Image)resources.GetObject("resizableButton4.KaynakResim");
            resizableButton4.Location = new Point(775, 4);
            resizableButton4.Margin = new Padding(3, 4, 3, 4);
            resizableButton4.Name = "resizableButton4";
            resizableButton4.ResimBoyutu = 32;
            resizableButton4.Size = new Size(43, 45);
            resizableButton4.TabIndex = 9;
            resizableButton4.TabStop = false;
            resizableButton4.UseVisualStyleBackColor = true;
            resizableButton4.Click += resizableButton4_Click;
            // 
            // resizableButtonExcel
            // 
            resizableButtonExcel.Image = (Image)resources.GetObject("resizableButtonExcel.Image");
            resizableButtonExcel.KaynakResim = (Image)resources.GetObject("resizableButtonExcel.KaynakResim");
            resizableButtonExcel.Location = new Point(726, 4);
            resizableButtonExcel.Margin = new Padding(3, 4, 3, 4);
            resizableButtonExcel.Name = "resizableButtonExcel";
            resizableButtonExcel.ResimBoyutu = 32;
            resizableButtonExcel.Size = new Size(43, 45);
            resizableButtonExcel.TabIndex = 5;
            resizableButtonExcel.TabStop = false;
            resizableButtonExcel.UseVisualStyleBackColor = true;
            resizableButtonExcel.Click += resizableButtonyenile_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveBorder;
            panel1.Location = new Point(718, 4);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(2, 44);
            panel1.TabIndex = 6;
            // 
            // resizableButtonFiltreSil
            // 
            resizableButtonFiltreSil.Enabled = false;
            resizableButtonFiltreSil.Image = (Image)resources.GetObject("resizableButtonFiltreSil.Image");
            resizableButtonFiltreSil.KaynakResim = (Image)resources.GetObject("resizableButtonFiltreSil.KaynakResim");
            resizableButtonFiltreSil.Location = new Point(669, 4);
            resizableButtonFiltreSil.Margin = new Padding(3, 4, 3, 4);
            resizableButtonFiltreSil.Name = "resizableButtonFiltreSil";
            resizableButtonFiltreSil.ResimBoyutu = 32;
            resizableButtonFiltreSil.Size = new Size(43, 45);
            resizableButtonFiltreSil.TabIndex = 10;
            resizableButtonFiltreSil.TabStop = false;
            resizableButtonFiltreSil.UseVisualStyleBackColor = true;
            resizableButtonFiltreSil.Click += resizableButtonFiltreSil_Click;
            // 
            // resizableButtonAra
            // 
            resizableButtonAra.Image = (Image)resources.GetObject("resizableButtonAra.Image");
            resizableButtonAra.KaynakResim = (Image)resources.GetObject("resizableButtonAra.KaynakResim");
            resizableButtonAra.Location = new Point(620, 4);
            resizableButtonAra.Margin = new Padding(3, 4, 3, 4);
            resizableButtonAra.Name = "resizableButtonAra";
            resizableButtonAra.ResimBoyutu = 32;
            resizableButtonAra.Size = new Size(43, 45);
            resizableButtonAra.TabIndex = 4;
            resizableButtonAra.UseVisualStyleBackColor = true;
            resizableButtonAra.Click += resizableButtonAra_Click;
            // 
            // textBoxArama
            // 
            textBoxArama.Font = new Font("Segoe UI", 9F);
            textBoxArama.Location = new Point(458, 12);
            textBoxArama.Margin = new Padding(3, 12, 3, 4);
            textBoxArama.MaxLength = 50;
            textBoxArama.Name = "textBoxArama";
            textBoxArama.Size = new Size(156, 27);
            textBoxArama.TabIndex = 1;
            textBoxArama.TextChanged += textBoxArama_TextChanged;
            // 
            // comboBoxRol
            // 
            comboBoxRol.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRol.FormattingEnabled = true;
            comboBoxRol.Location = new Point(338, 12);
            comboBoxRol.Margin = new Padding(3, 12, 3, 4);
            comboBoxRol.Name = "comboBoxRol";
            comboBoxRol.Size = new Size(114, 28);
            comboBoxRol.TabIndex = 7;
            comboBoxRol.SelectedIndexChanged += comboBoxRol_SelectedIndexChanged;
            // 
            // comboBoxAktif
            // 
            comboBoxAktif.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAktif.FormattingEnabled = true;
            comboBoxAktif.Items.AddRange(new object[] { "Aktif/Pasif", "Aktif", "Pasif" });
            comboBoxAktif.Location = new Point(218, 12);
            comboBoxAktif.Margin = new Padding(3, 12, 3, 4);
            comboBoxAktif.Name = "comboBoxAktif";
            comboBoxAktif.Size = new Size(114, 28);
            comboBoxAktif.TabIndex = 8;
            comboBoxAktif.SelectedIndexChanged += comboBoxAktif_SelectedIndexChanged;
            // 
            // comboBoxSirala
            // 
            comboBoxSirala.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSirala.FormattingEnabled = true;
            comboBoxSirala.Items.AddRange(new object[] { "Eskiden Yeniye", "Yeniden Eskiye", "Kullanici Adı (A→Z)", "Kullanici Adı (Z→A)", "İsim (A→Z)", "İsim (Z→A)", "Rol" });
            comboBoxSirala.Location = new Point(65, 12);
            comboBoxSirala.Margin = new Padding(3, 12, 3, 4);
            comboBoxSirala.Name = "comboBoxSirala";
            comboBoxSirala.Size = new Size(147, 28);
            comboBoxSirala.TabIndex = 11;
            comboBoxSirala.SelectedIndexChanged += comboBoxSirala_SelectedIndexChanged;
            // 
            // frmKullaniciYonetimi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(981, 655);
            Controls.Add(panel2);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmKullaniciYonetimi";
            Load += frmKullaniciYonetimi_Load;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKullaniciListesi).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private DataGridView dgvKullaniciListesi;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private TextBox textBoxArama;
        private ResizableButton resizableButton1;
        private ResizableButton resizableButtonExcel;
        private Panel panel1;
        private ResizableButton resizableButtonAra;
        private ComboBox comboBoxRol;
        private ComboBox comboBoxAktif;
        private ResizableButton resizableButton4;
        private ResizableButton resizableButtonFiltreSil;
        private ComboBox comboBoxSirala;
    }

}