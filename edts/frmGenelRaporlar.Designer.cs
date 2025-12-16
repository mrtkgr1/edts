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
        private void InitializeComponent() {
            panel1 = new Panel();
            panel7 = new Panel();
            btnExcelAktar = new Button();
            btnRaporuGetir = new Button();
            cmbRaporTipi = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            dtpBaslangic = new DateTimePicker();
            dtpBitis = new DateTimePicker();
            panel3 = new Panel();
            panel6 = new Panel();
            label6 = new Label();
            panel5 = new Panel();
            label4 = new Label();
            panel4 = new Panel();
            label5 = new Label();
            pnlOzetGiris = new Panel();
            label3 = new Label();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            panel7.SuspendLayout();
            panel3.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            pnlOzetGiris.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1034, 167);
            panel1.TabIndex = 2;
            // 
            // panel7
            // 
            panel7.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel7.BackColor = SystemColors.ControlLightLight;
            panel7.Controls.Add(btnExcelAktar);
            panel7.Controls.Add(btnRaporuGetir);
            panel7.Controls.Add(cmbRaporTipi);
            panel7.Controls.Add(label2);
            panel7.Controls.Add(label1);
            panel7.Controls.Add(dtpBaslangic);
            panel7.Controls.Add(dtpBitis);
            panel7.Location = new Point(3, 8);
            panel7.Name = "panel7";
            panel7.Size = new Size(1030, 63);
            panel7.TabIndex = 8;
            // 
            // btnExcelAktar
            // 
            btnExcelAktar.BackColor = Color.DarkOliveGreen;
            btnExcelAktar.FlatAppearance.BorderSize = 0;
            btnExcelAktar.FlatStyle = FlatStyle.Flat;
            btnExcelAktar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnExcelAktar.ForeColor = SystemColors.ControlLightLight;
            btnExcelAktar.Location = new Point(520, 33);
            btnExcelAktar.Name = "btnExcelAktar";
            btnExcelAktar.Size = new Size(108, 25);
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
            btnRaporuGetir.Location = new Point(520, 5);
            btnRaporuGetir.Name = "btnRaporuGetir";
            btnRaporuGetir.Size = new Size(108, 25);
            btnRaporuGetir.TabIndex = 12;
            btnRaporuGetir.Text = "Raporu Getir";
            btnRaporuGetir.UseVisualStyleBackColor = false;
            btnRaporuGetir.Click += btnRaporuGetir_Click;
            // 
            // cmbRaporTipi
            // 
            cmbRaporTipi.FormattingEnabled = true;
            cmbRaporTipi.Items.AddRange(new object[] { "Stok Değerleri, Giriş/Çıkış Özeti, Kritik Durum" });
            cmbRaporTipi.Location = new Point(739, 7);
            cmbRaporTipi.Name = "cmbRaporTipi";
            cmbRaporTipi.Size = new Size(133, 25);
            cmbRaporTipi.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label2.Location = new Point(158, 37);
            label2.Name = "label2";
            label2.Size = new Size(91, 21);
            label2.TabIndex = 10;
            label2.Text = "Bitiş Tarihi :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label1.Location = new Point(158, 5);
            label1.Name = "label1";
            label1.Size = new Size(128, 21);
            label1.TabIndex = 9;
            label1.Text = "Başlangıç Tarihi :";
            // 
            // dtpBaslangic
            // 
            dtpBaslangic.Location = new Point(281, 5);
            dtpBaslangic.Name = "dtpBaslangic";
            dtpBaslangic.Size = new Size(219, 25);
            dtpBaslangic.TabIndex = 7;
            // 
            // dtpBitis
            // 
            dtpBitis.Location = new Point(281, 33);
            dtpBitis.Name = "dtpBitis";
            dtpBitis.Size = new Size(219, 25);
            dtpBitis.TabIndex = 8;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLightLight;
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(pnlOzetGiris);
            panel3.Location = new Point(3, 76);
            panel3.Name = "panel3";
            panel3.Size = new Size(1028, 83);
            panel3.TabIndex = 7;
            // 
            // panel6
            // 
            panel6.BackColor = Color.DarkOliveGreen;
            panel6.Controls.Add(label6);
            panel6.ForeColor = SystemColors.ControlLightLight;
            panel6.Location = new Point(773, 13);
            panel6.Name = "panel6";
            panel6.Size = new Size(248, 56);
            panel6.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.DarkOliveGreen;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label6.Location = new Point(3, 18);
            label6.Name = "label6";
            label6.Size = new Size(130, 21);
            label6.TabIndex = 0;
            label6.Text = "Toplam Değeri :";
            // 
            // panel5
            // 
            panel5.BackColor = Color.DarkOliveGreen;
            panel5.Controls.Add(label4);
            panel5.Location = new Point(262, 13);
            panel5.Name = "panel5";
            panel5.Size = new Size(251, 56);
            panel5.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.DarkOliveGreen;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(10, 18);
            label4.Name = "label4";
            label4.Size = new Size(174, 21);
            label4.TabIndex = 0;
            label4.Text = "Toplam Çıkış Miktarı :";
            // 
            // panel4
            // 
            panel4.BackColor = Color.DarkOliveGreen;
            panel4.Controls.Add(label5);
            panel4.Location = new Point(519, 13);
            panel4.Name = "panel4";
            panel4.Size = new Size(248, 56);
            panel4.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(18, 18);
            label5.Name = "label5";
            label5.Size = new Size(125, 21);
            label5.TabIndex = 0;
            label5.Text = "Net Stok Farkı :";
            // 
            // pnlOzetGiris
            // 
            pnlOzetGiris.BackColor = Color.DarkOliveGreen;
            pnlOzetGiris.Controls.Add(label3);
            pnlOzetGiris.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            pnlOzetGiris.ForeColor = SystemColors.ControlLightLight;
            pnlOzetGiris.Location = new Point(11, 13);
            pnlOzetGiris.Name = "pnlOzetGiris";
            pnlOzetGiris.Size = new Size(246, 56);
            pnlOzetGiris.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(3, 18);
            label3.Name = "label3";
            label3.Size = new Size(172, 21);
            label3.TabIndex = 0;
            label3.Text = "Toplam Giriş Miktarı :";
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 167);
            panel2.Name = "panel2";
            panel2.Size = new Size(1034, 337);
            panel2.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1034, 337);
            dataGridView1.TabIndex = 0;
            // 
            // frmGenelRaporlar
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1034, 504);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmGenelRaporlar";
            Text = "frmGenelRaporlar";
            panel1.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel3.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            pnlOzetGiris.ResumeLayout(false);
            pnlOzetGiris.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Panel panel2;
        private Panel pnlOzetGiris;
        private DataGridView dataGridView1;
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