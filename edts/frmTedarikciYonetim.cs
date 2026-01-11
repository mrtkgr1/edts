using DocumentFormat.OpenXml.Bibliography;
using edts;
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
    public partial class frmTedarikciYonetim : Form
    {
        static private readonly string baglantiDizesi = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
        public frmTedarikciYonetim()
        {
            InitializeComponent();
        }

        private void frmTedarikciYonetim_Load(object sender, EventArgs e)
        {
            TedarikcileriListele();
        }

        public void TedarikcileriListele()
        {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();

                    string sorgu = "SELECT TedarikciID, TedarikciAd, VergiDairesi, VergiNo, IletisimTel FROM tblTedarikciler";

                    SqlDataAdapter da = new SqlDataAdapter(sorgu, baglan);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView2.DataSource = dt;

                    
                    btnGuncelleSutun.DisplayIndex = dataGridView2.ColumnCount - 1;
                    btnSilSutun.DisplayIndex = dataGridView2.ColumnCount - 1;

                    if (dataGridView2.Columns["TedarikciID"] != null)
                        dataGridView2.Columns["TedarikciID"].Visible = false;

                    dataGridView2.Columns["TedarikciAd"].HeaderText = "Firma Adı";
                    dataGridView2.Columns["VergiDairesi"].HeaderText = "Vergi Dairesi";
                    dataGridView2.Columns["VergiNo"].HeaderText = "Vergi No";
                    dataGridView2.Columns["IletisimTel"].HeaderText = "Telefon";

                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Listeleme Hatası: " + ex.Message);
                }
            }
        }
        private void TedarikciBigiAl(int id, out string ad, out string verigiNo, out string vergiDairesi, out string tel)
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
                    SqlCommand cmd = new SqlCommand("SELECT TedarikciAd, VergiDairesi, VergiNo, IletisimTel FROM tblTedarikciler WHERE TedarikciID = @id", baglan);
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ad = dr["TedarikciAd"].ToString();
                            vergiDairesi = dr["VergiDairesi"].ToString();
                            verigiNo = dr["VergiNo"].ToString();
                            tel = dr["IletisimTel"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tedarikci yüklenirken hata: " + ex.Message);
                }
            }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnTedarikciSill_Click(object sender, EventArgs e)
        {
         
        }
        
        private void btnTedarikciGuncellee_Click(object sender, EventArgs e)
        {
           
        }

        private void btnTedarikciKaydett_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
           
        }

        private void TedarikciSil(string id)
        {
            using (SqlConnection baglan = new SqlConnection(baglantiDizesi))
            {
                try
                {
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblTedarikciler WHERE TedarikciID = @id", baglan);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tedarikçi silindi.");
                }
                catch (SqlException sqlEx) when (sqlEx.Number == 547)
                {
                    MessageBox.Show("Bu tedarikçiye ait alış kayıtları olduğu için silemezsiniz. Pasife almayı deneyin.");
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dataGridView2.Columns[e.ColumnIndex].Name == "btnGuncelleSutun")
            {
                int id = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["TedarikciID"].Value);

                frmTedarikciYonetimGuncellepopup popup = new frmTedarikciYonetimGuncellepopup();
                popup.GuncellenecekUrunID = id;

                if (popup.ShowDialog() == DialogResult.OK)
                {
                    TedarikcileriListele();
                }
            }

            else if (dataGridView2.Columns[e.ColumnIndex].Name == "btnSilSutun")
            {
                string idSil = dataGridView2.Rows[e.RowIndex].Cells["TedarikciID"].Value.ToString();
                string adSil = dataGridView2.Rows[e.RowIndex].Cells["TedarikciAd"].Value?.ToString();

                if (MessageBox.Show($"{adSil} silinsin mi?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    TedarikciSil(idSil);
                    TedarikcileriListele();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frmTedarikciYonetimKaydetpopup yeniForm = new frmTedarikciYonetimKaydetpopup();
            yeniForm.ShowDialog();
            TedarikcileriListele();
        }
    }
}



