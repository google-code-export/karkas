
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
public partial class JobHistoryDal : BaseDal<JobHistory>
{
	
	public override string DatabaseName
	{
		get
		{
			return "ORACLEDEVDAYS";
		}
	}
	protected override void identityKolonDegeriniSetle(JobHistory pTypeLibrary,long pIdentityKolonValue)
	{
	}
	protected override string SelectCountString
	{
		get
		{
			return @"SELECT COUNT(*) FROM HR.JOB_HISTORY";
		}
	}
	protected override string SelectString
	{
		get 
		{
			return @"SELECT EMPLOYEE_ID,START_DATE,END_DATE,JOB_ID,DEPARTMENT_ID FROM HR.JOB_HISTORY";
		}
	}
	protected override string DeleteString
	{
		get 
		{
			return @"DELETE   FROM HR.JOB_HISTORY WHERE EMPLOYEE_ID = @EMPLOYEE_ID ANDSTART_DATE = @START_DATE";
		}
	}
	protected override string UpdateString
	{
		get 
		{
			return @"UPDATE HR.JOB_HISTORY
			 SET 
			END_DATE = @END_DATE,JOB_ID = @JOB_ID,DEPARTMENT_ID = @DEPARTMENT_ID			
			WHERE 
			 EMPLOYEE_ID = @EMPLOYEE_ID AND START_DATE = @START_DATE ";
		}
	}
	protected override string InsertString
	{
		get 
		{
			return @"INSERT INTO HR.JOB_HISTORY 
			 (EMPLOYEE_ID,START_DATE,END_DATE,JOB_ID,DEPARTMENT_ID) 
			 VALUES 
						(@EMPLOYEE_ID,@START_DATE,@END_DATE,@JOB_ID,@DEPARTMENT_ID)";
		}
	}
	public JobHistory SorgulaSTART_DATEIle(DateTime p1)
	{
		List<JobHistory> liste = new List<JobHistory>();
		SorguCalistir(liste,String.Format(" START_DATE = '{0}'", p1));		
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
			return "START_DATE";
		}
	}
	
	protected override void ProcessRow(IDataReader dr, JobHistory row)
	{
		row.EmployeeId = dr.GetDecimal(0);
		row.StartDate = dr.GetDateTime(1);
		row.EndDate = dr.GetDateTime(2);
		row.JobId = dr.GetString(3);
		if (!dr.IsDBNull(4))
		{
			row.DepartmentId = dr.GetDecimal(4);
		}
	}
	protected override void InsertCommandParametersAdd(DbCommand cmd, JobHistory row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle("@EMPLOYEE_ID",SqlDbType.VarChar, row.EmployeeId);
		builder.parameterEkle("@START_DATE",SqlDbType.VarChar, row.StartDate);
		builder.parameterEkle("@END_DATE",SqlDbType.VarChar, row.EndDate);
		builder.parameterEkle("@JOB_ID",SqlDbType.VarChar, row.JobId,10);
		builder.parameterEkle("@DEPARTMENT_ID",SqlDbType.VarChar, row.DepartmentId);
	}
	protected override void UpdateCommandParametersAdd(DbCommand cmd, 	JobHistory	 row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle("@EMPLOYEE_ID",SqlDbType.VarChar, row.EmployeeId);
		builder.parameterEkle("@START_DATE",SqlDbType.VarChar, row.StartDate);
		builder.parameterEkle("@END_DATE",SqlDbType.VarChar, row.EndDate);
		builder.parameterEkle("@JOB_ID",SqlDbType.VarChar, row.JobId,10);
		builder.parameterEkle("@DEPARTMENT_ID",SqlDbType.VarChar, row.DepartmentId);
	}
	protected override void DeleteCommandParametersAdd(DbCommand cmd, 	JobHistory	 row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle("@EMPLOYEE_ID",SqlDbType.VarChar, row.EmployeeId);
		builder.parameterEkle("@START_DATE",SqlDbType.VarChar, row.StartDate);
	}
}
}
