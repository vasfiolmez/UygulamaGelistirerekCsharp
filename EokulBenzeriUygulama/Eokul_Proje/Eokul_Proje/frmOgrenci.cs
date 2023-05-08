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
    public partial class frmOgrenci : Form
    {
        public frmOgrenci()
        {
            InitializeComponent();
        }

        private void pctExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        DataSet1TableAdapters.DataTable1TableAdapter ds=new DataSet1TableAdapters.DataTable1TableAdapter();
            SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-O6URGDO7\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");

        private void frmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource= ds.Ogrlistesi();
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select * from TBLKULUPLER",baglanti);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            comboBox1.DisplayMember = "KULUPAD";
            comboBox1.ValueMember = "KULUPID";
            comboBox1.DataSource = dataTable;
            baglanti.Close();



              
            
            
        }
        string c = "";
        private void btnEkle_Click(object sender, EventArgs e)
        {
            
            ds.ogrekle(txtOgradi.Text, txtOgrsoyadi.Text, byte.Parse(comboBox1.SelectedValue.ToString()), c);
            MessageBox.Show("Öğrenci Ekleme Yapıldı.");
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Ogrlistesi();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.ogrsil(int.Parse(txtOgrid.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtOgrid.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtOgradi.Text= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtOgrsoyadi.Text= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox1.Text= dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()=="Kadın")
            {
                radioButton1.Checked = true;
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()=="Erkek")
            {
                radioButton2.Checked = true;
            }

        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            ds.ogrguncelle(txtOgradi.Text, txtOgrsoyadi.Text, byte.Parse(comboBox1.SelectedValue.ToString()), c,int.Parse(txtOgrid.Text));
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) { c = "Kadın"; }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true) { c = "Erkek"; }
        }

        private void btnARA_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource= ds.ogrencigetir(txtAra.Text);
        }
    }
}
