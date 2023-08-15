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
                    //Dosyanın okunacağı dizin
                    //string filePath = @"C:\Users\Semih\Documents\Test.xlsx";
                    string tamYol = @"\\10.124.1.38\ftp24\Bilgi Teknolojileri Şube Müdürlüğü\Dahili Rehber\dsi24bolge_dahili.xlsx";

                    //Excel bağlantı adresi
                    string baglantiAdresi = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + tamYol + ";Extended Properties='Excel 12.0;Xml;HDR=YES;'";

                    //bağlantı 
                    OleDbConnection baglanti = new OleDbConnection(baglantiAdresi);

                    //bağlantıyı açıyoruz.
                    baglanti.Open();

                    OleDbCommand komut = new OleDbCommand("Update [" + "Sayfa1" + "$] set AdSoyad=@p1,Unvan=@p2,Birim=@p3,DahiliNo=@p4 where Id=@p5", baglanti);

                    komut.Parameters.AddWithValue("@p1", txtAdSoyad.Text);
                    komut.Parameters.AddWithValue("@p2", txtUnvan.Text);
                    komut.Parameters.AddWithValue("@p3", txtBirim.Text);
                    komut.Parameters.AddWithValue("@p4", txtDahiliNo.Text);
                    komut.Parameters.AddWithValue("@p5", lblId.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Güncelleme işlemi başarıyla gerçekleşti.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
            else
            {
                MessageBox.Show("Lütfen gerekli tüm alanları doldurunuz!");
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
                fBaslangic f = new fBaslangic();
                f.Show();
                this.Close();
            }
        }
    }
}
