using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Speech.Synthesis;

namespace edts
{
    public partial class ChatbotYonetici : Form
    {
        static string connectionString =
            "Server=LAPTOP-ECRTR81F\\SQLEXPRESS;Database=StokYonetimDB;Trusted_Connection=True;Encrypt=False;";

        // Sınıfın başında, constructor'dan önce
        private Dictionary<int, List<string>> RolYetkileri = new Dictionary<int, List<string>>()
{
    { 1, new List<string> { "stok", "fiyat", "ciro", "teslim", "kritik stok", "rol", "aktif", "yanlış giriş", "giriş yapan", "giriş yapmayan" } }, // Admin
    { 3, new List<string> { "stok", "fiyat", "teslim", "kritik stok" } }, // Personel
    { 2, new List<string> { "stok", "ciro", "kritik stok","fiyat","giriş yapmayan","giriş yapan" } } // Yönetici
};

        public ChatbotYonetici()
        {
            InitializeComponent();

            flowChattt.FlowDirection = FlowDirection.TopDown;
            flowChattt.WrapContents = false;
            flowChattt.AutoScroll = true;
            flowChattt.Dock = DockStyle.Fill; // panel ekranı kaplasın



            string botAdi = "Stok Yönetim Botu";
            _ = GosterHarfHarf($"{botAdi}: Merhaba! Bugün size nasıl yardımcı olabilirim?", false);





        }
        // Placeholder metni
        private string placeholder = "Bana soru sor...";
        private bool sesliOkumaAcik = false;
        private SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        
 

        private int KullaniciRolID(string kullaniciAdi)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            using SqlCommand cmd = new SqlCommand(
                "SELECT RolID FROM tblKullanicilar WHERE LOWER(KullaniciAdi) = @KullaniciAdi", conn);
            cmd.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi.ToLower().Trim());

            object result = cmd.ExecuteScalar();
            if (result != null)
                return Convert.ToInt32(result);

            return 0; // Bulunamadıysa
        }
       

       
        private string ChatbotCevapla(string soru)
        {
            if (string.IsNullOrWhiteSpace(soru))
                return "Lütfen bir soru yazın.";

            // Noktalama ve küçük harfe çevir
            string temizSoru = new string(soru
                .Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
                .ToArray())
                .ToLower()
                .Trim();

            // Kimlik soruları kontrolü EN BAŞTA
            string[] kimlikSorulari = { "sen kimsin", "kimsin sen", "kimsin", "görevin ne", "ne iş yaparsın", "amacın ne", "ne işe yarıyorsun", "neden buradasın", "kim", "bot musun", "chatbot musun" };
            if (kimlikSorulari.Any(k => temizSoru.Contains(k)))
                return "Ben Fuzuli! Envanter Depo Yönetim Sisteminde sana yardımcı olmak için tasarlanmış bir chatbotum.";

            string orijinal = soru.Trim();

            // Küçük kelimeleri kaldırmak için normalize fonksiyonu
            string Normalize(string text)
            {
                string[] removeWords = { "nedir", "acaba", "mı", "mu", "bilgi", "hakkında", "lütfen", "öğrenebilir miyim" };
                foreach (var w in removeWords)
                    text = text.Replace(w, "");
                return text.Trim();
            }


            string normalizedSoru = Normalize(temizSoru);

            // Selamlar ve duygu sözleri
            string[] tesekkurler = { "teşekkür", "teşekkür ederim", "teşekkürler", "çok sağ ol", "sağ ol", "sağol" };
            string[] vedalar = { "iyi günler", "görüşürüz", "hoşça kal", "güle güle" };
            string[] iyiDurum = { "iyi", "harika", "güzel", "süper", "mükemmel" };
            string[] kotuDurum = { "kötü", "berbat", "fena", "yorgun", "mutsuz" };
            string[] selamlar = { "merhaba", "selam", "günaydın", "iyi akşamlar", "hey" };




            // Selam ve duygu cevapları
            if (selamlar.Any(s => temizSoru.Contains(s)))
                return "Merhaba! Gününüz güzel geçiyordur umarım. Nasılsınız?";

            if (normalizedSoru.Contains("nasılsın"))
                return "Ben iyiyim, teşekkürler! Size nasıl yardımcı olabilirim?";

            if (iyiDurum.Any(s => temizSoru.Contains(s)))
                return "Harika! Size nasıl yardımcı olabilirim?";

            if (kotuDurum.Any(s => temizSoru.Contains(s)))
                return "Üzgünüm, umarım gününüz daha iyi olur. Nasıl yardımcı olayım?";

            // Yetki kontrolü: aktif kullanıcının rolü
            int rolID = AktifKullanici.RolID;

            if (!RolYetkileri.ContainsKey(rolID))
                return "Geçersiz rol. Lütfen tekrar giriş yapın.";



            // --- Yönetici yetkileri ----

            if (orijinal.Contains("aktif mi"))
                return KullaniciAktifMi(orijinal);

            if (orijinal.Contains("rol") && orijinal.Contains("kim"))
                return KullaniciRolu(orijinal);

            if (orijinal.Contains("yanlış giriş"))
                return KullaniciYanlisGirisSayisi(orijinal);

            if (orijinal.Contains("bugün giriş yapan"))
                return BugunGirisYapanKullanicilar();

            if (orijinal.Contains("giriş yapmayan"))
                return BugunGirisYapmayanKullanicilar();



            // ---- Ürün işlemleri ----

            if (orijinal.Contains("stok"))
            {
                if (!RolYetkileri[rolID].Contains("stok"))
                    return "Bu bilgiye erişim yetkiniz yok.";

                return UrunStokDurumu(orijinal);
            }

            if (orijinal.Contains("fiyat"))
            {
                if (!RolYetkileri[rolID].Contains("fiyat"))
                    return "Bu bilgiye erişim yetkiniz yok.";

                return UrunFiyatiGetir(orijinal);
            }

            // 1. ÖNCE GENEL CİRO (Bu ay toplam ciro gibi)
            if (temizSoru.Contains("toplam ciro") || temizSoru.Contains("bu ayki ciro") || temizSoru.Contains("aylık ciro"))
            {
                if (!RolYetkileri[rolID].Contains("ciro"))
                    return "Bu bilgiye erişim yetkiniz yok.";

                return BuAyToplamCiro(); // Genel ciro metoduna yönlendir
            }

            // 2. SONRA ÜRÜN BAZLI CİRO
            if (temizSoru.Contains("ciro"))
            {
                if (!RolYetkileri[rolID].Contains("ciro"))
                    return "Bu bilgiye erişim yetkiniz yok.";

                return UrunCiroGetir(orijinal); // Ürün adı arayan metoda yönlendir
            }

            if (orijinal.Contains("teslim"))
            {
                if (!RolYetkileri[rolID].Contains("teslim"))
                    return "Bu bilgiye erişim yetkiniz yok.";

                return UrunTeslimTarihi(orijinal);
            }

            if (orijinal.Contains("kritik") && orijinal.Contains("stok"))
            {
                if (!RolYetkileri[rolID].Contains("kritik stok"))
                    return "Bu bilgiye erişim yetkiniz yok.";

                return KritikStokUrunleri();
            }

            return "Soruyu anlayamadım. Örnek: 'masa stok durumu nedir?'";
        }

        // TextBox focus aldığında placeholder'ı temizle
        private void txtSoru_Enter(object sender, EventArgs e)
        {
            if (txtSoruuu.Text == placeholder)
            {
                txtSoruuu.Text = "";
                txtSoruuu.ForeColor = Color.Black; // yazı rengini normal yap
            }
        }
        private string TemizleKullaniciAdi(string? kelime)
        {
            if (string.IsNullOrWhiteSpace(kelime))
                return "";

            string[] ekler = { "in", "ın", "un", "ün", "nin", "nın", "nun", "nün" };

            foreach (var ek in ekler)
                if (kelime.EndsWith(ek))
                    return kelime.Substring(0, kelime.Length - ek.Length);

            return kelime;
        }
        private void EkleMesaj(string mesaj, bool kullaniciMesaji)
        {
            if (kullaniciMesaji)
            {
                // Kullanıcı balonu
                Panel balon = new Panel();
                balon.BackColor = Color.FromArgb(250, 250, 250);
                balon.AutoSize = true;
                balon.Padding = new Padding(10);
                balon.Margin = new Padding(150, 5, 10, 5); // Sağ tarafta
                balon.MaximumSize = new Size(400, 0);

                Label lbl = new Label();
                lbl.Text = mesaj;
                lbl.AutoSize = true;
                lbl.MaximumSize = new Size(380, 0); // balonun içine sığacak
                lbl.BackColor = Color.Transparent;
                lbl.Font = new Font("Segoe UI", 10);
                lbl.TextAlign = ContentAlignment.MiddleRight;
                lbl.Dock = DockStyle.Fill;

                balon.Controls.Add(lbl);
                flowChattt.Controls.Add(balon);
                flowChattt.SetFlowBreak(balon, true);
                flowChattt.ScrollControlIntoView(balon);
            }
            else
            {
                // Chatbot mesajı
                Label lbl = new Label();
                lbl.Text = mesaj;
                lbl.AutoSize = true;
                lbl.MaximumSize = new Size(600, 0);
                lbl.BackColor = Color.Transparent;
                lbl.Font = new Font("Segoe UI", 10);
                lbl.Margin = new Padding(10, 5, 50, 5);
                lbl.TextAlign = ContentAlignment.MiddleLeft;

                flowChattt.Controls.Add(lbl);
                flowChattt.SetFlowBreak(lbl, true);
                flowChattt.ScrollControlIntoView(lbl);
            }
        }

        private string KullaniciRolu(string soru)
        {
            string[] stopWords = { "rol", "nedir", "yetki", "görev", "ne", "kullanıcısının", "kullanıcısı", "kimdir" };
            string[] kelimeler = soru.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string? kelime = kelimeler
       .Where(x => !stopWords.Contains(x))
       .FirstOrDefault();


            string kullaniciAdi = TemizleKullaniciAdi(kelime);

            if (string.IsNullOrEmpty(kullaniciAdi))
                return "Kullanıcı adı algılanamadı.";

            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            using SqlCommand cmd = new SqlCommand(
                @"SELECT r.RolAd
          FROM tblKullanicilar k
          JOIN tblRoller r ON r.RolID = k.RolID
          WHERE LOWER(k.KullaniciAdi) = @KullaniciAdi", conn);

            cmd.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi.ToLower().Trim());
            object result = cmd.ExecuteScalar();

            if (result == null)
                return $"{kullaniciAdi} adlı kullanıcı bulunamadı.";

            return $"{kullaniciAdi} adlı kullanıcının rolü: {result}";
        }

        private string KullaniciAktifMi(string soru)
        {
            string[] stopWords = { "aktif", "mi", "?", "kullanıcısı", "kullanıcının" };
            string[] kelimeler = soru.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string kelime = kelimeler
     .Where(x => !stopWords.Contains(x))
     .FirstOrDefault() ?? "";

            if (string.IsNullOrWhiteSpace(kelime))
                return "Kelime algılanamadı.";

            string kullaniciAdi = TemizleKullaniciAdi(kelime);

            if (string.IsNullOrEmpty(kullaniciAdi))
                return "Kullanıcı adı algılanamadı.";

            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            using SqlCommand cmd = new SqlCommand(
                "SELECT AktifMi FROM tblKullanicilar WHERE LOWER(KullaniciAdi) = @KullaniciAdi", conn);
            cmd.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi.ToLower().Trim());

            object result = cmd.ExecuteScalar();
            if (result == null)
                return $"{kullaniciAdi} adlı kullanıcı bulunamadı.";

            bool aktif = Convert.ToBoolean(result);
            return aktif
                ? $"{kullaniciAdi} kullanıcısı aktiftir."
                : $"{kullaniciAdi} kullanıcısı pasiftir.";
        }

        private string UrunStokDurumu(string soru)
        {

            // Sorudan ürün adını çıkar
            string? urunAdi = soru.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .FirstOrDefault(x => x != "stok" && x != "var" && x != "mı");

            if (string.IsNullOrEmpty(urunAdi))
                return "Ürün adı algılanamadı.";

            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            // önce birebir arayalım
            using (SqlCommand cmd = new SqlCommand(
                "SELECT MevcutStok FROM tblUrunler WHERE LOWER(UrunAd) = @UrunAdi", conn))
            {
                cmd.Parameters.AddWithValue("@UrunAdi", urunAdi.ToLower().Trim());
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    decimal stok = Convert.ToDecimal(result);

                    return stok > 0
                        ? $"{urunAdi} stokta mevcut. Miktar: {stok}"
                        : $"{urunAdi} stokta mevcut değil.";
                }
            }

            // ❗ Ürün bulunamazsa en yakın ürünü önerelim

            List<string> tumUrunler = new List<string>();

            using (SqlCommand cmd = new SqlCommand("SELECT UrunAd FROM tblUrunler", conn))
            using (SqlDataReader r = cmd.ExecuteReader())
            {
                while (r.Read())
                    tumUrunler.Add((r["UrunAd"]?.ToString() ?? "").ToLower());
            }

            string tahmin = tumUrunler
                .OrderBy(x => Mesafe(x, urunAdi))
                .First();

            if (Mesafe(tahmin, urunAdi) <= 2) // 2 harf tolerans
            {
                return $"‘{urunAdi}’ adlı ürün bulunamadı. Şunu mu demek istediniz: {tahmin}?";
            }

            return $"{urunAdi} adlı ürün bulunamadı.";
        }
        private string UrunFiyatiGetir(string soru)
        {
            string? urunAdi = soru.Split(' ', StringSplitOptions.RemoveEmptyEntries)
      .FirstOrDefault(x => x != "fiyat" && x != "ne" && x != "kadar" && x != "birim");



            if (string.IsNullOrEmpty(urunAdi))
                return "Ürün adı algılanamadı.";

            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            // önce birebir arayalım
            using SqlCommand cmd = new SqlCommand(
                "SELECT BirimFiyat FROM tblUrunler WHERE LOWER(UrunAd) = @UrunAdi", conn);
            cmd.Parameters.AddWithValue("@UrunAdi", urunAdi.ToLower().Trim());

            object result = cmd.ExecuteScalar();

            if (result != null)
            {
                decimal fiyat = Convert.ToDecimal(result);
                return $"{urunAdi} ürününün fiyatı: {fiyat:C}";
            }

            // ❗ ürün bulunamadı → tahmin dene
            List<string> tumUrunler = new List<string>();

            using (SqlCommand cmd2 = new SqlCommand(
                "SELECT UrunAd FROM tblUrunler", conn))
            using (SqlDataReader r = cmd2.ExecuteReader())
            {
                while (r.Read())
                {
                    string? ad = r["UrunAd"]?.ToString()?.ToLower();

                    if (!string.IsNullOrWhiteSpace(ad))
                    {
                        tumUrunler.Add(ad);
                    }
                }
            }

            string tahmin = tumUrunler
                .OrderBy(x => Mesafe(x, urunAdi))
                .First();

            if (Mesafe(tahmin, urunAdi) <= 2)
                return $"‘{urunAdi}' bulunamadı. Şunu mu demek istediniz: {tahmin}?";

            return $"{urunAdi} adlı ürün bulunamadı.";
        }
        private string UrunCiroGetir(string soru)
        {
            string? urunAdi = soru.Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .FirstOrDefault(x => x != "ciro" && x != "satış" && x != "ne" && x != "kadar");

            if (string.IsNullOrEmpty(urunAdi))
                return "Lütfen ürün adını belirtin.";

            urunAdi = urunAdi.ToLower().Trim();

            if (string.IsNullOrEmpty(urunAdi))
                return "Lütfen ürün adını belirtin.";

            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            using SqlCommand cmd = new SqlCommand(@"
        SELECT SUM(sd.Miktar * sd.BirimFiyat)
        FROM tblSatisDetay sd
        JOIN tblUrunler u ON u.UrunID = sd.UrunID
        WHERE LOWER(u.UrunAd) = @UrunAdi",
                conn);

            cmd.Parameters.AddWithValue("@UrunAdi", urunAdi.ToLower().Trim());

            object? result = cmd.ExecuteScalar();

            if (result != DBNull.Value && result != null)
                return $"{urunAdi} ürününün toplam cirosu: {result} ₺";

            return $"{urunAdi} ürünü için ciro bulunamadı.";
        }

        private string KullaniciYanlisGirisSayisi(string soru)
        {
            string[] stopWords = { "kaç", "kez", "yanlış", "giriş", "hatalı", "girdi", "kullanıcı" };
            string[] kelimeler = soru.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string? kelime = kelimeler
    .Where(x => !stopWords.Contains(x))
    .FirstOrDefault();

            kelime = kelime?.Trim() ?? "";

            string kullaniciAdi = TemizleKullaniciAdi(kelime);


            if (string.IsNullOrEmpty(kullaniciAdi))
                return "Kullanıcı adı algılanamadı.";

            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            using SqlCommand cmd = new SqlCommand(
                @"SELECT COUNT(*) 
          FROM tblDenetimKayitlari d
          JOIN tblKullanicilar k ON k.KullaniciID = d.KullaniciID
          WHERE LOWER(k.KullaniciAdi) = @KullaniciAdi 
            AND d.Aciklama LIKE '%yanlış giriş%'", conn);
            cmd.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi.ToLower().Trim());

            object result = cmd.ExecuteScalar();
            int sayi = Convert.ToInt32(result);

            return $"{kullaniciAdi} adlı kullanıcı {sayi} kez yanlış giriş yapmış.";
        }
        private string UrunTeslimTarihi(string soru)
        {
            string urunAdi = soru
      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
      .FirstOrDefault(x => x is not "son"
                        && x is not "teslim"
                        && x is not "tarihi"
                        && x is not "ne"
                        && x is not "zaman")
      ?.ToLower() ?? "";

            if (string.IsNullOrWhiteSpace(urunAdi))
                return "Ürün adı algılanamadı.";


            // 1️⃣ teslim tarihi sorgusu
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using SqlCommand cmd =
                    new("SELECT TOP 1 TeslimTarihi FROM tblUrunler WHERE LOWER(UrunAd)=@ad", conn);
                cmd.Parameters.AddWithValue("@ad", urunAdi);

                object? result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    DateTime tarih = Convert.ToDateTime(result);
                    return $"{urunAdi} ürünü teslim tarihi: {tarih:dd.MM.yyyy}";
                }
            }


            // 2️⃣ ilgili ürün bulunamadı → tahmin öner
            List<string> tumUrunler = new();

            using (SqlConnection conn2 = new SqlConnection(connectionString))
            {
                conn2.Open();

                using SqlCommand cmd2 = new("SELECT UrunAd FROM tblUrunler", conn2);
                using SqlDataReader r = cmd2.ExecuteReader();
                while (r.Read())
                {
                    string? ad = r["UrunAd"]?.ToString()?.ToLower();
                    if (!string.IsNullOrWhiteSpace(ad))
                        tumUrunler.Add(ad);
                }
            }

            // 3️⃣ en benzer ürün öner
            string benzer = tumUrunler
                .FirstOrDefault(x => x.StartsWith(urunAdi[..2])) ?? "Benzer ürün bulunamadı.";

            return $"'{urunAdi}' adına ait teslim tarihi bulunamadı.\nBuna yakın ürün: {benzer}";
        }
        private string KritikStokUrunleri()
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            using SqlCommand cmd = new SqlCommand(
                "SELECT UrunAd FROM tblUrunler WHERE MevcutStok <= KritikStokSeviyesi", conn);

            using SqlDataReader reader = cmd.ExecuteReader();

            List<string> kritikUrunler = new List<string>();
            while (reader.Read())
            {
                var urun = reader["UrunAd"]?.ToString();

                if (!string.IsNullOrWhiteSpace(urun))
                {
                    kritikUrunler.Add(urun);
                }
            }

            if (kritikUrunler.Count == 0)
                return "Kritik stokta olan ürün bulunmamaktadır.";

            return "Kritik stokta olan ürünler: " + string.Join(", ", kritikUrunler);
        }

        private string BugunGirisYapanKullanicilar()
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            using SqlCommand cmd = new SqlCommand(
                @"SELECT COUNT(DISTINCT k.KullaniciID)
          FROM tblDenetimKayitlari d
          JOIN tblKullanicilar k ON k.KullaniciID = d.KullaniciID
          WHERE d.HareketID = 1 -- giriş işlemi
            AND CAST(d.IslemTarihi AS DATE) = CAST(GETDATE() AS DATE)", conn);

            object result = cmd.ExecuteScalar();
            int sayi = Convert.ToInt32(result);

            return $"Bugün giriş yapan kullanıcı sayısı: {sayi}";
        }
        private string BugunGirisYapmayanKullanicilar()
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            using SqlCommand cmd = new SqlCommand(
                @"SELECT k.KullaniciAdi
          FROM tblKullanicilar k
          WHERE k.KullaniciID NOT IN (
              SELECT DISTINCT d.KullaniciID
              FROM tblDenetimKayitlari d
              WHERE d.HareketID = 1
                AND CAST(d.IslemTarihi AS DATE) = CAST(GETDATE() AS DATE)
          )", conn);

            using SqlDataReader reader = cmd.ExecuteReader();
            List<string> kullanicilar = new List<string>();

            while (reader.Read())
            {
                var ad = reader["KullaniciAdi"]?.ToString();

                if (!string.IsNullOrEmpty(ad))
                {
                    kullanicilar.Add(ad);
                }

            }

            if (kullanicilar.Count == 0)
                return "Bugün giriş yapmayan kullanıcı bulunmamaktadır.";

            return $"Bugün giriş yapmayan kullanıcılar: {string.Join(", ", kullanicilar)}";
        }

        private string BuAyToplamCiro()
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            using SqlCommand cmd = new SqlCommand(
                @"SELECT SUM(sh.Miktar * u.BirimFiyat) AS ToplamCiro
          FROM tblStokHareketleri sh
          JOIN tblUrunler u ON u.UrunID = sh.UrunID
          WHERE MONTH(sh.Tarih) = MONTH(GETDATE()) 
            AND YEAR(sh.Tarih) = YEAR(GETDATE()) 
            AND sh.HareketID = 2", conn);

            object result = cmd.ExecuteScalar();
            if (result == DBNull.Value || result == null)
                return "Bu ay henüz satış yapılmamış.";

            decimal ciro = Convert.ToDecimal(result);
            return $"Bu ayın toplam satış cirosu: {ciro:C}";
        }
        private string GecenHaftaStokHareketleri()
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            using SqlCommand cmd = new SqlCommand(
                @"SELECT COUNT(*) 
          FROM tblStokHareketleri 
          WHERE Tarih >= DATEADD(day, -7, GETDATE())", conn);

            object result = cmd.ExecuteScalar();
            int toplam = Convert.ToInt32(result);
            return $"Geçen hafta toplam stok hareketi sayısı: {toplam}";
        }
        private string DestekMesaji()
        {
            return "Şu anda bu konuda yardımcı olamıyorum. Ancak destek için mail veya telefon ile iletişime geçebilirsiniz.";
        }

        private async Task GosterHarfHarf(string mesaj, bool kullaniciMesaji)
        {
            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.MaximumSize = new Size(400, 0);
            lbl.Padding = new Padding(10);
            lbl.Font = new Font("Segoe UI", 10);
            lbl.BackColor = kullaniciMesaji ? Color.LightGray : Color.Transparent;
            lbl.TextAlign = kullaniciMesaji ? ContentAlignment.MiddleRight : ContentAlignment.MiddleLeft;
            lbl.Margin = kullaniciMesaji ? new Padding(50, 5, 0, 5) : new Padding(0, 5, 50, 5);

            flowChattt.Controls.Add(lbl);
            flowChattt.SetFlowBreak(lbl, true);

            lbl.Text = "";

            foreach (char c in mesaj)
            {
                lbl.Text += c;

                // Her harf eklenince FlowPanel otomatik olarak en alta kayıyor
                flowChattt.ScrollControlIntoView(lbl);

                await Task.Delay(20); // Harf harf animasyon
            }
        }

        // TextBox focus kaybettiğinde placeholder'ı geri getir
        private void txtSoru_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoruuu.Text))
            {
                txtSoruuu.Text = placeholder;
                txtSoruuu.ForeColor = Color.Gray; // placeholder rengi
            }
        }



        int Mesafe(string a, string b)
        {
            int[,] dp = new int[a.Length + 1, b.Length + 1];

            for (int i = 0; i <= a.Length; i++)
                dp[i, 0] = i;

            for (int j = 0; j <= b.Length; j++)
                dp[0, j] = j;

            for (int i = 1; i <= a.Length; i++)
                for (int j = 1; j <= b.Length; j++)
                {
                    int cost = (a[i - 1] == b[j - 1]) ? 0 : 1;

                    dp[i, j] = Math.Min(Math.Min(
                        dp[i - 1, j] + 1,
                        dp[i, j - 1] + 1),
                        dp[i - 1, j - 1] + cost);
                }

            return dp[a.Length, b.Length];
        }




        // İstersen placeholder Label'a tıklayınca TextBox focus almasını sağlayabilirsin:
        private void lblPlaceholder_Click(object sender, EventArgs e)
        {
            txtSoruuu.Focus();
        }

        private void txtSoruuu_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSesliOkumaaa_Click(object sender, EventArgs e)
        {
            sesliOkumaAcik = !sesliOkumaAcik;

        }

        private async void btnGonderrr_Click(object sender, EventArgs e)
        {
            string soru = txtSoruuu.Text.Trim();
            if (string.IsNullOrEmpty(soru) || soru == "Bana soru sor...")
            {
                MessageBox.Show("Lütfen bir soru yazın.");
                return;
            }

            // Kullanıcı mesajını ekle
            EkleMesaj(soru, true);
            txtSoruuu.Clear();

            // Chatbot cevabı
            string cevap = ChatbotCevapla(soru);

            // Sesli okuma açıksa hemen başlat (await yok, paralel çalışacak)
            if (sesliOkumaAcik)
            {
                synthesizer.SpeakAsyncCancelAll(); // önceki sesi kes
                synthesizer.SpeakAsync(cevap);     // yeni cevabı oku
            }

            // Harf harf yazdır
            await GosterHarfHarf(cevap, false);

        }

        private void flowChattt_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ChatbotYonetici_Load(object sender, EventArgs e)
        {
            synthesizer.SetOutputToDefaultAudioDevice(); // hoparlöre gönder
            synthesizer.Rate = 5; // biraz hızlı
            synthesizer.SelectVoice("Microsoft Zira Desktop"); // kadın sesi


        }
      
        private string KelimeKokunuBul(string kelime)
{
    // Türkçedeki yaygın iyelik ve durum eklerini temizler
    string[] ekler = { "ın", "in", "un", "ün", "nın", "nin", "nun", "nün", "ı", "i", "u", "ü" };
    
    foreach (var ek in ekler)
    {
        if (kelime.EndsWith(ek) && kelime.Length > 3) // Kelime çok kısa değilse eki at
            return kelime.Substring(0, kelime.Length - ek.Length);
    }
    return kelime;
}
        private void txtSoruuu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Enter sesini kapat
                btnGonderrr.PerformClick();
            }
        }
             private async Task BotCevapVer(string cevap)
        {
            await Task.Run(() => synthesizer.Speak(cevap));
        }

    }
}
