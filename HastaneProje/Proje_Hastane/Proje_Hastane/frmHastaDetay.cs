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

namespace Proje_Hastane
{
    public partial class frmHastaDetay : Form
    {
        public frmHastaDetay()
        {
            InitializeComponent();
        }
        public string tc;
        
        SqlBaglantisi bgl=new SqlBaglantisi();
        private void frmHastaDetay_Load(object sender, EventArgs e)
        {
            //ad soyad çekme
            lblTC.Text = tc;
            SqlCommand cmd=new SqlCommand("select HastaAd,HastaSoyad from Tbl_Hastalar where HastaTC=@p1",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", lblTC.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) 
            {
                lblAdSoyad.Text = dr[0]+ "  " + dr[1];
            }

            //randevu çekme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Randevu where HastaTC="+tc,bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //Branş Çekme-
            SqlCommand cmd2 = new SqlCommand("Select BransAd From Tbl_Branslar",bgl.baglanti());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read()) 
            {
                cmbBrans.Items.Add(dr2[0]);            
            }
            bgl.baglanti().Close();  
        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();     
            SqlCommand cmd3 = new SqlCommand("Select DoktorAd,DoktorSoyad From Tbl_Doktorlar where DoktorBrans=@p1", bgl.baglanti());
            cmd3.Parameters.AddWithValue("@p1",cmbBrans.Text);
            SqlDataReader dr3= cmd3.ExecuteReader();
            while (dr3.Read()) 
            {
                cmbDoktor.Items.Add(dr3[0]+" " + dr3[1]);
            }
            bgl.baglanti().Close();
        }

        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter d = new SqlDataAdapter("select * From Tbl_Randevu where RandevuBrans='"+cmbBrans.Text+"' and RandevuDoktor='"+cmbDoktor.Text+"' and RandevuDurum=0",bgl.baglanti());
            d.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void lblBilgiDuzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmBilgiDuzenle fr=new frmBilgiDuzenle();
            fr.TCno = lblTC.Text;
            fr.ShowDialog();
            
        }

        private void btnRandevuAl_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update Tbl_Randevu set RandevuDurum=1,HastaTC=@p1,HastaSikayet=@p2 where Randevuid=@p3",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",lblTC.Text);
            cmd.Parameters.AddWithValue("@p2",richtxtSikayet.Text);
            cmd.Parameters.AddWithValue("@p3",txtId.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Randevu alındı.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            bgl.baglanti().Close();


        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            txtId.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();

        }
    }
}
