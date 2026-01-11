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
using System.IO;
using ClosedXML.Excel; 


namespace edts
{
    public partial class ChatbotForm : Form
    {
        static string connectionString =
            "Server=.\\SQLEXPRESS;Database=StokYonetimDB;Trusted_Connection=True;Encrypt=False;";

        private bool formatBekleniyor = false;




        private Dictionary<int, List<string>> RolYetkileri = new Dictionary<int, List<string>>()
{
    { 1, new List<string> { "stok", "fiyat", "ciro", "teslim", "kritik stok", "rol", "aktif", "yanlış giriş", "giriş yapan", "giriş yapmayan", "analiz", "hareketler", "kullanıcı özet" } },
    { 2, new List<string> { "stok", "fiyat", "teslim", "kritik stok" } },
    { 3, new List<string> { "stok", "teslim", "ciro", "kritik stok" } }
};
        public ChatbotForm()
        {
            InitializeComponent();

            flowChat.FlowDirection = FlowDirection.TopDown;
            flowChat.WrapContents = false;
            flowChat.AutoScroll = true;
            flowChat.Dock = DockStyle.Fill;




            string botAdi = "Fuzuli";
            _ = GosterHarfHarf($"{botAdi}: Merhaba! Bugün size nasıl yardımcı olabilirim?", false);


        }





        private string placeholder = "Fuzuli'ye Soru Sor...";
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
        private int aktifRolId = 1;

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


            string[] kimlikSorulari = { "sen kimsin", "kimsin sen", "kimsin", "görevin ne", "ne iş yaparsın", "amacın ne", "ne işe yarıyorsun", "neden buradasın", "kim", "bot musun", "chatbot musun" };
            if (kimlikSorulari.Any(k => temizSoru.Contains(k)))
                return "Ben Fuzuli! Envanter Depo Yönetim Sisteminde sana yardımcı olmak için tasarlanmış bir chatbotum.";

            if (temizSoru.Contains("yetki") || temizSoru.Contains("neleri sorabilirim") || temizSoru.Contains("ne yapabilirsin"))
            {
                var yetkiler = RolYetkileri[aktifRolId];
                string yetkiListesi = string.Join(", ", yetkiler);
                return $"Mevcut rolünüzle şu konular hakkında bilgi alabilirsiniz: {yetkiListesi}.";
            }

            string orijinal = soru;
            soru = Normalize(soru);


            string[] tesekkurler = { "teşekkür", "teşekkür ederim", "teşekkürler", "çok sağ ol", "sağ ol", "sağol" };
            string[] vedalar = { "iyi günler", "görüşürüz", "hoşça kal", "güle güle" };
            string[] iyiDurum = { "iyi", "harika", "güzel", "süper", "mükemmel" };
            string[] kotuDurum = { "kötü", "berbat", "fena", "yorgun", "mutsuz" };
            string[] selamlar = { "merhaba", "selam", "günaydın", "iyi akşamlar", "hey" };


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


            string soruAnahtar = "";


            if (temizSoru.Contains("havalı söz") || temizSoru.Contains("özlü söz"))
            {

                Random rnd = new Random();
                List<string> sozler = new List<string>
                {
                    "Önündekini görmek için kendi gözlerin yeter, görünmeyeni görmek için başkalarının gözlerini kullanmalısın.",
                    "Tanrıyı güldürmek istiyorsan ona planlarından bahset.",
                    "Maalesef hayat her zaman arzularımızı ve beklentilerimizi karşılamıyor..."
                };

                int index = rnd.Next(sozler.Count);
                return sozler[index];
            }


            if (temizSoru.Contains("şaka yap") || temizSoru.Contains("beni güldür"))
            {
                Random rnd = new Random();


                List<string> sakaListesi = new List<string> {
        "Bilgisayar doktora neden gitmiş?\r\nÇünkü virüs kapmış! 💻😂",
        "Matematik kitabı neden üzgünmüş?\r\nÇünkü çok problemi var",
        "Adminim, size şaka yapacaktım ama sistemin 'Exception' vermesinden korktum!",

    };

                return sakaListesi[rnd.Next(sakaListesi.Count)];
            }


            if (formatBekleniyor)
            {
                if (soru.Contains("excel"))
                {
                    formatBekleniyor = false;
                    BotDosyaHazirla("excel");
                    return "Tamamdır! Admin denetim raporunu Excel olarak masaüstüne hazırladım.";
                }
                else if (soru.Contains("not defteri") || soru.Contains("txt"))
                {
                    formatBekleniyor = false;
                    BotDosyaHazirla("txt");
                    return "Anlaşıldı! Raporu Not Defteri (TXT) formatında masaüstüne çıkardım.";
                }
                else
                {
                    return "Lütfen sadece 'Excel' veya 'Not Defteri' yazarak format seçiniz.";
                }

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


            if (soru.Contains("denetim kayıtlarını kaydet") || soru.Contains("kayıtları dışa aktar"))
            {
                if (aktifRolId == 1)
                {
                    formatBekleniyor = true;
                    return "Tabii ki efendim. Denetim kayıtlarını hangi formatta hazırlamamı istersiniz? (Excel / Not Defteri)";
                }
                else
                {
                    return "Bu işlem için yönetici yetkiniz bulunmuyor.";
                }
            }



            if (orijinal.Contains("kritik") && (orijinal.Contains("liste") || orijinal.Contains("rapor")))
            {
                if (aktifRolId == 1)
                    return KritikStokRaporuTablo();
            }


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


            if (!string.IsNullOrEmpty(soruAnahtar))
            {
                if (!RolYetkileri[aktifRolId].Contains(soruAnahtar))
                    return "Maalesef bu yetki alanınızın dışında.";
            }

            if (orijinal.Contains("yap") && (orijinal.Contains("stok") || orijinal.Contains("miktar")))
            {

                if (aktifRolId == 1 || aktifRolId == 2)
                    return UrunStokGuncelle(orijinal);
                else
                    return "Stok güncelleme yetkiniz bulunmuyor.";
            }


            if (orijinal.Contains("art") || orijinal.Contains("azalt") || orijinal.Contains("ekle"))
            {
                if (aktifRolId == 1)
                {
                    return UrunStokMatematik(orijinal);
                }
            }

            if (orijinal.Contains("fiyat") && orijinal.Contains("yap"))
            {
                if (aktifRolId == 1)
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



            if (orijinal.Contains("rol") && orijinal.Contains("nedir"))
                return KullaniciRolu(orijinal);

            if (orijinal.Contains("aktif") && orijinal.Contains("mi"))
                return KullaniciAktifMi(orijinal);

            if (orijinal.Contains("yanlış") && orijinal.Contains("giriş"))
                return KullaniciYanlisGirisSayisi(orijinal);


            if (orijinal.Contains("bugün") && orijinal.Contains("giriş") && orijinal.Contains("yapan"))
                return BugunGirisYapanKullanicilar();

            if (orijinal.Contains("bugün") && orijinal.Contains("giriş") && orijinal.Contains("yapmayan"))
                return BugunGirisYapmayanKullanicilar();


            if (aktifRolId == 1)
            {
                if (orijinal.Contains("analiz") || orijinal.Contains("sistem durumu"))
                    return SistemGenelAnalizi();

                if (orijinal.Contains("ne yaptı") || orijinal.Contains("hareketleri"))
                    return KullaniciIslemGecmisi(orijinal);
            }


            if (orijinal.Contains("log") || (orijinal.Contains("kim") && orijinal.Contains("yaptı")))
            {

                if (aktifRolId == 1)
                    return SonSistemHareketleri();
                else
                    return "Bu sistem raporlarını sadece Admin görüntüleyebilir.";
            }



            if (orijinal.Contains("raf") || orijinal.Contains("nerede"))
                return UrunKonumuGetir(orijinal);


            if (aktifRolId == 1 && (orijinal.Contains("analiz") || orijinal.Contains("özet")))
                return SistemGenelAnalizi();


            if (orijinal.Contains("geçen hafta") && orijinal.Contains("stok"))
                return GecenHaftaStokHareketleri();


            if (orijinal.Contains("giriş yapamıyorum") || orijinal.Contains("destek"))
                return DestekMesaji();

            if (tesekkurler.Any(x => orijinal.Contains(x)))
                return "Rica ederim! Yardımcı olmaya hazırım.";

            if (vedalar.Any(x => orijinal.Contains(x)))
                return "İyi günler, tekrar beklerim.";


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
                flowChat.Controls.Add(balon);
                flowChat.SetFlowBreak(balon, true);
                flowChat.ScrollControlIntoView(balon);
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


            string? urunAdi = soru.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .FirstOrDefault(x => x != "stok" && x != "var" && x != "mı");

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

                    return stok > 0
                        ? $"{urunAdi} stokta mevcut. Miktar: {stok}"
                        : $"{urunAdi} stokta mevcut değil.";
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

        private string KullaniciDurumGuncelle(string soru)
        {

            int yeniDurum = (soru.Contains("aktif") || soru.Contains("aç")) ? 1 : 0;
            string durumMetni = yeniDurum == 1 ? "aktif" : "pasif";


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

                        LogEkle(49, $"Chatbot: {kullaniciAdi} {durumMetni} yapıldı.");
                        return $"{kullaniciAdi} kullanıcısı başarıyla {durumMetni} duruma getirildi.";
                    }
                }
            }
            return $"'{kullaniciAdi}' isimli kullanıcı bulunamadı.";
        }


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
                cmd.Parameters.AddWithValue("@hareketId", 2);
                cmd.ExecuteNonQuery();
            }
            catch { }
        }

        private string UrunTedarikcisiGetir(string soru)
        {
            string urunAdi = soru.Replace("tedarikçisi", "").Replace("kim", "").Trim();


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
     "SELECT UrunAd, MevcutStok, KritikStok FROM tblUrunler WHERE MevcutStok <= KritikStok", conn);

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


                flowChat.ScrollControlIntoView(lbl);

                await Task.Delay(20);
            }
        }


        private void txtSoru_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoru.Text))
            {
                txtSoru.Text = placeholder;
                txtSoru.ForeColor = Color.Gray;
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

            txtSoru.SelectionAlignment = HorizontalAlignment.Right;
            txtSoru.SelectionColor = Color.Blue;
            txtSoru
                .AppendText("\nSiz: " + soru + "\n");

            EkleMesaj(soru, true);
            txtSoru.Clear();

            string[] kritikKelimeler = { "stok", "ciro", "analiz", "rapor", "fiyat", "log" };
            if (kritikKelimeler.Any(k => soru.ToLower().Contains(k)))
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

        private void btnSesliOkuma_Click(object sender, EventArgs e)
        {

            sesliOkumaAcik = !sesliOkumaAcik;

            if (sesliOkumaAcik)
            {

                btnSesliOkuma.BackgroundImage = Properties.Resources.mic_on;

            }
            else
            {
                btnSesliOkuma.BackgroundImage = Properties.Resources.mic_off;
                synthesizer.SpeakAsyncCancelAll();
            }

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
                e.SuppressKeyPress = true;
                btnGonder.PerformClick();
            }

        }
        private async Task BotCevapVer(string cevap)
        {
            await Task.Run(() => synthesizer.Speak(cevap));
        }

        private void ChatbotForm_Load(object sender, EventArgs e)
        {
            synthesizer.SetOutputToDefaultAudioDevice();
            synthesizer.Rate = 3;
            synthesizer.SelectVoice("Microsoft Tolga");
            synthesizer.Volume = 100;
            txtSoru.Text = placeholder;

            txtSoru.ForeColor = Color.Gray;
        }

        private string UrunStokGuncelle(string soru)
        {

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


            string urunAdi = soru.Replace("stok", "").Replace("yap", "").Replace(yeniMiktar.ToString(), "").Trim();
            urunAdi = TemizleKullaniciAdi(urunAdi);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("UPDATE tblUrunler SET MevcutStok = @miktar WHERE LOWER(UrunAd) LIKE @ad", conn))
                {
                    cmd.Parameters.AddWithValue("@miktar", yeniMiktar);
                    cmd.Parameters.AddWithValue("@ad", "%" + urunAdi.ToLower() + "%");

                    int etkilenen = cmd.ExecuteNonQuery();

                    if (etkilenen > 0)
                    {

                        LogEkle(49, $"Chatbot: {urunAdi} ürünü stoğu {yeniMiktar} olarak güncellendi.");
                        return $"{urunAdi} stoğu başarıyla {yeniMiktar} adet olarak güncellendi.";
                    }
                }
            }
            return "Ürünü bulamadığım için stok güncellemesi yapamadım.";
        }

        private string UrunStokMatematik(string soru)
        {

            decimal degisimMiktari = 0;
            string[] kelimeler = soru.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var kelime in kelimeler)
            {

                string sadeceSayi = new string(kelime.Where(c => char.IsDigit(c) || c == ',' || c == '.').ToArray());
                if (decimal.TryParse(sadeceSayi, out decimal sonuc))
                {
                    degisimMiktari = sonuc;
                    break;
                }
            }

            if (degisimMiktari == 0) return "Miktarı anlayamadım. Örnek: 'Kalemi 10 artır'";


            bool artir = soru.Contains("art") || soru.Contains("ekle") || soru.Contains("ilave");
            string islemMetni = artir ? "artırıldı" : "azaltıldı";


            string temizSoru = soru;
            string[] temizlenecekler = { "stok", "stoğunu", "artır", "arttır", "artir", "arttir", "azalt", "ekle", "ilave", degisimMiktari.ToString() };
            foreach (var kelime in temizlenecekler)
                temizSoru = temizSoru.Replace(kelime, "");

            string urunAdi = TemizleKullaniciAdi(temizSoru.Trim());

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();


                SqlCommand cmdGetir = new SqlCommand("SELECT MevcutStok FROM tblUrunler WHERE LOWER(UrunAd) LIKE @ad", conn);
                cmdGetir.Parameters.AddWithValue("@ad", "%" + urunAdi.ToLower() + "%");
                object mevcut = cmdGetir.ExecuteScalar();

                if (mevcut != null)
                {
                    decimal suAnkiStok = Convert.ToDecimal(mevcut);
                    decimal yeniStok = artir ? (suAnkiStok + degisimMiktari) : (suAnkiStok - degisimMiktari);

                    if (yeniStok < 0) return $"Hata: Stok sıfırın altına düşemez! (Mevcut: {suAnkiStok})";


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


            string temizSoru = soru;
            string[] temizlenecekler = { "fiyat", "fiyatını", "yap", "tl", "₺", "güncelle", yeniFiyat.ToString() };
            foreach (var w in temizlenecekler) temizSoru = temizSoru.Replace(w, "");

            string urunAdi = TemizleKullaniciAdi(temizSoru.Trim());

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

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
                txtSoru.ForeColor = Color.Black;
            }
        }

        private void txtSoru_KeyDown_1(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;


                btnGonder.PerformClick();
            }
        }

        private string SonHareketleriGetir()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

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

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private string SistemGenelAnalizi()
        {
            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();


                string query = @"
            SELECT 
                (SELECT COUNT(*) FROM tblUrunler WHERE MevcutStok <= KritikStok) as KritikAdet,
                (SELECT COUNT(*) FROM tblDenetimKayitlari WHERE Aciklama LIKE '%yanlış%' AND CAST(IslemTarihi AS DATE) = CAST(GETDATE() AS DATE)) as HataliGiris,
                (SELECT ISNULL(SUM(MevcutStok * BirimFiyat), 0) FROM tblUrunler) as DepoDegeri,
                (SELECT COUNT(*) FROM tblUrunler WHERE MevcutStok = 0) as BitenUrun";

                using SqlCommand cmd = new SqlCommand(query, conn);
                using SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    return $"📊 **Admin Sistem Özeti:**\n" +
                           $"• **Kritik Stok:** {dr["KritikAdet"]} ürün limitin altında.\n" +
                           $"• **Stoku Biten:** {dr["BitenUrun"]} ürün tamamen tükenmiş.\n" +
                           $"• **Depo Değeri:** {Convert.ToDecimal(dr["DepoDegeri"]):C2} (Mevcut stokların toplam satış değeri).\n" +
                           $"• **Güvenlik:** Bugün {dr["HataliGiris"]} hatalı giriş denemesi yapıldı.";
                }
            }
            catch (Exception ex)
            {
                return "Analiz hatası: " + ex.Message;
            }
            return "Veri alınamadı.";
        }

        private string UrunKonumuGetir(string soru)
        {

            string urunAdi = soru.Replace("rafı", "").Replace("nerede", "").Replace("konumu", "").Trim();

            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            using SqlCommand cmd = new SqlCommand("SELECT RafNo FROM tblUrunler WHERE LOWER(UrunAd) LIKE @ad", conn);
            cmd.Parameters.AddWithValue("@ad", "%" + urunAdi + "%");

            object res = cmd.ExecuteScalar();
            return res != null && res != DBNull.Value
                ? $"{urunAdi} ürünü **{res}** numaralı rafta bulunuyor."
                : $"{urunAdi} için raf bilgisi girilmemiş.";
        }


        private void BotDosyaHazirla(string tip)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sorgu = @"SELECT d.IslemTarihi, k.KullaniciAdi, d.Aciklama 
                         FROM tblDenetimKayitlari d 
                         JOIN tblKullanicilar k ON d.KullaniciID = k.KullaniciID 
                         ORDER BY d.IslemTarihi DESC";

                SqlDataAdapter da = new SqlDataAdapter(sorgu, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                string masaustuPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (tip == "excel")
                {
                    string dosyaAdi = Path.Combine(masaustuPath, "Admin_Denetim_Raporu.xlsx");
                    using (var wb = new ClosedXML.Excel.XLWorkbook())
                    {
                        var ws = wb.Worksheets.Add("Denetim Kayıtları");
                        ws.Cell(1, 1).InsertTable(dt);
                        ws.Columns().AdjustToContents();
                        wb.SaveAs(dosyaAdi);
                    }
                }
                else if (tip == "txt")
                {
                    string dosyaAdi = Path.Combine(masaustuPath, "Admin_Denetim_Raporu.txt");
                    using (StreamWriter sw = new StreamWriter(dosyaAdi))
                    {
                        sw.WriteLine("--- ADMİN DENETİM KAYITLARI RAPORU ---");
                        sw.WriteLine($"Rapor Tarihi: {DateTime.Now}");
                        sw.WriteLine("---------------------------------------");
                        foreach (DataRow row in dt.Rows)
                        {
                            sw.WriteLine($"{row["IslemTarihi"]} | {row["KullaniciAdi"]} | {row["Aciklama"]}");
                        }
                    }
                }
            }
        }

        private async Task MatrixEfektiYap()
        {
            Random rnd = new Random();
            string[] mesajlar;


            if (aktifRolId == 1)
            {
                mesajlar = new string[] {

            "Sistem çekirdeğine güvenli bağlantı kuruluyor...",
            "Admin yetki anahtarları (RSA-4096) doğrulanıyor...",
            "SQL Server Express üzerinden veri çekiliyor...",
            "Kernel.dll üzerinden bellek optimizasyonu yapıldı.",
            "Sistem logları taranıyor: [OK]",
            "Donanım hızlandırma aktif edildi (GPU-Ready)."
        };
            }
            else
            {
                mesajlar = new string[] {
            "> Departman performans verileri taranıyor...",
            "> Raporlama motoru başlatıldı...",
            "> Kritik stok seviyeleri analiz ediliyor..."
        };
            }
            var secilenMesajlar = mesajlar.OrderBy(x => rnd.Next()).Take(1).ToList();

            foreach (string m in secilenMesajlar)
            {
                EkleMesaj(m, false);

                await Task.Delay(rnd.Next(400, 800));
            }
        }

        private string KullaniciIslemGecmisi(string soru)
        {
            string kullaniciAdi = TemizleKullaniciAdi(soru.Replace("ne", "").Replace("yaptı", "").Replace("hareketleri", "").Trim());

            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            using SqlCommand cmd = new SqlCommand(@"
        SELECT TOP 5 d.Aciklama, d.IslemTarihi 
        FROM tblDenetimKayitlari d
        JOIN tblKullanicilar k ON d.KullaniciID = k.KullaniciID
        WHERE LOWER(k.KullaniciAdi) = @ad
        ORDER BY d.IslemTarihi DESC", conn);

            cmd.Parameters.AddWithValue("@ad", kullaniciAdi.ToLower());
            using SqlDataReader dr = cmd.ExecuteReader();

            string sonuc = $"🔍 **{kullaniciAdi} Son 5 Hareketi:**\n";
            bool bulundu = false;
            while (dr.Read())
            {
                sonuc += $"• {dr["IslemTarihi"]:dd/MM HH:mm}: {dr["Aciklama"]}\n";
                bulundu = true;
            }
            return bulundu ? sonuc : $"{kullaniciAdi} için işlem kaydı bulunamadı.";
        }

        private void txtSoru_Enter_1(object sender, EventArgs e)
        {
            if (txtSoru.Text == "Fuzuli'ye Sor")
            {
                txtSoru.Text = "";
                txtSoru.ForeColor = Color.Black; 
            }
        }

        private void txtSoru_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoru.Text))
            {
                txtSoru.Text = "Fuzuli'ye Sor";
                txtSoru.ForeColor = Color.Gray; 
            }
        }
    }
}
