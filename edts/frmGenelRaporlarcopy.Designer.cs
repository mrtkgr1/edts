namespace edts
{
    partial class frmGenelRaporlarcopy
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
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
            panel1.Size = new Size(1202, 279);
            panel1.TabIndex = 0;
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
            panel7.Location = new Point(12, 43);
            panel7.Margin = new Padding(3, 4, 3, 4);
            panel7.Name = "panel7";
            panel7.Size = new Size(1177, 74);
            panel7.TabIndex = 10;
            // 
            // btnExcelAktar
            // 
            btnExcelAktar.BackColor = Color.LightSlateGray;
            btnExcelAktar.FlatAppearance.BorderSize = 0;
            btnExcelAktar.FlatStyle = FlatStyle.Flat;
            btnExcelAktar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnExcelAktar.ForeColor = SystemColors.ControlLightLight;
            btnExcelAktar.Location = new Point(594, 39);
            btnExcelAktar.Margin = new Padding(3, 4, 3, 4);
            btnExcelAktar.Name = "btnExcelAktar";
            btnExcelAktar.Size = new Size(123, 29);
            btnExcelAktar.TabIndex = 13;
            btnExcelAktar.Text = "Excel'e Aktar";
            btnExcelAktar.UseVisualStyleBackColor = false;
            btnExcelAktar.Click += btnExcelAktar_Click;
            // 
            // btnRaporuGetir
            // 
            btnRaporuGetir.BackColor = Color.LightSlateGray;
            btnRaporuGetir.FlatAppearance.BorderSize = 0;
            btnRaporuGetir.FlatStyle = FlatStyle.Flat;
            btnRaporuGetir.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnRaporuGetir.ForeColor = SystemColors.ControlLightLight;
            btnRaporuGetir.Location = new Point(594, 6);
            btnRaporuGetir.Margin = new Padding(3, 4, 3, 4);
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
            cmbRaporTipi.Margin = new Padding(3, 4, 3, 4);
            cmbRaporTipi.Name = "cmbRaporTipi";
            cmbRaporTipi.Size = new Size(151, 28);
            cmbRaporTipi.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label2.Location = new Point(181, 44);
            label2.Name = "label2";
            label2.Size = new Size(95, 23);
            label2.TabIndex = 10;
            label2.Text = "Bitiş Tarihi :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label1.Location = new Point(181, 6);
            label1.Name = "label1";
            label1.Size = new Size(135, 23);
            label1.TabIndex = 9;
            label1.Text = "Başlangıç Tarihi :";
            // 
            // dtpBaslangic
            // 
            dtpBaslangic.Location = new Point(321, 6);
            dtpBaslangic.Margin = new Padding(3, 4, 3, 4);
            dtpBaslangic.Name = "dtpBaslangic";
            dtpBaslangic.Size = new Size(250, 27);
            dtpBaslangic.TabIndex = 7;
            // 
            // dtpBitis
            // 
            dtpBitis.Location = new Point(321, 39);
            dtpBitis.Margin = new Padding(3, 4, 3, 4);
            dtpBitis.Name = "dtpBitis";
            dtpBitis.Size = new Size(250, 27);
            dtpBitis.TabIndex = 8;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLightLight;
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(pnlOzetGiris);
            panel3.Location = new Point(12, 123);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(1175, 98);
            panel3.TabIndex = 9;
            // 
            // panel6
            // 
            panel6.BackColor = Color.LightSlateGray;
            panel6.Controls.Add(label6);
            panel6.ForeColor = SystemColors.ControlLightLight;
            panel6.Location = new Point(883, 15);
            panel6.Margin = new Padding(3, 4, 3, 4);
            panel6.Name = "panel6";
            panel6.Size = new Size(283, 66);
            panel6.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.LightSlateGray;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label6.Location = new Point(3, 21);
            label6.Name = "label6";
            label6.Size = new Size(138, 23);
            label6.TabIndex = 0;
            label6.Text = "Toplam Değeri :";
            // 
            // panel5
            // 
            panel5.BackColor = Color.LightSlateGray;
            panel5.Controls.Add(label4);
            panel5.Location = new Point(299, 15);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(287, 66);
            panel5.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.LightSlateGray;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(11, 21);
            label4.Name = "label4";
            label4.Size = new Size(186, 23);
            label4.TabIndex = 0;
            label4.Text = "Toplam Çıkış Miktarı :";
            // 
            // panel4
            // 
            panel4.BackColor = Color.LightSlateGray;
            panel4.Controls.Add(label5);
            panel4.Location = new Point(593, 15);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(283, 66);
            panel4.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(3, 21);
            label5.Name = "label5";
            label5.Size = new Size(135, 23);
            label5.TabIndex = 0;
            label5.Text = "Net Stok Farkı :";
            // 
            // pnlOzetGiris
            // 
            pnlOzetGiris.BackColor = Color.LightSlateGray;
            pnlOzetGiris.Controls.Add(label3);
            pnlOzetGiris.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            pnlOzetGiris.ForeColor = SystemColors.ControlLightLight;
            pnlOzetGiris.Location = new Point(13, 15);
            pnlOzetGiris.Margin = new Padding(3, 4, 3, 4);
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
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 279);
            panel2.Name = "panel2";
            panel2.Size = new Size(1202, 352);
            panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = Color.AliceBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1202, 352);
            dataGridView1.TabIndex = 0;
            // 
            // frmGenelRaporlarcopy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1202, 631);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmGenelRaporlarcopy";
            Text = "frmGenelRaporlarcopy";
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
        private DataGridView dataGridView1;
        private Panel panel7;
        private Button btnExcelAktar;
        private Button btnRaporuGetir;
        private ComboBox cmbRaporTipi;
        private Label label2;
        private Label label1;
        private DateTimePicker dtpBaslangic;
        private DateTimePicker dtpBitis;
        private Panel panel3;
        private Panel panel6;
        private Label label6;
        private Panel panel5;
        private Label label4;
        private Panel panel4;
        private Label label5;
        private Panel pnlOzetGiris;
        private Label label3;
    }
}