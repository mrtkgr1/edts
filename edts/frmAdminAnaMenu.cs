using System;
using System.Windows.Forms;

namespace edts
{
    public partial class frmAdminAnaMenu : Form
    {
        // Constructor, formun başlatıldığı yerdir ve tüm kritik yüklemeler burada olmalıdır.
        public frmAdminAnaMenu()
        {
            InitializeComponent();

            // Yükleme mantığını doğrudan constructor'a taşıyoruz
            SolPaneliYukle();
            IcerikDegistir(new frmAdminHomeIcerik()); // Varsayılan: Ana Sayfa

            // Uygulama kapanışını yöneten olayı atayın
            this.FormClosed += frmAdminAnaMenu_FormClosed;
        }

        // Bu metot artık kullanılmadığı için SİLİNDİ veya yerine kod taşındı.
        // private void frmAdminAnaMenu_Load(object? sender, EventArgs e) { ... }

        // Sol menüyü (frmAdminSolPanel) sol panele sabitleyen metot.
        private void SolPaneliYukle()
        {
            frmAdminSolPanel solMenu = new frmAdminSolPanel();

            solMenu.TopLevel = false;          // <-- KRİTİK: Çerçevesiz alt form olarak ayarla.
            solMenu.FormBorderStyle = FormBorderStyle.None;
            solMenu.Dock = DockStyle.Fill;

            pnlSolMenu.Controls.Clear();
            pnlSolMenu.Controls.Add(solMenu);
            solMenu.Show();
        }

        // Sağdaki içeriği değiştirmek için genel metot (Tek içerik yönetimi)
        public void IcerikDegistir(Form yeniForm)
        {
            yeniForm.TopLevel = false;
            yeniForm.FormBorderStyle = FormBorderStyle.None;
            yeniForm.Dock = DockStyle.Fill;

            pnlIcerik.Controls.Clear();
            pnlIcerik.Controls.Add(yeniForm);
            yeniForm.Show();
        }

        // Sol Panel Büyüt/Küçült İşlevi
        public void SolPanelDurumunuDegistir()
        {
            if (pnlSolMenu.Width == 250) // Varsayılan genişliğin 250 olduğunu varsayıyorum
            {
                pnlSolMenu.Width = 50;
            }
            else
            {
                pnlSolMenu.Width = 250;
            }
        }

        // Form kapandığında tüm uygulamayı sonlandırma.
        private void frmAdminAnaMenu_FormClosed(object? sender, FormClosedEventArgs e) // <-- Burası değişti!
        {
            Application.Exit();
        }
    }
}