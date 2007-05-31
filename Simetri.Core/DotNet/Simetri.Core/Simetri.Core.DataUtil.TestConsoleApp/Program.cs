using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.Dal.Ortak;
using Simetri.Core.TypeLibrary.Ortak;
using System.Data;
using Simetri.Core.Validation.ForPonos;

namespace Simetri.Core.DataUtil.TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string sql = @"SELECT     Customers.CustomerID, Customers.CompanyName, Customers.ContactName, Customers.ContactTitle, Customers.Address, Orders.OrderID, 
                     [Order Details].ProductID, [Order Details].UnitPrice, [Order Details].Quantity
FROM         Customers INNER JOIN
                      Orders ON Customers.CustomerID = Orders.CustomerID INNER JOIN
                      [Order Details] ON Orders.OrderID = [Order Details].OrderID
                WHERE Customers.CompanyName LIKE @CompanyName + '%'";

            AdoTemplate template = new AdoTemplate();
            ParameterBuilder builder = new ParameterBuilder();
            builder.parameterEkle("@CompanyName", SqlDbType.VarChar, "S");

//            DataTable dt = template.DataTableOlustur(sql, builder.GetParameterArray());
            DataTable dt2 = template.DataTableDoldurSayfalamaYap(sql, 20, 5, "Customers.CustomerID", builder.GetParameterArray());




        }
    }
}
