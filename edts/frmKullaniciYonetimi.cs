using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using edts;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Drawing.Printing;
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
                        dgvKullaniciListesi.Columns["RolID"].HeaderText = "Rol";
                        dgvKullaniciListesi.Columns["AktifMi"].HeaderText = "Aktif";

                        if (!dgvKullaniciListesi.Columns.Contains("btnDuzenle")) {
                            DataGridViewButtonColumn dzn = new DataGridViewButtonColumn();
                            dzn.Name = "btnDuzenle";
                            dzn.HeaderText = "D";
                            dzn.Text = "📝";
                            dzn.UseColumnTextForButtonValue = true;
                            dzn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                            dzn.Width = 35;

                            dgvKullaniciListesi.Columns.Add(dzn);

                            DataGridViewButtonColumn sil = new DataGridViewButtonColumn();
                            sil.Name = "btnSil";
                            sil.HeaderText = "S";
                            sil.Text = "🗑";
                            sil.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                            sil.UseColumnTextForButtonValue = true;
                            sil.Width = 35;

                            dgvKullaniciListesi.Columns.Add(sil);
                        }

                        dgvKullaniciListesi.Columns["KullaniciID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dgvKullaniciListesi.Columns["KullaniciID"].Width = 50;

                        dgvKullaniciListesi.Columns["RolID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dgvKullaniciListesi.Columns["RolID"].Width = 60;

                        dgvKullaniciListesi.Columns["AktifMi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dgvKullaniciListesi.Columns["AktifMi"].Width = 50;

                        dgvKullaniciListesi.Columns["AdSoyad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgvKullaniciListesi.Columns["KullaniciAdi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

            // "Silme" yerine "Pasifleştirme" vurgusu yapmak açık kaynakta daha profesyonel durur
            DialogResult result = MessageBox.Show(
                "\"" + kullaniciAdi + "\" adlı kullanıcıyı pasifleştirmek istediğinizden emin misiniz? \n(Kullanıcının geçmiş kayıtları korunacak ancak sisteme giriş yapamayacaktır.)",
                "Kullanıcıyı Pasif Yap",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

                    // DEĞİŞİKLİK BURADA: DELETE yerine UPDATE yapıyoruz
                    string sorgu = "UPDATE tblKullanicilar SET AktifMi = 0 WHERE KullaniciID = @pID";

                    using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
                    {
                        using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                        {
                            komut.Parameters.AddWithValue("@pID", id);

                            baglanti.Open();
                            komut.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Kullanıcı başarıyla pasifleştirildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Log kaydını da "Pasifleştirildi" olarak güncelleyelim
                    VeritabaniYardimcisi.LogKaydet(
                        AktifKullanici.ID,
                        Sabitler.IslemTuru.Kullanici_Silindi, // Enum ismini bozmamak için böyle bıraktım
                        "tblKullanicilar",
                        "\"" + kullaniciAdi + "\" adlı kullanıcı pasif duruma getirildi.");

                    KullanicilariListele();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("İşlem sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

       
        private void resizableButtonyenile_Click(object sender, EventArgs e) {
            if (dgvKullaniciListesi.Rows.Count == 0 || dgvKullaniciListesi.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow || r.Visible == false))
            {
                MessageBox.Show("Aktarılacak kayıt bulunmamaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Dosyaları (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = "KullaniciYonetimi_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable dt = new DataTable();

                    foreach (DataGridViewColumn column in dgvKullaniciListesi.Columns)
                    {
                        if (column.Visible)
                        {
                            dt.Columns.Add(column.HeaderText);
                        }
                    }

                    foreach (DataGridViewRow row in dgvKullaniciListesi.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            DataRow newRow = dt.NewRow();
                            int dtColumnIndex = 0;

                            for (int i = 0; i < dgvKullaniciListesi.Columns.Count; i++)
                            {
                                if (dgvKullaniciListesi.Columns[i].Visible)
                                {
                                    newRow[dtColumnIndex] = row.Cells[i].Value;
                                    dtColumnIndex++;
                                }
                            }
                            dt.Rows.Add(newRow);
                        }
                    }

                    using (var wb = new XLWorkbook())
                    {
                        var ws = wb.Worksheets.Add(dt, "Kullanıcı Yönetimi");
                        ws.Row(1).Style.Font.Bold = true;
                        ws.Columns().AdjustToContents();
                        wb.SaveAs(saveFileDialog.FileName);
                    }

                    MessageBox.Show("Kayıtlar başarıyla XLSX formatında Excel dosyasına aktarıldı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excel'e aktarım sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        
        private void resizableButton4_Click(object sender, EventArgs e) {
            if (dgvKullaniciListesi.Rows.Count == 0)
            {
                MessageBox.Show("Yazdırılacak kayıt bulunmamaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (s, ev) =>
            {
                // Basit tablo çizimi
                int y = 20;
                foreach (DataGridViewRow row in dgvKullaniciListesi.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string line = "";
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            line += cell.Value?.ToString() + "\t";
                        }
                        y += 20;
                    }
                }
            };

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pd;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
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
                e.FormattingApplied = true;
            }
        }
    }
}
