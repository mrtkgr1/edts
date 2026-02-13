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
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GirişForm));
            button2 = new Button();
            loginForm = new Panel();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            loginpsw = new TextBox();
            textBox1 = new TextBox();
            btnGiris = new KavisliButon();
            loginForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(200, 422);
            button2.Margin = new Padding(0);
            button2.Name = "button2";
            button2.Size = new Size(26, 21);
            button2.TabIndex = 6;
            button2.TabStop = false;
            button2.UseVisualStyleBackColor = false;
            button2.Visible = false;
            button2.Click += button2_Click;
            // 
            // loginForm
            // 
            loginForm.BackColor = Color.Gainsboro;
            loginForm.Controls.Add(label2);
            loginForm.Controls.Add(button2);
            loginForm.Controls.Add(label1);
            loginForm.Controls.Add(pictureBox1);
            loginForm.Controls.Add(loginpsw);
            loginForm.Controls.Add(textBox1);
            loginForm.Controls.Add(kavisliButon1);
            loginForm.Location = new Point(425, 0);
            loginForm.Name = "loginForm";
            loginForm.Size = new Size(295, 626);
            loginForm.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 297);
            label2.Name = "label2";
            label2.Size = new Size(26, 17);
            label2.TabIndex = 7;
            label2.Text = "🔒";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 257);
            label1.Name = "label1";
            label1.Size = new Size(26, 17);
            label1.TabIndex = 6;
            label1.Text = "👤";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(60, 11);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(165, 111);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // loginpsw
            // 
            loginpsw.BorderStyle = BorderStyle.FixedSingle;
            loginpsw.Location = new Point(61, 295);
            loginpsw.Name = "loginpsw";
            loginpsw.PasswordChar = '*';
            loginpsw.Size = new Size(166, 25);
            loginpsw.TabIndex = 4;
            loginpsw.Enter += loginpsw_Enter;
            loginpsw.Leave += loginpsw_Leave;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(61, 256);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(166, 25);
            textBox1.TabIndex = 3;
            textBox1.Enter += textBox1_Enter;
            textBox1.Leave += textBox1_Leave;
            // 
            // kavisliButon1
            // 
            kavisliButon1.BackColor = Color.LightSlateGray;
            kavisliButon1.BorderRadius = 30;
            kavisliButon1.FlatAppearance.BorderSize = 0;
            kavisliButon1.FlatStyle = FlatStyle.Flat;
            kavisliButon1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            kavisliButon1.ForeColor = SystemColors.ControlLightLight;
            kavisliButon1.Location = new Point(95, 336);
            kavisliButon1.Name = "kavisliButon1";
            kavisliButon1.Size = new Size(94, 36);
            kavisliButon1.TabIndex = 0;
            kavisliButon1.Text = "Giriş Yap";
            kavisliButon1.UseVisualStyleBackColor = false;
            kavisliButon1.Click += btnGiris_Click;
            // 
            // GirişForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(31, 41, 55);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1144, 627);
            Controls.Add(loginForm);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            KeyPreview = true;
            MaximizeBox = false;
            MinimumSize = new Size(387, 404);
            Name = "GirişForm";
            Text = "EDTS - Giriş Ekranı";
            Load += GirişForm_Load;
            loginForm.ResumeLayout(false);
            loginForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button button2;
        private Panel loginForm;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
        private TextBox loginpsw;
        private TextBox textBox1;
        private KavisliButon btnGiris;
    }
}