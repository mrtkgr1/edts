namespace edts
{
    partial class frmYoneticiHomeİcerikcopy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYoneticiHomeİcerikcopy));
            panel1 = new Panel();
            groupBox6 = new GroupBox();
            basitYuvarlakGrafik1 = new BasitYuvarlakGrafik();
            groupBox4 = new GroupBox();
            basitGrafik1 = new BasitGrafik();
            groupBox3 = new GroupBox();
            groupBox5 = new GroupBox();
            kavisliButon1 = new KavisliButon();
            kavisliButon2 = new KavisliButon();
            label1 = new Label();
            label2 = new Label();
            kavisliButon3 = new KavisliButon();
            groupBox1 = new GroupBox();
            label3 = new Label();
            progressBar1 = new ProgressBar();
            panel1.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSteelBlue;
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(groupBox5);
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(groupBox6);
            panel1.Controls.Add(groupBox4);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1216, 861);
            panel1.TabIndex = 4;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(basitYuvarlakGrafik1);
            groupBox6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            groupBox6.Location = new Point(575, 12);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(537, 307);
            groupBox6.TabIndex = 4;
            groupBox6.TabStop = false;
            groupBox6.Text = "Ödemeler";
            // 
            // basitYuvarlakGrafik1
            // 
            basitYuvarlakGrafik1.Degerler = new float[]
    {
    30F,
    20F,
    50F
    };
            basitYuvarlakGrafik1.DonutModu = true;
            basitYuvarlakGrafik1.Location = new Point(144, 30);
            basitYuvarlakGrafik1.Name = "basitYuvarlakGrafik1";
            basitYuvarlakGrafik1.Renkler = new Color[]
    {
    Color.FromArgb(52, 152, 219),
    Color.FromArgb(46, 204, 113),
    Color.FromArgb(231, 76, 60),
    Color.FromArgb(241, 196, 15)
    };
            basitYuvarlakGrafik1.Size = new Size(250, 250);
            basitYuvarlakGrafik1.TabIndex = 0;
            basitYuvarlakGrafik1.Text = "basitYuvarlakGrafik1";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(basitGrafik1);
            groupBox4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            groupBox4.Location = new Point(32, 12);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(537, 307);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Analiz";
            // 
            // basitGrafik1
            // 
            basitGrafik1.GrafikRengi = Color.DodgerBlue;
            basitGrafik1.Location = new Point(82, 62);
            basitGrafik1.Name = "basitGrafik1";
            basitGrafik1.Size = new Size(347, 188);
            basitGrafik1.TabIndex = 0;
            basitGrafik1.Text = "basitGrafik1";
            basitGrafik1.Veriler = (List<int>)resources.GetObject("basitGrafik1.Veriler");
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(kavisliButon2);
            groupBox3.Controls.Add(kavisliButon1);
            groupBox3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            groupBox3.Location = new Point(575, 348);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(537, 381);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Aktif/Pasif Kullanıcılar";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label3);
            groupBox5.Controls.Add(kavisliButon3);
            groupBox5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            groupBox5.Location = new Point(32, 348);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(537, 183);
            groupBox5.TabIndex = 4;
            groupBox5.TabStop = false;
            groupBox5.Text = "Bugünkü Toplam Satış";
            // 
            // kavisliButon1
            // 
            kavisliButon1.BackColor = Color.LightSteelBlue;
            kavisliButon1.BackgroundImage = (Image)resources.GetObject("kavisliButon1.BackgroundImage");
            kavisliButon1.BackgroundImageLayout = ImageLayout.Zoom;
            kavisliButon1.BorderRadius = 30;
            kavisliButon1.FlatAppearance.BorderSize = 0;
            kavisliButon1.FlatStyle = FlatStyle.Flat;
            kavisliButon1.ForeColor = SystemColors.ControlDarkDark;
            kavisliButon1.Location = new Point(77, 96);
            kavisliButon1.Name = "kavisliButon1";
            kavisliButon1.Size = new Size(96, 94);
            kavisliButon1.TabIndex = 0;
            kavisliButon1.UseVisualStyleBackColor = false;
            // 
            // kavisliButon2
            // 
            kavisliButon2.BackColor = Color.LightSteelBlue;
            kavisliButon2.BackgroundImage = (Image)resources.GetObject("kavisliButon2.BackgroundImage");
            kavisliButon2.BackgroundImageLayout = ImageLayout.Zoom;
            kavisliButon2.BorderRadius = 30;
            kavisliButon2.FlatAppearance.BorderSize = 0;
            kavisliButon2.FlatStyle = FlatStyle.Flat;
            kavisliButon2.ForeColor = SystemColors.ControlDarkDark;
            kavisliButon2.Location = new Point(77, 199);
            kavisliButon2.Name = "kavisliButon2";
            kavisliButon2.Size = new Size(96, 94);
            kavisliButon2.TabIndex = 1;
            kavisliButon2.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(215, 131);
            label1.Name = "label1";
            label1.Size = new Size(207, 28);
            label1.TabIndex = 2;
            label1.Text = "Aktif Kullanıcı Sayısı";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(215, 234);
            label2.Name = "label2";
            label2.Size = new Size(206, 28);
            label2.TabIndex = 3;
            label2.Text = "Pasif Kullanıcı Sayısı";
            // 
            // kavisliButon3
            // 
            kavisliButon3.BackgroundImage = (Image)resources.GetObject("kavisliButon3.BackgroundImage");
            kavisliButon3.BackgroundImageLayout = ImageLayout.Zoom;
            kavisliButon3.BorderRadius = 30;
            kavisliButon3.FlatAppearance.BorderSize = 0;
            kavisliButon3.FlatStyle = FlatStyle.Flat;
            kavisliButon3.Location = new Point(15, 53);
            kavisliButon3.Name = "kavisliButon3";
            kavisliButon3.Size = new Size(126, 115);
            kavisliButon3.TabIndex = 0;
            kavisliButon3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(progressBar1);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            groupBox1.Location = new Point(32, 537);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(537, 192);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Kar/Zarar";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(188, 96);
            label3.Name = "label3";
            label3.Size = new Size(222, 28);
            label3.TabIndex = 1;
            label3.Text = "Bugünkü Toplam Satış";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(82, 63);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(347, 78);
            progressBar1.TabIndex = 0;
            // 
            // frmYoneticiHomeİcerikcopy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1216, 861);
            Controls.Add(panel1);
            Name = "frmYoneticiHomeİcerikcopy";
            Text = "frmYoneticiHomeİcerikcopy";
            Load += frmYoneticiHomeİcerikcopy_Load;
            panel1.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private GroupBox groupBox4;
        private BasitGrafik basitGrafik1;
        private GroupBox groupBox6;
        private BasitYuvarlakGrafik basitYuvarlakGrafik1;
        private GroupBox groupBox5;
        private GroupBox groupBox3;
        private KavisliButon kavisliButon2;
        private KavisliButon kavisliButon1;
        private Label label2;
        private Label label1;
        private GroupBox groupBox1;
        private Label label3;
        private KavisliButon kavisliButon3;
        private ProgressBar progressBar1;
    }
}