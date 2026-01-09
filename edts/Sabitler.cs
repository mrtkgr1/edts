using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edts {
    public class Sabitler {
        public const string VERSION = "1.0.0";
        public static string IslemAl(IslemTuru n) {
            switch (n) {
                case IslemTuru.Oturum_Acildi:
                    return "Oturum Açıldı";
                case IslemTuru.Satım:
                    return "Stok çıktısı";
                case IslemTuru.Alim:
                    return "Stok girdisi";
                case IslemTuru.Urun_Degisiklik:
                    return "Ürün Değişiklik";
                case IslemTuru.Kategori_Degisiklik:
                    return "Kategori Değişiklik";
                case IslemTuru.Tedarikci_Degisiklik:
                    return "Tedarikçi Değişiklik";
                case IslemTuru.Musteri_Degisiklik:
                    return "Müşteri Değişiklik";
                case IslemTuru.Oturum_Kapandi:
                    return "Oturum Kapandı";
                default:
                    return "Tanımlanmamış";
            }
        }

        public static string IslemAl(int n) {
            if (Enum.IsDefined(typeof(IslemTuru), n)) {
                return IslemAl((IslemTuru)n);
            } else {
                return "Tanımlanmamış";
            }
        }

        public enum IslemTuru {
            Oturum_Acildi = 1,           
            Satım = 2,                 
            Alim = 4,                  
            Urun_Degisiklik = 5,        
            Kategori_Degisiklik = 6,   
            Tedarikci_Degisiklik = 8,  
            Musteri_Degisiklik = 9,    
            Oturum_Kapandi = 11         
        }

        public enum Rol {
            Admin = 1,
            Yonetici = 2,
            Personel = 3
        }
    }
}

