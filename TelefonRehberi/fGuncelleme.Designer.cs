﻿
namespace TelefonRehberi
{
    partial class fGuncelleme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fGuncelleme));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAdSoyad = new System.Windows.Forms.TextBox();
            this.txtUnvan = new System.Windows.Forms.TextBox();
            this.txtDahiliNo = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.txtCepNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSubeler = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ad Soyad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(18, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Unvan ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(18, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Şube";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(18, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Dahili No ";
            // 
            // txtAdSoyad
            // 
            this.txtAdSoyad.Location = new System.Drawing.Point(94, 46);
            this.txtAdSoyad.Name = "txtAdSoyad";
            this.txtAdSoyad.Size = new System.Drawing.Size(253, 20);
            this.txtAdSoyad.TabIndex = 4;
            // 
            // txtUnvan
            // 
            this.txtUnvan.Location = new System.Drawing.Point(94, 76);
            this.txtUnvan.Name = "txtUnvan";
            this.txtUnvan.Size = new System.Drawing.Size(253, 20);
            this.txtUnvan.TabIndex = 5;
            // 
            // txtDahiliNo
            // 
            this.txtDahiliNo.Location = new System.Drawing.Point(94, 137);
            this.txtDahiliNo.Name = "txtDahiliNo";
            this.txtDahiliNo.Size = new System.Drawing.Size(253, 20);
            this.txtDahiliNo.TabIndex = 7;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.ForeColor = System.Drawing.Color.White;
            this.lblId.Location = new System.Drawing.Point(251, 9);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(35, 13);
            this.lblId.TabIndex = 10;
            this.lblId.Text = "label5";
            this.lblId.Visible = false;
            // 
            // btnTemizle
            // 
            this.btnTemizle.BackColor = System.Drawing.Color.Red;
            this.btnTemizle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTemizle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemizle.ForeColor = System.Drawing.Color.White;
            this.btnTemizle.Image = global::TelefonRehberi.Properties.Resources.clear4848;
            this.btnTemizle.Location = new System.Drawing.Point(217, 204);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(130, 36);
            this.btnTemizle.TabIndex = 10;
            this.btnTemizle.Text = "Vazgeç";
            this.btnTemizle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTemizle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTemizle.UseVisualStyleBackColor = false;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.Green;
            this.btnGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncelle.ForeColor = System.Drawing.Color.White;
            this.btnGuncelle.Image = global::TelefonRehberi.Properties.Resources.save24;
            this.btnGuncelle.Location = new System.Drawing.Point(94, 203);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(117, 37);
            this.btnGuncelle.TabIndex = 9;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuncelle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // txtCepNo
            // 
            this.txtCepNo.Location = new System.Drawing.Point(94, 168);
            this.txtCepNo.MaxLength = 15;
            this.txtCepNo.Name = "txtCepNo";
            this.txtCepNo.Size = new System.Drawing.Size(253, 20);
            this.txtCepNo.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(18, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Cep No ";
            // 
            // cmbSubeler
            // 
            this.cmbSubeler.FormattingEnabled = true;
            this.cmbSubeler.Items.AddRange(new object[] {
            "Bilgi Teknolojileri Şube Müdürlüğü",
            "Bölge Müdürlük Makamı",
            "Personel Şube Müdürlüğü",
            "Muhasebe Şube Müdürlüğü",
            "Destek Hizmetleri Şube Müdürlüğü",
            "241. Şube Müdürlüğü",
            "Barajlar ve Hes Şube Müdürlüğü",
            "Havza Yönetimi,İzleme ve Tahsisler Şube Müdürlüğü",
            "Emlak ve Kamulaştırma Şube Müdürlüğü",
            "Arazi Toplulaştırma ve Tarla İçi Geliştirme Şube Müdürlüğü",
            "Strateji Geliştirme Şube Müdürlüğü",
            "Muhasebe Şube Müdürlüğü",
            "İşletme ve Bakım  Şube Müdürlüğü",
            "Makine İmalat ve Donatım Şube Müdürlüğü",
            "Elektromekanik Teçhizat Şube Müdürlüğü",
            "Taşkın Kontrol Şube Müdürlüğü",
            "Kalite Kontrol ve Laboratuvar Şube Müdürlüğü",
            "Sulama Şube Müdürlüğü",
            "Bilgi Koordinasyon",
            "Jeoteknik Hizmetler Şube Müdürlüğü",
            "Yeraltı Suları Şube Müdürlüğü",
            "Hukuk İşleri Müdürlüğü",
            "241. Şube Müdürlüğü",
            "242. Şube Müdürlüğü",
            "243. Şube Müdürlüğü"});
            this.cmbSubeler.Location = new System.Drawing.Point(94, 107);
            this.cmbSubeler.Name = "cmbSubeler";
            this.cmbSubeler.Size = new System.Drawing.Size(253, 21);
            this.cmbSubeler.TabIndex = 27;
            this.cmbSubeler.Text = "seçiniz...";
            // 
            // fGuncelleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(399, 252);
            this.Controls.Add(this.cmbSubeler);
            this.Controls.Add(this.txtCepNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.txtDahiliNo);
            this.Controls.Add(this.txtUnvan);
            this.Controls.Add(this.txtAdSoyad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fGuncelleme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Güncelleme Sayfası";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fGuncelleme_FormClosing);
            this.Load += new System.EventHandler(this.fGuncelleme_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Button btnGuncelle;
        public System.Windows.Forms.TextBox txtAdSoyad;
        public System.Windows.Forms.TextBox txtUnvan;
        public System.Windows.Forms.TextBox txtDahiliNo;
        public System.Windows.Forms.Label lblId;
        public System.Windows.Forms.TextBox txtCepNo;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox cmbSubeler;
    }
}