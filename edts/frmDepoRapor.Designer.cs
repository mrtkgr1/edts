namespace EnvanterDepoSistemitaslak2
{
    partial class frmDepoRapor
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
            dtpBaslangic = new DateTimePicker();
            dtpBitis = new DateTimePicker();
            cmbIslemTipi = new ComboBox();
            btnRaporla = new Button();
            btnExcelAktar = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dtpBaslangic
            // 
            dtpBaslangic.Location = new Point(232, 79);
            dtpBaslangic.Name = "dtpBaslangic";
            dtpBaslangic.Size = new Size(250, 27);
            dtpBaslangic.TabIndex = 0;
            // 
            // dtpBitis
            // 
            dtpBitis.Location = new Point(235, 124);
            dtpBitis.Name = "dtpBitis";
            dtpBitis.Size = new Size(250, 27);
            dtpBitis.TabIndex = 1;
            // 
            // cmbIslemTipi
            // 
            cmbIslemTipi.FormattingEnabled = true;
            cmbIslemTipi.Location = new Point(231, 170);
            cmbIslemTipi.Name = "cmbIslemTipi";
            cmbIslemTipi.Size = new Size(151, 28);
            cmbIslemTipi.TabIndex = 2;
            // 
            // btnRaporla
            // 
            btnRaporla.Location = new Point(421, 174);
            btnRaporla.Name = "btnRaporla";
            btnRaporla.Size = new Size(94, 29);
            btnRaporla.TabIndex = 3;
            btnRaporla.Text = "button1";
            btnRaporla.UseVisualStyleBackColor = true;
            // 
            // btnExcelAktar
            // 
            btnExcelAktar.Location = new Point(533, 173);
            btnExcelAktar.Name = "btnExcelAktar";
            btnExcelAktar.Size = new Size(94, 29);
            btnExcelAktar.TabIndex = 4;
            btnExcelAktar.Text = "button1";
            btnExcelAktar.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(239, 212);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(388, 226);
            dataGridView1.TabIndex = 5;
            // 
            // frmDepoRapor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(938, 539);
            Controls.Add(dataGridView1);
            Controls.Add(btnExcelAktar);
            Controls.Add(btnRaporla);
            Controls.Add(cmbIslemTipi);
            Controls.Add(dtpBitis);
            Controls.Add(dtpBaslangic);
            Name = "frmDepoRapor";
            Text = "frmDepoRapor";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dtpBaslangic;
        private DateTimePicker dtpBitis;
        private ComboBox cmbIslemTipi;
        private Button btnRaporla;
        private Button btnExcelAktar;
        private DataGridView dataGridView1;
    }
}