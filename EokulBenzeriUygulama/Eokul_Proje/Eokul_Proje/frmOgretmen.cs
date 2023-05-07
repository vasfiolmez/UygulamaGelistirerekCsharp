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
    public partial class frmOgretmen : Form
    {
        public frmOgretmen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmKulup fr=new frmKulup();
            fr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDersler frmDersler = new frmDersler();
            frmDersler.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmOgrenci frmOgrenci = new frmOgrenci();
            frmOgrenci.Show();
        }
    }
}
