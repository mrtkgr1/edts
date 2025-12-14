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
            panel1 = new Panel();
            panel3 = new Panel();
            label2 = new Label();
            label1 = new Label();
            btnYenile = new Button();
            cmbDurumFiltresi = new ComboBox();
            cmbKategoriFiltresi = new ComboBox();
            txtArama = new TextBox();
            panel2 = new Panel();
            dgvStoklar = new DataGridView();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStoklar).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkOliveGreen;
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1069, 266);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLight;
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(btnYenile);
            panel3.Controls.Add(cmbDurumFiltresi);
            panel3.Controls.Add(cmbKategoriFiltresi);
            panel3.Controls.Add(txtArama);
            panel3.Location = new Point(175, 55);
            panel3.Name = "panel3";
            panel3.Size = new Size(744, 191);
            panel3.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.Location = new Point(300, 63);
            label2.Name = "label2";
            label2.Size = new Size(130, 23);
            label2.TabIndex = 13;
            label2.Text = "Durum Filtresi:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label1.Location = new Point(143, 63);
            label1.Name = "label1";
            label1.Size = new Size(143, 23);
            label1.TabIndex = 12;
            label1.Text = "Kategori Filtresi:";
            // 
            // btnYenile
            // 
            btnYenile.BackColor = Color.DarkOliveGreen;
            btnYenile.FlatAppearance.BorderSize = 0;
            btnYenile.FlatStyle = FlatStyle.Flat;
            btnYenile.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnYenile.ForeColor = SystemColors.ControlLightLight;
            btnYenile.Location = new Point(457, 92);
            btnYenile.Name = "btnYenile";
            btnYenile.Size = new Size(135, 29);
            btnYenile.TabIndex = 11;
            btnYenile.Text = "🔄Yenile";
            btnYenile.UseVisualStyleBackColor = false;
            btnYenile.Click += btnYenile_Click;
            // 
            // cmbDurumFiltresi
            // 
            cmbDurumFiltresi.FormattingEnabled = true;
            cmbDurumFiltresi.Location = new Point(300, 94);
            cmbDurumFiltresi.Name = "cmbDurumFiltresi";
            cmbDurumFiltresi.Size = new Size(151, 28);
            cmbDurumFiltresi.TabIndex = 10;
            // 
            // cmbKategoriFiltresi
            // 
            cmbKategoriFiltresi.FormattingEnabled = true;
            cmbKategoriFiltresi.Location = new Point(143, 94);
            cmbKategoriFiltresi.Name = "cmbKategoriFiltresi";
            cmbKategoriFiltresi.Size = new Size(151, 28);
            cmbKategoriFiltresi.TabIndex = 9;
            // 
            // txtArama
            // 
            txtArama.Location = new Point(12, 94);
            txtArama.Name = "txtArama";
            txtArama.Size = new Size(125, 27);
            txtArama.TabIndex = 8;
            txtArama.Text = "🔎";
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvStoklar);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 266);
            panel2.Name = "panel2";
            panel2.Size = new Size(1069, 324);
            panel2.TabIndex = 1;
            // 
            // dgvStoklar
            // 
            dgvStoklar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStoklar.Dock = DockStyle.Fill;
            dgvStoklar.Location = new Point(0, 0);
            dgvStoklar.Name = "dgvStoklar";
            dgvStoklar.RowHeadersWidth = 51;
            dgvStoklar.Size = new Size(1069, 324);
            dgvStoklar.TabIndex = 0;
            // 
            // frmStokListele
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1069, 590);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmStokListele";
            Text = "frmStokListele";
            Load += frmStokListele_Load;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStoklar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Label label2;
        private Label label1;
        private Button btnYenile;
        private ComboBox cmbDurumFiltresi;
        private ComboBox cmbKategoriFiltresi;
        private TextBox txtArama;
        private Panel panel2;
        private DataGridView dgvStoklar;
    }
}