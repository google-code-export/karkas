using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.Example.TypeLibrary;
using Simetri.Core.DataUtil;
using System.Data;

namespace Simetri.Core.Example.Dal
{
    public class KisiDal : BaseDal<Kisi>
    {
        public void Ekle()
        {
            AdoTemplate template = new AdoTemplate();
            template.CalistirSelectHaric(@"INSERT INTO [ORTAK].[KISI]
                                           ([KisiKey]
                                           ,[Adi]
                                           ,[Soyadi])
                                     VALUES
                                           ('dsdsd','ddd','ddd')");
        }


        public List<Kisi> hepsiniGetir()
        {
            List<Kisi> liste = new List<Kisi>();
            string sql = "SELECT KisiKey,Adi,Soyadi  FROM ORTAK.KISI";

            selectKomutuCalistir(liste, sql);
            return liste;

        }

        

        public override void processRow(IDataReader dr, Kisi row)
        {
            row.Adi = dr.GetString(1);
            row.Soyadi = dr.GetString(2);

        }
    }
}
