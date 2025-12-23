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
            ıconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            fullAd = new Label();
            userAd = new Label();
            rolAd = new Label();
            ((System.ComponentModel.ISupportInitialize)ıconPictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ıconPictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ıconPictureBox3).BeginInit();
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
            // ıconPictureBox3
            // 
            ıconPictureBox3.BackColor = SystemColors.Control;
            ıconPictureBox3.ForeColor = SystemColors.ControlText;
            ıconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.User;
            ıconPictureBox3.IconColor = SystemColors.ControlText;
            ıconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ıconPictureBox3.IconSize = 71;
            ıconPictureBox3.Location = new Point(3, 3);
            ıconPictureBox3.Name = "ıconPictureBox3";
            ıconPictureBox3.Size = new Size(71, 76);
            ıconPictureBox3.TabIndex = 2;
            ıconPictureBox3.TabStop = false;
            ıconPictureBox3.Click += btnProfile_Click;
            // 
            // fullAd
            // 
            fullAd.AutoSize = true;
            fullAd.Font = new Font("Segoe UI", 11F);
            fullAd.Location = new Point(80, 3);
            fullAd.Name = "fullAd";
            fullAd.Size = new Size(55, 23);
            fullAd.TabIndex = 3;
            fullAd.Text = "label1";
            // 
            // userAd
            // 
            userAd.AutoSize = true;
            userAd.Location = new Point(80, 32);
            userAd.Name = "userAd";
            userAd.Size = new Size(43, 17);
            userAd.TabIndex = 4;
            userAd.Text = "label2";
            // 
            // rolAd
            // 
            rolAd.AutoSize = true;
            rolAd.Location = new Point(80, 54);
            rolAd.Name = "rolAd";
            rolAd.Size = new Size(43, 17);
            rolAd.TabIndex = 5;
            rolAd.Text = "label3";
            // 
            // ProfilMenuControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(rolAd);
            Controls.Add(userAd);
            Controls.Add(fullAd);
            Controls.Add(ıconPictureBox3);
            Controls.Add(ıconPictureBox2);
            Controls.Add(ıconPictureBox1);
            Name = "ProfilMenuControl";
            Size = new Size(320, 84);
            ((System.ComponentModel.ISupportInitialize)ıconPictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ıconPictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)ıconPictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox ıconPictureBox1;
        private FontAwesome.Sharp.IconPictureBox ıconPictureBox2;
        private FontAwesome.Sharp.IconPictureBox ıconPictureBox3;
        private Label fullAd;
        private Label userAd;
        private Label rolAd;
    }
}
