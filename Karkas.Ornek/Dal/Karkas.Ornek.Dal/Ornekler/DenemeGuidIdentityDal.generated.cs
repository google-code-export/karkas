using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Karkas.Core.DataUtil;
using Karkas.Ornek.TypeLibrary;
using Karkas.Ornek.TypeLibrary.Ornekler;


namespace Karkas.Ornek.Dal.Ornekler
{
	public partial class DenemeGuidIdentityDal : BaseDalForIdentity<DenemeGuidIdentity,int>
	{
		
		public override string DatabaseName
		{
			get
			{
				return "KARKAS_ORNEK";
			}
		}
		protected override void identityKolonDegeriniSetle(DenemeGuidIdentity pTypeLibrary,int pIdentityKolonValue)
		{
			pTypeLibrary.DenemeNo = pIdentityKolonValue;
		}
		protected override string SelectCountString
		{
			get
			{
				return @"SELECT COUNT(*) FROM ORNEKLER.DENEME_GUID_IDENTITY";
			}
		}
		protected override string SelectString
		{
			get 
			{
				return @"SELECT DenemeKey,DenemeNo,DenemeKolon FROM ORNEKLER.DENEME_GUID_IDENTITY";
			}
		}
		protected override string DeleteString
		{
			get 
			{
				return @"DELETE   FROM ORNEKLER.DENEME_GUID_IDENTITY WHERE DenemeKey = @DenemeKey";
			}
		}
		protected override string UpdateString
		{
			get 
			{
				return @"UPDATE ORNEKLER.DENEME_GUID_IDENTITY
				 SET 
				DenemeNo = @DenemeNo,DenemeKolon = @DenemeKolon				
				WHERE 
				DenemeKey = @DenemeKey ";
			}
		}
		protected override string InsertString
		{
			get 
			{
				return @"INSERT INTO ORNEKLER.DENEME_GUID_IDENTITY 
				 (DenemeKey,DenemeKolon) 
				 VALUES 
								(@DenemeKey,@DenemeKolon);SELECT scope_identity();";
			}
		}
		public List<DenemeGuidIdentity>SorgulaHepsiniGetir()
		{
			List<DenemeGuidIdentity> liste = new List<DenemeGuidIdentity>();
			SorguCalistir(liste);
			return liste;
		}
		public DenemeGuidIdentity SorgulaDenemeKeyIle(Guid p1)
		{
			List<DenemeGuidIdentity> liste = new List<DenemeGuidIdentity>();
			SorguCalistir(liste,String.Format(" DenemeKey = '{0}'", p1));			
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
				return true;
			}
		}
		
		protected override bool PkGuidMi
		{
			get
			{
				return true;
			}
		}
		
		protected override void ProcessRow(System.Data.IDataReader dr, DenemeGuidIdentity row)
		{
			row.DenemeKey = dr.GetGuid(0);
			row.DenemeNo = dr.GetInt32(1);
			row.DenemeKolon = dr.GetString(2);
		}
		protected override void InsertCommandParametersAdd(SqlCommand cmd, DenemeGuidIdentity row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@DenemeKey",SqlDbType.UniqueIdentifier, row.DenemeKey);
			builder.parameterEkle("@DenemeKolon",SqlDbType.VarChar, row.DenemeKolon,50);
		}
		protected override void UpdateCommandParametersAdd(SqlCommand cmd, 		DenemeGuidIdentity		 row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@DenemeKey",SqlDbType.UniqueIdentifier, row.DenemeKey);
			builder.parameterEkle("@DenemeNo",SqlDbType.Int, row.DenemeNo);
			builder.parameterEkle("@DenemeKolon",SqlDbType.VarChar, row.DenemeKolon,50);
		}
		protected override void DeleteCommandParametersAdd(SqlCommand cmd, 		DenemeGuidIdentity		 row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@DenemeKey",SqlDbType.UniqueIdentifier, row.DenemeKey);
		}
	}
}