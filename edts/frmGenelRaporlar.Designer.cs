namespace edts
{
    partial class frmGenelRaporlar
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
            panel1 = new Panel();
            panel2 = new Panel();
            dgvGenelRaporListesi = new DataGridView();
            pnlOzetGiris = new Panel();
            label3 = new Label();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            label4 = new Label();
            label5 = new Label();
            panel6 = new Panel();
            label6 = new Label();
            panel7 = new Panel();
            btnExcelAktar = new Button();
            btnRaporuGetir = new Button();
            cmbRaporTipi = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            dtpBaslangic = new DateTimePicker();
            dtpBitis = new DateTimePicker();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGenelRaporListesi).BeginInit();
            pnlOzetGiris.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1181, 197);
            panel1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvGenelRaporListesi);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 197);
            panel2.Name = "panel2";
            panel2.Size = new Size(1181, 396);
            panel2.TabIndex = 3;
            // 
            // dgvGenelRaporListesi
            // 
            dgvGenelRaporListesi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGenelRaporListesi.Dock = DockStyle.Fill;
            dgvGenelRaporListesi.Location = new Point(0, 0);
            dgvGenelRaporListesi.Name = "dgvGenelRaporListesi";
            dgvGenelRaporListesi.RowHeadersWidth = 51;
            dgvGenelRaporListesi.Size = new Size(1181, 396);
            dgvGenelRaporListesi.TabIndex = 0;
            // 
            // pnlOzetGiris
            // 
            pnlOzetGiris.BackColor = Color.DarkOliveGreen;
            pnlOzetGiris.Controls.Add(label3);
            pnlOzetGiris.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            pnlOzetGiris.ForeColor = SystemColors.ControlLightLight;
            pnlOzetGiris.Location = new Point(13, 15);
            pnlOzetGiris.Name = "pnlOzetGiris";
            pnlOzetGiris.Size = new Size(281, 66);
            pnlOzetGiris.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(3, 21);
            label3.Name = "label3";
            label3.Size = new Size(184, 23);
            label3.TabIndex = 0;
            label3.Text = "Toplam Giriş Miktarı :";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLightLight;
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(pnlOzetGiris);
            panel3.Location = new Point(3, 89);
            panel3.Name = "panel3";
            panel3.Size = new Size(1175, 98);
            panel3.TabIndex = 7;
            // 
            // panel4
            // 
            panel4.BackColor = Color.DarkOliveGreen;
            panel4.Controls.Add(label5);
            panel4.Location = new Point(593, 15);
            panel4.Name = "panel4";
            panel4.Size = new Size(284, 66);
            panel4.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.BackColor = Color.DarkOliveGreen;
            panel5.Controls.Add(label4);
            panel5.Location = new Point(300, 15);
            panel5.Name = "panel5";
            panel5.Size = new Size(287, 66);
            panel5.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.DarkOliveGreen;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(12, 21);
            label4.Name = "label4";
            label4.Size = new Size(186, 23);
            label4.TabIndex = 0;
            label4.Text = "Toplam Çıkış Miktarı :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(20, 21);
            label5.Name = "label5";
            label5.Size = new Size(135, 23);
            label5.TabIndex = 0;
            label5.Text = "Net Stok Farkı :";
            // 
            // panel6
            // 
            panel6.BackColor = Color.DarkOliveGreen;
            panel6.Controls.Add(label6);
            panel6.ForeColor = SystemColors.ControlLightLight;
            panel6.Location = new Point(883, 15);
            panel6.Name = "panel6";
            panel6.Size = new Size(283, 66);
            panel6.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.DarkOliveGreen;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label6.Location = new Point(3, 21);
            label6.Name = "label6";
            label6.Size = new Size(213, 23);
            label6.TabIndex = 0;
            label6.Text = "Toplam Envanter Değeri :";
            // 
            // panel7
            // 
            panel7.BackColor = SystemColors.ControlLightLight;
            panel7.Controls.Add(btnExcelAktar);
            panel7.Controls.Add(btnRaporuGetir);
            panel7.Controls.Add(cmbRaporTipi);
            panel7.Controls.Add(label2);
            panel7.Controls.Add(label1);
            panel7.Controls.Add(dtpBaslangic);
            panel7.Controls.Add(dtpBitis);
            panel7.Location = new Point(3, 10);
            panel7.Name = "panel7";
            panel7.Size = new Size(1177, 74);
            panel7.TabIndex = 8;
            // 
            // btnExcelAktar
            // 
            btnExcelAktar.BackColor = Color.DarkOliveGreen;
            btnExcelAktar.FlatAppearance.BorderSize = 0;
            btnExcelAktar.FlatStyle = FlatStyle.Flat;
            btnExcelAktar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnExcelAktar.ForeColor = SystemColors.ControlLightLight;
            btnExcelAktar.Location = new Point(594, 39);
            btnExcelAktar.Name = "btnExcelAktar";
            btnExcelAktar.Size = new Size(123, 29);
            btnExcelAktar.TabIndex = 13;
            btnExcelAktar.Text = "Excel'e Aktar";
            btnExcelAktar.UseVisualStyleBackColor = false;
            // 
            // btnRaporuGetir
            // 
            btnRaporuGetir.BackColor = Color.DarkOliveGreen;
            btnRaporuGetir.FlatAppearance.BorderSize = 0;
            btnRaporuGetir.FlatStyle = FlatStyle.Flat;
            btnRaporuGetir.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnRaporuGetir.ForeColor = SystemColors.ControlLightLight;
            btnRaporuGetir.Location = new Point(594, 6);
            btnRaporuGetir.Name = "btnRaporuGetir";
            btnRaporuGetir.Size = new Size(123, 29);
            btnRaporuGetir.TabIndex = 12;
            btnRaporuGetir.Text = "Raporu Getir";
            btnRaporuGetir.UseVisualStyleBackColor = false;
            // 
            // cmbRaporTipi
            // 
            cmbRaporTipi.FormattingEnabled = true;
            cmbRaporTipi.Items.AddRange(new object[] { "Stok Değerleri, Giriş/Çıkış Özeti, Kritik Durum" });
            cmbRaporTipi.Location = new Point(845, 8);
            cmbRaporTipi.Name = "cmbRaporTipi";
            cmbRaporTipi.Size = new Size(151, 28);
            cmbRaporTipi.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label2.Location = new Point(180, 43);
            label2.Name = "label2";
            label2.Size = new Size(95, 23);
            label2.TabIndex = 10;
            label2.Text = "Bitiş Tarihi :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label1.Location = new Point(180, 6);
            label1.Name = "label1";
            label1.Size = new Size(135, 23);
            label1.TabIndex = 9;
            label1.Text = "Başlangıç Tarihi :";
            // 
            // dtpBaslangic
            // 
            dtpBaslangic.Location = new Point(321, 6);
            dtpBaslangic.Name = "dtpBaslangic";
            dtpBaslangic.Size = new Size(250, 27);
            dtpBaslangic.TabIndex = 7;
            // 
            // dtpBitis
            // 
            dtpBitis.Location = new Point(321, 39);
            dtpBitis.Name = "dtpBitis";
            dtpBitis.Size = new Size(250, 27);
            dtpBitis.TabIndex = 8;
            // 
            // frmGenelRaporlar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1181, 593);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmGenelRaporlar";
            Text = "frmGenelRaporlar";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGenelRaporListesi).EndInit();
            pnlOzetGiris.ResumeLayout(false);
            pnlOzetGiris.PerformLayout();
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Panel panel2;
        private Panel pnlOzetGiris;
        private DataGridView dgvGenelRaporListesi;
        private Panel panel3;
        private Panel panel4;
        private Label label3;
        private Panel panel6;
        private Label label6;
        private Panel panel5;
        private Label label4;
        private Label label5;
        private Panel panel7;
        private Button btnExcelAktar;
        private Button btnRaporuGetir;
        private ComboBox cmbRaporTipi;
        private Label label2;
        private Label label1;
        private DateTimePicker dtpBaslangic;
        private DateTimePicker dtpBitis;
    }
}