
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
	public partial class LocationsBs : BaseBs<Locations, LocationsDal>
	{
		public override string DatabaseName
		{
			get
			{
				return "ORACLEDEVDAYS";
			}
		}
		public void Sil(decimal pLocationId)
		{
			dal.Sil( pLocationId);
		}
		public Locations SorgulaLOCATION_IDIle(decimal p1)
		{
			return dal.SorgulaLOCATION_IDIle(p1);
		}
	}
}
