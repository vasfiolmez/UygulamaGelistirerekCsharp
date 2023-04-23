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
    public partial class frmİstatistik : Form
    {
        public frmİstatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-O6URGDO7\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void frmİstatistik_Load(object sender, EventArgs e)
        {
            //Toplam Personel 
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select count(*) from Tbl_Personel",baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read()) 
            {
                lblToplamPersonel.Text = dr1[0].ToString();             
            }
            baglanti.Close();
            // evli personel sayısı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select count(*) from Tbl_Personel where Per_durum=1",baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read()) 
            {
                lblEvliPersonel.Text = dr2[0].ToString();   
            }
            baglanti.Close();

            //bekar personel sayısı
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select count(*) from Tbl_Personel where Per_durum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblBekarPersonel.Text = dr3[0].ToString();
            }
            baglanti.Close();


            //Toplam farklı şehir sayısı
            baglanti.Open();
            SqlCommand komut4= new SqlCommand("select  count(distinct(Per_sehir)) from Tbl_Personel", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read()) 
            {
                lblSehir.Text = dr4[0].ToString();
            }
            baglanti.Close();

            //toplam maaş
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select sum(Per_maas) from Tbl_Personel",baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read()) 
            { 
            lblToplamMaas.Text = dr5[0].ToString();
            }
            baglanti.Close();
            //ortalama maaş
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select avg(Per_maas) from Tbl_Personel",baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read()) 
            { 
            lblOrtMaas.Text = dr6[0].ToString();
            }
            baglanti.Close();
        }
    }
}
