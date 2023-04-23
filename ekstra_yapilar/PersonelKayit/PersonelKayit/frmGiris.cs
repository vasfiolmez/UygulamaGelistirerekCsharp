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


namespace PersonelKayit
{
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-O6URGDO7\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void btnGiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("select * from Tbl_Yonetici where KullaniciAd=@a1 and Sifre=@a2",baglanti);
            komut.Parameters.AddWithValue("@a1",txtKadi.Text);
            komut.Parameters.AddWithValue("@a2",txtKsifre.Text);
            SqlDataReader dr=komut.ExecuteReader();
           
            if (dr.Read()) 
            {
                frmAnaForm anaForm = new frmAnaForm();
                anaForm.Show();
                this.Hide();
            }
            else 
            {
                MessageBox.Show("Hatalı kullanıcı adı ya da şifre girdiniz.");
            }


            baglanti.Close();
        }
    }
}
