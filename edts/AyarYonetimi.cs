using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edts {
    class AyarYonetimi {
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

        public static List<KullaniciAyar> Ayarlar = new List<KullaniciAyar>() {
            new("tema", "Tema", "Acik", "Acik", AyarTuru.Metin, "Grub 1"),
            new("font_boyutu", "Font Boyutu", "12", "12", AyarTuru.Sayi, "Grub 1"),
            new("sifre_koruma", "Sifre Koruma", "false", "false", AyarTuru.Metin, "Grub 2"),
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

        public static void AyarDegistir(string ayarId, string yeniDeger) {
            KullaniciAyar? ayar = Ayarlar.FirstOrDefault(a => a.Id == ayarId);
            if (ayar != null) {
                ayar.Deger = yeniDeger;
            }
        }

    }
}
