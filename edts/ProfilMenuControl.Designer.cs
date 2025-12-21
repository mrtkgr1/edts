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
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(37, 22);
            button1.Name = "button1";
            button1.Size = new Size(83, 25);
            button1.TabIndex = 0;
            button1.Text = "Ayarlar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnAyarlar_Click;
            // 
            // button2
            // 
            button2.Location = new Point(110, 87);
            button2.Name = "button2";
            button2.Size = new Size(83, 25);
            button2.TabIndex = 1;
            button2.Text = "Hesap";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnProfile_Click;
            // 
            // ProfilMenuControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "ProfilMenuControl";
            Size = new Size(320, 134);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
    }
}
