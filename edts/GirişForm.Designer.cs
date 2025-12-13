using System.Windows.Forms;
using System.Data.SqlClient; // SQL Server ile iletişim için
using System.Configuration;
namespace edts
{
    partial class GirişForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GirişForm));
            panel1 = new Panel();
            linkLabel1 = new LinkLabel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            lblHata = new Label();
            txtSifre = new TextBox();
            txtKullaniciAdi = new TextBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            btnGiris = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkOliveGreen;
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(576, 684);
            panel1.TabIndex = 0;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.White;
            linkLabel1.Location = new Point(184, 655);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(186, 20);
            linkLabel1.TabIndex = 5;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Bir sorun mu yaşıyorsunuz?";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(119, 306);
            label1.Name = "label1";
            label1.Size = new Size(325, 31);
            label1.TabIndex = 1;
            label1.Text = "Envanter Depo Takip Sistemi ";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(171, 139);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(199, 146);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblHata);
            panel2.Controls.Add(txtSifre);
            panel2.Controls.Add(txtKullaniciAdi);
            panel2.Controls.Add(pictureBox3);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(btnGiris);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(576, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(645, 684);
            panel2.TabIndex = 1;
            // 
            // lblHata
            // 
            lblHata.AutoSize = true;
            lblHata.ForeColor = Color.Crimson;
            lblHata.Location = new Point(105, 365);
            lblHata.Name = "lblHata";
            lblHata.Size = new Size(210, 20);
            lblHata.TabIndex = 5;
            lblHata.Text = "*Kullanıcı Adı veya Şifre Hatalı";
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(240, 290);
            txtSifre.Name = "txtSifre";
            txtSifre.PasswordChar = '*';
            txtSifre.Size = new Size(165, 27);
            txtSifre.TabIndex = 4;
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.Location = new Point(240, 210);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(165, 27);
            txtKullaniciAdi.TabIndex = 3;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(144, 278);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(90, 50);
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(144, 197);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(90, 51);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // btnGiris
            // 
            btnGiris.BackColor = Color.DarkOliveGreen;
            btnGiris.FlatAppearance.BorderSize = 0;
            btnGiris.FlatStyle = FlatStyle.Flat;
            btnGiris.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnGiris.ForeColor = SystemColors.ControlLightLight;
            btnGiris.Location = new Point(324, 352);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new Size(81, 44);
            btnGiris.TabIndex = 0;
            btnGiris.Text = "Giriş";
            btnGiris.UseVisualStyleBackColor = false;
            btnGiris.Click += btnGiris_Click;
            // 
            // GirişForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1221, 684);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "GirişForm";
            Text = "GirişForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Panel panel2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private Button btnGiris;
        private LinkLabel linkLabel1;
        private TextBox txtSifre;
        private TextBox txtKullaniciAdi;
        private Label lblHata;
    }
}