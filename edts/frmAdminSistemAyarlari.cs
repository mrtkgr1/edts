
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
using System.Configuration;

namespace edts {
    public partial class frmAdminSistemAyarlari : Form {
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
        static public readonly string kritik_stok_esigi = "kritik_stok_esigi";
        static public readonly string var_birim = "var_birim";
        static public readonly string var_depo_konum = "var_depo_konum";
        static public readonly string sifre_degistirme_suresi = "sifre_degistirme_suresi";
        static public readonly string giris_hata_siniri = "giris_hata_siniri";
        static public readonly string oturum_suresi = "oturum_suresi";

        public frmAdminSistemAyarlari() {
            InitializeComponent();
            degerleriYaz();
        }

        public static void AyarDegistir(string anahtar, string deger) {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    baglan.Open();

                    SqlCommand cmdUpdate = new SqlCommand("UPDATE tblSistemAyarlari SET Deger = @deger WHERE Anahtar = @anahtar", baglan);
                    cmdUpdate.Parameters.AddWithValue("@anahtar", anahtar);
                    cmdUpdate.Parameters.AddWithValue("@deger", deger);

                    int etkilenenSatir = cmdUpdate.ExecuteNonQuery();

                    if (etkilenenSatir == 0) {
                        SqlCommand cmdInsert = new SqlCommand("INSERT INTO tblSistemAyarlari (Anahtar, Deger) VALUES (@anahtar, @deger)", baglan);
                        cmdInsert.Parameters.AddWithValue("@anahtar", anahtar);
                        cmdInsert.Parameters.AddWithValue("@deger", deger);
                        cmdInsert.ExecuteNonQuery();
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Ayar değiştirilemedi: " + ex.Message);
                }
            }
        }
        public static string AyarAlStr(string anahtar) {
            string sonuc = "";

            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("SELECT Deger FROM tblSistemAyarlari WHERE Anahtar = @anahtar", baglan);
                    cmd.Parameters.AddWithValue("@anahtar", anahtar);

                    object dbSonuc = cmd.ExecuteScalar();

                    if (dbSonuc != null && dbSonuc != DBNull.Value) {
                        sonuc = dbSonuc.ToString();
                    }
                } catch {

                }
            }
            return sonuc;
        }
        public static int AyarAlInt(string anahtar) {
            int sonuc = 0;

            using (SqlConnection baglan = new SqlConnection(baglantiDizesi)) {
                try {
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("SELECT Deger FROM tblSistemAyarlari WHERE Anahtar = @anahtar", baglan);
                    cmd.Parameters.AddWithValue("@anahtar", anahtar);

                    object dbSonuc = cmd.ExecuteScalar();

                    if (dbSonuc != null && dbSonuc != DBNull.Value) {
                        int.TryParse(dbSonuc.ToString(), out sonuc);
                    }
                } catch {
                }
            }
            return sonuc;
        }
        private void degerleriYaz() {
            numerickritikStok.Value = AyarAlInt(kritik_stok_esigi);
            comboBox1.Text = AyarAlStr(var_birim);
            textBoxVarDepo.Text = AyarAlStr(var_depo_konum);
            numericSifreDeg.Value = AyarAlInt(sifre_degistirme_suresi);
            numericmaxGir.Value = AyarAlInt(giris_hata_siniri);
            numericOturumSure.Value = AyarAlInt(oturum_suresi);
        }

        private void btnAyarlariKaydet_Click(object sender, EventArgs e) {
            AyarDegistir(kritik_stok_esigi, numerickritikStok.Value.ToString());
            AyarDegistir(var_birim, comboBox1.Text);
            AyarDegistir(var_depo_konum, textBoxVarDepo.Text);
            AyarDegistir(sifre_degistirme_suresi, numericSifreDeg.Value.ToString());
            AyarDegistir(giris_hata_siniri, numericmaxGir.Value.ToString());
            AyarDegistir(oturum_suresi, numericOturumSure.Value.ToString());
        }
    }
}
