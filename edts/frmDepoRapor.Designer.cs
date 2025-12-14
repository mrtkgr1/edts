namespace edts
{
    partial class frmDepoRapor
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
            panel3 = new Panel();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            comboBox2 = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            button2 = new Button();
            button1 = new Button();
            label1 = new Label();
            comboBox1 = new ComboBox();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkOliveGreen;
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1114, 317);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLightLight;
            panel3.Controls.Add(dateTimePicker2);
            panel3.Controls.Add(dateTimePicker1);
            panel3.Controls.Add(comboBox2);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(button1);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(comboBox1);
            panel3.Location = new Point(80, 68);
            panel3.Name = "panel3";
            panel3.Size = new Size(871, 215);
            panel3.TabIndex = 0;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(181, 116);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(250, 27);
            dateTimePicker2.TabIndex = 17;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(181, 72);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 16;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(247, 172);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.Location = new Point(135, 177);
            label4.Name = "label4";
            label4.Size = new Size(106, 23);
            label4.TabIndex = 14;
            label4.Text = "Ürün Seçimi:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(85, 120);
            label3.Name = "label3";
            label3.Size = new Size(90, 23);
            label3.TabIndex = 13;
            label3.Text = "Bitiş Tarihi:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label2.Location = new Point(45, 76);
            label2.Name = "label2";
            label2.Size = new Size(130, 23);
            label2.TabIndex = 12;
            label2.Text = "Başlangıç Tarihi:";
            // 
            // button2
            // 
            button2.BackColor = Color.DarkCyan;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button2.ForeColor = SystemColors.ControlLightLight;
            button2.Location = new Point(531, 173);
            button2.Name = "button2";
            button2.Size = new Size(121, 27);
            button2.TabIndex = 11;
            button2.Text = "Excel'e Aktar";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.LimeGreen;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(404, 172);
            button1.Name = "button1";
            button1.Size = new Size(121, 28);
            button1.TabIndex = 10;
            button1.Text = "Raporu Getir";
            button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label1.Location = new Point(85, 30);
            label1.Name = "label1";
            label1.Size = new Size(86, 23);
            label1.TabIndex = 9;
            label1.Text = "İşlem Tipi:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(177, 25);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 8;
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 317);
            panel2.Name = "panel2";
            panel2.Size = new Size(1114, 418);
            panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1114, 418);
            dataGridView1.TabIndex = 1;
            // 
            // frmDepoRapor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1114, 735);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmDepoRapor";
            Text = "frmDepoRapor";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private ComboBox comboBox2;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button button2;
        private Button button1;
        private Label label1;
        private ComboBox comboBox1;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private DataGridView dataGridView1;
    }
}