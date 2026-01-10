using System.Windows.Forms;
using System.Data.SqlClient; // SQL Server ile iletişim için
using System.Configuration;
namespace edts {
    partial class GirişForm {
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
            tableLayoutPanel1 = new TableLayoutPanel();
            panel4 = new Panel();
            label3 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top;
            textBox1.BackColor = SystemColors.Control;
            textBox1.Font = new Font("Segoe UI", 11F);
            textBox1.ForeColor = SystemColors.ControlText;
            textBox1.Location = new Point(106, 209);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(309, 32);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top;
            button1.BackColor = Color.FromArgb(0, 0, 192);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(291, 342);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(125, 40);
            button1.TabIndex = 2;
            button1.Text = "Giriş yap";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnGiris_Click;
            // 
            // loginpsw
            // 
            loginpsw.BackColor = SystemColors.Control;
            loginpsw.BorderStyle = BorderStyle.None;
            loginpsw.Font = new Font("Segoe UI", 11F);
            loginpsw.ForeColor = SystemColors.ControlText;
            loginpsw.Location = new Point(3, 4);
            loginpsw.Margin = new Padding(0);
            loginpsw.Name = "loginpsw";
            loginpsw.PasswordChar = '*';
            loginpsw.Size = new Size(271, 25);
            loginpsw.TabIndex = 1;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(0, 0, 192);
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(274, 4);
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
            linkLabel1.LinkColor = Color.DarkSlateGray;
            linkLabel1.Location = new Point(168, 20);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(193, 28);
            linkLabel1.TabIndex = 8;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Sorun mu yaşıyorsunuz?";
            linkLabel1.UseCompatibleTextRendering = true;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(106, 181);
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
            label2.ForeColor = Color.Black;
            label2.Location = new Point(106, 253);
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
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(loginpsw);
            panel1.Controls.Add(button2);
            panel1.Location = new Point(106, 281);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(304, 29);
            panel1.TabIndex = 1;
            // 
            // hatalipsw
            // 
            hatalipsw.Anchor = AnchorStyles.Top;
            hatalipsw.AutoSize = true;
            hatalipsw.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            hatalipsw.ForeColor = Color.Red;
            hatalipsw.Location = new Point(106, 156);
            hatalipsw.Name = "hatalipsw";
            hatalipsw.Size = new Size(238, 25);
            hatalipsw.TabIndex = 12;
            hatalipsw.Text = "*Kullanıcı adı veya şifre hatalı";
            hatalipsw.Visible = false;
            // 
            // panel2
            // 
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.BackColor = Color.Gainsboro;
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(hatalipsw);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(517, 0);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(518, 534);
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
            panel3.Size = new Size(518, 42);
            panel3.TabIndex = 13;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.BackColor = Color.WhiteSmoke;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel2, 1, 0);
            tableLayoutPanel1.Controls.Add(panel4, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1035, 534);
            tableLayoutPanel1.TabIndex = 13;
            // 
            // panel4
            // 
            panel4.BackgroundImage = Properties.Resources.loginImage;
            panel4.BackgroundImageLayout = ImageLayout.Stretch;
            panel4.Controls.Add(label3);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 0);
            panel4.Margin = new Padding(0);
            panel4.Name = "panel4";
            panel4.Size = new Size(517, 534);
            panel4.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(128, 128, 255);
            label3.Location = new Point(6, 29);
            label3.Name = "label3";
            label3.Size = new Size(502, 47);
            label3.TabIndex = 0;
            label3.Text = "Envanter Depo Takip Sistemi ";
            // 
            // GirişForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(31, 41, 55);
            ClientSize = new Size(1035, 534);
            Controls.Add(tableLayoutPanel1);
            KeyPreview = true;
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(440, 469);
            Name = "GirişForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
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
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel4;
        private Label label3;
    }
}