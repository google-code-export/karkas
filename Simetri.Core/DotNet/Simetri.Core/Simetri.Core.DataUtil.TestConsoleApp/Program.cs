using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.Dal.Ortak;
using Simetri.Core.TypeLibrary.Ortak;
using System.Data;

namespace Simetri.Core.DataUtil.TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AdoTemplate template = new AdoTemplate();

//            string sql = @"SELECT     ID, TcKimlikNo, Adi, Soyadi, WindowsUserName, IkinciAdi
//                                FROM         ORTAK.KISI
//                                WHERE Adi LIKE @Adi + '%'";
//            ParameterBuilder builder = new ParameterBuilder();
//            builder.parameterEkle("@Adi", SqlDbType.VarChar, "A");

//            DataTable dt = new DataTable();
//            template.DataTableDoldur(dt, sql, builder.GetParameterArray());

//            foreach (DataRow row in dt.Rows)
//            {
//                Console.WriteLine(row["Adi"]);
//            }


                string sqlToExecute = @"
SELECT     ORTAK.KISI.Adi, ORTAK.KISI.Soyadi, ORTAK.KISI.TcKimlikNo, ORTAK.KISI_ADRES.Adres
FROM         ORTAK.KISI LEFT JOIN
                      ORTAK.KISI_ADRES ON ORTAK.KISI.ID = ORTAK.KISI_ADRES.KisiKey
                WHERE Adi Like @Adi + '%'
                ";

            
            DataTable dt2 = new DataTable();
            ParameterBuilder b = new ParameterBuilder();
            b.parameterEkle("@Adi", SqlDbType.VarChar, "");
            template.DataTableDoldurSayfalamaYap(dt2, sqlToExecute, 3, 2, "Soyadi", b.GetParameterArray());

            foreach (DataRow row in dt2.Rows)
            {
                Console.WriteLine(row["Adi"]);
                Console.WriteLine(row["Adres"]);
            }



        }
    }
}
