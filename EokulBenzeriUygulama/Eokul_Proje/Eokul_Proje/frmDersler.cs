using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eokul_Proje
{
    public partial class frmDersler : Form
    {
        public frmDersler()
        {
            InitializeComponent();
        }

        private void pctExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
          DataSet1TableAdapters.TBLDERSLERTableAdapter ds = new DataSet1TableAdapters.TBLDERSLERTableAdapter();
        private void frmDersler_Load(object sender, EventArgs e)
        {
           
            dataGridView1.DataSource = ds.Derslistesi();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            ds.DersEkle(txtKadi.Text);
            MessageBox.Show("Ders Ekleme işlemi yapılmıştır.");
           
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Derslistesi();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(txtKid.Text) );
            MessageBox.Show("Ders kaydı silinmiştir.");
            
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            ds.DersGuncelle(txtKadi.Text,byte.Parse(txtKid.Text));
            MessageBox.Show("Ders Kaydı güncellenmiştir.");
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtKadi.Text= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
