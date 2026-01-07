namespace edts
{
    partial class frmKategoriYonetimiGuncellepopup
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
            tabControl1 = new TabControl();
            tabPage2 = new TabPage();
            btnKategoriGuncellee = new KavisliButon();
            txtKategoriAciklama = new TextBox();
            lblAciklama = new Label();
            txtKategoriAdi = new TextBox();
            lblKategoriAdi = new Label();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            tabControl1.Location = new Point(12, 13);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(644, 512);
            tabControl1.TabIndex = 3;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.LightSlateGray;
            tabPage2.Controls.Add(btnKategoriGuncellee);
            tabPage2.Controls.Add(txtKategoriAciklama);
            tabPage2.Controls.Add(lblAciklama);
            tabPage2.Controls.Add(txtKategoriAdi);
            tabPage2.Controls.Add(lblKategoriAdi);
            tabPage2.Location = new Point(4, 32);
            tabPage2.Margin = new Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 4, 3, 4);
            tabPage2.Size = new Size(636, 476);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Kategori Tanımlama";
            // 
            // btnKategoriGuncellee
            // 
            btnKategoriGuncellee.BorderRadius = 30;
            btnKategoriGuncellee.FlatStyle = FlatStyle.System;
            btnKategoriGuncellee.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnKategoriGuncellee.Location = new Point(379, 411);
            btnKategoriGuncellee.Name = "btnKategoriGuncellee";
            btnKategoriGuncellee.Size = new Size(124, 39);
            btnKategoriGuncellee.TabIndex = 8;
            btnKategoriGuncellee.Text = "Güncelle";
            btnKategoriGuncellee.UseVisualStyleBackColor = true;
            btnKategoriGuncellee.Click += btnKategoriGuncellee_Click;
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
            lblAciklama.Location = new Point(62, 116);
            lblAciklama.Name = "lblAciklama";
            lblAciklama.Size = new Size(94, 23);
            lblAciklama.TabIndex = 2;
            lblAciklama.Text = "Açıklama :";
            // 
            // txtKategoriAdi
            // 
            txtKategoriAdi.Location = new Point(156, 57);
            txtKategoriAdi.Margin = new Padding(3, 4, 3, 4);
            txtKategoriAdi.Name = "txtKategoriAdi";
            txtKategoriAdi.Size = new Size(347, 30);
            txtKategoriAdi.TabIndex = 1;
            // 
            // lblKategoriAdi
            // 
            lblKategoriAdi.AutoSize = true;
            lblKategoriAdi.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblKategoriAdi.ForeColor = SystemColors.ControlLightLight;
            lblKategoriAdi.Location = new Point(39, 69);
            lblKategoriAdi.Name = "lblKategoriAdi";
            lblKategoriAdi.Size = new Size(117, 23);
            lblKategoriAdi.TabIndex = 0;
            lblKategoriAdi.Text = "Kategori Adı:";
            // 
            // frmKategoriYonetimiGuncellepopup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(669, 556);
            Controls.Add(tabControl1);
            Name = "frmKategoriYonetimiGuncellepopup";
            Text = "frmKategoriYonetimiGuncellepopup";
            Load += frmKategoriYonetimiGuncellepopup_Load;
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage2;
        private KavisliButon btnKategoriGuncellee;
        private TextBox txtKategoriAciklama;
        private Label lblAciklama;
        private TextBox txtKategoriAdi;
        private Label lblKategoriAdi;
    }
}