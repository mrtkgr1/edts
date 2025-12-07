namespace EnvanterDepoSistemitaslak2
{
    partial class frmDepoHomeIcerik
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDepoHomeIcerik));
            tblHomeLayout = new TableLayoutPanel();
            lblTalimat = new Label();
            lblTarihSaat = new Label();
            lblRol = new Label();
            lblHosGeldiniz = new Label();
            lblBaslik = new Label();
            pbLogo = new PictureBox();
            tblHomeLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // tblHomeLayout
            // 
            tblHomeLayout.ColumnCount = 2;
            tblHomeLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.375F));
            tblHomeLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.625F));
            tblHomeLayout.Controls.Add(lblRol, 0, 2);
            tblHomeLayout.Controls.Add(pbLogo, 1, 1);
            tblHomeLayout.Controls.Add(lblTalimat, 1, 2);
            tblHomeLayout.Controls.Add(lblBaslik, 1, 0);
            tblHomeLayout.Controls.Add(lblHosGeldiniz, 0, 1);
            tblHomeLayout.Controls.Add(lblTarihSaat, 0, 0);
            tblHomeLayout.Dock = DockStyle.Fill;
            tblHomeLayout.Location = new Point(0, 0);
            tblHomeLayout.Name = "tblHomeLayout";
            tblHomeLayout.RowCount = 3;
            tblHomeLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 19.1588783F));
            tblHomeLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 80.84112F));
            tblHomeLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 235F));
            tblHomeLayout.Size = new Size(800, 450);
            tblHomeLayout.TabIndex = 12;
            // 
            // lblTalimat
            // 
            lblTalimat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblTalimat.AutoSize = true;
            lblTalimat.Location = new Point(406, 214);
            lblTalimat.Name = "lblTalimat";
            lblTalimat.Size = new Size(391, 236);
            lblTalimat.TabIndex = 17;
            lblTalimat.Text = "Lütfen işlemleriniz için sol menüdeki ilgili ikonu seçiniz.";
            lblTalimat.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTarihSaat
            // 
            lblTarihSaat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblTarihSaat.AutoSize = true;
            lblTarihSaat.Location = new Point(3, 0);
            lblTarihSaat.Name = "lblTarihSaat";
            lblTarihSaat.Size = new Size(397, 41);
            lblTarihSaat.TabIndex = 16;
            lblTarihSaat.Text = "Bugünün Tarihi";
            lblTarihSaat.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRol
            // 
            lblRol.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblRol.AutoSize = true;
            lblRol.Location = new Point(3, 214);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(397, 236);
            lblRol.TabIndex = 15;
            lblRol.Text = "Yetki Seviyesi: DEPO PERSONELİ";
            lblRol.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblHosGeldiniz
            // 
            lblHosGeldiniz.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblHosGeldiniz.AutoSize = true;
            lblHosGeldiniz.Location = new Point(3, 41);
            lblHosGeldiniz.Name = "lblHosGeldiniz";
            lblHosGeldiniz.Size = new Size(397, 173);
            lblHosGeldiniz.TabIndex = 14;
            lblHosGeldiniz.Text = "Hoş Geldiniz, [Kullanıcı Adı]";
            lblHosGeldiniz.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBaslik
            // 
            lblBaslik.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblBaslik.Location = new Point(406, 0);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(391, 41);
            lblBaslik.TabIndex = 13;
            lblBaslik.Text = "Envanter Takip Sistemi";
            lblBaslik.TextAlign = ContentAlignment.MiddleCenter;
            lblBaslik.Click += lblBaslik_Click;
            // 
            // pbLogo
            // 
            pbLogo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbLogo.BackgroundImage = (Image)resources.GetObject("pbLogo.BackgroundImage");
            pbLogo.BackgroundImageLayout = ImageLayout.Zoom;
            pbLogo.Location = new Point(406, 44);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(391, 167);
            pbLogo.TabIndex = 12;
            pbLogo.TabStop = false;
            // 
            // frmDepoHomeIcerik
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tblHomeLayout);
            Name = "frmDepoHomeIcerik";
            Text = "frmDepoHomeIcerik";
            Load += frmDepoHomeIcerik_Load;
            tblHomeLayout.ResumeLayout(false);
            tblHomeLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblHomeLayout;
        private Label lblTarihSaat;
        private Label lblRol;
        private Label lblBaslik;
        private Label lblHosGeldiniz;
        private Label lblTalimat;
        private PictureBox pbLogo;
    }
}