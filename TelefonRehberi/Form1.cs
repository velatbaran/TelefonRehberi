﻿using ExcelDataReader;
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

namespace TelefonRehberi
{
    public partial class fBaslangic : Form
    {
        public fBaslangic()
        {
            InitializeComponent();
        }

        private DataTable data;

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 8);
            rdAdSoyad.Checked = true;

            verilerigoster();

            lblSol.Text = "Güncelleme talebi için: bt24 @dsi.gov.tr";
            lblSag.Text = "Copyright @ " + DateTime.Now.Year + " Bilgi Teknolojileri Şube Müdürlüğü";

        }

        public void verilerigoster()
        {
            //Dosyanın okunacağı dizin
            //string filePath = @"C:\Users\Semih\Documents\Test.xlsx";
            string tamYol = @"\\10.124.1.38\ftp24\Bilgi Teknolojileri Şube Müdürlüğü\Dahili Rehber\dsi24bolge_dahili.xlsx";

            //Excel bağlantı adresi
            string baglantiAdresi = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + tamYol + ";Extended Properties='Excel 12.0;Xml;HDR=YES;'";

            //bağlantı 
            OleDbConnection baglanti = new OleDbConnection(baglantiAdresi);

            //tüm verileri seçmek için select sorgumuz. Sayfa1 olan kısmı Excel'de hangi sayfayı açmak istiyosanız orayı yazabilirsiniz.
            OleDbCommand komut = new OleDbCommand("Select * From [" + "Sayfa1" + "$]", baglanti);

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
        }

        // arama seçenekleri
        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(data);

            if (txtAra.Text == "")
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

            dataGridView1.DataSource = dv;

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (SystemInformation.UserName == "velatbaran" || SystemInformation.UserName == "yalcinguney" || SystemInformation.UserName == "bayramcanpolat" || SystemInformation.UserName == "arifcan")
            {
                int seciliAlan = dataGridView1.SelectedCells[0].RowIndex;
                string id = dataGridView1.Rows[seciliAlan].Cells[0].Value.ToString();
                string adsoyad = dataGridView1.Rows[seciliAlan].Cells[1].Value.ToString();
                string unvan = dataGridView1.Rows[seciliAlan].Cells[2].Value.ToString();
                string birim = dataGridView1.Rows[seciliAlan].Cells[3].Value.ToString();
                string dahili = dataGridView1.Rows[seciliAlan].Cells[4].Value.ToString();

                fGuncelleme f = new fGuncelleme();
                f.lblId.Text = id;
                f.txtAdSoyad.Text = adsoyad;
                f.txtUnvan.Text = unvan;
                f.txtBirim.Text = birim;
                f.txtDahiliNo.Text = dahili;
                f.Show();
            }
            else
            {
                MessageBox.Show("Güncelleme yetkiniz bulunmamaktadır.Lütfen birim yöneticisiyle irtibata geçiniz!");
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            DialogResult Cikis;
            Cikis = MessageBox.Show("Program Kapatılacak Emin siniz?", "Kapatma Uyarısı!", MessageBoxButtons.YesNo);
            if (Cikis == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}