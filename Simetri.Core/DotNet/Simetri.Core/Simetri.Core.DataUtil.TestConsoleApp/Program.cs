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
            string sql = @"SELECT     ID, TcKimlikNo, Adi, Soyadi, WindowsUserName, IkinciAdi
                                FROM         ORTAK.KISI
                                WHERE Adi LIKE @Adi + '%'";
            ParameterBuilder builder = new ParameterBuilder();
            builder.parameterEkle("@Adi", SqlDbType.VarChar, "A");

            DataTable dt = new DataTable();
            AdoTemplate template = new AdoTemplate();
            template.DataTableDoldur(dt, sql, builder.GetParameterArray());

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine(row["Adi"]);
            }


        }
    }
}
