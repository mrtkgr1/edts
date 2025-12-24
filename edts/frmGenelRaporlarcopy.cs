using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace edts
{
    public partial class frmGenelRaporlarcopy : Form
    {
        public frmGenelRaporlarcopy()
        {
            InitializeComponent();
        }

        private void btnExcelAktar_Click(object sender, EventArgs e)
        {
            // DataGridView boşsa işlem yapma
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Aktarılacak veri bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Excel Uygulamasını Başlat
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = true; // İşlem bittiğinde Excel açılsın
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;
                worksheet.Name = "Genel Rapor";

                // 2. Başlıkları Aktar (Kolon isimleri)
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                    // Başlıkları kalın yapalım
                    Excel.Range baslikHucresi = (Excel.Range)worksheet.Cells[1, i];
                    baslikHucresi.Font.Bold = true;
                    baslikHucresi.Interior.Color = ColorTranslator.ToOle(Color.LightGray); // İstersen arka planı da boyayabilirsin
                }

                // 3. Verileri Aktar
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        // Satır indeksi 2'den başlar (1. satır başlıktı)
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                // 4. Sütunları otomatik genişlet
                worksheet.Columns.AutoFit();

                MessageBox.Show("Veriler başarıyla Excel'e aktarıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
