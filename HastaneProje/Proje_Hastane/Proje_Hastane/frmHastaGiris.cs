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
    public partial class frmHastaGiris : Form
    {
        public frmHastaGiris()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl=new SqlBaglantisi();
        private void lnkUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmHastaKayıt frm= new frmHastaKayıt();
            frm.Show();
            this.Hide();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Tbl_Hastalar where HastaTC=@p1 and HastaSifre=@p2",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", mskTC.Text);
            cmd.Parameters.AddWithValue("@p2",txtSifre.Text);
            SqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.Read()) 
            {
              frmHastaDetay fr= new frmHastaDetay();
                fr.tc=mskTC.Text;
            
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Tc veya Sifre girişi yaptınız.");
            }
            bgl.baglanti().Close();
        }
    }
}
