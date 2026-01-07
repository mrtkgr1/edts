using edts;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static edts.Sabitler;
namespace edts {
    public partial class frmKullaniciYonetimi : Form {
        public frmKullaniciYonetimi() {
            InitializeComponent();
            RolleriDoldur();
            KullanicilariListele();
        }

        private void KullanicilariListele() {
            try {
                string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

                string sorgu = "SELECT KullaniciID, AdSoyad, KullaniciAdi, RolID, AktifMi " +
                    "FROM tblKullanicilar " +
                    "WHERE (@RolID = 0 OR RolID = @RolID) AND (@AktifMi = -1 OR AktifMi = @AktifMi) " +
                    "AND (@ArananKelime = '' OR (AdSoyad LIKE @ArananKelime + '%' OR KullaniciAdi LIKE '%' + @ArananKelime + '%')) " +
                    "ORDER BY ";
                switch (comboBoxSirala.SelectedIndex) {
                    case 0:
                        sorgu += "KullaniciID ASC";
                        break;
                    case 1:
                        sorgu += "KullaniciID DESC";
                        break;
                    case 2:
                        sorgu += "KullaniciAdi ASC";
                        break;
                    case 3:
                        sorgu += "KullaniciAdi DESC";
                        break;
                    case 4:
                        sorgu += "AdSoyad ASC";
                        break;
                    case 5:
                        sorgu += "AdSoyad DESC";
                        break;
                    case 6:
                        sorgu += "RolID ASC";
                        break;
                    default:
                        sorgu += "KullaniciID ASC";
                        break;
                }

                using (SqlConnection baglanti = new SqlConnection(baglantiDizesi)) {
                    using (SqlCommand komut = new SqlCommand(sorgu, baglanti)) {

                        komut.Parameters.AddWithValue("@RolID", comboBoxRol.SelectedIndex);
                        komut.Parameters.AddWithValue("@AktifMi", comboBoxAktif.SelectedIndex == 0 ? -1 : (comboBoxAktif.SelectedIndex == 1 ? 1 : 0));
                        komut.Parameters.AddWithValue("@ArananKelime", textBoxArama.Text);

                        baglanti.Open();


                        SqlDataAdapter da = new SqlDataAdapter(komut);
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        dgvKullaniciListesi.DataSource = dt;

                        dgvKullaniciListesi.Columns["KullaniciID"].HeaderText = "ID";
                        dgvKullaniciListesi.Columns["AdSoyad"].HeaderText = "Adı Soyadı";
                        dgvKullaniciListesi.Columns["KullaniciAdi"].HeaderText = "Kullanıcı Adı";
                        dgvKullaniciListesi.Columns["RolID"].HeaderText = "Rol ID";
                        dgvKullaniciListesi.Columns["AktifMi"].HeaderText = "Aktif";

                        if (!dgvKullaniciListesi.Columns.Contains("btnDuzenle")) {
                            DataGridViewButtonColumn dzn = new DataGridViewButtonColumn();
                            dzn.Name = "btnDuzenle";
                            dzn.HeaderText = "D";
                            dzn.Text = "📝";
                            dzn.UseColumnTextForButtonValue = true;
                            dzn.Width = 35;
                            dgvKullaniciListesi.Columns.Add(dzn);

                            DataGridViewButtonColumn sil = new DataGridViewButtonColumn();
                            sil.Name = "btnSil";
                            sil.HeaderText = "S";
                            sil.Text = "🗑";
                            sil.UseColumnTextForButtonValue = true;
                            sil.Width = 35;
                            dgvKullaniciListesi.Columns.Add(sil);
                        }
                    }

                }
            } catch (Exception ex) {
                MessageBox.Show("Kullanıcılar listelenirken bir hata oluştu: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmKullaniciYonetimi_Load(object sender, EventArgs e) {
            try {
                KullanicilariListele();
            } catch (Exception ex) {
                MessageBox.Show("Form yüklenirken kritik bir hata oluştu: " + ex.Message,
                                "Kullanıcı Yönetimi Yükleme Hatası",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }


        private void resizableButton1_Click(object sender, EventArgs e) {
            frmAdminKullaniciEkle tmp = new frmAdminKullaniciEkle();
            tmp.ShowDialog();
            KullanicilariListele();
        }

        private void RolleriDoldur() {
            var rolListesi = Enum.GetValues(typeof(Rol))
            .Cast<Rol>()
            .Select(r => new {
                RolID = (int)r,
                RolAd = r.ToString()
            })
            .ToList();

            rolListesi.Insert(0, new {
                RolID = 0,
                RolAd = "Tüm Roller"
            });

            comboBoxRol.DataSource = rolListesi;
            comboBoxRol.DisplayMember = "RolAd";
            comboBoxRol.ValueMember = "RolID";

            comboBoxRol.SelectedIndex = 0;
            comboBoxAktif.SelectedIndex = 0;
            comboBoxSirala.SelectedIndex = 0;
        }


        private void dgvKullaniciListesi_CellDouble(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0 &&
            dgvKullaniciListesi.Columns[e.ColumnIndex].Name != "btnDuzenle" &&
            dgvKullaniciListesi.Columns[e.ColumnIndex].Name != "btnSil") {
                int id = Convert.ToInt32(dgvKullaniciListesi.Rows[e.RowIndex].Cells["KullaniciID"].Value);
                KullaniciBilgi tmp = new KullaniciBilgi(id);
                tmp.ShowDialog();
            }
        }

        private void dgvKullaniciListesi_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvKullaniciListesi.Rows[e.RowIndex].Cells["KullaniciID"].Value);

            if (dgvKullaniciListesi.Columns[e.ColumnIndex].Name == "btnDuzenle") {
                KullaniciDuzenle(id);
            } else if (dgvKullaniciListesi.Columns[e.ColumnIndex].Name == "btnSil") {
                HesapSil(
                    dgvKullaniciListesi.Rows[e.RowIndex].Cells["KullaniciAdi"].Value.ToString(),
                    id
                );
            }

        }


        private void KullaniciDuzenle(int id) {
            frmKullaniciDüzenle tmp = new frmKullaniciDüzenle(id);
            tmp.ShowDialog();
            KullanicilariListele();
        }


        private void HesapSil(string? kullaniciAdi, int id) {

             DialogResult result = MessageBox.Show(
             "\"" + kullaniciAdi + "\" adlı kullanıcyı silmek istediğinizden emin misiniz? Bu işlem geri alınamaz.",
             "Silme Onayı",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Question);

             if (result == DialogResult.Yes) {
                 try {
                     string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
                     string sorgu = "DELETE FROM tblKullanicilar WHERE KullaniciID = @pID";

                     using (SqlConnection baglanti = new SqlConnection(baglantiDizesi)) {
                         using (SqlCommand komut = new SqlCommand(sorgu, baglanti)) {
                             komut.Parameters.AddWithValue("@pID", id);

                             baglanti.Open();
                             komut.ExecuteNonQuery();
                         }
                     }

                     MessageBox.Show("Kullanıcı başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     KullanicilariListele();

                 } catch (Exception ex) {
                     MessageBox.Show("Silme işlemi sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
             }
         }




        private void resizableButtonAra_Click(object sender, EventArgs e) {
            KullanicilariListele();
        }

        /**
         comboboxRol - comboboxAktif
         */

        private void comboBoxAktif_SelectedIndexChanged(object sender, EventArgs e) {
            comboxIslev();
        }

        private void comboBoxRol_SelectedIndexChanged(object sender, EventArgs e) {
            comboxIslev();
        }

        private void comboxIslev() {
            if (comboBoxRol.SelectedIndex == 0 && comboBoxAktif.SelectedIndex == 0 && textBoxArama.Text == "") {
                KullanicilariListele();
                resizableButtonFiltreSil.Enabled = false;
                return;
            }

            resizableButtonFiltreSil.Enabled = true;
            KullanicilariListele();

        }

        private void resizableButtonFiltreSil_Click(object sender, EventArgs e) {

            comboBoxAktif.SelectedIndex = 0;
            comboBoxRol.SelectedIndex = 0;
            textBoxArama.Clear();
            resizableButtonAra.KaynakResim = Properties.Resources.yenile_siyah;
            comboxIslev();
        }

        //----Aktar----
        //EXCEL
        private void resizableButtonyenile_Click(object sender, EventArgs e) {
            KullanicilariListele();
        }

        //pdf yazdir
        private void resizableButton4_Click(object sender, EventArgs e) {

        }

        private void textBoxArama_TextChanged(object sender, EventArgs e) {
            if (textBoxArama.Text == "") {
                resizableButtonAra.KaynakResim = Properties.Resources.yenile_siyah;
            } else {
                resizableButtonAra.KaynakResim = Properties.Resources.ara_siyah;
            }

            if (comboBoxRol.SelectedIndex == 0 && comboBoxAktif.SelectedIndex == 0 && textBoxArama.Text == "") {
                resizableButtonFiltreSil.Enabled = false;
                return;
            }

            resizableButtonFiltreSil.Enabled = true;
        }

        private void comboBoxSirala_SelectedIndexChanged(object sender, EventArgs e) {
            KullanicilariListele();
        }

        private void dgvKullaniciListesi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (this.dgvKullaniciListesi.Columns[e.ColumnIndex].Name == "RolID" && e.Value != null) {
                e.Value = ((Rol)(int)e.Value).ToString();
                e.FormattingApplied = true; // İşlemin tamamlandığını belirtir
            }
        }
    }
}
