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
    public partial class frmYoneticiHomeİcerikcopy : Form
    {
        public frmYoneticiHomeİcerikcopy()
        {
            InitializeComponent();
        }

        private void frmYoneticiHomeİcerikcopy_Load(object sender, EventArgs e)
        {
            // Form1.cs içine
            // Yuvarlak (Donut) Grafik Düzenlemesi
            // 0: Geciken (Kırmızı), 1: Bekleyen (Turuncu), 2: Tamamlanan (Yeşil)
            basitYuvarlakGrafik1.Renkler = new Color[] { Color.Tomato, Color.Orange, Color.MediumSeaGreen };
            basitYuvarlakGrafik1.Degerler = new float[] { 15, 25, 60 }; // Örnek oranlar

            // Sütun Grafik Düzenlemesi (Örneğin Sadece Geciken Ödemeler Analizi)
            basitGrafik1.GrafikRengi = Color.Tomato;
            basitGrafik1.Veriler = new List<int> { 10, 25, 15, 40, 20 }; // Haftalık gecikme trendi
            basitGrafik1.GrafikRengi = Color.DodgerBlue; // Genel stok rengi

            basitGrafik1.Veriler = new List<int> { 85, 12, 55, 18, 90, 40 }; // 12 ve 18 olanlar kritik!
            basitGrafik1.Invalidate();
        }

        private void groupBox4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

