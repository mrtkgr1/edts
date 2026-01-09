using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edts {
    class TemaYonetim {
        static List<Tema> temalar = new List<Tema>() {
            new("siyah",false,Color.FromArgb(24, 24, 27),Color.FromArgb(32, 32, 35),Color.FromArgb(45, 45, 48),Color.FromArgb(20, 20, 22),Color.FromArgb(225, 225, 225)),
            new("beyaz",true,Color.FromArgb(245, 245, 245),Color.FromArgb(225, 225, 225),Color.FromArgb(230, 240, 255),Color.FromArgb(249, 249, 249),Color.FromArgb(33, 33, 33)),
            new("mavi",false,Color.FromArgb(15, 30, 50),Color.FromArgb(25, 50, 85),Color.FromArgb(40, 75, 120),Color.FromArgb(10, 25, 45),Color.FromArgb(255, 255, 255)),
            new("mavi_gri",false,Color.FromArgb(15, 23, 42),Color.FromArgb(30, 41, 59),Color.FromArgb(51, 65, 85),Color.FromArgb(15, 23, 42),Color.FromArgb(226, 232, 240)),
        };
        static Tema seciliTema = temalar[0];
        public static void TemaDegistir(string id) {
            if (id == "def") {
                seciliTema = temalar[0];
            } else {
                Tema? tema = temalar.FirstOrDefault(t => t.ad == id);
                if (tema != null) {
                    seciliTema = tema;
                }
            }
        }

        public static Tema TemaAl() {
            return seciliTema;
        }
    }

    class Tema {
        public string ad { get; }
        public bool siyahIcon { get; }
        public Color ustPanelArkaPlan { get; }
        public Color solMenuArkaPlan { get; }
        public Color solMenuSecilen { get; }
        public Color solMenuAltMenu { get; }
        public Color yaziRengi { get; }

        public Tema(string ad, bool siyahIcon, Color ustPanelArkaPlan, Color solMenuArkaPlan, Color solMenuSecilen, Color solMenuAltMenu, Color yaziRengi) {
            this.ad = ad;
            this.siyahIcon = siyahIcon;
            this.ustPanelArkaPlan = ustPanelArkaPlan;
            this.solMenuArkaPlan = solMenuArkaPlan;
            this.solMenuSecilen = solMenuSecilen;
            this.solMenuAltMenu = solMenuAltMenu;
            this.yaziRengi = yaziRengi;
        }

    }
}
