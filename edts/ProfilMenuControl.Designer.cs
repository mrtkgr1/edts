namespace edts {
    partial class ProfilMenuControl {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent() {
            ıconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            ıconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            fullAd = new Label();
            userAd = new Label();
            rolAd = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)ıconPictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ıconPictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // ıconPictureBox1
            // 
            ıconPictureBox1.BackColor = SystemColors.Control;
            ıconPictureBox1.ForeColor = SystemColors.ControlText;
            ıconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.SignOut;
            ıconPictureBox1.IconColor = SystemColors.ControlText;
            ıconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ıconPictureBox1.IconSize = 35;
            ıconPictureBox1.Location = new Point(282, 44);
            ıconPictureBox1.Name = "ıconPictureBox1";
            ıconPictureBox1.Size = new Size(35, 35);
            ıconPictureBox1.TabIndex = 0;
            ıconPictureBox1.TabStop = false;
            ıconPictureBox1.Visible = false;
            // 
            // ıconPictureBox2
            // 
            ıconPictureBox2.BackColor = SystemColors.Control;
            ıconPictureBox2.ForeColor = SystemColors.ControlText;
            ıconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Cog;
            ıconPictureBox2.IconColor = SystemColors.ControlText;
            ıconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ıconPictureBox2.IconSize = 35;
            ıconPictureBox2.Location = new Point(282, 3);
            ıconPictureBox2.Name = "ıconPictureBox2";
            ıconPictureBox2.Size = new Size(35, 35);
            ıconPictureBox2.TabIndex = 1;
            ıconPictureBox2.TabStop = false;
            ıconPictureBox2.Click += btnAyarlar_Click;
            // 
            // fullAd
            // 
            fullAd.AutoSize = true;
            fullAd.Font = new Font("Segoe UI", 11F);
            fullAd.Location = new Point(87, 3);
            fullAd.Name = "fullAd";
            fullAd.Size = new Size(55, 23);
            fullAd.TabIndex = 3;
            fullAd.Text = "label1";
            // 
            // userAd
            // 
            userAd.AutoSize = true;
            userAd.Location = new Point(87, 32);
            userAd.Name = "userAd";
            userAd.Size = new Size(43, 17);
            userAd.TabIndex = 4;
            userAd.Text = "label2";
            // 
            // rolAd
            // 
            rolAd.AutoSize = true;
            rolAd.Location = new Point(87, 54);
            rolAd.Name = "rolAd";
            rolAd.Size = new Size(43, 17);
            rolAd.TabIndex = 5;
            rolAd.Text = "label3";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.var_pp;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(76, 76);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            pictureBox1.Click += btnProfile_Click;
            // 
            // ProfilMenuControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox1);
            Controls.Add(rolAd);
            Controls.Add(userAd);
            Controls.Add(fullAd);
            Controls.Add(ıconPictureBox2);
            Controls.Add(ıconPictureBox1);
            Name = "ProfilMenuControl";
            Size = new Size(320, 84);
            ((System.ComponentModel.ISupportInitialize)ıconPictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ıconPictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox ıconPictureBox1;
        private FontAwesome.Sharp.IconPictureBox ıconPictureBox2;
        private Label fullAd;
        private Label userAd;
        private Label rolAd;
        private PictureBox pictureBox1;
    }
}
