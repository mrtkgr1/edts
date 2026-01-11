using DocumentFormat.OpenXml.Office.Word;
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
using System.Runtime.InteropServices;

namespace edts
{
    public partial class ChatbotDepo : Form
    {
        static string connectionString =
            "Server=LAPTOP-ECRTR81F\\SQLEXPRESS;Database=StokYonetimDB;Trusted_Connection=True;Encrypt=False;";


        private string sonArananUrun = "";
        private string sonKategori = "";

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
    int nLeftRect,
    int nTopRect,
    int nRightRect,
    int nBottomRect,
    int nWidthEllipse,
    int nHeightEllipse
            );

        private bool formatBekleniyor = false;
        private string[] matrixMesajlari = {
    "◈ Veritabanı katmanlarına sızılıyor...",
    "◈ SQL paketleri analiz ediliyor...",
    "◈ Güvenlik duvarı aşılıyor (şaka şaka)...",
    "◈ Veriler şifreleniyor: [##########] %100",
    "◈ Fuzuli derinlere iniyor..."
};


        private Dictionary<int, List<string>> RolYetkileri = new Dictionary<int, List<string>>()
    {
        { 3, new List<string> { "stok", "fiyat", "teslim", "kritik stok","raf", "stok_matematik" } },
    };


        public ChatbotDepo()
        {
            InitializeComponent();

            flowChatt.FlowDirection = FlowDirection.TopDown;
            flowChatt.WrapContents = false;
            flowChatt.AutoScroll = true;
            flowChatt.Dock = DockStyle.Fill;



            string botAdi = "Fuzuli";
            _ = GosterHarfHarf($"{botAdi}: Merhaba! Bugün size nasıl yardımcı olabilirim?", false);


        }




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

            return 0;
        }




        private string ChatbotCevapla(string soru)
        {


            if (string.IsNullOrWhiteSpace(soru))
                return "Lütfen bir soru yazın.";


            string temizSoru = new string(soru
                .Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
                .ToArray())
                .ToLower()
                .Trim();


            string[] kimlikSorulari = { "sen kimsin", "kimsin sen", "kimsin", "görevin ne", "ne iş yaparsın", "amacın ne", "ne işe yarıyorsun", "neden buradasın", "kim", "bot musun", "chatbot musun" };
            if (kimlikSorulari.Any(k => temizSoru.Contains(k)))
                return "Ben Fuzuli! Envanter Depo Yönetim Sisteminde sana yardımcı olmak için tasarlanmış bir chatbotum.";

            string orijinal = soru.Trim();


            string Normalize(string text)
            {
                string[] removeWords = { "nedir", "acaba", "mı", "mu", "bilgi", "hakkında", "lütfen", "öğrenebilir miyim" };
                foreach (var w in removeWords)
                    text = text.Replace(w, "");
                return text.Trim();
            }


            string normalizedSoru = Normalize(temizSoru);


            string[] tesekkurler = { "teşekkür", "teşekkür ederim", "teşekkürler", "çok sağ ol", "sağ ol", "sağol" };
            string[] vedalar = { "iyi günler", "görüşürüz", "hoşça kal", "güle güle" };
            string[] iyiDurum = { "iyi", "harika", "güzel", "süper", "mükemmel" };
            string[] kotuDurum = { "kötü", "berbat", "fena", "yorgun", "mutsuz" };
            string[] selamlar = { "merhaba", "selam", "günaydın", "iyi akşamlar", "hey" };





            if (selamlar.Any(s => temizSoru.Contains(s)))
                return "Merhaba! Gününüz güzel geçiyordur umarım. Nasılsınız?";

            if (normalizedSoru.Contains("nasılsın"))
                return "Ben iyiyim, teşekkürler! Size nasıl yardımcı olabilirim?";

            if (iyiDurum.Any(s => temizSoru.Contains(s)))
                return "Harika! Size nasıl yardımcı olabilirim?";

            if (kotuDurum.Any(s => temizSoru.Contains(s)))
                return "Üzgünüm, umarım gününüz daha iyi olur. Nasıl yardımcı olayım?";

            int rolID = AktifKullanici.RolID;

            string kategori = "";








            if (temizSoru.Contains("aktif") || temizSoru.Contains("pasif"))
            {
                if (temizSoru.Contains("yap"))
                {
                    if (AktifKullanici.RolID != 1) return "Kullanıcı durumunu sadece Admin değiştirebilir.";
                    kategori = "kullanici_guncelle";
                }
                else kategori = "aktif";
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



            else if (temizSoru.Contains("stok") || temizSoru.Contains("miktar"))
            {
                if (temizSoru.Contains("yap") || temizSoru.Contains("art") || temizSoru.Contains("azalt") || temizSoru.Contains("ekle"))
                {

                    if (AktifKullanici.RolID == 1 || AktifKullanici.RolID == 3)
                        kategori = "stok_guncelle";
                    else
                        return "Stok güncelleme yetkiniz bulunmuyor.";
                }
                else if (temizSoru.Contains("kritik")) kategori = "kritik stok";
                else kategori = "stok";
            }


            if (soru.Contains("şaka yap") || soru.Contains("komik bir şey söyle"))
            {
                string[] sakalar = {
        "Geçen gün bir SQL sorgusu bara girmiş, yan masadaki iki tabloya 'Join' olabilir miyiz demiş.",
        "Bilgisayarlar neden hiç şemsiye taşımaz? Çünkü zaten pencereleri (Windows) var.",
        "Fuzuli diyor ki: Veritabanı dolup taşsa da gönlümdeki yeriniz sınırsız efendim."
    };
                Random rnd = new Random();
                return sakalar[rnd.Next(sakalar.Length)];
            }

            if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 6)
            {

                string sitemliGiris = "Gecenin bu saatinde dertlerinize ortak olurum ama bu verileri sormanız beni biraz yaraladı... Yine de sizin için bakıyorum: ";

                if (soru.Contains("fiyat") || soru.Contains("birim") || soru.Contains("kadar"))
                {
                    return sitemliGiris + UrunFiyatiGetir(soru);
                }
            }

            if (soru.Contains("nasılsın") || soru.Contains("naber"))
            {
                return "Hiç bu kadar iyi olmamıştım";
            }



            else if (temizSoru.Contains("fiyat") || temizSoru.Contains("birim"))
            {
                if (temizSoru.Contains("yap") || temizSoru.Contains("güncelle") || temizSoru.Contains("değiştir"))
                {
                    if (AktifKullanici.RolID != 1)
                        return "Fiyatları sadece Admin güncelleyebilir. Personel sadece fiyat sorgulayabilir.";

                    kategori = "fiyat_guncelle";
                }
                else
                {
                    kategori = "fiyat";
                }
            }


            else if (temizSoru.Contains("stok") || temizSoru.Contains("miktar"))
            {

                if (temizSoru.Contains("art") || temizSoru.Contains("azalt") || temizSoru.Contains("ekle") || temizSoru.Contains("yap"))
                {

                    if (AktifKullanici.RolID == 1 || AktifKullanici.RolID == 3)
                    {
                        kategori = "stok_matematik";
                    }
                    else
                    {
                        return "Stok güncelleme yetkiniz bulunmuyor. Mevcut Rol ID'niz: " + AktifKullanici.RolID;
                    }
                }
                else if (temizSoru.Contains("kritik")) kategori = "kritik stok";
                else kategori = "stok";
            }


            if (temizSoru.Contains("kritik stok"))
                kategori = "kritik stok";
            else if (temizSoru.Contains("bugün") && temizSoru.Contains("giriş") && temizSoru.Contains("yapmayan"))
                kategori = "giriş yapmayan";
            else if (temizSoru.Contains("bugün") && temizSoru.Contains("giriş") && temizSoru.Contains("yapan"))
                kategori = "giriş yapan";
            else if (temizSoru.Contains("yanlış") && temizSoru.Contains("giriş"))
                kategori = "yanlış giriş";
            else if (temizSoru.Contains("teslim") && temizSoru.Contains("tarih"))
                kategori = "teslim";

            else if (temizSoru.Contains("stok") || temizSoru.Contains("mevcut") || temizSoru.Contains("var"))
                kategori = "stok";
            else if (temizSoru.Contains("fiyat") || temizSoru.Contains("birim"))
                kategori = "fiyat";
            else if (temizSoru.Contains("ciro"))
                kategori = "ciro";
            else if (temizSoru.Contains("rol"))
                kategori = "rol";
            else if (temizSoru.Contains("aktif"))
                kategori = "aktif";
            else if (temizSoru.Contains("raf") || temizSoru.Contains("nerede"))
                kategori = "raf";






            if (!string.IsNullOrEmpty(kategori))
            {

                if (kategori.EndsWith("_guncelle") && rolID != 1)
                {

                    if (!(kategori == "stok_guncelle" && rolID == 2))
                        return "Bu işlem için yetkiniz bulunmamaktadır. Lütfen sistem yöneticisine başvurun.";
                }


                if (!RolYetkileri.ContainsKey(rolID) || !RolYetkileri[rolID].Contains(kategori.Replace("_guncelle", "")))
                {
                    return "Bu bilgiye erişim yetkiniz bulunmuyor.";
                }
            }

            if (temizSoru.Contains("yetkim") || temizSoru.Contains("neler yapabilirim") || temizSoru.Contains("görevim ne"))
            {
                if (rolID == 1)
                {
                    return "Sistem Yöneticisiniz (Admin). Tüm yetkilere sahipsiniz: Stok ve fiyat güncelleyebilir, kullanıcıları yönetebilir, ciro ve raporları görebilirsiniz.";
                }
                else if (rolID == 3)
                {
                    return "Depo Personelisiniz. Yapabileceğiniz işlemler:\n" +
                           "• Stok sorgulama ve ürün konumu öğrenme\n" +
                           "• Stok miktarı artırma/azaltma (Örn: 'Kalem stoğunu 10 artır')\n" +
                           "• Kritik stok ve teslim tarihi sorgulama\n" +
                           "• Ürün fiyatı sorgulama.";
                }
                else if (rolID == 2)
                {
                    return "Yöneticisiniz. Yapabileceğiniz işlemler:\n" +
                           "• Satış ve ciro raporlarını görme\n" +
                           "• Stok ve fiyatları izleme.";
                }
                else
                {
                    return $"Sistemde tanımlı bir rolünüz bulunamadı. (Mevcut ID: {rolID})";
                }
            }

            if (!string.IsNullOrEmpty(kategori))
            {
                if (!RolYetkileri.ContainsKey(rolID) || !RolYetkileri[rolID].Contains(kategori))
                {
                    return "Maalesef bu yetki alanınızın dışında.";
                }
            }

            switch (kategori)
            {
                case "stok_matematik": return UrunStokMatematik(orijinal);
                case "stok": return UrunStokDurumu(orijinal);
                case "raf": return UrunKonumuGetir(orijinal);
                case "kritik stok": return KritikStokUrunleri();
                case "teslim": return UrunTeslimTarihi(orijinal);
                case "fiyat": return UrunFiyatiGetir(orijinal);
                case "ciro": return UrunCiroGetir(orijinal);
                case "rol": return KullaniciRolu(orijinal);
                case "aktif": return KullaniciAktifMi(orijinal);
                case "yanlış giriş": return KullaniciYanlisGirisSayisi(orijinal);
                case "giriş yapan": return BugunGirisYapanKullanicilar();
                case "giriş yapmayan": return BugunGirisYapmayanKullanicilar();

            }

            if (temizSoru.Contains("giriş yapamıyorum") || temizSoru.Contains("destek"))
                return DestekMesaji();

            if (tesekkurler.Any(x => temizSoru.Contains(x)))
                return "Rica ederim! Yardımcı olmaya hazırım.";

            if (vedalar.Any(x => temizSoru.Contains(x)))
                return "İyi günler, tekrar beklerim.";

            return "Soruyu anlayamadım. Örnek: 'admin aktif mi?' veya 'dolap stokta var mı?'";
        }


        private void txtSoru_Enter(object sender, EventArgs e)
        {
            if (txtSoruu.Text == placeholder)
            {
                txtSoruu.Text = "";
                txtSoruu.ForeColor = Color.Black;
            }
        }

        private string UrunKonumuGetir(string soru)
        {

            string urunAdi = soru.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                 .FirstOrDefault(x => x != "nerede" && x != "raf" && x != "konum") ?? "";

            if (string.IsNullOrEmpty(urunAdi)) return "Hangi ürünün konumunu merak ediyorsunuz?";

            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            using SqlCommand cmd = new SqlCommand("SELECT RafNo FROM tblUrunler WHERE LOWER(UrunAd) = @ad", conn);
            cmd.Parameters.AddWithValue("@ad", urunAdi.ToLower().Trim());

            object result = cmd.ExecuteScalar();
            if (result != null && result != DBNull.Value)
                return $"{urunAdi} ürünü {result} numaralı rafta bulunuyor.";

            return $"{urunAdi} ürünü için raf bilgisi sistemde kayıtlı değil.";
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

                Panel balon = new Panel();
                balon.BackColor = Color.FromArgb(250, 250, 250);
                balon.AutoSize = true;
                balon.Padding = new Padding(10);
                balon.Margin = new Padding(150, 5, 10, 5);
                balon.MaximumSize = new Size(400, 0);

                Label lbl = new Label();
                lbl.Text = mesaj;
                lbl.AutoSize = true;
                lbl.MaximumSize = new Size(380, 0);
                lbl.BackColor = Color.Transparent;
                lbl.Font = new Font("Segoe UI", 10);
                lbl.TextAlign = ContentAlignment.MiddleRight;
                lbl.Dock = DockStyle.Fill;

                balon.Controls.Add(lbl);
                flowChatt.Controls.Add(balon);
                flowChatt.SetFlowBreak(balon, true);
                flowChatt.ScrollControlIntoView(balon);
            }
            else
            {

                Label lbl = new Label();
                lbl.Text = mesaj;
                lbl.AutoSize = true;
                lbl.MaximumSize = new Size(600, 0);
                lbl.BackColor = Color.Transparent;
                lbl.Font = new Font("Segoe UI", 10);
                lbl.Margin = new Padding(10, 5, 50, 5);
                lbl.TextAlign = ContentAlignment.MiddleLeft;

                flowChatt.Controls.Add(lbl);
                flowChatt.SetFlowBreak(lbl, true);
                flowChatt.ScrollControlIntoView(lbl);
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


            string urunAdi = UrunAdiniBelirle(soru.ToLower().Trim());

            if (string.IsNullOrEmpty(urunAdi))
                return "Ürün adı algılanamadı.";

            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();


            using (SqlCommand cmd = new SqlCommand(
                "SELECT MevcutStok FROM tblUrunler WHERE LOWER(UrunAd) = @UrunAdi", conn))
            {
                cmd.Parameters.AddWithValue("@UrunAdi", urunAdi.ToLower().Trim());
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    decimal stok = Convert.ToDecimal(result);
                    return $"{urunAdi} ürününden şu an stokta {stok} adet var.";
                }
            }



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

            if (Mesafe(tahmin, urunAdi) <= 2)
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


            using SqlCommand cmd = new SqlCommand(
                "SELECT BirimFiyat FROM tblUrunler WHERE LOWER(UrunAd) = @UrunAdi", conn);
            cmd.Parameters.AddWithValue("@UrunAdi", urunAdi.ToLower().Trim());

            object result = cmd.ExecuteScalar();

            if (result != null)
            {
                decimal fiyat = Convert.ToDecimal(result);
                return $"{urunAdi} ürününün fiyatı: {fiyat:C}";
            }


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

            flowChatt.Controls.Add(lbl);
            flowChatt.SetFlowBreak(lbl, true);

            lbl.Text = "";

            foreach (char c in mesaj)
            {
                lbl.Text += c;


                flowChatt.ScrollControlIntoView(lbl);

                await Task.Delay(20);
            }
        }

        private string UrunStokMatematik(string soru)
        {
            try
            {
                int miktar = 0;

                var sayiKismi = new string(soru.Where(char.IsDigit).ToArray());
                if (!int.TryParse(sayiKismi, out miktar) || miktar <= 0)
                    return "Lütfen geçerli bir miktar belirtin. (Örn: 10 ekle)";


                bool artir = soru.Contains("art") || soru.Contains("ekle") || soru.Contains("geldi");


                string hamUrunAdi = UrunAdiniBelirle(soru);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();


                    string gercekUrunAdi = hamUrunAdi;


                    SqlCommand kontrolCmd = new SqlCommand("SELECT MevcutStok FROM tblUrunler WHERE UrunAd = @ad", conn);
                    kontrolCmd.Parameters.AddWithValue("@ad", gercekUrunAdi);
                    object currentStockObj = kontrolCmd.ExecuteScalar();

                    if (currentStockObj == null)
                        return $"'{hamUrunAdi}' adında bir ürün bulunamadı. Lütfen ürün adını kontrol edin.";

                    int mevcutStok = Convert.ToInt32(currentStockObj);


                    if (!artir && mevcutStok < miktar)
                        return $"Yetersiz stok! Mevcut: {mevcutStok}, Azaltılmak istenen: {miktar}. İşlem iptal edildi.";


                    string sql = artir
                        ? "UPDATE tblUrunler SET MevcutStok = MevcutStok + @m WHERE UrunAd = @ad"
                        : "UPDATE tblUrunler SET MevcutStok = MevcutStok - @m WHERE UrunAd = @ad";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@m", miktar);
                        cmd.Parameters.AddWithValue("@ad", gercekUrunAdi);
                        cmd.ExecuteNonQuery();

                        int yeniStok = artir ? mevcutStok + miktar : mevcutStok - miktar;



                        return $"✅ **{gercekUrunAdi}** stoğu güncellendi.\nDeğişim: {(artir ? "+" : "-")}{miktar}\nGüncel Stok: **{yeniStok}**";
                    }
                }
            }
            catch (Exception ex) { return "Hata oluştu: " + ex.Message; }
        }


        private void txtSoru_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoruu.Text))
            {
                txtSoruu.Text = placeholder;
                txtSoruu.ForeColor = Color.Gray;
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





        private void lblPlaceholder_Click(object sender, EventArgs e)
        {
            txtSoruu.Focus();
        }

        private async Task BotCevapVer(string cevap)
        {
            await Task.Run(() => synthesizer.Speak(cevap));
        }
        private void txtSoruu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnGonderr.PerformClick();
            }
        }

        private void txtSoruu_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSesliOkumaa_Click(object sender, EventArgs e)
        {
            sesliOkumaAcik = !sesliOkumaAcik;
            if (sesliOkumaAcik)
            {

                btnSesliOkumaa.BackgroundImage = Properties.Resources.mic_on;

            }
            else
            {
                btnSesliOkumaa.BackgroundImage = Properties.Resources.mic_off;
                synthesizer.SpeakAsyncCancelAll();
            }

        }

        private string UrunFiyatGuncelle(string soru)
        {

            string urunAdi = "";
            decimal yeniFiyat = 0;

            try
            {

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


                string temizSoru = soru.ToLower();
                string[] temizlenecekler = { "fiyat", "fiyatını", "yap", "tl", "₺", "güncelle", yeniFiyat.ToString() };
                foreach (var w in temizlenecekler)
                    temizSoru = temizSoru.Replace(w, "");

                urunAdi = TemizleKullaniciAdi(temizSoru.Trim());

                if (string.IsNullOrEmpty(urunAdi)) return "Ürün adı belirlenemedi.";


                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE tblUrunler SET BirimFiyat = @fiyat WHERE LOWER(UrunAd) LIKE @ad", conn))
                    {
                        cmd.Parameters.AddWithValue("@fiyat", yeniFiyat);
                        cmd.Parameters.AddWithValue("@ad", "%" + urunAdi + "%");

                        int etkilenen = cmd.ExecuteNonQuery();
                        if (etkilenen > 0)
                        {
                            return $"{urunAdi} ürününün fiyatı {yeniFiyat} TL olarak güncellendi.";
                        }
                        else
                        {
                            return $"'{urunAdi}' isimli ürün bulunamadı.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "İşlem sırasında bir hata oluştu: " + ex.Message;
            }
        }
        private async void btnGonderr_Click(object sender, EventArgs e)
        {
            string soru = txtSoruu.Text.Trim();
            if (string.IsNullOrEmpty(soru) || soru == "Bana soru sor...")
            {
                MessageBox.Show("Lütfen bir soru yazın.");
                return;
            }


            EkleMesaj(soru, true);
            txtSoruu.Clear();



            if (soru.Contains("stok") || soru.Contains("kaydet") || soru.Contains("log") || soru.Contains("ciro"))
            {
                await MatrixEfektiYap();
            }



            string cevap = ChatbotCevapla(soru);


            if (sesliOkumaAcik)
            {
                synthesizer.SpeakAsyncCancelAll();
                synthesizer.SpeakAsync(cevap);
            }


            await GosterHarfHarf(cevap, false);

        }


        private async Task MatrixEfektiYap()
        {
            Random rnd = new Random();
            for (int i = 0; i < 2; i++)
            {
                string secilen = matrixMesajlari[rnd.Next(matrixMesajlari.Length)];
                await GosterHarfHarf(secilen, false);
                await Task.Delay(400);
            }
        }

        private void BotDosyaHazirla(string tip)
        {

        }

        private void ChatbotDepo_Load(object sender, EventArgs e)
        {
            panel4.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panel4.Width, panel4.Height, 25, 25));
            synthesizer.SetOutputToDefaultAudioDevice();
            synthesizer.Rate = 2;
            synthesizer.SelectVoice("Microsoft Tolga");


        }

        private string UrunAdiniBelirle(string temizSoru)
        {

            string[] gereksizKelimeler = { "ne", "kadar", "stok", "fiyat", "birim", "var", "mı", "mu", "nerede", "raf", "ciro", "teslim", "tarihi", "peki", "ya", "onun" };

            var kelimeler = temizSoru.Split(' ', StringSplitOptions.RemoveEmptyEntries);


            string bulunanUrun = kelimeler.FirstOrDefault(k => !gereksizKelimeler.Contains(k)) ?? "";

            if (!string.IsNullOrEmpty(bulunanUrun))
            {

                sonArananUrun = bulunanUrun;
                return bulunanUrun;
            }
            else if (!string.IsNullOrEmpty(sonArananUrun))
            {

                return sonArananUrun;
            }

            return "";
        }

        private void flowChatt_Paint(object sender, PaintEventArgs e)
        {

        }


        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSoruu_Enter(object sender, EventArgs e)
        {
            if (txtSoruu.Text == "Fuzuli'ye Sor")
            {
                txtSoruu.Text = "";
                txtSoruu.ForeColor = Color.Black; 
            }
        }

        private void txtSoruu_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoruu.Text))
            {
                txtSoruu.Text = "Fuzuli'ye Sor";
                txtSoruu.ForeColor = Color.Gray; 
            }
        }
    }
}
