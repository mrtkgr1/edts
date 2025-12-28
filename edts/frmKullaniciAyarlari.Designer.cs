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
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(pnlSettings);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(746, 443);
            panel1.TabIndex = 0;
            // 
            // pnlSettings
            // 
            pnlSettings.Dock = DockStyle.Fill;
            pnlSettings.Location = new Point(0, 0);
            pnlSettings.Name = "pnlSettings";
            pnlSettings.Size = new Size(746, 443);
            pnlSettings.TabIndex = 0;
            // 
            // frmKullaniciAyarlari
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(746, 443);
            Controls.Add(panel1);
            Name = "frmKullaniciAyarlari";
            Text = "frmKullaniciAyarlari";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private FlowLayoutPanel pnlSettings;
    }
}