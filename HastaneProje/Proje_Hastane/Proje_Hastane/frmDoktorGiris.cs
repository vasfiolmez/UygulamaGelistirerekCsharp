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
    public partial class frmDoktorGiris : Form
    {
        public frmDoktorGiris()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl =new SqlBaglantisi();
        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Tbl_Doktorlar where DoktorTC=@p1 and DoktorSifre=@p2",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",mskTC.Text);
            cmd.Parameters.AddWithValue("@p2",txtSifre.Text);
          SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read()) 
            { 
            frmDoktorDetay doktorDetay = new frmDoktorDetay();
                doktorDetay.doktortc=mskTC.Text;
                doktorDetay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı Adı veya şifre girişi yaptınız.");
            }
            bgl.baglanti().Close();
            
        }
    }
}
