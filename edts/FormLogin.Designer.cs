namespace edts
{
    partial class FormLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            textBox1 = new TextBox();
            button1 = new Button();
            loginpsw = new TextBox();
            button2 = new Button();
            linkLabel1 = new LinkLabel();
            label1 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            hatalipsw = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top;
            textBox1.BackColor = SystemColors.Desktop;
            textBox1.Font = new Font("Segoe UI", 11F);
            textBox1.ForeColor = SystemColors.InactiveBorder;
            textBox1.Location = new Point(84, 209);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(309, 32);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top;
            button1.Font = new Font("Segoe UI", 12F);
            button1.Location = new Point(270, 342);
            button1.Name = "button1";
            button1.Size = new Size(123, 40);
            button1.TabIndex = 2;
            button1.Text = "Giriş yap";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // loginpsw
            // 
            loginpsw.BackColor = SystemColors.Desktop;
            loginpsw.BorderStyle = BorderStyle.None;
            loginpsw.Font = new Font("Segoe UI", 11F);
            loginpsw.ForeColor = SystemColors.InactiveBorder;
            loginpsw.Location = new Point(3, 3);
            loginpsw.Name = "loginpsw";
            loginpsw.PasswordChar = '*';
            loginpsw.Size = new Size(271, 25);
            loginpsw.TabIndex = 1;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.WindowText;
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(274, 3);
            button2.Margin = new Padding(0);
            button2.Name = "button2";
            button2.Size = new Size(30, 25);
            button2.TabIndex = 6;
            button2.TabStop = false;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = AnchorStyles.Top;
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            linkLabel1.LinkArea = new LinkArea(0, 34);
            linkLabel1.LinkColor = Color.SkyBlue;
            linkLabel1.Location = new Point(146, 20);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(193, 28);
            linkLabel1.TabIndex = 8;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Sorun mu yaşıyorsunuz?";
            linkLabel1.UseCompatibleTextRendering = true;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(84, 181);
            label1.Name = "label1";
            label1.Size = new Size(115, 25);
            label1.TabIndex = 10;
            label1.Text = "Kullanıcı adı";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.ForeColor = Color.Silver;
            label2.Location = new Point(84, 253);
            label2.Name = "label2";
            label2.Size = new Size(50, 25);
            label2.TabIndex = 11;
            label2.Text = "Şifre";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top;
            panel1.AutoSize = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(loginpsw);
            panel1.Controls.Add(button2);
            panel1.Location = new Point(84, 281);
            panel1.Name = "panel1";
            panel1.Size = new Size(308, 35);
            panel1.TabIndex = 1;
            // 
            // hatalipsw
            // 
            hatalipsw.Anchor = AnchorStyles.Top;
            hatalipsw.AutoSize = true;
            hatalipsw.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            hatalipsw.ForeColor = Color.Red;
            hatalipsw.Location = new Point(84, 156);
            hatalipsw.Name = "hatalipsw";
            hatalipsw.Size = new Size(238, 25);
            hatalipsw.TabIndex = 12;
            hatalipsw.Text = "*Kullanıcı adı veya şifre hatalı";
            hatalipsw.Visible = false;
            // 
            // panel2
            // 
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.BackColor = Color.FromArgb(31, 41, 55);
            panel2.Controls.Add(hatalipsw);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(474, 534);
            panel2.TabIndex = 13;
            // 
            // panel3
            // 
            panel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel3.Controls.Add(linkLabel1);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 492);
            panel3.Margin = new Padding(3, 0, 3, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(474, 42);
            panel3.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(31, 41, 55);
            ClientSize = new Size(474, 534);
            Controls.Add(panel3);
            Controls.Add(panel2);
            KeyPreview = true;
            MinimumSize = new Size(440, 470);
            Name = "Form1";
            Text = "EDTS-Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private TextBox loginpsw;
        private Button button2;
        private LinkLabel linkLabel1;
        private Label label1;
        private Label label2;
        private Panel panel1;
        private Label hatalipsw;
        private Panel panel2;
        private Panel panel3;
    }
}
