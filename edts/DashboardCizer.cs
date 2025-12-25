using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Drawing2D;

namespace edts
{
    public static class DashboardCizer
    {
        // En Çok Satanlar Grafiğini Oluşturan Metot
        public static void EnCokSatanlarGrafiginiKur(GroupBox hedefKutu)
        {
            // 1. Grafik Nesnesi
            Chart chart = new Chart();
            chart.Parent = hedefKutu;
            chart.Dock = DockStyle.Fill;
            chart.BackColor = Color.Transparent;

            // 2. Alan Ayarları
            ChartArea alan = new ChartArea("MainArea");
            alan.BackColor = Color.Transparent;
            alan.AxisX.MajorGrid.Enabled = false; // Dikey çizgileri sil
            alan.AxisY.MajorGrid.LineColor = Color.LightGray;
            alan.AxisX.LabelStyle.Font = new Font("Segoe UI", 8f);
            chart.ChartAreas.Add(alan);

            // 3. Seri (Data) Ayarları
            Series seri = new Series("Kar");
            seri.ChartType = SeriesChartType.Bar; // Yatay sütun
            seri.Palette = ChartColorPalette.SeaGreen;
            chart.Series.Add(seri);

            // 4. Test Verileri (Daha sonra SQL'den gelecek)
            chart.Series["Kar"].Points.AddXY("Ürün A", 5000);
            chart.Series["Kar"].Points.AddXY("Ürün B", 3500);
            chart.Series["Kar"].Points.AddXY("Ürün C", 8000);
            chart.Series["Kar"].Points.AddXY("Ürün D", 4200);

            hedefKutu.Controls.Add(chart);
        }

        // Köşe Yuvarlama Metodunu da buraya taşıyalım (Merkezi yönetim)
        public static void KoseleriYuvarla(Control ctrl, int yariCap)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(0, 0, yariCap, yariCap, 180, 90);
            gp.AddArc(ctrl.Width - yariCap, 0, yariCap, yariCap, 270, 90);
            gp.AddArc(ctrl.Width - yariCap, ctrl.Height - yariCap, yariCap, yariCap, 0, 90);
            gp.AddArc(0, ctrl.Height - yariCap, yariCap, yariCap, 90, 90);
            gp.CloseAllFigures();
            ctrl.Region = new Region(gp);
        }
    }
}