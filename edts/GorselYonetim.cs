using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edts {
    public class GorselYonetim {
        static string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

        public static void Kaydet(int kullaniciID, string gorselKod, Image image) {
            string  base64Data = GorselArac.ImageToBase64(image);

            using (SqlConnection conn = new SqlConnection(baglantiDizesi)) {
                string query = @"
                IF EXISTS (SELECT 1 FROM UserImages WHERE UserID = @uid AND ImgCode = @code)
                    UPDATE UserImages SET ImgData = @data WHERE UserID = @uid AND ImgCode = @code
                ELSE
                    INSERT INTO UserImages (UserID, ImgCode, ImgData) VALUES (@uid, @code, @data)";

                using (SqlCommand cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@uid", kullaniciID);
                    cmd.Parameters.AddWithValue("@code", gorselKod);
                    cmd.Parameters.AddWithValue("@data", base64Data ?? (object)DBNull.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Image? Al(int kullaniciID, string gorselKod) {
            using (SqlConnection conn = new SqlConnection(baglantiDizesi)) {
                string query = "SELECT ImgData FROM UserImages WHERE UserID = @uid AND ImgCode = @code";

                using (SqlCommand cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@uid", kullaniciID);
                    cmd.Parameters.AddWithValue("@code", gorselKod);

                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value) {
                        return GorselArac.Base64ToImage(result.ToString());
                    }
                }
            }
            return null;
        }
    }
}
