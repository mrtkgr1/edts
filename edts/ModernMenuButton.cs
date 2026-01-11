using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace edts
{
    public class KavisliButon : Button
    {
        public int BorderRadius { get; set; } = 30;

        public KavisliButon()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Cursor = Cursors.Hand; 
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            int kavis = Math.Min(BorderRadius, this.Height);
            if (kavis <= 0) kavis = 1;

            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            GraphicsPath path = new GraphicsPath();

            path.AddArc(rect.X, rect.Y, kavis, kavis, 180, 90);
            path.AddArc(rect.Right - kavis, rect.Y, kavis, kavis, 270, 90);
            path.AddArc(rect.Right - kavis, rect.Bottom - kavis, kavis, kavis, 0, 90);
            path.AddArc(rect.X, rect.Bottom - kavis, kavis, kavis, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path);

            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(this.BackColor, 1.75f))
            {
                pevent.Graphics.DrawPath(pen, path);
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.BackColor = Color.FromArgb(200, this.BackColor);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = Color.FromArgb(255, this.BackColor);
        }
    }
}