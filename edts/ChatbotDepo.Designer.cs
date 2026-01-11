namespace edts
{
    partial class ChatbotDepo
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
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatbotDepo));
            panel4 = new Panel();
            flowChatt = new FlowLayoutPanel();
            panel3 = new Panel();
            btnGonderr = new Button();
            panel2 = new Panel();
            btnSesliOkumaa = new Button();
            panel1 = new Panel();
            txtSoruu = new TextBox();
            panel5 = new Panel();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(flowChatt);
            panel4.Location = new Point(34, 26);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(2);
            panel4.Size = new Size(517, 246);
            panel4.TabIndex = 11;
            panel4.Paint += panel4_Paint;
            // 
            // flowChatt
            // 
            flowChatt.BackColor = SystemColors.ControlLightLight;
            flowChatt.Dock = DockStyle.Fill;
            flowChatt.Location = new Point(2, 2);
            flowChatt.Name = "flowChatt";
            flowChatt.Size = new Size(513, 242);
            flowChatt.TabIndex = 3;
            flowChatt.Paint += flowChatt_Paint;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnGonderr);
            panel3.Location = new Point(475, 276);
            panel3.Name = "panel3";
            panel3.Size = new Size(74, 26);
            panel3.TabIndex = 10;
            // 
            // btnGonderr
            // 
            btnGonderr.BackgroundImage = (Image)resources.GetObject("btnGonderr.BackgroundImage");
            btnGonderr.BackgroundImageLayout = ImageLayout.Zoom;
            btnGonderr.Location = new Point(0, 0);
            btnGonderr.Name = "btnGonderr";
            btnGonderr.Size = new Size(76, 26);
            btnGonderr.TabIndex = 0;
            btnGonderr.UseVisualStyleBackColor = true;
            btnGonderr.Click += btnGonderr_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnSesliOkumaa);
            panel2.Location = new Point(398, 276);
            panel2.Name = "panel2";
            panel2.Size = new Size(72, 26);
            panel2.TabIndex = 9;
            // 
            // btnSesliOkumaa
            // 
            btnSesliOkumaa.BackgroundImage = (Image)resources.GetObject("btnSesliOkumaa.BackgroundImage");
            btnSesliOkumaa.BackgroundImageLayout = ImageLayout.Zoom;
            btnSesliOkumaa.Location = new Point(-3, 0);
            btnSesliOkumaa.Name = "btnSesliOkumaa";
            btnSesliOkumaa.Size = new Size(79, 26);
            btnSesliOkumaa.TabIndex = 1;
            btnSesliOkumaa.UseVisualStyleBackColor = true;
            btnSesliOkumaa.Click += btnSesliOkumaa_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtSoruu);
            panel1.Location = new Point(34, 276);
            panel1.Name = "panel1";
            panel1.Size = new Size(356, 26);
            panel1.TabIndex = 8;
            // 
            // txtSoruu
            // 
            txtSoruu.Dock = DockStyle.Bottom;
            txtSoruu.Location = new Point(0, 0);
            txtSoruu.Multiline = true;
            txtSoruu.Name = "txtSoruu";
            txtSoruu.Size = new Size(356, 26);
            txtSoruu.TabIndex = 3;
            txtSoruu.TextChanged += txtSoruu_TextChanged;
            txtSoruu.Enter += txtSoruu_Enter;
            txtSoruu.KeyDown += txtSoruu_KeyDown;
            txtSoruu.Leave += txtSoruu_Leave;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Transparent;
            panel5.Controls.Add(panel4);
            panel5.Controls.Add(panel1);
            panel5.Controls.Add(panel3);
            panel5.Controls.Add(panel2);
            panel5.Location = new Point(124, 69);
            panel5.Name = "panel5";
            panel5.Size = new Size(590, 332);
            panel5.TabIndex = 12;
            // 
            // ChatbotDepo
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSlateGray;
            ClientSize = new Size(890, 598);
            Controls.Add(panel5);
            Name = "ChatbotDepo";
            Text = "Fuzuli";
            Load += ChatbotDepo_Load;
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel4;
        private FlowLayoutPanel flowChatt;
        private Panel panel3;
        private Button btnGonderr;
        private Panel panel2;
        private Button btnSesliOkumaa;
        private Panel panel1;
        private TextBox txtSoruu;
        private Panel panel5;
    }
}