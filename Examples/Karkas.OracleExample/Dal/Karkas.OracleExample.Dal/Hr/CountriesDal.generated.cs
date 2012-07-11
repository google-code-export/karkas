
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
public partial class CountriesDal : BaseDal<Countries>
{
	
	public override string DatabaseName
	{
		get
		{
			return "ORACLEDEVDAYS";
		}
	}
	protected override void identityKolonDegeriniSetle(Countries pTypeLibrary,long pIdentityKolonValue)
	{
	}
	protected override string SelectCountString
	{
		get
		{
			return @"SELECT COUNT(*) FROM HR.COUNTRIES";
		}
	}
	protected override string SelectString
	{
		get 
		{
			return @"SELECT COUNTRY_ID,COUNTRY_NAME,REGION_ID FROM HR.COUNTRIES";
		}
	}
	protected override string DeleteString
	{
		get 
		{
			return @"DELETE   FROM HR.COUNTRIES WHERE COUNTRY_ID = :COUNTRY_ID";
		}
	}
	protected override string UpdateString
	{
		get 
		{
			return @"UPDATE HR.COUNTRIES
			 SET 
			COUNTRY_NAME = :COUNTRY_NAME,REGION_ID = :REGION_ID			
			WHERE 
			 COUNTRY_ID = :COUNTRY_ID ";
		}
	}
	protected override string InsertString
	{
		get 
		{
			return @"INSERT INTO HR.COUNTRIES 
			 (COUNTRY_ID,COUNTRY_NAME,REGION_ID) 
			 VALUES 
						(:COUNTRY_ID,:COUNTRY_NAME,:REGION_ID)";
		}
	}
	public Countries SorgulaCOUNTRY_IDIle(string p1)
	{
		List<Countries> liste = new List<Countries>();
		SorguCalistir(liste,String.Format(" COUNTRY_ID = '{0}'", p1));		
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
			return "COUNTRY_ID";
		}
	}
	
	public virtual void Sil(string CountryId)
	{
		Countries row = new Countries();
		row.CountryId = CountryId;
		base.Sil(row);
	}
	protected override void ProcessRow(IDataReader dr, Countries row)
	{
		row.CountryId = dr.GetString(0);
		if (!dr.IsDBNull(1))
		{
			row.CountryName = dr.GetString(1);
		}
		if (!dr.IsDBNull(2))
		{
			row.RegionId = dr.GetDecimal(2);
		}
	}
	protected override void InsertCommandParametersAdd(DbCommand cmd, Countries row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle(":COUNTRY_ID",DbType.String, row.CountryId,2);
		builder.parameterEkle(":COUNTRY_NAME",DbType.String, row.CountryName,40);
		builder.parameterEkle(":REGION_ID",DbType.Decimal, row.RegionId);
	}
	protected override void UpdateCommandParametersAdd(DbCommand cmd, 	Countries	 row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle(":COUNTRY_ID",DbType.String, row.CountryId,2);
		builder.parameterEkle(":COUNTRY_NAME",DbType.String, row.CountryName,40);
		builder.parameterEkle(":REGION_ID",DbType.Decimal, row.RegionId);
	}
	protected override void DeleteCommandParametersAdd(DbCommand cmd, 	Countries	 row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle(":COUNTRY_ID",DbType.String, row.CountryId,2);
	}
}
}
