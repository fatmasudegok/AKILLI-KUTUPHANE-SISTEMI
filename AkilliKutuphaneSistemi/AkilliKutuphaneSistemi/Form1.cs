using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AkilliKutuphaneSistemi
{
    public partial class Form1 : Form
    {
        public static int girisYapanId;

        SqlConnection baglanti = new SqlConnection(@"Data Source=SUDE;Initial Catalog=KutuphaneOtomasyon;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string eposta = txtEposta.Text.Trim();
            string sifre = txtSifre.Text.Trim();

            if (string.IsNullOrWhiteSpace(eposta) || string.IsNullOrWhiteSpace(sifre))
            {
                MessageBox.Show("Lütfen e-posta ve şifre alanlarını doldurunuz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
                baglanti.Open();

                string sorgu = "SELECT Id, Rol FROM Kullanicilar WHERE Eposta=@mail AND Sifre=@pass";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@mail", eposta);
                komut.Parameters.AddWithValue("@pass", sifre);

                SqlDataReader oku = komut.ExecuteReader();

                if (oku.Read())
                {
                    girisYapanId = Convert.ToInt32(oku["Id"]);
                    string rol = oku["Rol"].ToString().Trim().ToLower();

                    if (rol.Contains("yönetici") || rol.Contains("admin"))
                    {
                        YoneticiArayuzu f = new YoneticiArayuzu();
                        f.Show();
                        this.Hide();
                    }
                    else if (rol.Contains("öğrenci") || rol.Contains("ogrenci"))
                    {
                        OgrenciArayuzu f = new OgrenciArayuzu();
                        f.Show();
                        this.Hide();
                    }
                   
                    else if (rol.Contains("personel"))
                    {
                        PersonelArayuzu f = new PersonelArayuzu();
                        f.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Tanımsız Rol: " + rol + "\nLütfen veritabanını kontrol edin.", "Yetki Hatası");
                    }
                }
                else
                {
                    MessageBox.Show("Hatalı e-posta veya şifre!", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı Hatası: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }
        

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            KayitFormu kayit = new KayitFormu();
            kayit.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
        }
    }
}