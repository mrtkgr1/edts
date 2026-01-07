using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace edts {
    public class ResizableButton : Button {
        private Image _kaynakResim;
        private int _resimBoyutu = 24; 

        [Category("_Ozel Ayarlar")]
        [Description("Resmin kaç piksel olacağını belirler.")]
        public int ResimBoyutu {
            get { return _resimBoyutu; }
            set {
                _resimBoyutu = value;
                ResmiGuncelle();
            }
        }

        [Category("_Ozel Ayarlar")]
        [Description("Boyutlandırılacak orijinal resmi buraya seçin.")]
        public Image KaynakResim {
            get { return _kaynakResim; }
            set {
                _kaynakResim = value;
                ResmiGuncelle();
            }
        }

        [Browsable(false)]
        public new Image Image {
            get { return base.Image; }
            set { base.Image = value; }
        }

        private void ResmiGuncelle() {
            if (_kaynakResim == null || _resimBoyutu <= 0) {
                base.Image = null;
                return;
            }

            try {
                Bitmap destImage = new Bitmap(_resimBoyutu, _resimBoyutu);
                using (Graphics g = Graphics.FromImage(destImage)) {
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.DrawImage(_kaynakResim, 0, 0, _resimBoyutu, _resimBoyutu);
                }

                base.Image = destImage;
            } catch {
            }
        }
    }
}