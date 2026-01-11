using System;
using System.Windows.Forms;

namespace edts
{
    public partial class frmAdminAnaMenu : Form
    {
        private bool isMenuAcik = true; 
       
        public frmAdminAnaMenu()
        {
            InitializeComponent();

           
            SolPaneliYukle();
            IcerikDegistir(new frmAdminHomeIcerik()); 

           
            this.FormClosed += frmAdminAnaMenu_FormClosed;
        }

        

       
        private void SolPaneliYukle()
        {
            frmAdminSolPanel solMenu = new frmAdminSolPanel();

            solMenu.TopLevel = false;          
            solMenu.FormBorderStyle = FormBorderStyle.None;
            solMenu.Dock = DockStyle.Fill;

            pnlSolMenu.Controls.Clear();
            pnlSolMenu.Controls.Add(solMenu);
            solMenu.Show();
        }

       
        public void IcerikDegistir(Form yeniForm)
        {
            yeniForm.TopLevel = false;
            yeniForm.FormBorderStyle = FormBorderStyle.None;
            yeniForm.Dock = DockStyle.Fill;

            pnlIcerik.Controls.Clear();
            pnlIcerik.Controls.Add(yeniForm);
            yeniForm.Show();
        }

       
        public bool SolPanelDurumunuDegistir()
        {
            if (isMenuAcik) {
               
                tableLayoutPanel1.ColumnStyles[0].Width = 100;
                isMenuAcik = false; 

            } else {
               
                tableLayoutPanel1.ColumnStyles[0].Width = 280;
                isMenuAcik = true;
            }
            return isMenuAcik;
        }

      
        private void frmAdminAnaMenu_FormClosed(object? sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}