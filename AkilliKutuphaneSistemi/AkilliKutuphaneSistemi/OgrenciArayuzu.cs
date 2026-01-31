using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace AkilliKutuphaneSistemi
{
    public partial class OgrenciArayuzu : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=SUDE;Initial Catalog=KutuphaneOtomasyon;Integrated Security=True");

        public OgrenciArayuzu()
        {
            InitializeComponent();
        }

        private void KitaplariGetir()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Kitaplar", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvKitaplar.DataSource = dt;

                dgvKitaplar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kitaplar yüklenirken hata oluştu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void OgrenciArayuzu_Load(object sender, EventArgs e)
        {
            KitaplariGetir();

            dgvKitaplar.ScrollBars = ScrollBars.Both;

            dgvKitaplar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvKitaplar.RowTemplate.Height = 30;
            dgvKitaplar.BorderStyle = BorderStyle.None;
            dgvKitaplar.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgvKitaplar.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvKitaplar.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgvKitaplar.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgvKitaplar.BackgroundColor = Color.White;

            dgvKitaplar.EnableHeadersVisualStyles = false;
            dgvKitaplar.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvKitaplar.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgvKitaplar.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvKitaplar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvKitaplar.ScrollBars = ScrollBars.Both;
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtArama.Text))
            {
                KitaplariGetir(); 
                return;
            }

            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                string sorgu = "SELECT * FROM Kitaplar WHERE KitapAd LIKE @arama OR Yazar LIKE @arama OR YayinYili LIKE @arama";

                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                da.SelectCommand.Parameters.AddWithValue("@arama", "%" + txtArama.Text + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvKitaplar.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Aradığınız kriterlere uygun kitap bulunamadı.", "Bilgi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Arama hatası: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void btnOduncTalep_Click(object sender, EventArgs e)
        {
            if (dgvKitaplar.CurrentRow != null)
            {
                int stok = Convert.ToInt32(dgvKitaplar.CurrentRow.Cells["Stok"].Value);
                int kitapId = Convert.ToInt32(dgvKitaplar.CurrentRow.Cells["Id"].Value);

                if (stok <= 0)
                {
                    MessageBox.Show("Bu kitap şu anda ödünç verilemez. Stokta bulunmamaktadır.", "Stok Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        if (baglanti.State == ConnectionState.Open) baglanti.Close();
                        baglanti.Open();

                        string talepSorgu = "INSERT INTO OduncTalepleri (KullaniciId, KitapId, Durum, TalepTarihi) VALUES (@kid, @kitapid, 'Beklemede', GETDATE())";
                        SqlCommand talepKomut = new SqlCommand(talepSorgu, baglanti);
                        talepKomut.Parameters.AddWithValue("@kid", Form1.girisYapanId); 
                        talepKomut.Parameters.AddWithValue("@kitapid", kitapId);
                        talepKomut.ExecuteNonQuery();

                        string stokSorgu = "UPDATE Kitaplar SET Stok = Stok - 1 WHERE Id=@id";
                        SqlCommand stokKomut = new SqlCommand(stokSorgu, baglanti);
                        stokKomut.Parameters.AddWithValue("@id", kitapId);
                        stokKomut.ExecuteNonQuery();

                        MessageBox.Show("Ödünç talebiniz başarıyla gönderildi. Personel onayı bekleniyor. (Durum: Beklemede)", "Talep Oluşturuldu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("İşlem sırasında hata oluştu: " + ex.Message);
                    }
                    finally
                    {
                        baglanti.Close();
                        KitaplariGetir();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen ödünç almak istediğiniz kitabı listeden seçiniz.");
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Form1 giris = new Form1();
            giris.Show();
            this.Hide();
        }

        private void btnOduncTalep_Click_1(object sender, EventArgs e)
        {
        }

        private void btnCikis_Click_1(object sender, EventArgs e)
        {
            Form1 giris = new Form1();
            giris.Show();
            this.Close(); 
        }

        private void btnGecmisim_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                
                string sorgu = @"SELECT B.KitapAd AS [Kitap Adı], T.TalepTarihi AS [İşlem Tarihi], T.Durum AS [Durum]
                         FROM OduncTalepleri T
                         JOIN Kitaplar B ON T.KitapId = B.Id
                         WHERE T.KullaniciId = @ogrenciId
                         ORDER BY T.TalepTarihi DESC";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@ogrenciId", Form1.girisYapanId);

                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvKitaplar.DataSource = dt;

                MessageBox.Show("Ödünç alma geçmişiniz listelendi.", "Bilgi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Geçmiş yüklenirken hata oluştu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void btnKitapDetay_Click(object sender, EventArgs e)
        {
            if (dgvKitaplar.CurrentRow != null)
            {
                try
                {
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                    int kitapId = Convert.ToInt32(dgvKitaplar.CurrentRow.Cells["Id"].Value);

                    string sorgu = "SELECT KitapAd, Ozet, RafBilgisi FROM Kitaplar WHERE Id = @id";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@id", kitapId);

                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvKitaplar.DataSource = dt;

                    dgvKitaplar.Columns["KitapAd"].HeaderText = "Kitap İsmi";
                    dgvKitaplar.Columns["Ozet"].HeaderText = "Kitap Özeti";
                    dgvKitaplar.Columns["RafBilgisi"].HeaderText = "Kütüphane Rafı";

                    MessageBox.Show("Kitap detayları ve konum bilgisi getirildi.", "Bilgi");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Detaylar yüklenirken hata: " + ex.Message);
                }
                finally
                {
                    baglanti.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen detayını görmek istediğiniz kitabı listeden seçiniz!");
            }
        }

        private void dgvKitaplar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKitaplar.Columns[e.ColumnIndex].Name == "Durum" && e.Value != null)
            {
                if (e.Value.ToString() == "Beklemede") e.CellStyle.ForeColor = Color.Orange;
                if (e.Value.ToString() == "Onaylandı") e.CellStyle.ForeColor = Color.Green;
                if (e.Value.ToString() == "Gecikmiş") e.CellStyle.ForeColor = Color.Red;
            }
        }
    }
}