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
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            button1 = new Button();
            label2 = new Label();
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
            panel2.Controls.Add(label2);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(pictureBox3);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(button1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(576, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(645, 684);
            panel2.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(240, 290);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(165, 27);
            textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(240, 210);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(165, 27);
            textBox1.TabIndex = 3;
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
            // button1
            // 
            button1.BackColor = Color.DarkOliveGreen;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(324, 352);
            button1.Name = "button1";
            button1.Size = new Size(81, 44);
            button1.TabIndex = 0;
            button1.Text = "Giriş";
            button1.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(105, 365);
            label2.Name = "label2";
            label2.Size = new Size(210, 20);
            label2.TabIndex = 5;
            label2.Text = "*Kullanıcı Adı veya Şifre Hatalı";
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
        private Button button1;
        private LinkLabel linkLabel1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label2;
    }
}