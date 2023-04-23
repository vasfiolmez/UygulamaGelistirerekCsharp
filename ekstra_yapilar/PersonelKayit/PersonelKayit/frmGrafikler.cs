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
    public partial class frmGrafikler : Form
    {
        public frmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-O6URGDO7\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void frmGrafikler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutg1 = new SqlCommand("select Per_sehir,count(*) from Tbl_Personel Group By Per_sehir",baglanti);
            SqlDataReader dr1= komutg1.ExecuteReader();
            while (dr1.Read()) 
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);           
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komutg2 = new SqlCommand("select Per_meslek,avg(Per_maas) from Tbl_Personel Group By Per_meslek",baglanti);
            SqlDataReader dr2 = komutg2.ExecuteReader();
            while (dr2.Read()) 
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglanti.Close();
        }
    }
}
