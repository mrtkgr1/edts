namespace edts
{
    partial class frmTedarikciYonetim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTedarikciYonetim));
            panel2 = new Panel();
            dataGridView2 = new DataGridView();
            btnSilSutun = new DataGridViewButtonColumn();
            btnGuncelleSutun = new DataGridViewButtonColumn();
            panel1 = new Panel();
            button1 = new Button();
            label1 = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 97);
            panel2.Name = "panel2";
            panel2.Size = new Size(1192, 694);
            panel2.TabIndex = 5;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { btnSilSutun, btnGuncelleSutun });
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.Location = new Point(0, 0);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(1192, 694);
            dataGridView2.TabIndex = 0;
            dataGridView2.CellClick += dataGridView2_CellClick;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            dataGridView2.CellPainting += dataGridView2_CellPainting;
            dataGridView2.MouseLeave += dataGridView2_MouseLeave;
            dataGridView2.MouseMove += dataGridView2_MouseMove;
            // 
            // btnSilSutun
            // 
            btnSilSutun.HeaderText = "Sil";
            btnSilSutun.MinimumWidth = 6;
            btnSilSutun.Name = "btnSilSutun";
            btnSilSutun.Text = "🗑";
            btnSilSutun.UseColumnTextForButtonValue = true;
            btnSilSutun.Width = 125;
            // 
            // btnGuncelleSutun
            // 
            btnGuncelleSutun.HeaderText = "Güncelle";
            btnGuncelleSutun.MinimumWidth = 6;
            btnGuncelleSutun.Name = "btnGuncelleSutun";
            btnGuncelleSutun.Text = "📝";
            btnGuncelleSutun.UseColumnTextForButtonValue = true;
            btnGuncelleSutun.Width = 125;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1192, 97);
            panel1.TabIndex = 4;
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.Location = new Point(26, 55);
            button1.Name = "button1";
            button1.Size = new Size(206, 36);
            button1.TabIndex = 3;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(26, 24);
            label1.Name = "label1";
            label1.Size = new Size(206, 28);
            label1.TabIndex = 4;
            label1.Text = "Tedarikçi Tanımlama";
            // 
            // frmTedarikciYonetim
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1192, 791);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmTedarikciYonetim";
            Text = "frmTedarikciYonetim";
            Load += frmTedarikciYonetim_Load;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private DataGridView dataGridView2;
        private Panel panel1;
        private DataGridViewButtonColumn btnSilSutun;
        private DataGridViewButtonColumn btnGuncelleSutun;
        private Button button1;
        private Label label1;
    }
}