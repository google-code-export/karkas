
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
public partial class RegionsDal : BaseDal<Regions>
{
	
	public override string DatabaseName
	{
		get
		{
			return "ORACLEDEVDAYS";
		}
	}
	protected override void identityKolonDegeriniSetle(Regions pTypeLibrary,long pIdentityKolonValue)
	{
	}
	protected override string SelectCountString
	{
		get
		{
			return @"SELECT COUNT(*) FROM HR.REGIONS";
		}
	}
	protected override string SelectString
	{
		get 
		{
			return @"SELECT REGION_ID,REGION_NAME FROM HR.REGIONS";
		}
	}
	protected override string DeleteString
	{
		get 
		{
			return @"DELETE   FROM HR.REGIONS WHERE REGION_ID = :REGION_ID";
		}
	}
	protected override string UpdateString
	{
		get 
		{
			return @"UPDATE HR.REGIONS
			 SET 
			REGION_NAME = :REGION_NAME			
			WHERE 
			 REGION_ID = :REGION_ID ";
		}
	}
	protected override string InsertString
	{
		get 
		{
			return @"INSERT INTO HR.REGIONS 
			 (REGION_ID,REGION_NAME) 
			 VALUES 
						(:REGION_ID,:REGION_NAME)";
		}
	}
	public Regions SorgulaREGION_IDIle(decimal p1)
	{
		List<Regions> liste = new List<Regions>();
		SorguCalistir(liste,String.Format(" REGION_ID = '{0}'", p1));		
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
			return "REGION_ID";
		}
	}
	
	public virtual void Sil(decimal RegionId)
	{
		Regions row = new Regions();
		row.RegionId = RegionId;
		base.Sil(row);
	}
	protected override void ProcessRow(IDataReader dr, Regions row)
	{
		row.RegionId = dr.GetDecimal(0);
		if (!dr.IsDBNull(1))
		{
			row.RegionName = dr.GetString(1);
		}
	}
	protected override void InsertCommandParametersAdd(DbCommand cmd, Regions row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle(":REGION_ID",DbType.Decimal, row.RegionId);
		builder.parameterEkle(":REGION_NAME",DbType.String, row.RegionName,25);
	}
	protected override void UpdateCommandParametersAdd(DbCommand cmd, 	Regions	 row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle(":REGION_ID",DbType.Decimal, row.RegionId);
		builder.parameterEkle(":REGION_NAME",DbType.String, row.RegionName,25);
	}
	protected override void DeleteCommandParametersAdd(DbCommand cmd, 	Regions	 row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle(":REGION_ID",DbType.Decimal, row.RegionId);
	}
}
}
