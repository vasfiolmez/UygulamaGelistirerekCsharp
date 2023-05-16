using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;


namespace DataAccessLayer
{
    public class DALPersonel
    {
        public static List<EntityPersonel> PersonelListesi()
        {
            List<EntityPersonel> degerler = new List<EntityPersonel>();
            SqlCommand cmd = new SqlCommand("Select * from TBLBILGI", Baglanti.bgl);
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                EntityPersonel ent = new EntityPersonel();
                ent.Id = int.Parse(dr["id"].ToString());
                ent.Ad = dr["ad"].ToString();
                ent.Soyad = dr["soyad"].ToString();
                ent.Sehir = dr["sehir"].ToString();
                ent.Gorev = dr["gorev"].ToString();
                ent.Maas = short.Parse(dr["maas"].ToString());
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }

           public static int PersonelEkle(EntityPersonel p) 
        {
         
            SqlCommand cmd = new SqlCommand("insert into TBLBILGI (ad,soyad,sehir,gorev,maas) values (@p1,@p2,@p3,@p4,@p5)", Baglanti.bgl);
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            cmd.Parameters.AddWithValue("@p1",p.Ad);
            cmd.Parameters.AddWithValue("@p2",p.Soyad);
            cmd.Parameters.AddWithValue("@p3", p.Sehir);
            cmd.Parameters.AddWithValue("@p4", p.Gorev);
            cmd.Parameters.AddWithValue("@p5", p.Maas);
            return cmd.ExecuteNonQuery();

        }
    }
}
