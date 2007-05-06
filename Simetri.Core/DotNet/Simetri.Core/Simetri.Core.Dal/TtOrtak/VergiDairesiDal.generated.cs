using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Simetri.Core.DataUtil;
using Simetri.Core.TypeLibrary;
using Simetri.Core.TypeLibrary.TtOrtak;


namespace Simetri.Core.Dal.TtOrtak
{
    public partial class VergiDairesiDal : BaseDal<VergiDairesi,int>
    {


        protected override string SelectString
        {
            get 
			{ 
				return @"SELECT  TipNo,Adi FROM TT_ORTAK.VERGI_DAIRESI";
			}
        }

        protected override string DeleteString
        {
            get 
			{ 
				return @"DELETE   FROM TT_ORTAK.VERGI_DAIRESI WHERE TipNo = @TipNo";
			}
        }
        protected override string UpdateString
        {
            get 
			{ 
				return @"UPDATE TT_ORTAK.VERGI_DAIRESI SET 
				Adi = @Adi
				WHERE TipNo = @TipNo ";
			}
        }

       protected override string InsertString
        {
            get 
			{ 
				return @"INSERT INTO TT_ORTAK.VERGI_DAIRESI 
				   (Adi) VALUES (@Adi);SELECT scope_identity();";
			}
        }
		public List<VergiDairesi> SorgulaHepsiniGetir()
		{
			List<VergiDairesi> liste = new List<VergiDairesi>();
			SorguCalistir(liste);
            return liste;
		}
		public VergiDairesi SorgulaTipNoIle(int p1)
		{
			List<VergiDairesi> liste = new List<VergiDairesi>();
			SorguCalistir(liste," TipNo = " + p1);

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

		
        protected override void ProcessRow(System.Data.IDataReader dr, VergiDairesi row)
        {
		
					row.TipNo = dr.GetInt32(0);
					row.Adi = dr.GetString(1);		
        }
        protected override void InsertCommandParametersAdd(SqlCommand cmd, VergiDairesi row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);

			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi);
        }
        protected override void UpdateCommandParametersAdd(SqlCommand cmd, VergiDairesi row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@TipNo",SqlDbType.Int, row.TipNo);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi);
        }
        protected override void DeleteCommandParametersAdd(SqlCommand cmd, VergiDairesi row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@TipNo",SqlDbType.Int, row.TipNo);
        }



    }
}
