namespace edts
{
    partial class ChatbotForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatbotForm));
            btnSesliOkuma = new Button();
            panel1 = new Panel();
            txtSoru = new RichTextBox();
            panel2 = new Panel();
            panel3 = new Panel();
            btnGonder = new Button();
            panel4 = new Panel();
            flowChat = new FlowLayoutPanel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // btnSesliOkuma
            // 
            btnSesliOkuma.BackgroundImage = (Image)resources.GetObject("btnSesliOkuma.BackgroundImage");
            btnSesliOkuma.BackgroundImageLayout = ImageLayout.Zoom;
            btnSesliOkuma.Dock = DockStyle.Fill;
            btnSesliOkuma.Location = new Point(0, 0);
            btnSesliOkuma.Name = "btnSesliOkuma";
            btnSesliOkuma.Size = new Size(82, 41);
            btnSesliOkuma.TabIndex = 1;
            btnSesliOkuma.UseVisualStyleBackColor = true;
            btnSesliOkuma.Click += btnSesliOkuma_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtSoru);
            panel1.Location = new Point(90, 335);
            panel1.Name = "panel1";
            panel1.Size = new Size(430, 27);
            panel1.TabIndex = 4;
            // 
            // txtSoru
            // 
            txtSoru.Dock = DockStyle.Fill;
            txtSoru.Location = new Point(0, 0);
            txtSoru.Name = "txtSoru";
            txtSoru.Size = new Size(430, 27);
            txtSoru.TabIndex = 8;
            txtSoru.Text = "";
            txtSoru.TextChanged += txtSoru_TextChanged_1;
            txtSoru.KeyDown += txtSoru_KeyDown_1;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnSesliOkuma);
            panel2.Location = new Point(526, 321);
            panel2.Name = "panel2";
            panel2.Size = new Size(82, 41);
            panel2.TabIndex = 5;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnGonder);
            panel3.Location = new Point(614, 321);
            panel3.Name = "panel3";
            panel3.Size = new Size(84, 41);
            panel3.TabIndex = 6;
            // 
            // btnGonder
            // 
            btnGonder.BackgroundImage = (Image)resources.GetObject("btnGonder.BackgroundImage");
            btnGonder.BackgroundImageLayout = ImageLayout.Zoom;
            btnGonder.Dock = DockStyle.Fill;
            btnGonder.Location = new Point(0, 0);
            btnGonder.Name = "btnGonder";
            btnGonder.Size = new Size(84, 41);
            btnGonder.TabIndex = 0;
            btnGonder.UseVisualStyleBackColor = true;
            btnGonder.Click += btnGonder_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(flowChat);
            panel4.Location = new Point(90, 26);
            panel4.Name = "panel4";
            panel4.Size = new Size(611, 289);
            panel4.TabIndex = 7;
            // 
            // flowChat
            // 
            flowChat.Dock = DockStyle.Bottom;
            flowChat.Location = new Point(0, 0);
            flowChat.Name = "flowChat";
            flowChat.Size = new Size(611, 289);
            flowChat.TabIndex = 3;
            // 
            // ChatbotForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1039, 602);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ChatbotForm";
            Text = "ChatbotForm";
            Load += ChatbotForm_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button kavisliButon1;
        private Button btnSesliOkuma;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private FlowLayoutPanel flowChat;
        private RichTextBox txtSoru;
        private Button btnGonder;
      
    }
}