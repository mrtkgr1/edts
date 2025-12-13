using System;
using System.Security.Cryptography; // SHA256 için gerekli kütüphane
using System.Text; // Encoding ve StringBuilder için gerekli kütüphane

namespace edts // Projenizin ana namespace'i
{
    public static class GuvenlikYardimcisi
    {
        public static string HashSifre(string sifre)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Şifreyi bayt dizisine dönüştür
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(sifre));

                // Baytları Hexadecimal (onaltılık) stringe dönüştür
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}