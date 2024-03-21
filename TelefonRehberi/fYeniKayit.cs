using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelefonRehberi
{
    public partial class fYeniKayit : Form
    {
        public fYeniKayit()
        {
            InitializeComponent();
        }

        fBaslangic f = (fBaslangic)Application.OpenForms["fBaslangic"];
        int _id = 0;

        private void Temizle()
        {
            txtDahiliNo.Clear();
            txtAdSoyad.Clear();
            txtUnvan.Clear();
            cmbSubeler.Text="seçiniz...";
            txtAdSoyad.Focus();
            txtCepNo.Clear();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            f.verilerigoster();
            f.ExcelToplamKayit();
            this.Close();
        }

        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            if (txtAdSoyad.Text != "" && txtUnvan.Text != "" && cmbSubeler.Text != "seçiniz..." && txtDahiliNo.Text != "")
            {
                try
                {
                    //bağlantıyı açıyoruz.
                    f.baglanti.Open();
                    OleDbCommand komut = new OleDbCommand("Insert into [" + "Sayfa1" + "$]  (Id,AdSoyad,Unvan,Birim,DahiliNo,CepNo,SilindiMi) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)", f.baglanti);
                    komut.Parameters.AddWithValue("@p1", _id);
                    komut.Parameters.AddWithValue("@p2", txtAdSoyad.Text);
                    komut.Parameters.AddWithValue("@p3", txtUnvan.Text);
                    komut.Parameters.AddWithValue("@p4", cmbSubeler.Text);
                    komut.Parameters.AddWithValue("@p5", txtDahiliNo.Text);
                    komut.Parameters.AddWithValue("@p6", txtCepNo.Text);
                    komut.Parameters.AddWithValue("@p7", "False");
                    komut.ExecuteNonQuery();
                    f.baglanti.Close();
                    MessageBox.Show("Personel ekleme işlemi başarıyla gerçekleşti.", "Personel Ekleme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    Temizle();
                    f.verilerigoster();
                    f.ExcelToplamKayit();
                    _id += 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Lütfen gerekli tüm alanları doldurunuz!", "Personel Ekleme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void fYeniKayit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                dynamic result = MessageBox.Show("Çıkmak istiyor musunuz?", "Personel Ekleme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    e.Cancel = false;
                    f.verilerigoster();
                    f.ExcelToplamKayit();
                }

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void fYeniKayit_Load(object sender, EventArgs e)
        {
            _id = Convert.ToInt32(lblToplamKayit.Text);
        }
    }
}
