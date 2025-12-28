using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edts {
    class KullaniciAyar {
        public string Id { get; set; }         
        public string AyarAdi { get; set; }   
        public string VarsayilanDeger { get; set; } 
        public string Deger { get; set; }
        public AyarTuru Tur { get; set; }

        public string Kategori { get; set; }

        public KullaniciAyar(string id, string ayarAdi, string varsayilanDeger, string deger, AyarTuru tur, string kategori) {
            Id = id;
            AyarAdi = ayarAdi;
            VarsayilanDeger = varsayilanDeger;
            Deger = deger;
            Tur = tur;
            Kategori = kategori;
        }

        public int IntAl() {
            if (int.TryParse(Deger, out int result))
                return result;
            return 0;
        }

        public bool BoolAl() {
            if (bool.TryParse(Deger, out bool result))
                return result;
            return false;
        }
    }
    
    enum AyarTuru {
        Metin,
        Sayi,
        Mantik,
        Sifre,
    }
}
