using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Metin_belgesi_kayıt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            saveFileDialog1.Filter = "Metin Dosyaları|*.txt";
            saveFileDialog1.Title = "Metin belgesi kayıt";        
            saveFileDialog1.ShowDialog();
            StreamWriter sw= new StreamWriter(saveFileDialog1.FileName);
            sw.WriteLine(richTextBox1.Text);
            sw.Close();
            MessageBox.Show("Belge oluşturuldu.");
            
            
        }
    }
}
