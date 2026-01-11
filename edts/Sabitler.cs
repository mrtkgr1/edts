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
                case IslemTuru.Oturum_Basarisiz:
                    return "Oturum Başarısız";
                case IslemTuru.Kullanici_Ekle:
                    return "Kullanıcı Eklendi";
                    case IslemTuru.Kullanini_Degisiklik:
                        return "Kullanıcı Değişiklik";
                    case IslemTuru.Kullanici_Sifre_Degisiklik:
                        return "Kullanıcı Şifre Değişiklik";
                    case IslemTuru.Sistem_Ayar_Degisiklik:
                        return "Sistem Ayar Değişiklik";
                    case IslemTuru.Kullanici_Silindi:
                        return "Kullanıcı Silindi";
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
            Oturum_Acildi = 1,            //1
            Satım = 2,                  //2
            Alim = 4,                   //4
            Urun_Degisiklik = 5,        //5
            Kategori_Degisiklik = 6,    //6
            Tedarikci_Degisiklik = 8,   //8
            Musteri_Degisiklik = 9,     //9
            Oturum_Kapandi = 11,        //11
            Oturum_Basarisiz = 12, //++
            Kullanici_Ekle = 13, //++
            Kullanini_Degisiklik = 14, //++
            Kullanici_Sifre_Degisiklik = 15, //++
            Sistem_Ayar_Degisiklik = 16, //++
            Kullanici_Silindi = 17
        }

        public enum Rol {
            Admin = 1,
            Yonetici = 2,
            Personel = 3
        }
    }
}

