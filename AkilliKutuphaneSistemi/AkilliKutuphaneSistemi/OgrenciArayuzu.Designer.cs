namespace AkilliKutuphaneSistemi
{
    partial class OgrenciArayuzu
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
            this.btnAra = new System.Windows.Forms.Button();
            this.btnOduncTalep = new System.Windows.Forms.Button();
            this.dgvKitaplar = new System.Windows.Forms.DataGridView();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnGecmisim = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKitaplar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(257, 13);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(148, 23);
            this.btnAra.TabIndex = 0;
            this.btnAra.Text = "Kitap Ara";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // btnOduncTalep
            // 
            this.btnOduncTalep.Location = new System.Drawing.Point(321, 390);
            this.btnOduncTalep.Name = "btnOduncTalep";
            this.btnOduncTalep.Size = new System.Drawing.Size(163, 30);
            this.btnOduncTalep.TabIndex = 1;
            this.btnOduncTalep.Text = "Ödünç Talebi Gönder";
            this.btnOduncTalep.UseVisualStyleBackColor = true;
            this.btnOduncTalep.Click += new System.EventHandler(this.btnOduncTalep_Click);
            // 
            // dgvKitaplar
            // 
            this.dgvKitaplar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKitaplar.BackgroundColor = System.Drawing.Color.White;
            this.dgvKitaplar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKitaplar.Location = new System.Drawing.Point(12, 64);
            this.dgvKitaplar.Name = "dgvKitaplar";
            this.dgvKitaplar.RowHeadersWidth = 51;
            this.dgvKitaplar.RowTemplate.Height = 24;
            this.dgvKitaplar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKitaplar.Size = new System.Drawing.Size(776, 309);
            this.dgvKitaplar.TabIndex = 2;
            // 
            // txtArama
            // 
            this.txtArama.Location = new System.Drawing.Point(12, 12);
            this.txtArama.Name = "txtArama";
            this.txtArama.Size = new System.Drawing.Size(212, 22);
            this.txtArama.TabIndex = 3;
            // 
            // btnCikis
            // 
            this.btnCikis.Location = new System.Drawing.Point(703, 390);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(85, 30);
            this.btnCikis.TabIndex = 4;
            this.btnCikis.Text = "Çıkış Yap";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click_1);
            // 
            // btnGecmisim
            // 
            this.btnGecmisim.Location = new System.Drawing.Point(678, 13);
            this.btnGecmisim.Name = "btnGecmisim";
            this.btnGecmisim.Size = new System.Drawing.Size(110, 23);
            this.btnGecmisim.TabIndex = 5;
            this.btnGecmisim.Text = "Geçmişim";
            this.btnGecmisim.UseVisualStyleBackColor = true;
            this.btnGecmisim.Click += new System.EventHandler(this.btnGecmisim_Click);
            // 
            // OgrenciArayuzu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGecmisim);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.txtArama);
            this.Controls.Add(this.dgvKitaplar);
            this.Controls.Add(this.btnOduncTalep);
            this.Controls.Add(this.btnAra);
            this.Name = "OgrenciArayuzu";
            this.Text = "OgrenciArayuzu";
            this.Load += new System.EventHandler(this.OgrenciArayuzu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKitaplar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.Button btnOduncTalep;
        private System.Windows.Forms.DataGridView dgvKitaplar;
        private System.Windows.Forms.TextBox txtArama;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnGecmisim;
    }
}