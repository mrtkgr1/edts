namespace edts
{
    partial class ChatbotYonetici
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatbotYonetici));
            panel4 = new Panel();
            flowChattt = new FlowLayoutPanel();
            panel3 = new Panel();
            btnGonderrr = new Button();
            panel2 = new Panel();
            btnSesliOkumaaa = new Button();
            panel1 = new Panel();
            txtSoruuu = new TextBox();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel4
            // 
            panel4.Controls.Add(flowChattt);
            panel4.Location = new Point(185, 103);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(2);
            panel4.Size = new Size(589, 289);
            panel4.TabIndex = 11;
            panel4.Paint += panel4_Paint;
            // 
            // flowChattt
            // 
            flowChattt.BackColor = SystemColors.Window;
            flowChattt.Dock = DockStyle.Bottom;
            flowChattt.Location = new Point(2, -2);
            flowChattt.Name = "flowChattt";
            flowChattt.Size = new Size(585, 289);
            flowChattt.TabIndex = 3;
            flowChattt.Paint += flowChattt_Paint;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnGonderrr);
            panel3.Location = new Point(690, 398);
            panel3.Name = "panel3";
            panel3.Size = new Size(84, 30);
            panel3.TabIndex = 10;
            // 
            // btnGonderrr
            // 
            btnGonderrr.BackgroundImage = (Image)resources.GetObject("btnGonderrr.BackgroundImage");
            btnGonderrr.BackgroundImageLayout = ImageLayout.Zoom;
            btnGonderrr.Dock = DockStyle.Fill;
            btnGonderrr.Location = new Point(0, 0);
            btnGonderrr.Name = "btnGonderrr";
            btnGonderrr.Size = new Size(84, 30);
            btnGonderrr.TabIndex = 0;
            btnGonderrr.UseVisualStyleBackColor = true;
            btnGonderrr.Click += btnGonderrr_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnSesliOkumaaa);
            panel2.Location = new Point(602, 398);
            panel2.Name = "panel2";
            panel2.Size = new Size(82, 30);
            panel2.TabIndex = 9;
            // 
            // btnSesliOkumaaa
            // 
            btnSesliOkumaaa.BackgroundImage = (Image)resources.GetObject("btnSesliOkumaaa.BackgroundImage");
            btnSesliOkumaaa.BackgroundImageLayout = ImageLayout.Zoom;
            btnSesliOkumaaa.Dock = DockStyle.Fill;
            btnSesliOkumaaa.Location = new Point(0, 0);
            btnSesliOkumaaa.Name = "btnSesliOkumaaa";
            btnSesliOkumaaa.Size = new Size(82, 30);
            btnSesliOkumaaa.TabIndex = 1;
            btnSesliOkumaaa.UseVisualStyleBackColor = true;
            btnSesliOkumaaa.Click += btnSesliOkumaaa_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtSoruuu);
            panel1.Location = new Point(187, 398);
            panel1.Name = "panel1";
            panel1.Size = new Size(406, 30);
            panel1.TabIndex = 8;
            // 
            // txtSoruuu
            // 
            txtSoruuu.Dock = DockStyle.Bottom;
            txtSoruuu.Location = new Point(0, 0);
            txtSoruuu.Multiline = true;
            txtSoruuu.Name = "txtSoruuu";
            txtSoruuu.Size = new Size(406, 30);
            txtSoruuu.TabIndex = 3;
            txtSoruuu.TextChanged += txtSoruuu_TextChanged;
            txtSoruuu.KeyDown += txtSoruuu_KeyDown;
            // 
            // ChatbotYonetici
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSlateGray;
            ClientSize = new Size(979, 570);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ChatbotYonetici";
            Text = "ChatbotYonetici";
            Load += ChatbotYonetici_Load;
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel4;
        private FlowLayoutPanel flowChattt;
        private Panel panel3;
        private Button btnGonderrr;
        private Panel panel2;
        private Button btnSesliOkumaaa;
        private Panel panel1;
        private TextBox txtSoruuu;
    }
}