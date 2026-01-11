using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edts {
    public class GuvenlikKullanici {
        static string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

        public static int GetInt(int userId, string columnName) {
            using (var connection = new SqlConnection(baglantiDizesi)) {
                string query = $"SELECT [{columnName}] FROM [tblKullaniciGuvenlik] WHERE [userId] = @UserId";
                using (var command = new SqlCommand(query, connection)) {
                    command.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value) {
                        return Convert.ToInt32(result);
                    }
                    return 0;
                }
            }
        }

        public static void SetInt(int userId, string columnName, int? value) {
            using (var connection = new SqlConnection(baglantiDizesi)) {
                string query = $"UPDATE [tblKullaniciGuvenlik] SET [{columnName}] = @Value WHERE [userId] = @UserId";
                using (var command = new SqlCommand(query, connection)) {
                    command.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                    command.Parameters.Add("@Value", SqlDbType.Int).Value = (object)value ?? DBNull.Value;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public static DateTime? GetDate(int userId, string columnName) {
            using (var connection = new SqlConnection(baglantiDizesi)) {
                string query = $"SELECT [{columnName}] FROM [tblKullaniciGuvenlik] WHERE [userId] = @UserId";
                using (var command = new SqlCommand(query, connection)) {
                    command.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value) {
                        return Convert.ToDateTime(result);
                    }
                    return null;
                }
            }
        }

        public static void SetDate(int userId, string columnName, DateTime? value) {
            using (var connection = new SqlConnection(baglantiDizesi)) {
                string query = $"UPDATE [tblKullaniciGuvenlik] SET [{columnName}] = @Value WHERE [userId] = @UserId";
                using (var command = new SqlCommand(query, connection)) {
                    command.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                    command.Parameters.Add("@Value", SqlDbType.DateTime).Value = (object)value ?? DBNull.Value;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public static bool? GetBool(int userId, string columnName) {
            using (var connection = new SqlConnection(baglantiDizesi)) {
                string query = $"SELECT [{columnName}] FROM [tblKullaniciGuvenlik] WHERE [userId] = @UserId";
                using (var command = new SqlCommand(query, connection)) {
                    command.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value) {
                        return Convert.ToBoolean(result);
                    }
                    return null;
                }
            }
        }

        public static void SetBool(int userId, string columnName, bool? value) {
            using (var connection = new SqlConnection(baglantiDizesi)) {
                string query = $"UPDATE [tblKullaniciGuvenlik] SET [{columnName}] = @Value WHERE [userId] = @UserId";
                using (var command = new SqlCommand(query, connection)) {
                    command.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                    command.Parameters.Add("@Value", SqlDbType.Bit).Value = (object)value ?? DBNull.Value;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public static string GetString(int userId, string columnName) {
            using (var connection = new SqlConnection(baglantiDizesi)) {
                string query = $"SELECT [{columnName}] FROM [tblKullaniciGuvenlik] WHERE [userId] = @UserId";
                using (var command = new SqlCommand(query, connection)) {
                    command.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value) {
                        return result.ToString();
                    }
                    return null;
                }
            }
        }

        public static void SetStringe(int userId, string columnName, string value) {
            using (var connection = new SqlConnection(baglantiDizesi)) {
                string query = $"UPDATE [tblKullaniciGuvenlik] SET [{columnName}] = @Value WHERE [userId] = @UserId";
                using (var command = new SqlCommand(query, connection)) {
                    command.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                    command.Parameters.Add("@Value", SqlDbType.NVarChar).Value = (object)value ?? DBNull.Value;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
