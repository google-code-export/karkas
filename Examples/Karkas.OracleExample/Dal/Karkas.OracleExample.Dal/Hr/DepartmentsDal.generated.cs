
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Karkas.Core.DataUtil;
using Karkas.OracleExample.TypeLibrary;
using Karkas.OracleExample.TypeLibrary.Hr;


namespace Karkas.OracleExample.Dal.Hr
{
public partial class DepartmentsDal : BaseDal<Departments>
{
	
	public override string DatabaseName
	{
		get
		{
			return "ORACLEDEVDAYS";
		}
	}
	protected override void identityKolonDegeriniSetle(Departments pTypeLibrary,long pIdentityKolonValue)
	{
	}
	protected override string SelectCountString
	{
		get
		{
			return @"SELECT COUNT(*) FROM HR.DEPARTMENTS";
		}
	}
	protected override string SelectString
	{
		get 
		{
			return @"SELECT DEPARTMENT_ID,DEPARTMENT_NAME,MANAGER_ID,LOCATION_ID FROM HR.DEPARTMENTS";
		}
	}
	protected override string DeleteString
	{
		get 
		{
			return @"DELETE   FROM HR.DEPARTMENTS WHERE DEPARTMENT_ID = @DEPARTMENT_ID";
		}
	}
	protected override string UpdateString
	{
		get 
		{
			return @"UPDATE HR.DEPARTMENTS
			 SET 
			DEPARTMENT_NAME = @DEPARTMENT_NAME,MANAGER_ID = @MANAGER_ID,LOCATION_ID = @LOCATION_ID			
			WHERE 
			 DEPARTMENT_ID = @DEPARTMENT_ID ";
		}
	}
	protected override string InsertString
	{
		get 
		{
			return @"INSERT INTO HR.DEPARTMENTS 
			 (DEPARTMENT_ID,DEPARTMENT_NAME,MANAGER_ID,LOCATION_ID) 
			 VALUES 
						(@DEPARTMENT_ID,@DEPARTMENT_NAME,@MANAGER_ID,@LOCATION_ID)";
		}
	}
	public Departments SorgulaDEPARTMENT_IDIle(decimal p1)
	{
		List<Departments> liste = new List<Departments>();
		SorguCalistir(liste,String.Format(" DEPARTMENT_ID = '{0}'", p1));		
		if (liste.Count > 0)
		{
			return liste[0];
		}
		else
		{
			return null;
		}
	}
	
	protected override bool IdentityVarMi
	{
		get
		{
			return false;
		}
	}
	
	protected override bool PkGuidMi
	{
		get
		{
			return false;
		}
	}
	
	
	public override string PrimaryKey
	{
		get
		{
			return "DEPARTMENT_ID";
		}
	}
	
	public virtual void Sil(decimal DepartmentId)
	{
		Departments row = new Departments();
		row.DepartmentId = DepartmentId;
		base.Sil(row);
	}
	protected override void ProcessRow(IDataReader dr, Departments row)
	{
		row.DepartmentId = dr.GetDecimal(0);
		row.DepartmentName = dr.GetString(1);
		if (!dr.IsDBNull(2))
		{
			row.ManagerId = dr.GetDecimal(2);
		}
		if (!dr.IsDBNull(3))
		{
			row.LocationId = dr.GetDecimal(3);
		}
	}
	protected override void InsertCommandParametersAdd(DbCommand cmd, Departments row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle("@DEPARTMENT_ID",SqlDbType.VarChar, row.DepartmentId);
		builder.parameterEkle("@DEPARTMENT_NAME",SqlDbType.VarChar, row.DepartmentName,30);
		builder.parameterEkle("@MANAGER_ID",SqlDbType.VarChar, row.ManagerId);
		builder.parameterEkle("@LOCATION_ID",SqlDbType.VarChar, row.LocationId);
	}
	protected override void UpdateCommandParametersAdd(DbCommand cmd, 	Departments	 row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle("@DEPARTMENT_ID",SqlDbType.VarChar, row.DepartmentId);
		builder.parameterEkle("@DEPARTMENT_NAME",SqlDbType.VarChar, row.DepartmentName,30);
		builder.parameterEkle("@MANAGER_ID",SqlDbType.VarChar, row.ManagerId);
		builder.parameterEkle("@LOCATION_ID",SqlDbType.VarChar, row.LocationId);
	}
	protected override void DeleteCommandParametersAdd(DbCommand cmd, 	Departments	 row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle("@DEPARTMENT_ID",SqlDbType.VarChar, row.DepartmentId);
	}
}
}
