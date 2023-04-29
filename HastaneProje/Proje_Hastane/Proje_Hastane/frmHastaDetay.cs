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
    }
}
