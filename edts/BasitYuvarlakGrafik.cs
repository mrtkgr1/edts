using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace edts
{
    public class BasitYuvarlakGrafik : Control
    {
        public float[] Degerler { get; set; } = { 30, 20, 50 };
        public Color[] Renkler { get; set; } = { Color.FromArgb(52, 152, 219), Color.FromArgb(46, 204, 113), Color.FromArgb(231, 76, 60), Color.FromArgb(241, 196, 15) };

        public bool DonutModu { get; set; } = true; 

        public BasitYuvarlakGrafik()
        {
            this.Size = new Size(200, 200);
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (Degerler == null || Degerler.Length == 0) return;

            float toplam = Degerler.Sum();
            if (toplam == 0) return;

            float baslangicAcisi = -90; 
            RectangleF rect = new RectangleF(10, 10, Width - 20, Height - 20);

            for (int i = 0; i < Degerler.Length; i++)
            {
                float supürmeAcisi = (Degerler[i] / toplam) * 360f;

                using (SolidBrush firca = new SolidBrush(Renkler[i % Renkler.Length]))
                {
                    g.FillPie(firca, rect.X, rect.Y, rect.Width, rect.Height, baslangicAcisi, supürmeAcisi);
                }
                baslangicAcisi += supürmeAcisi;
            }

            if (DonutModu)
            {
                float boslukOrani = 0.65f; 
                float icCap = rect.Width * boslukOrani;
                float merkezX = rect.X + (rect.Width - icCap) / 2;
                float merkezY = rect.Y + (rect.Height - icCap) / 2;

                using (SolidBrush arkaPlanFircasi = new SolidBrush(this.Parent?.BackColor ?? Color.White))
                {
                    g.FillEllipse(arkaPlanFircasi, merkezX, merkezY, icCap, icCap);
                }
            }
        }
    }
}