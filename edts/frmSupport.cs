using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace edts
{
    public partial class frmSupport : Form
    {
        public frmSupport()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblDestekMail_Click(object sender, EventArgs e)
        {
           
            string mailAdresi = "destekmail.com";
            string konu = "Destek Talebi";
            string icerik = "Merhaba, uygulamanız hakkında şu konuda yardıma ihtiyacım var: ";

           
            string url = $"mailto:{mailAdresi}?subject={Uri.EscapeDataString(konu)}&body={Uri.EscapeDataString(icerik)}";

            try
            {
                
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mail uygulaması açılamadı: " + ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
