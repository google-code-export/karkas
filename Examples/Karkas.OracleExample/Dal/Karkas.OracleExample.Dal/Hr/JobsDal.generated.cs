
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
public partial class JobsDal : BaseDal<Jobs>
{
	
	public override string DatabaseName
	{
		get
		{
			return "ORACLEDEVDAYS";
		}
	}
	protected override void identityKolonDegeriniSetle(Jobs pTypeLibrary,long pIdentityKolonValue)
	{
	}
	protected override string SelectCountString
	{
		get
		{
			return @"SELECT COUNT(*) FROM HR.JOBS";
		}
	}
	protected override string SelectString
	{
		get 
		{
			return @"SELECT JOB_ID,JOB_TITLE,MIN_SALARY,MAX_SALARY FROM HR.JOBS";
		}
	}
	protected override string DeleteString
	{
		get 
		{
			return @"DELETE   FROM HR.JOBS WHERE JOB_ID = :JOB_ID";
		}
	}
	protected override string UpdateString
	{
		get 
		{
			return @"UPDATE HR.JOBS
			 SET 
			JOB_TITLE = :JOB_TITLE,MIN_SALARY = :MIN_SALARY,MAX_SALARY = :MAX_SALARY			
			WHERE 
			 JOB_ID = :JOB_ID ";
		}
	}
	protected override string InsertString
	{
		get 
		{
			return @"INSERT INTO HR.JOBS 
			 (JOB_ID,JOB_TITLE,MIN_SALARY,MAX_SALARY) 
			 VALUES 
						(:JOB_ID,:JOB_TITLE,:MIN_SALARY,:MAX_SALARY)";
		}
	}
	public Jobs SorgulaJOB_IDIle(string p1)
	{
		List<Jobs> liste = new List<Jobs>();
		SorguCalistir(liste,String.Format(" JOB_ID = '{0}'", p1));		
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
			return "JOB_ID";
		}
	}
	
	public virtual void Sil(string JobId)
	{
		Jobs row = new Jobs();
		row.JobId = JobId;
		base.Sil(row);
	}
	protected override void ProcessRow(IDataReader dr, Jobs row)
	{
		row.JobId = dr.GetString(0);
		row.JobTitle = dr.GetString(1);
		if (!dr.IsDBNull(2))
		{
			row.MinSalary = dr.GetDecimal(2);
		}
		if (!dr.IsDBNull(3))
		{
			row.MaxSalary = dr.GetDecimal(3);
		}
	}
	protected override void InsertCommandParametersAdd(DbCommand cmd, Jobs row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle(":JOB_ID",DbType.String, row.JobId,10);
		builder.parameterEkle(":JOB_TITLE",DbType.String, row.JobTitle,35);
		builder.parameterEkle(":MIN_SALARY",DbType.Decimal, row.MinSalary);
		builder.parameterEkle(":MAX_SALARY",DbType.Decimal, row.MaxSalary);
	}
	protected override void UpdateCommandParametersAdd(DbCommand cmd, 	Jobs	 row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle(":JOB_ID",DbType.String, row.JobId,10);
		builder.parameterEkle(":JOB_TITLE",DbType.String, row.JobTitle,35);
		builder.parameterEkle(":MIN_SALARY",DbType.Decimal, row.MinSalary);
		builder.parameterEkle(":MAX_SALARY",DbType.Decimal, row.MaxSalary);
	}
	protected override void DeleteCommandParametersAdd(DbCommand cmd, 	Jobs	 row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle(":JOB_ID",DbType.String, row.JobId,10);
	}
}
}
