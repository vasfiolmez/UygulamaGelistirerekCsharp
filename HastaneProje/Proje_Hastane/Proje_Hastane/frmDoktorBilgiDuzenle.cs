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
    public partial class frmDoktorBilgiDuzenle : Form
    {
        public frmDoktorBilgiDuzenle()
        {
            InitializeComponent();
        }
        public string dTCNO;
        SqlBaglantisi bgl =new SqlBaglantisi();
        private void frmDoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mskTC.Text = dTCNO;

            SqlCommand cmd = new SqlCommand("select * from Tbl_Doktorlar where DoktoTC=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",mskTC.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) 
            {
                txtAd.Text = dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();
                cmbBrans.Text = dr[3].ToString();
                txtSifre.Text = dr[5].ToString();
            }
            bgl.baglanti().Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update Tbl_Doktorlar set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p4 where DoktorTC=@p5",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",txtAd.Text);
            cmd.Parameters.AddWithValue("@p2", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@p3", cmbBrans.Text);
            cmd.Parameters.AddWithValue("@p4", txtSifre.Text);
            cmd.Parameters.AddWithValue("@p5", mskTC.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgiler Güncellendi.");

        }
    }
}
