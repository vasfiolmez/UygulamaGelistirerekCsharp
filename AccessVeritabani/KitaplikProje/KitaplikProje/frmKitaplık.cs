using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace KitaplikProje
{
    public partial class frmKitaplık : Form
    {
        public frmKitaplık()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti=new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\hp\\Desktop\\Kitaplik.mdb");
        void listele()
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter da=new OleDbDataAdapter("select * from Kitaplar",baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }
        string durum = "";
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("insert into Kitaplar (KitapAd,Yazar,Tur,Sayfa,Durum) values (@p1,@p2,@p3,@p4,@p5)",baglanti);
            cmd.Parameters.AddWithValue("@p1",txtKitapAdi.Text);
            cmd.Parameters.AddWithValue("@p2",txtYazar.Text);
            cmd.Parameters.AddWithValue("@p3",cmbTur.Text);
            cmd.Parameters.AddWithValue("@p4",txtSayfa.Text);
            cmd.Parameters.AddWithValue("@p5", durum);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kitap sisteme kaydedildi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            durum = "0";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            durum = "1";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtKitapid.Text= dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtKitapAdi.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtYazar.Text= dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbTur.Text= dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtSayfa.Text= dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            if (dataGridView1.Rows[secilen].Cells[5].Value.ToString()=="True")
            {
                radioButton2.Checked = true;
            }
            else { radioButton1.Checked = true; }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("delete from Kitaplar where Kitapid=@p1",baglanti);
            cmd.Parameters.AddWithValue("@p1",txtKitapid.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
          
            MessageBox.Show("Kayıt silindi");
            listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("update Kitaplar set KitapAd=@p1,Yazar=@p2,Tur=@p3,Sayfa=@p4,Durum=@p5 where Kitapid=@p6",baglanti);
            cmd.Parameters.AddWithValue("@p1", txtKitapAdi.Text);
            cmd.Parameters.AddWithValue("@p2", txtYazar.Text);
            cmd.Parameters.AddWithValue("@p3", cmbTur.Text);
            cmd.Parameters.AddWithValue("@p4", txtSayfa.Text);
            if (radioButton1.Checked==true) { cmd.Parameters.AddWithValue("@p5", durum); }
            if (radioButton2.Checked==true) { cmd.Parameters.AddWithValue("@p5", durum); }
           
            cmd.Parameters.AddWithValue("@p6",txtKitapid.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kitap kaydı güncellendi.");
            listele();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnBul_Click(object sender, EventArgs e)
        {
           
            OleDbCommand cmd1 = new OleDbCommand("select * from Kitaplar where KitapAd=@p1",baglanti);
            cmd1.Parameters.AddWithValue("@p1",txtBul.Text);
           DataTable dt = new DataTable();
            OleDbDataAdapter da=new OleDbDataAdapter(cmd1);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
