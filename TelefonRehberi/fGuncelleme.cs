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
    public partial class fGuncelleme : Form
    {
        public fGuncelleme()
        {
            InitializeComponent();
        }

        fBaslangic f = new fBaslangic();

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtDahiliNo.Clear();
            txtAdSoyad.Clear();
            txtUnvan.Clear();
            txtBirim.Clear();
            txtAdSoyad.Focus();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtAdSoyad.Text != "" && txtUnvan.Text != "" && txtBirim.Text != "" && txtDahiliNo.Text != "")
            {
                try
                {
                    //bağlantıyı açıyoruz.
                    f.baglanti.Open();

                    OleDbCommand komut = new OleDbCommand("Update [" + "Sayfa1" + "$] set AdSoyad=@p1,Unvan=@p2,Birim=@p3,DahiliNo=@p4,CepNo=@p5 where Id=@p6", f.baglanti);

                    komut.Parameters.AddWithValue("@p1", txtAdSoyad.Text);
                    komut.Parameters.AddWithValue("@p2", txtUnvan.Text);
                    komut.Parameters.AddWithValue("@p3", txtBirim.Text);
                    komut.Parameters.AddWithValue("@p4", txtDahiliNo.Text);
                    komut.Parameters.AddWithValue("@p5", txtCepNo.Text);
                    komut.Parameters.AddWithValue("@p6", Convert.ToInt32(lblId.Text));
                    komut.ExecuteNonQuery();
                    f.baglanti.Close();
                    MessageBox.Show("Güncelleme işlemi başarıyla gerçekleşti.", "Personel Güncelleme İşlemi");
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
                MessageBox.Show("Lütfen gerekli tüm alanları doldurunuz!", "Personel Güncelleme İşlemi");
            }
        }

        private void fGuncelleme_Load(object sender, EventArgs e)
        {

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            DialogResult Cikis;
            Cikis = MessageBox.Show("Ekran Kapatılacak Emin siniz?", "Kapatma Uyarısı!", MessageBoxButtons.YesNo);
            if (Cikis == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
