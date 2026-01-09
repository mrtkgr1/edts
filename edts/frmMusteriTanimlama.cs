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
    public partial class frmMusteriTanimlama : Form
    {
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
        public frmMusteriTanimlama()
        {
            InitializeComponent();
        }

        public int GuncellenecekMusteriID = 0;

        private void frmMusteriTanimlama_Load(object sender, EventArgs e)
        {
            musteriListele();
        }

        private void musteriListele()
        {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();

                    string sorgu = "SELECT MusteriID, MusteriAd, VergiDairesi, VergiNo, Telefon FROM tblMusteriler";

                    SqlDataAdapter da = new SqlDataAdapter(sorgu, baglan);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView2.DataSource = dt;

                   

                    if (dataGridView2.Columns["MusteriID"] != null)
                        dataGridView2.Columns["MusteriID"].Visible = false;

                    dataGridView2.Columns["MusteriAd"].HeaderText = "Müsteri Adı";
                    dataGridView2.Columns["VergiDairesi"].HeaderText = "Vergi Dairesi";
                    dataGridView2.Columns["VergiNo"].HeaderText = "Vergi No";
                    dataGridView2.Columns["Telefon"].HeaderText = "Telefon";

                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Listeleme Hatası: " + ex.Message);
                }
            }
            dataGridView2.Columns["btnGuncelleSutun"].DisplayIndex = dataGridView2.Columns.Count - 1;
            dataGridView2.Columns["btnSilSutun"].DisplayIndex = dataGridView2.Columns.Count - 1;
        }


      

       

       

       

        private void dataGridView2_MouseLeave(object sender, EventArgs e)
        {
            dataGridView2.Invalidate();
        }

        private void dataGridView2_MouseMove(object sender, MouseEventArgs e)
        {
            var hit = dataGridView2.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.Cell && dataGridView2.Columns[hit.ColumnIndex].Name == "btnSilSutun")
                dataGridView2.InvalidateCell(hit.ColumnIndex, hit.RowIndex);
        }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
         
        }

        private void MusteriSil(string id)
        {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();
                    string sorgu = "DELETE FROM tblMusteriler WHERE MusteriID = @ID";
                    SqlCommand cmd = new SqlCommand(sorgu, baglan);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Müşteri başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) 
                    {
                        MessageBox.Show("Bu müşteriye ait satış kayıtları olduğu için silemezsiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        MessageBox.Show("Silme Hatası: " + ex.Message);
                    }
                }
            }
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex < 0) return;

            if (dataGridView2.Rows[e.RowIndex].IsNewRow) return;

            if (dataGridView2.Columns[e.ColumnIndex].Name == "btnSilSutun")
            {
                var cellValue = dataGridView2.Rows[e.RowIndex].Cells["MusteriID"].Value;
                if (cellValue == null || cellValue == DBNull.Value) return;

                string musteriAd = dataGridView2.Rows[e.RowIndex].Cells["MusteriAd"].Value?.ToString() ?? "Müşteri";
                string musteriId = cellValue.ToString();

                DialogResult onay = MessageBox.Show(
                    $"{musteriAd} isimli müşteriyi silmek istediğinize emin misiniz?",
                    "Müşteri Silme",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (onay == DialogResult.Yes)
                {
                    MusteriSil(musteriId);
                    musteriListele();
                }
            }

            if (dataGridView2.Columns[e.ColumnIndex].Name == "btnGuncelleSutun")
            {
                var cellValue = dataGridView2.Rows[e.RowIndex].Cells["MusteriID"].Value;

                if (cellValue != null && cellValue != DBNull.Value)
                {
                    int id = Convert.ToInt32(cellValue);

                    frmMusteriTanimlamaGuncellepopup popup = new frmMusteriTanimlamaGuncellepopup();
                    popup.GuncellenecekMusteriID = id;

                    if (popup.ShowDialog() == DialogResult.OK)
                    {
                        musteriListele();
                    }
                }
            }
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMusteriTanimlamaKaydetpopup popup = new frmMusteriTanimlamaKaydetpopup();

            if (popup.ShowDialog() == DialogResult.OK)
            {
                musteriListele();
            }
        }
    }
}



