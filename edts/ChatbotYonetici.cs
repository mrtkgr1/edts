using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace edts
{
    public partial class ChatbotYonetici : Form
    {
        static string connectionString =
            "Server=.\\SQLEXPRESS;Database=StokYonetimDB;Trusted_Connection=True;Encrypt=False;";
        
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
    int nLeftRect,     // Sol üst x-koordinatı
    int nTopRect,      // Sol üst y-koordinatı
    int nRightRect,    // Sağ alt x-koordinatı
    int nBottomRect,   // Sağ alt y-koordinatı
    int nWidthEllipse, // Köşe yuvarlatma genişliği
    int nHeightEllipse // Köşe yuvarlatma yüksekliği
);

        // Botun son önerisini aklında tutar
        private string sonOneri = "";
        private string sonArananUrun = "";

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



            string botAdi = "Fuzuli)";
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
            if (string.IsNullOrWhiteSpace(soru) || soru == placeholder)
                return "Henüz bir şey yazmadınız, size nasıl yardımcı olabilirim?";



            // Noktalama ve küçük harfe çevir
            string temizSoru = new string(soru
                .Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
                .ToArray())
                .ToLower()
                .Trim();

            // Kimlik soruları kontrolü EN BAŞTA
            string[] kimlikSorulari = { "sen kimsin", "kimsin sen", "kimsin", "görevin ne", "ne iş yaparsın", "amacın ne", "ne işe yarıyorsun", "neden buradasın", "kim", "bot musun", "chatbot musun" };
            if (kimlikSorulari.Any(k => temizSoru.Contains(k)))
            {
                return "Ben Fuzuli, senin akıllı depo asistanınım! 🤖\n" +
                       "Sana şu konularda yardımcı olabilirim:\n\n" +
                       "🔍 **Stok Sorgula:** '[Ürün Adı] stok' yazabilirsin.\n" +
                       "💰 **Fiyat Öğren:** '[Ürün Adı] fiyatı ne kadar?'\n" +
                       "📈 **Ciro Analizi:** 'Toplam ciro' veya '[Ürün] ciro'\n" +
                       "⚠️ **Kritik Durum:** 'Kritik stokta ne var?'\n" +
                       "👤 **Yönetim:** 'Giriş yapmayan kullanıcılar kim?'\n\n" +
                       "Ne ile başlayalım?";
            }

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


            // --- 1. ADIM: EVET/HAYIR KONTROLÜNÜ EN BAŞA AL VE RETURN İLE ÇIK ---
            if (temizSoru == "evet" || temizSoru == "olur" || temizSoru == "isterim" || temizSoru == "getir")
            {
                if (sonOneri == "fiyat_sor")
                {
                    sonOneri = ""; // Hafızayı boşalt
                    return UrunFiyatiGetir(sonArananUrun); // Direkt metodu döndür ve ÇIK
                }
                else if (sonOneri == "stok_sor")
                {
                    sonOneri = ""; // Hafızayı boşalt
                    return UrunStokDurumu(sonArananUrun); // Direkt metodu döndür ve ÇIK
                }
                return "Neye evet dediğinizi tam anlayamadım, başka bir şey sormak ister misiniz?";
            }

            if (temizSoru.Contains("neden fuzuli") || temizSoru.Contains("ismin neden fuzuli") || temizSoru.Contains("ismini nereden aldın"))
            {
                return "İsmim, büyük şair Fuzuli'ye bir saygı duruşu olmasının yanı sıra, projedeki ironik bir dokunuşu temsil ediyor: " +
                       "Aslında bir depo yönetim sisteminde yapay zeka 'fuzuli' (gereksiz) bir lüks gibi görünebilir; " +
                       "ancak biz, en karmaşık işleri bile bir sohbet kadar kolay hale getirerek bu lüksü bir standart haline getirdik. " +
                       "Yani ismim fuzuli, ama işlevim vazgeçilmez!";
            }

            if (temizSoru.Contains("fuzuli ne demek") || temizSoru.Contains("fuzulinin tanımı") || temizSoru.Contains("fuzuli anlamı"))
            {
                return "Kelime anlamı olarak 'fuzuli'; gereksiz, boşuna veya yersiz demektir. " +
                       "Ancak edebiyatımızda bu isim, 'faziletli ve bilgili' anlamındaki 'fazl' kelimesinden köken alır. " +
                       "Biz de projemizde bu ismi; ilk bakışta lüks (fuzuli) görünen bir teknolojinin, aslında derin bir bilgi (fazilet) ve kolaylık sunduğunu vurgulamak için seçtik.";
            }

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

            // ---- Ürün işlemleri içinde STOK kısmı ----
            // Stok Sorgusu
            // Stok Sorgusu
            if (orijinal.Contains("stok"))
            {
                if (!RolYetkileri[rolID].Contains("stok")) return "Yetkiniz yok.";

                // ÖNEMLİ: Burada ürün adını ayıklarken "stok" kelimesini temizleyip hafızaya alıyoruz
                sonArananUrun = orijinal.Replace("stok", "").Replace("durumu", "").Replace("ne", "").Replace("kadar", "").Trim();

                // Eğer bu bir 'evet' cevabı sonucu değilse öneri yap
                sonOneri = "fiyat_sor";
                return UrunStokDurumu(orijinal);
            }
            // Fiyat Sorgusu
            else if (orijinal.Contains("fiyat"))
            {
                if (!RolYetkileri[rolID].Contains("fiyat")) return "Yetkiniz yok.";

                sonArananUrun = orijinal.Replace("fiyat", "").Replace("nedir", "").Replace("ne", "").Replace("kadar", "").Trim();

                sonOneri = "stok_sor";
                return UrunFiyatiGetir(orijinal);
            }

            if (temizSoru == "rapor" || temizSoru == "rapor ver")
            {
                return "Raporunuz hazır! Şunları yapabilirim:\n" +
                       "1. 'Raporu kaydet' diyerek masaüstüne alabilirsiniz.\n" +
                       "2. 'Excel raporu oluştur' diyebilirsiniz.\n" +
                       "3. '...mail@gmail.com adresine mail at' diyerek istediğiniz kişiye gönderebilirsiniz.";
            }

            if (temizSoru.Contains("en pahalı")) return EnPahaliUrunuGetir();
            if (temizSoru.Contains("en ucuz")) return EnUcuzUrunuGetir(); // Yeni eklendi

            // --- AKILLI DOSYA KAYDETME SİSTEMİ ---
            if (temizSoru.Contains("kaydet") || temizSoru.Contains("dosya") || temizSoru.Contains("rapor oluştur"))
            {
                // Kullanıcı cümlede formatı zaten belirttiyse (Örn: "Excel olarak kaydet")
                if (temizSoru.Contains("excel"))
                    return KritikStokRaporuDosyala("excel");

                if (temizSoru.Contains("not defteri") || temizSoru.Contains("txt") || temizSoru.Contains("metin"))
                    return KritikStokRaporuDosyala("txt");

                // Format belirtmediyse bot soru sorsun
                return "Raporu hangi formatta hazırlamamı istersiniz? (Örn: 'Excel olarak kaydet' veya 'Not defteri olarak kaydet' diyebilirsiniz.)";
            }

            if (soru.Contains("şaka yap") || soru.Contains("beni güldür"))
            {
                string[] yoneticiSakalari = {
            "Yöneticim, size bir şaka yapacaktım ama performans primimi etkilemesinden korktum... Şaka şaka, bakıyorum hemen!\"Bir gün bir veritabanı hatası yöneticiye çıkmış. Yazılımcı 'Kod bozuk' demiş, sistemci 'Sunucu kapalı' demiş. Yönetici gelip 'Hallederiz' demiş ve hata korkudan düzelmiş. Sizin 'Hallederiz' demeniz bile bu sisteme güven veriyor efendim!\"",
            "Bir gün bir yönetici Fuzuli'ye sormuş: 'Benim neden hiç boş vaktim yok?' Fuzuli cevap vermiş: 'Çünkü her şeyi bana soruyorsunuz efendim!'",
            "Yönetici olmak zor iş; hem personeli idare et, hem bütçeyi düşün, bir de gelip Fuzuli ile uğraş... Allah kolaylık versin!",
            "Sizin için bir 'Toplantı Savar' özelliği geliştirecektim ama yine fuzuli olur diye vazgeçtim. En iyisi biz stoklara bakalım."
        };

                Random rnd = new Random();
                return yoneticiSakalari[rnd.Next(yoneticiSakalari.Length)];
            }



            if (temizSoru.Contains("not al") || temizSoru.Contains("hatırlat"))
            {
                // Orijinal cümleyi gönderiyoruz ki büyük/küçük harf bozulmasın
                return NotKaydet(orijinal);
            }

            // Sadece ekrana özet raporu getirme
            if (temizSoru.Contains("durum raporu") || temizSoru.Contains("genel rapor") || temizSoru.Equals("durum") || temizSoru.Equals("özet"))
            {
                return GenelDurumRaporuHazirla();
            }

            if (temizSoru.Contains("notlarım") || temizSoru.Contains("ajanda") || temizSoru.Contains("neler var"))
            {
                return NotlariListele();
            }

            if (temizSoru.Contains("sil"))
            {
                return NotSil(temizSoru);
            }

            if (temizSoru.Contains("mail at") || temizSoru.Contains("e-posta gönder"))
            {
                // Cümledeki mail adresini ayıklayalım
                string[] kelimeler = orijinal.Split(' ');
                string hedefMail = "";

                foreach (string kelime in kelimeler)
                {
                    if (kelime.Contains("@")) { hedefMail = kelime; break; }
                }

                if (string.IsNullOrEmpty(hedefMail))
                    return "Lütfen bir mail adresi belirtin. Örn: 'test@gmail.com adresine mail at'";

                // Dosyayı sessizce oluştur
                KritikStokRaporuDosyala("sessiz_txt");
                string yol = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Stok_Raporu.txt");

                // İŞTE BURASI: Artık metodumuz 2 parça bilgi (Yol ve Alıcı) bekliyor
                return MailGonder(yol, hedefMail);
            }

            // En pahalı ürün analizi
            if (temizSoru.Contains("en pahalı") || temizSoru.Contains("en yüksek fiyat"))
            {
                return EnPahaliUrunuGetir();
            }

            if (orijinal.Contains("fiyat"))
            {
                if (!RolYetkileri[rolID].Contains("fiyat"))
                    return "Bu bilgiye erişim yetkiniz yok.";

                sonOneri = "stok_sor";

                // Ürün adını ayıkla ve hafızaya al
                sonArananUrun = orijinal.Replace("fiyat", "").Replace("nedir", "").Trim();

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

            // --- GÜVENLİK KİLİDİ ---
            // Mevcut öneriyi yedekle ve hemen sıfırla. 
            // Böylece metot çalışırken 'yeni' bir öneri yapıp yapmayacağına karar verebilir.
            string aktifOneri = sonOneri;
            sonOneri = "";

            // 1. ADIM: "Evet" kontrolü ve hafıza yönetimi
            // Eğer sadece "evet" dendiği için buraya gelindiyse, 'soru' değişkeni 'evet' olacaktır.
            string gercekSoru = (soru.ToLower().Trim() == "evet" || soru.ToLower().Trim() == "olur")
                                ? sonArananUrun : soru;

            // 2. ADIM: Ürün adını ayıkla
            string? urunAdi = gercekSoru.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .FirstOrDefault(x => x != "stok" && x != "var" && x != "mı" && x != "durumu" && x != "nedir" && x != "evet");

            if (string.IsNullOrEmpty(urunAdi))
                return "Ürün adı algılanamadı.";

            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            // 3. ADIM: Veritabanı Sorgusu
            using (SqlCommand cmd = new SqlCommand(
                "SELECT MevcutStok FROM tblUrunler WHERE LOWER(UrunAd) = @UrunAdi", conn))
            {
                cmd.Parameters.AddWithValue("@UrunAdi", urunAdi.ToLower().Trim());
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    decimal stok = Convert.ToDecimal(result);
                    sonArananUrun = urunAdi; // Hafızayı tazele

                    // --- ZİNCİRİ BURADA KIRIYORUZ ---
                    if (aktifOneri == "stok_sor")
                    {
                        // Eğer zaten bir fiyattan sonra buraya geldiysek, yeni öneri YAPMA (sonOneri zaten "" oldu)
                        return $"{urunAdi} stokta {stok} adet var.";
                    }
                    else
                    {
                        // Eğer kullanıcı direkt stok sorduysa, fiyatı teklif et
                        sonOneri = "fiyat_sor";
                        return (stok > 0)
                            ? $"{urunAdi} stokta mevcut. Miktar: {stok}. \n\n**Bu ürünün birim fiyatını da öğrenmek ister misiniz?**"
                            : $"{urunAdi} şu an stokta yok. Başka bir ürün sormak ister misiniz?";
                    }
                }

                // 4. ADIM: Tahmin Mekanizması (Orijinal kodun)
                List<string> tumUrunler = new List<string>();
                using (SqlCommand cmdList = new SqlCommand("SELECT UrunAd FROM tblUrunler", conn))
                using (SqlDataReader r = cmdList.ExecuteReader())
                {
                    while (r.Read())
                        tumUrunler.Add((r["UrunAd"]?.ToString() ?? "").ToLower());
                }

                if (tumUrunler.Count > 0)
                {
                    string tahmin = tumUrunler.OrderBy(x => Mesafe(x, urunAdi)).First();

                    if (Mesafe(tahmin, urunAdi) <= 2)
                    {
                        sonArananUrun = tahmin; // Tahmin edilen ürünü hafızaya al ki "evet" derse çalışsın
                        return $"‘{urunAdi}’ adlı ürün bulunamadı. Şunu mu demek istediniz: **{tahmin}**?";
                    }
                }

                return $"{urunAdi} adlı ürün bulunamadı.";
            }
        }
        private string UrunFiyatiGetir(string soru)
        {

            // 1. ÖNCE: Soru "evet" mi yoksa gerçek bir soru mu ona karar ver
            string gercekSoru = (soru.ToLower().Trim() == "evet" || soru.ToLower().Trim() == "olur")
                                 ? sonArananUrun : soru;

            // 2. SONRA: Karar verdiğin o "gercekSoru" içinden ürün adını çek
            string? urunAdi = gercekSoru.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .FirstOrDefault(x => x != "fiyat" && x != "ne" && x != "kadar" && x != "birim" && x != "nedir" && x != "evet");

            if (string.IsNullOrEmpty(urunAdi))
                return "Ürün adı algılanamadı.";

            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            // Sorgu
            using SqlCommand cmd = new SqlCommand(
                "SELECT BirimFiyat FROM tblUrunler WHERE LOWER(UrunAd) = @UrunAdi", conn);
            cmd.Parameters.AddWithValue("@UrunAdi", urunAdi.ToLower().Trim());

            object result = cmd.ExecuteScalar();

            if (result != null)
            {
                decimal fiyat = Convert.ToDecimal(result);
                sonArananUrun = urunAdi; // Hafızaya al

                // --- ZEKA KONTROLÜ: Tekrar teklif etmeyi engelle ---
                if (sonOneri == "fiyat_sor")
                {
                    sonOneri = ""; // Döngüyü burada bitiriyoruz
                    return $"{urunAdi} ürününün birim fiyatı: {fiyat:C}";
                }
                else
                {
                    // Kullanıcı doğrudan fiyat sorduysa stok teklif et
                    sonOneri = "stok_sor";
                    return $"{urunAdi} ürününün fiyatı: {fiyat:C}. \n\n**Depodaki güncel stok miktarını da öğrenmek ister misiniz?**";
                }
            }

            // --- TAHMİN MEKANİZMASI (Ürün bulunamadıysa) ---
            List<string> tumUrunler = new List<string>();
            using (SqlCommand cmd2 = new SqlCommand("SELECT UrunAd FROM tblUrunler", conn))
            using (SqlDataReader r = cmd2.ExecuteReader())
            {
                while (r.Read())
                {
                    string? ad = r["UrunAd"]?.ToString()?.ToLower();
                    if (!string.IsNullOrWhiteSpace(ad)) tumUrunler.Add(ad);
                }
            }

            if (tumUrunler.Count > 0)
            {
                string tahmin = tumUrunler.OrderBy(x => Mesafe(x, urunAdi)).First();
                if (Mesafe(tahmin, urunAdi) <= 2)
                {
                    sonArananUrun = tahmin; // Tahmini hafızaya al ki "evet" derse fiyatı getirebilsin
                    return $"‘{urunAdi}' bulunamadı. Şunu mu demek istediniz: **{tahmin}**?";
                }
            }

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

            if (sesliOkumaAcik)
            {
                // Image özelliğini veya BackgroundImage özelliğini değiştirebilirsin
                btnSesliOkumaaa.BackgroundImage = Properties.Resources.mic_on;
               
            }
            else
            {
                btnSesliOkumaaa.BackgroundImage = Properties.Resources.mic_off;
                synthesizer.SpeakAsyncCancelAll();
            }

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
            synthesizer.SelectVoice("Microsoft Tolga"); 
            panel4.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panel4.Width, panel4.Height, 30, 30));


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

        private int KritikStokSayisiAl()
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            using SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblUrunler WHERE MevcutStok <= KritikStokSeviyesi", conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private string GunlukOzetBilgi()
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            // Bugün yapılan toplam satış sayısı
            using SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblStokHareketleri WHERE HareketID = 2 AND CAST(Tarih AS DATE) = CAST(GETDATE() AS DATE)", conn);
            int satisSayisi = Convert.ToInt32(cmd.ExecuteScalar());
            return $"Bugün şimdiye kadar {satisSayisi} adet satış işlemi gerçekleştirildi.";
        }

        private string GenelDurumRaporuHazirla()
        {
            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                // Kritik Stok Sayısı
                int kritik = (int)new SqlCommand("SELECT COUNT(*) FROM tblUrunler WHERE MevcutStok <= KritikStok", conn).ExecuteScalar();
                // Bugünün Cirosu
                decimal ciro = (decimal)new SqlCommand("SELECT ISNULL(SUM(ToplamTutar), 0) FROM tblSatislar WHERE CAST(SatisTarihi AS DATE) = CAST(GETDATE() AS DATE)", conn).ExecuteScalar();
                // En Popüler Ürün
                string populer = new SqlCommand("SELECT TOP 1 u.UrunAd FROM tblSatisDetay sd JOIN tblUrunler u ON u.UrunID = sd.UrunID GROUP BY u.UrunAd ORDER BY SUM(sd.Miktar) DESC", conn).ExecuteScalar()?.ToString() ?? "Veri yok";

                return $"📊 **GÜNLÜK ÖZET**\n------------------\n🔹 Kritik Stok: {kritik} adet\n🔹 Bugünün Cirosu: {ciro:C}\n🔹 En Çok Satan: {populer}";
            }
            catch (Exception ex) { return "Rapor Hatası: " + ex.Message; }
        }

        private string EnPahaliUrunuGetir()
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlDataReader dr = new SqlCommand("SELECT TOP 1 UrunAd, BirimFiyat FROM tblUrunler ORDER BY BirimFiyat DESC", conn).ExecuteReader();
            return dr.Read() ? $"En pahalı ürün: {dr["UrunAd"]} ({Convert.ToDecimal(dr["BirimFiyat"]):C})" : "Ürün bulunamadı.";
        }

        private string KritikStokRaporuDosyala(string format = "txt") // Hata buradaki (string format) kısmının eksik olmasındaydı
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataReader dr = new SqlCommand("SELECT UrunAd, MevcutStok, KritikStok FROM tblUrunler WHERE MevcutStok <= KritikStok", conn).ExecuteReader();

                    StringBuilder sb = new StringBuilder();

                    // Eğer format excel ise CSV (noktalı virgüllü) yapıyoruz, değilse düz metin
                    string ayirici = (format == "excel") ? ";" : " | ";
                    string uzanti = (format == "excel") ? "csv" : "txt";

                    // Başlık satırı
                    if (format == "excel")
                        sb.AppendLine("Urun Adi;Mevcut Stok;Kritik Limit");
                    else
                        sb.AppendLine("URUN ADI | MEVCUT | LIMIT");

                    sb.AppendLine("------------------------------------");

                    while (dr.Read())
                    {
                        sb.AppendLine($"{dr["UrunAd"]}{ayirici}{dr["MevcutStok"]}{ayirici}{dr["KritikStok"]}");
                    }

                    string masaustu = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string tamYol = Path.Combine(masaustu, $"Stok_Raporu.{uzanti}");

                    // Excel (CSV) için Türkçe karakter sorunu olmasın diye Encoding.UTF8 ekliyoruz
                    File.WriteAllText(tamYol, sb.ToString(), Encoding.UTF8);
                    if (!format.Contains("sessiz"))
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(tamYol) { UseShellExecute = true });
                    }

                    return $"Rapor {format.ToUpper()} olarak masaüstüne kaydedildi.";
                }
            }
            catch (Exception ex)
            {
                return "Dosya işlemi sırasında hata: " + ex.Message;
            }
        }

        private string EnUcuzUrunuGetir()
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            // ORDER BY BirimFiyat ASC (Küçükten büyüğe) yaparak en ucuzu buluyoruz
            SqlDataReader dr = new SqlCommand("SELECT TOP 1 UrunAd, BirimFiyat FROM tblUrunler ORDER BY BirimFiyat ASC", conn).ExecuteReader();
            return dr.Read() ? $"En ucuz ürün: {dr["UrunAd"]} ({Convert.ToDecimal(dr["BirimFiyat"]):C})" : "Ürün bulunamadı.";
        }

        // ÖNEMLİ: Parantez içindeki (string dosyaYolu, string alici) kısmına dikkat!
        private string MailGonder(string dosyaYolu, string alici)
        {
            try
            {
                // Kendi Gmail adresini ve Uygulama Şifreni buraya yazmayı unutma!
                string gonderenMail = "kanklcx1903@gmail.com";
                string uygulamaSifresi = "mtgc wmdi lnxc nwrl";

                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(gonderenMail);

                // HATA BURADAYDI: 'alici' artık yukarıdaki parantezden geliyor
                mail.To.Add(alici);

                mail.Subject = "Fuzuli - Talep Edilen Rapor";
                mail.Body = "Efendim, istediğiniz rapor ekte sunulmuştur.";

                if (!string.IsNullOrEmpty(dosyaYolu) && File.Exists(dosyaYolu))
                {
                    mail.Attachments.Add(new Attachment(dosyaYolu));
                }

                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential(gonderenMail, uygulamaSifresi);
                smtp.EnableSsl = true;
                smtp.Send(mail);

                return $"Rapor başarıyla {alici} adresine gönderildi.";
            }
            catch (Exception ex)
            {
                return "Mail hatası: " + ex.Message;
            }
        }

        private string NotKaydet(string soru)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // "not al" veya "hatırlat" kelimelerini temizleyip asıl notu alıyoruz
                    string asilNot = soru.Replace("not al", "").Replace("hatırlat", "").Trim();

                    if (string.IsNullOrEmpty(asilNot)) return "Not içeriği boş görünüyor efendim.";

                    string sql = "INSERT INTO tblHatirlaticilar (NotIcerigi) VALUES (@not)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@not", asilNot);
                    cmd.ExecuteNonQuery();

                    return $"Tamamdır, '{asilNot}' notunuzu ajandama ekledim.";
                }
            }
            catch (Exception ex) { return "Not eklenirken bir hata oluştu: " + ex.Message; }
        }

        private string NotlariListele()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT NotIcerigi, KayitTarihi FROM tblHatirlaticilar WHERE Durum = 0 ORDER BY KayitTarihi DESC";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    string sonuc = "📝 **Güncel Notlarınız ve Ajandanız:**\n\n";
                    int sayac = 1;

                    while (dr.Read())
                    {
                        string tarih = Convert.ToDateTime(dr["KayitTarihi"]).ToString("dd.MM HH:mm");
                        sonuc += $"{sayac}. [{tarih}] {dr["NotIcerigi"]}\n";
                        sayac++;
                    }

                    if (sayac == 1) return "Efendim, şu an kayıtlı bir notunuz bulunmuyor.";

                    return sonuc + "\n\n(Bu notları silmek veya tamamlamak isterseniz 'notları temizle' diyebilirsiniz.)";
                }
            }
            catch (Exception ex) { return "Notlar getirilirken hata: " + ex.Message; }
        }

        private string NotSil(string soru)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Sorunun içinden "sil" kelimesini atıp geri kalan kısmı (numara veya metin) alıyoruz
                    string hedef = soru.Replace("sil", "").Replace("notu", "").Trim();

                    if (string.IsNullOrEmpty(hedef)) return "Efendim, hangi notu sileceğimi anlayamadım.";

                    string sql;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    // Eğer kullanıcı sadece sayı girdiyse (örn: "1 sil")
                    if (int.TryParse(hedef, out int siraNo))
                    {
                        // Notları tarihe göre sıralayıp kaçıncı sıradaysa onu buluyoruz
                        sql = @"WITH SiraliNotlar AS (
                            SELECT NotID, ROW_NUMBER() OVER (ORDER BY KayitTarihi DESC) as Sira 
                            FROM tblHatirlaticilar WHERE Durum = 0
                        )
                        UPDATE tblHatirlaticilar SET Durum = 1 
                        WHERE NotID = (SELECT NotID FROM SiraliNotlar WHERE Sira = @sira)";
                        cmd.Parameters.AddWithValue("@sira", siraNo);
                    }
                    else
                    {
                        // Eğer metin girdiyse (örn: "toplantı notunu sil")
                        sql = "UPDATE tblHatirlaticilar SET Durum = 1 WHERE NotIcerigi LIKE @icerik AND Durum = 0";
                        cmd.Parameters.AddWithValue("@icerik", "%" + hedef + "%");
                    }

                    cmd.CommandText = sql;
                    int etkilenen = cmd.ExecuteNonQuery();

                    if (etkilenen > 0)
                        return $"Tabiki, ilgili notu ajandanızdan kaldırdım.";
                    else
                        return "Belirttiğiniz kritere uygun bir not bulamadım.";
                }
            }
            catch (Exception ex) { return "Not silinirken hata: " + ex.Message; }
        }



        private async Task BotCevapVer(string cevap)
        {
            await Task.Run(() => synthesizer.Speak(cevap));
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
