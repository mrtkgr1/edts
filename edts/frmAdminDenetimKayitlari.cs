using Microsoft.Data.SqlClient; // SQL kütüphanesini ekleyin
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; // ConfigurationManager için ekleyin
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel; // XLSX işlemleri için yeni kütüphane
using System.IO;       // StreamWriter yerine bu gerekli

namespace edts
{
    public partial class frmAdminDenetimKayitlari : Form {
        public frmAdminDenetimKayitlari() {
            InitializeComponent();
        }
        private void KullaniciSecimleriniDoldur() {
            try {
                string baglantiDizesi = System.Configuration.ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
                string sorgu = "SELECT KullaniciID, KullaniciAdi FROM tblKullanicilar ORDER BY KullaniciAdi";

                using (SqlConnection baglanti = new SqlConnection(baglantiDizesi)) {
                    SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DataRow tumuRow = dt.NewRow();
                    tumuRow["KullaniciID"] = 0;
                    tumuRow["KullaniciAdi"] = "Tümü";
                    dt.Rows.InsertAt(tumuRow, 0);

                    cmbKullaniciSecim.DisplayMember = "KullaniciAdi";
                    cmbKullaniciSecim.ValueMember = "KullaniciID";
                    cmbKullaniciSecim.DataSource = dt;
                    cmbKullaniciSecim.SelectedIndex = 0;
                }
            } catch (Exception ex) {
                MessageBox.Show("Kullanıcı listesi yüklenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HareketTipleriniDoldur() {
            var veriListesi = Enum.GetValues(typeof(Sabitler.IslemTuru))
            .Cast<Sabitler.IslemTuru>()
            .Select(x => new {
                HareketAd = x.ToString(),
                HareketID = (int)x
            })
            .ToList();

            veriListesi.Insert(0, new { HareketAd = "Tümü", HareketID = 0 });

            cmbHareketTipi.DataSource = veriListesi;
            cmbHareketTipi.DisplayMember = "HareketAd";
            cmbHareketTipi.ValueMember = "HareketID";
        }


        private void KayitlariGetir() {
            try {
                string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

                DateTime baslangicTarihi = dtpBaslangic.Value.Date;
                DateTime bitisTarihi = dtpBitis.Value.Date.AddDays(1).AddSeconds(-1);

                int? hareketID = null;
                if (cmbHareketTipi.SelectedIndex > 0 && cmbHareketTipi.SelectedValue != null) {
                    if (int.TryParse(cmbHareketTipi.SelectedValue.ToString(), out int id)) {
                        hareketID = id;
                    }
                }

                string sorgu = @"
                SELECT
                    D.LogID,
                    D.IslemTarihi,
                    K.KullaniciAdi,
                    D.HareketID,
                    D.TabloAdi,
                    D.Aciklama
                FROM 
                    tblDenetimKayitlari D
                INNER JOIN 
                    tblKullanicilar K ON D.KullaniciID = K.KullaniciID
                WHERE 
                    D.IslemTarihi >= @pBaslangicTarihi 
                    AND D.IslemTarihi <= @pBitisTarihi";

                if (hareketID.HasValue) {
                    sorgu += " AND D.HareketID = @pHareketID";
                }

                sorgu += " ORDER BY D.IslemTarihi DESC";

                using (SqlConnection baglanti = new SqlConnection(baglantiDizesi)) {
                    using (SqlCommand komut = new SqlCommand(sorgu, baglanti)) {
                        // 2. Parametreleri Ekle
                        komut.Parameters.AddWithValue("@pBaslangicTarihi", baslangicTarihi);
                        komut.Parameters.AddWithValue("@pBitisTarihi", bitisTarihi);

                        if (hareketID.HasValue) {
                            komut.Parameters.AddWithValue("@pHareketID", hareketID.Value);
                        }

                        SqlDataAdapter da = new SqlDataAdapter(komut);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dt.Columns.Add("IslemAdi", typeof(string));

                        foreach (DataRow row in dt.Rows) {
                            if (row["HareketID"] != DBNull.Value) {
                                int id = Convert.ToInt32(row["HareketID"]);
                                row["IslemAdi"] = Sabitler.IslemAl(id);
                            }
                        }

                        dgvDenetimKayitlari.DataSource = dt;

                        dgvDenetimKayitlari.Columns["IslemAdi"].DisplayIndex = 3;
                        dgvDenetimKayitlari.Columns["HareketID"].Visible = false;
                        dgvDenetimKayitlari.Columns["TabloAdi"].Visible = false;

                        if (dgvDenetimKayitlari.Columns.Count > 0) {
                            dgvDenetimKayitlari.Columns["LogID"].Visible = false;
                            dgvDenetimKayitlari.Columns["IslemTarihi"].HeaderText = "İşlem Tarihi";
                            dgvDenetimKayitlari.Columns["KullaniciAdi"].HeaderText = "Kullanıcı Adı";
                            dgvDenetimKayitlari.Columns["TabloAdi"].HeaderText = "Tablo";
                            dgvDenetimKayitlari.Columns["Aciklama"].HeaderText = "Açıklama";

                            dgvDenetimKayitlari.Columns["IslemTarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                            dgvDenetimKayitlari.Columns["IslemTarihi"].Width = 150;

                            dgvDenetimKayitlari.Columns["KullaniciAdi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                            dgvDenetimKayitlari.Columns["KullaniciAdi"].Width = 120;

                            dgvDenetimKayitlari.Columns["IslemAdi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                            dgvDenetimKayitlari.Columns["IslemAdi"].Width = 150;

                            dgvDenetimKayitlari.Columns["Aciklama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                            dgvDenetimKayitlari.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                        }
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show("Kayıtları getirirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnKayitlariGetir_Click(object sender, EventArgs e) {
            KayitlariGetir();
        }

        private void btnExcelAktar_Click(object sender, EventArgs e) {
            if (dgvDenetimKayitlari.Rows.Count == 0 || dgvDenetimKayitlari.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow || r.Visible == false)) {
                MessageBox.Show("Aktarılacak kayıt bulunmamaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Dosyaları (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = "DenetimKayitlari_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                try {
                    DataTable dt = new DataTable();

                    foreach (DataGridViewColumn column in dgvDenetimKayitlari.Columns) {
                        if (column.Visible) {
                            dt.Columns.Add(column.HeaderText);
                        }
                    }

                    foreach (DataGridViewRow row in dgvDenetimKayitlari.Rows) {
                        if (!row.IsNewRow) {
                            DataRow newRow = dt.NewRow();
                            int dtColumnIndex = 0;

                            for (int i = 0; i < dgvDenetimKayitlari.Columns.Count; i++) {
                                if (dgvDenetimKayitlari.Columns[i].Visible) {
                                    newRow[dtColumnIndex] = row.Cells[i].Value;
                                    dtColumnIndex++;
                                }
                            }
                            dt.Rows.Add(newRow);
                        }
                    }

                    using (var wb = new XLWorkbook()) {
                        var ws = wb.Worksheets.Add(dt, "Denetim Kayıtları");

                        ws.Row(1).Style.Font.Bold = true;

                        ws.Columns().AdjustToContents();

                        wb.SaveAs(saveFileDialog.FileName);
                    }

                    MessageBox.Show("Kayıtlar başarıyla XLSX formatında Excel dosyasına aktarıldı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } catch (Exception ex) {
                    MessageBox.Show("Excel'e aktarım sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void frmAdminDenetimKayitlari_Load_1(object sender, EventArgs e) {

            KullaniciSecimleriniDoldur();
            HareketTipleriniDoldur();

            KayitlariGetir();
        }

        private void cmbHareketTipi_SelectedIndexChanged(object sender, EventArgs e) {
            KayitlariGetir();
        }

        private void cmbKullaniciSecim_SelectedIndexChanged(object sender, EventArgs e) {
            KayitlariGetir();
        }

        private void dtpBaslangic_ValueChanged(object sender, EventArgs e) {
            KayitlariGetir();
        }

        private void dtpBitis_ValueChanged(object sender, EventArgs e) {
            KayitlariGetir();
        }
    }
}

