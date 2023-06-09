﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;

namespace LogicLayer
{
    public class LogicPersonel
    {
        public static List<EntityPersonel> llPersonelListesi()
        {
            return DALPersonel.PersonelListesi();
        }
        public static int llPersonelEkle(EntityPersonel personel)
        {

            if (personel.Ad != "" && personel.Soyad != "" && personel.Maas >= 3500 && personel.Ad.Length >= 3)
            {
                return DALPersonel.PersonelEkle(personel);
            }
            else
            {
                return -1;
            }
        }

        public static bool llPersonelSil(int per)
        {
            if (per >= 1)
            {
                return DALPersonel.PersonelSil(per);
            }
            else
            {
                return false;
            }

        }
        public static bool llPersonelGuncelle(EntityPersonel ent)
        {
            if (ent.Ad.Length >= 3 && ent.Ad != "" && ent.Maas >= 4500)
            {
                return DALPersonel.personelGuncelle(ent);
            }
            else
            {
                return false;
            }
        }
    }
}
