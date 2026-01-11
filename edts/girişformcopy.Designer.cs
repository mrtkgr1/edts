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
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(girişformcopy));
            kavisliButon1 = new KavisliButon();
            loginForm = new Panel();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            txtSifre = new TextBox();
            txtKullanici = new TextBox();
            loginForm.SuspendLayout();
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
            kavisliButon1.Location = new Point(94, 287);
            kavisliButon1.Name = "kavisliButon1";
            kavisliButon1.Size = new Size(94, 36);
            kavisliButon1.TabIndex = 0;
            kavisliButon1.Text = "Giriş Yap";
            kavisliButon1.UseVisualStyleBackColor = false;
            // 
            // loginForm
            // 
            loginForm.BackColor = Color.Gainsboro;
            loginForm.Controls.Add(label2);
            loginForm.Controls.Add(label1);
            loginForm.Controls.Add(pictureBox1);
            loginForm.Controls.Add(txtSifre);
            loginForm.Controls.Add(txtKullanici);
            loginForm.Controls.Add(kavisliButon1);
            loginForm.Location = new Point(424, -1);
            loginForm.Name = "loginForm";
            loginForm.Size = new Size(295, 626);
            loginForm.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 248);
            label2.Name = "label2";
            label2.Size = new Size(26, 17);
            label2.TabIndex = 7;
            label2.Text = "🔒";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 208);
            label1.Name = "label1";
            label1.Size = new Size(26, 17);
            label1.TabIndex = 6;
            label1.Text = "👤";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(64, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 78);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // txtSifre
            // 
            txtSifre.BorderStyle = BorderStyle.FixedSingle;
            txtSifre.Location = new Point(60, 246);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(166, 25);
            txtSifre.TabIndex = 4;
            txtSifre.Enter += txtSifre_Enter;
            txtSifre.Leave += txtSifre_Leave;
            // 
            // txtKullanici
            // 
            txtKullanici.BorderStyle = BorderStyle.FixedSingle;
            txtKullanici.Location = new Point(60, 207);
            txtKullanici.Name = "txtKullanici";
            txtKullanici.Size = new Size(166, 25);
            txtKullanici.TabIndex = 3;
            txtKullanici.Enter += txtKullanici_Enter;
            txtKullanici.Leave += txtKullanici_Leave;
            // 
            // girişformcopy
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1144, 627);
            Controls.Add(loginForm);
            Name = "girişformcopy";
            Text = "girişformcopy";
            Load += girişformcopy_Load;
            loginForm.ResumeLayout(false);
            loginForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private KavisliButon kavisliButon1;
        private Panel loginForm;
        private TextBox txtSifre;
        private TextBox txtKullanici;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label1;
    }
}