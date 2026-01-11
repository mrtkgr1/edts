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
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSolMenu
            // 
            pnlSolMenu.BackColor = Color.LightSlateGray;
            pnlSolMenu.Dock = DockStyle.Fill;
            pnlSolMenu.Location = new Point(0, 0);
            pnlSolMenu.Margin = new Padding(0);
            pnlSolMenu.Name = "pnlSolMenu";
            pnlSolMenu.Size = new Size(320, 673);
            pnlSolMenu.TabIndex = 0;
            // 
            // pnlIcerik
            // 
            pnlIcerik.BackColor = Color.LightSlateGray;
            pnlIcerik.Dock = DockStyle.Fill;
            pnlIcerik.Location = new Point(320, 0);
            pnlIcerik.Margin = new Padding(0);
            pnlIcerik.Name = "pnlIcerik";
            pnlIcerik.Size = new Size(942, 673);
            pnlIcerik.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 320F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(pnlIcerik, 1, 0);
            tableLayoutPanel1.Controls.Add(pnlSolMenu, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1262, 673);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // frmAdminAnaMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 673);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmAdminAnaMenu";
            StartPosition = FormStartPosition.CenterScreen;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSolMenu;
        private Panel pnlIcerik;
        private TableLayoutPanel tableLayoutPanel1;
    }
}