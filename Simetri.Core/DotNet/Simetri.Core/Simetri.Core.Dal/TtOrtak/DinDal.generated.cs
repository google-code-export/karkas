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
    public partial class DinDal : BaseDal<Din,byte>
    {


        protected override string SelectString
        {
            get 
			{ 
				return @"SELECT  No,Adi,AktifMi FROM TT_ORTAK.DIN";
			}
        }

        protected override string DeleteString
        {
            get 
			{ 
				return @"DELETE   FROM TT_ORTAK.DIN WHERE No = @No";
			}
        }
        protected override string UpdateString
        {
            get 
			{ 
				return @"UPDATE TT_ORTAK.DIN SET 
				Adi = @Adi,AktifMi = @AktifMi
				WHERE No = @No ";
			}
        }

       protected override string InsertString
        {
            get 
			{ 
				return @"INSERT INTO TT_ORTAK.DIN 
				   (Adi,AktifMi) VALUES (@Adi,@AktifMi);SELECT scope_identity();";
			}
        }
		public List<Din> SorgulaHepsiniGetir()
		{
			List<Din> liste = new List<Din>();
			SorguCalistir(liste);
            return liste;
		}
		public Din SorgulaNoIle(byte p1)
		{
			List<Din> liste = new List<Din>();
			SorguCalistir(liste," No = " + p1);

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

		
        protected override void ProcessRow(System.Data.IDataReader dr, Din row)
        {
		
					row.No = dr.GetByte(0);
					row.Adi = dr.GetString(1);
					if (!dr.IsDBNull(2))
					{
						row.AktifMi = dr.GetBoolean(2);
					}
							
        }
        protected override void InsertCommandParametersAdd(SqlCommand cmd, Din row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);

			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi);
			builder.parameterEkle("@AktifMi",SqlDbType.Bit, row.AktifMi);
        }
        protected override void UpdateCommandParametersAdd(SqlCommand cmd, Din row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@No",SqlDbType.TinyInt, row.No);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi);
			builder.parameterEkle("@AktifMi",SqlDbType.Bit, row.AktifMi);
        }
        protected override void DeleteCommandParametersAdd(SqlCommand cmd, Din row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@No",SqlDbType.TinyInt, row.No);
        }



    }
}
