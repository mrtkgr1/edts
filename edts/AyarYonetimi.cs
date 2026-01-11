using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edts {
    class AyarYonetimi {
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

        public static List<KullaniciAyar> Ayarlar = new List<KullaniciAyar>() {
            new("tema", "Tema", "def", "def", AyarTuru.Liste, "Görünüm"),
            new("dinamik_renk_onay", "Sekmenin pencere rengini değiştirmesine izin ver", "true", "true", AyarTuru.Mantik, "Görünüm"),



        };

        public static Dictionary<string, (string, string)[]> SecenekListesi = new() {
            ["tema"] = [("Varsayılan", "def"),("Siyah","siyah"),("Beyaz","beyaz"),("Mavi","mavi"),("Mavi-Gri","mavi_gri")],
            ["bildirim_sesi"] = [("Ses kapalı","off"), ("Varsayılan", "def")],
        };

        public static void AyarlariSenkronizeEt(int userId) {
            Dictionary<string, string> veritabanindakiAyarlar = new Dictionary<string, string>();

            using (SqlConnection connection = new SqlConnection(baglantiDizesi)) {
                connection.Open();

                string selectQuery = "SELECT SettingKey, SettingValue FROM UserSettings WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection)) {
                    cmd.Parameters.AddWithValue("@UserID", userId);

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
                        if(ayar.Tur == AyarTuru.Liste) {
                            if(!ListeVerisiVarMi(ayar.Id, dbValue)) {
                                dbValue = "def";
                            }
                        }
                        ayar.Deger = dbValue;
                    } else {
                        string insertQuery = "INSERT INTO UserSettings (UserID, SettingKey, SettingValue) VALUES (@UserID, @Key, @Value)";
                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, connection)) {
                            insertCmd.Parameters.AddWithValue("@UserID", userId);
                            insertCmd.Parameters.AddWithValue("@Key", ayar.Id);
                            insertCmd.Parameters.AddWithValue("@Value", ayar.VarsayilanDeger.ToString());
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public static void AyarlariKaydet(int userId) {
            using (SqlConnection connection = new SqlConnection(baglantiDizesi)) {
                connection.Open();
                foreach (var ayar in Ayarlar) {
                    string updateQuery = "UPDATE UserSettings SET SettingValue = @Value WHERE UserID = @UserID AND SettingKey = @Key";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, connection)) {
                        cmd.Parameters.AddWithValue("@Value", ayar.Deger);
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@Key", ayar.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }


        public static string AyarGetir(string ayarId) {
            KullaniciAyar? ayar = Ayarlar.FirstOrDefault(a => a.Id == ayarId);
            return ayar != null ? ayar.Deger : string.Empty;
        } 
        
        public static int AyarIntGetir(string ayarId) {
            KullaniciAyar? ayar = Ayarlar.FirstOrDefault(a => a.Id == ayarId);
            return ayar != null ? ayar.IntAl() : 0;
        }

        public static bool AyarBoolGetir(string ayarId) {
            KullaniciAyar? ayar = Ayarlar.FirstOrDefault(a => a.Id == ayarId);
            return ayar != null ? ayar.BoolAl() : false;
        }

        public static bool AyarGetir(string ayarId, out string? cvp) {
            KullaniciAyar? ayar = Ayarlar.FirstOrDefault(a => a.Id == ayarId);
            if (ayar == null) {
                cvp = null;
                return false;
            }
            cvp = ayar.Deger;
            return true;
        }
        public static bool AyarGetir(string ayarId, out int? cvp) {
            KullaniciAyar? ayar = Ayarlar.FirstOrDefault(a => a.Id == ayarId);
            if (ayar == null) {
                cvp = null;
                return false;
            }
            cvp = ayar.IntAl();
            return true;
        }
        public static bool AyarGetir(string ayarId, out bool? cvp) {
            KullaniciAyar? ayar = Ayarlar.FirstOrDefault(a => a.Id == ayarId);
            if (ayar == null) {
                cvp = null;
                return false;
            }
            cvp = ayar.BoolAl();
            return true;
        }

        public static void AyarDegistir(string ayarId, string yeniDeger) {
            KullaniciAyar? ayar = Ayarlar.FirstOrDefault(a => a.Id == ayarId);
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
}
