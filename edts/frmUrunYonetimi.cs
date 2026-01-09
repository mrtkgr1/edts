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

namespace edts
{
    public partial class frmUrunYonetimi : Form
    {
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

        public frmUrunYonetimi()
        {
            InitializeComponent();
            UrunListeGuncelle();
         

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

       

        private void btnKaydet_Click_1(object sender, EventArgs e)
        {
            
        }
        private void btnSill_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz ürünün en solundaki boşluğa tıklayarak satırı seçin.");
                return;
            }

            DialogResult onay = MessageBox.Show("Bu ürünü silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (onay == DialogResult.Yes)
            {
                using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
                {
                    try
                    {
                        int id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["UrunID"].Value);
                        string silinenUrunAdi = dataGridView2.SelectedRows[0].Cells["UrunAd"].Value.ToString();

                        baglan.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM tblUrunler WHERE UrunID = @id", baglan);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();

                        VeritabaniYardimcisi.LogKaydet(AktifKullanici.ID, 5, "tblUrunler", $"{silinenUrunAdi} adlı ürün silindi.");

                        MessageBox.Show("Ürün başarıyla silindi.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ürün silinemedi. Hata: " + ex.Message);
                    }
                }
                UrunListeGuncelle(); 
            }
        }

        private void btnGuncelle_Click_1(object sender, EventArgs e)
        {

           
        }

        private void UrunListeGuncelle()
        {

            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();

                    string sorgu = @"
            SELECT 
                u.UrunID,
                u.UrunKodu,
                u.UrunAd,
                u.BirimFiyat,
                u.AlisFiyat,
                u.BirimTipi,  -- İŞTE BURASI EKSİKTİ!
                u.KritikStok,  -- BURASI EKLENDİ
                u.MevcutStok,  -- BURASI EKLENDİ (Stok miktarını görmek için)
                k.KategoriAd   
            FROM tblUrunler u
            INNER JOIN tblKategoriler k ON u.KategoriID = k.KategoriID";

                    SqlDataAdapter da = new SqlDataAdapter(sorgu, baglan);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView2.DataSource = dt;

                    dataGridView2.Columns["btnGuncelleSutun"].DisplayIndex = dataGridView2.ColumnCount - 1;
                    dataGridView2.Columns["btnSilSutun"].DisplayIndex = dataGridView2.ColumnCount - 1;

                    if (dataGridView2.Columns.Contains("btnGuncelleSutun")) dataGridView2.Columns.Remove("btnGuncelleSutun");
                    if (dataGridView2.Columns.Contains("btnSilSutun")) dataGridView2.Columns.Remove("btnSilSutun");

                    DataGridViewButtonColumn btnGuncelle = new DataGridViewButtonColumn();
                    btnGuncelle.Name = "btnGuncelleSutun";
                    btnGuncelle.HeaderText = "Düzenle";
                    btnGuncelle.Text = "📝";
                    btnGuncelle.UseColumnTextForButtonValue = true;
                    dataGridView2.Columns.Add(btnGuncelle);

                    DataGridViewButtonColumn btnSil = new DataGridViewButtonColumn();
                    btnSil.Name = "btnSilSutun";
                    btnSil.HeaderText = "İşlem";
                    btnSil.Text = "🗑";
                    btnSil.UseColumnTextForButtonValue = true;
                    dataGridView2.Columns.Add(btnSil);

                   
                    dataGridView2.Columns["btnGuncelleSutun"].DisplayIndex = dataGridView2.ColumnCount - 2;
                    dataGridView2.Columns["btnSilSutun"].DisplayIndex = dataGridView2.ColumnCount - 1;


                    if (dataGridView2.Columns["UrunID"] != null) dataGridView2.Columns["UrunID"].Visible = false;

                    dataGridView2.Columns["UrunKodu"].HeaderText = "Ürün Kodu";
                    dataGridView2.Columns["UrunAd"].HeaderText = "Ürün Adı";
                    dataGridView2.Columns["AlisFiyat"].HeaderText = "Alış Fiyatı";
                    dataGridView2.Columns["BirimFiyat"].HeaderText = "Satış Fiyatı";
                    dataGridView2.Columns["KategoriAd"].HeaderText = "Kategori";

                    if (dataGridView2.Columns["BirimTipi"] != null)
                        dataGridView2.Columns["BirimTipi"].HeaderText = "Birim";
                    dataGridView2.Columns["KritikStok"].HeaderText = "Kritik Seviye";
                    dataGridView2.Columns["MevcutStok"].HeaderText = "Stok Adedi";

                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                  
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                       
                        if (!row.IsNewRow && row.Cells["MevcutStok"].Value != null && row.Cells["KritikStok"].Value != null)
                        {
                            int stok = Convert.ToInt32(row.Cells["MevcutStok"].Value);
                            int kritik = Convert.ToInt32(row.Cells["KritikStok"].Value);

                            if (stok <= kritik)
                            {
                               
                                row.Cells["MevcutStok"].Style.BackColor = Color.Salmon;
                                row.Cells["MevcutStok"].Style.ForeColor = Color.Black;

                               
                                row.Cells["MevcutStok"].Style.Font = new Font(dataGridView2.Font, FontStyle.Bold);
                            }
                            else
                            {
                               
                                row.Cells["MevcutStok"].Style.BackColor = Color.White;
                                row.Cells["MevcutStok"].Style.ForeColor = Color.Black;
                                row.Cells["MevcutStok"].Style.Font = new Font(dataGridView2.Font, FontStyle.Regular);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri çekilemedi: " + ex.Message);
                }
            }
        }
    
        private void KategoriListeGuncelle()
        {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();
                    string sorgu = "SELECT KategoriID, KategoriAd FROM tblKategoriler";

                    SqlDataAdapter da = new SqlDataAdapter(sorgu, baglan);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dataGridView2.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri çekilemedi: " + ex.Message);
                }
            }
        }



        private void musteriBilgiAl(int id, out string ad, out string verigiNo, out string vergiDairesi, out string tel)
        {
            ad = string.Empty;
            verigiNo = string.Empty;
            vergiDairesi = string.Empty;
            tel = string.Empty;
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("SELECT MusteriAd, VergiDairesi, VergiNo, Telefon FROM tblMusteriler WHERE MusteriID = @id", baglan);
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ad = dr["MusteriAd"].ToString();
                            vergiDairesi = dr["VergiDairesi"].ToString();
                            verigiNo = dr["VergiNo"].ToString();
                            tel = dr["Telefon"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Müsteri kaydı yüklenirken hata: " + ex.Message);
                }
            }
        }

      
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         
            }
        

        private void frmUrunYonetimi_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

           
        }
          

        private void btnTedarikciKaydett_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
           
        }
        


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView2.Columns[e.ColumnIndex].Name == "btnGuncelleSutun")
            {
                int secilenUrunID = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["UrunID"].Value);
                frmUrunYonetimiGuncellepopup frm = new frmUrunYonetimiGuncellepopup();
                frm.GuncellenecekUrunID = secilenUrunID;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    UrunListeGuncelle();
                }
            }


            if (e.RowIndex >= 0 && dataGridView2.Columns[e.ColumnIndex].Name == "btnSilSutun")
            {
                string urunAd = dataGridView2.Rows[e.RowIndex].Cells["UrunAd"].Value?.ToString() ?? "Ürün";
                string urunId = dataGridView2.Rows[e.RowIndex].Cells["UrunID"].Value.ToString();

                DialogResult onay = MessageBox.Show(
                    $"{urunAd} ürününü silmek üzeresiniz. Onaylıyor musunuz?",
                    "Dikkat",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (onay == DialogResult.Yes)
                {
                    UrunSil(urunId);
                    UrunListeGuncelle();
                }
            }
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.ReadOnly = true;
        }
        private void UrunSil(string id)
        {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblUrunler WHERE UrunID = @id", baglan);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                    VeritabaniYardimcisi.LogKaydet(AktifKullanici.ID, 5, "tblUrunler", $"ID:{id} olan ürün silindi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ürün silinirken bir hata oluştu: " + ex.Message);
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


        private void BoyamaYardimcisi(DataGridViewCellPaintingEventArgs e, Color normalRenk, Color hoverRenk, string metin)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);
            var btnRect = new Rectangle(e.CellBounds.X + 5, e.CellBounds.Y + 4, e.CellBounds.Width - 10, e.CellBounds.Height - 8);

            Point mousePos = dataGridView2.PointToClient(Cursor.Position);
            bool isHovering = dataGridView2.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Contains(mousePos);
            Color gecerliRenk = isHovering ? hoverRenk : normalRenk;

            using (Brush b = new SolidBrush(gecerliRenk))
            {
                e.Graphics.FillRectangle(b, btnRect);
            }
            TextRenderer.DrawText(e.Graphics, metin, e.CellStyle.Font, btnRect, Color.Black, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
            e.Handled = true;
        }

        private void ButonCiz(DataGridViewCellPaintingEventArgs e, string metin, Color normalRenk, Color hoverRenk)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);

            var btnRect = new Rectangle(e.CellBounds.X + 5, e.CellBounds.Y + 4, e.CellBounds.Width - 10, e.CellBounds.Height - 8);

            Point mousePos = dataGridView2.PointToClient(Cursor.Position);
            bool isHovering = dataGridView2.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Contains(mousePos);

            Color gecerliRenk = isHovering ? hoverRenk : normalRenk;

            using (Pen p = new Pen(gecerliRenk, 1))
            using (Brush b = new SolidBrush(gecerliRenk))
            {
                e.Graphics.FillRectangle(b, btnRect);
                e.Graphics.DrawRectangle(p, btnRect);
            }

            TextRenderer.DrawText(e.Graphics, metin, e.CellStyle.Font, btnRect, Color.White,
                TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);

            e.Handled = true;
        }

        private void ButonCizici(DataGridViewCellPaintingEventArgs e, string metin, Color normalRenk, Color hoverRenk)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);
            var btnRect = new Rectangle(e.CellBounds.X + 5, e.CellBounds.Y + 4, e.CellBounds.Width - 10, e.CellBounds.Height - 8);

            Point mousePos = dataGridView2.PointToClient(Cursor.Position);
            bool isHovering = dataGridView2.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Contains(mousePos);
            Color gecerliRenk = isHovering ? hoverRenk : normalRenk;

            using (Pen p = new Pen(gecerliRenk, 1))
            using (Brush b = new SolidBrush(gecerliRenk))
            {
                e.Graphics.FillRectangle(b, btnRect);
                e.Graphics.DrawRectangle(p, btnRect);
            }

            TextRenderer.DrawText(e.Graphics, metin, e.CellStyle.Font, btnRect, Color.White,
                TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);

            e.Handled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            frmUrunTanimlamapopup yeniForm = new frmUrunTanimlamapopup();          
            yeniForm.ShowDialog();
            UrunListeGuncelle();
        }
    }
}


    




