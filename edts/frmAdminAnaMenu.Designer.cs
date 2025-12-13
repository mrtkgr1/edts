namespace edts
{
    partial class frmAdminAnaMenu
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
            pnlSolMenu = new Panel();
            pnlIcerik = new Panel();
            SuspendLayout();
            // 
            // pnlSolMenu
            // 
            pnlSolMenu.BackColor = Color.DarkOliveGreen;
            pnlSolMenu.Dock = DockStyle.Left;
            pnlSolMenu.Location = new Point(0, 0);
            pnlSolMenu.Margin = new Padding(0);
            pnlSolMenu.Name = "pnlSolMenu";
            pnlSolMenu.Size = new Size(350, 673);
            pnlSolMenu.TabIndex = 0;
            // 
            // pnlIcerik
            // 
            pnlIcerik.BackColor = Color.DarkOliveGreen;
            pnlIcerik.Dock = DockStyle.Fill;
            pnlIcerik.Location = new Point(350, 0);
            pnlIcerik.Margin = new Padding(0);
            pnlIcerik.Name = "pnlIcerik";
            pnlIcerik.Size = new Size(912, 673);
            pnlIcerik.TabIndex = 1;
            // 
            // frmAdminAnaMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 673);
            Controls.Add(pnlIcerik);
            Controls.Add(pnlSolMenu);
            Name = "frmAdminAnaMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmAdminAnaMenu";
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSolMenu;
        private Panel pnlIcerik;
    }
}