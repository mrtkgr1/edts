namespace EnvanterDepoSistemitaslak2
{
    partial class frmStokListele
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
            txtArama = new TextBox();
            cmbKategori = new ComboBox();
            cmbLokasyon = new ComboBox();
            btnYenile = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtArama
            // 
            txtArama.Location = new Point(143, 45);
            txtArama.Name = "txtArama";
            txtArama.Size = new Size(125, 27);
            txtArama.TabIndex = 0;
            // 
            // cmbKategori
            // 
            cmbKategori.FormattingEnabled = true;
            cmbKategori.Location = new Point(274, 45);
            cmbKategori.Name = "cmbKategori";
            cmbKategori.Size = new Size(151, 28);
            cmbKategori.TabIndex = 1;
            // 
            // cmbLokasyon
            // 
            cmbLokasyon.FormattingEnabled = true;
            cmbLokasyon.Location = new Point(431, 45);
            cmbLokasyon.Name = "cmbLokasyon";
            cmbLokasyon.Size = new Size(151, 28);
            cmbLokasyon.TabIndex = 2;
            // 
            // btnYenile
            // 
            btnYenile.Location = new Point(588, 45);
            btnYenile.Name = "btnYenile";
            btnYenile.Size = new Size(94, 29);
            btnYenile.TabIndex = 3;
            btnYenile.Text = "button1";
            btnYenile.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(143, 79);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(539, 236);
            dataGridView1.TabIndex = 4;
            // 
            // frmStokListele
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(btnYenile);
            Controls.Add(cmbLokasyon);
            Controls.Add(cmbKategori);
            Controls.Add(txtArama);
            Name = "frmStokListele";
            Text = "frmStokListele";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtArama;
        private ComboBox cmbKategori;
        private ComboBox cmbLokasyon;
        private Button btnYenile;
        private DataGridView dataGridView1;
    }
}