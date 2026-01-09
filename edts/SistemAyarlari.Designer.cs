namespace edts {
    partial class SistemAyarlari {
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
            panel2 = new Panel();
            resizableButton1 = new ResizableButton();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(pnlSettings);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 400);
            panel1.TabIndex = 1;
            // 
            // pnlSettings
            // 
            pnlSettings.Dock = DockStyle.Fill;
            pnlSettings.Location = new Point(0, 0);
            pnlSettings.Name = "pnlSettings";
            pnlSettings.Size = new Size(800, 400);
            pnlSettings.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(resizableButton1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 400);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 50);
            panel2.TabIndex = 0;
            // 
            // resizableButton1
            // 
            resizableButton1.Image = null;
            resizableButton1.KaynakResim = null;
            resizableButton1.Location = new Point(348, 6);
            resizableButton1.Name = "resizableButton1";
            resizableButton1.ResimBoyutu = 24;
            resizableButton1.Size = new Size(101, 41);
            resizableButton1.TabIndex = 0;
            resizableButton1.Text = "resizableButton1";
            resizableButton1.UseVisualStyleBackColor = true;
            // 
            // SistemAyarlari
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "SistemAyarlari";
            Text = "Sistem Ayarları";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private FlowLayoutPanel pnlSettings;
        private Panel panel2;
        private ResizableButton resizableButton1;
    }
}