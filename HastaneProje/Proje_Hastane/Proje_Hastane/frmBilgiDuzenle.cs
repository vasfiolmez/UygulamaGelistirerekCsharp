using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class frmBilgiDuzenle : Form
    {
        public frmBilgiDuzenle()
        {
            InitializeComponent();
        }
        public string TCno;

        private void frmBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mskTC.Text = TCno;
        }
    }
}
