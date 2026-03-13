using System.Windows.Forms;
using System.Data.SqlClient; // SQL Server ile iletişim için
using System.Configuration;
namespace edts {
    partial class GirisForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GirisForm));
            rightPanel = new Panel();
            linkLabel2 = new LinkLabel();
            chkRemember = new CheckBox();
            kavisliButon1 = new ResizableButton();
            label2 = new Label();
            label1 = new Label();
            loginpsw = new TextBox();
            txtKullaniciAdi = new TextBox();
            leftPanel = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            rightPanel.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // rightPanel
            // 
            rightPanel.AutoSize = true;
            rightPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            rightPanel.BackColor = Color.LightBlue;
            rightPanel.Controls.Add(linkLabel2);
            rightPanel.Controls.Add(chkRemember);
            rightPanel.Controls.Add(kavisliButon1);
            rightPanel.Controls.Add(label2);
            rightPanel.Controls.Add(label1);
            rightPanel.Controls.Add(loginpsw);
            rightPanel.Controls.Add(txtKullaniciAdi);
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.Location = new Point(449, 0);
            rightPanel.Margin = new Padding(0);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(449, 491);
            rightPanel.TabIndex = 3;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            linkLabel2.LinkColor = Color.WhiteSmoke;
            linkLabel2.Location = new Point(116, 457);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(190, 19);
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
            chkRemember.Location = new Point(289, 49);
            chkRemember.Name = "chkRemember";
            chkRemember.Size = new Size(107, 23);
            chkRemember.TabIndex = 25;
            chkRemember.Text = "Beni Hatırla";
            chkRemember.UseVisualStyleBackColor = true;
            chkRemember.Visible = false;
            // 
            // kavisliButon1
            // 
            kavisliButon1.BackColor = Color.DarkSlateGray;
            kavisliButon1.FlatAppearance.BorderSize = 0;
            kavisliButon1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            kavisliButon1.ForeColor = SystemColors.ButtonFace;
            kavisliButon1.Image = null;
            kavisliButon1.KaynakResim = null;
            kavisliButon1.Location = new Point(165, 320);
            kavisliButon1.Name = "kavisliButon1";
            kavisliButon1.ResimBoyutu = 24;
            kavisliButon1.Size = new Size(110, 36);
            kavisliButon1.TabIndex = 23;
            kavisliButon1.Text = "Giriş Yap";
            kavisliButon1.UseVisualStyleBackColor = false;
            kavisliButon1.Click += kavisliButon1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(93, 207);
            label2.Name = "label2";
            label2.Size = new Size(26, 17);
            label2.TabIndex = 22;
            label2.Text = "🔒";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(93, 156);
            label1.Name = "label1";
            label1.Size = new Size(26, 17);
            label1.TabIndex = 21;
            label1.Text = "👤";
            // 
            // loginpsw
            // 
            loginpsw.BorderStyle = BorderStyle.FixedSingle;
            loginpsw.Location = new Point(125, 205);
            loginpsw.Name = "loginpsw";
            loginpsw.PasswordChar = '*';
            loginpsw.Size = new Size(212, 25);
            loginpsw.TabIndex = 20;
            loginpsw.TextChanged += loginpsw_TextChanged;
            loginpsw.Enter += loginpsw_Enter_1;
            loginpsw.Leave += loginpsw_Leave_1;
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.BorderStyle = BorderStyle.FixedSingle;
            txtKullaniciAdi.Location = new Point(125, 154);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(212, 25);
            txtKullaniciAdi.TabIndex = 19;
            txtKullaniciAdi.TextChanged += txtSifre_TextChanged;
            txtKullaniciAdi.Enter += txtSifre_Enter;
            txtKullaniciAdi.Leave += txtSifre_Leave;
            // 
            // leftPanel
            // 
            leftPanel.BackColor = SystemColors.ControlLightLight;
            leftPanel.BackgroundImage = (Image)resources.GetObject("leftPanel.BackgroundImage");
            leftPanel.BackgroundImageLayout = ImageLayout.Zoom;
            leftPanel.Dock = DockStyle.Fill;
            leftPanel.Location = new Point(0, 0);
            leftPanel.Margin = new Padding(0);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(449, 491);
            leftPanel.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(rightPanel, 1, 0);
            tableLayoutPanel1.Controls.Add(leftPanel, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(898, 491);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // GirisForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(31, 41, 55);
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(898, 491);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            KeyPreview = true;
            MaximizeBox = false;
            MinimumSize = new Size(387, 403);
            Name = "GirisForm";
            Text = "EDTS - Giriş Ekranı";
            Load += GirişForm_Load;
            rightPanel.ResumeLayout(false);
            rightPanel.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel rightPanel;
        private CheckBox chkRemember;
        private ResizableButton kavisliButon1;
        private Label label2;
        private Label label1;
        private TextBox loginpsw;
        private TextBox txtKullaniciAdi;
        private Panel leftPanel;
        private LinkLabel linkLabel2;
        private TableLayoutPanel tableLayoutPanel1;
    }
}