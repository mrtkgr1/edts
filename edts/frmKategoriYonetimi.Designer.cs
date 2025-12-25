namespace edts
{
    partial class frmKategoriYonetimi
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
            lblKategoriAdi = new Label();
            panel2 = new Panel();
            dataGridView2 = new DataGridView();
            txtKategoriAdi = new TextBox();
            panel1 = new Panel();
            tabControl1 = new TabControl();
            tabPage2 = new TabPage();
            btnKategoriSill = new KavisliButon();
            btnKategoriGuncellee = new KavisliButon();
            btnKategoriKaydett = new KavisliButon();
            txtKategoriAciklama = new TextBox();
            lblAciklama = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // lblKategoriAdi
            // 
            lblKategoriAdi.AutoSize = true;
            lblKategoriAdi.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblKategoriAdi.ForeColor = SystemColors.ControlLightLight;
            lblKategoriAdi.Location = new Point(36, 65);
            lblKategoriAdi.Name = "lblKategoriAdi";
            lblKategoriAdi.Size = new Size(117, 23);
            lblKategoriAdi.TabIndex = 0;
            lblKategoriAdi.Text = "Kategori Adı:";
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(653, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(613, 710);
            panel2.TabIndex = 5;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.Location = new Point(0, 0);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(613, 710);
            dataGridView2.TabIndex = 0;
            dataGridView2.CellClick += dataGridView2_CellClick;
            // 
            // txtKategoriAdi
            // 
            txtKategoriAdi.Location = new Point(156, 57);
            txtKategoriAdi.Margin = new Padding(3, 4, 3, 4);
            txtKategoriAdi.Name = "txtKategoriAdi";
            txtKategoriAdi.Size = new Size(347, 30);
            txtKategoriAdi.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(tabControl1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(653, 710);
            panel1.TabIndex = 4;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            tabControl1.Location = new Point(6, 131);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(644, 556);
            tabControl1.TabIndex = 2;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.LightSlateGray;
            tabPage2.Controls.Add(btnKategoriSill);
            tabPage2.Controls.Add(btnKategoriGuncellee);
            tabPage2.Controls.Add(btnKategoriKaydett);
            tabPage2.Controls.Add(txtKategoriAciklama);
            tabPage2.Controls.Add(lblAciklama);
            tabPage2.Controls.Add(txtKategoriAdi);
            tabPage2.Controls.Add(lblKategoriAdi);
            tabPage2.Location = new Point(4, 32);
            tabPage2.Margin = new Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 4, 3, 4);
            tabPage2.Size = new Size(636, 520);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Kategori Tanımlama";
            // 
            // btnKategoriSill
            // 
            btnKategoriSill.BorderRadius = 30;
            btnKategoriSill.FlatStyle = FlatStyle.System;
            btnKategoriSill.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnKategoriSill.Location = new Point(388, 411);
            btnKategoriSill.Name = "btnKategoriSill";
            btnKategoriSill.Size = new Size(101, 39);
            btnKategoriSill.TabIndex = 9;
            btnKategoriSill.Text = "Sil";
            btnKategoriSill.UseVisualStyleBackColor = true;
            btnKategoriSill.Click += btnKategoriSill_Click;
            // 
            // btnKategoriGuncellee
            // 
            btnKategoriGuncellee.BorderRadius = 30;
            btnKategoriGuncellee.FlatStyle = FlatStyle.System;
            btnKategoriGuncellee.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnKategoriGuncellee.Location = new Point(281, 411);
            btnKategoriGuncellee.Name = "btnKategoriGuncellee";
            btnKategoriGuncellee.Size = new Size(101, 39);
            btnKategoriGuncellee.TabIndex = 8;
            btnKategoriGuncellee.Text = "Güncelle";
            btnKategoriGuncellee.UseVisualStyleBackColor = true;
            btnKategoriGuncellee.Click += btnKategoriGuncellee_Click;
            // 
            // btnKategoriKaydett
            // 
            btnKategoriKaydett.BorderRadius = 30;
            btnKategoriKaydett.FlatStyle = FlatStyle.System;
            btnKategoriKaydett.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnKategoriKaydett.Location = new Point(174, 411);
            btnKategoriKaydett.Name = "btnKategoriKaydett";
            btnKategoriKaydett.Size = new Size(101, 39);
            btnKategoriKaydett.TabIndex = 7;
            btnKategoriKaydett.Text = "Kaydet";
            btnKategoriKaydett.UseVisualStyleBackColor = true;
            btnKategoriKaydett.Click += btnKategoriKaydett_Click;
            // 
            // txtKategoriAciklama
            // 
            txtKategoriAciklama.Location = new Point(153, 104);
            txtKategoriAciklama.Margin = new Padding(3, 4, 3, 4);
            txtKategoriAciklama.Multiline = true;
            txtKategoriAciklama.Name = "txtKategoriAciklama";
            txtKategoriAciklama.ScrollBars = ScrollBars.Vertical;
            txtKategoriAciklama.Size = new Size(350, 300);
            txtKategoriAciklama.TabIndex = 3;
            // 
            // lblAciklama
            // 
            lblAciklama.AutoSize = true;
            lblAciklama.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblAciklama.ForeColor = SystemColors.ControlLightLight;
            lblAciklama.Location = new Point(59, 112);
            lblAciklama.Name = "lblAciklama";
            lblAciklama.Size = new Size(94, 23);
            lblAciklama.TabIndex = 2;
            lblAciklama.Text = "Açıklama :";
            // 
            // frmKategoriYonetimi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1266, 710);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmKategoriYonetimi";
            Text = "frmKategoriYonetimi";
            Load += frmKategoriYonetimi_Load;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            panel1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblKategoriAdi;
        private Panel panel2;
        private DataGridView dataGridView2;
        private TextBox txtKategoriAdi;
        private Panel panel1;
        private TabControl tabControl1;
        private TabPage tabPage2;
        private KavisliButon btnKategoriSill;
        private KavisliButon btnKategoriGuncellee;
        private KavisliButon btnKategoriKaydett;
        private TextBox txtKategoriAciklama;
        private Label lblAciklama;
    }
}