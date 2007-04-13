using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Simetri.Core.DataUtil.Exceptions;

namespace Simetri.Core.DataUtil
{
    public class ExceptionDegistirici
    {
        public static void Degistir(SqlException ex)
        {
            Degistir(ex,"SQL CUMLESI YOK");
        }


        public static void Degistir(SqlException ex, string sql)
        {
            if (ex.Number == 102)
            {
                throw new YanlisSqlCumlesiHatasi(String.Format("{0} sql cumlesi hatalý yazýlmýþtýr. Sunucudan gelen mesaj {1}", sql, ex.Message), ex);
            }
            if (ex.Number == 208)
            {
                throw new VeritabaniBaglantiHatasi(String.Format("Veritabanina baglanilamadi lutfen connection string'in dogrulugunu ve veritabanininin calisip calismadigini kontrol ediniz, Kullanilan ConnectionString = {0}, verilen hata Mesaji = {1}", ConnectionSingleton.Instance.ConnectionString, ex.Message));
            }
            throw new SimetriVeriHatasi(String.Format("Tanimlanamayan Veri Hatasi, Mesaji = {0}", ex.Message), ex);
        }

    }
}
