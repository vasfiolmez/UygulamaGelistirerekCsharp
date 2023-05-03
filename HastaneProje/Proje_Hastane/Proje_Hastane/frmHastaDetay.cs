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
                cmbDoktor.Items.Add(dr3[0]+"  " + dr3[1]);
            }
            bgl.baglanti().Close();
        }

        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter d = new SqlDataAdapter("select * From Tbl_Randevu where RandevuBrans='"+cmbBrans.Text+"'",bgl.baglanti());
            d.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void lblBilgiDuzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmBilgiDuzenle fr=new frmBilgiDuzenle();
            fr.TCno = lblTC.Text;
            fr.ShowDialog();
            
        }
    }
}
