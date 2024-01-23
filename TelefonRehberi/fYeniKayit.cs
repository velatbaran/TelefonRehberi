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
        fBaslangic f = new fBaslangic();
        private void btnKapat_Click(object sender, EventArgs e)
        {
            DialogResult Cikis;
            Cikis = MessageBox.Show("Ekran Kapatılacak Emin siniz?", "Kapatma Uyarısı!", MessageBoxButtons.YesNo);
            if (Cikis == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtDahiliNo.Clear();
            txtAdSoyad.Clear();
            txtUnvan.Clear();
            txtBirim.Clear();
            txtAdSoyad.Focus();
        }

        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            if (txtAdSoyad.Text != "" && txtUnvan.Text != "" && txtBirim.Text != "" && txtDahiliNo.Text != "")
            {
                try
                {

                    //bağlantıyı açıyoruz.
                    f.baglanti.Open();

                    OleDbCommand komut = new OleDbCommand("Insert into [" + "Sayfa1" + "$]  (Id,AdSoyad,Unvan,Birim,DahiliNo,CepNo,SilindiMi) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)", f.baglanti);

                    int Id = Convert.ToInt32(lblToplamKayitSayisi.Text) + 1;

                    komut.Parameters.AddWithValue("@p1", Id);
                    komut.Parameters.AddWithValue("@p2", txtAdSoyad.Text);
                    komut.Parameters.AddWithValue("@p3", txtUnvan.Text);
                    komut.Parameters.AddWithValue("@p4", txtBirim.Text);
                    komut.Parameters.AddWithValue("@p5", txtDahiliNo.Text);
                    komut.Parameters.AddWithValue("@p6", txtCepNo.Text);
                    komut.Parameters.AddWithValue("@p7", "False");
                    komut.ExecuteNonQuery();
                    f.baglanti.Close();
                    MessageBox.Show("Personel ekleme işlemi başarıyla gerçekleşti.", "Yeni Personel Ekleme İşlemi");
                    f.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Lütfen gerekli tüm alanları doldurunuz!", "Yeni Personel Ekleme İşlemi");
            }
        }
    }
}
