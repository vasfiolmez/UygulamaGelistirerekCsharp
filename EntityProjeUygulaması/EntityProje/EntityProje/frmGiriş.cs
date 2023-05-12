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
    public partial class frmGiriş : Form
    {
        public frmGiriş()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void btnGirisYap_Click(object sender, EventArgs e)
        {

            var sorgu= from x in db.TBLADMIN where x.KULLANICI==txtKadi.Text && x.SİFRE==txtSifre.Text select x;

            if(sorgu.Any() ) 
            {
            frmAnaform fr=new frmAnaform();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatali kullanıcı adı veya şifre girişi yaptınız.");
            }
        }
    }
}
