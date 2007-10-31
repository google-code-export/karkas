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
    public partial class OrnekIdentityPkTableDal : BaseDalForIdentity<OrnekIdentityPkTable,int>
    {

        protected override string SelectCountString
        {
            get 
			{ 
				return @"SELECT COUNT(*) FROM ORNEKLER.ORNEK_IDENTITY_PK_TABLE";
			}
		}

        protected override string SelectString
        {
            get 
			{ 
				return @"SELECT  ID,Adi,Soyadi FROM ORNEKLER.ORNEK_IDENTITY_PK_TABLE";
			}
        }

        protected override string DeleteString
        {
            get 
			{ 
				return @"DELETE   FROM ORNEKLER.ORNEK_IDENTITY_PK_TABLE WHERE ID = @ID";
			}
        }
        protected override string UpdateString
        {
            get 
			{ 
				return @"UPDATE ORNEKLER.ORNEK_IDENTITY_PK_TABLE SET 
				Adi = @Adi,Soyadi = @Soyadi
				WHERE ID = @ID ";
			}
        }

       protected override string InsertString
        {
            get 
			{ 
				return @"INSERT INTO ORNEKLER.ORNEK_IDENTITY_PK_TABLE 
				   (Adi,Soyadi) VALUES (@Adi,@Soyadi);SELECT scope_identity();";
			}
        }
		public List<OrnekIdentityPkTable> SorgulaHepsiniGetir()
		{
			List<OrnekIdentityPkTable> liste = new List<OrnekIdentityPkTable>();
			SorguCalistir(liste);
            return liste;
		}
		public OrnekIdentityPkTable SorgulaIDIle(int p1)
		{
			List<OrnekIdentityPkTable> liste = new List<OrnekIdentityPkTable>();
			SorguCalistir(liste,String.Format(" ID = '{0}'", p1));

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
                return false;
            }
        }

		
        protected override void ProcessRow(System.Data.IDataReader dr, OrnekIdentityPkTable row)
        {
		
					row.Id = dr.GetInt32(0);
					row.Adi = dr.GetString(1);
					row.Soyadi = dr.GetString(2);		
        }
        protected override void InsertCommandParametersAdd(SqlCommand cmd, OrnekIdentityPkTable row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);

			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi,50);
			builder.parameterEkle("@Soyadi",SqlDbType.VarChar, row.Soyadi,50);
        }
        protected override void UpdateCommandParametersAdd(SqlCommand cmd, OrnekIdentityPkTable row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@ID",SqlDbType.Int, row.Id);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi,50);
			builder.parameterEkle("@Soyadi",SqlDbType.VarChar, row.Soyadi,50);
        }
        protected override void DeleteCommandParametersAdd(SqlCommand cmd, OrnekIdentityPkTable row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@ID",SqlDbType.Int, row.Id);
        }



    }
}
