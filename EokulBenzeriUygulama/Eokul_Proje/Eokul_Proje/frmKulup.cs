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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtKadi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("delete from TBLKULUPLER where KULUPID=@p1",baglanti);
            cmd.Parameters.AddWithValue("@p1",txtKid.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp kaydı silindi.");
            listele();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("update TBLKULUPLER set KULUPAD=@p1 where KULUPID=@p2",baglanti);
            cmd.Parameters.AddWithValue("@p1",txtKadi.Text);
            cmd.Parameters.AddWithValue("@p2",txtKid.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp kaydı güncellendi.");
            listele();
        }
    }
}
