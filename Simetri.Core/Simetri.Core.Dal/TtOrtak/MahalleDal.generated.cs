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
    public partial class MahalleDal : BaseDal<Mahalle,int>
    {


        protected override string SelectString
        {
            get 
			{ 
				return @"SELECT  ID,IlceKey,Adi,AktifMi FROM TT_ORTAK.MAHALLE";
			}
        }

        protected override string DeleteString
        {
            get 
			{ 
				return @"DELETE   FROM TT_ORTAK.MAHALLE WHERE ID = @ID";
			}
        }
        protected override string UpdateString
        {
            get 
			{ 
				return @"UPDATE TT_ORTAK.MAHALLE SET 
				IlceKey = @IlceKey,Adi = @Adi,AktifMi = @AktifMi
				WHERE ID = @ID ";
			}
        }

       protected override string InsertString
        {
            get 
			{ 
				return @"INSERT INTO TT_ORTAK.MAHALLE 
				   (ID,IlceKey,Adi,AktifMi) VALUES (@ID,@IlceKey,@Adi,@AktifMi)";
			}
        }
		public List<Mahalle> SorgulaHepsiniGetir()
		{
			List<Mahalle> liste = new List<Mahalle>();
			SorguCalistir(liste);
            return liste;
		}
		public Mahalle SorgulaIDIle(int p1)
		{
			List<Mahalle> liste = new List<Mahalle>();
			SorguCalistir(liste," ID = " + p1);

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

		
        protected override void ProcessRow(System.Data.IDataReader dr, Mahalle row)
        {
		
					row.Id = dr.GetInt32(0);
					row.IlceKey = dr.GetInt32(1);
					row.Adi = dr.GetString(2);
					row.AktifMi = dr.GetBoolean(3);		
        }
        protected override void InsertCommandParametersAdd(SqlCommand cmd, Mahalle row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);

			builder.parameterEkle("@ID",SqlDbType.Int, row.Id);
			builder.parameterEkle("@IlceKey",SqlDbType.Int, row.IlceKey);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi);
			builder.parameterEkle("@AktifMi",SqlDbType.Bit, row.AktifMi);
        }
        protected override void UpdateCommandParametersAdd(SqlCommand cmd, Mahalle row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@ID",SqlDbType.Int, row.Id);
			builder.parameterEkle("@IlceKey",SqlDbType.Int, row.IlceKey);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi);
			builder.parameterEkle("@AktifMi",SqlDbType.Bit, row.AktifMi);
        }
        protected override void DeleteCommandParametersAdd(SqlCommand cmd, Mahalle row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@ID",SqlDbType.Int, row.Id);
        }



    }
}
