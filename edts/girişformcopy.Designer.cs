namespace edts
{
    partial class girişformcopy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(girişformcopy));
            kavisliButon1 = new KavisliButon();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            txtSifre = new TextBox();
            txtKullanici = new TextBox();
            label1 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // kavisliButon1
            // 
            kavisliButon1.BackColor = Color.LightSlateGray;
            kavisliButon1.BorderRadius = 30;
            kavisliButon1.FlatAppearance.BorderSize = 0;
            kavisliButon1.FlatStyle = FlatStyle.Flat;
            kavisliButon1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            kavisliButon1.ForeColor = SystemColors.ControlLightLight;
            kavisliButon1.Location = new Point(108, 338);
            kavisliButon1.Name = "kavisliButon1";
            kavisliButon1.Size = new Size(108, 42);
            kavisliButon1.TabIndex = 0;
            kavisliButon1.Text = "Giriş Yap";
            kavisliButon1.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gainsboro;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(txtSifre);
            panel1.Controls.Add(txtKullanici);
            panel1.Controls.Add(kavisliButon1);
            panel1.Location = new Point(646, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(295, 626);
            panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(73, 11);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(143, 92);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // txtSifre
            // 
            txtSifre.BorderStyle = BorderStyle.FixedSingle;
            txtSifre.Location = new Point(69, 290);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(190, 27);
            txtSifre.TabIndex = 4;
            txtSifre.Enter += txtSifre_Enter;
            txtSifre.Leave += txtSifre_Leave;
            // 
            // txtKullanici
            // 
            txtKullanici.BorderStyle = BorderStyle.FixedSingle;
            txtKullanici.Location = new Point(69, 243);
            txtKullanici.Name = "txtKullanici";
            txtKullanici.Size = new Size(190, 27);
            txtKullanici.TabIndex = 3;
            txtKullanici.Enter += txtKullanici_Enter;
            txtKullanici.Leave += txtKullanici_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 245);
            label1.Name = "label1";
            label1.Size = new Size(30, 20);
            label1.TabIndex = 6;
            label1.Text = "👤";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 292);
            label2.Name = "label2";
            label2.Size = new Size(30, 20);
            label2.TabIndex = 7;
            label2.Text = "🔒";
            // 
            // girişformcopy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1144, 627);
            Controls.Add(panel1);
            Name = "girişformcopy";
            Text = "girişformcopy";
            Load += girişformcopy_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private KavisliButon kavisliButon1;
        private Panel panel1;
        private TextBox txtSifre;
        private TextBox txtKullanici;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label1;
    }
}