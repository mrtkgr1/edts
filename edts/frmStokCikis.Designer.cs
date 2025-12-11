namespace EnvanterDepoSistemitaslak2
{
    partial class frmStokCikis
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
            panel1 = new Panel();
            groupBox3 = new GroupBox();
            textBox2 = new TextBox();
            comboBox2 = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            groupBox4 = new GroupBox();
            label1 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            panel4 = new Panel();
            button2 = new Button();
            button1 = new Button();
            button3 = new Button();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            comboBox3 = new ComboBox();
            panel1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkOliveGreen;
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(groupBox4);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(389, 692);
            panel1.TabIndex = 2;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button3);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(textBox2);
            groupBox3.Controls.Add(comboBox2);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(label4);
            groupBox3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            groupBox3.ForeColor = SystemColors.ControlLightLight;
            groupBox3.Location = new Point(61, 346);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(250, 252);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Ürün Ekleme";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(89, 139);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(151, 30);
            textBox2.TabIndex = 3;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(89, 51);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 31);
            comboBox2.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(22, 142);
            label3.Name = "label3";
            label3.Size = new Size(54, 23);
            label3.TabIndex = 1;
            label3.Text = "Adet:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(22, 50);
            label4.Name = "label4";
            label4.Size = new Size(54, 23);
            label4.TabIndex = 0;
            label4.Text = "Ürün:";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(comboBox3);
            groupBox4.Controls.Add(comboBox1);
            groupBox4.Controls.Add(textBox1);
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(label5);
            groupBox4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            groupBox4.ForeColor = SystemColors.ControlLightLight;
            groupBox4.Location = new Point(61, 12);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(250, 311);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            groupBox4.Text = "Sevkiyat Bilgileri";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(108, 85);
            label1.Name = "label1";
            label1.Size = new Size(126, 23);
            label1.TabIndex = 4;
            label1.Text = "Mevcut Stok: 0";
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(dataGridView1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(389, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(699, 323);
            panel2.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLightLight;
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(389, 323);
            panel3.Name = "panel3";
            panel3.Size = new Size(699, 369);
            panel3.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(699, 323);
            dataGridView1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ControlDark;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(274, 9);
            label2.Name = "label2";
            label2.Size = new Size(174, 28);
            label2.TabIndex = 2;
            label2.Text = "SEVKİYAT LİSTESİ";
            // 
            // panel4
            // 
            panel4.Controls.Add(button2);
            panel4.Controls.Add(button1);
            panel4.Location = new Point(141, 23);
            panel4.Name = "panel4";
            panel4.Size = new Size(467, 125);
            panel4.TabIndex = 2;
            // 
            // button2
            // 
            button2.BackColor = Color.Green;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            button2.ForeColor = SystemColors.ControlLightLight;
            button2.Location = new Point(48, 24);
            button2.Name = "button2";
            button2.Size = new Size(182, 77);
            button2.TabIndex = 3;
            button2.Text = "Çıkışı Onayla";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Crimson;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(236, 24);
            button1.Name = "button1";
            button1.Size = new Size(182, 77);
            button1.TabIndex = 2;
            button1.Text = "Listeyi Temizle";
            button1.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.DarkCyan;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(108, 195);
            button3.Name = "button3";
            button3.Size = new Size(132, 29);
            button3.TabIndex = 5;
            button3.Text = "Listeye Ekle";
            button3.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(36, 57);
            label5.Name = "label5";
            label5.Size = new Size(76, 23);
            label5.TabIndex = 0;
            label5.Text = "Müşteri:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(36, 135);
            label6.Name = "label6";
            label6.Size = new Size(97, 23);
            label6.TabIndex = 1;
            label6.Text = "Sipariş No:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(36, 225);
            label7.Name = "label7";
            label7.Size = new Size(110, 23);
            label7.TabIndex = 2;
            label7.Text = "Çıkış Nedeni";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(36, 161);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(151, 30);
            textBox1.TabIndex = 3;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(36, 83);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 31);
            comboBox1.TabIndex = 4;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(36, 251);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(151, 31);
            comboBox3.TabIndex = 5;
            // 
            // frmStokCikis
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1088, 692);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmStokCikis";
            Text = "frmStokCikis";
            panel1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private GroupBox groupBox3;
        private Label label1;
        private TextBox textBox2;
        private ComboBox comboBox2;
        private Label label3;
        private Label label4;
        private GroupBox groupBox4;
        private Panel panel2;
        private Label label2;
        private DataGridView dataGridView1;
        private Panel panel3;
        private Panel panel4;
        private Button button2;
        private Button button1;
        private Button button3;
        private ComboBox comboBox3;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private Label label7;
        private Label label6;
        private Label label5;
    }
}