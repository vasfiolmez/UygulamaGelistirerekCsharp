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
    public partial class frmSekreterGiris : Form
    {
        public frmSekreterGiris()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl=new SqlBaglantisi();

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Tbl_Sekreter where SekreterTC=@p1 and SekreterSifre=@p2",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",mskTC.Text);
            cmd.Parameters.AddWithValue("@p2",txtSifre.Text);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) 
            { 
            frmSekreterDetay fr=new frmSekreterDetay();
            fr.Tcnumara=mskTC.Text;
            fr.Show();
            this.Hide();

            }
            else 
            {

                MessageBox.Show("Şifrenizi Veya TcNo yanlış girdiniz.Lütfen tekrar deneyiniz.");
            
            }
        }
    }
}
