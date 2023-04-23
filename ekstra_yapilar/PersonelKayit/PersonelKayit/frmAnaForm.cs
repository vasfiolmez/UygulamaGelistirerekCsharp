using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PersonelKayit
{
    public partial class frmAnaForm : Form
    {
        public frmAnaForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-O6URGDO7\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        void temizle()
        {
            txtİd.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtMeslek.Text = "";
            mskMaas.Text = "";
            cmbSehir.Text = "";
            rbE.Checked = false;
            rdB.Checked = false;
            txtAd.Focus();
        }
        private void btnKayıtEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (Per_ad,Per_soyad,Per_sehir,Per_maas,Per_meslek,Per_durum) values (@p1,@p2,@p3,@p4,@p5,@p6)",baglanti);
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbSehir.Text);
            komut.Parameters.AddWithValue("@p4", mskMaas.Text);
            komut.Parameters.AddWithValue("@p5", txtMeslek.Text);
            komut.Parameters.AddWithValue("@p6",label8.Text);
            komut.ExecuteNonQuery();            
            baglanti.Close();
            MessageBox.Show("Personel Eklendi.");
        }

        private void rbE_CheckedChanged(object sender, EventArgs e)
        {
            if (rbE.Checked==true)
            {
              label8.Text = "True";
            }
            
        }

        private void rdB_CheckedChanged(object sender, EventArgs e)
        {
            if (rdB.Checked == true)
            {
                label8.Text = "False";
            }
            
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtİd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text =dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True")
            {
                rbE.Checked=true;
            }
            if (label8.Text == "False")
            {
                rdB.Checked = true;
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil= new SqlCommand("Delete From Tbl_Personel Where Per_id=@k1",baglanti);
            komutsil.Parameters.AddWithValue("@k1",txtİd.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand update = new SqlCommand("Update Tbl_Personel Set Per_ad=@a1,Per_soyad=@a2,Per_sehir=@a3,Per_maas=@a4,,Per_durum=@a5,Per_meslek=@a6 where Per_id=@a7",baglanti);
            update.Parameters.AddWithValue("@a1",txtAd.Text);
            update.Parameters.AddWithValue("@a2", txtAd.Text);
            update.Parameters.AddWithValue("@a3", txtAd.Text);
            update.Parameters.AddWithValue("@a4", txtAd.Text);
            update.Parameters.AddWithValue("@a5", txtAd.Text);
            update.Parameters.AddWithValue("@a6", txtAd.Text);
            update.Parameters.AddWithValue("@a7", txtİd.Text);
            update.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel kayıtları güncellendi.");

        }

        private void btnİstatistik_Click(object sender, EventArgs e)
        {
            frmİstatistik istatistik = new frmİstatistik();
            istatistik.Show();
            
        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
           frmGrafikler grafikler = new frmGrafikler();
            grafikler.Show();
        }
    }
}
