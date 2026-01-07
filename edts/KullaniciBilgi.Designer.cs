namespace edts {
    partial class KullaniciBilgi {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KullaniciBilgi));
            pictureBox1 = new PictureBox();
            lblAd = new Label();
            lblKullanici = new Label();
            lblYetki = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panelKullaniciAyar = new Panel();
            buttonKullaniciAyar = new Button();
            panelAdminAyar = new Panel();
            button1 = new Button();
            panelBildirim = new Panel();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            panelKullaniciAyar.SuspendLayout();
            panelAdminAyar.SuspendLayout();
            panelBildirim.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(124, 124);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblAd
            // 
            lblAd.AutoSize = true;
            lblAd.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblAd.Location = new Point(142, 12);
            lblAd.Name = "lblAd";
            lblAd.Size = new Size(37, 30);
            lblAd.TabIndex = 1;
            lblAd.Text = "ad";
            // 
            // lblKullanici
            // 
            lblKullanici.AutoSize = true;
            lblKullanici.Location = new Point(142, 42);
            lblKullanici.Name = "lblKullanici";
            lblKullanici.Size = new Size(69, 17);
            lblKullanici.TabIndex = 2;
            lblKullanici.Text = "kullaniciAd";
            // 
            // lblYetki
            // 
            lblYetki.AutoSize = true;
            lblYetki.Location = new Point(142, 59);
            lblYetki.Name = "lblYetki";
            lblYetki.Size = new Size(43, 17);
            lblYetki.TabIndex = 3;
            lblYetki.Text = "label3";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(panelKullaniciAyar);
            flowLayoutPanel1.Controls.Add(panelAdminAyar);
            flowLayoutPanel1.Controls.Add(panelBildirim);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(0, 328);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(379, 34);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // panelKullaniciAyar
            // 
            panelKullaniciAyar.AutoSize = true;
            panelKullaniciAyar.BorderStyle = BorderStyle.FixedSingle;
            panelKullaniciAyar.Controls.Add(buttonKullaniciAyar);
            panelKullaniciAyar.Location = new Point(262, 0);
            panelKullaniciAyar.Margin = new Padding(0, 0, 3, 2);
            panelKullaniciAyar.Name = "panelKullaniciAyar";
            panelKullaniciAyar.Size = new Size(114, 31);
            panelKullaniciAyar.TabIndex = 5;
            panelKullaniciAyar.Visible = false;
            // 
            // buttonKullaniciAyar
            // 
            buttonKullaniciAyar.AutoSize = true;
            buttonKullaniciAyar.FlatAppearance.BorderSize = 0;
            buttonKullaniciAyar.Location = new Point(-1, 0);
            buttonKullaniciAyar.Margin = new Padding(0);
            buttonKullaniciAyar.Name = "buttonKullaniciAyar";
            buttonKullaniciAyar.Size = new Size(113, 29);
            buttonKullaniciAyar.TabIndex = 0;
            buttonKullaniciAyar.TabStop = false;
            buttonKullaniciAyar.Text = "Kullanıcı Ayarları";
            buttonKullaniciAyar.UseVisualStyleBackColor = false;
            buttonKullaniciAyar.Click += buttonKullaniciAyar_Click;
            // 
            // panelAdminAyar
            // 
            panelAdminAyar.AutoSize = true;
            panelAdminAyar.BorderStyle = BorderStyle.FixedSingle;
            panelAdminAyar.Controls.Add(button1);
            panelAdminAyar.Location = new Point(154, 0);
            panelAdminAyar.Margin = new Padding(0, 0, 3, 2);
            panelAdminAyar.Name = "panelAdminAyar";
            panelAdminAyar.Size = new Size(105, 32);
            panelAdminAyar.TabIndex = 6;
            panelAdminAyar.Visible = false;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.FlatAppearance.BorderSize = 0;
            button1.Location = new Point(0, 1);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(103, 29);
            button1.TabIndex = 0;
            button1.TabStop = false;
            button1.Text = "Admin Araçları";
            button1.UseVisualStyleBackColor = false;
            // 
            // panelBildirim
            // 
            panelBildirim.AutoSize = true;
            panelBildirim.BorderStyle = BorderStyle.FixedSingle;
            panelBildirim.Controls.Add(button2);
            panelBildirim.Location = new Point(40, 0);
            panelBildirim.Margin = new Padding(0, 0, 3, 2);
            panelBildirim.Name = "panelBildirim";
            panelBildirim.Size = new Size(111, 31);
            panelBildirim.TabIndex = 7;
            panelBildirim.Visible = false;
            // 
            // button2
            // 
            button2.AutoSize = true;
            button2.FlatAppearance.BorderSize = 0;
            button2.Location = new Point(0, 0);
            button2.Margin = new Padding(0);
            button2.Name = "button2";
            button2.Size = new Size(109, 29);
            button2.TabIndex = 0;
            button2.TabStop = false;
            button2.Text = "Bildirim Gönder";
            button2.UseVisualStyleBackColor = false;
            // 
            // KullaniciBilgi
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(379, 362);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(lblYetki);
            Controls.Add(lblKullanici);
            Controls.Add(lblAd);
            Controls.Add(pictureBox1);
            MaximizeBox = false;
            Name = "KullaniciBilgi";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Profil";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            panelKullaniciAyar.ResumeLayout(false);
            panelKullaniciAyar.PerformLayout();
            panelAdminAyar.ResumeLayout(false);
            panelAdminAyar.PerformLayout();
            panelBildirim.ResumeLayout(false);
            panelBildirim.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblAd;
        private Label lblKullanici;
        private Label lblYetki;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button buttonKullaniciAyar;
        private Panel panelKullaniciAyar;
        private Panel panelAdminAyar;
        private Button button1;
        private Panel panelBildirim;
        private Button button2;
    }
}