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
    public partial class frmİstatistik : Form
    {
        public frmİstatistik()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db =new DbEntityUrunEntities();
        private void frmİstatistik_Load(object sender, EventArgs e)
        {
            label2.Text=db.TBLKATEGORI.Count().ToString();
            label3.Text=db.TBLURUN.Count().ToString();
            label5.Text=db.TBLMUSTERILER.Count(x=>x.DURUM==true).ToString();
            label7.Text = db.TBLMUSTERILER.Count(x => x.DURUM == false).ToString();
            label11.Text = db.TBLURUN.Sum(y=>y.STOK).ToString();
            label19.Text=db.TBLSATIS.Sum(z=>z.FIYAT).ToString()+" TL";
            label13.Text=(from x in db.TBLURUN orderby x.FIYAT descending select x.URUNAD).FirstOrDefault().ToString();
            label15.Text=(from x in db.TBLURUN orderby x.FIYAT ascending select x.URUNAD).FirstOrDefault().ToString();
            label9.Text =db.TBLURUN.Count(x=>x.KATEGORI==1).ToString();
            label17.Text=(from x in db.TBLMUSTERILER select x.SEHIR).Distinct().Count().ToString();
            label21.Text=db.markagetir().FirstOrDefault().ToString();   
        }
    }
}
