using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AkilliKutuphaneSistemi
{
    public partial class YoneticiArayuzu : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=SUDE;Initial Catalog=KutuphaneOtomasyon;Integrated Security=True");

        public YoneticiArayuzu()
        {
            InitializeComponent();
        }

        private void VerileriGetir()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Kitaplar", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvYoneticiKitaplar.DataSource = dt;
                dgvYoneticiKitaplar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
            finally { baglanti.Close(); }
        }

        private void PanelDuzenle(string mod)
        {
            if (mod == "Kitap")
            {
                txtKitapAd.Visible = txtYazar.Visible = txtKategori.Visible = txtStok.Visible = btnKitapEkle.Visible = true;

                txtAd.Visible = txtSoyad.Visible = txtEposta.Visible = txtTelNo.Visible = txtSifre.Visible = comboBox1.Visible = btnEkle.Visible = false;
            }
            else if (mod == "Kullanici")
            {
                txtKitapAd.Visible = txtYazar.Visible = txtKategori.Visible = txtStok.Visible = btnKitapEkle.Visible = false;

                txtAd.Visible = txtSoyad.Visible = txtEposta.Visible = txtTelNo.Visible = txtSifre.Visible = comboBox1.Visible = btnEkle.Visible = true;
            }
        }

        private void YoneticiArayuzu_Load(object sender, EventArgs e)
        {
            VerileriGetir();
            PanelDuzenle("Kitap"); 
                                  
            PlaceholderAyarla(txtKitapAd, "Kitap Adı...");
            PlaceholderAyarla(txtYazar, "Yazar Adı...");
            PlaceholderAyarla(txtKategori, "Kategori...");
            PlaceholderAyarla(txtStok, "Stok Sayısı...");

            PlaceholderAyarla(txtAd, "Adı...");
            PlaceholderAyarla(txtSoyad, "Soyadı...");
            PlaceholderAyarla(txtEposta, "E-posta...");
            PlaceholderAyarla(txtTelNo, "Telefon Numarası...");
            PlaceholderAyarla(txtSifre, "Şifre...");


            dgvYoneticiKitaplar.ScrollBars = ScrollBars.Both;

         
            dgvYoneticiKitaplar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvYoneticiKitaplar.RowTemplate.Height = 30;
            dgvYoneticiKitaplar.BorderStyle = BorderStyle.None;
            dgvYoneticiKitaplar.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249); 
            dgvYoneticiKitaplar.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvYoneticiKitaplar.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise; 
            dgvYoneticiKitaplar.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgvYoneticiKitaplar.BackgroundColor = Color.White;

            dgvYoneticiKitaplar.EnableHeadersVisualStyles = false;
            dgvYoneticiKitaplar.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvYoneticiKitaplar.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);

            dgvYoneticiKitaplar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvYoneticiKitaplar.ScrollBars = ScrollBars.Both;
        }

        private void btnKitapListesi_Click(object sender, EventArgs e)
        {
            VerileriGetir();
            PanelDuzenle("Kitap");
        }

        private void button3_Click(object sender, EventArgs e) 
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                string sorgu = "SELECT Id, Ad, Soyad, Eposta, Rol, OkulNo, Telefon FROM Kullanicilar";
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvYoneticiKitaplar.DataSource = dt;
                PanelDuzenle("Kullanici");
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
            finally { baglanti.Close(); }
        }

        private void btnKitapEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKitapAd.Text) || txtKitapAd.Text == "Kitap Adı..." ||
                string.IsNullOrWhiteSpace(txtStok.Text) || txtStok.Text == "Stok Sayısı...")
            {
                 MessageBox.Show("Lütfen Kitap Adı ve Stok bilgilerini eksiksiz giriniz!", "Hata");
                return;
            }

            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open(); 

                string sorgu = "INSERT INTO Kitaplar (KitapAd, Yazar, Kategori, Stok) VALUES (@ad, @yazar, @kat, @stok)";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@ad", txtKitapAd.Text);
                komut.Parameters.AddWithValue("@yazar", txtYazar.Text == "Yazar Adı..." ? "" : txtYazar.Text);
                komut.Parameters.AddWithValue("@kat", txtKategori.Text == "Kategori..." ? "" : txtKategori.Text);
                komut.Parameters.AddWithValue("@stok", int.Parse(txtStok.Text));

                komut.ExecuteNonQuery();
                MessageBox.Show("Kitap başarıyla eklendi!");

                VerileriGetir();

                txtKitapAd.Text = "Kitap Adı..."; txtKitapAd.ForeColor = Color.Gray;
                txtYazar.Text = "Yazar Adı..."; txtYazar.ForeColor = Color.Gray;
                txtKategori.Text = "Kategori..."; txtKategori.ForeColor = Color.Gray;
                txtStok.Text = "Stok Sayısı..."; txtStok.ForeColor = Color.Gray;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message );
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            try
            {
                baglanti.Open();
                string sorgu = "INSERT INTO Kullanicilar (Ad, Soyad, Eposta,Telefon, Sifre, Rol) VALUES (@ad, @soyad, @mail,@telefon, @pass, @rol)";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@ad", txtAd.Text);
                komut.Parameters.AddWithValue("@soyad", txtSoyad.Text);
                komut.Parameters.AddWithValue("@mail", txtEposta.Text);
                komut.Parameters.AddWithValue("@telefon", txtTelNo.Text);
                komut.Parameters.AddWithValue("@pass", txtSifre.Text);
                komut.Parameters.AddWithValue("@rol", comboBox1.SelectedItem.ToString());
                komut.ExecuteNonQuery();
                MessageBox.Show("Kullanıcı Eklendi!");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { baglanti.Close(); button3_Click(null, null); }
        }

        private void dgvYoneticiKitaplar_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                try
                {
                    if (baglanti.State == ConnectionState.Open) baglanti.Close();
                    baglanti.Open();

                   
                    string id = dgvYoneticiKitaplar.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                    string sutun = dgvYoneticiKitaplar.Columns[e.ColumnIndex].Name;

                    var hucreDegeri = dgvYoneticiKitaplar.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    string deger = hucreDegeri != null ? hucreDegeri.ToString() : "";

                   
                    string tablo = dgvYoneticiKitaplar.Columns.Contains("KitapAd") ? "Kitaplar" : "Kullanicilar";

                    
                    string sorgu = $"UPDATE {tablo} SET {sutun} = @val WHERE Id = @id";

                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@val", deger);
                    komut.Parameters.AddWithValue("@id", id);

                    komut.ExecuteNonQuery();

                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme sırasında hata oluştu: " + ex.Message);
                }
                finally
                {
                    baglanti.Close();
                }
            }
        }

        private void dgvYoneticiKitaplar_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Sileyim mi?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    baglanti.Open();
                    string id = e.Row.Cells["Id"].Value.ToString();
                    string tablo = dgvYoneticiKitaplar.Columns.Contains("KitapAd") ? "Kitaplar" : "Kullanicilar";
                    string sorgu = $"DELETE FROM {tablo} WHERE Id = @id";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@id", id);
                    komut.ExecuteNonQuery();
                }
                catch (Exception ex) { MessageBox.Show("Silinemedi: " + ex.Message); e.Cancel = true; }
                finally { baglanti.Close(); }
            }
            else e.Cancel = true;
        }

        private void btnRaporGetir_Click(object sender, EventArgs e) 
        {
            try
            {
                baglanti.Open();
                string sorgu = @"SELECT B.KitapAd, COUNT(T.TalepId) AS Sayi FROM OduncTalepleri T 
                                 JOIN Kitaplar B ON T.KitapId = B.Id GROUP BY B.KitapAd ORDER BY Sayi DESC";
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvYoneticiKitaplar.DataSource = dt;
            }
            finally { baglanti.Close(); }
        }

        private void btnZamanliRapor_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                string sorgu = @"
            SELECT 'Günlük (Son 24 Saat)' AS Periyot, COUNT(*) AS [İşlem Sayısı] 
            FROM OduncTalepleri WHERE DATEDIFF(day, TalepTarihi, GETDATE()) = 0
            UNION ALL
            SELECT 'Haftalık (Son 7 Gün)', COUNT(*) 
            FROM OduncTalepleri WHERE DATEDIFF(day, TalepTarihi, GETDATE()) <= 7
            UNION ALL
            SELECT 'Aylık (Son 30 Gün)', COUNT(*) 
            FROM OduncTalepleri WHERE DATEDIFF(day, TalepTarihi, GETDATE()) <= 30";

                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvYoneticiKitaplar.DataSource = dt;

                dgvYoneticiKitaplar.Columns[0].HeaderText = "Zaman Aralığı";
                dgvYoneticiKitaplar.Columns[1].HeaderText = "Toplam Ödünç";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rapor oluşturulurken bir hata oluştu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void btnCikis_Click_1(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Close();
        }
        private void PlaceholderAyarla(TextBox txt, string placeholderMetni)
        {
            txt.Text = placeholderMetni;
            txt.ForeColor = Color.Gray;

            txt.Enter += (s, e) => {
                if (txt.Text == placeholderMetni)
                {
                    txt.Text = "";
                    txt.ForeColor = Color.Black;
                }
            };

            txt.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholderMetni;
                    txt.ForeColor = Color.Gray;
                }
            };
        }

        private void dgvYoneticiKitaplar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvYoneticiKitaplar.CurrentRow == null)
            {
                MessageBox.Show("Lütfen silmek istediğiniz satırı seçiniz!", "Uyarı");
                return;
            }

            DialogResult onay = MessageBox.Show("Seçili kaydı kalıcı olarak silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (onay == DialogResult.Yes)
            {
                try
                {
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                    string id = dgvYoneticiKitaplar.CurrentRow.Cells["Id"].Value.ToString();
                    bool kitapMi = dgvYoneticiKitaplar.Columns.Contains("KitapAd");
                    string tabloAdi = kitapMi ? "Kitaplar" : "Kullanicilar";

                    if (kitapMi)
                    {
                        string talepSilSorgu = "DELETE FROM OduncTalepleri WHERE KitapId = @id";
                        SqlCommand talepKomut = new SqlCommand(talepSilSorgu, baglanti);
                        talepKomut.Parameters.AddWithValue("@id", id);
                        talepKomut.ExecuteNonQuery();
                    }
                    else 
                    {
                        string talepSilSorgu = "DELETE FROM OduncTalepleri WHERE KullaniciId = @id";
                        SqlCommand talepKomut = new SqlCommand(talepSilSorgu, baglanti);
                        talepKomut.Parameters.AddWithValue("@id", id);
                        talepKomut.ExecuteNonQuery();
                    }

                    string anaSorgu = $"DELETE FROM {tabloAdi} WHERE Id = @id";
                    SqlCommand anaKomut = new SqlCommand(anaSorgu, baglanti);
                    anaKomut.Parameters.AddWithValue("@id", id);
                    anaKomut.ExecuteNonQuery();

                    MessageBox.Show("Kayıt ve ilişkili tüm veriler başarıyla silindi.", "Bilgi");

                    VerileriGetir();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Silme işlemi başarısız: " + ex.Message, "Hata");
                }
                finally
                {
                    baglanti.Close();
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvYoneticiKitaplar.CurrentRow == null)
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz satırı seçiniz!", "Uyarı");
                return;
            }

            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                bool kitapMi = dgvYoneticiKitaplar.Columns.Contains("KitapAd");
                string tabloAdi = kitapMi ? "Kitaplar" : "Kullanicilar";
                string id = dgvYoneticiKitaplar.CurrentRow.Cells["Id"].Value.ToString();

                
                foreach (DataGridViewColumn sutun in dgvYoneticiKitaplar.Columns)
                {
                    if (sutun.Name == "Id") continue;

                    string sutunAdi = sutun.Name;
                    var hucreDegeri = dgvYoneticiKitaplar.CurrentRow.Cells[sutunAdi].Value;
                    string yeniDeger = hucreDegeri != null ? hucreDegeri.ToString() : "";

                    string sorgu = $"UPDATE {tabloAdi} SET {sutunAdi} = @val WHERE Id = @id";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@val", yeniDeger);
                    komut.Parameters.AddWithValue("@id", id);
                    komut.ExecuteNonQuery();
                }

                MessageBox.Show($"{tabloAdi} bilgileri başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                VerileriGetir(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında bir hata oluştu: " + ex.Message, "Hata");
            }
            finally
            {
                baglanti.Close();
            }
        }
    }
}