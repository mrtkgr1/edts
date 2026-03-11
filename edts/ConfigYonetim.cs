using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace edts {
    internal class ConfigYonetim {
        public static bool BaglantiCumlesiniGuncelle(string yeniBaglantiCumlesi) {
            try {
                string mevcutKlasor = AppDomain.CurrentDomain.BaseDirectory;
                string hedefExeYolu = Path.Combine(mevcutKlasor, "EDTS.exe");

                Configuration config = ConfigurationManager.OpenExeConfiguration(hedefExeYolu);
                ConnectionStringsSection section = config.ConnectionStrings;

                if (section.ConnectionStrings["baglanti"] != null) {
                    section.ConnectionStrings["baglanti"].ConnectionString = yeniBaglantiCumlesi;
                } else {
                    section.ConnectionStrings.Add(new ConnectionStringSettings("baglanti", yeniBaglantiCumlesi, "System.Data.SqlClient"));
                }
                config.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection("connectionStrings");
                return true;
            } catch (Exception) {
                return false;
            }
        }

        

    }
}
