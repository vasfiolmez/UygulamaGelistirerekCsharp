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

namespace Eokul_Proje
{
    public partial class frmKulup : Form
    {
        public frmKulup()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-O6URGDO7\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");
        void listele()
        {
            SqlCommand cmd = new SqlCommand("select * from TBLKULUPLER", baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void frmKulup_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void pctExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("insert into TBLKULUPLER (KULUPAD) VALUES (@p1)",baglanti);
            cmd.Parameters.AddWithValue("@p1",txtKadi.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulup Listeye eklendi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }
    }
}
