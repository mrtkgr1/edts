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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GirişForm));
            rightPanel = new Panel();
            linkLabel2 = new LinkLabel();
            chkRemember = new CheckBox();
            kavisliButon1 = new ResizableButton();
            label2 = new Label();
            label1 = new Label();
            loginpsw = new TextBox();
            txtSifre = new TextBox();
            leftPanel = new Panel();
            rightPanel.SuspendLayout();
            SuspendLayout();
            // 
            // rightPanel
            // 
            rightPanel.BackColor = Color.LightBlue;
            rightPanel.Controls.Add(linkLabel2);
            rightPanel.Controls.Add(chkRemember);
            rightPanel.Controls.Add(kavisliButon1);
            rightPanel.Controls.Add(label2);
            rightPanel.Controls.Add(label1);
            rightPanel.Controls.Add(loginpsw);
            rightPanel.Controls.Add(txtSifre);
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.Location = new Point(600, 0);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(707, 738);
            rightPanel.TabIndex = 3;
            rightPanel.Paint += rightPanel_Paint;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            linkLabel2.LinkColor = Color.WhiteSmoke;
            linkLabel2.Location = new Point(238, 650);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(202, 20);
            linkLabel2.TabIndex = 26;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Bir sorun mu yaşıyorsunuz?";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // chkRemember
            // 
            chkRemember.AutoSize = true;
            chkRemember.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            chkRemember.ForeColor = SystemColors.ControlLightLight;
            chkRemember.Location = new Point(344, 318);
            chkRemember.Name = "chkRemember";
            chkRemember.Size = new Size(113, 24);
            chkRemember.TabIndex = 25;
            chkRemember.Text = "Beni Hatırla";
            chkRemember.UseVisualStyleBackColor = true;
            // 
            // kavisliButon1
            // 
            kavisliButon1.BackColor = Color.DarkSlateGray;
            kavisliButon1.FlatAppearance.BorderSize = 0;
            kavisliButon1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            kavisliButon1.ForeColor = SystemColors.ButtonFace;
            kavisliButon1.Image = null;
            kavisliButon1.KaynakResim = null;
            kavisliButon1.Location = new Point(269, 384);
            kavisliButon1.Name = "kavisliButon1";
            kavisliButon1.ResimBoyutu = 24;
            kavisliButon1.Size = new Size(126, 42);
            kavisliButon1.TabIndex = 23;
            kavisliButon1.Text = "Giriş Yap";
            kavisliButon1.UseVisualStyleBackColor = false;
            kavisliButon1.Click += kavisliButon1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(177, 269);
            label2.Name = "label2";
            label2.Size = new Size(30, 20);
            label2.TabIndex = 22;
            label2.Text = "🔒";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(177, 207);
            label1.Name = "label1";
            label1.Size = new Size(30, 20);
            label1.TabIndex = 21;
            label1.Text = "👤";
            // 
            // loginpsw
            // 
            loginpsw.BorderStyle = BorderStyle.FixedSingle;
            loginpsw.Location = new Point(215, 267);
            loginpsw.Margin = new Padding(3, 4, 3, 4);
            loginpsw.Name = "loginpsw";
            loginpsw.PasswordChar = '*';
            loginpsw.Size = new Size(242, 27);
            loginpsw.TabIndex = 20;
            loginpsw.TextChanged += loginpsw_TextChanged;
            loginpsw.Enter += loginpsw_Enter_1;
            loginpsw.Leave += loginpsw_Leave_1;
            // 
            // txtSifre
            // 
            txtSifre.BorderStyle = BorderStyle.FixedSingle;
            txtSifre.Location = new Point(213, 207);
            txtSifre.Margin = new Padding(3, 4, 3, 4);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(242, 27);
            txtSifre.TabIndex = 19;
            txtSifre.TextChanged += txtSifre_TextChanged;
            txtSifre.Enter += txtSifre_Enter;
            txtSifre.Leave += txtSifre_Leave;
            // 
            // leftPanel
            // 
            leftPanel.BackColor = SystemColors.ControlLightLight;
            leftPanel.BackgroundImage = (Image)resources.GetObject("leftPanel.BackgroundImage");
            leftPanel.BackgroundImageLayout = ImageLayout.Zoom;
            leftPanel.Dock = DockStyle.Left;
            leftPanel.Location = new Point(0, 0);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(600, 738);
            leftPanel.TabIndex = 2;
            // 
            // GirişForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(31, 41, 55);
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1307, 738);
            Controls.Add(rightPanel);
            Controls.Add(leftPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            KeyPreview = true;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimumSize = new Size(440, 467);
            Name = "GirişForm";
            Text = "EDTS - Giriş Ekranı";
            Load += GirişForm_Load;
            rightPanel.ResumeLayout(false);
            rightPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel rightPanel;
        private CheckBox chkRemember;
        private ResizableButton kavisliButon1;
        private Label label2;
        private Label label1;
        private TextBox loginpsw;
        private TextBox txtSifre;
        private Panel leftPanel;
        private LinkLabel linkLabel2;
    }
}