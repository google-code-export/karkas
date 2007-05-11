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
SELECT     
ID
,TcKimlikNo
,Adi
,Soyadi
,WindowsUserName
,IkinciAdi
FROM ORTAK.KISI
";
            DataTable dt2 = new DataTable();
            template.DataTableDoldurSayfalamaYap(dt2, sqlToExecute, 2, 3, "Adi");

            foreach (DataRow row in dt2.Rows)
            {
                Console.WriteLine(row["Adi"]);
            }



        }
    }
}
