namespace edts
{
    partial class frmTedarikciYonetimKaydetpopup
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
            tabPage3 = new TabPage();
            btnTedarikciKaydett = new KavisliButon();
            lblAdres = new Label();
            txtTelefon = new TextBox();
            txtVergiDairesi = new TextBox();
            txtVergiNo = new TextBox();
            txtFirmaAdi = new TextBox();
            lblTelefon = new Label();
            lblYetkiliKisi = new Label();
            lblFirmaAdi = new Label();
            tabControl1.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            tabControl1.Location = new Point(12, 13);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(525, 556);
            tabControl1.TabIndex = 3;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.LightSlateGray;
            tabPage3.Controls.Add(btnTedarikciKaydett);
            tabPage3.Controls.Add(lblAdres);
            tabPage3.Controls.Add(txtTelefon);
            tabPage3.Controls.Add(txtVergiDairesi);
            tabPage3.Controls.Add(txtVergiNo);
            tabPage3.Controls.Add(txtFirmaAdi);
            tabPage3.Controls.Add(lblTelefon);
            tabPage3.Controls.Add(lblYetkiliKisi);
            tabPage3.Controls.Add(lblFirmaAdi);
            tabPage3.Location = new Point(4, 37);
            tabPage3.Margin = new Padding(3, 4, 3, 4);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3, 4, 3, 4);
            tabPage3.Size = new Size(517, 515);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Tedarikçi Tanımlama";
            // 
            // btnTedarikciKaydett
            // 
            btnTedarikciKaydett.BackColor = Color.White;
            btnTedarikciKaydett.BorderRadius = 30;
            btnTedarikciKaydett.FlatAppearance.BorderSize = 0;
            btnTedarikciKaydett.FlatStyle = FlatStyle.System;
            btnTedarikciKaydett.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnTedarikciKaydett.Location = new Point(333, 287);
            btnTedarikciKaydett.Name = "btnTedarikciKaydett";
            btnTedarikciKaydett.Size = new Size(142, 45);
            btnTedarikciKaydett.TabIndex = 11;
            btnTedarikciKaydett.Text = "Kaydet";
            btnTedarikciKaydett.UseVisualStyleBackColor = false;
            btnTedarikciKaydett.Click += btnTedarikciKaydett_Click;
            // 
            // lblAdres
            // 
            lblAdres.AutoSize = true;
            lblAdres.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblAdres.ForeColor = SystemColors.ControlLightLight;
            lblAdres.Location = new Point(55, 236);
            lblAdres.Name = "lblAdres";
            lblAdres.Size = new Size(78, 23);
            lblAdres.TabIndex = 7;
            lblAdres.Text = "Telefon: ";
            // 
            // txtTelefon
            // 
            txtTelefon.Location = new Point(184, 220);
            txtTelefon.Margin = new Padding(3, 4, 3, 4);
            txtTelefon.Multiline = true;
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(291, 29);
            txtTelefon.TabIndex = 6;
            // 
            // txtVergiDairesi
            // 
            txtVergiDairesi.Location = new Point(184, 159);
            txtVergiDairesi.Margin = new Padding(3, 4, 3, 4);
            txtVergiDairesi.Name = "txtVergiDairesi";
            txtVergiDairesi.Size = new Size(291, 34);
            txtVergiDairesi.TabIndex = 5;
            // 
            // txtVergiNo
            // 
            txtVergiNo.Location = new Point(184, 106);
            txtVergiNo.Margin = new Padding(3, 4, 3, 4);
            txtVergiNo.Name = "txtVergiNo";
            txtVergiNo.Size = new Size(291, 34);
            txtVergiNo.TabIndex = 4;
            // 
            // txtFirmaAdi
            // 
            txtFirmaAdi.Location = new Point(184, 58);
            txtFirmaAdi.Margin = new Padding(3, 4, 3, 4);
            txtFirmaAdi.Name = "txtFirmaAdi";
            txtFirmaAdi.Size = new Size(291, 34);
            txtFirmaAdi.TabIndex = 3;
            // 
            // lblTelefon
            // 
            lblTelefon.AutoSize = true;
            lblTelefon.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblTelefon.ForeColor = SystemColors.ControlLightLight;
            lblTelefon.Location = new Point(55, 176);
            lblTelefon.Name = "lblTelefon";
            lblTelefon.Size = new Size(117, 23);
            lblTelefon.TabIndex = 2;
            lblTelefon.Text = "Vergi Dairesi:";
            // 
            // lblYetkiliKisi
            // 
            lblYetkiliKisi.AutoSize = true;
            lblYetkiliKisi.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblYetkiliKisi.ForeColor = SystemColors.ControlLightLight;
            lblYetkiliKisi.Location = new Point(55, 124);
            lblYetkiliKisi.Name = "lblYetkiliKisi";
            lblYetkiliKisi.Size = new Size(85, 23);
            lblYetkiliKisi.TabIndex = 1;
            lblYetkiliKisi.Text = "Vergi No:";
            // 
            // lblFirmaAdi
            // 
            lblFirmaAdi.AutoSize = true;
            lblFirmaAdi.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblFirmaAdi.ForeColor = SystemColors.ControlLightLight;
            lblFirmaAdi.Location = new Point(55, 74);
            lblFirmaAdi.Name = "lblFirmaAdi";
            lblFirmaAdi.Size = new Size(94, 23);
            lblFirmaAdi.TabIndex = 0;
            lblFirmaAdi.Text = "Firma Adı:";
            // 
            // frmTedarikciYonetimKaydetpopup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 588);
            Controls.Add(tabControl1);
            Name = "frmTedarikciYonetimKaydetpopup";
            Text = "frmTedarikciYonetimKaydetpopup";
            Load += frmTedarikciYonetimKaydetpopup_Load;
            tabControl1.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage3;
        private KavisliButon btnTedarikciKaydett;
        private Label lblAdres;
        private TextBox txtTelefon;
        private TextBox txtVergiDairesi;
        private TextBox txtVergiNo;
        private TextBox txtFirmaAdi;
        private Label lblTelefon;
        private Label lblYetkiliKisi;
        private Label lblFirmaAdi;
    }
}