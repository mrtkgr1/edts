namespace edts {
    partial class pSfrD {
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
            panel4 = new Panel();
            label4 = new Label();
            button2 = new Button();
            buttonOnay = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            textBox1 = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            textBox2 = new TextBox();
            label2 = new Label();
            panel3 = new Panel();
            textBox3 = new TextBox();
            label3 = new Label();
            panel4.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel4
            // 
            panel4.BackColor = Color.WhiteSmoke;
            panel4.Controls.Add(label4);
            panel4.Controls.Add(button2);
            panel4.Controls.Add(buttonOnay);
            panel4.Controls.Add(flowLayoutPanel1);
            panel4.Location = new Point(12, 12);
            panel4.Name = "panel4";
            panel4.Size = new Size(244, 206);
            panel4.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(64, 5);
            label4.Name = "label4";
            label4.Size = new Size(113, 25);
            label4.TabIndex = 8;
            label4.Text = "Şifre Değiştir";
            // 
            // button2
            // 
            button2.Location = new Point(9, 176);
            button2.Name = "button2";
            button2.Size = new Size(83, 25);
            button2.TabIndex = 7;
            button2.Text = "İptal";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // buttonOnay
            // 
            buttonOnay.Location = new Point(156, 176);
            buttonOnay.Name = "buttonOnay";
            buttonOnay.Size = new Size(83, 25);
            buttonOnay.TabIndex = 6;
            buttonOnay.Text = "Onayla";
            buttonOnay.UseVisualStyleBackColor = true;
            buttonOnay.Click += buttonOnay_Click_1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.Controls.Add(panel2);
            flowLayoutPanel1.Controls.Add(panel3);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(3, 44);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(239, 117);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(233, 33);
            panel1.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(108, 3);
            textBox1.Name = "textBox1";
            textBox1.PasswordChar = '*';
            textBox1.Size = new Size(110, 25);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 6);
            label1.Name = "label1";
            label1.Size = new Size(62, 17);
            label1.TabIndex = 0;
            label1.Text = "Eski şifre:";
            // 
            // panel2
            // 
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(3, 42);
            panel2.Name = "panel2";
            panel2.Size = new Size(233, 33);
            panel2.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(108, 3);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(110, 25);
            textBox2.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 6);
            label2.Name = "label2";
            label2.Size = new Size(63, 17);
            label2.TabIndex = 0;
            label2.Text = "Yeni şifre:";
            // 
            // panel3
            // 
            panel3.Controls.Add(textBox3);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(3, 81);
            panel3.Name = "panel3";
            panel3.Size = new Size(233, 33);
            panel3.TabIndex = 3;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(108, 3);
            textBox3.Name = "textBox3";
            textBox3.PasswordChar = '*';
            textBox3.Size = new Size(110, 25);
            textBox3.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 6);
            label3.Name = "label3";
            label3.Size = new Size(101, 17);
            label3.TabIndex = 0;
            label3.Text = "Yeni şifre tekrar:";
            // 
            // pSfrD
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(268, 230);
            Controls.Add(panel4);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "pSfrD";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Şifre değiştir";
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel4;
        private Label label4;
        private Button button2;
        private Button buttonOnay;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private TextBox textBox1;
        private Label label1;
        private Panel panel2;
        private TextBox textBox2;
        private Label label2;
        private Panel panel3;
        private TextBox textBox3;
        private Label label3;
    }
}