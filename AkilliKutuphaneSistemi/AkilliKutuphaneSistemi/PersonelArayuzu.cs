using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing; 
using System.Windows.Forms;

namespace AkilliKutuphaneSistemi
{
    public partial class PersonelArayuzu : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=SUDE;Initial Catalog=KutuphaneOtomasyon;Integrated Security=True");

        public PersonelArayuzu()
        {
            InitializeComponent();
        }

        private void VerileriGetir()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                string sorgu = @"SELECT T.TalepId, K.Ad + ' ' + K.Soyad AS Ogrenci, B.KitapAd, T.Durum, T.TalepTarihi 
                                FROM OduncTalepleri T
                                JOIN Kullanicilar K ON T.KullaniciId = K.Id
                                JOIN Kitaplar B ON T.KitapId = B.Id
                                ORDER BY T.TalepTarihi DESC";

                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvTalepler.DataSource = dt;

               
                string istatistikSorgu = @"
                    SELECT 
                        COUNT(CASE WHEN Durum = 'Teslim Edildi' AND DATEDIFF(day, TalepTarihi, GETDATE()) = 0 THEN 1 END) as BugunVerilen,
                        COUNT(CASE WHEN Durum = 'İade Edildi' AND DATEDIFF(day, TalepTarihi, GETDATE()) = 0 THEN 1 END) as BugunIade,
                        COUNT(CASE WHEN Durum = 'Teslim Edildi' AND DATEDIFF(day, TalepTarihi, GETDATE()) > 15 THEN 1 END) as Gecikenler
                    FROM OduncTalepleri";

                SqlCommand istatistikKomut = new SqlCommand(istatistikSorgu, baglanti);
                SqlDataReader dr = istatistikKomut.ExecuteReader();

                if (dr.Read())
                {
                    label1.Text = $"Özet: Bugün Verilen: {dr["BugunVerilen"]} | Bugün İade: {dr["BugunIade"]} | Toplam Geciken: {dr["Gecikenler"]}";
                    label1.ForeColor = Color.DarkBlue;
                }
                dr.Close();

                GecikenleriIsaretle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı Hatası: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void GecikenleriIsaretle()
        {
            foreach (DataGridViewRow row in dgvTalepler.Rows)
            {
                if (row.Cells["Durum"].Value != null && row.Cells["TalepTarihi"].Value != null)
                {
                    string durum = row.Cells["Durum"].Value.ToString();
                    DateTime talepTarihi = Convert.ToDateTime(row.Cells["TalepTarihi"].Value);
                    TimeSpan fark = DateTime.Now - talepTarihi;

                    if (durum == "Teslim Edildi" && fark.TotalDays > 15)
                    {
                        row.DefaultCellStyle.BackColor = Color.MistyRose;
                        row.DefaultCellStyle.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void PersonelArayuzu_Load(object sender, EventArgs e)
        {
            VerileriGetir();

            cmbDurum.Items.Clear();
            cmbDurum.Items.Add("Beklemede");
            cmbDurum.Items.Add("Onaylandı");
            cmbDurum.Items.Add("Teslim Edildi");
            cmbDurum.Items.Add("İade Edildi");

            dgvTalepler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dgvTalepler.ScrollBars = ScrollBars.Both;

         
            dgvTalepler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvTalepler.RowTemplate.Height = 30;

            dgvTalepler.BorderStyle = BorderStyle.None;
            dgvTalepler.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249); 
            dgvTalepler.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTalepler.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise; 
            dgvTalepler.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgvTalepler.BackgroundColor = Color.White;

            dgvTalepler.EnableHeadersVisualStyles = false;
            dgvTalepler.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTalepler.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72); 
            dgvTalepler.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvTalepler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvTalepler.ScrollBars = ScrollBars.Both; 
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvTalepler.CurrentRow != null && cmbDurum.SelectedItem != null)
            {
                try
                {
                    if (baglanti.State == ConnectionState.Open) baglanti.Close();
                    baglanti.Open();

                    string talepId = dgvTalepler.CurrentRow.Cells["TalepId"].Value.ToString();
                    string yeniDurum = cmbDurum.SelectedItem.ToString();

                    string sorgu = "UPDATE OduncTalepleri SET Durum=@durum WHERE TalepId=@id";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@durum", yeniDurum);
                    komut.Parameters.AddWithValue("@id", talepId);

                    komut.ExecuteNonQuery();

                    MessageBox.Show($"Talep durumu '{yeniDurum}' olarak güncellendi.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    VerileriGetir(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme hatası: " + ex.Message);
                }
                finally
                {
                    baglanti.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir satır ve yeni durum seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Form1 giris = new Form1();
            giris.Show();
            this.Close();
        }
        private void dgvTalepler_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTalepler.Columns[e.ColumnIndex].Name == "Durum" && e.Value != null)
            {
                if (e.Value.ToString() == "Beklemede") e.CellStyle.ForeColor = Color.Orange;
                if (e.Value.ToString() == "Onaylandı") e.CellStyle.ForeColor = Color.Green;
                if (e.Value.ToString() == "Gecikmiş") e.CellStyle.ForeColor = Color.Red;
            }
        }
    }
}