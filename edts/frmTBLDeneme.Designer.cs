namespace edts
{
    partial class frmTBLDeneme
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
            tblDeneme = new TableLayoutPanel();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            tblDeneme.SuspendLayout();
            SuspendLayout();
            // 
            // tblDeneme
            // 
            tblDeneme.ColumnCount = 3;
            tblDeneme.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblDeneme.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblDeneme.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblDeneme.Controls.Add(panel3, 2, 0);
            tblDeneme.Controls.Add(panel2, 1, 0);
            tblDeneme.Controls.Add(panel1, 0, 0);
            tblDeneme.Dock = DockStyle.Fill;
            tblDeneme.Location = new Point(0, 0);
            tblDeneme.Name = "tblDeneme";
            tblDeneme.RowCount = 2;
            tblDeneme.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblDeneme.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblDeneme.Size = new Size(1216, 736);
            tblDeneme.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DimGray;
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(10, 10);
            panel1.Margin = new Padding(10);
            panel1.Name = "panel1";
            panel1.Size = new Size(385, 348);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.DimGray;
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(415, 10);
            panel2.Margin = new Padding(10);
            panel2.Name = "panel2";
            panel2.Size = new Size(385, 348);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.DimGray;
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(820, 10);
            panel3.Margin = new Padding(10);
            panel3.Name = "panel3";
            panel3.Size = new Size(386, 348);
            panel3.TabIndex = 2;
            // 
            // frmTBLDeneme
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1216, 736);
            Controls.Add(tblDeneme);
            Name = "frmTBLDeneme";
            Text = "frmTBLDeneme";
            tblDeneme.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblDeneme;
        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
    }
}