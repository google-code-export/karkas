using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Simetri.Core.DataUtil;
using Simetri.Core.TypeLibrary;
using Simetri.Core.TypeLibrary.Ornekler;


namespace Simetri.Core.Dal.Ornekler
{
    public partial class OrnekGuidPkIdentityColumnTableDal : BaseDalForIdentity<OrnekGuidPkIdentityColumnTable,int>
    {

        protected override string SelectCountString
        {
            get 
			{ 
				return @"SELECT COUNT(*) FROM ORNEKLER.ORNEK_GUID_PK_IDENTITY_COLUMN_TABLE";
			}
		}

        protected override string SelectString
        {
            get 
			{ 
				return @"SELECT  GuidPK,IdentityColumn,Adi,Soyadi FROM ORNEKLER.ORNEK_GUID_PK_IDENTITY_COLUMN_TABLE";
			}
        }

        protected override string DeleteString
        {
            get 
			{ 
				return @"DELETE   FROM ORNEKLER.ORNEK_GUID_PK_IDENTITY_COLUMN_TABLE WHERE GuidPK = @GuidPK";
			}
        }
        protected override string UpdateString
        {
            get 
			{ 
				return @"UPDATE ORNEKLER.ORNEK_GUID_PK_IDENTITY_COLUMN_TABLE SET 
				IdentityColumn = @IdentityColumn,Adi = @Adi,Soyadi = @Soyadi
				WHERE GuidPK = @GuidPK ";
			}
        }

       protected override string InsertString
        {
            get 
			{ 
				return @"INSERT INTO ORNEKLER.ORNEK_GUID_PK_IDENTITY_COLUMN_TABLE 
				   (GuidPK,Adi,Soyadi) VALUES (@GuidPK,@Adi,@Soyadi);SELECT scope_identity();";
			}
        }
		public List<OrnekGuidPkIdentityColumnTable> SorgulaHepsiniGetir()
		{
			List<OrnekGuidPkIdentityColumnTable> liste = new List<OrnekGuidPkIdentityColumnTable>();
			SorguCalistir(liste);
            return liste;
		}
		public OrnekGuidPkIdentityColumnTable SorgulaGuidPKIle(Guid p1)
		{
			List<OrnekGuidPkIdentityColumnTable> liste = new List<OrnekGuidPkIdentityColumnTable>();
			SorguCalistir(liste,String.Format(" GuidPK = '{0}'", p1));

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

		
        protected override void ProcessRow(System.Data.IDataReader dr, OrnekGuidPkIdentityColumnTable row)
        {
		
					row.GuidPK = dr.GetGuid(0);
					row.IdentityColumn = dr.GetInt32(1);
					row.Adi = dr.GetString(2);
					row.Soyadi = dr.GetString(3);		
        }
        protected override void InsertCommandParametersAdd(SqlCommand cmd, OrnekGuidPkIdentityColumnTable row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);

			builder.parameterEkle("@GuidPK",SqlDbType.UniqueIdentifier, row.GuidPK);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi,50);
			builder.parameterEkle("@Soyadi",SqlDbType.VarChar, row.Soyadi,50);
        }
        protected override void UpdateCommandParametersAdd(SqlCommand cmd, OrnekGuidPkIdentityColumnTable row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@GuidPK",SqlDbType.UniqueIdentifier, row.GuidPK);
			builder.parameterEkle("@IdentityColumn",SqlDbType.Int, row.IdentityColumn);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi,50);
			builder.parameterEkle("@Soyadi",SqlDbType.VarChar, row.Soyadi,50);
        }
        protected override void DeleteCommandParametersAdd(SqlCommand cmd, OrnekGuidPkIdentityColumnTable row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@GuidPK",SqlDbType.UniqueIdentifier, row.GuidPK);
        }



    }
}
