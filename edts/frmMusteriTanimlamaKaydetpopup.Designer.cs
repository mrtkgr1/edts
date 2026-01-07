namespace edts
{
    partial class frmMusteriTanimlamaKaydetpopup
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
            tabControl1 = new TabControl();
            tabPage4 = new TabPage();
            btnMusteriKayit = new Button();
            label6 = new Label();
            textMusteriTel = new TextBox();
            textMusteriVd = new TextBox();
            textMusteriVNo = new TextBox();
            textMusteriAd = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            tabControl1.SuspendLayout();
            tabPage4.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            tabControl1.Location = new Point(8, 13);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(644, 556);
            tabControl1.TabIndex = 3;
            // 
            // tabPage4
            // 
            tabPage4.BackColor = Color.LightSlateGray;
            tabPage4.Controls.Add(btnMusteriKayit);
            tabPage4.Controls.Add(label6);
            tabPage4.Controls.Add(textMusteriTel);
            tabPage4.Controls.Add(textMusteriVd);
            tabPage4.Controls.Add(textMusteriVNo);
            tabPage4.Controls.Add(textMusteriAd);
            tabPage4.Controls.Add(label7);
            tabPage4.Controls.Add(label8);
            tabPage4.Controls.Add(label9);
            tabPage4.Location = new Point(4, 37);
            tabPage4.Margin = new Padding(3, 4, 3, 4);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3, 4, 3, 4);
            tabPage4.Size = new Size(636, 515);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Müşteri Tanımlama";
            // 
            // btnMusteriKayit
            // 
            btnMusteriKayit.BackColor = SystemColors.ControlLightLight;
            btnMusteriKayit.FlatAppearance.BorderSize = 0;
            btnMusteriKayit.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnMusteriKayit.Location = new Point(358, 298);
            btnMusteriKayit.Margin = new Padding(3, 4, 3, 4);
            btnMusteriKayit.Name = "btnMusteriKayit";
            btnMusteriKayit.Size = new Size(138, 38);
            btnMusteriKayit.TabIndex = 8;
            btnMusteriKayit.Text = "Kaydet";
            btnMusteriKayit.UseVisualStyleBackColor = false;
            btnMusteriKayit.Click += btnMusteriKayit_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label6.ForeColor = SystemColors.ControlLightLight;
            label6.Location = new Point(72, 237);
            label6.Name = "label6";
            label6.Size = new Size(78, 23);
            label6.TabIndex = 7;
            label6.Text = "Telefon: ";
            // 
            // textMusteriTel
            // 
            textMusteriTel.Location = new Point(211, 217);
            textMusteriTel.Margin = new Padding(3, 4, 3, 4);
            textMusteriTel.Multiline = true;
            textMusteriTel.Name = "textMusteriTel";
            textMusteriTel.Size = new Size(285, 35);
            textMusteriTel.TabIndex = 6;
            // 
            // textMusteriVd
            // 
            textMusteriVd.Location = new Point(211, 168);
            textMusteriVd.Margin = new Padding(3, 4, 3, 4);
            textMusteriVd.Name = "textMusteriVd";
            textMusteriVd.Size = new Size(285, 34);
            textMusteriVd.TabIndex = 5;
            // 
            // textMusteriVNo
            // 
            textMusteriVNo.Location = new Point(211, 115);
            textMusteriVNo.Margin = new Padding(3, 4, 3, 4);
            textMusteriVNo.Name = "textMusteriVNo";
            textMusteriVNo.Size = new Size(285, 34);
            textMusteriVNo.TabIndex = 4;
            // 
            // textMusteriAd
            // 
            textMusteriAd.Location = new Point(211, 67);
            textMusteriAd.Margin = new Padding(3, 4, 3, 4);
            textMusteriAd.Name = "textMusteriAd";
            textMusteriAd.Size = new Size(285, 34);
            textMusteriAd.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label7.ForeColor = SystemColors.ControlLightLight;
            label7.Location = new Point(72, 180);
            label7.Name = "label7";
            label7.Size = new Size(117, 23);
            label7.TabIndex = 2;
            label7.Text = "Vergi Dairesi:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label8.ForeColor = SystemColors.ControlLightLight;
            label8.Location = new Point(72, 127);
            label8.Name = "label8";
            label8.Size = new Size(85, 23);
            label8.TabIndex = 1;
            label8.Text = "Vergi No:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label9.ForeColor = SystemColors.ControlLightLight;
            label9.Location = new Point(72, 79);
            label9.Name = "label9";
            label9.Size = new Size(109, 23);
            label9.TabIndex = 0;
            label9.Text = "Müşteri Adı:";
            // 
            // frmMusteriTanimlamaKaydetpopup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(664, 579);
            Controls.Add(tabControl1);
            Name = "frmMusteriTanimlamaKaydetpopup";
            Text = "frmMusteriTanimlamaKaydetpopup";
            Load += frmMusteriTanimlamaKaydetpopup_Load;
            tabControl1.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage4;
        private Button btnMusteriKayit;
        private Label label6;
        private TextBox textMusteriTel;
        private TextBox textMusteriVd;
        private TextBox textMusteriVNo;
        private TextBox textMusteriAd;
        private Label label7;
        private Label label8;
        private Label label9;
    }
}