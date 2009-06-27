using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.MyGenerationHelper;
using NUnit.Framework;
namespace Karkas.MyGenerationConsoleTest.Tests.SmoHelper
{
	[TestFixture]
	public class SchemaTest
	{
		private static string ConnectionString;
		static SchemaTest()
		{
			ConnectionString = Program.ConnectionString;
		}


		[Test]
		public void TestSchemaListesi1()
		{

			Utils uti = new Utils();
			string[] schemalar = uti.GetSchemaList("NOBET", ConnectionString);
			foreach (string item in schemalar)
			{
				Console.WriteLine(item);
			}
		}
	}
}
