namespace edts
{
    public partial class Form1 : Form
    {
        public string Username = "";
        public Form1()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (loginpsw.PasswordChar == '*')
            {
                button2.Image = Properties.Resources.eye;
                loginpsw.PasswordChar = '\0';
            }
            else
            {
                button2.Image = Properties.Resources.eyek;
                loginpsw.PasswordChar = '*';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Edts.UserLogin(textBox1.Text, loginpsw.Text))
             {
                //UserMainForm tmp = new UserMainForm(textBox1.Text);
                //tmp.Show();
                this.DialogResult = DialogResult.OK;
            }
            else
             {
                
                 hatalipsw.Visible = true;
             }
        }
    }
}
