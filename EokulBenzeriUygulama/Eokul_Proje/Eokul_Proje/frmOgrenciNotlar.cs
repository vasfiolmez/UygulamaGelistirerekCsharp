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


namespace Eokul_Proje
{
    public partial class frmOgrenciNotlar : Form
    {
        public frmOgrenciNotlar()
        {
            InitializeComponent();
        }
        public string numara;
        SqlConnection baglanti=new SqlConnection(@"Data Source=LAPTOP-O6URGDO7\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");
        private void frmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select DERSAD,SINAV1,SINAV2,SINAV3,PROJE,ORTALAMA,DURUM from TBLNOTLAR inner join TBLDERSLER on TBLNOTLAR.DERSID=TBLDERSLER.DERSID where OGRID=@p1", baglanti);
            cmd.Parameters.AddWithValue("@p1",numara);
           // this.Text = numara.ToString();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            baglanti.Open();
            SqlCommand cmd2 = new SqlCommand("select OGRAD,OGRSOYAD from TBLOGRENCILER where OGRID="+numara,baglanti);
            SqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read()) 
            { 
            this.Text= dr[0] +" "+ dr[1];
            }
            baglanti.Close();
            
            
        }
    }
}
