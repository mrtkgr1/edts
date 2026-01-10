namespace edts
{
    partial class frmSupport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSupport));
            label1 = new Label();
            label4 = new Label();
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            lblDestekMail = new Label();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            panel3 = new Panel();
            panel4 = new Panel();
            pictureBox3 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(59, 18);
            label1.Name = "label1";
            label1.Size = new Size(198, 31);
            label1.TabIndex = 0;
            label1.Text = "Yardım ve Destek";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Cursor = Cursors.Hand;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(52, 16);
            label4.Name = "label4";
            label4.Size = new Size(53, 23);
            label4.TabIndex = 3;
            label4.Text = "v2.0.0";
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(lblDestekMail);
            panel1.Location = new Point(21, 121);
            panel1.Name = "panel1";
            panel1.Size = new Size(520, 125);
            panel1.TabIndex = 6;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(4, 29);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(125, 62);
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // lblDestekMail
            // 
            lblDestekMail.AutoSize = true;
            lblDestekMail.Cursor = Cursors.Hand;
            lblDestekMail.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblDestekMail.ForeColor = SystemColors.ControlLightLight;
            lblDestekMail.Location = new Point(138, 49);
            lblDestekMail.Name = "lblDestekMail";
            lblDestekMail.Size = new Size(338, 28);
            lblDestekMail.TabIndex = 7;
            lblDestekMail.Text = "E-posta: destek@stokyönetim.com";
            lblDestekMail.Click += lblDestekMail_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(21, 291);
            panel2.Name = "panel2";
            panel2.Size = new Size(520, 125);
            panel2.TabIndex = 7;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(3, 33);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 62);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Cursor = Cursors.Hand;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(134, 53);
            label2.Name = "label2";
            label2.Size = new Size(371, 28);
            label2.TabIndex = 6;
            label2.Text = "Telefon Destek: +90 (XXX) XXX XX XX";
            // 
            // panel3
            // 
            panel3.Controls.Add(label1);
            panel3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            panel3.Location = new Point(398, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(295, 65);
            panel3.TabIndex = 8;
            // 
            // panel4
            // 
            panel4.Controls.Add(label4);
            panel4.Location = new Point(503, 526);
            panel4.Name = "panel4";
            panel4.Size = new Size(164, 48);
            panel4.TabIndex = 9;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(564, 95);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(537, 369);
            pictureBox3.TabIndex = 10;
            pictureBox3.TabStop = false;
            // 
            // frmSupport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSlateGray;
            ClientSize = new Size(1138, 586);
            Controls.Add(pictureBox3);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmSupport";
            Text = "frmSupport";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label4;
        private Panel panel1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label lblDestekMail;
        private Label label2;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private PictureBox pictureBox3;
    }
}