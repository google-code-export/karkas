
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
	public partial class DepartmentsBs : BaseBs<Departments, DepartmentsDal>
	{
		public override string DatabaseName
		{
			get
			{
				return "ORACLEDEVDAYS";
			}
		}
		public void Sil(decimal pDepartmentId)
		{
			dal.Sil( pDepartmentId);
		}
		public Departments SorgulaDEPARTMENT_IDIle(decimal p1)
		{
			return dal.SorgulaDEPARTMENT_IDIle(p1);
		}
	}
}
