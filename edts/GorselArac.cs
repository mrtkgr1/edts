using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edts {
    public class GorselArac {
        public static string ImageToBase64(Image image) {
            if (image == null) return null;
            using (MemoryStream ms = new MemoryStream()) {
                image.Save(ms, ImageFormat.Png);
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        public static Image Base64ToImage(string base64String) {
            if (string.IsNullOrEmpty(base64String)) return null;
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes);
            return Image.FromStream(ms);
        }
        public static Image KesveBoyutla(Image gorsel, int w, int h) {
            double ratioX = (double)w / gorsel.Width;
            double ratioY = (double)h / gorsel.Height;
            double ratio = Math.Max(ratioX, ratioY);

            int nw = (int)(gorsel.Width * ratio);
            int nh = (int)(gorsel.Height * ratio);

            Bitmap n = new Bitmap(w, h);

            using (Graphics g = Graphics.FromImage(n)) {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                int posX = (w - nw) / 2;
                int posY = (h - nh) / 2;

                g.DrawImage(gorsel, posX, posY, nw, nh);
            }

            return n;
        }
    }
}
