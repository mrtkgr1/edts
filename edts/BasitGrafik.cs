using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace edts
{
    public class BasitGrafik : Control
    {
        public List<int> Veriler { get; set; } = new List<int> { 40, 70, 50, 90, 30, 85, 60 };
        public Color GrafikRengi { get; set; } = Color.DodgerBlue;

        public BasitGrafik()
        {
            this.Size = new Size(300, 150);
            this.DoubleBuffered = true; 
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            GraphicsPath path = new GraphicsPath();
            int kavis = 20;
            path.AddArc(0, 0, kavis, kavis, 180, 90);
            path.AddArc(Width - kavis, 0, kavis, kavis, 270, 90);
            path.AddArc(Width - kavis, Height - kavis, kavis, kavis, 0, 90);
            path.AddArc(0, Height - kavis, kavis, kavis, 90, 90);
            this.Region = new Region(path);

            g.Clear(Color.FromArgb(245, 245, 250)); 

            // Sütunları çiz
            if (Veriler == null || Veriler.Count == 0) return;

            float sutunGenisligi = (float)Width / (Veriler.Count * 1.5f);
            float bosluk = sutunGenisligi / 2;
            float maxDeger = 100f; 

            for (int i = 0; i < Veriler.Count; i++)
            {
                float sutunBoyu = (Veriler[i] / maxDeger) * (Height - 40);
                float x = bosluk + i * (sutunGenisligi + bosluk);
                float y = Height - sutunBoyu - 20;

                
                RectangleF rect = new RectangleF(x, y, sutunGenisligi, sutunBoyu);

                using (LinearGradientBrush firca = new LinearGradientBrush(rect, GrafikRengi, Color.FromArgb(150, GrafikRengi), LinearGradientMode.Vertical))
                {
                    
                    GraphicsPath sutunPath = GetRoundedRect(rect, 5);
                    g.FillPath(firca, sutunPath);
                }
            }
        }

        
        private GraphicsPath GetRoundedRect(RectangleF baseRect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(baseRect.X, baseRect.Y, radius, radius, 180, 90);
            path.AddArc(baseRect.Right - radius, baseRect.Y, radius, radius, 270, 90);
            path.AddLine(baseRect.Right, baseRect.Y + radius, baseRect.Right, baseRect.Bottom);
            path.AddLine(baseRect.Right, baseRect.Bottom, baseRect.X, baseRect.Bottom);
            path.AddLine(baseRect.X, baseRect.Bottom, baseRect.X, baseRect.Y + radius);
            return path;
        }
    }
}