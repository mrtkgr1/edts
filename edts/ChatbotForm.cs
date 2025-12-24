using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace edts
{
    public partial class ChatbotForm : Form
    {
        static string connectionString =
            "Server=LAPTOP-ECRTR81F\\SQLEXPRESS;Database=StokYonetimDB;Trusted_Connection=True;Encrypt=False;";

        // Sınıfın başında, constructor'dan önce
        private Dictionary<int, List<string>> RolYetkileri = new Dictionary<int, List<string>>()
    {
        { 1, new List<string> { "stok", "fiyat", "ciro", "teslim", "kritik stok", "rol", "aktif", "yanlış giriş", "giriş yapan", "giriş yapmayan" } }, // Admin
        { 2, new List<string> { "stok", "fiyat", "teslim", "kritik stok" } }, // Personel
        { 3, new List<string> { "stok", "teslim", "ciro", "kritik stok" } } // Yönetici
    };
        public ChatbotForm()
        {
            InitializeComponent();

            flowChat.FlowDirection = FlowDirection.TopDown;
            flowChat.WrapContents = false;
            flowChat.AutoScroll = true;
            flowChat.Dock = DockStyle.Fill; // panel ekranı kaplasın



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
        private int aktifRolId = 1; // Örnek: 1=Admin, 2=Personel, 3=Yönetici

        private string ChatbotCevapla(string soru)
        {
            if (string.IsNullOrWhiteSpace(soru))
                return "Lütfen bir soru yazın.";

            soru = soru.ToLower().Trim();

            string Normalize(string text)
            {
                text = text.ToLower().Trim();
                string[] removeWords = { "nedir", "acaba", "mı", "mu", "bilgi", "hakkında", "lütfen", "öğrenebilir miyim" };
                foreach (var w in removeWords)
                    text = text.Replace(w, "");
                return text.Trim();
            }
            string temizSoru = new string(soru
               .Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
               .ToArray())
               .ToLower()
               .Trim();

            // Kimlik soruları kontrolü EN BAŞTA
            string[] kimlikSorulari = { "sen kimsin", "kimsin sen", "kimsin", "görevin ne", "ne iş yaparsın", "amacın ne", "ne işe yarıyorsun", "neden buradasın", "kim", "bot musun", "chatbot musun" };
            if (kimlikSorulari.Any(k => temizSoru.Contains(k)))
                return "Ben Fuzuli! Envanter Depo Yönetim Sisteminde sana yardımcı olmak için tasarlanmış bir chatbotum.";

            // Yetki sorgulama kontrolü
            if (temizSoru.Contains("yetki") || temizSoru.Contains("neleri sorabilirim") || temizSoru.Contains("ne yapabilirsin"))
            {
                var yetkiler = RolYetkileri[aktifRolId];
                string yetkiListesi = string.Join(", ", yetkiler);
                return $"Mevcut rolünüzle şu konular hakkında bilgi alabilirsiniz: {yetkiListesi}.";
            }

            string orijinal = soru;
            soru = Normalize(soru);

            // Basit duygu ve selam sözleri
            string[] tesekkurler = { "teşekkür", "teşekkür ederim", "teşekkürler", "çok sağ ol", "sağ ol", "sağol" };
            string[] vedalar = { "iyi günler", "görüşürüz", "hoşça kal", "güle güle" };
            string[] iyiDurum = { "iyi", "harika", "güzel", "süper", "mükemmel" };
            string[] kotuDurum = { "kötü", "berbat", "fena", "yorgun", "mutsuz" };
            string[] selamlar = { "merhaba", "selam", "günaydın", "iyi akşamlar", "hey" };

            // Selamlar ve duygu cevapları
            if (selamlar.Any(s => orijinal.Contains(s)))
                return "Merhaba! Gününüz güzel geçiyordur umarım. Nasılsınız?";

            if (orijinal.Contains("sen nasılsın") || orijinal.Contains("nasılsın"))
                return "Ben iyiyim, teşekkürler! Size nasıl yardımcı olabilirim?";

            if (iyiDurum.Any(s => orijinal.Contains(s)))
                return "Harika! Size nasıl yardımcı olabilirim?";

            if (kotuDurum.Any(s => orijinal.Contains(s)))
                return "Üzgünüm, umarım gününüz daha iyi olur. Nasıl yardımcı olayım?";

            if (temizSoru.Contains("yetki") || temizSoru.Contains("neleri sorabilirim"))
            {
                if (RolYetkileri.ContainsKey(aktifRolId))
                {
                    string yetkiListesi = string.Join(", ", RolYetkileri[aktifRolId]);
                    return $"Mevcut yetkilerinizle şu anahtar kelimelerle sorgu yapabilirsiniz: {yetkiListesi}";
                }
                return "Yetki bilgileriniz alınamadı.";
            }

            // Sorunun anahtar kelimesini tespit et
            string soruAnahtar = "";

            if (orijinal.Contains("kritik") && (orijinal.Contains("liste") || orijinal.Contains("rapor")))
            {
                if (aktifRolId == 1) // Admin
                    return KritikStokRaporuTablo();
            }

            // Kullanıcı Aktif/Pasif Yönetimi (Sadece Admin - RoleID: 1)
            if ((orijinal.Contains("aktif") || orijinal.Contains("pasif")) && orijinal.Contains("yap"))
            {
                if (aktifRolId == 1)
                    return KullaniciDurumGuncelle(orijinal);
                else
                    return "Kullanıcı yetkilerini değiştirme işlemi sadece Admin tarafından yapılabilir.";
            }
            if (orijinal.Contains("stok") || orijinal.Contains("mevcut") || orijinal.Contains("var"))
                soruAnahtar = "stok";
            else if (orijinal.Contains("fiyat") || orijinal.Contains("birim"))
                soruAnahtar = "fiyat";
            else if (orijinal.Contains("ciro"))
                soruAnahtar = "ciro";
            else if (orijinal.Contains("teslim") && orijinal.Contains("tarih"))
                soruAnahtar = "teslim";
            else if (orijinal.Contains("kritik stok"))
                soruAnahtar = "kritik stok";
            else if (orijinal.Contains("rol") && orijinal.Contains("nedir"))
                soruAnahtar = "rol";
            else if (orijinal.Contains("aktif") && orijinal.Contains("mi"))
                soruAnahtar = "aktif";
            else if (orijinal.Contains("yanlış") && orijinal.Contains("giriş"))
                soruAnahtar = "yanlış giriş";
            else if (orijinal.Contains("giriş yapan"))
                soruAnahtar = "giriş yapan";
            else if (orijinal.Contains("giriş yapmayan"))
                soruAnahtar = "giriş yapmayan";

            // Rol yetki kontrolü
            if (!string.IsNullOrEmpty(soruAnahtar))
            {
                if (!RolYetkileri[aktifRolId].Contains(soruAnahtar))
                    return "Maalesef bu yetki alanınızın dışında.";
            }

            if (orijinal.Contains("yap") && (orijinal.Contains("stok") || orijinal.Contains("miktar")))
            {
                // Admin veya Depo Personeli yetkisi kontrolü
                if (aktifRolId == 1 || aktifRolId == 2)
                    return UrunStokGuncelle(orijinal);
                else
                    return "Stok güncelleme yetkiniz bulunmuyor.";
            }

            // Artırma, Azaltma veya Ekleme komutları
            if (orijinal.Contains("art") || orijinal.Contains("azalt") || orijinal.Contains("ekle"))
            {
                if (aktifRolId == 1)
                {
                    return UrunStokMatematik(orijinal);
                }
            }

            if (orijinal.Contains("fiyat") && orijinal.Contains("yap"))
            {
                if (aktifRolId == 1) // Sadece Admin
                {
                    return UrunFiyatGuncelle(orijinal);
                }
                else
                {
                    return "Fiyat güncelleme yetkisi sadece Admin'e aittir.";
                }
            }

            if (orijinal.Contains("son") && (orijinal.Contains("hareket") || orijinal.Contains("işlem") || orijinal.Contains("log")))
            {
                if (aktifRolId == 1) return SonHareketleriGetir();
            }


            // Ürün soruları
            if (orijinal.Contains("stok") || orijinal.Contains("mevcut") || orijinal.Contains("var"))
                return UrunStokDurumu(orijinal);

            if (orijinal.Contains("fiyat") || orijinal.Contains("birim"))
                return UrunFiyatiGetir(orijinal);

            if (orijinal.Contains("ciro"))
                return UrunCiroGetir(orijinal);

            if (orijinal.Contains("teslim") && orijinal.Contains("tarih"))
                return UrunTeslimTarihi(orijinal);

            if (orijinal.Contains("kritik stok"))
                return KritikStokUrunleri();


            // Kullanıcı soruları
            if (orijinal.Contains("rol") && orijinal.Contains("nedir"))
                return KullaniciRolu(orijinal);

            if (orijinal.Contains("aktif") && orijinal.Contains("mi"))
                return KullaniciAktifMi(orijinal);

            if (orijinal.Contains("yanlış") && orijinal.Contains("giriş"))
                return KullaniciYanlisGirisSayisi(orijinal);

            // Depo / kullanıcı hareketleri
            if (orijinal.Contains("bugün") && orijinal.Contains("giriş") && orijinal.Contains("yapan"))
                return BugunGirisYapanKullanicilar();

            if (orijinal.Contains("bugün") && orijinal.Contains("giriş") && orijinal.Contains("yapmayan"))
                return BugunGirisYapmayanKullanicilar();

            // --- YENİ EKLENEN KISIM ---
            if (orijinal.Contains("log") || (orijinal.Contains("kim") && orijinal.Contains("yaptı")))
            {
                // Admin kontrolü (Sadece admin görebilsin)
                if (aktifRolId == 1)
                    return SonSistemHareketleri();
                else
                    return "Bu sistem raporlarını sadece Admin görüntüleyebilir.";
            }
            // --------------------------

            if (orijinal.Contains("geçen hafta") && orijinal.Contains("stok"))
                return GecenHaftaStokHareketleri();

            // Destek / teşekkür / vedalar
            if (orijinal.Contains("giriş yapamıyorum") || orijinal.Contains("destek"))
                return DestekMesaji();

            if (tesekkurler.Any(x => orijinal.Contains(x)))
                return "Rica ederim! Yardımcı olmaya hazırım.";

            if (vedalar.Any(x => orijinal.Contains(x)))
                return "İyi günler, tekrar beklerim.";

            // Cevap bulunamadıysa
            return "Soruyu anlayamadım. Örnek: 'admin aktif mi?' veya 'dolap stokta var mı?'";
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
                flowChat.Controls.Add(balon);
                flowChat.SetFlowBreak(balon, true);
                flowChat.ScrollControlIntoView(balon);
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

                flowChat.Controls.Add(lbl);
                flowChat.SetFlowBreak(lbl, true);
                flowChat.ScrollControlIntoView(lbl);
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

        private string KullaniciDurumGuncelle(string soru)
        {
            // 1. Durumu belirleyelim
            int yeniDurum = (soru.Contains("aktif") || soru.Contains("aç")) ? 1 : 0;
            string durumMetni = yeniDurum == 1 ? "aktif" : "pasif";

            // 2. Kullanıcı adını ayıklayalım
            string[] kelimeler = soru.Replace("aktif", "").Replace("pasif", "").Replace("yap", "").Replace("durumuna", "").Replace("getir", "").Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string hamAd = kelimeler.Length > 0 ? kelimeler[0] : "";
            string kullaniciAdi = TemizleKullaniciAdi(hamAd);

            if (string.IsNullOrEmpty(kullaniciAdi)) return "İşlem yapılacak kullanıcı adını anlayamadım.";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE tblKullanicilar SET AktifMi = @durum WHERE LOWER(KullaniciAdi) = @ad", conn))
                {
                    cmd.Parameters.AddWithValue("@durum", yeniDurum);
                    cmd.Parameters.AddWithValue("@ad", kullaniciAdi.ToLower().Trim());

                    int etkilenenSatir = cmd.ExecuteNonQuery();

                    if (etkilenenSatir > 0)
                    {
                        // BURADA 49 YAZDIK ÇÜNKÜ VERİTABANINDA 1 YOK
                        LogEkle(49, $"Chatbot: {kullaniciAdi} {durumMetni} yapıldı.");
                        return $"{kullaniciAdi} kullanıcısı başarıyla {durumMetni} duruma getirildi.";
                    }
                }
            }
            return $"'{kullaniciAdi}' isimli kullanıcı bulunamadı.";
        }

        // Yardımcı LogEkle metodu (Eğer yoksa)
        private void LogEkle(int kullaniciId, string aciklama)
        {
            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                using SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO tblDenetimKayitlari (KullaniciID, IslemTarihi, Aciklama, TabloAdi, HareketID)  
              VALUES (@id, GETDATE(), @aciklama, 'tblKullanicilar', @hareketId)", conn);

                cmd.Parameters.AddWithValue("@id", kullaniciId);
                cmd.Parameters.AddWithValue("@aciklama", aciklama);
                cmd.Parameters.AddWithValue("@hareketId", 2); // HareketID sütunu için 2 (Güncelleme) gönderiyoruz
                cmd.ExecuteNonQuery();
            }
            catch { /* Log hatası ana işlemi bozmasın */ }
        }

        private string UrunTedarikcisiGetir(string soru)
        {
            string urunAdi = soru.Replace("tedarikçisi", "").Replace("kim", "").Trim();
            // Basit bir temizleme, senin Mesafe metodunla da birleştirebilirsin.

            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            using SqlCommand cmd = new SqlCommand(@"
        SELECT TOP 1 t.TedarikciAd 
        FROM tblTedarikciler t
        JOIN tblStokHareketleri sh ON t.TedarikciID = sh.TedarikciID
        JOIN tblUrunler u ON u.UrunID = sh.UrunID
        WHERE LOWER(u.UrunAd) LIKE @UrunAd", conn);
            cmd.Parameters.AddWithValue("@UrunAd", "%" + urunAdi + "%");

            object result = cmd.ExecuteScalar();
            return result != null
                ? $"{urunAdi} ürününü şu tedarikçiden alıyoruz: {result}"
                : $"{urunAdi} için tedarikçi kaydı bulunamadı.";
        }

        private string SonSistemHareketleri()
        {
            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                using SqlCommand cmd = new SqlCommand(@"
            SELECT TOP 5 d.Aciklama, k.KullaniciAdi, d.IslemTarihi 
            FROM tblDenetimKayitlari d 
            JOIN tblKullanicilar k ON d.KullaniciID = k.KullaniciID 
            ORDER BY d.IslemTarihi DESC", conn);

                using SqlDataReader dr = cmd.ExecuteReader();
                string rapor = "Son 5 işlem:\n";
                bool kayitVarMi = false;
                while (dr.Read())
                {
                    rapor += $"• {dr["IslemTarihi"]:HH:mm} - {dr["KullaniciAdi"]}: {dr["Aciklama"]}\n";
                    kayitVarMi = true;
                }
                return kayitVarMi ? rapor : "Henüz bir sistem hareketi kaydedilmemiş.";
            }
            catch (Exception ex) { return "Hata oluştu: " + ex.Message; }
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

            flowChat.Controls.Add(lbl);
            flowChat.SetFlowBreak(lbl, true);

            lbl.Text = "";

            foreach (char c in mesaj)
            {
                lbl.Text += c;

                // Her harf eklenince FlowPanel otomatik olarak en alta kayıyor
                flowChat.ScrollControlIntoView(lbl);

                await Task.Delay(20); // Harf harf animasyon
            }
        }

        // TextBox focus kaybettiğinde placeholder'ı geri getir
        private void txtSoru_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoru.Text))
            {
                txtSoru.Text = placeholder;
                txtSoru.ForeColor = Color.Gray; // placeholder rengi
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
            txtSoru.Focus();
        }


        private async void btnGonder_Click(object sender, EventArgs e)
        {
            string soru = txtSoru.Text.Trim();
            if (string.IsNullOrEmpty(soru) || soru == "Bana soru sor...")
            {
                MessageBox.Show("Lütfen bir soru yazın.");
                return;
            }
            // --- BURAYA EKLE ---
            txtSoru.SelectionAlignment = HorizontalAlignment.Right; // Sağa yasla
            txtSoru.SelectionColor = Color.Blue; // İstersen kullanıcı rengini farklı yapabilirsin
            txtSoru
                .AppendText("\nSiz: " + soru + "\n");
            // -------------------
            // Kullanıcı mesajını ekle
            EkleMesaj(soru, true);
            txtSoru.Clear();

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

        private void btnSesliOkuma_Click(object sender, EventArgs e)
        {
            sesliOkumaAcik = !sesliOkumaAcik;



        }

        private void flowChat_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSoru_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSoru_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Enter sesini kapat
                btnGonder.PerformClick();
            }

        }
        private async Task BotCevapVer(string cevap)
        {
            await Task.Run(() => synthesizer.Speak(cevap));
        }

        private void ChatbotForm_Load(object sender, EventArgs e)
        {
            synthesizer.SetOutputToDefaultAudioDevice(); // hoparlöre gönder
            synthesizer.Rate = 5; // biraz hızlı
            synthesizer.SelectVoice("Microsoft Zira Desktop"); // kadın sesi
        }

        private string UrunStokGuncelle(string soru)
        {
            // 1. Sayıyı (miktarı) cümleden ayıklayalım
            string[] kelimeler = soru.Split(' ');
            int yeniMiktar = 0;
            foreach (var kelime in kelimeler)
            {
                if (int.TryParse(kelime, out int sonuc))
                {
                    yeniMiktar = sonuc;
                    break;
                }
            }

            // 2. Ürün adını ayıklayalım (Senin önceki ürün bulma mantığın)
            string urunAdi = soru.Replace("stok", "").Replace("yap", "").Replace(yeniMiktar.ToString(), "").Trim();
            urunAdi = TemizleKullaniciAdi(urunAdi); // Ekleri temizle

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Ürünü güncelle
                using (SqlCommand cmd = new SqlCommand("UPDATE tblUrunler SET MevcutStok = @miktar WHERE LOWER(UrunAd) LIKE @ad", conn))
                {
                    cmd.Parameters.AddWithValue("@miktar", yeniMiktar);
                    cmd.Parameters.AddWithValue("@ad", "%" + urunAdi.ToLower() + "%");

                    int etkilenen = cmd.ExecuteNonQuery();

                    if (etkilenen > 0)
                    {
                        // İşlemi loglayalım (Senin 49 ID'li kullanıcın ile)
                        LogEkle(49, $"Chatbot: {urunAdi} ürünü stoğu {yeniMiktar} olarak güncellendi.");
                        return $"{urunAdi} stoğu başarıyla {yeniMiktar} adet olarak güncellendi.";
                    }
                }
            }
            return "Ürünü bulamadığım için stok güncellemesi yapamadım.";
        }

        private string UrunStokMatematik(string soru)
        {
            // 1. Sayıyı ayıklayalım (Cümledeki tüm kelimeleri tek tek kontrol et)
            decimal degisimMiktari = 0;
            string[] kelimeler = soru.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var kelime in kelimeler)
            {
                // Kelime içindeki sadece rakamları ve virgülü alalım (Örn: "100adet" -> "100")
                string sadeceSayi = new string(kelime.Where(c => char.IsDigit(c) || c == ',' || c == '.').ToArray());
                if (decimal.TryParse(sadeceSayi, out decimal sonuc))
                {
                    degisimMiktari = sonuc;
                    break;
                }
            }

            if (degisimMiktari == 0) return "Miktarı anlayamadım. Örnek: 'Kalemi 10 artır'";

            // 2. İşlem yönünü daha geniş bir kontrolle belirleyelim
            // "arttır", "artır", "ekle", "ilave" gibi kelimelerin hepsini kapsayalım
            bool artir = soru.Contains("art") || soru.Contains("ekle") || soru.Contains("ilave");
            string islemMetni = artir ? "artırıldı" : "azaltıldı";

            // 3. Ürün adını ayıklayalım (Sayıyı ve işlem kelimelerini temizle)
            string temizSoru = soru;
            string[] temizlenecekler = { "stok", "stoğunu", "artır", "arttır", "artir", "arttir", "azalt", "ekle", "ilave", degisimMiktari.ToString() };
            foreach (var kelime in temizlenecekler)
                temizSoru = temizSoru.Replace(kelime, "");

            string urunAdi = TemizleKullaniciAdi(temizSoru.Trim());

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Ürünü bul
                SqlCommand cmdGetir = new SqlCommand("SELECT MevcutStok FROM tblUrunler WHERE LOWER(UrunAd) LIKE @ad", conn);
                cmdGetir.Parameters.AddWithValue("@ad", "%" + urunAdi.ToLower() + "%");
                object mevcut = cmdGetir.ExecuteScalar();

                if (mevcut != null)
                {
                    decimal suAnkiStok = Convert.ToDecimal(mevcut);
                    decimal yeniStok = artir ? (suAnkiStok + degisimMiktari) : (suAnkiStok - degisimMiktari);

                    if (yeniStok < 0) return $"Hata: Stok sıfırın altına düşemez! (Mevcut: {suAnkiStok})";

                    // Güncelle
                    SqlCommand cmdGuncelle = new SqlCommand("UPDATE tblUrunler SET MevcutStok = @yeni WHERE LOWER(UrunAd) LIKE @ad", conn);
                    cmdGuncelle.Parameters.AddWithValue("@yeni", yeniStok);
                    cmdGuncelle.Parameters.AddWithValue("@ad", "%" + urunAdi.ToLower() + "%");
                    cmdGuncelle.ExecuteNonQuery();

                    LogEkle(49, $"Chatbot: {urunAdi} {degisimMiktari} {islemMetni}. Yeni: {yeniStok}");

                    return $"{urunAdi} ürünü {degisimMiktari} birim {islemMetni}. Güncel stok: {yeniStok}";
                }
            }
            return $"'{urunAdi}' isimli ürünü veritabanında bulamadım.";
        }

        private string UrunFiyatGuncelle(string soru)
        {
            // 1. Sayıyı (Fiyatı) ayıklayalım
            decimal yeniFiyat = 0;
            string[] kelimeler = soru.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var kelime in kelimeler)
            {
                string sadeceSayi = new string(kelime.Where(c => char.IsDigit(c) || c == ',' || c == '.').ToArray());
                if (decimal.TryParse(sadeceSayi, out decimal sonuc))
                {
                    yeniFiyat = sonuc;
                    break;
                }
            }

            if (yeniFiyat <= 0) return "Geçerli bir fiyat belirtmediniz.";

            // 2. Ürün adını ayıklayalım
            string temizSoru = soru;
            string[] temizlenecekler = { "fiyat", "fiyatını", "yap", "tl", "₺", "güncelle", yeniFiyat.ToString() };
            foreach (var w in temizlenecekler) temizSoru = temizSoru.Replace(w, "");

            string urunAdi = TemizleKullaniciAdi(temizSoru.Trim());

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Sütun ismin: BirimFiyat
                using (SqlCommand cmd = new SqlCommand("UPDATE tblUrunler SET BirimFiyat = @fiyat WHERE LOWER(UrunAd) LIKE @ad", conn))
                {
                    cmd.Parameters.AddWithValue("@fiyat", yeniFiyat);
                    cmd.Parameters.AddWithValue("@ad", "%" + urunAdi.ToLower() + "%");

                    int etkilenen = cmd.ExecuteNonQuery();
                    if (etkilenen > 0)
                    {
                        LogEkle(49, $"Chatbot: {urunAdi} fiyatı {yeniFiyat} TL olarak güncellendi.");
                        return $"{urunAdi} ürününün yeni birim fiyatı: {yeniFiyat} TL.";
                    }
                }
            }
            return $"'{urunAdi}' isimli ürünü bulamadım.";
        }

        private string KritikStokRaporuTablo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT UrunAd, MevcutStok, KritikStok FROM tblUrunler WHERE MevcutStok <= KritikStok";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                // Tablo başlığı
                string tablo = "\n----------------------------------------\n";
                tablo += string.Format("{0,-15} | {1,-10} | {2,-10}\n", "Ürün Adı", "Mevcut", "Kritik");
                tablo += "----------------------------------------\n";

                bool veriVar = false;
                while (dr.Read())
                {
                    veriVar = true;
                    tablo += string.Format("{0,-15} | {1,-10} | {2,-10}\n",
                        dr["UrunAd"].ToString(),
                        dr["MevcutStok"].ToString(),
                        dr["KritikStok"].ToString());
                }

                if (!veriVar) return "Harika! Şu an kritik stok seviyesinde ürün bulunmuyor.";

                tablo += "----------------------------------------";
                return "İşte dikkat etmen gereken ürünler:\n" + tablo;
            }
        }

        private string AdminYardimRehberi()
        {
            return @"--- ADMIN KOMUT REHBERİ ---
1. KULLANICI: '[İsim] pasif yap' veya 'aktif yap'
2. STOK GÜNCELLE: '[Ürün] stoğunu [Sayı] yap'
3. STOK İŞLEM: '[Ürün] stoğunu [Sayı] artır/azalt'
4. FİYAT: '[Ürün] fiyatını [Sayı] yap'
5. RAPOR: 'kritik stok raporu' veya 'sistem özeti'
---------------------------";
        }
        private void txtSoru_Enter(object sender, EventArgs e)
        {
            if (txtSoru.Text == placeholder)
            {
                txtSoru.Text = "";
                txtSoru.ForeColor = Color.Black; // yazı rengini normal yap
            }
        }

        private void txtSoru_KeyDown_1(object sender, KeyEventArgs e)
        {
            // Sadece Enter tuşuna basıldıysa (Shift tuşu basılı değilse)
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true; // Enter'ın alt satıra geçmesini engelle

                // Buraya senin soruyu gönderen butonunun adını yaz (Örn: btnGonder_Click)
                btnGonder.PerformClick();
            }
        }

        private string SonHareketleriGetir()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Son 5 işlemi tarih sırasına göre getiriyoruz
                string query = "SELECT TOP 5 Aciklama, IslemTarihi FROM tblDenetimKayitlari ORDER BY IslemTarihi DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                string rapor = "--- SON 5 SİSTEM HAREKETİ ---\n";
                bool kayitVar = false;

                while (dr.Read())
                {
                    kayitVar = true;
                    rapor += $"* {dr["IslemTarihi"]}: {dr["Aciklama"]}\n";
                }

                return kayitVar ? rapor : "Henüz bir işlem kaydı bulunmuyor.";
            }
        }

        private void txtSoru_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnGonder_Click_1(object sender, EventArgs e)
        {

        }
    }
}
