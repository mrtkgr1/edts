using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edts {
    public class SistemAyarYonetim {
        //56 20
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

        public static List<SistemAyar> Ayarlar = new List<SistemAyar>() {
            //new("sifre_yenile_zorunlu", "Şifre yenilemeyi zorunlu kıl","false",AyarTuru.Mantik, ""),
            new("giri_sure_engel", "Hatalı Girişlerde Geçici Süreli Engel", "true", AyarTuru.Mantik, "Giriş Güvenliği ve Kısıtlamalar"),
            new("giris_sure_denemesi", "Geçici Engel İçin Hata Sınırı", "3", AyarTuru.Sayi, "Giriş Güvenliği ve Kısıtlamalar"),
            new("girs_sure_zaman", "Geçici Engelleme Süresi (Dakika)", "3", AyarTuru.Sayi, "Giriş Güvenliği ve Kısıtlamalar"),
            new("hesabi_kilitleme", "Hatalı Girişlerde Hesabı Tamamen Kilitleme", "false", AyarTuru.Mantik, "Giriş Güvenliği ve Kısıtlamalar"),
            new("giris_denemesi", "Hesap Kilitleme Hata Sınırı", "15", AyarTuru.Sayi, "Giriş Güvenliği ve Kısıtlamalar"),

        };

        public static Dictionary<string, (string, string)[]> SecenekListesi = new() {
        };

        public static void AyarlariSenkronizeEt() {
            Dictionary<string, string> veritabanindakiAyarlar = new Dictionary<string, string>();

            using (SqlConnection connection = new SqlConnection(baglantiDizesi)) {
                connection.Open();

                string selectQuery = "SELECT SettingKey, SettingValue FROM frmSunucuAyar";
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection)) {

                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            string key = reader["SettingKey"].ToString()!;
                            string value = reader["SettingValue"].ToString()!;

                            if (!veritabanindakiAyarlar.ContainsKey(key)) {
                                veritabanindakiAyarlar.Add(key, value);
                            }
                        }
                    }
                }

                foreach (var ayar in Ayarlar) {
                    if (veritabanindakiAyarlar.ContainsKey(ayar.Id)) {
                        string dbValue = veritabanindakiAyarlar[ayar.Id];
                        if (ayar.Tur == AyarTuru.Liste) {
                            if (!ListeVerisiVarMi(ayar.Id, dbValue)) {
                                dbValue = "def";
                            }
                        }
                        ayar.Deger = dbValue;
                    } else {
                        string insertQuery = "INSERT INTO frmSunucuAyar ( SettingKey, SettingValue) VALUES ( @Key, @Value)";
                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, connection)) {
                            insertCmd.Parameters.AddWithValue("@Key", ayar.Id);
                            insertCmd.Parameters.AddWithValue("@Value", ayar.VarsayilanDeger.ToString());
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        //kayııt
        public static void AyarlariKaydet(int userId) {
            using (SqlConnection connection = new SqlConnection(baglantiDizesi)) {
                connection.Open();
                foreach (var ayar in Ayarlar) {
                    string updateQuery = "UPDATE frmSunucuAyar SET SettingValue = @Value WHERE SettingKey = @Key";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, connection)) {
                        cmd.Parameters.AddWithValue("@Value", ayar.Deger);
                        cmd.Parameters.AddWithValue("@Key", ayar.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }


        //Getter
        public static string AyarGetir(string ayarId) {
            SistemAyar? ayar = Ayarlar.FirstOrDefault(a => a.Id == ayarId);
            return ayar != null ? ayar.Deger : string.Empty;
        }

        public static int AyarIntGetir(string ayarId) {
            SistemAyar? ayar = Ayarlar.FirstOrDefault(a => a.Id == ayarId);
            return ayar != null ? ayar.IntAl() : 0;
        }

        public static bool AyarBoolGetir(string ayarId) {
            SistemAyar? ayar = Ayarlar.FirstOrDefault(a => a.Id == ayarId);
            return ayar != null ? ayar.BoolAl() : false;
        }

        //getter kontrol
        public static bool AyarGetir(string ayarId, out string? cvp) {
            SistemAyar? ayar = Ayarlar.FirstOrDefault(a => a.Id == ayarId);
            if (ayar == null) {
                cvp = null;
                return false;
            }
            cvp = ayar.Deger;
            return true;
        }
        public static bool AyarGetir(string ayarId, out int? cvp) {
            SistemAyar? ayar = Ayarlar.FirstOrDefault(a => a.Id == ayarId);
            if (ayar == null) {
                cvp = null;
                return false;
            }
            cvp = ayar.IntAl();
            return true;
        }
        public static bool AyarGetir(string ayarId, out bool? cvp) {
            SistemAyar? ayar = Ayarlar.FirstOrDefault(a => a.Id == ayarId);
            if (ayar == null) {
                cvp = null;
                return false;
            }
            cvp = ayar.BoolAl();
            return true;
        }

        //---
        public static void AyarDegistir(string ayarId, string yeniDeger) {
            SistemAyar? ayar = Ayarlar.FirstOrDefault(a => a.Id == ayarId);
            if (ayar != null) {
                ayar.Deger = yeniDeger;
            }
        }

        public static bool ListeVerisiVarMi(string Id, string veriTabanidanGelenId) {
            bool f = false;
            if (AyarYonetimi.SecenekListesi.TryGetValue(Id, out (string, string)[] c)) {
                foreach ((string _text, string _id) item in c) {
                    if (item._id == veriTabanidanGelenId) {
                        return true;
                    }
                }
            }
            return f;
        }

    }

    public class SistemAyar {
        public string Id { get; set; }
        public string AyarAdi { get; set; }
        public string VarsayilanDeger { get; set; }
        public string Deger { get; set; }
        public AyarTuru Tur { get; set; }
        public string Kategori { get; set; }

        public SistemAyar(string ıd, string ayarAdi, string varsayilanDeger, AyarTuru tur, string kategori) {
            Id = ıd;
            AyarAdi = ayarAdi;
            VarsayilanDeger = varsayilanDeger;
            Deger = varsayilanDeger;
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
}
