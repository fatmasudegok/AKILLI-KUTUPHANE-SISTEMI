using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace AkilliKutuphaneSistemi
{
    public partial class KayitFormu : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=SUDE;Initial Catalog=KutuphaneOtomasyon;Integrated Security=True");

        public KayitFormu()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtSoyad.Text) ||
                string.IsNullOrWhiteSpace(txtEposta.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sifre = txtSifre.Text;
            if (sifre.Length < 8 || !sifre.Any(char.IsUpper) || !sifre.Any(char.IsLower) || !sifre.Any(char.IsDigit))
            {
                MessageBox.Show("Parola en az 8 karakter olmalı; büyük harf, küçük harf ve sayı içermelidir.", "Zayıf Şifre", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (baglanti.State == ConnectionState.Open) baglanti.Close();

                baglanti.Open();
                string sorgu = "INSERT INTO Kullanicilar (Ad, Soyad, Eposta, Sifre, Rol, OkulNo, Telefon) VALUES (@ad, @soyad, @mail, @pass, @rol, @no, @tel)";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@ad", txtAd.Text);
                komut.Parameters.AddWithValue("@soyad", txtSoyad.Text);
                komut.Parameters.AddWithValue("@mail", txtEposta.Text);
                komut.Parameters.AddWithValue("@pass", txtSifre.Text);
                komut.Parameters.AddWithValue("@no", txtOkulNo.Text);
                komut.Parameters.AddWithValue("@tel", txtTelefon.Text);

                string rol = cmbRol.SelectedItem != null ? cmbRol.SelectedItem.ToString() : "Ogrenci";
                komut.Parameters.AddWithValue("@rol", rol);

                komut.ExecuteNonQuery();

                MessageBox.Show("Kaydınız başarıyla oluşturuldu!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form1 giris = new Form1();
                giris.Show();
                this.Close();
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

        private void KayitFormu_Load(object sender, EventArgs e)
        {
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}