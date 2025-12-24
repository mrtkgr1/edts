using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace edts
{
    public class KavisliButon : Button
    {
        // BorderRadius değerini yüksek tutarsan (örneğin 40-50) tam oval olur
        public int BorderRadius { get; set; } = 30;

        public KavisliButon()
        {
            // Butonun varsayılan ayarlarını burada yapıyoruz
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Cursor = Cursors.Hand; // Üzerine gelince el işareti çıksın
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            // Eğer BorderRadius buton yüksekliğinden büyükse hata vermemesi için sınırlıyoruz
            int kavis = Math.Min(BorderRadius, this.Height);
            if (kavis <= 0) kavis = 1;

            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            GraphicsPath path = new GraphicsPath();

            // Oval yapıyı kuran çizim
            path.AddArc(rect.X, rect.Y, kavis, kavis, 180, 90);
            path.AddArc(rect.Right - kavis, rect.Y, kavis, kavis, 270, 90);
            path.AddArc(rect.Right - kavis, rect.Bottom - kavis, kavis, kavis, 0, 90);
            path.AddArc(rect.X, rect.Bottom - kavis, kavis, kavis, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path);

            // Kenarları pürüzsüzleştirmek (Anti-Alias) ve ince bir hat çekmek için
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(this.BackColor, 1.75f))
            {
                pevent.Graphics.DrawPath(pen, path);
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            // Mevcut rengin üzerine hafif bir beyazlık/şeffaflık katar
            this.BackColor = Color.FromArgb(200, this.BackColor);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            // Rengi tekrar tam opak (255) hale getirir
            this.BackColor = Color.FromArgb(255, this.BackColor);
        }
    }
}