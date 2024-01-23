using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TelefonRehberi
{
    public partial class fBaslangic : Form
    {
        public fBaslangic()
        {
            InitializeComponent();
        }

        private DataTable data;
        //bağlantı 
        static string yol = @"\\10.124.1.38\ftp24\Bilgi Teknolojileri Şube Müdürlüğü\Dahili Rehber\dsi24bolge_dahili.xlsx";
        //static string yol = @"\\10.124.1.38\ftp24\Dahili Rehber\dsi24bolge_dahili.xlsx";
        //static string yol = @"D:\Dahili Rehber\dsi24bolge_dahili.xlsx";
        public OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + yol + "; Extended Properties='Excel 12.0;Xml;HDR=YES;'");

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 8);
            rdAdSoyad.Checked = true;

            verilerigoster();
            ExcelToplamKayitSayisi();

            lblSol.Text = "Güncelleme talebi için: bt24 @dsi.gov.tr";
            lblSag.Text = "Copyright @ " + DateTime.Now.Year + " Bilgi Teknolojileri Şube Müdürlüğü";

            if (SystemInformation.UserName == "velatbaran" || SystemInformation.UserName == "yalcinguney" || SystemInformation.UserName == "bayramcanpolat" || SystemInformation.UserName == "arifcan")
            {
                btnYeniKayit.Visible = true;
            }
            else
            {
                btnYeniKayit.Visible = false;
            }

        }

        public void verilerigoster()
        {
            //tüm verileri seçmek için select sorgumuz. Sayfa1 olan kısmı Excel'de hangi sayfayı açmak istiyosanız orayı yazabilirsiniz.
            OleDbCommand komut = new OleDbCommand("Select * From [" + "Sayfa1" + "$] where SilindiMi='False' ", baglanti);

            //bağlantıyı açıyoruz.
            baglanti.Open();
            //Gelen verileri DataAdapter'e atıyoruz.
            OleDbDataAdapter da = new OleDbDataAdapter(komut);

            //Grid'imiz için bir DataTable oluşturuyoruz.
            data = new DataTable();

            //DataAdapter'da ki verileri data adındaki DataTable'a dolduruyoruz.
            da.Fill(data);

            //DataGrid'imizin kaynağını oluşturduğumuz DataTable ile dolduruyoruz.
            dataGridView1.DataSource = data;
            lblToplamKayitSayisi.Text = dataGridView1.Rows.Count.ToString();
            //dataGridView1.Columns[6].Visible = false;
            baglanti.Close();
        }

        public void ExcelToplamKayitSayisi()
        {
            //tüm verileri seçmek için select sorgumuz. Sayfa1 olan kısmı Excel'de hangi sayfayı açmak istiyosanız orayı yazabilirsiniz.
            OleDbCommand komut = new OleDbCommand("Select * From [" + "Sayfa1" + "$] ", baglanti);

            //bağlantıyı açıyoruz.
            baglanti.Open();
            //Gelen verileri DataAdapter'e atıyoruz.
            OleDbDataAdapter da = new OleDbDataAdapter(komut);

            //Grid'imiz için bir DataTable oluşturuyoruz.
            data = new DataTable();

            //Grid'imiz için bir DataTable oluşturuyoruz.
            data = new DataTable();

            //DataAdapter'da ki verileri data adındaki DataTable'a dolduruyoruz.
            da.Fill(data);

            lblExcelToplamKayitSayisi.Text = data.Rows.Count.ToString();
            baglanti.Close();
        }

        // arama seçenekleri
        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(data);

            if (string.IsNullOrEmpty(txtAra.Text) == true)
            {
                verilerigoster();
            }

            if (rdAdSoyad.Checked == true)
            {

                dv.RowFilter = "AdSoyad LIKE '%" + txtAra.Text + "%'";

                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("bulunamadı.");
                }
            }
            else if (rdUnvan.Checked == true)
            {

                dv.RowFilter = "Unvan LIKE '%" + txtAra.Text + "%'";

                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("bulunamadı.");
                }
            }
            else if (rdBirim.Checked == true)
            {

                dv.RowFilter = "Birim LIKE '%" + txtAra.Text + "%'";

                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("bulunamadı.");
                }
            }
            else if (rdDahiliNo.Checked == true)
            {

                dv.RowFilter = string.Format("convert(DahiliNo, 'System.String') Like '%{0}%' ", txtAra.Text);

                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("bulunamadı.");
                }
            }

            else if (rdCepNo.Checked == true)
            {

                dv.RowFilter = string.Format("convert(CepNo, 'System.String') Like '%{0}%' ", txtAra.Text);

                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("bulunamadı.");
                }
            }

            dataGridView1.DataSource = dv;

        }

        private void fBaslangic_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult x = MessageBox.Show("Programdan Çıkmak İstediğinizden Emin Misiniz?", "Çıkış Mesajı!", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                Environment.Exit(0);

            }
            else if (x == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int seciliAlan = dataGridView1.SelectedCells[0].RowIndex;
            string id = dataGridView1.Rows[seciliAlan].Cells[0].Value.ToString();
            string ad = dataGridView1.Rows[seciliAlan].Cells[1].Value.ToString();
            DialogResult onay = MessageBox.Show(ad + " personel bilgisini silmek istediğinize emin misiniz?", "Personel Silme İşlemi", MessageBoxButtons.YesNo);
            if (onay == DialogResult.Yes)
            {
                try
                {
                    //bağlantıyı açıyoruz.
                    baglanti.Open();

                    OleDbCommand komut = new OleDbCommand("Update [" + "Sayfa1" + "$] set SilindiMi='True' where Id=@p5", baglanti);

                    komut.Parameters.AddWithValue("@p5", Convert.ToInt32(id));
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Silme işlemi başarıyla gerçekleşti.", "Personel Güncelleme İşlemi");
                    verilerigoster();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Silme işlemi iptal edildi!", "Personel Silme İşlemi");
            }

        }

        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            fYeniKayit f = new fYeniKayit();
            f.lblToplamKayitSayisi.Text = lblExcelToplamKayitSayisi.Text;
            f.Show();
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SystemInformation.UserName == "velatbaran" || SystemInformation.UserName == "yalcinguney" || SystemInformation.UserName == "bayramcanpolat" || SystemInformation.UserName == "arifcan")
            {
                int seciliAlan = dataGridView1.SelectedCells[0].RowIndex;
                string id = dataGridView1.Rows[seciliAlan].Cells[0].Value.ToString();
                string adsoyad = dataGridView1.Rows[seciliAlan].Cells[1].Value.ToString();
                string unvan = dataGridView1.Rows[seciliAlan].Cells[2].Value.ToString();
                string birim = dataGridView1.Rows[seciliAlan].Cells[3].Value.ToString();
                string dahili = dataGridView1.Rows[seciliAlan].Cells[4].Value.ToString();
                string cep = dataGridView1.Rows[seciliAlan].Cells[5].Value.ToString();

                fGuncelleme f = new fGuncelleme();
                f.lblId.Text = id;
                f.txtAdSoyad.Text = adsoyad;
                f.txtUnvan.Text = unvan;
                f.txtBirim.Text = birim;
                f.txtDahiliNo.Text = dahili;
                f.txtCepNo.Text = cep;
                f.Show();
            }
            else
            {
                MessageBox.Show("Güncelleme yetkiniz bulunmamaktadır.Lütfen birim yöneticisiyle irtibata geçiniz!");
            }
        }
    }
}

