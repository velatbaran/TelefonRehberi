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

        fBaslangic f = (fBaslangic)Application.OpenForms["fBaslangic"];

        private void Temizle()
        {
            txtDahiliNo.Clear();
            txtAdSoyad.Clear();
            txtUnvan.Clear();
            txtBirim.Clear();
            txtAdSoyad.Focus();
            txtCepNo.Clear();
            lblId.Text = "";
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            f.verilerigoster();
            this.Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if(lblId.Text != "")
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
                        MessageBox.Show("Güncelleme işlemi başarıyla gerçekleşti.", "Personel Güncelleme Sayfası", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        Temizle();
                        f.verilerigoster();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen gerekli tüm alanları doldurunuz!", "Personel Güncelleme Sayfası", MessageBoxButtons.OK,MessageBoxIcon.Question);
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz!", "Personel Güncelleme Sayfası", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

        }

        private void fGuncelleme_Load(object sender, EventArgs e)
        {
            
        }

        private void fGuncelleme_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                dynamic result = MessageBox.Show("Çıkmak istiyor musunuz?", "Personel Güncelleme Sayfası", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    e.Cancel = false;
                    f.verilerigoster();
                }

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
