using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProje
{
    public partial class frmAnaform : Form
    {
        public frmAnaform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmKategori frm=new frmKategori();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmUrun frm=new frmUrun();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmİstatistik frm=new frmİstatistik();
            frm.Show(); 
        }
    }
}
