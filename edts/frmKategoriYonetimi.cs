using DocumentFormat.OpenXml.Bibliography;
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
using edts;

namespace edts
{
    public partial class frmKategoriYonetimi : Form
    {
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

        public frmKategoriYonetimi()
        {
            InitializeComponent();
        }

        private void btnKategoriKaydett_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtKategoriAdi.Text))
            {
                MessageBox.Show("Kategori adı boş olamaz!");
                return;
            }

            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();
                    // Sorguyu ve parametreleri kontrol ettim
                    SqlCommand cmdInsert = new SqlCommand("INSERT INTO tblKategoriler (KategoriAd, KategoriAciklama) VALUES (@kat, @aci)", baglan);
                    cmdInsert.Parameters.AddWithValue("@kat", txtKategoriAdi.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@aci", txtKategoriAciklama.Text.Trim());
                    cmdInsert.ExecuteNonQuery();

                    VeritabaniYardimcisi.LogKaydet(AktifKullanici.ID, 6, "tblKategoriler", $"{txtKategoriAdi.Text} adlı kategori eklendi.");

                    MessageBox.Show("Kategori başarıyla eklendi.");
                    txtKategoriAdi.Clear();
                    txtKategoriAciklama.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kategori eklenemedi.\nHata: " + ex.Message);
                }
            }
            KategoriListeGuncelle();
        }

        private void btnKategoriGuncellee_Click(object sender, EventArgs e)
        {

            if (dataGridView2.SelectedRows.Count == 0) return;

            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    int id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["KategoriID"].Value);
                    baglan.Open();
                    // SQL sorgusundaki yazım hataları düzeltildi
                    SqlCommand cmd = new SqlCommand("UPDATE tblKategoriler SET KategoriAd = @ad, KategoriAciklama = @aciklama WHERE KategoriID = @id", baglan);
                    cmd.Parameters.AddWithValue("@ad", txtKategoriAdi.Text); // .Text eklendi
                    cmd.Parameters.AddWithValue("@aciklama", txtKategoriAciklama.Text); // .Text eklendi
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                    VeritabaniYardimcisi.LogKaydet(AktifKullanici.ID, 6, "tblKategoriler", $"{txtKategoriAdi.Text} güncellendi.");
                    MessageBox.Show("Güncelleme başarılı.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme hatası: " + ex.Message);
                }
            }
            KategoriListeGuncelle();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                txtKategoriAdi.Text = row.Cells["KategoriAd"].Value.ToString();
                txtKategoriAciklama.Text = row.Cells["KategoriAciklama"].Value.ToString();
            }
        }

        private void btnKategoriSill_Click(object sender, EventArgs e)
        {

            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz kategorinin solundaki kutuya basarak tüm satırı seçiniz.");
                return;
            }

            // Kullanıcıya onay soralım
            DialogResult onay = MessageBox.Show("Bu kategoriyi silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (onay == DialogResult.Yes)
            {
                using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
                {
                    try
                    {
                        int id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["KategoriID"].Value);
                        string silinenAd = dataGridView2.SelectedRows[0].Cells["KategoriAd"].Value?.ToString() ?? "";

                        baglan.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM tblKategoriler WHERE KategoriID = @id", baglan);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();

                        VeritabaniYardimcisi.LogKaydet(
                            kullaniciID: AktifKullanici.ID,
                            hareketID: 6,
                            tabloAdi: "tblKategoriler",
                            aciklama: $"{silinenAd} adlı kategori silindi."
                        );

                        MessageBox.Show("Kategori başarıyla silindi.");
                        txtKategoriAdi.Clear();
                        txtKategoriAciklama.Clear();
                    }
                    catch (SqlException sqlEx) when (sqlEx.Number == 547)
                    {
                        MessageBox.Show("Bu kategoriye ait ürünler olduğu için silme işlemi yapılamaz.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
                KategoriListeGuncelle();
            }
        }
        private void KategoriListeGuncelle()
        {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();
                    // Sorguya KategoriAciklama eklendi
                    string sorgu = "SELECT KategoriID, KategoriAd, KategoriAciklama FROM tblKategoriler";

                    SqlDataAdapter da = new SqlDataAdapter(sorgu, baglan);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView2.DataSource = dt;

                    // Görsel iyileştirme
                    dataGridView2.Columns["KategoriID"].Visible = false; // ID'yi gizle
                    dataGridView2.Columns["KategoriAd"].HeaderText = "Kategori Adı";
                    dataGridView2.Columns["KategoriAciklama"].HeaderText = "Açıklama";
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri çekilemedi: " + ex.Message);
                }
            }
        }

        private void frmKategoriYonetimi_Load(object sender, EventArgs e)
        {
            // Kategori formunda olduğumuz için doğru metodu çağıralım
            KategoriListeGuncelle();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView2.Columns[e.ColumnIndex].Name == "btnSilSutun")
            {
                string kategoriAd = dataGridView2.Rows[e.RowIndex].Cells["KategoriAd"].Value?.ToString() ?? "Kategori";
                string kategoriId = dataGridView2.Rows[e.RowIndex].Cells["KategoriID"].Value.ToString();

                DialogResult onay = MessageBox.Show(
                    $"{kategoriAd} kategorisini silmek istediğinize emin misiniz?\nNot: Eğer bu kategoriye bağlı ürünler varsa silinemez.",
                    "Kategori Silme",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (onay == DialogResult.Yes)
                {
                    // Senin mevcut silme mantığını buraya bağladık
                    KategoriSil(kategoriId);
                    KategoriListeGuncelle();
                }
            }
        }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (this.DesignMode || e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dataGridView2.Columns[e.ColumnIndex].Name == "btnSilSutun")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);

                // Butonu hücreden biraz küçük ve zarif yapıyoruz
                var btnRect = new Rectangle(e.CellBounds.X + 10, e.CellBounds.Y + 4, e.CellBounds.Width - 20, e.CellBounds.Height - 8);

                Point mousePos = dataGridView2.PointToClient(Cursor.Position);
                bool isHovering = dataGridView2.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Contains(mousePos);

                Color gecerliRenk = isHovering ? Color.FromArgb(235, 110, 110) : Color.FromArgb(255, 148, 148);

                using (Pen p = new Pen(gecerliRenk, 1))
                using (Brush b = new SolidBrush(gecerliRenk))
                {
                    e.Graphics.FillRectangle(b, btnRect);
                    e.Graphics.DrawRectangle(p, btnRect);
                }

                TextRenderer.DrawText(e.Graphics, "Sil", e.CellStyle.Font, btnRect, Color.White,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);

                e.Handled = true;
            }
        }

        // 4. SQL Silme Metodu (Eğer istersen burayı güncelle)
        private void KategoriSil(string id)
        {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblKategoriler WHERE KategoriID = @id", baglan);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                    VeritabaniYardimcisi.LogKaydet(AktifKullanici.ID, 6, "tblKategoriler", $"ID:{id} olan kategori silindi.");
                }
                catch (SqlException sqlEx) when (sqlEx.Number == 547)
                {
                    MessageBox.Show("Bu kategoriye bağlı ürünler olduğu için silemezsiniz. Önce ürünleri başka kategoriye taşıyın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
            }
        }

        private void dataGridView2_MouseMove(object sender, MouseEventArgs e)
        {
            var hit = dataGridView2.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.Cell && dataGridView2.Columns[hit.ColumnIndex].Name == "btnSilSutun")
            {
                dataGridView2.InvalidateCell(hit.ColumnIndex, hit.RowIndex);
            }
        }

        private void dataGridView2_MouseLeave(object sender, EventArgs e)
        {
           dataGridView2.Invalidate();
    }
    }
}


