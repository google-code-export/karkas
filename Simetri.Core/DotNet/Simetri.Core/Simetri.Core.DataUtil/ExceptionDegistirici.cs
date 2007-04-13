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
        }


        public static void Degistir(SqlException ex, string sql)
        {
            if (ex.Number == 102)
            {
                throw new YanlisSqlCumlesiHatasi(String.Format("{0} sql cumlesi hatalý yazýlmýþtýr. Sunucudan gelen mesaj {1}", sql, ex.Message), ex);
            }

            throw new SimetriVeriHatasi(String.Format("Tanimlanamayan Veri Hatasi, Mesaji = {0}", ex.Message), ex);
        }

    }
}
