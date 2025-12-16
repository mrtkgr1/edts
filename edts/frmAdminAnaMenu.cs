using System;
using System.Windows.Forms;

namespace edts
{
    public partial class frmAdminAnaMenu : Form
    {
        private bool isMenuAcik = true; 
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
        public bool SolPanelDurumunuDegistir()
        {
            if (isMenuAcik) {
                // 1. MENÜYÜ KAPAT
                tableLayoutPanel1.ColumnStyles[0].Width = 100;
                isMenuAcik = false; // Durumu Kapatıldı olarak ayarla

            } else {
                // 2. MENÜYÜ AÇ
                tableLayoutPanel1.ColumnStyles[0].Width = 280;
                isMenuAcik = true; // Durumu Açık olarak ayarla
            }
            return isMenuAcik;
        }

        // Form kapandığında tüm uygulamayı sonlandırma.
        private void frmAdminAnaMenu_FormClosed(object? sender, FormClosedEventArgs e) // <-- Burası değişti!
        {
            Application.Exit();
        }
    }
}