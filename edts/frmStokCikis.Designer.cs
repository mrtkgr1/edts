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
            cmbMusteri = new ComboBox();
            cmbIslemNedeni = new ComboBox();
            txtMiktar = new TextBox();
            btnSepeteEkle = new Button();
            dgvSevkiyatListesi = new DataGridView();
            btnCikisYap = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSevkiyatListesi).BeginInit();
            SuspendLayout();
            // 
            // cmbMusteri
            // 
            cmbMusteri.FormattingEnabled = true;
            cmbMusteri.Location = new Point(163, 48);
            cmbMusteri.Name = "cmbMusteri";
            cmbMusteri.Size = new Size(151, 28);
            cmbMusteri.TabIndex = 0;
            // 
            // cmbIslemNedeni
            // 
            cmbIslemNedeni.FormattingEnabled = true;
            cmbIslemNedeni.Location = new Point(160, 90);
            cmbIslemNedeni.Name = "cmbIslemNedeni";
            cmbIslemNedeni.Size = new Size(151, 28);
            cmbIslemNedeni.TabIndex = 1;
            // 
            // txtMiktar
            // 
            txtMiktar.Location = new Point(182, 135);
            txtMiktar.Name = "txtMiktar";
            txtMiktar.Size = new Size(125, 27);
            txtMiktar.TabIndex = 2;
            // 
            // btnSepeteEkle
            // 
            btnSepeteEkle.Location = new Point(334, 138);
            btnSepeteEkle.Name = "btnSepeteEkle";
            btnSepeteEkle.Size = new Size(94, 29);
            btnSepeteEkle.TabIndex = 3;
            btnSepeteEkle.Text = "button1";
            btnSepeteEkle.UseVisualStyleBackColor = true;
            // 
            // dgvSevkiyatListesi
            // 
            dgvSevkiyatListesi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSevkiyatListesi.Location = new Point(194, 193);
            dgvSevkiyatListesi.Name = "dgvSevkiyatListesi";
            dgvSevkiyatListesi.RowHeadersWidth = 51;
            dgvSevkiyatListesi.Size = new Size(300, 188);
            dgvSevkiyatListesi.TabIndex = 4;
            // 
            // btnCikisYap
            // 
            btnCikisYap.Location = new Point(449, 134);
            btnCikisYap.Name = "btnCikisYap";
            btnCikisYap.Size = new Size(94, 29);
            btnCikisYap.TabIndex = 5;
            btnCikisYap.Text = "button1";
            btnCikisYap.UseVisualStyleBackColor = true;
            // 
            // frmStokCikis
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCikisYap);
            Controls.Add(dgvSevkiyatListesi);
            Controls.Add(btnSepeteEkle);
            Controls.Add(txtMiktar);
            Controls.Add(cmbIslemNedeni);
            Controls.Add(cmbMusteri);
            Name = "frmStokCikis";
            Text = "frmStokCikis";
            ((System.ComponentModel.ISupportInitialize)dgvSevkiyatListesi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbMusteri;
        private ComboBox cmbIslemNedeni;
        private TextBox txtMiktar;
        private Button btnSepeteEkle;
        private DataGridView dgvSevkiyatListesi;
        private Button btnCikisYap;
    }
}