namespace edts {
    partial class frmKullaniciAyarlari {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
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
            pnlSettings = new FlowLayoutPanel();
            kaydetPanel = new Panel();
            btnKayit = new Button();
            panel1.SuspendLayout();
            kaydetPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(pnlSettings);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(746, 393);
            panel1.TabIndex = 0;
            // 
            // pnlSettings
            // 
            pnlSettings.Dock = DockStyle.Fill;
            pnlSettings.Location = new Point(0, 0);
            pnlSettings.Name = "pnlSettings";
            pnlSettings.Size = new Size(746, 393);
            pnlSettings.TabIndex = 0;
            // 
            // kaydetPanel
            // 
            kaydetPanel.AutoSize = true;
            kaydetPanel.Controls.Add(btnKayit);
            kaydetPanel.Dock = DockStyle.Bottom;
            kaydetPanel.Location = new Point(0, 393);
            kaydetPanel.Margin = new Padding(0);
            kaydetPanel.Name = "kaydetPanel";
            kaydetPanel.Size = new Size(746, 50);
            kaydetPanel.TabIndex = 0;
            // 
            // btnKayit
            // 
            btnKayit.BackColor = Color.DodgerBlue;
            btnKayit.Cursor = Cursors.Hand;
            btnKayit.FlatStyle = FlatStyle.Flat;
            btnKayit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnKayit.ForeColor = Color.White;
            btnKayit.Location = new Point(0, 0);
            btnKayit.Margin = new Padding(0);
            btnKayit.Name = "btnKayit";
            btnKayit.Size = new Size(150, 50);
            btnKayit.TabIndex = 0;
            btnKayit.Text = "KAYDET";
            btnKayit.UseVisualStyleBackColor = false;
            btnKayit.Click += BtnSave_Click;
            // 
            // frmKullaniciAyarlari
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(746, 443);
            Controls.Add(panel1);
            Controls.Add(kaydetPanel);
            Name = "frmKullaniciAyarlari";
            Text = "frmKullaniciAyarlari";
            panel1.ResumeLayout(false);
            kaydetPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();


        }

        #endregion
        private Button btnKayit;
        private Panel kaydetPanel;
        private Panel panel1;
        private FlowLayoutPanel pnlSettings;
    }
}