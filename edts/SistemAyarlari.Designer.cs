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
        private void InitializeComponent()
        {
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
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(914, 477);
            panel1.TabIndex = 1;
            // 
            // pnlSettings
            // 
            pnlSettings.Dock = DockStyle.Fill;
            pnlSettings.Location = new Point(0, 0);
            pnlSettings.Margin = new Padding(3, 4, 3, 4);
            pnlSettings.Name = "pnlSettings";
            pnlSettings.Size = new Size(914, 477);
            pnlSettings.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(resizableButton1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 477);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(914, 52);
            panel2.TabIndex = 0;
            // 
            // resizableButton1
            // 
            resizableButton1.Image = null;
            resizableButton1.KaynakResim = null;
            resizableButton1.Location = new Point(393, 0);
            resizableButton1.Margin = new Padding(3, 4, 3, 4);
            resizableButton1.Name = "resizableButton1";
            resizableButton1.ResimBoyutu = 24;
            resizableButton1.Size = new Size(115, 48);
            resizableButton1.TabIndex = 0;
            resizableButton1.Text = "Kaydet";
            resizableButton1.UseVisualStyleBackColor = true;
            resizableButton1.Click += resizableButton1_Click;
            // 
            // SistemAyarlari
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 529);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SistemAyarlari";
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