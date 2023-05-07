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

        private void frmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource= ds.Ogrlistesi();
        }
    }
}
