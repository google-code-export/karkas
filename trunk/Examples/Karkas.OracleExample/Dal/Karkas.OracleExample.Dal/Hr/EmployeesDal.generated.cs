
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
public partial class EmployeesDal : BaseDal<Employees>
{
	
	public override string DatabaseName
	{
		get
		{
			return "ORACLEDEVDAYS";
		}
	}
	protected override void identityKolonDegeriniSetle(Employees pTypeLibrary,long pIdentityKolonValue)
	{
	}
	protected override string SelectCountString
	{
		get
		{
			return @"SELECT COUNT(*) FROM HR.EMPLOYEES";
		}
	}
	protected override string SelectString
	{
		get 
		{
			return @"SELECT FULL_NAME,EMPLOYEE_ID,FIRST_NAME,LAST_NAME,EMAIL,PHONE_NUMBER,HIRE_DATE,JOB_ID,SALARY,COMMISSION_PCT,MANAGER_ID,DEPARTMENT_ID FROM HR.EMPLOYEES";
		}
	}
	protected override string DeleteString
	{
		get 
		{
			return @"DELETE   FROM HR.EMPLOYEES WHERE EMPLOYEE_ID = @EMPLOYEE_ID";
		}
	}
	protected override string UpdateString
	{
		get 
		{
			return @"UPDATE HR.EMPLOYEES
			 SET 
			FIRST_NAME = @FIRST_NAME,LAST_NAME = @LAST_NAME,EMAIL = @EMAIL,PHONE_NUMBER = @PHONE_NUMBER,HIRE_DATE = @HIRE_DATE,JOB_ID = @JOB_ID,SALARY = @SALARY,COMMISSION_PCT = @COMMISSION_PCT,MANAGER_ID = @MANAGER_ID,DEPARTMENT_ID = @DEPARTMENT_ID			
			WHERE 
			 EMPLOYEE_ID = @EMPLOYEE_ID ";
		}
	}
	protected override string InsertString
	{
		get 
		{
			return @"INSERT INTO HR.EMPLOYEES 
			 (EMPLOYEE_ID,FIRST_NAME,LAST_NAME,EMAIL,PHONE_NUMBER,HIRE_DATE,JOB_ID,SALARY,COMMISSION_PCT,MANAGER_ID,DEPARTMENT_ID) 
			 VALUES 
						(@EMPLOYEE_ID,@FIRST_NAME,@LAST_NAME,@EMAIL,@PHONE_NUMBER,@HIRE_DATE,@JOB_ID,@SALARY,@COMMISSION_PCT,@MANAGER_ID,@DEPARTMENT_ID)";
		}
	}
	public Employees SorgulaEMPLOYEE_IDIle(decimal p1)
	{
		List<Employees> liste = new List<Employees>();
		SorguCalistir(liste,String.Format(" EMPLOYEE_ID = '{0}'", p1));		
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
			return "EMPLOYEE_ID";
		}
	}
	
	public virtual void Sil(decimal EmployeeId)
	{
		Employees row = new Employees();
		row.EmployeeId = EmployeeId;
		base.Sil(row);
	}
	protected override void ProcessRow(IDataReader dr, Employees row)
	{
		if (!dr.IsDBNull(0))
		{
			row.FullName = dr.GetString(0);
		}
		row.EmployeeId = dr.GetDecimal(1);
		if (!dr.IsDBNull(2))
		{
			row.FirstName = dr.GetString(2);
		}
		row.LastName = dr.GetString(3);
		row.Email = dr.GetString(4);
		if (!dr.IsDBNull(5))
		{
			row.PhoneNumber = dr.GetString(5);
		}
		row.HireDate = dr.GetDateTime(6);
		row.JobId = dr.GetString(7);
		if (!dr.IsDBNull(8))
		{
			row.Salary = dr.GetDecimal(8);
		}
		if (!dr.IsDBNull(9))
		{
			row.CommissionPct = dr.GetDecimal(9);
		}
		if (!dr.IsDBNull(10))
		{
			row.ManagerId = dr.GetDecimal(10);
		}
		if (!dr.IsDBNull(11))
		{
			row.DepartmentId = dr.GetDecimal(11);
		}
	}
	protected override void InsertCommandParametersAdd(DbCommand cmd, Employees row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle("@EMPLOYEE_ID",SqlDbType.VarChar, row.EmployeeId);
		builder.parameterEkle("@FIRST_NAME",SqlDbType.VarChar, row.FirstName,20);
		builder.parameterEkle("@LAST_NAME",SqlDbType.VarChar, row.LastName,25);
		builder.parameterEkle("@EMAIL",SqlDbType.VarChar, row.Email,25);
		builder.parameterEkle("@PHONE_NUMBER",SqlDbType.VarChar, row.PhoneNumber,20);
		builder.parameterEkle("@HIRE_DATE",SqlDbType.VarChar, row.HireDate);
		builder.parameterEkle("@JOB_ID",SqlDbType.VarChar, row.JobId,10);
		builder.parameterEkle("@SALARY",SqlDbType.VarChar, row.Salary);
		builder.parameterEkle("@COMMISSION_PCT",SqlDbType.VarChar, row.CommissionPct);
		builder.parameterEkle("@MANAGER_ID",SqlDbType.VarChar, row.ManagerId);
		builder.parameterEkle("@DEPARTMENT_ID",SqlDbType.VarChar, row.DepartmentId);
	}
	protected override void UpdateCommandParametersAdd(DbCommand cmd, 	Employees	 row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle("@EMPLOYEE_ID",SqlDbType.VarChar, row.EmployeeId);
		builder.parameterEkle("@FIRST_NAME",SqlDbType.VarChar, row.FirstName,20);
		builder.parameterEkle("@LAST_NAME",SqlDbType.VarChar, row.LastName,25);
		builder.parameterEkle("@EMAIL",SqlDbType.VarChar, row.Email,25);
		builder.parameterEkle("@PHONE_NUMBER",SqlDbType.VarChar, row.PhoneNumber,20);
		builder.parameterEkle("@HIRE_DATE",SqlDbType.VarChar, row.HireDate);
		builder.parameterEkle("@JOB_ID",SqlDbType.VarChar, row.JobId,10);
		builder.parameterEkle("@SALARY",SqlDbType.VarChar, row.Salary);
		builder.parameterEkle("@COMMISSION_PCT",SqlDbType.VarChar, row.CommissionPct);
		builder.parameterEkle("@MANAGER_ID",SqlDbType.VarChar, row.ManagerId);
		builder.parameterEkle("@DEPARTMENT_ID",SqlDbType.VarChar, row.DepartmentId);
	}
	protected override void DeleteCommandParametersAdd(DbCommand cmd, 	Employees	 row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle("@EMPLOYEE_ID",SqlDbType.VarChar, row.EmployeeId);
	}
}
}
