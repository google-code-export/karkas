using System;
using System.Collections.Generic;
using System.Text;
using MbUnit.Framework;
using Simetri.MyGenerationHelper;

namespace Simetri.MyGenerationTest
{
    [TestFixture]
    [Author("Atilla Özgür","aozgur@simetri.com")]
    public class ConnectionHelperTest
    {
        public static string connectionStringWithProvider = @"Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;User ID=sa;Initial Catalog=ITO;Data Source=ATILAPTOP\SQLEXPRESS";
        public static string connectionStringWithoutProvider = @"Integrated Security=SSPI;Persist Security Info=False;User ID=sa;Initial Catalog=ITO;Data Source=ATILAPTOP\SQLEXPRESS";
        public static string connectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ITO;Data Source=.\SQLEXPRESS";

        [Test]
        public void providerStringiTestEt()
        {
            Assert.IsTrue(ConnectionHelper.RemoveProviderFromConnectionString(connectionStringWithProvider) == connectionStringWithoutProvider);
            Assert.IsTrue(ConnectionHelper.RemoveProviderFromConnectionString(connectionString) == connectionString);
        }
    }
}
