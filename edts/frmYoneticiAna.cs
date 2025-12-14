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
    public partial class frmYoneticiAna : Form {
        public frmYoneticiAna() {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (tableLayoutPanel1.ColumnStyles[0].Width > 150) {
                tableLayoutPanel1.ColumnStyles[0].Width = 90;
            } else {
                tableLayoutPanel1.ColumnStyles[0].Width = 300;
            }
        }

        private void SayfaGoster(Form yeniForm) {
            panel2.Controls.Clear();

            panel2.AutoScroll = true;

            yeniForm.TopLevel = false;

            yeniForm.FormBorderStyle = FormBorderStyle.None;

            yeniForm.Dock = DockStyle.Fill;

            panel2.Controls.Add(yeniForm);

            yeniForm.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e) {
            SayfaGoster(new frmAdminSistemAyarlari());
        }

        private void pictureBox7_Click(object sender, EventArgs e) {
            SayfaGoster(new frmSupport());
        }

        private void pictureBox5_Click(object sender, EventArgs e) {
            SayfaGoster(new frmUrunYonetimi());
        }

        private void panel6_Paint(object sender, PaintEventArgs e) {
            SayfaGoster(new frmUrunYonetimi());
        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void panel8_Paint(object sender, PaintEventArgs e) {
            SayfaGoster(new frmGenelRaporlar());
        }

        private void pictureBox3_Click(object sender, EventArgs e) {
            SayfaGoster(new frmGenelRaporlar());
        }
    }
}
