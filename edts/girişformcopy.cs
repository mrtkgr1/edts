using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace edts
{
    public partial class girişformcopy : Form
    {
        public girişformcopy()
        {
            InitializeComponent();
        }

        private void girişformcopy_Load(object sender, EventArgs e)
        {

        }

        private void txtKullanici_Enter(object sender, EventArgs e)
        {
            if (txtKullanici.Text == "Kullanıcı Adı")
            {
                txtKullanici.Text = ""; 
                txtKullanici.ForeColor = Color.Black; 
            }
        }

        private void txtKullanici_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKullanici.Text))
            {
                txtKullanici.Text = "Kullanıcı Adı"; 
                txtKullanici.ForeColor = Color.Gray; 
            }
        }

        private void txtSifre_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                txtSifre.Text = "Şifre";
                txtSifre.ForeColor = Color.Gray; 
                txtSifre.PasswordChar = '\0'; 
            }
        }

        private void txtSifre_Enter(object sender, EventArgs e)
        {
            if (txtSifre.Text == "Şifre")
            {
                txtSifre.Text = "";
                txtSifre.ForeColor = Color.Black; 
                txtSifre.PasswordChar = '*'; 
            }
        }
    }
}
