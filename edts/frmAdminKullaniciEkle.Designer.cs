namespace edts {
    partial class frmAdminKullaniciEkle {
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
        private void InitializeComponent()
        {
            button1 = new Button();
            label1 = new Label();
            textBoxKullaniciAd = new TextBox();
            checkBox1 = new CheckBox();
            panel1 = new Panel();
            panel2 = new Panel();
            label2 = new Label();
            textBoxTamAd = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel4 = new Panel();
            comboBoxRol = new ComboBox();
            label4 = new Label();
            panel3 = new Panel();
            label3 = new Label();
            textBoxsifre = new TextBox();
            panel5 = new Panel();
            labelBildirim = new Label();
            resizableButton2 = new ResizableButton();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(224, 208);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(95, 29);
            button1.TabIndex = 0;
            button1.Text = "Ekle";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 7);
            label1.Name = "label1";
            label1.Size = new Size(95, 20);
            label1.TabIndex = 1;
            label1.Text = "Kullanıcı Adı:";
            // 
            // textBoxKullaniciAd
            // 
            textBoxKullaniciAd.Location = new Point(126, 4);
            textBoxKullaniciAd.Margin = new Padding(3, 4, 3, 4);
            textBoxKullaniciAd.Name = "textBoxKullaniciAd";
            textBoxKullaniciAd.Size = new Size(177, 27);
            textBoxKullaniciAd.TabIndex = 2;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(6, 212);
            checkBox1.Margin = new Padding(3, 4, 3, 4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(163, 24);
            checkBox1.TabIndex = 3;
            checkBox1.TabStop = false;
            checkBox1.Text = "Çoklu hesap ekleme";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBoxKullaniciAd);
            panel1.Location = new Point(3, 4);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(306, 35);
            panel1.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(textBoxTamAd);
            panel2.Location = new Point(3, 47);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(306, 35);
            panel2.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 7);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 1;
            label2.Text = "Tam Adı:";
            // 
            // textBoxTamAd
            // 
            textBoxTamAd.Location = new Point(126, 4);
            textBoxTamAd.Margin = new Padding(3, 4, 3, 4);
            textBoxTamAd.Name = "textBoxTamAd";
            textBoxTamAd.Size = new Size(177, 27);
            textBoxTamAd.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.Controls.Add(panel2);
            flowLayoutPanel1.Controls.Add(panel4);
            flowLayoutPanel1.Controls.Add(panel3);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(6, 7);
            flowLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(312, 170);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // panel4
            // 
            panel4.AutoSize = true;
            panel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel4.Controls.Add(comboBoxRol);
            panel4.Controls.Add(label4);
            panel4.Location = new Point(3, 90);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(306, 33);
            panel4.TabIndex = 7;
            // 
            // comboBoxRol
            // 
            comboBoxRol.FormattingEnabled = true;
            comboBoxRol.Location = new Point(126, 1);
            comboBoxRol.Margin = new Padding(3, 4, 3, 4);
            comboBoxRol.Name = "comboBoxRol";
            comboBoxRol.Size = new Size(177, 28);
            comboBoxRol.TabIndex = 2;
            comboBoxRol.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(62, 5);
            label4.Name = "label4";
            label4.Size = new Size(34, 20);
            label4.TabIndex = 1;
            label4.Text = "Rol:";
            // 
            // panel3
            // 
            panel3.AutoSize = true;
            panel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel3.Controls.Add(label3);
            panel3.Controls.Add(textBoxsifre);
            panel3.Location = new Point(3, 131);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(306, 35);
            panel3.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(54, 7);
            label3.Name = "label3";
            label3.Size = new Size(42, 20);
            label3.TabIndex = 1;
            label3.Text = "Şifre:";
            // 
            // textBoxsifre
            // 
            textBoxsifre.Location = new Point(126, 4);
            textBoxsifre.Margin = new Padding(3, 4, 3, 4);
            textBoxsifre.Name = "textBoxsifre";
            textBoxsifre.Size = new Size(177, 27);
            textBoxsifre.TabIndex = 2;
            // 
            // panel5
            // 
            panel5.Controls.Add(labelBildirim);
            panel5.Controls.Add(resizableButton2);
            panel5.Controls.Add(pictureBox1);
            panel5.Location = new Point(6, 268);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(313, 168);
            panel5.TabIndex = 7;
            panel5.Visible = false;
            // 
            // labelBildirim
            // 
            labelBildirim.Location = new Point(123, 9);
            labelBildirim.Name = "labelBildirim";
            labelBildirim.Size = new Size(183, 106);
            labelBildirim.TabIndex = 6;
            // 
            // resizableButton2
            // 
            resizableButton2.Image = null;
            resizableButton2.KaynakResim = null;
            resizableButton2.Location = new Point(78, 133);
            resizableButton2.Margin = new Padding(3, 4, 3, 4);
            resizableButton2.Name = "resizableButton2";
            resizableButton2.ResimBoyutu = 24;
            resizableButton2.Size = new Size(157, 29);
            resizableButton2.TabIndex = 5;
            resizableButton2.Text = "Profili görüntüle";
            resizableButton2.UseVisualStyleBackColor = true;
            resizableButton2.Visible = false;
            resizableButton2.Click += resizableButton2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(5, 4);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(111, 112);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // frmAdminKullaniciEkle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(327, 442);
            Controls.Add(panel5);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(checkBox1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAdminKullaniciEkle";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Yeni kullanıcı ekle";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox textBoxKullaniciAd;
        private CheckBox checkBox1;
        private Panel panel1;
        private Panel panel2;
        private Label label2;
        private TextBox textBoxTamAd;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel3;
        private Label label3;
        private TextBox textBoxsifre;
        private Panel panel4;
        private Label label4;
        private ComboBox comboBoxRol;
        private Panel panel5;
        private PictureBox pictureBox1;
        private ResizableButton resizableButton2;
        private Label labelBildirim;
    }
}