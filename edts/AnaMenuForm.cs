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
    public partial class AnaMenuForm : Form
    {
        private int aktifRolID;
        
        private void AnaMenuForm_Load(object? sender, EventArgs e)
        {
            Form? acilacakForm = null;

           
            AyarYonetimi.AyarlariSenkronizeEt(AktifKullanici.ID);
            acilacakForm = new AnaForm();

            if (acilacakForm != null)
            {
                acilacakForm.ShowDialog();

                this.Close();
            }
            else
            {
                MessageBox.Show("Yetkiniz bulunmamaktadır veya hedef form oluşturulmamıştır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
        }
        public AnaMenuForm(int gelenRolID)
        {
            InitializeComponent();
            aktifRolID = gelenRolID;

            this.Visible = false;

            this.FormBorderStyle = FormBorderStyle.None;

            this.Load += AnaMenuForm_Load;
        }
    }
}
