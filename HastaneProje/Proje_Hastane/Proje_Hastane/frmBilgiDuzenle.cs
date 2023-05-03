﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    public partial class frmBilgiDuzenle : Form
    {
        public frmBilgiDuzenle()
        {
            InitializeComponent();
        }
        public string TCno;

        SqlBaglantisi bgl=new SqlBaglantisi();
        private void frmBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mskTC.Text = TCno;
            SqlCommand cmd = new SqlCommand("select * from Tbl_Hastalar where HastaTC=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",mskTC.Text);
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read()) 
            {
                txtAd.Text = dataReader[1].ToString();  
                txtSoyad.Text = dataReader[2].ToString();
                mskTelno.Text = dataReader[4].ToString();
                txtSifre.Text = dataReader[5].ToString();
                cmbCinsiyet.Text = dataReader[6].ToString();
            
            }
            bgl.baglanti().Close();
        }

        private void btnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update Tbl_Hastalar set HastaAd=@p1,HastaSoyad=@p2,HastaTelefon=@p3,HastaSifre=@p4,HastaCinsiyet=@p5 where HastaTC=@p6",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",txtAd.Text);
            cmd.Parameters.AddWithValue("@p2",txtSoyad.Text);
            cmd.Parameters.AddWithValue("@p3",mskTelno.Text);
            cmd.Parameters.AddWithValue("@p4", txtSifre.Text);
            cmd.Parameters.AddWithValue("@p5",cmbCinsiyet.Text);
            cmd.Parameters.AddWithValue("@p6",mskTC.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz güncellendi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);


        }
    }
}
