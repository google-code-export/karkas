
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
	public partial class RegionsBs : BaseBs<Regions, RegionsDal>
	{
		public override string DatabaseName
		{
			get
			{
				return "ORACLEDEVDAYS";
			}
		}
		public void Sil(decimal pRegionId)
		{
			dal.Sil( pRegionId);
		}
		public Regions SorgulaREGION_IDIle(decimal p1)
		{
			return dal.SorgulaREGION_IDIle(p1);
		}
	}
}
