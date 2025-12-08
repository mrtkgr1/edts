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
            cmbUrunSecim = new ComboBox();
            txtGelenMiktar = new TextBox();
            txtIrsaliyeNo = new TextBox();
            btnSepeteEkle = new Button();
            dgvKabulListesi = new DataGridView();
            btnKaydet = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvKabulListesi).BeginInit();
            SuspendLayout();
            // 
            // cmbUrunSecim
            // 
            cmbUrunSecim.FormattingEnabled = true;
            cmbUrunSecim.Location = new Point(171, 43);
            cmbUrunSecim.Name = "cmbUrunSecim";
            cmbUrunSecim.Size = new Size(151, 28);
            cmbUrunSecim.TabIndex = 0;
            // 
            // txtGelenMiktar
            // 
            txtGelenMiktar.Location = new Point(171, 93);
            txtGelenMiktar.Name = "txtGelenMiktar";
            txtGelenMiktar.Size = new Size(125, 27);
            txtGelenMiktar.TabIndex = 1;
            // 
            // txtIrsaliyeNo
            // 
            txtIrsaliyeNo.Location = new Point(168, 144);
            txtIrsaliyeNo.Name = "txtIrsaliyeNo";
            txtIrsaliyeNo.Size = new Size(125, 27);
            txtIrsaliyeNo.TabIndex = 2;
            // 
            // btnSepeteEkle
            // 
            btnSepeteEkle.Location = new Point(315, 142);
            btnSepeteEkle.Name = "btnSepeteEkle";
            btnSepeteEkle.Size = new Size(94, 29);
            btnSepeteEkle.TabIndex = 3;
            btnSepeteEkle.Text = "Ekle";
            btnSepeteEkle.UseVisualStyleBackColor = true;
            // 
            // dgvKabulListesi
            // 
            dgvKabulListesi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKabulListesi.Location = new Point(175, 186);
            dgvKabulListesi.Name = "dgvKabulListesi";
            dgvKabulListesi.RowHeadersWidth = 51;
            dgvKabulListesi.Size = new Size(300, 188);
            dgvKabulListesi.TabIndex = 4;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(459, 139);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(94, 29);
            btnKaydet.TabIndex = 5;
            btnKaydet.Text = "button1";
            btnKaydet.UseVisualStyleBackColor = true;
            // 
            // frmStokGiris
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnKaydet);
            Controls.Add(dgvKabulListesi);
            Controls.Add(btnSepeteEkle);
            Controls.Add(txtIrsaliyeNo);
            Controls.Add(txtGelenMiktar);
            Controls.Add(cmbUrunSecim);
            Name = "frmStokGiris";
            Text = "frmStokGiris";
            ((System.ComponentModel.ISupportInitialize)dgvKabulListesi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbUrunSecim;
        private TextBox txtGelenMiktar;
        private TextBox txtIrsaliyeNo;
        private Button btnSepeteEkle;
        private DataGridView dgvKabulListesi;
        private Button btnKaydet;
    }
}