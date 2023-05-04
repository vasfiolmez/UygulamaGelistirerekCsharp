using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class frmDoktorDetay : Form
    {
        public frmDoktorDetay()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl=new SqlBaglantisi();
        public string doktortc;
        private void frmDoktorDetay_Load(object sender, EventArgs e)
        {
            lblTC.Text = doktortc;

            //doktor ad soyad

            SqlCommand cmd = new SqlCommand("Select DoktorAd,DoktorSoyad From Tbl_Doktorlar where DoktorTC=@p1",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",lblTC.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) 
            {
                lblAdSoyad.Text = dr[0].ToString()+" "+dr[1].ToString();
            }
            bgl.baglanti().Close();

            //randevular,
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Randevu where RandevuDoktor='"+lblAdSoyad.Text+"'",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            frmDoktorBilgiDuzenle duz = new frmDoktorBilgiDuzenle();
            duz.dTCNO=lblTC.Text;
            duz.Show();

        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDuyuru_Click(object sender, EventArgs e)
        {
            frmDuyurular duyurular = new frmDuyurular();
            duyurular.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            rxhSikayet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();

        }
    }
}
