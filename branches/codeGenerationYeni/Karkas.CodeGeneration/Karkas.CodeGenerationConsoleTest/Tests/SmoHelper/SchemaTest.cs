using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper;
using NUnit.Framework;
namespace Karkas.MyGenerationConsoleTest.Tests.SmoHelper
{
	[TestFixture]
	public class SchemaTest
	{
		private static string ConnectionString;
		static SchemaTest()
		{
			ConnectionString = Program._ConnectionString;
		}


		[Test]
		public void TestSchemaListesi1()
		{

			Utils uti = new Utils();
			string[] schemalar = uti.GetSchemaList("KARKAS_ORNEK", ConnectionString);
			foreach (string item in schemalar)
			{
				Console.WriteLine(item);
			}
		}
	}
}
