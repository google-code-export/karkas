
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
public partial class LocationsDal : BaseDal<Locations>
{
	
	public override string DatabaseName
	{
		get
		{
			return "ORACLEDEVDAYS";
		}
	}
	protected override void identityKolonDegeriniSetle(Locations pTypeLibrary,long pIdentityKolonValue)
	{
	}
	protected override string SelectCountString
	{
		get
		{
			return @"SELECT COUNT(*) FROM HR.LOCATIONS";
		}
	}
	protected override string SelectString
	{
		get 
		{
			return @"SELECT LOCATION_ID,STREET_ADDRESS,POSTAL_CODE,CITY,STATE_PROVINCE,COUNTRY_ID FROM HR.LOCATIONS";
		}
	}
	protected override string DeleteString
	{
		get 
		{
			return @"DELETE   FROM HR.LOCATIONS WHERE LOCATION_ID = @LOCATION_ID";
		}
	}
	protected override string UpdateString
	{
		get 
		{
			return @"UPDATE HR.LOCATIONS
			 SET 
			STREET_ADDRESS = @STREET_ADDRESS,POSTAL_CODE = @POSTAL_CODE,CITY = @CITY,STATE_PROVINCE = @STATE_PROVINCE,COUNTRY_ID = @COUNTRY_ID			
			WHERE 
			 LOCATION_ID = @LOCATION_ID ";
		}
	}
	protected override string InsertString
	{
		get 
		{
			return @"INSERT INTO HR.LOCATIONS 
			 (LOCATION_ID,STREET_ADDRESS,POSTAL_CODE,CITY,STATE_PROVINCE,COUNTRY_ID) 
			 VALUES 
						(@LOCATION_ID,@STREET_ADDRESS,@POSTAL_CODE,@CITY,@STATE_PROVINCE,@COUNTRY_ID)";
		}
	}
	public Locations SorgulaLOCATION_IDIle(decimal p1)
	{
		List<Locations> liste = new List<Locations>();
		SorguCalistir(liste,String.Format(" LOCATION_ID = '{0}'", p1));		
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
			return "LOCATION_ID";
		}
	}
	
	public virtual void Sil(decimal LocationId)
	{
		Locations row = new Locations();
		row.LocationId = LocationId;
		base.Sil(row);
	}
	protected override void ProcessRow(IDataReader dr, Locations row)
	{
		row.LocationId = dr.GetDecimal(0);
		if (!dr.IsDBNull(1))
		{
			row.StreetAddress = dr.GetString(1);
		}
		if (!dr.IsDBNull(2))
		{
			row.PostalCode = dr.GetString(2);
		}
		row.City = dr.GetString(3);
		if (!dr.IsDBNull(4))
		{
			row.StateProvince = dr.GetString(4);
		}
		if (!dr.IsDBNull(5))
		{
			row.CountryId = dr.GetString(5);
		}
	}
	protected override void InsertCommandParametersAdd(DbCommand cmd, Locations row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle("@LOCATION_ID",SqlDbType.VarChar, row.LocationId);
		builder.parameterEkle("@STREET_ADDRESS",SqlDbType.VarChar, row.StreetAddress,40);
		builder.parameterEkle("@POSTAL_CODE",SqlDbType.VarChar, row.PostalCode,12);
		builder.parameterEkle("@CITY",SqlDbType.VarChar, row.City,30);
		builder.parameterEkle("@STATE_PROVINCE",SqlDbType.VarChar, row.StateProvince,25);
		builder.parameterEkle("@COUNTRY_ID",SqlDbType.VarChar, row.CountryId,2);
	}
	protected override void UpdateCommandParametersAdd(DbCommand cmd, 	Locations	 row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle("@LOCATION_ID",SqlDbType.VarChar, row.LocationId);
		builder.parameterEkle("@STREET_ADDRESS",SqlDbType.VarChar, row.StreetAddress,40);
		builder.parameterEkle("@POSTAL_CODE",SqlDbType.VarChar, row.PostalCode,12);
		builder.parameterEkle("@CITY",SqlDbType.VarChar, row.City,30);
		builder.parameterEkle("@STATE_PROVINCE",SqlDbType.VarChar, row.StateProvince,25);
		builder.parameterEkle("@COUNTRY_ID",SqlDbType.VarChar, row.CountryId,2);
	}
	protected override void DeleteCommandParametersAdd(DbCommand cmd, 	Locations	 row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle("@LOCATION_ID",SqlDbType.VarChar, row.LocationId);
	}
}
}
