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
    public partial class frmKategori : Form
    {
        public frmKategori()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db= new DbEntityUrunEntities();
        private void btnListele_Click(object sender, EventArgs e)
        {
            var ketegoriler = db.TBLKATEGORI.ToList();
            dataGridView1.DataSource= ketegoriler;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            TBLKATEGORI t=new TBLKATEGORI();
            t.AD = textBox2.Text;
            db.TBLKATEGORI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kategori eklendi.");  
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int x= Convert.ToInt32(textBox1.Text);
            var ktgr = db.TBLKATEGORI.Find(x);
            db.TBLKATEGORI.Remove(ktgr);
            db.SaveChanges();
            MessageBox.Show("Kategori silindi.");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            var ktgr = db.TBLKATEGORI.Find(x);
            ktgr.AD = textBox2.Text;
            db.SaveChanges();
            MessageBox.Show("Güncelleme yapıldı.");
        }
    }
}
