using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using edts;

public static class VeritabaniYardimcisi
{
    public static bool BaglantiyiTestEt(string test, out string hataMesaji) {
        hataMesaji = string.Empty;

        try {
            using (SqlConnection baglanti = new SqlConnection(test)) {
                baglanti.Open();
                return true;
            }
        } catch (SqlException sqlEx) {
            hataMesaji = "Veritabanı reddetti: " + sqlEx.Message;
            return false;
        } catch (Exception ex) {
            hataMesaji = "Bağlantı kurulamadı: " + ex.Message;
            return false;
        }
    }

    public static string BaglaniOlustur(string mevcutBaglantiCumlesi, string yeniSunucu, string yeniVeritabaniAdi) {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(mevcutBaglantiCumlesi);

        builder.DataSource = yeniSunucu;
        builder.InitialCatalog = yeniVeritabaniAdi;

        return builder.ConnectionString;
    }

    public static bool BaglantiyiGuncelle(string yeniBaglantiDizesi) {

        try {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConnectionStringsSection section = config.ConnectionStrings;

            if (section.ConnectionStrings["baglanti"] != null) {
                section.ConnectionStrings["baglanti"].ConnectionString = yeniBaglantiDizesi;
            } else {
                section.ConnectionStrings.Add(new ConnectionStringSettings("baglanti", yeniBaglantiDizesi, "System.Data.SqlClient"));
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            return true;
        } catch (Exception ex) {
            MessageBox.Show("Bağlantı Dizesi Güncellenirken Hata: " + ex.Message);
            return false;
        }
    }

    //db bilgisi alma

    public static string SunucuyuGetir() {
        string tamBaglanti = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(tamBaglanti);
        return builder.DataSource;
    }

    public static string SunucuyuGetir(string tamBaglanti) {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(tamBaglanti);
        return builder.DataSource;
    }

    public static string VeritabaniAdiniGetir() {
        string tamBaglanti = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(tamBaglanti);
        return builder.InitialCatalog;
    }

    public static string VeritabaniAdiniGetir(string tamBaglanti) {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(tamBaglanti);
        return builder.InitialCatalog;
    }

    //Standat

    public static void LogKaydet(int kullaniciID, Sabitler.IslemTuru hareket, string tabloAdi, string aciklama)
    {
        try {
            string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
            string sorgu = @"INSERT INTO tblDenetimKayitlari (KullaniciID, HareketID, TabloAdi, Aciklama) 
                             VALUES (@pKullaniciID, @pHareketID, @pTabloAdi, @pAciklama)";

            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            using (SqlCommand komut = new SqlCommand(sorgu, baglanti)) {
                komut.Parameters.AddWithValue("@pKullaniciID", kullaniciID);
                komut.Parameters.AddWithValue("@pHareketID", (int)hareket);
                komut.Parameters.AddWithValue("@pTabloAdi", tabloAdi);
                komut.Parameters.AddWithValue("@pAciklama", aciklama);
                baglanti.Open();
                komut.ExecuteNonQuery();
            }
        } catch (Exception ex) {
            Console.WriteLine("Denetim Kaydı Sırasında Hata Oluştu: " + ex.Message);
        }
    }

    public static void LogKaydet(int kullaniciID, int hareketID, string tabloAdi, string aciklama)
    {
        try
        {
            string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
            string sorgu = @"INSERT INTO tblDenetimKayitlari (KullaniciID, HareketID, TabloAdi, Aciklama) 
                             VALUES (@pKullaniciID, @pHareketID, @pTabloAdi, @pAciklama)";

            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
            {
                komut.Parameters.AddWithValue("@pKullaniciID", kullaniciID);
                komut.Parameters.AddWithValue("@pHareketID", hareketID);
                komut.Parameters.AddWithValue("@pTabloAdi", tabloAdi);
                komut.Parameters.AddWithValue("@pAciklama", aciklama);
                baglanti.Open();
                komut.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Denetim Kaydı Sırasında Hata Oluştu: " + ex.Message);
        }
    }


    public static int KayitSayisiGetir(string tabloAdi, string sart = null)
    {
        string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
        string sorgu = $"SELECT COUNT(*) FROM {tabloAdi}";
        if (!string.IsNullOrEmpty(sart))
        {
            sorgu += " WHERE " + sart;
        }

        try
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
            {
                baglanti.Open();
                object sonuc = komut.ExecuteScalar();
                if (sonuc != null && sonuc != DBNull.Value)
                {
                    return Convert.ToInt32(sonuc);
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Kayıt Sayısı Getirirken Hata: " + ex.Message);
        }
        return 0;
    }

    public static DataTable SistemAyarlariGetir()
    {
        string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

        string sorgu = @"SELECT AyarID, 
                           kritikstok,               -- Tablonuzdaki gerçek ad
                           VarsayilanDepoAd,         -- Tablonuzdaki gerçek ad
                           ParaBirim, SirketAd,
                           sifregun,                 -- Tablonuzdaki gerçek ad
                           girishata,                -- Tablonuzdaki gerçek ad
                           oturumzaman               -- Tablonuzdaki gerçek ad
                     FROM tblSistemAyarlari 
                     WHERE AyarID = 1";

        try
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            using (SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Sistem Ayarlari Getirilirken Hata: " + ex.Message);
            return null;
        }
    }

    public static bool SistemAyarlariniKaydet(int kritikStok, string varsayilanDepo,
                                         int sifreGecerlilikGunu, int girisHataLimiti, int oturumZamanAsimiDk)
    {
        string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

        string sorgu = @"UPDATE tblSistemAyarlari 
                     SET kritikstok = @pKritikStok,          
                         VarsayilanDepoAd = @pVarsayilanDepo,    
                         sifregun = @pSifreGecerlilikGunu, 
                         girishata = @pGirisHataLimiti,      
                         oturumzaman = @pOturumZamanAsimiDk  
                     WHERE AyarID = 1";

        try
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
            {
                komut.Parameters.AddWithValue("@pKritikStok", kritikStok);
                komut.Parameters.AddWithValue("@pVarsayilanDepo", varsayilanDepo);

                // Parametreler
                komut.Parameters.AddWithValue("@pSifreGecerlilikGunu", sifreGecerlilikGunu);
                komut.Parameters.AddWithValue("@pGirisHataLimiti", girisHataLimiti);
                komut.Parameters.AddWithValue("@pOturumZamanAsimiDk", oturumZamanAsimiDk);

                baglanti.Open();
                return komut.ExecuteNonQuery() > 0;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Sistem Ayarları Kaydedilirken Hata: " + ex.Message);
            return false;
        }
    }

    public static DataTable DataTableGetir(string sorgu)
    {
        string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
        DataTable dt = new DataTable();

        try
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            using (SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti))
            {
                baglanti.Open();
                da.Fill(dt);
            }
            return dt;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("DataTable Getirilirken Hata: " + ex.Message);
            return null; 
        }
    }

    public static bool ExecuteNonQuery(string sorgu, params SqlParameter[] parameters)
    {
        string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

        try
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
            {
                if (parameters != null)
                {
                    komut.Parameters.AddRange(parameters);
                }
                baglanti.Open();
                int etkilenenSatir = komut.ExecuteNonQuery();
                return etkilenenSatir > 0;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("ExecuteNonQuery Hata: " + ex.Message + " Sorgu: " + sorgu);
            return false; 
        }
    }
}