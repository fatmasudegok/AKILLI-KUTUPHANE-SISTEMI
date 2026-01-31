namespace AkilliKutuphaneSistemi
{
    partial class YoneticiArayuzu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtKitapAd = new System.Windows.Forms.TextBox();
            this.txtYazar = new System.Windows.Forms.TextBox();
            this.txtStok = new System.Windows.Forms.TextBox();
            this.dgvYoneticiKitaplar = new System.Windows.Forms.DataGridView();
            this.btnKitapEkle = new System.Windows.Forms.Button();
            this.txtKategori = new System.Windows.Forms.TextBox();
            this.btnRaporGetir = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnZamanliRapor = new System.Windows.Forms.Button();
            this.btnListele = new System.Windows.Forms.Button();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.txtSoyad = new System.Windows.Forms.TextBox();
            this.txtEposta = new System.Windows.Forms.TextBox();
            this.txtTelNo = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnKitapListesi = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnguncelle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYoneticiKitaplar)).BeginInit();
            this.SuspendLayout();
            // 
            // txtKitapAd
            // 
            this.txtKitapAd.Location = new System.Drawing.Point(12, 114);
            this.txtKitapAd.Name = "txtKitapAd";
            this.txtKitapAd.Size = new System.Drawing.Size(235, 22);
            this.txtKitapAd.TabIndex = 0;
            this.txtKitapAd.Text = "Kitap Adı...";
            // 
            // txtYazar
            // 
            this.txtYazar.Location = new System.Drawing.Point(12, 151);
            this.txtYazar.Name = "txtYazar";
            this.txtYazar.Size = new System.Drawing.Size(235, 22);
            this.txtYazar.TabIndex = 1;
            this.txtYazar.Text = "Yazar Adı...";
            // 
            // txtStok
            // 
            this.txtStok.Location = new System.Drawing.Point(12, 217);
            this.txtStok.Name = "txtStok";
            this.txtStok.Size = new System.Drawing.Size(235, 22);
            this.txtStok.TabIndex = 2;
            this.txtStok.Text = "Stok Sayısı...";
            // 
            // dgvYoneticiKitaplar
            // 
            this.dgvYoneticiKitaplar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvYoneticiKitaplar.BackgroundColor = System.Drawing.Color.White;
            this.dgvYoneticiKitaplar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvYoneticiKitaplar.Location = new System.Drawing.Point(556, 25);
            this.dgvYoneticiKitaplar.Name = "dgvYoneticiKitaplar";
            this.dgvYoneticiKitaplar.RowHeadersWidth = 51;
            this.dgvYoneticiKitaplar.RowTemplate.Height = 24;
            this.dgvYoneticiKitaplar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvYoneticiKitaplar.Size = new System.Drawing.Size(526, 416);
            this.dgvYoneticiKitaplar.TabIndex = 4;
            this.dgvYoneticiKitaplar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvYoneticiKitaplar_CellContentClick);
            // 
            // btnKitapEkle
            // 
            this.btnKitapEkle.Location = new System.Drawing.Point(286, 140);
            this.btnKitapEkle.Name = "btnKitapEkle";
            this.btnKitapEkle.Size = new System.Drawing.Size(165, 45);
            this.btnKitapEkle.TabIndex = 5;
            this.btnKitapEkle.Text = "Kitap Ekle";
            this.btnKitapEkle.UseVisualStyleBackColor = true;
            this.btnKitapEkle.Click += new System.EventHandler(this.btnKitapEkle_Click);
            // 
            // txtKategori
            // 
            this.txtKategori.Location = new System.Drawing.Point(12, 189);
            this.txtKategori.Name = "txtKategori";
            this.txtKategori.Size = new System.Drawing.Size(235, 22);
            this.txtKategori.TabIndex = 6;
            this.txtKategori.Text = "Kategori...";
            // 
            // btnRaporGetir
            // 
            this.btnRaporGetir.Location = new System.Drawing.Point(40, 427);
            this.btnRaporGetir.Name = "btnRaporGetir";
            this.btnRaporGetir.Size = new System.Drawing.Size(176, 43);
            this.btnRaporGetir.TabIndex = 7;
            this.btnRaporGetir.Text = "En Çok Ödünç Alınan Kitaplar";
            this.btnRaporGetir.UseVisualStyleBackColor = true;
            this.btnRaporGetir.Click += new System.EventHandler(this.btnRaporGetir_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.Location = new System.Drawing.Point(997, 447);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(85, 30);
            this.btnCikis.TabIndex = 8;
            this.btnCikis.Text = "Çıkış Yap";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click_1);
            // 
            // btnZamanliRapor
            // 
            this.btnZamanliRapor.Location = new System.Drawing.Point(275, 427);
            this.btnZamanliRapor.Name = "btnZamanliRapor";
            this.btnZamanliRapor.Size = new System.Drawing.Size(176, 43);
            this.btnZamanliRapor.TabIndex = 9;
            this.btnZamanliRapor.Text = "Zaman Bazlı Raporlar";
            this.btnZamanliRapor.UseVisualStyleBackColor = true;
            this.btnZamanliRapor.Click += new System.EventHandler(this.btnZamanliRapor_Click);
            // 
            // btnListele
            // 
            this.btnListele.Location = new System.Drawing.Point(249, 34);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(202, 45);
            this.btnListele.TabIndex = 12;
            this.btnListele.Text = "Öğrenci ve Personel Listesi";
            this.btnListele.UseVisualStyleBackColor = true;
            this.btnListele.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtAd
            // 
            this.txtAd.Location = new System.Drawing.Point(12, 133);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(100, 22);
            this.txtAd.TabIndex = 13;
            this.txtAd.Text = "Adı...";
            // 
            // txtSoyad
            // 
            this.txtSoyad.Location = new System.Drawing.Point(12, 170);
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Size = new System.Drawing.Size(100, 22);
            this.txtSoyad.TabIndex = 14;
            this.txtSoyad.Text = "Soyadı...";
            // 
            // txtEposta
            // 
            this.txtEposta.Location = new System.Drawing.Point(12, 198);
            this.txtEposta.Name = "txtEposta";
            this.txtEposta.Size = new System.Drawing.Size(100, 22);
            this.txtEposta.TabIndex = 15;
            this.txtEposta.Text = "E-posta...";
            // 
            // txtTelNo
            // 
            this.txtTelNo.Location = new System.Drawing.Point(12, 226);
            this.txtTelNo.Name = "txtTelNo";
            this.txtTelNo.Size = new System.Drawing.Size(100, 22);
            this.txtTelNo.TabIndex = 16;
            this.txtTelNo.Text = "Telefon Numarası...";
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(12, 254);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(100, 22);
            this.txtSifre.TabIndex = 17;
            this.txtSifre.Text = "Şifre...";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Yönetici ",
            "Öğrenci",
            "Personel"});
            this.comboBox1.Location = new System.Drawing.Point(12, 282);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 18;
            // 
            // btnKitapListesi
            // 
            this.btnKitapListesi.Location = new System.Drawing.Point(12, 34);
            this.btnKitapListesi.Name = "btnKitapListesi";
            this.btnKitapListesi.Size = new System.Drawing.Size(204, 45);
            this.btnKitapListesi.TabIndex = 19;
            this.btnKitapListesi.Text = "Kitap Listesi";
            this.btnKitapListesi.UseVisualStyleBackColor = true;
            this.btnKitapListesi.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(286, 169);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(165, 42);
            this.btnEkle.TabIndex = 20;
            this.btnEkle.Text = "Kullanıcı Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(286, 215);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(165, 33);
            this.btnSil.TabIndex = 21;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnguncelle
            // 
            this.btnguncelle.Location = new System.Drawing.Point(286, 254);
            this.btnguncelle.Name = "btnguncelle";
            this.btnguncelle.Size = new System.Drawing.Size(165, 29);
            this.btnguncelle.TabIndex = 22;
            this.btnguncelle.Text = "Güncelle";
            this.btnguncelle.UseVisualStyleBackColor = true;
            this.btnguncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // YoneticiArayuzu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1128, 585);
            this.Controls.Add(this.btnguncelle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.btnKitapListesi);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtTelNo);
            this.Controls.Add(this.txtEposta);
            this.Controls.Add(this.txtSoyad);
            this.Controls.Add(this.txtAd);
            this.Controls.Add(this.btnListele);
            this.Controls.Add(this.btnZamanliRapor);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnRaporGetir);
            this.Controls.Add(this.txtKategori);
            this.Controls.Add(this.btnKitapEkle);
            this.Controls.Add(this.dgvYoneticiKitaplar);
            this.Controls.Add(this.txtStok);
            this.Controls.Add(this.txtYazar);
            this.Controls.Add(this.txtKitapAd);
            this.Name = "YoneticiArayuzu";
            this.Text = "YoneticiArayuzu";
            this.Load += new System.EventHandler(this.YoneticiArayuzu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvYoneticiKitaplar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKitapAd;
        private System.Windows.Forms.TextBox txtYazar;
        private System.Windows.Forms.TextBox txtStok;
        private System.Windows.Forms.DataGridView dgvYoneticiKitaplar;
        private System.Windows.Forms.Button btnKitapEkle;
        private System.Windows.Forms.TextBox txtKategori;
        private System.Windows.Forms.Button btnRaporGetir;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnZamanliRapor;
        private System.Windows.Forms.Button btnListele;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.TextBox txtSoyad;
        private System.Windows.Forms.TextBox txtEposta;
        private System.Windows.Forms.TextBox txtTelNo;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnKitapListesi;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnguncelle;
    }
}