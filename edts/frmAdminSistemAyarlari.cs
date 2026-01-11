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

namespace edts
{
    public partial class frmAdminSistemAyarlari : Form
    {
        private System.Windows.Forms.Timer refreshTimer;
        public frmAdminSistemAyarlari()
        {


            InitializeComponent();

           
            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 50; 
            refreshTimer.Tick += RefreshTimer_Tick;
        }
        private void RefreshTimer_Tick(object? sender, EventArgs e)
        {
            refreshTimer.Stop(); 

           
            dgvHareketTipleri.Invalidate();
            dgvHareketTipleri.Update();

          
            this.Invalidate();
            this.Update();
        }
        private void AyarlariYukle()
        {
          
            DataTable dtAyarlar = VeritabaniYardimcisi.SistemAyarlariGetir();

            if (dtAyarlar != null && dtAyarlar.Rows.Count > 0)
            {
                DataRow ayar = dtAyarlar.Rows[0]; 

               
                numKritikStok.Value = Convert.ToInt32(ayar["KritikStokEsigi"]);
                txtVarsayilanDepoKonum.Text = ayar["VarsayilanDepoAd"].ToString();

               
                numSifreDegistirmeSuresi.Value = Convert.ToInt32(ayar["SifreGecerlilikGunu"]);
                numMaksimumGirisDenemesi.Value = Convert.ToInt32(ayar["GirisHataLimiti"]);
                numOturumZamanAsimi.Value = Convert.ToInt32(ayar["OturumZamanAsimiDk"]);

               
            }
        }
        private bool GenelAyarlariKaydet()
        {
           
            if (txtVarsayilanDepoKonum.Text.Trim() == "")
            {
                MessageBox.Show("Varsayılan Depo Konumu boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

           
            int kritikStok = (int)numKritikStok.Value;
            string varsayilanDepo = txtVarsayilanDepoKonum.Text.Trim();

           
            int sifreGecerlilikGunu = (int)numSifreDegistirmeSuresi.Value;
            int girisHataLimiti = (int)numMaksimumGirisDenemesi.Value;
            int oturumZamanAsimiDk = (int)numOturumZamanAsimi.Value;

            return VeritabaniYardimcisi.SistemAyarlariniKaydet(kritikStok, varsayilanDepo,
                                                             sifreGecerlilikGunu, girisHataLimiti, oturumZamanAsimiDk);
        }
        private void HareketTipleriniYukle()
        {
            string sorgu = "SELECT HareketID, HareketAd, CarpimFaktoru FROM tblHareketTipleri";
            DataTable dt = VeritabaniYardimcisi.DataTableGetir(sorgu);

            try
            {
                if (dt != null)
                {
                    dgvHareketTipleri.DataSource = null;
                    dgvHareketTipleri.DataSource = dt;

                    if (dgvHareketTipleri.Columns.Count > 0)
                    {
                        if (dgvHareketTipleri.Columns.Contains("HareketID"))
                            dgvHareketTipleri.Columns["HareketID"].Visible = false;

                        if (dgvHareketTipleri.Columns.Contains("HareketAd"))
                            dgvHareketTipleri.Columns["HareketAd"].HeaderText = "Hareket Adı";

                        dgvHareketTipleri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }

                    refreshTimer.Start();
                }
                else
                {
                    dgvHareketTipleri.DataSource = null; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hareket Tipleri yüklenirken kritik bir hata oluştu. Detay: " + ex.Message, "Veri Yükleme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void SistemAyarlariniYukle()
        {
            DataTable dtAyarlar = VeritabaniYardimcisi.SistemAyarlariGetir();

            if (dtAyarlar != null && dtAyarlar.Rows.Count > 0)
            {
                DataRow ayarSatiri = dtAyarlar.Rows[0];
                decimal tempValue; 

                if (ayarSatiri["kritikstok"] != DBNull.Value)
                {
                    if (decimal.TryParse(ayarSatiri["kritikstok"].ToString(), out tempValue))
                    {
                        numKritikStok.Value = tempValue;
                    }
                }

                txtVarsayilanDepoKonum.Text = ayarSatiri["VarsayilanDepoAd"].ToString();

                if (ayarSatiri["sifregun"] != DBNull.Value)
                {
                    if (decimal.TryParse(ayarSatiri["sifregun"].ToString(), out tempValue))
                    {
                        numSifreDegistirmeSuresi.Value = tempValue;
                    }
                }

                if (ayarSatiri["girishata"] != DBNull.Value)
                {
                    if (decimal.TryParse(ayarSatiri["girishata"].ToString(), out tempValue))
                    {
                        numMaksimumGirisDenemesi.Value = tempValue;
                    }
                }

                if (ayarSatiri["oturumzaman"] != DBNull.Value)
                {
                    if (decimal.TryParse(ayarSatiri["oturumzaman"].ToString(), out tempValue))
                    {
                        numOturumZamanAsimi.Value = tempValue;
                    }
                }
            }
            else
            {
                MessageBox.Show("Sistem Ayarları veritabanından yüklenemedi. Lütfen SQL veritabanında AyarID=1 olan satırın varlığını ve sütun adlarını kontrol edin.", "Kritik Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAdminSistemAyarlari_Load(object sender, EventArgs e)
        {
            cmbVarsayilanBirimTip.Items.Add("Adet");
            cmbVarsayilanBirimTip.Items.Add("Koli");
            cmbVarsayilanBirimTip.Items.Add("Kutu");
            cmbVarsayilanBirimTip.Items.Add("Kilogram (KG)");
            cmbVarsayilanBirimTip.Items.Add("Litre (LT)");

            if (cmbVarsayilanBirimTip.Items.Count > 0)
            {
                cmbVarsayilanBirimTip.SelectedIndex = 0;
            }

            SistemAyarlariniYukle();

            HareketTipleriniYukle();
        }

        private void btnHareketTipiEkle_Click(object sender, EventArgs e)
        {
            string yeniHareketAd = txtHareketTipiAd.Text.Trim();
            if (string.IsNullOrEmpty(yeniHareketAd))
            {
                MessageBox.Show("Lütfen yeni hareket tipinin adını giriniz.", "Uyarı");
                return;
            }

            int carpimFaktoru = 1;

            string sorgu = "INSERT INTO tblHareketTipleri (HareketAd, CarpimFaktoru) VALUES (@pHareketAd, @pCarpimFaktoru)";

            SqlParameter[] parametreler = new SqlParameter[]
            {
        new SqlParameter("@pHareketAd", yeniHareketAd),
        new SqlParameter("@pCarpimFaktoru", carpimFaktoru)
            };

            if (VeritabaniYardimcisi.ExecuteNonQuery(sorgu, parametreler))
            {
                MessageBox.Show("Hareket tipi başarıyla eklendi.", "Başarılı");
                HareketTipleriniYukle();
                txtHareketTipiAd.Clear();
            }
            else
            {
                MessageBox.Show("Ekleme başarısız oldu. Lütfen veritabanı bağlantı dizesini kontrol edin.", "Hata");
            }
        }

        private void btnHareketTipiSil_Click(object sender, EventArgs e)
        {
            if (dgvHareketTipleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz hareketi listeden seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int hareketID = Convert.ToInt32(dgvHareketTipleri.SelectedRows[0].Cells["HareketID"].Value);
            string hareketAd = dgvHareketTipleri.SelectedRows[0].Cells["HareketAd"].Value?.ToString() ?? string.Empty;

            DialogResult onay = MessageBox.Show(
                $"{hareketAd} adlı hareket tipini kalıcı olarak silmek istediğinizden emin misiniz? Bu işlem geri alınamaz.",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (onay == DialogResult.Yes)
            {
                string sorgu = "DELETE FROM tblHareketTipleri WHERE HareketID = @pHareketID";

                SqlParameter[] parametreler = new SqlParameter[]
                {
            new SqlParameter("@pHareketID", hareketID)
                };

                if (VeritabaniYardimcisi.ExecuteNonQuery(sorgu, parametreler))
                {
                    MessageBox.Show("Hareket tipi başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    HareketTipleriniYukle();
                }
                else
                {
                    MessageBox.Show("Hareket tipi silinirken bir hata oluştu veya bu hareket tipi başka kayıtlarda kullanılıyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAyarlariKaydet_Click(object sender, EventArgs e)
        {

            int kritikStok = (int)numKritikStok.Value;

            string varsayilanDepoAd = txtVarsayilanDepoKonum.Text.Trim();

            int sifreGecerlilikGunu = (int)numSifreDegistirmeSuresi.Value;
            int girisHataLimiti = (int)numMaksimumGirisDenemesi.Value;
            int oturumZamanAsimiDk = (int)numOturumZamanAsimi.Value;

            bool sonuc = VeritabaniYardimcisi.SistemAyarlariniKaydet(
                kritikStok,
                varsayilanDepoAd,
                sifreGecerlilikGunu,
                girisHataLimiti,
                oturumZamanAsimiDk
            );

            if (sonuc)
            {
                MessageBox.Show("Sistem ayarları başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SistemAyarlariniYukle(); 
            }
            else
            {
                MessageBox.Show("Ayarlar kaydedilirken bir sorun oluştu. Detaylar için 'VeritabaniYardimcisi.cs' dosyasındaki hata mesajlarını kontrol edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHareketTipleri_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}