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
    public partial class OrnekGuidPkTableDal : BaseDal<OrnekGuidPkTable>
    {

        protected override string SelectCountString
        {
            get 
			{ 
				return @"SELECT COUNT(*) FROM ORNEKLER.ORNEK_GUID_PK_TABLE";
			}
		}

        protected override string SelectString
        {
            get 
			{ 
				return @"SELECT  ID,Adi,Soyadi FROM ORNEKLER.ORNEK_GUID_PK_TABLE";
			}
        }

        protected override string DeleteString
        {
            get 
			{ 
				return @"DELETE   FROM ORNEKLER.ORNEK_GUID_PK_TABLE WHERE ID = @ID";
			}
        }
        protected override string UpdateString
        {
            get 
			{ 
				return @"UPDATE ORNEKLER.ORNEK_GUID_PK_TABLE SET 
				Adi = @Adi,Soyadi = @Soyadi
				WHERE ID = @ID ";
			}
        }

       protected override string InsertString
        {
            get 
			{ 
				return @"INSERT INTO ORNEKLER.ORNEK_GUID_PK_TABLE 
				   (ID,Adi,Soyadi) VALUES (@ID,@Adi,@Soyadi)";
			}
        }
		public List<OrnekGuidPkTable> SorgulaHepsiniGetir()
		{
			List<OrnekGuidPkTable> liste = new List<OrnekGuidPkTable>();
			SorguCalistir(liste);
            return liste;
		}
		public OrnekGuidPkTable SorgulaIDIle(Guid p1)
		{
			List<OrnekGuidPkTable> liste = new List<OrnekGuidPkTable>();
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
                return false;
            }
        }

		
 
        protected override bool PkGuidMi
        {
            get
            {
                return true;
            }
        }

		
        protected override void ProcessRow(System.Data.IDataReader dr, OrnekGuidPkTable row)
        {
		
					row.Id = dr.GetGuid(0);
					row.Adi = dr.GetString(1);
					row.Soyadi = dr.GetString(2);		
        }
        protected override void InsertCommandParametersAdd(SqlCommand cmd, OrnekGuidPkTable row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);

			builder.parameterEkle("@ID",SqlDbType.UniqueIdentifier, row.Id);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi,50);
			builder.parameterEkle("@Soyadi",SqlDbType.VarChar, row.Soyadi,50);
        }
        protected override void UpdateCommandParametersAdd(SqlCommand cmd, OrnekGuidPkTable row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@ID",SqlDbType.UniqueIdentifier, row.Id);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi,50);
			builder.parameterEkle("@Soyadi",SqlDbType.VarChar, row.Soyadi,50);
        }
        protected override void DeleteCommandParametersAdd(SqlCommand cmd, OrnekGuidPkTable row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@ID",SqlDbType.UniqueIdentifier, row.Id);
        }



    }
}
