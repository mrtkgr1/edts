using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using ClosedXML.Excel;

namespace EnvanterDepoSistemitaslak2
{
    public partial class frmStokListele : Form
    {
        public frmStokListele()
        {
            InitializeComponent();
        }
        private void VerileriDoldur()
        {

            string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;


            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    string kategoriSorgu = "SELECT KategoriID, KategoriAd FROM tblKategoriler ORDER BY KategoriAd";
                    DataTable dtKategori = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(kategoriSorgu, baglanti))
                    {
                        da.Fill(dtKategori);
                    }


                    DataRow tumuRow = dtKategori.NewRow();
                    tumuRow["KategoriID"] = 0;
                    tumuRow["KategoriAd"] = "Tümü";
                    dtKategori.Rows.InsertAt(tumuRow, 0);


                    cmbKategoriFiltresi.DataSource = dtKategori;
                    cmbKategoriFiltresi.DisplayMember = "KategoriAd";
                    cmbKategoriFiltresi.ValueMember = "KategoriID";
                    cmbKategoriFiltresi.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kategori verileri yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            if (cmbDurumFiltresi.Items.Count == 0)
            {
                cmbDurumFiltresi.Items.Add("Tümü");
                cmbDurumFiltresi.Items.Add("Normal");
                cmbDurumFiltresi.Items.Add("Kritik Seviye");
            }
            cmbDurumFiltresi.SelectedIndex = 0;
        }
        private void StoklariListele(string aramaMetni = "", int kategoriID = 0, string durumFiltresi = "")
        {
            string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

            string sorgu = @"
        SELECT
            U.UrunID,
            U.UrunAd,
            U.MevcutStok,
            C.KategoriAd,
            B.BirimAd,
            U.KritikStok,
            CASE 
                WHEN U.MevcutStok <= U.KritikStok THEN 'Kritik Seviye'
                ELSE 'Normal'
            END AS StokDurumu
        FROM 
            tblUrunler U
        INNER JOIN 
            tblKategoriler C ON U.KategoriID = C.KategoriID
        LEFT JOIN  -- *** DEĞİŞİKLİK BURADA ***
            tblBirimler B ON U.BirimID = B.BirimID
        WHERE 1=1 ";

            using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
            {
                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {


                    if (!string.IsNullOrEmpty(aramaMetni))
                    {
                        komut.CommandText += " AND U.UrunAd LIKE @AramaMetni ";
                        komut.Parameters.AddWithValue("@AramaMetni", "%" + aramaMetni + "%");
                    }


                    if (kategoriID > 0)
                    {
                        komut.CommandText += " AND U.KategoriID = @KategoriID ";
                        komut.Parameters.AddWithValue("@KategoriID", kategoriID);
                    }

                    if (!string.IsNullOrEmpty(durumFiltresi) && durumFiltresi != "Tümü")
                    {

                        if (durumFiltresi == "Kritik Seviye")
                        {
                            komut.CommandText += " AND U.MevcutStok <= U.KritikStok ";
                        }
                        else if (durumFiltresi == "Normal")
                        {
                            komut.CommandText += " AND U.MevcutStok > U.KritikStok ";
                        }
                    }

                    komut.CommandText += " ORDER BY U.UrunAd";

                    try
                    {
                        SqlDataAdapter da = new SqlDataAdapter(komut);
                        DataTable dt = new DataTable();
                        da.Fill(dt);


                        dgvStoklar.DataSource = dt;

                        dgvStoklar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        dgvStoklar.AllowUserToAddRows = false;

                        dgvStoklar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                        dgvStoklar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                        dgvStoklar.DefaultCellStyle.Font = new Font("Segoe UI", 9);

                        dgvStoklar.RowHeadersVisible = false;
                        dgvStoklar.Refresh();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Stok listesi yüklenirken veritabanı hatası oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (dgvStoklar.Columns.Count > 0)
                {
                    dgvStoklar.Columns["UrunID"].Visible = false;
                    dgvStoklar.Columns["UrunAd"].HeaderText = "Ürün Adı";
                    dgvStoklar.Columns["MevcutStok"].HeaderText = "Stok Miktarı";
                    dgvStoklar.Columns["KategoriAd"].HeaderText = "Kategori";
                    dgvStoklar.Columns["BirimAd"].HeaderText = "Birim";
                    dgvStoklar.Columns["KritikStok"].HeaderText = "Kritik Sınır";
                    dgvStoklar.Columns["StokDurumu"].HeaderText = "Durum";


                    dgvStoklar.Columns["MevcutStok"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        private void frmStokListele_Load(object sender, EventArgs e)
        {

            VerileriDoldur();


            if (cmbKategoriFiltresi.Items.Count > 0)
            {
                cmbKategoriFiltresi.SelectedIndex = 0;
            }
            if (cmbDurumFiltresi.Items.Count > 0)
            {
                cmbDurumFiltresi.SelectedIndex = 0;
            }


            txtArama.Text = string.Empty;


            StoklariListele();
            dgvStoklar.AllowUserToAddRows = false;
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {

            string aramaMetni = txtArama.Text.Trim();


            int kategoriID = 0;
            if (cmbKategoriFiltresi.SelectedValue != null &&
                cmbKategoriFiltresi.SelectedValue != DBNull.Value)
            {

                kategoriID = Convert.ToInt32(cmbKategoriFiltresi.SelectedValue);
            }



            string durumFiltresi = cmbDurumFiltresi.Text;


            StoklariListele(aramaMetni, kategoriID, durumFiltresi);
        }

        private void dgvStoklar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dgvStoklar.Columns[e.ColumnIndex].Name == "StokDurumu" && e.Value != null)
            {
                if (e.Value.ToString() == "Kritik Seviye")
                {

                    dgvStoklar.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
                    dgvStoklar.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {

                    dgvStoklar.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    dgvStoklar.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void ExcelAktarClosedXML(DataGridView dgv)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Stok Listesi");

                // 1. Başlıkları Aktar ve Formatla
                int gecerliSutun = 1;
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (dgv.Columns[i].Visible) // Sadece görünür sütunları aktar
                    {
                        var cell = worksheet.Cell(1, gecerliSutun);
                        cell.Value = dgv.Columns[i].HeaderText;
                        cell.Style.Font.Bold = true;
                        cell.Style.Fill.BackgroundColor = XLColor.LightGray;
                        cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        gecerliSutun++;
                    }
                }

                // 2. Verileri Aktar
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    gecerliSutun = 1;
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv.Columns[j].Visible)
                        {
                            worksheet.Cell(i + 2, gecerliSutun).Value = dgv.Rows[i].Cells[j].Value?.ToString();
                            worksheet.Cell(i + 2, gecerliSutun).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            gecerliSutun++;
                        }
                    }
                }

                // 3. Sütun Genişliklerini Ayarla
                worksheet.Columns().AdjustToContents();

                // 4. Kaydetme Penceresi
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.FileName = "Stok_Raporu_" + DateTime.Now.ToString("dd_MM_yyyy");

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(sfd.FileName);
                    MessageBox.Show("Rapor başarıyla oluşturuldu!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void txtArama_TextChanged(object sender, EventArgs e)
        {

            btnYenile_Click(sender, e);
        }

        private void btnExcelAktar_Click(object sender, EventArgs e)
        {
            if (dgvStoklar.Rows.Count > 0)
            {
                
                ExcelAktarClosedXML(dgvStoklar);
            }
            else
            {
                MessageBox.Show("Aktarılacak veri bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

}
