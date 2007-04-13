using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.Example.TypeLibrary;
using Simetri.Core.DataUtil;
using System.Data;
using System.Data.SqlClient;

namespace Simetri.Core.Example.Dal
{
    public class KisiDal : BaseDal<Kisi>
    {
        public void Ekle(Kisi p)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"INSERT INTO ORTAK.KISI
                           (KisiKey
                           ,Adi
                           ,Soyadi
                           )
                     VALUES
                           (@KisiKey
                           ,@Adi
                           ,@Soyadi
                           )";
            cmd.Connection = Connection;

            parameterEkle(cmd, "@KisiKey", p.KisiKey);
            parameterEkle(cmd, "@Adi", p.Adi, 50);
            parameterEkle(cmd, "@Soyadi", p.Soyadi, 50);

            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();
        }


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
