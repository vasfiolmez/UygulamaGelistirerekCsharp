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
    public partial class frmHastaKayıt : Form
    {
        public frmHastaKayıt()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void btnKayıtYap_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Tbl_Hastalar (HastaAd,HastaSoyad,HastaTC,HastaTelefon,HastaSifre,HastaCinsiyet) values (@p1,@p2,@p3,@p4,@p5,@p6)",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",txtAd.Text);
            cmd.Parameters.AddWithValue("@p2", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@p3", mskTC.Text);
            cmd.Parameters.AddWithValue("@p4", mskTelno.Text);
            cmd.Parameters.AddWithValue("@p5", txtSifre.Text);
            cmd.Parameters.AddWithValue("@p6", cmbCinsiyet.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız Gerçekleştirilmiştir. Şifreniz:"+txtSifre.Text,"Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
           

        }
    }
}
