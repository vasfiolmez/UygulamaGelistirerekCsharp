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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Eokul_Proje
{
    public partial class frmSınavNotları : Form
    {
        public frmSınavNotları()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.TBLNOTLARTableAdapter ds=new DataSet1TableAdapters.TBLNOTLARTableAdapter();
        private void btnARA_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = ds.notlistesi(int.Parse(txtOgrid.Text));
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-O6URGDO7\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");

        private void frmSınavNotları_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select * from TBLDERSLER", baglanti);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            cmbDers.DisplayMember = "DERSAD";
            cmbDers.ValueMember = "DERSID";
            cmbDers.DataSource = dataTable;
            baglanti.Close();
        }
        int notid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid =int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtOgrid.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
           
        }
            int sinav1, sinav2, sinav3, proje;

        private void txtGuncelle_Click(object sender, EventArgs e)
        {
            ds.notguncelle(byte.Parse(cmbDers.SelectedValue.ToString()), int.Parse(txtOgrid.Text), byte.Parse(txtSinav1.Text), byte.Parse(txtSinav2.Text), byte.Parse(txtSinav3.Text), byte.Parse(txtProje.Text), decimal.Parse(txtOrtalama.Text), bool.Parse(txtDurum.Text), notid);
        }

        double ortalama;
            string durum;
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            
            sinav1 = Convert.ToInt16(txtSinav1.Text);
            sinav2= Convert.ToInt16(txtSinav2.Text);
            sinav3= Convert.ToInt16(txtSinav3.Text);
            proje= Convert.ToInt16(txtProje.Text);
            ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;
            txtOrtalama.Text=ortalama.ToString("00.00");
            if (ortalama>=50){ txtDurum.Text = "True"; }
            else { txtDurum.Text = "False"; }
        }
    }
}
