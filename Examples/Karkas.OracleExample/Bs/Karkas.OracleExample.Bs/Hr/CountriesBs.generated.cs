
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Karkas.Core.DataUtil;
using Karkas.OracleExample.TypeLibrary;
using Karkas.OracleExample.TypeLibrary.Hr;
using Karkas.OracleExample.Dal.Hr;


namespace Karkas.OracleExample.Bs.Hr
{
	public partial class CountriesBs : BaseBs<Countries, CountriesDal>
	{
		public override string DatabaseName
		{
			get
			{
				return "ORACLEDEVDAYS";
			}
		}
		public void Sil(string pCountryId)
		{
			dal.Sil( pCountryId);
		}
		public Countries SorgulaCOUNTRY_IDIle(string p1)
		{
			return dal.SorgulaCOUNTRY_IDIle(p1);
		}
	}
}
