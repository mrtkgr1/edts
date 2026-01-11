using ClosedXML;
using edts.Properties;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static edts.Sabitler;

namespace edts {
    public partial class frmAdminKullaniciEkle : Form {

        string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
        public frmAdminKullaniciEkle() {
            InitializeComponent();
            RolleriDoldur();
        }

        //işlev
        private Boolean KullaniciEkle() {
            if (string.IsNullOrEmpty(textBoxKullaniciAd.Text) ||
            string.IsNullOrEmpty(textBoxTamAd.Text) ||
            string.IsNullOrEmpty(textBoxsifre.Text) ||
            comboBoxRol.SelectedValue == null) {
                MesajGoruntule(mIcon.Uyari, "Lütfen tüm alanları doldurun");
                return false;

            }

            try {
                string sifreHash = GuvenlikYardimcisi.HashSifre(textBoxsifre.Text);

                string adSoyad = textBoxTamAd.Text;
                string kullaniciAdi = textBoxKullaniciAd.Text;

                int rolID = Convert.ToInt32(comboBoxRol.SelectedValue);
                bool aktifMi = true;

                string sorgu = @"INSERT INTO tblKullanicilar 
                (AdSoyad, KullaniciAdi, SifreHash, RolID, AktifMi) 
                VALUES (@pAdSoyad, @pKullaniciAdi, @pSifreHash, @pRolID, @pAktifMi)";

                using (SqlConnection baglanti = new SqlConnection(baglantiDizesi)) {
                    using (SqlCommand komut = new SqlCommand(sorgu, baglanti)) {
                        komut.Parameters.AddWithValue("@pAdSoyad", adSoyad);
                        komut.Parameters.AddWithValue("@pKullaniciAdi", kullaniciAdi);
                        komut.Parameters.AddWithValue("@pSifreHash", sifreHash);
                        komut.Parameters.AddWithValue("@pRolID", rolID);
                        komut.Parameters.AddWithValue("@pAktifMi", aktifMi ? 1 : 0);

                        baglanti.Open();
                        komut.ExecuteNonQuery();
                    }
                }

                MesajGoruntule(mIcon.Onay, "\"" + textBoxKullaniciAd.Text + "\" adlı kullanıcı " + comboBoxRol.Text +
                " rolü ile başarıyla eklendi.");
                VeritabaniYardimcisi.LogKaydet(AktifKullanici.ID, IslemTuru.Kullanici_Ekle, "tblKullanicilar",
                 "\"" + textBoxKullaniciAd.Text + "\" adlı kullanıcı eklendi.");
                AlanlariTemizle();

            } catch (SqlException sqlEx) {
                switch (sqlEx.Number) {
                    case 2627:
                    case 2601:
                        MesajGoruntule(mIcon.Hata, "Kullanıcı adı mevcut."); 
                        break;
                    case 8152:
                        MesajGoruntule(mIcon.Hata, "Desteklenenden fazla uzun metin girildi.");
                        break;
                    default:
                        MesajGoruntule(mIcon.Hata, "Veri tabanı hatası.");
                        MessageBox.Show(sqlEx.Message);
                        break;
                }
                return false;
            } catch (Exception ex) {
                MesajGoruntule(mIcon.Hata, "Hata.");
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        private enum mIcon {
            Onay, Uyari, Hata, bilgi
        }

        string sonKullanici;
        private void MesajGoruntule(mIcon icon, string msj) {
            if (panel5.Visible == false) panel5.Visible = true;

            switch (icon) {
                case mIcon.Onay:
                    pictureBox1.Image = Resources.renk_onay;
                    break;
                case mIcon.Uyari:
                    pictureBox1.Image = Resources.renk_uyari;
                    break;
                case mIcon.Hata:
                    pictureBox1.Image = Resources.renk_olumsuz;
                    break;
                case mIcon.bilgi:
                default:
                    pictureBox1.Image = Resources.renk_bilgi;
                    break;
            }

            labelBildirim.Text = msj;

            if (icon == mIcon.Onay) {
                sonKullanici = textBoxKullaniciAd.Text;
                resizableButton2.Visible = true;
            } else {
                resizableButton2.Visible = false;
            }
        }

        private void AlanlariTemizle() {
            textBoxKullaniciAd.Clear();
            textBoxTamAd.Clear();
            textBoxsifre.Clear();
            comboBoxRol.SelectedIndex = -1; // Seçimi sıfırla
            // CheckBox'ı sıfırla (veya true yapabilirsiniz)
            textBoxKullaniciAd.Focus();
        }


        //event
        private void RolleriDoldur() {
            var rolListesi = Enum.GetValues(typeof(Rol))
            .Cast<Rol>()
            .Select(r => new {
                RolID = (int)r,
                RolAd = r.ToString()
            })
            .ToList();

            comboBoxRol.DataSource = rolListesi;
            comboBoxRol.DisplayMember = "RolAd";
            comboBoxRol.ValueMember = "RolID";

            comboBoxRol.SelectedIndex = -1;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {

        }

    //EKLE
        private void button1_Click(object sender, EventArgs e) {
            bool ekleBasarili = KullaniciEkle();
            if (!checkBox1.Checked) {
                if(ekleBasarili) this.Close();
            }
        }

        private void resizableButton2_Click(object sender, EventArgs e) {
            KullaniciBilgi tmp = new KullaniciBilgi(sonKullanici);
            tmp.ShowDialog();
        }
    }
}
